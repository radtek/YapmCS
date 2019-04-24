using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackThreadEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cThreadConnection con;
    private int _instanceId;
    public asyncCallbackThreadEnumerate(ref Control ctr, Delegate de, ref cThreadConnection co, int iId)
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
        public poolObj(int pi, int iid)
        {
            forInstanceId = iid;
            pid = pi;
        }
    }

    // When socket got a list of processes !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, threadInfos> dico = new Dictionary<string, threadInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (threadInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestThreadList, pObj.pid);
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

                    // Save current collection
                    Dictionary<string, threadInfos> _dico = new Dictionary<string, threadInfos>();
                    string msg = "";
                    bool res = Wmi.Objects.Thread.EnumerateThreadByIds(pObj.pid, con.wmiSearcher, ref _dico, ref msg);
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, res, _dico, msg, pObj.forInstanceId);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    // Snapshot

                    Dictionary<string, threadInfos> _dico = new Dictionary<string, threadInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.ThreadsByProcessId(pObj.pid);
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
                    Dictionary<string, threadInfos> _dico = new Dictionary<string, threadInfos>();

                    Native.Objects.Thread.EnumerateThreadsByProcessId(ref _dico, pObj.pid);

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
    public static Dictionary<string, threadInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, threadInfos> _dico = new Dictionary<string, threadInfos>();
        Native.Objects.Thread.EnumerateThreadsByProcessId(ref _dico, pObj.pid);
        return _dico;
    }
}

