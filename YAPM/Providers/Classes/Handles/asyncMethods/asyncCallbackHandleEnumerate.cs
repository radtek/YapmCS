using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackHandleEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cHandleConnection con;
    private int _instanceId;
    public asyncCallbackHandleEnumerate(ref Control ctr, Delegate de, ref cHandleConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int pid;
        public bool unNamed;
        public int forInstanceId;
        public poolObj(int pi, bool unN, int iid)
        {
            forInstanceId = iid;
            pid = pi;
            unNamed = unN;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, handleInfos> dico = new Dictionary<string, handleInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (handleInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestHandleList, pObj.pid, pObj.unNamed);
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

                    Dictionary<string, handleInfos> _dico = new Dictionary<string, handleInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        // For some processes only
                        _dico = snap.HandlesByProcessId(pObj.pid);
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
                    Dictionary<string, handleInfos> _dico = new Dictionary<string, handleInfos>();

                    Native.Objects.Handle.EnumerateHandleByProcessId(pObj.pid, pObj.unNamed, ref _dico);

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
    public static Dictionary<string, handleInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, handleInfos> _dico = new Dictionary<string, handleInfos>();
        Native.Objects.Handle.EnumerateHandleByProcessId(pObj.pid, pObj.unNamed, ref _dico);
        return _dico;
    }
}

