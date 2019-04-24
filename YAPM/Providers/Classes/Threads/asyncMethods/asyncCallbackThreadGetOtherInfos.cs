using System;

public class asyncCallbackThreadGetOtherInfos
{
    private int _id;
    private IntPtr _handle;
    private cThreadConnection _connection;
    // Private _deg As GatheredInfos

    public struct TheseInfos
    {
        public IntPtr affinity;
        public TheseInfos(IntPtr _affinity)
        {
            affinity = _affinity;
        }
    }

    public event GatheredInfosEventHandler GatheredInfos;

    public delegate void GatheredInfosEventHandler(TheseInfos infos);

    public asyncCallbackThreadGetOtherInfos(int pid, ref cThreadConnection procConnection, IntPtr handle)
    {
        _id = pid;
        // _deg = deg
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
                    IntPtr _affinity = Native.Objects.Thread.GetThreadAffinityByHandle(_handle);

                    GatheredInfos?.Invoke(new TheseInfos(_affinity));
                    break;
                }
        }
    }
}

