using System;

[Serializable()]
public class serviceInfos : generalInfos
{
    public static bool operator !=(serviceInfos m1, serviceInfos m2)
    {
        return !(m1 == m2);
    }
    public static bool operator ==(serviceInfos i1, serviceInfos i2)
    {
        return (i1.ProcessId == i2.ProcessId && i1.State == i2.State && i1.AcceptedControl == i2.AcceptedControl && i1.CheckPoint == i2.CheckPoint && i1.ServiceType == i2.ServiceType && i1.ProcessName == i2.ProcessName && i1.ServiceFlags == i2.ServiceFlags && i1.ServiceSpecificExitCode == i2.ServiceSpecificExitCode && i1.WaitHint == i2.WaitHint && i1.Win32ExitCode == i2.Win32ExitCode);
    }


    private int _pid;
    private Native.Api.NativeEnums.ServiceState _state;
    private string _displayName;
    private Native.Api.NativeEnums.ServiceStartType _startType;
    private string _path;
    private Native.Api.NativeEnums.ServiceType _serviceType;
    private string _desc;
    private int _errorControl;
    private string _processName;
    private string _loadOrderGroup;
    private string _startName;
    private string _diagMF;
    private string _objName;
    private Native.Api.NativeEnums.ServiceAccept _acceptedCtrls;
    private string _name;
    private SerializableFileVersionInfo _fileInfo;

    private bool _tag = false;
    private string[] _Dependencies;
    private int _tagID;
    private Native.Api.NativeEnums.ServiceFlags _ServiceFlags;
    private int _WaitHint;
    private int _CheckPoint;
    private int _ServiceSpecificExitCode;
    private int _Win32ExitCode;

    private bool _allInformationsRetrieved;


