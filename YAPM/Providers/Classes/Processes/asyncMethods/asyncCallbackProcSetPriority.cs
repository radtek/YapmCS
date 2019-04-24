using System.Diagnostics;
using Common;
using System;

public class asyncCallbackProcSetPriority
{
    private cProcessConnection con;
    private HasSetPriority _deg;

    public delegate void HasSetPriority(bool Success, string msg, int actionN);

    public asyncCallbackProcSetPriority(HasSetPriority deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public ProcessPriorityClass lvl;
        public int newAction;
        public poolObj(int pi, ProcessPriorityClass level, int act)
        {
            newAction = act;
            pid = pi;
            lvl = level;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessChangePriority, pObj.pid, pObj.lvl);
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
                    bool ret = Wmi.Objects.Process.SetProcessPriorityById(pObj.pid, pObj.lvl, con.wmiSearcher, ref msg);
                    try
                    {
                        _deg.Invoke(ret, msg, pObj.newAction);
                    }
                    catch (Exception ex)
                    {
                        _deg.Invoke(false, ex.Message, pObj.newAction);
                    }

                    break;
                }

            default:
                {
                    // Local
                    bool r = Native.Objects.Process.SetProcessPriorityById(pObj.pid, pObj.lvl);
                    _deg.Invoke(r, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

