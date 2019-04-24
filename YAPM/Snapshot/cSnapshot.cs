using Common;
using System.Collections.Generic;
using System;

[Serializable()]
public class cSnapshot
{


    // List of processes
    private Dictionary<string, processInfos> _processes = new Dictionary<string, processInfos>();

    // List of services
    private Dictionary<string, serviceInfos> _services = new Dictionary<string, serviceInfos>();

    // List of network connections 
    private Dictionary<string, networkInfos> _networkConnections = new Dictionary<string, networkInfos>();

    // List of jobs
    private Dictionary<string, jobInfos> _jobs = new Dictionary<string, jobInfos>();

    // List of tasks
    private Dictionary<string, windowInfos> _tasks = new Dictionary<string, windowInfos>();

    // List of modules (PID <-> Dico)
    private Dictionary<int, Dictionary<string, moduleInfos>> _modules = new Dictionary<int, Dictionary<string, moduleInfos>>();

    // List of windows (PID <-> Dico)
    private Dictionary<int, Dictionary<string, windowInfos>> _windows = new Dictionary<int, Dictionary<string, windowInfos>>();

    // List of threads (PID <-> Dico)
    private Dictionary<int, Dictionary<string, threadInfos>> _threads = new Dictionary<int, Dictionary<string, threadInfos>>();

    // List of privileges (PID <-> Dico)
    private Dictionary<int, Dictionary<string, privilegeInfos>> _privileges = new Dictionary<int, Dictionary<string, privilegeInfos>>();

    // List of memory regions (PID <-> Dico)
    private Dictionary<int, Dictionary<string, memRegionInfos>> _memRegions = new Dictionary<int, Dictionary<string, memRegionInfos>>();

    // List of job limits (jobName <-> Dico)
    private Dictionary<string, Dictionary<string, jobLimitInfos>> _jobLimits = new Dictionary<string, Dictionary<string, jobLimitInfos>>();

    // List of heaps (PID <-> Dico)
    private Dictionary<int, Dictionary<string, heapInfos>> _heaps = new Dictionary<int, Dictionary<string, heapInfos>>();

    // List of envvariables (PID <-> Dico)
    private Dictionary<int, Dictionary<string, envVariableInfos>> _envV = new Dictionary<int, Dictionary<string, envVariableInfos>>();

    // List of handles (PID <-> Dico)
    private Dictionary<int, Dictionary<string, handleInfos>> _handles = new Dictionary<int, Dictionary<string, handleInfos>>();

    // Version of file type
    private string _fileVersion;

    // Date of snapshot
    private DateTime _date;

    // System infos
    private SnapshotSystemInfo _infos;



    public cSnapshot(ref string ssFile)
    {
        // Build from file

        // Serialization part :
        byte[] b = System.IO.File.ReadAllBytes(ssFile);
        cSnapshot newObj = cSerialization.DeserializeObject<cSnapshot>(b);

        // Set objects
        {
            var withBlock = newObj;
            this.Processes = withBlock.Processes;
            this.Services = withBlock.Services;
            this.NetworkConnections = withBlock.NetworkConnections;
            this.Jobs = withBlock.Jobs;
            this.Tasks = withBlock.Tasks;
            this.Modules = withBlock.Modules;
            this.Windows = withBlock.Windows;
            this.Threads = withBlock.Threads;
            this.Privileges = withBlock.Privileges;
            this.MemoryRegions = withBlock.MemoryRegions;
            this.JobLimits = withBlock.JobLimits;
            this.Heaps = withBlock.Heaps;
            this.EnvironnementVariables = withBlock.EnvironnementVariables;
            this.Handles = withBlock.Handles;
            this.FileVersion = withBlock.FileVersion;
            this.Date = withBlock.Date;
            this.SystemInformation = withBlock.SystemInformation;
        }
    }

    public cSnapshot()
    {
    }

    public override string ToString()
    {
        return "Snapshot, computer : " + this.SystemInformation.ComputerName + ", date : " + this.Date.ToLongDateString() + "-" + this.Date.ToLongTimeString();
    }



