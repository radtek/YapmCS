using Common;
using System;

public class asyncCallbackThreadSetAffinity
{
    private cThreadConnection con;
    private HasSetAffinity _deg;

    public delegate void HasSetAffinity(bool Success, string msg, int actionNumber);

    public asyncCallbackThreadSetAffinity(HasSetAffinity deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int id;
        public IntPtr level;
        public int newAction;
        public int pid;
        public poolObj(int _id, int _level, int action, int procId = 0)
        {
            newAction = action;
            id = _id;
            level = new IntPtr(_level);
            pid = procId;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadSetAffinity, pObj.pid, pObj.id, pObj.level);
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
                    bool ret = Native.Objects.Thread.SetThreadAffinityById(pObj.id, pObj.level);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

