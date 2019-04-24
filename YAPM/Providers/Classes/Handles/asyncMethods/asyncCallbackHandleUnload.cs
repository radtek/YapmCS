using Common;
using System;

public class asyncCallbackHandleUnload
{
    private cHandleConnection con;
    private HasUnloadedHandle _deg;

    public delegate void HasUnloadedHandle(bool Success, int pid, IntPtr handle, string msg, int actionNumber);

    public asyncCallbackHandleUnload(HasUnloadedHandle deg, ref cHandleConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public IntPtr handle;
        public int newAction;
        public poolObj(int pi, IntPtr hand, int act)
        {
            handle = hand;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.HandleClose, pObj.pid, pObj.handle);
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
                    int ret = Native.Objects.Handle.CloseProcessLocalHandle(pObj.pid, pObj.handle);
                    _deg.Invoke(ret != 0, pObj.pid, pObj.handle, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

