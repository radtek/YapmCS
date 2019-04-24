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

public partial class frmJobInfo
{
    private cJob _curJob;

    private cJob curJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _curJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_curJob != null)
            {
            }

            _curJob = value;
            if (_curJob != null)
            {
            }
        }
    }

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
    private void refreshJobTab()
    {
        this.Text = "Job informations (" + curJob.Infos.Name + ")";

        // Here is a special function call :
        // we retrieve our cJob from the main form (lvJob), as they
        // are refreshed in this listview from the correct source (server
        // wmi or local).
        cJob curJobTemp = Program._frmMain.lvJob.GetItemByKey(curJob.Infos.Name);
        if (curJobTemp != null)
            curJob = curJobTemp;

        if (curJob == null)
            return;

        switch (this.tabJob.SelectedTab.Text)
        {
            case "General":
                {
                    // Update processes in job
                    this.lvProcess.Job = curJob;
                    this.lvProcess.UpdateTheItems();
                    break;
                }

            case "Statistics":
                {

                    // CPU
                    DateTime ts;
                    string s;
                    this.lblAffinity.Text = curJob.Infos.BasicLimitInformation.Affinity.ToString();
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalUserTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblUserTime.Text = s;
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.ThisPeriodTotalUserTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblUserPeriod.Text = s;
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalKernelTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblKernelTime.Text = s;
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.ThisPeriodTotalKernelTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblPeriodKernel.Text = s;
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.ThisPeriodTotalKernelTime + curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.ThisPeriodTotalUserTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblTotalPeriod.Text = s;
                    ts = new DateTime(curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalKernelTime + curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalUserTime);
                    s = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    this.lblTotalTime.Text = s;
                    this.lblPriority.Text = curJob.Infos.BasicLimitInformation.PriorityClass.ToString();

                    // Others
                    this.lblTotalProcesses.Text = curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalProcesses.ToString();
                    this.lblActiveProcesses.Text = curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.ActiveProcesses.ToString();
                    this.lblTotalTerminatedProcesses.Text = curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalTerminatedProcesses.ToString();
                    this.lblMaxWSS.Text = Misc.GetFormatedSize(curJob.Infos.BasicLimitInformation.MaximumWorkingSetSize);
                    this.lblMinWSS.Text = Misc.GetFormatedSize(curJob.Infos.BasicLimitInformation.MinimumWorkingSetSize);
                    this.lblSchedulingClass.Text = curJob.Infos.BasicLimitInformation.SchedulingClass.ToString();
                    this.lblPageFaultCount.Text = curJob.Infos.BasicAndIoAccountingInformation.BasicInfo.TotalPageFaultCount.ToString();

                    // IO
                    this.lblProcOther.Text = curJob.Infos.BasicAndIoAccountingInformation.IoInfo.OtherOperationCount.ToString();
                    this.lblProcOtherBytes.Text = Misc.GetFormatedSize(curJob.Infos.BasicAndIoAccountingInformation.IoInfo.OtherTransferCount);
                    this.lblProcReads.Text = curJob.Infos.BasicAndIoAccountingInformation.IoInfo.WriteOperationCount.ToString();
                    this.lblProcReadBytes.Text = Misc.GetFormatedSize(curJob.Infos.BasicAndIoAccountingInformation.IoInfo.ReadTransferCount);
                    this.lblProcWriteBytes.Text = curJob.Infos.BasicAndIoAccountingInformation.IoInfo.ReadOperationCount.ToString();
                    this.lblProcWrites.Text = Misc.GetFormatedSize(curJob.Infos.BasicAndIoAccountingInformation.IoInfo.WriteTransferCount);
                    break;
                }

            case "Limitations":
                {
                    break;
                }
        }
    }

    private void frmJobInfo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        // Save position & size
        Pref.SaveFormPositionAndSize(this, "PSfrmJobInfo");
    }

    private void frmServiceInfo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
            tabJob_SelectedIndexChanged(null, null);
    }

    private void frmProcessInfo_Load(object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        // Some tooltips
        Native.Functions.Misc.SetTheme(this.lvProcess.Handle);
        Native.Functions.Misc.SetTheme(this.lvLimits.Handle);
        Misc.SetToolTip(this.cmdTerminateJob, "Terminate the job");
        Misc.SetToolTip(this.cmdSetLimits, "Add a limit to the job");

        // Load column pref
        Pref.LoadListViewColumns(this.lvProcess, "COLmain_process");

        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmJobInfo");

        // Add some submenus (Copy to clipboard)
        foreach (string ss in jobLimitInfos.GetAvailableProperties(true))
            this.MenuItemCopyLimit.MenuItems.Add(ss, MenuItemCopyLimit_Click);
        foreach (string ss in processInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyProcess.MenuItems.Add(ss, MenuItemCopyProcess_Click);

        switch (My.MySettingsProperty.Settings.JobSelectedTab)
        {
            case "General":
                {
                    this.tabJob.SelectedTab = this.pageGeneral;
                    break;
                }

            case "Statistics":
                {
                    this.tabJob.SelectedTab = this.pageStats;
                    break;
                }

            case "Limitations":
                {
                    this.tabJob.SelectedTab = this.pageLimitations;
                    break;
                }
        }

        Connect();
        refreshJobTab();
    }


    private void MenuItemCopyProcess_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyLimit_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cJobLimit it in this.lvLimits.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }


    // Get process to monitor
    public void SetJob(ref cJob job)
    {
        curJob = job;

        _local = (cJob.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        _notWMI = (cJob.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        _notSnapshotMode = (cJob.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.SnapshotFile);

        this.Timer.Enabled = true;
        this.TimerLimits.Enabled = true;
        this.cmdSetLimits.Enabled = _notWMI && _notSnapshotMode;
        this.cmdTerminateJob.Enabled = _notSnapshotMode;
    }

    private void tabJob_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.refreshJobTab();
        My.MySettingsProperty.Settings.JobSelectedTab = this.tabJob.SelectedTab.Text;
    }

    // Connection
    public void Connect()
    {
        // Connect providers
        // theConnection.CopyFromInstance(Program.Connection)
        try
        {
            theConnection = Program.Connection;
            this.lvProcess.ConnectionObj = theConnection;
            this.lvLimits.ConnectionObj = theConnection;
            theConnection.Connect();
            this.Timer.Interval = System.Convert.ToInt32(1000 * Program.Connection.RefreshmentCoefficient);
            this.TimerLimits.Interval = System.Convert.ToInt32(1000 * Program.Connection.RefreshmentCoefficient);
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

    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        // Refresh informations about process
        this.refreshJobTab();
    }

    private void cmdTerminateJob_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to terminate the job ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        curJob.TerminateJob();
    }

    private void TimerLimits_Tick(System.Object sender, System.EventArgs e)
    {
        this.lvLimits.JobName = curJob.Infos.Name;
        this.lvLimits.UpdateTheItems();
    }

    private void lvLimits_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectedAtLeastOnce = (this.lvLimits.GetSelectedItems() != null && this.lvLimits.GetSelectedItems().Count >= 1);
            this.MenuItemCopyLimit.Enabled = selectedAtLeastOnce;
            this.mnuLimit.Show(this.lvLimits, e.Location);
        }
    }

    private void MenuItemLimitRemove_Click(System.Object sender, System.EventArgs e)
    {
    }

    private void cmdSetLimits_Click(System.Object sender, System.EventArgs e)
    {
        frmSetJobLimits frm = new frmSetJobLimits(ref this);
        frm.JobName = curJob.Infos.Name;
        frm.ShowDialog();
    }

    private void lvProcess_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete & this.lvProcess.SelectedItems.Count > 0)
        {
            if (Misc.WarnDangerousAction("Are you sure you want to kill these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (cProcess it in this.lvProcess.GetSelectedItems())
                it.Kill();
        }
        else if (e.KeyCode == Keys.Enter & this.lvProcess.SelectedItems.Count > 0)
        {
            foreach (cProcess it in this.lvProcess.GetSelectedItems())
            {
                frmProcessInfo frm = new frmProcessInfo();
                frm.SetProcess(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void lvProcess_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            foreach (cProcess it in this.lvProcess.GetSelectedItems())
            {
                frmProcessInfo frm = new frmProcessInfo();
                frm.SetProcess(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void lvProcess_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            int p = -1;
            if (this.lvProcess.SelectedItems == null)
            {
                this.MenuItemProcPIdle.Checked = false;
                this.MenuItemProcPN.Checked = false;
                this.MenuItemProcPAN.Checked = false;
                this.MenuItemProcPBN.Checked = false;
                this.MenuItemProcPH.Checked = false;
                this.MenuItemProcPRT.Checked = false;
                return;
            }
            if (this.lvProcess.SelectedItems.Count == 1)
                p = this.lvProcess.GetSelectedItem().Infos.Priority;
            this.MenuItemProcPIdle.Checked = (p == ProcessPriorityClass.Idle);
            this.MenuItemProcPN.Checked = (p == ProcessPriorityClass.Normal);
            this.MenuItemProcPAN.Checked = (p == ProcessPriorityClass.AboveNormal);
            this.MenuItemProcPBN.Checked = (p == ProcessPriorityClass.BelowNormal);
            this.MenuItemProcPH.Checked = (p == ProcessPriorityClass.High);
            this.MenuItemProcPRT.Checked = (p == ProcessPriorityClass.RealTime);

            bool selectionIsNotNothing = (this.lvProcess.SelectedItems != null && this.lvProcess.SelectedItems.Count > 0);
            this.MenuItem35.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcKill.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcPriority.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcResume.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcKillT.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcStop.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcResume.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcSFileDetails.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcSFileProp.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcSOpenDir.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcSSearch.Enabled = selectionIsNotNothing;
            this.MenuItemProcSDep.Enabled = selectionIsNotNothing && _local;
            this.MenuItemCopyProcess.Enabled = selectionIsNotNothing;
            this.MenuItemProcSFileDetails.Enabled = (selectionIsNotNothing && this.lvProcess.SelectedItems.Count == 1 && _local);
            this.MenuItemProcDump.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcAff.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcWSS.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcKillByMethod.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;

            this.mnuProcess.Show(this.lvProcess, e.Location);
        }
    }

    private void MenuItemProcKill_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to kill these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.Kill();
    }

    private void MenuItemProcKillT_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to kill these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.KillProcessTree();
    }

    private void MenuItemProcStop_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to suspend these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SuspendProcess();
    }

    private void MenuItemProcResume_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.ResumeProcess();
    }

    private void MenuItemProcPIdle_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.Idle);
    }

    private void MenuItemProcPBN_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.BelowNormal);
    }

    private void MenuItemProcPN_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.Normal);
    }

    private void MenuItemProcPAN_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.AboveNormal);
    }

    private void MenuItemProcPH_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.High);
    }

    private void MenuItemProcPRT_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            cp.SetPriority(ProcessPriorityClass.RealTime);
    }

    private void MenuItemProcWorkingSS_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess _p in this.lvProcess.GetSelectedItems())
            _p.EmptyWorkingSetSize();
    }

    private void MenuItemProcDump_Click(System.Object sender, System.EventArgs e)
    {
        frmDumpFile _frm = new frmDumpFile();
        _frm.TopMost = Program._frmMain.TopMost;
        if (_frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            {
                string _file = _frm.TargetDir + @"\" + DateTime.Now.Ticks.ToString() + "_" + cp.Infos.Name + ".dmp";
                cp.CreateDumpFile(_file, _frm.DumpOption);
            }
        }
    }

    private void MenuItemProcAff_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcess.SelectedItems.Count == 0)
            return;

        cProcess[] c;
        c = new cProcess[this.lvProcess.SelectedItems.Count - 1 + 1];
        int x = 0;
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
        {
            c[x] = it;
            x += 1;
        }

        frmProcessAffinity frm = new frmProcessAffinity(ref c);
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void MenuItemProcSFileProp_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (System.IO.File.Exists(cp.Infos.Path))
                cFile.ShowFileProperty(cp.Infos.Path, this.Handle);
        }
    }

    private void MenuItemProcSOpenDir_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (cp.Infos.Path != Program.NO_INFO_RETRIEVED)
                cFile.OpenDirectory(cp.Infos.Path);
        }
    }

    private void MenuItemProcSFileDetails_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcess.SelectedItems.Count > 0)
        {
            cProcess cp = this.lvProcess.GetSelectedItem();
            string s = cp.Infos.Path;
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void MenuItemProcSSearch_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            Application.DoEvents();
            Misc.SearchInternet(cp.Infos.Name, this.Handle);
        }
    }

    private void MenuItemProcSDep_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
        {
            if (System.IO.File.Exists(it.Infos.Path))
            {
                frmDepViewerMain frm = new frmDepViewerMain();
                frm.HideOpenMenu();
                frm.OpenReferences(it.Infos.Path);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void MenuItemProcColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvProcess.ChooseColumns();
    }
}
