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
using Microsoft.Win32;

public static class Program
{

    // Exit code when leave YAPM in ModeRequestReplaceTaskMgr
    public enum RequestReplaceTaskMgrResult : byte
    {
        ReplaceSuccess,
        ReplaceFail,
        NotReplaceSuccess,
        NotReplaceFail
    }

    // Constants for command line of YAPM
    public const string PARAM_DO_NOT_CHECK_PREV_INSTANCE = " -donotcheckprevinstance";
    public const string PARAM_CHANGE_TASKMGR = " -reptaskmgr";

    // Represent options passed with command line
    public class ProgramParameters
    {

        // Available parameters
        private bool isServerMode = false;
        private int remPort = 8081;
        private bool isHidden = false;
        private bool requestReplaceTaskMgr = false;
        private bool replaceTaskMgrValue = false;
        private string ssFileModeValue;
        private bool oneInstance = true;
        private bool useDriver = true;
        private bool serviceMode = false;
        private bool ssFileMode = false;
        public bool ModeServer
        {
            get
            {
                return isServerMode;
            }
        }
        public bool ModeServerService
        {
            get
            {
                return serviceMode;
            }
        }
        public bool ModeHidden
        {
            get
            {
                return isHidden;
            }
        }
        public int RemotePort
        {
            get
            {
                return remPort;
            }
        }
        public bool ModeRequestReplaceTaskMgr
        {
            get
            {
                return requestReplaceTaskMgr;
            }
        }
        public bool ValueReplaceTaskMgr
        {
            get
            {
                return replaceTaskMgrValue;
            }
        }
        public string ValueCreateSSFile
        {
            get
            {
                return ssFileModeValue;
            }
        }
        public bool OnlyOneInstance
        {
            get
            {
                return oneInstance;
            }
        }
        public bool UseKernelDriver
        {
            get
            {
                return useDriver;
            }
        }
        public bool ModeSnapshotFileCreation
        {
            get
            {
                return ssFileMode;
            }
        }
        public ProgramParameters(ref string[] parameters)
        {
            if (parameters == null)
                return;
            var loopTo = parameters.Length - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                if (parameters[i].ToUpperInvariant() == "-SERVER")
                    isServerMode = true;
                else if (parameters[i].ToUpperInvariant() == "-HIDE")
                    isHidden = true;
                else if (parameters[i].ToUpperInvariant() == "-PORT")
                {
                    if (parameters.Length - 1 >= i + 1)
                        remPort = System.Convert.ToInt32(Conversion.Val(parameters[i + 1]));
                }
                else if (parameters[i].ToUpperInvariant() == "-REPTASKMGR")
                {
                    if (parameters.Length - 1 >= i + 1)
                    {
                        replaceTaskMgrValue = System.Convert.ToBoolean(Conversion.Val(parameters[i + 1]));
                        requestReplaceTaskMgr = true;
                    }
                }
                else if (parameters[i].ToUpperInvariant() == "-DONOTCHECKPREVINSTANCE")
                    oneInstance = false;
                else if (parameters[i].ToUpperInvariant() == "-NODRIVER")
                    useDriver = false;
                else if (parameters[i].ToUpperInvariant() == "-SSFILE")
                {
                    if (parameters.Length - 1 >= i + 1)
                    {
                        ssFileModeValue = parameters[i + 1];
                        ssFileMode = true;
                    }
                }
                else if (parameters[i].ToUpperInvariant() == "-SERVERSERVICE")
                    serviceMode = true;
            }
        }
    }



    public static frmMain _frmMain;
    public static frmServer _frmServer;

    private static cUpdate __updater;

    private static cUpdate _updater
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __updater;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__updater != null)
            {
            }

            __updater = value;
            if (__updater != null)
            {
            }
        }
    }

    private static ProgramParameters _progParameters;
    private static cConnection _theConnection;

    private static cConnection theConnection
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
            }

            _theConnection = value;
            if (_theConnection != null)
            {
            }
        }
    }

    private static cSystemInfo _systemInfo;
    private static cHotkeys _hotkeys;
    private static Pref _pref;
    private static cLog _log;
    private static bool _isVistaOrAbove;
    private static bool _isAdmin;
    private static cTrayIcon _trayIcon;
    private static frmConnection _ConnectionForm;
    private static int _time;
    private static bool _isElevated;
    private static bool _mustCloseWithCloseButton = false;

    public static ProgramParameters Parameters
    {
        get
        {
            return _progParameters;
        }
    }
    public static int ElapsedTime
    {
        get
        {
            return Native.Api.Win32.GetElapsedTime() - _time;
        }
    }
    public static cConnection Connection
    {
        get
        {
            return theConnection;
        }
    }
    public static cSystemInfo SystemInfo
    {
        get
        {
            return _systemInfo;
        }
    }
    public static cHotkeys Hotkeys
    {
        get
        {
            return _hotkeys;
        }
    }
    public static Pref Preferences
    {
        get
        {
            return _pref;
        }
    }
    public static cLog Log
    {
        get
        {
            return _log;
        }
    }
    public static bool IsAdministrator
    {
        get
        {
            return _isAdmin;
        }
    }
    public static cTrayIcon TrayIcon
    {
        get
        {
            return _trayIcon;
        }
    }
    public static frmConnection ConnectionForm
    {
        get
        {
            return _ConnectionForm;
        }
    }
    public static bool IsElevated
    {
        get
        {
            return _isElevated;
        }
    }
    public static cUpdate Updater
    {
        get
        {
            return _updater;
        }
    }
    public static bool MustCloseWithCloseButton
    {
        get
        {
            return _mustCloseWithCloseButton;
        }
        set
        {
            _mustCloseWithCloseButton = value;
        }
    }


    public const string HELP_PATH_INTERNET = "http://yaprocmon.sourceforge.net/help_static.html";
    public const string HELP_PATH_DD = @"\Help\help_static.html";
    public const string NO_INFO_RETRIEVED = "N/A";

    public static Color NEW_ITEM_COLOR = Color.FromArgb(128, 255, 0);
    public static Color DELETED_ITEM_COLOR = Color.FromArgb(255, 64, 48);
    public static int PROCESSOR_COUNT;



    public static void Main()
    {


        // ======= Some basic initialisations
        // /!\ Looks like Comctl32 v6 could not be initialized before
        // a form is loaded. So as Comctl32 v5 can not display VistaDialogBoxes,
        // all error messages before instanciation of a form should use classical style.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);    // Use GDI, not GDI+



        // ======= Save time of start
        _time = Native.Api.Win32.GetElapsedTime();



        // ======= Check if framework is 2.0 or above
        if (cEnvironment.IsFramework2OrAbove == false)
        {
            Misc.ShowError(".Net Framework 2.0 must be installed.", true);
            Application.Exit();
        }



        // ======= Other init
        _isVistaOrAbove = cEnvironment.IsWindowsVistaOrAbove;
        _isAdmin = cEnvironment.IsAdmin;
        _isElevated = (cEnvironment.GetElevationType == Native.Api.Enums.ElevationType.Full);



        // ======= Read parameters
        _progParameters = new ProgramParameters(ref Environment.GetCommandLineArgs());



        // ======= We replace Taskmgr if needed. This will end YAPM
        if (_progParameters.ModeRequestReplaceTaskMgr)
            safeReplaceTaskMgr(_progParameters.ValueReplaceTaskMgr);


        // ======= We create a snapshot file
        if (_progParameters.ModeSnapshotFileCreation)
        {

            // Request debug privilege (if possible)
            cEnvironment.RequestPrivilege(cEnvironment.PrivilegeToRequest.DebugPrivilege);

            // New connection
            theConnection = new cConnection();

            // Used for service enumeration. Snapshot enumeration of services
            // need a cServiceConnection, retrieved as a property in
            // _frmMain.lvServices
            _frmMain = new frmMain();
            _frmMain.lvServices.ConnectionObj = theConnection;

            // This initializes the Handle Enumeration Class (needed to enumerate
            // handles)
            Native.Objects.Handle.HandleEnumerationClass = new Native.Objects.HandleEnumeration(_progParameters.UseKernelDriver & cEnvironment.Is32Bits);

            // Connect to the local machine
            theConnection.Connect();

            createSSFile(_progParameters.ValueCreateSSFile);
            return;
        }


        // ======= Close application if there is a previous instance of YAPM running
        if (_progParameters.ModeServerService == false)
        {
            if (_progParameters.OnlyOneInstance & cEnvironment.IsAlreadyRunning)
                return;



            // ======= Set handler for exceptions
            Application.ThreadException += MYThreadHandler;
            AppDomain.CurrentDomain.UnhandledException += MYExnHandler;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);



            // ======= Parse port files
            cNetwork.ParsePortTextFile();



            // ======= Enable some privileges
            cEnvironment.RequestPrivilege(cEnvironment.PrivilegeToRequest.DebugPrivilege);
            cEnvironment.RequestPrivilege(cEnvironment.PrivilegeToRequest.ShutdownPrivilege);



            // ======= Instanciate all classes

            // Common classes
            theConnection = new cConnection();     // The cConnection instance of the connection
            _systemInfo = new cSystemInfo();       // System informations
            _ConnectionForm = new frmConnection(ref theConnection);


            // FOR NOW, we use kernel only on 32 bits systems...
            Native.Objects.Handle.HandleEnumerationClass = new Native.Objects.HandleEnumeration(_progParameters.UseKernelDriver & cEnvironment.Is32Bits);


            // Classes for client only
            if (_progParameters.ModeServer == false)
            {
                _pref = new Pref();                    // Preferences
                _hotkeys = new cHotkeys();             // Hotkeys
                _log = new cLog();                     // Log instance
                _trayIcon = new cTrayIcon(2);        // Tray icons
                _frmMain = new frmMain();              // Main form
                _updater = new cUpdate();              // Updater class
            }
            else
            {
                _frmMain = new frmMain();              // Main form
                _frmServer = new frmServer();          // Server form (server mode)
            }



            // ======= Load preferences
            if (My.MySettingsProperty.Settings.ShouldUpgrade)
            {
                try
                {
                    // Try to update settings from a previous version of YAPM
                    My.MySettingsProperty.Settings.Upgrade();
                }
                catch (Exception ex)
                {
                    Misc.ShowDebugError(ex);
                }
                My.MySettingsProperty.Settings.ShouldUpgrade = false;
                My.MySettingsProperty.Settings.Save();
            }
            if (_progParameters.ModeServer == false)
            {
                try
                {
                    if (My.MySettingsProperty.Settings.FirstTime)
                    {
                        Misc.ShowMsg("This is the first time YAPM starts", "Please read this :", Pref.MessageFirstStartOfYAPM, MessageBoxButtons.OK, TaskDialogIcon.ShieldWarning, forceClassical: true);
                        My.MySettingsProperty.Settings.FirstTime = false;
                        Program.Preferences.Save();
                    }
                    Program.Preferences.Apply();
                    cProcess.BuffSize = My.MySettingsProperty.Settings.HistorySize;
                }
                catch (Exception ex)
                {
                    // Preference file corrupted/missing
                    Misc.ShowMsg("Startup error", "Failed to load preferences.", "Preference file is missing or corrupted and will be now recreated.", MessageBoxButtons.OK, TaskDialogIcon.ShieldError, true);
                    Program.Preferences.SetDefault();
                }
            }



            // ======= Read hotkeys & state based actions from XML files
            if (_progParameters.ModeServer == false)
                My.MyProject.MyForms.frmHotkeys.readHotkeysFromXML();



            // ======= Show main form & start application
            if (_progParameters.ModeServer)
                Application.Run(_frmServer);
            else
                Application.Run(_frmMain);
        }
        else
        {
            // Then YAPM is a service !

            // ======= Instanciate all classes

            // Common classes
            theConnection = new cConnection();     // The cConnection instance of the connection
            _systemInfo = new cSystemInfo();       // System informations
            _ConnectionForm = new frmConnection(ref theConnection);

            // FOR NOW, we use kernel only on 32 bits systems...
            Native.Objects.Handle.HandleEnumerationClass = new Native.Objects.HandleEnumeration(false);

            YAPMLauncherService.InteractiveProcess service = new YAPMLauncherService.InteractiveProcess();
            System.ServiceProcess.ServiceBase.Run(service);
        }
    }

    // Handler for exceptions
    private static void MYExnHandler(object sender, UnhandledExceptionEventArgs e)
    {
        Exception ex;
        ex = (Exception)e.ExceptionObject;
        Console.WriteLine(ex.StackTrace);
        frmError t = new frmError(ex);
        t.TopMost = true;
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        t.ShowDialog();
    }
    private static void MYThreadHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception.StackTrace);
        frmError t = new frmError(e.Exception);
        t.TopMost = true;
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        t.ShowDialog();
    }



    // Free memory (GC)
    public static void CollectGarbage()
    {
        // Use GC to collect
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    // Exit application
    public static void ExitYAPM()
    {

        // Save settings
        Pref.SaveListViewColumns(_frmMain.lvTask, "COLmain_task");
        Pref.SaveListViewColumns(_frmMain.lvServices, "COLmain_service");
        Pref.SaveListViewColumns(_frmMain.lvProcess, "COLmain_process");
        Pref.SaveListViewColumns(_frmMain.lvNetwork, "COLmain_network");

        My.MySettingsProperty.Settings.Save();

        // Uninstall driver
        try
        {
            Native.Objects.Handle.HandleEnumerationClass.Close();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }

        // Close forms & exit
        Program.MustCloseWithCloseButton = true;
        if (_frmMain != null)
            _frmMain.Close();
        Application.Exit();
    }

    private static void theConnection_Disconnected()
    {
        // Clear list of processes (used to get ParentProcess name)
        cProcess.ClearProcessDico();
    }

    // Create a snapshot file
    private static bool createSSFile(string file)
    {
        try
        {
            string res = null;

            // Create empty snapshot file
            cSnapshot snap = new cSnapshot();

            // Get options
            Native.Api.Enums.SnapshotObject options = Native.Api.Enums.SnapshotObject.All;

            // Build it
            if (snap.CreateSnapshot(Program.Connection, options, ref res) == false)
                // Failed
                // Misc.ShowMsg("Snapshot creation", "Could not build snapshot.", res, MessageBoxButtons.OK, TaskDialogIcon.Error)
                return false;

            // Save it
            if (snap.SaveSnapshot(file, ref res) == false)
                // Failed
                // Misc.ShowMsg("Snapshot creation", "Could not save snapshot.", res, MessageBoxButtons.OK, TaskDialogIcon.Error)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
            return false;
        }
    }

    // Replace taskmgr
    // This function will end YAPM with a specific ExitCode (if fail or not)
    private static void safeReplaceTaskMgr(bool value)
    {
        try
        {
            RegistryKey regKey;
            regKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);

            if (value)
                regKey.CreateSubKey("taskmgr.exe").SetValue("debugger", Application.ExecutablePath);
            else
                regKey.DeleteSubKey("taskmgr.exe");

            // Success
            RequestReplaceTaskMgrResult res;
            if (value)
                res = RequestReplaceTaskMgrResult.ReplaceSuccess;
            else
                res = RequestReplaceTaskMgrResult.NotReplaceSuccess;
            Native.Api.NativeFunctions.ExitProcess(res);
        }
        catch (Exception ex)
        {
            // Could not set key -> failed
            Misc.ShowDebugError(ex);
            RequestReplaceTaskMgrResult res;
            if (value)
                res = RequestReplaceTaskMgrResult.ReplaceFail;
            else
                res = RequestReplaceTaskMgrResult.NotReplaceFail;
            Native.Api.NativeFunctions.ExitProcess(res);
        }
    }

    private static void _updater_FailedToCheckVersion(bool silent, string msg)
    {
        // Failed to check update
        if (silent)
        {
            // Silent mode -> only displays a tooltip
            if (_frmMain != null && _frmMain.Tray != null)
            {
                {
                    var withBlock = _frmMain.Tray;
                    withBlock.BalloonTipText = msg;
                    withBlock.BalloonTipIcon = ToolTipIcon.Info;
                    withBlock.BalloonTipTitle = "Could not check if YAPM us ip to date.";
                    withBlock.ShowBalloonTip(3000);
                }
            }
        }
        else
            _frmMain.Invoke(new frmMain.FailedToCheckUpDateNotification(impFailedToCheckUpDateNotification), msg);
    }

    private static void _updater_NewVersionAvailable(bool silent, cUpdate.NewReleaseInfos release)
    {
        // A new version of YAPM is available
        if (silent)
        {
            // Silent mode -> only displays a tooltip
            if (_frmMain != null && _frmMain.Tray != null)
            {
                {
                    var withBlock = _frmMain.Tray;
                    withBlock.BalloonTipText = release.Infos;
                    withBlock.BalloonTipIcon = ToolTipIcon.Info;
                    withBlock.BalloonTipTitle = "A new version of YAPM is available !";
                    withBlock.ShowBalloonTip(3000);
                }
            }
        }
        else
            _frmMain.Invoke(new frmMain.NewUpdateAvailableNotification(impNewUpdateAvailableNotification), release);
    }

    private static void _updater_ProgramUpToDate(bool silent)
    {
        // YAPM is up to date (no new version available)
        if (silent)
        {
            // Silent mode -> only displays a tooltip
            if (_frmMain != null && _frmMain.Tray != null)
            {
                {
                    var withBlock = _frmMain.Tray;
                    withBlock.BalloonTipText = "YAPM is up to date !";
                    withBlock.BalloonTipIcon = ToolTipIcon.Info;
                    withBlock.BalloonTipTitle = "Now new version of YAPM is available.";
                    withBlock.ShowBalloonTip(3000);
                }
            }
        }
        else
            _frmMain.Invoke(new frmMain.NoNewUpdateAvailableNotification(impNoNewUpdateAvailableNotification));
    }

    // Called when a new update is available
    // It's here cause of thread safety
    public static void impNewUpdateAvailableNotification(cUpdate.NewReleaseInfos release)
    {
        frmNewVersionAvailable frm = new frmNewVersionAvailable(release);
        frm.ShowDialog();
    }

    // Called when no new update is available
    // It's here cause of thread safety
    public static void impNoNewUpdateAvailableNotification()
    {
        Common.Misc.ShowMsg("YAPM update", "YAPM is up to date !", "The current version (" + My.MyProject.Application.Info.Version.ToString() + ") is the latest available for download.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
    }

    // Called when failed to check is YAPM is up to date
    public static void impFailedToCheckUpDateNotification(string msg)
    {
        Common.Misc.ShowMsg("YAPM update", "Could not check if YAPM is up to date.", msg, MessageBoxButtons.OK, TaskDialogIcon.ShieldError);
    }
}