    public bool Tag
    {
        get
        {
            return _tag;
        }
        set
        {
            _tag = value;
        }
    }
    public int ProcessId
    {
        get
        {
            return _pid;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }
    public string DisplayName
    {
        get
        {
            return _displayName;
        }
    }
    public Native.Api.NativeEnums.ServiceState State
    {
        get
        {
            return _state;
        }
    }
    public Native.Api.NativeEnums.ServiceStartType StartType
    {
        get
        {
            return _startType;
        }
    }
    public string ImagePath
    {
        get
        {
            return _path;
        }
    }
    public Native.Api.NativeEnums.ServiceType ServiceType
    {
        get
        {
            return _serviceType;
        }
    }
    public string Description
    {
        get
        {
            return _desc;
        }
    }
    public int ErrorControl
    {
        get
        {
            return _errorControl;
        }
    }
    public string ProcessName
    {
        get
        {
            return _processName;
        }
    }
    public string LoadOrderGroup
    {
        get
        {
            return _loadOrderGroup;
        }
    }
    public string ServiceStartName
    {
        get
        {
            return _startName;
        }
    }
    public string DiagnosticMessageFile
    {
        get
        {
            return _diagMF;
        }
    }
    public string ObjectName
    {
        get
        {
            return _objName;
        }
    }
    public Native.Api.NativeEnums.ServiceAccept AcceptedControl
    {
        get
        {
            return _acceptedCtrls;
        }
    }
    public string[] Dependencies
    {
        get
        {
            return _Dependencies;
        }
    }
    public int TagID
    {
        get
        {
            return _tagID;
        }
    }
    public Native.Api.NativeEnums.ServiceFlags ServiceFlags
    {
        get
        {
            return _ServiceFlags;
        }
    }
    public int WaitHint
    {
        get
        {
            return _WaitHint;
        }
    }
    public int CheckPoint
    {
        get
        {
            return _CheckPoint;
        }
    }
    public int ServiceSpecificExitCode
    {
        get
        {
            return _ServiceSpecificExitCode;
        }
    }
    public int Win32ExitCode
    {
        get
        {
            return _Win32ExitCode;
        }
    }
    public SerializableFileVersionInfo FileInfo
    {
        get
        {
            return _fileInfo;
        }
        set
        {
            _fileInfo = value;
        }
    }


    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public serviceInfos()
    {
    }
    public serviceInfos(ref Native.Api.NativeStructs.EnumServiceStatusProcess Thr, bool allInfos = false)
    {
        {
            var withBlock = Thr;
            _displayName = withBlock.DisplayName;
            _name = withBlock.ServiceName;
            {
                var withBlock1 = withBlock.ServiceStatusProcess;
                _CheckPoint = withBlock1.CheckPoint;
                _acceptedCtrls = withBlock1.ControlsAccepted;
                _state = withBlock1.CurrentState;
                _pid = withBlock1.ProcessID;
                _ServiceFlags = withBlock1.ServiceFlags;
                _ServiceSpecificExitCode = withBlock1.ServiceSpecificExitCode;
                _serviceType = withBlock1.ServiceType;
                _WaitHint = withBlock1.WaitHint;
                _Win32ExitCode = withBlock1.Win32ExitCode;
            }
            _allInformationsRetrieved = allInfos;
        }
    }

    // Merge an old and a new instance
    public void Merge(ref serviceInfos newI)
    {
        {
            var withBlock = newI;
            _pid = withBlock.ProcessId;
            _state = withBlock.State;
            _acceptedCtrls = withBlock.AcceptedControl;
            _CheckPoint = withBlock.CheckPoint;
            _serviceType = withBlock.ServiceType;
            _processName = withBlock.ProcessName;
            _ServiceFlags = withBlock.ServiceFlags;
            _ServiceSpecificExitCode = withBlock.ServiceSpecificExitCode;
            _WaitHint = withBlock.WaitHint;
            _Win32ExitCode = withBlock.Win32ExitCode;

            if (_allInformationsRetrieved)
            {
                // Then we are in WMI or Socket mode : all informations 
                // (including startType...etc) have been retrieved
                // So the merge have to copy all the informations below
                _serviceType = withBlock.ServiceType;
                _errorControl = withBlock.ErrorControl;
                _startType = withBlock.StartType;
                _path = withBlock.ImagePath;
                _displayName = withBlock.DisplayName;
                _loadOrderGroup = withBlock.LoadOrderGroup;
                _startName = withBlock.ServiceStartName;
                _Dependencies = withBlock.Dependencies;
                _desc = withBlock.Description;                 // UPDATED ONCE (no merge)
                _diagMF = withBlock.DiagnosticMessageFile;     // UPDATED ONCE (no merge)
                _objName = withBlock.ObjectName;                // UPDATED ONCE (no merge)
                _tagID = withBlock.TagID;
            }

            if (_fileInfo == null)
                _fileInfo = withBlock.FileInfo;
        }
    }

    internal void SetConfig(ref Native.Api.NativeStructs.QueryServiceConfig conf)
    {
        {
            var withBlock = conf;
            _serviceType = withBlock.ServiceType;
            _errorControl = withBlock.ErrorControl;
            _startType = withBlock.StartType;
            _path = withBlock.BinaryPathName;
            _displayName = withBlock.DisplayName;
            _loadOrderGroup = withBlock.LoadOrderGroup;
            _startName = withBlock.ServiceStartName;
            _tagID = withBlock.TagID;

            _Dependencies = Native.Objects.Service.GetServiceDependenciesAsStringArrayFromPtr(withBlock.Dependencies);
        }
    }

    internal void SetRealImagePath()
    {
        _path = Common.Misc.GetRealPath(_path);
    }

    internal void SetRegInfos(string desc, string dmf, string obj)
    {
        _desc = desc;
        _diagMF = dmf;
        _objName = obj;
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[21];

        s[0] = "DisplayName";
        s[1] = "State";
        s[2] = "StartType";
        s[3] = "ImagePath";
        s[4] = "ServiceType";
        s[5] = "Description";
        s[6] = "ErrorControl";
        s[7] = "Process";
        s[8] = "ProcessId";
        s[9] = "ProcessName";
        s[10] = "LoadOrderGroup";
        s[11] = "ServiceStartName";
        s[12] = "DiagnosticMessageFile";
        s[13] = "ObjectName";
        s[14] = "Dependencies";
        s[15] = "TagID";
        s[16] = "ServiceFlags";
        s[17] = "WaitHint";
        s[18] = "CheckPoint";
        s[19] = "ServiceSpecificExitCode";
        s[20] = "Win32ExitCode";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Name";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

