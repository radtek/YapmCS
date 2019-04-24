using Common;
using System;

public class asyncCallbackJobTerminateJob
{
    private cJobConnection con;
    private HasTerminatedJob _deg;

    public delegate void HasTerminatedJob(bool Success, string jobName, string msg, int actionNumber);

    public asyncCallbackJobTerminateJob(HasTerminatedJob deg, ref cJobConnection jobConnection)
    {
        _deg = deg;
        con = jobConnection;
    }

    public struct poolObj
    {
        public string jobName;
        public int newAction;
        public poolObj(string name, int act)
        {
            newAction = act;
            jobName = name;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.JobTerminate, pObj.jobName);
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
                    bool ret = Native.Objects.Job.TerminateJobByJobName(pObj.jobName);
                    _deg.Invoke(ret, pObj.jobName, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

