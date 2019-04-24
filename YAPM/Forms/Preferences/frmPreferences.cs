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
using System;
using Microsoft.Samples;

public partial class frmPreferences
{
    private int _newcolor;
    private int _deletedcolor;

    private void cmdQuit_Click(System.Object sender, System.EventArgs e)
    {
        Program._frmMain.timerProcess.Interval = My.MySettingsProperty.Settings.ProcessInterval;
        Program._frmMain.timerTask.Interval = My.MySettingsProperty.Settings.TaskInterval;
        Program._frmMain.timerNetwork.Interval = My.MySettingsProperty.Settings.NetworkInterval;
        Program._frmMain.timerServices.Interval = My.MySettingsProperty.Settings.ServiceInterval;
        Program._frmMain.timerTrayIcon.Interval = My.MySettingsProperty.Settings.TrayInterval;
        Program._frmMain.timerJobs.Interval = My.MySettingsProperty.Settings.JobInterval;
        this.Close();
    }

    private void cmdSave_Click(System.Object sender, System.EventArgs e)
    {
        // Save
        bool _oldRibbonStyle = My.MySettingsProperty.Settings.UseRibbonStyle;
        My.MySettingsProperty.Settings.ServiceInterval = System.Convert.ToInt32(Conversion.Val(this.txtServiceIntervall.Text));
        My.MySettingsProperty.Settings.ProcessInterval = System.Convert.ToInt32(Conversion.Val(this.txtProcessIntervall.Text));
        My.MySettingsProperty.Settings.WindowsStartup = this.chkStart.Checked;
        My.MySettingsProperty.Settings.StartHidden = this.chkStartTray.Checked;
        My.MySettingsProperty.Settings.ReplaceTaskmgr = this.chkReplaceTaskmgr.Checked;
        My.MySettingsProperty.Settings.TopMost = this.chkTopMost.Checked;
        My.MySettingsProperty.Settings.NewItemColor = _newcolor;
        My.MySettingsProperty.Settings.HideWhenClosed = this.chkHideClosed.Checked;
        My.MySettingsProperty.Settings.DeletedItemColor = _deletedcolor;
        My.MySettingsProperty.Settings.ShowTrayIcon = this.chkTrayIcon.Checked;
        My.MySettingsProperty.Settings.Priority = this.cbPriority.SelectedIndex;
        My.MySettingsProperty.Settings.TaskInterval = System.Convert.ToInt32(Conversion.Val(this.txtTaskInterval.Text));
        My.MySettingsProperty.Settings.NetworkInterval = System.Convert.ToInt32(Conversion.Val(this.txtNetworkInterval.Text));
        My.MySettingsProperty.Settings.JobInterval = System.Convert.ToInt32(Conversion.Val(this.txtJobInterval.Text));
        My.MySettingsProperty.Settings.UseRibbonStyle = this.chkRibbon.Checked;
        My.MySettingsProperty.Settings.SearchEngine = this.txtSearchEngine.Text;
        My.MySettingsProperty.Settings.WarnDangerousActions = this.chkWarn.Checked;
        My.MySettingsProperty.Settings.HideWhenMinimized = this.chkHideMinimized.Checked;
        My.MySettingsProperty.Settings.TrayInterval = System.Convert.ToInt32(Conversion.Val(this.txtTrayInterval.Text));
        My.MySettingsProperty.Settings.SystemInterval = System.Convert.ToInt32(Conversion.Val(this.txtSysInfoInterval.Text));
        My.MySettingsProperty.Settings.AutomaticInternetInfos = this.chkAutoOnline.Checked;
        My.MySettingsProperty.Settings.AutomaticWintrust = this.chkWintrust.Checked;
        My.MySettingsProperty.Settings.ShowUserGroupDomain = this.chkUserGroup.Checked;
        My.MySettingsProperty.Settings.ShowStatusBar = this.chkStatusBar.Checked;
        My.MySettingsProperty.Settings.ShowFixedTab = this.chkFixedTab.Checked;
        My.MySettingsProperty.Settings.FixedTab = this.cbShownTab.Text;
        My.MySettingsProperty.Settings.UpdateAlpha = this.chkUpdateAlpha.Checked;
        My.MySettingsProperty.Settings.UpdateBeta = this.chkUpdateBeta.Checked;
        My.MySettingsProperty.Settings.UpdateAuto = this.chkUpdateAuto.Checked;
        My.MySettingsProperty.Settings.UpdateServer = this.txtUpdateServer.Text;
        My.MySettingsProperty.Settings.ShowClassicMessageBoxes = this.chkClassicMsgbox.Checked;
        My.MySettingsProperty.Settings.CoefTimeMul = System.Convert.ToInt32(this.valCoefRemote.Value);
        My.MySettingsProperty.Settings.RememberPosAndSize = this.chkRemember.Checked;

        if (this.chkUnlimitedBuf.Checked)
            My.MySettingsProperty.Settings.HistorySize = -1;
        else
            My.MySettingsProperty.Settings.HistorySize = System.Convert.ToInt32(this.bufferSize.Value * 1024);

        Common.Misc.StartWithWindows(My.MySettingsProperty.Settings.WindowsStartup);
        Common.Misc.ReplaceTaskmgr(My.MySettingsProperty.Settings.ReplaceTaskmgr);

        // Highlightings
        foreach (ListViewItem it in this.lvHighlightingOther.Items)
        {
            if (it.Text == "Suspended thread")
            {
                My.MySettingsProperty.Settings.HighlightingColorSuspendedThread = it.BackColor;
                // My.Settings.HighlightingPrioritySuspendedThread = CByte(it.Index + 1)
                My.MySettingsProperty.Settings.EnableHighlightingSuspendedThread = it.Checked;
            }
            else if (it.Text == "Relocated module")
            {
                My.MySettingsProperty.Settings.HighlightingColorRelocatedModule = it.BackColor;
                // My.Settings.HighlightingPriorityRelocatedModule = CByte(it.Index + 1)
                My.MySettingsProperty.Settings.EnableHighlightingRelocatedModule = it.Checked;
            }
        }
        foreach (ListViewItem it in this.lvHighlightingProcess.Items)
        {
            if (it.Text == "Process being debugged")
            {
                My.MySettingsProperty.Settings.HighlightingColorBeingDebugged = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityBeingDebugged = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingBeingDebugged = it.Checked;
            }
            else if (it.Text == "Critical process")
            {
                My.MySettingsProperty.Settings.HighlightingColorCriticalProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityCriticalProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingCriticalProcess = it.Checked;
            }
            else if (it.Text == "Elevated process")
            {
                My.MySettingsProperty.Settings.HighlightingColorElevatedProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityElevatedProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingElevated = it.Checked;
            }
            else if (it.Text == "Process in job")
            {
                My.MySettingsProperty.Settings.HighlightingColorJobProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityJobProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingJobProcess = it.Checked;
            }
            else if (it.Text == "Service process")
            {
                My.MySettingsProperty.Settings.HighlightingColorServiceProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityServiceProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingServiceProcess = it.Checked;
            }
            else if (it.Text == "Owned process")
            {
                My.MySettingsProperty.Settings.HighlightingColorOwnedProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPriorityOwnedProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingOwnedProcess = it.Checked;
            }
            else if (it.Text == "System process")
            {
                My.MySettingsProperty.Settings.HighlightingColorSystemProcess = it.BackColor;
                My.MySettingsProperty.Settings.HighlightingPrioritySystemProcess = System.Convert.ToByte(it.Index + 1);
                My.MySettingsProperty.Settings.EnableHighlightingSystemProcess = it.Checked;
            }
        }

        Program.Preferences.Save();
        Program.Preferences.Apply();

        if (!(_oldRibbonStyle == My.MySettingsProperty.Settings.UseRibbonStyle))
        {
            int ret;
            ret = Misc.ShowMsg("Menu style has changed", "The new menu style will be displayed next time you start YAPM.", "Do you want to exit YAPM now ?", MessageBoxButtons.YesNo, TaskDialogIcon.Information, true);
            if (ret == DialogResult.Yes)
            {
                Program.ExitYAPM();
                return;
            }
        }

        Misc.ShowMsg("Preferences", null, "Saved preferences sucessfully.", MessageBoxButtons.OK, TaskDialogIcon.Information);
    }

