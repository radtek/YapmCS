using Common;
using System;

public class asyncCallbackProcSuspend
{
    private cProcessConnection con;
    private HasSuspended _deg;

    public delegate void HasSuspended(bool Success, string msg, int actionN);

    public asyncCallbackProcSuspend(HasSuspended deg, ref cProcessConnection procConnection)
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessSuspend, pObj.pid);
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
                    bool ret = Native.Objects.Process.SuspendProcessById(pObj.pid);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

