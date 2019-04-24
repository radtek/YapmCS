using Common;
using System;

public class asyncCallbackProcKill
{
    private cProcessConnection con;
    private HasKilled _deg;

    public delegate void HasKilled(bool Success, int pid, string msg, int actionN);

    public asyncCallbackProcKill(HasKilled deg, ref cProcessConnection procConnection)
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessKill, pObj.pid);
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
                    string msg = "";
                    bool ret = Wmi.Objects.Process.KillProcessById(pObj.pid, con.wmiSearcher, ref msg);

                    try
                    {
                        _deg.Invoke(ret, pObj.pid, msg, pObj.newAction);
                    }
                    catch (Exception ex)
                    {
                        _deg.Invoke(false, pObj.pid, ex.Message, pObj.newAction);
                    }

                    break;
                }

            default:
                {
                    // Local
                    bool ret = Native.Objects.Process.KillProcessById(pObj.pid);
                    _deg.Invoke(ret, pObj.pid, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