    private void frmPreferences_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(this.lvHighlightingProcess.Handle);
        Native.Functions.Misc.SetTheme(this.lvHighlightingOther.Handle);

        Misc.SetToolTip(this.chkReplaceTaskmgr, "Replace taskmgr (do not forget to uncheck this option before you delete/move YAPM executable !!");
        Misc.SetToolTip(this.chkStart, "Start YAPM on Windows startup.");
        Misc.SetToolTip(this.chkStartTray, "Start YAPM hidden (only in tray system).");
        Misc.SetToolTip(this.txtProcessIntervall, "Set interval (milliseconds) between two refreshments of process list.");
        Misc.SetToolTip(this.txtServiceIntervall, "Set interval (milliseconds) between two refreshments of service list.");
        Misc.SetToolTip(this.cmdSave, "Save configuration.");
        Misc.SetToolTip(this.cmdQuit, "Quit without saving.");
        Misc.SetToolTip(this.cmdDefaut, "Set default configuration.");
        Misc.SetToolTip(this.chkTopMost, "Start YAPM topmost.");
        Misc.SetToolTip(this.pctDeletedItems, "Color of deleted items.");
        Misc.SetToolTip(this.pctNewitems, "Color of new items.");
        Misc.SetToolTip(this.chkTrayIcon, "Show tray icon.");
        Misc.SetToolTip(this.cbPriority, "Priority of YAPM.");
        Misc.SetToolTip(this.chkWintrust, "Verify the signature of processes when opening process' detailed window.");
        Misc.SetToolTip(this.txtTaskInterval, "Set interval (milliseconds) between two refreshments of task list.");
        Misc.SetToolTip(this.txtNetworkInterval, "Set interval (milliseconds) between two refreshments of network connections list.");
        Misc.SetToolTip(this.txtJobInterval, "Set interval (milliseconds) between two refreshments of job list.");
        Misc.SetToolTip(this.chkRibbon, "Show ribbon style menu.");
        Misc.SetToolTip(this.txtSearchEngine, "Search engine for 'Internet search'. Use the keyword ITEM to specify the item name to search.");
        Misc.SetToolTip(this.chkWarn, "Warn user for all (potentially) dangerous actions.");
        Misc.SetToolTip(this.chkHideMinimized, "Hide main form when minimized.");
        Misc.SetToolTip(this.txtTrayInterval, "Set interval (milliseconds) between two refreshments of tray icon.");
        Misc.SetToolTip(this.txtSysInfoInterval, "Set interval (milliseconds) between two refreshments of system/network informations.");
        Misc.SetToolTip(this.chkHideClosed, "Hide YAPM when user click on 'close' button");
        Misc.SetToolTip(this.chkUnlimitedBuf, "No size limit for history");
        Misc.SetToolTip(this.bufferSize, "Size of the buffer used to save history of statistics of one process (KB). The change of this value will be applied on the next start of YAPM.");
        Misc.SetToolTip(this.chkAutoOnline, "Automatically retrieve online description of a process/service when detailed form is showned.");
        Misc.SetToolTip(this.lvHighlightingProcess, "Enabled or not highlighting of items in listviews. Double click on a category to change its color.");
        Misc.SetToolTip(this.lvHighlightingOther, "Enabled or not highlighting of items in listviews. Double click on a category to change its color.");
        Misc.SetToolTip(this.cmdMoveDownProcess, "Decrease priority of selected category.");
        Misc.SetToolTip(this.cmdMoveUpProcess, "Increase priority of selected category.");
        Misc.SetToolTip(this.chkUserGroup, "Show or not user group/domain in process listview.");
        Misc.SetToolTip(this.chkStatusBar, "Show or not status bar on main form.");
        Misc.SetToolTip(this.chkFixedTab, "Show always the same tab when YAPM starts.");
        Misc.SetToolTip(this.cbShownTab, "Tab to show when YAPM starts.");
        Misc.SetToolTip(this.chkUpdateAlpha, "Check for alpha releases.");
        Misc.SetToolTip(this.chkUpdateBeta, "Check for beta releases.");
        Misc.SetToolTip(this.chkUpdateAuto, "Check for updates at startup.");
        Misc.SetToolTip(this.cmdUpdateCheckNow, "Check for updates now.");
        Misc.SetToolTip(this.txtUpdateServer, "Update server.");
        Misc.SetToolTip(this.chkClassicMsgbox, "Display classical messageboxes (Windows XP style)");
        Misc.SetToolTip(this.valCoefRemote, "Coefficient for update interval in case of remote monitoring." + Constants.vbNewLine + "For example, if you set 200, all refreshment intervals for remote monitoring will" + Constants.vbNewLine + "be 2 times greater than intervals for local monitoring.");
        Misc.SetToolTip(this.chkRemember, "Remember position and size of the main windows.");


