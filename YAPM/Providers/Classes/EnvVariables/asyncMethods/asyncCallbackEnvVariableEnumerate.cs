using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackEnvVariableEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cEnvVariableConnection con;
    private int _instanceId;
    public asyncCallbackEnvVariableEnumerate(ref Control ctr, Delegate de, ref cEnvVariableConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int pid;
        public IntPtr peb;
        public int forInstanceId;
        public poolObj(int pi, IntPtr add, int ii)
        {
            forInstanceId = ii;
            peb = add;
            pid = pi;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, envVariableInfos> dico = new Dictionary<string, envVariableInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (envVariableInfos)lst[x]);
        }
        if (deg != null && ctrl.Created)
            ctrl.Invoke(deg, true, dico, null, _instanceId);
    }
    private static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
    public void Process(object thePoolObj)
    {
        sem.WaitOne();

        poolObj pObj = (poolObj)thePoolObj;
        if (con.ConnectionObj.IsConnected == false)
        {
            sem.Release();
            return;
        }

        switch (con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    _poolObj = pObj;
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestEnvironmentVariableList, pObj.pid, Native.Api.NativeConstants.InvalidHandleValue);
                        cDat.InstanceId = _instanceId;   // Instance which request the list
                        con.ConnectionObj.Socket.Send(cDat);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Unable to send request to server");
                    }

                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    // Snapshot

                    Dictionary<string, envVariableInfos> _dico = new Dictionary<string, envVariableInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.EnvironnementVariablesByProcessId(pObj.pid);
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }

            default:
                {
                    // Local
                    Dictionary<string, envVariableInfos> _dico = SharedLocalSyncEnumerate(pObj);

                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }
        }

        sem.Release();
    }


    // Shared, local and sync enumeration
    public static Dictionary<string, envVariableInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, envVariableInfos> _dico = new Dictionary<string, envVariableInfos>();

        string[] var = null;
        string[] val = null;
        Native.Objects.EnvVariable.GetEnvironmentVariables(pObj.peb, pObj.pid, ref var, ref val);
        var loopTo = var.Length - 1;
        for (int x = 0; x <= loopTo; x++)
        {
            if (_dico.ContainsKey(var[x]) == false)
                _dico.Add(var[x], new envVariableInfos(var[x], val[x], pObj.pid));
        }

        return _dico;
    }
}

