using Common;
using System;

public class asyncCallbackProcKillByMethod
{
    private cProcessConnection con;
    private HasKilled _deg;

    public delegate void HasKilled(bool Success, int pid, string msg, int actionN);

    public asyncCallbackProcKillByMethod(HasKilled deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public Native.Api.Enums.KillMethod method;
        public int newAction;
        public poolObj(int pi, Native.Api.Enums.KillMethod meth, int act)
        {
            newAction = act;
            pid = pi;
            method = meth;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessKillByMethod, pObj.pid, pObj.method);
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
                    bool ret = Native.Objects.Process.KillProcessByMethod(pObj.pid, pObj.method);
                    _deg.Invoke(ret, pObj.pid, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