    // File type version
    public string FileVersion
    {
        get
        {
            return _fileVersion;
        }
        set
        {
            _fileVersion = value;
        }
    }

    // System info
    public SnapshotSystemInfo SystemInformation
    {
        get
        {
            return _infos;
        }
        set
        {
            _infos = value;
        }
    }

    // File date
    public DateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }



    // List of processes
    public Dictionary<string, processInfos> Processes
    {
        get
        {
            return _processes;
        }
        set
        {
            _processes = value;
        }
    }

    // List of services
    public Dictionary<string, serviceInfos> Services
    {
        get
        {
            return _services;
        }
        set
        {
            _services = value;
        }
    }
    public Dictionary<string, serviceInfos> ServicesByProcessId
    {
        get
        {
            Dictionary<string, serviceInfos> ret = new Dictionary<string, serviceInfos>();
            if (this.Services != null)
            {
                foreach (System.Collections.Generic.KeyValuePair<string, serviceInfos> pair in this.Services)
                {
                    if (pair.Value.ProcessId == processId)
                        ret.Add(pair.Key, pair.Value);
                }
            }
            return ret;
        }
    }

    // List of network connections
    public Dictionary<string, networkInfos> NetworkConnections
    {
        get
        {
            return _networkConnections;
        }
        set
        {
            _networkConnections = value;
        }
    }
    public Dictionary<string, networkInfos> NetworkConnectionsByProcessId
    {
        get
        {
            Dictionary<string, networkInfos> ret = new Dictionary<string, networkInfos>();
            if (this.NetworkConnections != null)
            {
                foreach (System.Collections.Generic.KeyValuePair<string, networkInfos> pair in this.NetworkConnections)
                {
                    if (pair.Value.ProcessId == processId)
                        ret.Add(pair.Key, pair.Value);
                }
            }
            return ret;
        }
    }

    // List of jobs
    public Dictionary<string, jobInfos> Jobs
    {
        get
        {
            return _jobs;
        }
        set
        {
            _jobs = value;
        }
    }

    // List of tasks
    public Dictionary<string, windowInfos> Tasks
    {
        get
        {
            return _tasks;
        }
        set
        {
            _tasks = value;
        }
    }

    // List of modules
    public Dictionary<string, moduleInfos> ModulesByProcessId
    {
        get
        {
            if (_modules.ContainsKey(processId))
                return _modules[processId];
            else
                return new Dictionary<string, moduleInfos>();
        }
        set
        {
            if (_modules.ContainsKey(processId))
                _modules[processId] = value;
            else
                _modules.Add(processId, value);
        }
    }

    // List of windows
    public Dictionary<string, windowInfos> WindowsByProcessId
    {
        get
        {
            if (_windows.ContainsKey(processId))
                return _windows[processId];
            else
                return new Dictionary<string, windowInfos>();
        }
        set
        {
            if (_windows.ContainsKey(processId))
                _windows[processId] = value;
            else
                _windows.Add(processId, value);
        }
    }

    // List of threads
    public Dictionary<string, threadInfos> ThreadsByProcessId
    {
        get
        {
            if (_threads.ContainsKey(processId))
                return _threads[processId];
            else
                return new Dictionary<string, threadInfos>();
        }
        set
        {
            if (_threads.ContainsKey(processId))
                _threads[processId] = value;
            else
                _threads.Add(processId, value);
        }
    }

    // List of privileges
    public Dictionary<string, privilegeInfos> PrivilegesByProcessId
    {
        get
        {
            if (_privileges.ContainsKey(processId))
                return _privileges[processId];
            else
                return new Dictionary<string, privilegeInfos>();
        }
        set
        {
            if (_privileges.ContainsKey(processId))
                _privileges[processId] = value;
            else
                _privileges.Add(processId, value);
        }
    }

    // List of mem regions
    public Dictionary<string, memRegionInfos> MemoryRegionsByProcessId
    {
        get
        {
            if (_memRegions.ContainsKey(processId))
                return _memRegions[processId];
            else
                return new Dictionary<string, memRegionInfos>();
        }
        set
        {
            if (_memRegions.ContainsKey(processId))
                _memRegions[processId] = value;
            else
                _memRegions.Add(processId, value);
        }
    }

    // List of job limits
    public Dictionary<string, jobLimitInfos> JobLimitsByJobName
    {
        get
        {
            if (_jobLimits.ContainsKey(jobName))
                return _jobLimits[jobName];
            else
                return new Dictionary<string, jobLimitInfos>();
        }
        set
        {
            if (_jobLimits.ContainsKey(jobName))
                _jobLimits[jobName] = value;
            else
                _jobLimits.Add(jobName, value);
        }
    }

    // List of heaps
    public Dictionary<string, heapInfos> HeapsByProcessId
    {
        get
        {
            if (_heaps.ContainsKey(processId))
                return _heaps[processId];
            else
                return new Dictionary<string, heapInfos>();
        }
        set
        {
            if (_heaps.ContainsKey(processId))
                _heaps[processId] = value;
            else
                _heaps.Add(processId, value);
        }
    }

    // List of handles
    public Dictionary<string, handleInfos> HandlesByProcessId
    {
        get
        {
            if (_handles.ContainsKey(processId))
                return _handles[processId];
            else
                return new Dictionary<string, handleInfos>();
        }
        set
        {
            if (_handles.ContainsKey(processId))
                _handles[processId] = value;
            else
                _handles.Add(processId, value);
        }
    }

    // List of env variables
    public Dictionary<string, envVariableInfos> EnvironnementVariablesByProcessId
    {
        get
        {
            if (_envV.ContainsKey(processId))
                return _envV[processId];
            else
                return new Dictionary<string, envVariableInfos>();
        }
        set
        {
            if (_envV.ContainsKey(processId))
                _envV[processId] = value;
            else
                _envV.Add(processId, value);
        }
    }



    // List of modules
    private Dictionary<int, Dictionary<string, moduleInfos>> Modules
    {
        get
        {
            return _modules;
        }
        set
        {
            _modules = value;
        }
    }

    // List of windows
    private Dictionary<int, Dictionary<string, windowInfos>> Windows
    {
        get
        {
            return _windows;
        }
        set
        {
            _windows = value;
        }
    }

    // List of threads
    private Dictionary<int, Dictionary<string, threadInfos>> Threads
    {
        get
        {
            return _threads;
        }
        set
        {
            _threads = value;
        }
    }

    // List of privileges
    private Dictionary<int, Dictionary<string, privilegeInfos>> Privileges
    {
        get
        {
            return _privileges;
        }
        set
        {
            _privileges = value;
        }
    }

    // List of mem regions
    private Dictionary<int, Dictionary<string, memRegionInfos>> MemoryRegions
    {
        get
        {
            return _memRegions;
        }
        set
        {
            _memRegions = value;
        }
    }

    // List of mem regions
    private Dictionary<string, Dictionary<string, jobLimitInfos>> JobLimits
    {
        get
        {
            return _jobLimits;
        }
        set
        {
            _jobLimits = value;
        }
    }

    // List of heaps
    private Dictionary<int, Dictionary<string, heapInfos>> Heaps
    {
        get
        {
            return _heaps;
        }
        set
        {
            _heaps = value;
        }
    }

    // List of handles
    private Dictionary<int, Dictionary<string, handleInfos>> Handles
    {
        get
        {
            return _handles;
        }
        set
        {
            _handles = value;
        }
    }

    // List of env variables
    private Dictionary<int, Dictionary<string, envVariableInfos>> EnvironnementVariables
    {
        get
        {
            return _envV;
        }
        set
        {
            _envV = value;
        }
    }



    // Save the snapshot as SSFile
    public bool SaveSnapshot(string ssFile, ref string msg)
    {

        // Create empty new file
        try
        {
            System.IO.File.Open(ssFile, System.IO.FileMode.Create).Close();
        }
        catch (Exception ex)
        {
            // Could not create file
            msg = ex.Message;
            return false;
        }

        // Serialize current instance
        byte[] b;
        try
        {
            b = cSerialization.GetSerializedObject(this);
        }
        catch (Exception ex)
        {
            // Could not serialize as XML file
            msg = ex.Message;
            Misc.ShowDebugError(ex);
            return false;
        }

        // Create file
        try
        {
            System.IO.File.WriteAllBytes(ssFile, b);
        }
        catch (Exception ex)
        {
            // Could not create file
            msg = ex.Message;
            return false;
        }

        // If we're here, evrything is OK
        return true;
    }

    // Create the snapshot
    public bool CreateSnapshot(cConnection connection, Native.Api.Enums.SnapshotObject options, ref string msg)
    {
        bool b = true;
        switch (connection.ConnectionType)
        {
            case cConnection.TypeOfConnection.LocalConnection:
                {
                    b = this.LocalBuild(ref msg, options);
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    b = this.SocketBuild(ref msg, options);
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    b = this.WmiBuild(ref msg, options);
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

        return b;
    }



    // Local building
    private bool LocalBuild(ref string msg, Native.Api.Enums.SnapshotObject options)
    {
        try
        {

            // Informations about system & ssfile
            this.Date = System.DateTime.Now;
            this.FileVersion = My.MyProject.Application.Info.Version.ToString();
            this.SystemInformation = new SnapshotSystemInfo(Program.Connection);


            // Processes
            // We HAVE to get the list cause some other informations depend on it
            this.Processes = asyncCallbackProcEnumerate.SharedLocalSyncEnumerate(true, new asyncCallbackProcEnumerate.poolObj(0, asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses));

            // Services
            if ((options & Native.Api.Enums.SnapshotObject.Services) == Native.Api.Enums.SnapshotObject.Services)
                this.Services = asyncCallbackServiceEnumerate.SharedLocalSyncEnumerate(new asyncCallbackServiceEnumerate.poolObj(0, true, true, 0), Program._frmMain.lvServices.ServiceConnection);

            // Network connections
            if ((options & Native.Api.Enums.SnapshotObject.NetworkConnections) == Native.Api.Enums.SnapshotObject.NetworkConnections)
                this.NetworkConnections = asyncCallbackNetworkEnumerate.SharedLocalSyncEnumerate(new asyncCallbackNetworkEnumerate.poolObj(default(int), true, 0));

            // Jobs
            if ((options & Native.Api.Enums.SnapshotObject.Jobs) == Native.Api.Enums.SnapshotObject.Jobs)
                this.Jobs = asyncCallbackJobEnumerate.SharedLocalSyncEnumerate();

            // Tasks
            if ((options & Native.Api.Enums.SnapshotObject.Tasks) == Native.Api.Enums.SnapshotObject.Tasks)
                this.Tasks = asyncCallbackTaskEnumerate.SharedLocalSyncEnumerate();

            // Modules
            if ((options & Native.Api.Enums.SnapshotObject.Modules) == Native.Api.Enums.SnapshotObject.Modules)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    Dictionary<string, moduleInfos> _dico = asyncCallbackModuleEnumerate.SharedLocalSyncEnumerate(new asyncCallbackModuleEnumerate.poolObj(proc.ProcessId, 0));
                    this.ModulesByProcessId(proc.ProcessId) = _dico;
                }
            }

            // Windows
            if ((options & Native.Api.Enums.SnapshotObject.Windows) == Native.Api.Enums.SnapshotObject.Windows)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    Dictionary<string, windowInfos> _dico = asyncCallbackWindowEnumerate.SharedLocalSyncEnumerate(new asyncCallbackWindowEnumerate.poolObj(proc.ProcessId, false, true, 0));
                    this.WindowsByProcessId(proc.ProcessId) = _dico;
                }
            }

            // Threads
            if ((options & Native.Api.Enums.SnapshotObject.Threads) == Native.Api.Enums.SnapshotObject.Threads)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    Dictionary<string, threadInfos> _dico = asyncCallbackThreadEnumerate.SharedLocalSyncEnumerate(new asyncCallbackThreadEnumerate.poolObj(proc.ProcessId, 0));
                    this.ThreadsByProcessId(proc.ProcessId) = _dico;
                }
            }

            // Privileges
            if ((options & Native.Api.Enums.SnapshotObject.Privileges) == Native.Api.Enums.SnapshotObject.Privileges)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    int pid = proc.ProcessId;
                    Dictionary<string, privilegeInfos> _dico = asyncCallbackPrivilegesEnumerate.SharedLocalSyncEnumerate(new asyncCallbackPrivilegesEnumerate.poolObj(pid, 0));
                    this.PrivilegesByProcessId(pid) = _dico;
                }
            }

            // Memory regions
            if ((options & Native.Api.Enums.SnapshotObject.MemoryRegions) == Native.Api.Enums.SnapshotObject.MemoryRegions)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    int pid = proc.ProcessId;
                    Dictionary<string, memRegionInfos> _dico = asyncCallbackMemRegionEnumerate.SharedLocalSyncEnumerate(new asyncCallbackMemRegionEnumerate.poolObj(pid, 0));
                    this.MemoryRegionsByProcessId(pid) = _dico;
                }
            }

            // Job limits
            if ((options & Native.Api.Enums.SnapshotObject.JobLimits) == Native.Api.Enums.SnapshotObject.JobLimits)
            {
                foreach (jobInfos job in this.Jobs.Values)
                {
                    string name = job.Name;
                    Dictionary<string, jobLimitInfos> _dico = asyncCallbackJobLimitsEnumerate.SharedLocalSyncEnumerate(new asyncCallbackJobLimitsEnumerate.poolObj(name, 0));
                    this.JobLimitsByJobName(name) = _dico;
                }
            }

            // Heaps
            // TODO (have to fix heap enumeration before implenting it)
            if ((options & Native.Api.Enums.SnapshotObject.Heaps) == Native.Api.Enums.SnapshotObject.Heaps)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    int pid = proc.ProcessId;
                    if (pid > 0)
                    {
                    }
                }
            }

            // Envvariables
            if ((options & Native.Api.Enums.SnapshotObject.EnvironmentVariables) == Native.Api.Enums.SnapshotObject.EnvironmentVariables)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    int pid = proc.ProcessId;
                    using (ProcessMemReader reader = new ProcessMemReader(pid))
                    {
                        IntPtr peb = reader.GetPebAddress();
                        Dictionary<string, envVariableInfos> _dico = asyncCallbackEnvVariableEnumerate.SharedLocalSyncEnumerate(new asyncCallbackEnvVariableEnumerate.poolObj(pid, peb, 0));
                        this.EnvironnementVariablesByProcessId(pid) = _dico;
                    }
                }
            }

            // Handles
            if ((options & Native.Api.Enums.SnapshotObject.Handles) == Native.Api.Enums.SnapshotObject.Handles)
            {
                foreach (processInfos proc in this.Processes.Values)
                {
                    Dictionary<string, handleInfos> _dico = asyncCallbackHandleEnumerate.SharedLocalSyncEnumerate(new asyncCallbackHandleEnumerate.poolObj(proc.ProcessId, true, 0));
                    this.HandlesByProcessId(proc.ProcessId) = _dico;
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
            Misc.ShowDebugError(ex);
            return false;
        }

        return true;
    }


    // WMI building
    private bool WmiBuild(ref string msg, Native.Api.Enums.SnapshotObject options)
    {
        try
        {
        }
        // Processes

        // Services

        catch (Exception ex)
        {
            msg = ex.Message;
            Misc.ShowDebugError(ex);
            return false;
        }

        return true;
    }


    // Remote server building
    private bool SocketBuild(ref string msg, Native.Api.Enums.SnapshotObject options)
    {
        try
        {
        }
        // Processes

        // Services

        catch (Exception ex)
        {
            msg = ex.Message;
            Misc.ShowDebugError(ex);
            return false;
        }

        return true;
    }
}

