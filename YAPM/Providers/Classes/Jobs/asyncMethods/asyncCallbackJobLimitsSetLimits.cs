using Common;
using System;
using Native.Api;

public class asyncCallbackJobLimitsSetLimits
{
    private cJobConnection con;
    private HasSetLimits _deg;

    public delegate void HasSetLimits(bool Success, string jobName, string msg, int actionNumber);

    public asyncCallbackJobLimitsSetLimits(HasSetLimits deg, ref cJobConnection jobLimitConnection)
    {
        _deg = deg;
        con = jobLimitConnection;
    }

    public struct poolObj
    {
        public string jobName;
        public NativeStructs.JobObjectBasicUiRestrictions struct1;
        public NativeStructs.JobObjectExtendedLimitInformation struct2;
        public int newAction;
        public poolObj(string name, NativeStructs.JobObjectBasicUiRestrictions s1, NativeStructs.JobObjectExtendedLimitInformation s2, int act)
        {
            newAction = act;
            jobName = name;
            struct1 = s1;
            struct2 = s2;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.JobSetLimits, pObj.jobName, pObj.struct1, pObj.struct2);
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
                    bool ret = Native.Objects.Job.SetJobCommonLimitsByName(pObj.jobName, pObj.struct1, pObj.struct2);
                    _deg.Invoke(ret, pObj.jobName, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

