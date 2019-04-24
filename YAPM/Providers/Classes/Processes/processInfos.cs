using System.Diagnostics;
using Common;
using System;

[Serializable()]
public class processInfos : generalInfos
{
    public static bool operator !=(processInfos m1, processInfos m2)
    {
        return !(m1 == m2);
    }
    public static bool operator ==(processInfos m1, processInfos m2)
    {
        return (m1.KernelTime == m2.KernelTime && m1.UserTime == m2.UserTime && m1.Priority == m2.Priority && m1.MemoryInfos == m2.MemoryInfos && m1.IOValues == m2.IOValues && m1.HandleCount == m2.HandleCount && m1.GdiObjects == m2.GdiObjects && m1.UserObjects == m2.UserObjects && m1.AffinityMask == m2.AffinityMask && m1.IsHidden == m2.IsHidden && m1.ThreadCount == m2.ThreadCount);
    }



    private string _CommandLine;
    private bool _isHidden;
    private int _Pid;
    private IntPtr _AffinityMask;
    private IntPtr _PebAddress;
    private SerializableFileVersionInfo _fileInfo;
    private int _ParentProcessId;
    private Native.Api.NativeStructs.IoCounters _IOValues;
    private string _Path;
    private string _UserName;
    private string _DomainName;
    private string _Name;
    private long _KernelTime;
    private long _UserTime;
    private Native.Api.NativeStructs.VmCountersEx _MemoryInfos;
    private int _HandleCount;
    private long _StartTime;
    private ProcessPriorityClass _Priority;
    private int _gdiObjects;
    private int _userObjects;
    private int _threadCount;

    private bool _hasReanalize = false;

    private int _processors;



    public bool HasReanalize
    {
        get
        {
            return _hasReanalize;
        }
        set
        {
            _hasReanalize = value;
        }
    }

    public bool IsHidden
    {
        get
        {
            return _isHidden;
        }
        set
        {
            _isHidden = value;
        }
    }
    public int ThreadCount
    {
        get
        {
            return _threadCount;
        }
    }
    public int ProcessId
    {
        get
        {
            return _Pid;
        }
    }
    public int ParentProcessId
    {
        get
        {
            return _ParentProcessId;
        }
    }
    public Native.Api.NativeStructs.IoCounters IOValues
    {
        get
        {
            return _IOValues;
        }
    }
    public string Name
    {
        get
        {
            return _Name;
        }
    }
    public long ProcessorTime
    {
        get
        {
            return _UserTime + _KernelTime;
        }
    }
    public long KernelTime
    {
        get
        {
            return _KernelTime;
        }
    }
    public long UserTime
    {
        get
        {
            return _UserTime;
        }
    }
    public Native.Api.NativeStructs.VmCountersEx MemoryInfos
    {
        get
        {
            return _MemoryInfos;
        }
    }
    public ProcessPriorityClass Priority
    {
        get
        {
            return _Priority;
        }
    }
    public double AverageCpuUsage
    {
        get
        {
            long i = DateTime.Now.Ticks - this.StartTime;
            if (i > 0 && _processors > 0)
                return (this.ProcessorTime / (double)i / _processors);
            else
                return 0;
        }
    }
    public int HandleCount
    {
        get
        {
            return _HandleCount;
        }
    }
    public long StartTime
    {
        get
        {
            return _StartTime;
        }
    }



