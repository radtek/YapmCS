using Common;
using System;

public class asyncCallbackProcEmptyWorkingSet
{
    private cProcessConnection con;
    private HasReducedWorkingSet _deg;

    public delegate void HasReducedWorkingSet(bool Success, string msg, int actionN);

    public asyncCallbackProcEmptyWorkingSet(HasReducedWorkingSet deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public int newAction;
        public poolObj(int pi, int act)
        {
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessReduceWorkingSet, pObj.pid);
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
                    bool ret = Native.Objects.Process.EmptyProcessWorkingSetById(pObj.pid);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

