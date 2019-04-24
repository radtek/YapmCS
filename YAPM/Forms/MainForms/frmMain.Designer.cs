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

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
partial class frmMain : System.Windows.Forms.Form
{

    // Form remplace la méthode Dispose pour nettoyer la liste des composants.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
                components.Dispose();
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    // Requise par le Concepteur Windows Form
    private System.ComponentModel.IContainer components;

    // REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    // Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    // Ne la modifiez pas à l'aide de l'éditeur de code.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        cConnection CConnection1 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Tasks", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.TreeNode TreeNode1 = new System.Windows.Forms.TreeNode("System");
        System.Windows.Forms.TreeNode TreeNode2 = new System.Windows.Forms.TreeNode("[System process]", new System.Windows.Forms.TreeNode[] { TreeNode1 });
        cConnection CConnection2 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup3 = new System.Windows.Forms.ListViewGroup("Processes", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup4 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        cConnection CConnection3 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup5 = new System.Windows.Forms.ListViewGroup("Tasks", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup6 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.TreeNode TreeNode3 = new System.Windows.Forms.TreeNode("Items", 1, 1);
        cConnection CConnection4 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup7 = new System.Windows.Forms.ListViewGroup("Services", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup8 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        cConnection CConnection5 = new cConnection();
        cConnection CConnection6 = new cConnection();
        cConnection CConnection7 = new cConnection();
        cConnection CConnection8 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup9 = new System.Windows.Forms.ListViewGroup("Results", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup10 = new System.Windows.Forms.ListViewGroup("Search results", System.Windows.Forms.HorizontalAlignment.Left);
        this.timerProcess = new System.Windows.Forms.Timer(this.components);
        this.imgServices = new System.Windows.Forms.ImageList(this.components);
        this.timerServices = new System.Windows.Forms.Timer(this.components);
        this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
        this.EnableServiceRefreshingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.saveDial = new System.Windows.Forms.SaveFileDialog();
        this.openDial = new System.Windows.Forms.OpenFileDialog();
        this.Ribbon = new System.Windows.Forms.Ribbon();
        this.orbStartElevated = new System.Windows.Forms.RibbonOrbMenuItem();
        this.orbMenuNetwork = new System.Windows.Forms.RibbonOrbMenuItem();
        this.RibbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
        this.orbMenuEmergency = new System.Windows.Forms.RibbonOrbMenuItem();
        this.orbMenuSBA = new System.Windows.Forms.RibbonOrbMenuItem();
        this.RibbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
        this.orbMenuSaveReport = new System.Windows.Forms.RibbonOrbMenuItem();
        this.RibbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
        this.orbMenuAbout = new System.Windows.Forms.RibbonOrbMenuItem();
        this.butExit = new System.Windows.Forms.RibbonOrbOptionButton();
        this.butShowPreferences = new System.Windows.Forms.RibbonOrbOptionButton();
        this.butLog = new System.Windows.Forms.RibbonButton();
        this.butSystemInfo = new System.Windows.Forms.RibbonButton();
        this.butWindows = new System.Windows.Forms.RibbonButton();
        this.butFindWindow = new System.Windows.Forms.RibbonButton();
        this.butNetwork = new System.Windows.Forms.RibbonButton();
        this.butFeedBack = new System.Windows.Forms.RibbonButton();
        this.butHiddenProcesses = new System.Windows.Forms.RibbonButton();
        this.butShowDepViewer = new System.Windows.Forms.RibbonButton();
        this.butShowAllPendingTasks = new System.Windows.Forms.RibbonButton();
        this.butCreateService = new System.Windows.Forms.RibbonButton();
        this.butNetworkInfos = new System.Windows.Forms.RibbonButton();
        this.butScripting = new System.Windows.Forms.RibbonButton();
        this.butSaveSystemSnaphotFile = new System.Windows.Forms.RibbonButton();
        this.butExploreSSFile = new System.Windows.Forms.RibbonButton();
        this.butCheckSignatures = new System.Windows.Forms.RibbonButton();
        this.TaskTab = new System.Windows.Forms.RibbonTab();
        this.RBTaskDisplay = new System.Windows.Forms.RibbonPanel();
        this.butTaskRefresh = new System.Windows.Forms.RibbonButton();
        this.RBTaskActions = new System.Windows.Forms.RibbonPanel();
        this.butTaskShow = new System.Windows.Forms.RibbonButton();
        this.butTaskEndTask = new System.Windows.Forms.RibbonButton();
        this.ProcessTab = new System.Windows.Forms.RibbonTab();
        this.RBProcessDisplay = new System.Windows.Forms.RibbonPanel();
        this.butProcessRerfresh = new System.Windows.Forms.RibbonButton();
        this.butProcessDisplayDetails = new System.Windows.Forms.RibbonButton();
        this.RBProcessActions = new System.Windows.Forms.RibbonPanel();
        this.butNewProcess = new System.Windows.Forms.RibbonButton();
        this.butKillProcess = new System.Windows.Forms.RibbonButton();
        this.butStopProcess = new System.Windows.Forms.RibbonButton();
        this.butResumeProcess = new System.Windows.Forms.RibbonButton();
        this.butProcessOtherActions = new System.Windows.Forms.RibbonButton();
        this.butProcessAffinity = new System.Windows.Forms.RibbonButton();
        this.butProcessReduceWS = new System.Windows.Forms.RibbonButton();
        this.butProcessDumpF = new System.Windows.Forms.RibbonButton();
        this.butProcessLimitCPU = new System.Windows.Forms.RibbonButton();
        this.RBProcessPriority = new System.Windows.Forms.RibbonPanel();
        this.butProcessPriority = new System.Windows.Forms.RibbonButton();
        this.butIdle = new System.Windows.Forms.RibbonButton();
        this.butBelowNormal = new System.Windows.Forms.RibbonButton();
        this.butNormal = new System.Windows.Forms.RibbonButton();
        this.butAboveNormal = new System.Windows.Forms.RibbonButton();
        this.butHigh = new System.Windows.Forms.RibbonButton();
        this.butRealTime = new System.Windows.Forms.RibbonButton();
        this.RBProcessOnline = new System.Windows.Forms.RibbonPanel();
        this.butProcessGoogle = new System.Windows.Forms.RibbonButton();
        this.panelProcessReport = new System.Windows.Forms.RibbonPanel();
        this.butSaveProcessReport = new System.Windows.Forms.RibbonButton();
        this.JobTab = new System.Windows.Forms.RibbonTab();
        this.RBJobDisplay = new System.Windows.Forms.RibbonPanel();
        this.butJobRefresh = new System.Windows.Forms.RibbonButton();
        this.butJobDetails = new System.Windows.Forms.RibbonButton();
        this.RBJobActions = new System.Windows.Forms.RibbonPanel();
        this.butJobTerminate = new System.Windows.Forms.RibbonButton();
        this.RBJobPrivileges = new System.Windows.Forms.RibbonPanel();
        this.butJobElevate = new System.Windows.Forms.RibbonButton();
        this.MonitorTab = new System.Windows.Forms.RibbonTab();
        this.RBMonitor = new System.Windows.Forms.RibbonPanel();
        this.butMonitoringAdd = new System.Windows.Forms.RibbonButton();
        this.butMonitoringRemove = new System.Windows.Forms.RibbonButton();
        this.RBMonitoringControl = new System.Windows.Forms.RibbonPanel();
        this.butMonitorStart = new System.Windows.Forms.RibbonButton();
        this.butMonitorStop = new System.Windows.Forms.RibbonButton();
        this.butSaveMonitorReport = new System.Windows.Forms.RibbonPanel();
        this.butMonitorSaveReport = new System.Windows.Forms.RibbonButton();
        this.ServiceTab = new System.Windows.Forms.RibbonTab();
        this.RBServiceDisplay = new System.Windows.Forms.RibbonPanel();
        this.butServiceRefresh = new System.Windows.Forms.RibbonButton();
        this.butServiceDetails = new System.Windows.Forms.RibbonButton();
        this.RBServiceAction = new System.Windows.Forms.RibbonPanel();
        this.butStopService = new System.Windows.Forms.RibbonButton();
        this.butStartService = new System.Windows.Forms.RibbonButton();
        this.RibbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
        this.butPauseService = new System.Windows.Forms.RibbonButton();
        this.butResumeService = new System.Windows.Forms.RibbonButton();
        this.RibbonSeparator6 = new System.Windows.Forms.RibbonSeparator();
        this.butDeleteService = new System.Windows.Forms.RibbonButton();
        this.RibbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
        this.RBServiceStartType = new System.Windows.Forms.RibbonPanel();
        this.butServiceStartType = new System.Windows.Forms.RibbonButton();
        this.butAutomaticStart = new System.Windows.Forms.RibbonButton();
        this.butOnDemandStart = new System.Windows.Forms.RibbonButton();
        this.butDisabledStart = new System.Windows.Forms.RibbonButton();
        this.RBServiceFile = new System.Windows.Forms.RibbonPanel();
        this.butServiceFileProp = new System.Windows.Forms.RibbonButton();
        this.butServiceOpenDir = new System.Windows.Forms.RibbonButton();
        this.butServiceFileDetails = new System.Windows.Forms.RibbonButton();
        this.RBServiceOnline = new System.Windows.Forms.RibbonPanel();
        this.butServiceGoogle = new System.Windows.Forms.RibbonButton();
        this.RBServiceReport = new System.Windows.Forms.RibbonPanel();
        this.butServiceReport = new System.Windows.Forms.RibbonButton();
        this.NetworkTab = new System.Windows.Forms.RibbonTab();
        this.RBNetworkRefresh = new System.Windows.Forms.RibbonPanel();
        this.butNetworkRefresh = new System.Windows.Forms.RibbonButton();
        this.FileTab = new System.Windows.Forms.RibbonTab();
        this.RBFileOpenFile = new System.Windows.Forms.RibbonPanel();
        this.butOpenFile = new System.Windows.Forms.RibbonButton();
        this.butFileRefresh = new System.Windows.Forms.RibbonButton();
        this.RBFileKillProcess = new System.Windows.Forms.RibbonPanel();
        this.butFileRelease = new System.Windows.Forms.RibbonButton();
        this.RBFileDelete = new System.Windows.Forms.RibbonPanel();
        this.butMoveFileToTrash = new System.Windows.Forms.RibbonButton();
        this.butDeleteFile = new System.Windows.Forms.RibbonButton();
        this.RBFileOnline = new System.Windows.Forms.RibbonPanel();
        this.butFileGoogleSearch = new System.Windows.Forms.RibbonButton();
        this.RBFileOther = new System.Windows.Forms.RibbonPanel();
        this.butFileProperties = new System.Windows.Forms.RibbonButton();
        this.butFileOpenDir = new System.Windows.Forms.RibbonButton();
        this.butFileShowFolderProperties = new System.Windows.Forms.RibbonButton();
        this.RBFileOthers = new System.Windows.Forms.RibbonPanel();
        this.butFileOthersActions = new System.Windows.Forms.RibbonButton();
        this.sepFile1 = new System.Windows.Forms.RibbonSeparator();
        this.butFileRename = new System.Windows.Forms.RibbonButton();
        this.butFileCopy = new System.Windows.Forms.RibbonButton();
        this.butFileMove = new System.Windows.Forms.RibbonButton();
        this.butFileOpen = new System.Windows.Forms.RibbonButton();
        this.sepFile2 = new System.Windows.Forms.RibbonSeparator();
        this.butFileSeeStrings = new System.Windows.Forms.RibbonButton();
        this.sepFile3 = new System.Windows.Forms.RibbonSeparator();
        this.butFileEncrypt = new System.Windows.Forms.RibbonButton();
        this.butFileDecrypt = new System.Windows.Forms.RibbonButton();
        this.SearchTab = new System.Windows.Forms.RibbonTab();
        this.RBSearchMain = new System.Windows.Forms.RibbonPanel();
        this.butSearchGo = new System.Windows.Forms.RibbonButton();
        this.butSearchSaveReport = new System.Windows.Forms.RibbonButton();
        this.txtSearchString = new System.Windows.Forms.RibbonTextBox();
        this.HelpTab = new System.Windows.Forms.RibbonTab();
        this.RBUpdate = new System.Windows.Forms.RibbonPanel();
        this.butUpdate = new System.Windows.Forms.RibbonButton();
        this.RBHelpAction = new System.Windows.Forms.RibbonPanel();
        this.butDonate = new System.Windows.Forms.RibbonButton();
        this.butAbout = new System.Windows.Forms.RibbonButton();
        this.RBHelpWeb = new System.Windows.Forms.RibbonPanel();
        this.butWebite = new System.Windows.Forms.RibbonButton();
        this.butProjectPage = new System.Windows.Forms.RibbonButton();
        this.butDownload = new System.Windows.Forms.RibbonButton();
        this.RBOptions = new System.Windows.Forms.RibbonPanel();
        this.butPreferences = new System.Windows.Forms.RibbonButton();
        this.butAlwaysDisplay = new System.Windows.Forms.RibbonButton();
        this.imgMonitor = new System.Windows.Forms.ImageList(this.components);
        this.timerMonitoring = new System.Windows.Forms.Timer(this.components);
        this.FolderChooser = new System.Windows.Forms.FolderBrowserDialog();
        this.timerTask = new System.Windows.Forms.Timer(this.components);
        this.timerTrayIcon = new System.Windows.Forms.Timer(this.components);
        this._main = new System.Windows.Forms.SplitContainer();
        this.containerSystemMenu = new System.Windows.Forms.SplitContainer();
        this._tab = new System.Windows.Forms.TabControl();
        this.pageTasks = new System.Windows.Forms.TabPage();
        this.panelMain13 = new System.Windows.Forms.Panel();
        this.SplitContainerTask = new System.Windows.Forms.SplitContainer();
        this.Label19 = new System.Windows.Forms.Label();
        this.lblTaskCountResult = new System.Windows.Forms.Label();
        this.txtSearchTask = new System.Windows.Forms.TextBox();
        this.lvTask = new taskList();
        this.ColumnHeader62 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader63 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader64 = new System.Windows.Forms.ColumnHeader();
        this.pageProcesses = new System.Windows.Forms.TabPage();
        this.containerProcessPage = new System.Windows.Forms.SplitContainer();
        this.panelMenu = new System.Windows.Forms.Panel();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblResCount = new System.Windows.Forms.Label();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.panelMain = new System.Windows.Forms.Panel();
        this.SplitContainerProcess = new System.Windows.Forms.SplitContainer();
        this.SplitContainerTvLv = new System.Windows.Forms.SplitContainer();
        this.tvProc = new System.Windows.Forms.TreeView();
        this.lvProcess = new processList();
        this.c1 = new System.Windows.Forms.ColumnHeader();
        this.c2 = new System.Windows.Forms.ColumnHeader();
        this.c3 = new System.Windows.Forms.ColumnHeader();
        this.c4 = new System.Windows.Forms.ColumnHeader();
        this.c5 = new System.Windows.Forms.ColumnHeader();
        this.c7 = new System.Windows.Forms.ColumnHeader();
        this.c8 = new System.Windows.Forms.ColumnHeader();
        this.c9 = new System.Windows.Forms.ColumnHeader();
        this.c10 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.pageJobs = new System.Windows.Forms.TabPage();
        this.panelMain12 = new System.Windows.Forms.Panel();
        this.lvJob = new jobList();
        this.ColumnHeader50 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.pageMonitor = new System.Windows.Forms.TabPage();
        this.panelMain8 = new System.Windows.Forms.Panel();
        this.splitMonitor = new System.Windows.Forms.SplitContainer();
        this.tvMonitor = new System.Windows.Forms.TreeView();
        this.splitMonitor2 = new System.Windows.Forms.SplitContainer();
        this.txtMonitoringLog = new System.Windows.Forms.TextBox();
        this.lvMonitorReport = new DoubleBufferedLV();
        this.ColumnHeader22 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader23 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader47 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader48 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader49 = new System.Windows.Forms.ColumnHeader();
        this.splitMonitor3 = new System.Windows.Forms.SplitContainer();
        this.splitMonitor4 = new System.Windows.Forms.SplitContainer();
        this.graphMonitor = new Graph();
        this.txtMonitorNumber = new System.Windows.Forms.TextBox();
        this.lblMonitorMaxNumber = new System.Windows.Forms.Label();
        this.chkMonitorRightAuto = new System.Windows.Forms.CheckBox();
        this.chkMonitorLeftAuto = new System.Windows.Forms.CheckBox();
        this.dtMonitorR = new System.Windows.Forms.DateTimePicker();
        this.dtMonitorL = new System.Windows.Forms.DateTimePicker();
        this.pageServices = new System.Windows.Forms.TabPage();
        this.containerServicesPage = new System.Windows.Forms.SplitContainer();
        this.panelMenu2 = new System.Windows.Forms.Panel();
        this.Label2 = new System.Windows.Forms.Label();
        this.lblResCount2 = new System.Windows.Forms.Label();
        this.txtServiceSearch = new System.Windows.Forms.TextBox();
        this.panelMain2 = new System.Windows.Forms.Panel();
        this.splitServices = new System.Windows.Forms.SplitContainer();
        this.lvServices = new serviceList();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader10 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
        this.splitServices2 = new System.Windows.Forms.SplitContainer();
        this.cmdCopyServiceToCp = new System.Windows.Forms.Button();
        this.lblServicePath = new System.Windows.Forms.TextBox();
        this.lblServiceName = new System.Windows.Forms.Label();
        this.splitServices3 = new System.Windows.Forms.SplitContainer();
        this.rtb2 = new System.Windows.Forms.RichTextBox();
        this.splitServices4 = new System.Windows.Forms.SplitContainer();
        this.tv2 = new serviceDependenciesList();
        this.tv = new serviceDependenciesList();
        this.pageNetwork = new System.Windows.Forms.TabPage();
        this.panelMain14 = new System.Windows.Forms.Panel();
        this.lvNetwork = new networkList();
        this.ColumnHeader66 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader67 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader68 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader69 = new System.Windows.Forms.ColumnHeader();
        this.pageFile = new System.Windows.Forms.TabPage();
        this.panelMain5 = new System.Windows.Forms.Panel();
        this.SplitContainerFilexx = new System.Windows.Forms.SplitContainer();
        this.txtFile = new System.Windows.Forms.TextBox();
        this.cmdFileClipboard = new System.Windows.Forms.Button();
        this.pctFileSmall = new System.Windows.Forms.PictureBox();
        this.pctFileBig = new System.Windows.Forms.PictureBox();
        this.SplitContainerFile = new System.Windows.Forms.SplitContainer();
        this.SplitContainerFile2 = new System.Windows.Forms.SplitContainer();
        this.rtb3 = new System.Windows.Forms.RichTextBox();
        this.gpFileAttributes = new System.Windows.Forms.GroupBox();
        this.chkFileEncrypted = new System.Windows.Forms.CheckBox();
        this.chkFileContentNotIndexed = new System.Windows.Forms.CheckBox();
        this.chkFileNormal = new System.Windows.Forms.CheckBox();
        this.chkFileSystem = new System.Windows.Forms.CheckBox();
        this.chkFileReadOnly = new System.Windows.Forms.CheckBox();
        this.chkFileHidden = new System.Windows.Forms.CheckBox();
        this.chkFileCompressed = new System.Windows.Forms.CheckBox();
        this.chkFileArchive = new System.Windows.Forms.CheckBox();
        this.gpFileDates = new System.Windows.Forms.GroupBox();
        this.cmdSetFileDates = new System.Windows.Forms.Button();
        this.DTlastModification = new System.Windows.Forms.DateTimePicker();
        this.DTlastAccess = new System.Windows.Forms.DateTimePicker();
        this.DTcreation = new System.Windows.Forms.DateTimePicker();
        this.Label6 = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.lvFileString = new DoubleBufferedLV();
        this.headerString = new System.Windows.Forms.ColumnHeader();
        this.pageSearch = new System.Windows.Forms.TabPage();
        this.panelMain6 = new System.Windows.Forms.Panel();
        this.SplitContainerSearch = new System.Windows.Forms.SplitContainer();
        this.chkSearchEnvVar = new System.Windows.Forms.CheckBox();
        this.Label11 = new System.Windows.Forms.Label();
        this.lblResultsCount = new System.Windows.Forms.Label();
        this.txtSearchResults = new System.Windows.Forms.TextBox();
        this.chkSearchWindows = new System.Windows.Forms.CheckBox();
        this.chkSearchHandles = new System.Windows.Forms.CheckBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.chkSearchModules = new System.Windows.Forms.CheckBox();
        this.chkSearchServices = new System.Windows.Forms.CheckBox();
        this.chkSearchProcess = new System.Windows.Forms.CheckBox();
        this.chkSearchCase = new System.Windows.Forms.CheckBox();
        this.lvSearchResults = new searchList();
        this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader17 = new System.Windows.Forms.ColumnHeader();
        this.pageHelp = new System.Windows.Forms.TabPage();
        this.panelMain4 = new System.Windows.Forms.Panel();
        this.WBHelp = new System.Windows.Forms.WebBrowser();
        this.timerNetwork = new System.Windows.Forms.Timer(this.components);
        this.timerStateBasedActions = new System.Windows.Forms.Timer(this.components);
        this.MenuItemTaskShow = new System.Windows.Forms.MenuItem();
        this.MenuItemTaskEnd = new System.Windows.Forms.MenuItem();
        this.MenuItemTaskSelProc = new System.Windows.Forms.MenuItem();
        this.MenuItemMonitorAdd = new System.Windows.Forms.MenuItem();
        this.MenuItemMonitorRemove = new System.Windows.Forms.MenuItem();
        this.MenuItemMonitorStart = new System.Windows.Forms.MenuItem();
        this.MenuItemMonitorStop = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyBig = new System.Windows.Forms.MenuItem();
        this.MenuItemCopySmall = new System.Windows.Forms.MenuItem();
        this.MenuItemMainShow = new System.Windows.Forms.MenuItem();
        this.MenuItemMainToTray = new System.Windows.Forms.MenuItem();
        this.MenuItemMainAbout = new System.Windows.Forms.MenuItem();
        this.MenuItemMainLog = new System.Windows.Forms.MenuItem();
        this.MenuItemMainOpenedW = new System.Windows.Forms.MenuItem();
        this.MenuItemMainExit = new System.Windows.Forms.MenuItem();
        this.MenuItemMainSysInfo = new System.Windows.Forms.MenuItem();
        this.MenuItemServSelService = new System.Windows.Forms.MenuItem();
        this.MenuItemServFileProp = new System.Windows.Forms.MenuItem();
        this.MenuItemServOpenDir = new System.Windows.Forms.MenuItem();
        this.MenuItemServFileDetails = new System.Windows.Forms.MenuItem();
        this.MenuItemServSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemServPause = new System.Windows.Forms.MenuItem();
        this.MenuItemServStop = new System.Windows.Forms.MenuItem();
        this.MenuItemServStart = new System.Windows.Forms.MenuItem();
        this.MenuItemServAutoStart = new System.Windows.Forms.MenuItem();
        this.MenuItemServOnDemand = new System.Windows.Forms.MenuItem();
        this.MenuItemServDisabled = new System.Windows.Forms.MenuItem();
        this.MenuItemServDepe = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkClose = new System.Windows.Forms.MenuItem();
        this.MenuItemServSelProc = new System.Windows.Forms.MenuItem();
        this.MenuItemSearchSel = new System.Windows.Forms.MenuItem();
        this.MenuItemSearchClose = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSFileProp = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSOpenDir = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSFileDetails = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSDep = new System.Windows.Forms.MenuItem();
        this.MenuItemProcKill = new System.Windows.Forms.MenuItem();
        this.MenuItemProcKillT = new System.Windows.Forms.MenuItem();
        this.MenuItemProcStop = new System.Windows.Forms.MenuItem();
        this.MenuItemProcResume = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPIdle = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPBN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPAN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPH = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPRT = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemRefresh = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemLog = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemInfos = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemOpenedWindows = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemToTray = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemExit = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemUpdate = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemWebsite = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemAbout = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemFindWindow = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemHelp = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemOptions = new System.Windows.Forms.MenuItem();
        this.MenuItemMainFindWindow = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyTask = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyService = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyNetwork = new System.Windows.Forms.MenuItem();
        this.MenuItemCopySearch = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyProcess = new System.Windows.Forms.MenuItem();
        this.mnuTask = new System.Windows.Forms.ContextMenu();
        this.MenuItemTaskMax = new System.Windows.Forms.MenuItem();
        this.MenuItemTaskMin = new System.Windows.Forms.MenuItem();
        this.MenuItem4 = new System.Windows.Forms.MenuItem();
        this.MenuItem6 = new System.Windows.Forms.MenuItem();
        this.MenuItemTaskSelectWindow = new System.Windows.Forms.MenuItem();
        this.MenuItem9 = new System.Windows.Forms.MenuItem();
        this.MenuItemTaskColumns = new System.Windows.Forms.MenuItem();
        this.mnuMonitor = new System.Windows.Forms.ContextMenu();
        this.MenuItem1 = new System.Windows.Forms.MenuItem();
        this.mnuFileCpPctBig = new System.Windows.Forms.ContextMenu();
        this.mnuFileCpPctSmall = new System.Windows.Forms.ContextMenu();
        this.mnuMain = new System.Windows.Forms.ContextMenu();
        this.MenuItemMainAlwaysVisible = new System.Windows.Forms.MenuItem();
        this.MenuItem29 = new System.Windows.Forms.MenuItem();
        this.MenuItem31 = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifNP = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifTP = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifNS = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifDS = new System.Windows.Forms.MenuItem();
        this.MenuItem46 = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifAll = new System.Windows.Forms.MenuItem();
        this.MenuItemNotifNone = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.MenuItemMainRestart = new System.Windows.Forms.MenuItem();
        this.MenuItemMainShutdown = new System.Windows.Forms.MenuItem();
        this.MenuItemMainPowerOff = new System.Windows.Forms.MenuItem();
        this.MenuItem11 = new System.Windows.Forms.MenuItem();
        this.MenuItemMainSleep = new System.Windows.Forms.MenuItem();
        this.MenuItemMainHibernate = new System.Windows.Forms.MenuItem();
        this.MenuItem17 = new System.Windows.Forms.MenuItem();
        this.MenuItemMainLogOff = new System.Windows.Forms.MenuItem();
        this.MenuItemMainLock = new System.Windows.Forms.MenuItem();
        this.MenuItem5 = new System.Windows.Forms.MenuItem();
        this.MenuItemMainReport = new System.Windows.Forms.MenuItem();
        this.MenuItemMainNetworkInfo = new System.Windows.Forms.MenuItem();
        this.MenuItemMainEmergencyH = new System.Windows.Forms.MenuItem();
        this.MenuItemMainSBA = new System.Windows.Forms.MenuItem();
        this.MenuItem15 = new System.Windows.Forms.MenuItem();
        this.MenuItemRefProc = new System.Windows.Forms.MenuItem();
        this.MenuItemMainRefServ = new System.Windows.Forms.MenuItem();
        this.MenuItem18 = new System.Windows.Forms.MenuItem();
        this.mnuService = new System.Windows.Forms.ContextMenu();
        this.MenuItem7 = new System.Windows.Forms.MenuItem();
        this.MenuItem20 = new System.Windows.Forms.MenuItem();
        this.MenuItemServStartType = new System.Windows.Forms.MenuItem();
        this.MenuItemServDelete = new System.Windows.Forms.MenuItem();
        this.MenuItem25 = new System.Windows.Forms.MenuItem();
        this.MenuItemServReanalize = new System.Windows.Forms.MenuItem();
        this.MenuItem24 = new System.Windows.Forms.MenuItem();
        this.MenuItemServColumns = new System.Windows.Forms.MenuItem();
        this.mnuNetwork = new System.Windows.Forms.ContextMenu();
        this.MenuItem16 = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkTools = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkPing = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkRoute = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkWhoIs = new System.Windows.Forms.MenuItem();
        this.MenuItem10 = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkColumns = new System.Windows.Forms.MenuItem();
        this.mnuSearch = new System.Windows.Forms.ContextMenu();
        this.MenuItemSearchNew = new System.Windows.Forms.MenuItem();
        this.MenuItem28 = new System.Windows.Forms.MenuItem();
        this.MenuItem30 = new System.Windows.Forms.MenuItem();
        this.mnuProcess = new System.Windows.Forms.ContextMenu();
        this.MenuItemProcKillByMethod = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPriority = new System.Windows.Forms.MenuItem();
        this.MenuItem44 = new System.Windows.Forms.MenuItem();
        this.MenuItemProcReanalize = new System.Windows.Forms.MenuItem();
        this.MenuItemProcOther = new System.Windows.Forms.MenuItem();
        this.MenuItemProcWSS = new System.Windows.Forms.MenuItem();
        this.MenuItemProcAff = new System.Windows.Forms.MenuItem();
        this.MenuItemProcDump = new System.Windows.Forms.MenuItem();
        this.MenuItemProcJob = new System.Windows.Forms.MenuItem();
        this.MenuItemProcAddToJob = new System.Windows.Forms.MenuItem();
        this.MenuItem33 = new System.Windows.Forms.MenuItem();
        this.MenuItemJobMng = new System.Windows.Forms.MenuItem();
        this.MenuItem51 = new System.Windows.Forms.MenuItem();
        this.MenuItem38 = new System.Windows.Forms.MenuItem();
        this.MenuItemProcColumns = new System.Windows.Forms.MenuItem();
        this.mnuSystem = new System.Windows.Forms.MainMenu(this.components);
        this.MenuItemSYSTEMFILE = new System.Windows.Forms.MenuItem();
        this.MenuItem54 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemConnection = new System.Windows.Forms.MenuItem();
        this.MenuItemRunAsAdmin = new System.Windows.Forms.MenuItem();
        this.MenuItem56 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemReport = new System.Windows.Forms.MenuItem();
        this.MenuItem59 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemNetworkInfos = new System.Windows.Forms.MenuItem();
        this.MenuItemShowPendingTasks = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemScripting = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemSaveSSFile = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemExploreSSFile = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemCheckSignatures = new System.Windows.Forms.MenuItem();
        this.MenuItem62 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemEmergency = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemSBA = new System.Windows.Forms.MenuItem();
        this.MenuItem66 = new System.Windows.Forms.MenuItem();
        this.MenuItemProcesses = new System.Windows.Forms.MenuItem();
        this.MenuItemReportProcesses = new System.Windows.Forms.MenuItem();
        this.MenuItemJobs = new System.Windows.Forms.MenuItem();
        this.MenuItemMonitor = new System.Windows.Forms.MenuItem();
        this.MenuItemReportMonitor = new System.Windows.Forms.MenuItem();
        this.MenuItemServices = new System.Windows.Forms.MenuItem();
        this.MenuItemReportServices = new System.Windows.Forms.MenuItem();
        this.MenuItemSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemNewSearch = new System.Windows.Forms.MenuItem();
        this.MenuItem61 = new System.Windows.Forms.MenuItem();
        this.MenuItemReportSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemFiles = new System.Windows.Forms.MenuItem();
        this.MenuItemFileOpen = new System.Windows.Forms.MenuItem();
        this.MenuItem68 = new System.Windows.Forms.MenuItem();
        this.MenuItemFileRelease = new System.Windows.Forms.MenuItem();
        this.MenuItemFileDelete = new System.Windows.Forms.MenuItem();
        this.MenuItemFileTrash = new System.Windows.Forms.MenuItem();
        this.MenuItem72 = new System.Windows.Forms.MenuItem();
        this.MenuItemFileRename = new System.Windows.Forms.MenuItem();
        this.MenuItemFileShellOpen = new System.Windows.Forms.MenuItem();
        this.MenuItemFileMove = new System.Windows.Forms.MenuItem();
        this.MenuItemFileCopy = new System.Windows.Forms.MenuItem();
        this.MenuItem77 = new System.Windows.Forms.MenuItem();
        this.MenuItemFileEncrypt = new System.Windows.Forms.MenuItem();
        this.MenuItemFileDecrypt = new System.Windows.Forms.MenuItem();
        this.MenuItem80 = new System.Windows.Forms.MenuItem();
        this.MenuItemFileStrings = new System.Windows.Forms.MenuItem();
        this.MenuItemSYSTEMOPT = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemAlwaysVisible = new System.Windows.Forms.MenuItem();
        this.MenuItem37 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemRefProc = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemRefServ = new System.Windows.Forms.MenuItem();
        this.MenuItem42 = new System.Windows.Forms.MenuItem();
        this.MenuItemSYSTEMTOOLS = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemShowHidden = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemDependency = new System.Windows.Forms.MenuItem();
        this.MenuItemCreateService = new System.Windows.Forms.MenuItem();
        this.MenuItemSYSTEMSYSTEM = new System.Windows.Forms.MenuItem();
        this.MenuItem34 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemRestart = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemShutdown = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemPowerOff = new System.Windows.Forms.MenuItem();
        this.MenuItem40 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemSleep = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemHIbernate = new System.Windows.Forms.MenuItem();
        this.MenuItem43 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemLogoff = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemLock = new System.Windows.Forms.MenuItem();
        this.MenuItemSYSTEMHEL = new System.Windows.Forms.MenuItem();
        this.MenuItem39 = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemDonation = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemFeedBack = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemSF = new System.Windows.Forms.MenuItem();
        this.MenuItemSystemDownloads = new System.Windows.Forms.MenuItem();
        this.MenuItem49 = new System.Windows.Forms.MenuItem();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemJobTerminate = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyJob = new System.Windows.Forms.MenuItem();
        this.StatusBar = new System.Windows.Forms.StatusBar();
        this.sbPanelConnection = new System.Windows.Forms.StatusBarPanel();
        this.sbPanelProcesses = new System.Windows.Forms.StatusBarPanel();
        this.sbPanelServices = new System.Windows.Forms.StatusBarPanel();
        this.sbPanelCpu = new System.Windows.Forms.StatusBarPanel();
        this.sbPanelMemory = new System.Windows.Forms.StatusBarPanel();
        this.timerStatus = new System.Windows.Forms.Timer(this.components);
        this.timerJobs = new System.Windows.Forms.Timer(this.components);
        this.mnuJob = new System.Windows.Forms.ContextMenu();
        this.MenuItem53 = new System.Windows.Forms.MenuItem();
        this.butFreeMemory = new System.Windows.Forms.RibbonOrbOptionButton();
        this._main.Panel1.SuspendLayout();
        this._main.Panel2.SuspendLayout();
        this._main.SuspendLayout();
        this.containerSystemMenu.Panel2.SuspendLayout();
        this.containerSystemMenu.SuspendLayout();
        this._tab.SuspendLayout();
        this.pageTasks.SuspendLayout();
        this.panelMain13.SuspendLayout();
        this.SplitContainerTask.Panel1.SuspendLayout();
        this.SplitContainerTask.Panel2.SuspendLayout();
        this.SplitContainerTask.SuspendLayout();
        this.pageProcesses.SuspendLayout();
        this.containerProcessPage.Panel1.SuspendLayout();
        this.containerProcessPage.Panel2.SuspendLayout();
        this.containerProcessPage.SuspendLayout();
        this.panelMenu.SuspendLayout();
        this.panelMain.SuspendLayout();
        this.SplitContainerProcess.Panel1.SuspendLayout();
        this.SplitContainerProcess.SuspendLayout();
        this.SplitContainerTvLv.Panel1.SuspendLayout();
        this.SplitContainerTvLv.Panel2.SuspendLayout();
        this.SplitContainerTvLv.SuspendLayout();
        this.pageJobs.SuspendLayout();
        this.panelMain12.SuspendLayout();
        this.pageMonitor.SuspendLayout();
        this.panelMain8.SuspendLayout();
        this.splitMonitor.Panel1.SuspendLayout();
        this.splitMonitor.Panel2.SuspendLayout();
        this.splitMonitor.SuspendLayout();
        this.splitMonitor2.Panel1.SuspendLayout();
        this.splitMonitor2.Panel2.SuspendLayout();
        this.splitMonitor2.SuspendLayout();
        this.splitMonitor3.Panel1.SuspendLayout();
        this.splitMonitor3.Panel2.SuspendLayout();
        this.splitMonitor3.SuspendLayout();
        this.splitMonitor4.Panel2.SuspendLayout();
        this.splitMonitor4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.graphMonitor).BeginInit();
        this.pageServices.SuspendLayout();
        this.containerServicesPage.Panel1.SuspendLayout();
        this.containerServicesPage.Panel2.SuspendLayout();
        this.containerServicesPage.SuspendLayout();
        this.panelMenu2.SuspendLayout();
        this.panelMain2.SuspendLayout();
        this.splitServices.Panel1.SuspendLayout();
        this.splitServices.Panel2.SuspendLayout();
        this.splitServices.SuspendLayout();
        this.splitServices2.Panel1.SuspendLayout();
        this.splitServices2.Panel2.SuspendLayout();
        this.splitServices2.SuspendLayout();
        this.splitServices3.Panel1.SuspendLayout();
        this.splitServices3.Panel2.SuspendLayout();
        this.splitServices3.SuspendLayout();
        this.splitServices4.Panel1.SuspendLayout();
        this.splitServices4.Panel2.SuspendLayout();
        this.splitServices4.SuspendLayout();
        this.pageNetwork.SuspendLayout();
        this.panelMain14.SuspendLayout();
        this.pageFile.SuspendLayout();
        this.panelMain5.SuspendLayout();
        this.SplitContainerFilexx.Panel1.SuspendLayout();
        this.SplitContainerFilexx.Panel2.SuspendLayout();
        this.SplitContainerFilexx.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctFileSmall).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pctFileBig).BeginInit();
        this.SplitContainerFile.Panel1.SuspendLayout();
        this.SplitContainerFile.Panel2.SuspendLayout();
        this.SplitContainerFile.SuspendLayout();
        this.SplitContainerFile2.Panel1.SuspendLayout();
        this.SplitContainerFile2.Panel2.SuspendLayout();
        this.SplitContainerFile2.SuspendLayout();
        this.gpFileAttributes.SuspendLayout();
        this.gpFileDates.SuspendLayout();
        this.pageSearch.SuspendLayout();
        this.panelMain6.SuspendLayout();
        this.SplitContainerSearch.Panel1.SuspendLayout();
        this.SplitContainerSearch.Panel2.SuspendLayout();
        this.SplitContainerSearch.SuspendLayout();
        this.pageHelp.SuspendLayout();
        this.panelMain4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelConnection).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelProcesses).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelServices).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelCpu).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelMemory).BeginInit();
        this.SuspendLayout();
        // 
        // timerProcess
        // 
        this.timerProcess.Interval = 1000;
        // 
        // imgServices
        // 
        this.imgServices.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgServices.ImageStream");
        this.imgServices.TransparentColor = System.Drawing.Color.Transparent;
        this.imgServices.Images.SetKeyName(0, "ok");
        this.imgServices.Images.SetKeyName(1, "ko");
        this.imgServices.Images.SetKeyName(2, "key");
        this.imgServices.Images.SetKeyName(3, "thread");
        this.imgServices.Images.SetKeyName(4, "noicon");
        this.imgServices.Images.SetKeyName(5, "service");
        // 
        // timerServices
        // 
        this.timerServices.Interval = 6000;
        // 
        // Tray
        // 
        this.Tray.Icon = (System.Drawing.Icon)resources.GetObject("Tray.Icon");
        this.Tray.Text = "Yet Another (remote) Process Monitor";
        // 
        // EnableServiceRefreshingToolStripMenuItem
        // 
        this.EnableServiceRefreshingToolStripMenuItem.Checked = true;
        this.EnableServiceRefreshingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        this.EnableServiceRefreshingToolStripMenuItem.Name = "EnableServiceRefreshingToolStripMenuItem";
        this.EnableServiceRefreshingToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
        this.EnableServiceRefreshingToolStripMenuItem.Text = "Enable service refreshing";
        // 
        // saveDial
        // 
        this.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt";
        this.saveDial.SupportMultiDottedExtensions = true;
        // 
        // openDial
        // 
        this.openDial.CheckFileExists = false;
        this.openDial.CheckPathExists = false;
        this.openDial.SupportMultiDottedExtensions = true;
        // 
        // Ribbon
        // 
        this.Ribbon.Location = new System.Drawing.Point(0, 0);
        this.Ribbon.Minimized = false;
        this.Ribbon.Name = "Ribbon";
        // 
        // 
        // 
        this.Ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbStartElevated);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbMenuNetwork);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.RibbonSeparator4);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbMenuEmergency);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbMenuSBA);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.RibbonSeparator2);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbMenuSaveReport);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.RibbonSeparator5);
        this.Ribbon.OrbDropDown.MenuItems.Add(this.orbMenuAbout);
        this.Ribbon.OrbDropDown.Name = "";
        this.Ribbon.OrbDropDown.NextPopup = null;
        this.Ribbon.OrbDropDown.OptionItems.Add(this.butExit);
        this.Ribbon.OrbDropDown.OptionItems.Add(this.butShowPreferences);
        this.Ribbon.OrbDropDown.OptionItems.Add(this.butFreeMemory);
        this.Ribbon.OrbDropDown.PreviousPopup = null;
        this.Ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 345);
        this.Ribbon.OrbDropDown.TabIndex = 0;
        this.Ribbon.OrbImage = (System.Drawing.Image)resources.GetObject("Ribbon.OrbImage");
        // 
        // 
        // 
        this.Ribbon.QuickAcessToolbar.AltKey = null;
        this.Ribbon.QuickAcessToolbar.Checked = true;
        this.Ribbon.QuickAcessToolbar.Image = null;
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butLog);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butSystemInfo);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butWindows);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butFindWindow);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butNetwork);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butFeedBack);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butHiddenProcesses);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butShowDepViewer);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butShowAllPendingTasks);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butCreateService);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butNetworkInfos);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butScripting);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butSaveSystemSnaphotFile);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butExploreSSFile);
        this.Ribbon.QuickAcessToolbar.Items.Add(this.butCheckSignatures);
        this.Ribbon.QuickAcessToolbar.Tag = null;
        this.Ribbon.QuickAcessToolbar.Text = null;
        this.Ribbon.QuickAcessToolbar.ToolTip = null;
        this.Ribbon.QuickAcessToolbar.ToolTipImage = null;
        this.Ribbon.QuickAcessToolbar.ToolTipTitle = null;
        this.Ribbon.Size = new System.Drawing.Size(866, 138);
        this.Ribbon.TabIndex = 44;
        this.Ribbon.Tabs.Add(this.TaskTab);
        this.Ribbon.Tabs.Add(this.ProcessTab);
        this.Ribbon.Tabs.Add(this.JobTab);
        this.Ribbon.Tabs.Add(this.MonitorTab);
        this.Ribbon.Tabs.Add(this.ServiceTab);
        this.Ribbon.Tabs.Add(this.NetworkTab);
        this.Ribbon.Tabs.Add(this.FileTab);
        this.Ribbon.Tabs.Add(this.SearchTab);
        this.Ribbon.Tabs.Add(this.HelpTab);
        this.Ribbon.TabSpacing = 6;
        // 
        // orbStartElevated
        // 
        this.orbStartElevated.AltKey = null;
        this.orbStartElevated.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbStartElevated.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbStartElevated.Image = global::My.Resources.Resources.shield32;
        this.orbStartElevated.SmallImage = global::My.Resources.Resources.shield32;
        this.orbStartElevated.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbStartElevated.Tag = null;
        this.orbStartElevated.Text = "Restart with privileges";
        this.orbStartElevated.ToolTip = null;
        this.orbStartElevated.ToolTipImage = null;
        this.orbStartElevated.ToolTipTitle = null;
        // 
        // orbMenuNetwork
        // 
        this.orbMenuNetwork.AltKey = null;
        this.orbMenuNetwork.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbMenuNetwork.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbMenuNetwork.Image = global::My.Resources.Resources.network32;
        this.orbMenuNetwork.SmallImage = global::My.Resources.Resources.network32;
        this.orbMenuNetwork.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbMenuNetwork.Tag = null;
        this.orbMenuNetwork.Text = "Change connection type";
        this.orbMenuNetwork.ToolTip = null;
        this.orbMenuNetwork.ToolTipImage = null;
        this.orbMenuNetwork.ToolTipTitle = null;
        // 
        // RibbonSeparator4
        // 
        this.RibbonSeparator4.AltKey = null;
        this.RibbonSeparator4.Image = null;
        this.RibbonSeparator4.Tag = null;
        this.RibbonSeparator4.Text = null;
        this.RibbonSeparator4.ToolTip = null;
        this.RibbonSeparator4.ToolTipImage = null;
        this.RibbonSeparator4.ToolTipTitle = null;
        // 
        // orbMenuEmergency
        // 
        this.orbMenuEmergency.AltKey = null;
        this.orbMenuEmergency.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbMenuEmergency.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbMenuEmergency.Image = global::My.Resources.Resources.warning32;
        this.orbMenuEmergency.SmallImage = global::My.Resources.Resources.warning32;
        this.orbMenuEmergency.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbMenuEmergency.Tag = null;
        this.orbMenuEmergency.Text = "Emergency hotkeys  ";
        this.orbMenuEmergency.ToolTip = null;
        this.orbMenuEmergency.ToolTipImage = null;
        this.orbMenuEmergency.ToolTipTitle = null;
        // 
        // orbMenuSBA
        // 
        this.orbMenuSBA.AltKey = null;
        this.orbMenuSBA.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbMenuSBA.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbMenuSBA.Image = global::My.Resources.Resources.monitoring32;
        this.orbMenuSBA.SmallImage = global::My.Resources.Resources.monitoring32;
        this.orbMenuSBA.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbMenuSBA.Tag = null;
        this.orbMenuSBA.Text = "State based actions  ";
        this.orbMenuSBA.ToolTip = null;
        this.orbMenuSBA.ToolTipImage = null;
        this.orbMenuSBA.ToolTipTitle = null;
        // 
        // RibbonSeparator2
        // 
        this.RibbonSeparator2.AltKey = null;
        this.RibbonSeparator2.Image = null;
        this.RibbonSeparator2.Tag = null;
        this.RibbonSeparator2.Text = null;
        this.RibbonSeparator2.ToolTip = null;
        this.RibbonSeparator2.ToolTipImage = null;
        this.RibbonSeparator2.ToolTipTitle = null;
        // 
        // orbMenuSaveReport
        // 
        this.orbMenuSaveReport.AltKey = null;
        this.orbMenuSaveReport.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbMenuSaveReport.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbMenuSaveReport.Image = global::My.Resources.Resources.save32;
        this.orbMenuSaveReport.SmallImage = global::My.Resources.Resources.save32;
        this.orbMenuSaveReport.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbMenuSaveReport.Tag = null;
        this.orbMenuSaveReport.Text = "Save report";
        this.orbMenuSaveReport.ToolTip = null;
        this.orbMenuSaveReport.ToolTipImage = null;
        this.orbMenuSaveReport.ToolTipTitle = null;
        // 
        // RibbonSeparator5
        // 
        this.RibbonSeparator5.AltKey = null;
        this.RibbonSeparator5.Image = null;
        this.RibbonSeparator5.Tag = null;
        this.RibbonSeparator5.Text = null;
        this.RibbonSeparator5.ToolTip = null;
        this.RibbonSeparator5.ToolTipImage = null;
        this.RibbonSeparator5.ToolTipTitle = null;
        // 
        // orbMenuAbout
        // 
        this.orbMenuAbout.AltKey = null;
        this.orbMenuAbout.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.orbMenuAbout.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.orbMenuAbout.Image = global::My.Resources.Resources.info32;
        this.orbMenuAbout.SmallImage = global::My.Resources.Resources.info32;
        this.orbMenuAbout.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.orbMenuAbout.Tag = null;
        this.orbMenuAbout.Text = "About";
        this.orbMenuAbout.ToolTip = null;
        this.orbMenuAbout.ToolTipImage = null;
        this.orbMenuAbout.ToolTipTitle = null;
        // 
        // butExit
        // 
        this.butExit.AltKey = null;
        this.butExit.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butExit.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butExit.Image = global::My.Resources.Resources.cross_circle16;
        this.butExit.SmallImage = global::My.Resources.Resources.cross_circle16;
        this.butExit.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butExit.Tag = null;
        this.butExit.Text = "Quit";
        this.butExit.ToolTip = null;
        this.butExit.ToolTipImage = null;
        this.butExit.ToolTipTitle = null;
        // 
        // butShowPreferences
        // 
        this.butShowPreferences.AltKey = null;
        this.butShowPreferences.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butShowPreferences.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butShowPreferences.Image = global::My.Resources.Resources.options16;
        this.butShowPreferences.SmallImage = global::My.Resources.Resources.options16;
        this.butShowPreferences.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butShowPreferences.Tag = null;
        this.butShowPreferences.Text = "Preferences";
        this.butShowPreferences.ToolTip = null;
        this.butShowPreferences.ToolTipImage = null;
        this.butShowPreferences.ToolTipTitle = null;
        // 
        // butLog
        // 
        this.butLog.AltKey = null;
        this.butLog.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butLog.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butLog.Image = null;
        this.butLog.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butLog.SmallImage = global::My.Resources.Resources.document_text;
        this.butLog.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butLog.Tag = null;
        this.butLog.Text = "Show log";
        this.butLog.ToolTip = "Show log";
        this.butLog.ToolTipImage = null;
        this.butLog.ToolTipTitle = null;
        // 
        // butSystemInfo
        // 
        this.butSystemInfo.AltKey = null;
        this.butSystemInfo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butSystemInfo.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butSystemInfo.Image = null;
        this.butSystemInfo.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butSystemInfo.SmallImage = global::My.Resources.Resources.taskmgr;
        this.butSystemInfo.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butSystemInfo.Tag = null;
        this.butSystemInfo.Text = "Show system infos";
        this.butSystemInfo.ToolTip = "Show system infos";
        this.butSystemInfo.ToolTipImage = null;
        this.butSystemInfo.ToolTipTitle = null;
        // 
        // butWindows
        // 
        this.butWindows.AltKey = null;
        this.butWindows.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butWindows.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butWindows.Image = null;
        this.butWindows.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butWindows.SmallImage = global::My.Resources.Resources.monitor16;
        this.butWindows.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butWindows.Tag = null;
        this.butWindows.Text = "Show opened windows";
        this.butWindows.ToolTip = "Show opened windows";
        this.butWindows.ToolTipImage = null;
        this.butWindows.ToolTipTitle = null;
        // 
        // butFindWindow
        // 
        this.butFindWindow.AltKey = null;
        this.butFindWindow.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFindWindow.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFindWindow.Image = null;
        this.butFindWindow.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butFindWindow.SmallImage = global::My.Resources.Resources.target16;
        this.butFindWindow.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFindWindow.Tag = null;
        this.butFindWindow.Text = "Find a process by window";
        this.butFindWindow.ToolTip = "Find a process by window";
        this.butFindWindow.ToolTipImage = null;
        this.butFindWindow.ToolTipTitle = null;
        // 
        // butNetwork
        // 
        this.butNetwork.AltKey = null;
        this.butNetwork.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butNetwork.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butNetwork.Image = null;
        this.butNetwork.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butNetwork.SmallImage = global::My.Resources.Resources.network16;
        this.butNetwork.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butNetwork.Tag = null;
        this.butNetwork.Text = "Change connection type";
        this.butNetwork.ToolTip = "Change connection type";
        this.butNetwork.ToolTipImage = null;
        this.butNetwork.ToolTipTitle = null;
        // 
        // butFeedBack
        // 
        this.butFeedBack.AltKey = null;
        this.butFeedBack.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFeedBack.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFeedBack.Image = null;
        this.butFeedBack.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butFeedBack.SmallImage = global::My.Resources.Resources.information_frame;
        this.butFeedBack.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFeedBack.Tag = null;
        this.butFeedBack.Text = "Feed back";
        this.butFeedBack.ToolTip = "Feed back";
        this.butFeedBack.ToolTipImage = null;
        this.butFeedBack.ToolTipTitle = null;
        // 
        // butHiddenProcesses
        // 
        this.butHiddenProcesses.AltKey = null;
        this.butHiddenProcesses.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butHiddenProcesses.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butHiddenProcesses.Image = null;
        this.butHiddenProcesses.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butHiddenProcesses.SmallImage = global::My.Resources.Resources.shield16;
        this.butHiddenProcesses.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butHiddenProcesses.Tag = null;
        this.butHiddenProcesses.Text = "Show hidden processes";
        this.butHiddenProcesses.ToolTip = "Show hidden processes";
        this.butHiddenProcesses.ToolTipImage = null;
        this.butHiddenProcesses.ToolTipTitle = null;
        // 
        // butShowDepViewer
        // 
        this.butShowDepViewer.AltKey = null;
        this.butShowDepViewer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butShowDepViewer.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butShowDepViewer.Image = null;
        this.butShowDepViewer.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butShowDepViewer.SmallImage = global::My.Resources.Resources.dllIcon16;
        this.butShowDepViewer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butShowDepViewer.Tag = null;
        this.butShowDepViewer.Text = "Dependencies viewer";
        this.butShowDepViewer.ToolTip = "Dependencies viewer";
        this.butShowDepViewer.ToolTipImage = null;
        this.butShowDepViewer.ToolTipTitle = null;
        // 
        // butShowAllPendingTasks
        // 
        this.butShowAllPendingTasks.AltKey = null;
        this.butShowAllPendingTasks.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butShowAllPendingTasks.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butShowAllPendingTasks.Image = null;
        this.butShowAllPendingTasks.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butShowAllPendingTasks.SmallImage = global::My.Resources.Resources.thread;
        this.butShowAllPendingTasks.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butShowAllPendingTasks.Tag = null;
        this.butShowAllPendingTasks.Text = "Display pending tasks";
        this.butShowAllPendingTasks.ToolTip = "Display pending tasks";
        this.butShowAllPendingTasks.ToolTipImage = null;
        this.butShowAllPendingTasks.ToolTipTitle = null;
        // 
        // butCreateService
        // 
        this.butCreateService.AltKey = null;
        this.butCreateService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butCreateService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butCreateService.Image = null;
        this.butCreateService.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butCreateService.SmallImage = global::My.Resources.Resources.plus_circle;
        this.butCreateService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butCreateService.Tag = null;
        this.butCreateService.Text = "Create service";
        this.butCreateService.ToolTip = "Create service";
        this.butCreateService.ToolTipImage = null;
        this.butCreateService.ToolTipTitle = null;
        // 
        // butNetworkInfos
        // 
        this.butNetworkInfos.AltKey = null;
        this.butNetworkInfos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butNetworkInfos.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butNetworkInfos.Image = (System.Drawing.Image)resources.GetObject("butNetworkInfos.Image");
        this.butNetworkInfos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butNetworkInfos.SmallImage = global::My.Resources.Resources.globe;
        this.butNetworkInfos.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butNetworkInfos.Tag = null;
        this.butNetworkInfos.Text = "Show network infos";
        this.butNetworkInfos.ToolTip = null;
        this.butNetworkInfos.ToolTipImage = null;
        this.butNetworkInfos.ToolTipTitle = null;
        // 
        // butScripting
        // 
        this.butScripting.AltKey = null;
        this.butScripting.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butScripting.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butScripting.Image = (System.Drawing.Image)resources.GetObject("butScripting.Image");
        this.butScripting.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butScripting.SmallImage = global::My.Resources.Resources.scripting16;
        this.butScripting.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butScripting.Tag = null;
        this.butScripting.Text = "Scripting";
        this.butScripting.ToolTip = null;
        this.butScripting.ToolTipImage = null;
        this.butScripting.ToolTipTitle = null;
        // 
        // butSaveSystemSnaphotFile
        // 
        this.butSaveSystemSnaphotFile.AltKey = null;
        this.butSaveSystemSnaphotFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butSaveSystemSnaphotFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butSaveSystemSnaphotFile.Image = (System.Drawing.Image)resources.GetObject("butSaveSystemSnaphotFile.Image");
        this.butSaveSystemSnaphotFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butSaveSystemSnaphotFile.SmallImage = global::My.Resources.Resources.save16;
        this.butSaveSystemSnaphotFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butSaveSystemSnaphotFile.Tag = null;
        this.butSaveSystemSnaphotFile.Text = "Save System Snapshot File";
        this.butSaveSystemSnaphotFile.ToolTip = null;
        this.butSaveSystemSnaphotFile.ToolTipImage = null;
        this.butSaveSystemSnaphotFile.ToolTipTitle = null;
        // 
        // butExploreSSFile
        // 
        this.butExploreSSFile.AltKey = null;
        this.butExploreSSFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butExploreSSFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butExploreSSFile.Image = (System.Drawing.Image)resources.GetObject("butExploreSSFile.Image");
        this.butExploreSSFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butExploreSSFile.SmallImage = global::My.Resources.Resources.folder_open_document;
        this.butExploreSSFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butExploreSSFile.Tag = null;
        this.butExploreSSFile.Text = "Explore System Snapshot File";
        this.butExploreSSFile.ToolTip = null;
        this.butExploreSSFile.ToolTipImage = null;
        this.butExploreSSFile.ToolTipTitle = null;
        // 
        // butCheckSignatures
        // 
        this.butCheckSignatures.AltKey = null;
        this.butCheckSignatures.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butCheckSignatures.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butCheckSignatures.Image = (System.Drawing.Image)resources.GetObject("butCheckSignatures.Image");
        this.butCheckSignatures.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
        this.butCheckSignatures.SmallImage = global::My.Resources.Resources.ok16;
        this.butCheckSignatures.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butCheckSignatures.Tag = null;
        this.butCheckSignatures.Text = "RibbonButton1";
        this.butCheckSignatures.ToolTip = null;
        this.butCheckSignatures.ToolTipImage = null;
        this.butCheckSignatures.ToolTipTitle = null;
        // 
        // TaskTab
        // 
        this.TaskTab.Panels.Add(this.RBTaskDisplay);
        this.TaskTab.Panels.Add(this.RBTaskActions);
        this.TaskTab.Tag = null;
        this.TaskTab.Text = "Tasks";
        // 
        // RBTaskDisplay
        // 
        this.RBTaskDisplay.ButtonMoreEnabled = false;
        this.RBTaskDisplay.ButtonMoreVisible = false;
        this.RBTaskDisplay.Items.Add(this.butTaskRefresh);
        this.RBTaskDisplay.Tag = null;
        this.RBTaskDisplay.Text = "Display";
        // 
        // butTaskRefresh
        // 
        this.butTaskRefresh.AltKey = null;
        this.butTaskRefresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butTaskRefresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butTaskRefresh.Image = global::My.Resources.Resources.refresh32;
        this.butTaskRefresh.SmallImage = (System.Drawing.Image)resources.GetObject("butTaskRefresh.SmallImage");
        this.butTaskRefresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butTaskRefresh.Tag = null;
        this.butTaskRefresh.Text = "Refresh";
        this.butTaskRefresh.ToolTip = null;
        this.butTaskRefresh.ToolTipImage = null;
        this.butTaskRefresh.ToolTipTitle = null;
        // 
        // RBTaskActions
        // 
        this.RBTaskActions.ButtonMoreEnabled = false;
        this.RBTaskActions.ButtonMoreVisible = false;
        this.RBTaskActions.Items.Add(this.butTaskShow);
        this.RBTaskActions.Items.Add(this.butTaskEndTask);
        this.RBTaskActions.Tag = null;
        this.RBTaskActions.Text = "Common task actions";
        // 
        // butTaskShow
        // 
        this.butTaskShow.AltKey = null;
        this.butTaskShow.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butTaskShow.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butTaskShow.Image = global::My.Resources.Resources.monitor32;
        this.butTaskShow.SmallImage = (System.Drawing.Image)resources.GetObject("butTaskShow.SmallImage");
        this.butTaskShow.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butTaskShow.Tag = null;
        this.butTaskShow.Text = "Show";
        this.butTaskShow.ToolTip = null;
        this.butTaskShow.ToolTipImage = null;
        this.butTaskShow.ToolTipTitle = null;
        // 
        // butTaskEndTask
        // 
        this.butTaskEndTask.AltKey = null;
        this.butTaskEndTask.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butTaskEndTask.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butTaskEndTask.Image = global::My.Resources.Resources.delete32;
        this.butTaskEndTask.SmallImage = (System.Drawing.Image)resources.GetObject("butTaskEndTask.SmallImage");
        this.butTaskEndTask.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butTaskEndTask.Tag = null;
        this.butTaskEndTask.Text = "End task";
        this.butTaskEndTask.ToolTip = null;
        this.butTaskEndTask.ToolTipImage = null;
        this.butTaskEndTask.ToolTipTitle = null;
        // 
        // ProcessTab
        // 
        this.ProcessTab.Panels.Add(this.RBProcessDisplay);
        this.ProcessTab.Panels.Add(this.RBProcessActions);
        this.ProcessTab.Panels.Add(this.RBProcessPriority);
        this.ProcessTab.Panels.Add(this.RBProcessOnline);
        this.ProcessTab.Panels.Add(this.panelProcessReport);
        this.ProcessTab.Tag = null;
        this.ProcessTab.Text = "Processes";
        // 
        // RBProcessDisplay
        // 
        this.RBProcessDisplay.ButtonMoreEnabled = false;
        this.RBProcessDisplay.ButtonMoreVisible = false;
        this.RBProcessDisplay.Items.Add(this.butProcessRerfresh);
        this.RBProcessDisplay.Items.Add(this.butProcessDisplayDetails);
        this.RBProcessDisplay.Tag = null;
        this.RBProcessDisplay.Text = "Display";
        // 
        // butProcessRerfresh
        // 
        this.butProcessRerfresh.AltKey = null;
        this.butProcessRerfresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProcessRerfresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessRerfresh.Image = global::My.Resources.Resources.refresh32;
        this.butProcessRerfresh.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessRerfresh.SmallImage");
        this.butProcessRerfresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessRerfresh.Tag = null;
        this.butProcessRerfresh.Text = "Refresh";
        this.butProcessRerfresh.ToolTip = null;
        this.butProcessRerfresh.ToolTipImage = null;
        this.butProcessRerfresh.ToolTipTitle = null;
        // 
        // butProcessDisplayDetails
        // 
        this.butProcessDisplayDetails.AltKey = null;
        this.butProcessDisplayDetails.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProcessDisplayDetails.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessDisplayDetails.Image = global::My.Resources.Resources.monitor32;
        this.butProcessDisplayDetails.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessDisplayDetails.SmallImage");
        this.butProcessDisplayDetails.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessDisplayDetails.Tag = null;
        this.butProcessDisplayDetails.Text = "Show details";
        this.butProcessDisplayDetails.ToolTip = null;
        this.butProcessDisplayDetails.ToolTipImage = null;
        this.butProcessDisplayDetails.ToolTipTitle = null;
        // 
        // RBProcessActions
        // 
        this.RBProcessActions.ButtonMoreEnabled = false;
        this.RBProcessActions.ButtonMoreVisible = false;
        this.RBProcessActions.Items.Add(this.butNewProcess);
        this.RBProcessActions.Items.Add(this.butKillProcess);
        this.RBProcessActions.Items.Add(this.butStopProcess);
        this.RBProcessActions.Items.Add(this.butResumeProcess);
        this.RBProcessActions.Items.Add(this.butProcessOtherActions);
        this.RBProcessActions.Tag = null;
        this.RBProcessActions.Text = "Common processes actions";
        // 
        // butNewProcess
        // 
        this.butNewProcess.AltKey = null;
        this.butNewProcess.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butNewProcess.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butNewProcess.Image = global::My.Resources.Resources.window_add32;
        this.butNewProcess.SmallImage = (System.Drawing.Image)resources.GetObject("butNewProcess.SmallImage");
        this.butNewProcess.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butNewProcess.Tag = null;
        this.butNewProcess.Text = "New...";
        this.butNewProcess.ToolTip = null;
        this.butNewProcess.ToolTipImage = null;
        this.butNewProcess.ToolTipTitle = null;
        // 
        // butKillProcess
        // 
        this.butKillProcess.AltKey = null;
        this.butKillProcess.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butKillProcess.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butKillProcess.Image = global::My.Resources.Resources.delete32;
        this.butKillProcess.SmallImage = (System.Drawing.Image)resources.GetObject("butKillProcess.SmallImage");
        this.butKillProcess.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butKillProcess.Tag = null;
        this.butKillProcess.Text = "Kill";
        this.butKillProcess.ToolTip = null;
        this.butKillProcess.ToolTipImage = null;
        this.butKillProcess.ToolTipTitle = null;
        // 
        // butStopProcess
        // 
        this.butStopProcess.AltKey = null;
        this.butStopProcess.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butStopProcess.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butStopProcess.Image = global::My.Resources.Resources.pause32;
        this.butStopProcess.SmallImage = (System.Drawing.Image)resources.GetObject("butStopProcess.SmallImage");
        this.butStopProcess.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butStopProcess.Tag = null;
        this.butStopProcess.Text = "Pause";
        this.butStopProcess.ToolTip = null;
        this.butStopProcess.ToolTipImage = null;
        this.butStopProcess.ToolTipTitle = null;
        // 
        // butResumeProcess
        // 
        this.butResumeProcess.AltKey = null;
        this.butResumeProcess.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butResumeProcess.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butResumeProcess.Image = global::My.Resources.Resources.play32;
        this.butResumeProcess.SmallImage = (System.Drawing.Image)resources.GetObject("butResumeProcess.SmallImage");
        this.butResumeProcess.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butResumeProcess.Tag = null;
        this.butResumeProcess.Text = "Resume";
        this.butResumeProcess.ToolTip = null;
        this.butResumeProcess.ToolTipImage = null;
        this.butResumeProcess.ToolTipTitle = null;
        // 
        // butProcessOtherActions
        // 
        this.butProcessOtherActions.AltKey = null;
        this.butProcessOtherActions.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProcessOtherActions.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessOtherActions.DropDownItems.Add(this.butProcessAffinity);
        this.butProcessOtherActions.DropDownItems.Add(this.butProcessReduceWS);
        this.butProcessOtherActions.DropDownItems.Add(this.butProcessDumpF);
        this.butProcessOtherActions.DropDownItems.Add(this.butProcessLimitCPU);
        this.butProcessOtherActions.Image = global::My.Resources.Resources.process32;
        this.butProcessOtherActions.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessOtherActions.SmallImage");
        this.butProcessOtherActions.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
        this.butProcessOtherActions.Tag = null;
        this.butProcessOtherActions.Text = "Other actions";
        this.butProcessOtherActions.ToolTip = null;
        this.butProcessOtherActions.ToolTipImage = null;
        this.butProcessOtherActions.ToolTipTitle = null;
        // 
        // butProcessAffinity
        // 
        this.butProcessAffinity.AltKey = null;
        this.butProcessAffinity.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butProcessAffinity.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessAffinity.Image = (System.Drawing.Image)resources.GetObject("butProcessAffinity.Image");
        this.butProcessAffinity.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessAffinity.SmallImage");
        this.butProcessAffinity.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessAffinity.Tag = null;
        this.butProcessAffinity.Text = "Affinity";
        this.butProcessAffinity.ToolTip = null;
        this.butProcessAffinity.ToolTipImage = null;
        this.butProcessAffinity.ToolTipTitle = null;
        // 
        // butProcessReduceWS
        // 
        this.butProcessReduceWS.AltKey = null;
        this.butProcessReduceWS.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butProcessReduceWS.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessReduceWS.Image = (System.Drawing.Image)resources.GetObject("butProcessReduceWS.Image");
        this.butProcessReduceWS.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessReduceWS.SmallImage");
        this.butProcessReduceWS.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessReduceWS.Tag = null;
        this.butProcessReduceWS.Text = "Reduce working set size";
        this.butProcessReduceWS.ToolTip = null;
        this.butProcessReduceWS.ToolTipImage = null;
        this.butProcessReduceWS.ToolTipTitle = null;
        // 
        // butProcessDumpF
        // 
        this.butProcessDumpF.AltKey = null;
        this.butProcessDumpF.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butProcessDumpF.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessDumpF.Image = (System.Drawing.Image)resources.GetObject("butProcessDumpF.Image");
        this.butProcessDumpF.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessDumpF.SmallImage");
        this.butProcessDumpF.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessDumpF.Tag = null;
        this.butProcessDumpF.Text = "Create dump file...";
        this.butProcessDumpF.ToolTip = null;
        this.butProcessDumpF.ToolTipImage = null;
        this.butProcessDumpF.ToolTipTitle = null;
        // 
        // butProcessLimitCPU
        // 
        this.butProcessLimitCPU.AltKey = null;
        this.butProcessLimitCPU.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butProcessLimitCPU.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessLimitCPU.Enabled = false;
        this.butProcessLimitCPU.Image = (System.Drawing.Image)resources.GetObject("butProcessLimitCPU.Image");
        this.butProcessLimitCPU.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessLimitCPU.SmallImage");
        this.butProcessLimitCPU.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessLimitCPU.Tag = null;
        this.butProcessLimitCPU.Text = "Limit CPU usage";
        this.butProcessLimitCPU.ToolTip = null;
        this.butProcessLimitCPU.ToolTipImage = null;
        this.butProcessLimitCPU.ToolTipTitle = null;
        // 
        // RBProcessPriority
        // 
        this.RBProcessPriority.ButtonMoreEnabled = false;
        this.RBProcessPriority.ButtonMoreVisible = false;
        this.RBProcessPriority.Items.Add(this.butProcessPriority);
        this.RBProcessPriority.Tag = null;
        this.RBProcessPriority.Text = "Priority";
        // 
        // butProcessPriority
        // 
        this.butProcessPriority.AltKey = null;
        this.butProcessPriority.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProcessPriority.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessPriority.DropDownItems.Add(this.butIdle);
        this.butProcessPriority.DropDownItems.Add(this.butBelowNormal);
        this.butProcessPriority.DropDownItems.Add(this.butNormal);
        this.butProcessPriority.DropDownItems.Add(this.butAboveNormal);
        this.butProcessPriority.DropDownItems.Add(this.butHigh);
        this.butProcessPriority.DropDownItems.Add(this.butRealTime);
        this.butProcessPriority.Image = global::My.Resources.Resources.speed32;
        this.butProcessPriority.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessPriority.SmallImage");
        this.butProcessPriority.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
        this.butProcessPriority.Tag = null;
        this.butProcessPriority.Text = "Priority";
        this.butProcessPriority.ToolTip = null;
        this.butProcessPriority.ToolTipImage = null;
        this.butProcessPriority.ToolTipTitle = null;
        // 
        // butIdle
        // 
        this.butIdle.AltKey = null;
        this.butIdle.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butIdle.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butIdle.Image = (System.Drawing.Image)resources.GetObject("butIdle.Image");
        this.butIdle.SmallImage = global::My.Resources.Resources.p0;
        this.butIdle.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butIdle.Tag = null;
        this.butIdle.Text = "Idle";
        this.butIdle.ToolTip = null;
        this.butIdle.ToolTipImage = null;
        this.butIdle.ToolTipTitle = null;
        // 
        // butBelowNormal
        // 
        this.butBelowNormal.AltKey = null;
        this.butBelowNormal.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butBelowNormal.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butBelowNormal.Image = (System.Drawing.Image)resources.GetObject("butBelowNormal.Image");
        this.butBelowNormal.SmallImage = global::My.Resources.Resources.p1;
        this.butBelowNormal.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butBelowNormal.Tag = null;
        this.butBelowNormal.Text = "Below Normal";
        this.butBelowNormal.ToolTip = null;
        this.butBelowNormal.ToolTipImage = null;
        this.butBelowNormal.ToolTipTitle = null;
        // 
        // butNormal
        // 
        this.butNormal.AltKey = null;
        this.butNormal.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butNormal.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butNormal.Image = (System.Drawing.Image)resources.GetObject("butNormal.Image");
        this.butNormal.SmallImage = global::My.Resources.Resources.p2;
        this.butNormal.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butNormal.Tag = null;
        this.butNormal.Text = "Normal";
        this.butNormal.ToolTip = null;
        this.butNormal.ToolTipImage = null;
        this.butNormal.ToolTipTitle = null;
        // 
        // butAboveNormal
        // 
        this.butAboveNormal.AltKey = null;
        this.butAboveNormal.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butAboveNormal.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butAboveNormal.Image = (System.Drawing.Image)resources.GetObject("butAboveNormal.Image");
        this.butAboveNormal.SmallImage = global::My.Resources.Resources.p3;
        this.butAboveNormal.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butAboveNormal.Tag = null;
        this.butAboveNormal.Text = "Above Normal";
        this.butAboveNormal.ToolTip = null;
        this.butAboveNormal.ToolTipImage = null;
        this.butAboveNormal.ToolTipTitle = null;
        // 
        // butHigh
        // 
        this.butHigh.AltKey = null;
        this.butHigh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butHigh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butHigh.Image = (System.Drawing.Image)resources.GetObject("butHigh.Image");
        this.butHigh.SmallImage = global::My.Resources.Resources.p4;
        this.butHigh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butHigh.Tag = null;
        this.butHigh.Text = "High";
        this.butHigh.ToolTip = null;
        this.butHigh.ToolTipImage = null;
        this.butHigh.ToolTipTitle = null;
        // 
        // butRealTime
        // 
        this.butRealTime.AltKey = null;
        this.butRealTime.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butRealTime.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butRealTime.Image = (System.Drawing.Image)resources.GetObject("butRealTime.Image");
        this.butRealTime.SmallImage = global::My.Resources.Resources.p6;
        this.butRealTime.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butRealTime.Tag = null;
        this.butRealTime.Text = "Real Time";
        this.butRealTime.ToolTip = null;
        this.butRealTime.ToolTipImage = null;
        this.butRealTime.ToolTipTitle = null;
        // 
        // RBProcessOnline
        // 
        this.RBProcessOnline.ButtonMoreEnabled = false;
        this.RBProcessOnline.ButtonMoreVisible = false;
        this.RBProcessOnline.Items.Add(this.butProcessGoogle);
        this.RBProcessOnline.Tag = null;
        this.RBProcessOnline.Text = "Online";
        // 
        // butProcessGoogle
        // 
        this.butProcessGoogle.AltKey = null;
        this.butProcessGoogle.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProcessGoogle.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProcessGoogle.Image = global::My.Resources.Resources.ie732;
        this.butProcessGoogle.SmallImage = (System.Drawing.Image)resources.GetObject("butProcessGoogle.SmallImage");
        this.butProcessGoogle.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProcessGoogle.Tag = null;
        this.butProcessGoogle.Text = "Internet search";
        this.butProcessGoogle.ToolTip = null;
        this.butProcessGoogle.ToolTipImage = null;
        this.butProcessGoogle.ToolTipTitle = null;
        // 
        // panelProcessReport
        // 
        this.panelProcessReport.ButtonMoreEnabled = false;
        this.panelProcessReport.ButtonMoreVisible = false;
        this.panelProcessReport.Items.Add(this.butSaveProcessReport);
        this.panelProcessReport.Tag = null;
        this.panelProcessReport.Text = "Report";
        // 
        // butSaveProcessReport
        // 
        this.butSaveProcessReport.AltKey = null;
        this.butSaveProcessReport.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butSaveProcessReport.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butSaveProcessReport.Image = global::My.Resources.Resources.save32;
        this.butSaveProcessReport.SmallImage = (System.Drawing.Image)resources.GetObject("butSaveProcessReport.SmallImage");
        this.butSaveProcessReport.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butSaveProcessReport.Tag = null;
        this.butSaveProcessReport.Text = "Save report";
        this.butSaveProcessReport.ToolTip = null;
        this.butSaveProcessReport.ToolTipImage = null;
        this.butSaveProcessReport.ToolTipTitle = null;
        // 
        // JobTab
        // 
        this.JobTab.Panels.Add(this.RBJobDisplay);
        this.JobTab.Panels.Add(this.RBJobActions);
        this.JobTab.Panels.Add(this.RBJobPrivileges);
        this.JobTab.Tag = null;
        this.JobTab.Text = "Jobs";
        // 
        // RBJobDisplay
        // 
        this.RBJobDisplay.ButtonMoreVisible = false;
        this.RBJobDisplay.Items.Add(this.butJobRefresh);
        this.RBJobDisplay.Items.Add(this.butJobDetails);
        this.RBJobDisplay.Tag = null;
        this.RBJobDisplay.Text = "Display";
        // 
        // butJobRefresh
        // 
        this.butJobRefresh.AltKey = null;
        this.butJobRefresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butJobRefresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butJobRefresh.Image = global::My.Resources.Resources.refresh32;
        this.butJobRefresh.SmallImage = (System.Drawing.Image)resources.GetObject("butJobRefresh.SmallImage");
        this.butJobRefresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butJobRefresh.Tag = null;
        this.butJobRefresh.Text = "Refresh";
        this.butJobRefresh.ToolTip = null;
        this.butJobRefresh.ToolTipImage = null;
        this.butJobRefresh.ToolTipTitle = null;
        // 
        // butJobDetails
        // 
        this.butJobDetails.AltKey = null;
        this.butJobDetails.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butJobDetails.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butJobDetails.Image = global::My.Resources.Resources.monitor32;
        this.butJobDetails.SmallImage = (System.Drawing.Image)resources.GetObject("butJobDetails.SmallImage");
        this.butJobDetails.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butJobDetails.Tag = null;
        this.butJobDetails.Text = "Show details";
        this.butJobDetails.ToolTip = null;
        this.butJobDetails.ToolTipImage = null;
        this.butJobDetails.ToolTipTitle = null;
        // 
        // RBJobActions
        // 
        this.RBJobActions.ButtonMoreVisible = false;
        this.RBJobActions.Items.Add(this.butJobTerminate);
        this.RBJobActions.Tag = null;
        this.RBJobActions.Text = "Common job actions";
        // 
        // butJobTerminate
        // 
        this.butJobTerminate.AltKey = null;
        this.butJobTerminate.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butJobTerminate.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butJobTerminate.Image = global::My.Resources.Resources.delete32;
        this.butJobTerminate.SmallImage = (System.Drawing.Image)resources.GetObject("butJobTerminate.SmallImage");
        this.butJobTerminate.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butJobTerminate.Tag = null;
        this.butJobTerminate.Text = "Terminate";
        this.butJobTerminate.ToolTip = null;
        this.butJobTerminate.ToolTipImage = null;
        this.butJobTerminate.ToolTipTitle = null;
        // 
        // RBJobPrivileges
        // 
        this.RBJobPrivileges.ButtonMoreVisible = false;
        this.RBJobPrivileges.Items.Add(this.butJobElevate);
        this.RBJobPrivileges.Tag = null;
        this.RBJobPrivileges.Text = "Enable this feature";
        // 
        // butJobElevate
        // 
        this.butJobElevate.AltKey = null;
        this.butJobElevate.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butJobElevate.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butJobElevate.Image = global::My.Resources.Resources.shield32;
        this.butJobElevate.SmallImage = (System.Drawing.Image)resources.GetObject("butJobElevate.SmallImage");
        this.butJobElevate.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butJobElevate.Tag = null;
        this.butJobElevate.Text = "Restart with privileges          .";
        this.butJobElevate.ToolTip = null;
        this.butJobElevate.ToolTipImage = null;
        this.butJobElevate.ToolTipTitle = null;
        // 
        // MonitorTab
        // 
        this.MonitorTab.Panels.Add(this.RBMonitor);
        this.MonitorTab.Panels.Add(this.RBMonitoringControl);
        this.MonitorTab.Panels.Add(this.butSaveMonitorReport);
        this.MonitorTab.Tag = null;
        this.MonitorTab.Text = "Monitor";
        // 
        // RBMonitor
        // 
        this.RBMonitor.ButtonMoreEnabled = false;
        this.RBMonitor.ButtonMoreVisible = false;
        this.RBMonitor.Items.Add(this.butMonitoringAdd);
        this.RBMonitor.Items.Add(this.butMonitoringRemove);
        this.RBMonitor.Tag = null;
        this.RBMonitor.Text = "Monitor a process";
        // 
        // butMonitoringAdd
        // 
        this.butMonitoringAdd.AltKey = null;
        this.butMonitoringAdd.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMonitoringAdd.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMonitoringAdd.Image = global::My.Resources.Resources.add32;
        this.butMonitoringAdd.SmallImage = (System.Drawing.Image)resources.GetObject("butMonitoringAdd.SmallImage");
        this.butMonitoringAdd.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMonitoringAdd.Tag = null;
        this.butMonitoringAdd.Text = "Add";
        this.butMonitoringAdd.ToolTip = null;
        this.butMonitoringAdd.ToolTipImage = null;
        this.butMonitoringAdd.ToolTipTitle = null;
        // 
        // butMonitoringRemove
        // 
        this.butMonitoringRemove.AltKey = null;
        this.butMonitoringRemove.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMonitoringRemove.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMonitoringRemove.Image = global::My.Resources.Resources.delete32;
        this.butMonitoringRemove.SmallImage = (System.Drawing.Image)resources.GetObject("butMonitoringRemove.SmallImage");
        this.butMonitoringRemove.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMonitoringRemove.Tag = null;
        this.butMonitoringRemove.Text = "Remove selection";
        this.butMonitoringRemove.ToolTip = null;
        this.butMonitoringRemove.ToolTipImage = null;
        this.butMonitoringRemove.ToolTipTitle = null;
        // 
        // RBMonitoringControl
        // 
        this.RBMonitoringControl.ButtonMoreEnabled = false;
        this.RBMonitoringControl.ButtonMoreVisible = false;
        this.RBMonitoringControl.Items.Add(this.butMonitorStart);
        this.RBMonitoringControl.Items.Add(this.butMonitorStop);
        this.RBMonitoringControl.Tag = null;
        this.RBMonitoringControl.Text = "Monitor";
        // 
        // butMonitorStart
        // 
        this.butMonitorStart.AltKey = null;
        this.butMonitorStart.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMonitorStart.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMonitorStart.Enabled = false;
        this.butMonitorStart.Image = global::My.Resources.Resources.play32;
        this.butMonitorStart.SmallImage = (System.Drawing.Image)resources.GetObject("butMonitorStart.SmallImage");
        this.butMonitorStart.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMonitorStart.Tag = null;
        this.butMonitorStart.Text = "Start";
        this.butMonitorStart.ToolTip = null;
        this.butMonitorStart.ToolTipImage = null;
        this.butMonitorStart.ToolTipTitle = null;
        // 
        // butMonitorStop
        // 
        this.butMonitorStop.AltKey = null;
        this.butMonitorStop.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMonitorStop.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMonitorStop.Enabled = false;
        this.butMonitorStop.Image = global::My.Resources.Resources.stop32;
        this.butMonitorStop.SmallImage = (System.Drawing.Image)resources.GetObject("butMonitorStop.SmallImage");
        this.butMonitorStop.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMonitorStop.Tag = null;
        this.butMonitorStop.Text = "Stop";
        this.butMonitorStop.ToolTip = null;
        this.butMonitorStop.ToolTipImage = null;
        this.butMonitorStop.ToolTipTitle = null;
        // 
        // butSaveMonitorReport
        // 
        this.butSaveMonitorReport.ButtonMoreEnabled = false;
        this.butSaveMonitorReport.ButtonMoreVisible = false;
        this.butSaveMonitorReport.Items.Add(this.butMonitorSaveReport);
        this.butSaveMonitorReport.Tag = null;
        this.butSaveMonitorReport.Text = "Report";
        // 
        // butMonitorSaveReport
        // 
        this.butMonitorSaveReport.AltKey = null;
        this.butMonitorSaveReport.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMonitorSaveReport.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMonitorSaveReport.Enabled = false;
        this.butMonitorSaveReport.Image = global::My.Resources.Resources.save32;
        this.butMonitorSaveReport.SmallImage = (System.Drawing.Image)resources.GetObject("butMonitorSaveReport.SmallImage");
        this.butMonitorSaveReport.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMonitorSaveReport.Tag = null;
        this.butMonitorSaveReport.Text = "Save report";
        this.butMonitorSaveReport.ToolTip = null;
        this.butMonitorSaveReport.ToolTipImage = null;
        this.butMonitorSaveReport.ToolTipTitle = null;
        // 
        // ServiceTab
        // 
        this.ServiceTab.Panels.Add(this.RBServiceDisplay);
        this.ServiceTab.Panels.Add(this.RBServiceAction);
        this.ServiceTab.Panels.Add(this.RBServiceStartType);
        this.ServiceTab.Panels.Add(this.RBServiceFile);
        this.ServiceTab.Panels.Add(this.RBServiceOnline);
        this.ServiceTab.Panels.Add(this.RBServiceReport);
        this.ServiceTab.Tag = null;
        this.ServiceTab.Text = "Services";
        // 
        // RBServiceDisplay
        // 
        this.RBServiceDisplay.ButtonMoreEnabled = false;
        this.RBServiceDisplay.ButtonMoreVisible = false;
        this.RBServiceDisplay.Items.Add(this.butServiceRefresh);
        this.RBServiceDisplay.Items.Add(this.butServiceDetails);
        this.RBServiceDisplay.Tag = null;
        this.RBServiceDisplay.Text = "Display";
        // 
        // butServiceRefresh
        // 
        this.butServiceRefresh.AltKey = null;
        this.butServiceRefresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceRefresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceRefresh.Image = global::My.Resources.Resources.refresh32;
        this.butServiceRefresh.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceRefresh.SmallImage");
        this.butServiceRefresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceRefresh.Tag = null;
        this.butServiceRefresh.Text = "Refresh";
        this.butServiceRefresh.ToolTip = null;
        this.butServiceRefresh.ToolTipImage = null;
        this.butServiceRefresh.ToolTipTitle = null;
        // 
        // butServiceDetails
        // 
        this.butServiceDetails.AltKey = null;
        this.butServiceDetails.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceDetails.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceDetails.Image = global::My.Resources.Resources.monitor32;
        this.butServiceDetails.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceDetails.SmallImage");
        this.butServiceDetails.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceDetails.Tag = null;
        this.butServiceDetails.Text = "Show details";
        this.butServiceDetails.ToolTip = null;
        this.butServiceDetails.ToolTipImage = null;
        this.butServiceDetails.ToolTipTitle = null;
        // 
        // RBServiceAction
        // 
        this.RBServiceAction.ButtonMoreEnabled = false;
        this.RBServiceAction.ButtonMoreVisible = false;
        this.RBServiceAction.Items.Add(this.butStopService);
        this.RBServiceAction.Items.Add(this.butStartService);
        this.RBServiceAction.Items.Add(this.RibbonSeparator1);
        this.RBServiceAction.Items.Add(this.butPauseService);
        this.RBServiceAction.Items.Add(this.butResumeService);
        this.RBServiceAction.Items.Add(this.RibbonSeparator6);
        this.RBServiceAction.Items.Add(this.butDeleteService);
        this.RBServiceAction.Tag = null;
        this.RBServiceAction.Text = "Service actions";
        // 
        // butStopService
        // 
        this.butStopService.AltKey = null;
        this.butStopService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butStopService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butStopService.Image = global::My.Resources.Resources.stop32;
        this.butStopService.SmallImage = (System.Drawing.Image)resources.GetObject("butStopService.SmallImage");
        this.butStopService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butStopService.Tag = null;
        this.butStopService.Text = "Stop";
        this.butStopService.ToolTip = null;
        this.butStopService.ToolTipImage = null;
        this.butStopService.ToolTipTitle = null;
        // 
        // butStartService
        // 
        this.butStartService.AltKey = null;
        this.butStartService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butStartService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butStartService.Image = global::My.Resources.Resources.play32;
        this.butStartService.SmallImage = (System.Drawing.Image)resources.GetObject("butStartService.SmallImage");
        this.butStartService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butStartService.Tag = null;
        this.butStartService.Text = "Start";
        this.butStartService.ToolTip = null;
        this.butStartService.ToolTipImage = null;
        this.butStartService.ToolTipTitle = null;
        // 
        // RibbonSeparator1
        // 
        this.RibbonSeparator1.AltKey = null;
        this.RibbonSeparator1.Image = null;
        this.RibbonSeparator1.Tag = null;
        this.RibbonSeparator1.Text = null;
        this.RibbonSeparator1.ToolTip = null;
        this.RibbonSeparator1.ToolTipImage = null;
        this.RibbonSeparator1.ToolTipTitle = null;
        // 
        // butPauseService
        // 
        this.butPauseService.AltKey = null;
        this.butPauseService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butPauseService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butPauseService.Image = global::My.Resources.Resources.pause32;
        this.butPauseService.SmallImage = (System.Drawing.Image)resources.GetObject("butPauseService.SmallImage");
        this.butPauseService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butPauseService.Tag = null;
        this.butPauseService.Text = "Pause";
        this.butPauseService.ToolTip = null;
        this.butPauseService.ToolTipImage = null;
        this.butPauseService.ToolTipTitle = null;
        // 
        // butResumeService
        // 
        this.butResumeService.AltKey = null;
        this.butResumeService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butResumeService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butResumeService.Image = global::My.Resources.Resources.play32;
        this.butResumeService.SmallImage = (System.Drawing.Image)resources.GetObject("butResumeService.SmallImage");
        this.butResumeService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butResumeService.Tag = null;
        this.butResumeService.Text = "Resume";
        this.butResumeService.ToolTip = null;
        this.butResumeService.ToolTipImage = null;
        this.butResumeService.ToolTipTitle = null;
        // 
        // RibbonSeparator6
        // 
        this.RibbonSeparator6.AltKey = null;
        this.RibbonSeparator6.Image = null;
        this.RibbonSeparator6.Tag = null;
        this.RibbonSeparator6.Text = null;
        this.RibbonSeparator6.ToolTip = null;
        this.RibbonSeparator6.ToolTipImage = null;
        this.RibbonSeparator6.ToolTipTitle = null;
        // 
        // butDeleteService
        // 
        this.butDeleteService.AltKey = null;
        this.butDeleteService.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butDeleteService.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butDeleteService.DropDownItems.Add(this.RibbonSeparator3);
        this.butDeleteService.Image = global::My.Resources.Resources.delete32;
        this.butDeleteService.SmallImage = (System.Drawing.Image)resources.GetObject("butDeleteService.SmallImage");
        this.butDeleteService.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butDeleteService.Tag = null;
        this.butDeleteService.Text = "Delete";
        this.butDeleteService.ToolTip = null;
        this.butDeleteService.ToolTipImage = null;
        this.butDeleteService.ToolTipTitle = null;
        // 
        // RibbonSeparator3
        // 
        this.RibbonSeparator3.AltKey = null;
        this.RibbonSeparator3.Image = null;
        this.RibbonSeparator3.Tag = null;
        this.RibbonSeparator3.Text = null;
        this.RibbonSeparator3.ToolTip = null;
        this.RibbonSeparator3.ToolTipImage = null;
        this.RibbonSeparator3.ToolTipTitle = null;
        // 
        // RBServiceStartType
        // 
        this.RBServiceStartType.ButtonMoreEnabled = false;
        this.RBServiceStartType.ButtonMoreVisible = false;
        this.RBServiceStartType.Items.Add(this.butServiceStartType);
        this.RBServiceStartType.Tag = null;
        this.RBServiceStartType.Text = "Start type";
        // 
        // butServiceStartType
        // 
        this.butServiceStartType.AltKey = null;
        this.butServiceStartType.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceStartType.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceStartType.DropDownItems.Add(this.butAutomaticStart);
        this.butServiceStartType.DropDownItems.Add(this.butOnDemandStart);
        this.butServiceStartType.DropDownItems.Add(this.butDisabledStart);
        this.butServiceStartType.Image = global::My.Resources.Resources.start_type32;
        this.butServiceStartType.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceStartType.SmallImage");
        this.butServiceStartType.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
        this.butServiceStartType.Tag = null;
        this.butServiceStartType.Text = "Start Type";
        this.butServiceStartType.ToolTip = null;
        this.butServiceStartType.ToolTipImage = null;
        this.butServiceStartType.ToolTipTitle = null;
        // 
        // butAutomaticStart
        // 
        this.butAutomaticStart.AltKey = null;
        this.butAutomaticStart.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butAutomaticStart.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butAutomaticStart.Image = null;
        this.butAutomaticStart.SmallImage = global::My.Resources.Resources.p6;
        this.butAutomaticStart.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butAutomaticStart.Tag = null;
        this.butAutomaticStart.Text = "Automatic";
        this.butAutomaticStart.ToolTip = null;
        this.butAutomaticStart.ToolTipImage = null;
        this.butAutomaticStart.ToolTipTitle = null;
        // 
        // butOnDemandStart
        // 
        this.butOnDemandStart.AltKey = null;
        this.butOnDemandStart.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butOnDemandStart.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butOnDemandStart.Image = (System.Drawing.Image)resources.GetObject("butOnDemandStart.Image");
        this.butOnDemandStart.SmallImage = global::My.Resources.Resources.p3;
        this.butOnDemandStart.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butOnDemandStart.Tag = null;
        this.butOnDemandStart.Text = "On Demand";
        this.butOnDemandStart.ToolTip = null;
        this.butOnDemandStart.ToolTipImage = null;
        this.butOnDemandStart.ToolTipTitle = null;
        // 
        // butDisabledStart
        // 
        this.butDisabledStart.AltKey = null;
        this.butDisabledStart.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butDisabledStart.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butDisabledStart.Image = (System.Drawing.Image)resources.GetObject("butDisabledStart.Image");
        this.butDisabledStart.SmallImage = global::My.Resources.Resources.p0;
        this.butDisabledStart.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butDisabledStart.Tag = null;
        this.butDisabledStart.Text = "Disabled";
        this.butDisabledStart.ToolTip = null;
        this.butDisabledStart.ToolTipImage = null;
        this.butDisabledStart.ToolTipTitle = null;
        // 
        // RBServiceFile
        // 
        this.RBServiceFile.ButtonMoreEnabled = false;
        this.RBServiceFile.ButtonMoreVisible = false;
        this.RBServiceFile.Items.Add(this.butServiceFileProp);
        this.RBServiceFile.Items.Add(this.butServiceOpenDir);
        this.RBServiceFile.Items.Add(this.butServiceFileDetails);
        this.RBServiceFile.Tag = null;
        this.RBServiceFile.Text = "Executable";
        // 
        // butServiceFileProp
        // 
        this.butServiceFileProp.AltKey = null;
        this.butServiceFileProp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceFileProp.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceFileProp.Image = global::My.Resources.Resources.page_info32;
        this.butServiceFileProp.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceFileProp.SmallImage");
        this.butServiceFileProp.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceFileProp.Tag = null;
        this.butServiceFileProp.Text = "Show file properties";
        this.butServiceFileProp.ToolTip = null;
        this.butServiceFileProp.ToolTipImage = null;
        this.butServiceFileProp.ToolTipTitle = null;
        // 
        // butServiceOpenDir
        // 
        this.butServiceOpenDir.AltKey = null;
        this.butServiceOpenDir.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceOpenDir.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceOpenDir.Image = (System.Drawing.Image)resources.GetObject("butServiceOpenDir.Image");
        this.butServiceOpenDir.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceOpenDir.SmallImage");
        this.butServiceOpenDir.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceOpenDir.Tag = null;
        this.butServiceOpenDir.Text = "Open file   directory";
        this.butServiceOpenDir.ToolTip = null;
        this.butServiceOpenDir.ToolTipImage = null;
        this.butServiceOpenDir.ToolTipTitle = null;
        // 
        // butServiceFileDetails
        // 
        this.butServiceFileDetails.AltKey = null;
        this.butServiceFileDetails.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceFileDetails.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceFileDetails.Image = global::My.Resources.Resources.magnify32;
        this.butServiceFileDetails.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceFileDetails.SmallImage");
        this.butServiceFileDetails.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceFileDetails.Tag = null;
        this.butServiceFileDetails.Text = "Details";
        this.butServiceFileDetails.ToolTip = null;
        this.butServiceFileDetails.ToolTipImage = null;
        this.butServiceFileDetails.ToolTipTitle = null;
        // 
        // RBServiceOnline
        // 
        this.RBServiceOnline.ButtonMoreEnabled = false;
        this.RBServiceOnline.ButtonMoreVisible = false;
        this.RBServiceOnline.Items.Add(this.butServiceGoogle);
        this.RBServiceOnline.Tag = null;
        this.RBServiceOnline.Text = "Online";
        // 
        // butServiceGoogle
        // 
        this.butServiceGoogle.AltKey = null;
        this.butServiceGoogle.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceGoogle.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceGoogle.Image = global::My.Resources.Resources.ie732;
        this.butServiceGoogle.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceGoogle.SmallImage");
        this.butServiceGoogle.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceGoogle.Tag = null;
        this.butServiceGoogle.Text = "Internet search";
        this.butServiceGoogle.ToolTip = null;
        this.butServiceGoogle.ToolTipImage = null;
        this.butServiceGoogle.ToolTipTitle = null;
        // 
        // RBServiceReport
        // 
        this.RBServiceReport.ButtonMoreEnabled = false;
        this.RBServiceReport.ButtonMoreVisible = false;
        this.RBServiceReport.Items.Add(this.butServiceReport);
        this.RBServiceReport.Tag = null;
        this.RBServiceReport.Text = "Report";
        // 
        // butServiceReport
        // 
        this.butServiceReport.AltKey = null;
        this.butServiceReport.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butServiceReport.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butServiceReport.Image = global::My.Resources.Resources.save32;
        this.butServiceReport.SmallImage = (System.Drawing.Image)resources.GetObject("butServiceReport.SmallImage");
        this.butServiceReport.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butServiceReport.Tag = null;
        this.butServiceReport.Text = "Save report";
        this.butServiceReport.ToolTip = null;
        this.butServiceReport.ToolTipImage = null;
        this.butServiceReport.ToolTipTitle = null;
        // 
        // NetworkTab
        // 
        this.NetworkTab.Panels.Add(this.RBNetworkRefresh);
        this.NetworkTab.Tag = null;
        this.NetworkTab.Text = "Network";
        // 
        // RBNetworkRefresh
        // 
        this.RBNetworkRefresh.ButtonMoreEnabled = false;
        this.RBNetworkRefresh.ButtonMoreVisible = false;
        this.RBNetworkRefresh.Items.Add(this.butNetworkRefresh);
        this.RBNetworkRefresh.Tag = null;
        this.RBNetworkRefresh.Text = "Display";
        // 
        // butNetworkRefresh
        // 
        this.butNetworkRefresh.AltKey = null;
        this.butNetworkRefresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butNetworkRefresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butNetworkRefresh.Image = global::My.Resources.Resources.refresh32;
        this.butNetworkRefresh.SmallImage = (System.Drawing.Image)resources.GetObject("butNetworkRefresh.SmallImage");
        this.butNetworkRefresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butNetworkRefresh.Tag = null;
        this.butNetworkRefresh.Text = "Refresh";
        this.butNetworkRefresh.ToolTip = null;
        this.butNetworkRefresh.ToolTipImage = null;
        this.butNetworkRefresh.ToolTipTitle = null;
        // 
        // FileTab
        // 
        this.FileTab.Panels.Add(this.RBFileOpenFile);
        this.FileTab.Panels.Add(this.RBFileKillProcess);
        this.FileTab.Panels.Add(this.RBFileDelete);
        this.FileTab.Panels.Add(this.RBFileOnline);
        this.FileTab.Panels.Add(this.RBFileOther);
        this.FileTab.Panels.Add(this.RBFileOthers);
        this.FileTab.Tag = null;
        this.FileTab.Text = "File";
        // 
        // RBFileOpenFile
        // 
        this.RBFileOpenFile.ButtonMoreEnabled = false;
        this.RBFileOpenFile.ButtonMoreVisible = false;
        this.RBFileOpenFile.Items.Add(this.butOpenFile);
        this.RBFileOpenFile.Items.Add(this.butFileRefresh);
        this.RBFileOpenFile.Tag = null;
        this.RBFileOpenFile.Text = "File";
        // 
        // butOpenFile
        // 
        this.butOpenFile.AltKey = null;
        this.butOpenFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butOpenFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butOpenFile.Image = global::My.Resources.Resources.open_folder32;
        this.butOpenFile.SmallImage = (System.Drawing.Image)resources.GetObject("butOpenFile.SmallImage");
        this.butOpenFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butOpenFile.Tag = null;
        this.butOpenFile.Text = "Open file";
        this.butOpenFile.ToolTip = null;
        this.butOpenFile.ToolTipImage = null;
        this.butOpenFile.ToolTipTitle = null;
        // 
        // butFileRefresh
        // 
        this.butFileRefresh.AltKey = null;
        this.butFileRefresh.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileRefresh.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileRefresh.Image = global::My.Resources.Resources.refresh32;
        this.butFileRefresh.SmallImage = (System.Drawing.Image)resources.GetObject("butFileRefresh.SmallImage");
        this.butFileRefresh.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileRefresh.Tag = null;
        this.butFileRefresh.Text = "Refresh infos";
        this.butFileRefresh.ToolTip = null;
        this.butFileRefresh.ToolTipImage = null;
        this.butFileRefresh.ToolTipTitle = null;
        // 
        // RBFileKillProcess
        // 
        this.RBFileKillProcess.ButtonMoreEnabled = false;
        this.RBFileKillProcess.ButtonMoreVisible = false;
        this.RBFileKillProcess.Enabled = false;
        this.RBFileKillProcess.Items.Add(this.butFileRelease);
        this.RBFileKillProcess.Tag = null;
        this.RBFileKillProcess.Text = "Release file";
        // 
        // butFileRelease
        // 
        this.butFileRelease.AltKey = null;
        this.butFileRelease.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileRelease.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileRelease.Enabled = false;
        this.butFileRelease.Image = global::My.Resources.Resources.unlock32;
        this.butFileRelease.SmallImage = (System.Drawing.Image)resources.GetObject("butFileRelease.SmallImage");
        this.butFileRelease.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileRelease.Tag = null;
        this.butFileRelease.Text = "Release";
        this.butFileRelease.ToolTip = null;
        this.butFileRelease.ToolTipImage = null;
        this.butFileRelease.ToolTipTitle = null;
        // 
        // RBFileDelete
        // 
        this.RBFileDelete.ButtonMoreEnabled = false;
        this.RBFileDelete.ButtonMoreVisible = false;
        this.RBFileDelete.Enabled = false;
        this.RBFileDelete.Items.Add(this.butMoveFileToTrash);
        this.RBFileDelete.Items.Add(this.butDeleteFile);
        this.RBFileDelete.Tag = null;
        this.RBFileDelete.Text = "Delete";
        // 
        // butMoveFileToTrash
        // 
        this.butMoveFileToTrash.AltKey = null;
        this.butMoveFileToTrash.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butMoveFileToTrash.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butMoveFileToTrash.Enabled = false;
        this.butMoveFileToTrash.Image = global::My.Resources.Resources.trash32;
        this.butMoveFileToTrash.SmallImage = (System.Drawing.Image)resources.GetObject("butMoveFileToTrash.SmallImage");
        this.butMoveFileToTrash.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butMoveFileToTrash.Tag = null;
        this.butMoveFileToTrash.Text = "Trash";
        this.butMoveFileToTrash.ToolTip = null;
        this.butMoveFileToTrash.ToolTipImage = null;
        this.butMoveFileToTrash.ToolTipTitle = null;
        // 
        // butDeleteFile
        // 
        this.butDeleteFile.AltKey = null;
        this.butDeleteFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butDeleteFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butDeleteFile.Enabled = false;
        this.butDeleteFile.Image = global::My.Resources.Resources.delete32;
        this.butDeleteFile.SmallImage = (System.Drawing.Image)resources.GetObject("butDeleteFile.SmallImage");
        this.butDeleteFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butDeleteFile.Tag = null;
        this.butDeleteFile.Text = "Delete";
        this.butDeleteFile.ToolTip = null;
        this.butDeleteFile.ToolTipImage = null;
        this.butDeleteFile.ToolTipTitle = null;
        // 
        // RBFileOnline
        // 
        this.RBFileOnline.ButtonMoreEnabled = false;
        this.RBFileOnline.ButtonMoreVisible = false;
        this.RBFileOnline.Enabled = false;
        this.RBFileOnline.Items.Add(this.butFileGoogleSearch);
        this.RBFileOnline.Tag = null;
        this.RBFileOnline.Text = "Online";
        // 
        // butFileGoogleSearch
        // 
        this.butFileGoogleSearch.AltKey = null;
        this.butFileGoogleSearch.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileGoogleSearch.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileGoogleSearch.Enabled = false;
        this.butFileGoogleSearch.Image = global::My.Resources.Resources.ie732;
        this.butFileGoogleSearch.SmallImage = (System.Drawing.Image)resources.GetObject("butFileGoogleSearch.SmallImage");
        this.butFileGoogleSearch.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileGoogleSearch.Tag = null;
        this.butFileGoogleSearch.Text = "Internet search";
        this.butFileGoogleSearch.ToolTip = null;
        this.butFileGoogleSearch.ToolTipImage = null;
        this.butFileGoogleSearch.ToolTipTitle = null;
        // 
        // RBFileOther
        // 
        this.RBFileOther.ButtonMoreEnabled = false;
        this.RBFileOther.ButtonMoreVisible = false;
        this.RBFileOther.Enabled = false;
        this.RBFileOther.Items.Add(this.butFileProperties);
        this.RBFileOther.Items.Add(this.butFileOpenDir);
        this.RBFileOther.Items.Add(this.butFileShowFolderProperties);
        this.RBFileOther.Tag = null;
        this.RBFileOther.Text = "Properties";
        // 
        // butFileProperties
        // 
        this.butFileProperties.AltKey = null;
        this.butFileProperties.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileProperties.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileProperties.Enabled = false;
        this.butFileProperties.Image = global::My.Resources.Resources.page_info32;
        this.butFileProperties.SmallImage = (System.Drawing.Image)resources.GetObject("butFileProperties.SmallImage");
        this.butFileProperties.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileProperties.Tag = null;
        this.butFileProperties.Text = "Show file properties";
        this.butFileProperties.ToolTip = null;
        this.butFileProperties.ToolTipImage = null;
        this.butFileProperties.ToolTipTitle = null;
        // 
        // butFileOpenDir
        // 
        this.butFileOpenDir.AltKey = null;
        this.butFileOpenDir.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileOpenDir.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileOpenDir.Enabled = false;
        this.butFileOpenDir.Image = (System.Drawing.Image)resources.GetObject("butFileOpenDir.Image");
        this.butFileOpenDir.SmallImage = (System.Drawing.Image)resources.GetObject("butFileOpenDir.SmallImage");
        this.butFileOpenDir.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileOpenDir.Tag = null;
        this.butFileOpenDir.Text = "Open file   directory";
        this.butFileOpenDir.ToolTip = null;
        this.butFileOpenDir.ToolTipImage = null;
        this.butFileOpenDir.ToolTipTitle = null;
        // 
        // butFileShowFolderProperties
        // 
        this.butFileShowFolderProperties.AltKey = null;
        this.butFileShowFolderProperties.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileShowFolderProperties.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileShowFolderProperties.Enabled = false;
        this.butFileShowFolderProperties.Image = global::My.Resources.Resources.file_info32;
        this.butFileShowFolderProperties.SmallImage = (System.Drawing.Image)resources.GetObject("butFileShowFolderProperties.SmallImage");
        this.butFileShowFolderProperties.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileShowFolderProperties.Tag = null;
        this.butFileShowFolderProperties.Text = "Show dir. properties";
        this.butFileShowFolderProperties.ToolTip = null;
        this.butFileShowFolderProperties.ToolTipImage = null;
        this.butFileShowFolderProperties.ToolTipTitle = null;
        // 
        // RBFileOthers
        // 
        this.RBFileOthers.ButtonMoreEnabled = false;
        this.RBFileOthers.ButtonMoreVisible = false;
        this.RBFileOthers.Enabled = false;
        this.RBFileOthers.Items.Add(this.butFileOthersActions);
        this.RBFileOthers.Tag = null;
        this.RBFileOthers.Text = "Others";
        // 
        // butFileOthersActions
        // 
        this.butFileOthersActions.AltKey = null;
        this.butFileOthersActions.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFileOthersActions.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileOthersActions.DropDownItems.Add(this.sepFile1);
        this.butFileOthersActions.DropDownItems.Add(this.butFileRename);
        this.butFileOthersActions.DropDownItems.Add(this.butFileCopy);
        this.butFileOthersActions.DropDownItems.Add(this.butFileMove);
        this.butFileOthersActions.DropDownItems.Add(this.butFileOpen);
        this.butFileOthersActions.DropDownItems.Add(this.sepFile2);
        this.butFileOthersActions.DropDownItems.Add(this.butFileSeeStrings);
        this.butFileOthersActions.DropDownItems.Add(this.sepFile3);
        this.butFileOthersActions.DropDownItems.Add(this.butFileEncrypt);
        this.butFileOthersActions.DropDownItems.Add(this.butFileDecrypt);
        this.butFileOthersActions.Enabled = false;
        this.butFileOthersActions.Image = global::My.Resources.Resources.process32;
        this.butFileOthersActions.SmallImage = (System.Drawing.Image)resources.GetObject("butFileOthersActions.SmallImage");
        this.butFileOthersActions.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
        this.butFileOthersActions.Tag = null;
        this.butFileOthersActions.Text = "Others";
        this.butFileOthersActions.ToolTip = null;
        this.butFileOthersActions.ToolTipImage = null;
        this.butFileOthersActions.ToolTipTitle = null;
        // 
        // sepFile1
        // 
        this.sepFile1.AltKey = null;
        this.sepFile1.Image = null;
        this.sepFile1.Tag = null;
        this.sepFile1.Text = "Explorer actions";
        this.sepFile1.ToolTip = null;
        this.sepFile1.ToolTipImage = null;
        this.sepFile1.ToolTipTitle = null;
        // 
        // butFileRename
        // 
        this.butFileRename.AltKey = null;
        this.butFileRename.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileRename.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileRename.Image = (System.Drawing.Image)resources.GetObject("butFileRename.Image");
        this.butFileRename.SmallImage = (System.Drawing.Image)resources.GetObject("butFileRename.SmallImage");
        this.butFileRename.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileRename.Tag = null;
        this.butFileRename.Text = "Rename";
        this.butFileRename.ToolTip = null;
        this.butFileRename.ToolTipImage = null;
        this.butFileRename.ToolTipTitle = null;
        // 
        // butFileCopy
        // 
        this.butFileCopy.AltKey = null;
        this.butFileCopy.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileCopy.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileCopy.Image = (System.Drawing.Image)resources.GetObject("butFileCopy.Image");
        this.butFileCopy.SmallImage = (System.Drawing.Image)resources.GetObject("butFileCopy.SmallImage");
        this.butFileCopy.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileCopy.Tag = null;
        this.butFileCopy.Text = "Copy";
        this.butFileCopy.ToolTip = null;
        this.butFileCopy.ToolTipImage = null;
        this.butFileCopy.ToolTipTitle = null;
        // 
        // butFileMove
        // 
        this.butFileMove.AltKey = null;
        this.butFileMove.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileMove.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileMove.Image = (System.Drawing.Image)resources.GetObject("butFileMove.Image");
        this.butFileMove.SmallImage = (System.Drawing.Image)resources.GetObject("butFileMove.SmallImage");
        this.butFileMove.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileMove.Tag = null;
        this.butFileMove.Text = "Move";
        this.butFileMove.ToolTip = null;
        this.butFileMove.ToolTipImage = null;
        this.butFileMove.ToolTipTitle = null;
        // 
        // butFileOpen
        // 
        this.butFileOpen.AltKey = null;
        this.butFileOpen.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileOpen.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileOpen.Image = (System.Drawing.Image)resources.GetObject("butFileOpen.Image");
        this.butFileOpen.SmallImage = (System.Drawing.Image)resources.GetObject("butFileOpen.SmallImage");
        this.butFileOpen.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileOpen.Tag = null;
        this.butFileOpen.Text = "Open";
        this.butFileOpen.ToolTip = null;
        this.butFileOpen.ToolTipImage = null;
        this.butFileOpen.ToolTipTitle = null;
        // 
        // sepFile2
        // 
        this.sepFile2.AltKey = null;
        this.sepFile2.Image = null;
        this.sepFile2.Tag = null;
        this.sepFile2.Text = "File content";
        this.sepFile2.ToolTip = null;
        this.sepFile2.ToolTipImage = null;
        this.sepFile2.ToolTipTitle = null;
        // 
        // butFileSeeStrings
        // 
        this.butFileSeeStrings.AltKey = null;
        this.butFileSeeStrings.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileSeeStrings.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileSeeStrings.Image = (System.Drawing.Image)resources.GetObject("butFileSeeStrings.Image");
        this.butFileSeeStrings.SmallImage = (System.Drawing.Image)resources.GetObject("butFileSeeStrings.SmallImage");
        this.butFileSeeStrings.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileSeeStrings.Tag = null;
        this.butFileSeeStrings.Text = "Show file strings";
        this.butFileSeeStrings.ToolTip = null;
        this.butFileSeeStrings.ToolTipImage = null;
        this.butFileSeeStrings.ToolTipTitle = null;
        // 
        // sepFile3
        // 
        this.sepFile3.AltKey = null;
        this.sepFile3.Image = null;
        this.sepFile3.Tag = null;
        this.sepFile3.Text = "Encryption";
        this.sepFile3.ToolTip = null;
        this.sepFile3.ToolTipImage = null;
        this.sepFile3.ToolTipTitle = null;
        // 
        // butFileEncrypt
        // 
        this.butFileEncrypt.AltKey = null;
        this.butFileEncrypt.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileEncrypt.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileEncrypt.Image = (System.Drawing.Image)resources.GetObject("butFileEncrypt.Image");
        this.butFileEncrypt.SmallImage = (System.Drawing.Image)resources.GetObject("butFileEncrypt.SmallImage");
        this.butFileEncrypt.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileEncrypt.Tag = null;
        this.butFileEncrypt.Text = "Encrypt";
        this.butFileEncrypt.ToolTip = null;
        this.butFileEncrypt.ToolTipImage = null;
        this.butFileEncrypt.ToolTipTitle = null;
        // 
        // butFileDecrypt
        // 
        this.butFileDecrypt.AltKey = null;
        this.butFileDecrypt.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
        this.butFileDecrypt.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFileDecrypt.Image = (System.Drawing.Image)resources.GetObject("butFileDecrypt.Image");
        this.butFileDecrypt.SmallImage = (System.Drawing.Image)resources.GetObject("butFileDecrypt.SmallImage");
        this.butFileDecrypt.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFileDecrypt.Tag = null;
        this.butFileDecrypt.Text = "Decrypt";
        this.butFileDecrypt.ToolTip = null;
        this.butFileDecrypt.ToolTipImage = null;
        this.butFileDecrypt.ToolTipTitle = null;
        // 
        // SearchTab
        // 
        this.SearchTab.Panels.Add(this.RBSearchMain);
        this.SearchTab.Tag = null;
        this.SearchTab.Text = "Search";
        // 
        // RBSearchMain
        // 
        this.RBSearchMain.ButtonMoreEnabled = false;
        this.RBSearchMain.ButtonMoreVisible = false;
        this.RBSearchMain.Items.Add(this.butSearchGo);
        this.RBSearchMain.Items.Add(this.butSearchSaveReport);
        this.RBSearchMain.Items.Add(this.txtSearchString);
        this.RBSearchMain.Tag = null;
        this.RBSearchMain.Text = "Search";
        // 
        // butSearchGo
        // 
        this.butSearchGo.AltKey = null;
        this.butSearchGo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butSearchGo.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butSearchGo.Enabled = false;
        this.butSearchGo.Image = global::My.Resources.Resources.magnify32;
        this.butSearchGo.SmallImage = (System.Drawing.Image)resources.GetObject("butSearchGo.SmallImage");
        this.butSearchGo.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butSearchGo.Tag = null;
        this.butSearchGo.Text = "Launch";
        this.butSearchGo.ToolTip = null;
        this.butSearchGo.ToolTipImage = null;
        this.butSearchGo.ToolTipTitle = null;
        // 
        // butSearchSaveReport
        // 
        this.butSearchSaveReport.AltKey = null;
        this.butSearchSaveReport.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butSearchSaveReport.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butSearchSaveReport.Image = global::My.Resources.Resources.save32;
        this.butSearchSaveReport.SmallImage = (System.Drawing.Image)resources.GetObject("butSearchSaveReport.SmallImage");
        this.butSearchSaveReport.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butSearchSaveReport.Tag = null;
        this.butSearchSaveReport.Text = "Save report";
        this.butSearchSaveReport.ToolTip = null;
        this.butSearchSaveReport.ToolTipImage = null;
        this.butSearchSaveReport.ToolTipTitle = null;
        // 
        // txtSearchString
        // 
        this.txtSearchString.AltKey = null;
        this.txtSearchString.Image = null;
        this.txtSearchString.Tag = null;
        this.txtSearchString.Text = "String to search ::";
        this.txtSearchString.TextBoxText = null;
        this.txtSearchString.ToolTip = null;
        this.txtSearchString.ToolTipImage = null;
        this.txtSearchString.ToolTipTitle = null;
        // 
        // HelpTab
        // 
        this.HelpTab.Panels.Add(this.RBUpdate);
        this.HelpTab.Panels.Add(this.RBHelpAction);
        this.HelpTab.Panels.Add(this.RBHelpWeb);
        this.HelpTab.Panels.Add(this.RBOptions);
        this.HelpTab.Tag = null;
        this.HelpTab.Text = "Help";
        // 
        // RBUpdate
        // 
        this.RBUpdate.ButtonMoreEnabled = false;
        this.RBUpdate.ButtonMoreVisible = false;
        this.RBUpdate.Items.Add(this.butUpdate);
        this.RBUpdate.Tag = null;
        this.RBUpdate.Text = "Update";
        // 
        // butUpdate
        // 
        this.butUpdate.AltKey = null;
        this.butUpdate.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butUpdate.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butUpdate.Image = global::My.Resources.Resources.refresh32;
        this.butUpdate.SmallImage = (System.Drawing.Image)resources.GetObject("butUpdate.SmallImage");
        this.butUpdate.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butUpdate.Tag = null;
        this.butUpdate.Text = "Check  update";
        this.butUpdate.ToolTip = null;
        this.butUpdate.ToolTipImage = null;
        this.butUpdate.ToolTipTitle = null;
        // 
        // RBHelpAction
        // 
        this.RBHelpAction.ButtonMoreEnabled = false;
        this.RBHelpAction.ButtonMoreVisible = false;
        this.RBHelpAction.Items.Add(this.butDonate);
        this.RBHelpAction.Items.Add(this.butAbout);
        this.RBHelpAction.Tag = null;
        this.RBHelpAction.Text = "Actions";
        // 
        // butDonate
        // 
        this.butDonate.AltKey = null;
        this.butDonate.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butDonate.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butDonate.Image = global::My.Resources.Resources.paypal_big;
        this.butDonate.SmallImage = (System.Drawing.Image)resources.GetObject("butDonate.SmallImage");
        this.butDonate.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butDonate.Tag = null;
        this.butDonate.Text = "Donate";
        this.butDonate.ToolTip = null;
        this.butDonate.ToolTipImage = null;
        this.butDonate.ToolTipTitle = null;
        // 
        // butAbout
        // 
        this.butAbout.AltKey = null;
        this.butAbout.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butAbout.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butAbout.Image = global::My.Resources.Resources.info32;
        this.butAbout.SmallImage = (System.Drawing.Image)resources.GetObject("butAbout.SmallImage");
        this.butAbout.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butAbout.Tag = null;
        this.butAbout.Text = "About";
        this.butAbout.ToolTip = null;
        this.butAbout.ToolTipImage = null;
        this.butAbout.ToolTipTitle = null;
        // 
        // RBHelpWeb
        // 
        this.RBHelpWeb.ButtonMoreEnabled = false;
        this.RBHelpWeb.ButtonMoreVisible = false;
        this.RBHelpWeb.Items.Add(this.butWebite);
        this.RBHelpWeb.Items.Add(this.butProjectPage);
        this.RBHelpWeb.Items.Add(this.butDownload);
        this.RBHelpWeb.Tag = null;
        this.RBHelpWeb.Text = "YAPM on Internet";
        // 
        // butWebite
        // 
        this.butWebite.AltKey = null;
        this.butWebite.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butWebite.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butWebite.Image = global::My.Resources.Resources.ie732;
        this.butWebite.SmallImage = (System.Drawing.Image)resources.GetObject("butWebite.SmallImage");
        this.butWebite.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butWebite.Tag = null;
        this.butWebite.Text = "Website";
        this.butWebite.ToolTip = null;
        this.butWebite.ToolTipImage = null;
        this.butWebite.ToolTipTitle = null;
        // 
        // butProjectPage
        // 
        this.butProjectPage.AltKey = null;
        this.butProjectPage.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butProjectPage.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butProjectPage.Image = global::My.Resources.Resources.sourceforge_big;
        this.butProjectPage.SmallImage = (System.Drawing.Image)resources.GetObject("butProjectPage.SmallImage");
        this.butProjectPage.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butProjectPage.Tag = null;
        this.butProjectPage.Text = "Project page on Sourceforge.net";
        this.butProjectPage.ToolTip = null;
        this.butProjectPage.ToolTipImage = null;
        this.butProjectPage.ToolTipTitle = null;
        // 
        // butDownload
        // 
        this.butDownload.AltKey = null;
        this.butDownload.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butDownload.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butDownload.Image = global::My.Resources.Resources.download32;
        this.butDownload.SmallImage = (System.Drawing.Image)resources.GetObject("butDownload.SmallImage");
        this.butDownload.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butDownload.Tag = null;
        this.butDownload.Text = "Downloads";
        this.butDownload.ToolTip = null;
        this.butDownload.ToolTipImage = null;
        this.butDownload.ToolTipTitle = null;
        // 
        // RBOptions
        // 
        this.RBOptions.ButtonMoreEnabled = false;
        this.RBOptions.ButtonMoreVisible = false;
        this.RBOptions.Items.Add(this.butPreferences);
        this.RBOptions.Items.Add(this.butAlwaysDisplay);
        this.RBOptions.Tag = null;
        this.RBOptions.Text = "Options";
        // 
        // butPreferences
        // 
        this.butPreferences.AltKey = null;
        this.butPreferences.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butPreferences.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butPreferences.Image = global::My.Resources.Resources.options32;
        this.butPreferences.SmallImage = (System.Drawing.Image)resources.GetObject("butPreferences.SmallImage");
        this.butPreferences.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butPreferences.Tag = null;
        this.butPreferences.Text = "Preferences";
        this.butPreferences.ToolTip = null;
        this.butPreferences.ToolTipImage = null;
        this.butPreferences.ToolTipTitle = null;
        // 
        // butAlwaysDisplay
        // 
        this.butAlwaysDisplay.AltKey = null;
        this.butAlwaysDisplay.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butAlwaysDisplay.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butAlwaysDisplay.Image = global::My.Resources.Resources.monitor32;
        this.butAlwaysDisplay.SmallImage = (System.Drawing.Image)resources.GetObject("butAlwaysDisplay.SmallImage");
        this.butAlwaysDisplay.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butAlwaysDisplay.Tag = null;
        this.butAlwaysDisplay.Text = "Always display";
        this.butAlwaysDisplay.ToolTip = null;
        this.butAlwaysDisplay.ToolTipImage = null;
        this.butAlwaysDisplay.ToolTipTitle = null;
        // 
        // imgMonitor
        // 
        this.imgMonitor.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgMonitor.ImageStream");
        this.imgMonitor.TransparentColor = System.Drawing.Color.Transparent;
        this.imgMonitor.Images.SetKeyName(0, "down");
        this.imgMonitor.Images.SetKeyName(1, "sub");
        this.imgMonitor.Images.SetKeyName(2, "exe");
        // 
        // timerMonitoring
        // 
        this.timerMonitoring.Interval = 1000;
        // 
        // timerTask
        // 
        this.timerTask.Interval = 1000;
        // 
        // timerTrayIcon
        // 
        this.timerTrayIcon.Interval = 1000;
        // 
        // _main
        // 
        this._main.Dock = System.Windows.Forms.DockStyle.Fill;
        this._main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this._main.IsSplitterFixed = true;
        this._main.Location = new System.Drawing.Point(0, 0);
        this._main.Name = "_main";
        this._main.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // _main.Panel1
        // 
        this._main.Panel1.Controls.Add(this.Ribbon);
        // 
        // _main.Panel2
        // 
        this._main.Panel2.Controls.Add(this.containerSystemMenu);
        this._main.Size = new System.Drawing.Size(866, 531);
        this._main.SplitterDistance = 138;
        this._main.TabIndex = 57;
        // 
        // containerSystemMenu
        // 
        this.containerSystemMenu.Dock = System.Windows.Forms.DockStyle.Fill;
        this.containerSystemMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.containerSystemMenu.IsSplitterFixed = true;
        this.containerSystemMenu.Location = new System.Drawing.Point(0, 0);
        this.containerSystemMenu.Name = "containerSystemMenu";
        this.containerSystemMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.containerSystemMenu.Panel1Collapsed = true;
        // 
        // containerSystemMenu.Panel2
        // 
        this.containerSystemMenu.Panel2.Controls.Add(this._tab);
        this.containerSystemMenu.Size = new System.Drawing.Size(866, 389);
        this.containerSystemMenu.SplitterDistance = 25;
        this.containerSystemMenu.TabIndex = 0;
        // 
        // _tab
        // 
        this._tab.Controls.Add(this.pageTasks);
        this._tab.Controls.Add(this.pageProcesses);
        this._tab.Controls.Add(this.pageJobs);
        this._tab.Controls.Add(this.pageMonitor);
        this._tab.Controls.Add(this.pageServices);
        this._tab.Controls.Add(this.pageNetwork);
        this._tab.Controls.Add(this.pageFile);
        this._tab.Controls.Add(this.pageSearch);
        this._tab.Controls.Add(this.pageHelp);
        this._tab.Dock = System.Windows.Forms.DockStyle.Fill;
        this._tab.Location = new System.Drawing.Point(0, 0);
        this._tab.Name = "_tab";
        this._tab.SelectedIndex = 0;
        this._tab.Size = new System.Drawing.Size(866, 389);
        this._tab.TabIndex = 3;
        // 
        // pageTasks
        // 
        this.pageTasks.BackColor = System.Drawing.Color.Transparent;
        this.pageTasks.Controls.Add(this.panelMain13);
        this.pageTasks.Location = new System.Drawing.Point(4, 22);
        this.pageTasks.Name = "pageTasks";
        this.pageTasks.Padding = new System.Windows.Forms.Padding(3);
        this.pageTasks.Size = new System.Drawing.Size(858, 363);
        this.pageTasks.TabIndex = 11;
        this.pageTasks.Text = "Tasks";
        this.pageTasks.UseVisualStyleBackColor = true;
        // 
        // panelMain13
        // 
        this.panelMain13.Controls.Add(this.SplitContainerTask);
        this.panelMain13.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain13.Location = new System.Drawing.Point(3, 3);
        this.panelMain13.Name = "panelMain13";
        this.panelMain13.Size = new System.Drawing.Size(852, 357);
        this.panelMain13.TabIndex = 56;
        // 
        // SplitContainerTask
        // 
        this.SplitContainerTask.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerTask.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerTask.IsSplitterFixed = true;
        this.SplitContainerTask.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerTask.Name = "SplitContainerTask";
        this.SplitContainerTask.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerTask.Panel1
        // 
        this.SplitContainerTask.Panel1.Controls.Add(this.Label19);
        this.SplitContainerTask.Panel1.Controls.Add(this.lblTaskCountResult);
        this.SplitContainerTask.Panel1.Controls.Add(this.txtSearchTask);
        // 
        // SplitContainerTask.Panel2
        // 
        this.SplitContainerTask.Panel2.Controls.Add(this.lvTask);
        this.SplitContainerTask.Size = new System.Drawing.Size(852, 357);
        this.SplitContainerTask.SplitterDistance = 25;
        this.SplitContainerTask.TabIndex = 0;
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(3, 6);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(65, 13);
        this.Label19.TabIndex = 13;
        this.Label19.Text = "Search task";
        // 
        // lblTaskCountResult
        // 
        this.lblTaskCountResult.AutoSize = true;
        this.lblTaskCountResult.Location = new System.Drawing.Point(393, 6);
        this.lblTaskCountResult.Name = "lblTaskCountResult";
        this.lblTaskCountResult.Size = new System.Drawing.Size(56, 13);
        this.lblTaskCountResult.TabIndex = 12;
        this.lblTaskCountResult.Text = "0 result(s)";
        // 
        // txtSearchTask
        // 
        this.txtSearchTask.Location = new System.Drawing.Point(72, 1);
        this.txtSearchTask.Name = "txtSearchTask";
        this.txtSearchTask.Size = new System.Drawing.Size(312, 22);
        this.txtSearchTask.TabIndex = 11;
        // 
        // lvTask
        // 
        this.lvTask.AllowColumnReorder = true;
        this.lvTask.CatchErrors = false;
        this.lvTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader62, this.ColumnHeader63, this.ColumnHeader64 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection1.Snapshot = null;
        CConnection1.SnapshotFile = null;
        this.lvTask.ConnectionObj = CConnection1;
        this.lvTask.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvTask.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvTask.FullRowSelect = true;
        ListViewGroup1.Header = "Tasks";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvTask.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvTask.HideSelection = false;
        this.lvTask.IsConnected = false;
        this.lvTask.Location = new System.Drawing.Point(0, 0);
        this.lvTask.Name = "lvTask";
        this.lvTask.OverriddenDoubleBuffered = true;
        this.lvTask.ReorganizeColumns = true;
        this.lvTask.ShowObjectDetailsOnDoubleClick = false;
        this.lvTask.Size = new System.Drawing.Size(852, 328);
        this.lvTask.TabIndex = 3;
        this.lvTask.UseCompatibleStateImageBehavior = false;
        this.lvTask.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader62
        // 
        this.ColumnHeader62.Text = "Name";
        this.ColumnHeader62.Width = 400;
        // 
        // ColumnHeader63
        // 
        this.ColumnHeader63.Text = "CpuUsage";
        this.ColumnHeader63.Width = 170;
        // 
        // ColumnHeader64
        // 
        this.ColumnHeader64.Text = "Process";
        this.ColumnHeader64.Width = 170;
        // 
        // pageProcesses
        // 
        this.pageProcesses.BackColor = System.Drawing.Color.Transparent;
        this.pageProcesses.Controls.Add(this.containerProcessPage);
        this.pageProcesses.Location = new System.Drawing.Point(4, 22);
        this.pageProcesses.Name = "pageProcesses";
        this.pageProcesses.Padding = new System.Windows.Forms.Padding(3);
        this.pageProcesses.Size = new System.Drawing.Size(858, 363);
        this.pageProcesses.TabIndex = 0;
        this.pageProcesses.Text = "Processes";
        this.pageProcesses.UseVisualStyleBackColor = true;
        // 
        // containerProcessPage
        // 
        this.containerProcessPage.Dock = System.Windows.Forms.DockStyle.Fill;
        this.containerProcessPage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.containerProcessPage.IsSplitterFixed = true;
        this.containerProcessPage.Location = new System.Drawing.Point(3, 3);
        this.containerProcessPage.Name = "containerProcessPage";
        this.containerProcessPage.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // containerProcessPage.Panel1
        // 
        this.containerProcessPage.Panel1.Controls.Add(this.panelMenu);
        // 
        // containerProcessPage.Panel2
        // 
        this.containerProcessPage.Panel2.Controls.Add(this.panelMain);
        this.containerProcessPage.Size = new System.Drawing.Size(852, 357);
        this.containerProcessPage.SplitterDistance = 25;
        this.containerProcessPage.TabIndex = 0;
        // 
        // panelMenu
        // 
        this.panelMenu.Controls.Add(this.Label3);
        this.panelMenu.Controls.Add(this.lblResCount);
        this.panelMenu.Controls.Add(this.txtSearch);
        this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMenu.Location = new System.Drawing.Point(0, 0);
        this.panelMenu.Name = "panelMenu";
        this.panelMenu.Size = new System.Drawing.Size(852, 25);
        this.panelMenu.TabIndex = 48;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(4, 6);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(83, 13);
        this.Label3.TabIndex = 4;
        this.Label3.Text = "Search process";
        // 
        // lblResCount
        // 
        this.lblResCount.AutoSize = true;
        this.lblResCount.Location = new System.Drawing.Point(394, 6);
        this.lblResCount.Name = "lblResCount";
        this.lblResCount.Size = new System.Drawing.Size(56, 13);
        this.lblResCount.TabIndex = 2;
        this.lblResCount.Text = "0 result(s)";
        // 
        // txtSearch
        // 
        this.txtSearch.Location = new System.Drawing.Point(90, 1);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Size = new System.Drawing.Size(298, 22);
        this.txtSearch.TabIndex = 1;
        // 
        // panelMain
        // 
        this.panelMain.Controls.Add(this.SplitContainerProcess);
        this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 0);
        this.panelMain.Name = "panelMain";
        this.panelMain.Size = new System.Drawing.Size(852, 328);
        this.panelMain.TabIndex = 4;
        // 
        // SplitContainerProcess
        // 
        this.SplitContainerProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerProcess.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainerProcess.IsSplitterFixed = true;
        this.SplitContainerProcess.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerProcess.Name = "SplitContainerProcess";
        this.SplitContainerProcess.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerProcess.Panel1
        // 
        this.SplitContainerProcess.Panel1.Controls.Add(this.SplitContainerTvLv);
        this.SplitContainerProcess.Panel2Collapsed = true;
        this.SplitContainerProcess.Size = new System.Drawing.Size(852, 328);
        this.SplitContainerProcess.SplitterDistance = 285;
        this.SplitContainerProcess.TabIndex = 0;
        // 
        // SplitContainerTvLv
        // 
        this.SplitContainerTvLv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerTvLv.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerTvLv.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerTvLv.Name = "SplitContainerTvLv";
        // 
        // SplitContainerTvLv.Panel1
        // 
        this.SplitContainerTvLv.Panel1.Controls.Add(this.tvProc);
        this.SplitContainerTvLv.Panel1Collapsed = true;
        // 
        // SplitContainerTvLv.Panel2
        // 
        this.SplitContainerTvLv.Panel2.Controls.Add(this.lvProcess);
        this.SplitContainerTvLv.Size = new System.Drawing.Size(852, 328);
        this.SplitContainerTvLv.SplitterDistance = 149;
        this.SplitContainerTvLv.TabIndex = 4;
        // 
        // tvProc
        // 
        this.tvProc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tvProc.FullRowSelect = true;
        this.tvProc.Location = new System.Drawing.Point(0, 0);
        this.tvProc.Name = "tvProc";
        TreeNode1.Name = "4";
        TreeNode1.Tag = "4";
        TreeNode1.Text = "System";
        TreeNode2.Name = "0";
        TreeNode2.Tag = "0";
        TreeNode2.Text = "[System process]";
        this.tvProc.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { TreeNode2 });
        this.tvProc.Size = new System.Drawing.Size(149, 100);
        this.tvProc.TabIndex = 4;
        // 
        // lvProcess
        // 
        this.lvProcess.AllowColumnReorder = true;
        this.lvProcess.CatchErrors = false;
        this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.c1, this.c2, this.c3, this.c4, this.c5, this.c7, this.c8, this.c9, this.c10, this.ColumnHeader20 });
        CConnection2.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection2.Snapshot = null;
        CConnection2.SnapshotFile = null;
        this.lvProcess.ConnectionObj = CConnection2;
        this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses;
        this.lvProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcess.FullRowSelect = true;
        ListViewGroup3.Header = "Processes";
        ListViewGroup3.Name = "gpOther";
        ListViewGroup4.Header = "Search result";
        ListViewGroup4.Name = "gpSearch";
        this.lvProcess.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup3, ListViewGroup4 });
        this.lvProcess.HideSelection = false;
        this.lvProcess.IsConnected = false;
        this.lvProcess.Location = new System.Drawing.Point(0, 0);
        this.lvProcess.Name = "lvProcess";
        this.lvProcess.OverriddenDoubleBuffered = true;
        this.lvProcess.ReorganizeColumns = true;
        this.lvProcess.ShowObjectDetailsOnDoubleClick = false;
        this.lvProcess.Size = new System.Drawing.Size(852, 328);
        this.lvProcess.TabIndex = 3;
        this.lvProcess.UseCompatibleStateImageBehavior = false;
        this.lvProcess.View = System.Windows.Forms.View.Details;
        // 
        // c1
        // 
        this.c1.Text = "Name";
        this.c1.Width = 100;
        // 
        // c2
        // 
        this.c2.Text = "PID";
        this.c2.Width = 40;
        // 
        // c3
        // 
        this.c3.Text = "UserName";
        this.c3.Width = 100;
        // 
        // c4
        // 
        this.c4.DisplayIndex = 5;
        this.c4.Text = "TotalCpuTime";
        this.c4.Width = 80;
        // 
        // c5
        // 
        this.c5.DisplayIndex = 6;
        this.c5.Text = "WorkingSet";
        this.c5.Width = 80;
        // 
        // c7
        // 
        this.c7.DisplayIndex = 7;
        this.c7.Text = "Priority";
        this.c7.Width = 70;
        // 
        // c8
        // 
        this.c8.DisplayIndex = 8;
        this.c8.Text = "Path";
        this.c8.Width = 350;
        // 
        // c9
        // 
        this.c9.DisplayIndex = 9;
        this.c9.Text = "StartTime";
        this.c9.Width = 250;
        // 
        // c10
        // 
        this.c10.DisplayIndex = 3;
        this.c10.Text = "CpuUsage";
        // 
        // ColumnHeader20
        // 
        this.ColumnHeader20.DisplayIndex = 4;
        this.ColumnHeader20.Text = "AverageCpuUsage";
        // 
        // pageJobs
        // 
        this.pageJobs.BackColor = System.Drawing.Color.Transparent;
        this.pageJobs.Controls.Add(this.panelMain12);
        this.pageJobs.Location = new System.Drawing.Point(4, 22);
        this.pageJobs.Name = "pageJobs";
        this.pageJobs.Padding = new System.Windows.Forms.Padding(3);
        this.pageJobs.Size = new System.Drawing.Size(858, 363);
        this.pageJobs.TabIndex = 13;
        this.pageJobs.Text = "Jobs";
        this.pageJobs.UseVisualStyleBackColor = true;
        // 
        // panelMain12
        // 
        this.panelMain12.Controls.Add(this.lvJob);
        this.panelMain12.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain12.Location = new System.Drawing.Point(3, 3);
        this.panelMain12.Name = "panelMain12";
        this.panelMain12.Size = new System.Drawing.Size(852, 357);
        this.panelMain12.TabIndex = 58;
        // 
        // lvJob
        // 
        this.lvJob.AllowColumnReorder = true;
        this.lvJob.CatchErrors = false;
        this.lvJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader50, this.ColumnHeader5 });
        CConnection3.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection3.Snapshot = null;
        CConnection3.SnapshotFile = null;
        this.lvJob.ConnectionObj = CConnection3;
        this.lvJob.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvJob.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvJob.FullRowSelect = true;
        ListViewGroup5.Header = "Tasks";
        ListViewGroup5.Name = "gpOther";
        ListViewGroup6.Header = "Search result";
        ListViewGroup6.Name = "gpSearch";
        this.lvJob.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup5, ListViewGroup6 });
        this.lvJob.HideSelection = false;
        this.lvJob.IsConnected = false;
        this.lvJob.Location = new System.Drawing.Point(0, 0);
        this.lvJob.Name = "lvJob";
        this.lvJob.OverriddenDoubleBuffered = true;
        this.lvJob.ReorganizeColumns = true;
        this.lvJob.ShowObjectDetailsOnDoubleClick = false;
        this.lvJob.Size = new System.Drawing.Size(852, 357);
        this.lvJob.TabIndex = 10;
        this.lvJob.UseCompatibleStateImageBehavior = false;
        this.lvJob.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader50
        // 
        this.ColumnHeader50.Text = "Name";
        this.ColumnHeader50.Width = 400;
        // 
        // ColumnHeader5
        // 
        this.ColumnHeader5.Text = "ProcessesCount";
        this.ColumnHeader5.Width = 142;
        // 
        // pageMonitor
        // 
        this.pageMonitor.BackColor = System.Drawing.Color.Transparent;
        this.pageMonitor.Controls.Add(this.panelMain8);
        this.pageMonitor.Location = new System.Drawing.Point(4, 22);
        this.pageMonitor.Name = "pageMonitor";
        this.pageMonitor.Padding = new System.Windows.Forms.Padding(3);
        this.pageMonitor.Size = new System.Drawing.Size(858, 363);
        this.pageMonitor.TabIndex = 7;
        this.pageMonitor.Text = "Monitor";
        this.pageMonitor.UseVisualStyleBackColor = true;
        // 
        // panelMain8
        // 
        this.panelMain8.Controls.Add(this.splitMonitor);
        this.panelMain8.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain8.Location = new System.Drawing.Point(3, 3);
        this.panelMain8.Name = "panelMain8";
        this.panelMain8.Size = new System.Drawing.Size(852, 357);
        this.panelMain8.TabIndex = 51;
        // 
        // splitMonitor
        // 
        this.splitMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMonitor.Location = new System.Drawing.Point(0, 0);
        this.splitMonitor.Name = "splitMonitor";
        // 
        // splitMonitor.Panel1
        // 
        this.splitMonitor.Panel1.Controls.Add(this.tvMonitor);
        // 
        // splitMonitor.Panel2
        // 
        this.splitMonitor.Panel2.Controls.Add(this.splitMonitor2);
        this.splitMonitor.Size = new System.Drawing.Size(852, 357);
        this.splitMonitor.SplitterDistance = 281;
        this.splitMonitor.TabIndex = 0;
        // 
        // tvMonitor
        // 
        this.tvMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tvMonitor.FullRowSelect = true;
        this.tvMonitor.ImageIndex = 0;
        this.tvMonitor.ImageList = this.imgMonitor;
        this.tvMonitor.Location = new System.Drawing.Point(0, 0);
        this.tvMonitor.Name = "tvMonitor";
        TreeNode3.ImageIndex = 1;
        TreeNode3.Name = "processes";
        TreeNode3.SelectedImageIndex = 1;
        TreeNode3.Text = "Items";
        this.tvMonitor.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { TreeNode3 });
        this.tvMonitor.SelectedImageIndex = 0;
        this.tvMonitor.Size = new System.Drawing.Size(281, 357);
        this.tvMonitor.TabIndex = 0;
        // 
        // splitMonitor2
        // 
        this.splitMonitor2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMonitor2.Location = new System.Drawing.Point(0, 0);
        this.splitMonitor2.Name = "splitMonitor2";
        this.splitMonitor2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitMonitor2.Panel1
        // 
        this.splitMonitor2.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.splitMonitor2.Panel1.Controls.Add(this.txtMonitoringLog);
        this.splitMonitor2.Panel1.Controls.Add(this.lvMonitorReport);
        // 
        // splitMonitor2.Panel2
        // 
        this.splitMonitor2.Panel2.Controls.Add(this.splitMonitor3);
        this.splitMonitor2.Size = new System.Drawing.Size(567, 357);
        this.splitMonitor2.SplitterDistance = 133;
        this.splitMonitor2.TabIndex = 0;
        // 
        // txtMonitoringLog
        // 
        this.txtMonitoringLog.BackColor = System.Drawing.Color.White;
        this.txtMonitoringLog.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtMonitoringLog.Font = new System.Drawing.Font("Tahoma", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.txtMonitoringLog.Location = new System.Drawing.Point(0, 0);
        this.txtMonitoringLog.Multiline = true;
        this.txtMonitoringLog.Name = "txtMonitoringLog";
        this.txtMonitoringLog.ReadOnly = true;
        this.txtMonitoringLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txtMonitoringLog.Size = new System.Drawing.Size(567, 133);
        this.txtMonitoringLog.TabIndex = 0;
        this.txtMonitoringLog.Text = "No process monitored." + (char)13 + (char)10 + "Click on 'Add' button to monitor a process.";
        // 
        // lvMonitorReport
        // 
        this.lvMonitorReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader22, this.ColumnHeader2, this.ColumnHeader23, this.ColumnHeader47, this.ColumnHeader48, this.ColumnHeader49 });
        this.lvMonitorReport.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvMonitorReport.FullRowSelect = true;
        this.lvMonitorReport.Location = new System.Drawing.Point(0, 0);
        this.lvMonitorReport.Name = "lvMonitorReport";
        this.lvMonitorReport.OverriddenDoubleBuffered = false;
        this.lvMonitorReport.Size = new System.Drawing.Size(567, 133);
        this.lvMonitorReport.TabIndex = 1;
        this.lvMonitorReport.UseCompatibleStateImageBehavior = false;
        this.lvMonitorReport.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader22
        // 
        this.ColumnHeader22.Text = "Counter";
        this.ColumnHeader22.Width = 150;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "MachineName";
        this.ColumnHeader2.Width = 100;
        // 
        // ColumnHeader23
        // 
        this.ColumnHeader23.Text = "Creation date";
        this.ColumnHeader23.Width = 100;
        // 
        // ColumnHeader47
        // 
        this.ColumnHeader47.Text = "Last start";
        this.ColumnHeader47.Width = 100;
        // 
        // ColumnHeader48
        // 
        this.ColumnHeader48.Text = "State";
        // 
        // ColumnHeader49
        // 
        this.ColumnHeader49.Text = "Interval";
        // 
        // splitMonitor3
        // 
        this.splitMonitor3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMonitor3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.splitMonitor3.IsSplitterFixed = true;
        this.splitMonitor3.Location = new System.Drawing.Point(0, 0);
        this.splitMonitor3.Name = "splitMonitor3";
        this.splitMonitor3.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitMonitor3.Panel1
        // 
        this.splitMonitor3.Panel1.Controls.Add(this.splitMonitor4);
        // 
        // splitMonitor3.Panel2
        // 
        this.splitMonitor3.Panel2.Controls.Add(this.txtMonitorNumber);
        this.splitMonitor3.Panel2.Controls.Add(this.lblMonitorMaxNumber);
        this.splitMonitor3.Panel2.Controls.Add(this.chkMonitorRightAuto);
        this.splitMonitor3.Panel2.Controls.Add(this.chkMonitorLeftAuto);
        this.splitMonitor3.Panel2.Controls.Add(this.dtMonitorR);
        this.splitMonitor3.Panel2.Controls.Add(this.dtMonitorL);
        this.splitMonitor3.Size = new System.Drawing.Size(567, 220);
        this.splitMonitor3.SplitterDistance = 191;
        this.splitMonitor3.TabIndex = 0;
        // 
        // splitMonitor4
        // 
        this.splitMonitor4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMonitor4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.splitMonitor4.IsSplitterFixed = true;
        this.splitMonitor4.Location = new System.Drawing.Point(0, 0);
        this.splitMonitor4.Name = "splitMonitor4";
        this.splitMonitor4.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.splitMonitor4.Panel1Collapsed = true;
        // 
        // splitMonitor4.Panel2
        // 
        this.splitMonitor4.Panel2.Controls.Add(this.graphMonitor);
        this.splitMonitor4.Size = new System.Drawing.Size(567, 191);
        this.splitMonitor4.SplitterDistance = 25;
        this.splitMonitor4.TabIndex = 4;
        // 
        // graphMonitor
        // 
        this.graphMonitor.BackColor = System.Drawing.Color.Black;
        this.graphMonitor.ColorMemory2 = System.Drawing.Color.Blue;
        this.graphMonitor.ColorMemory3 = System.Drawing.Color.Orange;
        this.graphMonitor.dDate = new DateTime(System.Convert.ToInt64(0));
        this.graphMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphMonitor.EnableGraph = false;
        this.graphMonitor.Location = new System.Drawing.Point(0, 0);
        this.graphMonitor.Name = "graphMonitor";
        this.graphMonitor.Size = new System.Drawing.Size(567, 191);
        this.graphMonitor.TabIndex = 3;
        this.graphMonitor.TabStop = false;
        this.graphMonitor.ViewMax = 0;
        this.graphMonitor.ViewMin = 0;
        // 
        // txtMonitorNumber
        // 
        this.txtMonitorNumber.Location = new System.Drawing.Point(241, 0);
        this.txtMonitorNumber.Name = "txtMonitorNumber";
        this.txtMonitorNumber.Size = new System.Drawing.Size(33, 22);
        this.txtMonitorNumber.TabIndex = 11;
        this.txtMonitorNumber.Text = "200";
        // 
        // lblMonitorMaxNumber
        // 
        this.lblMonitorMaxNumber.AutoSize = true;
        this.lblMonitorMaxNumber.Location = new System.Drawing.Point(171, 6);
        this.lblMonitorMaxNumber.Name = "lblMonitorMaxNumber";
        this.lblMonitorMaxNumber.Size = new System.Drawing.Size(66, 13);
        this.lblMonitorMaxNumber.TabIndex = 10;
        this.lblMonitorMaxNumber.Text = "Max. values";
        // 
        // chkMonitorRightAuto
        // 
        this.chkMonitorRightAuto.AutoSize = true;
        this.chkMonitorRightAuto.Checked = true;
        this.chkMonitorRightAuto.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkMonitorRightAuto.Dock = System.Windows.Forms.DockStyle.Right;
        this.chkMonitorRightAuto.Location = new System.Drawing.Point(428, 0);
        this.chkMonitorRightAuto.Name = "chkMonitorRightAuto";
        this.chkMonitorRightAuto.Size = new System.Drawing.Size(50, 25);
        this.chkMonitorRightAuto.TabIndex = 9;
        this.chkMonitorRightAuto.Text = "Now";
        this.chkMonitorRightAuto.UseVisualStyleBackColor = true;
        // 
        // chkMonitorLeftAuto
        // 
        this.chkMonitorLeftAuto.AutoSize = true;
        this.chkMonitorLeftAuto.Checked = true;
        this.chkMonitorLeftAuto.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkMonitorLeftAuto.Location = new System.Drawing.Point(95, 4);
        this.chkMonitorLeftAuto.Name = "chkMonitorLeftAuto";
        this.chkMonitorLeftAuto.Size = new System.Drawing.Size(78, 17);
        this.chkMonitorLeftAuto.TabIndex = 8;
        this.chkMonitorLeftAuto.Text = "Automatic";
        this.chkMonitorLeftAuto.UseVisualStyleBackColor = true;
        // 
        // dtMonitorR
        // 
        this.dtMonitorR.Dock = System.Windows.Forms.DockStyle.Right;
        this.dtMonitorR.Enabled = false;
        this.dtMonitorR.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.dtMonitorR.Location = new System.Drawing.Point(478, 0);
        this.dtMonitorR.Name = "dtMonitorR";
        this.dtMonitorR.Size = new System.Drawing.Size(89, 22);
        this.dtMonitorR.TabIndex = 7;
        // 
        // dtMonitorL
        // 
        this.dtMonitorL.Dock = System.Windows.Forms.DockStyle.Left;
        this.dtMonitorL.Enabled = false;
        this.dtMonitorL.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.dtMonitorL.Location = new System.Drawing.Point(0, 0);
        this.dtMonitorL.Name = "dtMonitorL";
        this.dtMonitorL.Size = new System.Drawing.Size(89, 22);
        this.dtMonitorL.TabIndex = 6;
        // 
        // pageServices
        // 
        this.pageServices.BackColor = System.Drawing.Color.Transparent;
        this.pageServices.Controls.Add(this.containerServicesPage);
        this.pageServices.Location = new System.Drawing.Point(4, 22);
        this.pageServices.Name = "pageServices";
        this.pageServices.Padding = new System.Windows.Forms.Padding(3);
        this.pageServices.Size = new System.Drawing.Size(858, 363);
        this.pageServices.TabIndex = 1;
        this.pageServices.Text = "Services";
        this.pageServices.UseVisualStyleBackColor = true;
        // 
        // containerServicesPage
        // 
        this.containerServicesPage.Dock = System.Windows.Forms.DockStyle.Fill;
        this.containerServicesPage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.containerServicesPage.IsSplitterFixed = true;
        this.containerServicesPage.Location = new System.Drawing.Point(3, 3);
        this.containerServicesPage.Name = "containerServicesPage";
        this.containerServicesPage.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // containerServicesPage.Panel1
        // 
        this.containerServicesPage.Panel1.Controls.Add(this.panelMenu2);
        // 
        // containerServicesPage.Panel2
        // 
        this.containerServicesPage.Panel2.Controls.Add(this.panelMain2);
        this.containerServicesPage.Size = new System.Drawing.Size(852, 357);
        this.containerServicesPage.SplitterDistance = 25;
        this.containerServicesPage.TabIndex = 0;
        // 
        // panelMenu2
        // 
        this.panelMenu2.Controls.Add(this.Label2);
        this.panelMenu2.Controls.Add(this.lblResCount2);
        this.panelMenu2.Controls.Add(this.txtServiceSearch);
        this.panelMenu2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMenu2.Location = new System.Drawing.Point(0, 0);
        this.panelMenu2.Name = "panelMenu2";
        this.panelMenu2.Size = new System.Drawing.Size(852, 25);
        this.panelMenu2.TabIndex = 49;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(6, 6);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(78, 13);
        this.Label2.TabIndex = 3;
        this.Label2.Text = "Search service";
        // 
        // lblResCount2
        // 
        this.lblResCount2.AutoSize = true;
        this.lblResCount2.Location = new System.Drawing.Point(596, 6);
        this.lblResCount2.Name = "lblResCount2";
        this.lblResCount2.Size = new System.Drawing.Size(56, 13);
        this.lblResCount2.TabIndex = 2;
        this.lblResCount2.Text = "0 result(s)";
        // 
        // txtServiceSearch
        // 
        this.txtServiceSearch.Location = new System.Drawing.Point(89, 1);
        this.txtServiceSearch.Name = "txtServiceSearch";
        this.txtServiceSearch.Size = new System.Drawing.Size(501, 22);
        this.txtServiceSearch.TabIndex = 1;
        // 
        // panelMain2
        // 
        this.panelMain2.Controls.Add(this.splitServices);
        this.panelMain2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain2.Location = new System.Drawing.Point(0, 0);
        this.panelMain2.Name = "panelMain2";
        this.panelMain2.Size = new System.Drawing.Size(852, 328);
        this.panelMain2.TabIndex = 17;
        // 
        // splitServices
        // 
        this.splitServices.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitServices.Location = new System.Drawing.Point(0, 0);
        this.splitServices.Name = "splitServices";
        this.splitServices.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitServices.Panel1
        // 
        this.splitServices.Panel1.Controls.Add(this.lvServices);
        // 
        // splitServices.Panel2
        // 
        this.splitServices.Panel2.Controls.Add(this.splitServices2);
        this.splitServices.Size = new System.Drawing.Size(852, 328);
        this.splitServices.SplitterDistance = 196;
        this.splitServices.TabIndex = 0;
        // 
        // lvServices
        // 
        this.lvServices.AllowColumnReorder = true;
        this.lvServices.CatchErrors = false;
        this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader3, this.ColumnHeader7, this.ColumnHeader8, this.ColumnHeader9, this.ColumnHeader10, this.ColumnHeader11, this.ColumnHeader19 });
        CConnection4.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection4.Snapshot = null;
        CConnection4.SnapshotFile = null;
        this.lvServices.ConnectionObj = CConnection4;
        this.lvServices.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvServices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvServices.FullRowSelect = true;
        ListViewGroup7.Header = "Services";
        ListViewGroup7.Name = "gpOther";
        ListViewGroup8.Header = "Search result";
        ListViewGroup8.Name = "gpSearch";
        this.lvServices.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup7, ListViewGroup8 });
        this.lvServices.HideSelection = false;
        this.lvServices.IsConnected = false;
        this.lvServices.Location = new System.Drawing.Point(0, 0);
        this.lvServices.Name = "lvServices";
        this.lvServices.OverriddenDoubleBuffered = true;
        this.lvServices.ProcessId = 0;
        this.lvServices.ReorganizeColumns = true;
        this.lvServices.ShowAll = true;
        this.lvServices.ShowObjectDetailsOnDoubleClick = false;
        this.lvServices.Size = new System.Drawing.Size(852, 196);
        this.lvServices.TabIndex = 1;
        this.lvServices.UseCompatibleStateImageBehavior = false;
        this.lvServices.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Name";
        this.ColumnHeader3.Width = 121;
        // 
        // ColumnHeader7
        // 
        this.ColumnHeader7.Text = "DisplayName";
        this.ColumnHeader7.Width = 243;
        // 
        // ColumnHeader8
        // 
        this.ColumnHeader8.Text = "State";
        this.ColumnHeader8.Width = 79;
        // 
        // ColumnHeader9
        // 
        this.ColumnHeader9.Text = "StartType";
        this.ColumnHeader9.Width = 70;
        // 
        // ColumnHeader10
        // 
        this.ColumnHeader10.Text = "ImagePath";
        this.ColumnHeader10.Width = 250;
        // 
        // ColumnHeader11
        // 
        this.ColumnHeader11.Text = "Process";
        this.ColumnHeader11.Width = 150;
        // 
        // ColumnHeader19
        // 
        this.ColumnHeader19.Text = "ServiceType";
        this.ColumnHeader19.Width = 100;
        // 
        // splitServices2
        // 
        this.splitServices2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitServices2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.splitServices2.IsSplitterFixed = true;
        this.splitServices2.Location = new System.Drawing.Point(0, 0);
        this.splitServices2.Name = "splitServices2";
        this.splitServices2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitServices2.Panel1
        // 
        this.splitServices2.Panel1.Controls.Add(this.cmdCopyServiceToCp);
        this.splitServices2.Panel1.Controls.Add(this.lblServicePath);
        this.splitServices2.Panel1.Controls.Add(this.lblServiceName);
        // 
        // splitServices2.Panel2
        // 
        this.splitServices2.Panel2.Controls.Add(this.splitServices3);
        this.splitServices2.Size = new System.Drawing.Size(852, 128);
        this.splitServices2.SplitterDistance = 35;
        this.splitServices2.TabIndex = 15;
        // 
        // cmdCopyServiceToCp
        // 
        this.cmdCopyServiceToCp.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.cmdCopyServiceToCp.Enabled = false;
        this.cmdCopyServiceToCp.Image = global::My.Resources.Resources.copy16;
        this.cmdCopyServiceToCp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdCopyServiceToCp.Location = new System.Drawing.Point(720, 8);
        this.cmdCopyServiceToCp.Name = "cmdCopyServiceToCp";
        this.cmdCopyServiceToCp.Size = new System.Drawing.Size(130, 24);
        this.cmdCopyServiceToCp.TabIndex = 19;
        this.cmdCopyServiceToCp.Text = "Copy to clipboard";
        this.cmdCopyServiceToCp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdCopyServiceToCp.UseVisualStyleBackColor = true;
        // 
        // lblServicePath
        // 
        this.lblServicePath.BackColor = System.Drawing.SystemColors.Control;
        this.lblServicePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblServicePath.ForeColor = System.Drawing.SystemColors.WindowFrame;
        this.lblServicePath.Location = new System.Drawing.Point(7, 19);
        this.lblServicePath.Name = "lblServicePath";
        this.lblServicePath.ReadOnly = true;
        this.lblServicePath.Size = new System.Drawing.Size(440, 15);
        this.lblServicePath.TabIndex = 18;
        // 
        // lblServiceName
        // 
        this.lblServiceName.Font = new System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblServiceName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.lblServiceName.Location = new System.Drawing.Point(3, 0);
        this.lblServiceName.Name = "lblServiceName";
        this.lblServiceName.Size = new System.Drawing.Size(554, 32);
        this.lblServiceName.TabIndex = 17;
        this.lblServiceName.Text = "Service name :";
        // 
        // splitServices3
        // 
        this.splitServices3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitServices3.Location = new System.Drawing.Point(0, 0);
        this.splitServices3.Name = "splitServices3";
        // 
        // splitServices3.Panel1
        // 
        this.splitServices3.Panel1.Controls.Add(this.rtb2);
        // 
        // splitServices3.Panel2
        // 
        this.splitServices3.Panel2.Controls.Add(this.splitServices4);
        this.splitServices3.Size = new System.Drawing.Size(852, 89);
        this.splitServices3.SplitterDistance = 629;
        this.splitServices3.TabIndex = 0;
        // 
        // rtb2
        // 
        this.rtb2.AutoWordSelection = true;
        this.rtb2.BackColor = System.Drawing.Color.White;
        this.rtb2.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb2.HideSelection = false;
        this.rtb2.Location = new System.Drawing.Point(0, 0);
        this.rtb2.Name = "rtb2";
        this.rtb2.ReadOnly = true;
        this.rtb2.Size = new System.Drawing.Size(629, 89);
        this.rtb2.TabIndex = 13;
        this.rtb2.Text = "";
        this.rtb2.WordWrap = false;
        // 
        // splitServices4
        // 
        this.splitServices4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitServices4.Location = new System.Drawing.Point(0, 0);
        this.splitServices4.Name = "splitServices4";
        this.splitServices4.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitServices4.Panel1
        // 
        this.splitServices4.Panel1.Controls.Add(this.tv2);
        // 
        // splitServices4.Panel2
        // 
        this.splitServices4.Panel2.Controls.Add(this.tv);
        this.splitServices4.Size = new System.Drawing.Size(219, 89);
        this.splitServices4.SplitterDistance = 30;
        this.splitServices4.TabIndex = 0;
        // 
        // tv2
        // 
        CConnection5.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection5.Snapshot = null;
        CConnection5.SnapshotFile = null;
        this.tv2.ConnectionObj = CConnection5;
        this.tv2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tv2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tv2.ImageIndex = 0;
        this.tv2.ImageList = this.imgServices;
        this.tv2.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
        this.tv2.IsConnected = false;
        this.tv2.Location = new System.Drawing.Point(0, 0);
        this.tv2.Name = "tv2";
        this.tv2.RootService = null;
        this.tv2.SelectedImageIndex = 2;
        this.tv2.Size = new System.Drawing.Size(219, 30);
        this.tv2.TabIndex = 15;
        // 
        // tv
        // 
        CConnection6.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection6.Snapshot = null;
        CConnection6.SnapshotFile = null;
        this.tv.ConnectionObj = CConnection6;
        this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tv.ImageIndex = 0;
        this.tv.ImageList = this.imgServices;
        this.tv.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
        this.tv.IsConnected = false;
        this.tv.Location = new System.Drawing.Point(0, 0);
        this.tv.Name = "tv";
        this.tv.RootService = null;
        this.tv.SelectedImageIndex = 0;
        this.tv.Size = new System.Drawing.Size(219, 55);
        this.tv.TabIndex = 14;
        // 
        // pageNetwork
        // 
        this.pageNetwork.BackColor = System.Drawing.Color.Transparent;
        this.pageNetwork.Controls.Add(this.panelMain14);
        this.pageNetwork.Location = new System.Drawing.Point(4, 22);
        this.pageNetwork.Name = "pageNetwork";
        this.pageNetwork.Padding = new System.Windows.Forms.Padding(3);
        this.pageNetwork.Size = new System.Drawing.Size(858, 363);
        this.pageNetwork.TabIndex = 12;
        this.pageNetwork.Text = "Network";
        this.pageNetwork.UseVisualStyleBackColor = true;
        // 
        // panelMain14
        // 
        this.panelMain14.Controls.Add(this.lvNetwork);
        this.panelMain14.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain14.Location = new System.Drawing.Point(3, 3);
        this.panelMain14.Name = "panelMain14";
        this.panelMain14.Size = new System.Drawing.Size(852, 357);
        this.panelMain14.TabIndex = 57;
        // 
        // lvNetwork
        // 
        this.lvNetwork.AllowColumnReorder = true;
        this.lvNetwork.CatchErrors = false;
        this.lvNetwork.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader66, this.ColumnHeader67, this.ColumnHeader68, this.ColumnHeader69 });
        CConnection7.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection7.Snapshot = null;
        CConnection7.SnapshotFile = null;
        this.lvNetwork.ConnectionObj = CConnection7;
        this.lvNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvNetwork.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvNetwork.FullRowSelect = true;
        this.lvNetwork.HideSelection = false;
        this.lvNetwork.IsConnected = false;
        this.lvNetwork.Location = new System.Drawing.Point(0, 0);
        this.lvNetwork.Name = "lvNetwork";
        this.lvNetwork.OverriddenDoubleBuffered = true;
        this.lvNetwork.ProcessId = 0;
        this.lvNetwork.ReorganizeColumns = true;
        this.lvNetwork.ShowAllPid = false;
        this.lvNetwork.ShowConnectionsByProcessesGroup = false;
        this.lvNetwork.ShowObjectDetailsOnDoubleClick = true;
        this.lvNetwork.Size = new System.Drawing.Size(852, 357);
        this.lvNetwork.TabIndex = 4;
        this.lvNetwork.UseCompatibleStateImageBehavior = false;
        this.lvNetwork.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader66
        // 
        this.ColumnHeader66.Text = "Local";
        this.ColumnHeader66.Width = 200;
        // 
        // ColumnHeader67
        // 
        this.ColumnHeader67.Text = "Remote";
        this.ColumnHeader67.Width = 250;
        // 
        // ColumnHeader68
        // 
        this.ColumnHeader68.Text = "Protocol";
        this.ColumnHeader68.Width = 100;
        // 
        // ColumnHeader69
        // 
        this.ColumnHeader69.Text = "State";
        this.ColumnHeader69.Width = 150;
        // 
        // pageFile
        // 
        this.pageFile.BackColor = System.Drawing.Color.Transparent;
        this.pageFile.Controls.Add(this.panelMain5);
        this.pageFile.Location = new System.Drawing.Point(4, 22);
        this.pageFile.Name = "pageFile";
        this.pageFile.Padding = new System.Windows.Forms.Padding(3);
        this.pageFile.Size = new System.Drawing.Size(858, 363);
        this.pageFile.TabIndex = 4;
        this.pageFile.Text = "File";
        this.pageFile.UseVisualStyleBackColor = true;
        // 
        // panelMain5
        // 
        this.panelMain5.Controls.Add(this.SplitContainerFilexx);
        this.panelMain5.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain5.Location = new System.Drawing.Point(3, 3);
        this.panelMain5.Name = "panelMain5";
        this.panelMain5.Size = new System.Drawing.Size(852, 357);
        this.panelMain5.TabIndex = 48;
        // 
        // SplitContainerFilexx
        // 
        this.SplitContainerFilexx.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerFilexx.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerFilexx.IsSplitterFixed = true;
        this.SplitContainerFilexx.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerFilexx.Name = "SplitContainerFilexx";
        this.SplitContainerFilexx.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerFilexx.Panel1
        // 
        this.SplitContainerFilexx.Panel1.Controls.Add(this.txtFile);
        this.SplitContainerFilexx.Panel1.Controls.Add(this.cmdFileClipboard);
        this.SplitContainerFilexx.Panel1.Controls.Add(this.pctFileSmall);
        this.SplitContainerFilexx.Panel1.Controls.Add(this.pctFileBig);
        // 
        // SplitContainerFilexx.Panel2
        // 
        this.SplitContainerFilexx.Panel2.Controls.Add(this.SplitContainerFile);
        this.SplitContainerFilexx.Size = new System.Drawing.Size(852, 357);
        this.SplitContainerFilexx.SplitterDistance = 35;
        this.SplitContainerFilexx.TabIndex = 0;
        // 
        // txtFile
        // 
        this.txtFile.BackColor = System.Drawing.SystemColors.Control;
        this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtFile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.txtFile.ForeColor = System.Drawing.SystemColors.WindowFrame;
        this.txtFile.Location = new System.Drawing.Point(5, 9);
        this.txtFile.Name = "txtFile";
        this.txtFile.ReadOnly = true;
        this.txtFile.Size = new System.Drawing.Size(240, 16);
        this.txtFile.TabIndex = 22;
        this.txtFile.Text = "No selected file";
        // 
        // cmdFileClipboard
        // 
        this.cmdFileClipboard.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.cmdFileClipboard.Enabled = false;
        this.cmdFileClipboard.Image = global::My.Resources.Resources.copy16;
        this.cmdFileClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdFileClipboard.Location = new System.Drawing.Point(651, 7);
        this.cmdFileClipboard.Name = "cmdFileClipboard";
        this.cmdFileClipboard.Size = new System.Drawing.Size(130, 24);
        this.cmdFileClipboard.TabIndex = 21;
        this.cmdFileClipboard.Text = "Copy to clipboard";
        this.cmdFileClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdFileClipboard.UseVisualStyleBackColor = true;
        // 
        // pctFileSmall
        // 
        this.pctFileSmall.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.pctFileSmall.Location = new System.Drawing.Point(794, 16);
        this.pctFileSmall.Name = "pctFileSmall";
        this.pctFileSmall.Size = new System.Drawing.Size(16, 16);
        this.pctFileSmall.TabIndex = 20;
        this.pctFileSmall.TabStop = false;
        // 
        // pctFileBig
        // 
        this.pctFileBig.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.pctFileBig.Location = new System.Drawing.Point(816, 0);
        this.pctFileBig.Name = "pctFileBig";
        this.pctFileBig.Size = new System.Drawing.Size(32, 32);
        this.pctFileBig.TabIndex = 19;
        this.pctFileBig.TabStop = false;
        // 
        // SplitContainerFile
        // 
        this.SplitContainerFile.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerFile.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerFile.Name = "SplitContainerFile";
        // 
        // SplitContainerFile.Panel1
        // 
        this.SplitContainerFile.Panel1.Controls.Add(this.SplitContainerFile2);
        // 
        // SplitContainerFile.Panel2
        // 
        this.SplitContainerFile.Panel2.Controls.Add(this.lvFileString);
        this.SplitContainerFile.Size = new System.Drawing.Size(852, 318);
        this.SplitContainerFile.SplitterDistance = 581;
        this.SplitContainerFile.TabIndex = 15;
        // 
        // SplitContainerFile2
        // 
        this.SplitContainerFile2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerFile2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainerFile2.IsSplitterFixed = true;
        this.SplitContainerFile2.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerFile2.Name = "SplitContainerFile2";
        this.SplitContainerFile2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerFile2.Panel1
        // 
        this.SplitContainerFile2.Panel1.Controls.Add(this.rtb3);
        // 
        // SplitContainerFile2.Panel2
        // 
        this.SplitContainerFile2.Panel2.Controls.Add(this.gpFileAttributes);
        this.SplitContainerFile2.Panel2.Controls.Add(this.gpFileDates);
        this.SplitContainerFile2.Size = new System.Drawing.Size(581, 318);
        this.SplitContainerFile2.SplitterDistance = 202;
        this.SplitContainerFile2.TabIndex = 3;
        // 
        // rtb3
        // 
        this.rtb3.AutoWordSelection = true;
        this.rtb3.BackColor = System.Drawing.Color.White;
        this.rtb3.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb3.HideSelection = false;
        this.rtb3.Location = new System.Drawing.Point(0, 0);
        this.rtb3.Name = "rtb3";
        this.rtb3.ReadOnly = true;
        this.rtb3.Size = new System.Drawing.Size(581, 202);
        this.rtb3.TabIndex = 21;
        this.rtb3.Text = "";
        // 
        // gpFileAttributes
        // 
        this.gpFileAttributes.Controls.Add(this.chkFileEncrypted);
        this.gpFileAttributes.Controls.Add(this.chkFileContentNotIndexed);
        this.gpFileAttributes.Controls.Add(this.chkFileNormal);
        this.gpFileAttributes.Controls.Add(this.chkFileSystem);
        this.gpFileAttributes.Controls.Add(this.chkFileReadOnly);
        this.gpFileAttributes.Controls.Add(this.chkFileHidden);
        this.gpFileAttributes.Controls.Add(this.chkFileCompressed);
        this.gpFileAttributes.Controls.Add(this.chkFileArchive);
        this.gpFileAttributes.Dock = System.Windows.Forms.DockStyle.Left;
        this.gpFileAttributes.Location = new System.Drawing.Point(203, 0);
        this.gpFileAttributes.Name = "gpFileAttributes";
        this.gpFileAttributes.Size = new System.Drawing.Size(173, 112);
        this.gpFileAttributes.TabIndex = 19;
        this.gpFileAttributes.TabStop = false;
        this.gpFileAttributes.Text = "File attributes";
        // 
        // chkFileEncrypted
        // 
        this.chkFileEncrypted.AutoSize = true;
        this.chkFileEncrypted.Enabled = false;
        this.chkFileEncrypted.Location = new System.Drawing.Point(91, 51);
        this.chkFileEncrypted.Name = "chkFileEncrypted";
        this.chkFileEncrypted.Size = new System.Drawing.Size(77, 17);
        this.chkFileEncrypted.TabIndex = 7;
        this.chkFileEncrypted.Text = "Encrypted";
        this.chkFileEncrypted.UseVisualStyleBackColor = true;
        // 
        // chkFileContentNotIndexed
        // 
        this.chkFileContentNotIndexed.AutoSize = true;
        this.chkFileContentNotIndexed.Location = new System.Drawing.Point(6, 88);
        this.chkFileContentNotIndexed.Name = "chkFileContentNotIndexed";
        this.chkFileContentNotIndexed.Size = new System.Drawing.Size(133, 17);
        this.chkFileContentNotIndexed.TabIndex = 6;
        this.chkFileContentNotIndexed.Text = "Content not indexed";
        this.chkFileContentNotIndexed.UseVisualStyleBackColor = true;
        // 
        // chkFileNormal
        // 
        this.chkFileNormal.AutoSize = true;
        this.chkFileNormal.Enabled = false;
        this.chkFileNormal.Location = new System.Drawing.Point(91, 15);
        this.chkFileNormal.Name = "chkFileNormal";
        this.chkFileNormal.Size = new System.Drawing.Size(63, 17);
        this.chkFileNormal.TabIndex = 5;
        this.chkFileNormal.Text = "Normal";
        this.chkFileNormal.UseVisualStyleBackColor = true;
        // 
        // chkFileSystem
        // 
        this.chkFileSystem.AutoSize = true;
        this.chkFileSystem.Location = new System.Drawing.Point(91, 33);
        this.chkFileSystem.Name = "chkFileSystem";
        this.chkFileSystem.Size = new System.Drawing.Size(61, 17);
        this.chkFileSystem.TabIndex = 4;
        this.chkFileSystem.Text = "System";
        this.chkFileSystem.UseVisualStyleBackColor = true;
        // 
        // chkFileReadOnly
        // 
        this.chkFileReadOnly.AutoSize = true;
        this.chkFileReadOnly.Location = new System.Drawing.Point(6, 70);
        this.chkFileReadOnly.Name = "chkFileReadOnly";
        this.chkFileReadOnly.Size = new System.Drawing.Size(77, 17);
        this.chkFileReadOnly.TabIndex = 3;
        this.chkFileReadOnly.Text = "Read only";
        this.chkFileReadOnly.UseVisualStyleBackColor = true;
        // 
        // chkFileHidden
        // 
        this.chkFileHidden.AutoSize = true;
        this.chkFileHidden.Location = new System.Drawing.Point(6, 52);
        this.chkFileHidden.Name = "chkFileHidden";
        this.chkFileHidden.Size = new System.Drawing.Size(64, 17);
        this.chkFileHidden.TabIndex = 2;
        this.chkFileHidden.Text = "Hidden";
        this.chkFileHidden.UseVisualStyleBackColor = true;
        // 
        // chkFileCompressed
        // 
        this.chkFileCompressed.AutoSize = true;
        this.chkFileCompressed.Enabled = false;
        this.chkFileCompressed.Location = new System.Drawing.Point(6, 34);
        this.chkFileCompressed.Name = "chkFileCompressed";
        this.chkFileCompressed.Size = new System.Drawing.Size(89, 17);
        this.chkFileCompressed.TabIndex = 1;
        this.chkFileCompressed.Text = "Compressed";
        this.chkFileCompressed.UseVisualStyleBackColor = true;
        // 
        // chkFileArchive
        // 
        this.chkFileArchive.AutoSize = true;
        this.chkFileArchive.Location = new System.Drawing.Point(6, 17);
        this.chkFileArchive.Name = "chkFileArchive";
        this.chkFileArchive.Size = new System.Drawing.Size(63, 17);
        this.chkFileArchive.TabIndex = 0;
        this.chkFileArchive.Text = "Archive";
        this.chkFileArchive.UseVisualStyleBackColor = true;
        // 
        // gpFileDates
        // 
        this.gpFileDates.Controls.Add(this.cmdSetFileDates);
        this.gpFileDates.Controls.Add(this.DTlastModification);
        this.gpFileDates.Controls.Add(this.DTlastAccess);
        this.gpFileDates.Controls.Add(this.DTcreation);
        this.gpFileDates.Controls.Add(this.Label6);
        this.gpFileDates.Controls.Add(this.Label5);
        this.gpFileDates.Controls.Add(this.Label4);
        this.gpFileDates.Dock = System.Windows.Forms.DockStyle.Left;
        this.gpFileDates.Location = new System.Drawing.Point(0, 0);
        this.gpFileDates.Name = "gpFileDates";
        this.gpFileDates.Size = new System.Drawing.Size(203, 112);
        this.gpFileDates.TabIndex = 18;
        this.gpFileDates.TabStop = false;
        this.gpFileDates.Text = "File dates";
        // 
        // cmdSetFileDates
        // 
        this.cmdSetFileDates.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.cmdSetFileDates.Location = new System.Drawing.Point(3, 87);
        this.cmdSetFileDates.Name = "cmdSetFileDates";
        this.cmdSetFileDates.Size = new System.Drawing.Size(197, 22);
        this.cmdSetFileDates.TabIndex = 6;
        this.cmdSetFileDates.Text = "Set dates";
        this.cmdSetFileDates.UseVisualStyleBackColor = true;
        // 
        // DTlastModification
        // 
        this.DTlastModification.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.DTlastModification.Location = new System.Drawing.Point(102, 57);
        this.DTlastModification.Name = "DTlastModification";
        this.DTlastModification.Size = new System.Drawing.Size(84, 22);
        this.DTlastModification.TabIndex = 5;
        // 
        // DTlastAccess
        // 
        this.DTlastAccess.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.DTlastAccess.Location = new System.Drawing.Point(102, 35);
        this.DTlastAccess.Name = "DTlastAccess";
        this.DTlastAccess.Size = new System.Drawing.Size(84, 22);
        this.DTlastAccess.TabIndex = 4;
        // 
        // DTcreation
        // 
        this.DTcreation.CustomFormat = "";
        this.DTcreation.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.DTcreation.Location = new System.Drawing.Point(102, 13);
        this.DTcreation.Name = "DTcreation";
        this.DTcreation.Size = new System.Drawing.Size(84, 22);
        this.DTcreation.TabIndex = 3;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(6, 41);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(62, 13);
        this.Label6.TabIndex = 2;
        this.Label6.Text = "Last access";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(6, 63);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(95, 13);
        this.Label5.TabIndex = 1;
        this.Label5.Text = "Last modification";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 19);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(51, 13);
        this.Label4.TabIndex = 0;
        this.Label4.Text = "Creation";
        // 
        // lvFileString
        // 
        this.lvFileString.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.headerString });
        this.lvFileString.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvFileString.FullRowSelect = true;
        this.lvFileString.Location = new System.Drawing.Point(0, 0);
        this.lvFileString.Name = "lvFileString";
        this.lvFileString.OverriddenDoubleBuffered = true;
        this.lvFileString.Size = new System.Drawing.Size(267, 318);
        this.lvFileString.TabIndex = 22;
        this.lvFileString.UseCompatibleStateImageBehavior = false;
        this.lvFileString.View = System.Windows.Forms.View.Details;
        // 
        // headerString
        // 
        this.headerString.Text = "Strings";
        this.headerString.Width = 250;
        // 
        // pageSearch
        // 
        this.pageSearch.BackColor = System.Drawing.Color.Transparent;
        this.pageSearch.Controls.Add(this.panelMain6);
        this.pageSearch.Location = new System.Drawing.Point(4, 22);
        this.pageSearch.Name = "pageSearch";
        this.pageSearch.Padding = new System.Windows.Forms.Padding(3);
        this.pageSearch.Size = new System.Drawing.Size(858, 363);
        this.pageSearch.TabIndex = 5;
        this.pageSearch.Text = "Search";
        this.pageSearch.UseVisualStyleBackColor = true;
        // 
        // panelMain6
        // 
        this.panelMain6.Controls.Add(this.SplitContainerSearch);
        this.panelMain6.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain6.Location = new System.Drawing.Point(3, 3);
        this.panelMain6.Name = "panelMain6";
        this.panelMain6.Size = new System.Drawing.Size(852, 357);
        this.panelMain6.TabIndex = 49;
        // 
        // SplitContainerSearch
        // 
        this.SplitContainerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerSearch.IsSplitterFixed = true;
        this.SplitContainerSearch.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerSearch.Name = "SplitContainerSearch";
        this.SplitContainerSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerSearch.Panel1
        // 
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchEnvVar);
        this.SplitContainerSearch.Panel1.Controls.Add(this.Label11);
        this.SplitContainerSearch.Panel1.Controls.Add(this.lblResultsCount);
        this.SplitContainerSearch.Panel1.Controls.Add(this.txtSearchResults);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchWindows);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchHandles);
        this.SplitContainerSearch.Panel1.Controls.Add(this.Label1);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchModules);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchServices);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchProcess);
        this.SplitContainerSearch.Panel1.Controls.Add(this.chkSearchCase);
        // 
        // SplitContainerSearch.Panel2
        // 
        this.SplitContainerSearch.Panel2.Controls.Add(this.lvSearchResults);
        this.SplitContainerSearch.Size = new System.Drawing.Size(852, 357);
        this.SplitContainerSearch.SplitterDistance = 55;
        this.SplitContainerSearch.TabIndex = 2;
        // 
        // chkSearchEnvVar
        // 
        this.chkSearchEnvVar.AutoSize = true;
        this.chkSearchEnvVar.Checked = true;
        this.chkSearchEnvVar.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchEnvVar.Location = new System.Drawing.Point(376, 7);
        this.chkSearchEnvVar.Name = "chkSearchEnvVar";
        this.chkSearchEnvVar.Size = new System.Drawing.Size(134, 17);
        this.chkSearchEnvVar.TabIndex = 14;
        this.chkSearchEnvVar.Text = "environment variable";
        this.chkSearchEnvVar.UseVisualStyleBackColor = true;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(6, 34);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(73, 13);
        this.Label11.TabIndex = 13;
        this.Label11.Text = "Search result";
        // 
        // lblResultsCount
        // 
        this.lblResultsCount.AutoSize = true;
        this.lblResultsCount.Location = new System.Drawing.Point(396, 34);
        this.lblResultsCount.Name = "lblResultsCount";
        this.lblResultsCount.Size = new System.Drawing.Size(56, 13);
        this.lblResultsCount.TabIndex = 12;
        this.lblResultsCount.Text = "0 result(s)";
        // 
        // txtSearchResults
        // 
        this.txtSearchResults.Location = new System.Drawing.Point(89, 31);
        this.txtSearchResults.Name = "txtSearchResults";
        this.txtSearchResults.Size = new System.Drawing.Size(298, 22);
        this.txtSearchResults.TabIndex = 11;
        // 
        // chkSearchWindows
        // 
        this.chkSearchWindows.AutoSize = true;
        this.chkSearchWindows.Checked = true;
        this.chkSearchWindows.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchWindows.Location = new System.Drawing.Point(656, 8);
        this.chkSearchWindows.Name = "chkSearchWindows";
        this.chkSearchWindows.Size = new System.Drawing.Size(73, 17);
        this.chkSearchWindows.TabIndex = 6;
        this.chkSearchWindows.Text = "windows";
        this.chkSearchWindows.UseVisualStyleBackColor = true;
        // 
        // chkSearchHandles
        // 
        this.chkSearchHandles.AutoSize = true;
        this.chkSearchHandles.Checked = true;
        this.chkSearchHandles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchHandles.Location = new System.Drawing.Point(587, 8);
        this.chkSearchHandles.Name = "chkSearchHandles";
        this.chkSearchHandles.Size = new System.Drawing.Size(67, 17);
        this.chkSearchHandles.TabIndex = 5;
        this.chkSearchHandles.Text = "handles";
        this.chkSearchHandles.UseVisualStyleBackColor = true;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(162, 8);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(53, 13);
        this.Label1.TabIndex = 4;
        this.Label1.Text = "search in";
        // 
        // chkSearchModules
        // 
        this.chkSearchModules.AutoSize = true;
        this.chkSearchModules.Checked = true;
        this.chkSearchModules.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchModules.Location = new System.Drawing.Point(300, 7);
        this.chkSearchModules.Name = "chkSearchModules";
        this.chkSearchModules.Size = new System.Drawing.Size(70, 17);
        this.chkSearchModules.TabIndex = 3;
        this.chkSearchModules.Text = "modules";
        this.chkSearchModules.UseVisualStyleBackColor = true;
        // 
        // chkSearchServices
        // 
        this.chkSearchServices.AutoSize = true;
        this.chkSearchServices.Checked = true;
        this.chkSearchServices.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchServices.Location = new System.Drawing.Point(516, 8);
        this.chkSearchServices.Name = "chkSearchServices";
        this.chkSearchServices.Size = new System.Drawing.Size(65, 17);
        this.chkSearchServices.TabIndex = 2;
        this.chkSearchServices.Text = "services";
        this.chkSearchServices.UseVisualStyleBackColor = true;
        // 
        // chkSearchProcess
        // 
        this.chkSearchProcess.AutoSize = true;
        this.chkSearchProcess.Checked = true;
        this.chkSearchProcess.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSearchProcess.Location = new System.Drawing.Point(223, 7);
        this.chkSearchProcess.Name = "chkSearchProcess";
        this.chkSearchProcess.Size = new System.Drawing.Size(76, 17);
        this.chkSearchProcess.TabIndex = 1;
        this.chkSearchProcess.Text = "processes";
        this.chkSearchProcess.UseVisualStyleBackColor = true;
        // 
        // chkSearchCase
        // 
        this.chkSearchCase.AutoSize = true;
        this.chkSearchCase.Location = new System.Drawing.Point(8, 7);
        this.chkSearchCase.Name = "chkSearchCase";
        this.chkSearchCase.Size = new System.Drawing.Size(97, 17);
        this.chkSearchCase.TabIndex = 0;
        this.chkSearchCase.Text = "Case sensitive";
        this.chkSearchCase.UseVisualStyleBackColor = true;
        // 
        // lvSearchResults
        // 
        this.lvSearchResults.AllowColumnReorder = true;
        this.lvSearchResults.CaseSensitive = false;
        this.lvSearchResults.CatchErrors = false;
        this.lvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader12, this.ColumnHeader13, this.ColumnHeader14, this.ColumnHeader17 });
        CConnection8.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection8.Snapshot = null;
        CConnection8.SnapshotFile = null;
        this.lvSearchResults.ConnectionObj = CConnection8;
        this.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvSearchResults.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvSearchResults.FullRowSelect = true;
        ListViewGroup9.Header = "Results";
        ListViewGroup9.Name = "gpResults";
        ListViewGroup10.Header = "Search results";
        ListViewGroup10.Name = "gpSearchResults";
        this.lvSearchResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup9, ListViewGroup10 });
        this.lvSearchResults.HideSelection = false;
        this.lvSearchResults.Includes = Native.Api.Enums.GeneralObjectType.Process;
        this.lvSearchResults.IsConnected = false;
        this.lvSearchResults.Location = new System.Drawing.Point(0, 0);
        this.lvSearchResults.Name = "lvSearchResults";
        this.lvSearchResults.OverriddenDoubleBuffered = true;
        this.lvSearchResults.ReorganizeColumns = true;
        this.lvSearchResults.SearchString = null;
        this.lvSearchResults.ShowObjectDetailsOnDoubleClick = true;
        this.lvSearchResults.Size = new System.Drawing.Size(852, 298);
        this.lvSearchResults.TabIndex = 3;
        this.lvSearchResults.UseCompatibleStateImageBehavior = false;
        this.lvSearchResults.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader12
        // 
        this.ColumnHeader12.Text = "Type";
        this.ColumnHeader12.Width = 150;
        // 
        // ColumnHeader13
        // 
        this.ColumnHeader13.Text = "Result";
        this.ColumnHeader13.Width = 400;
        // 
        // ColumnHeader14
        // 
        this.ColumnHeader14.Text = "Field";
        this.ColumnHeader14.Width = 150;
        // 
        // ColumnHeader17
        // 
        this.ColumnHeader17.Text = "Owner";
        this.ColumnHeader17.Width = 150;
        // 
        // pageHelp
        // 
        this.pageHelp.BackColor = System.Drawing.Color.Transparent;
        this.pageHelp.Controls.Add(this.panelMain4);
        this.pageHelp.Location = new System.Drawing.Point(4, 22);
        this.pageHelp.Name = "pageHelp";
        this.pageHelp.Padding = new System.Windows.Forms.Padding(3);
        this.pageHelp.Size = new System.Drawing.Size(858, 363);
        this.pageHelp.TabIndex = 3;
        this.pageHelp.Text = "Help";
        this.pageHelp.UseVisualStyleBackColor = true;
        // 
        // panelMain4
        // 
        this.panelMain4.Controls.Add(this.WBHelp);
        this.panelMain4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain4.Location = new System.Drawing.Point(3, 3);
        this.panelMain4.Name = "panelMain4";
        this.panelMain4.Size = new System.Drawing.Size(852, 357);
        this.panelMain4.TabIndex = 17;
        // 
        // WBHelp
        // 
        this.WBHelp.AllowWebBrowserDrop = false;
        this.WBHelp.Dock = System.Windows.Forms.DockStyle.Fill;
        this.WBHelp.IsWebBrowserContextMenuEnabled = false;
        this.WBHelp.Location = new System.Drawing.Point(0, 0);
        this.WBHelp.MinimumSize = new System.Drawing.Size(20, 20);
        this.WBHelp.Name = "WBHelp";
        this.WBHelp.Size = new System.Drawing.Size(852, 357);
        this.WBHelp.TabIndex = 0;
        this.WBHelp.Url = new System.Uri("", System.UriKind.Relative);
        this.WBHelp.WebBrowserShortcutsEnabled = false;
        // 
        // timerNetwork
        // 
        this.timerNetwork.Interval = 1000;
        // 
        // timerStateBasedActions
        // 
        this.timerStateBasedActions.Interval = 1000;
        // 
        // MenuItemTaskShow
        // 
        this.MenuItemTaskShow.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemTaskShow, global::My.Resources.Resources.monitor16);
        this.MenuItemTaskShow.Index = 0;
        this.MenuItemTaskShow.Text = "Show window";
        // 
        // MenuItemTaskEnd
        // 
        this.VistaMenu.SetImage(this.MenuItemTaskEnd, global::My.Resources.Resources.cross16);
        this.MenuItemTaskEnd.Index = 4;
        this.MenuItemTaskEnd.Text = "End task";
        // 
        // MenuItemTaskSelProc
        // 
        this.MenuItemTaskSelProc.Enabled = false;
        this.VistaMenu.SetImage(this.MenuItemTaskSelProc, global::My.Resources.Resources.exe16);
        this.MenuItemTaskSelProc.Index = 6;
        this.MenuItemTaskSelProc.Text = "Select associated process";
        // 
        // MenuItemMonitorAdd
        // 
        this.VistaMenu.SetImage(this.MenuItemMonitorAdd, global::My.Resources.Resources.plus_circle);
        this.MenuItemMonitorAdd.Index = 0;
        this.MenuItemMonitorAdd.Text = "Add...";
        // 
        // MenuItemMonitorRemove
        // 
        this.VistaMenu.SetImage(this.MenuItemMonitorRemove, global::My.Resources.Resources.cross16);
        this.MenuItemMonitorRemove.Index = 1;
        this.MenuItemMonitorRemove.Text = "Remove selection";
        // 
        // MenuItemMonitorStart
        // 
        this.MenuItemMonitorStart.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemMonitorStart, global::My.Resources.Resources.control);
        this.MenuItemMonitorStart.Index = 3;
        this.MenuItemMonitorStart.Text = "Start";
        // 
        // MenuItemMonitorStop
        // 
        this.VistaMenu.SetImage(this.MenuItemMonitorStop, global::My.Resources.Resources.control_stop_square);
        this.MenuItemMonitorStop.Index = 4;
        this.MenuItemMonitorStop.Text = "Stop";
        // 
        // MenuItemCopyBig
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyBig, global::My.Resources.Resources.copy16);
        this.MenuItemCopyBig.Index = 0;
        this.MenuItemCopyBig.Text = "Copy to clipboard";
        // 
        // MenuItemCopySmall
        // 
        this.VistaMenu.SetImage(this.MenuItemCopySmall, global::My.Resources.Resources.copy16);
        this.MenuItemCopySmall.Index = 0;
        this.MenuItemCopySmall.Text = "Copy to clipboard";
        // 
        // MenuItemMainShow
        // 
        this.MenuItemMainShow.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemMainShow, global::My.Resources.Resources.monitor16);
        this.MenuItemMainShow.Index = 0;
        this.MenuItemMainShow.Text = "Show YAPM";
        // 
        // MenuItemMainToTray
        // 
        this.VistaMenu.SetImage(this.MenuItemMainToTray, global::My.Resources.Resources.down16);
        this.MenuItemMainToTray.Index = 1;
        this.MenuItemMainToTray.Text = "Minimize to tray";
        // 
        // MenuItemMainAbout
        // 
        this.VistaMenu.SetImage(this.MenuItemMainAbout, global::My.Resources.Resources.information_frame);
        this.MenuItemMainAbout.Index = 2;
        this.MenuItemMainAbout.Text = "About YAPM";
        // 
        // MenuItemMainLog
        // 
        this.VistaMenu.SetImage(this.MenuItemMainLog, global::My.Resources.Resources.document_text);
        this.MenuItemMainLog.Index = 9;
        this.MenuItemMainLog.Text = "Show log";
        // 
        // MenuItemMainOpenedW
        // 
        this.VistaMenu.SetImage(this.MenuItemMainOpenedW, global::My.Resources.Resources.monitor16);
        this.MenuItemMainOpenedW.Index = 13;
        this.MenuItemMainOpenedW.Text = "Opened windows";
        // 
        // MenuItemMainExit
        // 
        this.VistaMenu.SetImage(this.MenuItemMainExit, global::My.Resources.Resources.cross16);
        this.MenuItemMainExit.Index = 21;
        this.MenuItemMainExit.Text = "Exit YAPM";
        // 
        // MenuItemMainSysInfo
        // 
        this.VistaMenu.SetImage(this.MenuItemMainSysInfo, global::My.Resources.Resources.taskmgr);
        this.MenuItemMainSysInfo.Index = 11;
        this.MenuItemMainSysInfo.Text = "System information";
        // 
        // MenuItemServSelService
        // 
        this.MenuItemServSelService.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemServSelService, global::My.Resources.Resources.exe16);
        this.MenuItemServSelService.Index = 0;
        this.MenuItemServSelService.Text = "Show selected process";
        // 
        // MenuItemServFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemServFileProp, global::My.Resources.Resources.document_text);
        this.MenuItemServFileProp.Index = 2;
        this.MenuItemServFileProp.Text = "File properties";
        // 
        // MenuItemServOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemServOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemServOpenDir.Index = 3;
        this.MenuItemServOpenDir.Text = "Open directory";
        // 
        // MenuItemServFileDetails
        // 
        this.VistaMenu.SetImage(this.MenuItemServFileDetails, global::My.Resources.Resources.magnifier);
        this.MenuItemServFileDetails.Index = 4;
        this.MenuItemServFileDetails.Text = "File details";
        // 
        // MenuItemServSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemServSearch, global::My.Resources.Resources.globe);
        this.MenuItemServSearch.Index = 5;
        this.MenuItemServSearch.Text = "Internet search";
        // 
        // MenuItemServPause
        // 
        this.VistaMenu.SetImage(this.MenuItemServPause, global::My.Resources.Resources.control_pause);
        this.MenuItemServPause.Index = 8;
        this.MenuItemServPause.Text = "Pause";
        // 
        // MenuItemServStop
        // 
        this.VistaMenu.SetImage(this.MenuItemServStop, global::My.Resources.Resources.control_stop_square);
        this.MenuItemServStop.Index = 9;
        this.MenuItemServStop.Text = "Stop";
        // 
        // MenuItemServStart
        // 
        this.VistaMenu.SetImage(this.MenuItemServStart, global::My.Resources.Resources.control);
        this.MenuItemServStart.Index = 10;
        this.MenuItemServStart.Text = "Start";
        // 
        // MenuItemServAutoStart
        // 
        this.VistaMenu.SetImage(this.MenuItemServAutoStart, global::My.Resources.Resources.p6);
        this.MenuItemServAutoStart.Index = 0;
        this.MenuItemServAutoStart.Text = "Auto start";
        // 
        // MenuItemServOnDemand
        // 
        this.VistaMenu.SetImage(this.MenuItemServOnDemand, global::My.Resources.Resources.p3);
        this.MenuItemServOnDemand.Index = 1;
        this.MenuItemServOnDemand.Text = "On demand";
        // 
        // MenuItemServDisabled
        // 
        this.VistaMenu.SetImage(this.MenuItemServDisabled, global::My.Resources.Resources.p0);
        this.MenuItemServDisabled.Index = 2;
        this.MenuItemServDisabled.Text = "Disabled";
        // 
        // MenuItemServDepe
        // 
        this.VistaMenu.SetImage(this.MenuItemServDepe, global::My.Resources.Resources.dllIcon16);
        this.MenuItemServDepe.Index = 6;
        this.MenuItemServDepe.Text = "Show dependencies...";
        // 
        // MenuItemNetworkClose
        // 
        this.VistaMenu.SetImage(this.MenuItemNetworkClose, global::My.Resources.Resources.cross16);
        this.MenuItemNetworkClose.Index = 2;
        this.MenuItemNetworkClose.Text = "Close TCP connection";
        // 
        // MenuItemServSelProc
        // 
        this.MenuItemServSelProc.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemServSelProc, global::My.Resources.Resources.exe16);
        this.MenuItemServSelProc.Index = 0;
        this.MenuItemServSelProc.Text = "Select associated process";
        // 
        // MenuItemSearchSel
        // 
        this.VistaMenu.SetImage(this.MenuItemSearchSel, global::My.Resources.Resources.exe16);
        this.MenuItemSearchSel.Index = 2;
        this.MenuItemSearchSel.Text = "Select associated process/service";
        // 
        // MenuItemSearchClose
        // 
        this.VistaMenu.SetImage(this.MenuItemSearchClose, global::My.Resources.Resources.cross16);
        this.MenuItemSearchClose.Index = 3;
        this.MenuItemSearchClose.Text = "Close/terminate item";
        // 
        // MenuItemProcSFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSFileProp, global::My.Resources.Resources.document_text);
        this.MenuItemProcSFileProp.Index = 11;
        this.MenuItemProcSFileProp.Text = "File properties";
        // 
        // MenuItemProcSOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemProcSOpenDir.Index = 12;
        this.MenuItemProcSOpenDir.Text = "Open directory";
        // 
        // MenuItemProcSFileDetails
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSFileDetails, global::My.Resources.Resources.magnifier);
        this.MenuItemProcSFileDetails.Index = 13;
        this.MenuItemProcSFileDetails.Text = "File details";
        // 
        // MenuItemProcSSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSSearch, global::My.Resources.Resources.globe);
        this.MenuItemProcSSearch.Index = 14;
        this.MenuItemProcSSearch.Text = "Internet search";
        // 
        // MenuItemProcSDep
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSDep, global::My.Resources.Resources.dllIcon16);
        this.MenuItemProcSDep.Index = 15;
        this.MenuItemProcSDep.Text = "View dependencies...";
        // 
        // MenuItemProcKill
        // 
        this.MenuItemProcKill.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemProcKill, global::My.Resources.Resources.cross16);
        this.MenuItemProcKill.Index = 0;
        this.MenuItemProcKill.Text = "Kill";
        // 
        // MenuItemProcKillT
        // 
        this.MenuItemProcKillT.Index = 1;
        this.MenuItemProcKillT.Text = "Kill process tree";
        // 
        // MenuItemProcStop
        // 
        this.VistaMenu.SetImage(this.MenuItemProcStop, global::My.Resources.Resources.control_stop_square);
        this.MenuItemProcStop.Index = 3;
        this.MenuItemProcStop.Text = "Stop";
        // 
        // MenuItemProcResume
        // 
        this.VistaMenu.SetImage(this.MenuItemProcResume, global::My.Resources.Resources.control);
        this.MenuItemProcResume.Index = 4;
        this.MenuItemProcResume.Text = "Resume";
        // 
        // MenuItemProcPIdle
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPIdle, global::My.Resources.Resources.p0);
        this.MenuItemProcPIdle.Index = 0;
        this.MenuItemProcPIdle.Text = "Idle";
        // 
        // MenuItemProcPBN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPBN, global::My.Resources.Resources.p1);
        this.MenuItemProcPBN.Index = 1;
        this.MenuItemProcPBN.Text = "Below normal";
        // 
        // MenuItemProcPN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPN, global::My.Resources.Resources.p2);
        this.MenuItemProcPN.Index = 2;
        this.MenuItemProcPN.Text = "Normal";
        // 
        // MenuItemProcPAN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPAN, global::My.Resources.Resources.p3);
        this.MenuItemProcPAN.Index = 3;
        this.MenuItemProcPAN.Text = "Above normal";
        // 
        // MenuItemProcPH
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPH, global::My.Resources.Resources.p4);
        this.MenuItemProcPH.Index = 4;
        this.MenuItemProcPH.Text = "High";
        // 
        // MenuItemProcPRT
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPRT, global::My.Resources.Resources.p6);
        this.MenuItemProcPRT.Index = 5;
        this.MenuItemProcPRT.Text = "Real time";
        // 
        // MenuItemSystemRefresh
        // 
        this.MenuItemSystemRefresh.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemSystemRefresh, global::My.Resources.Resources.refresh16);
        this.MenuItemSystemRefresh.Index = 0;
        this.MenuItemSystemRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
        this.MenuItemSystemRefresh.Text = "&Refresh";
        // 
        // MenuItemSystemLog
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemLog, global::My.Resources.Resources.document_text);
        this.MenuItemSystemLog.Index = 5;
        this.MenuItemSystemLog.Text = "Show &log";
        // 
        // MenuItemSystemInfos
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemInfos, global::My.Resources.Resources.taskmgr);
        this.MenuItemSystemInfos.Index = 8;
        this.MenuItemSystemInfos.Text = "System &infos";
        // 
        // MenuItemSystemOpenedWindows
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemOpenedWindows, global::My.Resources.Resources.monitor16);
        this.MenuItemSystemOpenedWindows.Index = 10;
        this.MenuItemSystemOpenedWindows.Text = "Opened &windows";
        // 
        // MenuItemSystemToTray
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemToTray, global::My.Resources.Resources.down16);
        this.MenuItemSystemToTray.Index = 21;
        this.MenuItemSystemToTray.Text = "Minimize to &tray";
        // 
        // MenuItemSystemExit
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemExit, global::My.Resources.Resources.cross16);
        this.MenuItemSystemExit.Index = 22;
        this.MenuItemSystemExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
        this.MenuItemSystemExit.Text = "E&xit";
        // 
        // MenuItemSystemUpdate
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemUpdate, global::My.Resources.Resources.refresh16);
        this.MenuItemSystemUpdate.Index = 0;
        this.MenuItemSystemUpdate.Text = "Check &updates";
        // 
        // MenuItemSystemWebsite
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemWebsite, global::My.Resources.Resources.globe);
        this.MenuItemSystemWebsite.Index = 5;
        this.MenuItemSystemWebsite.Text = "&Website";
        // 
        // MenuItemSystemAbout
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemAbout, global::My.Resources.Resources.information_frame);
        this.MenuItemSystemAbout.Index = 9;
        this.MenuItemSystemAbout.Text = "&About";
        // 
        // MenuItemSystemFindWindow
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemFindWindow, global::My.Resources.Resources.target16);
        this.MenuItemSystemFindWindow.Index = 17;
        this.MenuItemSystemFindWindow.Text = "&Find a window";
        // 
        // MenuItemSystemHelp
        // 
        this.MenuItemSystemHelp.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemSystemHelp, global::My.Resources.Resources.help16);
        this.MenuItemSystemHelp.Index = 8;
        this.MenuItemSystemHelp.Shortcut = System.Windows.Forms.Shortcut.F1;
        this.MenuItemSystemHelp.Text = "&Help";
        // 
        // MenuItemSystemOptions
        // 
        this.MenuItemSystemOptions.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemSystemOptions, global::My.Resources.Resources.options16);
        this.MenuItemSystemOptions.Index = 5;
        this.MenuItemSystemOptions.Text = "&Options...";
        // 
        // MenuItemMainFindWindow
        // 
        this.VistaMenu.SetImage(this.MenuItemMainFindWindow, global::My.Resources.Resources.target16);
        this.MenuItemMainFindWindow.Index = 15;
        this.MenuItemMainFindWindow.Text = "Find a window";
        // 
        // MenuItemCopyTask
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyTask, global::My.Resources.Resources.copy16);
        this.MenuItemCopyTask.Index = 9;
        this.MenuItemCopyTask.Text = "Copy to clipboard";
        // 
        // MenuItemCopyService
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyService, global::My.Resources.Resources.copy16);
        this.MenuItemCopyService.Index = 16;
        this.MenuItemCopyService.Text = "Copy to clipboard";
        // 
        // MenuItemCopyNetwork
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyNetwork, global::My.Resources.Resources.copy16);
        this.MenuItemCopyNetwork.Index = 5;
        this.MenuItemCopyNetwork.Text = "Copy to clipboard";
        // 
        // MenuItemCopySearch
        // 
        this.VistaMenu.SetImage(this.MenuItemCopySearch, global::My.Resources.Resources.copy16);
        this.MenuItemCopySearch.Index = 5;
        this.MenuItemCopySearch.Text = "Copy to clipboard";
        // 
        // MenuItemCopyProcess
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyProcess, global::My.Resources.Resources.copy16);
        this.MenuItemCopyProcess.Index = 17;
        this.MenuItemCopyProcess.Text = "Copy to clipboard";
        // 
        // mnuTask
        // 
        this.mnuTask.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemTaskShow, this.MenuItemTaskMax, this.MenuItemTaskMin, this.MenuItem4, this.MenuItemTaskEnd, this.MenuItem6, this.MenuItemTaskSelProc, this.MenuItemTaskSelectWindow, this.MenuItem9, this.MenuItemCopyTask, this.MenuItemTaskColumns });
        // 
        // MenuItemTaskMax
        // 
        this.MenuItemTaskMax.Index = 1;
        this.MenuItemTaskMax.Text = "Maximize";
        // 
        // MenuItemTaskMin
        // 
        this.MenuItemTaskMin.Index = 2;
        this.MenuItemTaskMin.Text = "Minimize";
        // 
        // MenuItem4
        // 
        this.MenuItem4.Index = 3;
        this.MenuItem4.Text = "-";
        // 
        // MenuItem6
        // 
        this.MenuItem6.Index = 5;
        this.MenuItem6.Text = "-";
        // 
        // MenuItemTaskSelectWindow
        // 
        this.MenuItemTaskSelectWindow.Index = 7;
        this.MenuItemTaskSelectWindow.Text = "Select in \"window tab\"";
        // 
        // MenuItem9
        // 
        this.MenuItem9.Index = 8;
        this.MenuItem9.Text = "-";
        // 
        // MenuItemTaskColumns
        // 
        this.MenuItemTaskColumns.Index = 10;
        this.MenuItemTaskColumns.Text = "Choose columns...";
        // 
        // mnuMonitor
        // 
        this.mnuMonitor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemMonitorAdd, this.MenuItemMonitorRemove, this.MenuItem1, this.MenuItemMonitorStart, this.MenuItemMonitorStop });
        // 
        // MenuItem1
        // 
        this.MenuItem1.Index = 2;
        this.MenuItem1.Text = "-";
        // 
        // mnuFileCpPctBig
        // 
        this.mnuFileCpPctBig.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyBig });
        // 
        // mnuFileCpPctSmall
        // 
        this.mnuFileCpPctSmall.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopySmall });
        // 
        // mnuMain
        // 
        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemMainShow, this.MenuItemMainToTray, this.MenuItemMainAbout, this.MenuItemMainAlwaysVisible, this.MenuItem29, this.MenuItem31, this.MenuItem2, this.MenuItem3, this.MenuItem5, this.MenuItemMainLog, this.MenuItemMainReport, this.MenuItemMainSysInfo, this.MenuItemMainNetworkInfo, this.MenuItemMainOpenedW, this.MenuItemMainEmergencyH, this.MenuItemMainFindWindow, this.MenuItemMainSBA, this.MenuItem15, this.MenuItemRefProc, this.MenuItemMainRefServ, this.MenuItem18, this.MenuItemMainExit });
        // 
        // MenuItemMainAlwaysVisible
        // 
        this.MenuItemMainAlwaysVisible.Index = 3;
        this.MenuItemMainAlwaysVisible.Text = "Always visible";
        // 
        // MenuItem29
        // 
        this.MenuItem29.Index = 4;
        this.MenuItem29.Text = "-";
        // 
        // MenuItem31
        // 
        this.MenuItem31.Index = 5;
        this.MenuItem31.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemNotifNP, this.MenuItemNotifTP, this.MenuItemNotifNS, this.MenuItemNotifDS, this.MenuItem46, this.MenuItemNotifAll, this.MenuItemNotifNone });
        this.MenuItem31.Text = "Notifications";
        // 
        // MenuItemNotifNP
        // 
        this.MenuItemNotifNP.Index = 0;
        this.MenuItemNotifNP.Text = "&New processes";
        // 
        // MenuItemNotifTP
        // 
        this.MenuItemNotifTP.Index = 1;
        this.MenuItemNotifTP.Text = "&Terminated processes";
        // 
        // MenuItemNotifNS
        // 
        this.MenuItemNotifNS.Index = 2;
        this.MenuItemNotifNS.Text = "&New services";
        // 
        // MenuItemNotifDS
        // 
        this.MenuItemNotifDS.Index = 3;
        this.MenuItemNotifDS.Text = "&Deleted services";
        // 
        // MenuItem46
        // 
        this.MenuItem46.Index = 4;
        this.MenuItem46.Text = "-";
        // 
        // MenuItemNotifAll
        // 
        this.MenuItemNotifAll.Index = 5;
        this.MenuItemNotifAll.Text = "&Enable all";
        // 
        // MenuItemNotifNone
        // 
        this.MenuItemNotifNone.Index = 6;
        this.MenuItemNotifNone.Text = "&Disable all";
        // 
        // MenuItem2
        // 
        this.MenuItem2.Index = 6;
        this.MenuItem2.Text = "-";
        // 
        // MenuItem3
        // 
        this.MenuItem3.Index = 7;
        this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemMainRestart, this.MenuItemMainShutdown, this.MenuItemMainPowerOff, this.MenuItem11, this.MenuItemMainSleep, this.MenuItemMainHibernate, this.MenuItem17, this.MenuItemMainLogOff, this.MenuItemMainLock });
        this.MenuItem3.Text = "Shutdown";
        // 
        // MenuItemMainRestart
        // 
        this.MenuItemMainRestart.Index = 0;
        this.MenuItemMainRestart.Text = "Restart";
        // 
        // MenuItemMainShutdown
        // 
        this.MenuItemMainShutdown.Index = 1;
        this.MenuItemMainShutdown.Text = "Shutdown";
        // 
        // MenuItemMainPowerOff
        // 
        this.MenuItemMainPowerOff.Index = 2;
        this.MenuItemMainPowerOff.Text = "Power off";
        // 
        // MenuItem11
        // 
        this.MenuItem11.Index = 3;
        this.MenuItem11.Text = "-";
        // 
        // MenuItemMainSleep
        // 
        this.MenuItemMainSleep.Index = 4;
        this.MenuItemMainSleep.Text = "Sleep";
        // 
        // MenuItemMainHibernate
        // 
        this.MenuItemMainHibernate.Index = 5;
        this.MenuItemMainHibernate.Text = "Hibernate";
        // 
        // MenuItem17
        // 
        this.MenuItem17.Index = 6;
        this.MenuItem17.Text = "-";
        // 
        // MenuItemMainLogOff
        // 
        this.MenuItemMainLogOff.Index = 7;
        this.MenuItemMainLogOff.Text = "Log off";
        // 
        // MenuItemMainLock
        // 
        this.MenuItemMainLock.Index = 8;
        this.MenuItemMainLock.Text = "Lock";
        // 
        // MenuItem5
        // 
        this.MenuItem5.Index = 8;
        this.MenuItem5.Text = "-";
        // 
        // MenuItemMainReport
        // 
        this.MenuItemMainReport.Index = 10;
        this.MenuItemMainReport.Text = "Save system report...";
        // 
        // MenuItemMainNetworkInfo
        // 
        this.VistaMenu.SetImage(this.MenuItemMainNetworkInfo, global::My.Resources.Resources.globe);
        this.MenuItemMainNetworkInfo.Index = 12;
        this.MenuItemMainNetworkInfo.Text = "Network information";
        // 
        // MenuItemMainEmergencyH
        // 
        this.MenuItemMainEmergencyH.Index = 14;
        this.MenuItemMainEmergencyH.Text = "Emergency hotkeys...";
        // 
        // MenuItemMainSBA
        // 
        this.MenuItemMainSBA.Enabled = false;
        this.MenuItemMainSBA.Index = 16;
        this.MenuItemMainSBA.Text = "State based actions...";
        this.MenuItemMainSBA.Visible = false;
        // 
        // MenuItem15
        // 
        this.MenuItem15.Index = 17;
        this.MenuItem15.Text = "-";
        // 
        // MenuItemRefProc
        // 
        this.MenuItemRefProc.Checked = true;
        this.MenuItemRefProc.Index = 18;
        this.MenuItemRefProc.Text = "Refresh process list";
        // 
        // MenuItemMainRefServ
        // 
        this.MenuItemMainRefServ.Checked = true;
        this.MenuItemMainRefServ.Index = 19;
        this.MenuItemMainRefServ.Text = "Refresh service list";
        // 
        // MenuItem18
        // 
        this.MenuItem18.Index = 20;
        this.MenuItem18.Text = "-";
        // 
        // mnuService
        // 
        this.mnuService.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemServSelService, this.MenuItem7, this.MenuItemServFileProp, this.MenuItemServOpenDir, this.MenuItemServFileDetails, this.MenuItemServSearch, this.MenuItemServDepe, this.MenuItem20, this.MenuItemServPause, this.MenuItemServStop, this.MenuItemServStart, this.MenuItemServStartType, this.MenuItemServDelete, this.MenuItem25, this.MenuItemServReanalize, this.MenuItem24, this.MenuItemCopyService, this.MenuItemServColumns });
        // 
        // MenuItem7
        // 
        this.MenuItem7.Index = 1;
        this.MenuItem7.Text = "-";
        // 
        // MenuItem20
        // 
        this.MenuItem20.Index = 7;
        this.MenuItem20.Text = "-";
        // 
        // MenuItemServStartType
        // 
        this.MenuItemServStartType.Index = 11;
        this.MenuItemServStartType.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemServAutoStart, this.MenuItemServOnDemand, this.MenuItemServDisabled });
        this.MenuItemServStartType.Text = "Start type";
        // 
        // MenuItemServDelete
        // 
        this.VistaMenu.SetImage(this.MenuItemServDelete, global::My.Resources.Resources.cross16);
        this.MenuItemServDelete.Index = 12;
        this.MenuItemServDelete.Text = "Delete";
        // 
        // MenuItem25
        // 
        this.MenuItem25.Index = 13;
        this.MenuItem25.Text = "-";
        // 
        // MenuItemServReanalize
        // 
        this.MenuItemServReanalize.Index = 14;
        this.MenuItemServReanalize.Text = "Reanalize";
        // 
        // MenuItem24
        // 
        this.MenuItem24.Index = 15;
        this.MenuItem24.Text = "-";
        // 
        // MenuItemServColumns
        // 
        this.MenuItemServColumns.Index = 17;
        this.MenuItemServColumns.Text = "Choose columns...";
        // 
        // mnuNetwork
        // 
        this.mnuNetwork.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemServSelProc, this.MenuItem16, this.MenuItemNetworkClose, this.MenuItemNetworkTools, this.MenuItem10, this.MenuItemCopyNetwork, this.MenuItemNetworkColumns });
        // 
        // MenuItem16
        // 
        this.MenuItem16.Index = 1;
        this.MenuItem16.Text = "-";
        // 
        // MenuItemNetworkTools
        // 
        this.MenuItemNetworkTools.Index = 3;
        this.MenuItemNetworkTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemNetworkPing, this.MenuItemNetworkRoute, this.MenuItemNetworkWhoIs });
        this.MenuItemNetworkTools.Text = "Tools";
        // 
        // MenuItemNetworkPing
        // 
        this.MenuItemNetworkPing.Index = 0;
        this.MenuItemNetworkPing.Text = "Ping";
        // 
        // MenuItemNetworkRoute
        // 
        this.MenuItemNetworkRoute.Index = 1;
        this.MenuItemNetworkRoute.Text = "TraceRoute";
        // 
        // MenuItemNetworkWhoIs
        // 
        this.MenuItemNetworkWhoIs.Index = 2;
        this.MenuItemNetworkWhoIs.Text = "WhoIs";
        // 
        // MenuItem10
        // 
        this.MenuItem10.Index = 4;
        this.MenuItem10.Text = "-";
        // 
        // MenuItemNetworkColumns
        // 
        this.MenuItemNetworkColumns.Index = 6;
        this.MenuItemNetworkColumns.Text = "Choose columns...";
        // 
        // mnuSearch
        // 
        this.mnuSearch.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSearchNew, this.MenuItem28, this.MenuItemSearchSel, this.MenuItemSearchClose, this.MenuItem30, this.MenuItemCopySearch });
        // 
        // MenuItemSearchNew
        // 
        this.MenuItemSearchNew.DefaultItem = true;
        this.MenuItemSearchNew.Index = 0;
        this.MenuItemSearchNew.Text = "New search...";
        // 
        // MenuItem28
        // 
        this.MenuItem28.Index = 1;
        this.MenuItem28.Text = "-";
        // 
        // MenuItem30
        // 
        this.MenuItem30.Index = 4;
        this.MenuItem30.Text = "-";
        // 
        // mnuProcess
        // 
        this.mnuProcess.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcKill, this.MenuItemProcKillT, this.MenuItemProcKillByMethod, this.MenuItemProcStop, this.MenuItemProcResume, this.MenuItemProcPriority, this.MenuItem44, this.MenuItemProcReanalize, this.MenuItemProcOther, this.MenuItemProcJob, this.MenuItem51, this.MenuItemProcSFileProp, this.MenuItemProcSOpenDir, this.MenuItemProcSFileDetails, this.MenuItemProcSSearch, this.MenuItemProcSDep, this.MenuItem38, this.MenuItemCopyProcess, this.MenuItemProcColumns });
        // 
        // MenuItemProcKillByMethod
        // 
        this.MenuItemProcKillByMethod.Index = 2;
        this.MenuItemProcKillByMethod.Text = "Kill process by method...";
        // 
        // MenuItemProcPriority
        // 
        this.MenuItemProcPriority.Index = 5;
        this.MenuItemProcPriority.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcPIdle, this.MenuItemProcPBN, this.MenuItemProcPN, this.MenuItemProcPAN, this.MenuItemProcPH, this.MenuItemProcPRT });
        this.MenuItemProcPriority.Text = "Priority";
        // 
        // MenuItem44
        // 
        this.MenuItem44.Index = 6;
        this.MenuItem44.Text = "-";
        // 
        // MenuItemProcReanalize
        // 
        this.MenuItemProcReanalize.Index = 7;
        this.MenuItemProcReanalize.Text = "Reanalize";
        // 
        // MenuItemProcOther
        // 
        this.MenuItemProcOther.Index = 8;
        this.MenuItemProcOther.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcWSS, this.MenuItemProcAff, this.MenuItemProcDump });
        this.MenuItemProcOther.Text = "Other";
        // 
        // MenuItemProcWSS
        // 
        this.MenuItemProcWSS.Index = 0;
        this.MenuItemProcWSS.Text = "Reduce working set size";
        // 
        // MenuItemProcAff
        // 
        this.MenuItemProcAff.Index = 1;
        this.MenuItemProcAff.Text = "Set affinity...";
        // 
        // MenuItemProcDump
        // 
        this.MenuItemProcDump.Index = 2;
        this.MenuItemProcDump.Text = "Create dump file...";
        // 
        // MenuItemProcJob
        // 
        this.MenuItemProcJob.Index = 9;
        this.MenuItemProcJob.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcAddToJob, this.MenuItem33, this.MenuItemJobMng });
        this.MenuItemProcJob.Text = "&Job";
        // 
        // MenuItemProcAddToJob
        // 
        this.MenuItemProcAddToJob.Index = 0;
        this.MenuItemProcAddToJob.Text = "&Add to job...";
        // 
        // MenuItem33
        // 
        this.MenuItem33.Index = 1;
        this.MenuItem33.Text = "-";
        // 
        // MenuItemJobMng
        // 
        this.MenuItemJobMng.Index = 2;
        this.MenuItemJobMng.Text = "&Control process job...";
        // 
        // MenuItem51
        // 
        this.MenuItem51.Index = 10;
        this.MenuItem51.Text = "-";
        // 
        // MenuItem38
        // 
        this.MenuItem38.Index = 16;
        this.MenuItem38.Text = "-";
        // 
        // MenuItemProcColumns
        // 
        this.MenuItemProcColumns.Index = 18;
        this.MenuItemProcColumns.Text = "Choose columns...";
        // 
        // mnuSystem
        // 
        this.mnuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSYSTEMFILE, this.MenuItemProcesses, this.MenuItemJobs, this.MenuItemMonitor, this.MenuItemServices, this.MenuItemSearch, this.MenuItemFiles, this.MenuItemSYSTEMOPT, this.MenuItemSYSTEMTOOLS, this.MenuItemSYSTEMSYSTEM, this.MenuItemSYSTEMHEL });
        // 
        // MenuItemSYSTEMFILE
        // 
        this.MenuItemSYSTEMFILE.Index = 0;
        this.MenuItemSYSTEMFILE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSystemRefresh, this.MenuItem54, this.MenuItemSystemConnection, this.MenuItemRunAsAdmin, this.MenuItem56, this.MenuItemSystemLog, this.MenuItemSystemReport, this.MenuItem59, this.MenuItemSystemInfos, this.MenuItemSystemNetworkInfos, this.MenuItemSystemOpenedWindows, this.MenuItemShowPendingTasks, this.MenuItemSystemScripting, this.MenuItemSystemSaveSSFile, this.MenuItemSystemExploreSSFile, this.MenuItemSystemCheckSignatures, this.MenuItem62, this.MenuItemSystemFindWindow, this.MenuItemSystemEmergency, this.MenuItemSystemSBA, this.MenuItem66, this.MenuItemSystemToTray, this.MenuItemSystemExit });
        this.MenuItemSYSTEMFILE.Text = "&File";
        // 
        // MenuItem54
        // 
        this.MenuItem54.Index = 1;
        this.MenuItem54.Text = "-";
        // 
        // MenuItemSystemConnection
        // 
        this.MenuItemSystemConnection.Index = 2;
        this.MenuItemSystemConnection.Text = "&Connection...";
        // 
        // MenuItemRunAsAdmin
        // 
        this.MenuItemRunAsAdmin.Index = 3;
        this.MenuItemRunAsAdmin.Text = "&Restart with privileges";
        // 
        // MenuItem56
        // 
        this.MenuItem56.Index = 4;
        this.MenuItem56.Text = "-";
        // 
        // MenuItemSystemReport
        // 
        this.MenuItemSystemReport.Index = 6;
        this.MenuItemSystemReport.Text = "Save &system report...";
        // 
        // MenuItem59
        // 
        this.MenuItem59.Index = 7;
        this.MenuItem59.Text = "-";
        // 
        // MenuItemSystemNetworkInfos
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemNetworkInfos, global::My.Resources.Resources.globe);
        this.MenuItemSystemNetworkInfos.Index = 9;
        this.MenuItemSystemNetworkInfos.Text = "&Network infos";
        // 
        // MenuItemShowPendingTasks
        // 
        this.MenuItemShowPendingTasks.Index = 11;
        this.MenuItemShowPendingTasks.Text = "&Pending tasks...";
        // 
        // MenuItemSystemScripting
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemScripting, global::My.Resources.Resources.scripting16);
        this.MenuItemSystemScripting.Index = 12;
        this.MenuItemSystemScripting.Text = "&Scripting...";
        // 
        // MenuItemSystemSaveSSFile
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemSaveSSFile, global::My.Resources.Resources.save16);
        this.MenuItemSystemSaveSSFile.Index = 13;
        this.MenuItemSystemSaveSSFile.Text = "&Save System Snapshot File...";
        // 
        // MenuItemSystemExploreSSFile
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemExploreSSFile, global::My.Resources.Resources.folder_open_document);
        this.MenuItemSystemExploreSSFile.Index = 14;
        this.MenuItemSystemExploreSSFile.Text = "&Explore System Snapshot File...";
        // 
        // MenuItemSystemCheckSignatures
        // 
        this.VistaMenu.SetImage(this.MenuItemSystemCheckSignatures, global::My.Resources.Resources.ok16);
        this.MenuItemSystemCheckSignatures.Index = 15;
        this.MenuItemSystemCheckSignatures.Text = "Check file signatures...";
        // 
        // MenuItem62
        // 
        this.MenuItem62.Index = 16;
        this.MenuItem62.Text = "-";
        // 
        // MenuItemSystemEmergency
        // 
        this.MenuItemSystemEmergency.Index = 18;
        this.MenuItemSystemEmergency.Text = "Emergency &hotkeys...";
        // 
        // MenuItemSystemSBA
        // 
        this.MenuItemSystemSBA.Enabled = false;
        this.MenuItemSystemSBA.Index = 19;
        this.MenuItemSystemSBA.Text = "State &based actions...";
        this.MenuItemSystemSBA.Visible = false;
        // 
        // MenuItem66
        // 
        this.MenuItem66.Index = 20;
        this.MenuItem66.Text = "-";
        // 
        // MenuItemProcesses
        // 
        this.MenuItemProcesses.Index = 1;
        this.MenuItemProcesses.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemReportProcesses });
        this.MenuItemProcesses.Text = "&Processes";
        this.MenuItemProcesses.Visible = false;
        // 
        // MenuItemReportProcesses
        // 
        this.VistaMenu.SetImage(this.MenuItemReportProcesses, global::My.Resources.Resources.save16);
        this.MenuItemReportProcesses.Index = 0;
        this.MenuItemReportProcesses.Text = "&Save report...";
        // 
        // MenuItemJobs
        // 
        this.MenuItemJobs.Index = 2;
        this.MenuItemJobs.Text = "&Jobs";
        this.MenuItemJobs.Visible = false;
        // 
        // MenuItemMonitor
        // 
        this.MenuItemMonitor.Index = 3;
        this.MenuItemMonitor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemReportMonitor });
        this.MenuItemMonitor.Text = "&Monitor";
        this.MenuItemMonitor.Visible = false;
        // 
        // MenuItemReportMonitor
        // 
        this.VistaMenu.SetImage(this.MenuItemReportMonitor, global::My.Resources.Resources.save16);
        this.MenuItemReportMonitor.Index = 0;
        this.MenuItemReportMonitor.Text = "&Save report...";
        // 
        // MenuItemServices
        // 
        this.MenuItemServices.Index = 4;
        this.MenuItemServices.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemReportServices });
        this.MenuItemServices.Text = "&Services";
        this.MenuItemServices.Visible = false;
        // 
        // MenuItemReportServices
        // 
        this.VistaMenu.SetImage(this.MenuItemReportServices, global::My.Resources.Resources.save16);
        this.MenuItemReportServices.Index = 0;
        this.MenuItemReportServices.Text = "&Save report...";
        // 
        // MenuItemSearch
        // 
        this.MenuItemSearch.Index = 5;
        this.MenuItemSearch.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemNewSearch, this.MenuItem61, this.MenuItemReportSearch });
        this.MenuItemSearch.Text = "&Search";
        this.MenuItemSearch.Visible = false;
        // 
        // MenuItemNewSearch
        // 
        this.MenuItemNewSearch.DefaultItem = true;
        this.MenuItemNewSearch.Index = 0;
        this.MenuItemNewSearch.Text = "&New search...";
        // 
        // MenuItem61
        // 
        this.MenuItem61.Index = 1;
        this.MenuItem61.Text = "-";
        // 
        // MenuItemReportSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemReportSearch, global::My.Resources.Resources.save16);
        this.MenuItemReportSearch.Index = 2;
        this.MenuItemReportSearch.Text = "&Save report...";
        // 
        // MenuItemFiles
        // 
        this.MenuItemFiles.Index = 6;
        this.MenuItemFiles.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemFileOpen, this.MenuItem68, this.MenuItemFileRelease, this.MenuItemFileDelete, this.MenuItemFileTrash, this.MenuItem72, this.MenuItemFileRename, this.MenuItemFileShellOpen, this.MenuItemFileMove, this.MenuItemFileCopy, this.MenuItem77, this.MenuItemFileEncrypt, this.MenuItemFileDecrypt, this.MenuItem80, this.MenuItemFileStrings });
        this.MenuItemFiles.Text = "&Files";
        this.MenuItemFiles.Visible = false;
        // 
        // MenuItemFileOpen
        // 
        this.MenuItemFileOpen.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemFileOpen, global::My.Resources.Resources.folder_open);
        this.MenuItemFileOpen.Index = 0;
        this.MenuItemFileOpen.Text = "&Open file...";
        // 
        // MenuItem68
        // 
        this.MenuItem68.Index = 1;
        this.MenuItem68.Text = "-";
        // 
        // MenuItemFileRelease
        // 
        this.MenuItemFileRelease.Enabled = false;
        this.VistaMenu.SetImage(this.MenuItemFileRelease, global::My.Resources.Resources.locked);
        this.MenuItemFileRelease.Index = 2;
        this.MenuItemFileRelease.Text = "&Release file...";
        // 
        // MenuItemFileDelete
        // 
        this.VistaMenu.SetImage(this.MenuItemFileDelete, global::My.Resources.Resources.cross16);
        this.MenuItemFileDelete.Index = 3;
        this.MenuItemFileDelete.Text = "&Delete file...";
        // 
        // MenuItemFileTrash
        // 
        this.VistaMenu.SetImage(this.MenuItemFileTrash, global::My.Resources.Resources.cross_circle16);
        this.MenuItemFileTrash.Index = 4;
        this.MenuItemFileTrash.Text = "&Move to trash...";
        // 
        // MenuItem72
        // 
        this.MenuItem72.Index = 5;
        this.MenuItem72.Text = "-";
        // 
        // MenuItemFileRename
        // 
        this.MenuItemFileRename.Index = 6;
        this.MenuItemFileRename.Text = "&Rename...";
        // 
        // MenuItemFileShellOpen
        // 
        this.MenuItemFileShellOpen.Index = 7;
        this.MenuItemFileShellOpen.Text = "&Open";
        // 
        // MenuItemFileMove
        // 
        this.MenuItemFileMove.Index = 8;
        this.MenuItemFileMove.Text = "&Move...";
        // 
        // MenuItemFileCopy
        // 
        this.MenuItemFileCopy.Index = 9;
        this.MenuItemFileCopy.Text = "&Copy...";
        // 
        // MenuItem77
        // 
        this.MenuItem77.Index = 10;
        this.MenuItem77.Text = "-";
        // 
        // MenuItemFileEncrypt
        // 
        this.MenuItemFileEncrypt.Index = 11;
        this.MenuItemFileEncrypt.Text = "&Encrypt";
        // 
        // MenuItemFileDecrypt
        // 
        this.MenuItemFileDecrypt.Index = 12;
        this.MenuItemFileDecrypt.Text = "&Decrypt";
        // 
        // MenuItem80
        // 
        this.MenuItem80.Index = 13;
        this.MenuItem80.Text = "-";
        // 
        // MenuItemFileStrings
        // 
        this.MenuItemFileStrings.Index = 14;
        this.MenuItemFileStrings.Text = "&Show file strings";
        // 
        // MenuItemSYSTEMOPT
        // 
        this.MenuItemSYSTEMOPT.Index = 7;
        this.MenuItemSYSTEMOPT.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSystemAlwaysVisible, this.MenuItem37, this.MenuItemSystemRefProc, this.MenuItemSystemRefServ, this.MenuItem42, this.MenuItemSystemOptions });
        this.MenuItemSYSTEMOPT.Text = "&Options";
        // 
        // MenuItemSystemAlwaysVisible
        // 
        this.MenuItemSystemAlwaysVisible.Index = 0;
        this.MenuItemSystemAlwaysVisible.Text = "&Always visible";
        // 
        // MenuItem37
        // 
        this.MenuItem37.Index = 1;
        this.MenuItem37.Text = "-";
        // 
        // MenuItemSystemRefProc
        // 
        this.MenuItemSystemRefProc.Checked = true;
        this.MenuItemSystemRefProc.Index = 2;
        this.MenuItemSystemRefProc.Text = "Refresh &process list";
        // 
        // MenuItemSystemRefServ
        // 
        this.MenuItemSystemRefServ.Checked = true;
        this.MenuItemSystemRefServ.Index = 3;
        this.MenuItemSystemRefServ.Text = "Refresh &service list";
        // 
        // MenuItem42
        // 
        this.MenuItem42.Index = 4;
        this.MenuItem42.Text = "-";
        // 
        // MenuItemSYSTEMTOOLS
        // 
        this.MenuItemSYSTEMTOOLS.Index = 8;
        this.MenuItemSYSTEMTOOLS.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSystemShowHidden, this.MenuItemSystemDependency, this.MenuItemCreateService });
        this.MenuItemSYSTEMTOOLS.Text = "&Tools";
        // 
        // MenuItemSystemShowHidden
        // 
        this.MenuItemSystemShowHidden.Index = 0;
        this.MenuItemSystemShowHidden.Text = "Show &hidden processes...";
        // 
        // MenuItemSystemDependency
        // 
        this.MenuItemSystemDependency.Index = 1;
        this.MenuItemSystemDependency.Text = "&Dependency viewer...";
        // 
        // MenuItemCreateService
        // 
        this.MenuItemCreateService.Index = 2;
        this.MenuItemCreateService.Text = "&Create service...";
        // 
        // MenuItemSYSTEMSYSTEM
        // 
        this.MenuItemSYSTEMSYSTEM.Index = 9;
        this.MenuItemSYSTEMSYSTEM.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem34 });
        this.MenuItemSYSTEMSYSTEM.Text = "&System";
        // 
        // MenuItem34
        // 
        this.MenuItem34.Index = 0;
        this.MenuItem34.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSystemRestart, this.MenuItemSystemShutdown, this.MenuItemSystemPowerOff, this.MenuItem40, this.MenuItemSystemSleep, this.MenuItemSystemHIbernate, this.MenuItem43, this.MenuItemSystemLogoff, this.MenuItemSystemLock });
        this.MenuItem34.Text = "Shutdown";
        // 
        // MenuItemSystemRestart
        // 
        this.MenuItemSystemRestart.Index = 0;
        this.MenuItemSystemRestart.Text = "Restart";
        // 
        // MenuItemSystemShutdown
        // 
        this.MenuItemSystemShutdown.Index = 1;
        this.MenuItemSystemShutdown.Text = "Shutdown";
        // 
        // MenuItemSystemPowerOff
        // 
        this.MenuItemSystemPowerOff.Index = 2;
        this.MenuItemSystemPowerOff.Text = "Power off";
        // 
        // MenuItem40
        // 
        this.MenuItem40.Index = 3;
        this.MenuItem40.Text = "-";
        // 
        // MenuItemSystemSleep
        // 
        this.MenuItemSystemSleep.Index = 4;
        this.MenuItemSystemSleep.Text = "Sleep";
        // 
        // MenuItemSystemHIbernate
        // 
        this.MenuItemSystemHIbernate.Index = 5;
        this.MenuItemSystemHIbernate.Text = "Hibernate";
        // 
        // MenuItem43
        // 
        this.MenuItem43.Index = 6;
        this.MenuItem43.Text = "-";
        // 
        // MenuItemSystemLogoff
        // 
        this.MenuItemSystemLogoff.Index = 7;
        this.MenuItemSystemLogoff.Text = "Log off";
        // 
        // MenuItemSystemLock
        // 
        this.MenuItemSystemLock.Index = 8;
        this.MenuItemSystemLock.Text = "Lock";
        // 
        // MenuItemSYSTEMHEL
        // 
        this.MenuItemSYSTEMHEL.Index = 10;
        this.MenuItemSYSTEMHEL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemSystemUpdate, this.MenuItem39, this.MenuItemSystemDonation, this.MenuItemSystemFeedBack, this.MenuItemSystemSF, this.MenuItemSystemWebsite, this.MenuItemSystemDownloads, this.MenuItem49, this.MenuItemSystemHelp, this.MenuItemSystemAbout });
        this.MenuItemSYSTEMHEL.Text = "&Help";
        // 
        // MenuItem39
        // 
        this.MenuItem39.Index = 1;
        this.MenuItem39.Text = "-";
        // 
        // MenuItemSystemDonation
        // 
        this.MenuItemSystemDonation.Index = 2;
        this.MenuItemSystemDonation.Text = "Make a &donation...";
        // 
        // MenuItemSystemFeedBack
        // 
        this.MenuItemSystemFeedBack.Index = 3;
        this.MenuItemSystemFeedBack.Text = "Send &feed back...";
        // 
        // MenuItemSystemSF
        // 
        this.MenuItemSystemSF.Index = 4;
        this.MenuItemSystemSF.Text = "&Project on Sourceforge.net";
        // 
        // MenuItemSystemDownloads
        // 
        this.MenuItemSystemDownloads.Index = 6;
        this.MenuItemSystemDownloads.Text = "&Downloads";
        // 
        // MenuItem49
        // 
        this.MenuItem49.Index = 7;
        this.MenuItem49.Text = "-";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItemJobTerminate
        // 
        this.VistaMenu.SetImage(this.MenuItemJobTerminate, global::My.Resources.Resources.cross16);
        this.MenuItemJobTerminate.Index = 0;
        this.MenuItemJobTerminate.Text = "Terminate job";
        // 
        // MenuItemCopyJob
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyJob, global::My.Resources.Resources.copy16);
        this.MenuItemCopyJob.Index = 2;
        this.MenuItemCopyJob.Text = "Copy to clipboard";
        // 
        // StatusBar
        // 
        this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.StatusBar.Location = new System.Drawing.Point(0, 531);
        this.StatusBar.Name = "StatusBar";
        this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.sbPanelConnection, this.sbPanelProcesses, this.sbPanelServices, this.sbPanelCpu, this.sbPanelMemory });
        this.StatusBar.ShowPanels = true;
        this.StatusBar.Size = new System.Drawing.Size(866, 20);
        this.StatusBar.TabIndex = 62;
        // 
        // sbPanelConnection
        // 
        this.sbPanelConnection.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelConnection.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
        this.sbPanelConnection.MinWidth = 100;
        this.sbPanelConnection.Name = "sbPanelConnection";
        this.sbPanelConnection.Text = "Localhost";
        // 
        // sbPanelProcesses
        // 
        this.sbPanelProcesses.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelProcesses.MinWidth = 80;
        this.sbPanelProcesses.Name = "sbPanelProcesses";
        this.sbPanelProcesses.Text = "0 processes";
        this.sbPanelProcesses.Width = 80;
        // 
        // sbPanelServices
        // 
        this.sbPanelServices.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelServices.MinWidth = 80;
        this.sbPanelServices.Name = "sbPanelServices";
        this.sbPanelServices.Text = "0 services";
        this.sbPanelServices.Width = 80;
        // 
        // sbPanelCpu
        // 
        this.sbPanelCpu.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelCpu.MinWidth = 80;
        this.sbPanelCpu.Name = "sbPanelCpu";
        this.sbPanelCpu.Text = "CPU : 0%";
        this.sbPanelCpu.Width = 80;
        // 
        // sbPanelMemory
        // 
        this.sbPanelMemory.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelMemory.MinWidth = 120;
        this.sbPanelMemory.Name = "sbPanelMemory";
        this.sbPanelMemory.Text = "Phys. Memory : 0%";
        this.sbPanelMemory.Width = 120;
        // 
        // timerStatus
        // 
        this.timerStatus.Enabled = true;
        this.timerStatus.Interval = 1000;
        // 
        // timerJobs
        // 
        this.timerJobs.Enabled = true;
        this.timerJobs.Interval = 1000;
        // 
        // mnuJob
        // 
        this.mnuJob.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemJobTerminate, this.MenuItem53, this.MenuItemCopyJob });
        // 
        // MenuItem53
        // 
        this.MenuItem53.Index = 1;
        this.MenuItem53.Text = "-";
        // 
        // butFreeMemory
        // 
        this.butFreeMemory.AltKey = null;
        this.butFreeMemory.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
        this.butFreeMemory.DropDownArrowSize = new System.Drawing.Size(5, 3);
        this.butFreeMemory.Image = global::My.Resources.Resources.scripting16;
        this.butFreeMemory.SmallImage = global::My.Resources.Resources.scripting16;
        this.butFreeMemory.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
        this.butFreeMemory.Tag = null;
        this.butFreeMemory.Text = "Free memory";
        this.butFreeMemory.ToolTip = null;
        this.butFreeMemory.ToolTipImage = null;
        this.butFreeMemory.ToolTipTitle = null;
        // 
        // frmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(866, 551);
        this.Controls.Add(this._main);
        this.Controls.Add(this.StatusBar);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Menu = this.mnuSystem;
        this.MinimumSize = new System.Drawing.Size(882, 589);
        this.Name = "frmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Yet Another (remote) Process Monitor";
        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        this._main.Panel1.ResumeLayout(false);
        this._main.Panel2.ResumeLayout(false);
        this._main.ResumeLayout(false);
        this.containerSystemMenu.Panel2.ResumeLayout(false);
        this.containerSystemMenu.ResumeLayout(false);
        this._tab.ResumeLayout(false);
        this.pageTasks.ResumeLayout(false);
        this.panelMain13.ResumeLayout(false);
        this.SplitContainerTask.Panel1.ResumeLayout(false);
        this.SplitContainerTask.Panel1.PerformLayout();
        this.SplitContainerTask.Panel2.ResumeLayout(false);
        this.SplitContainerTask.ResumeLayout(false);
        this.pageProcesses.ResumeLayout(false);
        this.containerProcessPage.Panel1.ResumeLayout(false);
        this.containerProcessPage.Panel2.ResumeLayout(false);
        this.containerProcessPage.ResumeLayout(false);
        this.panelMenu.ResumeLayout(false);
        this.panelMenu.PerformLayout();
        this.panelMain.ResumeLayout(false);
        this.SplitContainerProcess.Panel1.ResumeLayout(false);
        this.SplitContainerProcess.ResumeLayout(false);
        this.SplitContainerTvLv.Panel1.ResumeLayout(false);
        this.SplitContainerTvLv.Panel2.ResumeLayout(false);
        this.SplitContainerTvLv.ResumeLayout(false);
        this.pageJobs.ResumeLayout(false);
        this.panelMain12.ResumeLayout(false);
        this.pageMonitor.ResumeLayout(false);
        this.panelMain8.ResumeLayout(false);
        this.splitMonitor.Panel1.ResumeLayout(false);
        this.splitMonitor.Panel2.ResumeLayout(false);
        this.splitMonitor.ResumeLayout(false);
        this.splitMonitor2.Panel1.ResumeLayout(false);
        this.splitMonitor2.Panel1.PerformLayout();
        this.splitMonitor2.Panel2.ResumeLayout(false);
        this.splitMonitor2.ResumeLayout(false);
        this.splitMonitor3.Panel1.ResumeLayout(false);
        this.splitMonitor3.Panel2.ResumeLayout(false);
        this.splitMonitor3.Panel2.PerformLayout();
        this.splitMonitor3.ResumeLayout(false);
        this.splitMonitor4.Panel2.ResumeLayout(false);
        this.splitMonitor4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.graphMonitor).EndInit();
        this.pageServices.ResumeLayout(false);
        this.containerServicesPage.Panel1.ResumeLayout(false);
        this.containerServicesPage.Panel2.ResumeLayout(false);
        this.containerServicesPage.ResumeLayout(false);
        this.panelMenu2.ResumeLayout(false);
        this.panelMenu2.PerformLayout();
        this.panelMain2.ResumeLayout(false);
        this.splitServices.Panel1.ResumeLayout(false);
        this.splitServices.Panel2.ResumeLayout(false);
        this.splitServices.ResumeLayout(false);
        this.splitServices2.Panel1.ResumeLayout(false);
        this.splitServices2.Panel1.PerformLayout();
        this.splitServices2.Panel2.ResumeLayout(false);
        this.splitServices2.ResumeLayout(false);
        this.splitServices3.Panel1.ResumeLayout(false);
        this.splitServices3.Panel2.ResumeLayout(false);
        this.splitServices3.ResumeLayout(false);
        this.splitServices4.Panel1.ResumeLayout(false);
        this.splitServices4.Panel2.ResumeLayout(false);
        this.splitServices4.ResumeLayout(false);
        this.pageNetwork.ResumeLayout(false);
        this.panelMain14.ResumeLayout(false);
        this.pageFile.ResumeLayout(false);
        this.panelMain5.ResumeLayout(false);
        this.SplitContainerFilexx.Panel1.ResumeLayout(false);
        this.SplitContainerFilexx.Panel1.PerformLayout();
        this.SplitContainerFilexx.Panel2.ResumeLayout(false);
        this.SplitContainerFilexx.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.pctFileSmall).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pctFileBig).EndInit();
        this.SplitContainerFile.Panel1.ResumeLayout(false);
        this.SplitContainerFile.Panel2.ResumeLayout(false);
        this.SplitContainerFile.ResumeLayout(false);
        this.SplitContainerFile2.Panel1.ResumeLayout(false);
        this.SplitContainerFile2.Panel2.ResumeLayout(false);
        this.SplitContainerFile2.ResumeLayout(false);
        this.gpFileAttributes.ResumeLayout(false);
        this.gpFileAttributes.PerformLayout();
        this.gpFileDates.ResumeLayout(false);
        this.gpFileDates.PerformLayout();
        this.pageSearch.ResumeLayout(false);
        this.panelMain6.ResumeLayout(false);
        this.SplitContainerSearch.Panel1.ResumeLayout(false);
        this.SplitContainerSearch.Panel1.PerformLayout();
        this.SplitContainerSearch.Panel2.ResumeLayout(false);
        this.SplitContainerSearch.ResumeLayout(false);
        this.pageHelp.ResumeLayout(false);
        this.panelMain4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelConnection).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelProcesses).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelServices).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelCpu).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelMemory).EndInit();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Timer _timerProcess;

    internal System.Windows.Forms.Timer timerProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerProcess != null)
            {
            }

            _timerProcess = value;
            if (_timerProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerServices;

    internal System.Windows.Forms.Timer timerServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerServices != null)
            {
            }

            _timerServices = value;
            if (_timerServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.ImageList _imgServices;

    internal System.Windows.Forms.ImageList imgServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _imgServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_imgServices != null)
            {
            }

            _imgServices = value;
            if (_imgServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.NotifyIcon _Tray;

    internal System.Windows.Forms.NotifyIcon Tray
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Tray;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Tray != null)
            {
            }

            _Tray = value;
            if (_Tray != null)
            {
            }
        }
    }

    private System.Windows.Forms.SaveFileDialog _saveDial;

    internal System.Windows.Forms.SaveFileDialog saveDial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _saveDial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_saveDial != null)
            {
            }

            _saveDial = value;
            if (_saveDial != null)
            {
            }
        }
    }

    private System.Windows.Forms.OpenFileDialog _openDial;

    internal System.Windows.Forms.OpenFileDialog openDial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openDial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openDial != null)
            {
            }

            _openDial = value;
            if (_openDial != null)
            {
            }
        }
    }

    private System.Windows.Forms.Ribbon _Ribbon;

    internal System.Windows.Forms.Ribbon Ribbon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Ribbon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Ribbon != null)
            {
            }

            _Ribbon = value;
            if (_Ribbon != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _ProcessTab;

    internal System.Windows.Forms.RibbonTab ProcessTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ProcessTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ProcessTab != null)
            {
            }

            _ProcessTab = value;
            if (_ProcessTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _ServiceTab;

    internal System.Windows.Forms.RibbonTab ServiceTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ServiceTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ServiceTab != null)
            {
            }

            _ServiceTab = value;
            if (_ServiceTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _HelpTab;

    internal System.Windows.Forms.RibbonTab HelpTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _HelpTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_HelpTab != null)
            {
            }

            _HelpTab = value;
            if (_HelpTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBProcessActions;

    internal System.Windows.Forms.RibbonPanel RBProcessActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBProcessActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBProcessActions != null)
            {
            }

            _RBProcessActions = value;
            if (_RBProcessActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butStopProcess;

    internal System.Windows.Forms.RibbonButton butStopProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butStopProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butStopProcess != null)
            {
            }

            _butStopProcess = value;
            if (_butStopProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butResumeProcess;

    internal System.Windows.Forms.RibbonButton butResumeProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butResumeProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butResumeProcess != null)
            {
            }

            _butResumeProcess = value;
            if (_butResumeProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessOtherActions;

    internal System.Windows.Forms.RibbonButton butProcessOtherActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessOtherActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessOtherActions != null)
            {
            }

            _butProcessOtherActions = value;
            if (_butProcessOtherActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBProcessPriority;

    internal System.Windows.Forms.RibbonPanel RBProcessPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBProcessPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBProcessPriority != null)
            {
            }

            _RBProcessPriority = value;
            if (_RBProcessPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butKillProcess;

    internal System.Windows.Forms.RibbonButton butKillProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butKillProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butKillProcess != null)
            {
            }

            _butKillProcess = value;
            if (_butKillProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessPriority;

    internal System.Windows.Forms.RibbonButton butProcessPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessPriority != null)
            {
            }

            _butProcessPriority = value;
            if (_butProcessPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butNewProcess;

    internal System.Windows.Forms.RibbonButton butNewProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butNewProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butNewProcess != null)
            {
            }

            _butNewProcess = value;
            if (_butNewProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessAffinity;

    internal System.Windows.Forms.RibbonButton butProcessAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessAffinity != null)
            {
            }

            _butProcessAffinity = value;
            if (_butProcessAffinity != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessLimitCPU;

    internal System.Windows.Forms.RibbonButton butProcessLimitCPU
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessLimitCPU;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessLimitCPU != null)
            {
            }

            _butProcessLimitCPU = value;
            if (_butProcessLimitCPU != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butIdle;

    internal System.Windows.Forms.RibbonButton butIdle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butIdle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butIdle != null)
            {
            }

            _butIdle = value;
            if (_butIdle != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butBelowNormal;

    internal System.Windows.Forms.RibbonButton butBelowNormal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butBelowNormal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butBelowNormal != null)
            {
            }

            _butBelowNormal = value;
            if (_butBelowNormal != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butNormal;

    internal System.Windows.Forms.RibbonButton butNormal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butNormal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butNormal != null)
            {
            }

            _butNormal = value;
            if (_butNormal != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butAboveNormal;

    internal System.Windows.Forms.RibbonButton butAboveNormal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butAboveNormal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butAboveNormal != null)
            {
            }

            _butAboveNormal = value;
            if (_butAboveNormal != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butHigh;

    internal System.Windows.Forms.RibbonButton butHigh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butHigh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butHigh != null)
            {
            }

            _butHigh = value;
            if (_butHigh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butRealTime;

    internal System.Windows.Forms.RibbonButton butRealTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butRealTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butRealTime != null)
            {
            }

            _butRealTime = value;
            if (_butRealTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceAction;

    internal System.Windows.Forms.RibbonPanel RBServiceAction
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceAction;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceAction != null)
            {
            }

            _RBServiceAction = value;
            if (_RBServiceAction != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceFile;

    internal System.Windows.Forms.RibbonPanel RBServiceFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceFile != null)
            {
            }

            _RBServiceFile = value;
            if (_RBServiceFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceStartType;

    internal System.Windows.Forms.RibbonPanel RBServiceStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceStartType != null)
            {
            }

            _RBServiceStartType = value;
            if (_RBServiceStartType != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butStopService;

    internal System.Windows.Forms.RibbonButton butStopService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butStopService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butStopService != null)
            {
            }

            _butStopService = value;
            if (_butStopService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butStartService;

    internal System.Windows.Forms.RibbonButton butStartService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butStartService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butStartService != null)
            {
            }

            _butStartService = value;
            if (_butStartService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butPauseService;

    internal System.Windows.Forms.RibbonButton butPauseService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butPauseService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butPauseService != null)
            {
            }

            _butPauseService = value;
            if (_butPauseService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butResumeService;

    internal System.Windows.Forms.RibbonButton butResumeService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butResumeService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butResumeService != null)
            {
            }

            _butResumeService = value;
            if (_butResumeService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceStartType;

    internal System.Windows.Forms.RibbonButton butServiceStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceStartType != null)
            {
            }

            _butServiceStartType = value;
            if (_butServiceStartType != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butAutomaticStart;

    internal System.Windows.Forms.RibbonButton butAutomaticStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butAutomaticStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butAutomaticStart != null)
            {
            }

            _butAutomaticStart = value;
            if (_butAutomaticStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butOnDemandStart;

    internal System.Windows.Forms.RibbonButton butOnDemandStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butOnDemandStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butOnDemandStart != null)
            {
            }

            _butOnDemandStart = value;
            if (_butOnDemandStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butDisabledStart;

    internal System.Windows.Forms.RibbonButton butDisabledStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butDisabledStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butDisabledStart != null)
            {
            }

            _butDisabledStart = value;
            if (_butDisabledStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceFileProp;

    internal System.Windows.Forms.RibbonButton butServiceFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceFileProp != null)
            {
            }

            _butServiceFileProp = value;
            if (_butServiceFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceOpenDir;

    internal System.Windows.Forms.RibbonButton butServiceOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceOpenDir != null)
            {
            }

            _butServiceOpenDir = value;
            if (_butServiceOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBProcessDisplay;

    internal System.Windows.Forms.RibbonPanel RBProcessDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBProcessDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBProcessDisplay != null)
            {
            }

            _RBProcessDisplay = value;
            if (_RBProcessDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessRerfresh;

    internal System.Windows.Forms.RibbonButton butProcessRerfresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessRerfresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessRerfresh != null)
            {
            }

            _butProcessRerfresh = value;
            if (_butProcessRerfresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceDisplay;

    internal System.Windows.Forms.RibbonPanel RBServiceDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceDisplay != null)
            {
            }

            _RBServiceDisplay = value;
            if (_RBServiceDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceRefresh;

    internal System.Windows.Forms.RibbonButton butServiceRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceRefresh != null)
            {
            }

            _butServiceRefresh = value;
            if (_butServiceRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBHelpAction;

    internal System.Windows.Forms.RibbonPanel RBHelpAction
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBHelpAction;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBHelpAction != null)
            {
            }

            _RBHelpAction = value;
            if (_RBHelpAction != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butDonate;

    internal System.Windows.Forms.RibbonButton butDonate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butDonate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butDonate != null)
            {
            }

            _butDonate = value;
            if (_butDonate != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butAbout;

    internal System.Windows.Forms.RibbonButton butAbout
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butAbout;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butAbout != null)
            {
            }

            _butAbout = value;
            if (_butAbout != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBHelpActions;

    internal System.Windows.Forms.RibbonPanel RBHelpActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBHelpActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBHelpActions != null)
            {
            }

            _RBHelpActions = value;
            if (_RBHelpActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBHelpWeb;

    internal System.Windows.Forms.RibbonPanel RBHelpWeb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBHelpWeb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBHelpWeb != null)
            {
            }

            _RBHelpWeb = value;
            if (_RBHelpWeb != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butWebite;

    internal System.Windows.Forms.RibbonButton butWebite
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butWebite;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butWebite != null)
            {
            }

            _butWebite = value;
            if (_butWebite != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProjectPage;

    internal System.Windows.Forms.RibbonButton butProjectPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProjectPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProjectPage != null)
            {
            }

            _butProjectPage = value;
            if (_butProjectPage != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butDownload;

    internal System.Windows.Forms.RibbonButton butDownload
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butDownload;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butDownload != null)
            {
            }

            _butDownload = value;
            if (_butDownload != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBProcessOnline;

    internal System.Windows.Forms.RibbonPanel RBProcessOnline
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBProcessOnline;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBProcessOnline != null)
            {
            }

            _RBProcessOnline = value;
            if (_RBProcessOnline != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessGoogle;

    internal System.Windows.Forms.RibbonButton butProcessGoogle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessGoogle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessGoogle != null)
            {
            }

            _butProcessGoogle = value;
            if (_butProcessGoogle != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceOnline;

    internal System.Windows.Forms.RibbonPanel RBServiceOnline
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceOnline;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceOnline != null)
            {
            }

            _RBServiceOnline = value;
            if (_RBServiceOnline != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceGoogle;

    internal System.Windows.Forms.RibbonButton butServiceGoogle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceGoogle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceGoogle != null)
            {
            }

            _butServiceGoogle = value;
            if (_butServiceGoogle != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _FileTab;

    internal System.Windows.Forms.RibbonTab FileTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _FileTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_FileTab != null)
            {
            }

            _FileTab = value;
            if (_FileTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileDelete;

    internal System.Windows.Forms.RibbonPanel RBFileDelete
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileDelete;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileDelete != null)
            {
            }

            _RBFileDelete = value;
            if (_RBFileDelete != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileOnline;

    internal System.Windows.Forms.RibbonPanel RBFileOnline
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileOnline;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileOnline != null)
            {
            }

            _RBFileOnline = value;
            if (_RBFileOnline != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileOther;

    internal System.Windows.Forms.RibbonPanel RBFileOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileOther != null)
            {
            }

            _RBFileOther = value;
            if (_RBFileOther != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMoveFileToTrash;

    internal System.Windows.Forms.RibbonButton butMoveFileToTrash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMoveFileToTrash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMoveFileToTrash != null)
            {
            }

            _butMoveFileToTrash = value;
            if (_butMoveFileToTrash != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butDeleteFile;

    internal System.Windows.Forms.RibbonButton butDeleteFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butDeleteFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butDeleteFile != null)
            {
            }

            _butDeleteFile = value;
            if (_butDeleteFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileGoogleSearch;

    internal System.Windows.Forms.RibbonButton butFileGoogleSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileGoogleSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileGoogleSearch != null)
            {
            }

            _butFileGoogleSearch = value;
            if (_butFileGoogleSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileProperties;

    internal System.Windows.Forms.RibbonButton butFileProperties
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileProperties;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileProperties != null)
            {
            }

            _butFileProperties = value;
            if (_butFileProperties != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileOpenDir;

    internal System.Windows.Forms.RibbonButton butFileOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileOpenDir != null)
            {
            }

            _butFileOpenDir = value;
            if (_butFileOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceFileDetails;

    internal System.Windows.Forms.RibbonButton butServiceFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceFileDetails != null)
            {
            }

            _butServiceFileDetails = value;
            if (_butServiceFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _SearchTab;

    internal System.Windows.Forms.RibbonTab SearchTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SearchTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SearchTab != null)
            {
            }

            _SearchTab = value;
            if (_SearchTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileShowFolderProperties;

    internal System.Windows.Forms.RibbonButton butFileShowFolderProperties
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileShowFolderProperties;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileShowFolderProperties != null)
            {
            }

            _butFileShowFolderProperties = value;
            if (_butFileShowFolderProperties != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileOthers;

    internal System.Windows.Forms.RibbonPanel RBFileOthers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileOthers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileOthers != null)
            {
            }

            _RBFileOthers = value;
            if (_RBFileOthers != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileOthersActions;

    internal System.Windows.Forms.RibbonButton butFileOthersActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileOthersActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileOthersActions != null)
            {
            }

            _butFileOthersActions = value;
            if (_butFileOthersActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _sepFile1;

    internal System.Windows.Forms.RibbonSeparator sepFile1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sepFile1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sepFile1 != null)
            {
            }

            _sepFile1 = value;
            if (_sepFile1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileRename;

    internal System.Windows.Forms.RibbonButton butFileRename
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileRename;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileRename != null)
            {
            }

            _butFileRename = value;
            if (_butFileRename != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileCopy;

    internal System.Windows.Forms.RibbonButton butFileCopy
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileCopy;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileCopy != null)
            {
            }

            _butFileCopy = value;
            if (_butFileCopy != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileMove;

    internal System.Windows.Forms.RibbonButton butFileMove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileMove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileMove != null)
            {
            }

            _butFileMove = value;
            if (_butFileMove != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileOpen;

    internal System.Windows.Forms.RibbonButton butFileOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileOpen != null)
            {
            }

            _butFileOpen = value;
            if (_butFileOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _sepFile2;

    internal System.Windows.Forms.RibbonSeparator sepFile2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sepFile2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sepFile2 != null)
            {
            }

            _sepFile2 = value;
            if (_sepFile2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileSeeStrings;

    internal System.Windows.Forms.RibbonButton butFileSeeStrings
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileSeeStrings;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileSeeStrings != null)
            {
            }

            _butFileSeeStrings = value;
            if (_butFileSeeStrings != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _sepFile3;

    internal System.Windows.Forms.RibbonSeparator sepFile3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sepFile3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sepFile3 != null)
            {
            }

            _sepFile3 = value;
            if (_sepFile3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileEncrypt;

    internal System.Windows.Forms.RibbonButton butFileEncrypt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileEncrypt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileEncrypt != null)
            {
            }

            _butFileEncrypt = value;
            if (_butFileEncrypt != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileDecrypt;

    internal System.Windows.Forms.RibbonButton butFileDecrypt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileDecrypt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileDecrypt != null)
            {
            }

            _butFileDecrypt = value;
            if (_butFileDecrypt != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileKillProcess;

    internal System.Windows.Forms.RibbonPanel RBFileKillProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileKillProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileKillProcess != null)
            {
            }

            _RBFileKillProcess = value;
            if (_RBFileKillProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileRelease;

    internal System.Windows.Forms.RibbonButton butFileRelease
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileRelease;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileRelease != null)
            {
            }

            _butFileRelease = value;
            if (_butFileRelease != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBUpdate;

    internal System.Windows.Forms.RibbonPanel RBUpdate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBUpdate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBUpdate != null)
            {
            }

            _RBUpdate = value;
            if (_RBUpdate != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butUpdate;

    internal System.Windows.Forms.RibbonButton butUpdate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butUpdate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butUpdate != null)
            {
            }

            _butUpdate = value;
            if (_butUpdate != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBSearchMain;

    internal System.Windows.Forms.RibbonPanel RBSearchMain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBSearchMain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBSearchMain != null)
            {
            }

            _RBSearchMain = value;
            if (_RBSearchMain != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butSearchGo;

    internal System.Windows.Forms.RibbonButton butSearchGo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSearchGo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSearchGo != null)
            {
            }

            _butSearchGo = value;
            if (_butSearchGo != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butSearchSaveReport;

    internal System.Windows.Forms.RibbonButton butSearchSaveReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSearchSaveReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSearchSaveReport != null)
            {
            }

            _butSearchSaveReport = value;
            if (_butSearchSaveReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTextBox _txtSearchString;

    internal System.Windows.Forms.RibbonTextBox txtSearchString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearchString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearchString != null)
            {
            }

            _txtSearchString = value;
            if (_txtSearchString != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBFileOpenFile;

    internal System.Windows.Forms.RibbonPanel RBFileOpenFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBFileOpenFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBFileOpenFile != null)
            {
            }

            _RBFileOpenFile = value;
            if (_RBFileOpenFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butOpenFile;

    internal System.Windows.Forms.RibbonButton butOpenFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butOpenFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butOpenFile != null)
            {
            }

            _butOpenFile = value;
            if (_butOpenFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFileRefresh;

    internal System.Windows.Forms.RibbonButton butFileRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFileRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFileRefresh != null)
            {
            }

            _butFileRefresh = value;
            if (_butFileRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _MonitorTab;

    internal System.Windows.Forms.RibbonTab MonitorTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MonitorTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MonitorTab != null)
            {
            }

            _MonitorTab = value;
            if (_MonitorTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBMonitor;

    internal System.Windows.Forms.RibbonPanel RBMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBMonitor != null)
            {
            }

            _RBMonitor = value;
            if (_RBMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMonitoringAdd;

    internal System.Windows.Forms.RibbonButton butMonitoringAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMonitoringAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMonitoringAdd != null)
            {
            }

            _butMonitoringAdd = value;
            if (_butMonitoringAdd != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMonitoringRemove;

    internal System.Windows.Forms.RibbonButton butMonitoringRemove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMonitoringRemove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMonitoringRemove != null)
            {
            }

            _butMonitoringRemove = value;
            if (_butMonitoringRemove != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBMonitoringControl;

    internal System.Windows.Forms.RibbonPanel RBMonitoringControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBMonitoringControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBMonitoringControl != null)
            {
            }

            _RBMonitoringControl = value;
            if (_RBMonitoringControl != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMonitorStart;

    internal System.Windows.Forms.RibbonButton butMonitorStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMonitorStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMonitorStart != null)
            {
            }

            _butMonitorStart = value;
            if (_butMonitorStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMonitorStop;

    internal System.Windows.Forms.RibbonButton butMonitorStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMonitorStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMonitorStop != null)
            {
            }

            _butMonitorStop = value;
            if (_butMonitorStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _butSaveMonitorReport;

    internal System.Windows.Forms.RibbonPanel butSaveMonitorReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSaveMonitorReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSaveMonitorReport != null)
            {
            }

            _butSaveMonitorReport = value;
            if (_butSaveMonitorReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butMonitorSaveReport;

    internal System.Windows.Forms.RibbonButton butMonitorSaveReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butMonitorSaveReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butMonitorSaveReport != null)
            {
            }

            _butMonitorSaveReport = value;
            if (_butMonitorSaveReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.ImageList _imgMonitor;

    internal System.Windows.Forms.ImageList imgMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _imgMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_imgMonitor != null)
            {
            }

            _imgMonitor = value;
            if (_imgMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerMonitoring;

    internal System.Windows.Forms.Timer timerMonitoring
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerMonitoring;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerMonitoring != null)
            {
            }

            _timerMonitoring = value;
            if (_timerMonitoring != null)
            {
            }
        }
    }

    private System.Windows.Forms.FolderBrowserDialog _FolderChooser;

    internal System.Windows.Forms.FolderBrowserDialog FolderChooser
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _FolderChooser;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_FolderChooser != null)
            {
            }

            _FolderChooser = value;
            if (_FolderChooser != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBServiceReport;

    internal System.Windows.Forms.RibbonPanel RBServiceReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBServiceReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBServiceReport != null)
            {
            }

            _RBServiceReport = value;
            if (_RBServiceReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceReport;

    internal System.Windows.Forms.RibbonButton butServiceReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceReport != null)
            {
            }

            _butServiceReport = value;
            if (_butServiceReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBOptions;

    internal System.Windows.Forms.RibbonPanel RBOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBOptions != null)
            {
            }

            _RBOptions = value;
            if (_RBOptions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butPreferences;

    internal System.Windows.Forms.RibbonButton butPreferences
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butPreferences;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butPreferences != null)
            {
            }

            _butPreferences = value;
            if (_butPreferences != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butAlwaysDisplay;

    internal System.Windows.Forms.RibbonButton butAlwaysDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butAlwaysDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butAlwaysDisplay != null)
            {
            }

            _butAlwaysDisplay = value;
            if (_butAlwaysDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessDisplayDetails;

    internal System.Windows.Forms.RibbonButton butProcessDisplayDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessDisplayDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessDisplayDetails != null)
            {
            }

            _butProcessDisplayDetails = value;
            if (_butProcessDisplayDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _EnableServiceRefreshingToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem EnableServiceRefreshingToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _EnableServiceRefreshingToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_EnableServiceRefreshingToolStripMenuItem != null)
            {
            }

            _EnableServiceRefreshingToolStripMenuItem = value;
            if (_EnableServiceRefreshingToolStripMenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _TaskTab;

    internal System.Windows.Forms.RibbonTab TaskTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TaskTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TaskTab != null)
            {
            }

            _TaskTab = value;
            if (_TaskTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBTaskDisplay;

    internal System.Windows.Forms.RibbonPanel RBTaskDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBTaskDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBTaskDisplay != null)
            {
            }

            _RBTaskDisplay = value;
            if (_RBTaskDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butTaskRefresh;

    internal System.Windows.Forms.RibbonButton butTaskRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butTaskRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butTaskRefresh != null)
            {
            }

            _butTaskRefresh = value;
            if (_butTaskRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBTaskActions;

    internal System.Windows.Forms.RibbonPanel RBTaskActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBTaskActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBTaskActions != null)
            {
            }

            _RBTaskActions = value;
            if (_RBTaskActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butTaskShow;

    internal System.Windows.Forms.RibbonButton butTaskShow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butTaskShow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butTaskShow != null)
            {
            }

            _butTaskShow = value;
            if (_butTaskShow != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butTaskEndTask;

    internal System.Windows.Forms.RibbonButton butTaskEndTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butTaskEndTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butTaskEndTask != null)
            {
            }

            _butTaskEndTask = value;
            if (_butTaskEndTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerTask;

    internal System.Windows.Forms.Timer timerTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerTask != null)
            {
            }

            _timerTask = value;
            if (_timerTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _NetworkTab;

    internal System.Windows.Forms.RibbonTab NetworkTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NetworkTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NetworkTab != null)
            {
            }

            _NetworkTab = value;
            if (_NetworkTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBNetworkRefresh;

    internal System.Windows.Forms.RibbonPanel RBNetworkRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBNetworkRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBNetworkRefresh != null)
            {
            }

            _RBNetworkRefresh = value;
            if (_RBNetworkRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butNetworkRefresh;

    internal System.Windows.Forms.RibbonButton butNetworkRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butNetworkRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butNetworkRefresh != null)
            {
            }

            _butNetworkRefresh = value;
            if (_butNetworkRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerTrayIcon;

    internal System.Windows.Forms.Timer timerTrayIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerTrayIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerTrayIcon != null)
            {
            }

            _timerTrayIcon = value;
            if (_timerTrayIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator1;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator1 != null)
            {
            }

            _RibbonSeparator1 = value;
            if (_RibbonSeparator1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _panelProcessReport;

    internal System.Windows.Forms.RibbonPanel panelProcessReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelProcessReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelProcessReport != null)
            {
            }

            _panelProcessReport = value;
            if (_panelProcessReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butSaveProcessReport;

    internal System.Windows.Forms.RibbonButton butSaveProcessReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSaveProcessReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSaveProcessReport != null)
            {
            }

            _butSaveProcessReport = value;
            if (_butSaveProcessReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer __main;

    internal System.Windows.Forms.SplitContainer _main
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __main;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__main != null)
            {
            }

            __main = value;
            if (__main != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _containerSystemMenu;

    internal System.Windows.Forms.SplitContainer containerSystemMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _containerSystemMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_containerSystemMenu != null)
            {
            }

            _containerSystemMenu = value;
            if (_containerSystemMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabControl __tab;

    internal System.Windows.Forms.TabControl _tab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __tab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__tab != null)
            {
            }

            __tab = value;
            if (__tab != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageTasks;

    internal System.Windows.Forms.TabPage pageTasks
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageTasks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageTasks != null)
            {
            }

            _pageTasks = value;
            if (_pageTasks != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain13;

    internal System.Windows.Forms.Panel panelMain13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain13 != null)
            {
            }

            _panelMain13 = value;
            if (_panelMain13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerTask;

    internal System.Windows.Forms.SplitContainer SplitContainerTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerTask != null)
            {
            }

            _SplitContainerTask = value;
            if (_SplitContainerTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label19;

    internal System.Windows.Forms.Label Label19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label19 != null)
            {
            }

            _Label19 = value;
            if (_Label19 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblTaskCountResult;

    internal System.Windows.Forms.Label lblTaskCountResult
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTaskCountResult;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTaskCountResult != null)
            {
            }

            _lblTaskCountResult = value;
            if (_lblTaskCountResult != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSearchTask;

    internal System.Windows.Forms.TextBox txtSearchTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearchTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearchTask != null)
            {
            }

            _txtSearchTask = value;
            if (_txtSearchTask != null)
            {
            }
        }
    }

    private taskList _lvTask;

    internal taskList lvTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvTask != null)
            {
            }

            _lvTask = value;
            if (_lvTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader62;

    internal System.Windows.Forms.ColumnHeader ColumnHeader62
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader62;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader62 != null)
            {
            }

            _ColumnHeader62 = value;
            if (_ColumnHeader62 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader63;

    internal System.Windows.Forms.ColumnHeader ColumnHeader63
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader63;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader63 != null)
            {
            }

            _ColumnHeader63 = value;
            if (_ColumnHeader63 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader64;

    internal System.Windows.Forms.ColumnHeader ColumnHeader64
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader64;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader64 != null)
            {
            }

            _ColumnHeader64 = value;
            if (_ColumnHeader64 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageProcesses;

    internal System.Windows.Forms.TabPage pageProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageProcesses != null)
            {
            }

            _pageProcesses = value;
            if (_pageProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _containerProcessPage;

    internal System.Windows.Forms.SplitContainer containerProcessPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _containerProcessPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_containerProcessPage != null)
            {
            }

            _containerProcessPage = value;
            if (_containerProcessPage != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMenu;

    internal System.Windows.Forms.Panel panelMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMenu != null)
            {
            }

            _panelMenu = value;
            if (_panelMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label3;

    internal System.Windows.Forms.Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label3 != null)
            {
            }

            _Label3 = value;
            if (_Label3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblResCount;

    internal System.Windows.Forms.Label lblResCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblResCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblResCount != null)
            {
            }

            _lblResCount = value;
            if (_lblResCount != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSearch;

    internal System.Windows.Forms.TextBox txtSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearch != null)
            {
            }

            _txtSearch = value;
            if (_txtSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain;

    internal System.Windows.Forms.Panel panelMain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain != null)
            {
            }

            _panelMain = value;
            if (_panelMain != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerProcess;

    internal System.Windows.Forms.SplitContainer SplitContainerProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerProcess != null)
            {
            }

            _SplitContainerProcess = value;
            if (_SplitContainerProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerTvLv;

    internal System.Windows.Forms.SplitContainer SplitContainerTvLv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerTvLv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerTvLv != null)
            {
            }

            _SplitContainerTvLv = value;
            if (_SplitContainerTvLv != null)
            {
            }
        }
    }

    private System.Windows.Forms.TreeView _tvProc;

    internal System.Windows.Forms.TreeView tvProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tvProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tvProc != null)
            {
            }

            _tvProc = value;
            if (_tvProc != null)
            {
            }
        }
    }

    private processList _lvProcess;

    internal processList lvProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcess != null)
            {
            }

            _lvProcess = value;
            if (_lvProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c1;

    internal System.Windows.Forms.ColumnHeader c1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c1 != null)
            {
            }

            _c1 = value;
            if (_c1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c2;

    internal System.Windows.Forms.ColumnHeader c2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c2 != null)
            {
            }

            _c2 = value;
            if (_c2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c3;

    internal System.Windows.Forms.ColumnHeader c3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c3 != null)
            {
            }

            _c3 = value;
            if (_c3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c4;

    internal System.Windows.Forms.ColumnHeader c4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c4 != null)
            {
            }

            _c4 = value;
            if (_c4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c5;

    internal System.Windows.Forms.ColumnHeader c5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c5 != null)
            {
            }

            _c5 = value;
            if (_c5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c7;

    internal System.Windows.Forms.ColumnHeader c7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c7 != null)
            {
            }

            _c7 = value;
            if (_c7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c8;

    internal System.Windows.Forms.ColumnHeader c8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c8 != null)
            {
            }

            _c8 = value;
            if (_c8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c9;

    internal System.Windows.Forms.ColumnHeader c9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c9 != null)
            {
            }

            _c9 = value;
            if (_c9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c10;

    internal System.Windows.Forms.ColumnHeader c10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c10 != null)
            {
            }

            _c10 = value;
            if (_c10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader20;

    internal System.Windows.Forms.ColumnHeader ColumnHeader20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader20 != null)
            {
            }

            _ColumnHeader20 = value;
            if (_ColumnHeader20 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageMonitor;

    internal System.Windows.Forms.TabPage pageMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageMonitor != null)
            {
            }

            _pageMonitor = value;
            if (_pageMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain8;

    internal System.Windows.Forms.Panel panelMain8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain8 != null)
            {
            }

            _panelMain8 = value;
            if (_panelMain8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitMonitor;

    internal System.Windows.Forms.SplitContainer splitMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitMonitor != null)
            {
            }

            _splitMonitor = value;
            if (_splitMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.TreeView _tvMonitor;

    internal System.Windows.Forms.TreeView tvMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tvMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tvMonitor != null)
            {
            }

            _tvMonitor = value;
            if (_tvMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitMonitor2;

    internal System.Windows.Forms.SplitContainer splitMonitor2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitMonitor2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitMonitor2 != null)
            {
            }

            _splitMonitor2 = value;
            if (_splitMonitor2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtMonitoringLog;

    internal System.Windows.Forms.TextBox txtMonitoringLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtMonitoringLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtMonitoringLog != null)
            {
            }

            _txtMonitoringLog = value;
            if (_txtMonitoringLog != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvMonitorReport;

    internal DoubleBufferedLV lvMonitorReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvMonitorReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvMonitorReport != null)
            {
            }

            _lvMonitorReport = value;
            if (_lvMonitorReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader22;

    internal System.Windows.Forms.ColumnHeader ColumnHeader22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader22 != null)
            {
            }

            _ColumnHeader22 = value;
            if (_ColumnHeader22 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader23;

    internal System.Windows.Forms.ColumnHeader ColumnHeader23
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader23;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader23 != null)
            {
            }

            _ColumnHeader23 = value;
            if (_ColumnHeader23 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader47;

    internal System.Windows.Forms.ColumnHeader ColumnHeader47
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader47;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader47 != null)
            {
            }

            _ColumnHeader47 = value;
            if (_ColumnHeader47 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader48;

    internal System.Windows.Forms.ColumnHeader ColumnHeader48
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader48;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader48 != null)
            {
            }

            _ColumnHeader48 = value;
            if (_ColumnHeader48 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader49;

    internal System.Windows.Forms.ColumnHeader ColumnHeader49
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader49;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader49 != null)
            {
            }

            _ColumnHeader49 = value;
            if (_ColumnHeader49 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitMonitor3;

    internal System.Windows.Forms.SplitContainer splitMonitor3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitMonitor3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitMonitor3 != null)
            {
            }

            _splitMonitor3 = value;
            if (_splitMonitor3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitMonitor4;

    internal System.Windows.Forms.SplitContainer splitMonitor4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitMonitor4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitMonitor4 != null)
            {
            }

            _splitMonitor4 = value;
            if (_splitMonitor4 != null)
            {
            }
        }
    }

    private Graph _graphMonitor;

    internal Graph graphMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _graphMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_graphMonitor != null)
            {
            }

            _graphMonitor = value;
            if (_graphMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtMonitorNumber;

    internal System.Windows.Forms.TextBox txtMonitorNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtMonitorNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtMonitorNumber != null)
            {
            }

            _txtMonitorNumber = value;
            if (_txtMonitorNumber != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblMonitorMaxNumber;

    internal System.Windows.Forms.Label lblMonitorMaxNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMonitorMaxNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMonitorMaxNumber != null)
            {
            }

            _lblMonitorMaxNumber = value;
            if (_lblMonitorMaxNumber != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkMonitorRightAuto;

    internal System.Windows.Forms.CheckBox chkMonitorRightAuto
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkMonitorRightAuto;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkMonitorRightAuto != null)
            {
            }

            _chkMonitorRightAuto = value;
            if (_chkMonitorRightAuto != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkMonitorLeftAuto;

    internal System.Windows.Forms.CheckBox chkMonitorLeftAuto
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkMonitorLeftAuto;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkMonitorLeftAuto != null)
            {
            }

            _chkMonitorLeftAuto = value;
            if (_chkMonitorLeftAuto != null)
            {
            }
        }
    }

    private System.Windows.Forms.DateTimePicker _dtMonitorR;

    internal System.Windows.Forms.DateTimePicker dtMonitorR
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _dtMonitorR;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_dtMonitorR != null)
            {
            }

            _dtMonitorR = value;
            if (_dtMonitorR != null)
            {
            }
        }
    }

    private System.Windows.Forms.DateTimePicker _dtMonitorL;

    internal System.Windows.Forms.DateTimePicker dtMonitorL
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _dtMonitorL;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_dtMonitorL != null)
            {
            }

            _dtMonitorL = value;
            if (_dtMonitorL != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageServices;

    internal System.Windows.Forms.TabPage pageServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageServices != null)
            {
            }

            _pageServices = value;
            if (_pageServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _containerServicesPage;

    internal System.Windows.Forms.SplitContainer containerServicesPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _containerServicesPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_containerServicesPage != null)
            {
            }

            _containerServicesPage = value;
            if (_containerServicesPage != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMenu2;

    internal System.Windows.Forms.Panel panelMenu2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMenu2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMenu2 != null)
            {
            }

            _panelMenu2 = value;
            if (_panelMenu2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label2;

    internal System.Windows.Forms.Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label2 != null)
            {
            }

            _Label2 = value;
            if (_Label2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblResCount2;

    internal System.Windows.Forms.Label lblResCount2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblResCount2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblResCount2 != null)
            {
            }

            _lblResCount2 = value;
            if (_lblResCount2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServiceSearch;

    internal System.Windows.Forms.TextBox txtServiceSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceSearch != null)
            {
            }

            _txtServiceSearch = value;
            if (_txtServiceSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain2;

    internal System.Windows.Forms.Panel panelMain2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain2 != null)
            {
            }

            _panelMain2 = value;
            if (_panelMain2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitServices;

    internal System.Windows.Forms.SplitContainer splitServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitServices != null)
            {
            }

            _splitServices = value;
            if (_splitServices != null)
            {
            }
        }
    }

    private serviceList _lvServices;

    internal serviceList lvServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvServices != null)
            {
            }

            _lvServices = value;
            if (_lvServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader3;

    internal System.Windows.Forms.ColumnHeader ColumnHeader3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader3 != null)
            {
            }

            _ColumnHeader3 = value;
            if (_ColumnHeader3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader7;

    internal System.Windows.Forms.ColumnHeader ColumnHeader7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader7 != null)
            {
            }

            _ColumnHeader7 = value;
            if (_ColumnHeader7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader8;

    internal System.Windows.Forms.ColumnHeader ColumnHeader8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader8 != null)
            {
            }

            _ColumnHeader8 = value;
            if (_ColumnHeader8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader9;

    internal System.Windows.Forms.ColumnHeader ColumnHeader9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader9 != null)
            {
            }

            _ColumnHeader9 = value;
            if (_ColumnHeader9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader10;

    internal System.Windows.Forms.ColumnHeader ColumnHeader10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader10 != null)
            {
            }

            _ColumnHeader10 = value;
            if (_ColumnHeader10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader11;

    internal System.Windows.Forms.ColumnHeader ColumnHeader11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader11 != null)
            {
            }

            _ColumnHeader11 = value;
            if (_ColumnHeader11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader19;

    internal System.Windows.Forms.ColumnHeader ColumnHeader19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader19 != null)
            {
            }

            _ColumnHeader19 = value;
            if (_ColumnHeader19 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitServices2;

    internal System.Windows.Forms.SplitContainer splitServices2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitServices2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitServices2 != null)
            {
            }

            _splitServices2 = value;
            if (_splitServices2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCopyServiceToCp;

    internal System.Windows.Forms.Button cmdCopyServiceToCp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCopyServiceToCp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCopyServiceToCp != null)
            {
            }

            _cmdCopyServiceToCp = value;
            if (_cmdCopyServiceToCp != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _lblServicePath;

    internal System.Windows.Forms.TextBox lblServicePath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblServicePath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblServicePath != null)
            {
            }

            _lblServicePath = value;
            if (_lblServicePath != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblServiceName;

    internal System.Windows.Forms.Label lblServiceName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblServiceName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblServiceName != null)
            {
            }

            _lblServiceName = value;
            if (_lblServiceName != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitServices3;

    internal System.Windows.Forms.SplitContainer splitServices3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitServices3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitServices3 != null)
            {
            }

            _splitServices3 = value;
            if (_splitServices3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtb2;

    internal System.Windows.Forms.RichTextBox rtb2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtb2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtb2 != null)
            {
            }

            _rtb2 = value;
            if (_rtb2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitServices4;

    internal System.Windows.Forms.SplitContainer splitServices4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitServices4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitServices4 != null)
            {
            }

            _splitServices4 = value;
            if (_splitServices4 != null)
            {
            }
        }
    }

    private serviceDependenciesList _tv2;

    internal serviceDependenciesList tv2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tv2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tv2 != null)
            {
            }

            _tv2 = value;
            if (_tv2 != null)
            {
            }
        }
    }

    private serviceDependenciesList _tv;

    internal serviceDependenciesList tv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tv != null)
            {
            }

            _tv = value;
            if (_tv != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageNetwork;

    internal System.Windows.Forms.TabPage pageNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageNetwork != null)
            {
            }

            _pageNetwork = value;
            if (_pageNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain14;

    internal System.Windows.Forms.Panel panelMain14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain14 != null)
            {
            }

            _panelMain14 = value;
            if (_panelMain14 != null)
            {
            }
        }
    }

    private networkList _lvNetwork;

    internal networkList lvNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvNetwork != null)
            {
            }

            _lvNetwork = value;
            if (_lvNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader66;

    internal System.Windows.Forms.ColumnHeader ColumnHeader66
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader66;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader66 != null)
            {
            }

            _ColumnHeader66 = value;
            if (_ColumnHeader66 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader67;

    internal System.Windows.Forms.ColumnHeader ColumnHeader67
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader67;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader67 != null)
            {
            }

            _ColumnHeader67 = value;
            if (_ColumnHeader67 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader68;

    internal System.Windows.Forms.ColumnHeader ColumnHeader68
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader68;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader68 != null)
            {
            }

            _ColumnHeader68 = value;
            if (_ColumnHeader68 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader69;

    internal System.Windows.Forms.ColumnHeader ColumnHeader69
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader69;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader69 != null)
            {
            }

            _ColumnHeader69 = value;
            if (_ColumnHeader69 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageFile;

    internal System.Windows.Forms.TabPage pageFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageFile != null)
            {
            }

            _pageFile = value;
            if (_pageFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain5;

    internal System.Windows.Forms.Panel panelMain5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain5 != null)
            {
            }

            _panelMain5 = value;
            if (_panelMain5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageSearch;

    internal System.Windows.Forms.TabPage pageSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageSearch != null)
            {
            }

            _pageSearch = value;
            if (_pageSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain6;

    internal System.Windows.Forms.Panel panelMain6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain6 != null)
            {
            }

            _panelMain6 = value;
            if (_panelMain6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerSearch;

    internal System.Windows.Forms.SplitContainer SplitContainerSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerSearch != null)
            {
            }

            _SplitContainerSearch = value;
            if (_SplitContainerSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label11;

    internal System.Windows.Forms.Label Label11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label11 != null)
            {
            }

            _Label11 = value;
            if (_Label11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblResultsCount;

    internal System.Windows.Forms.Label lblResultsCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblResultsCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblResultsCount != null)
            {
            }

            _lblResultsCount = value;
            if (_lblResultsCount != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSearchResults;

    internal System.Windows.Forms.TextBox txtSearchResults
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearchResults;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearchResults != null)
            {
            }

            _txtSearchResults = value;
            if (_txtSearchResults != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchWindows;

    internal System.Windows.Forms.CheckBox chkSearchWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchWindows != null)
            {
            }

            _chkSearchWindows = value;
            if (_chkSearchWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchHandles;

    internal System.Windows.Forms.CheckBox chkSearchHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchHandles != null)
            {
            }

            _chkSearchHandles = value;
            if (_chkSearchHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label1;

    internal System.Windows.Forms.Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label1 != null)
            {
            }

            _Label1 = value;
            if (_Label1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchModules;

    internal System.Windows.Forms.CheckBox chkSearchModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchModules != null)
            {
            }

            _chkSearchModules = value;
            if (_chkSearchModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchServices;

    internal System.Windows.Forms.CheckBox chkSearchServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchServices != null)
            {
            }

            _chkSearchServices = value;
            if (_chkSearchServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchProcess;

    internal System.Windows.Forms.CheckBox chkSearchProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchProcess != null)
            {
            }

            _chkSearchProcess = value;
            if (_chkSearchProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchCase;

    internal System.Windows.Forms.CheckBox chkSearchCase
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchCase;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchCase != null)
            {
            }

            _chkSearchCase = value;
            if (_chkSearchCase != null)
            {
            }
        }
    }

    private searchList _lvSearchResults;

    internal searchList lvSearchResults
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvSearchResults;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvSearchResults != null)
            {
            }

            _lvSearchResults = value;
            if (_lvSearchResults != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader12;

    internal System.Windows.Forms.ColumnHeader ColumnHeader12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader12 != null)
            {
            }

            _ColumnHeader12 = value;
            if (_ColumnHeader12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader13;

    internal System.Windows.Forms.ColumnHeader ColumnHeader13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader13 != null)
            {
            }

            _ColumnHeader13 = value;
            if (_ColumnHeader13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader14;

    internal System.Windows.Forms.ColumnHeader ColumnHeader14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader14 != null)
            {
            }

            _ColumnHeader14 = value;
            if (_ColumnHeader14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader17;

    internal System.Windows.Forms.ColumnHeader ColumnHeader17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader17 != null)
            {
            }

            _ColumnHeader17 = value;
            if (_ColumnHeader17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageHelp;

    internal System.Windows.Forms.TabPage pageHelp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageHelp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageHelp != null)
            {
            }

            _pageHelp = value;
            if (_pageHelp != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain4;

    internal System.Windows.Forms.Panel panelMain4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain4 != null)
            {
            }

            _panelMain4 = value;
            if (_panelMain4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.WebBrowser _WBHelp;

    internal System.Windows.Forms.WebBrowser WBHelp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _WBHelp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_WBHelp != null)
            {
            }

            _WBHelp = value;
            if (_WBHelp != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerNetwork;

    internal System.Windows.Forms.Timer timerNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerNetwork != null)
            {
            }

            _timerNetwork = value;
            if (_timerNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerStateBasedActions;

    internal System.Windows.Forms.Timer timerStateBasedActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerStateBasedActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerStateBasedActions != null)
            {
            }

            _timerStateBasedActions = value;
            if (_timerStateBasedActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butLog;

    internal System.Windows.Forms.RibbonButton butLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butLog != null)
            {
            }

            _butLog = value;
            if (_butLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butSystemInfo;

    internal System.Windows.Forms.RibbonButton butSystemInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSystemInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSystemInfo != null)
            {
            }

            _butSystemInfo = value;
            if (_butSystemInfo != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butWindows;

    internal System.Windows.Forms.RibbonButton butWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butWindows != null)
            {
            }

            _butWindows = value;
            if (_butWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFindWindow;

    internal System.Windows.Forms.RibbonButton butFindWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFindWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFindWindow != null)
            {
            }

            _butFindWindow = value;
            if (_butFindWindow != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbMenuEmergency;

    internal System.Windows.Forms.RibbonOrbMenuItem orbMenuEmergency
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbMenuEmergency;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbMenuEmergency != null)
            {
            }

            _orbMenuEmergency = value;
            if (_orbMenuEmergency != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbMenuSBA;

    internal System.Windows.Forms.RibbonOrbMenuItem orbMenuSBA
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbMenuSBA;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbMenuSBA != null)
            {
            }

            _orbMenuSBA = value;
            if (_orbMenuSBA != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator2;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator2 != null)
            {
            }

            _RibbonSeparator2 = value;
            if (_RibbonSeparator2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbMenuSaveReport;

    internal System.Windows.Forms.RibbonOrbMenuItem orbMenuSaveReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbMenuSaveReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbMenuSaveReport != null)
            {
            }

            _orbMenuSaveReport = value;
            if (_orbMenuSaveReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbMenuAbout;

    internal System.Windows.Forms.RibbonOrbMenuItem orbMenuAbout
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbMenuAbout;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbMenuAbout != null)
            {
            }

            _orbMenuAbout = value;
            if (_orbMenuAbout != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbMenuNetwork;

    internal System.Windows.Forms.RibbonOrbMenuItem orbMenuNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbMenuNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbMenuNetwork != null)
            {
            }

            _orbMenuNetwork = value;
            if (_orbMenuNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator4;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator4 != null)
            {
            }

            _RibbonSeparator4 = value;
            if (_RibbonSeparator4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butNetwork;

    internal System.Windows.Forms.RibbonButton butNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butNetwork != null)
            {
            }

            _butNetwork = value;
            if (_butNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butFeedBack;

    internal System.Windows.Forms.RibbonButton butFeedBack
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFeedBack;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFeedBack != null)
            {
            }

            _butFeedBack = value;
            if (_butFeedBack != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butHiddenProcesses;

    internal System.Windows.Forms.RibbonButton butHiddenProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butHiddenProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butHiddenProcesses != null)
            {
            }

            _butHiddenProcesses = value;
            if (_butHiddenProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerFilexx;

    internal System.Windows.Forms.SplitContainer SplitContainerFilexx
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerFilexx;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerFilexx != null)
            {
            }

            _SplitContainerFilexx = value;
            if (_SplitContainerFilexx != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtFile;

    internal System.Windows.Forms.TextBox txtFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtFile != null)
            {
            }

            _txtFile = value;
            if (_txtFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdFileClipboard;

    internal System.Windows.Forms.Button cmdFileClipboard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdFileClipboard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdFileClipboard != null)
            {
            }

            _cmdFileClipboard = value;
            if (_cmdFileClipboard != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctFileSmall;

    internal System.Windows.Forms.PictureBox pctFileSmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctFileSmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctFileSmall != null)
            {
            }

            _pctFileSmall = value;
            if (_pctFileSmall != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctFileBig;

    internal System.Windows.Forms.PictureBox pctFileBig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctFileBig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctFileBig != null)
            {
            }

            _pctFileBig = value;
            if (_pctFileBig != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerFile2;

    internal System.Windows.Forms.SplitContainer SplitContainerFile2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerFile2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerFile2 != null)
            {
            }

            _SplitContainerFile2 = value;
            if (_SplitContainerFile2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtb3;

    internal System.Windows.Forms.RichTextBox rtb3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtb3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtb3 != null)
            {
            }

            _rtb3 = value;
            if (_rtb3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpFileAttributes;

    internal System.Windows.Forms.GroupBox gpFileAttributes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpFileAttributes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpFileAttributes != null)
            {
            }

            _gpFileAttributes = value;
            if (_gpFileAttributes != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileEncrypted;

    internal System.Windows.Forms.CheckBox chkFileEncrypted
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileEncrypted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileEncrypted != null)
            {
            }

            _chkFileEncrypted = value;
            if (_chkFileEncrypted != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileContentNotIndexed;

    internal System.Windows.Forms.CheckBox chkFileContentNotIndexed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileContentNotIndexed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileContentNotIndexed != null)
            {
            }

            _chkFileContentNotIndexed = value;
            if (_chkFileContentNotIndexed != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileNormal;

    internal System.Windows.Forms.CheckBox chkFileNormal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileNormal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileNormal != null)
            {
            }

            _chkFileNormal = value;
            if (_chkFileNormal != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileSystem;

    internal System.Windows.Forms.CheckBox chkFileSystem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileSystem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileSystem != null)
            {
            }

            _chkFileSystem = value;
            if (_chkFileSystem != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileReadOnly;

    internal System.Windows.Forms.CheckBox chkFileReadOnly
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileReadOnly;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileReadOnly != null)
            {
            }

            _chkFileReadOnly = value;
            if (_chkFileReadOnly != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileHidden;

    internal System.Windows.Forms.CheckBox chkFileHidden
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileHidden;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileHidden != null)
            {
            }

            _chkFileHidden = value;
            if (_chkFileHidden != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileCompressed;

    internal System.Windows.Forms.CheckBox chkFileCompressed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileCompressed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileCompressed != null)
            {
            }

            _chkFileCompressed = value;
            if (_chkFileCompressed != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFileArchive;

    internal System.Windows.Forms.CheckBox chkFileArchive
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFileArchive;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFileArchive != null)
            {
            }

            _chkFileArchive = value;
            if (_chkFileArchive != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpFileDates;

    internal System.Windows.Forms.GroupBox gpFileDates
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpFileDates;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpFileDates != null)
            {
            }

            _gpFileDates = value;
            if (_gpFileDates != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSetFileDates;

    internal System.Windows.Forms.Button cmdSetFileDates
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSetFileDates;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSetFileDates != null)
            {
            }

            _cmdSetFileDates = value;
            if (_cmdSetFileDates != null)
            {
            }
        }
    }

    private System.Windows.Forms.DateTimePicker _DTlastModification;

    internal System.Windows.Forms.DateTimePicker DTlastModification
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DTlastModification;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DTlastModification != null)
            {
            }

            _DTlastModification = value;
            if (_DTlastModification != null)
            {
            }
        }
    }

    private System.Windows.Forms.DateTimePicker _DTlastAccess;

    internal System.Windows.Forms.DateTimePicker DTlastAccess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DTlastAccess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DTlastAccess != null)
            {
            }

            _DTlastAccess = value;
            if (_DTlastAccess != null)
            {
            }
        }
    }

    private System.Windows.Forms.DateTimePicker _DTcreation;

    internal System.Windows.Forms.DateTimePicker DTcreation
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DTcreation;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DTcreation != null)
            {
            }

            _DTcreation = value;
            if (_DTcreation != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label6;

    internal System.Windows.Forms.Label Label6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label6 != null)
            {
            }

            _Label6 = value;
            if (_Label6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label5;

    internal System.Windows.Forms.Label Label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label5 != null)
            {
            }

            _Label5 = value;
            if (_Label5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label4;

    internal System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label4 != null)
            {
            }

            _Label4 = value;
            if (_Label4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerFile;

    internal System.Windows.Forms.SplitContainer SplitContainerFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerFile != null)
            {
            }

            _SplitContainerFile = value;
            if (_SplitContainerFile != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvFileString;

    internal DoubleBufferedLV lvFileString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvFileString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvFileString != null)
            {
            }

            _lvFileString = value;
            if (_lvFileString != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader2;

    internal System.Windows.Forms.ColumnHeader ColumnHeader2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader2 != null)
            {
            }

            _ColumnHeader2 = value;
            if (_ColumnHeader2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butServiceDetails;

    internal System.Windows.Forms.RibbonButton butServiceDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butServiceDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butServiceDetails != null)
            {
            }

            _butServiceDetails = value;
            if (_butServiceDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSearchEnvVar;

    internal System.Windows.Forms.CheckBox chkSearchEnvVar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSearchEnvVar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSearchEnvVar != null)
            {
            }

            _chkSearchEnvVar = value;
            if (_chkSearchEnvVar != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator5;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator5 != null)
            {
            }

            _RibbonSeparator5 = value;
            if (_RibbonSeparator5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbOptionButton _butExit;

    internal System.Windows.Forms.RibbonOrbOptionButton butExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butExit != null)
            {
            }

            _butExit = value;
            if (_butExit != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbOptionButton _butShowPreferences;

    internal System.Windows.Forms.RibbonOrbOptionButton butShowPreferences
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butShowPreferences;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butShowPreferences != null)
            {
            }

            _butShowPreferences = value;
            if (_butShowPreferences != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butShowDepViewer;

    internal System.Windows.Forms.RibbonButton butShowDepViewer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butShowDepViewer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butShowDepViewer != null)
            {
            }

            _butShowDepViewer = value;
            if (_butShowDepViewer != null)
            {
            }
        }
    }

    private wyDay.Controls.VistaMenu _VistaMenu;

    internal wyDay.Controls.VistaMenu VistaMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _VistaMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_VistaMenu != null)
            {
            }

            _VistaMenu = value;
            if (_VistaMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuTask;

    private System.Windows.Forms.ContextMenu mnuTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuTask != null)
            {
            }

            _mnuTask = value;
            if (_mnuTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskShow;

    internal System.Windows.Forms.MenuItem MenuItemTaskShow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskShow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskShow != null)
            {
            }

            _MenuItemTaskShow = value;
            if (_MenuItemTaskShow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskMax;

    internal System.Windows.Forms.MenuItem MenuItemTaskMax
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskMax;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskMax != null)
            {
            }

            _MenuItemTaskMax = value;
            if (_MenuItemTaskMax != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskMin;

    internal System.Windows.Forms.MenuItem MenuItemTaskMin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskMin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskMin != null)
            {
            }

            _MenuItemTaskMin = value;
            if (_MenuItemTaskMin != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem4;

    internal System.Windows.Forms.MenuItem MenuItem4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem4 != null)
            {
            }

            _MenuItem4 = value;
            if (_MenuItem4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskEnd;

    internal System.Windows.Forms.MenuItem MenuItemTaskEnd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskEnd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskEnd != null)
            {
            }

            _MenuItemTaskEnd = value;
            if (_MenuItemTaskEnd != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem6;

    internal System.Windows.Forms.MenuItem MenuItem6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem6 != null)
            {
            }

            _MenuItem6 = value;
            if (_MenuItem6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskSelProc;

    internal System.Windows.Forms.MenuItem MenuItemTaskSelProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskSelProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskSelProc != null)
            {
            }

            _MenuItemTaskSelProc = value;
            if (_MenuItemTaskSelProc != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem9;

    internal System.Windows.Forms.MenuItem MenuItem9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem9 != null)
            {
            }

            _MenuItem9 = value;
            if (_MenuItem9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskColumns;

    internal System.Windows.Forms.MenuItem MenuItemTaskColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskColumns != null)
            {
            }

            _MenuItemTaskColumns = value;
            if (_MenuItemTaskColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuMonitor;

    private System.Windows.Forms.ContextMenu mnuMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuMonitor != null)
            {
            }

            _mnuMonitor = value;
            if (_mnuMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMonitorAdd;

    internal System.Windows.Forms.MenuItem MenuItemMonitorAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMonitorAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMonitorAdd != null)
            {
            }

            _MenuItemMonitorAdd = value;
            if (_MenuItemMonitorAdd != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMonitorRemove;

    internal System.Windows.Forms.MenuItem MenuItemMonitorRemove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMonitorRemove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMonitorRemove != null)
            {
            }

            _MenuItemMonitorRemove = value;
            if (_MenuItemMonitorRemove != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem1;

    internal System.Windows.Forms.MenuItem MenuItem1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem1 != null)
            {
            }

            _MenuItem1 = value;
            if (_MenuItem1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMonitorStart;

    internal System.Windows.Forms.MenuItem MenuItemMonitorStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMonitorStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMonitorStart != null)
            {
            }

            _MenuItemMonitorStart = value;
            if (_MenuItemMonitorStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMonitorStop;

    internal System.Windows.Forms.MenuItem MenuItemMonitorStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMonitorStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMonitorStop != null)
            {
            }

            _MenuItemMonitorStop = value;
            if (_MenuItemMonitorStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuFileCpPctBig;

    private System.Windows.Forms.ContextMenu mnuFileCpPctBig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuFileCpPctBig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuFileCpPctBig != null)
            {
            }

            _mnuFileCpPctBig = value;
            if (_mnuFileCpPctBig != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyBig;

    internal System.Windows.Forms.MenuItem MenuItemCopyBig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyBig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyBig != null)
            {
            }

            _MenuItemCopyBig = value;
            if (_MenuItemCopyBig != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuFileCpPctSmall;

    private System.Windows.Forms.ContextMenu mnuFileCpPctSmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuFileCpPctSmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuFileCpPctSmall != null)
            {
            }

            _mnuFileCpPctSmall = value;
            if (_mnuFileCpPctSmall != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopySmall;

    internal System.Windows.Forms.MenuItem MenuItemCopySmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopySmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopySmall != null)
            {
            }

            _MenuItemCopySmall = value;
            if (_MenuItemCopySmall != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuMain;

    private System.Windows.Forms.ContextMenu mnuMain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuMain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuMain != null)
            {
            }

            _mnuMain = value;
            if (_mnuMain != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainShow;

    internal System.Windows.Forms.MenuItem MenuItemMainShow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainShow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainShow != null)
            {
            }

            _MenuItemMainShow = value;
            if (_MenuItemMainShow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainToTray;

    internal System.Windows.Forms.MenuItem MenuItemMainToTray
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainToTray;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainToTray != null)
            {
            }

            _MenuItemMainToTray = value;
            if (_MenuItemMainToTray != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainAbout;

    internal System.Windows.Forms.MenuItem MenuItemMainAbout
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainAbout;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainAbout != null)
            {
            }

            _MenuItemMainAbout = value;
            if (_MenuItemMainAbout != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainAlwaysVisible;

    internal System.Windows.Forms.MenuItem MenuItemMainAlwaysVisible
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainAlwaysVisible;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainAlwaysVisible != null)
            {
            }

            _MenuItemMainAlwaysVisible = value;
            if (_MenuItemMainAlwaysVisible != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem2;

    internal System.Windows.Forms.MenuItem MenuItem2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem2 != null)
            {
            }

            _MenuItem2 = value;
            if (_MenuItem2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem3;

    internal System.Windows.Forms.MenuItem MenuItem3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem3 != null)
            {
            }

            _MenuItem3 = value;
            if (_MenuItem3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem5;

    internal System.Windows.Forms.MenuItem MenuItem5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem5 != null)
            {
            }

            _MenuItem5 = value;
            if (_MenuItem5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainLog;

    internal System.Windows.Forms.MenuItem MenuItemMainLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainLog != null)
            {
            }

            _MenuItemMainLog = value;
            if (_MenuItemMainLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainReport;

    internal System.Windows.Forms.MenuItem MenuItemMainReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainReport != null)
            {
            }

            _MenuItemMainReport = value;
            if (_MenuItemMainReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainSysInfo;

    internal System.Windows.Forms.MenuItem MenuItemMainSysInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainSysInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainSysInfo != null)
            {
            }

            _MenuItemMainSysInfo = value;
            if (_MenuItemMainSysInfo != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainOpenedW;

    internal System.Windows.Forms.MenuItem MenuItemMainOpenedW
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainOpenedW;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainOpenedW != null)
            {
            }

            _MenuItemMainOpenedW = value;
            if (_MenuItemMainOpenedW != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainEmergencyH;

    internal System.Windows.Forms.MenuItem MenuItemMainEmergencyH
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainEmergencyH;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainEmergencyH != null)
            {
            }

            _MenuItemMainEmergencyH = value;
            if (_MenuItemMainEmergencyH != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainFindWindow;

    internal System.Windows.Forms.MenuItem MenuItemMainFindWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainFindWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainFindWindow != null)
            {
            }

            _MenuItemMainFindWindow = value;
            if (_MenuItemMainFindWindow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainSBA;

    internal System.Windows.Forms.MenuItem MenuItemMainSBA
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainSBA;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainSBA != null)
            {
            }

            _MenuItemMainSBA = value;
            if (_MenuItemMainSBA != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem15;

    internal System.Windows.Forms.MenuItem MenuItem15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem15 != null)
            {
            }

            _MenuItem15 = value;
            if (_MenuItem15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemRefProc;

    internal System.Windows.Forms.MenuItem MenuItemRefProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemRefProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemRefProc != null)
            {
            }

            _MenuItemRefProc = value;
            if (_MenuItemRefProc != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainRefServ;

    internal System.Windows.Forms.MenuItem MenuItemMainRefServ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainRefServ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainRefServ != null)
            {
            }

            _MenuItemMainRefServ = value;
            if (_MenuItemMainRefServ != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem18;

    internal System.Windows.Forms.MenuItem MenuItem18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem18 != null)
            {
            }

            _MenuItem18 = value;
            if (_MenuItem18 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainExit;

    internal System.Windows.Forms.MenuItem MenuItemMainExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainExit != null)
            {
            }

            _MenuItemMainExit = value;
            if (_MenuItemMainExit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainRestart;

    internal System.Windows.Forms.MenuItem MenuItemMainRestart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainRestart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainRestart != null)
            {
            }

            _MenuItemMainRestart = value;
            if (_MenuItemMainRestart != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainShutdown;

    internal System.Windows.Forms.MenuItem MenuItemMainShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainShutdown != null)
            {
            }

            _MenuItemMainShutdown = value;
            if (_MenuItemMainShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainPowerOff;

    internal System.Windows.Forms.MenuItem MenuItemMainPowerOff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainPowerOff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainPowerOff != null)
            {
            }

            _MenuItemMainPowerOff = value;
            if (_MenuItemMainPowerOff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem11;

    internal System.Windows.Forms.MenuItem MenuItem11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem11 != null)
            {
            }

            _MenuItem11 = value;
            if (_MenuItem11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainSleep;

    internal System.Windows.Forms.MenuItem MenuItemMainSleep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainSleep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainSleep != null)
            {
            }

            _MenuItemMainSleep = value;
            if (_MenuItemMainSleep != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainHibernate;

    internal System.Windows.Forms.MenuItem MenuItemMainHibernate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainHibernate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainHibernate != null)
            {
            }

            _MenuItemMainHibernate = value;
            if (_MenuItemMainHibernate != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem17;

    internal System.Windows.Forms.MenuItem MenuItem17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem17 != null)
            {
            }

            _MenuItem17 = value;
            if (_MenuItem17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainLogOff;

    internal System.Windows.Forms.MenuItem MenuItemMainLogOff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainLogOff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainLogOff != null)
            {
            }

            _MenuItemMainLogOff = value;
            if (_MenuItemMainLogOff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainLock;

    internal System.Windows.Forms.MenuItem MenuItemMainLock
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainLock;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainLock != null)
            {
            }

            _MenuItemMainLock = value;
            if (_MenuItemMainLock != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuService;

    private System.Windows.Forms.ContextMenu mnuService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuService != null)
            {
            }

            _mnuService = value;
            if (_mnuService != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServSelService;

    internal System.Windows.Forms.MenuItem MenuItemServSelService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServSelService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServSelService != null)
            {
            }

            _MenuItemServSelService = value;
            if (_MenuItemServSelService != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem7;

    internal System.Windows.Forms.MenuItem MenuItem7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem7 != null)
            {
            }

            _MenuItem7 = value;
            if (_MenuItem7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServFileProp;

    internal System.Windows.Forms.MenuItem MenuItemServFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServFileProp != null)
            {
            }

            _MenuItemServFileProp = value;
            if (_MenuItemServFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServOpenDir;

    internal System.Windows.Forms.MenuItem MenuItemServOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServOpenDir != null)
            {
            }

            _MenuItemServOpenDir = value;
            if (_MenuItemServOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServFileDetails;

    internal System.Windows.Forms.MenuItem MenuItemServFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServFileDetails != null)
            {
            }

            _MenuItemServFileDetails = value;
            if (_MenuItemServFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServSearch;

    internal System.Windows.Forms.MenuItem MenuItemServSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServSearch != null)
            {
            }

            _MenuItemServSearch = value;
            if (_MenuItemServSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServDepe;

    internal System.Windows.Forms.MenuItem MenuItemServDepe
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServDepe;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServDepe != null)
            {
            }

            _MenuItemServDepe = value;
            if (_MenuItemServDepe != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem20;

    internal System.Windows.Forms.MenuItem MenuItem20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem20 != null)
            {
            }

            _MenuItem20 = value;
            if (_MenuItem20 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServPause;

    internal System.Windows.Forms.MenuItem MenuItemServPause
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServPause;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServPause != null)
            {
            }

            _MenuItemServPause = value;
            if (_MenuItemServPause != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServStop;

    internal System.Windows.Forms.MenuItem MenuItemServStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServStop != null)
            {
            }

            _MenuItemServStop = value;
            if (_MenuItemServStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServStart;

    internal System.Windows.Forms.MenuItem MenuItemServStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServStart != null)
            {
            }

            _MenuItemServStart = value;
            if (_MenuItemServStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServStartType;

    internal System.Windows.Forms.MenuItem MenuItemServStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServStartType != null)
            {
            }

            _MenuItemServStartType = value;
            if (_MenuItemServStartType != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServAutoStart;

    internal System.Windows.Forms.MenuItem MenuItemServAutoStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServAutoStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServAutoStart != null)
            {
            }

            _MenuItemServAutoStart = value;
            if (_MenuItemServAutoStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServOnDemand;

    internal System.Windows.Forms.MenuItem MenuItemServOnDemand
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServOnDemand;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServOnDemand != null)
            {
            }

            _MenuItemServOnDemand = value;
            if (_MenuItemServOnDemand != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServDisabled;

    internal System.Windows.Forms.MenuItem MenuItemServDisabled
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServDisabled;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServDisabled != null)
            {
            }

            _MenuItemServDisabled = value;
            if (_MenuItemServDisabled != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem25;

    internal System.Windows.Forms.MenuItem MenuItem25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem25 != null)
            {
            }

            _MenuItem25 = value;
            if (_MenuItem25 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServReanalize;

    internal System.Windows.Forms.MenuItem MenuItemServReanalize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServReanalize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServReanalize != null)
            {
            }

            _MenuItemServReanalize = value;
            if (_MenuItemServReanalize != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem24;

    internal System.Windows.Forms.MenuItem MenuItem24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem24 != null)
            {
            }

            _MenuItem24 = value;
            if (_MenuItem24 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServColumns;

    internal System.Windows.Forms.MenuItem MenuItemServColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServColumns != null)
            {
            }

            _MenuItemServColumns = value;
            if (_MenuItemServColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuNetwork;

    private System.Windows.Forms.ContextMenu mnuNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuNetwork != null)
            {
            }

            _mnuNetwork = value;
            if (_mnuNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServSelProc;

    internal System.Windows.Forms.MenuItem MenuItemServSelProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServSelProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServSelProc != null)
            {
            }

            _MenuItemServSelProc = value;
            if (_MenuItemServSelProc != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem16;

    internal System.Windows.Forms.MenuItem MenuItem16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem16 != null)
            {
            }

            _MenuItem16 = value;
            if (_MenuItem16 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkClose;

    internal System.Windows.Forms.MenuItem MenuItemNetworkClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkClose != null)
            {
            }

            _MenuItemNetworkClose = value;
            if (_MenuItemNetworkClose != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem10;

    internal System.Windows.Forms.MenuItem MenuItem10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem10 != null)
            {
            }

            _MenuItem10 = value;
            if (_MenuItem10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkColumns;

    internal System.Windows.Forms.MenuItem MenuItemNetworkColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkColumns != null)
            {
            }

            _MenuItemNetworkColumns = value;
            if (_MenuItemNetworkColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuSearch;

    private System.Windows.Forms.ContextMenu mnuSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuSearch != null)
            {
            }

            _mnuSearch = value;
            if (_mnuSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSearchNew;

    internal System.Windows.Forms.MenuItem MenuItemSearchNew
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSearchNew;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSearchNew != null)
            {
            }

            _MenuItemSearchNew = value;
            if (_MenuItemSearchNew != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem28;

    internal System.Windows.Forms.MenuItem MenuItem28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem28 != null)
            {
            }

            _MenuItem28 = value;
            if (_MenuItem28 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSearchClose;

    internal System.Windows.Forms.MenuItem MenuItemSearchClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSearchClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSearchClose != null)
            {
            }

            _MenuItemSearchClose = value;
            if (_MenuItemSearchClose != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSearchSel;

    internal System.Windows.Forms.MenuItem MenuItemSearchSel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSearchSel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSearchSel != null)
            {
            }

            _MenuItemSearchSel = value;
            if (_MenuItemSearchSel != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuProcess;

    private System.Windows.Forms.ContextMenu mnuProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuProcess != null)
            {
            }

            _mnuProcess = value;
            if (_mnuProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSFileProp;

    internal System.Windows.Forms.MenuItem MenuItemProcSFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSFileProp != null)
            {
            }

            _MenuItemProcSFileProp = value;
            if (_MenuItemProcSFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSOpenDir;

    internal System.Windows.Forms.MenuItem MenuItemProcSOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSOpenDir != null)
            {
            }

            _MenuItemProcSOpenDir = value;
            if (_MenuItemProcSOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSFileDetails;

    internal System.Windows.Forms.MenuItem MenuItemProcSFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSFileDetails != null)
            {
            }

            _MenuItemProcSFileDetails = value;
            if (_MenuItemProcSFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSSearch;

    internal System.Windows.Forms.MenuItem MenuItemProcSSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSSearch != null)
            {
            }

            _MenuItemProcSSearch = value;
            if (_MenuItemProcSSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSDep;

    internal System.Windows.Forms.MenuItem MenuItemProcSDep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSDep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSDep != null)
            {
            }

            _MenuItemProcSDep = value;
            if (_MenuItemProcSDep != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem38;

    internal System.Windows.Forms.MenuItem MenuItem38
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem38;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem38 != null)
            {
            }

            _MenuItem38 = value;
            if (_MenuItem38 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcColumns;

    internal System.Windows.Forms.MenuItem MenuItemProcColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcColumns != null)
            {
            }

            _MenuItemProcColumns = value;
            if (_MenuItemProcColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKill;

    internal System.Windows.Forms.MenuItem MenuItemProcKill
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKill;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKill != null)
            {
            }

            _MenuItemProcKill = value;
            if (_MenuItemProcKill != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKillT;

    internal System.Windows.Forms.MenuItem MenuItemProcKillT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKillT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKillT != null)
            {
            }

            _MenuItemProcKillT = value;
            if (_MenuItemProcKillT != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcStop;

    internal System.Windows.Forms.MenuItem MenuItemProcStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcStop != null)
            {
            }

            _MenuItemProcStop = value;
            if (_MenuItemProcStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcResume;

    internal System.Windows.Forms.MenuItem MenuItemProcResume
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcResume;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcResume != null)
            {
            }

            _MenuItemProcResume = value;
            if (_MenuItemProcResume != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPriority;

    internal System.Windows.Forms.MenuItem MenuItemProcPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPriority != null)
            {
            }

            _MenuItemProcPriority = value;
            if (_MenuItemProcPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcReanalize;

    internal System.Windows.Forms.MenuItem MenuItemProcReanalize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcReanalize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcReanalize != null)
            {
            }

            _MenuItemProcReanalize = value;
            if (_MenuItemProcReanalize != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem44;

    internal System.Windows.Forms.MenuItem MenuItem44
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem44;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem44 != null)
            {
            }

            _MenuItem44 = value;
            if (_MenuItem44 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem51;

    internal System.Windows.Forms.MenuItem MenuItem51
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem51;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem51 != null)
            {
            }

            _MenuItem51 = value;
            if (_MenuItem51 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPIdle;

    internal System.Windows.Forms.MenuItem MenuItemProcPIdle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPIdle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPIdle != null)
            {
            }

            _MenuItemProcPIdle = value;
            if (_MenuItemProcPIdle != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPBN;

    internal System.Windows.Forms.MenuItem MenuItemProcPBN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPBN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPBN != null)
            {
            }

            _MenuItemProcPBN = value;
            if (_MenuItemProcPBN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPN;

    internal System.Windows.Forms.MenuItem MenuItemProcPN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPN != null)
            {
            }

            _MenuItemProcPN = value;
            if (_MenuItemProcPN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPAN;

    internal System.Windows.Forms.MenuItem MenuItemProcPAN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPAN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPAN != null)
            {
            }

            _MenuItemProcPAN = value;
            if (_MenuItemProcPAN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPH;

    internal System.Windows.Forms.MenuItem MenuItemProcPH
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPH;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPH != null)
            {
            }

            _MenuItemProcPH = value;
            if (_MenuItemProcPH != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPRT;

    internal System.Windows.Forms.MenuItem MenuItemProcPRT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPRT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPRT != null)
            {
            }

            _MenuItemProcPRT = value;
            if (_MenuItemProcPRT != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcOther;

    internal System.Windows.Forms.MenuItem MenuItemProcOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcOther != null)
            {
            }

            _MenuItemProcOther = value;
            if (_MenuItemProcOther != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcWSS;

    internal System.Windows.Forms.MenuItem MenuItemProcWSS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcWSS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcWSS != null)
            {
            }

            _MenuItemProcWSS = value;
            if (_MenuItemProcWSS != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcAff;

    internal System.Windows.Forms.MenuItem MenuItemProcAff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcAff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcAff != null)
            {
            }

            _MenuItemProcAff = value;
            if (_MenuItemProcAff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcDump;

    internal System.Windows.Forms.MenuItem MenuItemProcDump
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcDump;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcDump != null)
            {
            }

            _MenuItemProcDump = value;
            if (_MenuItemProcDump != null)
            {
            }
        }
    }

    private System.Windows.Forms.MainMenu _mnuSystem;

    private System.Windows.Forms.MainMenu mnuSystem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuSystem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuSystem != null)
            {
            }

            _mnuSystem = value;
            if (_mnuSystem != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSYSTEMFILE;

    internal System.Windows.Forms.MenuItem MenuItemSYSTEMFILE
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSYSTEMFILE;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSYSTEMFILE != null)
            {
            }

            _MenuItemSYSTEMFILE = value;
            if (_MenuItemSYSTEMFILE != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSYSTEMOPT;

    internal System.Windows.Forms.MenuItem MenuItemSYSTEMOPT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSYSTEMOPT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSYSTEMOPT != null)
            {
            }

            _MenuItemSYSTEMOPT = value;
            if (_MenuItemSYSTEMOPT != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSYSTEMTOOLS;

    internal System.Windows.Forms.MenuItem MenuItemSYSTEMTOOLS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSYSTEMTOOLS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSYSTEMTOOLS != null)
            {
            }

            _MenuItemSYSTEMTOOLS = value;
            if (_MenuItemSYSTEMTOOLS != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSYSTEMSYSTEM;

    internal System.Windows.Forms.MenuItem MenuItemSYSTEMSYSTEM
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSYSTEMSYSTEM;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSYSTEMSYSTEM != null)
            {
            }

            _MenuItemSYSTEMSYSTEM = value;
            if (_MenuItemSYSTEMSYSTEM != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSYSTEMHEL;

    internal System.Windows.Forms.MenuItem MenuItemSYSTEMHEL
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSYSTEMHEL;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSYSTEMHEL != null)
            {
            }

            _MenuItemSYSTEMHEL = value;
            if (_MenuItemSYSTEMHEL != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem34;

    internal System.Windows.Forms.MenuItem MenuItem34
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem34;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem34 != null)
            {
            }

            _MenuItem34 = value;
            if (_MenuItem34 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemRestart;

    internal System.Windows.Forms.MenuItem MenuItemSystemRestart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemRestart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemRestart != null)
            {
            }

            _MenuItemSystemRestart = value;
            if (_MenuItemSystemRestart != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemShutdown;

    internal System.Windows.Forms.MenuItem MenuItemSystemShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemShutdown != null)
            {
            }

            _MenuItemSystemShutdown = value;
            if (_MenuItemSystemShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemPowerOff;

    internal System.Windows.Forms.MenuItem MenuItemSystemPowerOff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemPowerOff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemPowerOff != null)
            {
            }

            _MenuItemSystemPowerOff = value;
            if (_MenuItemSystemPowerOff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem40;

    internal System.Windows.Forms.MenuItem MenuItem40
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem40;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem40 != null)
            {
            }

            _MenuItem40 = value;
            if (_MenuItem40 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemSleep;

    internal System.Windows.Forms.MenuItem MenuItemSystemSleep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemSleep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemSleep != null)
            {
            }

            _MenuItemSystemSleep = value;
            if (_MenuItemSystemSleep != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemHIbernate;

    internal System.Windows.Forms.MenuItem MenuItemSystemHIbernate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemHIbernate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemHIbernate != null)
            {
            }

            _MenuItemSystemHIbernate = value;
            if (_MenuItemSystemHIbernate != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem43;

    internal System.Windows.Forms.MenuItem MenuItem43
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem43;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem43 != null)
            {
            }

            _MenuItem43 = value;
            if (_MenuItem43 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemLogoff;

    internal System.Windows.Forms.MenuItem MenuItemSystemLogoff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemLogoff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemLogoff != null)
            {
            }

            _MenuItemSystemLogoff = value;
            if (_MenuItemSystemLogoff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemLock;

    internal System.Windows.Forms.MenuItem MenuItemSystemLock
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemLock;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemLock != null)
            {
            }

            _MenuItemSystemLock = value;
            if (_MenuItemSystemLock != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemShowHidden;

    internal System.Windows.Forms.MenuItem MenuItemSystemShowHidden
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemShowHidden;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemShowHidden != null)
            {
            }

            _MenuItemSystemShowHidden = value;
            if (_MenuItemSystemShowHidden != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemDependency;

    internal System.Windows.Forms.MenuItem MenuItemSystemDependency
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemDependency;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemDependency != null)
            {
            }

            _MenuItemSystemDependency = value;
            if (_MenuItemSystemDependency != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemAlwaysVisible;

    internal System.Windows.Forms.MenuItem MenuItemSystemAlwaysVisible
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemAlwaysVisible;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemAlwaysVisible != null)
            {
            }

            _MenuItemSystemAlwaysVisible = value;
            if (_MenuItemSystemAlwaysVisible != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem37;

    internal System.Windows.Forms.MenuItem MenuItem37
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem37;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem37 != null)
            {
            }

            _MenuItem37 = value;
            if (_MenuItem37 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemRefProc;

    internal System.Windows.Forms.MenuItem MenuItemSystemRefProc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemRefProc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemRefProc != null)
            {
            }

            _MenuItemSystemRefProc = value;
            if (_MenuItemSystemRefProc != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemRefServ;

    internal System.Windows.Forms.MenuItem MenuItemSystemRefServ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemRefServ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemRefServ != null)
            {
            }

            _MenuItemSystemRefServ = value;
            if (_MenuItemSystemRefServ != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem42;

    internal System.Windows.Forms.MenuItem MenuItem42
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem42;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem42 != null)
            {
            }

            _MenuItem42 = value;
            if (_MenuItem42 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemOptions;

    internal System.Windows.Forms.MenuItem MenuItemSystemOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemOptions != null)
            {
            }

            _MenuItemSystemOptions = value;
            if (_MenuItemSystemOptions != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemRefresh;

    internal System.Windows.Forms.MenuItem MenuItemSystemRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemRefresh != null)
            {
            }

            _MenuItemSystemRefresh = value;
            if (_MenuItemSystemRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem54;

    internal System.Windows.Forms.MenuItem MenuItem54
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem54;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem54 != null)
            {
            }

            _MenuItem54 = value;
            if (_MenuItem54 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemConnection;

    internal System.Windows.Forms.MenuItem MenuItemSystemConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemConnection != null)
            {
            }

            _MenuItemSystemConnection = value;
            if (_MenuItemSystemConnection != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem56;

    internal System.Windows.Forms.MenuItem MenuItem56
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem56;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem56 != null)
            {
            }

            _MenuItem56 = value;
            if (_MenuItem56 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemLog;

    internal System.Windows.Forms.MenuItem MenuItemSystemLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemLog != null)
            {
            }

            _MenuItemSystemLog = value;
            if (_MenuItemSystemLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemReport;

    internal System.Windows.Forms.MenuItem MenuItemSystemReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemReport != null)
            {
            }

            _MenuItemSystemReport = value;
            if (_MenuItemSystemReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem59;

    internal System.Windows.Forms.MenuItem MenuItem59
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem59;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem59 != null)
            {
            }

            _MenuItem59 = value;
            if (_MenuItem59 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemInfos;

    internal System.Windows.Forms.MenuItem MenuItemSystemInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemInfos != null)
            {
            }

            _MenuItemSystemInfos = value;
            if (_MenuItemSystemInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemOpenedWindows;

    internal System.Windows.Forms.MenuItem MenuItemSystemOpenedWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemOpenedWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemOpenedWindows != null)
            {
            }

            _MenuItemSystemOpenedWindows = value;
            if (_MenuItemSystemOpenedWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem62;

    internal System.Windows.Forms.MenuItem MenuItem62
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem62;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem62 != null)
            {
            }

            _MenuItem62 = value;
            if (_MenuItem62 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemFindWindow;

    internal System.Windows.Forms.MenuItem MenuItemSystemFindWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemFindWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemFindWindow != null)
            {
            }

            _MenuItemSystemFindWindow = value;
            if (_MenuItemSystemFindWindow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemEmergency;

    internal System.Windows.Forms.MenuItem MenuItemSystemEmergency
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemEmergency;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemEmergency != null)
            {
            }

            _MenuItemSystemEmergency = value;
            if (_MenuItemSystemEmergency != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemSBA;

    internal System.Windows.Forms.MenuItem MenuItemSystemSBA
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemSBA;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemSBA != null)
            {
            }

            _MenuItemSystemSBA = value;
            if (_MenuItemSystemSBA != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem66;

    internal System.Windows.Forms.MenuItem MenuItem66
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem66;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem66 != null)
            {
            }

            _MenuItem66 = value;
            if (_MenuItem66 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemToTray;

    internal System.Windows.Forms.MenuItem MenuItemSystemToTray
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemToTray;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemToTray != null)
            {
            }

            _MenuItemSystemToTray = value;
            if (_MenuItemSystemToTray != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemExit;

    internal System.Windows.Forms.MenuItem MenuItemSystemExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemExit != null)
            {
            }

            _MenuItemSystemExit = value;
            if (_MenuItemSystemExit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemUpdate;

    internal System.Windows.Forms.MenuItem MenuItemSystemUpdate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemUpdate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemUpdate != null)
            {
            }

            _MenuItemSystemUpdate = value;
            if (_MenuItemSystemUpdate != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem39;

    internal System.Windows.Forms.MenuItem MenuItem39
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem39;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem39 != null)
            {
            }

            _MenuItem39 = value;
            if (_MenuItem39 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemDonation;

    internal System.Windows.Forms.MenuItem MenuItemSystemDonation
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemDonation;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemDonation != null)
            {
            }

            _MenuItemSystemDonation = value;
            if (_MenuItemSystemDonation != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemFeedBack;

    internal System.Windows.Forms.MenuItem MenuItemSystemFeedBack
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemFeedBack;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemFeedBack != null)
            {
            }

            _MenuItemSystemFeedBack = value;
            if (_MenuItemSystemFeedBack != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemSF;

    internal System.Windows.Forms.MenuItem MenuItemSystemSF
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemSF;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemSF != null)
            {
            }

            _MenuItemSystemSF = value;
            if (_MenuItemSystemSF != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemWebsite;

    internal System.Windows.Forms.MenuItem MenuItemSystemWebsite
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemWebsite;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemWebsite != null)
            {
            }

            _MenuItemSystemWebsite = value;
            if (_MenuItemSystemWebsite != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemDownloads;

    internal System.Windows.Forms.MenuItem MenuItemSystemDownloads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemDownloads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemDownloads != null)
            {
            }

            _MenuItemSystemDownloads = value;
            if (_MenuItemSystemDownloads != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem49;

    internal System.Windows.Forms.MenuItem MenuItem49
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem49;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem49 != null)
            {
            }

            _MenuItem49 = value;
            if (_MenuItem49 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemHelp;

    internal System.Windows.Forms.MenuItem MenuItemSystemHelp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemHelp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemHelp != null)
            {
            }

            _MenuItemSystemHelp = value;
            if (_MenuItemSystemHelp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemAbout;

    internal System.Windows.Forms.MenuItem MenuItemSystemAbout
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemAbout;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemAbout != null)
            {
            }

            _MenuItemSystemAbout = value;
            if (_MenuItemSystemAbout != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem30;

    internal System.Windows.Forms.MenuItem MenuItem30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem30 != null)
            {
            }

            _MenuItem30 = value;
            if (_MenuItem30 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopySearch;

    internal System.Windows.Forms.MenuItem MenuItemCopySearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopySearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopySearch != null)
            {
            }

            _MenuItemCopySearch = value;
            if (_MenuItemCopySearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyProcess;

    internal System.Windows.Forms.MenuItem MenuItemCopyProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyProcess != null)
            {
            }

            _MenuItemCopyProcess = value;
            if (_MenuItemCopyProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyTask;

    internal System.Windows.Forms.MenuItem MenuItemCopyTask
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyTask;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyTask != null)
            {
            }

            _MenuItemCopyTask = value;
            if (_MenuItemCopyTask != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyService;

    internal System.Windows.Forms.MenuItem MenuItemCopyService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyService != null)
            {
            }

            _MenuItemCopyService = value;
            if (_MenuItemCopyService != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyNetwork;

    internal System.Windows.Forms.MenuItem MenuItemCopyNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyNetwork != null)
            {
            }

            _MenuItemCopyNetwork = value;
            if (_MenuItemCopyNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbMenuItem _orbStartElevated;

    internal System.Windows.Forms.RibbonOrbMenuItem orbStartElevated
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orbStartElevated;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orbStartElevated != null)
            {
            }

            _orbStartElevated = value;
            if (_orbStartElevated != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemRunAsAdmin;

    internal System.Windows.Forms.MenuItem MenuItemRunAsAdmin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemRunAsAdmin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemRunAsAdmin != null)
            {
            }

            _MenuItemRunAsAdmin = value;
            if (_MenuItemRunAsAdmin != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _headerString;

    internal System.Windows.Forms.ColumnHeader headerString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _headerString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_headerString != null)
            {
            }

            _headerString = value;
            if (_headerString != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBar _StatusBar;

    internal System.Windows.Forms.StatusBar StatusBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _StatusBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_StatusBar != null)
            {
            }

            _StatusBar = value;
            if (_StatusBar != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelConnection;

    internal System.Windows.Forms.StatusBarPanel sbPanelConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelConnection != null)
            {
            }

            _sbPanelConnection = value;
            if (_sbPanelConnection != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelProcesses;

    internal System.Windows.Forms.StatusBarPanel sbPanelProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelProcesses != null)
            {
            }

            _sbPanelProcesses = value;
            if (_sbPanelProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelServices;

    internal System.Windows.Forms.StatusBarPanel sbPanelServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelServices != null)
            {
            }

            _sbPanelServices = value;
            if (_sbPanelServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelCpu;

    internal System.Windows.Forms.StatusBarPanel sbPanelCpu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelCpu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelCpu != null)
            {
            }

            _sbPanelCpu = value;
            if (_sbPanelCpu != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelMemory;

    internal System.Windows.Forms.StatusBarPanel sbPanelMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelMemory != null)
            {
            }

            _sbPanelMemory = value;
            if (_sbPanelMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerStatus;

    internal System.Windows.Forms.Timer timerStatus
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerStatus;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerStatus != null)
            {
            }

            _timerStatus = value;
            if (_timerStatus != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butShowAllPendingTasks;

    internal System.Windows.Forms.RibbonButton butShowAllPendingTasks
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butShowAllPendingTasks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butShowAllPendingTasks != null)
            {
            }

            _butShowAllPendingTasks = value;
            if (_butShowAllPendingTasks != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemShowPendingTasks;

    internal System.Windows.Forms.MenuItem MenuItemShowPendingTasks
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemShowPendingTasks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemShowPendingTasks != null)
            {
            }

            _MenuItemShowPendingTasks = value;
            if (_MenuItemShowPendingTasks != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcesses;

    internal System.Windows.Forms.MenuItem MenuItemProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcesses != null)
            {
            }

            _MenuItemProcesses = value;
            if (_MenuItemProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemReportProcesses;

    internal System.Windows.Forms.MenuItem MenuItemReportProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemReportProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemReportProcesses != null)
            {
            }

            _MenuItemReportProcesses = value;
            if (_MenuItemReportProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMonitor;

    internal System.Windows.Forms.MenuItem MenuItemMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMonitor != null)
            {
            }

            _MenuItemMonitor = value;
            if (_MenuItemMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemReportMonitor;

    internal System.Windows.Forms.MenuItem MenuItemReportMonitor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemReportMonitor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemReportMonitor != null)
            {
            }

            _MenuItemReportMonitor = value;
            if (_MenuItemReportMonitor != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServices;

    internal System.Windows.Forms.MenuItem MenuItemServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServices != null)
            {
            }

            _MenuItemServices = value;
            if (_MenuItemServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemReportServices;

    internal System.Windows.Forms.MenuItem MenuItemReportServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemReportServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemReportServices != null)
            {
            }

            _MenuItemReportServices = value;
            if (_MenuItemReportServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSearch;

    internal System.Windows.Forms.MenuItem MenuItemSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSearch != null)
            {
            }

            _MenuItemSearch = value;
            if (_MenuItemSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNewSearch;

    internal System.Windows.Forms.MenuItem MenuItemNewSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNewSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNewSearch != null)
            {
            }

            _MenuItemNewSearch = value;
            if (_MenuItemNewSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem61;

    internal System.Windows.Forms.MenuItem MenuItem61
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem61;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem61 != null)
            {
            }

            _MenuItem61 = value;
            if (_MenuItem61 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemReportSearch;

    internal System.Windows.Forms.MenuItem MenuItemReportSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemReportSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemReportSearch != null)
            {
            }

            _MenuItemReportSearch = value;
            if (_MenuItemReportSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFiles;

    internal System.Windows.Forms.MenuItem MenuItemFiles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFiles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFiles != null)
            {
            }

            _MenuItemFiles = value;
            if (_MenuItemFiles != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileOpen;

    internal System.Windows.Forms.MenuItem MenuItemFileOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileOpen != null)
            {
            }

            _MenuItemFileOpen = value;
            if (_MenuItemFileOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem68;

    internal System.Windows.Forms.MenuItem MenuItem68
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem68;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem68 != null)
            {
            }

            _MenuItem68 = value;
            if (_MenuItem68 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileRelease;

    internal System.Windows.Forms.MenuItem MenuItemFileRelease
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileRelease;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileRelease != null)
            {
            }

            _MenuItemFileRelease = value;
            if (_MenuItemFileRelease != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileDelete;

    internal System.Windows.Forms.MenuItem MenuItemFileDelete
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileDelete;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileDelete != null)
            {
            }

            _MenuItemFileDelete = value;
            if (_MenuItemFileDelete != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileTrash;

    internal System.Windows.Forms.MenuItem MenuItemFileTrash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileTrash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileTrash != null)
            {
            }

            _MenuItemFileTrash = value;
            if (_MenuItemFileTrash != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem72;

    internal System.Windows.Forms.MenuItem MenuItem72
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem72;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem72 != null)
            {
            }

            _MenuItem72 = value;
            if (_MenuItem72 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileRename;

    internal System.Windows.Forms.MenuItem MenuItemFileRename
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileRename;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileRename != null)
            {
            }

            _MenuItemFileRename = value;
            if (_MenuItemFileRename != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileShellOpen;

    internal System.Windows.Forms.MenuItem MenuItemFileShellOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileShellOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileShellOpen != null)
            {
            }

            _MenuItemFileShellOpen = value;
            if (_MenuItemFileShellOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileMove;

    internal System.Windows.Forms.MenuItem MenuItemFileMove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileMove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileMove != null)
            {
            }

            _MenuItemFileMove = value;
            if (_MenuItemFileMove != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileCopy;

    internal System.Windows.Forms.MenuItem MenuItemFileCopy
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileCopy;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileCopy != null)
            {
            }

            _MenuItemFileCopy = value;
            if (_MenuItemFileCopy != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem77;

    internal System.Windows.Forms.MenuItem MenuItem77
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem77;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem77 != null)
            {
            }

            _MenuItem77 = value;
            if (_MenuItem77 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileEncrypt;

    internal System.Windows.Forms.MenuItem MenuItemFileEncrypt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileEncrypt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileEncrypt != null)
            {
            }

            _MenuItemFileEncrypt = value;
            if (_MenuItemFileEncrypt != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileDecrypt;

    internal System.Windows.Forms.MenuItem MenuItemFileDecrypt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileDecrypt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileDecrypt != null)
            {
            }

            _MenuItemFileDecrypt = value;
            if (_MenuItemFileDecrypt != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem80;

    internal System.Windows.Forms.MenuItem MenuItem80
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem80;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem80 != null)
            {
            }

            _MenuItem80 = value;
            if (_MenuItem80 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileStrings;

    internal System.Windows.Forms.MenuItem MenuItemFileStrings
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileStrings;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileStrings != null)
            {
            }

            _MenuItemFileStrings = value;
            if (_MenuItemFileStrings != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessReduceWS;

    internal System.Windows.Forms.RibbonButton butProcessReduceWS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessReduceWS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessReduceWS != null)
            {
            }

            _butProcessReduceWS = value;
            if (_butProcessReduceWS != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butProcessDumpF;

    internal System.Windows.Forms.RibbonButton butProcessDumpF
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butProcessDumpF;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butProcessDumpF != null)
            {
            }

            _butProcessDumpF = value;
            if (_butProcessDumpF != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem29;

    internal System.Windows.Forms.MenuItem MenuItem29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem29 != null)
            {
            }

            _MenuItem29 = value;
            if (_MenuItem29 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem31;

    internal System.Windows.Forms.MenuItem MenuItem31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem31 != null)
            {
            }

            _MenuItem31 = value;
            if (_MenuItem31 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifNP;

    internal System.Windows.Forms.MenuItem MenuItemNotifNP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifNP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifNP != null)
            {
            }

            _MenuItemNotifNP = value;
            if (_MenuItemNotifNP != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifTP;

    internal System.Windows.Forms.MenuItem MenuItemNotifTP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifTP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifTP != null)
            {
            }

            _MenuItemNotifTP = value;
            if (_MenuItemNotifTP != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifNS;

    internal System.Windows.Forms.MenuItem MenuItemNotifNS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifNS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifNS != null)
            {
            }

            _MenuItemNotifNS = value;
            if (_MenuItemNotifNS != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifDS;

    internal System.Windows.Forms.MenuItem MenuItemNotifDS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifDS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifDS != null)
            {
            }

            _MenuItemNotifDS = value;
            if (_MenuItemNotifDS != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem46;

    internal System.Windows.Forms.MenuItem MenuItem46
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem46;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem46 != null)
            {
            }

            _MenuItem46 = value;
            if (_MenuItem46 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifAll;

    internal System.Windows.Forms.MenuItem MenuItemNotifAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifAll != null)
            {
            }

            _MenuItemNotifAll = value;
            if (_MenuItemNotifAll != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNotifNone;

    internal System.Windows.Forms.MenuItem MenuItemNotifNone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNotifNone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNotifNone != null)
            {
            }

            _MenuItemNotifNone = value;
            if (_MenuItemNotifNone != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcJob;

    internal System.Windows.Forms.MenuItem MenuItemProcJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcJob != null)
            {
            }

            _MenuItemProcJob = value;
            if (_MenuItemProcJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcAddToJob;

    internal System.Windows.Forms.MenuItem MenuItemProcAddToJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcAddToJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcAddToJob != null)
            {
            }

            _MenuItemProcAddToJob = value;
            if (_MenuItemProcAddToJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem33;

    internal System.Windows.Forms.MenuItem MenuItem33
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem33;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem33 != null)
            {
            }

            _MenuItem33 = value;
            if (_MenuItem33 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemJobMng;

    internal System.Windows.Forms.MenuItem MenuItemJobMng
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemJobMng;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemJobMng != null)
            {
            }

            _MenuItemJobMng = value;
            if (_MenuItemJobMng != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageJobs;

    internal System.Windows.Forms.TabPage pageJobs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageJobs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageJobs != null)
            {
            }

            _pageJobs = value;
            if (_pageJobs != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonTab _JobTab;

    internal System.Windows.Forms.RibbonTab JobTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _JobTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_JobTab != null)
            {
            }

            _JobTab = value;
            if (_JobTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemJobs;

    internal System.Windows.Forms.MenuItem MenuItemJobs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemJobs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemJobs != null)
            {
            }

            _MenuItemJobs = value;
            if (_MenuItemJobs != null)
            {
            }
        }
    }

    private System.Windows.Forms.Panel _panelMain12;

    internal System.Windows.Forms.Panel panelMain12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panelMain12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_panelMain12 != null)
            {
            }

            _panelMain12 = value;
            if (_panelMain12 != null)
            {
            }
        }
    }

    private jobList _lvJob;

    internal jobList lvJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvJob != null)
            {
            }

            _lvJob = value;
            if (_lvJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader50;

    internal System.Windows.Forms.ColumnHeader ColumnHeader50
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader50;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader50 != null)
            {
            }

            _ColumnHeader50 = value;
            if (_ColumnHeader50 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerJobs;

    internal System.Windows.Forms.Timer timerJobs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerJobs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerJobs != null)
            {
            }

            _timerJobs = value;
            if (_timerJobs != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuJob;

    private System.Windows.Forms.ContextMenu mnuJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuJob != null)
            {
            }

            _mnuJob = value;
            if (_mnuJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemJobTerminate;

    internal System.Windows.Forms.MenuItem MenuItemJobTerminate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemJobTerminate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemJobTerminate != null)
            {
            }

            _MenuItemJobTerminate = value;
            if (_MenuItemJobTerminate != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem53;

    internal System.Windows.Forms.MenuItem MenuItem53
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem53;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem53 != null)
            {
            }

            _MenuItem53 = value;
            if (_MenuItem53 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyJob;

    internal System.Windows.Forms.MenuItem MenuItemCopyJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyJob != null)
            {
            }

            _MenuItemCopyJob = value;
            if (_MenuItemCopyJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader5;

    internal System.Windows.Forms.ColumnHeader ColumnHeader5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader5 != null)
            {
            }

            _ColumnHeader5 = value;
            if (_ColumnHeader5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBJobDisplay;

    internal System.Windows.Forms.RibbonPanel RBJobDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBJobDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBJobDisplay != null)
            {
            }

            _RBJobDisplay = value;
            if (_RBJobDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butJobRefresh;

    internal System.Windows.Forms.RibbonButton butJobRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butJobRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butJobRefresh != null)
            {
            }

            _butJobRefresh = value;
            if (_butJobRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBJobActions;

    internal System.Windows.Forms.RibbonPanel RBJobActions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBJobActions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBJobActions != null)
            {
            }

            _RBJobActions = value;
            if (_RBJobActions != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butJobTerminate;

    internal System.Windows.Forms.RibbonButton butJobTerminate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butJobTerminate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butJobTerminate != null)
            {
            }

            _butJobTerminate = value;
            if (_butJobTerminate != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butJobDetails;

    internal System.Windows.Forms.RibbonButton butJobDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butJobDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butJobDetails != null)
            {
            }

            _butJobDetails = value;
            if (_butJobDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKillByMethod;

    internal System.Windows.Forms.MenuItem MenuItemProcKillByMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKillByMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKillByMethod != null)
            {
            }

            _MenuItemProcKillByMethod = value;
            if (_MenuItemProcKillByMethod != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonPanel _RBJobPrivileges;

    internal System.Windows.Forms.RibbonPanel RBJobPrivileges
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RBJobPrivileges;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RBJobPrivileges != null)
            {
            }

            _RBJobPrivileges = value;
            if (_RBJobPrivileges != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butJobElevate;

    internal System.Windows.Forms.RibbonButton butJobElevate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butJobElevate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butJobElevate != null)
            {
            }

            _butJobElevate = value;
            if (_butJobElevate != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCreateService;

    internal System.Windows.Forms.MenuItem MenuItemCreateService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCreateService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCreateService != null)
            {
            }

            _MenuItemCreateService = value;
            if (_MenuItemCreateService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butCreateService;

    internal System.Windows.Forms.RibbonButton butCreateService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butCreateService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butCreateService != null)
            {
            }

            _butCreateService = value;
            if (_butCreateService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butDeleteService;

    internal System.Windows.Forms.RibbonButton butDeleteService
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butDeleteService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butDeleteService != null)
            {
            }

            _butDeleteService = value;
            if (_butDeleteService != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator3;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator3 != null)
            {
            }

            _RibbonSeparator3 = value;
            if (_RibbonSeparator3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonSeparator _RibbonSeparator6;

    internal System.Windows.Forms.RibbonSeparator RibbonSeparator6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RibbonSeparator6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RibbonSeparator6 != null)
            {
            }

            _RibbonSeparator6 = value;
            if (_RibbonSeparator6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemServDelete;

    internal System.Windows.Forms.MenuItem MenuItemServDelete
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServDelete;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServDelete != null)
            {
            }

            _MenuItemServDelete = value;
            if (_MenuItemServDelete != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemTaskSelectWindow;

    internal System.Windows.Forms.MenuItem MenuItemTaskSelectWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemTaskSelectWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemTaskSelectWindow != null)
            {
            }

            _MenuItemTaskSelectWindow = value;
            if (_MenuItemTaskSelectWindow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkTools;

    internal System.Windows.Forms.MenuItem MenuItemNetworkTools
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkTools;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkTools != null)
            {
            }

            _MenuItemNetworkTools = value;
            if (_MenuItemNetworkTools != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkPing;

    internal System.Windows.Forms.MenuItem MenuItemNetworkPing
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkPing;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkPing != null)
            {
            }

            _MenuItemNetworkPing = value;
            if (_MenuItemNetworkPing != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkRoute;

    internal System.Windows.Forms.MenuItem MenuItemNetworkRoute
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkRoute;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkRoute != null)
            {
            }

            _MenuItemNetworkRoute = value;
            if (_MenuItemNetworkRoute != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemNetworkWhoIs;

    internal System.Windows.Forms.MenuItem MenuItemNetworkWhoIs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemNetworkWhoIs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemNetworkWhoIs != null)
            {
            }

            _MenuItemNetworkWhoIs = value;
            if (_MenuItemNetworkWhoIs != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemNetworkInfos;

    internal System.Windows.Forms.MenuItem MenuItemSystemNetworkInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemNetworkInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemNetworkInfos != null)
            {
            }

            _MenuItemSystemNetworkInfos = value;
            if (_MenuItemSystemNetworkInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMainNetworkInfo;

    internal System.Windows.Forms.MenuItem MenuItemMainNetworkInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMainNetworkInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMainNetworkInfo != null)
            {
            }

            _MenuItemMainNetworkInfo = value;
            if (_MenuItemMainNetworkInfo != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butNetworkInfos;

    internal System.Windows.Forms.RibbonButton butNetworkInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butNetworkInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butNetworkInfos != null)
            {
            }

            _butNetworkInfos = value;
            if (_butNetworkInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemScripting;

    internal System.Windows.Forms.MenuItem MenuItemSystemScripting
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemScripting;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemScripting != null)
            {
            }

            _MenuItemSystemScripting = value;
            if (_MenuItemSystemScripting != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butScripting;

    internal System.Windows.Forms.RibbonButton butScripting
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butScripting;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butScripting != null)
            {
            }

            _butScripting = value;
            if (_butScripting != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butSaveSystemSnaphotFile;

    internal System.Windows.Forms.RibbonButton butSaveSystemSnaphotFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butSaveSystemSnaphotFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butSaveSystemSnaphotFile != null)
            {
            }

            _butSaveSystemSnaphotFile = value;
            if (_butSaveSystemSnaphotFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemSaveSSFile;

    internal System.Windows.Forms.MenuItem MenuItemSystemSaveSSFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemSaveSSFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemSaveSSFile != null)
            {
            }

            _MenuItemSystemSaveSSFile = value;
            if (_MenuItemSystemSaveSSFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butExploreSSFile;

    internal System.Windows.Forms.RibbonButton butExploreSSFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butExploreSSFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butExploreSSFile != null)
            {
            }

            _butExploreSSFile = value;
            if (_butExploreSSFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemExploreSSFile;

    internal System.Windows.Forms.MenuItem MenuItemSystemExploreSSFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemExploreSSFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemExploreSSFile != null)
            {
            }

            _MenuItemSystemExploreSSFile = value;
            if (_MenuItemSystemExploreSSFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonButton _butCheckSignatures;

    internal System.Windows.Forms.RibbonButton butCheckSignatures
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butCheckSignatures;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butCheckSignatures != null)
            {
            }

            _butCheckSignatures = value;
            if (_butCheckSignatures != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSystemCheckSignatures;

    internal System.Windows.Forms.MenuItem MenuItemSystemCheckSignatures
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSystemCheckSignatures;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSystemCheckSignatures != null)
            {
            }

            _MenuItemSystemCheckSignatures = value;
            if (_MenuItemSystemCheckSignatures != null)
            {
            }
        }
    }

    private System.Windows.Forms.RibbonOrbOptionButton _butFreeMemory;

    internal System.Windows.Forms.RibbonOrbOptionButton butFreeMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butFreeMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butFreeMemory != null)
            {
            }

            _butFreeMemory = value;
            if (_butFreeMemory != null)
            {
            }
        }
    }
}

