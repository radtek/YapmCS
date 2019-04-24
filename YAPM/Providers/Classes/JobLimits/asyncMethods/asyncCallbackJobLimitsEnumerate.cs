using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackJobLimitsEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cJobLimitConnection con;
    private int _instanceId;
    public asyncCallbackJobLimitsEnumerate(ref Control ctr, Delegate de, ref cJobLimitConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public string JobName;
        public int forInstanceId;
        public poolObj(string _jobName, int ii)
        {
            forInstanceId = ii;
            JobName = _jobName;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, jobLimitInfos> dico = new Dictionary<string, jobLimitInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (jobLimitInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestJobLimits, pObj.JobName);
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

                    Dictionary<string, jobLimitInfos> _dico = new Dictionary<string, jobLimitInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.JobLimitsByJobName(pObj.JobName);
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

                    Dictionary<string, jobLimitInfos> _dico = Native.Objects.Job.EnumerateJobLimitsByJobName(pObj.JobName);

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
    public static Dictionary<string, jobLimitInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, jobLimitInfos> _dico = Native.Objects.Job.EnumerateJobLimitsByJobName(pObj.JobName);
        return _dico;
    }
}

