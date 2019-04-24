using Common;
using System;

public class asyncCallbackJobAddProcess
{
    private cJobConnection con;
    private HasAddedProcessesToJob _deg;

    public delegate void HasAddedProcessesToJob(bool Success, int[] pid, string msg, int actionNumber);

    public asyncCallbackJobAddProcess(HasAddedProcessesToJob deg, ref cJobConnection jobConnection)
    {
        _deg = deg;
        con = jobConnection;
    }

    public struct poolObj
    {
        public int[] pid;
        public string jobName;
        public int newAction;
        public poolObj(int[] pi, string name, int act)
        {
            jobName = name;
            newAction = act;
            pid = pi;
        }
    }

    public void Process(object thePoolObj)
    {
        poolObj pObj = (poolObj)thePoolObj;
        if (con.ConnectionObj.IsConnected == false)
            return;

        switch (con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.JobAddProcessToJob, pObj.jobName, pObj.pid);
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

            default:
                {
                    // Local
                    bool ret = Native.Objects.Job.AddProcessToJobByIds(pObj.pid, pObj.jobName);
                    _deg.Invoke(ret, pObj.pid, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

