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

public partial class frmServiceInfo
{
    private cService _curServ;

    private cService curServ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _curServ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_curServ != null)
            {
            }

            _curServ = value;
            if (_curServ != null)
            {
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

    private bool _local = true;
    private bool _notWMI;
    private bool _notSnapshotMode = true;


    // Refresh current tab
    private void refreshServiceTab()
    {
        if (curServ == null)
            return;

        switch (this.tabProcess.SelectedTab.Text)
        {
            case "General - 1":
                {
                    if (curServ.Infos.FileInfo != null)
                    {
                        this.txtImageVersion.Text = curServ.Infos.FileInfo.FileVersion;
                        this.lblCopyright.Text = curServ.Infos.FileInfo.LegalCopyright;
                        this.lblDescription.Text = curServ.Infos.FileInfo.FileDescription;
                    }
                    else
                    {
                        this.txtImageVersion.Text = Program.NO_INFO_RETRIEVED;
                        this.lblCopyright.Text = Program.NO_INFO_RETRIEVED;
                        this.lblDescription.Text = Program.NO_INFO_RETRIEVED;
                    }
                    this.txtName.Text = curServ.Infos.DisplayName;
                    if (this.curServ.Infos.ProcessId > 0)
                        this.txtProcess.Text = curServ.Infos.ProcessName + " -- " + curServ.Infos.ProcessId;
                    else
                        this.txtProcess.Text = "Not started";
                    this.txtCommand.Text = curServ.GetInformation("ImagePath");
                    this.txtServicePath.Text = Misc.GetPathFromCommand(this.txtCommand.Text);
                    this.txtStartType.Text = curServ.Infos.StartType.ToString();
                    this.txtState.Text = curServ.Infos.State.ToString();
                    this.txtType.Text = curServ.Infos.ServiceType.ToString();
                    this.cmdGoProcess.Enabled = (this.curServ.Infos.ProcessId > 0);
                    this.cmdPause.Enabled = _notSnapshotMode && ((this.curServ.Infos.AcceptedControl & Native.Api.NativeEnums.ServiceAccept.PauseContinue) == Native.Api.NativeEnums.ServiceAccept.PauseContinue);
                    this.cmdStop.Enabled = _notSnapshotMode && ((this.curServ.Infos.AcceptedControl & Native.Api.NativeEnums.ServiceAccept.Stop) == Native.Api.NativeEnums.ServiceAccept.Stop);
                    this.cmdStart.Enabled = _notSnapshotMode && (this.curServ.Infos.State == Native.Api.NativeEnums.ServiceState.Stopped);
                    break;
                }

            case "General - 2":
                {
                    this.txtCheckPoint.Text = curServ.Infos.CheckPoint.ToString();
                    this.txtDiagnosticMessageFile.Text = curServ.Infos.DiagnosticMessageFile;
                    this.txtErrorControl.Text = curServ.Infos.ErrorControl.ToString();
                    this.txtObjectName.Text = curServ.Infos.ObjectName;
                    this.txtLoadOrderGroup.Text = curServ.Infos.LoadOrderGroup;
                    this.txtServiceFlags.Text = curServ.Infos.ServiceFlags.ToString();
                    this.txtServiceSpecificExitCode.Text = curServ.Infos.ServiceSpecificExitCode.ToString();
                    this.txtServiceStartName.Text = curServ.Infos.ServiceStartName;
                    this.txtTagID.Text = curServ.Infos.TagID.ToString();
                    this.txtWaitHint.Text = curServ.Infos.WaitHint.ToString();
                    this.txtWin32ExitCode.Text = curServ.Infos.Win32ExitCode.ToString();
                    this.rtbDescription.Text = this.curServ.Infos.Description;
                    break;
                }

            case "Dependencies":
                {
                    {
                        var withBlock = tv;
                        withBlock.RootService = curServ.Infos.Name;
                        withBlock.InfosToGet = cServDepConnection.DependenciesToget.DependenciesOfMe;
                        withBlock.UpdateItems();
                    }
                    {
                        var withBlock1 = tv2;
                        withBlock1.RootService = curServ.Infos.Name;
                        withBlock1.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
                        withBlock1.UpdateItems();
                    }

                    break;
                }

            case "Informations":
                {

                    // Description
                    string s = Constants.vbNullString;
                    string description = Constants.vbNullString;
                    string diagnosticsMessageFile = curServ.Infos.DiagnosticMessageFile;
                    string group = curServ.Infos.LoadOrderGroup;
                    string objectName = curServ.Infos.ObjectName;
                    string sp = curServ.GetInformation("ImagePath");

                    // OK it's not the best way to retrive the description...
                    // (if @ -> extract string to retrieve description)
                    string sTemp = curServ.Infos.Description;
                    if (Strings.InStr(sTemp, "@", CompareMethod.Binary) > 0)
                        description = Native.Objects.File.GetResourceStringFromFile(sTemp);
                    else
                        description = sTemp;
                    description = Strings.Replace(curServ.Infos.Description, @"\", @"\\");


                    s = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}";
                    s = s + @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b Service properties\b0\par";
                    s = s + @"\tab Name :\tab\tab\tab " + curServ.Infos.Name + @"\par";
                    s = s + @"\tab Common name :\tab\tab " + curServ.Infos.DisplayName + @"\par";
                    if (Strings.Len(sp) > 0)
                        s = s + @"\tab Path :\tab\tab\tab " + Strings.Replace(curServ.GetInformation("ImagePath"), @"\", @"\\") + @"\par";
                    if (Strings.Len(description) > 0)
                        s = s + @"\tab Description :\tab\tab " + description + @"\par";
                    if (Strings.Len(group) > 0)
                        s = s + @"\tab Group :\tab\tab\tab " + group + @"\par";
                    if (Strings.Len(objectName) > 0)
                        s = s + @"\tab ObjectName :\tab\tab " + objectName + @"\par";
                    if (Strings.Len(diagnosticsMessageFile) > 0)
                        s = s + @"\tab DiagnosticsMessageFile :\tab\tab " + diagnosticsMessageFile + @"\par";
                    s = s + @"\tab State :\tab\tab\tab " + curServ.Infos.State.ToString() + @"\par";
                    s = s + @"\tab Startup :\tab\tab " + curServ.Infos.StartType.ToString() + @"\par";
                    if (curServ.Infos.ProcessId > 0)
                        s = s + @"\tab Owner process :\tab\tab " + curServ.Infos.ProcessId + "-- " + cProcess.GetProcessName(curServ.Infos.ProcessId) + @"\par";
                    s = s + @"\tab Service type :\tab\tab " + curServ.Infos.ServiceType.ToString() + @"\par";

                    s = s + @"\tab AcceptedControl :\tab " + curServ.Infos.AcceptedControl.ToString() + @"\par";
                    s = s + @"\tab CheckPoint :\tab\tab " + curServ.Infos.CheckPoint.ToString() + @"\par";
                    s = s + @"\tab ServiceFlags :\tab\tab " + curServ.Infos.ServiceFlags.ToString() + @"\par";
                    s = s + @"\tab Win32ExitCode :\tab\tab " + curServ.Infos.Win32ExitCode.ToString() + @"\par";
                    s = s + @"\tab WaitHint :\tab\tab " + curServ.Infos.WaitHint.ToString() + @"\par";
                    s = s + @"\tab TagID :\tab\tab\tab " + curServ.Infos.TagID.ToString() + @"\par";
                    s = s + @"\tab ServiceSpecificExitCode :\tab " + curServ.Infos.ServiceSpecificExitCode.ToString() + @"\par";

                    s = s + "}";

                    rtb.Rtf = s;
                    break;
                }
        }
    }

    private void frmServiceInfo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        // Save position & size
        Pref.SaveFormPositionAndSize(this, "PSfrmServiceInfo");
    }

    private void frmServiceInfo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
            tabProcess_SelectedIndexChanged(null, null);
    }

    private void frmProcessInfo_Load(object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        // Some tooltips
        Misc.SetToolTip(this.txtServicePath, "Path of the image file");
        Misc.SetToolTip(this.txtCheckPoint, "Check point value during when service is starting, stopping, pausing...");
        Misc.SetToolTip(this.txtDiagnosticMessageFile, "Diagnostic message file");
        Misc.SetToolTip(this.txtErrorControl, "Severity error is start failed");
        Misc.SetToolTip(this.txtImageVersion, "Version of the image file");
        Misc.SetToolTip(this.txtLoadOrderGroup, "The name of the load ordering group to which this service belongs");
        Misc.SetToolTip(this.txtName, "Name of the service");
        Misc.SetToolTip(this.txtObjectName, "Object name");
        Misc.SetToolTip(this.txtProcess, "Associated process, if any");
        Misc.SetToolTip(this.txtServiceFlags, "Flags (0 or SERVICE_RUNS_IN_SYSTEM_PROCESS, which means that service" + Constants.vbNewLine + "is part of the system and should not be terminated");
        Misc.SetToolTip(this.txtServiceSpecificExitCode, "The service-specific error code that the service returns when an error occurs while the service is starting or stopping");
        Misc.SetToolTip(this.txtServiceStartName, "Name of the account that the service process will be logged on as when it runs.");
        Misc.SetToolTip(this.txtStartType, "Type of start");
        Misc.SetToolTip(this.txtState, "State (running...)");
        Misc.SetToolTip(this.txtTagID, "A unique tag value for this service in the group specified by the lpLoadOrderGroup parameter");
        Misc.SetToolTip(this.txtType, "Type of the service");
        Misc.SetToolTip(this.txtWaitHint, "The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds");
        Misc.SetToolTip(this.txtWin32ExitCode, "The error code that the service uses to report an error that occurs when it is starting or stopping");
        Misc.SetToolTip(this.cmdGetOnlineInfos, "Get online description");
        Misc.SetToolTip(this.cmdInfosToClipB, "Copy services informations to clipboard. Use left click to copy as text, right click to copy as rtf (preserve text style)");
        Misc.SetToolTip(this.cmdGoProcess, "Open details of the associated process");
        Misc.SetToolTip(this.cmdOpenDirectory, "Open direcotry of the image file");
        Misc.SetToolTip(this.cmdInspectExe, "Show dependencies");
        Misc.SetToolTip(this.cmdPause, "Pause service");
        Misc.SetToolTip(this.cmdRefresh, "Refresh informations");
        Misc.SetToolTip(this.cmdResume, "Resume service");
        Misc.SetToolTip(this.cmdServDet1, "Open details of the selected service");
        Misc.SetToolTip(this.cmdServDet2, "Open details of the selected service");
        Misc.SetToolTip(this.cmdSetStartType, "Change start type of the service");
        Misc.SetToolTip(this.cmdShowFileDetails, "Show details of image file");
        Misc.SetToolTip(this.cmdShowFileProperties, "Show file properties");
        Misc.SetToolTip(this.cmdStart, "Start service");
        Misc.SetToolTip(this.cmdStop, "Stop service");
        Misc.SetToolTip(this.cbStart, "Service start type");
        Misc.SetToolTip(this.cmdDelete, "Delete the service");

        switch (My.MySettingsProperty.Settings.ServSelectedTab)
        {
            case "General - 1":
                {
                    this.tabProcess.SelectedTab = this.TabPage1;
                    break;
                }

            case "General - 2":
                {
                    this.tabProcess.SelectedTab = this.TabPage2;
                    break;
                }

            case "Dependencies":
                {
                    this.tabProcess.SelectedTab = this.tabDep;
                    break;
                }

            case "Informations":
                {
                    this.tabProcess.SelectedTab = this.TabPage6;
                    break;
                }
        }

        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmServiceInfo");

        // Icons
        this.tv.ImageList = Program._frmMain.imgServices;
        this.tv2.ImageList = Program._frmMain.imgServices;
        if (cService.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
        {
            if (pctBigIcon.Image == null)
            {
                try
                {
                    pctBigIcon.Image = Misc.GetIcon(this.txtServicePath.Text, false).ToBitmap();
                    pctSmallIcon.Image = Misc.GetIcon(this.txtServicePath.Text, true).ToBitmap();
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
        refreshServiceTab();

        if (My.MySettingsProperty.Settings.AutomaticInternetInfos)
            cmdGetOnlineInfos_Click(null, null);
    }

    // Get process to monitor
    public void SetService(ref cService service)
    {
        curServ = service;

        this.Text = curServ.Infos.Name + " (" + curServ.Infos.DisplayName + ")";

        _local = (cService.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        _notWMI = (cService.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        _notSnapshotMode = (cService.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.SnapshotFile);

        this.cmdShowFileDetails.Enabled = _local;
        this.cmdShowFileProperties.Enabled = _local;
        this.cmdOpenDirectory.Enabled = _local;
        this.cmdInspectExe.Enabled = _local;

        this.txtServicePath.Text = Misc.GetPathFromCommand(curServ.GetInformation("ImagePath"));
        this.cbStart.Text = curServ.Infos.StartType.ToString();

        this.cmdDelete.Enabled = _notSnapshotMode && _notWMI;
        this.cmdPause.Enabled = _notSnapshotMode;
        this.cmdResume.Enabled = _notSnapshotMode;
        this.cmdSetStartType.Enabled = _notSnapshotMode;
        this.cbStart.Enabled = _notSnapshotMode;
        this.cmdStop.Enabled = _notSnapshotMode;

        this.Timer.Enabled = true; // _local

        if (_local)
        {
            try
            {
                if (System.IO.File.Exists(this.txtServicePath.Text) && curServ.Infos.FileInfo == null)
                    curServ.Infos.FileInfo = new SerializableFileVersionInfo(FileVersionInfo.GetVersionInfo(this.txtServicePath.Text));
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        // Verify file
        if (_local)
        {
            try
            {
                bool bVer = Security.WinTrust.WinTrust.VerifyEmbeddedSignature(this.txtServicePath.Text);
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
    }

    // Change caption
    private void ChangeCaption()
    {
        this.Text = curServ.Infos.Name + " (" + curServ.Infos.DisplayName + ")";
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
        // Open directory of selected service
        if (this.txtServicePath.Text != Program.NO_INFO_RETRIEVED)
            cFile.OpenDirectory(this.txtServicePath.Text);
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
        this.refreshServiceTab();
        ChangeCaption();
        My.MySettingsProperty.Settings.ServSelectedTab = this.tabProcess.SelectedTab.Text;
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
        _AsyncDownload = new cAsyncProcInfoDownload(curServ.Infos.Name);

        // Start async download of infos
        _asyncDlThread = new System.Threading.Thread(_AsyncDownload.BeginDownload());
        {
            var withBlock = _asyncDlThread;
            withBlock.IsBackground = true;
            withBlock.Priority = System.Threading.ThreadPriority.Lowest;
            withBlock.Start();
        }
    }

    // Here we finished to download informations from internet
    private cAsyncProcInfoDownload.InternetProcessInfo _asyncInfoRes;
    private bool _asyncDownloadDone = false;
    private void _AsyncDownload_GotInformations(ref cAsyncProcInfoDownload.InternetProcessInfo result)
    {
        _asyncInfoRes = result;
        _asyncDownloadDone = true;
    }

    private void cmdRefresh_Click(System.Object sender, System.EventArgs e)
    {
        this.tabProcess_SelectedIndexChanged(null, null);
    }

    // Connection
    public void Connect()
    {
        // Connect providers
        try
        {
            theConnection = Program.Connection;
            this.tv.ConnectionObj = theConnection;
            this.tv2.ConnectionObj = theConnection;
            theConnection.Connect();
            this.Timer.Interval = System.Convert.ToInt32(1000 * Program.Connection.RefreshmentCoefficient);
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

    private void tv_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        tv.SelectedNode = e.Node.Nodes[0];
    }

    private void servDep_Connected()
    {
        if (this.tabProcess.SelectedTab.Text == "Dependencies")
        {
            {
                var withBlock = tv;
                withBlock.RootService = curServ.Infos.Name;
                withBlock.InfosToGet = cServDepConnection.DependenciesToget.DependenciesOfMe;
                withBlock.UpdateItems();
            }
        }
    }

    private void tv2_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        tv2.SelectedNode = e.Node.Nodes[0];
    }

    private void servDep2_Connected()
    {
        if (this.tabProcess.SelectedTab.Text == "Dependencies")
        {
            {
                var withBlock = tv2;
                withBlock.RootService = curServ.Infos.Name;
                withBlock.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
                withBlock.UpdateItems();
            }
        }
    }

    private void cmdShowFileDetails_Click(System.Object sender, System.EventArgs e)
    {
        string s = this.txtServicePath.Text;
        if (System.IO.File.Exists(s))
            Misc.DisplayDetailsFile(s);
    }

    private void cmdShowFileProperties_Click(System.Object sender, System.EventArgs e)
    {
        // File properties for selected process
        if (System.IO.File.Exists(this.txtServicePath.Text))
            cFile.ShowFileProperty(this.txtServicePath.Text, this.Handle);
    }

    private void cmdPause_Click(System.Object sender, System.EventArgs e)
    {
        curServ.PauseService();
    }

    private void cmdResume_Click(System.Object sender, System.EventArgs e)
    {
        curServ.ResumeService();
    }

    private void cmdStart_Click(System.Object sender, System.EventArgs e)
    {
        curServ.StartService();
    }

    private void cmdStop_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to stop this service ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        curServ.StopService();
    }

    private void cmdSetStartType_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to change the type of start ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        switch (cbStart.Text)
        {
            case "BootStart":
                {
                    curServ.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.BootStart);
                    break;
                }

            case "SystemStart":
                {
                    curServ.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.SystemStart);
                    break;
                }

            case "AutoStart":
                {
                    curServ.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.AutoStart);
                    break;
                }

            case "DemandStart":
                {
                    curServ.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.DemandStart);
                    break;
                }

            case "StartDisabled":
                {
                    curServ.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.StartDisabled);
                    break;
                }
        }
    }

    private void cmdGoProcess_Click(System.Object sender, System.EventArgs e)
    {
        cProcess _t = null;
        Native.Objects.Process.SemCurrentProcesses.WaitOne();
        if (Native.Objects.Process.CurrentProcesses.ContainsKey(curServ.Infos.ProcessId.ToString()))
            _t = Native.Objects.Process.CurrentProcesses[curServ.Infos.ProcessId.ToString()];
        Native.Objects.Process.SemCurrentProcesses.Release();
        if (_t != null)
        {
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref _t);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void txtServicePath_TextChanged(System.Object sender, System.EventArgs e)
    {
        string s = this.txtServicePath.Text;
        bool b = false;
        b = (this._local && System.IO.File.Exists(s));
        this.cmdShowFileDetails.Enabled = b;
        this.cmdShowFileProperties.Enabled = b;
        this.cmdOpenDirectory.Enabled = b;
    }

    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        // Refresh informations about process
        if (!(this.tabProcess.SelectedTab.Text == "Informations" | this.tabProcess.SelectedTab.Text == "Dependencies"))
            this.refreshServiceTab();

        // Display caption
        ChangeCaption();

        // If online infos received, display it
        if (_asyncDownloadDone)
        {
            this.lblSecurityRisk.Text = "Risk : " + _asyncInfoRes._Risk.ToString();
            this.rtbOnlineInfos.Text = _asyncInfoRes._Description;
            _asyncDlThread.Abort();
            _asyncInfoRes = default(cAsyncProcInfoDownload.InternetProcessInfo);
            _asyncDlThread = null;
            _asyncDownloadDone = false;
        }
    }

    private void cmdServDet1_Click(System.Object sender, System.EventArgs e)
    {
        if (this.tv2.SelectedNode != null)
        {
            string s = ((serviceDependenciesList.servTag)this.tv2.SelectedNode.Tag).name;
            cService it = Native.Objects.Service.GetServiceByName(s);
            if (it != null)
            {
                frmServiceInfo frm = new frmServiceInfo();
                frm.SetService(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void cmdServDet2_Click(System.Object sender, System.EventArgs e)
    {
        if (this.tv.SelectedNode != null)
        {
            string s = ((serviceDependenciesList.servTag)this.tv.SelectedNode.Tag).name;
            cService it = Native.Objects.Service.GetServiceByName(s);
            if (it != null)
            {
                frmServiceInfo frm = new frmServiceInfo();
                frm.SetService(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void cmdInspectExe_Click(System.Object sender, System.EventArgs e)
    {
        if (System.IO.File.Exists(this.curServ.GetInformation("ImagePath")))
        {
            frmDepViewerMain _depForm = new frmDepViewerMain();
            {
                var withBlock = _depForm;
                withBlock.OpenReferences(this.curServ.GetInformation("ImagePath"));
                withBlock.HideOpenMenu();
                withBlock.TopMost = Program._frmMain.TopMost;
                withBlock.Show();
            }
        }
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctBigIcon.Image);
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

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctSmallIcon.Image);
    }

    private void MenuItem4_Click(System.Object sender, System.EventArgs e)
    {
        tabProcess_SelectedIndexChanged(null, null);
    }

    private void cmdDelete_Click(System.Object sender, System.EventArgs e)
    {
        if (_notWMI)
        {
            if (Misc.WarnDangerousAction("Are you sure you want to delete this service ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
                return;
            curServ.DeleteService();
        }
    }
}
