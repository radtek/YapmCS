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
using Program;
using Common.Misc;

public partial class frmMain
{

    // ========================================
    // Private attributes
    // ========================================
    private cRegMonitor _creg;

    private cRegMonitor creg
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _creg;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_creg != null)
            {
                _creg.KeyAdded -= creg_KeyAdded;
                _creg.KeyDeleted -= creg_KeyDeleted;
            }

            _creg = value;
            if (_creg != null)
            {
                _creg.KeyAdded += creg_KeyAdded;
                _creg.KeyDeleted += creg_KeyDeleted;
            }
        }
    }

    private bool _ribbonStyle = true;
    private bool _local = true;
    private bool _notWMI = true;
    private bool _notSnapshotMode = true;
    private bool _callExitWhenExitYAPM = true;
    private int[] handlesToRefresh;
    private int[] threadsToRefresh;
    private int[] modulesToRefresh;
    private int[] windowsToRefresh;
    private cFile cSelFile;


    // ========================================
    // Public & properties
    // ========================================
    public bool CallExitWhenExitYAPM
    {
        get
        {
            return _callExitWhenExitYAPM;
        }
        set
        {
            _callExitWhenExitYAPM = value;
        }
    }

    public cShutdownConnection _shutdownConnection = new cShutdownConnection(this, ref Program.Connection);


    // ========================================
    // Constants
    // ========================================
    private const int SIZE_FOR_STRING = 4;


    // ========================================
    // Form functions
    // ========================================

    // Refresh File informations
    public void refreshFileInfos(string file)
    {
        string s = "";

        cSelFile = new cFile(file, true);

        if (System.IO.File.Exists(file))
        {

            // Set dates to datepickers
            this.DTcreation.Value = cSelFile.CreationTime;
            this.DTlastAccess.Value = cSelFile.LastAccessTime;
            this.DTlastModification.Value = cSelFile.LastWriteTime;

            // Set attributes
            System.IO.FileAttributes att = cSelFile.Attributes();
            this.chkFileArchive.Checked = ((att & System.IO.FileAttributes.Archive) == System.IO.FileAttributes.Archive);
            this.chkFileCompressed.Checked = ((att & System.IO.FileAttributes.Compressed) == System.IO.FileAttributes.Compressed);
            this.chkFileHidden.Checked = ((att & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden);
            this.chkFileReadOnly.Checked = ((att & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly);
            this.chkFileSystem.Checked = ((att & System.IO.FileAttributes.System) == System.IO.FileAttributes.System);
            this.chkFileNormal.Checked = ((att & System.IO.FileAttributes.Normal) == System.IO.FileAttributes.Normal);
            this.chkFileContentNotIndexed.Checked = ((att & System.IO.FileAttributes.NotContentIndexed) == System.IO.FileAttributes.NotContentIndexed);
            this.chkFileEncrypted.Checked = ((att & System.IO.FileAttributes.Encrypted) == System.IO.FileAttributes.Encrypted);

            // Clean string list
            this.lvFileString.Items.Clear();
            this.lvFileString.Items.Add("Click on 'Others->Show file strings' to retrieve file strings");

            s += @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}{\f1\fswiss\fcharset0 Arial;}}";
            s += @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   ";
            s += @"\b File basic properties\b0\par";
            s += @"\tab File name :\tab\tab " + cSelFile.Name + @"\par";
            s += @"\tab Parent directory :\tab " + cSelFile.ParentDirectory + @"\par";
            s += @"\tab Extension :\tab\tab " + cSelFile.FileExtension + @"\par";
            s += @"\tab Creation date :\tab\tab " + cSelFile.DateCreated + @"\par";
            s += @"\tab Last access date :\tab " + cSelFile.DateLastAccessed + @"\par";
            s += @"\tab Last modification date :\tab " + cSelFile.DateLastModified + @"\par";
            s += @"\tab Size :\tab\tab\tab " + cSelFile.FileSize + " Bytes -- " + Math.Round(cSelFile.FileSize / (double)1024, 3) + " KB" + " -- " + Math.Round(cSelFile.FileSize / (double)1024 / 1024, 3) + @"MB\par";
            s += @"\tab Compressed size :\tab " + cSelFile.CompressedFileSize + " Bytes -- " + Math.Round(cSelFile.CompressedFileSize / (double)1024, 3) + " KB" + " -- " + Math.Round(cSelFile.CompressedFileSize / (double)1024 / 1024, 3) + @"MB\par\par";
            s += @"\b File advances properties\b0\par";
            s += @"\tab File type :\tab\tab " + cSelFile.FileType + @"\par";
            s += @"\tab Associated program :\tab " + cSelFile.FileAssociatedProgram + @"\par";
            s += @"\tab Short name :\tab\tab " + cSelFile.ShortName + @"\par";
            s += @"\tab Short path :\tab\tab " + cSelFile.ShortPath + @"\par";
            s += @"\tab Directory depth :\tab\tab " + cSelFile.DirectoryDepth + @"\par";
            s += @"\tab File available for read :\tab " + cSelFile.FileAvailableForWrite + @"\par";
            s += @"\tab File available for write :\tab " + cSelFile.FileAvailableForWrite + @"\par\par";
            s += @"\b Attributes\b0\par";
            s += @"\tab Archive :\tab\tab " + cSelFile.IsArchive + @"\par";
            s += @"\tab Compressed :\tab\tab " + cSelFile.IsCompressed + @"\par";
            s += @"\tab Device :\tab\tab\tab " + cSelFile.IsDevice + @"\par";
            s += @"\tab Directory :\tab\tab " + cSelFile.IsDirectory + @"\par";
            s += @"\tab Encrypted :\tab\tab " + cSelFile.IsEncrypted + @"\par";
            s += @"\tab Hidden :\tab\tab\tab " + cSelFile.IsHidden + @"\par";
            s += @"\tab Normal :\tab\tab\tab " + cSelFile.IsNormal + @"\par";
            s += @"\tab Not content indexed :\tab " + cSelFile.IsNotContentIndexed + @"\par";
            s += @"\tab Offline :\tab\tab\tab " + cSelFile.IsOffline + @"\par";
            s += @"\tab Read only :\tab\tab " + cSelFile.IsReadOnly + @"\par";
            s += @"\tab Reparse file :\tab\tab " + cSelFile.IsReparsePoint + @"\par";
            s += @"\tab Fragmented :\tab\tab " + cSelFile.IsSparseFile + @"\par";
            s += @"\tab System :\tab\tab " + cSelFile.IsSystem + @"\par";
            s += @"\tab Temporary :\tab\tab " + cSelFile.IsTemporary + @"\par\par";
            s += @"\b File version infos\b0\par";

            if (cSelFile.FileVersion != null)
            {
                if (cSelFile.FileVersion.Comments != null && cSelFile.FileVersion.Comments.Length > 0)
                    s += @"\tab Comments :\tab\tab " + cSelFile.FileVersion.Comments + @"\par";
                if (cSelFile.FileVersion.CompanyName != null && cSelFile.FileVersion.CompanyName.Length > 0)
                    s += @"\tab CompanyName :\tab\tab " + cSelFile.FileVersion.CompanyName + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.FileBuildPart).Length > 0)
                    s += @"\tab FileBuildPart :\tab\tab " + System.Convert.ToString(cSelFile.FileVersion.FileBuildPart) + @"\par";
                if (cSelFile.FileVersion.FileDescription != null && cSelFile.FileVersion.FileDescription.Length > 0)
                    s += @"\tab FileDescription :\tab\tab " + cSelFile.FileVersion.FileDescription + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.FileMajorPart).Length > 0)
                    s += @"\tab FileMajorPart :\tab\tab " + System.Convert.ToString(cSelFile.FileVersion.FileMajorPart) + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.FileMinorPart).Length > 0)
                    s += @"\tab FileMinorPart :\tab\tab " + cSelFile.FileVersion.FileMinorPart + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.FilePrivatePart).Length > 0)
                    s += @"\tab FilePrivatePart :\tab\tab " + cSelFile.FileVersion.FilePrivatePart + @"\par";
                if (cSelFile.FileVersion.FileVersion != null && cSelFile.FileVersion.FileVersion.Length > 0)
                    s += @"\tab FileVersion :\tab\tab " + cSelFile.FileVersion.FileVersion + @"\par";
                if (cSelFile.FileVersion.InternalName != null && cSelFile.FileVersion.InternalName.Length > 0)
                    s += @"\tab InternalName :\tab\tab " + cSelFile.FileVersion.InternalName + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.IsDebug).Length > 0)
                    s += @"\tab IsDebug :\tab\tab " + cSelFile.FileVersion.IsDebug + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.IsPatched).Length > 0)
                    s += @"\tab IsPatched :\tab\tab " + cSelFile.FileVersion.IsPatched + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.IsPreRelease).Length > 0)
                    s += @"\tab IsPreRelease :\tab\tab " + cSelFile.FileVersion.IsPreRelease + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.IsPrivateBuild).Length > 0)
                    s += @"\tab IsPrivateBuild :\tab\tab " + cSelFile.FileVersion.IsPrivateBuild + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.IsSpecialBuild).Length > 0)
                    s += @"\tab IsSpecialBuild :\tab\tab " + cSelFile.FileVersion.IsSpecialBuild + @"\par";
                if (cSelFile.FileVersion.Language != null && cSelFile.FileVersion.Language.Length > 0)
                    s += @"\tab Language :\tab\tab " + cSelFile.FileVersion.Language + @"\par";
                if (cSelFile.FileVersion.LegalCopyright != null && cSelFile.FileVersion.LegalCopyright.Length > 0)
                    s += @"\tab LegalCopyright :\tab\tab " + cSelFile.FileVersion.LegalCopyright + @"\par";
                if (cSelFile.FileVersion.LegalTrademarks != null && cSelFile.FileVersion.LegalTrademarks.Length > 0)
                    s += @"\tab LegalTrademarks :\tab " + cSelFile.FileVersion.LegalTrademarks + @"\par";
                if (cSelFile.FileVersion.OriginalFilename != null && cSelFile.FileVersion.OriginalFilename.Length > 0)
                    s += @"\tab OriginalFilename :\tab\tab " + cSelFile.FileVersion.OriginalFilename + @"\par";
                if (cSelFile.FileVersion.PrivateBuild != null && cSelFile.FileVersion.PrivateBuild.Length > 0)
                    s += @"\tab PrivateBuild :\tab\tab " + cSelFile.FileVersion.PrivateBuild + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.ProductBuildPart).Length > 0)
                    s += @"\tab ProductBuildPart :\tab " + cSelFile.FileVersion.ProductBuildPart + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.ProductMajorPart).Length > 0)
                    s += @"\tab ProductMajorPart :\tab " + cSelFile.FileVersion.ProductMajorPart + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.ProductMinorPart).Length > 0)
                    s += @"\tab Comments :\tab\tab " + cSelFile.FileVersion.ProductMinorPart + @"\par";
                if (cSelFile.FileVersion.ProductName != null && cSelFile.FileVersion.ProductName.Length > 0)
                    s += @"\tab ProductName :\tab\tab " + cSelFile.FileVersion.ProductName + @"\par";
                if (System.Convert.ToString(cSelFile.FileVersion.ProductPrivatePart).Length > 0)
                    s += @"\tab ProductPrivatePart :\tab " + cSelFile.FileVersion.ProductPrivatePart + @"\par";
                if (cSelFile.FileVersion.ProductVersion != null && cSelFile.FileVersion.ProductVersion.Length > 0)
                    s += @"\tab ProductVersion :\tab\tab " + cSelFile.FileVersion.ProductVersion + @"\par";
                if (cSelFile.FileVersion.SpecialBuild != null && cSelFile.FileVersion.SpecialBuild.Length > 0)
                    s += @"\tab SpecialBuild :\tab\tab " + cSelFile.FileVersion.SpecialBuild + @"\par";
            }

            // Icons
            try
            {
                pctFileBig.Image = Misc.GetIcon(file, false).ToBitmap();
                pctFileSmall.Image = Misc.GetIcon(file, true).ToBitmap();
            }
            catch (Exception ex)
            {
                pctFileSmall.Image = My.Resources.Resources.exe16;
                pctFileBig.Image = My.Resources.Resources.exe32;
            }


            s += @"\f1\fs20\par";
            s += "}";
        }
        else
        {
            s += @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}{\f1\fswiss\fcharset0 Arial;}}";
            s += @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b " + @"File does not exist !\b0\par";
            s += @"\f1\fs20\par";
            s += "}";
        }


        rtb3.Rtf = s;
    }

    // Refresh service list
    public void refreshServiceList()
    {

        // Update list
        this.lvServices.ShowAll = true;
        this.lvServices.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            if (this.Ribbon.ActiveTab.Text == "Services")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvServices.Items.Count) + " services running";
        }
    }

    // Refresh job list
    public void refreshJobList()
    {

        // Update list
        this.lvJob.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            if (this.Ribbon.ActiveTab.Text == "Jobs")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvJob.Items.Count) + " jobs running";
        }
    }

    // Refresh process list in listview
    public void refreshProcessList()
    {

        // Update list
        this.lvProcess.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            string ss = this.Ribbon.ActiveTab.Text;
            if (ss == "Processes" | ss == "Monitor" | ss == "Misc" | ss == "Help" | ss == "File")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
        }
    }

    private void timerProcess_Tick(System.Object sender, System.EventArgs e)
    {
        refreshProcessList();
    }

    private void frmMain_Activated(object sender, System.EventArgs e)
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
        Static bFirst As Boolean = True

 */
        if (bFirst)
        {
            bFirst = false;
            Native.Functions.Misc.SetTheme(this.lvProcess.Handle);
            Native.Functions.Misc.SetTheme(this.lvMonitorReport.Handle);
            Native.Functions.Misc.SetTheme(this.lvNetwork.Handle);
            Native.Functions.Misc.SetTheme(this.lvTask.Handle);
            Native.Functions.Misc.SetTheme(this.lvSearchResults.Handle);
            Native.Functions.Misc.SetTheme(this.lvServices.Handle);
            Native.Functions.Misc.SetTheme(this.tv.Handle);
            Native.Functions.Misc.SetTheme(this.tv2.Handle);
            Native.Functions.Misc.SetTheme(this.tvMonitor.Handle);
            Native.Functions.Misc.SetTheme(this.lvFileString.Handle);
            Native.Functions.Misc.SetTheme(this.lvJob.Handle);
        }
        frmMain_Resize(null, null);
    }

    private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        if (My.MySettingsProperty.Settings.HideWhenClosed && Program.MustCloseWithCloseButton == false)
        {
            this.Hide();
            e.Cancel = true;
            return;
        }

        if (this.CallExitWhenExitYAPM)
        {

            // This avoid to call ExitYAPM recursively when exiting
            this.CallExitWhenExitYAPM = false;

            // Save position & size
            Pref.SaveFormPositionAndSize(this, "PSfrmMain");

            // Exit
            Program.ExitYAPM();
        }
    }

    private void frmMain_Load(System.Object sender, System.EventArgs e)
    {
        if (Program.Parameters.ModeHidden)
        {
            this.Left = Pref.LEFT_POSITION_HIDDEN;
            this.ShowInTaskbar = false;
        }
        if (My.MySettingsProperty.Settings.StartHidden)
        {
            // If Ribbon is displayed, there is a problem : Form is automatically shown...
            // So we have to remoe it from taskbar and move it to the left to hide it
            // If Ribbon is not displayed, we can't hide from taskbar else icons won't
            // be displayed in MainMenu...
            if (My.MySettingsProperty.Settings.UseRibbonStyle)
            {
                this.Left = Pref.LEFT_POSITION_HIDDEN;
                this.ShowInTaskbar = false;
            }
            this.Hide();
        }

        // For now, SBA is removed from menu...
        this.Ribbon.OrbDropDown.MenuItems.Remove(this.orbMenuSBA);
        // For now, scripting is removed from menu...
        this.Ribbon.QuickAcessToolbar.Items.Remove(this.butScripting);
        this.MenuItemSYSTEMFILE.MenuItems.Remove(this.MenuItemSystemScripting);
        // For now, remove Tracert/WhoIs menus
        this.MenuItemNetworkTools.MenuItems.Remove(this.MenuItemNetworkRoute);
        this.MenuItemNetworkTools.MenuItems.Remove(this.MenuItemNetworkWhoIs);

        // Disable 'start as admin' if we are not on Vista or above
        if (cEnvironment.SupportsUac == false || cEnvironment.GetElevationType != Native.Api.Enums.ElevationType.Limited)
        {
            this.Ribbon.OrbDropDown.MenuItems.Remove(this.orbStartElevated);
            this.MenuItemSYSTEMFILE.MenuItems.Remove(this.MenuItemRunAsAdmin);
        }
        else
            // If we display standard menus, we add the icon
            if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
            this.VistaMenu.SetImage(this.MenuItemRunAsAdmin, cEnvironment.GetUacShieldImage());

        this.timerProcess.Enabled = false;
        int t = Native.Api.Win32.GetElapsedTime();

        this.containerSystemMenu.Panel1Collapsed = true;
        this.Tray.Visible = true;
        this.Tray.ContextMenu = this.mnuMain;
        this.rtb3.AllowDrop = true;

        // Set tray icon counters
        Program.TrayIcon.SetCounter(1, Color.Red, Color.FromArgb(120, 0, 0));
        Program.TrayIcon.SetCounter(2, Color.LightGreen, Color.FromArgb(0, 120, 0));

        Program.PROCESSOR_COUNT = Program.SystemInfo.ProcessorCount;

        creg = new cRegMonitor(Native.Api.NativeEnums.KeyType.LocalMachine, @"SYSTEM\CurrentControlSet\Services", Native.Api.NativeEnums.KeyMonitoringType.ChangeName);

        {
            var withBlock = this.graphMonitor;
            withBlock.ColorMemory1 = Color.Yellow;
            withBlock.ColorMemory2 = Color.Red;
            withBlock.ColorMemory3 = Color.Orange;
        }

        // Create tooltips
        Misc.SetToolTip(this.lblResCount, "Number of results. Click on the number to view results");
        Misc.SetToolTip(this.lblResCount2, "Number of results. Click on the number to view results");
        Misc.SetToolTip(this.lblTaskCountResult, "Number of results. Click on the number to view results");
        Misc.SetToolTip(this.txtSearchTask, "Enter text here to search a task");
        Misc.SetToolTip(this.txtSearch, "Enter text here to search a process");
        Misc.SetToolTip(this.txtSearchResults, "Enter text here to search into the results");
        Misc.SetToolTip(this.lblResultsCount, "Number of results. Click on the number to view results");
        Misc.SetToolTip(this.tvMonitor, "Monitoring items");
        Misc.SetToolTip(this.chkMonitorLeftAuto, "Setting to display graph. See help for details");
        Misc.SetToolTip(this.chkMonitorRightAuto, "Setting to display graph. See help for details");
        Misc.SetToolTip(this.dtMonitorL, "Setting to display graph. See help for details");
        Misc.SetToolTip(this.dtMonitorR, "Setting to display graph. See help for details");
        Misc.SetToolTip(this.txtMonitorNumber, "Setting to display graph. See help for details");
        Misc.SetToolTip(this.cmdFileClipboard, "Copy file informations to clipboard. Use left click to copy as text, right click to copy as rtf (preserve text style)");
        Misc.SetToolTip(this.DTcreation, "Date of creation");
        Misc.SetToolTip(this.DTlastAccess, "Date of last access");
        Misc.SetToolTip(this.DTlastModification, "Date of last modification");
        Misc.SetToolTip(this.cmdSetFileDates, "Set these dates");
        Misc.SetToolTip(this.chkFileArchive, "File is archive");
        Misc.SetToolTip(this.chkFileCompressed, "File is compressed");
        Misc.SetToolTip(this.chkFileContentNotIndexed, "File is indexed");
        Misc.SetToolTip(this.chkFileEncrypted, "File is encrypted");
        Misc.SetToolTip(this.chkFileHidden, "File is hidden");
        Misc.SetToolTip(this.chkFileNormal, "File is normal");
        Misc.SetToolTip(this.chkFileReadOnly, "File is read only");
        Misc.SetToolTip(this.chkFileSystem, "File is system");
        Misc.SetToolTip(this.txtServiceSearch, "Enter text here to search a service");
        Misc.SetToolTip(this.cmdCopyServiceToCp, "Copy services informations to clipboard. Use left click to copy as text, right click to copy as rtf (preserve text style)");
        Misc.SetToolTip(this.lblServicePath, "Path of the main executable of the service");
        Misc.SetToolTip(this.tv, "Selected service depends on these services");
        Misc.SetToolTip(this.tv2, "This services depend on selected service");
        Misc.SetToolTip(this.chkSearchProcess, "Include processes in search");
        Misc.SetToolTip(this.chkSearchServices, "Include services in search");
        Misc.SetToolTip(this.chkSearchWindows, "Include windows in search");
        Misc.SetToolTip(this.chkSearchCase, "Search is case sensitive or not");
        Misc.SetToolTip(this.chkSearchEnvVar, "Include environement variables in search");
        Misc.SetToolTip(this.chkSearchHandles, "Include handles in search");
        Misc.SetToolTip(this.chkSearchModules, "Include modules in search");
        Misc.SetToolTip(this.lvFileString, "List of strings in file. Middle click to copy to clipboard.");

        // Init columns
        Pref.LoadListViewColumns(this.lvProcess, "COLmain_process");
        Pref.LoadListViewColumns(this.lvTask, "COLmain_task");
        Pref.LoadListViewColumns(this.lvServices, "COLmain_service");
        Pref.LoadListViewColumns(this.lvNetwork, "COLmain_network");

        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmMain");

        // Connect to the local machine
        Program.Connection.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        ConnectToMachine();

        this.timerMonitoring.Enabled = true;
        this.timerProcess.Enabled = true;
        this.timerTask.Enabled = true;
        this.timerNetwork.Enabled = true;
        this.timerStateBasedActions.Enabled = true;
        this.timerTrayIcon.Enabled = true;
        this.timerServices.Enabled = true;
        this.timerStatus.Enabled = true;
        this.timerJobs.Enabled = true;

        if (this.lvProcess.Items.Count > 1)
        {
            this.lvProcess.Focus();
            this.lvProcess.Items[this.lvProcess.Items.Count - 1].Selected = true;
            this.lvProcess.Items[this.lvProcess.Items.Count - 1].EnsureVisible();
        }

        t = Native.Api.Win32.GetElapsedTime() - t;

        Trace.WriteLine("Loaded in " + System.Convert.ToString(t) + " ms.");
        refreshTaskList();


        // Add some submenus (Copy to clipboard)
        foreach (string ss in jobInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyJob.MenuItems.Add(ss, MenuItemCopyJob_Click);
        foreach (string ss in networkInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyNetwork.MenuItems.Add(ss, MenuItemCopyNetwork_Click);
        foreach (string ss in searchInfos.GetAvailableProperties(true, true))
            this.MenuItemCopySearch.MenuItems.Add(ss, MenuItemCopySearch_Click);
        foreach (string ss in serviceInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyService.MenuItems.Add(ss, MenuItemCopyService_Click);
        foreach (string ss in taskInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyTask.MenuItems.Add(ss, MenuItemCopyTask_Click);
        foreach (string ss in processInfos.GetAvailableProperties(true, true))
            this.MenuItemCopyProcess.MenuItems.Add(ss, MenuItemCopyProcess_Click);
    }

    private void frmMain_Resize(object sender, System.EventArgs e)
    {
        try
        {
            // If we do not use Ribbon mode, we hide Ribbon. Else, we add tabs
            if (My.MySettingsProperty.Settings.UseRibbonStyle)
            {
                // The only way to hide tabs is to change region of tabcontrol
                // But we also have to set Dock to None to avoid displaying a blank area
                // We change manually height/width, that's why this piece of code is located
                // in Resize()
                {
                    var withBlock = _tab;
                    _tab.Dock = DockStyle.None;
                    _tab.Top = -24;
                    _tab.Left = -2;
                    _tab.Width = this.Width - 12;
                    _tab.Height = this.Height - this.Ribbon.Height - this.StatusBar.Height - 15;
                    _tab.Region = new Region(new RectangleF(_tab.Left, _tab.SelectedTab.Top, _tab.SelectedTab.Width + 5, _tab.SelectedTab.Height));
                    _tab.Refresh();
                }
            }
            else
                this._main.Panel1Collapsed = true;

            if (My.MySettingsProperty.Settings.HideWhenMinimized && this.WindowState == FormWindowState.Minimized)
                this.Hide();

            foreach (TabPage t in _tab.TabPages)
                t.Hide();

            // Dim i As Integer = CInt((Me.Height - 250) / 2)
            // Dim MepanelInfosHeight As Integer = CInt(IIf(i < 340, i, 340))
            // Dim MepanelInfonWidth As Integer = Me.panelMain.Width

            // File resizement
            this.txtFile.Width = this.Width - 260;

            _tab.SelectedTab.Show();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void timerServices_Tick(System.Object sender, System.EventArgs e)
    {
        refreshServiceList();
    }

    private void Tray_MouseDoubleClick(System.Object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // If ribbon is used, then the main form is to the left of the screen and
        // not shown in taskbar
        if (My.MySettingsProperty.Settings.UseRibbonStyle)
        {
            if (this.Left == Pref.LEFT_POSITION_HIDDEN)
                this.CenterToScreen();
            this.ShowInTaskbar = true;
        }
        this.Visible = true;
        this.WindowState = FormWindowState.Normal;
        this.Show();
    }

    private void frmMain_Shown(object sender, System.EventArgs e)
    {
        // Static first As Boolean = True
        // If first Then
        // first = False
        // If My.Settings.StartHidden Then
        // Me.Hide()
        // Me.WindowState = FormWindowState.Minimized
        // Else
        // Me.Show()
        // Me.WindowState = FormWindowState.Normal
        // End If
        // End If

        // Select tab to activate
        string tabToShow = My.MySettingsProperty.Settings.SelectedTab;
        if (My.MySettingsProperty.Settings.ShowFixedTab)
            tabToShow = My.MySettingsProperty.Settings.FixedTab;
        foreach (RibbonTab tab in this.Ribbon.Tabs)
        {
            if (tab.Text == tabToShow)
            {
                this.Ribbon.ActiveTab = tab;
                break;
            }
        }

        Ribbon_MouseMove(null, null);
        this.frmMain_Resize(null, null);
    }

    private void butKill_Click(object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to kill these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.Kill();
    }

    private void butAbout_Click(object sender, System.EventArgs e)
    {
        frmAboutG frm = new frmAboutG();
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void butProcessRerfresh_Click(object sender, System.EventArgs e)
    {
        this.refreshProcessList();
    }

    private void butServiceRefresh_Click(object sender, System.EventArgs e)
    {
        this.refreshServiceList();
    }

    private void butDonate_Click(object sender, System.EventArgs e)
    {
        Misc.ShowMsg("Donation procedure", "Thanks for making a donation !", "You will be redirected to my sourceforge.net donation page.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        cFile.ShellOpenFile("https://sourceforge.net/donate/index.php?user_id=1590933#donate", this.Handle);
    }

    private void butWebite_Click(object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile("http://yaprocmon.sourceforge.net/", this.Handle);
    }

    private void butProjectPage_Click(object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile("http://sourceforge.net/projects/yaprocmon", this.Handle);
    }

    private void butServiceFileProp_Click(object sender, System.EventArgs e)
    {
        this.MenuItemServFileProp_Click(null, null);
    }

    private void butServiceOpenDir_Click(object sender, System.EventArgs e)
    {
        this.MenuItemServOpenDir_Click(null, null);
    }

    private void butStopProcess_Click(object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to suspend these processes ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SuspendProcess();
    }

    private void butProcessAffinity_Click(object sender, System.EventArgs e)
    {
        this.MenuItemProcAff_Click(null, null);
    }

    private void butResumeProcess_Click(object sender, System.EventArgs e)
    {
        // Resume selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.ResumeProcess();
    }

    private void butIdle_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.Idle);
    }

    private void butHigh_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.High);
    }

    private void butNormal_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.Normal);
    }

    private void butRealTime_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.RealTime);
    }

    private void butBelowNormal_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.BelowNormal);
    }

    private void butAboveNormal_Click(object sender, System.EventArgs e)
    {
        // Set priority to selected processes
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
            it.SetPriority(ProcessPriorityClass.AboveNormal);
    }

    private void butStopService_Click(object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to stop these services ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.StopService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butStartService_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.StartService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butPauseService_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.PauseService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butAutomaticStart_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.AutoStart);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butDisabledStart_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.StartDisabled);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butOnDemandStart_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.DemandStart);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void butResumeService_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.ResumeService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void Ribbon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lvServices.Items.Count == 0)
        {
            if (this.Ribbon.ActiveTab.Text == "Services")
                // First display of service tab
                refreshServiceList();
        }
        else if (this.lvProcess.Items.Count == 0)
        {
            if (this.Ribbon.ActiveTab.Text == "Processes")
                // First display of process tab
                refreshProcessList();
        }
    }

    public void Ribbon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
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
        ' Static currentText As String = vbNullString
        Static bHelpShown As Boolean = False

 */
        // If Not (Ribbon.ActiveTab.Text = currentText) Then
        // currentText = Ribbon.ActiveTab.Text

        switch (Ribbon.ActiveTab.Text)
        {
            case "Jobs":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvJob.Items.Count) + " jobs running";
                    _tab.SelectedTab = this.pageJobs;
                    break;
                }

            case "Services":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvServices.Items.Count) + " services running";
                    _tab.SelectedTab = this.pageServices;
                    break;
                }

            case "Processes":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
                    _tab.SelectedTab = this.pageProcesses;
                    break;
                }

            case "Help":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
                    _tab.SelectedTab = this.pageHelp;
                    break;
                }

            case "File":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
                    _tab.SelectedTab = this.pageFile;
                    break;
                }

            case "Search":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvSearchResults.Items.Count) + " search results";
                    _tab.SelectedTab = this.pageSearch;
                    break;
                }

            case "Monitor":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
                    _tab.SelectedTab = this.pageMonitor;
                    break;
                }

            case "Tasks":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvTask.Items.Count) + " tasks running";
                    _tab.SelectedTab = this.pageTasks;
                    break;
                }

            case "Network":
                {
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvNetwork.Items.Count) + " connections opened";
                    _tab.SelectedTab = this.pageNetwork;
                    break;
                }
        }
    }

    private void butDownload_Click(object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile("http://sourceforge.net/project/showfiles.php?group_id=244697", this.Handle);
    }

    private void frmMain_VisibleChanged(object sender, System.EventArgs e)
    {
    }

    private void butProcessGoogle_Click(object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            Application.DoEvents();
            Misc.SearchInternet(cp.Infos.Name, this.Handle);
        }
    }

    private void butServiceGoogle_Click(object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lvServices.SelectedItems)
        {
            Application.DoEvents();
            Misc.SearchInternet(it.Text, this.Handle);
        }
    }

    private void butServiceFileDetails_Click(object sender, System.EventArgs e)
    {
        if (this.lvServices.SelectedItems.Count > 0)
        {
            string s = this.lvServices.GetSelectedItem().GetInformation("ImagePath");
            if (System.IO.File.Exists(s) == false)
                s = cFile.IntelligentPathRetrieving2(s);
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void butUpdate_Click(object sender, System.EventArgs e)
    {
        // Check for updates manually
        // No silent mode, so it will cause a messagebox to be displayed
        Program.Updater.CheckUpdates(false);
    }

    private void butSearchGo_Click(object sender, System.EventArgs e)
    {
        goSearch(this.txtSearchString.TextBoxText);
    }

    private void txtSearchString_TextBoxTextChanged(System.Object sender, System.EventArgs e)
    {
        bool b = (txtSearchString.TextBoxText != null);
        if (b)
            b = b & txtSearchString.TextBoxText.Length > 0;
        this.butSearchGo.Enabled = b;
    }

    private void butSearchSaveReport_Click(object sender, System.EventArgs e)
    {
        frmSaveReport frm = new frmSaveReport();
        {
            var withBlock = frm;
            withBlock.ReportType = "search";
            Application.DoEvents();
            withBlock.TopMost = Program._frmMain.TopMost;
            withBlock.ShowDialog();
        }
    }

    private void butFileProperties_Click(object sender, System.EventArgs e)
    {
        cFile.ShowFileProperty(this.txtFile.Text, this.Handle);
    }

    private void butFileShowFolderProperties_Click(object sender, System.EventArgs e)
    {
        cFile.ShowFileProperty(System.IO.Directory.GetParent(this.txtFile.Text).FullName, this.Handle);
    }

    private void butFileOpenDir_Click(object sender, System.EventArgs e)
    {
        cFile.OpenDirectory(this.txtFile.Text);
    }

    private void butOpenFile_Click(object sender, System.EventArgs e)
    {
        // Open a file
        openDial.Filter = "All files (*.*)|*.*";
        openDial.Title = "Open a file to retrieve details";
        if (openDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            if (System.IO.File.Exists(openDial.FileName))
                Misc.DisplayDetailsFile(openDial.FileName);
        }
    }

    private void butFileRelease_Click(object sender, System.EventArgs e)
    {
        frmFileRelease frm = new frmFileRelease();
        {
            var withBlock = frm;
            withBlock.file = this.txtFile.Text;
            withBlock.TopMost = Program._frmMain.TopMost;
            withBlock.ShowDialog();
        }
    }

    private void butFileGoogleSearch_Click(object sender, System.EventArgs e)
    {
        Application.DoEvents();
        Misc.SearchInternet(cFile.GetFileName(this.txtFile.Text), this.Handle);
    }

    private void butFileEncrypt_Click(object sender, System.EventArgs e)
    {
        try
        {
            cSelFile.Encrypt();
            Misc.ShowMsg("File encryption", null, "Encryption done.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Encryption failed");
        }
    }

    private void butFileDecrypt_Click(object sender, System.EventArgs e)
    {
        try
        {
            cSelFile.Decrypt();
            Misc.ShowMsg("File decryption", null, "Decryption done.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Decryption failed");
        }
    }

    private void butFileRefresh_Click(object sender, System.EventArgs e)
    {
        Misc.DisplayDetailsFile(this.txtFile.Text);
    }

    private void butMoveFileToTrash_Click(object sender, System.EventArgs e)
    {
        cSelFile.MoveToTrash();
    }

    private void butFileSeeStrings_Click(object sender, System.EventArgs e)
    {
        DisplayFileStrings(this.lvFileString, this.txtFile.Text);
    }

    private System.IO.FileAttributes RemoveAttribute(System.IO.FileAttributes attributesToRemove)
    {
        System.IO.FileAttributes attributes = cSelFile.Attributes();
        return attributes & !(attributesToRemove);
    }
    private System.IO.FileAttributes AddAttribute(System.IO.FileAttributes attributesToAdd)
    {
        System.IO.FileAttributes attributes = cSelFile.Attributes;
        return attributes | attributesToAdd;
    }

    private void butFileOpen_Click(object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(this.txtFile.Text, this.Handle);
    }

    // Display file strings
    public void DisplayFileStrings(ListView lst, string file)
    {
        string s = Constants.vbNullString;
        string sCtemp = Constants.vbNullString;
        int x = 1;
        int bTaille;
        int lLen;

        if (System.IO.File.Exists(file))
        {
            lst.Items.Clear();

            // Retrieve entire file in memory
            // Warn user if file is up to 2MB
            try
            {
                if (FileSystem.FileLen(file) > 2000000)
                {
                    if (Misc.ShowMsg("Show file strings", "File size is greater than 2MB.", "It is not recommended to open a large file, do you want to continue ?", MessageBoxButtons.YesNo, TaskDialogIcon.Information, true) == System.Windows.Forms.DialogResult.No)
                    {
                        lvFileString.Items.Add("Click on 'Others->Show file strings' to retrieve file strings");
                        return;
                    }
                }

                s = System.IO.File.ReadAllText(file);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Could not read file");
            }


            // Desired minimum size for a string
            bTaille = SIZE_FOR_STRING;

            // A char is considered as part of a string if its value is between 32 and 122
            lLen = Strings.Len(s);

            // Lock listbox
            lst.BeginUpdate();

            // Ok, parse file
            while (x <= lLen)
            {
                if (char.IsLetterOrDigit(s.Chars[x - 1]))
                    // Valid char
                    sCtemp += s.Chars[x - 1];
                else
                {
                    // sCtemp = LTrim$(sCtemp)
                    // sCtemp = RTrim$(sCtemp)
                    if (Strings.Len(sCtemp) > bTaille)
                        lst.Items.Add(sCtemp);
                    sCtemp = Constants.vbNullString;
                }

                x += 1;
            }

            // Last item
            if (Strings.Len(sCtemp) > bTaille)
                lst.Items.Add(sCtemp);

            // Unlock listbox
            lst.EndUpdate();
        }
    }

    private void butMonitoringAdd_Click(object sender, System.EventArgs e)
    {
        frmAddProcessMonitor frm = new frmAddProcessMonitor(ref Program.Connection);
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    // Add a monitoring item
    public void AddMonitoringItem(cMonitor it)
    {

        // Check if a node with same category and instance exists
        TreeNode nExistingItem = null;
        TreeNode n;
        foreach (var n in this.tvMonitor.Nodes[0].Nodes)
        {
            if (System.Convert.ToString(Interaction.IIf(Strings.Len(it.InstanceName) > 0, it.InstanceName + " - ", Constants.vbNullString)) + it.CategoryName == n.Text)
            {
                nExistingItem = n;
                break;
            }
        }

        if (nExistingItem == null)
        {
            // New sub item
            TreeNode n1 = new TreeNode();
            {
                var withBlock = n1;
                withBlock.Text = System.Convert.ToString(Interaction.IIf(Strings.Len(it.InstanceName) > 0, it.InstanceName + " - ", Constants.vbNullString)) + it.CategoryName;
                withBlock.ImageIndex = 0;
                withBlock.SelectedImageIndex = 0;
            }

            TreeNode ncpu = new TreeNode();
            {
                var withBlock1 = ncpu;
                withBlock1.Text = it.CounterName;
                withBlock1.ImageKey = "sub";
                withBlock1.SelectedImageKey = "sub";
                withBlock1.Tag = it;
            }
            n1.Nodes.Add(ncpu);

            this.tvMonitor.Nodes[0].Nodes.Add(n1);
        }
        else
        {
            // Use existing sub item
            TreeNode ncpu = new TreeNode();
            {
                var withBlock2 = ncpu;
                withBlock2.Text = it.CounterName;
                withBlock2.ImageKey = "sub";
                withBlock2.SelectedImageKey = "sub";
                withBlock2.Tag = it;
            }

            nExistingItem.Nodes.Add(ncpu);
        }
    }

    private void butMonitorStart_Click(object sender, System.EventArgs e)
    {
        if (tvMonitor.SelectedNode != null)
        {
            if (tvMonitor.SelectedNode.Parent != null)
            {
                if (tvMonitor.SelectedNode.Parent.Parent != null)
                {
                    // Subsub item
                    cMonitor it = (cMonitor)tvMonitor.SelectedNode.Tag;
                    it.StartMonitoring();
                    tvMonitor_AfterSelect(null, null);
                }
                else
                {
                    // Sub item
                    TreeNode n;
                    foreach (var n in tvMonitor.SelectedNode.Nodes)
                    {
                        cMonitor it = (cMonitor)n.Tag;
                        it.StartMonitoring();
                    }
                }
            }
            else
            {
                // All items
                TreeNode n;
                foreach (var n in tvMonitor.SelectedNode.Nodes)
                {
                    TreeNode n2;
                    foreach (var n2 in n.Nodes)
                    {
                        cMonitor it = (cMonitor)n2.Tag;
                        it.StartMonitoring();
                    }
                }
            }
        }
        UpdateMonitoringLog();
    }

    private void butMonitorStop_Click(object sender, System.EventArgs e)
    {
        if (tvMonitor.SelectedNode != null)
        {
            if (tvMonitor.SelectedNode.Parent != null)
            {
                if (tvMonitor.SelectedNode.Parent.Parent != null)
                {
                    // Subsub item
                    cMonitor it = (cMonitor)tvMonitor.SelectedNode.Tag;
                    it.StopMonitoring();
                    tvMonitor_AfterSelect(null, null);
                }
                else
                {
                    // Sub item
                    TreeNode n;
                    foreach (var n in tvMonitor.SelectedNode.Nodes)
                    {
                        cMonitor it = (cMonitor)n.Tag;
                        it.StopMonitoring();
                    }
                }
            }
            else
            {
                // All items
                TreeNode n;
                foreach (var n in tvMonitor.SelectedNode.Nodes)
                {
                    TreeNode n2;
                    foreach (var n2 in n.Nodes)
                    {
                        cMonitor it = (cMonitor)n2.Tag;
                        it.StopMonitoring();
                    }
                }
            }
        }
        UpdateMonitoringLog();
    }

    // Powerful recursive method to unload all cMonitor items in subnodes
    private void RemoveSubNode(ref TreeNode nod, ref TreeNodeCollection n)
    {
        TreeNode subn;
        foreach (var subn in n)
            RemoveSubNode(ref subn, ref subn.Nodes);
        // It's a monitor sub item
        if (nod.ImageKey == "sub")
        {
            cMonitor it = (cMonitor)nod.Tag;
            if (it != null)
                it.Dispose();
            it = null;
        }
    }

    private void butMonitoringRemove_Click(object sender, System.EventArgs e)
    {
        if (tvMonitor.SelectedNode != null)
        {
            RemoveSubNode(ref tvMonitor.SelectedNode, ref tvMonitor.SelectedNode.Nodes);
            TreeNodeCollection nn = tvMonitor.SelectedNode.Nodes;
            int cnn = nn.Count;
            for (int i = cnn - 1; i >= 0; i += -1)
                nn[i].Remove();
            if (tvMonitor.SelectedNode.Parent != null)
                tvMonitor.SelectedNode.Remove();

            // Remove all single items (no sub)
            nn = this.tvMonitor.Nodes[0].Nodes;
            cnn = nn.Count;
            for (int i = cnn - 1; i >= 0; i += -1)
            {
                if (nn[i].Nodes.Count == 0)
                    nn[i].Remove();
            }
        }
        UpdateMonitoringLog();
    }

    // Display stats in graph
    private void ShowMonitorStats(cMonitor it, string key1, string key2, string key3)
    {
        this.timerMonitoring.Interval = it.Interval;

        if (it.Enabled == false)
        {
            Graphics g = this.graphMonitor.CreateGraphics();
            {
                var withBlock = g;
                withBlock.Clear(Color.Black);
                withBlock.DrawString("You have to start monitoring.", this.Font, Brushes.White, 0, 0);
                withBlock.Dispose();
            }
            return;
        }

        // Get values from monitor item
        Graph.ValueItem[] v;
        Collection cCol = new Collection();
        cCol = it.GetMonitorItems();

        // Limit DT pickers
        this.dtMonitorL.MaxDate = DateTime.Now;
        this.dtMonitorL.MinDate = it.MonitorCreationDate;
        this.dtMonitorR.MaxDate = this.dtMonitorL.MaxDate;
        this.dtMonitorR.MinDate = this.dtMonitorL.MinDate;

        if (cCol.Count > 0)
        {
            v = new Graph.ValueItem[cCol.Count + 1];
            cMonitor.MonitorStructure c;
            int i = 0;

            foreach (var c in cCol)
            {
                if (i < v.Length)
                {
                    v[i].y = System.Convert.ToInt64(c.value);
                    v[i].x = c.time;
                    i += 1;
                }
            }

            var oldV = v;
            v = new Graph.ValueItem[cCol.Count - 1 + 1];
            if (oldV != null)
                Array.Copy(oldV, v, Math.Min(cCol.Count - 1 + 1, oldV.Length));

            {
                var withBlock1 = this.graphMonitor;

                // Set max and min (depends and dates chosen)
                if (this.chkMonitorLeftAuto.Checked & this.chkMonitorRightAuto.Checked)
                {
                    // Then no one fixed
                    withBlock1.ViewMin = System.Convert.ToInt32(Math.Max(0, i - System.Convert.ToInt32(Conversion.Val(this.txtMonitorNumber.Text))));
                    withBlock1.ViewMax = i - 1;
                }
                else if (this.chkMonitorRightAuto.Checked)
                {
                    // Then left fixed
                    withBlock1.ViewMin = findViewIntegerFromDate(this.dtMonitorL.Value, v, it);
                    withBlock1.ViewMax = findViewMaxFromMin(withBlock1.ViewMin, v);
                }
                else if (this.chkMonitorLeftAuto.Checked)
                {
                    // Then right fixed
                    withBlock1.ViewMax = findViewIntegerFromDate(this.dtMonitorR.Value, v, it);
                    withBlock1.ViewMin = findViewLast(withBlock1.ViewMax);
                }
                else
                {
                    // Then both fixed
                    withBlock1.ViewMax = findViewIntegerFromDate(this.dtMonitorR.Value, v, it);
                    withBlock1.ViewMin = findViewIntegerFromDate(this.dtMonitorL.Value, v, it);
                }

                withBlock1.SetValues(v);
                withBlock1.dDate = it.MonitorCreationDate;
                withBlock1.EnableGraph = true;
                withBlock1.Refresh();
            }
        }
    }

    private void timerMonitoring_Tick(System.Object sender, System.EventArgs e)
    {
        tvMonitor_AfterSelect(null, null);
    }

    // Return an integer that corresponds to a time in a monitor from a date
    private int findViewIntegerFromDate(DateTime d, Graph.ValueItem[] v, cMonitor monitor)
    {
        Graph.ValueItem it;
        long l = d.Ticks;
        long start = monitor.MonitorCreationDate.Ticks;
        int o = 0;
        foreach (var it in v)
        {
            if ((start + 10000 * it.x) >= l)
                return o;
            o += 1;
        }

        return System.Convert.ToInt32(v.Length - 1);
    }

    // Return an integer that corresponds to min + txtMAX.value iterations
    private int findViewMaxFromMin(int min, Graph.ValueItem[] v)
    {
        return Math.Min(v.Length - 1, min + System.Convert.ToInt32(Conversion.Val(this.txtMonitorNumber.Text)));
    }

    // Return element of array with a distance of txtMAX.value to the end of the array
    private int findViewLast(int max)
    {
        int lMax = System.Convert.ToInt32(Conversion.Val(this.txtMonitorNumber.Text));
        return Math.Max(0, max - lMax);
    }

    private void butDeleteFile_Click(object sender, System.EventArgs e)
    {
        cSelFile.WindowsKill();
    }

    private void butFileMove_Click(object sender, System.EventArgs e)
    {
        {
            var withBlock = this.FolderChooser;
            withBlock.Description = "Select new location";
            withBlock.SelectedPath = cFile.GetParentDir(cSelFile.Path);
            withBlock.ShowNewFolderButton = true;
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = cSelFile.WindowsMove(withBlock.SelectedPath);
                this.refreshFileInfos(cSelFile.Path);
            }
        }
    }

    private void butFileCopy_Click(object sender, System.EventArgs e)
    {
        {
            var withBlock = this.saveDial;
            withBlock.AddExtension = true;
            withBlock.FileName = cSelFile.Name;
            withBlock.Filter = "All (*.*)|*.*";
            withBlock.InitialDirectory = cSelFile.GetParentDir();
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                cSelFile.WindowCopy(withBlock.FileName);
        }
    }

    private void butFileRename_Click(object sender, System.EventArgs e)
    {
        string s = Misc.CInputBox("New name (name+extension) ?", "Select a new file name", cFile.GetFileName(cSelFile.Path));
        if (s == null || s.Equals(string.Empty))
            return;
        this.txtFile.Text = cSelFile.WindowsRename(s);
        this.refreshFileInfos(cSelFile.Path);
    }

    private void butServiceReport_Click(object sender, System.EventArgs e)
    {
        frmSaveReport frm = new frmSaveReport();
        {
            var withBlock = frm;
            withBlock.ReportType = "services";
            Application.DoEvents();
            withBlock.TopMost = Program._frmMain.TopMost;
            withBlock.ShowDialog();
        }
    }

    private void butAlwaysDisplay_Click(object sender, System.EventArgs e)
    {
        changeTopMost();
    }

    private void butPreferences_Click(object sender, System.EventArgs e)
    {
        frmPreferences frm = new frmPreferences();
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void butProcessDisplayDetails_Click(object sender, System.EventArgs e)
    {
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
        {
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void creg_KeyAdded(cRegMonitor.KeyDefinition key)
    {
        // log.AppendLine("Service added : " & key.name)
        if (My.MySettingsProperty.Settings.NotifyNewServices)
        {
            {
                var withBlock = this.Tray;
                withBlock.BalloonTipText = key.name;
                withBlock.BalloonTipIcon = ToolTipIcon.Info;
                withBlock.BalloonTipTitle = "A new service has been created";
                withBlock.ShowBalloonTip(3000);
            }
        }
    }

    private void creg_KeyDeleted(cRegMonitor.KeyDefinition key)
    {
        // log.AppendLine("Service deleted : " & key.name)
        if (My.MySettingsProperty.Settings.NotifyDeletedServices)
        {
            {
                var withBlock = this.Tray;
                withBlock.BalloonTipText = key.name;
                withBlock.BalloonTipIcon = ToolTipIcon.Info;
                withBlock.BalloonTipTitle = "A service has been deleted";
                withBlock.ShowBalloonTip(3000);
            }
        }
    }

    // Refresh  task list in listview
    public void refreshTaskList()
    {

        // Update list
        this.lvTask.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            string ss = this.Ribbon.ActiveTab.Text;
            if (ss == "Tasks")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvTask.Items.Count) + " tasks running";
        }
    }

    private void timerTask_Tick(object sender, System.EventArgs e)
    {
        refreshTaskList();
    }

    private void butTaskRefresh_Click(object sender, System.EventArgs e)
    {
        refreshTaskList();
    }

    private void butTaskShow_Click(object sender, System.EventArgs e)
    {
        foreach (cTask it in this.lvTask.GetSelectedItems())
            it.SetAsForegroundWindow();
    }

    private void butTaskEndTask_Click(object sender, System.EventArgs e)
    {
        // Close task
        if (Misc.WarnDangerousAction("Are you sure you want to terminate these tasks ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cTask it in this.lvTask.GetSelectedItems())
            it.Close();
    }

    private void refreshNetworkList()
    {
        this.lvNetwork.ShowAllPid = true;
        this.lvNetwork.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            string ss = this.Ribbon.ActiveTab.Text;
            if (ss == "Network")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvNetwork.Items.Count) + " connections opened";
        }
    }

    private void butNetworkRefresh_Click(object sender, System.EventArgs e)
    {
        refreshNetworkList();
    }

    private void timerTrayIcon_Tick(System.Object sender, System.EventArgs e)
    {
        // Refresh infos
        Program.SystemInfo.RefreshInfo();

        double _cpuUsage = Program.SystemInfo.CpuUsage;
        double _physMemUsage = Program.SystemInfo.PhysicalMemoryPercentageUsage;
        decimal d = new decimal(decimal.Multiply(Program.SystemInfo.TotalPhysicalMemory, new decimal(_physMemUsage)));

        if (_cpuUsage > 1)
            _cpuUsage = 1;

        string s = "CPU usage : " + System.Convert.ToString(Math.Round(100 * _cpuUsage, 3)) + " %";
        s += Constants.vbNewLine + "Phys. mem. usage : " + Misc.GetFormatedSize(d) + " (" + System.Convert.ToString(Math.Round(100 * _physMemUsage, 3)) + " %)";

        this.Tray.Text = s;

        Program.TrayIcon.AddValue(1, _cpuUsage);
        Program.TrayIcon.AddValue(2, _physMemUsage);
    }

    // Update monitoring log
    public void UpdateMonitoringLog()
    {
        // Dim s As String

        if (this.tvMonitor.Nodes[0].Nodes.Count > 0)
        {

            // Count counters :-)
            // Dim iCount As Integer = 0
            // Dim n As TreeNode
            // Dim n2 As TreeNode
            // For Each n In Me.tvMonitor.Nodes.Item(0).Nodes
            // For Each n2 In n.Nodes
            // iCount += 1
            // Next
            // Next

            // s = "Monitoring log" & vbNewLine
            // s &= vbNewLine & vbNewLine & "Monitoring " & CStr(iCount) & " item(s)" & vbNewLine

            // For Each n In Me.tvMonitor.Nodes.Item(0).Nodes
            // For Each n2 In n.Nodes

            // Dim it As cMonitor = CType(n2.Tag, cMonitor)
            // s &= vbNewLine & "* Category  : " & it.CategoryName & " -- Instance : " & it.InstanceName & " -- Counter : " & it.CounterName
            // s &= vbNewLine & "      Monitoring creation : " & it.MonitorCreationDate.ToLongDateString & " -- " & it.MonitorCreationDate.ToLongTimeString
            // If it.LastStarted.Ticks > 0 Then
            // s &= vbNewLine & "      Last start : " & it.LastStarted.ToLongDateString & " -- " & it.LastStarted.ToLongTimeString
            // Else
            // s &= vbNewLine & "      Not yet started"
            // End If
            // s &= vbNewLine & "      State : " & it.Enabled
            // s &= vbNewLine & "      Interval : " & it.Interval

            // s &= vbNewLine
            // Next
            // Next
            // s = s.Substring(0, s.Length - 2)

            // Me.txtMonitoringLog.Text = s
            // Me.txtMonitoringLog.SelectionLength = 0
            // Me.txtMonitoringLog.SelectionStart = 0


            this.lvMonitorReport.Items.Clear();
            this.lvMonitorReport.BeginUpdate();
            foreach (TreeNode n in this.tvMonitor.Nodes[0].Nodes)
            {
                foreach (TreeNode n2 in n.Nodes)
                {
                    cMonitor it = (cMonitor)n2.Tag;

                    string k = n.Text;
                    try
                    {
                        ListViewGroup g = new ListViewGroup(k, k);
                        g.HeaderAlignment = HorizontalAlignment.Center;
                        this.lvMonitorReport.Groups.Add(g);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    ListViewItem lvit = new ListViewItem(it.CounterName);
                    lvit.SubItems.Add(it.MachineName);
                    lvit.SubItems.Add(it.MonitorCreationDate.ToLongDateString() + " -- " + it.MonitorCreationDate.ToLongTimeString());
                    if (it.LastStarted.Ticks > 0)
                        lvit.SubItems.Add(it.LastStarted.ToLongDateString() + " -- " + it.LastStarted.ToLongTimeString());
                    else
                        lvit.SubItems.Add("Not yet started");
                    lvit.SubItems.Add(it.Enabled.ToString());
                    lvit.SubItems.Add(it.Interval.ToString());

                    lvit.Group = this.lvMonitorReport.Groups[k];
                    this.lvMonitorReport.Items.Add(lvit);
                }
            }

            this.lvMonitorReport.EndUpdate();
            this.lvMonitorReport.BringToFront();
        }
        else
        {
            this.txtMonitoringLog.Text = "No process monitored." + Constants.vbNewLine + "Click on 'Add' button to monitor a process.";
            this.txtMonitoringLog.SelectionLength = 0;
            this.txtMonitoringLog.SelectionStart = 0;
            this.txtMonitoringLog.BringToFront();
        }
    }

    private void butSaveProcessReport_Click(object sender, System.EventArgs e)
    {
        frmSaveReport frm = new frmSaveReport();
        {
            var withBlock = frm;
            withBlock.ReportType = "processes";
            Application.DoEvents();
            withBlock.TopMost = Program._frmMain.TopMost;
            withBlock.ShowDialog();
        }
    }

    // Permute style of menus
    public void permuteMenuStyle(bool ribbonStyle)
    {
        // =============== ' _tab.Region = New Region(New RectangleF(_tab.TabPages(0).Left, _tab.TabPages(0).Top, _tab.TabPages(0).Width, _tab.TabPages(0).Height))

        // Change selected tab of tabStrip
        _ribbonStyle = ribbonStyle;

        _main.Panel1Collapsed = !(_ribbonStyle);

        this.MenuItemSYSTEMFILE.Visible = !(_ribbonStyle);
        this.MenuItemSYSTEMOPT.Visible = !(_ribbonStyle);
        this.MenuItemSYSTEMTOOLS.Visible = !(_ribbonStyle);
        this.MenuItemSYSTEMSYSTEM.Visible = !(_ribbonStyle);
        this.MenuItemSYSTEMHEL.Visible = !(_ribbonStyle);

        this.frmMain_Resize(null, null);
    }

    private void txtServiceSearch_Click(object sender, System.EventArgs e)
    {
        txtServiceSearch_TextChanged(null, null);
    }

    private void txtServiceSearch_TextChanged(object sender, System.EventArgs e)
    {
        ListViewItem it;
        string comp = this.txtServiceSearch.Text.ToLowerInvariant();
        foreach (var it in this.lvServices.Items)
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
                it.Group = lvServices.Groups[0];
            else
                it.Group = lvServices.Groups[1];
        }
        this.lblResCount2.Text = System.Convert.ToString(lvServices.Groups[1].Items.Count) + " result(s)";
    }

    private void txtSearch_Click(object sender, System.EventArgs e)
    {
        txtSearch_TextChanged(null, null);
    }

    private void txtSearch_TextChanged(object sender, System.EventArgs e)
    {
        ListViewItem it;
        string comp = this.txtSearch.Text.ToLowerInvariant();
        foreach (var it in this.lvProcess.Items)
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
                it.Group = lvProcess.Groups[0];
            else
                it.Group = lvProcess.Groups[1];
        }
        this.lblResCount.Text = System.Convert.ToString(lvProcess.Groups[1].Items.Count) + " result(s)";
    }

    private void txtFile_TextChanged(object sender, System.EventArgs e)
    {
        bool b = System.IO.File.Exists(this.txtFile.Text);
        this.RBFileDelete.Enabled = b;
        this.RBFileKillProcess.Enabled = false; // TOCHANGE
        this.RBFileOnline.Enabled = b;
        this.RBFileOther.Enabled = b;
        this.RBFileOthers.Enabled = b;
    }

    private void tvMonitor_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        this.graphMonitor.EnableGraph = false;

        if (tvMonitor.SelectedNode == null)
            return;

        if (tvMonitor.SelectedNode.Parent != null)
        {
            if (tvMonitor.SelectedNode.Parent.Name == tvMonitor.Nodes[0].Name)
            {
                // Then we have selected a process
                this.butMonitorStart.Enabled = true;
                this.butMonitorStop.Enabled = true;
                Graphics g = this.graphMonitor.CreateGraphics();
                {
                    var withBlock = g;
                    withBlock.Clear(Color.Black);
                    withBlock.DrawString("Select in the treeview a counter.", this.Font, Brushes.White, 0, 0);
                    withBlock.Dispose();
                }
            }
            else
            {
                cMonitor it = (cMonitor)tvMonitor.SelectedNode.Tag;
                this.butMonitorStart.Enabled = !(it.Enabled);
                this.butMonitorStop.Enabled = it.Enabled;

                // We have selected a sub item -> display values in graph
                string sKey = tvMonitor.SelectedNode.Text;
                ShowMonitorStats(it, sKey, "", "");
            }
        }
        else
        {
            // The we can start/stop all items
            this.butMonitorStart.Enabled = true;
            this.butMonitorStop.Enabled = true;
            Graphics g = this.graphMonitor.CreateGraphics();
            {
                var withBlock1 = g;
                withBlock1.Clear(Color.Black);
                withBlock1.DrawString("Select in the treeview an item and then a counter.", this.Font, Brushes.White, 0, 0);
                withBlock1.Dispose();
            }
        }

        this.MenuItemMonitorStart.Enabled = this.butMonitorStart.Enabled;
        this.MenuItemMonitorStop.Enabled = this.butMonitorStop.Enabled;
    }

    private void tvProc_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        this.lvProcess.Items[0].Group = this.lvProcess.Groups[1];
    }

    private void rtb2_TextChanged(object sender, System.EventArgs e)
    {
        this.cmdCopyServiceToCp.Enabled = (rtb2.Rtf.Length > 0);
    }

    private void lvTask_DoubleClick(object sender, System.EventArgs e)
    {
        if (MenuItemTaskSelProc.Enabled)
            this.MenuItemTaskSelProc_Click(null, null);
    }

    private void lvTask_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lvTask);
    }

    private void lvServices_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            this.butServiceDetails_Click(null, null);
        else if (e.KeyCode == Keys.Delete)
        {
            if (_notWMI)
                butDeleteService_Click(null, null);
        }
    }

    private void lvServices_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            foreach (cService it in this.lvServices.GetSelectedItems())
            {
                frmServiceInfo frm = new frmServiceInfo();
                frm.SetService(ref it);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void lvServices_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lvServices);
    }

    private void lvServices_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvServices.SelectedItems != null
                    && this.lvServices.SelectedItems.Count > 0);

            if (_notSnapshotMode)
            {
                if (lvServices.SelectedItems.Count == 1)
                {
                    cService cSe = this.lvServices.GetSelectedItem();
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
                    MenuItemServStartType.Enabled = true;
                }
                else if (lvServices.SelectedItems.Count > 1)
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
                    MenuItemServStartType.Enabled = true;
                }
                else if (lvServices.SelectedItems.Count == 0)
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
                    MenuItemServStartType.Enabled = false;
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
                MenuItemServStartType.Enabled = false;
            }

            this.MenuItemServFileDetails.Enabled = selectionIsNotNothing && _local && this.lvServices.SelectedItems.Count == 1;
            this.MenuItemServFileProp.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServOpenDir.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServSearch.Enabled = selectionIsNotNothing;
            this.MenuItemServDepe.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServSelService.Enabled = selectionIsNotNothing && _local;
            this.MenuItemServReanalize.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemCopyService.Enabled = selectionIsNotNothing;
            this.MenuItemServDelete.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;

            this.mnuService.Show(this.lvServices, e.Location);
        }
    }

    private void lvServices_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // New service selected
        if (lvServices.SelectedItems.Count == 1)
        {
            try
            {
                cService cS = this.lvServices.GetSelectedItem();

                this.lblServiceName.Text = "Service name : " + cS.Infos.Name;
                this.lblServicePath.Text = "Service path : " + cS.GetInformation("ImagePath");

                // Description
                string s = Constants.vbNullString;
                string description = Constants.vbNullString;
                string diagnosticsMessageFile = cS.Infos.DiagnosticMessageFile;
                string group = cS.Infos.LoadOrderGroup;
                string objectName = cS.Infos.ObjectName;
                string sp = cS.GetInformation("ImagePath");

                // OK it's not the best way to retrive the description...
                // (if @ -> extract string to retrieve description)
                string sTemp = cS.Infos.Description;
                if (Strings.InStr(sTemp, "@", CompareMethod.Binary) > 0)
                    description = Native.Objects.File.GetResourceStringFromFile(sTemp);
                else
                    description = sTemp;
                description = Strings.Replace(cS.Infos.Description, @"\", @"\\");


                s = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}";
                s = s + @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b Service properties\b0\par";
                s = s + @"\tab Name :\tab\tab\tab " + cS.Infos.Name + @"\par";
                s = s + @"\tab Common name :\tab\tab " + cS.Infos.DisplayName + @"\par";
                if (Strings.Len(sp) > 0)
                    s = s + @"\tab Path :\tab\tab\tab " + Strings.Replace(cS.GetInformation("ImagePath"), @"\", @"\\") + @"\par";
                if (Strings.Len(description) > 0)
                    s = s + @"\tab Description :\tab\tab " + description + @"\par";
                if (Strings.Len(group) > 0)
                    s = s + @"\tab Group :\tab\tab\tab " + group + @"\par";
                if (Strings.Len(objectName) > 0)
                    s = s + @"\tab ObjectName :\tab\tab " + objectName + @"\par";
                if (Strings.Len(diagnosticsMessageFile) > 0)
                    s = s + @"\tab DiagnosticsMessageFile :\tab\tab " + diagnosticsMessageFile + @"\par";
                s = s + @"\tab State :\tab\tab\tab " + cS.Infos.State.ToString() + @"\par";
                s = s + @"\tab Startup :\tab\tab " + cS.Infos.StartType.ToString() + @"\par";
                if (cS.Infos.ProcessId > 0)
                    s = s + @"\tab Owner process :\tab\tab " + cS.Infos.ProcessId + "-- " + cProcess.GetProcessName(cS.Infos.ProcessId) + @"\par";
                s = s + @"\tab Service type :\tab\tab " + cS.Infos.ServiceType.ToString() + @"\par";

                s = s + "}";

                rtb2.Rtf = s;

                // Treeviews stuffs
                // Only if we are in local mode...
                if (Program.Connection.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
                {
                    {
                        var withBlock = tv;
                        withBlock.RootService = cS.Infos.Name;
                        withBlock.InfosToGet = cServDepConnection.DependenciesToget.DependenciesOfMe;
                        withBlock.UpdateItems();
                    }
                    {
                        var withBlock1 = tv2;
                        withBlock1.RootService = cS.Infos.Name;
                        withBlock1.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
                        withBlock1.UpdateItems();
                    }
                }
                else
                {
                    tv.ClearItems();
                    tv.SafeAdd("No auto refresh for remote monitoring");
                    tv2.ClearItems();
                    tv2.SafeAdd("No auto refresh for remote monitoring");
                }
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

                rtb2.Rtf = s;
            }
        }
    }

    private void lvSearchResults_HasRefreshed()
    {
        this.butSearchGo.Enabled = true;
        this.MenuItemSearchNew.Enabled = true;
    }

    private void lvSearchResults_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lvSearchResults);
    }

    private void lvProcess_GotAnError(string origin, string msg)
    {
        Misc.ShowError("Error : " + msg + Constants.vbNewLine + "Origin : " + origin + Constants.vbNewLine + Constants.vbNewLine + "YAPM will be disconnected from the machine.");
        this.DisconnectFromMachine();
    }

    private void lvProcess_ItemAdded(ref cProcess item)
    {
        if (item != null)
        {
            Program.Log.AppendLine("Process created : " + item.Infos.Name + " (" + item.Infos.ProcessId + ")");
            if (this.MenuItemTaskSelProc.Enabled == false)
                MenuItemTaskSelProc.Enabled = true;
            if (My.MySettingsProperty.Settings.NotifyNewProcesses && this.lvProcess.FirstRefreshDone)
            {
                string text = "Name : " + item.Infos.Name + " (" + item.Infos.ProcessId.ToString() + ")";
                if (item.Infos.ParentProcessId > 0)
                    text += Constants.vbNewLine + "Parent : " + cProcess.GetProcessName(item.Infos.ParentProcessId) + " (" + cProcess.GetProcessName(item.Infos.ParentProcessId) + ")";
                if (item.Infos.FileInfo != null)
                    text += Constants.vbNewLine + "Company : " + item.Infos.FileInfo.CompanyName + Constants.vbNewLine + "Description : " + item.Infos.FileInfo.FileDescription;
                {
                    var withBlock = this.Tray;
                    withBlock.BalloonTipText = text;
                    withBlock.BalloonTipIcon = ToolTipIcon.Info;
                    withBlock.BalloonTipTitle = "A new process has been started";
                    withBlock.ShowBalloonTip(3000);
                }
            }
        }
    }

    private void lvProcess_ItemDeleted(ref cProcess item)
    {
        if (item != null)
        {
            Program.Log.AppendLine("Process deleted : " + item.Infos.Name + " (" + item.Infos.ProcessId + ")");
            if (My.MySettingsProperty.Settings.NotifyTerminatedProcesses)
            {
                string text = "Name : " + item.Infos.Name + " (" + item.Infos.ProcessId.ToString() + ")";
                if (item.Infos.ParentProcessId > 0)
                    text += Constants.vbNewLine + "Parent : " + cProcess.GetProcessName(item.Infos.ParentProcessId) + " (" + cProcess.GetProcessName(item.Infos.ParentProcessId) + ")";
                if (item.Infos.FileInfo != null)
                    text += Constants.vbNewLine + "Company : " + item.Infos.FileInfo.CompanyName + Constants.vbNewLine + "Description : " + item.Infos.FileInfo.FileDescription;
                {
                    var withBlock = this.Tray;
                    withBlock.BalloonTipText = text;
                    withBlock.BalloonTipIcon = ToolTipIcon.Info;
                    withBlock.BalloonTipTitle = "A process has been terminated";
                    withBlock.ShowBalloonTip(3000);
                }
            }
        }
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
            this.butProcessDisplayDetails_Click(null, null);
    }

    private void lvProcess_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
            this.butProcessDisplayDetails_Click(null, null);
    }

    private void lvProcess_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lvProcess);
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
            this.MenuItemProcOther.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcKill.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcPriority.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcReanalize.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemProcResume.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcKillT.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcStop.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcResume.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcSFileProp.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcSOpenDir.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcSSearch.Enabled = selectionIsNotNothing;
            this.MenuItemProcSDep.Enabled = selectionIsNotNothing && _local;
            this.MenuItemCopyProcess.Enabled = selectionIsNotNothing;
            this.MenuItemProcSFileDetails.Enabled = (selectionIsNotNothing && _local && this.lvProcess.SelectedItems.Count == 1);
            this.MenuItemProcDump.Enabled = selectionIsNotNothing && _local;
            this.MenuItemProcAff.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcWSS.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemProcKillByMethod.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;

            // Job menuitems
            this.MenuItemProcJob.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            if (this.lvProcess.SelectedItems.Count != 1)
                this.MenuItemJobMng.Enabled = true;
            else
                // We currently can not get process job by id synchronously
                // if we are using remote monitoring
                if (_local)
            {
                this.MenuItemJobMng.Enabled = (cJob.GetProcessJobById(this.lvProcess.GetSelectedItem().Infos.ProcessId) != null);
                this.MenuItemProcAddToJob.Enabled = !(this.MenuItemJobMng.Enabled);
            }
            else
            {
                this.MenuItemProcAddToJob.Enabled = true;
                this.MenuItemJobMng.Enabled = false;
            }

            this.mnuProcess.Show(this.lvProcess, e.Location);
        }
    }

    private void lstFileString_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Middle)
        {
            string s = Constants.vbNullString;
            ListViewItem it;
            int x = 0;
            foreach (var it in this.lvFileString.SelectedItems)
            {
                s += it.Text;
                x += 1;
                if (!(x == this.lvFileString.SelectedItems.Count))
                    s += Constants.vbNewLine;
            }
            if (!(s == Constants.vbNullString))
                My.MyProject.Computer.Clipboard.SetText(s, TextDataFormat.UnicodeText);
        }
    }

    private void lblTaskCountResult_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lvTask.Groups[1].Items.Count > 0)
        {
            this.lvTask.Focus();
            this.lvTask.EnsureVisible(this.lvTask.Groups[1].Items[0].Index);
            this.lvTask.SelectedItems.Clear();
            this.lvTask.Groups[1].Items[0].Selected = true;
        }
    }

    private void txtSearchTask_TextChanged(object sender, System.EventArgs e)
    {
        ListViewItem it;
        string comp = this.txtSearchTask.Text.ToLowerInvariant();
        foreach (var it in this.lvTask.Items)
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
                it.Group = lvTask.Groups[0];
            else
                it.Group = lvTask.Groups[1];
        }
        this.lblTaskCountResult.Text = System.Convert.ToString(lvTask.Groups[1].Items.Count) + " result(s)";
    }

    private void lblResCount2_Click(object sender, System.EventArgs e)
    {
        if (this.lvServices.Groups[1].Items.Count > 0)
        {
            this.lvServices.Focus();
            this.lvServices.EnsureVisible(this.lvServices.Groups[1].Items[0].Index);
            this.lvServices.SelectedItems.Clear();
            this.lvServices.Groups[1].Items[0].Selected = true;
        }
    }

    private void lblResCount_Click(object sender, System.EventArgs e)
    {
        if (this.lvProcess.Groups[1].Items.Count > 0)
        {
            this.lvProcess.Focus();
            this.lvProcess.EnsureVisible(this.lvProcess.Groups[1].Items[0].Index);
            this.lvProcess.SelectedItems.Clear();
            this.lvProcess.Groups[1].Items[0].Selected = true;
        }
    }

    private void graphMonitor_OnZoom(int leftVal, int rightVal)
    {
        // Change dates and set view as fixed (left and right)
        try
        {
            cMonitor it = (cMonitor)tvMonitor.SelectedNode.Tag;
            DateTime l = new DateTime(it.MonitorCreationDate.Ticks + leftVal * 10000);
            DateTime r = new DateTime(it.MonitorCreationDate.Ticks + rightVal * 10000);
            this.dtMonitorL.Value = l;
            this.dtMonitorR.Value = r;
            this.chkMonitorLeftAuto.Checked = false;
            this.chkMonitorRightAuto.Checked = false;
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Could not zoom on graph");
        }
    }

    private void chkFileArchive_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileArchive.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.Archive);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.Archive);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileArchive.Checked = !(this.chkFileArchive.Checked);
        }
    }

    private void chkFileHidden_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileHidden.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.Hidden);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.Hidden);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileHidden.Checked = !(this.chkFileHidden.Checked);
        }
    }

    private void chkFileReadOnly_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileReadOnly.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.ReadOnly);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.ReadOnly);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileReadOnly.Checked = !(this.chkFileReadOnly.Checked);
        }
    }

    private void chkFileContentNotIndexed_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileContentNotIndexed.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.NotContentIndexed);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.NotContentIndexed);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileContentNotIndexed.Checked = !(this.chkFileContentNotIndexed.Checked);
        }
    }

    private void chkFileNormal_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileNormal.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.Normal);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.Normal);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileNormal.Checked = !(this.chkFileNormal.Checked);
        }
    }

    private void chkFileSystem_CheckedChanged(object sender, System.EventArgs e)
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
        Static accessed As Boolean = False

 */
        if (accessed)
        {
            accessed = false;
            return;
        }
        try
        {
            if (this.chkFileSystem.Checked)
                cSelFile.Attributes = AddAttribute(System.IO.FileAttributes.System);
            else
                cSelFile.Attributes = RemoveAttribute(System.IO.FileAttributes.System);
        }
        catch (Exception ex)
        {
            accessed = true;
            this.chkFileSystem.Checked = !(this.chkFileSystem.Checked);
        }
    }

    private void chkMonitorLeftAuto_CheckedChanged(object sender, System.EventArgs e)
    {
        this.dtMonitorL.Enabled = !(this.chkMonitorLeftAuto.Checked);
        this.txtMonitorNumber.Enabled = !(this.chkMonitorLeftAuto.Checked == false & this.chkMonitorRightAuto.Checked == false);
        this.lblMonitorMaxNumber.Enabled = this.txtMonitorNumber.Enabled;
    }

    private void chkMonitorRightAuto_CheckedChanged(object sender, System.EventArgs e)
    {
        this.dtMonitorR.Enabled = !(this.chkMonitorRightAuto.Checked);
        this.txtMonitorNumber.Enabled = !(this.chkMonitorLeftAuto.Checked == false & this.chkMonitorRightAuto.Checked == false);
        this.lblMonitorMaxNumber.Enabled = this.txtMonitorNumber.Enabled;
    }

    private void chkSearchProcess_CheckedChanged(object sender, System.EventArgs e)
    {
        this.chkSearchModules.Enabled = (this.chkSearchProcess.Checked);
        this.chkSearchEnvVar.Enabled = (this.chkSearchProcess.Checked);
    }

    private void cmdCopyServiceToCp_Click(object sender, System.EventArgs e)
    {
        if (this.rtb2.Text.Length > 0)
            My.MyProject.Computer.Clipboard.SetText(this.rtb2.Text, TextDataFormat.Text);
    }

    private void cmdCopyServiceToCp_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (this.rtb2.Rtf.Length > 0)
                My.MyProject.Computer.Clipboard.SetText(this.rtb2.Rtf, TextDataFormat.Rtf);
        }
    }

    private void cmdFileClipboard_Click(object sender, System.EventArgs e)
    {
        if (this.rtb3.Text.Length > 0)
            My.MyProject.Computer.Clipboard.SetText(this.rtb3.Text, TextDataFormat.Text);
    }

    private void cmdFileClipboard_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (this.rtb3.Rtf.Length > 0)
                My.MyProject.Computer.Clipboard.SetText(this.rtb3.Rtf, TextDataFormat.Rtf);
        }
    }

    private void cmdSetFileDates_Click(object sender, System.EventArgs e)
    {
        // Set new dates
        try
        {
            cSelFile.CreationTime = this.DTcreation.Value;
            cSelFile.LastAccessTime = this.DTlastAccess.Value;
            cSelFile.LastWriteTime = this.DTlastModification.Value;
            Misc.ShowMsg("Set file dates", null, "New dates have been set successfully.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to change dates");
        }
    }

    private void dtMonitorL_ValueChanged(object sender, System.EventArgs e)
    {
        if (this.chkMonitorLeftAuto.Checked == false)
            tvMonitor_AfterSelect(null, null);
    }

    private void dtMonitorR_ValueChanged(object sender, System.EventArgs e)
    {
        if (this.chkMonitorRightAuto.Checked == false)
            tvMonitor_AfterSelect(null, null);
    }

    private void txtSearchResults_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        ListViewItem it;
        string comp = this.lvSearchResults.Text.ToLowerInvariant();
        foreach (var it in this.lvSearchResults.Items)
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
                it.Group = lvSearchResults.Groups[0];
            else
                it.Group = lvSearchResults.Groups[1];
        }
        this.lblResultsCount.Text = System.Convert.ToString(lvSearchResults.Groups[1].Items.Count) + " result(s)";
    }

    private void txtSearchResults_TextChanged(object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lvSearchResults.Items)
        {
            if (Strings.InStr(Strings.LCase(it.SubItems[1].Text), Strings.LCase(this.txtSearchResults.Text)) == 0)
                it.Group = lvSearchResults.Groups[0];
            else
                it.Group = lvSearchResults.Groups[1];
        }
        this.lblResultsCount.Text = System.Convert.ToString(lvSearchResults.Groups[1].Items.Count) + " result(s)";
    }

    private void lblResultsCount_Click(object sender, System.EventArgs e)
    {
        if (this.lvSearchResults.Groups[1].Items.Count > 0)
        {
            this.lvSearchResults.Focus();
            this.lvSearchResults.EnsureVisible(this.lvSearchResults.Groups[1].Items[0].Index);
            this.lvSearchResults.SelectedItems.Clear();
            this.lvSearchResults.Groups[1].Items[0].Selected = true;
        }
    }

    private void _tab_SelectedIndexChanged(object sender, System.EventArgs e)
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
        Static bHelpShown As Boolean = False

 */
        // Hide specific menus
        if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
        {
            this.MenuItemProcesses.Visible = false;
            this.MenuItemMonitor.Visible = false;
            this.MenuItemServices.Visible = false;
            this.MenuItemFiles.Visible = false;
            this.MenuItemSearch.Visible = false;
            this.MenuItemJobs.Visible = false;
        }

        // Change current tab of ribbon
        RibbonTab theTab = this.HelpTab;
        My.MySettingsProperty.Settings.SelectedTab = _tab.TabPages[_tab.SelectedIndex].Text;
        switch (My.MySettingsProperty.Settings.SelectedTab)
        {
            case "Tasks":
                {
                    theTab = this.TaskTab;
                    break;
                }

            case "Processes":
                {
                    theTab = this.ProcessTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemProcesses.Visible = true;
                    break;
                }

            case "Jobs":
                {
                    theTab = this.JobTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemJobs.Visible = true;
                    break;
                }

            case "Monitor":
                {
                    theTab = this.MonitorTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemMonitor.Visible = true;
                    break;
                }

            case "Services":
                {
                    theTab = this.ServiceTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemServices.Visible = true;
                    break;
                }

            case "Network":
                {
                    theTab = this.NetworkTab;
                    break;
                }

            case "File":
                {
                    theTab = this.FileTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemFiles.Visible = true;
                    break;
                }

            case "Search":
                {
                    theTab = this.SearchTab;
                    if (My.MySettingsProperty.Settings.UseRibbonStyle == false)
                        this.MenuItemSearch.Visible = true;
                    break;
                }

            case "Help":
                {
                    theTab = this.HelpTab;
                    this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvProcess.Items.Count) + " processes running";
                    if (!(bHelpShown))
                    {
                        bHelpShown = true;
                        // Load help file
                        if (System.IO.File.Exists(My.MyProject.Application.Info.DirectoryPath + Program.HELP_PATH_DD))
                            // WBHelp.Document.Write("<body link=blue vlink=purple><span>Help file cannot be found. <p></span><span>Please download help file at <a href=" & Chr(34) & "http://sourceforge.net/projects/yaprocmon/" & Chr(34) & ">http://sourceforge.net/projects/yaprocmon</a> and save it in the Help directory.</span></body>")
                            WBHelp.Navigate(My.MyProject.Application.Info.DirectoryPath + Program.HELP_PATH_DD);
                        else
                            WBHelp.Navigate(Program.HELP_PATH_INTERNET);
                    }
                    _tab.SelectedTab = this.pageHelp;
                    break;
                }
        }
        this.Ribbon.ActiveTab = theTab;
    }

    private void goSearch(string ssearch)
    {
        if (ssearch != null && ssearch.Length > 0)
        {
            {
                var withBlock = this.lvSearchResults;
                withBlock.CaseSensitive = this.chkSearchCase.Checked;
                withBlock.SearchString = ssearch;
                Native.Api.Enums.GeneralObjectType t;
                if (this.chkSearchEnvVar.Checked & this.chkSearchEnvVar.Enabled)
                    t = t | Native.Api.Enums.GeneralObjectType.EnvironmentVariable;
                if (this.chkSearchHandles.Checked)
                    t = t | Native.Api.Enums.GeneralObjectType.Handle;
                if (this.chkSearchModules.Checked & this.chkSearchModules.Enabled)
                    t = t | Native.Api.Enums.GeneralObjectType.Module;
                if (this.chkSearchProcess.Checked)
                    t = t | Native.Api.Enums.GeneralObjectType.Process;
                if (this.chkSearchServices.Checked)
                    t = t | Native.Api.Enums.GeneralObjectType.Service;
                if (this.chkSearchWindows.Checked)
                    t = t | Native.Api.Enums.GeneralObjectType.Window;
                withBlock.Includes = t;
                this.butSearchGo.Enabled = false;
                this.MenuItemSearchNew.Enabled = false;
                withBlock.UpdateItems();
            }
        }
    }

    private void timerNetwork_Tick(System.Object sender, System.EventArgs e)
    {
        refreshNetworkList();
    }

    private void timerStateBasedActions_Tick(System.Object sender, System.EventArgs e)
    {
    }

    // Private Sub emStateBasedActions_ExitRequested() Handles emStateBasedActions.ExitRequested
    // Me.Close()
    // End Sub

    // Private Sub emStateBasedActions_LogRequested(ByRef process As cLocalProcess) Handles emStateBasedActions.LogRequested
    // 'Dim frm As New frmProcessInfo
    // 'frm.SetProcess(process)
    // 'frm.WindowState = FormWindowState.Minimized
    // 'frm.StartLog()
    // 'frm.tabProcess.SelectedTab = frm.TabPage14
    // 'frm.Show()
    // 'TODO_  (sba)
    // End Sub

    // Private Sub emStateBasedActions_NotifyAction(ByRef action As cBasedStateActionState, ByRef process As cLocalProcess) Handles emStateBasedActions.NotifyAction
    // Dim proc As String = process.Name & " (" & process.Pid.ToString & ")"
    // If action.Notify Then
    // Me.Tray.ShowBalloonTip(2000, "State based action was raised", "Rule : " & action.RuleText & " , process : " & proc, ToolTipIcon.Info)
    // End If

    // ' Add to log
    // Program.Log.AppendLine("State based action was raised -- Rule : " & action.RuleText & " , process : " & proc)
    // End Sub

    // Private Sub emStateBasedActions_SaveProcessListRequested(ByVal path As String) Handles emStateBasedActions.SaveProcessListRequested
    // Try
    // ' Create file report
    // Dim c As String = vbNullString
    // Dim stream As New System.IO.StreamWriter(path, False)
    // Dim _count As Integer = Me.lvProcess.GetAllItems.Count
    // For Each it As cProcess In Me.lvProcess.GetAllItems
    // c = "Process : " & it.Name
    // c &= vbTab & "PID : " & it.Pid.ToString
    // c &= vbTab & "Path : " & it.Path
    // c &= vbNewLine
    // stream.Write(c)
    // Next
    // c = CStr(_count) & " result(s)"
    // stream.Write(c)
    // stream.Close()
    // Catch
    // '
    // End Try
    // End Sub

    // Private Sub emStateBasedActions_SaveServiceListRequested(ByVal path As String) Handles emStateBasedActions.SaveServiceListRequested
    // Try
    // ' Create file report
    // Dim c As String = vbNullString
    // Dim stream As New System.IO.StreamWriter(path, False)
    // Dim _count As Integer = Me.lvServices.GetAllItems.Count
    // For Each it As cService In Me.lvServices.GetAllItems
    // c = "Service : " & it.Name
    // c &= vbTab & "Long name : " & it.LongName
    // c &= vbTab & "Path : " & it.ImagePath
    // c &= vbTab & "Process : " & it.ProcessName & " (" & it.ProcessID & ")"
    // c &= vbNewLine
    // stream.Write(c)
    // Next
    // c = CStr(_count) & " result(s)"
    // stream.Write(c)
    // stream.Close()
    // Catch
    // '
    // End Try
    // End Sub

    private void butNewProcess_Click(object sender, System.EventArgs e)
    {
        if (Program.Connection.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            cFile.ShowRunBox(this.Handle, "Start a new process", "Enter the path of the process you want to start.");
        else
        {
            string sres = Misc.CInputBox("Enter the path of the process you want to start.", "Start a new process", "");
            if (sres == null || sres.Equals(string.Empty))
                return;
            cProcess.SharedRLStartNewProcess(sres);
        }
    }

    private void butLog_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainLog_Click(null, null);
    }

    private void butWindows_Click(object sender, System.EventArgs e)
    {
        this.MenuItemSystemOpenedWindows_Click(null, null);
    }

    private void butSystemInfo_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainSysInfo_Click(null, null);
    }

    private void butFindWindow_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainFindWindow_Click(null, null);
    }

    private void orbMenuAbout_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainAbout_Click(null, null);
    }

    private void orbMenuEmergency_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainEmergencyH_Click(null, null);
    }

    private void orbMenuSaveReport_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainReport_Click(null, null);
    }

    private void orbMenuSBA_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainSBA_Click(null, null);
    }

    private void butNetwork_Click(object sender, System.EventArgs e)
    {
        orbMenuNetwork_Click(null, null);
    }

    private void orbMenuNetwork_Click(object sender, System.EventArgs e)
    {
        if (Program.ConnectionForm.Visible)
            Program.ConnectionForm.Hide();
        else
        {
            Program.ConnectionForm.TopMost = Program._frmMain.TopMost;
            Program.ConnectionForm.Show();
        }
    }

    public void ConnectToMachine()
    {
        _local = (Program.Connection.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        _notWMI = (Program.Connection.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        _notSnapshotMode = (Program.Connection.ConnectionType != cConnection.TypeOfConnection.SnapshotFile);

        // Disable all refreshments
        this.timerProcess.Enabled = false;
        this.timerServices.Enabled = false;
        this.timerMonitoring.Enabled = false;
        this.timerTask.Enabled = false;
        this.timerNetwork.Enabled = false;
        this.timerJobs.Enabled = false;

        // Clear all lvItems
        this.lvProcess.ClearItems();
        this.lvSearchResults.ClearItems();
        this.tv.ClearItems();
        this.tv2.ClearItems();
        this.lvTask.ClearItems();
        this.lvServices.ClearItems();
        this.lvNetwork.ClearItems();
        this.lvJob.ClearItems();

        // Connect all lvItems
        this.lvProcess.ConnectionObj = Program.Connection;
        this.lvServices.ConnectionObj = Program.Connection;
        this.lvNetwork.ConnectionObj = Program.Connection;
        this.lvTask.ConnectionObj = Program.Connection;
        this.tv.ConnectionObj = Program.Connection;
        this.tv2.ConnectionObj = Program.Connection;
        this.lvJob.ConnectionObj = Program.Connection;
        this.lvSearchResults.ConnectionObj = Program.Connection;
        _shutdownConnection.ConnectionObj = Program.Connection;
        try
        {
            Program.Connection.Connect();
            _shutdownConnection.Connect();
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to connect");
            return;
        }

        this.butServiceFileDetails.Enabled = _local;
        this.butServiceFileProp.Enabled = _local;
        this.butServiceOpenDir.Enabled = _local;
        this.butDeleteService.Enabled = this._notWMI && _notSnapshotMode;
        this.butResumeProcess.Enabled = this._notWMI && _notSnapshotMode;
        this.butStopProcess.Enabled = this._notWMI && _notSnapshotMode;
        this.butProcessAffinity.Enabled = this._notWMI && _notSnapshotMode;
        this.butProcessAffinity.Enabled = this._notWMI && _notSnapshotMode;
        this.butStopProcess.Enabled = this._notWMI && _notSnapshotMode;
        this.butResumeProcess.Enabled = this._notWMI && _notSnapshotMode;
        this.pageJobs.Enabled = (_local & (cEnvironment.HasYAPMDebugPrivilege())) || !(_local);
        this.RBJobActions.Enabled = this.pageJobs.Enabled && _notSnapshotMode;
        this.RBJobDisplay.Enabled = this.pageJobs.Enabled;
        this.RBJobPrivileges.Enabled = _local && !(cEnvironment.HasYAPMDebugPrivilege());
        this.pageNetwork.Enabled = _notWMI;
        this.pageTasks.Enabled = _notWMI;
        this.pageSearch.Enabled = _notWMI;
        this.RBNetworkRefresh.Enabled = _notWMI;
        this.RBSearchMain.Enabled = _notWMI;
        this.RBTaskActions.Enabled = _notWMI && _notSnapshotMode;
        this.RBTaskDisplay.Enabled = _notWMI;
        this.RBServiceFile.Enabled = _notWMI;
        this.butProcessOtherActions.Enabled = _notWMI && _notSnapshotMode;
        this.RBProcessActions.Enabled = _notSnapshotMode;
        this.RBProcessPriority.Enabled = _notSnapshotMode;
        this.RBServiceAction.Enabled = _notSnapshotMode;
        this.RBServiceStartType.Enabled = _notSnapshotMode;
        this.RBServiceFile.Enabled = _notSnapshotMode;
        this.butCheckSignatures.Enabled = _local;

        this.lvProcess.CatchErrors = !(_local);
        this.lvServices.CatchErrors = !(_local);
        this.lvSearchResults.CatchErrors = !(_local);
        this.lvTask.CatchErrors = !(_local);
        this.lvNetwork.CatchErrors = !(_local);
        this.lvJob.CatchErrors = !(_local);

        // Set new refreshment intervals
        this.timerProcess.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.ProcessInterval * Program.Connection.RefreshmentCoefficient);
        this.timerServices.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.ServiceInterval * Program.Connection.RefreshmentCoefficient);
        this.timerNetwork.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.NetworkInterval * Program.Connection.RefreshmentCoefficient);
        this.timerTask.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.TaskInterval * Program.Connection.RefreshmentCoefficient);
        this.timerTrayIcon.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.TrayInterval * Program.Connection.RefreshmentCoefficient);
        this.timerJobs.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.JobInterval * Program.Connection.RefreshmentCoefficient);

        // Enable all refreshments
        this.timerProcess.Enabled = true; // _local
        this.timerServices.Enabled = true; // _local
        this.timerMonitoring.Enabled = true; // _local
        this.timerNetwork.Enabled = true; // _local
        this.timerTask.Enabled = true; // _local
        this.timerJobs.Enabled = true; // _local
    }

    public void DisconnectFromMachine()
    {
        // Close all frmInfo forms
        // No ForEach but a simple For

        // Disable all refreshments
        this.timerProcess.Enabled = false;
        this.timerServices.Enabled = false;
        this.timerMonitoring.Enabled = false;
        this.timerTask.Enabled = false;
        this.timerNetwork.Enabled = false;
        this.timerJobs.Enabled = false;

        // Clear all lvItems
        this.lvProcess.ClearItems();
        this.lvSearchResults.ClearItems();
        this.lvTask.ClearItems();
        this.lvServices.ClearItems();
        this.lvNetwork.ClearItems();
        this.lvJob.ClearItems();

        for (int x = Application.OpenForms.Count - 1; x >= 0; x += -1)
        {
            Form frm = Application.OpenForms[x];
            if (frm is frmProcessInfo || frm is frmServiceInfo || frm is frmJobInfo)
            {
                try
                {
                    frm.Close();
                }
                catch (Exception ex)
                {
                    Misc.ShowDebugError(ex);
                }
            }
        }
        try
        {
            Program.Connection.Disconnect();
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to disconnect");
            Program.Connection.DisconnectForce();
            return;
        }
    }

    private void butFeedBack_Click(object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmTracker.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmTracker.Show();
    }

    private void butHiddenProcesses_Click(object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmHiddenProcesses.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmHiddenProcesses.Show();
    }

    private void butServiceDetails_Click(object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
        {
            frmServiceInfo frm = new frmServiceInfo();
            frm.SetService(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void butShowPreferences_Click(object sender, System.EventArgs e)
    {
        frmPreferences frm = new frmPreferences();
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void butExit_Click(object sender, System.EventArgs e)
    {
        this.MenuItemMainExit_Click(null, null);
    }

    private void rtb3_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
        string strFile = null;
        foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop))
        {
            if (System.IO.File.Exists(file))
                strFile = file;
        }
        if (strFile != null)
            Misc.DisplayDetailsFile(strFile);
    }

    private void rtb3_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }

    private void rtb3_TextChanged(object sender, System.EventArgs e)
    {
        this.cmdFileClipboard.Enabled = (rtb3.Rtf.Length > 0);
    }

    private void butShowDepViewer_Click(object sender, System.EventArgs e)
    {
        frmDepViewerMain _depFrm = new frmDepViewerMain();
        _depFrm.TopMost = Program._frmMain.TopMost;
        _depFrm.Show();
    }

    private void MenuItemTaskShow_Click(System.Object sender, System.EventArgs e)
    {
        butTaskShow_Click(null, null);
    }

    private void MenuItemTaskMax_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cTask it in this.lvTask.GetSelectedItems())
            it.Maximize();
    }

    private void MenuItemTaskMin_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cTask it in this.lvTask.GetSelectedItems())
            it.Minimize();
    }

    private void MenuItemTaskEnd_Click(System.Object sender, System.EventArgs e)
    {
        butTaskEndTask_Click(null, null);
    }

    private void MenuItemTaskSelProc_Click(System.Object sender, System.EventArgs e)
    {
        // Select processes associated to selected windows
        if (this.lvTask.SelectedItems.Count > 0)
            this.lvProcess.SelectedItems.Clear();
        foreach (cTask it in this.lvTask.GetSelectedItems())
        {
            int pid = it.Infos.ProcessId;
            ListViewItem it2;
            foreach (var it2 in this.lvProcess.Items)
            {
                cProcess cp = this.lvProcess.GetItemByKey(it2.Name);
                if (cp != null && cp.Infos.ProcessId == pid)
                {
                    it2.Selected = true;
                    it2.EnsureVisible();
                }
            }
        }
        this.Ribbon.ActiveTab = this.ProcessTab;
        this.Ribbon_MouseMove(null, null);
        this.lvProcess.Focus();
    }

    private void MenuItemTaskColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvTask.ChooseColumns();
    }

    private void MenuItemMonitorAdd_Click(System.Object sender, System.EventArgs e)
    {
        butMonitoringAdd_Click(null, null);
    }

    private void MenuItemMonitorRemove_Click(System.Object sender, System.EventArgs e)
    {
        butMonitoringRemove_Click(null, null);
    }

    private void MenuItemMonitorStart_Click(System.Object sender, System.EventArgs e)
    {
        butMonitorStart_Click(null, null);
    }

    private void MenuItemMonitorStop_Click(System.Object sender, System.EventArgs e)
    {
        butMonitorStop_Click(null, null);
    }

    private void lvTask_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvTask.SelectedItems != null
