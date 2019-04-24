using Common;
using System;

public class asyncCallbackThreadSetPriority
{
    private cThreadConnection con;
    private HasSetPriority _deg;

    public delegate void HasSetPriority(bool Success, string msg, int actionNumber);

    public asyncCallbackThreadSetPriority(HasSetPriority deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int id;
        public System.Diagnostics.ThreadPriorityLevel level;
        public int newAction;
        public int pid;
        public poolObj(int _id, System.Diagnostics.ThreadPriorityLevel _level, int action, int procId = 0)
        {
            newAction = action;
            id = _id;
            pid = procId;
            level = _level;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadSetPriority, pObj.pid, pObj.id, pObj.level);
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
                    bool r = Native.Objects.Thread.SetThreadPriorityById(pObj.id, pObj.level);
                    _deg.Invoke(r, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

