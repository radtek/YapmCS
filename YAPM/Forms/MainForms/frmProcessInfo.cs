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
using System.Runtime.InteropServices;
using Common.Misc;
using System.Threading;

public partial class frmProcessInfo
{
    private asyncCallbackProcGetAllNonFixedInfos _asyncAllNonFixedInfos;

    private asyncCallbackProcGetAllNonFixedInfos asyncAllNonFixedInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _asyncAllNonFixedInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_asyncAllNonFixedInfos != null)
            {
                _asyncAllNonFixedInfos.HasGotAllNonFixedInfos -= asyncAllNonFixedInfos_HasGotAllNonFixedInfos;
            }

            _asyncAllNonFixedInfos = value;
            if (_asyncAllNonFixedInfos != null)
            {
                _asyncAllNonFixedInfos.HasGotAllNonFixedInfos += asyncAllNonFixedInfos_HasGotAllNonFixedInfos;
            }
        }
    }

    private cProcess _curProc;

    private cProcess curProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _curProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_curProc != null)
            {
                _curProc.HasMerged -= curProc_Refreshed;
            }

            _curProc = value;
            if (_curProc != null)
            {
                _curProc.HasMerged += curProc_Refreshed;
            }
        }
    }

    private cAsyncProcInfoDownload __AsyncDownload;

    private cAsyncProcInfoDownload _AsyncDownload
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __AsyncDownload;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__AsyncDownload != null)
            {
                __AsyncDownload.GotInformations -= _AsyncDownload_GotInformations;
            }

            __AsyncDownload = value;
            if (__AsyncDownload != null)
            {
                __AsyncDownload.GotInformations += _AsyncDownload_GotInformations;
            }
        }
    }

    private System.Threading.Thread _asyncDlThread;

    private cConnection _theConnection;

    private cConnection theConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _theConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_theConnection != null)
            {
                _theConnection.Connected -= theConnection_Connected;
                _theConnection.Disconnected -= theConnection_Disconnected;
            }

            _theConnection = value;
            if (_theConnection != null)
            {
                _theConnection.Connected += theConnection_Connected;
                _theConnection.Disconnected += theConnection_Disconnected;
            }
        }
    }

    // String search (in process image/memory) private attributes
    private bool _stringSearchImmediateStop;   // Set to true to stop listing of string in process
    private string[] __sRes;
    private IntPtr[] __lRes;
    private ProcessRW cRW;

    private const int SIZE_FOR_STRING = 4;

    private int _historyGraphNumber = 0;
    private bool _local = true;
    private bool _notSnapshotMode = true;
    private bool _notWMI;

    // Caption to display when process has terminated
    // This also defines (if not null) that process has terminated
    private string fixedFormCaption = null;

    // The listview in which we will search using 'search panel'
    private ListView listViewForSearch;

    // ProcessHandle for process termination handler
    private IntPtr hProcSync;

    // Debug buffer
    private Native.Objects.DebugBuffer _dbgBuffer;

    // Here we finished to download informations from internet
    private cAsyncProcInfoDownload.InternetProcessInfo _asyncInfoRes;
    private bool _asyncDownloadDone = false;

    // Some declarations used for "log feature"
    private asyncCallbackLogEnumerate.LogItemType _logCaptureMask = asyncCallbackLogEnumerate.LogItemType.AllItems;
    private asyncCallbackLogEnumerate.LogItemType _logDisplayMask = asyncCallbackLogEnumerate.LogItemType.AllItems;
    private bool _autoScroll = false;
    private Dictionary<int, LogItem> _logDico = new Dictionary<int, LogItem>();

    public struct LogItem
    {
        public DateTime _date;
        public string _desc;
        public asyncCallbackLogEnumerate.LogItemType _type;
        public bool _created;
        public LogItem(string aDesc, asyncCallbackLogEnumerate.LogItemType aType, bool created)
        {
            _date = DateTime.Now;
            _desc = aDesc;
            _type = aType;
            _created = created;
        }
    }
    public asyncCallbackLogEnumerate.LogItemType LogCaptureMask
    {
        get
        {
            return _logCaptureMask;
        }
        set
        {
            _logCaptureMask = value;
        }
    }
    public asyncCallbackLogEnumerate.LogItemType LogDisplayMask
    {
        get
        {
            return _logDisplayMask;
        }
        set
        {
            _logDisplayMask = value;
        }
    }
    public bool LvAutoScroll
    {
        get
        {
            return _autoScroll;
        }
        set
        {
            _autoScroll = value;
        }
    }


    // Refresh current tab
    private void refreshProcessTab()
    {
        if (curProc == null)
            return;

        // General informations
        switch (this.tabProcess.SelectedTab.Text)
        {
            case "Token":
                {
                    if (_notWMI)
                        ShowPrivileges();
                    break;
                }

            case "Modules":
                {
                    // If _local Then _
                    ShowModules();
                    break;
                }

            case "Threads":
                {
                    // If _local Then _
                    ShowThreads();
                    break;
                }

            case "Windows":
                {
                    if (_notWMI)
                        ShowWindows();
                    break;
                }

            case "Handles":
                {
                    if (_notWMI)
                        ShowHandles();
                    break;
                }

            case "Memory":
                {
                    if (_notWMI)
                        ShowRegions();
                    break;
                }

            case "Environment":
                {
                    if (_notWMI)
                        ShowEnvVariables();
                    break;
                }

            case "Network":
                {
                    if (_notWMI)
                        ShowNetwork();
                    break;
                }

            case "Services":
                {
                    // If _local Then _
                    ShowServices();
                    break;
                }

            case "Heaps":
                {
                    if (_notWMI)
                        ShowHeaps();
                    break;
                }

            case "Strings":
                {
                    if (_local)
                        ThreadPool.QueueUserWorkItem(getProcString, curProc);
                    break;
                }

            case "General":
                {
                    this.txtProcessPath.Text = curProc.Infos.Path;
                    this.txtProcessId.Text = curProc.Infos.ProcessId.ToString();
                    this.txtParentProcess.Text = curProc.Infos.ParentProcessId.ToString() + " -- " + cProcess.GetProcessName(curProc.Infos.ParentProcessId);
                    this.txtProcessStarted.Text = new DateTime(curProc.Infos.StartTime).ToLongDateString() + " -- " + new DateTime(curProc.Infos.StartTime).ToLongTimeString();
                    this.txtProcessUser.Text = curProc.Infos.UserName;
                    this.txtCommandLine.Text = curProc.Infos.CommandLine;
                    TimeSpan sp = new TimeSpan(curProc.Infos.StartTime);
                    DateTime d = DateTime.Now.Subtract(sp);
                    if (_notSnapshotMode)
                        this.txtRunTime.Text = d.ToLongTimeString();
                    else
                        this.txtRunTime.Text = Program.NO_INFO_RETRIEVED;
                    this.txtPriority.Text = curProc.Infos.Priority.ToString();
                    if (curProc.Infos.FileInfo != null)
                    {
                        this.txtImageVersion.Text = curProc.Infos.FileInfo.FileVersion;
                        this.lblCopyright.Text = curProc.Infos.FileInfo.LegalCopyright;
                        this.lblDescription.Text = curProc.Infos.FileInfo.FileDescription;
                    }
                    else
                    {
                        this.txtImageVersion.Text = Program.NO_INFO_RETRIEVED;
                        this.lblCopyright.Text = Program.NO_INFO_RETRIEVED;
                        this.lblDescription.Text = Program.NO_INFO_RETRIEVED;
                    }

                    break;
                }

            case "Statistics":
                {

                    // OK, here's the deal :
                    // - if we are in local mode, we just display informations that
                    // are available in curproc, because the refreshment is done
                    // by the main form.
                    // - if it is a remote connection, we juste demand a refreshment, and
                    // the refreshment will be done next time we call the refreshProcessTab
                    // method.

                    refreshStatisticsTab();
                    if (cProcess.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.LocalConnection)
                        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(asyncAllNonFixedInfos.Process()));
                    break;
                }

            case "Informations":
                {

                    // OK, here's the deal :
                    // - if we are in local mode, we just display informations that
                    // are available in curproc, because the refreshment is done
                    // by the main form.
                    // - if it is a remote connection, we juste demand a refreshment, and
                    // the refreshment will be done next time we call the refreshProcessTab
                    // method.

                    refreshInfosTab();
                    if (cProcess.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.LocalConnection)
                        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(asyncAllNonFixedInfos.Process()));
                    break;
                }
        }
    }

    // Refresh statistics tab
    private void refreshStatisticsTab()
    {
        this.lblProcOther.Text = curProc.Infos.IOValues.OtherOperationCount.ToString();
        this.lblProcOtherBytes.Text = Misc.GetFormatedSize(curProc.Infos.IOValues.OtherTransferCount);
        this.lblProcReads.Text = curProc.Infos.IOValues.ReadOperationCount.ToString();
        this.lblProcReadBytes.Text = Misc.GetFormatedSize(curProc.Infos.IOValues.ReadTransferCount);
        this.lblProcWriteBytes.Text = Misc.GetFormatedSize(curProc.Infos.IOValues.WriteTransferCount);
        this.lblProcWrites.Text = curProc.Infos.IOValues.WriteOperationCount.ToString();
        this.lblGDIcount.Text = curProc.Infos.GdiObjects.ToString();
        this.lblThreads.Text = curProc.Infos.ThreadCount.ToString();
        this.lblUserObjectsCount.Text = curProc.Infos.UserObjects.ToString();
        this.lblAverageCPUusage.Text = curProc.GetInformation("AverageCpuUsage");

        this.lblRBD.Text = curProc.GetInformation("ReadTransferCountDelta");
        this.lblRD.Text = curProc.IODelta.ReadOperationCount.ToString();
        this.lblWBD.Text = curProc.GetInformation("WriteTransferCountDelta");
        this.lblWD.Text = curProc.IODelta.WriteOperationCount.ToString();
        this.lblOtherD.Text = curProc.IODelta.OtherOperationCount.ToString();
        this.lblOthersBD.Text = curProc.GetInformation("OtherTransferCountDelta");

        Native.Api.NativeStructs.VmCountersEx mem = curProc.Infos.MemoryInfos;
        this.lblHandles.Text = System.Convert.ToString(curProc.Infos.HandleCount);
        DateTime ts = new DateTime(curProc.Infos.KernelTime);
        string s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
        this.lblKernelTime.Text = s;
        this.lblPageFaults.Text = System.Convert.ToString(mem.PageFaultCount);
        this.lblPageFileUsage.Text = Misc.GetFormatedSize(mem.PagefileUsage);
        this.lblPeakPageFileUsage.Text = Misc.GetFormatedSize(mem.PeakPagefileUsage);
        this.lblPeakWorkingSet.Text = Misc.GetFormatedSize(mem.PeakWorkingSetSize);
        ts = new DateTime(curProc.Infos.ProcessorTime);
        s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
        this.lblTotalTime.Text = s;
        ts = new DateTime(curProc.Infos.UserTime);
        s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
        this.lblUserTime.Text = s;
        this.lblPriority.Text = curProc.Infos.Priority.ToString();
        this.lblWorkingSet.Text = Misc.GetFormatedSize(mem.WorkingSetSize);
        this.lblQuotaNPP.Text = Misc.GetFormatedSize(mem.QuotaNonPagedPoolUsage);
        this.lblQuotaPNPP.Text = Misc.GetFormatedSize(mem.QuotaPeakNonPagedPoolUsage);
        this.lblQuotaPP.Text = Misc.GetFormatedSize(mem.QuotaPagedPoolUsage);
        this.lblQuotaPPP.Text = Misc.GetFormatedSize(mem.QuotaPeakPagedPoolUsage);
    }

    // Refresh information tab
    private void refreshInfosTab()
    {
        try
        {
            Native.Api.NativeStructs.VmCountersEx pmc = curProc.Infos.MemoryInfos;
            string s = "";
            s = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}";
            s = s + @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b File properties\b0\par";
            s = s + @"\tab File name :\tab\tab\tab " + curProc.Infos.Name + @"\par";
            s = s + @"\tab Path :\tab\tab\tab\tab " + Strings.Replace(curProc.Infos.Path, @"\", @"\\") + @"\par";
            if (curProc.Infos.FileInfo != null)
            {
                s = s + @"\tab Description :\tab\tab\tab " + curProc.Infos.FileInfo.FileDescription + @"\par";
                s = s + @"\tab Company name :\tab\tab\tab " + curProc.Infos.FileInfo.CompanyName + @"\par";
                s = s + @"\tab Version :\tab\tab\tab " + curProc.Infos.FileInfo.FileVersion + @"\par";
                s = s + @"\tab Copyright :\tab\tab\tab " + curProc.Infos.FileInfo.LegalCopyright + @"\par";
            }
            s = s + @"\par";
            s = s + @"  \b Process description\b0\par";
            s = s + @"\tab PID :\tab\tab\tab\tab " + System.Convert.ToString(curProc.Infos.ProcessId) + @"\par";
            s = s + @"\tab Start time :\tab\tab\tab " + new DateTime(curProc.Infos.StartTime).ToLongDateString() + " -- " + new DateTime(curProc.Infos.StartTime).ToLongTimeString() + @"\par";
            s = s + @"\tab Priority :\tab\tab\tab\tab " + curProc.Infos.Priority.ToString() + @"\par";
            s = s + @"\tab User :\tab\tab\tab\tab " + curProc.Infos.UserName + @"\par";
            DateTime ts = new DateTime(curProc.Infos.ProcessorTime);
            string proctime = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
            s = s + @"\tab Processor time :\tab\tab\tab " + proctime + @"\par";
            s = s + @"\tab Memory :\tab\tab\tab " + System.Convert.ToString(pmc.WorkingSetSize.ToInt64() / (double)1024) + " Kb" + @"\par";
            s = s + @"\tab Memory peak :\tab\tab\tab " + System.Convert.ToString(pmc.PeakWorkingSetSize.ToInt64() / (double)1024) + " Kb" + @"\par";
            s = s + @"\tab Page faults :\tab\tab\tab " + System.Convert.ToString(pmc.PageFaultCount) + @"\par";
            s = s + @"\tab Page file usage :\tab\tab\tab " + System.Convert.ToString(pmc.PagefileUsage.ToInt64() / (double)1024) + " Kb" + @"\par";
            s = s + @"\tab Peak page file usage :\tab\tab " + System.Convert.ToString(pmc.PeakPagefileUsage.ToInt64() / (double)1024) + " Kb" + @"\par";
            s = s + @"\tab QuotaPagedPoolUsage :\tab\tab " + System.Convert.ToString(Math.Round(pmc.QuotaPagedPoolUsage.ToInt64() / (double)1024, 3)) + " Kb" + @"\par";
            s = s + @"\tab QuotaPeakPagedPoolUsage :\tab " + System.Convert.ToString(Math.Round(pmc.QuotaPeakPagedPoolUsage.ToInt64() / (double)1024, 3)) + " Kb" + @"\par";
            s = s + @"\tab QuotaNonPagedPoolUsage :\tab " + System.Convert.ToString(Math.Round(pmc.QuotaNonPagedPoolUsage.ToInt64() / (double)1024, 3)) + " Kb" + @"\par";
            s = s + @"\tab QuotaPeakNonPagedPoolUsage :\tab " + System.Convert.ToString(Math.Round(pmc.QuotaPeakNonPagedPoolUsage.ToInt64() / (double)1024, 3)) + " Kb" + @"\par";

            s = s + "}";

            rtb.Rtf = s;
        }
        catch (Exception ex)
        {
            string s = "";
            Exception er = ex;

            s = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}";
            s = s + @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b An error occured\b0\par";
            s = s + @"\tab Message :\tab " + er.Message + @"\par";
            s = s + @"\tab Source :\tab\tab " + er.Source + @"\par";
            if (Strings.Len(er.HelpLink) > 0)
                s = s + @"\tab Help link :\tab " + er.HelpLink + @"\par";
            s = s + "}";

            rtb.Rtf = s;
        }
    }

    private void frmProcessInfo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        this.Visible = false;

        // Save columns infos before closing
        Pref.SaveListViewColumns(this.lvLog, "COLprocdetail_log");
        Pref.SaveListViewColumns(this.lvHandles, "COLprocdetail_handle");
        Pref.SaveListViewColumns(this.lvPrivileges, "COLprocdetail_privilege");
        Pref.SaveListViewColumns(this.lvProcMem, "COLprocdetail_memory");
        Pref.SaveListViewColumns(this.lvProcNetwork, "COLprocdetail_network");
        Pref.SaveListViewColumns(this.lvModules, "COLprocdetail_module");
        Pref.SaveListViewColumns(this.lvProcEnv, "COLprocdetail_envvariable");
        Pref.SaveListViewColumns(this.lvHeaps, "COLprocdetail_heaps");

        // Save position & size
        Pref.SaveFormPositionAndSize(this, "PSfrmProcessInfo");

        // Close handles opened
        if (_local && hProcSync.IsNotNull())
            Native.Objects.General.CloseHandle(hProcSync);

        // Empty debug buffer
        if (_dbgBuffer != null)
            _dbgBuffer.Dispose();

        // Dispose other objects
        if (cRW != null)
            cRW.Dispose();
        if (_asyncDlThread != null)
            _asyncDlThread.Abort();

        if (this.pctBigIcon.Image != null)
            this.pctBigIcon.Image.Dispose();
        if (this.pctSmallIcon.Image != null)
            this.pctSmallIcon.Image.Dispose();

        this.lvHandles.ClearItems();
        this.lvHeaps.ClearItems();
        this.lvLog.ClearItems();
        this.lvModules.ClearItems();
        this.lvPrivileges.ClearItems();
        this.lvProcEnv.ClearItems();
        this.lvProcMem.ClearItems();
        this.lvProcNetwork.ClearItems();
        this.lvProcServices.ClearItems();
        this.lvProcString.Clear();
        this.lvThreads.ClearItems();
        this.lvWindows.ClearItems();
        this._logDico.Clear();
        __lRes = new IntPtr[1];
        __sRes = new string[1];
    }

    private void frmProcessInfo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
            tabProcess_SelectedIndexChanged(null, null);
    }

    private void frmProcessInfo_Load(object sender, System.EventArgs e)
    {

        // Hide panel 'Find window' if necessary
        if (My.MySettingsProperty.Settings.ShowFindWindowDetailedForm)
            showFindPanel();
        else
            hideFindPanel();

        Misc.CloseWithEchapKey(ref this);

        // Cool theme
        Native.Functions.Misc.SetTheme(this.lvProcString.Handle);
        Native.Functions.Misc.SetTheme(this.lvProcEnv.Handle);
        Native.Functions.Misc.SetTheme(this.lvProcNetwork.Handle);
        Native.Functions.Misc.SetTheme(this.lvProcMem.Handle);
        Native.Functions.Misc.SetTheme(this.lvProcServices.Handle);
        Native.Functions.Misc.SetTheme(this.lvPrivileges.Handle);
        Native.Functions.Misc.SetTheme(this.lvModules.Handle);
        Native.Functions.Misc.SetTheme(this.lvHandles.Handle);
        Native.Functions.Misc.SetTheme(this.lvThreads.Handle);
        Native.Functions.Misc.SetTheme(this.lvWindows.Handle);
        Native.Functions.Misc.SetTheme(this.lvLog.Handle);
        Native.Functions.Misc.SetTheme(this.lvHeaps.Handle);

        // Some tooltips
        Misc.SetToolTip(this.cmdInfosToClipB, "Copy process informations to clipboard. Use left click to copy as text, right click to copy as rtf (preserve text style)");
        Misc.SetToolTip(this.txtImageVersion, "Version of file");
        Misc.SetToolTip(this.txtProcessPath, "Path of file");
        Misc.SetToolTip(this.cmdShowFileDetails, "Show file details");
        Misc.SetToolTip(this.cmdInspectExe, "Show dependencies");
        Misc.SetToolTip(this.cmdShowFileProperties, "Open file property window");
        Misc.SetToolTip(this.cmdOpenDirectory, "Open directory of file");
        Misc.SetToolTip(this.txtParentProcess, "Parent process");
        Misc.SetToolTip(this.txtProcessStarted, "Start time");
        Misc.SetToolTip(this.txtProcessId, "Process ID");
        Misc.SetToolTip(this.txtProcessUser, "Process user");
        Misc.SetToolTip(this.txtCommandLine, "Command line which launched process");
        Misc.SetToolTip(this.cmdGetOnlineInfos, "Retrieve online information (based on process name)");
        Misc.SetToolTip(this.optProcStringImage, "Get strings from image file on disk");
        Misc.SetToolTip(this.optProcStringMemory, "Get strings from memory");
        Misc.SetToolTip(this.cmdProcStringSave, "Save list in a file");
        Misc.SetToolTip(this.pgbString, "Progression. Click to stop");
        Misc.SetToolTip(this.txtSearchProcString, "Search a specific string");
        Misc.SetToolTip(this.txtRunTime, "Total run time");
        Misc.SetToolTip(this.cmdProcSearchL, "Previous result (F2 on listview also works)");
        Misc.SetToolTip(this.cmdProcSearchR, "Next result (F3 on listview also works)");
        Misc.SetToolTip(this.cmdRefresh, "Refresh informations");
        Misc.SetToolTip(this.chkLog, "Activate or not log");
        Misc.SetToolTip(this.cmdLogOptions, "Log options");
        Misc.SetToolTip(this.cmdSave, "Save log");
        Misc.SetToolTip(this.cmdClearLog, "Clear log");
        Misc.SetToolTip(this.cmdKill, "Kill process");
        Misc.SetToolTip(this.cmdResume, "Resume process");
        Misc.SetToolTip(this.cmdPause, "Suspend process");
        Misc.SetToolTip(this.cmdAffinity, "Set affinity");
        Misc.SetToolTip(this.cmdSet, "Set priority");
        Misc.SetToolTip(this.cbPriority, "Priority of the process");
        Misc.SetToolTip(this.chkFreeze, "Suspend refreshment of informations to let you search into the view");
        Misc.SetToolTip(this.lblResCount, "Number of results. Click on the number to view results");
        Misc.SetToolTip(this.txtSearch, "Enter text here to search an item");
        Misc.SetToolTip(this.cmdHideFindPanel, "Hide 'find panel'");
        Misc.SetToolTip(this.cmdActivateHeapEnumeration, "The enumeration of heaps can fail and cause a crash of YAPM. This will be fixed soon. You must then manually enable this feature for now.");

        // Init columns
        Pref.LoadListViewColumns(this.lvPrivileges, "COLprocdetail_privilege");
        Pref.LoadListViewColumns(this.lvProcMem, "COLprocdetail_memory");
        Pref.LoadListViewColumns(this.lvProcServices, "COLprocdetail_service");
        Pref.LoadListViewColumns(this.lvProcNetwork, "COLprocdetail_network");
        Pref.LoadListViewColumns(this.lvHandles, "COLprocdetail_handle");
        Pref.LoadListViewColumns(this.lvWindows, "COLprocdetail_window");
        Pref.LoadListViewColumns(this.lvThreads, "COLprocdetail_thread");
        Pref.LoadListViewColumns(this.lvModules, "COLprocdetail_module");
        Pref.LoadListViewColumns(this.lvProcEnv, "COLprocdetail_envvariable");
        Pref.LoadListViewColumns(this.lvLog, "COLprocdetail_log");
        Pref.LoadListViewColumns(this.lvHeaps, "COLprocdetail_heaps");

        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmProcessInfo");

        switch (My.MySettingsProperty.Settings.ProcSelectedTab)
        {
            case "Token":
                {
                    this.tabProcess.SelectedTab = this.TabPageToken;
                    break;
                }

            case "Modules":
                {
                    this.tabProcess.SelectedTab = this.TabPageModules;
                    break;
                }

            case "Threads":
                {
                    this.tabProcess.SelectedTab = this.TabPageThreads;
                    break;
                }

            case "Windows":
                {
                    this.tabProcess.SelectedTab = this.TabPageWindows;
                    break;
                }

            case "Handles":
                {
                    this.tabProcess.SelectedTab = this.TabPageHandles;
                    break;
                }

            case "Memory":
                {
                    this.tabProcess.SelectedTab = this.TabPageMemory;
                    break;
                }

            case "Environment":
                {
                    this.tabProcess.SelectedTab = this.TabPageEnv;
                    break;
                }

            case "Network":
                {
                    this.tabProcess.SelectedTab = this.TabPageNetwork;
                    break;
                }

            case "Services":
                {
                    this.tabProcess.SelectedTab = this.TabPageServices;
                    break;
                }

            case "Strings":
                {
                    this.tabProcess.SelectedTab = this.TabPageString;
                    break;
                }

            case "General":
                {
                    this.tabProcess.SelectedTab = this.TabPageGeneral;
                    break;
                }

            case "Statistics":
                {
                    this.tabProcess.SelectedTab = this.TabPageStats;
                    break;
                }

            case "Informations":
                {
                    this.tabProcess.SelectedTab = this.TabPageInfos;
                    break;
                }

            case "Performances":
                {
                    this.tabProcess.SelectedTab = this.TabPagePerf;
                    break;
                }

            case "Log":
                {
                    this.tabProcess.SelectedTab = this.TabPageLog;
                    break;
                }

            case "History":
                {
                    this.tabProcess.SelectedTab = this.TabPageHistory;
                    break;
                }

            case "Heaps":
                {
                    this.tabProcess.SelectedTab = this.TabPageHeaps;
                    break;
                }
        }

        // Icons
        if (cProcess.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
        {
            if (pctBigIcon.Image == null)
            {
                try
                {
                    pctBigIcon.Image = Misc.GetIcon(curProc.Infos.Path, false).ToBitmap();
                    pctSmallIcon.Image = Misc.GetIcon(curProc.Infos.Path, true).ToBitmap();
                }
                catch (Exception ex)
                {
                    pctSmallIcon.Image = My.Resources.Resources.exe16;
                    pctBigIcon.Image = My.Resources.Resources.exe32;
                }
            }
        }
        else
        {
            pctSmallIcon.Image = My.Resources.Resources.exe16;
            pctBigIcon.Image = My.Resources.Resources.exe32;
        }

        Connect();
        refreshProcessTab();

        if (My.MySettingsProperty.Settings.AutomaticInternetInfos)
            cmdGetOnlineInfos_Click(null, null);

        // Add some submenus (Copy to clipboard)
        foreach (string ss in handleInfos.GetAvailableProperties(true))
            this.MenuItemCopyHandle.MenuItems.Add(ss, MenuItemCopyHandle_Click);
        foreach (string ss in memRegionInfos.GetAvailableProperties(true))
            this.MenuItemCopyMemory.MenuItems.Add(ss, MenuItemCopyMemory_Click);
        foreach (string ss in moduleInfos.GetAvailableProperties(true))
            this.MenuItemCopyModule.MenuItems.Add(ss, MenuItemCopyModule_Click);
        foreach (string ss in networkInfos.GetAvailableProperties(true))
            this.MenuItemCopyNetwork.MenuItems.Add(ss, MenuItemCopyNetwork_Click);
        foreach (string ss in privilegeInfos.GetAvailableProperties(true))
            this.MenuItemCopyPrivilege.MenuItems.Add(ss, MenuItemCopyPrivilege_Click);
        foreach (string ss in serviceInfos.GetAvailableProperties(true))
            this.MenuItemCopyService.MenuItems.Add(ss, MenuItemCopyService_Click);
        foreach (string ss in threadInfos.GetAvailableProperties(true))
            this.MenuItemCopyThread.MenuItems.Add(ss, MenuItemCopyThread_Click);
        foreach (string ss in windowInfos.GetAvailableProperties(true))
            this.MenuItemCopyWindow.MenuItems.Add(ss, MenuItemCopyWindow_Click);
        foreach (string ss in logItemInfos.GetAvailableProperties(true))
            this.MenuItemCopyLog.MenuItems.Add(ss, MenuItemCopyLog_Click);
        foreach (string ss in envVariableInfos.GetAvailableProperties(true))
            this.MenuItemCopyEnvVariable.MenuItems.Add(ss, MenuItemCopyEnvVariable_Click);
        foreach (string ss in heapInfos.GetAvailableProperties(true))
            this.MenuItemCopyHeaps.MenuItems.Add(ss, MenuItemCopyHeaps_Click);
        this.MenuItemCopyString.MenuItems.Add("Position", MenuItemCopyString_Click);
        this.MenuItemCopyString.MenuItems.Add("String", MenuItemCopyString_Click);

        // TOREMOVE
        this.lvHeaps.Enabled = false;
    }

    // Get process to monitor
    public void SetProcess(ref cProcess process)
    {
        curProc = process;
        asyncAllNonFixedInfos = new asyncCallbackProcGetAllNonFixedInfos(ref cProcess.Connection, ref curProc);

        this.Text = curProc.Infos.Name + " (" + System.Convert.ToString(curProc.Infos.ProcessId) + ")";
        this.cbPriority.Text = curProc.Infos.Priority.ToString();

        _local = (cProcess.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        _notWMI = (cProcess.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        _notSnapshotMode = (cProcess.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.SnapshotFile);

        this.cmdAffinity.Enabled = _notWMI & _notSnapshotMode;
        this.cmdPause.Enabled = _notWMI & _notSnapshotMode;
        this.cmdResume.Enabled = _notWMI & _notSnapshotMode;
        this.cmdKill.Enabled = _notSnapshotMode;
        this.cbPriority.Enabled = _notSnapshotMode;
        this.cmdSet.Enabled = _notSnapshotMode;
        this.lvModules.CatchErrors = !(_local);
        this.timerProcPerf.Enabled = _notSnapshotMode;
        this.lvPrivileges.Enabled = _notWMI;
        this.lvHandles.Enabled = _notWMI;
        this.lvLog.Enabled = _notWMI & _notSnapshotMode;
        this.lvProcEnv.Enabled = _notWMI;
        this.lvProcMem.Enabled = _notWMI;
        this.lvProcNetwork.Enabled = _notWMI;
        this.lvProcString.Enabled = _notWMI & _notSnapshotMode;
        this.lvWindows.Enabled = _notWMI;
        this.lvHeaps.Enabled = _notWMI;
        this.SplitContainerStrings.Enabled = _notWMI & _notSnapshotMode;
        this.SplitContainerLog.Enabled = _notWMI & _notSnapshotMode;
        this.cmdShowFileDetails.Enabled = _local;
        this.cmdInspectExe.Enabled = _local;
        this.cmdShowFileProperties.Enabled = _local;
        this.cmdOpenDirectory.Enabled = _local;
        this.txtRunTime.Enabled = _notSnapshotMode;
        this.containerHistory.Enabled = _notSnapshotMode;
        this.lstHistoryCat.Enabled = _notSnapshotMode;
        this.graphCPU.Enabled = _notSnapshotMode;
        this.graphIO.Enabled = _notSnapshotMode;
        this.graphMemory.Enabled = _notSnapshotMode;
        this.TabPageString.Enabled = _local;
        this.cmdActivateHeapEnumeration.Enabled = _notWMI;

        this.timerLog.Enabled = this.timerLog.Enabled & _notWMI & _notSnapshotMode;

        // Verify file
        if (My.MySettingsProperty.Settings.AutomaticWintrust && _local)
        {
            try
            {
                bool bVer = Security.WinTrust.WinTrust.VerifyEmbeddedSignature(curProc.Infos.Path);
                if (bVer)
                    gpProcGeneralFile.Text = "Image file (successfully verified)";
                else
                    gpProcGeneralFile.Text = "Image file (not verified)";
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }
        else
            gpProcGeneralFile.Text = "Image file (no verification was made)";

        // Parent process exists ?
        this.cmdGoProcess.Enabled = (cProcess.GetProcessById(curProc.Infos.ParentProcessId) != null);

        // Wow64 process ?
        if (curProc.IsWow64Process)
            this.GroupBoxProcessInfos.Text = "Wow64 process";

        // Add values to perf graphs
        // Memory usage
        foreach (double _val in curProc.GetHistory("WorkingSet"))
            this.graphMemory.AddValue(_val / 2147483648 * 100);
        this.graphMemory.Refresh();

        // CpuUsage
        double[] _v = curProc.GetHistory("CpuUsage");
        double[] _v2 = curProc.GetHistory("AverageCpuUsage");
        int x = 0;
        foreach (double _val2 in _v2)
        {
            double z = _v[x];
            x += 1;
            if (double.IsNegativeInfinity(z))
                z = 0;
            this.graphCPU.Add2Values(z, _val2);
        }
        this.graphCPU.Refresh();

        // IO graph
        _v = curProc.GetHistory("ReadTransferCountDelta");
        double[] __v = curProc.GetHistory("OtherTransferCountDelta");
        _v2 = curProc.GetHistory("WriteTransferCountDelta");
        x = 0;
        foreach (double _val2 in _v2)
        {
            double z = _v[x] + __v[x];
            x += 1;
            this.graphIO.Add2Values(z, _val2);
        }
        this.graphIO.Refresh();



        // Set handler for process termination
        if (_local)
        {
            hProcSync = Native.Objects.Process.GetProcessHandleById(process.Infos.ProcessId, Native.Security.ProcessAccess.Synchronize | Native.Objects.Process.ProcessQueryMinRights);
            Native.Objects.Process.ProcessTerminationStruct contObj = new Native.Objects.Process.ProcessTerminationStruct(hProcSync, ProcessHasTerminatedHandler);
            System.Threading.ThreadPool.QueueUserWorkItem(Native.Objects.Process.WaitForProcessToTerminate(), contObj);
        }
    }

    private void timerProcPerf_Tick(System.Object sender, System.EventArgs e)
    {
        if (this.chkFreeze.Checked)
            return;
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

        Static updatedRisk As Boolean = False

 */
        double z = curProc.CpuUsage;
        double z2 = curProc.Infos.AverageCpuUsage;
        if (double.IsNegativeInfinity(z))
            z = 0;
        this.graphCPU.Add2Values(z * 100, z2 * 100);
        this.graphCPU.Refresh();
        this.graphCPU.TopText = "Cpu : " + Misc.GetFormatedPercentage(z, 3, true) + " %";

        z = curProc.Infos.MemoryInfos.WorkingSetSize.ToInt64() / (double)2147483648 * 100;
        this.graphMemory.AddValue(z);
        this.graphMemory.Refresh();
        this.graphMemory.TopText = "WorkingSet : " + Misc.GetFormatedSize(curProc.Infos.MemoryInfos.WorkingSetSize.ToInt64());

        this.graphIO.Add2Values(curProc.IODelta.ReadTransferCount + curProc.IODelta.OtherTransferCount, curProc.IODelta.WriteTransferCount);
        this.graphIO.Refresh();
        this.graphIO.TopText = "R+O : " + Misc.GetFormatedSizePerSecond(curProc.IODelta.ReadTransferCount + curProc.IODelta.OtherTransferCount) + " , W : " + Misc.GetFormatedSizePerSecond(curProc.IODelta.WriteTransferCount);


        // Parent process exists ?
        this.cmdGoProcess.Enabled = (cProcess.GetProcessById(curProc.Infos.ParentProcessId) != null);


        // Refresh informations about process
        if (!(this.tabProcess.SelectedTab.Text == "Informations" | this.tabProcess.SelectedTab.Text == "Strings"))
            this.refreshProcessTab();

        // Display caption
        ChangeCaption();

        // If online infos received, display it
        if (_asyncDownloadDone && updatedRisk == false)
        {
            this.lblSecurityRisk.Text = "Risk : " + _asyncInfoRes._Risk.ToString();
            this.rtbOnlineInfos.Text = _asyncInfoRes._Description;
            _asyncDlThread.Abort();
            _asyncInfoRes = default(cAsyncProcInfoDownload.InternetProcessInfo);
            _asyncDlThread = null;
            _asyncDownloadDone = false;
            switch (_asyncInfoRes._Risk)
            {
                case cAsyncProcInfoDownload.SecurityRisk.Alert1:
                case cAsyncProcInfoDownload.SecurityRisk.Alert2:
                case cAsyncProcInfoDownload.SecurityRisk.Alert3:
                    {
                        this.lblSecurityRisk.ForeColor = Color.DarkRed;
                        break;
                    }

                case cAsyncProcInfoDownload.SecurityRisk.Caution1:
                case cAsyncProcInfoDownload.SecurityRisk.Caution2:
                    {
                        this.lblSecurityRisk.ForeColor = Color.DarkOrange;
                        break;
                    }

                case cAsyncProcInfoDownload.SecurityRisk.Safe:
                    {
                        this.lblSecurityRisk.ForeColor = Color.DarkGreen;
                        break;
                    }

                default:
                    {
                        this.lblSecurityRisk.ForeColor = Color.Black;
                        break;
                    }
            }
        }
    }

    // Change caption
    private void ChangeCaption()
    {

        // Display form caption
        if (string.IsNullOrEmpty(fixedFormCaption) == false)
        {
            this.Text = fixedFormCaption;
            // Refresh a last time
            if (this.timerProcPerf.Enabled)
            {
                if (!(this.tabProcess.SelectedTab.Text == "Informations" | this.tabProcess.SelectedTab.Text == "Strings"))
                    this.refreshProcessTab();
            }
            // Stop auto refreshment
            this.timerLog.Enabled = false;
            this.timerProcPerf.Enabled = false;
            this.chkLog.Enabled = false;
            this.chkLog.Checked = false;
            return;
        }
        else
            this.Text = curProc.Infos.Name + " (" + curProc.Infos.ProcessId.ToString() + ")";

        switch (this.tabProcess.SelectedTab.Text)
        {
            case "Modules":
                {
                    this.Text += " - " + this.lvModules.Items.Count.ToString() + " modules";
                    break;
                }

            case "Threads":
                {
                    this.Text += " - " + this.lvThreads.Items.Count.ToString() + " threads";
                    break;
                }

            case "Windows":
                {
                    this.Text += " - " + this.lvWindows.Items.Count.ToString() + " windows";
                    break;
                }

            case "Handles":
                {
                    this.Text += " - " + this.lvHandles.Items.Count.ToString() + " handles";
                    break;
                }

            case "Memory":
                {
                    this.Text += " - " + this.lvProcMem.Items.Count.ToString() + " memory regions";
                    break;
                }

            case "Network":
                {
                    this.Text += " - " + this.lvProcNetwork.Items.Count.ToString() + " connections";
                    break;
                }

            case "Services":
                {
                    this.Text += " - " + this.lvProcServices.Items.Count.ToString() + " services";
                    break;
                }

            case "Strings":
                {
                    this.Text += " - " + this.lvProcString.Items.Count.ToString() + " strings";
                    break;
                }

            case "Environment":
                {
                    this.Text += " - " + this.lvProcEnv.Items.Count.ToString() + " variables";
                    break;
                }

            case "Token":
                {
                    this.Text += " - " + this.lvPrivileges.Items.Count.ToString() + " privileges";
                    break;
                }

            case "Log":
                {
                    this.Text += " - " + this.lvLog.Items.Count.ToString() + " entries in log";
                    break;
                }
        }
    }

    private void getProcString(object cuProc)
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

        Static reentrance As Boolean = False

 */
        if (reentrance)
            return;
        reentrance = true;

        cProcess curProc = (cProcess)cuProc;
        Async.SplitContainer.ChangeEnabled(this.SplitContainerStrings, false);

        this.lvProcString.Items.Clear();
        if (this.optProcStringImage.Checked)
            // Image
            DisplayFileStringsImage(ref curProc);
        else
        {
            // Memory
            cRW = new ProcessRW(curProc.Infos.ProcessId);
            IntPtr[] lRes;
            lRes = new IntPtr[1];
            string[] sRes;
            sRes = new string[1];
            cRW.SearchEntireStringMemory(ref lRes, ref sRes, this.pgbString);

            __sRes = sRes;
            __lRes = lRes;

            Async.ListView.ChangeVirtualListSize(this.lvProcString, sRes.Length);
        }

        reentrance = false;
        Async.SplitContainer.ChangeEnabled(this.SplitContainerStrings, true);
    }


    // Display file strings
    public void DisplayFileStringsImage(ref cProcess cp)
    {
        string s = Constants.vbNullString;
        int x = 0;
        int bTaille;
        int lLen;
        ProcessRW.T_RESULT[] tRes;
        int cArraySizeBef = 0;
        string strCtemp = Constants.vbNullString;
        // Dim strBuffer As String

        const int BUF_SIZE = 2000;     // Size of array

        tRes = new ProcessRW.T_RESULT[2001];

        string file = cp.Infos.Path;

        _stringSearchImmediateStop = false;

        if (System.IO.File.Exists(file))
        {
            this.lvProcString.Items.Clear();

            // Retrieve entire file in memory
            s = System.IO.File.ReadAllText(file);

            // Desired minimum size for a string
            bTaille = SIZE_FOR_STRING;

            // A char is considered as part of a string if its value is between 32 and 122
            lLen = Strings.Len(s);
            Async.ProgressBar.ChangeMaximum(this.pgbString, System.Convert.ToInt32(lLen / (double)10000 + 2));
            Async.ProgressBar.ChangeValue(this.pgbString, 0);

            // Ok, parse file
            while (x < lLen)
            {
                if (_stringSearchImmediateStop)
                {
                    // Exit
                    Async.ProgressBar.ChangeValue(this.pgbString, this.pgbString.Maximum);
                    return;
                }

                if (isLetter(s[x]))
                    strCtemp += s.Chars[x];
                else
                {
                    // strCtemp = Trim$(strCtemp)
                    if (Strings.Len(strCtemp) > SIZE_FOR_STRING)
                    {

                        // Resize only every BUF times
                        if (cArraySizeBef == BUF_SIZE)
                        {
                            cArraySizeBef = 0;
                            var oldTRes = tRes;
                            tRes = new ProcessRW.T_RESULT[tRes.Length + BUF_SIZE + 1];
                            if (oldTRes != null)
                                Array.Copy(oldTRes, tRes, Math.Min(tRes.Length + BUF_SIZE + 1, oldTRes.Length));
                        }

                        tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].curOffset = new IntPtr(x);
                        tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].strString = strCtemp;
                        cArraySizeBef += 1;
                    }
                    strCtemp = Constants.vbNullString;
                }

                if ((x % 10000) == 0)
                    Async.ProgressBar.ChangeValue(this.pgbString, this.pgbString.Value + 1);

                x += 1;
            }

            Async.ProgressBar.ChangeValue(this.pgbString, this.pgbString.Maximum);

            // Last item
            if (Strings.Len(strCtemp) > SIZE_FOR_STRING)
            {
                // Resize only every BUF times
                if (cArraySizeBef == BUF_SIZE)
                {
                    cArraySizeBef = 0;
                    var oldTRes1 = tRes;
                    tRes = new ProcessRW.T_RESULT[tRes.Length + BUF_SIZE + 1];
                    if (oldTRes1 != null)
                        Array.Copy(oldTRes1, tRes, Math.Min(tRes.Length + BUF_SIZE + 1, oldTRes1.Length));
                }

                tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].curOffset = new IntPtr(lLen);
                tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].strString = strCtemp;
            }


            IntPtr[] lngRes;
            string[] strRes;
            lngRes = new IntPtr[tRes.Length - BUF_SIZE + cArraySizeBef - 1 + 1];
            strRes = new string[tRes.Length - BUF_SIZE + cArraySizeBef - 1 + 1];
            var loopTo = tRes.Length - BUF_SIZE + cArraySizeBef - 1;
            for (x = 0; x <= loopTo; x++)
            {
                lngRes[x] = tRes[x].curOffset;
                strRes[x] = tRes[x].strString;
            }

            __sRes = strRes;
            __lRes = lngRes;

            Async.ListView.ChangeVirtualListSize(this.lvProcString, tRes.Length - BUF_SIZE + cArraySizeBef - 1);
        }
    }

    // Return true if c is a valid character
    private bool isLetter(char c)
    {
        int i = Strings.Asc(c);
        // A-Z [/]_^' space a-z {|}
        return ((i >= 65 & i <= 125) || (i >= 45 & i <= 57) || i == 32);
    }

    private void cmdInfosToClipB_Click(object sender, System.EventArgs e)
    {
        if (this.rtb.Text.Length > 0)
            My.MyProject.Computer.Clipboard.SetText(this.rtb.Text, TextDataFormat.Text);
    }

    private void cmdInfosToClipB_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (this.rtb.Rtf.Length > 0)
                My.MyProject.Computer.Clipboard.SetText(this.rtb.Rtf, TextDataFormat.Rtf);
        }
    }

    private void cmdOpenDirectory_Click(object sender, System.EventArgs e)
    {
        // Open directory of selected process
        if (curProc.Infos.Path != Program.NO_INFO_RETRIEVED)
            cFile.OpenDirectory(curProc.Infos.Path);
    }

    private void pctBigIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.MenuItemCopyBig.Enabled = (this.pctBigIcon.Image != null);
    }

    private void pctSmallIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.MenuItemCopySmall.Enabled = (this.pctSmallIcon.Image != null);
    }

    private void tabProcess_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.refreshProcessTab();
        ChangeCaption();
        updateFindPanel();
        My.MySettingsProperty.Settings.ProcSelectedTab = this.tabProcess.SelectedTab.Text;
    }

    private void cmdProcSearchL_Click(object sender, System.EventArgs e)
    {
        string sSearch = this.txtSearchProcString.Text.ToLowerInvariant();
        int curIndex = this.lvProcString.Items.Count - 1;

        if (this.lvProcString.SelectedIndices != null && this.lvProcString.SelectedIndices.Count > 0)
            curIndex = this.lvProcString.SelectedIndices[0];

        for (int z = curIndex - 1; z >= 0; z += -1)
        {
            string sComp = this.lvProcString.Items[z].SubItems[1].Text.ToLowerInvariant();
            if (Strings.InStr(sComp, sSearch, CompareMethod.Binary) > 0)
            {
                this.lvProcString.Items[curIndex].Selected = false;
                this.lvProcString.Items[z].Selected = true;
                this.lvProcString.Items[z].EnsureVisible();
                this.lvProcString.Focus();
                return;
            }
        }
    }

    private void cmdProcSearchR_Click(object sender, System.EventArgs e)
    {
        string sSearch = this.txtSearchProcString.Text.ToLowerInvariant();
        int curIndex = 0;

        if (this.lvProcString.SelectedIndices != null && this.lvProcString.SelectedIndices.Count > 0)
            curIndex = this.lvProcString.SelectedIndices[0];
        var loopTo = this.lvProcString.Items.Count - 1;
        for (int z = curIndex + 1; z <= loopTo; z++)
        {
            string sComp = this.lvProcString.Items[z].SubItems[1].Text.ToLowerInvariant();
            if (Strings.InStr(sComp, sSearch, CompareMethod.Binary) > 0)
            {
                this.lvProcString.Items[curIndex].Selected = false;
                this.lvProcString.Items[z].Selected = true;
                this.lvProcString.Items[z].EnsureVisible();
                this.lvProcString.Focus();
                return;
            }
        }
    }

    private void lvProcString_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F2)
            cmdProcSearchL_Click(null, null);
        else if (e.KeyCode == Keys.F3)
            cmdProcSearchR_Click(null, null);
    }

    private void cmdProcStringSave_Click(object sender, System.EventArgs e)
    {

        // Save list of strings
        {
            var withBlock = Program._frmMain.saveDial;
            withBlock.AddExtension = true;
            withBlock.Filter = "Txt (*.txt*)|*.txt";
            withBlock.InitialDirectory = My.MyProject.Application.Info.DirectoryPath;
            if (!(withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                return;
        }

        // Save our file
        try
        {
            System.IO.StreamWriter stream = new System.IO.StreamWriter(Program._frmMain.saveDial.FileName, false);
            var loopTo = this.lvProcString.Items.Count - 1;
            for (int x = 0; x <= loopTo; x++)
                stream.WriteLine(this.lvProcString.Items[x].SubItems[1].Text);
            stream.Close();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    // Add item to virtual listview
    private void lvProcString_RetrieveVirtualItem(object sender, System.Windows.Forms.RetrieveVirtualItemEventArgs e)
    {
        e.Item = GetListItem(e.ItemIndex);
    }
    // Return desired item
    private ListViewItem GetListItem(int x)
    {
        ListViewItem it = new ListViewItem("0x" + __lRes[x].ToString("x"));
        it.SubItems.Add(__sRes[x]);
        it.Tag = __lRes[x];
        return it;
    }

    private void lvProcMem_DoubleClick(object sender, System.EventArgs e)
    {
        foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
        {
            frmHexEditor frm = new frmHexEditor();
            MemoryHexEditor.MemoryRegion reg = new MemoryHexEditor.MemoryRegion(it.Infos.BaseAddress, it.Infos.RegionSize);
            frm.SetPidAndRegion(it.Infos.ProcessId, reg);
            frm.Show();
        }
    }

    private void cmdShowFileDetails_Click(object sender, System.EventArgs e)
    {
        string s = curProc.Infos.Path;
        if (System.IO.File.Exists(s))
            Misc.DisplayDetailsFile(s);
    }

    private void cmdShowFileProperties_Click(object sender, System.EventArgs e)
    {
        // File properties for selected process
        if (System.IO.File.Exists(curProc.Infos.Path))
            cFile.ShowFileProperty(curProc.Infos.Path, this.Handle);
    }

    // Stop string listing
    private void pgbString_Click(object sender, System.EventArgs e)
    {
        if (cRW != null)
            cRW.StopSearch = true;
    }

    private void optProcStringImage_CheckedChanged(object sender, System.EventArgs e)
    {
        this.refreshProcessTab();
    }

    private void optProcStringMemory_CheckedChanged(object sender, System.EventArgs e)
    {
        this.refreshProcessTab();
    }

    private void rtb_TextChanged(object sender, System.EventArgs e)
    {
        this.cmdInfosToClipB.Enabled = (this.rtb.TextLength > 0);
    }

    private void cmdGetOnlineInfos_Click(System.Object sender, System.EventArgs e)
    {
        if (_asyncDlThread != null)
            // Already trying to get infos
            return;
        _AsyncDownload = new cAsyncProcInfoDownload(curProc.Infos.Name);

        // Start async download of infos
        _asyncDlThread = new System.Threading.Thread(_AsyncDownload.BeginDownload());
        {
            var withBlock = _asyncDlThread;
            withBlock.IsBackground = true;
            withBlock.Priority = System.Threading.ThreadPriority.Lowest;
            withBlock.Start();
        }
    }

    // Show services
    public void ShowServices()
    {

        // Update list
        this.lvProcServices.ShowAll = false;
        this.lvProcServices.ProcessId = curProc.Infos.ProcessId;
        this.lvProcServices.UpdateTheItems();
    }

    // Show modules
    public void ShowModules()
    {
        lvModules.ProcessId = curProc.Infos.ProcessId;
        lvModules.UpdateTheItems();
    }

    // Show env variables
    public void ShowEnvVariables()
    {
        lvProcEnv.ProcessId = curProc.Infos.ProcessId;
        lvProcEnv.Peb = curProc.Infos.PebAddress;
        lvProcEnv.UpdateTheItems();
    }

    // Show privileges
    public void ShowPrivileges()
    {
        lvPrivileges.ProcessId = curProc.Infos.ProcessId;
        lvPrivileges.UpdateTheItems();
    }

    // Show threads
    public void ShowThreads()
    {
        this.lvThreads.ProcessId = curProc.Infos.ProcessId;
        this.lvThreads.UpdateTheItems();
    }

    // Show heaps
    public void ShowHeaps()
    {
        this.lvHeaps.ProcessId = curProc.Infos.ProcessId;
        this.lvHeaps.UpdateTheItems();
    }

    // Show network connections
    public void ShowNetwork()
    {
        this.lvProcNetwork.ShowAllPid = false;
        this.lvProcNetwork.ProcessId = curProc.Infos.ProcessId;
        this.lvProcNetwork.UpdateTheItems();
    }

    // Show memory regions
    public void ShowRegions()
    {
        this.lvProcMem.ProcessId = curProc.Infos.ProcessId;
        this.lvProcMem.UpdateTheItems();
    }

    // Show threads
    public void ShowWindows()
    {
        this.lvWindows.ProcessId = curProc.Infos.ProcessId;
        this.lvWindows.ShowAllPid = false;
        this.lvWindows.ShowUnNamed = this.MenuItemWShowUn.Checked;
        this.lvWindows.UpdateTheItems();
    }

    // Display handles of process
    private void ShowHandles()
    {
        this.lvHandles.ShowUnnamed = this.MenuItemShowUnnamedHandles.Checked;
        this.lvHandles.ProcessId = curProc.Infos.ProcessId;
        this.lvHandles.UpdateTheItems();
    }

    // Update log items
    private void ShowLogItems()
    {
        this.lvLog.ProcessId = curProc.Infos.ProcessId;
        this.lvLog.CaptureItems = this.LogCaptureMask;
        this.lvLog.DisplayItems = this.LogDisplayMask;

        this.lvLog.UpdateTheItems();
    }

    private void lvProcString_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.menuViewMemory.Enabled = optProcStringMemory.Checked;
    }

    private void chkLog_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (string.IsNullOrEmpty(fixedFormCaption))
            // Then process has not yet terminated -> allow log
            this.timerLog.Enabled = this.chkLog.Checked;
        else
        {
            this.chkLog.Checked = false;
            this.chkLog.Enabled = false;
        }
    }

    private void timerLog_Tick(System.Object sender, System.EventArgs e)
    {
        if (this.chkFreeze.Checked)
            return;

        int _i = Native.Api.Win32.GetElapsedTime();

        this.lvLog.BeginUpdate();
        ShowLogItems();
        this.lvLog.EndUpdate();

        if (_autoScroll && this.lvLog.Items.Count > 0)
            this.lvLog.Items[this.lvLog.Items.Count - 1].EnsureVisible();

        ChangeCaption();
        Trace.WriteLine("Log updated in " + (Native.Api.Win32.GetElapsedTime() - _i).ToString() + " ms");
    }

    private void cmdClearLog_Click(System.Object sender, System.EventArgs e)
    {
        this.lvLog.Items.Clear();
        _logDico.Clear();
        ChangeCaption();
    }

    private void cmdSave_Click(System.Object sender, System.EventArgs e)
    {
        // Save log
        Program._frmMain.saveDial.Filter = "Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save log";
        try
        {
            if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = Program._frmMain.saveDial.FileName;
                if (Strings.Len(s) > 0)
                {
                    System.IO.StreamWriter stream = new System.IO.StreamWriter(s, false);
                    // Dim x As Integer = 0
                    foreach (ListViewItem cm in this.lvLog.Items)
                        stream.WriteLine(cm.Text + Constants.vbTab + cm.SubItems[1].Text + Constants.vbTab + cm.SubItems[2].Text);
                    stream.WriteLine();
                    stream.WriteLine(System.Convert.ToString(this.lvLog.Items.Count) + " entries(s)");
                    stream.Close();
                    Misc.ShowMsg("Save log", null, "Saved file successfully.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
                }
            }
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Could not save file");
        }
    }

    private void cmdLogOptions_Click(System.Object sender, System.EventArgs e)
    {
        frmLogOptions frm = new frmLogOptions();
        frm.LogCaptureMask = _logCaptureMask;
        frm.LogDisplayMask = _logDisplayMask;
        frm.Form = this;
        frm._autoScroll.Checked = _autoScroll;
        frm.TopMost = Program._frmMain.TopMost;

        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            // Redisplay items
            this.lvLog.CaptureItems = this.LogCaptureMask;
            this.lvLog.DisplayItems = this.LogDisplayMask;
            this.lvLog.ReAddItems();
        }
    }

    private void _AsyncDownload_GotInformations(ref cAsyncProcInfoDownload.InternetProcessInfo result)
    {
        _asyncInfoRes = result;
        _asyncDownloadDone = true;
    }

    private void lstHistoryCat_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Checked)
        {
            _historyGraphNumber += 1;
            Graph2 _g = new Graph2();
            _g.Dock = DockStyle.Top;
            _g.Height = System.Convert.ToInt32((this.containerHistory.Panel2.Height - _historyGraphNumber) / (double)_historyGraphNumber);
            _g.Visible = true;
            _g.ColorGrid = Color.DarkGreen;
            _g.BackColor = Color.Black;
            _g.Name = lstHistoryCat.Items[e.Index].ToString();
            _g.EnableGraph = true;
            _g.Fixedheight = (Strings.InStr(_g.Name, "CpuUsage") > 0);
            _g.ShowSecondGraph = false;
            if (Strings.InStr(_g.Name, "Cpu") > 0)
            {
                _g.Color = Color.LimeGreen;
                _g.Color2 = Color.Green;
            }
            else if (Strings.InStr(_g.Name, "Transfer") + Strings.InStr(_g.Name, "Operation") + Strings.InStr(_g.Name, "Delta") > 0)
            {
                _g.Color = Color.Red;
                _g.Color2 = Color.Maroon;
            }
            else
            {
                _g.Color = Color.Yellow;
                _g.Color2 = Color.Olive;
            }
            this.containerHistory.Panel2.Controls.Add(_g);
            PictureBox _p = new PictureBox();
            _p.BackColor = Color.Transparent;
            _p.Height = 1;
            _p.Dock = DockStyle.Top;
            _p.Name = "_" + lstHistoryCat.Items[e.Index].ToString();

            // Now we add all available values to the graph
            foreach (double _val in curProc.GetHistory(_g.Name))
                _g.AddValue(_val);
            _g.Refresh();

            this.containerHistory.Panel2.Controls.Add(_p);
        }
        else
        {
            _historyGraphNumber -= 1;
            this.containerHistory.Panel2.Controls.RemoveByKey(lstHistoryCat.Items[e.Index].ToString());
            this.containerHistory.Panel2.Controls.RemoveByKey("_" + lstHistoryCat.Items[e.Index].ToString());
        }

        this.containerHistory.Panel1Collapsed = (_historyGraphNumber > 0);

        // Recalculate heights
        foreach (Control ct in this.containerHistory.Panel2.Controls)
        {
            if (ct is Graph2)
            {
                ct.Height = System.Convert.ToInt32((this.containerHistory.Panel2.Height - _historyGraphNumber) / (double)_historyGraphNumber);
                ((Graph2)ct).TopText = ct.Name;
            }
        }
    }

    private void containerHistory_Resize(object sender, System.EventArgs e)
    {
        // Recalculate heights
        foreach (Control ct in this.containerHistory.Panel2.Controls)
        {
            if (ct is Graph2)
                ct.Height = System.Convert.ToInt32((this.containerHistory.Panel2.Height - 2 * _historyGraphNumber) / (double)_historyGraphNumber);
        }
    }

    private void curProc_Refreshed()
    {
        // curProc has been merged, so we have to add a value to the different
        // graphs in containerHistory
        foreach (Control ct in this.containerHistory.Panel2.Controls)
        {
            if (ct is Graph2)
            {
                Graph2 _tempG = (Graph2)ct;
                _tempG.AddValue(curProc.GetInformationNumerical(ct.Name));
                _tempG.Refresh();
            }
        }
    }

    private void cmdRefresh_Click(System.Object sender, System.EventArgs e)
    {
        this.tabProcess_SelectedIndexChanged(null, null);
    }

    private void cmdKill_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to kill this process ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        curProc.Kill();
    }

    private void cmdPause_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to suspend this process ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        curProc.SuspendProcess();
    }

    private void cmdResume_Click(System.Object sender, System.EventArgs e)
    {
        curProc.ResumeProcess();
    }

    private void cmdSet_Click(System.Object sender, System.EventArgs e)
    {
        switch (cbPriority.Text)
        {
            case "Idle":
                {
                    curProc.SetPriority(ProcessPriorityClass.Idle);
                    break;
                }

            case "BelowNormal":
                {
                    curProc.SetPriority(ProcessPriorityClass.BelowNormal);
                    break;
                }

            case "Normal":
                {
                    curProc.SetPriority(ProcessPriorityClass.Normal);
                    break;
                }

            case "AboveNormal":
                {
                    curProc.SetPriority(ProcessPriorityClass.AboveNormal);
                    break;
                }

            case "High":
                {
                    curProc.SetPriority(ProcessPriorityClass.High);
                    break;
                }

            case "RealTime":
                {
                    curProc.SetPriority(ProcessPriorityClass.RealTime);
                    break;
                }
        }
    }

    private void cmdAffinity_Click(System.Object sender, System.EventArgs e)
    {
        cProcess[] c = new cProcess[1];
        c[0] = curProc;
        frmProcessAffinity frm = new frmProcessAffinity(ref c);
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    // When we've finished to get all non fixed infos
    private void asyncAllNonFixedInfos_HasGotAllNonFixedInfos(bool Success, ref Native.Api.NativeStructs.SystemProcessInformation newInfos, string msg)
    {
        if (Success)
            curProc.Merge(ref newInfos);
        else
        {
        }
    }

    // Connection
    public void Connect()
    {
        // Connect providers
        // theConnection.CopyFromInstance(Program.Connection)
        try
        {
            theConnection = Program.Connection;
            this.lvThreads.ConnectionObj = theConnection;
            this.lvModules.ConnectionObj = theConnection;
            this.lvHandles.ConnectionObj = theConnection;
            this.lvProcMem.ConnectionObj = theConnection;
            this.lvLog.ConnectionObj = theConnection;
            this.lvPrivileges.ConnectionObj = theConnection;
            this.lvProcEnv.ConnectionObj = theConnection;
            this.lvProcServices.ConnectionObj = theConnection;
            this.lvWindows.ConnectionObj = theConnection;
            this.lvHeaps.ConnectionObj = theConnection;
            this.lvProcNetwork.ConnectionObj = theConnection;
            theConnection.Connect();
            this.timerProcPerf.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.ProcessInterval * Program.Connection.RefreshmentCoefficient);
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to connect");
        }
    }

    private void theConnection_Connected()
    {
    }

    private void theConnection_Disconnected()
    {
    }

    private void lvProcServices_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            frmServiceInfo frm = new frmServiceInfo();
            frm.SetService(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void lvProcServices_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.MenuItemServOpenDir.Enabled = _local;
        this.MenuItemServFileProp.Enabled = _local;
        this.MenuItemServFileDetails.Enabled = _local;

        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvProcServices.SelectedItems != null
                    && this.lvProcServices.SelectedItems.Count > 0);

            if (_notSnapshotMode)
            {
                if (lvProcServices.SelectedItems.Count == 1)
                {
                    cService cSe = this.lvProcServices.GetSelectedItem();
                    Native.Api.NativeEnums.ServiceStartType start = cSe.Infos.StartType;
                    Native.Api.NativeEnums.ServiceState state = cSe.Infos.State;
                    Native.Api.NativeEnums.ServiceAccept acc = cSe.Infos.AcceptedControl;

                    this.MenuItemServPause.Text = Interaction.IIf(state == Native.Api.NativeEnums.ServiceState.Running, "Pause", "Resume").ToString();
                    MenuItemServPause.Enabled = (acc & Native.Api.NativeEnums.ServiceAccept.PauseContinue) == Native.Api.NativeEnums.ServiceAccept.PauseContinue;
                    MenuItemServStart.Enabled = !(state == Native.Api.NativeEnums.ServiceState.Running);
                    this.MenuItemServStop.Enabled = (acc & Native.Api.NativeEnums.ServiceAccept.Stop) == Native.Api.NativeEnums.ServiceAccept.Stop;

                    this.MenuItemServDisabled.Checked = (start == Native.Api.NativeEnums.ServiceStartType.StartDisabled);
                    MenuItemServDisabled.Enabled = !(MenuItemServDisabled.Checked);
                    MenuItemServAutoStart.Checked = (start == Native.Api.NativeEnums.ServiceStartType.AutoStart);
                    MenuItemServAutoStart.Enabled = !(MenuItemServAutoStart.Checked);
                    MenuItemServOnDemand.Checked = (start == Native.Api.NativeEnums.ServiceStartType.DemandStart);
                    MenuItemServOnDemand.Enabled = !(MenuItemServOnDemand.Checked);
                    MenuItem17.Enabled = true;
                }
                else if (lvProcServices.SelectedItems.Count > 1)
                {
                    MenuItemServPause.Text = "Pause";
                    MenuItemServPause.Enabled = true;
                    MenuItemServStart.Enabled = true;
                    MenuItemServStop.Enabled = true;
                    MenuItemServDisabled.Checked = true;
                    MenuItemServDisabled.Enabled = true;
                    MenuItemServAutoStart.Checked = true;
                    MenuItemServAutoStart.Enabled = true;
                    MenuItemServOnDemand.Checked = true;
                    MenuItemServOnDemand.Enabled = true;
                    MenuItem17.Enabled = true;
                }
                else if (lvProcServices.SelectedItems.Count == 0)
                {
                    MenuItemServPause.Text = "Pause";
                    MenuItemServPause.Enabled = false;
                    MenuItemServStart.Enabled = false;
                    MenuItemServStop.Enabled = false;
                    MenuItemServDisabled.Checked = false;
                    MenuItemServDisabled.Enabled = false;
                    MenuItemServAutoStart.Checked = false;
                    MenuItemServAutoStart.Enabled = false;
                    MenuItemServOnDemand.Checked = false;
                    MenuItemServOnDemand.Enabled = false;
                    MenuItem17.Enabled = false;
                }
            }
            else
            {
                MenuItemServPause.Text = "Pause";
                MenuItemServPause.Enabled = false;
                MenuItemServStart.Enabled = false;
                MenuItemServStop.Enabled = false;
                MenuItemServDisabled.Checked = false;
                MenuItemServDisabled.Enabled = false;
                MenuItemServAutoStart.Checked = false;
                MenuItemServAutoStart.Enabled = false;
                MenuItemServOnDemand.Checked = false;
                MenuItemServOnDemand.Enabled = false;
                MenuItem17.Enabled = false;
            }

            this.MenuItemServFileDetails.Enabled = selectionIsNotNothing && _local && this.lvProcServices.SelectedItems.Count == 1;
            this.MenuItemServFileProp.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServOpenDir.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServSearch.Enabled = selectionIsNotNothing;
            this.MenuItemServDepe.Enabled = selectionIsNotNothing && _notSnapshotMode && _notWMI;
            this.MenuItemServSelService.Enabled = selectionIsNotNothing;
            this.MenuItemServReanalize.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemCopyService.Enabled = selectionIsNotNothing;
            this.MenuItemServDetails.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemServDelete.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;

            this.mnuService.Show(this.lvProcServices, e.Location);
        }
    }

    private void cmdInspectExe_Click(System.Object sender, System.EventArgs e)
    {
        if (System.IO.File.Exists(this.curProc.Infos.Path))
        {
            frmDepViewerMain _depForm = new frmDepViewerMain();
            {
                var withBlock = _depForm;
                withBlock.OpenReferences(this.curProc.Infos.Path);
                withBlock.HideOpenMenu();
                withBlock.TopMost = Program._frmMain.TopMost;
                withBlock.Show();
            }
        }
    }

    private void MenuItem4_Click(System.Object sender, System.EventArgs e)
    {
        tabProcess_SelectedIndexChanged(null, null);
    }

    private void MenuItemCopyBig_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctBigIcon.Image);
    }

    private void MenuItemCopySmall_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctSmallIcon.Image);
    }

    private void pctBigIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.menuCopyPctbig.Show(this.pctBigIcon, e.Location);
    }

    private void pctSmallIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.menuCopyPctSmall.Show(this.pctSmallIcon, e.Location);
    }

    private void menuViewMemory_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcString.SelectedIndices.Count == 0)
            return;

        IntPtr add = (IntPtr)this.lvProcString.Items[this.lvProcString.SelectedIndices[0]].Tag;
        foreach (cMemRegion reg in this.lvProcMem.GetAllItems())
        {
            if (reg.Infos.BaseAddress.IsLowerOrEqualThan(add) && add.IsLowerOrEqualThan(reg.Infos.BaseAddress.Increment(reg.Infos.RegionSize)))
            {
                frmHexEditor frm = new frmHexEditor();
                MemoryHexEditor.MemoryRegion regio = new MemoryHexEditor.MemoryRegion(reg.Infos.BaseAddress, reg.Infos.RegionSize);
                frm.SetPidAndRegion(curProc.Infos.ProcessId, regio);
                frm._hex.NavigateToOffset(System.Convert.ToInt64((add.ToInt64() - regio.BeginningAddress.ToInt64()) / (double)16));
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
                break;
            }
        }
    }

    private void lvProcString_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.menuViewMemory.Enabled = this.lvProcString.SelectedIndices.Count > 0;
            this.mnuString.Show(this.lvProcString, e.Location);
        }
    }

    private void MenuItem9_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to close these connections ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
        {
            if (it.Infos.Protocol == Native.Api.Enums.NetworkProtocol.Tcp)
                it.CloseTCP();
        }
    }

    private void MenuItem11_Click(System.Object sender, System.EventArgs e)
    {
        this.lvProcNetwork.ChooseColumns();
    }

    private void lvHandles_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        foreach (cHandle it in this.lvHandles.GetSelectedItems())
        {
            frmHandleInfo frm = new frmHandleInfo();
            frm.SetHandle(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void lvHandles_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvHandles.SelectedItems != null
                && this.lvHandles.SelectedItems.Count > 0);

            this.MenuItemCloseHandle.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemCopyHandle.Enabled = selectionIsNotNothing;

            this.mnuHandle.Show(this.lvHandles, e.Location);
        }
    }

    private void lvModules_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvModules.SelectedItems != null