&& this.lvTask.SelectedItems.Count > 0);
            this.MenuItemTaskEnd.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemTaskSelProc.Enabled = selectionIsNotNothing && this.lvProcess.Items.Count > 0;
            this.MenuItemTaskShow.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemTaskMax.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemTaskMin.Enabled = selectionIsNotNothing && _notSnapshotMode;
            this.MenuItemTaskSelectWindow.Enabled = selectionIsNotNothing;

            this.MenuItemCopyTask.Enabled = selectionIsNotNothing;
            this.mnuTask.Show(this.lvTask, e.Location);
        }
    }

    private void tvMonitor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.mnuMonitor.Show(this.tvMonitor, e.Location);
    }

    private void MenuItemCopySmall_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctFileSmall.Image);
    }

    private void MenuItemCopyBig_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.Computer.Clipboard.SetImage(this.pctFileBig.Image);
    }

    private void pctFileBig_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.mnuFileCpPctBig.Show(this.pctFileBig, e.Location);
    }

    private void pctFileSmall_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.mnuFileCpPctSmall.Show(this.pctFileSmall, e.Location);
    }

    private void MenuItemMainShow_Click(System.Object sender, System.EventArgs e)
    {
        // If ribbon is used, then the main form is to the left of the screen and
        // not shown in taskbar
        if (My.MySettingsProperty.Settings.UseRibbonStyle)
        {
            if (this.Left == Pref.LEFT_POSITION_HIDDEN)
                this.CenterToScreen();
            this.ShowInTaskbar = true;
        }
        this.Visible = true;
        this.WindowState = FormWindowState.Normal;
        this.Show();
    }

    private void MenuItemMainToTray_Click(System.Object sender, System.EventArgs e)
    {
        this.Hide();
        this.Visible = false;
    }

    private void MenuItemMainAbout_Click(System.Object sender, System.EventArgs e)
    {
        this.butAbout_Click(null, null);
    }

    private void MenuItemMainAlwaysVisible_Click(System.Object sender, System.EventArgs e)
    {
        changeTopMost();
    }

    private void MenuItemMainRestart_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Restart();
    }

    private void MenuItemMainShutdown_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Shutdown();
    }

    private void MenuItemMainPowerOff_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Poweroff();
    }

    private void MenuItemMainSleep_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Sleep();
    }

    private void MenuItemMainHibernate_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Hibernate();
    }

    private void MenuItemMainLogOff_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Logoff();
    }

    private void MenuItemMainLock_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Lock();
    }

    private void MenuItemMainLog_Click(System.Object sender, System.EventArgs e)
    {
        Program.Log.ShowForm = true;
    }

    private void MenuItemMainReport_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmGlobalReport.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmGlobalReport.ShowDialog();
    }

    private void MenuItemMainSysInfo_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmSystemInfo.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmSystemInfo.Show();
    }

    private void MenuItemMainOpenedW_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmWindowsList.BringToFront();
        My.MyProject.MyForms.frmWindowsList.WindowState = FormWindowState.Normal;
        My.MyProject.MyForms.frmWindowsList.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmWindowsList.Show();
    }

    private void MenuItemMainEmergencyH_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmHotkeys.BringToFront();
        My.MyProject.MyForms.frmHotkeys.WindowState = FormWindowState.Normal;
        My.MyProject.MyForms.frmHotkeys.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmHotkeys.Show();
    }

    private void MenuItemMainFindWindow_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmFindWindow.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmFindWindow.Show();
    }

    private void MenuItemMainSBA_Click(System.Object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmBasedStateAction.BringToFront();
        My.MyProject.MyForms.frmBasedStateAction.WindowState = FormWindowState.Normal;
        My.MyProject.MyForms.frmBasedStateAction.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmBasedStateAction.Show();
    }

    private void MenuItemRefProc_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemRefProc.Checked = !(this.MenuItemRefProc.Checked);
        this.MenuItemSystemRefProc.Checked = this.MenuItemRefProc.Checked;
        this.timerProcess.Enabled = this.MenuItemRefProc.Checked;
    }

    private void MenuItemMainRefServ_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainRefServ.Checked = !(this.MenuItemMainRefServ.Checked);
        this.MenuItemSystemRefServ.Checked = this.MenuItemMainRefServ.Checked;
        this.timerServices.Enabled = this.MenuItemMainRefServ.Checked;
    }

    private void MenuItemMainExit_Click(System.Object sender, System.EventArgs e)
    {
        Program.ExitYAPM();
    }

    private void MenuItemServSelService_Click(System.Object sender, System.EventArgs e)
    {
        // Select processes associated to selected services results
        ListViewItem it;
        bool bOne = false;
        if (this.lvServices.SelectedItems.Count > 0)
            this.lvProcess.SelectedItems.Clear();
        foreach (var it in this.lvServices.SelectedItems)
        {
            cService tmp = this.lvServices.GetItemByKey(it.Name);
            if (tmp != null)
            {
                int pid = tmp.Infos.ProcessId;
                ListViewItem it2;
                foreach (var it2 in this.lvProcess.Items)
                {
                    cProcess cp = this.lvProcess.GetItemByKey(it2.Name);
                    if (cp != null && cp.Infos.ProcessId == pid & pid > 0)
                    {
                        it2.Selected = true;
                        bOne = true;
                        it2.EnsureVisible();
                    }
                }
            }
        }
        if (bOne)
        {
            this.Ribbon.ActiveTab = this.ProcessTab;
            this.Ribbon_MouseMove(null, null);
        }
    }

    private void MenuItemServFileProp_Click(System.Object sender, System.EventArgs e)
    {
        string s = Constants.vbNullString;
        foreach (cService it in this.lvServices.GetSelectedItems())
        {
            string sP = it.GetInformation("ImagePath");
            if (sP != Program.NO_INFO_RETRIEVED)
            {
                // TODO_
                s = sP;  // cService.GetFileNameFromSpecial(sP)
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
                        withBlock.ShowDialog();
                        withBlock.TopMost = Program._frmMain.TopMost;
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
        foreach (cService it in this.lvServices.GetSelectedItems())
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
                        withBlock.ShowDialog();
                        withBlock.TopMost = Program._frmMain.TopMost;
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
        this.butServiceFileDetails_Click(null, null);
    }

    private void MenuItemServSearch_Click(System.Object sender, System.EventArgs e)
    {
        this.butServiceGoogle_Click(null, null);
    }

    private void MenuItemServDepe_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
        {
            if (System.IO.File.Exists(it.GetInformation("ImagePath")))
            {
                frmDepViewerMain frm = new frmDepViewerMain();
                frm.HideOpenMenu();
                frm.OpenReferences(it.GetInformation("ImagePath"));
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void MenuItemServPause_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
        {
            if (it.Infos.State == Native.Api.NativeEnums.ServiceState.Running)
                it.PauseService();
            else
                it.ResumeService();
        }

        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServStop_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to stop these services ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.StopService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServStart_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.StartService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServAutoStart_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.AutoStart);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServOnDemand_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.DemandStart);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServDisabled_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.SetServiceStartType(Native.Api.NativeEnums.ServiceStartType.StartDisabled);
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServReanalize_Click(System.Object sender, System.EventArgs e)
    {
        this.lvServices.ReAnalizeServices();
    }

    private void MenuItemServColumns_Click(System.Object sender, System.EventArgs e)
    {
        this.lvServices.ChooseColumns();
    }

    private void MenuItemServSelProc_Click(System.Object sender, System.EventArgs e)
    {
        // Select processes associated to selected connections
        ListViewItem it;
        if (this.lvNetwork.SelectedItems.Count > 0)
            this.lvProcess.SelectedItems.Clear();
        foreach (var it in this.lvNetwork.SelectedItems)
        {
            cNetwork tmp = lvNetwork.GetItemByKey(it.Name);
            if (tmp != null)
            {
                int pid = tmp.Infos.ProcessId;
                ListViewItem it2;
                foreach (var it2 in this.lvProcess.Items)
                {
                    cProcess cp = this.lvProcess.GetItemByKey(it2.Name);
                    if (cp != null && cp.Infos.ProcessId == pid)
                    {
                        it2.Selected = true;
                        it2.EnsureVisible();
                    }
                }
            }
        }
        this.Ribbon.ActiveTab = this.ProcessTab;
        this.Ribbon_MouseMove(null, null);
    }

    private void menuCloseTCP_Click(System.Object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to close these connections ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
        {
            if (it.Infos.Protocol == Native.Api.Enums.NetworkProtocol.Tcp)
                it.CloseTCP();
        }
    }

    private void MenuItem13_Click(System.Object sender, System.EventArgs e)
    {
        this.lvNetwork.ChooseColumns();
    }

    private void lvNetwork_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvNetwork.SelectedItems != null
                && this.lvNetwork.SelectedItems.Count > 0);

            bool enable = false;
            foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
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
            this.MenuItemNetworkClose.Enabled = enable && _notSnapshotMode && _notWMI;
            this.MenuItemServSelProc.Enabled = selectionIsNotNothing;
            this.MenuItemCopyNetwork.Enabled = selectionIsNotNothing;

            bool bTools = true;
            if (this.lvNetwork.SelectedItems.Count == 1)
                bTools = (this.lvNetwork.GetSelectedItem().Infos.Remote != null);
            this.MenuItemNetworkTools.Enabled = selectionIsNotNothing && bTools;

            this.mnuNetwork.Show(this.lvNetwork, e.Location);
        }
    }

    private void MenuItemSearchNew_Click(System.Object sender, System.EventArgs e)
    {
        string r = Misc.CInputBox("Enter the string you want to search", "String search");
        if (r != null && !(r.Equals(string.Empty)))
            goSearch(r);
    }

    private void MenuItemSearchSel_Click(System.Object sender, System.EventArgs e)
    {
        // Select processes associated to selected search results
        if (this.lvSearchResults.SelectedItems.Count > 0)
            this.lvProcess.SelectedItems.Clear();
        foreach (cSearchItem it in this.lvSearchResults.GetSelectedItems())
        {
            try
            {
                if (it.Infos.Type == Native.Api.Enums.GeneralObjectType.Service)
                {
                    // Select service
                    string sp = it.Infos.Owner;
                    ListViewItem it2;
                    foreach (var it2 in this.lvServices.Items)
                    {
                        cService cp = this.lvServices.GetItemByKey(it2.Name);
                        if (cp != null && cp.Infos.Name == sp)
                        {
                            it2.Selected = true;
                            it2.EnsureVisible();
                        }
                    }
                    this.Ribbon.ActiveTab = this.ServiceTab;
                }
                else
                {
                    // Select process
                    int i = it.Infos.OwnedProcessId;
                    if (i > 0)
                    {
                        ListViewItem it2;
                        foreach (var it2 in this.lvProcess.Items)
                        {
                            cProcess cp = this.lvProcess.GetItemByKey(it2.Name);
                            if (cp != null && cp.Infos.ProcessId == i)
                            {
                                it2.Selected = true;
                                it2.EnsureVisible();
                            }
                        }
                    }
                    this.Ribbon.ActiveTab = this.ProcessTab;
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        this.Ribbon_MouseMove(null, null);
    }

    private void MenuItemSearchClose_Click(System.Object sender, System.EventArgs e)
    {
        // Close selected items
        if (Misc.WarnDangerousAction("This will close handles, unload module, stop service, kill process or close window depending on the selected object.", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cSearchItem it in this.lvSearchResults.GetSelectedItems())
            it.CloseTerminate();
    }

    private void lvSearchResults_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvSearchResults.SelectedItems != null
&& this.lvSearchResults.SelectedItems.Count > 0);

            this.MenuItemSearchClose.Enabled = false; // selectionIsNotNothing
            this.MenuItemSearchSel.Enabled = selectionIsNotNothing;
            this.MenuItemCopySearch.Enabled = selectionIsNotNothing;

            this.mnuSearch.Show(this.lvSearchResults, e.Location);
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

    private void MenuItemProcReanalize_Click(System.Object sender, System.EventArgs e)
    {
        this.lvProcess.ReAnalizeProcesses();
    }

    private void MenuItemProcSServices_Click(System.Object sender, System.EventArgs e)
    {

        // Refresh service list if necessary
        if (this.lvServices.Items.Count == 0)
            this.refreshServiceList();

        // Get selected processes pids
        int[] pid;
        pid = new int[1];
        int x = -1;
        foreach (cProcess lvi in this.lvProcess.GetSelectedItems())
        {
            x += 1;
            var oldPid = pid;
            pid = new int[x + 1];
            if (oldPid != null)
                Array.Copy(oldPid, pid, Math.Min(x + 1, oldPid.Length));
            pid[x] = lvi.Infos.ProcessId;
        }

        // Get services names of all associated services
        // Dim name() As String
        // ReDim name(0)
        // x = -1
        bool bAddedOneService = false;
        bool bServRef = this.timerServices.Enabled;
        this.timerServices.Enabled = false;            // Lock service timer

        foreach (ListViewItem lvi in this.lvServices.Items)
        {
            cService cServ = this.lvServices.GetItemByKey(lvi.Name);
            bool bToAdd = false;
            if (cServ != null)
            {
                foreach (int _pid in pid)
                {
                    if (cServ.Infos.ProcessId == _pid & _pid > 0)
                    {
                        bToAdd = true;
                        break;
                    }
                }
            }

            // Then we select service
            if (bToAdd)
            {
                if (bAddedOneService == false)
                {
                    this.lvServices.SelectedItems.Clear();
                    bAddedOneService = true;
                }
                lvi.Selected = true;
                lvi.EnsureVisible();
            }
        }

        // Unlock timer
        this.timerServices.Enabled = bServRef;

        if (bAddedOneService)
        {
            this.Ribbon.ActiveTab = this.ServiceTab;
            this.Ribbon_MouseMove(null, null);
        }
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
        this.butProcessGoogle_Click(null, null);
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

    private void MenuItemSystemRefresh_Click(System.Object sender, System.EventArgs e)
    {
        switch (_tab.TabPages[_tab.SelectedIndex].Text)
        {
            case "Tasks":
                {
                    this.butTaskRefresh_Click(null, null);
                    break;
                }

            case "Processes":
                {
                    this.butProcessRerfresh_Click(null, null);
                    break;
                }

            case "Services":
                {
                    this.butServiceRefresh_Click(null, null);
                    break;
                }

            case "Network":
                {
                    this.butNetworkRefresh_Click(null, null);
                    break;
                }

            case "File":
                {
                    this.butFileRefresh_Click(null, null);
                    break;
                }

            case "Jobs":
                {
                    this.butJobRefresh_Click(null, null);
                    break;
                }
        }
    }

    private void MenuItemSystemConnection_Click(System.Object sender, System.EventArgs e)
    {
        orbMenuNetwork_Click(null, null);
    }

    private void MenuItemSystemLog_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainLog_Click(null, null);
    }

    private void MenuItemSystemReport_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainReport_Click(null, null);
    }

    private void MenuItemSystemInfos_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainSysInfo_Click(null, null);
    }

    private void MenuItemSystemOpenedWindows_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainOpenedW_Click(null, null);
    }

    private void MenuItemSystemFindWindow_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainFindWindow_Click(null, null);
    }

    private void MenuItemSystemEmergency_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainEmergencyH_Click(null, null);
    }

    private void MenuItemSystemSBA_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainSBA_Click(null, null);
    }

    private void MenuItemSystemToTray_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainToTray_Click(null, null);
    }

    private void MenuItemSystemExit_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainExit_Click(null, null);
    }

    private void MenuItemSystemAlwaysVisible_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainAlwaysVisible_Click(null, null);
    }

    private void MenuItemSystemRefProc_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemRefProc_Click(null, null);
    }

    private void MenuItemSystemRefServ_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemMainRefServ_Click(null, null);
    }

    private void MenuItemSystemOptions_Click(System.Object sender, System.EventArgs e)
    {
        this.butPreferences_Click(null, null);
    }

    private void MenuItemSystemShowHidden_Click(System.Object sender, System.EventArgs e)
    {
        butHiddenProcesses_Click(null, null);
    }

    private void MenuItemSystemDependency_Click(System.Object sender, System.EventArgs e)
    {
        butShowDepViewer_Click(null, null);
    }

    private void MenuItemSystemRestart_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Restart();
    }

    private void MenuItemSystemShutdown_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Shutdown();
    }

    private void MenuItemSystemPowerOff_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Poweroff();
    }

    private void MenuItemSystemSleep_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Sleep();
    }

    private void MenuItemSystemHIbernate_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Hibernate();
    }

    private void MenuItemSystemLogoff_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Logoff();
    }

    private void MenuItemSystemLock_Click(System.Object sender, System.EventArgs e)
    {
        cSystem.Lock();
    }

    private void MenuItemSystemUpdate_Click(System.Object sender, System.EventArgs e)
    {
        this.butUpdate_Click(null, null);
    }

    private void MenuItemSystemDonation_Click(System.Object sender, System.EventArgs e)
    {
        this.butDonate_Click(null, null);
    }

    private void MenuItemSystemFeedBack_Click(System.Object sender, System.EventArgs e)
    {
        butFeedBack_Click(null, null);
    }

    private void MenuItemSystemSF_Click(System.Object sender, System.EventArgs e)
    {
        this.butProjectPage_Click(null, null);
    }

    private void MenuItemSystemWebsite_Click(System.Object sender, System.EventArgs e)
    {
        this.butWebite_Click(null, null);
    }

    private void MenuItemSystemDownloads_Click(System.Object sender, System.EventArgs e)
    {
        this.butDownload_Click(null, null);
    }

    private void MenuItemSystemHelp_Click(System.Object sender, System.EventArgs e)
    {
        this._tab.SelectedTab = this.pageHelp;
    }

    private void MenuItemSystemAbout_Click(System.Object sender, System.EventArgs e)
    {
        this.butAbout_Click(null, null);
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


    private void MenuItemCopyService_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cService it in this.lvServices.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyJob_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cJob it in this.lvJob.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
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

    private void MenuItemCopyNetwork_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopySearch_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cSearchItem it in this.lvSearchResults.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCopyTask_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (cTask it in this.lvTask.GetSelectedItems())
            toCopy += it.GetInformation(info) + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }


    private void orbStartElevated_Click(object sender, System.EventArgs e)
    {
        // Restart elevated
        cEnvironment.RestartElevated();
    }

    private void MenuItemRunAsAdmin_Click(System.Object sender, System.EventArgs e)
    {
        // Restart elevated
        cEnvironment.RestartElevated();
    }

    private void timerStatus_Tick(System.Object sender, System.EventArgs e)
    {
        // Update panels of status bar
        try
        {
            // /!\ Here we refresh the informations about system
            // RefreshInfo should not be called elsewhere
            Program.SystemInfo.RefreshInfo();

            this.sbPanelConnection.Text = Program.Connection.ToString();
            this.sbPanelCpu.Text = "CPU : " + Common.Misc.GetFormatedPercentage(Program.SystemInfo.CpuUsage, 3, true) + " %";
            this.sbPanelMemory.Text = "Phys. Memory : " + Common.Misc.GetFormatedPercentage(Program.SystemInfo.PhysicalMemoryPercentageUsage, 3, true) + " %";
            this.sbPanelProcesses.Text = this.lvProcess.Items.Count + " processes";
            this.sbPanelServices.Text = this.lvServices.Items.Count + " services";

            // We disable some buttons on the main form
            this.butSaveSystemSnaphotFile.Enabled = Program.Connection.ConnectionType != cConnection.TypeOfConnection.SnapshotFile;
            this.MenuItemSystemSaveSSFile.Enabled = Program.Connection.ConnectionType != cConnection.TypeOfConnection.SnapshotFile;
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void butShowAllPendingTasks_Click(object sender, System.EventArgs e)
    {
        frmPendingTasks frm = new frmPendingTasks();
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void changeTopMost()
    {
        this.butAlwaysDisplay.Checked = !(this.butAlwaysDisplay.Checked);
        this.MenuItemMainAlwaysVisible.Checked = this.butAlwaysDisplay.Checked;
        this.TopMost = this.butAlwaysDisplay.Checked;

        foreach (Form frm in Application.OpenForms)
            frm.TopMost = this.TopMost;
    }

    private void MenuItemShowPendingTasks_Click(object sender, System.EventArgs e)
    {
        butShowAllPendingTasks_Click(null, null);
    }

    private void MenuItemReportProcesses_Click(System.Object sender, System.EventArgs e)
    {
        this.butSaveProcessReport_Click(null, null);
    }

    private void MenuItemReportMonitor_Click(System.Object sender, System.EventArgs e)
    {
        this.butMonitorSaveReport_Click(null, null);
    }

    private void MenuItemReportServices_Click(System.Object sender, System.EventArgs e)
    {
        this.butServiceReport_Click(null, null);
    }

    private void MenuItemNewSearch_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemSearchNew_Click(null, null);
    }

    private void MenuItemReportSearch_Click(System.Object sender, System.EventArgs e)
    {
        this.butSearchSaveReport_Click(null, null);
    }

    private void MenuItemFileOpen_Click(System.Object sender, System.EventArgs e)
    {
        this.butOpenFile_Click(null, null);
    }

    private void MenuItemFileRelease_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileRelease_Click(null, null);
    }

    private void MenuItemFileDelete_Click(System.Object sender, System.EventArgs e)
    {
        this.butDeleteFile_Click(null, null);
    }

    private void MenuItemFileTrash_Click(System.Object sender, System.EventArgs e)
    {
        this.butMoveFileToTrash_Click(null, null);
    }

    private void MenuItemFileRename_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileRename_Click(null, null);
    }

    private void MenuItemFileShellOpen_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileOpen_Click(null, null);
    }

    private void MenuItemFileMove_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileMove_Click(null, null);
    }

    private void MenuItemFileCopy_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileCopy_Click(null, null);
    }

    private void MenuItemFileEncrypt_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileEncrypt_Click(null, null);
    }

    private void MenuItemFileDecrypt_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileDecrypt_Click(null, null);
    }

    private void MenuItemFileStrings_Click(System.Object sender, System.EventArgs e)
    {
        this.butFileSeeStrings_Click(null, null);
    }

    private void butMonitorSaveReport_Click(object sender, System.EventArgs e)
    {
    }

    private void butProcessReduceWS_Click(object sender, System.EventArgs e)
    {
        this.MenuItemProcWorkingSS_Click(null, null);
    }

    private void butProcessDumpF_Click(object sender, System.EventArgs e)
    {
        this.MenuItemProcDump_Click(null, null);
    }

    private void MenuItemNotifAll_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifDS.Checked = true;
        this.MenuItemNotifNS.Checked = true;
        this.MenuItemNotifNP.Checked = true;
        this.MenuItemNotifTP.Checked = true;
        My.MySettingsProperty.Settings.NotifyNewProcesses = true;
        My.MySettingsProperty.Settings.NotifyNewServices = true;
        My.MySettingsProperty.Settings.NotifyDeletedServices = true;
        My.MySettingsProperty.Settings.NotifyTerminatedProcesses = true;
        My.MySettingsProperty.Settings.Save();
    }

    private void MenuItemNotifNone_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifDS.Checked = false;
        this.MenuItemNotifNS.Checked = false;
        this.MenuItemNotifNP.Checked = false;
        this.MenuItemNotifTP.Checked = false;
        My.MySettingsProperty.Settings.NotifyNewProcesses = false;
        My.MySettingsProperty.Settings.NotifyNewServices = false;
        My.MySettingsProperty.Settings.NotifyDeletedServices = false;
        My.MySettingsProperty.Settings.NotifyTerminatedProcesses = false;
        My.MySettingsProperty.Settings.Save();
    }

    private void MenuItemNotifDS_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifDS.Checked = !(this.MenuItemNotifDS.Checked);
        My.MySettingsProperty.Settings.NotifyDeletedServices = this.MenuItemNotifDS.Checked;
        My.MySettingsProperty.Settings.Save();
    }

    private void MenuItemNotifNP_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifNP.Checked = !(this.MenuItemNotifNP.Checked);
        My.MySettingsProperty.Settings.NotifyNewProcesses = this.MenuItemNotifNP.Checked;
        My.MySettingsProperty.Settings.Save();
    }

    private void MenuItemNotifNS_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifNS.Checked = !(this.MenuItemNotifNS.Checked);
        My.MySettingsProperty.Settings.NotifyNewServices = this.MenuItemNotifNS.Checked;
        My.MySettingsProperty.Settings.Save();
    }

    private void MenuItemNotifTP_Click(object sender, System.EventArgs e)
    {
        this.MenuItemNotifTP.Checked = !(this.MenuItemNotifTP.Checked);
        My.MySettingsProperty.Settings.NotifyTerminatedProcesses = this.MenuItemNotifTP.Checked;
        My.MySettingsProperty.Settings.Save();
    }

    private void timerJobs_Tick(System.Object sender, System.EventArgs e)
    {
        this.lvJob.UpdateTheItems();

        if (this.Ribbon != null && this.Ribbon.ActiveTab != null)
        {
            string ss = this.Ribbon.ActiveTab.Text;
            if (ss == "Jobs")
                this.Text = "Yet Another (remote) Process Monitor -- " + System.Convert.ToString(this.lvJob.Items.Count) + " jobs running";
        }
    }

    private void lvJob_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            butJobDetails_Click(null, null);
    }

    private void lvJob_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
            butJobDetails_Click(null, null);
    }

    private void lvJob_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            bool selectionIsNotNothing = (this.lvJob.SelectedItems != null
&& this.lvJob.SelectedItems.Count > 0);
            this.MenuItemJobTerminate.Enabled = selectionIsNotNothing && _notWMI && _notSnapshotMode;
            this.MenuItemCopyJob.Enabled = selectionIsNotNothing;
            this.mnuJob.Show(this.lvJob, e.Location);
        }
    }

    private void MenuItemJobTerminate_Click(object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to terminate these jobs ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cJob cJ in this.lvJob.GetSelectedItems())
            cJ.TerminateJob();
    }

    private void butJobRefresh_Click(object sender, System.EventArgs e)
    {
        this.refreshJobList();
    }

    private void butJobTerminate_Click(object sender, System.EventArgs e)
    {
        MenuItemJobTerminate_Click(null, null);
    }

    private void butJobDetails_Click(object sender, System.EventArgs e)
    {
        foreach (cJob it in this.lvJob.GetSelectedItems())
        {
            frmJobInfo frm = new frmJobInfo();
            frm.SetJob(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemJobMng_Click(object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            cJob theJob = cJob.GetProcessJobById(cp.Infos.ProcessId);
            if (theJob != null)
            {
                frmJobInfo frm = new frmJobInfo();
                frm.SetJob(ref theJob);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
    }

    private void MenuItemProcAddToJob_Click(System.Object sender, System.EventArgs e)
    {
        // Add to job

        // Get list of PIDs
        List<int> pid = new List<int>();
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
            pid.Add(cp.Infos.ProcessId);

        frmAddToJob frm = new frmAddToJob(pid);
        frm.ShowDialog();
    }

    private void MenuItemProcKillByMethod_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            frmKillProcessByMethod frm = new frmKillProcessByMethod();
            frm.ProcessToKill = cp;
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void butJobElevate_Click(object sender, System.EventArgs e)
    {
        // Restart elevated
        cEnvironment.RestartElevated();
    }

    private void lblTaskCountResult_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvTask.Groups[1].Items.Count > 0)
        {
            this.lvTask.Focus();
            this.lvTask.EnsureVisible(this.lvTask.Groups[1].Items[0].Index);
            this.lvTask.SelectedItems.Clear();
            this.lvTask.Groups[1].Items[0].Selected = true;
        }
    }

    private void MenuItemCreateService_Click(System.Object sender, System.EventArgs e)
    {
        frmCreateService frm = new frmCreateService();
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void butCreateService_Click(object sender, System.EventArgs e)
    {
        MenuItemCreateService_Click(null, null);
    }

    private void butDeleteService_Click(object sender, System.EventArgs e)
    {
        if (Misc.WarnDangerousAction("Are you sure you want to delete these services ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;
        foreach (cService it in this.lvServices.GetSelectedItems())
            it.DeleteService();
        this.lvServices_SelectedIndexChanged(null, null);
    }

    private void MenuItemServDelete_Click(System.Object sender, System.EventArgs e)
    {
        butDeleteService_Click(null, null);
    }

    public delegate void NewUpdateAvailableNotification(cUpdate.NewReleaseInfos release);
    public delegate void NoNewUpdateAvailableNotification();
    public delegate void FailedToCheckUpDateNotification(string msg);
    public delegate void GotErrorFromServer(Exception err);


    private void MenuItemTaskSelectWindow_Click(System.Object sender, System.EventArgs e)
    {
        // Select the task's window in the "window tab" of the associated process'
        // detailed form
        // This is a bit tricky, but here is it :
        foreach (cTask it in this.lvTask.GetSelectedItems())
        {

            // Retrieve the associated process
            cProcess _proc = cProcess.GetProcessById(it.Infos.ProcessId);

            if (_proc != null)
            {

                // Open the process' detailed form
                frmProcessInfo frm = new frmProcessInfo();
                frm.SetProcess(ref _proc);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
                // Display 'Windows' tab
                frm.tabProcess.SelectedTab = frm.TabPageWindows;

                // Create a thread which wait for threads to be added in the lvThread
                // and then select the good thread
                System.Threading.ThreadPool.QueueUserWorkItem(selectWindowImp, new contextObjSelectWindow(it.Infos.Handle.ToString(), frm));
            }
        }
    }

    private struct contextObjSelectWindow
    {
        public string handle;
        public frmProcessInfo frmProcInfo;
        public contextObjSelectWindow(string hWnd, frmProcessInfo form)
        {
            handle = hWnd;
            frmProcInfo = form;
        }
    }
    private void selectWindowImp(object context)
    {
        contextObjSelectWindow pObj = (contextObjSelectWindow)context;

        // Wait for windows to be added in the listview
        while (pObj.frmProcInfo.lvWindows.Items.Count == 0)
            System.Threading.Thread.Sleep(50);

        // Select the good window
        Async.ListView.EnsureItemVisible(pObj.frmProcInfo.lvWindows, pObj.handle);
    }


    private void MenuItemNetworkPing_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.Ping);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemNetworkRoute_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.TraceRoute);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemNetworkWhoIs_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cNetwork it in this.lvNetwork.GetSelectedItems())
        {
            frmNetworkTool frm = new frmNetworkTool(it, Native.Api.Enums.ToolType.WhoIs);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void MenuItemSystemNetworkInfos_Click(System.Object sender, System.EventArgs e)
    {
        this.butNetworkInfos_Click(null, null);
    }

    private void MenuItemMainNetworkInfo_Click(System.Object sender, System.EventArgs e)
    {
        this.butNetworkInfos_Click(null, null);
    }

    private void butNetworkInfos_Click(object sender, System.EventArgs e)
    {
        My.MyProject.MyForms.frmNetworkInfo.TopMost = Program._frmMain.TopMost;
        My.MyProject.MyForms.frmNetworkInfo.Show();
    }

    private void MenuItemSystemScripting_Click(System.Object sender, System.EventArgs e)
    {
        this.butScripting_Click(null, null);
    }

    private void butScripting_Click(object sender, System.EventArgs e)
    {
        frmScripting frm = new frmScripting();
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void MenuItemSystemSaveSSFile_Click(System.Object sender, System.EventArgs e)
    {
        this.butSaveSystemSnaphotFile_Click(null, null);
    }

    private void butSaveSystemSnaphotFile_Click(object sender, System.EventArgs e)
    {
        // Save System Snapshot File
        frmSaveSystemSnapshot frm = new frmSaveSystemSnapshot();
        frm.ShowDialog();
    }

    private void MenuItemSystemExploreSSFile_Click(System.Object sender, System.EventArgs e)
    {
        this.butExploreSSFile_Click(null, null);
    }

    private void butExploreSSFile_Click(object sender, System.EventArgs e)
    {
        frmSnapshotInfos frm = new frmSnapshotInfos();
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void MenuItemSystemCheckSignatures_Click(System.Object sender, System.EventArgs e)
    {
        this.butCheckSignatures_Click(null, null);
    }

    private void butCheckSignatures_Click(object sender, System.EventArgs e)
    {
        frmCheckSignatures frm = new frmCheckSignatures();
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void butFreeMemory_Click(object sender, System.EventArgs e)
    {
        // Calls the garbage collector
        Program.CollectGarbage();
    }
}
