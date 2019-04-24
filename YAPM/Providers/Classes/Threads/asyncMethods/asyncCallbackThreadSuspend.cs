using Common;
using System;

public class asyncCallbackThreadSuspend
{
    private cThreadConnection con;
    private HasSuspended _deg;

    public delegate void HasSuspended(bool Success, string msg, int actionNumber);

    public asyncCallbackThreadSuspend(HasSuspended deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int id;
        public int newAction;
        public int pid;
        public poolObj(int _id, int action, int processId = 0)
        {
            newAction = action;
            id = _id;
            pid = processId;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadSuspend, pObj.pid, pObj.id);
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
                    bool ret = Native.Objects.Thread.SuspendThreadById(pObj.id);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