&& this.lvModules.SelectedItems.Count > 0);
            this.MenuItemModuleDependencies.Enabled = selectionIsNotNothing && _local;
            this.MenuItemModuleFileDetails.Enabled = selectionIsNotNothing && _local && this.lvModules.SelectedItems.Count == 1;
            this.MenuItemModuleFileProp.Enabled = selectionIsNotNothing && _local;
            this.MenuItemModuleOpenDir.Enabled = selectionIsNotNothing && _local;
            this.MenuItemModuleSearch.Enabled = selectionIsNotNothing;
            this.MenuItemUnloadModule.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemCopyModule.Enabled = selectionIsNotNothing;
            this.MenuItemViewModuleMemory.Enabled = selectionIsNotNothing && _local && this.lvProcMem.Items.Count > 0;
            this.mnuModule.Show(this.lvModules, e.Location);
        }
    }

    private void lvPrivileges_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvPrivileges.SelectedItems != null
&& this.lvPrivileges.SelectedItems.Count > 0);
            this.MenuItemPriDisable.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemPriEnable.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemPriRemove.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemCopyPrivilege.Enabled = selectionIsNotNothing;
            this.mnuPrivileges.Show(this.lvPrivileges, e.Location);
        }
    }

    private void lvProcMem_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvProcMem.SelectedItems != null
