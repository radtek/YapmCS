using System;

public class asyncCallbackProcGetNonFixedInfos
{
    private int _pid;
    private IntPtr _handle;
    private cProcessConnection _connection;

    public struct TheseInfos
    {
        public int gdiO;
        public int userO;
        public IntPtr affinity;
        public TheseInfos(int _gdi, int _user, IntPtr _affinity)
        {
            gdiO = _gdi;
            userO = _user;
            affinity = _affinity;
        }
    }

    public event GatheredInfosEventHandler GatheredInfos;

    public delegate void GatheredInfosEventHandler(TheseInfos infos);

    public asyncCallbackProcGetNonFixedInfos(int pid, ref cProcessConnection procConnection, IntPtr handle)
    {
        _pid = pid;
        _handle = handle;
        _connection = procConnection;
    }

    public void Process()
    {
        switch (_connection.ConnectionObj.ConnectionType)
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
                    int _gdi = Native.Objects.Process.GetProcessGuiResourceByHandle(_handle, Native.Api.NativeEnums.GuiResourceType.GdiObjects);
                    int _user = Native.Objects.Process.GetProcessGuiResourceByHandle(_handle, Native.Api.NativeEnums.GuiResourceType.UserObjects);
                    IntPtr _affinity = Native.Objects.Process.GetProcessAffinityByHandle(_handle);

                    GatheredInfos?.Invoke(new TheseInfos(_gdi, _user, _affinity));
                    break;
                }
        }
    }
}

