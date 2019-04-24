using System.Collections.Generic;
using System;

[Serializable()]
public class cSocketData
{
    public override string ToString()
    {
        return _orderType.ToString();
    }

    // Type of data to send
    public enum DataType : byte
    {
        Order = 1                 // An order (nothing expected after)
,
        RequestedList = 2         // Requested list
,
        ErrorOnServer = 3         // Error occured on server
,
        Identification = 4        // For key return
    }

    // Type of orders
    public enum OrderType : byte
    {

        // Process functions
        ProcessKill,
        ProcessKillByMethod,
        ProcessKillTree,
        ProcessReduceWorkingSet,
        ProcessChangePriority,
        ProcessChangeAffinity,
        ProcessIncreasePriority,
        ProcessDecreasePriority,
        ProcessResume,
        ProcessSuspend,
        ProcessCreateNew,
        ProcessReanalize,

        // Service functions
        ServicePause,
        ServiceResume,
        ServiceStop,
        ServiceStart,
        ServiceDelete,
        ServiceChangeServiceStartType,

        // Thread functions
        ThreadTerminate,
        ThreadSuspend,
        ThreadResume,
        ThreadIncreasePriority,
        ThreadDecreasePriority,
        ThreadSetPriority,
        ThreadSetAffinity,

        // Windows functions
        WindowClose,
        WindowSetPositions,
        WindowShow,
        WindowHide,
        WindowEnable,
        WindowDisable,
        WindowBringToFront,
        WindowSetAsForegroundWindow,
        WindowSetAsActiveWindow,
        WindowSetCaption,
        WindowSetOpacity,
        WindowMinimize,
        WindowMaximize,
        WindowFlash,
        WindowStopFlashing,

        // Other functions
        HandleClose,
        ModuleUnload,
        PrivilegeChangeStatus,
        RequestProcessorCount,
        ReturnProcessorCount,
        TcpClose,

        // Memory functions
        MemoryFree,
        MemoryChangeProtectionType,

        // Job functions
        JobTerminate,
        JobAddProcessToJob,
        JobSetLimits,

        // Request lists
        RequestProcessList,
        RequestServiceList,
        RequestServDepList,
        RequestModuleList,
        RequestThreadList,
        RequestWindowList,
        RequestHandleList,
        RequestTaskList,
        RequestNetworkConnectionList,
        RequestPrivilegesList,
        RequestMemoryRegionList,
        RequestEnvironmentVariableList,
        RequestSearchList,
        RequestLogList,
        RequestJobList,
        RequestProcessesInJobList,
        RequestJobLimits,
        RequestHeapList,

        // General commands
        GeneralCommandSearch,
        GeneralCommandShutdown,
        GeneralCommandRestart,
        GeneralCommandPoweroff,
        GeneralCommandSleep,
        GeneralCommandHibernate,
        GeneralCommandLogoff,
        GeneralCommandLock,

        // Nothing
        DoNothing
    }


    // Type of data to send/receive
    private DataType _datatType;
    private OrderType _orderType;

    // Some parameters for our functions
    private int _instanceId;
    private object _param1;
    private object _param2;
    private object _param3;
    private object _param4;

    public string _id;

    // Contains items requested
    private generalInfos[] _list;
    private string[] _keys;

    // Properties
    public int InstanceId
    {
        get
        {
            return _instanceId;
        }
        set
        {
            _instanceId = value;
        }
    }
    public generalInfos[] GetList
    {
        get
        {
            return _list;
        }
    }
    public string[] GetKeys
    {
        get
        {
            return _keys;
        }
    }
    public DataType Type
    {
        get
        {
            return _datatType;
        }
    }
    public OrderType Order
    {
        get
        {
            return _orderType;
        }
    }
    public object Param1
    {
        get
        {
            return _param1;
        }
    }
    public object Param2
    {
        get
        {
            return _param2;
        }
    }
    public object Param3
    {
        get
        {
            return _param3;
        }
    }
    public object Param4
    {
        get
        {
            return _param4;
        }
    }

    // Create a SocketData
    public cSocketData(DataType dataT, OrderType orderT = OrderType.DoNothing, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
    {
        _datatType = dataT;
        _orderType = orderT;
        _param1 = param1;
        _param2 = param2;
        _param3 = param3;
        _param4 = param4;
    }


    public void SetPrivilegeList(Dictionary<string, privilegeInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, privilegeInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetHeapList(Dictionary<string, heapInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, heapInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetLogList(Dictionary<string, logItemInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, logItemInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetJobList(Dictionary<string, jobInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, jobInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetEnvVarList(Dictionary<string, envVariableInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, envVariableInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetMemoryRegList(Dictionary<string, memRegionInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, memRegionInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetProcessList(Dictionary<string, processInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, processInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetJobLimitsList(Dictionary<string, jobLimitInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, jobLimitInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetSearchList(Dictionary<string, searchInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, searchInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetNetworkList(Dictionary<string, networkInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, networkInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetTaskList(Dictionary<string, taskInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, taskInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }


    public void SetWindowsList(Dictionary<string, windowInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, windowInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetThreadList(Dictionary<string, threadInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, threadInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetHandleList(Dictionary<string, handleInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, handleInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetModuleList(Dictionary<string, moduleInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, moduleInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }

    public void SetServiceList(Dictionary<string, serviceInfos> dico)
    {
        if (dico == null)
            return;

        // Transform a dico into two lists
        _list = new generalInfos[dico.Count - 1 + 1];
        _keys = new string[dico.Count - 1 + 1];

        int x = 0;
        foreach (System.Collections.Generic.KeyValuePair<string, serviceInfos> pp in dico)
        {
            _list[x] = pp.Value;
            _keys[x] = pp.Key;
            x += 1;
        }
    }
}

