using Common;
using System;

public class asyncCallbackThreadKill
{
    private cThreadConnection con;
    private HasKilled _deg;

    public delegate void HasKilled(bool Success, int id, string msg, int actionNumber);

    public asyncCallbackThreadKill(HasKilled deg, ref cThreadConnection procConnection)
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadTerminate, pObj.pid, pObj.id);
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
                    bool ret = Native.Objects.Thread.KillThreadById(pObj.id);
                    _deg.Invoke(ret, pObj.id, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

