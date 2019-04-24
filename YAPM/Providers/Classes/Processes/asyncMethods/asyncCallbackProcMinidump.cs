using System;

public class asyncCallbackProcMinidump
{
    private cProcessConnection con;
    private HasCreatedDump _deg;

    public delegate void HasCreatedDump(bool Success, int pid, string file, string msg, int actionN);

    public asyncCallbackProcMinidump(HasCreatedDump deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public string file;
        public Native.Api.NativeEnums.MiniDumpType dumpOpt;
        public int newAction;
        public poolObj(int pi, string fil, Native.Api.NativeEnums.MiniDumpType opt, int act)
        {
            newAction = act;
            file = fil;
            dumpOpt = opt;
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

                    try
                    {
                        bool ret = Native.Objects.Process.CreateMiniDumpFileById(pObj.pid, pObj.file, pObj.dumpOpt);
                        _deg.Invoke(ret, pObj.pid, pObj.file, Native.Api.Win32.GetLastError(), pObj.newAction);
                    }
                    catch (Exception ex)
                    {
                        // Access denied, or...
                        _deg.Invoke(false, pObj.pid, pObj.file, ex.Message, pObj.newAction);
                    }

                    break;
                }
        }
    }
}

