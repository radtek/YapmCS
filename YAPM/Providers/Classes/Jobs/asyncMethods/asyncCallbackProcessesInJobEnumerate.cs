using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackProcessesInJobEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cJobConnection con;
    private int _instanceId;
    public asyncCallbackProcessesInJobEnumerate(ref Control ctr, Delegate de, ref cJobConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int forInstanceId;
        public string jobName;
        public poolObj(string _name, int ii)
        {
            forInstanceId = ii;
            jobName = _name;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, processInfos> dico = new Dictionary<string, processInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (processInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestProcessesInJobList, pObj.jobName);
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
                    break;
                }

            default:
                {
                    // Local

                    Dictionary<string, processInfos> _dico = Native.Objects.Job.GetProcessesInJobByName(pObj.jobName);

                    if (deg != null)
                    {
                        try
                        {
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId);
                        }
                        catch (Exception ex)
                        {
                            Misc.ShowDebugError(ex);
                        }
                    }

                    break;
                }
        }

        sem.Release();
    }
}

