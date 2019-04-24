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
partial class frmProcessInfo : System.Windows.Forms.Form
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

    // REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    // Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    // Ne la modifiez pas à l'aide de l'éditeur de code.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        cConnection CConnection1 = new cConnection();
        cConnection CConnection2 = new cConnection();
        cConnection CConnection3 = new cConnection();
        cConnection CConnection4 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Strings", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        cConnection CConnection5 = new cConnection();
        cConnection CConnection6 = new cConnection();
        cConnection CConnection7 = new cConnection();
        cConnection CConnection8 = new cConnection();
        cConnection CConnection9 = new cConnection();
        cConnection CConnection10 = new cConnection();
        cConnection CConnection11 = new cConnection();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessInfo));
        this.timerProcPerf = new System.Windows.Forms.Timer(this.components);
        this.timerLog = new System.Windows.Forms.Timer(this.components);
        this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.MenuItemRefresh = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyBig = new System.Windows.Forms.MenuItem();
        this.MenuItemCopySmall = new System.Windows.Forms.MenuItem();
        this.MenuItemPriEnable = new System.Windows.Forms.MenuItem();
        this.MenuItemViewMemory = new System.Windows.Forms.MenuItem();
        this.MenuItemCloseHandle = new System.Windows.Forms.MenuItem();
        this.menuCloseTCP = new System.Windows.Forms.MenuItem();
        this.MenuItemPriDisable = new System.Windows.Forms.MenuItem();
        this.MenuItemPriRemove = new System.Windows.Forms.MenuItem();
        this.MenuItemModuleFileProp = new System.Windows.Forms.MenuItem();
        this.MenuItemModuleOpenDir = new System.Windows.Forms.MenuItem();
        this.MenuItemModuleFileDetails = new System.Windows.Forms.MenuItem();
        this.MenuItemModuleSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemModuleDependencies = new System.Windows.Forms.MenuItem();
        this.MenuItemUnloadModule = new System.Windows.Forms.MenuItem();
        this.MenuItemViewModuleMemory = new System.Windows.Forms.MenuItem();
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
        this.MenuItemThTerm = new System.Windows.Forms.MenuItem();
        this.MenuItemThSuspend = new System.Windows.Forms.MenuItem();
        this.MenuItemThResu = new System.Windows.Forms.MenuItem();
        this.MenuItemThIdle = new System.Windows.Forms.MenuItem();
        this.MenuItemThLowest = new System.Windows.Forms.MenuItem();
        this.MenuItemThBNormal = new System.Windows.Forms.MenuItem();
        this.MenuItemThNorm = new System.Windows.Forms.MenuItem();
        this.MenuItemThANorm = new System.Windows.Forms.MenuItem();
        this.MenuItemThHighest = new System.Windows.Forms.MenuItem();
        this.MenuItemThTimeCr = new System.Windows.Forms.MenuItem();
        this.MenuItemWShow = new System.Windows.Forms.MenuItem();
        this.MenuItemWClose = new System.Windows.Forms.MenuItem();
        this.MenuItemWDisa = new System.Windows.Forms.MenuItem();
        this.MenuItemLogGoto = new System.Windows.Forms.MenuItem();
        this.menuViewMemory = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyPrivilege = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyMemory = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyModule = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyThread = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyWindow = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyHandle = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyNetwork = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyService = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyLog = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyEnvVariable = new System.Windows.Forms.MenuItem();
        this.menuCopyPctbig = new System.Windows.Forms.ContextMenu();
        this.menuCopyPctSmall = new System.Windows.Forms.ContextMenu();
        this.mnuString = new System.Windows.Forms.ContextMenu();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyString = new System.Windows.Forms.MenuItem();
        this.mnuPrivileges = new System.Windows.Forms.ContextMenu();
        this.MenuItem1 = new System.Windows.Forms.MenuItem();
        this.mnuProcMem = new System.Windows.Forms.ContextMenu();
        this.MenuItemMemoryDump = new System.Windows.Forms.MenuItem();
        this.MenuItemPEBAddress = new System.Windows.Forms.MenuItem();
        this.MenuItem13 = new System.Windows.Forms.MenuItem();
        this.MenuItemMemoryRelease = new System.Windows.Forms.MenuItem();
        this.MenuItemMemoryDecommit = new System.Windows.Forms.MenuItem();
        this.MenuItemMemoryChangeProtection = new System.Windows.Forms.MenuItem();
        this.MenuItem22 = new System.Windows.Forms.MenuItem();
        this.MenuItemColumnsMemory = new System.Windows.Forms.MenuItem();
        this.mnuModule = new System.Windows.Forms.ContextMenu();
        this.MenuItem16 = new System.Windows.Forms.MenuItem();
        this.MenuItem19 = new System.Windows.Forms.MenuItem();
        this.MenuItemColumnsModule = new System.Windows.Forms.MenuItem();
        this.mnuThread = new System.Windows.Forms.ContextMenu();
        this.MenuItem8 = new System.Windows.Forms.MenuItem();
        this.MenuItemThAffinity = new System.Windows.Forms.MenuItem();
        this.MenuItem15 = new System.Windows.Forms.MenuItem();
        this.MenuItemThColumns = new System.Windows.Forms.MenuItem();
        this.mnuWindow = new System.Windows.Forms.ContextMenu();
        this.MenuItemWShowUn = new System.Windows.Forms.MenuItem();
        this.MenuItemWHide = new System.Windows.Forms.MenuItem();
        this.MenuItem9 = new System.Windows.Forms.MenuItem();
        this.MenuItemWVisiblity = new System.Windows.Forms.MenuItem();
        this.MenuItemWFront = new System.Windows.Forms.MenuItem();
        this.MenuItemWNotFront = new System.Windows.Forms.MenuItem();
        this.MenuItemWActive = new System.Windows.Forms.MenuItem();
        this.MenuItemWForeground = new System.Windows.Forms.MenuItem();
        this.MenuItem26 = new System.Windows.Forms.MenuItem();
        this.MenuItemWMin = new System.Windows.Forms.MenuItem();
        this.MenuItemWMax = new System.Windows.Forms.MenuItem();
        this.MenuItemWPosSize = new System.Windows.Forms.MenuItem();
        this.MenuItem4 = new System.Windows.Forms.MenuItem();
        this.MenuItemWFlash = new System.Windows.Forms.MenuItem();
        this.MenuItemWStopFlash = new System.Windows.Forms.MenuItem();
        this.MenuItem21 = new System.Windows.Forms.MenuItem();
        this.MenuItemWOpacity = new System.Windows.Forms.MenuItem();
        this.MenuItemWCaption = new System.Windows.Forms.MenuItem();
        this.MenuItem30 = new System.Windows.Forms.MenuItem();
        this.MenuItemWEna = new System.Windows.Forms.MenuItem();
        this.MenuItem33 = new System.Windows.Forms.MenuItem();
        this.MenuItemWColumns = new System.Windows.Forms.MenuItem();
        this.mnuHandle = new System.Windows.Forms.ContextMenu();
        this.MenuItemHandleDetails = new System.Windows.Forms.MenuItem();
        this.MenuItem12 = new System.Windows.Forms.MenuItem();
        this.MenuItemShowUnnamedHandles = new System.Windows.Forms.MenuItem();
        this.MenuItem14 = new System.Windows.Forms.MenuItem();
        this.MenuItemChooseColumnsHandle = new System.Windows.Forms.MenuItem();
        this.mnuNetwork = new System.Windows.Forms.ContextMenu();
        this.MenuItemNetworkTools = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkPing = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkRoute = new System.Windows.Forms.MenuItem();
        this.MenuItemNetworkWhoIs = new System.Windows.Forms.MenuItem();
        this.MenuItem10 = new System.Windows.Forms.MenuItem();
        this.MenuItemColumnsNetwork = new System.Windows.Forms.MenuItem();
        this.mnuService = new System.Windows.Forms.ContextMenu();
        this.MenuItemServDetails = new System.Windows.Forms.MenuItem();
        this.MenuItem5 = new System.Windows.Forms.MenuItem();
        this.MenuItemServDepe = new System.Windows.Forms.MenuItem();
        this.MenuItem20 = new System.Windows.Forms.MenuItem();
        this.MenuItem17 = new System.Windows.Forms.MenuItem();
        this.MenuItemServDelete = new System.Windows.Forms.MenuItem();
        this.MenuItem25 = new System.Windows.Forms.MenuItem();
        this.MenuItemServReanalize = new System.Windows.Forms.MenuItem();
        this.MenuItem24 = new System.Windows.Forms.MenuItem();
        this.MenuItemServColumns = new System.Windows.Forms.MenuItem();
        this.mnuLog = new System.Windows.Forms.ContextMenu();
        this.MenuItem6 = new System.Windows.Forms.MenuItem();
        this.mnuEnv = new System.Windows.Forms.ContextMenu();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemCopyHeaps = new System.Windows.Forms.MenuItem();
        this.RadioButton1 = new System.Windows.Forms.RadioButton();
        this.mnuHeaps = new System.Windows.Forms.ContextMenu();
        this.MenuItem11 = new System.Windows.Forms.MenuItem();
        this.MenuItemColumnsHeap = new System.Windows.Forms.MenuItem();
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.tabProcess = new System.Windows.Forms.TabControl();
        this.TabPageGeneral = new System.Windows.Forms.TabPage();
        this.GroupBox7 = new System.Windows.Forms.GroupBox();
        this.cmdSet = new System.Windows.Forms.Button();
        this.cbPriority = new System.Windows.Forms.ComboBox();
        this.cmdAffinity = new System.Windows.Forms.Button();
        this.cmdPause = new System.Windows.Forms.Button();
        this.cmdResume = new System.Windows.Forms.Button();
        this.cmdKill = new System.Windows.Forms.Button();
        this.GroupBox6 = new System.Windows.Forms.GroupBox();
        this.SplitContainerOnlineInfo = new System.Windows.Forms.SplitContainer();
        this.lblSecurityRisk = new System.Windows.Forms.Label();
        this.cmdGetOnlineInfos = new System.Windows.Forms.Button();
        this.rtbOnlineInfos = new System.Windows.Forms.RichTextBox();
        this.GroupBoxProcessInfos = new System.Windows.Forms.GroupBox();
        this.cmdGoProcess = new System.Windows.Forms.Button();
        this.txtRunTime = new System.Windows.Forms.TextBox();
        this.txtProcessStarted = new System.Windows.Forms.TextBox();
        this.Label14 = new System.Windows.Forms.Label();
        this.txtParentProcess = new System.Windows.Forms.TextBox();
        this.Label15 = new System.Windows.Forms.Label();
        this.txtPriority = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.txtCommandLine = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtProcessUser = new System.Windows.Forms.TextBox();
        this.Label17 = new System.Windows.Forms.Label();
        this.txtProcessId = new System.Windows.Forms.TextBox();
        this.Label16 = new System.Windows.Forms.Label();
        this.gpProcGeneralFile = new System.Windows.Forms.GroupBox();
        this.cmdInspectExe = new System.Windows.Forms.Button();
        this.cmdShowFileDetails = new System.Windows.Forms.Button();
        this.cmdShowFileProperties = new System.Windows.Forms.Button();
        this.cmdOpenDirectory = new System.Windows.Forms.Button();
        this.txtProcessPath = new System.Windows.Forms.TextBox();
        this.Label13 = new System.Windows.Forms.Label();
        this.txtImageVersion = new System.Windows.Forms.TextBox();
        this.Label12 = new System.Windows.Forms.Label();
        this.lblCopyright = new System.Windows.Forms.Label();
        this.lblDescription = new System.Windows.Forms.Label();
        this.pctSmallIcon = new System.Windows.Forms.PictureBox();
        this.pctBigIcon = new System.Windows.Forms.PictureBox();
        this.TabPageStats = new System.Windows.Forms.TabPage();
        this.GroupBox5 = new System.Windows.Forms.GroupBox();
        this.lblThreads = new System.Windows.Forms.Label();
        this.Label44 = new System.Windows.Forms.Label();
        this.lblUserObjectsCount = new System.Windows.Forms.Label();
        this.Label37 = new System.Windows.Forms.Label();
        this.lblGDIcount = new System.Windows.Forms.Label();
        this.lbl789 = new System.Windows.Forms.Label();
        this.lblHandles = new System.Windows.Forms.Label();
        this.Label53 = new System.Windows.Forms.Label();
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.lblOthersBD = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.lblOtherD = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.lblWBD = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.lblWD = new System.Windows.Forms.Label();
        this.Label11 = new System.Windows.Forms.Label();
        this.lblRBD = new System.Windows.Forms.Label();
        this.Label34 = new System.Windows.Forms.Label();
        this.lblRD = new System.Windows.Forms.Label();
        this.Label41 = new System.Windows.Forms.Label();
        this.lblProcOtherBytes = new System.Windows.Forms.Label();
        this.Label23 = new System.Windows.Forms.Label();
        this.lblProcOther = new System.Windows.Forms.Label();
        this.Label30 = new System.Windows.Forms.Label();
        this.lblProcWriteBytes = new System.Windows.Forms.Label();
        this.Label36 = new System.Windows.Forms.Label();
        this.lblProcWrites = new System.Windows.Forms.Label();
        this.Label38 = new System.Windows.Forms.Label();
        this.lblProcReadBytes = new System.Windows.Forms.Label();
        this.Label40 = new System.Windows.Forms.Label();
        this.lblProcReads = new System.Windows.Forms.Label();
        this.Label42 = new System.Windows.Forms.Label();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.lblQuotaNPP = new System.Windows.Forms.Label();
        this.Label21 = new System.Windows.Forms.Label();
        this.lblQuotaPNPP = new System.Windows.Forms.Label();
        this.Label26 = new System.Windows.Forms.Label();
        this.lblQuotaPP = new System.Windows.Forms.Label();
        this.Label29 = new System.Windows.Forms.Label();
        this.lblQuotaPPP = new System.Windows.Forms.Label();
        this.Label32 = new System.Windows.Forms.Label();
        this.lblPageFaults = new System.Windows.Forms.Label();
        this.Label31 = new System.Windows.Forms.Label();
        this.lblPeakPageFileUsage = new System.Windows.Forms.Label();
        this.Label33 = new System.Windows.Forms.Label();
        this.lblPageFileUsage = new System.Windows.Forms.Label();
        this.Label35 = new System.Windows.Forms.Label();
        this.lblPeakWorkingSet = new System.Windows.Forms.Label();
        this.Label25 = new System.Windows.Forms.Label();
        this.lblWorkingSet = new System.Windows.Forms.Label();
        this.Label27 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.lblAverageCPUusage = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblTotalTime = new System.Windows.Forms.Label();
        this.Label24 = new System.Windows.Forms.Label();
        this.lblUserTime = new System.Windows.Forms.Label();
        this.Label22 = new System.Windows.Forms.Label();
        this.lblKernelTime = new System.Windows.Forms.Label();
        this.Label20 = new System.Windows.Forms.Label();
        this.lblPriority = new System.Windows.Forms.Label();
        this.Label18 = new System.Windows.Forms.Label();
        this.TabPagePerf = new System.Windows.Forms.TabPage();
        this.splitPerformances = new System.Windows.Forms.SplitContainer();
        this.graphCPU = new Graph2();
        this.splitPerformance2 = new System.Windows.Forms.SplitContainer();
        this.graphMemory = new Graph2();
        this.graphIO = new Graph2();
        this.TabPageToken = new System.Windows.Forms.TabPage();
        this.tabProcessToken = new System.Windows.Forms.TabControl();
        this.tabProcessTokenPagePrivileges = new System.Windows.Forms.TabPage();
        this.lvPrivileges = new privilegeList();
        this.ColumnHeader50 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader51 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader52 = new System.Windows.Forms.ColumnHeader();
        this.TabPageMemory = new System.Windows.Forms.TabPage();
        this.lvProcMem = new memoryList();
        this.ColumnHeader53 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader54 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader55 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader56 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
        this.TabPageInfos = new System.Windows.Forms.TabPage();
        this.SplitContainerInfoProcess = new System.Windows.Forms.SplitContainer();
        this.cmdRefresh = new System.Windows.Forms.Button();
        this.cmdInfosToClipB = new System.Windows.Forms.Button();
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.TabPageServices = new System.Windows.Forms.TabPage();
        this.lvProcServices = new serviceList();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader10 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
        this.TabPageNetwork = new System.Windows.Forms.TabPage();
        this.lvProcNetwork = new networkList();
        this.ColumnHeader49 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader57 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader58 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader59 = new System.Windows.Forms.ColumnHeader();
        this.TabPageString = new System.Windows.Forms.TabPage();
        this.SplitContainerStrings = new System.Windows.Forms.SplitContainer();
        this.lvProcString = new DoubleBufferedLV();
        this.ColumnHeader76 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader77 = new System.Windows.Forms.ColumnHeader();
        this.cmdProcSearchR = new System.Windows.Forms.Button();
        this.cmdProcSearchL = new System.Windows.Forms.Button();
        this.pgbString = new System.Windows.Forms.ProgressBar();
        this.Label28 = new System.Windows.Forms.Label();
        this.txtSearchProcString = new System.Windows.Forms.TextBox();
        this.cmdProcStringSave = new System.Windows.Forms.Button();
        this.optProcStringMemory = new System.Windows.Forms.RadioButton();
        this.optProcStringImage = new System.Windows.Forms.RadioButton();
        this.TabPageEnv = new System.Windows.Forms.TabPage();
        this.lvProcEnv = new envVariableList();
        this.ColumnHeader60 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader61 = new System.Windows.Forms.ColumnHeader();
        this.TabPageModules = new System.Windows.Forms.TabPage();
        this.lvModules = new moduleList();
        this.ColumnHeader29 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader43 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader44 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader45 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader46 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.TabPageThreads = new System.Windows.Forms.TabPage();
        this.lvThreads = new threadList();
        this.ColumnHeader32 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader34 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader35 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader36 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader37 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader38 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
        this.TabPageWindows = new System.Windows.Forms.TabPage();
        this.lvWindows = new windowList();
        this.ColumnHeader30 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader39 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader40 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader41 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader42 = new System.Windows.Forms.ColumnHeader();
        this.TabPageHandles = new System.Windows.Forms.TabPage();
        this.lvHandles = new handleList();
        this.ColumnHeader24 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader25 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader26 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader27 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader28 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader15 = new System.Windows.Forms.ColumnHeader();
        this.TabPageLog = new System.Windows.Forms.TabPage();
        this.SplitContainerLog = new System.Windows.Forms.SplitContainer();
        this.cmdLogOptions = new System.Windows.Forms.Button();
        this.cmdSave = new System.Windows.Forms.Button();
        this.cmdClearLog = new System.Windows.Forms.Button();
        this.chkLog = new System.Windows.Forms.CheckBox();
        this.lvLog = new logList();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.TabPageHistory = new System.Windows.Forms.TabPage();
        this.containerHistory = new System.Windows.Forms.SplitContainer();
        this.Label2 = new System.Windows.Forms.Label();
        this.lstHistoryCat = new System.Windows.Forms.CheckedListBox();
        this.TabPageHeaps = new System.Windows.Forms.TabPage();
        this.cmdActivateHeapEnumeration = new System.Windows.Forms.Button();
        this.lvHeaps = new heapList();
        this.ColumnHeader16 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader17 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader18 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
        this.cmdHideFindPanel = new System.Windows.Forms.Button();
        this.chkFreeze = new System.Windows.Forms.CheckBox();
        this.lblSearchItemCaption = new System.Windows.Forms.Label();
        this.lblResCount = new System.Windows.Forms.Label();
        this.txtSearch = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.tabProcess.SuspendLayout();
        this.TabPageGeneral.SuspendLayout();
        this.GroupBox7.SuspendLayout();
        this.GroupBox6.SuspendLayout();
        this.SplitContainerOnlineInfo.Panel1.SuspendLayout();
        this.SplitContainerOnlineInfo.Panel2.SuspendLayout();
        this.SplitContainerOnlineInfo.SuspendLayout();
        this.GroupBoxProcessInfos.SuspendLayout();
        this.gpProcGeneralFile.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctSmallIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pctBigIcon).BeginInit();
        this.TabPageStats.SuspendLayout();
        this.GroupBox5.SuspendLayout();
        this.GroupBox4.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.TabPagePerf.SuspendLayout();
        this.splitPerformances.Panel1.SuspendLayout();
        this.splitPerformances.Panel2.SuspendLayout();
        this.splitPerformances.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.graphCPU).BeginInit();
        this.splitPerformance2.Panel1.SuspendLayout();
        this.splitPerformance2.Panel2.SuspendLayout();
        this.splitPerformance2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.graphMemory).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.graphIO).BeginInit();
        this.TabPageToken.SuspendLayout();
        this.tabProcessToken.SuspendLayout();
        this.tabProcessTokenPagePrivileges.SuspendLayout();
        this.TabPageMemory.SuspendLayout();
        this.TabPageInfos.SuspendLayout();
        this.SplitContainerInfoProcess.Panel1.SuspendLayout();
        this.SplitContainerInfoProcess.Panel2.SuspendLayout();
        this.SplitContainerInfoProcess.SuspendLayout();
        this.TabPageServices.SuspendLayout();
        this.TabPageNetwork.SuspendLayout();
        this.TabPageString.SuspendLayout();
        this.SplitContainerStrings.Panel1.SuspendLayout();
        this.SplitContainerStrings.Panel2.SuspendLayout();
        this.SplitContainerStrings.SuspendLayout();
        this.TabPageEnv.SuspendLayout();
        this.TabPageModules.SuspendLayout();
        this.TabPageThreads.SuspendLayout();
        this.TabPageWindows.SuspendLayout();
        this.TabPageHandles.SuspendLayout();
        this.TabPageLog.SuspendLayout();
        this.SplitContainerLog.Panel1.SuspendLayout();
        this.SplitContainerLog.Panel2.SuspendLayout();
        this.SplitContainerLog.SuspendLayout();
        this.TabPageHistory.SuspendLayout();
        this.containerHistory.Panel1.SuspendLayout();
        this.containerHistory.SuspendLayout();
        this.TabPageHeaps.SuspendLayout();
        this.SuspendLayout();
        // 
        // timerProcPerf
        // 
        this.timerProcPerf.Enabled = true;
        this.timerProcPerf.Interval = 1000;
        // 
        // timerLog
        // 
        this.timerLog.Interval = 1000;
        // 
        // mainMenu
        // 
        this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem3 });
        // 
        // MenuItem3
        // 
        this.MenuItem3.Index = 0;
        this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemRefresh });
        this.MenuItem3.Text = "main";
        this.MenuItem3.Visible = false;
        // 
        // MenuItemRefresh
        // 
        this.MenuItemRefresh.DefaultItem = true;
        this.MenuItemRefresh.Index = 0;
        this.MenuItemRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
        this.MenuItemRefresh.Text = "Refresh";
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
        // MenuItemPriEnable
        // 
        this.VistaMenu.SetImage(this.MenuItemPriEnable, global::My.Resources.Resources.ok16);
        this.MenuItemPriEnable.Index = 0;
        this.MenuItemPriEnable.Text = "Enable";
        // 
        // MenuItemViewMemory
        // 
        this.MenuItemViewMemory.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemViewMemory, global::My.Resources.Resources.magnifier);
        this.MenuItemViewMemory.Index = 0;
        this.MenuItemViewMemory.Text = "View memory";
        // 
        // MenuItemCloseHandle
        // 
        this.VistaMenu.SetImage(this.MenuItemCloseHandle, global::My.Resources.Resources.close);
        this.MenuItemCloseHandle.Index = 1;
        this.MenuItemCloseHandle.Text = "Close item";
        // 
        // menuCloseTCP
        // 
        this.menuCloseTCP.DefaultItem = true;
        this.VistaMenu.SetImage(this.menuCloseTCP, global::My.Resources.Resources.cross16);
        this.menuCloseTCP.Index = 0;
        this.menuCloseTCP.Text = "Close TCP connection";
        // 
        // MenuItemPriDisable
        // 
        this.VistaMenu.SetImage(this.MenuItemPriDisable, global::My.Resources.Resources.close);
        this.MenuItemPriDisable.Index = 1;
        this.MenuItemPriDisable.Text = "Disable";
        // 
        // MenuItemPriRemove
        // 
        this.VistaMenu.SetImage(this.MenuItemPriRemove, global::My.Resources.Resources.cross16);
        this.MenuItemPriRemove.Index = 2;
        this.MenuItemPriRemove.Text = "Remove";
        // 
        // MenuItemModuleFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemModuleFileProp, global::My.Resources.Resources.document_text);
        this.MenuItemModuleFileProp.Index = 0;
        this.MenuItemModuleFileProp.Text = "File properties";
        // 
        // MenuItemModuleOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemModuleOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemModuleOpenDir.Index = 1;
        this.MenuItemModuleOpenDir.Text = "Open directory";
        // 
        // MenuItemModuleFileDetails
        // 
        this.VistaMenu.SetImage(this.MenuItemModuleFileDetails, global::My.Resources.Resources.magnifier);
        this.MenuItemModuleFileDetails.Index = 2;
        this.MenuItemModuleFileDetails.Text = "File details";
        // 
        // MenuItemModuleSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemModuleSearch, global::My.Resources.Resources.globe);
        this.MenuItemModuleSearch.Index = 3;
        this.MenuItemModuleSearch.Text = "Internet search";
        // 
        // MenuItemModuleDependencies
        // 
        this.VistaMenu.SetImage(this.MenuItemModuleDependencies, global::My.Resources.Resources.dllIcon16);
        this.MenuItemModuleDependencies.Index = 4;
        this.MenuItemModuleDependencies.Text = "View dependencies...";
        // 
        // MenuItemUnloadModule
        // 
        this.MenuItemUnloadModule.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemUnloadModule, global::My.Resources.Resources.cross16);
        this.MenuItemUnloadModule.Index = 7;
        this.MenuItemUnloadModule.Text = "Unload module";
        // 
        // MenuItemViewModuleMemory
        // 
        this.VistaMenu.SetImage(this.MenuItemViewModuleMemory, global::My.Resources.Resources.magnifier);
        this.MenuItemViewModuleMemory.Index = 5;
        this.MenuItemViewModuleMemory.Text = "View memory";
        // 
        // MenuItemServSelService
        // 
        this.VistaMenu.SetImage(this.MenuItemServSelService, global::My.Resources.Resources.exe16);
        this.MenuItemServSelService.Index = 1;
        this.MenuItemServSelService.Text = "Select service";
        // 
        // MenuItemServFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemServFileProp, global::My.Resources.Resources.document_text);
        this.MenuItemServFileProp.Index = 3;
        this.MenuItemServFileProp.Text = "File properties";
        // 
        // MenuItemServOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemServOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemServOpenDir.Index = 4;
        this.MenuItemServOpenDir.Text = "Open directory";
        // 
        // MenuItemServFileDetails
        // 
        this.VistaMenu.SetImage(this.MenuItemServFileDetails, global::My.Resources.Resources.magnifier);
        this.MenuItemServFileDetails.Index = 5;
        this.MenuItemServFileDetails.Text = "File details";
        // 
        // MenuItemServSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemServSearch, global::My.Resources.Resources.globe);
        this.MenuItemServSearch.Index = 6;
        this.MenuItemServSearch.Text = "Internet search";
        // 
        // MenuItemServPause
        // 
        this.VistaMenu.SetImage(this.MenuItemServPause, global::My.Resources.Resources.control_pause);
        this.MenuItemServPause.Index = 9;
        this.MenuItemServPause.Text = "Pause";
        // 
        // MenuItemServStop
        // 
        this.VistaMenu.SetImage(this.MenuItemServStop, global::My.Resources.Resources.control_stop_square);
        this.MenuItemServStop.Index = 10;
        this.MenuItemServStop.Text = "Stop";
        // 
        // MenuItemServStart
        // 
        this.VistaMenu.SetImage(this.MenuItemServStart, global::My.Resources.Resources.control);
        this.MenuItemServStart.Index = 11;
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
        // MenuItemThTerm
        // 
        this.MenuItemThTerm.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemThTerm, global::My.Resources.Resources.cross16);
        this.MenuItemThTerm.Index = 0;
        this.MenuItemThTerm.Text = "Terminate";
        // 
        // MenuItemThSuspend
        // 
        this.VistaMenu.SetImage(this.MenuItemThSuspend, global::My.Resources.Resources.control_pause);
        this.MenuItemThSuspend.Index = 1;
        this.MenuItemThSuspend.Text = "Suspend";
        // 
        // MenuItemThResu
        // 
        this.VistaMenu.SetImage(this.MenuItemThResu, global::My.Resources.Resources.control);
        this.MenuItemThResu.Index = 2;
        this.MenuItemThResu.Text = "Resume";
        // 
        // MenuItemThIdle
        // 
        this.VistaMenu.SetImage(this.MenuItemThIdle, global::My.Resources.Resources.p0);
        this.MenuItemThIdle.Index = 0;
        this.MenuItemThIdle.Text = "Idle";
        // 
        // MenuItemThLowest
        // 
        this.VistaMenu.SetImage(this.MenuItemThLowest, global::My.Resources.Resources.p1);
        this.MenuItemThLowest.Index = 1;
        this.MenuItemThLowest.Text = "Lowest";
        // 
        // MenuItemThBNormal
        // 
        this.VistaMenu.SetImage(this.MenuItemThBNormal, global::My.Resources.Resources.p2);
        this.MenuItemThBNormal.Index = 2;
        this.MenuItemThBNormal.Text = "Below normal";
        // 
        // MenuItemThNorm
        // 
        this.VistaMenu.SetImage(this.MenuItemThNorm, global::My.Resources.Resources.p3);
        this.MenuItemThNorm.Index = 3;
        this.MenuItemThNorm.Text = "Normal";
        // 
        // MenuItemThANorm
        // 
        this.VistaMenu.SetImage(this.MenuItemThANorm, global::My.Resources.Resources.p4);
        this.MenuItemThANorm.Index = 4;
        this.MenuItemThANorm.Text = "Above normal";
        // 
        // MenuItemThHighest
        // 
        this.VistaMenu.SetImage(this.MenuItemThHighest, global::My.Resources.Resources.p5);
        this.MenuItemThHighest.Index = 5;
        this.MenuItemThHighest.Text = "Highest";
        // 
        // MenuItemThTimeCr
        // 
        this.VistaMenu.SetImage(this.MenuItemThTimeCr, global::My.Resources.Resources.p6);
        this.MenuItemThTimeCr.Index = 6;
        this.MenuItemThTimeCr.Text = "Time critical";
        // 
        // MenuItemWShow
        // 
        this.MenuItemWShow.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemWShow, global::My.Resources.Resources.monitor16);
        this.MenuItemWShow.Index = 0;
        this.MenuItemWShow.Text = "Show";
        // 
        // MenuItemWClose
        // 
        this.VistaMenu.SetImage(this.MenuItemWClose, global::My.Resources.Resources.cross16);
        this.MenuItemWClose.Index = 3;
        this.MenuItemWClose.Text = "Close";
        // 
        // MenuItemWDisa
        // 
        this.MenuItemWDisa.Index = 8;
        this.MenuItemWDisa.Text = "Disable";
        // 
        // MenuItemLogGoto
        // 
        this.VistaMenu.SetImage(this.MenuItemLogGoto, global::My.Resources.Resources.right16);
        this.MenuItemLogGoto.Index = 0;
        this.MenuItemLogGoto.Text = "Go to item";
        // 
        // menuViewMemory
        // 
        this.menuViewMemory.DefaultItem = true;
        this.VistaMenu.SetImage(this.menuViewMemory, global::My.Resources.Resources.magnifier);
        this.menuViewMemory.Index = 0;
        this.menuViewMemory.Text = "View memory";
        // 
        // MenuItemCopyPrivilege
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyPrivilege, global::My.Resources.Resources.copy16);
        this.MenuItemCopyPrivilege.Index = 4;
        this.MenuItemCopyPrivilege.Text = "Copy to clipboard";
        // 
        // MenuItemCopyMemory
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyMemory, global::My.Resources.Resources.copy16);
        this.MenuItemCopyMemory.Index = 8;
        this.MenuItemCopyMemory.Text = "Copy to clipboard";
        // 
        // MenuItemCopyModule
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyModule, global::My.Resources.Resources.copy16);
        this.MenuItemCopyModule.Index = 9;
        this.MenuItemCopyModule.Text = "Copy to clipboard";
        // 
        // MenuItemCopyThread
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyThread, global::My.Resources.Resources.copy16);
        this.MenuItemCopyThread.Index = 6;
        this.MenuItemCopyThread.Text = "Copy to clipboard";
        // 
        // MenuItemCopyWindow
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyWindow, global::My.Resources.Resources.copy16);
        this.MenuItemCopyWindow.Index = 10;
        this.MenuItemCopyWindow.Text = "Copy to clipboard";
        // 
        // MenuItemCopyHandle
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyHandle, global::My.Resources.Resources.copy16);
        this.MenuItemCopyHandle.Index = 5;
        this.MenuItemCopyHandle.Text = "Copy to clipboard";
        // 
        // MenuItemCopyNetwork
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyNetwork, global::My.Resources.Resources.copy16);
        this.MenuItemCopyNetwork.Index = 3;
        this.MenuItemCopyNetwork.Text = "Copy to clipboard";
        // 
        // MenuItemCopyService
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyService, global::My.Resources.Resources.copy16);
        this.MenuItemCopyService.Index = 17;
        this.MenuItemCopyService.Text = "Copy to clipboard";
        // 
        // MenuItemCopyLog
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyLog, global::My.Resources.Resources.copy16);
        this.MenuItemCopyLog.Index = 2;
        this.MenuItemCopyLog.Text = "Copy to clipboard";
        // 
        // MenuItemCopyEnvVariable
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyEnvVariable, global::My.Resources.Resources.copy16);
        this.MenuItemCopyEnvVariable.Index = 0;
        this.MenuItemCopyEnvVariable.Text = "Copy to clipboard";
        // 
        // menuCopyPctbig
        // 
        this.menuCopyPctbig.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyBig });
        // 
        // menuCopyPctSmall
        // 
        this.menuCopyPctSmall.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopySmall });
        // 
        // mnuString
        // 
        this.mnuString.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuViewMemory, this.MenuItem2, this.MenuItemCopyString });
        // 
        // MenuItem2
        // 
        this.MenuItem2.Index = 1;
        this.MenuItem2.Text = "-";
        // 
        // MenuItemCopyString
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyString, global::My.Resources.Resources.copy16);
        this.MenuItemCopyString.Index = 2;
        this.MenuItemCopyString.Text = "Copy to clipboard";
        // 
        // mnuPrivileges
        // 
        this.mnuPrivileges.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemPriEnable, this.MenuItemPriDisable, this.MenuItemPriRemove, this.MenuItem1, this.MenuItemCopyPrivilege });
        // 
        // MenuItem1
        // 
        this.MenuItem1.Index = 3;
        this.MenuItem1.Text = "-";
        // 
        // mnuProcMem
        // 
        this.mnuProcMem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemViewMemory, this.MenuItemMemoryDump, this.MenuItemPEBAddress, this.MenuItem13, this.MenuItemMemoryRelease, this.MenuItemMemoryDecommit, this.MenuItemMemoryChangeProtection, this.MenuItem22, this.MenuItemCopyMemory, this.MenuItemColumnsMemory });
        // 
        // MenuItemMemoryDump
        // 
        this.VistaMenu.SetImage(this.MenuItemMemoryDump, global::My.Resources.Resources.save16);
        this.MenuItemMemoryDump.Index = 1;
        this.MenuItemMemoryDump.Text = "Dump...";
        // 
        // MenuItemPEBAddress
        // 
        this.MenuItemPEBAddress.Index = 2;
        this.MenuItemPEBAddress.Text = "Jump to PEB address";
        // 
        // MenuItem13
        // 
        this.MenuItem13.Index = 3;
        this.MenuItem13.Text = "-";
        // 
        // MenuItemMemoryRelease
        // 
        this.VistaMenu.SetImage(this.MenuItemMemoryRelease, global::My.Resources.Resources.cross16);
        this.MenuItemMemoryRelease.Index = 4;
        this.MenuItemMemoryRelease.Text = "Release";
        // 
        // MenuItemMemoryDecommit
        // 
        this.VistaMenu.SetImage(this.MenuItemMemoryDecommit, global::My.Resources.Resources.close);
        this.MenuItemMemoryDecommit.Index = 5;
        this.MenuItemMemoryDecommit.Text = "Decommit";
        // 
        // MenuItemMemoryChangeProtection
        // 
        this.VistaMenu.SetImage(this.MenuItemMemoryChangeProtection, global::My.Resources.Resources.locked);
        this.MenuItemMemoryChangeProtection.Index = 6;
        this.MenuItemMemoryChangeProtection.Text = "Change protection...";
        // 
        // MenuItem22
        // 
        this.MenuItem22.Index = 7;
        this.MenuItem22.Text = "-";
        // 
        // MenuItemColumnsMemory
        // 
        this.MenuItemColumnsMemory.Index = 9;
        this.MenuItemColumnsMemory.Text = "Choose columns...";
        // 
        // mnuModule
        // 
        this.mnuModule.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemModuleFileProp, this.MenuItemModuleOpenDir, this.MenuItemModuleFileDetails, this.MenuItemModuleSearch, this.MenuItemModuleDependencies, this.MenuItemViewModuleMemory, this.MenuItem16, this.MenuItemUnloadModule, this.MenuItem19, this.MenuItemCopyModule, this.MenuItemColumnsModule });
        // 
        // MenuItem16
        // 
        this.MenuItem16.Index = 6;
        this.MenuItem16.Text = "-";
        // 
        // MenuItem19
        // 
        this.MenuItem19.Index = 8;
        this.MenuItem19.Text = "-";
        // 
        // MenuItemColumnsModule
        // 
        this.MenuItemColumnsModule.Index = 10;
        this.MenuItemColumnsModule.Text = "Choose columns...";
        // 
        // mnuThread
        // 
        this.mnuThread.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemThTerm, this.MenuItemThSuspend, this.MenuItemThResu, this.MenuItem8, this.MenuItemThAffinity, this.MenuItem15, this.MenuItemCopyThread, this.MenuItemThColumns });
        // 
        // MenuItem8
        // 
        this.MenuItem8.Index = 3;
        this.MenuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemThIdle, this.MenuItemThLowest, this.MenuItemThBNormal, this.MenuItemThNorm, this.MenuItemThANorm, this.MenuItemThHighest, this.MenuItemThTimeCr });
        this.MenuItem8.Text = "Priority";
        // 
        // MenuItemThAffinity
        // 
        this.MenuItemThAffinity.Index = 4;
        this.MenuItemThAffinity.Text = "Set affinity...";
        // 
        // MenuItem15
        // 
        this.MenuItem15.Index = 5;
        this.MenuItem15.Text = "-";
        // 
        // MenuItemThColumns
        // 
        this.MenuItemThColumns.Index = 7;
        this.MenuItemThColumns.Text = "Choose columns...";
        // 
        // mnuWindow
        // 
        this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemWShow, this.MenuItemWShowUn, this.MenuItemWHide, this.MenuItemWClose, this.MenuItem9, this.MenuItemWVisiblity, this.MenuItem30, this.MenuItemWEna, this.MenuItemWDisa, this.MenuItem33, this.MenuItemCopyWindow, this.MenuItemWColumns });
        // 
        // MenuItemWShowUn
        // 
        this.MenuItemWShowUn.Index = 1;
        this.MenuItemWShowUn.Text = "Show unnamed";
        // 
        // MenuItemWHide
        // 
        this.MenuItemWHide.Index = 2;
        this.MenuItemWHide.Text = "Hide";
        // 
        // MenuItem9
        // 
        this.MenuItem9.Index = 4;
        this.MenuItem9.Text = "-";
        // 
        // MenuItemWVisiblity
        // 
        this.MenuItemWVisiblity.Index = 5;
        this.MenuItemWVisiblity.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemWFront, this.MenuItemWNotFront, this.MenuItemWActive, this.MenuItemWForeground, this.MenuItem26, this.MenuItemWMin, this.MenuItemWMax, this.MenuItemWPosSize, this.MenuItem4, this.MenuItemWFlash, this.MenuItemWStopFlash, this.MenuItem21, this.MenuItemWOpacity, this.MenuItemWCaption });
        this.MenuItemWVisiblity.Text = "Visibility";
        // 
        // MenuItemWFront
        // 
        this.MenuItemWFront.Index = 0;
        this.MenuItemWFront.Text = "Bring to front";
        // 
        // MenuItemWNotFront
        // 
        this.MenuItemWNotFront.Index = 1;
        this.MenuItemWNotFront.Text = "Do not bring to front";
        // 
        // MenuItemWActive
        // 
        this.MenuItemWActive.Index = 2;
        this.MenuItemWActive.Text = "Set as active window";
        // 
        // MenuItemWForeground
        // 
        this.MenuItemWForeground.Index = 3;
        this.MenuItemWForeground.Text = "Set as foreground window";
        // 
        // MenuItem26
        // 
        this.MenuItem26.Index = 4;
        this.MenuItem26.Text = "-";
        // 
        // MenuItemWMin
        // 
        this.MenuItemWMin.Index = 5;
        this.MenuItemWMin.Text = "Minimize";
        // 
        // MenuItemWMax
        // 
        this.MenuItemWMax.Index = 6;
        this.MenuItemWMax.Text = "Maximize";
        // 
        // MenuItemWPosSize
        // 
        this.MenuItemWPosSize.Index = 7;
        this.MenuItemWPosSize.Text = "Position && size";
        // 
        // MenuItem4
        // 
        this.MenuItem4.Index = 8;
        this.MenuItem4.Text = "-";
        // 
        // MenuItemWFlash
        // 
        this.MenuItemWFlash.Index = 9;
        this.MenuItemWFlash.Text = "Flash";
        // 
        // MenuItemWStopFlash
        // 
        this.MenuItemWStopFlash.Index = 10;
        this.MenuItemWStopFlash.Text = "Stop flashing";
        // 
        // MenuItem21
        // 
        this.MenuItem21.Index = 11;
        this.MenuItem21.Text = "-";
        // 
        // MenuItemWOpacity
        // 
        this.MenuItemWOpacity.Index = 12;
        this.MenuItemWOpacity.Text = "Change opacity...";
        // 
        // MenuItemWCaption
        // 
        this.MenuItemWCaption.Index = 13;
        this.MenuItemWCaption.Text = "Change caption...";
        // 
        // MenuItem30
        // 
        this.MenuItem30.Index = 6;
        this.MenuItem30.Text = "-";
        // 
        // MenuItemWEna
        // 
        this.MenuItemWEna.Index = 7;
        this.MenuItemWEna.Text = "Enable";
        // 
        // MenuItem33
        // 
        this.MenuItem33.Index = 9;
        this.MenuItem33.Text = "-";
        // 
        // MenuItemWColumns
        // 
        this.MenuItemWColumns.Index = 11;
        this.MenuItemWColumns.Text = "Choose columns...";
        // 
        // mnuHandle
        // 
        this.mnuHandle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemHandleDetails, this.MenuItemCloseHandle, this.MenuItem12, this.MenuItemShowUnnamedHandles, this.MenuItem14, this.MenuItemCopyHandle, this.MenuItemChooseColumnsHandle });
        // 
        // MenuItemHandleDetails
        // 
        this.MenuItemHandleDetails.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemHandleDetails, global::My.Resources.Resources.monitor16);
        this.MenuItemHandleDetails.Index = 0;
        this.MenuItemHandleDetails.Text = "Details...";
        // 
        // MenuItem12
        // 
        this.MenuItem12.Index = 2;
        this.MenuItem12.Text = "-";
        // 
        // MenuItemShowUnnamedHandles
        // 
        this.MenuItemShowUnnamedHandles.Index = 3;
        this.MenuItemShowUnnamedHandles.Text = "Show unnamed handles";
        // 
        // MenuItem14
        // 
        this.MenuItem14.Index = 4;
        this.MenuItem14.Text = "-";
        // 
        // MenuItemChooseColumnsHandle
        // 
        this.MenuItemChooseColumnsHandle.Index = 6;
        this.MenuItemChooseColumnsHandle.Text = "Choose columns...";
        // 
        // mnuNetwork
        // 
        this.mnuNetwork.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuCloseTCP, this.MenuItemNetworkTools, this.MenuItem10, this.MenuItemCopyNetwork, this.MenuItemColumnsNetwork });
        // 
        // MenuItemNetworkTools
        // 
        this.MenuItemNetworkTools.Index = 1;
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
        this.MenuItem10.Index = 2;
        this.MenuItem10.Text = "-";
        // 
        // MenuItemColumnsNetwork
        // 
        this.MenuItemColumnsNetwork.Index = 4;
        this.MenuItemColumnsNetwork.Text = "Choose columns...";
        // 
        // mnuService
        // 
        this.mnuService.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemServDetails, this.MenuItemServSelService, this.MenuItem5, this.MenuItemServFileProp, this.MenuItemServOpenDir, this.MenuItemServFileDetails, this.MenuItemServSearch, this.MenuItemServDepe, this.MenuItem20, this.MenuItemServPause, this.MenuItemServStop, this.MenuItemServStart, this.MenuItem17, this.MenuItemServDelete, this.MenuItem25, this.MenuItemServReanalize, this.MenuItem24, this.MenuItemCopyService, this.MenuItemServColumns });
        // 
        // MenuItemServDetails
        // 
        this.MenuItemServDetails.DefaultItem = true;
        this.MenuItemServDetails.Index = 0;
        this.MenuItemServDetails.Text = "Service details";
        // 
        // MenuItem5
        // 
        this.MenuItem5.Index = 2;
        this.MenuItem5.Text = "-";
        // 
        // MenuItemServDepe
        // 
        this.VistaMenu.SetImage(this.MenuItemServDepe, global::My.Resources.Resources.dllIcon16);
        this.MenuItemServDepe.Index = 7;
        this.MenuItemServDepe.Text = "View dependencies...";
        // 
        // MenuItem20
        // 
        this.MenuItem20.Index = 8;
        this.MenuItem20.Text = "-";
        // 
        // MenuItem17
        // 
        this.MenuItem17.Index = 12;
        this.MenuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemServAutoStart, this.MenuItemServOnDemand, this.MenuItemServDisabled });
        this.MenuItem17.Text = "Start type";
        // 
        // MenuItemServDelete
        // 
        this.VistaMenu.SetImage(this.MenuItemServDelete, global::My.Resources.Resources.cross16);
        this.MenuItemServDelete.Index = 13;
        this.MenuItemServDelete.Text = "Delete";
        // 
        // MenuItem25
        // 
        this.MenuItem25.Index = 14;
        this.MenuItem25.Text = "-";
        // 
        // MenuItemServReanalize
        // 
        this.MenuItemServReanalize.Index = 15;
        this.MenuItemServReanalize.Text = "Reanalize";
        // 
        // MenuItem24
        // 
        this.MenuItem24.Index = 16;
        this.MenuItem24.Text = "-";
        // 
        // MenuItemServColumns
        // 
        this.MenuItemServColumns.Index = 18;
        this.MenuItemServColumns.Text = "Choose columns...";
        // 
        // mnuLog
        // 
        this.mnuLog.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemLogGoto, this.MenuItem6, this.MenuItemCopyLog });
        // 
        // MenuItem6
        // 
        this.MenuItem6.Index = 1;
        this.MenuItem6.Text = "-";
        // 
        // mnuEnv
        // 
        this.mnuEnv.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyEnvVariable });
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItemCopyHeaps
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyHeaps, global::My.Resources.Resources.copy16);
        this.MenuItemCopyHeaps.Index = 0;
        this.MenuItemCopyHeaps.Text = "Copy to clipboard";
        // 
        // RadioButton1
        // 
        this.RadioButton1.Location = new System.Drawing.Point(0, 0);
        this.RadioButton1.Name = "RadioButton1";
        this.RadioButton1.Size = new System.Drawing.Size(104, 24);
        this.RadioButton1.TabIndex = 0;
        // 
        // mnuHeaps
        // 
        this.mnuHeaps.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyHeaps, this.MenuItem11, this.MenuItemColumnsHeap });
        // 
        // MenuItem11
        // 
        this.MenuItem11.Index = 1;
        this.MenuItem11.Text = "-";
        // 
        // MenuItemColumnsHeap
        // 
        this.MenuItemColumnsHeap.Index = 2;
        this.MenuItemColumnsHeap.Text = "Choose columns...";
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.SplitContainer.IsSplitterFixed = true;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.tabProcess);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.cmdHideFindPanel);
        this.SplitContainer.Panel2.Controls.Add(this.chkFreeze);
        this.SplitContainer.Panel2.Controls.Add(this.lblSearchItemCaption);
        this.SplitContainer.Panel2.Controls.Add(this.lblResCount);
        this.SplitContainer.Panel2.Controls.Add(this.txtSearch);
        this.SplitContainer.Size = new System.Drawing.Size(655, 356);
        this.SplitContainer.SplitterDistance = 326;
        this.SplitContainer.TabIndex = 1;
        // 
        // tabProcess
        // 
        this.tabProcess.Controls.Add(this.TabPageGeneral);
        this.tabProcess.Controls.Add(this.TabPageStats);
        this.tabProcess.Controls.Add(this.TabPagePerf);
        this.tabProcess.Controls.Add(this.TabPageToken);
        this.tabProcess.Controls.Add(this.TabPageMemory);
        this.tabProcess.Controls.Add(this.TabPageInfos);
        this.tabProcess.Controls.Add(this.TabPageServices);
        this.tabProcess.Controls.Add(this.TabPageNetwork);
        this.tabProcess.Controls.Add(this.TabPageString);
        this.tabProcess.Controls.Add(this.TabPageEnv);
        this.tabProcess.Controls.Add(this.TabPageModules);
        this.tabProcess.Controls.Add(this.TabPageThreads);
        this.tabProcess.Controls.Add(this.TabPageWindows);
        this.tabProcess.Controls.Add(this.TabPageHandles);
        this.tabProcess.Controls.Add(this.TabPageLog);
        this.tabProcess.Controls.Add(this.TabPageHistory);
        this.tabProcess.Controls.Add(this.TabPageHeaps);
        this.tabProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tabProcess.Location = new System.Drawing.Point(0, 0);
        this.tabProcess.Multiline = true;
        this.tabProcess.Name = "tabProcess";
        this.tabProcess.SelectedIndex = 0;
        this.tabProcess.Size = new System.Drawing.Size(655, 326);
        this.tabProcess.TabIndex = 0;
        // 
        // TabPageGeneral
        // 
        this.TabPageGeneral.Controls.Add(this.GroupBox7);
        this.TabPageGeneral.Controls.Add(this.GroupBox6);
        this.TabPageGeneral.Controls.Add(this.GroupBoxProcessInfos);
        this.TabPageGeneral.Controls.Add(this.gpProcGeneralFile);
        this.TabPageGeneral.Location = new System.Drawing.Point(4, 40);
        this.TabPageGeneral.Name = "TabPageGeneral";
        this.TabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageGeneral.Size = new System.Drawing.Size(647, 282);
        this.TabPageGeneral.TabIndex = 0;
        this.TabPageGeneral.Text = "General";
        this.TabPageGeneral.UseVisualStyleBackColor = true;
        // 
        // GroupBox7
        // 
        this.GroupBox7.Controls.Add(this.cmdSet);
        this.GroupBox7.Controls.Add(this.cbPriority);
        this.GroupBox7.Controls.Add(this.cmdAffinity);
        this.GroupBox7.Controls.Add(this.cmdPause);
        this.GroupBox7.Controls.Add(this.cmdResume);
        this.GroupBox7.Controls.Add(this.cmdKill);
        this.GroupBox7.Location = new System.Drawing.Point(391, 179);
        this.GroupBox7.Name = "GroupBox7";
        this.GroupBox7.Size = new System.Drawing.Size(242, 92);
        this.GroupBox7.TabIndex = 18;
        this.GroupBox7.TabStop = false;
        this.GroupBox7.Text = "Actions";
        // 
        // cmdSet
        // 
        this.cmdSet.Location = new System.Drawing.Point(202, 50);
        this.cmdSet.Name = "cmdSet";
        this.cmdSet.Size = new System.Drawing.Size(31, 23);
        this.cmdSet.TabIndex = 5;
        this.cmdSet.Text = "Set";
        this.cmdSet.UseVisualStyleBackColor = true;
        // 
        // cbPriority
        // 
        this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbPriority.FormattingEnabled = true;
        this.cbPriority.Items.AddRange(new object[] { "Idle", "BelowNormal", "Normal", "AboveNormal", "High", "RealTime" });
        this.cbPriority.Location = new System.Drawing.Point(91, 51);
        this.cbPriority.Name = "cbPriority";
        this.cbPriority.Size = new System.Drawing.Size(105, 21);
        this.cbPriority.TabIndex = 4;
        // 
        // cmdAffinity
        // 
        this.cmdAffinity.Image = global::My.Resources.Resources.gear;
        this.cmdAffinity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdAffinity.Location = new System.Drawing.Point(10, 50);
        this.cmdAffinity.Name = "cmdAffinity";
        this.cmdAffinity.Size = new System.Drawing.Size(75, 23);
        this.cmdAffinity.TabIndex = 3;
        this.cmdAffinity.Text = "Affinity ";
        this.cmdAffinity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdAffinity.UseVisualStyleBackColor = true;
        // 
        // cmdPause
        // 
        this.cmdPause.Image = global::My.Resources.Resources.control_pause;
        this.cmdPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdPause.Location = new System.Drawing.Point(76, 21);
        this.cmdPause.Name = "cmdPause";
        this.cmdPause.Size = new System.Drawing.Size(75, 23);
        this.cmdPause.TabIndex = 2;
        this.cmdPause.Text = "Pause   ";
        this.cmdPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdPause.UseVisualStyleBackColor = true;
        // 
        // cmdResume
        // 
        this.cmdResume.Image = global::My.Resources.Resources.control;
        this.cmdResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdResume.Location = new System.Drawing.Point(158, 21);
        this.cmdResume.Name = "cmdResume";
        this.cmdResume.Size = new System.Drawing.Size(75, 23);
        this.cmdResume.TabIndex = 1;
        this.cmdResume.Text = "Resume ";
        this.cmdResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdResume.UseVisualStyleBackColor = true;
        // 
        // cmdKill
        // 
        this.cmdKill.Image = global::My.Resources.Resources.cross16;
        this.cmdKill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdKill.Location = new System.Drawing.Point(10, 21);
        this.cmdKill.Name = "cmdKill";
        this.cmdKill.Size = new System.Drawing.Size(60, 23);
        this.cmdKill.TabIndex = 0;
        this.cmdKill.Text = "Kill   ";
        this.cmdKill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdKill.UseVisualStyleBackColor = true;
        // 
        // GroupBox6
        // 
        this.GroupBox6.Controls.Add(this.SplitContainerOnlineInfo);
        this.GroupBox6.Location = new System.Drawing.Point(391, 6);
        this.GroupBox6.Name = "GroupBox6";
        this.GroupBox6.Size = new System.Drawing.Size(242, 167);
        this.GroupBox6.TabIndex = 17;
        this.GroupBox6.TabStop = false;
        this.GroupBox6.Text = "Online informations";
        // 
        // SplitContainerOnlineInfo
        // 
        this.SplitContainerOnlineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerOnlineInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerOnlineInfo.IsSplitterFixed = true;
        this.SplitContainerOnlineInfo.Location = new System.Drawing.Point(3, 18);
        this.SplitContainerOnlineInfo.Name = "SplitContainerOnlineInfo";
        this.SplitContainerOnlineInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerOnlineInfo.Panel1
        // 
        this.SplitContainerOnlineInfo.Panel1.Controls.Add(this.lblSecurityRisk);
        this.SplitContainerOnlineInfo.Panel1.Controls.Add(this.cmdGetOnlineInfos);
        // 
        // SplitContainerOnlineInfo.Panel2
        // 
        this.SplitContainerOnlineInfo.Panel2.Controls.Add(this.rtbOnlineInfos);
        this.SplitContainerOnlineInfo.Size = new System.Drawing.Size(236, 146);
        this.SplitContainerOnlineInfo.SplitterDistance = 25;
        this.SplitContainerOnlineInfo.TabIndex = 16;
        // 
        // lblSecurityRisk
        // 
        this.lblSecurityRisk.AutoSize = true;
        this.lblSecurityRisk.Location = new System.Drawing.Point(124, 6);
        this.lblSecurityRisk.Name = "lblSecurityRisk";
        this.lblSecurityRisk.Size = new System.Drawing.Size(74, 13);
        this.lblSecurityRisk.TabIndex = 2;
        this.lblSecurityRisk.Text = "Not yet rated";
        // 
        // cmdGetOnlineInfos
        // 
        this.cmdGetOnlineInfos.Location = new System.Drawing.Point(10, 1);
        this.cmdGetOnlineInfos.Name = "cmdGetOnlineInfos";
        this.cmdGetOnlineInfos.Size = new System.Drawing.Size(108, 23);
        this.cmdGetOnlineInfos.TabIndex = 11;
        this.cmdGetOnlineInfos.Text = "Get online infos";
        this.cmdGetOnlineInfos.UseVisualStyleBackColor = true;
        // 
        // rtbOnlineInfos
        // 
        this.rtbOnlineInfos.AutoWordSelection = true;
        this.rtbOnlineInfos.BackColor = System.Drawing.Color.White;
        this.rtbOnlineInfos.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtbOnlineInfos.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtbOnlineInfos.HideSelection = false;
        this.rtbOnlineInfos.Location = new System.Drawing.Point(0, 0);
        this.rtbOnlineInfos.Name = "rtbOnlineInfos";
        this.rtbOnlineInfos.ReadOnly = true;
        this.rtbOnlineInfos.Size = new System.Drawing.Size(236, 117);
        this.rtbOnlineInfos.TabIndex = 12;
        this.rtbOnlineInfos.Text = "";
        // 
        // GroupBoxProcessInfos
        // 
        this.GroupBoxProcessInfos.Controls.Add(this.cmdGoProcess);
        this.GroupBoxProcessInfos.Controls.Add(this.txtRunTime);
        this.GroupBoxProcessInfos.Controls.Add(this.txtProcessStarted);
        this.GroupBoxProcessInfos.Controls.Add(this.Label14);
        this.GroupBoxProcessInfos.Controls.Add(this.txtParentProcess);
        this.GroupBoxProcessInfos.Controls.Add(this.Label15);
        this.GroupBoxProcessInfos.Controls.Add(this.txtPriority);
        this.GroupBoxProcessInfos.Controls.Add(this.Label4);
        this.GroupBoxProcessInfos.Controls.Add(this.txtCommandLine);
        this.GroupBoxProcessInfos.Controls.Add(this.Label1);
        this.GroupBoxProcessInfos.Controls.Add(this.txtProcessUser);
        this.GroupBoxProcessInfos.Controls.Add(this.Label17);
        this.GroupBoxProcessInfos.Controls.Add(this.txtProcessId);
        this.GroupBoxProcessInfos.Controls.Add(this.Label16);
        this.GroupBoxProcessInfos.Location = new System.Drawing.Point(6, 129);
        this.GroupBoxProcessInfos.Name = "GroupBoxProcessInfos";
        this.GroupBoxProcessInfos.Size = new System.Drawing.Size(376, 142);
        this.GroupBoxProcessInfos.TabIndex = 16;
        this.GroupBoxProcessInfos.TabStop = false;
        this.GroupBoxProcessInfos.Text = "Process";
        // 
        // cmdGoProcess
        // 
        this.cmdGoProcess.Enabled = false;
        this.cmdGoProcess.Image = global::My.Resources.Resources.down16;
        this.cmdGoProcess.Location = new System.Drawing.Point(344, 43);
        this.cmdGoProcess.Name = "cmdGoProcess";
        this.cmdGoProcess.Size = new System.Drawing.Size(26, 22);
        this.cmdGoProcess.TabIndex = 32;
        this.cmdGoProcess.UseVisualStyleBackColor = true;
        // 
        // txtRunTime
        // 
        this.txtRunTime.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtRunTime.Location = new System.Drawing.Point(292, 66);
        this.txtRunTime.Name = "txtRunTime";
        this.txtRunTime.ReadOnly = true;
        this.txtRunTime.Size = new System.Drawing.Size(79, 22);
        this.txtRunTime.TabIndex = 31;
        // 
        // txtProcessStarted
        // 
        this.txtProcessStarted.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtProcessStarted.Location = new System.Drawing.Point(89, 66);
        this.txtProcessStarted.Name = "txtProcessStarted";
        this.txtProcessStarted.ReadOnly = true;
        this.txtProcessStarted.Size = new System.Drawing.Size(197, 22);
        this.txtProcessStarted.TabIndex = 28;
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(6, 69);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(78, 13);
        this.Label14.TabIndex = 30;
        this.Label14.Text = "Start/run time";
        // 
        // txtParentProcess
        // 
        this.txtParentProcess.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtParentProcess.Location = new System.Drawing.Point(89, 43);
        this.txtParentProcess.Name = "txtParentProcess";
        this.txtParentProcess.ReadOnly = true;
        this.txtParentProcess.Size = new System.Drawing.Size(249, 22);
        this.txtParentProcess.TabIndex = 27;
        // 
        // Label15
        // 
        this.Label15.AutoSize = true;
        this.Label15.Location = new System.Drawing.Point(6, 46);
        this.Label15.Name = "Label15";
        this.Label15.Size = new System.Drawing.Size(82, 13);
        this.Label15.TabIndex = 29;
        this.Label15.Text = "Parent process";
        // 
        // txtPriority
        // 
        this.txtPriority.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtPriority.Location = new System.Drawing.Point(237, 20);
        this.txtPriority.Name = "txtPriority";
        this.txtPriority.ReadOnly = true;
        this.txtPriority.Size = new System.Drawing.Size(134, 22);
        this.txtPriority.TabIndex = 25;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(188, 23);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(43, 13);
        this.Label4.TabIndex = 26;
        this.Label4.Text = "Priority";
        // 
        // txtCommandLine
        // 
        this.txtCommandLine.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtCommandLine.Location = new System.Drawing.Point(89, 114);
        this.txtCommandLine.Name = "txtCommandLine";
        this.txtCommandLine.ReadOnly = true;
        this.txtCommandLine.Size = new System.Drawing.Size(282, 22);
        this.txtCommandLine.TabIndex = 10;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(6, 117);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(81, 13);
        this.Label1.TabIndex = 23;
        this.Label1.Text = "Command line";
        // 
        // txtProcessUser
        // 
        this.txtProcessUser.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtProcessUser.Location = new System.Drawing.Point(89, 90);
        this.txtProcessUser.Name = "txtProcessUser";
        this.txtProcessUser.ReadOnly = true;
        this.txtProcessUser.Size = new System.Drawing.Size(282, 22);
        this.txtProcessUser.TabIndex = 9;
        // 
        // Label17
        // 
        this.Label17.AutoSize = true;
        this.Label17.Location = new System.Drawing.Point(6, 93);
        this.Label17.Name = "Label17";
        this.Label17.Size = new System.Drawing.Size(30, 13);
        this.Label17.TabIndex = 21;
        this.Label17.Text = "User";
        // 
        // txtProcessId
        // 
        this.txtProcessId.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtProcessId.Location = new System.Drawing.Point(89, 19);
        this.txtProcessId.Name = "txtProcessId";
        this.txtProcessId.ReadOnly = true;
        this.txtProcessId.Size = new System.Drawing.Size(93, 22);
        this.txtProcessId.TabIndex = 8;
        // 
        // Label16
        // 
        this.Label16.AutoSize = true;
        this.Label16.Location = new System.Drawing.Point(6, 22);
        this.Label16.Name = "Label16";
        this.Label16.Size = new System.Drawing.Size(23, 13);
        this.Label16.TabIndex = 19;
        this.Label16.Text = "Pid";
        // 
        // gpProcGeneralFile
        // 
        this.gpProcGeneralFile.Controls.Add(this.cmdInspectExe);
        this.gpProcGeneralFile.Controls.Add(this.cmdShowFileDetails);
        this.gpProcGeneralFile.Controls.Add(this.cmdShowFileProperties);
        this.gpProcGeneralFile.Controls.Add(this.cmdOpenDirectory);
        this.gpProcGeneralFile.Controls.Add(this.txtProcessPath);
        this.gpProcGeneralFile.Controls.Add(this.Label13);
        this.gpProcGeneralFile.Controls.Add(this.txtImageVersion);
        this.gpProcGeneralFile.Controls.Add(this.Label12);
        this.gpProcGeneralFile.Controls.Add(this.lblCopyright);
        this.gpProcGeneralFile.Controls.Add(this.lblDescription);
        this.gpProcGeneralFile.Controls.Add(this.pctSmallIcon);
        this.gpProcGeneralFile.Controls.Add(this.pctBigIcon);
        this.gpProcGeneralFile.Location = new System.Drawing.Point(6, 6);
        this.gpProcGeneralFile.Name = "gpProcGeneralFile";
        this.gpProcGeneralFile.Size = new System.Drawing.Size(376, 117);
        this.gpProcGeneralFile.TabIndex = 15;
        this.gpProcGeneralFile.TabStop = false;
        this.gpProcGeneralFile.Text = "Image file";
        // 
        // cmdInspectExe
        // 
        this.cmdInspectExe.Image = global::My.Resources.Resources.dllIcon16;
        this.cmdInspectExe.Location = new System.Drawing.Point(266, 81);
        this.cmdInspectExe.Name = "cmdInspectExe";
        this.cmdInspectExe.Size = new System.Drawing.Size(26, 26);
        this.cmdInspectExe.TabIndex = 18;
        this.cmdInspectExe.UseVisualStyleBackColor = true;
        // 
        // cmdShowFileDetails
        // 
        this.cmdShowFileDetails.Image = global::My.Resources.Resources.magnifier;
        this.cmdShowFileDetails.Location = new System.Drawing.Point(292, 81);
        this.cmdShowFileDetails.Name = "cmdShowFileDetails";
        this.cmdShowFileDetails.Size = new System.Drawing.Size(26, 26);
        this.cmdShowFileDetails.TabIndex = 3;
        this.cmdShowFileDetails.UseVisualStyleBackColor = true;
        // 
        // cmdShowFileProperties
        // 
        this.cmdShowFileProperties.Image = global::My.Resources.Resources.document_text;
        this.cmdShowFileProperties.Location = new System.Drawing.Point(318, 81);
        this.cmdShowFileProperties.Name = "cmdShowFileProperties";
        this.cmdShowFileProperties.Size = new System.Drawing.Size(26, 26);
        this.cmdShowFileProperties.TabIndex = 4;
        this.cmdShowFileProperties.UseVisualStyleBackColor = true;
        // 
        // cmdOpenDirectory
        // 
        this.cmdOpenDirectory.Image = global::My.Resources.Resources.folder_open_document;
        this.cmdOpenDirectory.Location = new System.Drawing.Point(344, 81);
        this.cmdOpenDirectory.Name = "cmdOpenDirectory";
        this.cmdOpenDirectory.Size = new System.Drawing.Size(26, 26);
        this.cmdOpenDirectory.TabIndex = 5;
        this.cmdOpenDirectory.UseVisualStyleBackColor = true;
        // 
        // txtProcessPath
        // 
        this.txtProcessPath.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtProcessPath.Location = new System.Drawing.Point(85, 82);
        this.txtProcessPath.Name = "txtProcessPath";
        this.txtProcessPath.ReadOnly = true;
        this.txtProcessPath.Size = new System.Drawing.Size(175, 22);
        this.txtProcessPath.TabIndex = 2;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(5, 85);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(65, 13);
        this.Label13.TabIndex = 17;
        this.Label13.Text = "Image path";
        // 
        // txtImageVersion
        // 
        this.txtImageVersion.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtImageVersion.Location = new System.Drawing.Point(85, 59);
        this.txtImageVersion.Name = "txtImageVersion";
        this.txtImageVersion.ReadOnly = true;
        this.txtImageVersion.Size = new System.Drawing.Size(285, 22);
        this.txtImageVersion.TabIndex = 1;
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(6, 62);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(78, 13);
        this.Label12.TabIndex = 15;
        this.Label12.Text = "Image version";
        // 
        // lblCopyright
        // 
        this.lblCopyright.AutoSize = true;
        this.lblCopyright.Location = new System.Drawing.Point(82, 38);
        this.lblCopyright.Name = "lblCopyright";
        this.lblCopyright.Size = new System.Drawing.Size(77, 13);
        this.lblCopyright.TabIndex = 14;
        this.lblCopyright.Text = "File copyright";
        // 
        // lblDescription
        // 
        this.lblDescription.AutoSize = true;
        this.lblDescription.Location = new System.Drawing.Point(82, 19);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(86, 13);
        this.lblDescription.TabIndex = 13;
        this.lblDescription.Text = "File description";
        // 
        // pctSmallIcon
        // 
        this.pctSmallIcon.Location = new System.Drawing.Point(44, 35);
        this.pctSmallIcon.Name = "pctSmallIcon";
        this.pctSmallIcon.Size = new System.Drawing.Size(16, 16);
        this.pctSmallIcon.TabIndex = 12;
        this.pctSmallIcon.TabStop = false;
        // 
        // pctBigIcon
        // 
        this.pctBigIcon.Location = new System.Drawing.Point(6, 19);
        this.pctBigIcon.Name = "pctBigIcon";
        this.pctBigIcon.Size = new System.Drawing.Size(32, 32);
        this.pctBigIcon.TabIndex = 11;
        this.pctBigIcon.TabStop = false;
        // 
        // TabPageStats
        // 
        this.TabPageStats.Controls.Add(this.GroupBox5);
        this.TabPageStats.Controls.Add(this.GroupBox4);
        this.TabPageStats.Controls.Add(this.GroupBox3);
        this.TabPageStats.Controls.Add(this.GroupBox2);
        this.TabPageStats.Location = new System.Drawing.Point(4, 40);
        this.TabPageStats.Name = "TabPageStats";
        this.TabPageStats.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageStats.Size = new System.Drawing.Size(647, 282);
        this.TabPageStats.TabIndex = 1;
        this.TabPageStats.Text = "Statistics";
        this.TabPageStats.UseVisualStyleBackColor = true;
        // 
        // GroupBox5
        // 
        this.GroupBox5.Controls.Add(this.lblThreads);
        this.GroupBox5.Controls.Add(this.Label44);
        this.GroupBox5.Controls.Add(this.lblUserObjectsCount);
        this.GroupBox5.Controls.Add(this.Label37);
        this.GroupBox5.Controls.Add(this.lblGDIcount);
        this.GroupBox5.Controls.Add(this.lbl789);
        this.GroupBox5.Controls.Add(this.lblHandles);
        this.GroupBox5.Controls.Add(this.Label53);
        this.GroupBox5.Location = new System.Drawing.Point(416, 135);
        this.GroupBox5.Name = "GroupBox5";
        this.GroupBox5.Size = new System.Drawing.Size(180, 122);
        this.GroupBox5.TabIndex = 3;
        this.GroupBox5.TabStop = false;
        this.GroupBox5.Text = "Other";
        // 
        // lblThreads
        // 
        this.lblThreads.AutoSize = true;
        this.lblThreads.Location = new System.Drawing.Point(102, 72);
        this.lblThreads.Name = "lblThreads";
        this.lblThreads.Size = new System.Drawing.Size(19, 13);
        this.lblThreads.TabIndex = 7;
        this.lblThreads.Text = "00";
        this.lblThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label44
        // 
        this.Label44.AutoSize = true;
        this.Label44.Location = new System.Drawing.Point(8, 72);
        this.Label44.Name = "Label44";
        this.Label44.Size = new System.Drawing.Size(47, 13);
        this.Label44.TabIndex = 6;
        this.Label44.Text = "Threads";
        // 
        // lblUserObjectsCount
        // 
        this.lblUserObjectsCount.AutoSize = true;
        this.lblUserObjectsCount.Location = new System.Drawing.Point(102, 54);
        this.lblUserObjectsCount.Name = "lblUserObjectsCount";
        this.lblUserObjectsCount.Size = new System.Drawing.Size(19, 13);
        this.lblUserObjectsCount.TabIndex = 5;
        this.lblUserObjectsCount.Text = "00";
        this.lblUserObjectsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label37
        // 
        this.Label37.AutoSize = true;
        this.Label37.Location = new System.Drawing.Point(8, 54);
        this.Label37.Name = "Label37";
        this.Label37.Size = new System.Drawing.Size(70, 13);
        this.Label37.TabIndex = 4;
        this.Label37.Text = "User objects";
        // 
        // lblGDIcount
        // 
        this.lblGDIcount.AutoSize = true;
        this.lblGDIcount.Location = new System.Drawing.Point(102, 35);
        this.lblGDIcount.Name = "lblGDIcount";
        this.lblGDIcount.Size = new System.Drawing.Size(19, 13);
        this.lblGDIcount.TabIndex = 3;
        this.lblGDIcount.Text = "00";
        this.lblGDIcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbl789
        // 
        this.lbl789.AutoSize = true;
        this.lbl789.Location = new System.Drawing.Point(8, 35);
        this.lbl789.Name = "lbl789";
        this.lbl789.Size = new System.Drawing.Size(66, 13);
        this.lbl789.TabIndex = 2;
        this.lbl789.Text = "GDI objects";
        // 
        // lblHandles
        // 
        this.lblHandles.AutoSize = true;
        this.lblHandles.Location = new System.Drawing.Point(102, 16);
        this.lblHandles.Name = "lblHandles";
        this.lblHandles.Size = new System.Drawing.Size(19, 13);
        this.lblHandles.TabIndex = 1;
        this.lblHandles.Text = "00";
        this.lblHandles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label53
        // 
        this.Label53.AutoSize = true;
        this.Label53.Location = new System.Drawing.Point(8, 16);
        this.Label53.Name = "Label53";
        this.Label53.Size = new System.Drawing.Size(49, 13);
        this.Label53.TabIndex = 0;
        this.Label53.Text = "Handles";
        // 
        // GroupBox4
        // 
        this.GroupBox4.Controls.Add(this.lblOthersBD);
        this.GroupBox4.Controls.Add(this.Label5);
        this.GroupBox4.Controls.Add(this.lblOtherD);
        this.GroupBox4.Controls.Add(this.Label7);
        this.GroupBox4.Controls.Add(this.lblWBD);
        this.GroupBox4.Controls.Add(this.Label9);
        this.GroupBox4.Controls.Add(this.lblWD);
        this.GroupBox4.Controls.Add(this.Label11);
        this.GroupBox4.Controls.Add(this.lblRBD);
        this.GroupBox4.Controls.Add(this.Label34);
        this.GroupBox4.Controls.Add(this.lblRD);
        this.GroupBox4.Controls.Add(this.Label41);
        this.GroupBox4.Controls.Add(this.lblProcOtherBytes);
        this.GroupBox4.Controls.Add(this.Label23);
        this.GroupBox4.Controls.Add(this.lblProcOther);
        this.GroupBox4.Controls.Add(this.Label30);
        this.GroupBox4.Controls.Add(this.lblProcWriteBytes);
        this.GroupBox4.Controls.Add(this.Label36);
        this.GroupBox4.Controls.Add(this.lblProcWrites);
        this.GroupBox4.Controls.Add(this.Label38);
        this.GroupBox4.Controls.Add(this.lblProcReadBytes);
        this.GroupBox4.Controls.Add(this.Label40);
        this.GroupBox4.Controls.Add(this.lblProcReads);
        this.GroupBox4.Controls.Add(this.Label42);
        this.GroupBox4.Location = new System.Drawing.Point(234, 8);
        this.GroupBox4.Name = "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(176, 249);
        this.GroupBox4.TabIndex = 2;
        this.GroupBox4.TabStop = false;
        this.GroupBox4.Text = "I/O";
        // 
        // lblOthersBD
        // 
        this.lblOthersBD.AutoSize = true;
        this.lblOthersBD.Location = new System.Drawing.Point(102, 217);
        this.lblOthersBD.Name = "lblOthersBD";
        this.lblOthersBD.Size = new System.Drawing.Size(19, 13);
        this.lblOthersBD.TabIndex = 43;
        this.lblOthersBD.Text = "00";
        this.lblOthersBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(6, 217);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(96, 13);
        this.Label5.TabIndex = 42;
        this.Label5.Text = "Other bytes delta";
        // 
        // lblOtherD
        // 
        this.lblOtherD.AutoSize = true;
        this.lblOtherD.Location = new System.Drawing.Point(102, 199);
        this.lblOtherD.Name = "lblOtherD";
        this.lblOtherD.Size = new System.Drawing.Size(19, 13);
        this.lblOtherD.TabIndex = 41;
        this.lblOtherD.Text = "00";
        this.lblOtherD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(6, 199);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(66, 13);
        this.Label7.TabIndex = 40;
        this.Label7.Text = "Other delta";
        // 
        // lblWBD
        // 
        this.lblWBD.AutoSize = true;
        this.lblWBD.Location = new System.Drawing.Point(102, 180);
        this.lblWBD.Name = "lblWBD";
        this.lblWBD.Size = new System.Drawing.Size(19, 13);
        this.lblWBD.TabIndex = 39;
        this.lblWBD.Text = "00";
        this.lblWBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(6, 180);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(94, 13);
        this.Label9.TabIndex = 38;
        this.Label9.Text = "Write bytes delta";
        // 
        // lblWD
        // 
        this.lblWD.AutoSize = true;
        this.lblWD.Location = new System.Drawing.Point(102, 162);
        this.lblWD.Name = "lblWD";
        this.lblWD.Size = new System.Drawing.Size(19, 13);
        this.lblWD.TabIndex = 37;
        this.lblWD.Text = "00";
        this.lblWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(6, 162);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(69, 13);
        this.Label11.TabIndex = 36;
        this.Label11.Text = "Writes delta";
        // 
        // lblRBD
        // 
        this.lblRBD.AutoSize = true;
        this.lblRBD.Location = new System.Drawing.Point(102, 144);
        this.lblRBD.Name = "lblRBD";
        this.lblRBD.Size = new System.Drawing.Size(19, 13);
        this.lblRBD.TabIndex = 35;
        this.lblRBD.Text = "00";
        this.lblRBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label34
        // 
        this.Label34.AutoSize = true;
        this.Label34.Location = new System.Drawing.Point(6, 144);
        this.Label34.Name = "Label34";
        this.Label34.Size = new System.Drawing.Size(92, 13);
        this.Label34.TabIndex = 34;
        this.Label34.Text = "Read bytes delta";
        // 
        // lblRD
        // 
        this.lblRD.AutoSize = true;
        this.lblRD.Location = new System.Drawing.Point(102, 126);
        this.lblRD.Name = "lblRD";
        this.lblRD.Size = new System.Drawing.Size(19, 13);
        this.lblRD.TabIndex = 33;
        this.lblRD.Text = "00";
        this.lblRD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label41
        // 
        this.Label41.AutoSize = true;
        this.Label41.Location = new System.Drawing.Point(6, 126);
        this.Label41.Name = "Label41";
        this.Label41.Size = new System.Drawing.Size(67, 13);
        this.Label41.TabIndex = 32;
        this.Label41.Text = "Reads delta";
        // 
        // lblProcOtherBytes
        // 
        this.lblProcOtherBytes.AutoSize = true;
        this.lblProcOtherBytes.Location = new System.Drawing.Point(102, 107);
        this.lblProcOtherBytes.Name = "lblProcOtherBytes";
        this.lblProcOtherBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcOtherBytes.TabIndex = 31;
        this.lblProcOtherBytes.Text = "00";
        this.lblProcOtherBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label23
        // 
        this.Label23.AutoSize = true;
        this.Label23.Location = new System.Drawing.Point(6, 107);
        this.Label23.Name = "Label23";
        this.Label23.Size = new System.Drawing.Size(67, 13);
        this.Label23.TabIndex = 30;
        this.Label23.Text = "Other bytes";
        // 
        // lblProcOther
        // 
        this.lblProcOther.AutoSize = true;
        this.lblProcOther.Location = new System.Drawing.Point(102, 89);
        this.lblProcOther.Name = "lblProcOther";
        this.lblProcOther.Size = new System.Drawing.Size(19, 13);
        this.lblProcOther.TabIndex = 29;
        this.lblProcOther.Text = "00";
        this.lblProcOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label30
        // 
        this.Label30.AutoSize = true;
        this.Label30.Location = new System.Drawing.Point(6, 89);
        this.Label30.Name = "Label30";
        this.Label30.Size = new System.Drawing.Size(37, 13);
        this.Label30.TabIndex = 28;
        this.Label30.Text = "Other";
        // 
        // lblProcWriteBytes
        // 
        this.lblProcWriteBytes.AutoSize = true;
        this.lblProcWriteBytes.Location = new System.Drawing.Point(102, 70);
        this.lblProcWriteBytes.Name = "lblProcWriteBytes";
        this.lblProcWriteBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcWriteBytes.TabIndex = 27;
        this.lblProcWriteBytes.Text = "00";
        this.lblProcWriteBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label36
        // 
        this.Label36.AutoSize = true;
        this.Label36.Location = new System.Drawing.Point(6, 70);
        this.Label36.Name = "Label36";
        this.Label36.Size = new System.Drawing.Size(65, 13);
        this.Label36.TabIndex = 26;
        this.Label36.Text = "Write bytes";
        // 
        // lblProcWrites
        // 
        this.lblProcWrites.AutoSize = true;
        this.lblProcWrites.Location = new System.Drawing.Point(102, 52);
        this.lblProcWrites.Name = "lblProcWrites";
        this.lblProcWrites.Size = new System.Drawing.Size(19, 13);
        this.lblProcWrites.TabIndex = 25;
        this.lblProcWrites.Text = "00";
        this.lblProcWrites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label38
        // 
        this.Label38.AutoSize = true;
        this.Label38.Location = new System.Drawing.Point(6, 52);
        this.Label38.Name = "Label38";
        this.Label38.Size = new System.Drawing.Size(40, 13);
        this.Label38.TabIndex = 24;
        this.Label38.Text = "Writes";
        // 
        // lblProcReadBytes
        // 
        this.lblProcReadBytes.AutoSize = true;
        this.lblProcReadBytes.Location = new System.Drawing.Point(102, 34);
        this.lblProcReadBytes.Name = "lblProcReadBytes";
        this.lblProcReadBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcReadBytes.TabIndex = 23;
        this.lblProcReadBytes.Text = "00";
        this.lblProcReadBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label40
        // 
        this.Label40.AutoSize = true;
        this.Label40.Location = new System.Drawing.Point(6, 34);
        this.Label40.Name = "Label40";
        this.Label40.Size = new System.Drawing.Size(63, 13);
        this.Label40.TabIndex = 22;
        this.Label40.Text = "Read bytes";
        // 
        // lblProcReads
        // 
        this.lblProcReads.AutoSize = true;
        this.lblProcReads.Location = new System.Drawing.Point(102, 16);
        this.lblProcReads.Name = "lblProcReads";
        this.lblProcReads.Size = new System.Drawing.Size(19, 13);
        this.lblProcReads.TabIndex = 21;
        this.lblProcReads.Text = "00";
        this.lblProcReads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label42
        // 
        this.Label42.AutoSize = true;
        this.Label42.Location = new System.Drawing.Point(6, 16);
        this.Label42.Name = "Label42";
        this.Label42.Size = new System.Drawing.Size(38, 13);
        this.Label42.TabIndex = 20;
        this.Label42.Text = "Reads";
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.lblQuotaNPP);
        this.GroupBox3.Controls.Add(this.Label21);
        this.GroupBox3.Controls.Add(this.lblQuotaPNPP);
        this.GroupBox3.Controls.Add(this.Label26);
        this.GroupBox3.Controls.Add(this.lblQuotaPP);
        this.GroupBox3.Controls.Add(this.Label29);
        this.GroupBox3.Controls.Add(this.lblQuotaPPP);
        this.GroupBox3.Controls.Add(this.Label32);
        this.GroupBox3.Controls.Add(this.lblPageFaults);
        this.GroupBox3.Controls.Add(this.Label31);
        this.GroupBox3.Controls.Add(this.lblPeakPageFileUsage);
        this.GroupBox3.Controls.Add(this.Label33);
        this.GroupBox3.Controls.Add(this.lblPageFileUsage);
        this.GroupBox3.Controls.Add(this.Label35);
        this.GroupBox3.Controls.Add(this.lblPeakWorkingSet);
        this.GroupBox3.Controls.Add(this.Label25);
        this.GroupBox3.Controls.Add(this.lblWorkingSet);
        this.GroupBox3.Controls.Add(this.Label27);
        this.GroupBox3.Location = new System.Drawing.Point(6, 8);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(222, 249);
        this.GroupBox3.TabIndex = 1;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Memory";
        // 
        // lblQuotaNPP
        // 
        this.lblQuotaNPP.AutoSize = true;
        this.lblQuotaNPP.Location = new System.Drawing.Point(146, 145);
        this.lblQuotaNPP.Name = "lblQuotaNPP";
        this.lblQuotaNPP.Size = new System.Drawing.Size(19, 13);
        this.lblQuotaNPP.TabIndex = 23;
        this.lblQuotaNPP.Text = "00";
        this.lblQuotaNPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label21
        // 
        this.Label21.AutoSize = true;
        this.Label21.Location = new System.Drawing.Point(5, 145);
        this.Label21.Name = "Label21";
        this.Label21.Size = new System.Drawing.Size(117, 13);
        this.Label21.TabIndex = 22;
        this.Label21.Text = "QuotaNonPagedPool";
        // 
        // lblQuotaPNPP
        // 
        this.lblQuotaPNPP.AutoSize = true;
        this.lblQuotaPNPP.Location = new System.Drawing.Point(146, 127);
        this.lblQuotaPNPP.Name = "lblQuotaPNPP";
        this.lblQuotaPNPP.Size = new System.Drawing.Size(19, 13);
        this.lblQuotaPNPP.TabIndex = 21;
        this.lblQuotaPNPP.Text = "00";
        this.lblQuotaPNPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label26
        // 
        this.Label26.AutoSize = true;
        this.Label26.Location = new System.Drawing.Point(5, 127);
        this.Label26.Name = "Label26";
        this.Label26.Size = new System.Drawing.Size(141, 13);
        this.Label26.TabIndex = 20;
        this.Label26.Text = "QuotaPeakNonPagedPool";
        // 
        // lblQuotaPP
        // 
        this.lblQuotaPP.AutoSize = true;
        this.lblQuotaPP.Location = new System.Drawing.Point(146, 109);
        this.lblQuotaPP.Name = "lblQuotaPP";
        this.lblQuotaPP.Size = new System.Drawing.Size(19, 13);
        this.lblQuotaPP.TabIndex = 19;
        this.lblQuotaPP.Text = "00";
        this.lblQuotaPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label29
        // 
        this.Label29.AutoSize = true;
        this.Label29.Location = new System.Drawing.Point(5, 109);
        this.Label29.Name = "Label29";
        this.Label29.Size = new System.Drawing.Size(95, 13);
        this.Label29.TabIndex = 18;
        this.Label29.Text = "QuotaPagedPool";
        // 
        // lblQuotaPPP
        // 
        this.lblQuotaPPP.AutoSize = true;
        this.lblQuotaPPP.Location = new System.Drawing.Point(146, 91);
        this.lblQuotaPPP.Name = "lblQuotaPPP";
        this.lblQuotaPPP.Size = new System.Drawing.Size(19, 13);
        this.lblQuotaPPP.TabIndex = 17;
        this.lblQuotaPPP.Text = "00";
        this.lblQuotaPPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label32
        // 
        this.Label32.AutoSize = true;
        this.Label32.Location = new System.Drawing.Point(5, 91);
        this.Label32.Name = "Label32";
        this.Label32.Size = new System.Drawing.Size(119, 13);
        this.Label32.TabIndex = 16;
        this.Label32.Text = "QuotaPeakPagedPool";
        // 
        // lblPageFaults
        // 
        this.lblPageFaults.AutoSize = true;
        this.lblPageFaults.Location = new System.Drawing.Point(146, 163);
        this.lblPageFaults.Name = "lblPageFaults";
        this.lblPageFaults.Size = new System.Drawing.Size(19, 13);
        this.lblPageFaults.TabIndex = 15;
        this.lblPageFaults.Text = "00";
        this.lblPageFaults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label31
        // 
        this.Label31.AutoSize = true;
        this.Label31.Location = new System.Drawing.Point(5, 163);
        this.Label31.Name = "Label31";
        this.Label31.Size = new System.Drawing.Size(64, 13);
        this.Label31.TabIndex = 14;
        this.Label31.Text = "Page faults";
        // 
        // lblPeakPageFileUsage
        // 
        this.lblPeakPageFileUsage.AutoSize = true;
        this.lblPeakPageFileUsage.Location = new System.Drawing.Point(146, 72);
        this.lblPeakPageFileUsage.Name = "lblPeakPageFileUsage";
        this.lblPeakPageFileUsage.Size = new System.Drawing.Size(19, 13);
        this.lblPeakPageFileUsage.TabIndex = 13;
        this.lblPeakPageFileUsage.Text = "00";
        this.lblPeakPageFileUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label33
        // 
        this.Label33.AutoSize = true;
        this.Label33.Location = new System.Drawing.Point(5, 72);
        this.Label33.Name = "Label33";
        this.Label33.Size = new System.Drawing.Size(113, 13);
        this.Label33.TabIndex = 12;
        this.Label33.Text = "Peak page file usage";
        // 
        // lblPageFileUsage
        // 
        this.lblPageFileUsage.AutoSize = true;
        this.lblPageFileUsage.Location = new System.Drawing.Point(146, 54);
        this.lblPageFileUsage.Name = "lblPageFileUsage";
        this.lblPageFileUsage.Size = new System.Drawing.Size(19, 13);
        this.lblPageFileUsage.TabIndex = 11;
        this.lblPageFileUsage.Text = "00";
        this.lblPageFileUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label35
        // 
        this.Label35.AutoSize = true;
        this.Label35.Location = new System.Drawing.Point(5, 54);
        this.Label35.Name = "Label35";
        this.Label35.Size = new System.Drawing.Size(82, 13);
        this.Label35.TabIndex = 10;
        this.Label35.Text = "Pagefile usage";
        // 
        // lblPeakWorkingSet
        // 
        this.lblPeakWorkingSet.AutoSize = true;
        this.lblPeakWorkingSet.Location = new System.Drawing.Point(146, 36);
        this.lblPeakWorkingSet.Name = "lblPeakWorkingSet";
        this.lblPeakWorkingSet.Size = new System.Drawing.Size(19, 13);
        this.lblPeakWorkingSet.TabIndex = 5;
        this.lblPeakWorkingSet.Text = "00";
        this.lblPeakWorkingSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label25
        // 
        this.Label25.AutoSize = true;
        this.Label25.Location = new System.Drawing.Point(5, 36);
        this.Label25.Name = "Label25";
        this.Label25.Size = new System.Drawing.Size(95, 13);
        this.Label25.TabIndex = 4;
        this.Label25.Text = "Peak working set";
        // 
        // lblWorkingSet
        // 
        this.lblWorkingSet.AutoSize = true;
        this.lblWorkingSet.Location = new System.Drawing.Point(146, 18);
        this.lblWorkingSet.Name = "lblWorkingSet";
        this.lblWorkingSet.Size = new System.Drawing.Size(19, 13);
        this.lblWorkingSet.TabIndex = 3;
        this.lblWorkingSet.Text = "00";
        this.lblWorkingSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label27
        // 
        this.Label27.AutoSize = true;
        this.Label27.Location = new System.Drawing.Point(5, 18);
        this.Label27.Name = "Label27";
        this.Label27.Size = new System.Drawing.Size(70, 13);
        this.Label27.TabIndex = 2;
        this.Label27.Text = "Working set";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.lblAverageCPUusage);
        this.GroupBox2.Controls.Add(this.Label3);
        this.GroupBox2.Controls.Add(this.lblTotalTime);
        this.GroupBox2.Controls.Add(this.Label24);
        this.GroupBox2.Controls.Add(this.lblUserTime);
        this.GroupBox2.Controls.Add(this.Label22);
        this.GroupBox2.Controls.Add(this.lblKernelTime);
        this.GroupBox2.Controls.Add(this.Label20);
        this.GroupBox2.Controls.Add(this.lblPriority);
        this.GroupBox2.Controls.Add(this.Label18);
        this.GroupBox2.Location = new System.Drawing.Point(416, 8);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(180, 120);
        this.GroupBox2.TabIndex = 0;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "CPU";
        // 
        // lblAverageCPUusage
        // 
        this.lblAverageCPUusage.AutoSize = true;
        this.lblAverageCPUusage.Location = new System.Drawing.Point(100, 91);
        this.lblAverageCPUusage.Name = "lblAverageCPUusage";
        this.lblAverageCPUusage.Size = new System.Drawing.Size(19, 13);
        this.lblAverageCPUusage.TabIndex = 9;
        this.lblAverageCPUusage.Text = "00";
        this.lblAverageCPUusage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(6, 91);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(82, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "Average usage";
        // 
        // lblTotalTime
        // 
        this.lblTotalTime.AutoSize = true;
        this.lblTotalTime.Location = new System.Drawing.Point(100, 73);
        this.lblTotalTime.Name = "lblTotalTime";
        this.lblTotalTime.Size = new System.Drawing.Size(70, 13);
        this.lblTotalTime.TabIndex = 7;
        this.lblTotalTime.Text = "00:00:00.158";
        this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label24
        // 
        this.Label24.AutoSize = true;
        this.Label24.Location = new System.Drawing.Point(6, 73);
        this.Label24.Name = "Label24";
        this.Label24.Size = new System.Drawing.Size(57, 13);
        this.Label24.TabIndex = 6;
        this.Label24.Text = "Total time";
        // 
        // lblUserTime
        // 
        this.lblUserTime.AutoSize = true;
        this.lblUserTime.Location = new System.Drawing.Point(100, 54);
        this.lblUserTime.Name = "lblUserTime";
        this.lblUserTime.Size = new System.Drawing.Size(19, 13);
        this.lblUserTime.TabIndex = 5;
        this.lblUserTime.Text = "00";
        this.lblUserTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label22
        // 
        this.Label22.AutoSize = true;
        this.Label22.Location = new System.Drawing.Point(6, 54);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(55, 13);
        this.Label22.TabIndex = 4;
        this.Label22.Text = "User time";
        // 
        // lblKernelTime
        // 
        this.lblKernelTime.AutoSize = true;
        this.lblKernelTime.Location = new System.Drawing.Point(100, 36);
        this.lblKernelTime.Name = "lblKernelTime";
        this.lblKernelTime.Size = new System.Drawing.Size(19, 13);
        this.lblKernelTime.TabIndex = 3;
        this.lblKernelTime.Text = "00";
        this.lblKernelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label20
        // 
        this.Label20.AutoSize = true;
        this.Label20.Location = new System.Drawing.Point(6, 36);
        this.Label20.Name = "Label20";
        this.Label20.Size = new System.Drawing.Size(64, 13);
        this.Label20.TabIndex = 2;
        this.Label20.Text = "Kernel time";
        // 
        // lblPriority
        // 
        this.lblPriority.AutoSize = true;
        this.lblPriority.Location = new System.Drawing.Point(100, 18);
        this.lblPriority.Name = "lblPriority";
        this.lblPriority.Size = new System.Drawing.Size(19, 13);
        this.lblPriority.TabIndex = 1;
        this.lblPriority.Text = "00";
        this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label18
        // 
        this.Label18.AutoSize = true;
        this.Label18.Location = new System.Drawing.Point(6, 18);
        this.Label18.Name = "Label18";
        this.Label18.Size = new System.Drawing.Size(43, 13);
        this.Label18.TabIndex = 0;
        this.Label18.Text = "Priority";
        // 
        // TabPagePerf
        // 
        this.TabPagePerf.Controls.Add(this.splitPerformances);
        this.TabPagePerf.Location = new System.Drawing.Point(4, 40);
        this.TabPagePerf.Name = "TabPagePerf";
        this.TabPagePerf.Padding = new System.Windows.Forms.Padding(3);
        this.TabPagePerf.Size = new System.Drawing.Size(647, 282);
        this.TabPagePerf.TabIndex = 2;
        this.TabPagePerf.Text = "Performances";
        this.TabPagePerf.UseVisualStyleBackColor = true;
        // 
        // splitPerformances
        // 
        this.splitPerformances.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitPerformances.IsSplitterFixed = true;
        this.splitPerformances.Location = new System.Drawing.Point(3, 3);
        this.splitPerformances.Name = "splitPerformances";
        this.splitPerformances.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitPerformances.Panel1
        // 
        this.splitPerformances.Panel1.Controls.Add(this.graphCPU);
        // 
        // splitPerformances.Panel2
        // 
        this.splitPerformances.Panel2.Controls.Add(this.splitPerformance2);
        this.splitPerformances.Size = new System.Drawing.Size(641, 276);
        this.splitPerformances.SplitterDistance = 82;
        this.splitPerformances.SplitterWidth = 1;
        this.splitPerformances.TabIndex = 3;
        // 
        // graphCPU
        // 
        this.graphCPU.BackColor = System.Drawing.Color.Black;
        this.graphCPU.Color2 = System.Drawing.Color.Olive;
        this.graphCPU.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphCPU.EnableGraph = true;
        this.graphCPU.Fixedheight = true;
        this.graphCPU.GridStep = 13;
        this.graphCPU.Location = new System.Drawing.Point(0, 0);
        this.graphCPU.Name = "graphCPU";
        this.graphCPU.ShowSecondGraph = true;
        this.graphCPU.Size = new System.Drawing.Size(641, 82);
        this.graphCPU.TabIndex = 1;
        this.graphCPU.TabStop = false;
        this.graphCPU.TextColor = System.Drawing.Color.Lime;
        this.graphCPU.TopText = null;
        // 
        // splitPerformance2
        // 
        this.splitPerformance2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitPerformance2.IsSplitterFixed = true;
        this.splitPerformance2.Location = new System.Drawing.Point(0, 0);
        this.splitPerformance2.Name = "splitPerformance2";
        this.splitPerformance2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitPerformance2.Panel1
        // 
        this.splitPerformance2.Panel1.Controls.Add(this.graphMemory);
        // 
        // splitPerformance2.Panel2
        // 
        this.splitPerformance2.Panel2.Controls.Add(this.graphIO);
        this.splitPerformance2.Size = new System.Drawing.Size(641, 193);
        this.splitPerformance2.SplitterDistance = 88;
        this.splitPerformance2.SplitterWidth = 1;
        this.splitPerformance2.TabIndex = 0;
        // 
        // graphMemory
        // 
        this.graphMemory.BackColor = System.Drawing.Color.Black;
        this.graphMemory.Color = System.Drawing.Color.Red;
        this.graphMemory.Color2 = System.Drawing.Color.Maroon;
        this.graphMemory.Color3 = System.Drawing.Color.LightCoral;
        this.graphMemory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphMemory.EnableGraph = true;
        this.graphMemory.Fixedheight = false;
        this.graphMemory.GridStep = 13;
        this.graphMemory.Location = new System.Drawing.Point(0, 0);
        this.graphMemory.Name = "graphMemory";
        this.graphMemory.ShowSecondGraph = true;
        this.graphMemory.Size = new System.Drawing.Size(641, 88);
        this.graphMemory.TabIndex = 2;
        this.graphMemory.TabStop = false;
        this.graphMemory.TextColor = System.Drawing.Color.Lime;
        this.graphMemory.TopText = null;
        // 
        // graphIO
        // 
        this.graphIO.BackColor = System.Drawing.Color.Black;
        this.graphIO.Color = System.Drawing.Color.LimeGreen;
        this.graphIO.Color2 = System.Drawing.Color.Green;
        this.graphIO.Dock = System.Windows.Forms.DockStyle.Fill;
        this.graphIO.EnableGraph = true;
        this.graphIO.Fixedheight = false;
        this.graphIO.GridStep = 13;
        this.graphIO.Location = new System.Drawing.Point(0, 0);
        this.graphIO.Name = "graphIO";
        this.graphIO.ShowSecondGraph = false;
        this.graphIO.Size = new System.Drawing.Size(641, 104);
        this.graphIO.TabIndex = 3;
        this.graphIO.TabStop = false;
        this.graphIO.TextColor = System.Drawing.Color.Lime;
        this.graphIO.TopText = null;
        // 
        // TabPageToken
        // 
        this.TabPageToken.Controls.Add(this.tabProcessToken);
        this.TabPageToken.Location = new System.Drawing.Point(4, 40);
        this.TabPageToken.Name = "TabPageToken";
        this.TabPageToken.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageToken.Size = new System.Drawing.Size(647, 282);
        this.TabPageToken.TabIndex = 3;
        this.TabPageToken.Text = "Token";
        this.TabPageToken.UseVisualStyleBackColor = true;
        // 
        // tabProcessToken
        // 
        this.tabProcessToken.Controls.Add(this.tabProcessTokenPagePrivileges);
        this.tabProcessToken.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabProcessToken.Location = new System.Drawing.Point(3, 3);
        this.tabProcessToken.Name = "tabProcessToken";
        this.tabProcessToken.SelectedIndex = 0;
        this.tabProcessToken.Size = new System.Drawing.Size(641, 276);
        this.tabProcessToken.TabIndex = 0;
        // 
        // tabProcessTokenPagePrivileges
        // 
        this.tabProcessTokenPagePrivileges.Controls.Add(this.lvPrivileges);
        this.tabProcessTokenPagePrivileges.Location = new System.Drawing.Point(4, 22);
        this.tabProcessTokenPagePrivileges.Name = "tabProcessTokenPagePrivileges";
        this.tabProcessTokenPagePrivileges.Padding = new System.Windows.Forms.Padding(3);
        this.tabProcessTokenPagePrivileges.Size = new System.Drawing.Size(633, 250);
        this.tabProcessTokenPagePrivileges.TabIndex = 0;
        this.tabProcessTokenPagePrivileges.Text = "Privileges";
        this.tabProcessTokenPagePrivileges.UseVisualStyleBackColor = true;
        // 
        // lvPrivileges
        // 
        this.lvPrivileges.AllowColumnReorder = true;
        this.lvPrivileges.CatchErrors = false;
        this.lvPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader50, this.ColumnHeader51, this.ColumnHeader52 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection1.Snapshot = null;
        CConnection1.SnapshotFile = null;
        this.lvPrivileges.ConnectionObj = CConnection1;
        this.lvPrivileges.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvPrivileges.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvPrivileges.FullRowSelect = true;
        this.lvPrivileges.HideSelection = false;
        this.lvPrivileges.IsConnected = false;
        this.lvPrivileges.Location = new System.Drawing.Point(3, 3);
        this.lvPrivileges.Name = "lvPrivileges";
        this.lvPrivileges.OverriddenDoubleBuffered = true;
        this.lvPrivileges.ProcessId = 0;
        this.lvPrivileges.ReorganizeColumns = true;
        this.lvPrivileges.ShowObjectDetailsOnDoubleClick = true;
        this.lvPrivileges.Size = new System.Drawing.Size(627, 244);
        this.lvPrivileges.TabIndex = 13;
        this.lvPrivileges.UseCompatibleStateImageBehavior = false;
        this.lvPrivileges.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader50
        // 
        this.ColumnHeader50.Text = "Name";
        this.ColumnHeader50.Width = 159;
        // 
        // ColumnHeader51
        // 
        this.ColumnHeader51.Text = "Status";
        this.ColumnHeader51.Width = 100;
        // 
        // ColumnHeader52
        // 
        this.ColumnHeader52.Text = "Description";
        this.ColumnHeader52.Width = 319;
        // 
        // TabPageMemory
        // 
        this.TabPageMemory.Controls.Add(this.lvProcMem);
        this.TabPageMemory.Location = new System.Drawing.Point(4, 40);
        this.TabPageMemory.Name = "TabPageMemory";
        this.TabPageMemory.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageMemory.Size = new System.Drawing.Size(647, 282);
        this.TabPageMemory.TabIndex = 4;
        this.TabPageMemory.Text = "Memory";
        this.TabPageMemory.UseVisualStyleBackColor = true;
        // 
        // lvProcMem
        // 
        this.lvProcMem.AllowColumnReorder = true;
        this.lvProcMem.CatchErrors = false;
        this.lvProcMem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader53, this.ColumnHeader54, this.ColumnHeader55, this.ColumnHeader56, this.ColumnHeader13 });
        CConnection2.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection2.Snapshot = null;
        CConnection2.SnapshotFile = null;
        this.lvProcMem.ConnectionObj = CConnection2;
        this.lvProcMem.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcMem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcMem.FullRowSelect = true;
        this.lvProcMem.HideSelection = false;
        this.lvProcMem.IsConnected = false;
        this.lvProcMem.Location = new System.Drawing.Point(3, 3);
        this.lvProcMem.Name = "lvProcMem";
        this.lvProcMem.OverriddenDoubleBuffered = true;
        this.lvProcMem.ProcessId = 0;
        this.lvProcMem.ReorganizeColumns = true;
        this.lvProcMem.ShowObjectDetailsOnDoubleClick = false;
        this.lvProcMem.Size = new System.Drawing.Size(641, 276);
        this.lvProcMem.TabIndex = 14;
        this.lvProcMem.UseCompatibleStateImageBehavior = false;
        this.lvProcMem.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader53
        // 
        this.ColumnHeader53.Text = "Name";
        this.ColumnHeader53.Width = 170;
        // 
        // ColumnHeader54
        // 
        this.ColumnHeader54.Text = "Address";
        this.ColumnHeader54.Width = 82;
        // 
        // ColumnHeader55
        // 
        this.ColumnHeader55.Text = "Size";
        this.ColumnHeader55.Width = 64;
        // 
        // ColumnHeader56
        // 
        this.ColumnHeader56.Text = "Protection";
        this.ColumnHeader56.Width = 85;
        // 
        // ColumnHeader13
        // 
        this.ColumnHeader13.Text = "File";
        this.ColumnHeader13.Width = 338;
        // 
        // TabPageInfos
        // 
        this.TabPageInfos.Controls.Add(this.SplitContainerInfoProcess);
        this.TabPageInfos.Location = new System.Drawing.Point(4, 40);
        this.TabPageInfos.Name = "TabPageInfos";
        this.TabPageInfos.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageInfos.Size = new System.Drawing.Size(647, 282);
        this.TabPageInfos.TabIndex = 5;
        this.TabPageInfos.Text = "Informations";
        this.TabPageInfos.UseVisualStyleBackColor = true;
        // 
        // SplitContainerInfoProcess
        // 
        this.SplitContainerInfoProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerInfoProcess.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerInfoProcess.Location = new System.Drawing.Point(3, 3);
        this.SplitContainerInfoProcess.Name = "SplitContainerInfoProcess";
        this.SplitContainerInfoProcess.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerInfoProcess.Panel1
        // 
        this.SplitContainerInfoProcess.Panel1.Controls.Add(this.cmdRefresh);
        this.SplitContainerInfoProcess.Panel1.Controls.Add(this.cmdInfosToClipB);
        // 
        // SplitContainerInfoProcess.Panel2
        // 
        this.SplitContainerInfoProcess.Panel2.Controls.Add(this.rtb);
        this.SplitContainerInfoProcess.Size = new System.Drawing.Size(641, 276);
        this.SplitContainerInfoProcess.SplitterDistance = 25;
        this.SplitContainerInfoProcess.TabIndex = 0;
        // 
        // cmdRefresh
        // 
        this.cmdRefresh.Image = global::My.Resources.Resources.refresh16;
        this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdRefresh.Location = new System.Drawing.Point(159, 0);
        this.cmdRefresh.Name = "cmdRefresh";
        this.cmdRefresh.Size = new System.Drawing.Size(85, 24);
        this.cmdRefresh.TabIndex = 1;
        this.cmdRefresh.Text = "Refresh   ";
        this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdRefresh.UseVisualStyleBackColor = true;
        // 
        // cmdInfosToClipB
        // 
        this.cmdInfosToClipB.Enabled = false;
        this.cmdInfosToClipB.Image = global::My.Resources.Resources.copy16;
        this.cmdInfosToClipB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdInfosToClipB.Location = new System.Drawing.Point(3, 0);
        this.cmdInfosToClipB.Name = "cmdInfosToClipB";
        this.cmdInfosToClipB.Size = new System.Drawing.Size(150, 24);
        this.cmdInfosToClipB.TabIndex = 0;
        this.cmdInfosToClipB.Text = "Copy to clipboard";
        this.cmdInfosToClipB.UseVisualStyleBackColor = true;
        // 
        // rtb
        // 
        this.rtb.AutoWordSelection = true;
        this.rtb.BackColor = System.Drawing.Color.White;
        this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb.HideSelection = false;
        this.rtb.Location = new System.Drawing.Point(0, 0);
        this.rtb.Name = "rtb";
        this.rtb.ReadOnly = true;
        this.rtb.Size = new System.Drawing.Size(641, 247);
        this.rtb.TabIndex = 4;
        this.rtb.Text = "";
        // 
        // TabPageServices
        // 
        this.TabPageServices.Controls.Add(this.lvProcServices);
        this.TabPageServices.Location = new System.Drawing.Point(4, 40);
        this.TabPageServices.Name = "TabPageServices";
        this.TabPageServices.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageServices.Size = new System.Drawing.Size(647, 282);
        this.TabPageServices.TabIndex = 6;
        this.TabPageServices.Text = "Services";
        this.TabPageServices.UseVisualStyleBackColor = true;
        // 
        // lvProcServices
        // 
        this.lvProcServices.AllowColumnReorder = true;
        this.lvProcServices.CatchErrors = false;
        this.lvProcServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader3, this.ColumnHeader7, this.ColumnHeader8, this.ColumnHeader9, this.ColumnHeader10, this.ColumnHeader19 });
        CConnection3.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection3.Snapshot = null;
        CConnection3.SnapshotFile = null;
        this.lvProcServices.ConnectionObj = CConnection3;
        this.lvProcServices.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcServices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcServices.FullRowSelect = true;
        this.lvProcServices.HideSelection = false;
        this.lvProcServices.IsConnected = false;
        this.lvProcServices.Location = new System.Drawing.Point(3, 3);
        this.lvProcServices.Name = "lvProcServices";
        this.lvProcServices.OverriddenDoubleBuffered = true;
        this.lvProcServices.ProcessId = 0;
        this.lvProcServices.ReorganizeColumns = true;
        this.lvProcServices.ShowAll = false;
        this.lvProcServices.ShowObjectDetailsOnDoubleClick = false;
        this.lvProcServices.Size = new System.Drawing.Size(641, 276);
        this.lvProcServices.TabIndex = 2;
        this.lvProcServices.UseCompatibleStateImageBehavior = false;
        this.lvProcServices.View = System.Windows.Forms.View.Details;
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
        // ColumnHeader19
        // 
        this.ColumnHeader19.Text = "ServiceType";
        this.ColumnHeader19.Width = 100;
        // 
        // TabPageNetwork
        // 
        this.TabPageNetwork.Controls.Add(this.lvProcNetwork);
        this.TabPageNetwork.Location = new System.Drawing.Point(4, 40);
        this.TabPageNetwork.Name = "TabPageNetwork";
        this.TabPageNetwork.Padding = new System.Windows.Forms.Padding(3);
        this.TabPageNetwork.Size = new System.Drawing.Size(647, 282);
        this.TabPageNetwork.TabIndex = 7;
        this.TabPageNetwork.Text = "Network";
        this.TabPageNetwork.UseVisualStyleBackColor = true;
        // 
        // lvProcNetwork
        // 
        this.lvProcNetwork.AllowColumnReorder = true;
        this.lvProcNetwork.CatchErrors = false;
        this.lvProcNetwork.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader49, this.ColumnHeader57, this.ColumnHeader58, this.ColumnHeader59 });
        CConnection4.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection4.Snapshot = null;
        CConnection4.SnapshotFile = null;
        this.lvProcNetwork.ConnectionObj = CConnection4;
        this.lvProcNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcNetwork.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcNetwork.FullRowSelect = true;
        this.lvProcNetwork.HideSelection = false;
        this.lvProcNetwork.IsConnected = false;
        this.lvProcNetwork.Location = new System.Drawing.Point(3, 3);
        this.lvProcNetwork.Name = "lvProcNetwork";
        this.lvProcNetwork.OverriddenDoubleBuffered = true;
        this.lvProcNetwork.ProcessId = default(int);
        this.lvProcNetwork.ReorganizeColumns = true;
        this.lvProcNetwork.ShowAllPid = false;
        this.lvProcNetwork.ShowConnectionsByProcessesGroup = false;
        this.lvProcNetwork.ShowObjectDetailsOnDoubleClick = true;
        this.lvProcNetwork.Size = new System.Drawing.Size(641, 276);
        this.lvProcNetwork.TabIndex = 21;
        this.lvProcNetwork.UseCompatibleStateImageBehavior = false;
        this.lvProcNetwork.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader49
        // 
        this.ColumnHeader49.Text = "Local";
        this.ColumnHeader49.Width = 210;
        // 
        // ColumnHeader57
        // 
        this.ColumnHeader57.Text = "Remote";
        this.ColumnHeader57.Width = 200;
        // 
        // ColumnHeader58
        // 
        this.ColumnHeader58.Text = "Protocol";
        // 
        // ColumnHeader59
        // 
        this.ColumnHeader59.Text = "State";
        this.ColumnHeader59.Width = 150;
        // 
        // TabPageString
        // 
        this.TabPageString.Controls.Add(this.SplitContainerStrings);
        this.TabPageString.Location = new System.Drawing.Point(4, 40);
        this.TabPageString.Name = "TabPageString";
        this.TabPageString.Size = new System.Drawing.Size(647, 282);
        this.TabPageString.TabIndex = 8;
        this.TabPageString.Text = "Strings";
        this.TabPageString.UseVisualStyleBackColor = true;
        // 
        // SplitContainerStrings
        // 
        this.SplitContainerStrings.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerStrings.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerStrings.Name = "SplitContainerStrings";
        this.SplitContainerStrings.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerStrings.Panel1
        // 
        this.SplitContainerStrings.Panel1.Controls.Add(this.lvProcString);
        // 
        // SplitContainerStrings.Panel2
        // 
        this.SplitContainerStrings.Panel2.Controls.Add(this.cmdProcSearchR);
        this.SplitContainerStrings.Panel2.Controls.Add(this.cmdProcSearchL);
        this.SplitContainerStrings.Panel2.Controls.Add(this.pgbString);
        this.SplitContainerStrings.Panel2.Controls.Add(this.Label28);
        this.SplitContainerStrings.Panel2.Controls.Add(this.txtSearchProcString);
        this.SplitContainerStrings.Panel2.Controls.Add(this.cmdProcStringSave);
        this.SplitContainerStrings.Panel2.Controls.Add(this.optProcStringMemory);
        this.SplitContainerStrings.Panel2.Controls.Add(this.optProcStringImage);
        this.SplitContainerStrings.Size = new System.Drawing.Size(647, 282);
        this.SplitContainerStrings.SplitterDistance = 242;
        this.SplitContainerStrings.TabIndex = 0;
        // 
        // lvProcString
        // 
        this.lvProcString.AllowColumnReorder = true;
        this.lvProcString.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader76, this.ColumnHeader77 });
        this.lvProcString.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcString.FullRowSelect = true;
        ListViewGroup1.Header = "Strings";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvProcString.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvProcString.HideSelection = false;
        this.lvProcString.Location = new System.Drawing.Point(0, 0);
        this.lvProcString.Name = "lvProcString";
        this.lvProcString.OverriddenDoubleBuffered = true;
        this.lvProcString.Size = new System.Drawing.Size(647, 242);
        this.lvProcString.TabIndex = 22;
        this.lvProcString.UseCompatibleStateImageBehavior = false;
        this.lvProcString.View = System.Windows.Forms.View.Details;
        this.lvProcString.VirtualMode = true;
        // 
        // ColumnHeader76
        // 
        this.ColumnHeader76.Text = "Position";
        this.ColumnHeader76.Width = 149;
        // 
        // ColumnHeader77
        // 
        this.ColumnHeader77.Text = "String";
        this.ColumnHeader77.Width = 447;
        // 
        // cmdProcSearchR
        // 
        this.cmdProcSearchR.Image = global::My.Resources.Resources.arrow_000_medium;
        this.cmdProcSearchR.Location = new System.Drawing.Point(499, 1);
        this.cmdProcSearchR.Name = "cmdProcSearchR";
        this.cmdProcSearchR.Size = new System.Drawing.Size(19, 23);
        this.cmdProcSearchR.TabIndex = 29;
        this.cmdProcSearchR.UseVisualStyleBackColor = true;
        // 
        // cmdProcSearchL
        // 
        this.cmdProcSearchL.Image = global::My.Resources.Resources.arrow_180_medium;
        this.cmdProcSearchL.Location = new System.Drawing.Point(476, 1);
        this.cmdProcSearchL.Name = "cmdProcSearchL";
        this.cmdProcSearchL.Size = new System.Drawing.Size(19, 23);
        this.cmdProcSearchL.TabIndex = 28;
        this.cmdProcSearchL.UseVisualStyleBackColor = true;
        // 
        // pgbString
        // 
        this.pgbString.Location = new System.Drawing.Point(248, 1);
        this.pgbString.Name = "pgbString";
        this.pgbString.Size = new System.Drawing.Size(102, 23);
        this.pgbString.TabIndex = 26;
        // 
        // Label28
        // 
        this.Label28.AutoSize = true;
        this.Label28.Location = new System.Drawing.Point(365, 6);
        this.Label28.Name = "Label28";
        this.Label28.Size = new System.Drawing.Size(41, 13);
        this.Label28.TabIndex = 16;
        this.Label28.Text = "Search";
        // 
        // txtSearchProcString
        // 
        this.txtSearchProcString.Location = new System.Drawing.Point(410, 2);
        this.txtSearchProcString.Name = "txtSearchProcString";
        this.txtSearchProcString.Size = new System.Drawing.Size(60, 22);
        this.txtSearchProcString.TabIndex = 27;
        // 
        // cmdProcStringSave
        // 
        this.cmdProcStringSave.Image = global::My.Resources.Resources.save16;
        this.cmdProcStringSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdProcStringSave.Location = new System.Drawing.Point(140, 1);
        this.cmdProcStringSave.Name = "cmdProcStringSave";
        this.cmdProcStringSave.Size = new System.Drawing.Size(91, 23);
        this.cmdProcStringSave.TabIndex = 25;
        this.cmdProcStringSave.Text = "Save...";
        this.cmdProcStringSave.UseVisualStyleBackColor = true;
        // 
        // optProcStringMemory
        // 
        this.optProcStringMemory.AutoSize = true;
        this.optProcStringMemory.Location = new System.Drawing.Point(63, 4);
        this.optProcStringMemory.Name = "optProcStringMemory";
        this.optProcStringMemory.Size = new System.Drawing.Size(66, 17);
        this.optProcStringMemory.TabIndex = 24;
        this.optProcStringMemory.Text = "Memory";
        this.optProcStringMemory.UseVisualStyleBackColor = true;
        // 
        // optProcStringImage
        // 
        this.optProcStringImage.AutoSize = true;
        this.optProcStringImage.Checked = true;
        this.optProcStringImage.Location = new System.Drawing.Point(3, 4);
        this.optProcStringImage.Name = "optProcStringImage";
        this.optProcStringImage.Size = new System.Drawing.Size(56, 17);
        this.optProcStringImage.TabIndex = 23;
        this.optProcStringImage.TabStop = true;
        this.optProcStringImage.Text = "Image";
        this.optProcStringImage.UseVisualStyleBackColor = true;
        // 
        // TabPageEnv
        // 
        this.TabPageEnv.Controls.Add(this.lvProcEnv);
        this.TabPageEnv.Location = new System.Drawing.Point(4, 40);
        this.TabPageEnv.Name = "TabPageEnv";
        this.TabPageEnv.Size = new System.Drawing.Size(647, 282);
        this.TabPageEnv.TabIndex = 9;
        this.TabPageEnv.Text = "Environment";
        this.TabPageEnv.UseVisualStyleBackColor = true;
        // 
        // lvProcEnv
        // 
        this.lvProcEnv.AllowColumnReorder = true;
        this.lvProcEnv.CatchErrors = false;
        this.lvProcEnv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader60, this.ColumnHeader61 });
        CConnection5.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection5.Snapshot = null;
        CConnection5.SnapshotFile = null;
        this.lvProcEnv.ConnectionObj = CConnection5;
        this.lvProcEnv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcEnv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcEnv.FullRowSelect = true;
        this.lvProcEnv.HideSelection = false;
        this.lvProcEnv.IsConnected = false;
        this.lvProcEnv.Location = new System.Drawing.Point(0, 0);
        this.lvProcEnv.Name = "lvProcEnv";
        this.lvProcEnv.OverriddenDoubleBuffered = true;
        // TODO: La génération de code pour 'Me.lvProcEnv.Peb' a échoué en raison de l'exception 'Type Primitive non valide : System.IntPtr. Si possible, utilisez CodeObjectCreateExpression à la place.'.
        this.lvProcEnv.ProcessId = 0;
        this.lvProcEnv.ReorganizeColumns = true;
        this.lvProcEnv.ShowObjectDetailsOnDoubleClick = true;
        this.lvProcEnv.Size = new System.Drawing.Size(647, 282);
        this.lvProcEnv.TabIndex = 30;
        this.lvProcEnv.UseCompatibleStateImageBehavior = false;
        this.lvProcEnv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader60
        // 
        this.ColumnHeader60.Text = "Variable";
        this.ColumnHeader60.Width = 169;
        // 
        // ColumnHeader61
        // 
        this.ColumnHeader61.Text = "Value";
        this.ColumnHeader61.Width = 431;
        // 
        // TabPageModules
        // 
        this.TabPageModules.Controls.Add(this.lvModules);
        this.TabPageModules.Location = new System.Drawing.Point(4, 40);
        this.TabPageModules.Name = "TabPageModules";
        this.TabPageModules.Size = new System.Drawing.Size(647, 282);
        this.TabPageModules.TabIndex = 10;
        this.TabPageModules.Text = "Modules";
        this.TabPageModules.UseVisualStyleBackColor = true;
        // 
        // lvModules
        // 
        this.lvModules.AllowColumnReorder = true;
        this.lvModules.CatchErrors = false;
        this.lvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader29, this.ColumnHeader43, this.ColumnHeader44, this.ColumnHeader45, this.ColumnHeader46, this.ColumnHeader1 });
        CConnection6.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection6.Snapshot = null;
        CConnection6.SnapshotFile = null;
        this.lvModules.ConnectionObj = CConnection6;
        this.lvModules.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvModules.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvModules.FullRowSelect = true;
        this.lvModules.HideSelection = false;
        this.lvModules.IsConnected = false;
        this.lvModules.Location = new System.Drawing.Point(0, 0);
        this.lvModules.Name = "lvModules";
        this.lvModules.OverriddenDoubleBuffered = true;
        this.lvModules.ProcessId = default(int);
        this.lvModules.ReorganizeColumns = true;
        this.lvModules.ShowObjectDetailsOnDoubleClick = true;
        this.lvModules.Size = new System.Drawing.Size(647, 282);
        this.lvModules.TabIndex = 31;
        this.lvModules.UseCompatibleStateImageBehavior = false;
        this.lvModules.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader29
        // 
        this.ColumnHeader29.Text = "Name";
        this.ColumnHeader29.Width = 90;
        // 
        // ColumnHeader43
        // 
        this.ColumnHeader43.DisplayIndex = 2;
        this.ColumnHeader43.Text = "Version";
        this.ColumnHeader43.Width = 85;
        // 
        // ColumnHeader44
        // 
        this.ColumnHeader44.DisplayIndex = 3;
        this.ColumnHeader44.Text = "Description";
        this.ColumnHeader44.Width = 210;
        // 
        // ColumnHeader45
        // 
        this.ColumnHeader45.DisplayIndex = 4;
        this.ColumnHeader45.Text = "CompanyName";
        this.ColumnHeader45.Width = 150;
        // 
        // ColumnHeader46
        // 
        this.ColumnHeader46.DisplayIndex = 5;
        this.ColumnHeader46.Text = "Path";
        this.ColumnHeader46.Width = 300;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.DisplayIndex = 1;
        this.ColumnHeader1.Text = "Address";
        this.ColumnHeader1.Width = 80;
        // 
        // TabPageThreads
        // 
        this.TabPageThreads.Controls.Add(this.lvThreads);
        this.TabPageThreads.Location = new System.Drawing.Point(4, 40);
        this.TabPageThreads.Name = "TabPageThreads";
        this.TabPageThreads.Size = new System.Drawing.Size(647, 282);
        this.TabPageThreads.TabIndex = 11;
        this.TabPageThreads.Text = "Threads";
        this.TabPageThreads.UseVisualStyleBackColor = true;
        // 
        // lvThreads
        // 
        this.lvThreads.AllowColumnReorder = true;
        this.lvThreads.CatchErrors = false;
        this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader32, this.ColumnHeader12, this.ColumnHeader34, this.ColumnHeader35, this.ColumnHeader36, this.ColumnHeader37, this.ColumnHeader38, this.ColumnHeader6, this.ColumnHeader11 });
        CConnection7.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection7.Snapshot = null;
        CConnection7.SnapshotFile = null;
        this.lvThreads.ConnectionObj = CConnection7;
        this.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvThreads.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvThreads.FullRowSelect = true;
        this.lvThreads.HideSelection = false;
        this.lvThreads.IsConnected = false;
        this.lvThreads.Location = new System.Drawing.Point(0, 0);
        this.lvThreads.Name = "lvThreads";
        this.lvThreads.OverriddenDoubleBuffered = true;
        this.lvThreads.ProcessId = default(int);
        this.lvThreads.ReorganizeColumns = true;
        this.lvThreads.ShowObjectDetailsOnDoubleClick = true;
        this.lvThreads.Size = new System.Drawing.Size(647, 282);
        this.lvThreads.TabIndex = 4;
        this.lvThreads.UseCompatibleStateImageBehavior = false;
        this.lvThreads.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader32
        // 
        this.ColumnHeader32.Text = "Id";
        // 
        // ColumnHeader12
        // 
        this.ColumnHeader12.Text = "ContextSwitchDelta";
        this.ColumnHeader12.Width = 118;
        // 
        // ColumnHeader34
        // 
        this.ColumnHeader34.Text = "Priority";
        this.ColumnHeader34.Width = 100;
        // 
        // ColumnHeader35
        // 
        this.ColumnHeader35.Text = "State";
        this.ColumnHeader35.Width = 70;
        // 
        // ColumnHeader36
        // 
        this.ColumnHeader36.Text = "WaitReason";
        this.ColumnHeader36.Width = 100;
        // 
        // ColumnHeader37
        // 
        this.ColumnHeader37.Text = "CreateTime";
        this.ColumnHeader37.Width = 119;
        // 
        // ColumnHeader38
        // 
        this.ColumnHeader38.Text = "TotalTime";
        this.ColumnHeader38.Width = 200;
        // 
        // ColumnHeader6
        // 
        this.ColumnHeader6.Text = "StartAddress";
        this.ColumnHeader6.Width = 100;
        // 
        // ColumnHeader11
        // 
        this.ColumnHeader11.Text = "ContextSwitchCount";
        this.ColumnHeader11.Width = 200;
        // 
        // TabPageWindows
        // 
        this.TabPageWindows.Controls.Add(this.lvWindows);
        this.TabPageWindows.Location = new System.Drawing.Point(4, 40);
        this.TabPageWindows.Name = "TabPageWindows";
        this.TabPageWindows.Size = new System.Drawing.Size(647, 282);
        this.TabPageWindows.TabIndex = 12;
        this.TabPageWindows.Text = "Windows";
        this.TabPageWindows.UseVisualStyleBackColor = true;
        // 
        // lvWindows
        // 
        this.lvWindows.AllowColumnReorder = true;
        this.lvWindows.CatchErrors = false;
        this.lvWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader30, this.ColumnHeader39, this.ColumnHeader40, this.ColumnHeader41, this.ColumnHeader42 });
        CConnection8.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection8.Snapshot = null;
        CConnection8.SnapshotFile = null;
        this.lvWindows.ConnectionObj = CConnection8;
        this.lvWindows.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvWindows.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvWindows.FullRowSelect = true;
        this.lvWindows.HideSelection = false;
        this.lvWindows.IsConnected = false;
        this.lvWindows.Location = new System.Drawing.Point(0, 0);
        this.lvWindows.Name = "lvWindows";
        this.lvWindows.OverriddenDoubleBuffered = true;
        this.lvWindows.ProcessId = default(int);
        this.lvWindows.ReorganizeColumns = true;
        this.lvWindows.ShowAllPid = false;
        this.lvWindows.ShowObjectDetailsOnDoubleClick = true;
        this.lvWindows.ShowUnNamed = false;
        this.lvWindows.Size = new System.Drawing.Size(647, 282);
        this.lvWindows.TabIndex = 33;
        this.lvWindows.UseCompatibleStateImageBehavior = false;
        this.lvWindows.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader30
        // 
        this.ColumnHeader30.Text = "Id";
        this.ColumnHeader30.Width = 100;
        // 
        // ColumnHeader39
        // 
        this.ColumnHeader39.Text = "Caption";
        this.ColumnHeader39.Width = 350;
        // 
        // ColumnHeader40
        // 
        this.ColumnHeader40.Text = "IsTask";
        // 
        // ColumnHeader41
        // 
        this.ColumnHeader41.Text = "Enabled";
        // 
        // ColumnHeader42
        // 
        this.ColumnHeader42.Text = "Visible";
        // 
        // TabPageHandles
        // 
        this.TabPageHandles.Controls.Add(this.lvHandles);
        this.TabPageHandles.Location = new System.Drawing.Point(4, 40);
        this.TabPageHandles.Name = "TabPageHandles";
        this.TabPageHandles.Size = new System.Drawing.Size(647, 282);
        this.TabPageHandles.TabIndex = 13;
        this.TabPageHandles.Text = "Handles";
        this.TabPageHandles.UseVisualStyleBackColor = true;
        // 
        // lvHandles
        // 
        this.lvHandles.AllowColumnReorder = true;
        this.lvHandles.CatchErrors = false;
        this.lvHandles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader24, this.ColumnHeader25, this.ColumnHeader26, this.ColumnHeader27, this.ColumnHeader28, this.ColumnHeader15 });
        CConnection9.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection9.Snapshot = null;
        CConnection9.SnapshotFile = null;
        this.lvHandles.ConnectionObj = CConnection9;
        this.lvHandles.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvHandles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvHandles.FullRowSelect = true;
        this.lvHandles.HideSelection = false;
        this.lvHandles.IsConnected = false;
        this.lvHandles.Location = new System.Drawing.Point(0, 0);
        this.lvHandles.Name = "lvHandles";
        this.lvHandles.OverriddenDoubleBuffered = true;
        this.lvHandles.ProcessId = default(int);
        this.lvHandles.ReorganizeColumns = true;
        this.lvHandles.ShowObjectDetailsOnDoubleClick = false;
        this.lvHandles.ShowUnnamed = false;
        this.lvHandles.Size = new System.Drawing.Size(647, 282);
        this.lvHandles.TabIndex = 34;
        this.lvHandles.UseCompatibleStateImageBehavior = false;
        this.lvHandles.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader24
        // 
        this.ColumnHeader24.Text = "Type";
        this.ColumnHeader24.Width = 80;
        // 
        // ColumnHeader25
        // 
        this.ColumnHeader25.Text = "Name";
        this.ColumnHeader25.Width = 400;
        // 
        // ColumnHeader26
        // 
        this.ColumnHeader26.Text = "HandleCount";
        this.ColumnHeader26.Width = 70;
        // 
        // ColumnHeader27
        // 
        this.ColumnHeader27.Text = "PointerCount";
        this.ColumnHeader27.Width = 70;
        // 
        // ColumnHeader28
        // 
        this.ColumnHeader28.Text = "ObjectCount";
        this.ColumnHeader28.Width = 70;
        // 
        // ColumnHeader15
        // 
        this.ColumnHeader15.Text = "Handle";
        this.ColumnHeader15.Width = 70;
        // 
        // TabPageLog
        // 
        this.TabPageLog.Controls.Add(this.SplitContainerLog);
        this.TabPageLog.Location = new System.Drawing.Point(4, 40);
        this.TabPageLog.Name = "TabPageLog";
        this.TabPageLog.Size = new System.Drawing.Size(647, 282);
        this.TabPageLog.TabIndex = 14;
        this.TabPageLog.Text = "Log";
        this.TabPageLog.UseVisualStyleBackColor = true;
        // 
        // SplitContainerLog
        // 
        this.SplitContainerLog.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerLog.IsSplitterFixed = true;
        this.SplitContainerLog.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerLog.Name = "SplitContainerLog";
        this.SplitContainerLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerLog.Panel1
        // 
        this.SplitContainerLog.Panel1.Controls.Add(this.cmdLogOptions);
        this.SplitContainerLog.Panel1.Controls.Add(this.cmdSave);
        this.SplitContainerLog.Panel1.Controls.Add(this.cmdClearLog);
        this.SplitContainerLog.Panel1.Controls.Add(this.chkLog);
        // 
        // SplitContainerLog.Panel2
        // 
        this.SplitContainerLog.Panel2.Controls.Add(this.lvLog);
        this.SplitContainerLog.Size = new System.Drawing.Size(647, 282);
        this.SplitContainerLog.SplitterDistance = 25;
        this.SplitContainerLog.TabIndex = 0;
        // 
        // cmdLogOptions
        // 
        this.cmdLogOptions.Location = new System.Drawing.Point(280, 1);
        this.cmdLogOptions.Name = "cmdLogOptions";
        this.cmdLogOptions.Size = new System.Drawing.Size(75, 23);
        this.cmdLogOptions.TabIndex = 5;
        this.cmdLogOptions.Text = "Options...";
        this.cmdLogOptions.UseVisualStyleBackColor = true;
        // 
        // cmdSave
        // 
        this.cmdSave.Image = global::My.Resources.Resources.save16;
        this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSave.Location = new System.Drawing.Point(181, 1);
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.Size = new System.Drawing.Size(93, 23);
        this.cmdSave.TabIndex = 2;
        this.cmdSave.Text = "     Save log...";
        this.cmdSave.UseVisualStyleBackColor = true;
        // 
        // cmdClearLog
        // 
        this.cmdClearLog.Location = new System.Drawing.Point(100, 1);
        this.cmdClearLog.Name = "cmdClearLog";
        this.cmdClearLog.Size = new System.Drawing.Size(75, 23);
        this.cmdClearLog.TabIndex = 1;
        this.cmdClearLog.Text = "Clear log";
        this.cmdClearLog.UseVisualStyleBackColor = true;
        // 
        // chkLog
        // 
        this.chkLog.AutoSize = true;
        this.chkLog.Location = new System.Drawing.Point(8, 4);
        this.chkLog.Name = "chkLog";
        this.chkLog.Size = new System.Drawing.Size(86, 17);
        this.chkLog.TabIndex = 0;
        this.chkLog.Text = "Activate log";
        this.chkLog.UseVisualStyleBackColor = true;
        // 
        // lvLog
        // 
        this.lvLog.AllowColumnReorder = true;
        this.lvLog.CaptureItems = asyncCallbackLogEnumerate.LogItemType.AllItems;
        this.lvLog.CatchErrors = false;
        this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2, this.ColumnHeader5, this.ColumnHeader4 });
        CConnection10.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection10.Snapshot = null;
        CConnection10.SnapshotFile = null;
        this.lvLog.ConnectionObj = CConnection10;
        this.lvLog.DisplayItems = asyncCallbackLogEnumerate.LogItemType.AllItems;
        this.lvLog.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvLog.FullRowSelect = true;
        this.lvLog.HideSelection = false;
        this.lvLog.IsConnected = false;
        this.lvLog.Location = new System.Drawing.Point(0, 0);
        this.lvLog.MultiSelect = false;
        this.lvLog.Name = "lvLog";
        this.lvLog.OverriddenDoubleBuffered = true;
        this.lvLog.ProcessId = 0;
        this.lvLog.ReorganizeColumns = true;
        this.lvLog.ShowObjectDetailsOnDoubleClick = true;
        this.lvLog.Size = new System.Drawing.Size(647, 253);
        this.lvLog.TabIndex = 24;
        this.lvLog.UseCompatibleStateImageBehavior = false;
        this.lvLog.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Date & Time";
        this.ColumnHeader2.Width = 172;
        // 
        // ColumnHeader5
        // 
        this.ColumnHeader5.Text = "Type";
        this.ColumnHeader5.Width = 69;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Description";
        this.ColumnHeader4.Width = 400;
        // 
        // TabPageHistory
        // 
        this.TabPageHistory.Controls.Add(this.containerHistory);
        this.TabPageHistory.Controls.Add(this.lstHistoryCat);
        this.TabPageHistory.Location = new System.Drawing.Point(4, 40);
        this.TabPageHistory.Name = "TabPageHistory";
        this.TabPageHistory.Size = new System.Drawing.Size(647, 282);
        this.TabPageHistory.TabIndex = 15;
        this.TabPageHistory.Text = "History";
        this.TabPageHistory.UseVisualStyleBackColor = true;
        // 
        // containerHistory
        // 
        this.containerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.containerHistory.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.containerHistory.IsSplitterFixed = true;
        this.containerHistory.Location = new System.Drawing.Point(208, 0);
        this.containerHistory.Name = "containerHistory";
        this.containerHistory.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // containerHistory.Panel1
        // 
        this.containerHistory.Panel1.Controls.Add(this.Label2);
        this.containerHistory.Size = new System.Drawing.Size(439, 282);
        this.containerHistory.SplitterDistance = 25;
        this.containerHistory.TabIndex = 1;
        // 
        // Label2
        // 
        this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Label2.Location = new System.Drawing.Point(0, 0);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(439, 25);
        this.Label2.TabIndex = 0;
        this.Label2.Text = "  Check items to see history graph";
        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lstHistoryCat
        // 
        this.lstHistoryCat.Dock = System.Windows.Forms.DockStyle.Left;
        this.lstHistoryCat.FormattingEnabled = true;
        this.lstHistoryCat.Items.AddRange(new object[] { "CpuUsage", "AverageCpuUsage", "KernelCpuTime", "UserCpuTime", "TotalCpuTime", "GdiObjects", "UserObjects", "WorkingSet", "PeakWorkingSet", "PageFaultCount", "PagefileUsage", "PeakPagefileUsage", "QuotaPeakPagedPoolUsage", "QuotaPagedPoolUsage", "QuotaPeakNonPagedPoolUsage", "QuotaNonPagedPoolUsage", "ReadOperationCount", "WriteOperationCount", "OtherOperationCount", "ReadTransferCount", "WriteTransferCount", "OtherTransferCount", "ReadOperationCountDelta", "WriteOperationCountDelta", "OtherOperationCountDelta", "ReadTransferCountDelta", "WriteTransferCountDelta", "OtherTransferCountDelta", "TotalIoDelta" });
        this.lstHistoryCat.Location = new System.Drawing.Point(0, 0);
        this.lstHistoryCat.Name = "lstHistoryCat";
        this.lstHistoryCat.Size = new System.Drawing.Size(208, 276);
        this.lstHistoryCat.TabIndex = 0;
        // 
        // TabPageHeaps
        // 
        this.TabPageHeaps.Controls.Add(this.cmdActivateHeapEnumeration);
        this.TabPageHeaps.Controls.Add(this.lvHeaps);
        this.TabPageHeaps.Location = new System.Drawing.Point(4, 40);
        this.TabPageHeaps.Name = "TabPageHeaps";
        this.TabPageHeaps.Size = new System.Drawing.Size(647, 282);
        this.TabPageHeaps.TabIndex = 16;
        this.TabPageHeaps.Text = "Heaps";
        this.TabPageHeaps.UseVisualStyleBackColor = true;
        // 
        // cmdActivateHeapEnumeration
        // 
        this.cmdActivateHeapEnumeration.Image = global::My.Resources.Resources.warning16;
        this.cmdActivateHeapEnumeration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdActivateHeapEnumeration.Location = new System.Drawing.Point(8, 39);
        this.cmdActivateHeapEnumeration.Name = "cmdActivateHeapEnumeration";
        this.cmdActivateHeapEnumeration.Size = new System.Drawing.Size(289, 23);
        this.cmdActivateHeapEnumeration.TabIndex = 16;
        this.cmdActivateHeapEnumeration.Text = "     You have to manually unlock heap enumeration";
        this.cmdActivateHeapEnumeration.UseVisualStyleBackColor = true;
        // 
        // lvHeaps
        // 
        this.lvHeaps.AllowColumnReorder = true;
        this.lvHeaps.CatchErrors = false;
        this.lvHeaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader16, this.ColumnHeader17, this.ColumnHeader18, this.ColumnHeader20, this.ColumnHeader14 });
        CConnection11.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection11.Snapshot = null;
        CConnection11.SnapshotFile = null;
        this.lvHeaps.ConnectionObj = CConnection11;
        this.lvHeaps.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvHeaps.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvHeaps.FullRowSelect = true;
        this.lvHeaps.HideSelection = false;
        this.lvHeaps.IsConnected = false;
        this.lvHeaps.Location = new System.Drawing.Point(0, 0);
        this.lvHeaps.Name = "lvHeaps";
        this.lvHeaps.OverriddenDoubleBuffered = true;
        this.lvHeaps.ProcessId = 0;
        this.lvHeaps.ReorganizeColumns = true;
        this.lvHeaps.ShowObjectDetailsOnDoubleClick = false;
        this.lvHeaps.Size = new System.Drawing.Size(647, 282);
        this.lvHeaps.TabIndex = 15;
        this.lvHeaps.UseCompatibleStateImageBehavior = false;
        this.lvHeaps.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader16
        // 
        this.ColumnHeader16.Text = "Address";
        this.ColumnHeader16.Width = 101;
        // 
        // ColumnHeader17
        // 
        this.ColumnHeader17.Text = "BlockCount";
        this.ColumnHeader17.Width = 101;
        // 
        // ColumnHeader18
        // 
        this.ColumnHeader18.Text = "MemCommitted";
        this.ColumnHeader18.Width = 117;
        // 
        // ColumnHeader20
        // 
        this.ColumnHeader20.Text = "MemAllocated";
        this.ColumnHeader20.Width = 100;
        // 
        // ColumnHeader14
        // 
        this.ColumnHeader14.Text = "Flags";
        this.ColumnHeader14.Width = 100;
        // 
        // cmdHideFindPanel
        // 
        this.cmdHideFindPanel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.cmdHideFindPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        this.cmdHideFindPanel.Location = new System.Drawing.Point(628, 3);
        this.cmdHideFindPanel.Name = "cmdHideFindPanel";
        this.cmdHideFindPanel.Size = new System.Drawing.Size(23, 20);
        this.cmdHideFindPanel.TabIndex = 18;
        this.cmdHideFindPanel.Text = "X";
        this.cmdHideFindPanel.UseVisualStyleBackColor = true;
        // 
        // chkFreeze
        // 
        this.chkFreeze.AutoSize = true;
        this.chkFreeze.Location = new System.Drawing.Point(479, 5);
        this.chkFreeze.Name = "chkFreeze";
        this.chkFreeze.Size = new System.Drawing.Size(136, 17);
        this.chkFreeze.TabIndex = 17;
        this.chkFreeze.Text = "Suspend refreshment";
        this.chkFreeze.UseVisualStyleBackColor = true;
        // 
        // lblSearchItemCaption
        // 
        this.lblSearchItemCaption.AutoSize = true;
        this.lblSearchItemCaption.Enabled = false;
        this.lblSearchItemCaption.Location = new System.Drawing.Point(6, 6);
        this.lblSearchItemCaption.Name = "lblSearchItemCaption";
        this.lblSearchItemCaption.Size = new System.Drawing.Size(66, 13);
        this.lblSearchItemCaption.TabIndex = 16;
        this.lblSearchItemCaption.Text = "Search item";
        // 
        // lblResCount
        // 
        this.lblResCount.AutoSize = true;
        this.lblResCount.Enabled = false;
        this.lblResCount.Location = new System.Drawing.Point(396, 6);
        this.lblResCount.Name = "lblResCount";
        this.lblResCount.Size = new System.Drawing.Size(56, 13);
        this.lblResCount.TabIndex = 15;
        this.lblResCount.Text = "0 result(s)";
        // 
        // txtSearch
        // 
        this.txtSearch.Enabled = false;
        this.txtSearch.Location = new System.Drawing.Point(75, 1);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Size = new System.Drawing.Size(312, 22);
        this.txtSearch.TabIndex = 14;
        // 
        // frmProcessInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(655, 356);
        this.Controls.Add(this.SplitContainer);
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MinimumSize = new System.Drawing.Size(660, 392);
        this.Name = "frmProcessInfo";
        this.Text = "Process informations";
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.Panel2.PerformLayout();
        this.SplitContainer.ResumeLayout(false);
        this.tabProcess.ResumeLayout(false);
        this.TabPageGeneral.ResumeLayout(false);
        this.GroupBox7.ResumeLayout(false);
        this.GroupBox6.ResumeLayout(false);
        this.SplitContainerOnlineInfo.Panel1.ResumeLayout(false);
        this.SplitContainerOnlineInfo.Panel1.PerformLayout();
        this.SplitContainerOnlineInfo.Panel2.ResumeLayout(false);
        this.SplitContainerOnlineInfo.ResumeLayout(false);
        this.GroupBoxProcessInfos.ResumeLayout(false);
        this.GroupBoxProcessInfos.PerformLayout();
        this.gpProcGeneralFile.ResumeLayout(false);
        this.gpProcGeneralFile.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctSmallIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pctBigIcon).EndInit();
        this.TabPageStats.ResumeLayout(false);
        this.GroupBox5.ResumeLayout(false);
        this.GroupBox5.PerformLayout();
        this.GroupBox4.ResumeLayout(false);
        this.GroupBox4.PerformLayout();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.TabPagePerf.ResumeLayout(false);
        this.splitPerformances.Panel1.ResumeLayout(false);
        this.splitPerformances.Panel2.ResumeLayout(false);
        this.splitPerformances.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.graphCPU).EndInit();
        this.splitPerformance2.Panel1.ResumeLayout(false);
        this.splitPerformance2.Panel2.ResumeLayout(false);
        this.splitPerformance2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.graphMemory).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.graphIO).EndInit();
        this.TabPageToken.ResumeLayout(false);
        this.tabProcessToken.ResumeLayout(false);
        this.tabProcessTokenPagePrivileges.ResumeLayout(false);
        this.TabPageMemory.ResumeLayout(false);
        this.TabPageInfos.ResumeLayout(false);
        this.SplitContainerInfoProcess.Panel1.ResumeLayout(false);
        this.SplitContainerInfoProcess.Panel2.ResumeLayout(false);
        this.SplitContainerInfoProcess.ResumeLayout(false);
        this.TabPageServices.ResumeLayout(false);
        this.TabPageNetwork.ResumeLayout(false);
        this.TabPageString.ResumeLayout(false);
        this.SplitContainerStrings.Panel1.ResumeLayout(false);
        this.SplitContainerStrings.Panel2.ResumeLayout(false);
        this.SplitContainerStrings.Panel2.PerformLayout();
        this.SplitContainerStrings.ResumeLayout(false);
        this.TabPageEnv.ResumeLayout(false);
        this.TabPageModules.ResumeLayout(false);
        this.TabPageThreads.ResumeLayout(false);
        this.TabPageWindows.ResumeLayout(false);
        this.TabPageHandles.ResumeLayout(false);
        this.TabPageLog.ResumeLayout(false);
        this.SplitContainerLog.Panel1.ResumeLayout(false);
        this.SplitContainerLog.Panel1.PerformLayout();
        this.SplitContainerLog.Panel2.ResumeLayout(false);
        this.SplitContainerLog.ResumeLayout(false);
        this.TabPageHistory.ResumeLayout(false);
        this.containerHistory.Panel1.ResumeLayout(false);
        this.containerHistory.ResumeLayout(false);
        this.TabPageHeaps.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.TabControl _tabProcess;

    internal System.Windows.Forms.TabControl tabProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabProcess != null)
            {
            }

            _tabProcess = value;
            if (_tabProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageGeneral;

    internal System.Windows.Forms.TabPage TabPageGeneral
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageGeneral;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageGeneral != null)
            {
            }

            _TabPageGeneral = value;
            if (_TabPageGeneral != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBoxProcessInfos;

    internal System.Windows.Forms.GroupBox GroupBoxProcessInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBoxProcessInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBoxProcessInfos != null)
            {
            }

            _GroupBoxProcessInfos = value;
            if (_GroupBoxProcessInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessUser;

    internal System.Windows.Forms.TextBox txtProcessUser
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessUser;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessUser != null)
            {
            }

            _txtProcessUser = value;
            if (_txtProcessUser != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label17;

    internal System.Windows.Forms.Label Label17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label17 != null)
            {
            }

            _Label17 = value;
            if (_Label17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessId;

    internal System.Windows.Forms.TextBox txtProcessId
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessId;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessId != null)
            {
            }

            _txtProcessId = value;
            if (_txtProcessId != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label16;

    internal System.Windows.Forms.Label Label16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label16 != null)
            {
            }

            _Label16 = value;
            if (_Label16 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpProcGeneralFile;

    internal System.Windows.Forms.GroupBox gpProcGeneralFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpProcGeneralFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpProcGeneralFile != null)
            {
            }

            _gpProcGeneralFile = value;
            if (_gpProcGeneralFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShowFileDetails;

    internal System.Windows.Forms.Button cmdShowFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShowFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShowFileDetails != null)
            {
            }

            _cmdShowFileDetails = value;
            if (_cmdShowFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShowFileProperties;

    internal System.Windows.Forms.Button cmdShowFileProperties
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShowFileProperties;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShowFileProperties != null)
            {
            }

            _cmdShowFileProperties = value;
            if (_cmdShowFileProperties != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdOpenDirectory;

    internal System.Windows.Forms.Button cmdOpenDirectory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpenDirectory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpenDirectory != null)
            {
            }

            _cmdOpenDirectory = value;
            if (_cmdOpenDirectory != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessPath;

    internal System.Windows.Forms.TextBox txtProcessPath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessPath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessPath != null)
            {
            }

            _txtProcessPath = value;
            if (_txtProcessPath != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label13;

    internal System.Windows.Forms.Label Label13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label13 != null)
            {
            }

            _Label13 = value;
            if (_Label13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtImageVersion;

    internal System.Windows.Forms.TextBox txtImageVersion
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtImageVersion;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtImageVersion != null)
            {
            }

            _txtImageVersion = value;
            if (_txtImageVersion != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label12;

    internal System.Windows.Forms.Label Label12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label12 != null)
            {
            }

            _Label12 = value;
            if (_Label12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCopyright;

    internal System.Windows.Forms.Label lblCopyright
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCopyright;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCopyright != null)
            {
            }

            _lblCopyright = value;
            if (_lblCopyright != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblDescription;

    internal System.Windows.Forms.Label lblDescription
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDescription;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblDescription != null)
            {
            }

            _lblDescription = value;
            if (_lblDescription != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctSmallIcon;

    internal System.Windows.Forms.PictureBox pctSmallIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctSmallIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctSmallIcon != null)
            {
            }

            _pctSmallIcon = value;
            if (_pctSmallIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctBigIcon;

    internal System.Windows.Forms.PictureBox pctBigIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctBigIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctBigIcon != null)
            {
            }

            _pctBigIcon = value;
            if (_pctBigIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageStats;

    internal System.Windows.Forms.TabPage TabPageStats
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageStats;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageStats != null)
            {
            }

            _TabPageStats = value;
            if (_TabPageStats != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox5;

    internal System.Windows.Forms.GroupBox GroupBox5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox5 != null)
            {
            }

            _GroupBox5 = value;
            if (_GroupBox5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblUserObjectsCount;

    internal System.Windows.Forms.Label lblUserObjectsCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUserObjectsCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUserObjectsCount != null)
            {
            }

            _lblUserObjectsCount = value;
            if (_lblUserObjectsCount != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label37;

    internal System.Windows.Forms.Label Label37
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label37;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label37 != null)
            {
            }

            _Label37 = value;
            if (_Label37 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblGDIcount;

    internal System.Windows.Forms.Label lblGDIcount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblGDIcount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblGDIcount != null)
            {
            }

            _lblGDIcount = value;
            if (_lblGDIcount != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lbl789;

    internal System.Windows.Forms.Label lbl789
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lbl789;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lbl789 != null)
            {
            }

            _lbl789 = value;
            if (_lbl789 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblHandles;

    internal System.Windows.Forms.Label lblHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblHandles != null)
            {
            }

            _lblHandles = value;
            if (_lblHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label53;

    internal System.Windows.Forms.Label Label53
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label53;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label53 != null)
            {
            }

            _Label53 = value;
            if (_Label53 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox4;

    internal System.Windows.Forms.GroupBox GroupBox4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox4 != null)
            {
            }

            _GroupBox4 = value;
            if (_GroupBox4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcOtherBytes;

    internal System.Windows.Forms.Label lblProcOtherBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcOtherBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcOtherBytes != null)
            {
            }

            _lblProcOtherBytes = value;
            if (_lblProcOtherBytes != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label23;

    internal System.Windows.Forms.Label Label23
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label23;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label23 != null)
            {
            }

            _Label23 = value;
            if (_Label23 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcOther;

    internal System.Windows.Forms.Label lblProcOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcOther != null)
            {
            }

            _lblProcOther = value;
            if (_lblProcOther != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label30;

    internal System.Windows.Forms.Label Label30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label30 != null)
            {
            }

            _Label30 = value;
            if (_Label30 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcWriteBytes;

    internal System.Windows.Forms.Label lblProcWriteBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcWriteBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcWriteBytes != null)
            {
            }

            _lblProcWriteBytes = value;
            if (_lblProcWriteBytes != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label36;

    internal System.Windows.Forms.Label Label36
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label36;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label36 != null)
            {
            }

            _Label36 = value;
            if (_Label36 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcWrites;

    internal System.Windows.Forms.Label lblProcWrites
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcWrites;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcWrites != null)
            {
            }

            _lblProcWrites = value;
            if (_lblProcWrites != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label38;

    internal System.Windows.Forms.Label Label38
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label38;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label38 != null)
            {
            }

            _Label38 = value;
            if (_Label38 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcReadBytes;

    internal System.Windows.Forms.Label lblProcReadBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcReadBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcReadBytes != null)
            {
            }

            _lblProcReadBytes = value;
            if (_lblProcReadBytes != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label40;

    internal System.Windows.Forms.Label Label40
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label40;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label40 != null)
            {
            }

            _Label40 = value;
            if (_Label40 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcReads;

    internal System.Windows.Forms.Label lblProcReads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcReads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcReads != null)
            {
            }

            _lblProcReads = value;
            if (_lblProcReads != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label42;

    internal System.Windows.Forms.Label Label42
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label42;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label42 != null)
            {
            }

            _Label42 = value;
            if (_Label42 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox3;

    internal System.Windows.Forms.GroupBox GroupBox3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox3 != null)
            {
            }

            _GroupBox3 = value;
            if (_GroupBox3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblQuotaNPP;

    internal System.Windows.Forms.Label lblQuotaNPP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblQuotaNPP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblQuotaNPP != null)
            {
            }

            _lblQuotaNPP = value;
            if (_lblQuotaNPP != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label21;

    internal System.Windows.Forms.Label Label21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label21 != null)
            {
            }

            _Label21 = value;
            if (_Label21 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblQuotaPNPP;

    internal System.Windows.Forms.Label lblQuotaPNPP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblQuotaPNPP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblQuotaPNPP != null)
            {
            }

            _lblQuotaPNPP = value;
            if (_lblQuotaPNPP != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label26;

    internal System.Windows.Forms.Label Label26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label26 != null)
            {
            }

            _Label26 = value;
            if (_Label26 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblQuotaPP;

    internal System.Windows.Forms.Label lblQuotaPP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblQuotaPP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblQuotaPP != null)
            {
            }

            _lblQuotaPP = value;
            if (_lblQuotaPP != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label29;

    internal System.Windows.Forms.Label Label29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label29 != null)
            {
            }

            _Label29 = value;
            if (_Label29 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblQuotaPPP;

    internal System.Windows.Forms.Label lblQuotaPPP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblQuotaPPP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblQuotaPPP != null)
            {
            }

            _lblQuotaPPP = value;
            if (_lblQuotaPPP != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label32;

    internal System.Windows.Forms.Label Label32
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label32;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label32 != null)
            {
            }

            _Label32 = value;
            if (_Label32 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPageFaults;

    internal System.Windows.Forms.Label lblPageFaults
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPageFaults;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPageFaults != null)
            {
            }

            _lblPageFaults = value;
            if (_lblPageFaults != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label31;

    internal System.Windows.Forms.Label Label31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label31 != null)
            {
            }

            _Label31 = value;
            if (_Label31 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPeakPageFileUsage;

    internal System.Windows.Forms.Label lblPeakPageFileUsage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPeakPageFileUsage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPeakPageFileUsage != null)
            {
            }

            _lblPeakPageFileUsage = value;
            if (_lblPeakPageFileUsage != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label33;

    internal System.Windows.Forms.Label Label33
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label33;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label33 != null)
            {
            }

            _Label33 = value;
            if (_Label33 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPageFileUsage;

    internal System.Windows.Forms.Label lblPageFileUsage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPageFileUsage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPageFileUsage != null)
            {
            }

            _lblPageFileUsage = value;
            if (_lblPageFileUsage != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label35;

    internal System.Windows.Forms.Label Label35
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label35;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label35 != null)
            {
            }

            _Label35 = value;
            if (_Label35 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPeakWorkingSet;

    internal System.Windows.Forms.Label lblPeakWorkingSet
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPeakWorkingSet;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPeakWorkingSet != null)
            {
            }

            _lblPeakWorkingSet = value;
            if (_lblPeakWorkingSet != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label25;

    internal System.Windows.Forms.Label Label25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label25 != null)
            {
            }

            _Label25 = value;
            if (_Label25 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblWorkingSet;

    internal System.Windows.Forms.Label lblWorkingSet
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWorkingSet;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWorkingSet != null)
            {
            }

            _lblWorkingSet = value;
            if (_lblWorkingSet != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label27;

    internal System.Windows.Forms.Label Label27
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label27;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label27 != null)
            {
            }

            _Label27 = value;
            if (_Label27 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox2;

    internal System.Windows.Forms.GroupBox GroupBox2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox2 != null)
            {
            }

            _GroupBox2 = value;
            if (_GroupBox2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblTotalTime;

    internal System.Windows.Forms.Label lblTotalTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotalTime != null)
            {
            }

            _lblTotalTime = value;
            if (_lblTotalTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label24;

    internal System.Windows.Forms.Label Label24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label24 != null)
            {
            }

            _Label24 = value;
            if (_Label24 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblUserTime;

    internal System.Windows.Forms.Label lblUserTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUserTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUserTime != null)
            {
            }

            _lblUserTime = value;
            if (_lblUserTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label22;

    internal System.Windows.Forms.Label Label22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label22 != null)
            {
            }

            _Label22 = value;
            if (_Label22 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKernelTime;

    internal System.Windows.Forms.Label lblKernelTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKernelTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKernelTime != null)
            {
            }

            _lblKernelTime = value;
            if (_lblKernelTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label20;

    internal System.Windows.Forms.Label Label20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label20 != null)
            {
            }

            _Label20 = value;
            if (_Label20 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPriority;

    internal System.Windows.Forms.Label lblPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPriority != null)
            {
            }

            _lblPriority = value;
            if (_lblPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label18;

    internal System.Windows.Forms.Label Label18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label18 != null)
            {
            }

            _Label18 = value;
            if (_Label18 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPagePerf;

    internal System.Windows.Forms.TabPage TabPagePerf
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPagePerf;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPagePerf != null)
            {
            }

            _TabPagePerf = value;
            if (_TabPagePerf != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitPerformances;

    internal System.Windows.Forms.SplitContainer splitPerformances
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitPerformances;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitPerformances != null)
            {
            }

            _splitPerformances = value;
            if (_splitPerformances != null)
            {
            }
        }
    }

    private Graph2 _graphCPU;

    internal Graph2 graphCPU
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _graphCPU;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_graphCPU != null)
            {
            }

            _graphCPU = value;
            if (_graphCPU != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _splitPerformance2;

    internal System.Windows.Forms.SplitContainer splitPerformance2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitPerformance2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitPerformance2 != null)
            {
            }

            _splitPerformance2 = value;
            if (_splitPerformance2 != null)
            {
            }
        }
    }

    private Graph2 _graphMemory;

    internal Graph2 graphMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _graphMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_graphMemory != null)
            {
            }

            _graphMemory = value;
            if (_graphMemory != null)
            {
            }
        }
    }

    private Graph2 _graphIO;

    internal Graph2 graphIO
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _graphIO;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_graphIO != null)
            {
            }

            _graphIO = value;
            if (_graphIO != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageToken;

    internal System.Windows.Forms.TabPage TabPageToken
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageToken;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageToken != null)
            {
            }

            _TabPageToken = value;
            if (_TabPageToken != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabControl _tabProcessToken;

    internal System.Windows.Forms.TabControl tabProcessToken
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabProcessToken;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabProcessToken != null)
            {
            }

            _tabProcessToken = value;
            if (_tabProcessToken != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _tabProcessTokenPagePrivileges;

    internal System.Windows.Forms.TabPage tabProcessTokenPagePrivileges
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabProcessTokenPagePrivileges;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabProcessTokenPagePrivileges != null)
            {
            }

            _tabProcessTokenPagePrivileges = value;
            if (_tabProcessTokenPagePrivileges != null)
            {
            }
        }
    }

    private privilegeList _lvPrivileges;

    internal privilegeList lvPrivileges
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvPrivileges;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvPrivileges != null)
            {
            }

            _lvPrivileges = value;
            if (_lvPrivileges != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader51;

    internal System.Windows.Forms.ColumnHeader ColumnHeader51
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader51;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader51 != null)
            {
            }

            _ColumnHeader51 = value;
            if (_ColumnHeader51 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader52;

    internal System.Windows.Forms.ColumnHeader ColumnHeader52
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader52;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader52 != null)
            {
            }

            _ColumnHeader52 = value;
            if (_ColumnHeader52 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageMemory;

    internal System.Windows.Forms.TabPage TabPageMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageMemory != null)
            {
            }

            _TabPageMemory = value;
            if (_TabPageMemory != null)
            {
            }
        }
    }

    private memoryList _lvProcMem;

    internal memoryList lvProcMem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcMem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcMem != null)
            {
            }

            _lvProcMem = value;
            if (_lvProcMem != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader53;

    internal System.Windows.Forms.ColumnHeader ColumnHeader53
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader53;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader53 != null)
            {
            }

            _ColumnHeader53 = value;
            if (_ColumnHeader53 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader54;

    internal System.Windows.Forms.ColumnHeader ColumnHeader54
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader54;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader54 != null)
            {
            }

            _ColumnHeader54 = value;
            if (_ColumnHeader54 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader55;

    internal System.Windows.Forms.ColumnHeader ColumnHeader55
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader55;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader55 != null)
            {
            }

            _ColumnHeader55 = value;
            if (_ColumnHeader55 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader56;

    internal System.Windows.Forms.ColumnHeader ColumnHeader56
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader56;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader56 != null)
            {
            }

            _ColumnHeader56 = value;
            if (_ColumnHeader56 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageInfos;

    internal System.Windows.Forms.TabPage TabPageInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageInfos != null)
            {
            }

            _TabPageInfos = value;
            if (_TabPageInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerInfoProcess;

    internal System.Windows.Forms.SplitContainer SplitContainerInfoProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerInfoProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerInfoProcess != null)
            {
            }

            _SplitContainerInfoProcess = value;
            if (_SplitContainerInfoProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdInfosToClipB;

    internal System.Windows.Forms.Button cmdInfosToClipB
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdInfosToClipB;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdInfosToClipB != null)
            {
            }

            _cmdInfosToClipB = value;
            if (_cmdInfosToClipB != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtb;

    internal System.Windows.Forms.RichTextBox rtb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtb != null)
            {
            }

            _rtb = value;
            if (_rtb != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageServices;

    internal System.Windows.Forms.TabPage TabPageServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageServices != null)
            {
            }

            _TabPageServices = value;
            if (_TabPageServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageNetwork;

    internal System.Windows.Forms.TabPage TabPageNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageNetwork != null)
            {
            }

            _TabPageNetwork = value;
            if (_TabPageNetwork != null)
            {
            }
        }
    }

    private networkList _lvProcNetwork;

    internal networkList lvProcNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcNetwork != null)
            {
            }

            _lvProcNetwork = value;
            if (_lvProcNetwork != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader57;

    internal System.Windows.Forms.ColumnHeader ColumnHeader57
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader57;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader57 != null)
            {
            }

            _ColumnHeader57 = value;
            if (_ColumnHeader57 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader58;

    internal System.Windows.Forms.ColumnHeader ColumnHeader58
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader58;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader58 != null)
            {
            }

            _ColumnHeader58 = value;
            if (_ColumnHeader58 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader59;

    internal System.Windows.Forms.ColumnHeader ColumnHeader59
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader59;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader59 != null)
            {
            }

            _ColumnHeader59 = value;
            if (_ColumnHeader59 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageString;

    internal System.Windows.Forms.TabPage TabPageString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageString != null)
            {
            }

            _TabPageString = value;
            if (_TabPageString != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerStrings;

    internal System.Windows.Forms.SplitContainer SplitContainerStrings
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerStrings;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerStrings != null)
            {
            }

            _SplitContainerStrings = value;
            if (_SplitContainerStrings != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvProcString;

    internal DoubleBufferedLV lvProcString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcString != null)
            {
            }

            _lvProcString = value;
            if (_lvProcString != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader76;

    internal System.Windows.Forms.ColumnHeader ColumnHeader76
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader76;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader76 != null)
            {
            }

            _ColumnHeader76 = value;
            if (_ColumnHeader76 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader77;

    internal System.Windows.Forms.ColumnHeader ColumnHeader77
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader77;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader77 != null)
            {
            }

            _ColumnHeader77 = value;
            if (_ColumnHeader77 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdProcSearchR;

    internal System.Windows.Forms.Button cmdProcSearchR
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdProcSearchR;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdProcSearchR != null)
            {
            }

            _cmdProcSearchR = value;
            if (_cmdProcSearchR != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdProcSearchL;

    internal System.Windows.Forms.Button cmdProcSearchL
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdProcSearchL;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdProcSearchL != null)
            {
            }

            _cmdProcSearchL = value;
            if (_cmdProcSearchL != null)
            {
            }
        }
    }

    private System.Windows.Forms.ProgressBar _pgbString;

    internal System.Windows.Forms.ProgressBar pgbString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pgbString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pgbString != null)
            {
            }

            _pgbString = value;
            if (_pgbString != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label28;

    internal System.Windows.Forms.Label Label28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label28 != null)
            {
            }

            _Label28 = value;
            if (_Label28 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSearchProcString;

    internal System.Windows.Forms.TextBox txtSearchProcString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearchProcString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearchProcString != null)
            {
            }

            _txtSearchProcString = value;
            if (_txtSearchProcString != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdProcStringSave;

    internal System.Windows.Forms.Button cmdProcStringSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdProcStringSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdProcStringSave != null)
            {
            }

            _cmdProcStringSave = value;
            if (_cmdProcStringSave != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optProcStringMemory;

    internal System.Windows.Forms.RadioButton optProcStringMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optProcStringMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optProcStringMemory != null)
            {
            }

            _optProcStringMemory = value;
            if (_optProcStringMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optProcStringImage;

    internal System.Windows.Forms.RadioButton optProcStringImage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optProcStringImage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optProcStringImage != null)
            {
            }

            _optProcStringImage = value;
            if (_optProcStringImage != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageEnv;

    internal System.Windows.Forms.TabPage TabPageEnv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageEnv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageEnv != null)
            {
            }

            _TabPageEnv = value;
            if (_TabPageEnv != null)
            {
            }
        }
    }

    private envVariableList _lvProcEnv;

    internal envVariableList lvProcEnv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcEnv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcEnv != null)
            {
            }

            _lvProcEnv = value;
            if (_lvProcEnv != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader60;

    internal System.Windows.Forms.ColumnHeader ColumnHeader60
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader60;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader60 != null)
            {
            }

            _ColumnHeader60 = value;
            if (_ColumnHeader60 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader61;

    internal System.Windows.Forms.ColumnHeader ColumnHeader61
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader61;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader61 != null)
            {
            }

            _ColumnHeader61 = value;
            if (_ColumnHeader61 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerProcPerf;

    internal System.Windows.Forms.Timer timerProcPerf
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerProcPerf;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerProcPerf != null)
            {
            }

            _timerProcPerf = value;
            if (_timerProcPerf != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageModules;

    internal System.Windows.Forms.TabPage TabPageModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageModules != null)
            {
            }

            _TabPageModules = value;
            if (_TabPageModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageThreads;

    internal System.Windows.Forms.TabPage TabPageThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageThreads != null)
            {
            }

            _TabPageThreads = value;
            if (_TabPageThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageWindows;

    internal System.Windows.Forms.TabPage TabPageWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageWindows != null)
            {
            }

            _TabPageWindows = value;
            if (_TabPageWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageHandles;

    internal System.Windows.Forms.TabPage TabPageHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageHandles != null)
            {
            }

            _TabPageHandles = value;
            if (_TabPageHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox6;

    internal System.Windows.Forms.GroupBox GroupBox6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox6 != null)
            {
            }

            _GroupBox6 = value;
            if (_GroupBox6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerOnlineInfo;

    internal System.Windows.Forms.SplitContainer SplitContainerOnlineInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerOnlineInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerOnlineInfo != null)
            {
            }

            _SplitContainerOnlineInfo = value;
            if (_SplitContainerOnlineInfo != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblSecurityRisk;

    internal System.Windows.Forms.Label lblSecurityRisk
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblSecurityRisk;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblSecurityRisk != null)
            {
            }

            _lblSecurityRisk = value;
            if (_lblSecurityRisk != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGetOnlineInfos;

    internal System.Windows.Forms.Button cmdGetOnlineInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGetOnlineInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGetOnlineInfos != null)
            {
            }

            _cmdGetOnlineInfos = value;
            if (_cmdGetOnlineInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtbOnlineInfos;

    internal System.Windows.Forms.RichTextBox rtbOnlineInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtbOnlineInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtbOnlineInfos != null)
            {
            }

            _rtbOnlineInfos = value;
            if (_rtbOnlineInfos != null)
            {
            }
        }
    }

    private moduleList _lvModules;

    internal moduleList lvModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvModules != null)
            {
            }

            _lvModules = value;
            if (_lvModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader29;

    internal System.Windows.Forms.ColumnHeader ColumnHeader29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader29 != null)
            {
            }

            _ColumnHeader29 = value;
            if (_ColumnHeader29 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader43;

    internal System.Windows.Forms.ColumnHeader ColumnHeader43
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader43;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader43 != null)
            {
            }

            _ColumnHeader43 = value;
            if (_ColumnHeader43 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader44;

    internal System.Windows.Forms.ColumnHeader ColumnHeader44
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader44;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader44 != null)
            {
            }

            _ColumnHeader44 = value;
            if (_ColumnHeader44 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader45;

    internal System.Windows.Forms.ColumnHeader ColumnHeader45
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader45;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader45 != null)
            {
            }

            _ColumnHeader45 = value;
            if (_ColumnHeader45 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader46;

    internal System.Windows.Forms.ColumnHeader ColumnHeader46
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader46;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader46 != null)
            {
            }

            _ColumnHeader46 = value;
            if (_ColumnHeader46 != null)
            {
            }
        }
    }

    private windowList _lvWindows;

    internal windowList lvWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvWindows != null)
            {
            }

            _lvWindows = value;
            if (_lvWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader30;

    internal System.Windows.Forms.ColumnHeader ColumnHeader30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader30 != null)
            {
            }

            _ColumnHeader30 = value;
            if (_ColumnHeader30 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader39;

    internal System.Windows.Forms.ColumnHeader ColumnHeader39
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader39;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader39 != null)
            {
            }

            _ColumnHeader39 = value;
            if (_ColumnHeader39 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader40;

    internal System.Windows.Forms.ColumnHeader ColumnHeader40
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader40;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader40 != null)
            {
            }

            _ColumnHeader40 = value;
            if (_ColumnHeader40 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader41;

    internal System.Windows.Forms.ColumnHeader ColumnHeader41
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader41;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader41 != null)
            {
            }

            _ColumnHeader41 = value;
            if (_ColumnHeader41 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader42;

    internal System.Windows.Forms.ColumnHeader ColumnHeader42
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader42;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader42 != null)
            {
            }

            _ColumnHeader42 = value;
            if (_ColumnHeader42 != null)
            {
            }
        }
    }

    private handleList _lvHandles;

    internal handleList lvHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvHandles != null)
            {
            }

            _lvHandles = value;
            if (_lvHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader24;

    internal System.Windows.Forms.ColumnHeader ColumnHeader24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader24 != null)
            {
            }

            _ColumnHeader24 = value;
            if (_ColumnHeader24 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader25;

    internal System.Windows.Forms.ColumnHeader ColumnHeader25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader25 != null)
            {
            }

            _ColumnHeader25 = value;
            if (_ColumnHeader25 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader26;

    internal System.Windows.Forms.ColumnHeader ColumnHeader26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader26 != null)
            {
            }

            _ColumnHeader26 = value;
            if (_ColumnHeader26 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader27;

    internal System.Windows.Forms.ColumnHeader ColumnHeader27
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader27;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader27 != null)
            {
            }

            _ColumnHeader27 = value;
            if (_ColumnHeader27 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader28;

    internal System.Windows.Forms.ColumnHeader ColumnHeader28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader28 != null)
            {
            }

            _ColumnHeader28 = value;
            if (_ColumnHeader28 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader15;

    internal System.Windows.Forms.ColumnHeader ColumnHeader15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader15 != null)
            {
            }

            _ColumnHeader15 = value;
            if (_ColumnHeader15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader1;

    internal System.Windows.Forms.ColumnHeader ColumnHeader1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader1 != null)
            {
            }

            _ColumnHeader1 = value;
            if (_ColumnHeader1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtCommandLine;

    internal System.Windows.Forms.TextBox txtCommandLine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtCommandLine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtCommandLine != null)
            {
            }

            _txtCommandLine = value;
            if (_txtCommandLine != null)
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

    private System.Windows.Forms.Label _lblAverageCPUusage;

    internal System.Windows.Forms.Label lblAverageCPUusage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAverageCPUusage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblAverageCPUusage != null)
            {
            }

            _lblAverageCPUusage = value;
            if (_lblAverageCPUusage != null)
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

    private serviceList _lvProcServices;

    internal serviceList lvProcServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcServices != null)
            {
            }

            _lvProcServices = value;
            if (_lvProcServices != null)
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

    private System.Windows.Forms.TabPage _TabPageLog;

    internal System.Windows.Forms.TabPage TabPageLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageLog != null)
            {
            }

            _TabPageLog = value;
            if (_TabPageLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerLog;

    internal System.Windows.Forms.SplitContainer SplitContainerLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerLog != null)
            {
            }

            _SplitContainerLog = value;
            if (_SplitContainerLog != null)
            {
            }
        }
    }

    private logList _lvLog;

    internal logList lvLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvLog != null)
            {
            }

            _lvLog = value;
            if (_lvLog != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader4;

    internal System.Windows.Forms.ColumnHeader ColumnHeader4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader4 != null)
            {
            }

            _ColumnHeader4 = value;
            if (_ColumnHeader4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkLog;

    internal System.Windows.Forms.CheckBox chkLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkLog != null)
            {
            }

            _chkLog = value;
            if (_chkLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerLog;

    internal System.Windows.Forms.Timer timerLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerLog != null)
            {
            }

            _timerLog = value;
            if (_timerLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSave;

    internal System.Windows.Forms.Button cmdSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSave != null)
            {
            }

            _cmdSave = value;
            if (_cmdSave != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdClearLog;

    internal System.Windows.Forms.Button cmdClearLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdClearLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdClearLog != null)
            {
            }

            _cmdClearLog = value;
            if (_cmdClearLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdLogOptions;

    internal System.Windows.Forms.Button cmdLogOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdLogOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdLogOptions != null)
            {
            }

            _cmdLogOptions = value;
            if (_cmdLogOptions != null)
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

    private System.Windows.Forms.TabPage _TabPageHistory;

    internal System.Windows.Forms.TabPage TabPageHistory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageHistory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageHistory != null)
            {
            }

            _TabPageHistory = value;
            if (_TabPageHistory != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckedListBox _lstHistoryCat;

    internal System.Windows.Forms.CheckedListBox lstHistoryCat
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstHistoryCat;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstHistoryCat != null)
            {
            }

            _lstHistoryCat = value;
            if (_lstHistoryCat != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _containerHistory;

    internal System.Windows.Forms.SplitContainer containerHistory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _containerHistory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_containerHistory != null)
            {
            }

            _containerHistory = value;
            if (_containerHistory != null)
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

    private System.Windows.Forms.Button _cmdRefresh;

    internal System.Windows.Forms.Button cmdRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdRefresh != null)
            {
            }

            _cmdRefresh = value;
            if (_cmdRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox7;

    internal System.Windows.Forms.GroupBox GroupBox7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox7 != null)
            {
            }

            _GroupBox7 = value;
            if (_GroupBox7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdKill;

    internal System.Windows.Forms.Button cmdKill
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdKill;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdKill != null)
            {
            }

            _cmdKill = value;
            if (_cmdKill != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSet;

    internal System.Windows.Forms.Button cmdSet
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSet;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSet != null)
            {
            }

            _cmdSet = value;
            if (_cmdSet != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbPriority;

    internal System.Windows.Forms.ComboBox cbPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbPriority != null)
            {
            }

            _cbPriority = value;
            if (_cbPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdAffinity;

    internal System.Windows.Forms.Button cmdAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdAffinity != null)
            {
            }

            _cmdAffinity = value;
            if (_cmdAffinity != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdPause;

    internal System.Windows.Forms.Button cmdPause
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdPause;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdPause != null)
            {
            }

            _cmdPause = value;
            if (_cmdPause != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdResume;

    internal System.Windows.Forms.Button cmdResume
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdResume;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdResume != null)
            {
            }

            _cmdResume = value;
            if (_cmdResume != null)
            {
            }
        }
    }

    private threadList _lvThreads;

    internal threadList lvThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvThreads != null)
            {
            }

            _lvThreads = value;
            if (_lvThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader32;

    internal System.Windows.Forms.ColumnHeader ColumnHeader32
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader32;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader32 != null)
            {
            }

            _ColumnHeader32 = value;
            if (_ColumnHeader32 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader34;

    internal System.Windows.Forms.ColumnHeader ColumnHeader34
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader34;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader34 != null)
            {
            }

            _ColumnHeader34 = value;
            if (_ColumnHeader34 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader35;

    internal System.Windows.Forms.ColumnHeader ColumnHeader35
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader35;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader35 != null)
            {
            }

            _ColumnHeader35 = value;
            if (_ColumnHeader35 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader36;

    internal System.Windows.Forms.ColumnHeader ColumnHeader36
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader36;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader36 != null)
            {
            }

            _ColumnHeader36 = value;
            if (_ColumnHeader36 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader37;

    internal System.Windows.Forms.ColumnHeader ColumnHeader37
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader37;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader37 != null)
            {
            }

            _ColumnHeader37 = value;
            if (_ColumnHeader37 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader38;

    internal System.Windows.Forms.ColumnHeader ColumnHeader38
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader38;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader38 != null)
            {
            }

            _ColumnHeader38 = value;
            if (_ColumnHeader38 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader6;

    internal System.Windows.Forms.ColumnHeader ColumnHeader6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader6 != null)
            {
            }

            _ColumnHeader6 = value;
            if (_ColumnHeader6 != null)
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

    private System.Windows.Forms.Label _lblOthersBD;

    internal System.Windows.Forms.Label lblOthersBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOthersBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOthersBD != null)
            {
            }

            _lblOthersBD = value;
            if (_lblOthersBD != null)
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

    private System.Windows.Forms.Label _lblOtherD;

    internal System.Windows.Forms.Label lblOtherD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOtherD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOtherD != null)
            {
            }

            _lblOtherD = value;
            if (_lblOtherD != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label7;

    internal System.Windows.Forms.Label Label7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label7 != null)
            {
            }

            _Label7 = value;
            if (_Label7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblWBD;

    internal System.Windows.Forms.Label lblWBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWBD != null)
            {
            }

            _lblWBD = value;
            if (_lblWBD != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label9;

    internal System.Windows.Forms.Label Label9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label9 != null)
            {
            }

            _Label9 = value;
            if (_Label9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblWD;

    internal System.Windows.Forms.Label lblWD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWD != null)
            {
            }

            _lblWD = value;
            if (_lblWD != null)
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

    private System.Windows.Forms.Label _lblRBD;

    internal System.Windows.Forms.Label lblRBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRBD != null)
            {
            }

            _lblRBD = value;
            if (_lblRBD != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label34;

    internal System.Windows.Forms.Label Label34
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label34;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label34 != null)
            {
            }

            _Label34 = value;
            if (_Label34 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblRD;

    internal System.Windows.Forms.Label lblRD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRD != null)
            {
            }

            _lblRD = value;
            if (_lblRD != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label41;

    internal System.Windows.Forms.Label Label41
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label41;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label41 != null)
            {
            }

            _Label41 = value;
            if (_Label41 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblThreads;

    internal System.Windows.Forms.Label lblThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblThreads != null)
            {
            }

            _lblThreads = value;
            if (_lblThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label44;

    internal System.Windows.Forms.Label Label44
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label44;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label44 != null)
            {
            }

            _Label44 = value;
            if (_Label44 != null)
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

    private System.Windows.Forms.TextBox _txtPriority;

    internal System.Windows.Forms.TextBox txtPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtPriority != null)
            {
            }

            _txtPriority = value;
            if (_txtPriority != null)
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

    private System.Windows.Forms.TextBox _txtRunTime;

    internal System.Windows.Forms.TextBox txtRunTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtRunTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtRunTime != null)
            {
            }

            _txtRunTime = value;
            if (_txtRunTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessStarted;

    internal System.Windows.Forms.TextBox txtProcessStarted
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessStarted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessStarted != null)
            {
            }

            _txtProcessStarted = value;
            if (_txtProcessStarted != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label14;

    internal System.Windows.Forms.Label Label14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label14 != null)
            {
            }

            _Label14 = value;
            if (_Label14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtParentProcess;

    internal System.Windows.Forms.TextBox txtParentProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtParentProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtParentProcess != null)
            {
            }

            _txtParentProcess = value;
            if (_txtParentProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label15;

    internal System.Windows.Forms.Label Label15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label15 != null)
            {
            }

            _Label15 = value;
            if (_Label15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdInspectExe;

    internal System.Windows.Forms.Button cmdInspectExe
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdInspectExe;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdInspectExe != null)
            {
            }

            _cmdInspectExe = value;
            if (_cmdInspectExe != null)
            {
            }
        }
    }

    private System.Windows.Forms.MainMenu _mainMenu;

    private System.Windows.Forms.MainMenu mainMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mainMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mainMenu != null)
            {
            }

            _mainMenu = value;
            if (_mainMenu != null)
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

    private System.Windows.Forms.MenuItem _MenuItemRefresh;

    internal System.Windows.Forms.MenuItem MenuItemRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemRefresh != null)
            {
            }

            _MenuItemRefresh = value;
            if (_MenuItemRefresh != null)
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

    private System.Windows.Forms.ContextMenu _menuCopyPctbig;

    private System.Windows.Forms.ContextMenu menuCopyPctbig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuCopyPctbig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuCopyPctbig != null)
            {
            }

            _menuCopyPctbig = value;
            if (_menuCopyPctbig != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _menuCopyPctSmall;

    private System.Windows.Forms.ContextMenu menuCopyPctSmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuCopyPctSmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuCopyPctSmall != null)
            {
            }

            _menuCopyPctSmall = value;
            if (_menuCopyPctSmall != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuString;

    private System.Windows.Forms.ContextMenu mnuString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuString != null)
            {
            }

            _mnuString = value;
            if (_mnuString != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuPrivileges;

    private System.Windows.Forms.ContextMenu mnuPrivileges
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuPrivileges;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuPrivileges != null)
            {
            }

            _mnuPrivileges = value;
            if (_mnuPrivileges != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemPriEnable;

    internal System.Windows.Forms.MenuItem MenuItemPriEnable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemPriEnable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemPriEnable != null)
            {
            }

            _MenuItemPriEnable = value;
            if (_MenuItemPriEnable != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuProcMem;

    private System.Windows.Forms.ContextMenu mnuProcMem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuProcMem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuProcMem != null)
            {
            }

            _mnuProcMem = value;
            if (_mnuProcMem != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemViewMemory;

    internal System.Windows.Forms.MenuItem MenuItemViewMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemViewMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemViewMemory != null)
            {
            }

            _MenuItemViewMemory = value;
            if (_MenuItemViewMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuModule;

    private System.Windows.Forms.ContextMenu mnuModule
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuModule;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuModule != null)
            {
            }

            _mnuModule = value;
            if (_mnuModule != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuThread;

    private System.Windows.Forms.ContextMenu mnuThread
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuThread;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuThread != null)
            {
            }

            _mnuThread = value;
            if (_mnuThread != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuWindow;

    private System.Windows.Forms.ContextMenu mnuWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuWindow != null)
            {
            }

            _mnuWindow = value;
            if (_mnuWindow != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuHandle;

    private System.Windows.Forms.ContextMenu mnuHandle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuHandle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuHandle != null)
            {
            }

            _mnuHandle = value;
            if (_mnuHandle != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCloseHandle;

    internal System.Windows.Forms.MenuItem MenuItemCloseHandle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCloseHandle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCloseHandle != null)
            {
            }

            _MenuItemCloseHandle = value;
            if (_MenuItemCloseHandle != null)
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

    private System.Windows.Forms.MenuItem _menuCloseTCP;

    internal System.Windows.Forms.MenuItem menuCloseTCP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuCloseTCP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuCloseTCP != null)
            {
            }

            _menuCloseTCP = value;
            if (_menuCloseTCP != null)
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

    private System.Windows.Forms.MenuItem _MenuItemColumnsNetwork;

    internal System.Windows.Forms.MenuItem MenuItemColumnsNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemColumnsNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemColumnsNetwork != null)
            {
            }

            _MenuItemColumnsNetwork = value;
            if (_MenuItemColumnsNetwork != null)
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

    private System.Windows.Forms.MenuItem _MenuItem12;

    internal System.Windows.Forms.MenuItem MenuItem12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem12 != null)
            {
            }

            _MenuItem12 = value;
            if (_MenuItem12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemShowUnnamedHandles;

    internal System.Windows.Forms.MenuItem MenuItemShowUnnamedHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemShowUnnamedHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemShowUnnamedHandles != null)
            {
            }

            _MenuItemShowUnnamedHandles = value;
            if (_MenuItemShowUnnamedHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem14;

    internal System.Windows.Forms.MenuItem MenuItem14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem14 != null)
            {
            }

            _MenuItem14 = value;
            if (_MenuItem14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemChooseColumnsHandle;

    internal System.Windows.Forms.MenuItem MenuItemChooseColumnsHandle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemChooseColumnsHandle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemChooseColumnsHandle != null)
            {
            }

            _MenuItemChooseColumnsHandle = value;
            if (_MenuItemChooseColumnsHandle != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemPEBAddress;

    internal System.Windows.Forms.MenuItem MenuItemPEBAddress
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemPEBAddress;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemPEBAddress != null)
            {
            }

            _MenuItemPEBAddress = value;
            if (_MenuItemPEBAddress != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem13;

    internal System.Windows.Forms.MenuItem MenuItem13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem13 != null)
            {
            }

            _MenuItem13 = value;
            if (_MenuItem13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemColumnsMemory;

    internal System.Windows.Forms.MenuItem MenuItemColumnsMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemColumnsMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemColumnsMemory != null)
            {
            }

            _MenuItemColumnsMemory = value;
            if (_MenuItemColumnsMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemPriDisable;

    internal System.Windows.Forms.MenuItem MenuItemPriDisable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemPriDisable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemPriDisable != null)
            {
            }

            _MenuItemPriDisable = value;
            if (_MenuItemPriDisable != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemPriRemove;

    internal System.Windows.Forms.MenuItem MenuItemPriRemove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemPriRemove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemPriRemove != null)
            {
            }

            _MenuItemPriRemove = value;
            if (_MenuItemPriRemove != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemModuleFileProp;

    internal System.Windows.Forms.MenuItem MenuItemModuleFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemModuleFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemModuleFileProp != null)
            {
            }

            _MenuItemModuleFileProp = value;
            if (_MenuItemModuleFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemModuleOpenDir;

    internal System.Windows.Forms.MenuItem MenuItemModuleOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemModuleOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemModuleOpenDir != null)
            {
            }

            _MenuItemModuleOpenDir = value;
            if (_MenuItemModuleOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemModuleFileDetails;

    internal System.Windows.Forms.MenuItem MenuItemModuleFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemModuleFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemModuleFileDetails != null)
            {
            }

            _MenuItemModuleFileDetails = value;
            if (_MenuItemModuleFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemModuleSearch;

    internal System.Windows.Forms.MenuItem MenuItemModuleSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemModuleSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemModuleSearch != null)
            {
            }

            _MenuItemModuleSearch = value;
            if (_MenuItemModuleSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemModuleDependencies;

    internal System.Windows.Forms.MenuItem MenuItemModuleDependencies
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemModuleDependencies;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemModuleDependencies != null)
            {
            }

            _MenuItemModuleDependencies = value;
            if (_MenuItemModuleDependencies != null)
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

    private System.Windows.Forms.MenuItem _MenuItemUnloadModule;

    internal System.Windows.Forms.MenuItem MenuItemUnloadModule
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemUnloadModule;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemUnloadModule != null)
            {
            }

            _MenuItemUnloadModule = value;
            if (_MenuItemUnloadModule != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemViewModuleMemory;

    internal System.Windows.Forms.MenuItem MenuItemViewModuleMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemViewModuleMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemViewModuleMemory != null)
            {
            }

            _MenuItemViewModuleMemory = value;
            if (_MenuItemViewModuleMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem19;

    internal System.Windows.Forms.MenuItem MenuItem19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem19 != null)
            {
            }

            _MenuItem19 = value;
            if (_MenuItem19 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemColumnsModule;

    internal System.Windows.Forms.MenuItem MenuItemColumnsModule
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemColumnsModule;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemColumnsModule != null)
            {
            }

            _MenuItemColumnsModule = value;
            if (_MenuItemColumnsModule != null)
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

    private System.Windows.Forms.MenuItem _MenuItemServDetails;

    internal System.Windows.Forms.MenuItem MenuItemServDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemServDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemServDetails != null)
            {
            }

            _MenuItemServDetails = value;
            if (_MenuItemServDetails != null)
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

    private System.Windows.Forms.MenuItem _MenuItemThTerm;

    internal System.Windows.Forms.MenuItem MenuItemThTerm
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThTerm;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThTerm != null)
            {
            }

            _MenuItemThTerm = value;
            if (_MenuItemThTerm != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThSuspend;

    internal System.Windows.Forms.MenuItem MenuItemThSuspend
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThSuspend;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThSuspend != null)
            {
            }

            _MenuItemThSuspend = value;
            if (_MenuItemThSuspend != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThResu;

    internal System.Windows.Forms.MenuItem MenuItemThResu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThResu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThResu != null)
            {
            }

            _MenuItemThResu = value;
            if (_MenuItemThResu != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem8;

    internal System.Windows.Forms.MenuItem MenuItem8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem8 != null)
            {
            }

            _MenuItem8 = value;
            if (_MenuItem8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThIdle;

    internal System.Windows.Forms.MenuItem MenuItemThIdle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThIdle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThIdle != null)
            {
            }

            _MenuItemThIdle = value;
            if (_MenuItemThIdle != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThLowest;

    internal System.Windows.Forms.MenuItem MenuItemThLowest
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThLowest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThLowest != null)
            {
            }

            _MenuItemThLowest = value;
            if (_MenuItemThLowest != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThAffinity;

    internal System.Windows.Forms.MenuItem MenuItemThAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThAffinity != null)
            {
            }

            _MenuItemThAffinity = value;
            if (_MenuItemThAffinity != null)
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

    private System.Windows.Forms.MenuItem _MenuItemThColumns;

    internal System.Windows.Forms.MenuItem MenuItemThColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThColumns != null)
            {
            }

            _MenuItemThColumns = value;
            if (_MenuItemThColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThBNormal;

    internal System.Windows.Forms.MenuItem MenuItemThBNormal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThBNormal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThBNormal != null)
            {
            }

            _MenuItemThBNormal = value;
            if (_MenuItemThBNormal != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThNorm;

    internal System.Windows.Forms.MenuItem MenuItemThNorm
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThNorm;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThNorm != null)
            {
            }

            _MenuItemThNorm = value;
            if (_MenuItemThNorm != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThANorm;

    internal System.Windows.Forms.MenuItem MenuItemThANorm
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThANorm;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThANorm != null)
            {
            }

            _MenuItemThANorm = value;
            if (_MenuItemThANorm != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThHighest;

    internal System.Windows.Forms.MenuItem MenuItemThHighest
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThHighest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThHighest != null)
            {
            }

            _MenuItemThHighest = value;
            if (_MenuItemThHighest != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemThTimeCr;

    internal System.Windows.Forms.MenuItem MenuItemThTimeCr
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemThTimeCr;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemThTimeCr != null)
            {
            }

            _MenuItemThTimeCr = value;
            if (_MenuItemThTimeCr != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWShow;

    internal System.Windows.Forms.MenuItem MenuItemWShow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWShow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWShow != null)
            {
            }

            _MenuItemWShow = value;
            if (_MenuItemWShow != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWShowUn;

    internal System.Windows.Forms.MenuItem MenuItemWShowUn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWShowUn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWShowUn != null)
            {
            }

            _MenuItemWShowUn = value;
            if (_MenuItemWShowUn != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWHide;

    internal System.Windows.Forms.MenuItem MenuItemWHide
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWHide;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWHide != null)
            {
            }

            _MenuItemWHide = value;
            if (_MenuItemWHide != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWClose;

    internal System.Windows.Forms.MenuItem MenuItemWClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWClose != null)
            {
            }

            _MenuItemWClose = value;
            if (_MenuItemWClose != null)
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

    private System.Windows.Forms.MenuItem _MenuItemWFront;

    internal System.Windows.Forms.MenuItem MenuItemWFront
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWFront;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWFront != null)
            {
            }

            _MenuItemWFront = value;
            if (_MenuItemWFront != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWNotFront;

    internal System.Windows.Forms.MenuItem MenuItemWNotFront
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWNotFront;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWNotFront != null)
            {
            }

            _MenuItemWNotFront = value;
            if (_MenuItemWNotFront != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWActive;

    internal System.Windows.Forms.MenuItem MenuItemWActive
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWActive;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWActive != null)
            {
            }

            _MenuItemWActive = value;
            if (_MenuItemWActive != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWForeground;

    internal System.Windows.Forms.MenuItem MenuItemWForeground
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWForeground;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWForeground != null)
            {
            }

            _MenuItemWForeground = value;
            if (_MenuItemWForeground != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem26;

    internal System.Windows.Forms.MenuItem MenuItem26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem26 != null)
            {
            }

            _MenuItem26 = value;
            if (_MenuItem26 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWMin;

    internal System.Windows.Forms.MenuItem MenuItemWMin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWMin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWMin != null)
            {
            }

            _MenuItemWMin = value;
            if (_MenuItemWMin != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWMax;

    internal System.Windows.Forms.MenuItem MenuItemWMax
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWMax;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWMax != null)
            {
            }

            _MenuItemWMax = value;
            if (_MenuItemWMax != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWPosSize;

    internal System.Windows.Forms.MenuItem MenuItemWPosSize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWPosSize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWPosSize != null)
            {
            }

            _MenuItemWPosSize = value;
            if (_MenuItemWPosSize != null)
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

    private System.Windows.Forms.MenuItem _MenuItemWEna;

    internal System.Windows.Forms.MenuItem MenuItemWEna
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWEna;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWEna != null)
            {
            }

            _MenuItemWEna = value;
            if (_MenuItemWEna != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWDisa;

    internal System.Windows.Forms.MenuItem MenuItemWDisa
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWDisa;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWDisa != null)
            {
            }

            _MenuItemWDisa = value;
            if (_MenuItemWDisa != null)
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

    private System.Windows.Forms.MenuItem _MenuItemWColumns;

    internal System.Windows.Forms.MenuItem MenuItemWColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWColumns != null)
            {
            }

            _MenuItemWColumns = value;
            if (_MenuItemWColumns != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuLog;

    private System.Windows.Forms.ContextMenu mnuLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuLog != null)
            {
            }

            _mnuLog = value;
            if (_mnuLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemLogGoto;

    internal System.Windows.Forms.MenuItem MenuItemLogGoto
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemLogGoto;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemLogGoto != null)
            {
            }

            _MenuItemLogGoto = value;
            if (_MenuItemLogGoto != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyHandle;

    internal System.Windows.Forms.MenuItem MenuItemCopyHandle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyHandle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyHandle != null)
            {
            }

            _MenuItemCopyHandle = value;
            if (_MenuItemCopyHandle != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCopyPrivilege;

    internal System.Windows.Forms.MenuItem MenuItemCopyPrivilege
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyPrivilege;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyPrivilege != null)
            {
            }

            _MenuItemCopyPrivilege = value;
            if (_MenuItemCopyPrivilege != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyMemory;

    internal System.Windows.Forms.MenuItem MenuItemCopyMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyMemory != null)
            {
            }

            _MenuItemCopyMemory = value;
            if (_MenuItemCopyMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyModule;

    internal System.Windows.Forms.MenuItem MenuItemCopyModule
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyModule;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyModule != null)
            {
            }

            _MenuItemCopyModule = value;
            if (_MenuItemCopyModule != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyThread;

    internal System.Windows.Forms.MenuItem MenuItemCopyThread
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyThread;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyThread != null)
            {
            }

            _MenuItemCopyThread = value;
            if (_MenuItemCopyThread != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyWindow;

    internal System.Windows.Forms.MenuItem MenuItemCopyWindow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyWindow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyWindow != null)
            {
            }

            _MenuItemCopyWindow = value;
            if (_MenuItemCopyWindow != null)
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

    private System.Windows.Forms.MenuItem _menuViewMemory;

    internal System.Windows.Forms.MenuItem menuViewMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuViewMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuViewMemory != null)
            {
            }

            _menuViewMemory = value;
            if (_menuViewMemory != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCopyLog;

    internal System.Windows.Forms.MenuItem MenuItemCopyLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyLog != null)
            {
            }

            _MenuItemCopyLog = value;
            if (_MenuItemCopyLog != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuEnv;

    private System.Windows.Forms.ContextMenu mnuEnv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuEnv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuEnv != null)
            {
            }

            _mnuEnv = value;
            if (_mnuEnv != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyEnvVariable;

    internal System.Windows.Forms.MenuItem MenuItemCopyEnvVariable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyEnvVariable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyEnvVariable != null)
            {
            }

            _MenuItemCopyEnvVariable = value;
            if (_MenuItemCopyEnvVariable != null)
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

    private System.Windows.Forms.MenuItem _MenuItemMemoryDump;

    internal System.Windows.Forms.MenuItem MenuItemMemoryDump
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMemoryDump;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMemoryDump != null)
            {
            }

            _MenuItemMemoryDump = value;
            if (_MenuItemMemoryDump != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCopyString;

    internal System.Windows.Forms.MenuItem MenuItemCopyString
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyString != null)
            {
            }

            _MenuItemCopyString = value;
            if (_MenuItemCopyString != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMemoryRelease;

    internal System.Windows.Forms.MenuItem MenuItemMemoryRelease
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMemoryRelease;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMemoryRelease != null)
            {
            }

            _MenuItemMemoryRelease = value;
            if (_MenuItemMemoryRelease != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMemoryDecommit;

    internal System.Windows.Forms.MenuItem MenuItemMemoryDecommit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMemoryDecommit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMemoryDecommit != null)
            {
            }

            _MenuItemMemoryDecommit = value;
            if (_MenuItemMemoryDecommit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemMemoryChangeProtection;

    internal System.Windows.Forms.MenuItem MenuItemMemoryChangeProtection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemMemoryChangeProtection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemMemoryChangeProtection != null)
            {
            }

            _MenuItemMemoryChangeProtection = value;
            if (_MenuItemMemoryChangeProtection != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem22;

    internal System.Windows.Forms.MenuItem MenuItem22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem22 != null)
            {
            }

            _MenuItem22 = value;
            if (_MenuItem22 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWVisiblity;

    internal System.Windows.Forms.MenuItem MenuItemWVisiblity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWVisiblity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWVisiblity != null)
            {
            }

            _MenuItemWVisiblity = value;
            if (_MenuItemWVisiblity != null)
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

    private System.Windows.Forms.MenuItem _MenuItemWFlash;

    internal System.Windows.Forms.MenuItem MenuItemWFlash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWFlash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWFlash != null)
            {
            }

            _MenuItemWFlash = value;
            if (_MenuItemWFlash != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWStopFlash;

    internal System.Windows.Forms.MenuItem MenuItemWStopFlash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWStopFlash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWStopFlash != null)
            {
            }

            _MenuItemWStopFlash = value;
            if (_MenuItemWStopFlash != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem21;

    internal System.Windows.Forms.MenuItem MenuItem21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem21 != null)
            {
            }

            _MenuItem21 = value;
            if (_MenuItem21 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWOpacity;

    internal System.Windows.Forms.MenuItem MenuItemWOpacity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWOpacity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWOpacity != null)
            {
            }

            _MenuItemWOpacity = value;
            if (_MenuItemWOpacity != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemWCaption;

    internal System.Windows.Forms.MenuItem MenuItemWCaption
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemWCaption;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemWCaption != null)
            {
            }

            _MenuItemWCaption = value;
            if (_MenuItemWCaption != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer;

    internal System.Windows.Forms.SplitContainer SplitContainer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer != null)
            {
            }

            _SplitContainer = value;
            if (_SplitContainer != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _RadioButton1;

    internal System.Windows.Forms.RadioButton RadioButton1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _RadioButton1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_RadioButton1 != null)
            {
            }

            _RadioButton1 = value;
            if (_RadioButton1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblSearchItemCaption;

    internal System.Windows.Forms.Label lblSearchItemCaption
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblSearchItemCaption;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblSearchItemCaption != null)
            {
            }

            _lblSearchItemCaption = value;
            if (_lblSearchItemCaption != null)
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

    private System.Windows.Forms.CheckBox _chkFreeze;

    internal System.Windows.Forms.CheckBox chkFreeze
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFreeze;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFreeze != null)
            {
            }

            _chkFreeze = value;
            if (_chkFreeze != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdHideFindPanel;

    internal System.Windows.Forms.Button cmdHideFindPanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdHideFindPanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdHideFindPanel != null)
            {
            }

            _cmdHideFindPanel = value;
            if (_cmdHideFindPanel != null)
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

    private System.Windows.Forms.MenuItem _MenuItemHandleDetails;

    internal System.Windows.Forms.MenuItem MenuItemHandleDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemHandleDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemHandleDetails != null)
            {
            }

            _MenuItemHandleDetails = value;
            if (_MenuItemHandleDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPageHeaps;

    internal System.Windows.Forms.TabPage TabPageHeaps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageHeaps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPageHeaps != null)
            {
            }

            _TabPageHeaps = value;
            if (_TabPageHeaps != null)
            {
            }
        }
    }

    private heapList _lvHeaps;

    internal heapList lvHeaps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvHeaps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvHeaps != null)
            {
            }

            _lvHeaps = value;
            if (_lvHeaps != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader16;

    internal System.Windows.Forms.ColumnHeader ColumnHeader16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader16 != null)
            {
            }

            _ColumnHeader16 = value;
            if (_ColumnHeader16 != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader18;

    internal System.Windows.Forms.ColumnHeader ColumnHeader18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader18 != null)
            {
            }

            _ColumnHeader18 = value;
            if (_ColumnHeader18 != null)
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

    private System.Windows.Forms.ContextMenu _mnuHeaps;

    private System.Windows.Forms.ContextMenu mnuHeaps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuHeaps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuHeaps != null)
            {
            }

            _mnuHeaps = value;
            if (_mnuHeaps != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyHeaps;

    internal System.Windows.Forms.MenuItem MenuItemCopyHeaps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyHeaps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyHeaps != null)
            {
            }

            _MenuItemCopyHeaps = value;
            if (_MenuItemCopyHeaps != null)
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

    private System.Windows.Forms.MenuItem _MenuItemColumnsHeap;

    internal System.Windows.Forms.MenuItem MenuItemColumnsHeap
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemColumnsHeap;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemColumnsHeap != null)
            {
            }

            _MenuItemColumnsHeap = value;
            if (_MenuItemColumnsHeap != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGoProcess;

    internal System.Windows.Forms.Button cmdGoProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoProcess != null)
            {
            }

            _cmdGoProcess = value;
            if (_cmdGoProcess != null)
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

    private System.Windows.Forms.Button _cmdActivateHeapEnumeration;

    internal System.Windows.Forms.Button cmdActivateHeapEnumeration
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdActivateHeapEnumeration;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdActivateHeapEnumeration != null)
            {
            }

            _cmdActivateHeapEnumeration = value;
            if (_cmdActivateHeapEnumeration != null)
            {
            }
        }
    }
}
