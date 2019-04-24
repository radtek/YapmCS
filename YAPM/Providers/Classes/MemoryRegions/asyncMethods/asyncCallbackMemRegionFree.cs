using Common;
using System;

public class asyncCallbackMemRegionFree
{
    private cMemRegionConnection con;
    private HasFreed _deg;

    public delegate void HasFreed(bool Success, int pid, IntPtr address, string msg, int actionNumber);

    public asyncCallbackMemRegionFree(HasFreed deg, ref cMemRegionConnection memConnection)
    {
        _deg = deg;
        con = memConnection;
    }

    public struct poolObj
    {
        public int pid;
        public IntPtr address;
        public IntPtr size;
        public Native.Api.NativeEnums.MemoryState type;
        public int newAction;
        public poolObj(int pi, IntPtr ad, IntPtr siz, Native.Api.NativeEnums.MemoryState typ, int act)
        {
            address = ad;
            newAction = act;
            size = siz;
            type = typ;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.MemoryFree, pObj.pid, pObj.address, pObj.size, pObj.type);
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
                    bool ret = Native.Objects.MemRegion.FreeMemory(pObj.pid, pObj.address, pObj.size, pObj.type);
                    _deg.Invoke(ret, pObj.pid, pObj.address, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

