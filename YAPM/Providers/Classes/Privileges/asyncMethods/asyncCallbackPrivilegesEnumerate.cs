using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackPrivilegesEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cPrivilegeConnection con;
    private int _instanceId;
    public asyncCallbackPrivilegesEnumerate(ref Control ctr, Delegate de, ref cPrivilegeConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int pid;
        public int forInstanceId;
        public poolObj(int pi, int ii)
        {
            forInstanceId = ii;
            pid = pi;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, privilegeInfos> dico = new Dictionary<string, privilegeInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (privilegeInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestPrivilegesList, pObj.pid);
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

                    Dictionary<string, privilegeInfos> _dico = new Dictionary<string, privilegeInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        // For some processes only
                        _dico = snap.PrivilegesByProcessId(pObj.pid);
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
                    Dictionary<string, privilegeInfos> _dico = SharedLocalSyncEnumerate(pObj);

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
    public static Dictionary<string, privilegeInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, privilegeInfos> _dico = new Dictionary<string, privilegeInfos>();

        Native.Api.NativeStructs.PrivilegeInfo[] ret = Native.Objects.Token.GetPrivilegesListByProcessId(pObj.pid);

        foreach (Native.Api.NativeStructs.PrivilegeInfo tmp in ret)
            _dico.Add(tmp.Name, new privilegeInfos(tmp.Name, pObj.pid, tmp.Status));
        return _dico;
    }
}