        // Set control's values
        this.txtServiceIntervall.Text = My.MySettingsProperty.Settings.ServiceInterval.ToString();
        this.txtProcessIntervall.Text = My.MySettingsProperty.Settings.ProcessInterval.ToString();
        this.chkStart.Checked = My.MySettingsProperty.Settings.WindowsStartup;
        this.chkStartTray.Checked = My.MySettingsProperty.Settings.StartHidden;
        this.chkReplaceTaskmgr.Checked = My.MySettingsProperty.Settings.ReplaceTaskmgr;
        this.chkTopMost.Checked = My.MySettingsProperty.Settings.TopMost;
        this.pctNewitems.BackColor = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        this.pctDeletedItems.BackColor = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        _newcolor = My.MySettingsProperty.Settings.NewItemColor;
        _deletedcolor = My.MySettingsProperty.Settings.DeletedItemColor;
        this.chkTrayIcon.Checked = My.MySettingsProperty.Settings.ShowTrayIcon;
        this.cbPriority.SelectedIndex = My.MySettingsProperty.Settings.Priority;
        this.txtTaskInterval.Text = My.MySettingsProperty.Settings.TaskInterval.ToString();
        this.txtNetworkInterval.Text = My.MySettingsProperty.Settings.NetworkInterval.ToString();
        this.chkRibbon.Checked = My.MySettingsProperty.Settings.UseRibbonStyle;
        this.txtSearchEngine.Text = My.MySettingsProperty.Settings.SearchEngine;
        this.chkWarn.Checked = My.MySettingsProperty.Settings.WarnDangerousActions;
        this.chkHideMinimized.Checked = My.MySettingsProperty.Settings.HideWhenMinimized;
        this.txtTrayInterval.Text = My.MySettingsProperty.Settings.TrayInterval.ToString();
        this.txtSysInfoInterval.Text = My.MySettingsProperty.Settings.SystemInterval.ToString();
        this.chkWintrust.Checked = My.MySettingsProperty.Settings.AutomaticWintrust;
        this.chkHideClosed.Checked = My.MySettingsProperty.Settings.HideWhenClosed;
        this.chkAutoOnline.Checked = My.MySettingsProperty.Settings.AutomaticInternetInfos;
        this.chkUserGroup.Checked = My.MySettingsProperty.Settings.ShowUserGroupDomain;
        this.chkStatusBar.Checked = My.MySettingsProperty.Settings.ShowStatusBar;
        this.txtJobInterval.Text = My.MySettingsProperty.Settings.JobInterval.ToString();
        this.chkFixedTab.Checked = My.MySettingsProperty.Settings.ShowFixedTab;
        this.chkUpdateAlpha.Checked = My.MySettingsProperty.Settings.UpdateAlpha;
        this.chkUpdateBeta.Checked = My.MySettingsProperty.Settings.UpdateBeta;
        this.chkUpdateAuto.Checked = My.MySettingsProperty.Settings.UpdateAuto;
        this.txtUpdateServer.Text = My.MySettingsProperty.Settings.UpdateServer;
        this.chkClassicMsgbox.Checked = My.MySettingsProperty.Settings.ShowClassicMessageBoxes;
        this.chkClassicMsgbox.Enabled = false; // cEnvironment.SupportsTaskDialog
        this.valCoefRemote.Value = My.MySettingsProperty.Settings.CoefTimeMul;
        this.chkRemember.Checked = My.MySettingsProperty.Settings.RememberPosAndSize;

