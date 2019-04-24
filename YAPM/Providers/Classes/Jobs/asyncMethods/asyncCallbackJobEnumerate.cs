using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackJobEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cJobConnection con;
    private int _instanceId;
    public asyncCallbackJobEnumerate(ref Control ctr, Delegate de, ref cJobConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int forInstanceId;
        public poolObj(int ii)
        {
            forInstanceId = ii;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, jobInfos> dico = new Dictionary<string, jobInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (jobInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestJobList);
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
                    Dictionary<string, jobInfos> _dico = new Dictionary<string, jobInfos>();
                    bool res;
                    string msg = "";

                    res = Wmi.Objects.Job.EnumerateJobs(con.wmiSearcher, ref _dico, ref msg);
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, res, _dico, msg, 0);
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

                    Dictionary<string, jobInfos> _dico = new Dictionary<string, jobInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.Jobs;
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

                    Dictionary<string, jobInfos> _dico = Native.Objects.Job.EnumerateJobs();

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
    public static Dictionary<string, jobInfos> SharedLocalSyncEnumerate()
    {
        Dictionary<string, jobInfos> _dico = Native.Objects.Job.EnumerateJobs();
        return _dico;
    }
}

