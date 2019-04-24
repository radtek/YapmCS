// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.

using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System;
using Microsoft.Samples;
using Common.Misc;
using Native.Api.Structs;

public class cProcess : cGeneralObject, IDisposable
{
    private const int HIST_SIZE = 226;                // Size of an item of the history
    private static int _histBuff = 1000;              // Number of items to save

    public static int BuffSize
    {
        set
        {
            _histBuff = System.Convert.ToInt32(value / (double)HIST_SIZE);
        }
    }


    public event HasMergedEventHandler HasMerged;

    public delegate void HasMergedEventHandler();

    // Contains list of process names
    internal static Dictionary<string, string> _procs = new Dictionary<string, string>();

    private processInfos _processInfos;
    private int _processors = 1;       // By default we consider that there is only one processor
    private static cProcessConnection __connection;

    private static cProcessConnection _connection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __connection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__connection != null)
            {
            }

            __connection = value;
            if (__connection != null)
            {
            }
        }
    }

    private string _parentName = Constants.vbNullString;
    private double _cpuUsage;
    private Native.Api.NativeStructs.IoCounters _ioDelta;

    // Save informations about performance
    internal SortedList<int, Native.Api.Structs.ProcMemInfo> _dicoProcMem = new SortedList<int, Native.Api.Structs.ProcMemInfo>();
    internal SortedList<int, Native.Api.Structs.ProcTimeInfo> _dicoProcTimes = new SortedList<int, Native.Api.Structs.ProcTimeInfo>();
    internal SortedList<int, Native.Api.Structs.ProcIoInfo> _dicoProcIO = new SortedList<int, Native.Api.Structs.ProcIoInfo>();
    internal SortedList<int, Native.Api.Structs.ProcMiscInfo> _dicoProcMisc = new SortedList<int, Native.Api.Structs.ProcMiscInfo>();
    internal SortedList<int, Native.Api.Structs.ProcIoInfo> _dicoProcIODelta = new SortedList<int, Native.Api.Structs.ProcIoInfo>();

    private IntPtr _handleQueryInfo;
    private IntPtr _tokenHandle;

    // Informations which will be refreshed each call to 'merge'
    private Native.Api.Enums.ElevationType _elevation;
    private bool _isInJob;
    private bool _isBeingDebugged;
    private bool _isCritical;
    private bool _isBoostEnabled;
    private bool _isWow64Process;

    private static bool _hlProcessBeingDebugged;
    private static bool _hlProcessInJob;
    private static bool _hlProcessSystem;
    private static bool _hlProcessOwned;
    private static bool _hlProcessService;
    private static bool _hlProcessCritical;
    private static bool _hlProcessElevated;
    private static Color _hlProcessBeingDebuggedColor;
    private static Color _hlProcessInJobColor;
    private static Color _hlProcessSystemColor;
    private static Color _hlProcessOwnedColor;
    private static Color _hlProcessServiceColor;
    private static Color _hlProcessCriticalColor;
    private static Color _hlProcessElevatedColor;


    public static cProcessConnection Connection
    {
        get
        {
            return _connection;
        }
        set
        {
            _connection = value;
        }
    }

    // Get the performance dictionnaries
    public SortedList<int, Native.Api.Structs.ProcMemInfo> DicoPerfMem
    {
        get
        {
            return _dicoProcMem;
        }
    }
    public SortedList<int, Native.Api.Structs.ProcIoInfo> DicoPerfIO
    {
        get
        {
            return _dicoProcIO;
        }
    }
    public SortedList<int, Native.Api.Structs.ProcIoInfo> DicoPerfIODelta
    {
        get
        {
            return _dicoProcIODelta;
        }
    }
    public SortedList<int, Native.Api.Structs.ProcTimeInfo> DicoPerfTimes
    {
        get
        {
            return _dicoProcTimes;
        }
    }



    public cProcess(ref processInfos infos)
    {
        _processInfos = infos;
        _connection = Connection;
        _processors = cProcessConnection.ProcessorCount;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.Process;
        // Get a handle if local
        if (_connection != null)
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                _handleQueryInfo = Native.Objects.Process.GetProcessHandleById(infos.ProcessId, Native.Objects.Process.ProcessQueryMinRights);
                _tokenHandle = Native.Objects.Token.GetProcessTokenHandleByProcessHandle(_handleQueryInfo, Native.Security.TokenAccess.Query);
            }
        }
    }
    public void Dispose()
    {
    }

    ~cProcess()
    {
        // Close a handle if local
        if (_connection != null)
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                if (_handleQueryInfo.IsNotNull())
                    Native.Objects.General.CloseHandle(_handleQueryInfo);
            }
        }
    }



    public processInfos Infos
    {
        get
        {
            return _processInfos;
        }
    }

    public int ProcessorCount
    {
        get
        {
            return _processors;
        }
    }

    // Different kind of property, because it's changed by the call
    // of aVariable = aProcess.CpuUsage
    public double CpuUsage
    {
        get
        {
            return _cpuUsage;
        }
    }

    public Native.Api.NativeStructs.IoCounters IODelta
    {
        get
        {
            return _ioDelta;
        }
    }

    public bool IsBeingDebugged
    {
        get
        {
            return _isBeingDebugged;
        }
    }

    public bool IsInJob
    {
        get
        {
            return _isInJob;
        }
    }

    public bool IsCriticalProcess
    {
        get
        {
            return _isCritical;
        }
    }

    public bool IsBoostEnabled
    {
        get
        {
            return _isBoostEnabled;
        }
    }

    public Native.Api.Enums.ElevationType ElevationType
    {
        get
        {
            return _elevation;
        }
    }

    public bool IsOwnedProcess
    {
        get
        {
            return (Common.Objects.Token.CurrentUserName == _processInfos.DomainName + @"\" + _processInfos.UserName);
        }
    }

    public bool IsSystemProcess
    {
        get
        {
            // TODO : localization of "NT AUTHORITY" -> now uses only UserName
            // Return _processInfos.DomainName & "\" & _processInfos.UserName = "NT AUTHORITY\SYSTEM"
            return _processInfos.UserName == "SYSTEM";
        }
    }

    public bool IsServiceProcess
    {
        get
        {
        }
    }

    public bool IsWow64Process
    {
        get
        {
            return _isWow64Process;
        }
    }

    public bool HaveFullControl
    {
        get
        {
            return _handleQueryInfo.IsNotNull() && Strings.Len(_processInfos.Path) > 0;
        }
    }


    // Merge current infos and new infos
    private int _refrehNumber = 0;

    public void ClearHistory()
    {
        lock (_dicoProcIO)
        {
            _dicoProcMem.Clear();
            _dicoProcTimes.Clear();
            _dicoProcIO.Clear();
            _dicoProcIODelta.Clear();
            _dicoProcMisc.Clear();
            _refrehNumber = 0;
        }
    }

    public void Merge(ref processInfos Proc)
    {

        // Here we do some refreshment
        if (_handleQueryInfo.IsNotNull())
        {
            Native.Objects.Token.GetProcessElevationTypeByTokenHandle(_tokenHandle, ref _elevation);   // Elevation type
            _isInJob = Native.Objects.Process.IsProcessInJob(_handleQueryInfo);
            _isBeingDebugged = Native.Objects.Process.IsDebuggerPresent(_handleQueryInfo);
            _isWow64Process = Native.Objects.Process.IsWow64Process(_handleQueryInfo);
        }

        // Private _isCritical As Boolean
        // Private _isBoostEnabled As Boolean
        // IsService ??

        // Refresh numerical infos
        refreshCpuUsage();
        refreshIODelta();

        _refrehNumber += 1;   // This is the key for the history

        // Get date in ms
        long _now = DateTime.Now.Ticks;

        _processInfos.Merge(ref Proc);
        RefreshSpecialInformations();

        // Remove items from history if buffer is full
        int d = _refrehNumber - _histBuff;
        if (_histBuff > 0 && d > 0)
        {
            _dicoProcMem.Remove(d);
            _dicoProcTimes.Remove(d);
            _dicoProcIO.Remove(d);
            _dicoProcIODelta.Remove(d);
            _dicoProcMisc.Remove(d);
        }

        // Store history
        lock (_dicoProcIO)
        {
            _dicoProcMem.Add(_refrehNumber, new Native.Api.Structs.ProcMemInfo(_now, this.Infos.MemoryInfos));
            _dicoProcTimes.Add(_refrehNumber, new Native.Api.Structs.ProcTimeInfo(_now, this.Infos.UserTime, this.Infos.KernelTime));
            _dicoProcIO.Add(_refrehNumber, new Native.Api.Structs.ProcIoInfo(_now, this.Infos.IOValues));
            _dicoProcIODelta.Add(_refrehNumber, new Native.Api.Structs.ProcIoInfo(_now, _ioDelta));
            _dicoProcMisc.Add(_refrehNumber, new Native.Api.Structs.ProcMiscInfo(_now, this.Infos.GdiObjects, this.Infos.UserObjects, 100 * this.CpuUsage, 100 * this.Infos.AverageCpuUsage));
        }

        HasMerged?.Invoke();
    }
    public void Merge(ref Native.Api.NativeStructs.SystemProcessInformation Proc)
    {
        _processInfos.Merge(ref new processInfos(ref Proc));
        RefreshSpecialInformations();
    }


    // Refresh some non fixed infos
    // For now IT IS NOT ASYNC
    // Because create ~50 threads/sec is not really cool
    private asyncCallbackProcGetNonFixedInfos _asyncNonFixed;

    private asyncCallbackProcGetNonFixedInfos asyncNonFixed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _asyncNonFixed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_asyncNonFixed != null)
            {
                _asyncNonFixed.GatheredInfos -= nonFixedInfosGathered;
            }

            _asyncNonFixed = value;
            if (_asyncNonFixed != null)
            {
                _asyncNonFixed.GatheredInfos += nonFixedInfosGathered;
            }
        }
    }

    private void RefreshSpecialInformations()
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
                    if (asyncNonFixed == null)
                        asyncNonFixed = new asyncCallbackProcGetNonFixedInfos(this.Infos.ProcessId, ref _connection, _handleQueryInfo);
                    asyncNonFixed.Process();
                    break;
                }
        }
    }
    private void nonFixedInfosGathered(asyncCallbackProcGetNonFixedInfos.TheseInfos infos)
    {
        this.Infos.UserObjects = infos.userO;
        this.Infos.GdiObjects = infos.gdiO;
        this.Infos.AffinityMask = infos.affinity;
    }



    // Create dump file
    private asyncCallbackProcMinidump _createDumpF;
    public void CreateDumpFile(string file, Native.Api.NativeEnums.MiniDumpType opt)
    {
        if (_createDumpF == null)
            _createDumpF = new asyncCallbackProcMinidump(new asyncCallbackProcMinidump.HasCreatedDump(createdMinidump), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_createDumpF.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcMinidump.poolObj(this.Infos.ProcessId, file, opt, newAction));
    }
    private void createdMinidump(bool Success, int pid, string file, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not create minidump file for process " + pid.ToString() + " : " + msg);
        else
            Misc.ShowMsg("Mini dump file", null, "The dump file has been created successfully.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        RemovePendingTask(actionNumber);
    }


    // Set priority
    private asyncCallbackProcSetPriority _setPriorityP;
    public int SetPriority(ProcessPriorityClass level)
    {
        if (_setPriorityP == null)
            _setPriorityP = new asyncCallbackProcSetPriority(new asyncCallbackProcSetPriority.HasSetPriority(setPriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_setPriorityP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcSetPriority.poolObj(this.Infos.ProcessId, level, newAction));
    }
    private void setPriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Kill a process
    private asyncCallbackProcKill _killP;
    public int Kill()
    {
        if (_killP == null)
            _killP = new asyncCallbackProcKill(new asyncCallbackProcKill.HasKilled(killDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcKill.poolObj(this.Infos.ProcessId, newAction));
    }
    private void killDone(bool Success, int pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill process " + this.Infos.Name + " (" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Kill a process by method
    private asyncCallbackProcKillByMethod _killPM;
    public int KillByMethod(Native.Api.Enums.KillMethod method)
    {
        if (_killPM == null)
            _killPM = new asyncCallbackProcKillByMethod(new asyncCallbackProcKillByMethod.HasKilled(killDoneM), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killPM.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcKillByMethod.poolObj(this.Infos.ProcessId, method, newAction));
    }
    private void killDoneM(bool Success, int pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill process by method " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Decrease priority
    private asyncCallbackProcDecreasePriority _decP;
    public int DecreasePriority()
    {
        if (_decP == null)
            _decP = new asyncCallbackProcDecreasePriority(new asyncCallbackProcDecreasePriority.HasDecreasedPriority(decreasePriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_decP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcDecreasePriority.poolObj(this.Infos.ProcessId, this.Infos.Priority, newAction));
    }
    private void decreasePriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Increase priority
    private asyncCallbackProcIncreasePriority _incP;
    public int IncreasePriority()
    {
        if (_incP == null)
            _incP = new asyncCallbackProcIncreasePriority(new asyncCallbackProcIncreasePriority.HasIncreasedPriority(increasePriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_incP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcIncreasePriority.poolObj(this.Infos.ProcessId, this.Infos.Priority, newAction));
    }
    private void increasePriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Suspend a process
    private asyncCallbackProcSuspend _suspP;
    public int SuspendProcess()
    {
        if (_suspP == null)
            _suspP = new asyncCallbackProcSuspend(new asyncCallbackProcSuspend.HasSuspended(suspendDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_suspP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcSuspend.poolObj(this.Infos.ProcessId, newAction));
    }
    private void suspendDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not suspend process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Resume a process
    private asyncCallbackProcResume _resuP;
    public int ResumeProcess()
    {
        if (_resuP == null)
            _resuP = new asyncCallbackProcResume(new asyncCallbackProcResume.HasResumed(resumeDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_resuP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcResume.poolObj(this.Infos.ProcessId, newAction));
    }
    private void resumeDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not resume process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Kill a process tree
    private asyncCallbackProcKillTree _killTP;
    public int KillProcessTree()
    {
        if (_killTP == null)
            _killTP = new asyncCallbackProcKillTree(new asyncCallbackProcKillTree.HasKilled(recursiveKillDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killTP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcKillTree.poolObj(this.Infos.ProcessId, newAction));
    }
    private void recursiveKillDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Empty working set size
    private asyncCallbackProcEmptyWorkingSet _emptyP;
    public int EmptyWorkingSetSize()
    {
        if (_emptyP == null)
            _emptyP = new asyncCallbackProcEmptyWorkingSet(new asyncCallbackProcEmptyWorkingSet.HasReducedWorkingSet(emptyWorkingSetSizeDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_emptyP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcEmptyWorkingSet.poolObj(this.Infos.ProcessId, newAction));
    }
    private void emptyWorkingSetSizeDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not empty working set of process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Change affinity
    private asyncCallbackProcSetAffinity _setAffinityP;
    public int SetAffinity(int affinity)
    {
        if (_setAffinityP == null)
            _setAffinityP = new asyncCallbackProcSetAffinity(new asyncCallbackProcSetAffinity.HasSetAffinity(setAffinityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_setAffinityP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcSetAffinity.poolObj(this.Infos.ProcessId, affinity, newAction));
    }
    private void setAffinityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set affinity to process " + this.Infos.Name + "(" + this.Infos.ProcessId.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }



    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return processInfos.GetAvailableProperties(includeFirstProp, sorted);
    }

    // Retrieve informations by its name
    public override string GetInformation(string info)
    {
        string res = Program.NO_INFO_RETRIEVED;

        if (info == "ObjectCreationDate")
            res = _objectCreationDate.ToLongDateString() + " -- " + _objectCreationDate.ToLongTimeString();
        else if (info == "PendingTaskCount")
            res = PendingTaskCount.ToString();

        res = Program.NO_INFO_RETRIEVED;
        switch (info)
        {
            case "ParentPID":
                {
                    res = this.Infos.ParentProcessId.ToString();
                    break;
                }

            case "ParentName":
                {
                    if (_parentName == Constants.vbNullString)
                    {
                        int _pi = this.Infos.ParentProcessId;
                        if (_pi > 4)
                        {
                            _parentName = GetProcessName(this.Infos.ParentProcessId);
                            if (Strings.Len(_parentName) == 0)
                                _parentName = "[Parent killed]";
                        }
                        else if (_pi == 4)
                            _parentName = "Idle process";
                        else
                            _parentName = Program.NO_INFO_RETRIEVED;
                    }
                    res = _parentName;
                    break;
                }

            case "PID":
                {
                    res = this.Infos.ProcessId.ToString();
                    break;
                }

            case "UserName":
                {
                    if (My.MySettingsProperty.Settings.ShowUserGroupDomain && Strings.Len(this.Infos.DomainName) > 0)
                        res = this.Infos.DomainName + @"\" + this.Infos.UserName;
                    else
                        res = this.Infos.UserName;
                    break;
                }

            case "CpuUsage":
                {
                    res = Misc.GetFormatedPercentage(this.CpuUsage);
                    break;
                }

            case "KernelCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.KernelTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "UserCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.UserTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "TotalCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.ProcessorTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "StartTime":
                {
                    if (this.Infos.StartTime > 0)
                    {
                        DateTime ts = new DateTime(this.Infos.StartTime);
                        res = ts.ToLongDateString() + " -- " + ts.ToLongTimeString();
                    }

                    break;
                }

            case "WorkingSet":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.WorkingSetSize);
                    break;
                }

            case "PeakWorkingSet":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PeakWorkingSetSize);
                    break;
                }

            case "PageFaultCount":
                {
                    res = this.Infos.MemoryInfos.PageFaultCount.ToString();
                    break;
                }

            case "PagefileUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PagefileUsage);
                    break;
                }

            case "PeakPagefileUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PeakPagefileUsage);
                    break;
                }

            case "QuotaPeakPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPeakPagedPoolUsage);
                    break;
                }

            case "QuotaPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPagedPoolUsage);
                    break;
                }

            case "QuotaPeakNonPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPeakNonPagedPoolUsage);
                    break;
                }

            case "QuotaNonPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaNonPagedPoolUsage);
                    break;
                }

            case "Priority":
                {
                    res = this.Infos.Priority.ToString();
                    break;
                }

            case "Path":
                {
                    res = this.Infos.Path;
                    break;
                }

            case "Description":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.FileDescription;
                    break;
                }

            case "Copyright":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.LegalCopyright;
                    break;
                }

            case "Version":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.FileVersion;
                    break;
                }

            case "Company":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.CompanyName;
                    break;
                }

            case "Name":
                {
                    res = this.Infos.Name;
                    break;
                }

            case "GdiObjects":
                {
                    res = this.Infos.GdiObjects.ToString();
                    break;
                }

            case "UserObjects":
                {
                    res = this.Infos.UserObjects.ToString();
                    break;
                }

            case "RunTime":
                {
                    DateTime ts = new DateTime(DateTime.Now.Ticks - this.Infos.StartTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "AffinityMask":
                {
                    res = this.Infos.AffinityMask.ToString();
                    break;
                }

            case "AverageCpuUsage":
                {
                    res = Misc.GetFormatedPercentage(this.Infos.AverageCpuUsage, force0: true);
                    break;
                }

            case "CommandLine":
                {
                    res = this.Infos.CommandLine;
                    break;
                }

            case "ReadOperationCount":
                {
                    res = this.Infos.IOValues.ReadOperationCount.ToString();
                    break;
                }

            case "WriteOperationCount":
                {
                    res = this.Infos.IOValues.WriteOperationCount.ToString();
                    break;
                }

            case "OtherOperationCount":
                {
                    res = this.Infos.IOValues.OtherOperationCount.ToString();
                    break;
                }

            case "ReadTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.ReadTransferCount);
                    break;
                }

            case "WriteTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.WriteTransferCount);
                    break;
                }

            case "OtherTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.OtherTransferCount);
                    break;
                }

            case "ReadOperationCountDelta":
                {
                    res = _ioDelta.ReadOperationCount.ToString();
                    break;
                }

            case "WriteOperationCountDelta":
                {
                    res = _ioDelta.WriteOperationCount.ToString();
                    break;
                }

            case "OtherOperationCountDelta":
                {
                    res = _ioDelta.OtherOperationCount.ToString();
                    break;
                }

            case "ReadTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.ReadTransferCount);
                    break;
                }

            case "WriteTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.WriteTransferCount);
                    break;
                }

            case "OtherTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.OtherTransferCount);
                    break;
                }

            case "TotalIoDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.OtherTransferCount + _ioDelta.WriteTransferCount + _ioDelta.ReadTransferCount);
                    break;
                }

            case "HandleCount":
                {
                    res = this.Infos.HandleCount.ToString();
                    break;
                }

            case "ThreadCount":
                {
                    res = this.Infos.ThreadCount.ToString();
                    break;
                }

            case "InJob":
                {
                    res = this.IsInJob.ToString();
                    break;
                }

            case "Elevation":
                {
                    res = this.ElevationType.ToString();
                    break;
                }

            case "BeingDebugged":
                {
                    res = this.IsBeingDebugged.ToString();
                    break;
                }

            case "OwnedProcess":
                {
                    res = this.IsOwnedProcess.ToString();
                    break;
                }

            case "SystemProcess":
                {
                    res = this.IsSystemProcess.ToString();
                    break;
                }

            case "ServiceProcess":
                {
                    res = this.IsServiceProcess.ToString();
                    break;
                }

            case "CriticalProcess":
                {
                    res = this.IsCriticalProcess.ToString();
                    break;
                }

            case "IsWow64":
                {
                    res = this.IsWow64Process.ToString();
                    break;
                }
        }

        return res;
    }
    public override bool GetInformation(string info, ref string res)
    {
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 

        ' Old values (from last refresh)
        Static _old_ObjectCreationDate As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PendingTaskCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ParentName As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ParentPID As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PID As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_UserName As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_CpuUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_KernelCpuTime As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_UserCpuTime As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_TotalCpuTime As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_StartTime As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_WorkingSet As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PeakWorkingSet As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PageFaultCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PagefileUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_PeakPagefileUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_QuotaPeakPagedPoolUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_QuotaPagedPoolUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_QuotaPeakNonPagedPoolUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_QuotaNonPagedPoolUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Priority As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Path As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Description As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Copyright As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Version As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_CompanyName As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Name As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_GdiObjects As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_UserObjects As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_RunTime As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_AffinityMask As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_AverageCpuUsage As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_CommandLine As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ReadOperationCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_WriteOperationCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_OtherOperationCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ReadTransferCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_WriteTransferCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_OtherTransferCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ReadOperationCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_WriteOperationCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_OtherOperationCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ReadTransferCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_WriteTransferCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_OtherTransferCountDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_TotalIoDelta As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_HandleCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ThreadCount As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_InJob As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_Elevation As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_BeingDebugged As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_OwnedProcess As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_SystemProcess As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_ServiceProcess As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_CriticalProcess As String = ""

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static _old_IsWow64Process As String = ""

 */
        bool hasChanged = true;

        if (info == "ObjectCreationDate")
        {
            res = _objectCreationDate.ToLongDateString() + " -- " + _objectCreationDate.ToLongTimeString();
            if (res == _old_ObjectCreationDate)
                return false;
            else
            {
                _old_ObjectCreationDate = res;
                return true;
            }
        }
        else if (info == "PendingTaskCount")
        {
            res = PendingTaskCount.ToString();
            if (res == _old_PendingTaskCount)
                return false;
            else
            {
                _old_PendingTaskCount = res;
                return true;
            }
        }

        res = Program.NO_INFO_RETRIEVED;
        switch (info)
        {
            case "ParentPID":
                {
                    res = this.Infos.ParentProcessId.ToString();
                    if (res == _old_ParentPID)
                        hasChanged = false;
                    else
                        _old_ParentPID = res;
                    break;
                }

            case "ParentName":
                {
                    if (_parentName == Constants.vbNullString)
                    {
                        int _pi = this.Infos.ParentProcessId;
                        if (_pi > 4)
                        {
                            _parentName = GetProcessName(this.Infos.ParentProcessId);
                            if (Strings.Len(_parentName) == 0)
                                _parentName = "[Parent killed]";
                        }
                        else if (_pi == 4)
                            _parentName = "Idle process";
                        else
                            _parentName = Program.NO_INFO_RETRIEVED;
                    }
                    res = _parentName;
                    if (res == _old_ParentName)
                        hasChanged = false;
                    else
                        _old_ParentName = res;
                    break;
                }

            case "PID":
                {
                    res = this.Infos.ProcessId.ToString();
                    if (res == _old_PID)
                        hasChanged = false;
                    else
                        _old_PID = res;
                    break;
                }

            case "UserName":
                {
                    if (My.MySettingsProperty.Settings.ShowUserGroupDomain && Strings.Len(this.Infos.DomainName) > 0)
                        res = this.Infos.DomainName + @"\" + this.Infos.UserName;
                    else
                        res = this.Infos.UserName;
                    if (res == _old_UserName)
                        hasChanged = false;
                    else
                        _old_UserName = res;
                    break;
                }

            case "CpuUsage":
                {
                    res = Misc.GetFormatedPercentage(this.CpuUsage);
                    if (res == _old_CpuUsage)
                        hasChanged = false;
                    else
                        _old_CpuUsage = res;
                    break;
                }

            case "KernelCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.KernelTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_KernelCpuTime)
                        hasChanged = false;
                    else
                        _old_KernelCpuTime = res;
                    break;
                }

            case "UserCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.UserTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_UserCpuTime)
                        hasChanged = false;
                    else
                        _old_UserCpuTime = res;
                    break;
                }

            case "TotalCpuTime":
                {
                    DateTime ts = new DateTime(this.Infos.ProcessorTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_TotalCpuTime)
                        hasChanged = false;
                    else
                        _old_TotalCpuTime = res;
                    break;
                }

            case "StartTime":
                {
                    if (this.Infos.StartTime > 0)
                    {
                        DateTime ts = new DateTime(this.Infos.StartTime);
                        res = ts.ToLongDateString() + " -- " + ts.ToLongTimeString();
                    }
                    if (res == _old_StartTime)
                        hasChanged = false;
                    else
                        _old_StartTime = res;
                    break;
                }

            case "WorkingSet":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.WorkingSetSize);
                    if (res == _old_WorkingSet)
                        hasChanged = false;
                    else
                        _old_WorkingSet = res;
                    break;
                }

            case "PeakWorkingSet":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PeakWorkingSetSize);
                    if (res == _old_PeakWorkingSet)
                        hasChanged = false;
                    else
                        _old_PeakWorkingSet = res;
                    break;
                }

            case "PageFaultCount":
                {
                    res = this.Infos.MemoryInfos.PageFaultCount.ToString();
                    if (res == _old_PageFaultCount)
                        hasChanged = false;
                    else
                        _old_PageFaultCount = res;
                    break;
                }

            case "PagefileUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PagefileUsage);
                    if (res == _old_PagefileUsage)
                        hasChanged = false;
                    else
                        _old_PagefileUsage = res;
                    break;
                }

            case "PeakPagefileUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.PeakPagefileUsage);
                    if (res == _old_PeakPagefileUsage)
                        hasChanged = false;
                    else
                        _old_PeakPagefileUsage = res;
                    break;
                }

            case "QuotaPeakPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPeakPagedPoolUsage);
                    if (res == _old_QuotaPeakPagedPoolUsage)
                        hasChanged = false;
                    else
                        _old_QuotaPeakPagedPoolUsage = res;
                    break;
                }

            case "QuotaPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPagedPoolUsage);
                    if (res == _old_QuotaPagedPoolUsage)
                        hasChanged = false;
                    else
                        _old_QuotaPagedPoolUsage = res;
                    break;
                }

            case "QuotaPeakNonPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaPeakNonPagedPoolUsage);
                    if (res == _old_QuotaPeakNonPagedPoolUsage)
                        hasChanged = false;
                    else
                        _old_QuotaPeakNonPagedPoolUsage = res;
                    break;
                }

            case "QuotaNonPagedPoolUsage":
                {
                    res = Misc.GetFormatedSize(this.Infos.MemoryInfos.QuotaNonPagedPoolUsage);
                    if (res == _old_QuotaNonPagedPoolUsage)
                        hasChanged = false;
                    else
                        _old_QuotaNonPagedPoolUsage = res;
                    break;
                }

            case "Priority":
                {
                    res = this.Infos.Priority.ToString();
                    if (res == _old_Priority)
                        hasChanged = false;
                    else
                        _old_Priority = res;
                    break;
                }

            case "Path":
                {
                    res = this.Infos.Path;
                    if (res == _old_Path)
                        hasChanged = false;
                    else
                        _old_Path = res;
                    break;
                }

            case "Description":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.FileDescription;
                    if (res == _old_Description)
                        hasChanged = false;
                    else
                        _old_Description = res;
                    break;
                }

            case "Copyright":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.LegalCopyright;
                    if (res == _old_Copyright)
                        hasChanged = false;
                    else
                        _old_Copyright = res;
                    break;
                }

            case "Version":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.FileVersion;
                    if (res == _old_Version)
                        hasChanged = false;
                    else
                        _old_Version = res;
                    break;
                }

            case "Company":
                {
                    if (this.Infos.FileInfo != null)
                        res = this.Infos.FileInfo.CompanyName;
                    if (res == _old_CompanyName)
                        hasChanged = false;
                    else
                        _old_CompanyName = res;
                    break;
                }

            case "Name":
                {
                    res = this.Infos.Name;
                    if (this.IsWow64Process)
                        res += " * 32";
                    if (res == _old_Name)
                        hasChanged = false;
                    else
                        _old_Name = res;
                    break;
                }

            case "GdiObjects":
                {
                    res = this.Infos.GdiObjects.ToString();
                    if (res == _old_GdiObjects)
                        hasChanged = false;
                    else
                        _old_GdiObjects = res;
                    break;
                }

            case "UserObjects":
                {
                    res = this.Infos.UserObjects.ToString();
                    if (res == _old_UserObjects)
                        hasChanged = false;
                    else
                        _old_UserObjects = res;
                    break;
                }

            case "RunTime":
                {
                    DateTime ts = new DateTime(DateTime.Now.Ticks - this.Infos.StartTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_RunTime)
                        hasChanged = false;
                    else
                        _old_RunTime = res;
                    break;
                }

            case "AffinityMask":
                {
                    res = this.Infos.AffinityMask.ToString();
                    if (res == _old_AffinityMask)
                        hasChanged = false;
                    else
                        _old_AffinityMask = res;
                    break;
                }

            case "AverageCpuUsage":
                {
                    res = Misc.GetFormatedPercentage(this.Infos.AverageCpuUsage, force0: true);
                    if (res == _old_AverageCpuUsage)
                        hasChanged = false;
                    else
                        _old_AverageCpuUsage = res;
                    break;
                }

            case "CommandLine":
                {
                    res = this.Infos.CommandLine;
                    if (res == _old_CommandLine)
                        hasChanged = false;
                    else
                        _old_CommandLine = res;
                    break;
                }

            case "ReadOperationCount":
                {
                    res = this.Infos.IOValues.ReadOperationCount.ToString();
                    if (res == _old_ReadOperationCount)
                        hasChanged = false;
                    else
                        _old_ReadOperationCount = res;
                    break;
                }

            case "WriteOperationCount":
                {
                    res = this.Infos.IOValues.WriteOperationCount.ToString();
                    if (res == _old_WriteOperationCount)
                        hasChanged = false;
                    else
                        _old_WriteOperationCount = res;
                    break;
                }

            case "OtherOperationCount":
                {
                    res = this.Infos.IOValues.OtherOperationCount.ToString();
                    if (res == _old_OtherOperationCount)
                        hasChanged = false;
                    else
                        _old_OtherOperationCount = res;
                    break;
                }

            case "ReadTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.ReadTransferCount);
                    if (res == _old_ReadTransferCount)
                        hasChanged = false;
                    else
                        _old_ReadTransferCount = res;
                    break;
                }

            case "WriteTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.WriteTransferCount);
                    if (res == _old_WriteTransferCount)
                        hasChanged = false;
                    else
                        _old_WriteTransferCount = res;
                    break;
                }

            case "OtherTransferCount":
                {
                    res = Misc.GetFormatedSize(this.Infos.IOValues.OtherTransferCount);
                    if (res == _old_OtherTransferCount)
                        hasChanged = false;
                    else
                        _old_OtherTransferCount = res;
                    break;
                }

            case "ReadOperationCountDelta":
                {
                    res = _ioDelta.ReadOperationCount.ToString();
                    if (res == _old_ReadOperationCountDelta)
                        hasChanged = false;
                    else
                        _old_ReadOperationCountDelta = res;
                    break;
                }

            case "WriteOperationCountDelta":
                {
                    res = _ioDelta.WriteOperationCount.ToString();
                    if (res == _old_WriteOperationCountDelta)
                        hasChanged = false;
                    else
                        _old_WriteOperationCountDelta = res;
                    break;
                }

            case "OtherOperationCountDelta":
                {
                    res = _ioDelta.OtherOperationCount.ToString();
                    if (res == _old_OtherOperationCountDelta)
                        hasChanged = false;
                    else
                        _old_OtherOperationCountDelta = res;
                    break;
                }

            case "ReadTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.ReadTransferCount);
                    if (res == _old_ReadTransferCountDelta)
                        hasChanged = false;
                    else
                        _old_ReadTransferCountDelta = res;
                    break;
                }

            case "WriteTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.WriteTransferCount);
                    if (res == _old_WriteTransferCountDelta)
                        hasChanged = false;
                    else
                        _old_WriteTransferCountDelta = res;
                    break;
                }

            case "OtherTransferCountDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.OtherTransferCount);
                    if (res == _old_OtherTransferCountDelta)
                        hasChanged = false;
                    else
                        _old_OtherTransferCountDelta = res;
                    break;
                }

            case "TotalIoDelta":
                {
                    res = Misc.GetFormatedSizePerSecond(_ioDelta.OtherTransferCount + _ioDelta.ReadTransferCount + _ioDelta.WriteTransferCount);
                    if (res == _old_TotalIoDelta)
                        hasChanged = false;
                    else
                        _old_TotalIoDelta = res;
                    break;
                }

            case "HandleCount":
                {
                    res = this.Infos.HandleCount.ToString();
                    if (res == _old_HandleCount)
                        hasChanged = false;
                    else
                        _old_HandleCount = res;
                    break;
                }

            case "ThreadCount":
                {
                    res = this.Infos.ThreadCount.ToString();
                    if (res == _old_ThreadCount)
                        hasChanged = false;
                    else
                        _old_ThreadCount = res;
                    break;
                }

            case "InJob":
                {
                    res = this.IsInJob.ToString();
                    if (res == _old_InJob)
                        hasChanged = false;
                    else
                        _old_InJob = res;
                    break;
                }

            case "Elevation":
                {
                    res = this.ElevationType.ToString();
                    if (res == _old_Elevation)
                        hasChanged = false;
                    else
                        _old_Elevation = res;
                    break;
                }

            case "BeingDebugged":
                {
                    res = this.IsBeingDebugged.ToString();
                    if (res == _old_BeingDebugged)
                        hasChanged = false;
                    else
                        _old_BeingDebugged = res;
                    break;
                }

            case "OwnedProcess":
                {
                    res = this.IsOwnedProcess.ToString();
                    if (res == _old_OwnedProcess)
                        hasChanged = false;
                    else
                        _old_OwnedProcess = res;
                    break;
                }

            case "SystemProcess":
                {
                    res = this.IsSystemProcess.ToString();
                    if (res == _old_SystemProcess)
                        hasChanged = false;
                    else
                        _old_SystemProcess = res;
                    break;
                }

            case "ServiceProcess":
                {
                    res = this.IsServiceProcess.ToString();
                    if (res == _old_ServiceProcess)
                        hasChanged = false;
                    else
                        _old_ServiceProcess = res;
                    break;
                }

            case "CriticalProcess":
                {
                    res = this.IsCriticalProcess.ToString();
                    if (res == _old_CriticalProcess)
                        hasChanged = false;
                    else
                        _old_CriticalProcess = res;
                    break;
                }

            case "IsWow64":
                {
                    res = this.IsWow64Process.ToString();
                    if (res == _old_IsWow64Process)
                        hasChanged = false;
                    else
                        _old_IsWow64Process = res;
                    break;
                }
        }

        return hasChanged;
    }

    // Retrieve informations by its name (numerical)
    public double GetInformationNumerical(string infoName)
    {
        double res = 0;

        switch (infoName)
        {
            case "KernelCpuTime":
                {
                    res = this.Infos.KernelTime;
                    break;
                }

            case "UserCpuTime":
                {
                    res = this.Infos.UserTime;
                    break;
                }

            case "TotalCpuTime":
                {
                    res = this.Infos.ProcessorTime;
                    break;
                }

            case "WorkingSet":
                {
                    res = this.Infos.MemoryInfos.WorkingSetSize.ToInt64();
                    break;
                }

            case "PeakWorkingSet":
                {
                    res = this.Infos.MemoryInfos.PeakWorkingSetSize.ToInt64();
                    break;
                }

            case "PageFaultCount":
                {
                    res = this.Infos.MemoryInfos.PageFaultCount;
                    break;
                }

            case "PagefileUsage":
                {
                    res = this.Infos.MemoryInfos.PagefileUsage.ToInt64();
                    break;
                }

            case "PeakPagefileUsage":
                {
                    res = this.Infos.MemoryInfos.PeakPagefileUsage.ToInt64();
                    break;
                }

            case "QuotaPeakPagedPoolUsage":
                {
                    res = this.Infos.MemoryInfos.QuotaPeakPagedPoolUsage.ToInt64();
                    break;
                }

            case "QuotaPagedPoolUsage":
                {
                    res = this.Infos.MemoryInfos.QuotaPagedPoolUsage.ToInt64();
                    break;
                }

            case "QuotaPeakNonPagedPoolUsage":
                {
                    res = this.Infos.MemoryInfos.QuotaPeakNonPagedPoolUsage.ToInt64();
                    break;
                }

            case "QuotaNonPagedPoolUsage":
                {
                    res = this.Infos.MemoryInfos.QuotaNonPagedPoolUsage.ToInt64();
                    break;
                }

            case "GdiObjects":
                {
                    res = this.Infos.GdiObjects;
                    break;
                }

            case "UserObjects":
                {
                    res = this.Infos.UserObjects;
                    break;
                }

            case "ReadOperationCount":
                {
                    res = this.Infos.IOValues.ReadOperationCount;
                    break;
                }

            case "WriteOperationCount":
                {
                    res = this.Infos.IOValues.WriteOperationCount;
                    break;
                }

            case "OtherOperationCount":
                {
                    res = this.Infos.IOValues.OtherOperationCount;
                    break;
                }

            case "ReadTransferCount":
                {
                    res = this.Infos.IOValues.ReadTransferCount;
                    break;
                }

            case "WriteTransferCount":
                {
                    res = this.Infos.IOValues.WriteTransferCount;
                    break;
                }

            case "OtherTransferCount":
                {
                    res = this.Infos.IOValues.OtherTransferCount;
                    break;
                }

            case "ReadOperationCountDelta":
                {
                    res = _ioDelta.ReadOperationCount;
                    break;
                }

            case "WriteOperationCountDelta":
                {
                    res = _ioDelta.WriteOperationCount;
                    break;
                }

            case "OtherOperationCountDelta":
                {
                    res = _ioDelta.OtherOperationCount;
                    break;
                }

            case "ReadTransferCountDelta":
                {
                    res = _ioDelta.ReadTransferCount;
                    break;
                }

            case "WriteTransferCountDelta":
                {
                    res = _ioDelta.WriteTransferCount;
                    break;
                }

            case "OtherTransferCountDelta":
                {
                    res = _ioDelta.OtherTransferCount;
                    break;
                }

            case "TotalIoDelta":
                {
                    res = _ioDelta.OtherTransferCount + _ioDelta.WriteTransferCount + _ioDelta.ReadTransferCount;
                    break;
                }

            case "CpuUsage":
                {
                    res = 100 * this.CpuUsage;
                    break;
                }

            case "AverageCpuUsage":
                {
                    res = 100 * this.Infos.AverageCpuUsage;
                    break;
                }

            case "HandleCount":
                {
                    res = this.Infos.HandleCount;
                    break;
                }
        }

        return res;
    }



    // Return process from id
    public static cProcess GetProcessById(int pid)
    {
        return Native.Objects.Process.GetProcessById(pid);
    }

    // Return Process name
    public static string GetProcessName(int pid)
    {
        switch (pid)
        {
            case 0:
                {
                    return "[System Process]";
                }

            case 4:
                {
                    return "System";
                }

            default:
                {
                    if (_procs.ContainsKey(pid.ToString()))
                        return _procs[pid.ToString()];
                    else
                        return Program.NO_INFO_RETRIEVED;
                    break;
                }
        }
    }

    // Kill a process
    private static asyncCallbackProcKill _sharedKillP;
    public static int SharedLRKill(int pid)
    {
        if (_sharedKillP == null)
            _sharedKillP = new asyncCallbackProcKill(new asyncCallbackProcKill.HasKilled(killDoneShared), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_sharedKillP.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcKill.poolObj(pid, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void killDoneShared(bool Success, int pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill process " + pid.ToString() + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }

    // Start a process
    private static asyncCallbackProcNewProcess _newSharedP;
    public static int SharedRLStartNewProcess(string path)
    {
        if (_newSharedP == null)
            _newSharedP = new asyncCallbackProcNewProcess(new asyncCallbackProcNewProcess.HasCreated(newProcessDoneShared), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_newSharedP.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcNewProcess.poolObj(path, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void newProcessDoneShared(bool Success, string path, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not start process " + path + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }


    // Unload a module from a process
    private static asyncCallbackProcUnloadModule _unloadMSharedP;
    public static int SharedRLUnLoadModuleFromProcess(int pid, IntPtr ModuleBaseAddress)
    {
        if (_unloadMSharedP == null)
            _unloadMSharedP = new asyncCallbackProcUnloadModule(new asyncCallbackProcUnloadModule.HasUnloadedModule(unloadModuleDoneShared), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_unloadMSharedP.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcUnloadModule.poolObj(pid, ModuleBaseAddress, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void unloadModuleDoneShared(bool Success, int pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not unload module from process " + pid.ToString() + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }


    // Clear process dico
    public static void ClearProcessDico()
    {
        _procs.Clear();
    }

    // Add/remove a process to dictionnary
    public static void AssociatePidAndName(string pid, string name)
    {
        if (_procs.ContainsKey(pid) == false)
            _procs.Add(pid, name);
    }
    public static void UnAssociatePidAndName(string pid)
    {
        _procs.Remove(pid);
    }



    public static bool LocalKill(int pid)
    {
        return Native.Objects.Process.KillProcessById(pid);
    }


    // Retrieve a long array with all available values from dictionnaries
    public double[] GetHistory(string infoName)
    {
        double[] ret;

        switch (infoName)
        {
            case "KernelCpuTime":
                {
                    ret = new double[_dicoProcTimes.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcTimeInfo t in _dicoProcTimes.Values)
                    {
                        ret[x] = t.kernel;
                        x += 1;
                    }

                    break;
                }

            case "UserCpuTime":
                {
                    ret = new double[_dicoProcTimes.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcTimeInfo t in _dicoProcTimes.Values)
                    {
                        ret[x] = t.user;
                        x += 1;
                    }

                    break;
                }

            case "TotalCpuTime":
                {
                    ret = new double[_dicoProcTimes.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcTimeInfo t in _dicoProcTimes.Values)
                    {
                        ret[x] = t.total;
                        x += 1;
                    }

                    break;
                }

            case "WorkingSet":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.WorkingSetSize.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "PeakWorkingSet":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.PeakWorkingSetSize.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "PageFaultCount":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.PageFaultCount;
                        x += 1;
                    }

                    break;
                }

            case "PagefileUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.PagefileUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "PeakPagefileUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.PeakPagefileUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "QuotaPeakPagedPoolUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.QuotaPeakPagedPoolUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "QuotaPagedPoolUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.QuotaPagedPoolUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "QuotaPeakNonPagedPoolUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.QuotaPeakNonPagedPoolUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "QuotaNonPagedPoolUsage":
                {
                    ret = new double[_dicoProcMem.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMemInfo t in _dicoProcMem.Values)
                    {
                        ret[x] = t.mem.QuotaNonPagedPoolUsage.ToInt64();
                        x += 1;
                    }

                    break;
                }

            case "ReadOperationCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.ReadOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "WriteOperationCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.WriteOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "OtherOperationCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.OtherOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "ReadTransferCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.ReadTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "WriteTransferCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.WriteTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "OtherTransferCount":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIO.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.OtherTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "GdiObjects":
                {
                    ret = new double[_dicoProcMisc.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMiscInfo t in _dicoProcMisc.Values)
                    {
                        ret[x] = t.gdiO;
                        x += 1;
                    }

                    break;
                }

            case "UserObjects":
                {
                    ret = new double[_dicoProcMisc.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMiscInfo t in _dicoProcMisc.Values)
                    {
                        ret[x] = t.userO;
                        x += 1;
                    }

                    break;
                }

            case "CpuUsage":
                {
                    ret = new double[_dicoProcMisc.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMiscInfo t in _dicoProcMisc.Values)
                    {
                        ret[x] = t.cpuUsage;
                        x += 1;
                    }

                    break;
                }

            case "AverageCpuUsage":
                {
                    ret = new double[_dicoProcMisc.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcMiscInfo t in _dicoProcMisc.Values)
                    {
                        ret[x] = t.averageCpuUsage;
                        x += 1;
                    }

                    break;
                }

            case "ReadOperationCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.ReadOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "WriteOperationCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.WriteOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "OtherOperationCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.OtherOperationCount);
                        x += 1;
                    }

                    break;
                }

            case "ReadTransferCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.ReadTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "WriteTransferCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.WriteTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "OtherTransferCountDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.OtherTransferCount);
                        x += 1;
                    }

                    break;
                }

            case "TotalIoDelta":
                {
                    ret = new double[_dicoProcIO.Count - 1 + 1];
                    int x = 0;
                    foreach (Native.Api.Structs.ProcIoInfo t in _dicoProcIODelta.Values)
                    {
                        ret[x] = System.Convert.ToInt64(t.io.OtherTransferCount + t.io.ReadTransferCount + t.io.WriteTransferCount);
                        x += 1;
                    }

                    break;
                }

            default:
                {
                    ret = new double[1];
                    break;
                }
        }

        return ret;
    }

    // Refresh CPU usage once
    private void refreshCpuUsage()
    {
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static oldDate As Long = Date.Now.Ticks

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static oldProcTime As Long = Me.Infos.ProcessorTime

 */
        long currDate = DateTime.Now.Ticks;
        long proctime = this.Infos.ProcessorTime;

        long diff = currDate - oldDate;
        long procDiff = proctime - oldProcTime;

        oldProcTime = proctime;
        oldDate = currDate;

        if (diff > 0 && _processors > 0)
            _cpuUsage = procDiff / (double)diff / _processors;
        else
            _cpuUsage = 0;
    }

    // Refresh IO delta once
    private void refreshIODelta()
    {
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static oldDate As Long = Date.Now.Ticks

 */
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static oldIO As Native.Api.NativeStructs.IoCounters = Me.Infos.IOValues

 */
        long currDate = DateTime.Now.Ticks;
        Native.Api.NativeStructs.IoCounters ioValues = this.Infos.IOValues;

        long diff = currDate - oldDate;
        Native.Api.NativeStructs.IoCounters ioDiff;
        {
            var withBlock = ioDiff;
            withBlock.OtherOperationCount = ioValues.OtherOperationCount - oldIO.OtherOperationCount;
            withBlock.OtherTransferCount = ioValues.OtherTransferCount - oldIO.OtherTransferCount;
            withBlock.ReadOperationCount = ioValues.ReadOperationCount - oldIO.ReadOperationCount;
            withBlock.ReadTransferCount = ioValues.ReadTransferCount - oldIO.ReadTransferCount;
            withBlock.WriteOperationCount = ioValues.WriteOperationCount - oldIO.WriteOperationCount;
            withBlock.WriteTransferCount = ioValues.WriteTransferCount - oldIO.WriteTransferCount;
        }

        oldIO = ioValues;
        oldDate = currDate;

        if (diff > 0)
        {
            {
                var withBlock1 = _ioDelta;
                withBlock1.OtherOperationCount = System.Convert.ToUInt64(ioDiff.OtherOperationCount);
                withBlock1.OtherTransferCount = System.Convert.ToUInt64((10000000 / (double)diff) * ioDiff.OtherTransferCount);
                withBlock1.ReadOperationCount = System.Convert.ToUInt64(ioDiff.ReadOperationCount);
                withBlock1.ReadTransferCount = System.Convert.ToUInt64((10000000 / (double)diff) * ioDiff.ReadTransferCount);
                withBlock1.WriteOperationCount = System.Convert.ToUInt64(ioDiff.WriteOperationCount);
                withBlock1.WriteTransferCount = System.Convert.ToUInt64((10000000 / (double)diff) * ioDiff.WriteTransferCount);
            }
        }
        else
        {
            var withBlock2 = _ioDelta;
            withBlock2.OtherOperationCount = 0;
            withBlock2.OtherTransferCount = 0;
            withBlock2.ReadOperationCount = 0;
            withBlock2.ReadTransferCount = 0;
            withBlock2.WriteOperationCount = 0;
            withBlock2.WriteTransferCount = 0;
        }
    }


    // Set highlightings
    public static void SetHighlightings(bool debug, bool job, bool elev, bool critic, bool owned, bool system, bool service)
    {
        _hlProcessBeingDebugged = debug;
        _hlProcessCritical = critic;
        _hlProcessElevated = elev;
        _hlProcessInJob = job;
        _hlProcessOwned = owned;
        _hlProcessService = service;
        _hlProcessSystem = system;
    }
    public static void SetHighlightingsColor(Color debug, Color job, Color elev, Color critic, Color owned, Color system, Color service)
    {
        _hlProcessBeingDebuggedColor = debug;
        _hlProcessCriticalColor = critic;
        _hlProcessElevatedColor = elev;
        _hlProcessInJobColor = job;
        _hlProcessOwnedColor = owned;
        _hlProcessServiceColor = service;
        _hlProcessSystemColor = system;
    }

    // Return backcolor
    public override System.Drawing.Color GetBackColor()
    {
        if (_hlProcessCritical && this.IsCriticalProcess)
            return _hlProcessCriticalColor;
        else if (_hlProcessBeingDebugged && this.IsBeingDebugged)
            return _hlProcessBeingDebuggedColor;
        else if (_hlProcessElevated && this.ElevationType == Native.Api.Enums.ElevationType.Full)
            return _hlProcessElevatedColor;
        else if (_hlProcessInJob && this.IsInJob)
            return _hlProcessInJobColor;
        else if (_hlProcessService && this.IsServiceProcess)
            return _hlProcessServiceColor;
        else if (_hlProcessOwned && this.IsOwnedProcess)
            return _hlProcessOwnedColor;
        else if (_hlProcessSystem && this.IsSystemProcess)
            return _hlProcessSystemColor;
        return base.GetBackColor();
    }

    // Return forecolor
    public override System.Drawing.Color GetForeColor()
    {
        if (this.HaveFullControl || cProcess.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.LocalConnection)
            return Misc.NON_BLACK_COLOR;
        else
            return System.Drawing.Color.Gray;
    }
}

