using System;

[Serializable()]
public class SnapshotSystemInfo
{
    private string _ComputerName;
    private string _UserName;
    private System.Globalization.CultureInfo _Culture;
    private int _IntPtrSize;
    private string _OSFullName;
    private string _OSPlatform;
    private string _OSVersion;
    private ulong _AvailablePhysicalMemory;
    private ulong _AvailableVirtualMemory;
    private ulong _TotalPhysicalMemory;
    private ulong _TotalVirtualMemory;




    public string ComputerName
    {
        get
        {
            return _ComputerName;
        }
    }

    public string UserName
    {
        get
        {
            return _UserName;
        }
    }

    public System.Globalization.CultureInfo Culture
    {
        get
        {
            return _Culture;
        }
    }

    public int IntPtrSize
    {
        get
        {
            return _IntPtrSize;
        }
    }

    public string OSFullName
    {
        get
        {
            return _OSFullName;
        }
    }

    public string OSPlatform
    {
        get
        {
            return _OSPlatform;
        }
    }

    public string OSVersion
    {
        get
        {
            return _OSVersion;
        }
    }

    public ulong AvailablePhysicalMemory
    {
        get
        {
            return _AvailablePhysicalMemory;
        }
    }

    public ulong AvailableVirtualMemory
    {
        get
        {
            return _AvailableVirtualMemory;
        }
    }

    public ulong TotalPhysicalMemory
    {
        get
        {
            return _TotalPhysicalMemory;
        }
    }

    public ulong TotalVirtualMemory
    {
        get
        {
            return _TotalVirtualMemory;
        }
    }




    public SnapshotSystemInfo(cConnection con)
    {

        // Automatically fill in properties
        switch (con.ConnectionType)
        {
            case cConnection.TypeOfConnection.LocalConnection:
                {
                    // Local connection
                    _ComputerName = My.MyProject.Computer.Name;
                    _UserName = Common.Objects.Token.CurrentUserName;
                    {
                        var withBlock = My.MyProject.Computer.Info;
                        _Culture = withBlock.InstalledUICulture;
                        _OSFullName = withBlock.OSFullName;
                        _OSPlatform = withBlock.OSPlatform;
                        _OSVersion = withBlock.OSVersion;
                        _AvailablePhysicalMemory = withBlock.AvailablePhysicalMemory;
                        _AvailableVirtualMemory = withBlock.AvailableVirtualMemory;
                        _TotalPhysicalMemory = withBlock.TotalPhysicalMemory;
                        _TotalVirtualMemory = withBlock.TotalVirtualMemory;
                    }
                    _IntPtrSize = IntPtr.Size;
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}

