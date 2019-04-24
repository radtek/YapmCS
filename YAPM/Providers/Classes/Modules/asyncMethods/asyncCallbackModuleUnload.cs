using Common;
using System;

public class asyncCallbackModuleUnload
{
    private cModuleConnection con;
    private HasUnloadedModule _deg;

    public delegate void HasUnloadedModule(bool Success, int pid, string name, string msg, int actionNumber);

    public asyncCallbackModuleUnload(HasUnloadedModule deg, ref cModuleConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public string name;
        public int newAction;
        public IntPtr baseA;
        public poolObj(int pi, string nam, IntPtr add, int act)
        {
            name = nam;
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
                    bool ret = Native.Objects.Module.UnloadModuleByAddress(pObj.baseA, pObj.pid);
                    _deg.Invoke(ret, pObj.pid, pObj.name, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