    public IntPtr PebAddress
    {
        get
        {
            return _PebAddress;
        }
        set
        {
            _PebAddress = value;
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
    public string CommandLine
    {
        get
        {
            return _CommandLine;
        }
        set
        {
            _CommandLine = value;
        }
    }
    public string Path
    {
        get
        {
            return _Path;
        }
        set
        {
            _Path = value;
        }
    }
    public string UserName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }
    public string DomainName
    {
        get
        {
            return _DomainName;
        }
        set
        {
            _DomainName = value;
        }
    }



    public IntPtr AffinityMask
    {
        get
        {
            return _AffinityMask;
        }
        set
        {
            _AffinityMask = value;
        }
    }
    public int GdiObjects
    {
        get
        {
            return _gdiObjects;
        }
        set
        {
            _gdiObjects = value;
        }
    }
    public int UserObjects
    {
        get
        {
            return _userObjects;
        }
        set
        {
            _userObjects = value;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public processInfos()
    {
    }
    public processInfos(ref Native.Api.NativeStructs.SystemProcessInformation Proc, string ProcessName = null)
    {
        _PebAddress = IntPtr.Zero;

        {
            var withBlock = Proc;
            // _AffinityMask = 0
            _UserTime = withBlock.UserTime;
            _KernelTime = withBlock.KernelTime;
            try
            {
                _StartTime = DateTime.FromFileTime(withBlock.CreateTime).Ticks;
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
            _MemoryInfos = withBlock.VirtualMemoryCounters;
            _Priority = getPriorityClass(withBlock.BasePriority);
            _IOValues = withBlock.IoCounters;
            _HandleCount = withBlock.HandleCount;
            _Pid = withBlock.ProcessId;
            _isHidden = false;
            _threadCount = withBlock.NumberOfThreads;
            _ParentProcessId = withBlock.InheritedFromProcessId;
            if (_Pid > 0)
            {
                if (ProcessName != null)
                    _Name = ProcessName;
                else
                    _Name = Common.Misc.ReadUnicodeString(withBlock.ImageName);
            }
            else
                _Name = "Idle process";
        }

        _processors = cSystemInfo.GetProcessorCount();
    }

    // Merge an old and a new instance
    public void Merge(ref processInfos newI)
    {
        {
            var withBlock = newI;
            _KernelTime = withBlock.KernelTime;
            _UserTime = withBlock.UserTime;
            _Priority = withBlock.Priority;
            _MemoryInfos = withBlock.MemoryInfos;
            _IOValues = withBlock.IOValues;
            _HandleCount = withBlock.HandleCount;
            _gdiObjects = withBlock.GdiObjects;
            _userObjects = withBlock.UserObjects;
            _AffinityMask = withBlock.AffinityMask;
            _isHidden = withBlock.IsHidden;
            _threadCount = withBlock.ThreadCount;

            // Merge fixed info (in case of 'Reanalize')
            // If _Path <> ._Path OrElse _UserName <> .UserName OrElse _CommandLine <> .CommandLine Then
            if (withBlock.HasReanalize)
            {
                _Path = withBlock.Path;
                _UserName = withBlock.UserName;
                _DomainName = withBlock.DomainName;
                _CommandLine = withBlock.CommandLine;
                _hasReanalize = false;
                _fileInfo = withBlock.FileInfo;
            }
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[53];

        s[0] = "PID";
        s[1] = "UserName";
        s[2] = "ParentPID";
        s[3] = "ParentName";
        s[4] = "CpuUsage";
        s[5] = "AverageCpuUsage";
        s[6] = "KernelCpuTime";
        s[7] = "UserCpuTime";
        s[8] = "TotalCpuTime";
        s[9] = "StartTime";
        s[10] = "RunTime";
        s[11] = "GdiObjects";
        s[12] = "UserObjects";
        s[13] = "AffinityMask";
        s[14] = "HandleCount";
        s[15] = "ThreadCount";
        s[16] = "WorkingSet";
        s[17] = "InJob";
        s[18] = "Elevation";
        s[19] = "BeingDebugged";
        s[20] = "OwnedProcess";
        s[21] = "SystemProcess";
        s[22] = "ServiceProcess";
        s[23] = "CriticalProcess";
        s[24] = "PeakWorkingSet";
        s[25] = "PageFaultCount";
        s[26] = "PagefileUsage";
        s[27] = "PeakPagefileUsage";
        s[28] = "QuotaPeakPagedPoolUsage";
        s[29] = "QuotaPagedPoolUsage";
        s[30] = "QuotaPeakNonPagedPoolUsage";
        s[31] = "QuotaNonPagedPoolUsage";
        s[32] = "ReadOperationCount";
        s[33] = "WriteOperationCount";
        s[34] = "OtherOperationCount";
        s[35] = "ReadTransferCount";
        s[36] = "WriteTransferCount";
        s[37] = "OtherTransferCount";
        s[38] = "ReadOperationCountDelta";
        s[39] = "WriteOperationCountDelta";
        s[40] = "OtherOperationCountDelta";
        s[41] = "ReadTransferCountDelta";
        s[42] = "WriteTransferCountDelta";
        s[43] = "OtherTransferCountDelta";
        s[44] = "TotalIoDelta";
        s[45] = "Priority";
        s[46] = "Path";
        s[47] = "CommandLine";
        s[48] = "Description";
        s[49] = "Copyright";
        s[50] = "Version";
        s[51] = "Company";
        s[52] = "IsWow64";


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

    // Return a class from an int (concerning priority)
    private ProcessPriorityClass getPriorityClass(int priority)
    {
        if (priority >= 24)
            return ProcessPriorityClass.RealTime;
        else if (priority >= 13)
            return ProcessPriorityClass.High;
        else if (priority >= 10)
            return ProcessPriorityClass.AboveNormal;
        else if (priority >= 8)
            return ProcessPriorityClass.Normal;
        else if (priority >= 6)
            return ProcessPriorityClass.BelowNormal;
        else
            return ProcessPriorityClass.Idle;
    }
}

