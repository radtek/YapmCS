using Common;
using System;

public class asyncCallbackProcSetAffinity
{
    private cProcessConnection con;
    private HasSetAffinity _deg;

    public delegate void HasSetAffinity(bool Success, string msg, int actionN);

    public asyncCallbackProcSetAffinity(HasSetAffinity deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public int level;
        public int newAction;
        public poolObj(int pi, int lvl, int act)
        {
            newAction = act;
            level = lvl;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessChangeAffinity, pObj.pid, pObj.level);
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
                    bool ret = Native.Objects.Process.SetProcessAffinityById(pObj.pid, pObj.level);
                    _deg.Invoke(ret, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

