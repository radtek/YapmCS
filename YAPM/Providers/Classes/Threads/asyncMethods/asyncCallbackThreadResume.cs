using Common;
using System;

public class asyncCallbackThreadResume
{
    private cThreadConnection con;
    private HasResumed _deg;

    public delegate void HasResumed(bool Success, string msg, int actionNumber);

    public asyncCallbackThreadResume(HasResumed deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int id;
        public int newAction;
        public int pid;
        public poolObj(int _id, int action, int procId = 0)
        {
            newAction = action;
            id = _id;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadResume, pObj.pid, pObj.id);
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
                    bool ret = Native.Objects.Thread.ResumeThreadById(pObj.id);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