        if (My.MySettingsProperty.Settings.HistorySize > 0)
        {
            this.bufferSize.Value = System.Convert.ToInt32(My.MySettingsProperty.Settings.HistorySize / (double)1024);
            this.chkUnlimitedBuf.Checked = false;
        }
        else
        {
            this.bufferSize.Value = 0;
            this.chkUnlimitedBuf.Checked = true;
        }

        // Fill in list of main tabs
        foreach (TabPage t in Program._frmMain._tab.TabPages)
            this.cbShownTab.Items.Add(t.Text);
        this.cbShownTab.Text = My.MySettingsProperty.Settings.FixedTab;
        this.cbShownTab.Enabled = this.chkFixedTab.Checked;

        // Add items of "Highlighting listviews" in saved order
        this.lvHighlightingOther.Items.Clear();
        ListViewItem[] s;
        s = new ListViewItem[2];
        s[0] = new ListViewItem("Suspended thread"); // index = My.Settings.HighlightingPrioritySuspendedThread - 1
        s[1] = new ListViewItem("Relocated module");
        this.lvHighlightingOther.Items.AddRange(s);
        // 
        this.lvHighlightingProcess.Items.Clear();
        ListViewItem[] s2;
        s2 = new ListViewItem[7];
        s2[My.MySettingsProperty.Settings.HighlightingPriorityCriticalProcess - 1] = new ListViewItem("Critical process");
        s2[My.MySettingsProperty.Settings.HighlightingPriorityElevatedProcess - 1] = new ListViewItem("Elevated process");
        s2[My.MySettingsProperty.Settings.HighlightingPriorityJobProcess - 1] = new ListViewItem("Process in job");
        s2[My.MySettingsProperty.Settings.HighlightingPriorityServiceProcess - 1] = new ListViewItem("Service process");
        s2[My.MySettingsProperty.Settings.HighlightingPriorityOwnedProcess - 1] = new ListViewItem("Owned process");
        s2[My.MySettingsProperty.Settings.HighlightingPrioritySystemProcess - 1] = new ListViewItem("System process");
        s2[My.MySettingsProperty.Settings.HighlightingPriorityBeingDebugged - 1] = new ListViewItem("Process being debugged");
        this.lvHighlightingProcess.Items.AddRange(s2);

