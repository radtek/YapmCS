using System;

public class asyncCallbackMemRegionDump
{
    private cMemRegionConnection con;
    private HasDumped _deg;

    public delegate void HasDumped(bool Success, string file, IntPtr address, string msg, int actionNumber);

    public asyncCallbackMemRegionDump(HasDumped deg, ref cMemRegionConnection memConnection)
    {
        _deg = deg;
        con = memConnection;
    }

    public struct poolObj
    {
        public int pid;
        public IntPtr address;
        public string file;
        public IntPtr size;
        public int newAction;
        public poolObj(int pi, IntPtr ad, string fil, IntPtr siz, int act)
        {
            address = ad;
            newAction = act;
            file = fil;
            size = siz;
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
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    break;
                }

            default:
                {
                    // Local
                    bool ret = Native.Objects.MemRegion.DumpMemory(pObj.pid, pObj.address, pObj.size, pObj.file);
                    _deg.Invoke(ret, pObj.file, pObj.address, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