&& this.lvProcMem.SelectedItems.Count > 0);
            this.MenuItemViewMemory.Enabled = selectionIsNotNothing & _local;
            this.MenuItemPEBAddress.Enabled = selectionIsNotNothing & _local;
            this.MenuItemCopyMemory.Enabled = selectionIsNotNothing;
            this.MenuItemMemoryDump.Enabled = selectionIsNotNothing & _local;
            this.MenuItemMemoryChangeProtection.Enabled = selectionIsNotNothing & _notWMI && _notSnapshotMode;

            cMemRegion memReg = this.lvProcMem.GetSelectedItem();
            bool b = selectionIsNotNothing && _notWMI && _notSnapshotMode && (memReg != null) && (memReg.Infos.State == Native.Api.NativeEnums.MemoryState.Commit & memReg.Infos.Type == Native.Api.NativeEnums.MemoryType.Private);
            this.MenuItemMemoryDecommit.Enabled = b;
            this.MenuItemMemoryRelease.Enabled = b;

            this.mnuProcMem.Show(this.lvProcMem, e.Location);
        }
    }

    private void lvProcNetwork_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvProcNetwork.SelectedItems != null
                && this.lvProcNetwork.SelectedItems.Count > 0);

            bool enable = false;
            foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
            {
                if (it.Infos.Protocol == Native.Api.Enums.NetworkProtocol.Tcp)
                {
                    if (it.Infos.State != Native.Api.Enums.MibTcpState.Listening && it.Infos.State != Native.Api.Enums.MibTcpState.TimeWait && it.Infos.State != Native.Api.Enums.MibTcpState.CloseWait)
                    {
                        enable = true;
                        break;
                    }
                }
            }
            this.menuCloseTCP.Enabled = enable && _notSnapshotMode;
            this.MenuItemCopyNetwork.Enabled = selectionIsNotNothing;

            bool bTools = true;
            if (this.lvProcNetwork.SelectedItems.Count == 1)
                bTools = (this.lvProcNetwork.GetSelectedItem().Infos.Remote != null);
            this.MenuItemNetworkTools.Enabled = selectionIsNotNothing && bTools;

            this.mnuNetwork.Show(this.lvProcNetwork, e.Location);
        }
    }

    private void lvThreads_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            System.Diagnostics.ThreadPriorityLevel p;

            if (this.lvThreads.SelectedItems.Count > 0)
                p = this.lvThreads.GetSelectedItem().PriorityMod;

            this.MenuItemThIdle.Checked = (p == ThreadPriorityLevel.Idle);
            this.MenuItemThLowest.Checked = (p == ThreadPriorityLevel.Lowest);
            this.MenuItemThBNormal.Checked = (p == ThreadPriorityLevel.BelowNormal);
            this.MenuItemThNorm.Checked = (p == ThreadPriorityLevel.Normal);
            this.MenuItemThANorm.Checked = (p == ThreadPriorityLevel.AboveNormal);
            this.MenuItemThHighest.Checked = (p == ThreadPriorityLevel.Highest);
            this.MenuItemThTimeCr.Checked = (p == ThreadPriorityLevel.TimeCritical);


            bool selectionIsNotNothing = (this.lvThreads.SelectedItems != null
                            && this.lvThreads.SelectedItems.Count > 0);

            this.MenuItemThAffinity.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemThSuspend.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemThTerm.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemThResu.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItem8.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemCopyThread.Enabled = selectionIsNotNothing;

            this.mnuThread.Show(this.lvThreads, e.Location);
        }
    }

    private void lvWindows_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {

            // "Enable"/"Disable" menus
            if (this.lvWindows.SelectedItems.Count == 1)
            {
                cWindow wd = this.lvWindows.GetSelectedItem();
                if ((wd != null))
                {
                    this.MenuItemWEna.Checked = wd.Infos.Enabled;
                    this.MenuItemWDisa.Checked = (wd.Infos.Enabled == false);
                }
            }
            else
            {
                this.MenuItemWEna.Checked = false;
                this.MenuItemWDisa.Checked = false;
            }

            // Other menus
            bool selectionIsNotNothing = (this.lvWindows.SelectedItems.Count > 0);
            this.MenuItemWActive.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWCaption.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWClose.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWDisa.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWEna.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWFlash.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWForeground.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWFront.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWHide.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWMax.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWMin.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWNotFront.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWOpacity.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWPosSize.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWShow.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWShowUn.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWStopFlash.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;
            this.MenuItemWVisiblity.Enabled = _notWMI && _notSnapshotMode && selectionIsNotNothing;

            this.mnuWindow.Show(this.lvWindows, e.Location);
        }
    }

    private void MenuItemCloseHandle_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to close these handles ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cHandle ch in this.lvHandles.GetSelectedItems())
            ch.CloseHandle();
    }

    private void MenuItemShowUnnamedHandles_Click(System.Object sender, System.EventArgs e)
    {
        MenuItemShowUnnamedHandles.Checked = !(MenuItemShowUnnamedHandles.Checked);
    }

    private void MenuItemChooseColumnsHandle_Click(System.Object sender, System.EventArgs e)
    {
        this.lvHandles.ChooseColumns();
    }

    private void MenuItemViewMemory_Click(System.Object sender, System.EventArgs e)
    {
        lvProcMem_DoubleClick(null, null);
    }

    private void MenuItemPEBAddress_Click(System.Object sender, System.EventArgs e)
    {
        IntPtr peb = curProc.Infos.PebAddress;
        foreach (cMemRegion reg in this.lvProcMem.GetAllItems())
        {
            if (reg.Infos.BaseAddress.IsLowerOrEqualThan(peb) && peb.IsLowerOrEqualThan(reg.Infos.BaseAddress.Increment(reg.Infos.RegionSize)))
            {
                frmHexEditor frm = new frmHexEditor();
                MemoryHexEditor.MemoryRegion regio = new MemoryHexEditor.MemoryRegion(reg.Infos.BaseAddress, reg.Infos.RegionSize);
                frm.SetPidAndRegion(curProc.Infos.ProcessId, regio);
                frm._hex.NavigateToOffset(peb.ToInt64());
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
                break;
            }
        }
    }

    private void MenuItemColumnsMemory_Click(System.Object sender, System.EventArgs e)
    {
        this.lvProcMem.ChooseColumns();
    }

    private void MenuItemPriEnable_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cPrivilege it in this.lvPrivileges.GetSelectedItems())
            it.ChangeStatus(Native.Api.NativeEnums.SePrivilegeAttributes.Enabled);
    }

    private void MenuItemPriDisable_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cPrivilege it in this.lvPrivileges.GetSelectedItems())
            it.ChangeStatus(Native.Api.NativeEnums.SePrivilegeAttributes.Disabled);
    }

    private void MenuItemPriRemove_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to remove this privilege ?" + Constants.vbNewLine + "This is a permanent action for all process lifetime.", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cPrivilege it in this.lvPrivileges.GetSelectedItems())
            it.ChangeStatus(Native.Api.NativeEnums.SePrivilegeAttributes.Removed);
    }

    private void MenuItemModuleFileProp_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvModules.SelectedItems.Count > 0)
        {
            string s = this.lvModules.GetSelectedItem().Infos.Path;
            if (System.IO.File.Exists(s))
                cFile.ShowFileProperty(s, this.Handle);
        }
    }

    private void MenuItemModuleOpenDir_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvModules.SelectedItems.Count > 0)
        {
            string s = this.lvModules.GetSelectedItem().Infos.Path;
            if (System.IO.File.Exists(s))
                cFile.OpenDirectory(s);
        }
    }

    private void MenuItemModuleFileDetails_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvModules.SelectedItems.Count > 0)
        {
            string s = this.lvModules.GetSelectedItem().Infos.Path;
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void MenuItemModuleSearch_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lvModules.SelectedItems)
        {
            Application.DoEvents();
            Misc.SearchInternet(it.Text, this.Handle);
        }
    }

    private void MenuItemModuleDependencies_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvModules.SelectedItems.Count > 0)
        {
            string s = this.lvModules.GetSelectedItem().Infos.Path;
            if (System.IO.File.Exists(s))
            {
                frmDepViewerMain _depForm = new frmDepViewerMain();
                {
                    var withBlock = _depForm;
                    withBlock.OpenReferences(s);
                    withBlock.HideOpenMenu();
                    withBlock.TopMost = Program._frmMain.TopMost;
                    withBlock.Show();
                }
            }
        }
    }

    private void MenuItemViewModuleMemory_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcMem.Items.Count == 0)
            ShowRegions();

        foreach (cModule it in this.lvModules.GetSelectedItems())
        {
            IntPtr add = it.Infos.BaseAddress;

            foreach (cMemRegion reg in this.lvProcMem.GetAllItems())
            {
                if (reg.Infos.BaseAddress.IsLowerOrEqualThan(add) && add.IsLowerThan(reg.Infos.BaseAddress.Increment(reg.Infos.RegionSize)))
                {
                    frmHexEditor frm = new frmHexEditor();
                    MemoryHexEditor.MemoryRegion regio = new MemoryHexEditor.MemoryRegion(reg.Infos.BaseAddress, reg.Infos.RegionSize);
                    frm.SetPidAndRegion(curProc.Infos.ProcessId, regio);
                    frm._hex.NavigateToOffset(System.Convert.ToInt64((add.ToInt64() - regio.BeginningAddress.ToInt64()) / (double)16) - 1);
                    frm.TopMost = Program._frmMain.TopMost;
                    frm.Show();
                    break;
                }
            }
        }
    }

    private void MenuItemUnloadModule_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to unload these modules ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cModule it in this.lvModules.GetSelectedItems())
            it.UnloadModule();
    }

    private void MenuItemColumnsModule_Click(System.Object sender, System.EventArgs e)
    {
        this.lvModules.ChooseColumns();
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            frmServiceInfo frm = new frmServiceInfo();
            frm.SetService(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemServSelService_Click(System.Object sender, System.EventArgs e)
    {
        // Select services associated to selected process
        if (this.lvProcServices.SelectedItems.Count > 0)
            Program._frmMain.lvServices.SelectedItems.Clear();

        if (Program._frmMain.lvServices.Items.Count == 0)
            // Refresh list
            Program._frmMain.refreshServiceList();

        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            ListViewItem it2;
            foreach (var it2 in Program._frmMain.lvServices.Items)
            {
                cService cp = Program._frmMain.lvServices.GetItemByKey(it2.Name);
                if (cp != null && cp.Infos.Name == it.Infos.Name)
                {
                    it2.Selected = true;
                    it2.EnsureVisible();
                }
            }
        }
        Program._frmMain.Ribbon.ActiveTab = Program._frmMain.ServiceTab;
        Program._frmMain.Ribbon_MouseMove(null, null);
    }

    private void MenuItemServFileProp_Click(System.Object sender, System.EventArgs e)
    {
        string s = Constants.vbNullString;
        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            s = it.GetInformation("ImagePath");
            if (s != Program.NO_INFO_RETRIEVED)
            {
                if (System.IO.File.Exists(s))
                    cFile.ShowFileProperty(s, this.Handle);
                else
                {
                    // Cannot retrieve a good path
                    frmBox box = new frmBox();
                    {
                        var withBlock = box;
                        withBlock.txtMsg1.Text = "The file path cannot be extracted. Please edit it and then click 'OK' to open file properties box, or click 'Cancel' to cancel.";
                        withBlock.txtMsg1.Height = 35;
                        withBlock.txtMsg2.Top = 50;
                        withBlock.txtMsg2.Height = 25;
                        withBlock.txtMsg2.Text = s;
                        withBlock.txtMsg2.ReadOnly = false;
                        withBlock.txtMsg2.BackColor = System.Drawing.Color.White;
                        withBlock.Text = "Show file properties box";
                        withBlock.Height = 150;
                        withBlock.TopMost = Program._frmMain.TopMost;
                        withBlock.ShowDialog();
                        if (withBlock.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            if (System.IO.File.Exists(withBlock.MsgResult2))
                                cFile.ShowFileProperty(withBlock.MsgResult2, this.Handle);
                        }
                    }
                }
            }
        }
    }

    private void MenuItemServOpenDir_Click(System.Object sender, System.EventArgs e)
    {
        string s = Constants.vbNullString;
        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            string sP = it.GetInformation("ImagePath");
            if (sP != Program.NO_INFO_RETRIEVED)
            {
                s = cFile.GetParentDir(sP);
                if (System.IO.Directory.Exists(s))
                    cFile.OpenADirectory(s);
                else
                {
                    // Cannot retrieve a good path
                    frmBox box = new frmBox();
                    {
                        var withBlock = box;
                        withBlock.txtMsg1.Text = "The file directory cannot be extracted. Please edit it and then click 'OK' to open directory, or click 'Cancel' to cancel.";
                        withBlock.txtMsg1.Height = 35;
                        withBlock.txtMsg2.Top = 50;
                        withBlock.txtMsg2.Height = 25;
                        withBlock.txtMsg2.Text = s;
                        withBlock.txtMsg2.ReadOnly = false;
                        withBlock.txtMsg2.BackColor = System.Drawing.Color.White;
                        withBlock.Text = "Open directory";
                        withBlock.Height = 150;
                        withBlock.TopMost = Program._frmMain.TopMost;
                        withBlock.ShowDialog();
                        if (withBlock.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            if (System.IO.Directory.Exists(withBlock.MsgResult2))
                                cFile.OpenADirectory(withBlock.MsgResult2);
                        }
                    }
                }
            }
        }
    }

    private void MenuItemServFileDetails_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcServices.SelectedItems.Count > 0)
        {
            string s = this.lvProcServices.GetSelectedItem().GetInformation("ImagePath");
            if (System.IO.File.Exists(s) == false)
                s = cFile.IntelligentPathRetrieving2(s);
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void MenuItemServSearch_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lvProcServices.SelectedItems)
        {
            Application.DoEvents();
            Misc.SearchInternet(it.Text, this.Handle);
        }
    }

    private void MenuItemServPause_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
        {
            if (it.Infos.State == Native.Api.NativeEnums.ServiceState.Running)
                it.PauseService();
            else
                it.ResumeService();
        }
    }

    private void MenuItemServStop_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to stop these services ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.StopService();
    }

    private void MenuItemServStart_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.StartService();
    }

    private void MenuItemServAutoStart_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.AutoStart);
    }

    private void MenuItemServOnDemand_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.DemandStart);
    }

    private void MenuItemServDisabled_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.StartDisabled);
    }

    private void MenuItemServReanalize_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.Refresh();
    }

    private void MenuItemServColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvProcServices.ChooseColumns();
    }

    private void MenuItemThTerm_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to terminate these threads ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.ThreadTerminate();
    }

    private void MenuItemThSuspend_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to suspend these threads ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.ThreadSuspend();
    }

    private void MenuItemThResu_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.ThreadResume();
    }

    private void MenuItemThAffinity_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvThreads.SelectedItems.Count == 0)
            return;

        cThread[] c;
        c = new cThread[this.lvThreads.SelectedItems.Count - 1 + 1];
        int x = 0;
        foreach (cThread it in this.lvThreads.GetSelectedItems())
        {
            c[x] = it;
            x += 1;
        }

        frmThreadAffinity frm = new frmThreadAffinity();
        frm.Thread = c;
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void MenuItemThColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvThreads.ChooseColumns();
    }

    private void MenuItemThIdle_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.Idle);
    }

    private void MenuItemThLowest_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.Lowest);
    }

    private void MenuItemThBNormal_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.BelowNormal);
    }

    private void MenuItemThNorm_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.Normal);
    }

    private void MenuItemThANorm_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.AboveNormal);
    }

    private void MenuItemThHighest_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.Highest);
    }

    private void MenuItemThTimeCr_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            it.SetPriority(ThreadPriorityLevel.TimeCritical);
    }

    private void MenuItemWShow_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Show();
    }

    private void MenuItemWShowUn_Click(System.Object sender, System.EventArgs e)
    {
        MenuItemWShowUn.Checked = !(MenuItemWShowUn.Checked);
    }

    private void MenuItemWHide_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Hide();
    }

    private void MenuItemWClose_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to close these windows ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Close();
    }

    private void MenuItemWFront_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.BringToFront(true);
    }

    private void MenuItemWNotFront_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.BringToFront(false);
    }

    private void MenuItemWActive_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.SetAsActiveWindow();
    }

    private void MenuItemWForeground_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.SetAsForegroundWindow();
    }

    private void MenuItemWMin_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Minimize();
    }

    private void MenuItemWMax_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Maximize();
    }

    private void MenuItemWPosSize_Click(System.Object sender, System.EventArgs e)
    {
        Native.Api.NativeStructs.Rect r;

        if (this.lvWindows.SelectedItems.Count > 0)
        {
            frmWindowPosition frm = new frmWindowPosition();
            {
                var withBlock = frm;
                withBlock.SetCurrentPositions(this.lvWindows.GetSelectedItem().Infos.Positions);
                withBlock.TopMost = Program._frmMain.TopMost;

                if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    r = withBlock.NewRect;
                    foreach (cWindow it in this.lvWindows.GetSelectedItems())
                        it.SetPositions(r);
                }
            }
        }
    }

    private void MenuItemWEna_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Enabled = true;
    }

    private void MenuItemWDisa_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Enabled = false;
    }

    private void MenuItemWColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvWindows.ChooseColumns();
    }

    private void MenuItemLogGoto_Click(System.Object sender, System.EventArgs e)
    {
        // Select item in associated listview
        {
            var withBlock = this.lvLog.GetSelectedItem().Infos;
            switch (withBlock.TypeMask)
            {
                case asyncCallbackLogEnumerate.LogItemType.HandleItem:
                    {
                        foreach (ListViewItem it2 in this.lvHandles.Items)
                        {
                            cHandle tmp = this.lvHandles.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.Handle.ToString() == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageHandles;
                                break;
                            }
                        }

                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.MemoryItem:
                    {
                        foreach (ListViewItem it2 in this.lvProcMem.Items)
                        {
                            cMemRegion tmp = this.lvProcMem.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.BaseAddress.ToString() == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageMemory;
                                break;
                            }
                        }

                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.ModuleItem:
                    {
                        foreach (ListViewItem it2 in this.lvModules.Items)
                        {
                            cModule tmp = this.lvModules.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.BaseAddress.ToString() == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageModules;
                                break;
                            }
                        }

                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.NetworkItem:
                    {
                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.ServiceItem:
                    {
                        foreach (ListViewItem it2 in this.lvProcServices.Items)
                        {
                            cService tmp = this.lvProcServices.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.Name == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageMemory;
                                break;
                            }
                        }

                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.ThreadItem:
                    {
                        foreach (ListViewItem it2 in this.lvThreads.Items)
                        {
                            cThread tmp = this.lvThreads.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.Id.ToString() == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageThreads;
                                break;
                            }
                        }

                        break;
                    }

                case asyncCallbackLogEnumerate.LogItemType.WindowItem:
                    {
                        foreach (ListViewItem it2 in this.lvWindows.Items)
                        {
                            cWindow tmp = this.lvWindows.GetItemByKey(it2.Name);
                            if (tmp != null && tmp.Infos.Handle.ToString() == withBlock.DefKey)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                                this.tabProcess.SelectedTab = TabPageWindows;
                                break;
                            }
                        }

                        break;
                    }
            }
        }
    }

    private void lvLog_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.MenuItemLogGoto.Enabled = (this.lvLog.SelectedItems.Count == 1);
            this.MenuItemCopyLog.Enabled = (this.lvLog.SelectedItems.Count > 0);
            this.mnuLog.Show(this.lvLog, e.Location);
        }
    }


    private void MenuItemCopyHandle_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cHandle it in this.lvHandles.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyMemory_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyService_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyThread_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cThread it in this.lvThreads.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyModule_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cModule it in this.lvModules.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyPrivilege_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cPrivilege it in this.lvPrivileges.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyWindow_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyNetwork_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyLog_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cLogItem it in this.lvLog.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyEnvVariable_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cEnvVariable it in this.lvProcEnv.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyHeaps_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cHeap it in this.lvHeaps.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyString_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        if (info == "Position")
        {
            foreach (ListViewItem it in this.lvProcString.SelectedItemsVMode)
                toCopy += it.Text + Constants.vbNewLine;
        }
        else if (info == "String")
        {
            foreach (ListViewItem it in this.lvProcString.SelectedItemsVMode)
                toCopy += it.SubItems[1].Text + Constants.vbNewLine;
        }
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }


    private void lvProcEnv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.MenuItemCopyEnvVariable.Enabled = this.lvProcEnv.SelectedItems.Count > 0;
            this.mnuEnv.Show(this.lvProcEnv, e.Location);
        }
    }

    private void MenuItemServDepe_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcServices.SelectedItems.Count > 0)
        {
            string s = this.lvProcServices.GetSelectedItem().GetInformation("ImagePath");
            if (System.IO.File.Exists(s))
            {
                frmDepViewerMain _depForm = new frmDepViewerMain();
                {
                    var withBlock = _depForm;
                    withBlock.OpenReferences(s);
                    withBlock.HideOpenMenu();
                    withBlock.TopMost = Program._frmMain.TopMost;
                    withBlock.Show();
                }
            }
        }
    }

    private void MenuItemMemoryDump_Click(System.Object sender, System.EventArgs e)
    {
        // Dump memory
        string sDir;
        // Select destination dir
        using (System.Windows.Forms.FolderBrowserDialog chooseF = new System.Windows.Forms.FolderBrowserDialog())
        {
            chooseF.Description = "Choose destination directory";
            chooseF.ShowNewFolderButton = true;
            chooseF.ShowDialog();
            sDir = chooseF.SelectedPath;
        }
        // File name : process-pid-adressHexa.bin
        if (System.IO.Directory.Exists(sDir))
        {
            foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
            {
                string sFile = sDir + @"\" + curProc.Infos.Name + "-" + curProc.Infos.ProcessId.ToString() + "-0x" + it.Infos.BaseAddress.ToString("x") + ".bin";
                bool okToReplace = true;
                if (System.IO.File.Exists(sFile))
                    okToReplace = (Misc.ShowMsg("Dump memory", "Would you like to replace the existing file ?", "File " + sFile + " already exists.", MessageBoxButtons.YesNo, TaskDialogIcon.Warning) == System.Windows.Forms.DialogResult.Yes);
                if (okToReplace)
                    it.DumpToFile(sFile);
            }
        }
    }

    private void MenuItemMemoryRelease_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to release these memory regions ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
            it.Release();
    }

    private void MenuItemMemoryDecommit_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to release these memory regions ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
            it.Decommit();
    }

    private void MenuItemMemoryChangeProtection_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcMem.GetSelectedItems() != null && this.lvProcMem.GetSelectedItems().Count > 0)
        {
            frmChangeMemoryProtection frm = new frmChangeMemoryProtection();
            if (this.lvProcMem.GetSelectedItems().Count == 1)
                // One mem region selected -> check protection type by default
                // with current protection type (in form)
                frm.ProtectionType = this.lvProcMem.GetSelectedItem().Infos.Protection;
            frm.TopMost = Program._frmMain.TopMost;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (cMemRegion it in this.lvProcMem.GetSelectedItems())
                    it.ChangeProtectionType(frm.NewProtectionType);
            }
        }
    }

    private void MenuItemWFlash_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Flash();
    }

    private void MenuItemWStopFlash_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.StopFlashing();
    }

    private void MenuItemWOpacity_Click(System.Object sender, System.EventArgs e)
    {
        byte i;
        int z = 0;

        if (this.lvWindows.SelectedItems.Count > 0)
            z = this.lvWindows.GetSelectedItem().Infos.Opacity;

        string sres = Misc.CInputBox("Set a new opacity [0 to 255, 255 = minimum transparency]", "New opacity", System.Convert.ToString(z));

        if (sres == null || sres.Equals(string.Empty))
            return;

        i = System.Convert.ToByte(Conversion.Val(sres));
        if (i < 0 | i > 255)
            return;

        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Opacity = i;
    }

    private void MenuItemWCaption_Click(System.Object sender, System.EventArgs e)
    {
        string z = "";

        if (this.lvWindows.SelectedItems.Count > 0)
            z = this.lvWindows.GetSelectedItem().Caption;

        string sres = Misc.CInputBox("Set a new caption.", "New caption", z);

        if (sres == null || sres.Equals(string.Empty))
            return;

        foreach (cWindow it in this.lvWindows.GetSelectedItems())
            it.Caption = sres;
    }

    private void lvThreads_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
        else if (e.KeyCode == Keys.Delete)
        {
            if (Misc.WarnDangerousAction("Are you sure you want to terminate these threads ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (cThread it in this.lvThreads.GetSelectedItems())
                it.ThreadTerminate();
        }
    }

    // Handler for process termination event
    public void ProcessHasTerminatedHandler(UInt32 ntStatus)
    {

        // Defined fixed form caption
        fixedFormCaption = curProc.Infos.Name + " (" + curProc.Infos.ProcessId.ToString()
                    + ") exited with status 0x" + ntStatus.ToString("x") + " -- " + Native.Api.Win32.GetNtStatusMessageAsString(ntStatus);
    }



    private void cmdHideFindPanel_Click(System.Object sender, System.EventArgs e)
    {
        My.MySettingsProperty.Settings.ShowFindWindowDetailedForm = false;
        if (My.MySettingsProperty.Settings.FirstTimeShowFindWindowWasClosed)
        {
            My.MySettingsProperty.Settings.FirstTimeShowFindWindowWasClosed = false;
            Misc.ShowMsg("Search panel", "You have closed the search panel.", "Press Ctrl+F on a listview to open it again.", MessageBoxButtons.OK, TaskDialogIcon.Information);
            My.MySettingsProperty.Settings.Save();
        }
        hideFindPanel();
    }

    private void lvProcMem_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvProcServices_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
        else if (e.KeyCode == Keys.Delete)
        {
            if (_notWMI)
                MenuItemServDelete_Click(null, null);
        }
    }

    private void lvProcNetwork_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvProcEnv_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvLog_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvHeaps_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
        else if (e.KeyCode == Keys.Enter)
            this.lvHeaps_MouseDoubleClick(null, null);
    }

    private void lvWindows_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvPrivileges_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvModules_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
    }

    private void lvHandles_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            if (this.SplitContainer.Panel2Collapsed)
                showFindPanel();
        }
        else if (e.KeyCode == Keys.Delete)
        {
            if (Misc.WarnDangerousAction("Are you sure you want to close these handles ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (cHandle it in this.lvHandles.GetSelectedItems())
                it.CloseHandle();
        }
        else if (e.KeyCode == Keys.Enter & this.lvHandles.SelectedItems.Count > 0)
        {
            foreach (cHandle it in this.lvHandles.GetSelectedItems())
            {
                frmHandleInfo frm = new frmHandleInfo();
                frm.SetHandle(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    // Update 'Find panel' depending on the selected tab
    private void updateFindPanel()
    {
        switch (this.tabProcess.SelectedTab.Text)
        {
            case "Token":
                {
                    this.txtSearch.Enabled = true;
                    this.lblResCount.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    listViewForSearch = this.lvPrivileges;
                    break;
                }

            case "Modules":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvModules;
                    break;
                }

            case "Threads":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvThreads;
                    break;
                }

            case "Windows":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvWindows;
                    break;
                }

            case "Handles":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvHandles;
                    break;
                }

            case "Memory":
                {
                    this.lblSearchItemCaption.Enabled = true;
                    this.txtSearch.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvProcMem;
                    break;
                }

            case "Environment":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvProcEnv;
                    break;
                }

            case "Network":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvProcNetwork;
                    break;
                }

            case "Services":
                {
                    this.txtSearch.Enabled = true;
                    this.lblSearchItemCaption.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvProcServices;
                    break;
                }

            case "Log":
                {
                    this.lblSearchItemCaption.Enabled = true;
                    this.txtSearch.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvLog;
                    break;
                }

            case "Heaps":
                {
                    this.lblSearchItemCaption.Enabled = true;
                    this.txtSearch.Enabled = true;
                    this.lblResCount.Enabled = true;
                    listViewForSearch = this.lvHeaps;
                    break;
                }

            default:
                {
                    this.lblSearchItemCaption.Enabled = false;
                    this.txtSearch.Enabled = false;
                    this.lblResCount.Enabled = false;
                    break;
                }
        }
    }
    private void txtSearch_TextChanged(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        string comp = this.txtSearch.Text.ToLowerInvariant();
        foreach (var it in this.listViewForSearch.Items)
        {
            bool add = false;
            foreach (ListViewItem.ListViewSubItem subit in it.SubItems)
            {
                string ss = subit.Text;
                if (subit != null)
                {
                    if (Strings.InStr(ss.ToLowerInvariant(), comp, CompareMethod.Binary) > 0)
                    {
                        add = true;
                        break;
                    }
                }
            }
            if (add == false)
                it.Group = listViewForSearch.Groups[0];
            else
                it.Group = listViewForSearch.Groups[1];
        }
        this.lblResCount.Text = System.Convert.ToString(listViewForSearch.Groups[1].Items.Count) + " result(s)";
    }
    private void lblResCount_Click(System.Object sender, System.EventArgs e)
    {
        if (this.listViewForSearch.Groups[1].Items.Count > 0)
        {
            this.listViewForSearch.Focus();
            this.listViewForSearch.EnsureVisible(this.listViewForSearch.Groups[1].Items[0].Index);
            this.listViewForSearch.SelectedItems.Clear();
            this.listViewForSearch.Groups[1].Items[0].Selected = true;
        }
    }
    private void showFindPanel()
    {
        this.SplitContainer.Panel2Collapsed = false;
        My.MySettingsProperty.Settings.ShowFindWindowDetailedForm = true;
        My.MySettingsProperty.Settings.Save();
        this.txtSearch.Focus();

        // Add groups to listviews
        this.lvThreads.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvProcServices.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvPrivileges.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvLog.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvProcEnv.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvProcMem.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvWindows.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvHandles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvModules.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvProcNetwork.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
        this.lvHeaps.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
        {
            new ListViewGroup("0", "Items"),
            new ListViewGroup("1", "Search results")
        });
    }
    private void hideFindPanel()
    {
        this.SplitContainer.Panel2Collapsed = true;
        // Remove all groups
        this.lvPrivileges.Groups.Clear();
        this.lvProcServices.Groups.Clear();
        this.lvProcNetwork.Groups.Clear();
        this.lvModules.Groups.Clear();
        this.lvThreads.Groups.Clear();
        this.lvLog.Groups.Clear();
        this.lvProcMem.Groups.Clear();
        this.lvWindows.Groups.Clear();
        this.lvHandles.Groups.Clear();
        this.lvProcEnv.Groups.Clear();
        this.lvHeaps.Groups.Clear();
    }


    private void MenuItemServDelete_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to delete these services ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cService it in this.lvProcServices.GetSelectedItems())
            it.DeleteService();
    }

    private void MenuItemHandleDetails_Click(System.Object sender, System.EventArgs e)
    {
        this.lvHandles_MouseDoubleClick(null, null);
    }

    private void lvHeaps_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        cHeap heap = lvHeaps.GetSelectedItem();
        if (heap != null)
        {
            frmHeapBlocks frm = new frmHeapBlocks(curProc.Infos.ProcessId, heap.Infos.BaseAddress);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void lvHeaps_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.MenuItemCopyHeaps.Enabled = this.lvHeaps.SelectedItems.Count > 0;
            this.mnuHeaps.Show(this.lvHeaps, e.Location);
        }
    }

    private void MenuItemColumnsHeap_Click(System.Object sender, System.EventArgs e)
    {
        this.lvHeaps.ChooseColumns();
    }

    private void cmdGoProcess_Click(System.Object sender, System.EventArgs e)
    {
        // Select parent process
        cProcess _t = cProcess.GetProcessById(curProc.Infos.ParentProcessId);
        if (_t != null)
        {
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref _t);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemNetworkPing_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.Ping);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemNetworkRoute_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.TraceRoute);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemNetworkWhoIs_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvProcNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.WhoIs);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void cmdActivateHeapEnumeration_Click(System.Object sender, System.EventArgs e)
    {
        // TOREMOVE
        // This function activate heap enumeration
        this.lvHeaps.Enabled = true;
        this.TabPageHeaps.Controls.Remove(this.cmdActivateHeapEnumeration);
    }
}