        // Set colors of "Highlighting items"
        setColorOfHighlightingItems();

        // Set checkboxes of "Highlighting items"
        this.lvHighlightingOther.Items[0].Checked = My.MySettingsProperty.Settings.EnableHighlightingSuspendedThread;
        this.lvHighlightingOther.Items[1].Checked = My.MySettingsProperty.Settings.EnableHighlightingRelocatedModule;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPrioritySystemProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingSystemProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityServiceProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingServiceProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityOwnedProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingOwnedProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityJobProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingJobProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityElevatedProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingElevated;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityCriticalProcess - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingCriticalProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityBeingDebugged - 1].Checked = My.MySettingsProperty.Settings.EnableHighlightingBeingDebugged;

        // If not elevated under Vista or above, we cannot change 'replace taskmgr' state
        // without elevation -> set cmdChangeTaskmgr as visible
        if (cEnvironment.SupportsUac && Program.IsElevated == false)
        {
            this.chkReplaceTaskmgr.Enabled = false;
            cEnvironment.AddShieldToButton(this.cmdChangeTaskmgr);
            Misc.SetToolTip(this.cmdChangeTaskmgr, "This action requires elevation, and will automatically save settings");
            this.cmdChangeTaskmgr.Visible = true;
        }
    }

    // Set colors of "Highlighting items"
    private void setColorOfHighlightingItems()
    {
        // lvProcess
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityBeingDebugged - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorBeingDebugged;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityCriticalProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorCriticalProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityElevatedProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorElevatedProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityJobProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorJobProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityOwnedProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorOwnedProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPriorityServiceProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorServiceProcess;
        this.lvHighlightingProcess.Items[My.MySettingsProperty.Settings.HighlightingPrioritySystemProcess - 1].BackColor = My.MySettingsProperty.Settings.HighlightingColorSystemProcess;
        // lvThread
        this.lvHighlightingOther.Items[0].BackColor = My.MySettingsProperty.Settings.HighlightingColorSuspendedThread;
        this.lvHighlightingOther.Items[1].BackColor = My.MySettingsProperty.Settings.HighlightingColorRelocatedModule;
    }

    private void cmdDefaut_Click(System.Object sender, System.EventArgs e)
    {
        // Defaut settings
        this.chkStartTray.Checked = false;
        this.chkStart.Checked = false;
        this.chkReplaceTaskmgr.Checked = false;
        this.txtProcessIntervall.Value = 1000;
        this.txtServiceIntervall.Value = 2500;
        this.txtJobInterval.Value = 2000;
        this.chkTopMost.Checked = false;
        this.chkUserGroup.Checked = true;
        this.pctNewitems.BackColor = Color.FromArgb(-8323328);
        this.pctDeletedItems.BackColor = Color.FromArgb(-49104);
        _newcolor = -8323328;
        _deletedcolor = -49104;
        this.chkTrayIcon.Checked = true;
        this.chkHideMinimized.Checked = false;
        this.cbPriority.SelectedIndex = 3;
        this.txtTaskInterval.Value = 1000;
        this.txtNetworkInterval.Value = 1000;
        this.txtTrayInterval.Value = 1000;
        this.txtSysInfoInterval.Value = 1000;
        this.chkRibbon.Checked = true;
        this.txtSearchEngine.Text = "http://www.google.com/search?hl=en&q=ITEM";
        this.chkWarn.Checked = true;
        this.chkHideClosed.Checked = false;
        this.chkUnlimitedBuf.Checked = false;
        this.chkAutoOnline.Checked = false;
        this.bufferSize.Value = 100;
        this.chkStatusBar.Checked = true;
        this.chkFixedTab.Checked = false;
        this.chkUpdateAlpha.Checked = false;
        this.chkUpdateBeta.Checked = false;
        this.chkUpdateAuto.Checked = false;
        this.txtUpdateServer.Text = "http://yaprocmon.sourceforge.net/update.xml";
        this.valCoefRemote.Value = 250;
        this.chkRemember.Checked = true;
        if (this.chkClassicMsgbox.Enabled)
            this.chkClassicMsgbox.Checked = true;

        // Now empty highlightings listviews, re-add items in default order and check them all
        this.lvHighlightingProcess.Items.Clear();
        this.lvHighlightingProcess.Items.Add("Process being debugged").BackColor = Color.FromArgb(255, 192, 255);
        this.lvHighlightingProcess.Items.Add("Critical process").BackColor = Color.FromArgb(255, 128, 0);
        this.lvHighlightingProcess.Items.Add("Elevated process").BackColor = Color.FromArgb(255, 192, 128);
        this.lvHighlightingProcess.Items.Add("Process in job").BackColor = Color.FromArgb(192, 255, 192);
        this.lvHighlightingProcess.Items.Add("Service process").BackColor = Color.FromArgb(192, 255, 255);
        this.lvHighlightingProcess.Items.Add("Owned process").BackColor = Color.FromArgb(255, 255, 192);
        this.lvHighlightingProcess.Items.Add("System process").BackColor = Color.FromArgb(192, 192, 255);
        this.lvHighlightingOther.Items.Clear();
        this.lvHighlightingOther.Items.Add("Suspended thread").BackColor = Color.FromArgb(255, 255, 192);
        this.lvHighlightingOther.Items.Add("Relocated module").BackColor = Color.FromArgb(192, 255, 192);
        foreach (ListViewItem it in this.lvHighlightingProcess.Items)
            it.Checked = true;
        foreach (ListViewItem it in this.lvHighlightingOther.Items)
            it.Checked = true;

        // Re-set column properties
        Pref.LoadListViewColumns(Program._frmMain.lvProcess, "COLmain_process");
        Pref.LoadListViewColumns(Program._frmMain.lvTask, "COLmain_task");
        Pref.LoadListViewColumns(Program._frmMain.lvServices, "COLmain_service");
        Pref.LoadListViewColumns(Program._frmMain.lvNetwork, "COLmain_network");

        // Set colors of "Highlighting items"
        setColorOfHighlightingItems();
    }

    private void pctNewitems_Click(System.Object sender, System.EventArgs e)
    {
        colDial.Color = this.pctNewitems.BackColor;
        colDial.ShowDialog();
        this.pctNewitems.BackColor = colDial.Color;
        _newcolor = colDial.Color.ToArgb();
    }

    private void pctDeletedItems_Click(System.Object sender, System.EventArgs e)
    {
        colDial.Color = this.pctDeletedItems.BackColor;
        colDial.ShowDialog();
        this.pctDeletedItems.BackColor = colDial.Color;
        _deletedcolor = colDial.Color.ToArgb();
    }

    private void chkTrayIcon_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.chkHideMinimized.Enabled = chkTrayIcon.Checked;
        if (chkTrayIcon.Checked == false)
            this.chkHideMinimized.Checked = false;
    }

    private void chkStartTray_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (this.chkStartTray.Checked)
        {
            this.chkTrayIcon.Enabled = false;
            this.chkTrayIcon.Checked = true;
        }
        else
            this.chkTrayIcon.Enabled = true;
    }

    private void cmdResetAll_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.ShowMsg("Reset settings", null, "Are you sure ?", MessageBoxButtons.YesNo, TaskDialogIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        {
            My.MySettingsProperty.Settings.Reset();
            cmdDefaut_Click(null, null);
            My.MySettingsProperty.Settings.Save();
        }
    }

    private void cmdMoveUpProcess_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvHighlightingProcess.SelectedItems == null || this.lvHighlightingProcess.SelectedItems.Count != 1)
            return;
        if (this.lvHighlightingProcess.SelectedItems[0].Index == 0)
            return;

        this.lvHighlightingProcess.BeginUpdate();
        Misc.MoveListViewItem(this.lvHighlightingProcess, true);
        this.lvHighlightingProcess.EndUpdate();
        this.lvHighlightingProcess.Update();
    }

    private void cmdMoveDownProcess_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvHighlightingProcess.SelectedItems == null || this.lvHighlightingProcess.SelectedItems.Count != 1)
            return;
        if (this.lvHighlightingProcess.SelectedItems[0].Index == this.lvHighlightingProcess.Items.Count - 1)
            return;

        this.lvHighlightingProcess.BeginUpdate();
        Misc.MoveListViewItem(this.lvHighlightingProcess, false);
        this.lvHighlightingProcess.EndUpdate();
        this.lvHighlightingProcess.Update();
    }

    private void lvHighlightingProcess_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lvHighlightingProcess.SelectedItems != null && this.lvHighlightingProcess.SelectedItems.Count == 1)
        {
            colDial.Color = this.lvHighlightingProcess.SelectedItems[0].BackColor;
            colDial.ShowDialog();
            this.lvHighlightingProcess.SelectedItems[0].BackColor = colDial.Color;
        }
    }

    private void lvHighlightingThread_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lvHighlightingOther.SelectedItems != null && this.lvHighlightingOther.SelectedItems.Count == 1)
        {
            colDial.Color = this.lvHighlightingOther.SelectedItems[0].BackColor;
            colDial.ShowDialog();
            this.lvHighlightingOther.SelectedItems[0].BackColor = colDial.Color;
        }
    }

    private void cmdChangeTaskmgr_Click(System.Object sender, System.EventArgs e)
    {
        // Here we start YAPM elevated in order to change replace taskmgr or not
        string sCommandLine = Program.PARAM_CHANGE_TASKMGR + System.Convert.ToInt32(!(this.chkReplaceTaskmgr.Checked)).ToString();
        StartYapmElevated(sCommandLine);
        Program.Preferences.Save();
    }

    // Start YAPM elevated with a specific command line
    private bool StartYapmElevated(string cmdLine)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        {
            var withBlock = startInfo;
            withBlock.UseShellExecute = true;
            withBlock.WorkingDirectory = Environment.CurrentDirectory;
            withBlock.FileName = Application.ExecutablePath;
            withBlock.Verb = "runas";
            withBlock.Arguments = cmdLine;
            withBlock.WindowStyle = ProcessWindowStyle.Normal;
        }

        try
        {
            Process cP = Process.Start(startInfo);
            if (cP != null)
            {

                // Wait than the process ended
                Native.Api.NativeFunctions.WaitForSingleObject(cP.Handle, Native.Api.NativeConstants.WAIT_INFINITE);

                // Here we know that the process has ended, we retrieve the ExitCode
                Program.RequestReplaceTaskMgrResult exCode;
                exCode = (Program.RequestReplaceTaskMgrResult)cP.ExitCode;
                if (exCode == Program.RequestReplaceTaskMgrResult.NotReplaceSuccess)
                    this.chkReplaceTaskmgr.Checked = false;
                else if (exCode == Program.RequestReplaceTaskMgrResult.ReplaceSuccess)
                    this.chkReplaceTaskmgr.Checked = true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private void chkFixedTab_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.cbShownTab.Enabled = this.chkFixedTab.Checked;
    }

    private void cmdUpdateCheckNow_Click(System.Object sender, System.EventArgs e)
    {
        // Check for updates manually
        // No silent mode, so it will cause a messagebox to be displayed
        My.MySettingsProperty.Settings.UpdateAlpha = this.chkUpdateAlpha.Checked;
        My.MySettingsProperty.Settings.UpdateBeta = this.chkUpdateBeta.Checked;
        Program.Updater.CheckUpdates(false);
    }
}
