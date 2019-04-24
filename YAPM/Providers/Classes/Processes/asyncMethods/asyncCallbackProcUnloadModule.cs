using Common;
using System;

public class asyncCallbackProcUnloadModule
{
    private cProcessConnection con;
    private HasUnloadedModule _deg;

    public delegate void HasUnloadedModule(bool Success, int pid, string msg, int actionN);

    public asyncCallbackProcUnloadModule(HasUnloadedModule deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }
    public struct poolObj
    {
        public int pid;
        public int newAction;
        public IntPtr baseA;
        public poolObj(int pi, IntPtr add, int act)
        {
            baseA = add;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ModuleUnload, pObj.pid, pObj.baseA);
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
                    bool ret = Native.Objects.Process.UnloadProcessModuleByAddress(pObj.baseA, pObj.pid);
                    _deg.Invoke(ret, pObj.pid, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

