

namespace My
{
    [global::System.Runtime.CompilerServices.CompilerGenerated()]
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.0.0.0")]
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class MySettings : global::System.Configuration.ApplicationSettingsBase
    {
        private static MySettings defaultInstance = (MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings());

        /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
        public static MySettings Default
        {
            get
            {

                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1000")]
        public int ProcessInterval
        {
            get
            {
                return System.Convert.ToInt32(this["ProcessInterval"]);
            }
            set
            {
                this["ProcessInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("2500")]
        public int ServiceInterval
        {
            get
            {
                return System.Convert.ToInt32(this["ServiceInterval"]);
            }
            set
            {
                this["ServiceInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1000")]
        public int SystemInterval
        {
            get
            {
                return System.Convert.ToInt32(this["SystemInterval"]);
            }
            set
            {
                this["SystemInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1000")]
        public int TrayInterval
        {
            get
            {
                return System.Convert.ToInt32(this["TrayInterval"]);
            }
            set
            {
                this["TrayInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("102400")]
        public int HistorySize
        {
            get
            {
                return System.Convert.ToInt32(this["HistorySize"]);
            }
            set
            {
                this["HistorySize"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool WindowsStartup
        {
            get
            {
                return System.Convert.ToBoolean(this["WindowsStartup"]);
            }
            set
            {
                this["WindowsStartup"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool StartHidden
        {
            get
            {
                return System.Convert.ToBoolean(this["StartHidden"]);
            }
            set
            {
                this["StartHidden"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("English")]
        public string Lang
        {
            get
            {
                return System.Convert.ToString(this["Lang"]);
            }
            set
            {
                this["Lang"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool TopMost
        {
            get
            {
                return System.Convert.ToBoolean(this["TopMost"]);
            }
            set
            {
                this["TopMost"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool FirstTime
        {
            get
            {
                return System.Convert.ToBoolean(this["FirstTime"]);
            }
            set
            {
                this["FirstTime"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool FirstTimeSBA
        {
            get
            {
                return System.Convert.ToBoolean(this["FirstTimeSBA"]);
            }
            set
            {
                this["FirstTimeSBA"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool UseRibbonStyle
        {
            get
            {
                return System.Convert.ToBoolean(this["UseRibbonStyle"]);
            }
            set
            {
                this["UseRibbonStyle"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("-8323328")]
        public int NewItemColor
        {
            get
            {
                return System.Convert.ToInt32(this["NewItemColor"]);
            }
            set
            {
                this["NewItemColor"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("-49104")]
        public int DeletedItemColor
        {
            get
            {
                return System.Convert.ToInt32(this["DeletedItemColor"]);
            }
            set
            {
                this["DeletedItemColor"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool CloseYAPMWithCloseButton
        {
            get
            {
                return System.Convert.ToBoolean(this["CloseYAPMWithCloseButton"]);
            }
            set
            {
                this["CloseYAPMWithCloseButton"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool ShowTrayIcon
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowTrayIcon"]);
            }
            set
            {
                this["ShowTrayIcon"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("3")]
        public int Priority
        {
            get
            {
                return System.Convert.ToInt32(this["Priority"]);
            }
            set
            {
                this["Priority"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1000")]
        public int TaskInterval
        {
            get
            {
                return System.Convert.ToInt32(this["TaskInterval"]);
            }
            set
            {
                this["TaskInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1000")]
        public int NetworkInterval
        {
            get
            {
                return System.Convert.ToInt32(this["NetworkInterval"]);
            }
            set
            {
                this["NetworkInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("http://www.google.com/search?hl=en&q=ITEM")]
        public string SearchEngine
        {
            get
            {
                return System.Convert.ToString(this["SearchEngine"]);
            }
            set
            {
                this["SearchEngine"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool WarnDangerousActions
        {
            get
            {
                return System.Convert.ToBoolean(this["WarnDangerousActions"]);
            }
            set
            {
                this["WarnDangerousActions"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool HideWhenMinimized
        {
            get
            {
                return System.Convert.ToBoolean(this["HideWhenMinimized"]);
            }
            set
            {
                this["HideWhenMinimized"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool HideWhenClosed
        {
            get
            {
                return System.Convert.ToBoolean(this["HideWhenClosed"]);
            }
            set
            {
                this["HideWhenClosed"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool ReplaceTaskmgr
        {
            get
            {
                return System.Convert.ToBoolean(this["ReplaceTaskmgr"]);
            }
            set
            {
                this["ReplaceTaskmgr"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Processes")]
        public string SelectedTab
        {
            get
            {
                return System.Convert.ToString(this["SelectedTab"]);
            }
            set
            {
                this["SelectedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("General")]
        public string ProcSelectedTab
        {
            get
            {
                return System.Convert.ToString(this["ProcSelectedTab"]);
            }
            set
            {
                this["ProcSelectedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("General - 1")]
        public string ServSelectedTab
        {
            get
            {
                return System.Convert.ToString(this["ServSelectedTab"]);
            }
            set
            {
                this["ServSelectedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool AutomaticInternetInfos
        {
            get
            {
                return System.Convert.ToBoolean(this["AutomaticInternetInfos"]);
            }
            set
            {
                this["AutomaticInternetInfos"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool ShouldUpgrade
        {
            get
            {
                return System.Convert.ToBoolean(this["ShouldUpgrade"]);
            }
            set
            {
                this["ShouldUpgrade"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingBeingDebugged
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingBeingDebugged"]);
            }
            set
            {
                this["EnableHighlightingBeingDebugged"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingElevated
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingElevated"]);
            }
            set
            {
                this["EnableHighlightingElevated"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingJobProcess
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingJobProcess"]);
            }
            set
            {
                this["EnableHighlightingJobProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingOwnedProcess
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingOwnedProcess"]);
            }
            set
            {
                this["EnableHighlightingOwnedProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingServiceProcess
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingServiceProcess"]);
            }
            set
            {
                this["EnableHighlightingServiceProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingSystemProcess
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingSystemProcess"]);
            }
            set
            {
                this["EnableHighlightingSystemProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingCriticalProcess
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingCriticalProcess"]);
            }
            set
            {
                this["EnableHighlightingCriticalProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingSuspendedThread
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingSuspendedThread"]);
            }
            set
            {
                this["EnableHighlightingSuspendedThread"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("255, 192, 255")]
        public global::System.Drawing.Color HighlightingColorBeingDebugged
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorBeingDebugged"];
            }
            set
            {
                this["HighlightingColorBeingDebugged"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("192, 255, 192")]
        public global::System.Drawing.Color HighlightingColorJobProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorJobProcess"];
            }
            set
            {
                this["HighlightingColorJobProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("255, 255, 192")]
        public global::System.Drawing.Color HighlightingColorOwnedProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorOwnedProcess"];
            }
            set
            {
                this["HighlightingColorOwnedProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("192, 255, 255")]
        public global::System.Drawing.Color HighlightingColorServiceProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorServiceProcess"];
            }
            set
            {
                this["HighlightingColorServiceProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("192, 192, 255")]
        public global::System.Drawing.Color HighlightingColorSystemProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorSystemProcess"];
            }
            set
            {
                this["HighlightingColorSystemProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("255, 128, 0")]
        public global::System.Drawing.Color HighlightingColorCriticalProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorCriticalProcess"];
            }
            set
            {
                this["HighlightingColorCriticalProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("255, 255, 192")]
        public global::System.Drawing.Color HighlightingColorSuspendedThread
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorSuspendedThread"];
            }
            set
            {
                this["HighlightingColorSuspendedThread"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("255, 192, 128")]
        public global::System.Drawing.Color HighlightingColorElevatedProcess
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorElevatedProcess"];
            }
            set
            {
                this["HighlightingColorElevatedProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1")]
        public byte HighlightingPriorityBeingDebugged
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityBeingDebugged"]);
            }
            set
            {
                this["HighlightingPriorityBeingDebugged"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("4")]
        public byte HighlightingPriorityJobProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityJobProcess"]);
            }
            set
            {
                this["HighlightingPriorityJobProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("6")]
        public byte HighlightingPriorityOwnedProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityOwnedProcess"]);
            }
            set
            {
                this["HighlightingPriorityOwnedProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("5")]
        public byte HighlightingPriorityServiceProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityServiceProcess"]);
            }
            set
            {
                this["HighlightingPriorityServiceProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("7")]
        public byte HighlightingPrioritySystemProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPrioritySystemProcess"]);
            }
            set
            {
                this["HighlightingPrioritySystemProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("2")]
        public byte HighlightingPriorityCriticalProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityCriticalProcess"]);
            }
            set
            {
                this["HighlightingPriorityCriticalProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("3")]
        public byte HighlightingPriorityElevatedProcess
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPriorityElevatedProcess"]);
            }
            set
            {
                this["HighlightingPriorityElevatedProcess"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("1")]
        public byte HighlightingPrioritySuspendedThread
        {
            get
            {
                return System.Convert.ToByte(this["HighlightingPrioritySuspendedThread"]);
            }
            set
            {
                this["HighlightingPrioritySuspendedThread"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool ShowUserGroupDomain
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowUserGroupDomain"]);
            }
            set
            {
                this["ShowUserGroupDomain"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("8081")]
        public int RemotePort
        {
            get
            {
                return System.Convert.ToInt32(this["RemotePort"]);
            }
            set
            {
                this["RemotePort"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?540?0?Left$CpuUsage?73?1?Right$Process?233?2?Left$")]
        public string COLmain_task
        {
            get
            {
                return System.Convert.ToString(this["COLmain_task"]);
            }
            set
            {
                this["COLmain_task"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?106?0$PID?50?1$UserName?124?2$ParentName?94?3$CpuUsage?68?4?Right$AverageCpu" + "Usage?61?5?Right$TotalCpuTime?90?6?Right$HandleCount?56?7?Right$ThreadCount?50?8" + "?Right$WorkingSet?76?9?Right$Priority?90?10$Path?420?11$")]
        public string COLmain_process
        {
            get
            {
                return System.Convert.ToString(this["COLmain_process"]);
            }
            set
            {
                this["COLmain_process"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?107?0$Version?113?1$Description?279?2$CompanyName?138?3$Path?330?4$ProcessId" + "?60?5$")]
        public string COLmain_module
        {
            get
            {
                return System.Convert.ToString(this["COLmain_module"]);
            }
            set
            {
                this["COLmain_module"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Id?60?0$Priority?88?1$State?74?2$WaitReason?98?3$CreateTime?173?4?Right$TotalTime" + "?90?5?Right$StartAddress?83?6?Right$AffinityMask?78?7?Right$ContextSwitchCount?1" + "18?8?Right$ContextSwitchDelta?114?9?Right$ProcessId?68?10$")]
        public string COLmain_thread
        {
            get
            {
                return System.Convert.ToString(this["COLmain_thread"]);
            }
            set
            {
                this["COLmain_thread"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Type?113?0$Name?400?1$HandleCount?70??Right2$PointerCount?70?3?Right$ObjectCount?" + "70?4?Right$Handle?60?5?Right$Process?51?6$")]
        public string COLmain_handle
        {
            get
            {
                return System.Convert.ToString(this["COLmain_handle"]);
            }
            set
            {
                this["COLmain_handle"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Id?84?0$Caption?368?1$Process?162?2$IsTask?49?3$Enabled?56?4$Visible?47?5$ThreadI" + "d?61?6$")]
        public string COLmain_window
        {
            get
            {
                return System.Convert.ToString(this["COLmain_window"]);
            }
            set
            {
                this["COLmain_window"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?112?0$DisplayName?144?1$State?77?2$StartType?86?3$ImagePath?230?4$ServiceTyp" + "e?113?5$Process?127?6$")]
        public string COLmain_service
        {
            get
            {
                return System.Convert.ToString(this["COLmain_service"]);
            }
            set
            {
                this["COLmain_service"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Local?226?0$Remote?214?1$Protocol?65?2$State?99?3$LocalPortDescription?182?4$Proc" + "ess?100?5")]
        public string COLmain_network
        {
            get
            {
                return System.Convert.ToString(this["COLmain_network"]);
            }
            set
            {
                this["COLmain_network"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?177?0$Status?100?1$Description?327?2$")]
        public string COLprocdetail_privilege
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_privilege"]);
            }
            set
            {
                this["COLprocdetail_privilege"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?173?0$Protection?66?1$Address?90?2?Right$Size?66?3?Right$File?223?4$")]
        public string COLprocdetail_memory
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_memory"]);
            }
            set
            {
                this["COLprocdetail_memory"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?121?0$DisplayName?243?1$State?79?2$StartType?70?3$ImagePath?250?4$ServiceTyp" + "e?100?5$")]
        public string COLprocdetail_service
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_service"]);
            }
            set
            {
                this["COLprocdetail_service"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Local?214?0$Remote?214?1$Protocol?50?2$State?90?3$LocalPortDescription?140?4$")]
        public string COLprocdetail_network
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_network"]);
            }
            set
            {
                this["COLprocdetail_network"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Type?95?0$Name?400?1$HandleCount?70?2?Right$PointerCount?69?3?Right$ObjectCount?6" + "6?4?Right$Handle?52?5?Right$")]
        public string COLprocdetail_handle
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_handle"]);
            }
            set
            {
                this["COLprocdetail_handle"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Id?96?0$Caption?325?1$IsTask?44?2$Enabled?64?3$Visible?51?4$ThreadId?63?5$")]
        public string COLprocdetail_window
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_window"]);
            }
            set
            {
                this["COLprocdetail_window"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Id?60?0$ContextSwitchDelta?118?1?Right$Priority?100?2$State?70?3$WaitReason?100?4" + "$CreateTime?119?5?Right$TotalTime?200?6?Right$StartAddress?100?7?Right$ContextSw" + "itchCount?200?8?Right$")]
        public string COLprocdetail_thread
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_thread"]);
            }
            set
            {
                this["COLprocdetail_thread"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Name?90?0$Version?85?1$Description?210?2$CompanyName?150?3$Path?300?4$Address?80?" + "5$")]
        public string COLprocdetail_module
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_module"]);
            }
            set
            {
                this["COLprocdetail_module"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Variable?176?0$Value?445?1$")]
        public string COLprocdetail_envvariable
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_envvariable"]);
            }
            set
            {
                this["COLprocdetail_envvariable"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Date & Time?164?0$Type?102?1$Description?343?2$")]
        public string COLprocdetail_log
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_log"]);
            }
            set
            {
                this["COLprocdetail_log"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool ShowStatusBar
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowStatusBar"]);
            }
            set
            {
                this["ShowStatusBar"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool NotifyNewProcesses
        {
            get
            {
                return System.Convert.ToBoolean(this["NotifyNewProcesses"]);
            }
            set
            {
                this["NotifyNewProcesses"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool NotifyDeletedServices
        {
            get
            {
                return System.Convert.ToBoolean(this["NotifyDeletedServices"]);
            }
            set
            {
                this["NotifyDeletedServices"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool NotifyNewServices
        {
            get
            {
                return System.Convert.ToBoolean(this["NotifyNewServices"]);
            }
            set
            {
                this["NotifyNewServices"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool NotifyTerminatedProcesses
        {
            get
            {
                return System.Convert.ToBoolean(this["NotifyTerminatedProcesses"]);
            }
            set
            {
                this["NotifyTerminatedProcesses"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("192, 255, 192")]
        public global::System.Drawing.Color HighlightingColorRelocatedModule
        {
            get
            {
                return (global::System.Drawing.Color)this["HighlightingColorRelocatedModule"];
            }
            set
            {
                this["HighlightingColorRelocatedModule"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool EnableHighlightingRelocatedModule
        {
            get
            {
                return System.Convert.ToBoolean(this["EnableHighlightingRelocatedModule"]);
            }
            set
            {
                this["EnableHighlightingRelocatedModule"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("2000")]
        public int JobInterval
        {
            get
            {
                return System.Convert.ToInt32(this["JobInterval"]);
            }
            set
            {
                this["JobInterval"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("General")]
        public string JobSelectedTab
        {
            get
            {
                return System.Convert.ToString(this["JobSelectedTab"]);
            }
            set
            {
                this["JobSelectedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool AutomaticWintrust
        {
            get
            {
                return System.Convert.ToBoolean(this["AutomaticWintrust"]);
            }
            set
            {
                this["AutomaticWintrust"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool ShowFindWindowDetailedForm
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowFindWindowDetailedForm"]);
            }
            set
            {
                this["ShowFindWindowDetailedForm"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool FirstTimeShowFindWindowWasClosed
        {
            get
            {
                return System.Convert.ToBoolean(this["FirstTimeShowFindWindowWasClosed"]);
            }
            set
            {
                this["FirstTimeShowFindWindowWasClosed"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public string ClientIP
        {
            get
            {
                return System.Convert.ToString(this["ClientIP"]);
            }
            set
            {
                this["ClientIP"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool ShowFixedTab
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowFixedTab"]);
            }
            set
            {
                this["ShowFixedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Tasks")]
        public string FixedTab
        {
            get
            {
                return System.Convert.ToString(this["FixedTab"]);
            }
            set
            {
                this["FixedTab"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool UpdateAlpha
        {
            get
            {
                return System.Convert.ToBoolean(this["UpdateAlpha"]);
            }
            set
            {
                this["UpdateAlpha"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool UpdateBeta
        {
            get
            {
                return System.Convert.ToBoolean(this["UpdateBeta"]);
            }
            set
            {
                this["UpdateBeta"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool UpdateAuto
        {
            get
            {
                return System.Convert.ToBoolean(this["UpdateAuto"]);
            }
            set
            {
                this["UpdateAuto"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("http://yaprocmon.sourceforge.net/update.xml")]
        public string UpdateServer
        {
            get
            {
                return System.Convert.ToString(this["UpdateServer"]);
            }
            set
            {
                this["UpdateServer"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool ShowClassicMessageBoxes
        {
            get
            {
                return System.Convert.ToBoolean(this["ShowClassicMessageBoxes"]);
            }
            set
            {
                this["ShowClassicMessageBoxes"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public string RemoteMachineName
        {
            get
            {
                return System.Convert.ToString(this["RemoteMachineName"]);
            }
            set
            {
                this["RemoteMachineName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public string RemoteMachineNameW
        {
            get
            {
                return System.Convert.ToString(this["RemoteMachineNameW"]);
            }
            set
            {
                this["RemoteMachineNameW"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public string RemoteMachineUserW
        {
            get
            {
                return System.Convert.ToString(this["RemoteMachineUserW"]);
            }
            set
            {
                this["RemoteMachineUserW"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("250")]
        public int CoefTimeMul
        {
            get
            {
                return System.Convert.ToInt32(this["CoefTimeMul"]);
            }
            set
            {
                this["CoefTimeMul"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("Address?101?0$BlockCount?101?1$MemCommitted?117?2$MemAllocated?100?3$Flags?100?4$" + "")]
        public string COLprocdetail_heaps
        {
            get
            {
                return System.Convert.ToString(this["COLprocdetail_heaps"]);
            }
            set
            {
                this["COLprocdetail_heaps"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool SystemInfoTopMost
        {
            get
            {
                return System.Convert.ToBoolean(this["SystemInfoTopMost"]);
            }
            set
            {
                this["SystemInfoTopMost"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool SystemInfoOneGraph
        {
            get
            {
                return System.Convert.ToBoolean(this["SystemInfoOneGraph"]);
            }
            set
            {
                this["SystemInfoOneGraph"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("False")]
        public bool NetworkInfoTopMost
        {
            get
            {
                return System.Convert.ToBoolean(this["NetworkInfoTopMost"]);
            }
            set
            {
                this["NetworkInfoTopMost"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmMain
        {
            get
            {
                return System.Convert.ToString(this["PSfrmMain"]);
            }
            set
            {
                this["PSfrmMain"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmNetworkInfo
        {
            get
            {
                return System.Convert.ToString(this["PSfrmNetworkInfo"]);
            }
            set
            {
                this["PSfrmNetworkInfo"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmSystemInfo
        {
            get
            {
                return System.Convert.ToString(this["PSfrmSystemInfo"]);
            }
            set
            {
                this["PSfrmSystemInfo"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmJobInfo
        {
            get
            {
                return System.Convert.ToString(this["PSfrmJobInfo"]);
            }
            set
            {
                this["PSfrmJobInfo"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmServiceInfo
        {
            get
            {
                return System.Convert.ToString(this["PSfrmServiceInfo"]);
            }
            set
            {
                this["PSfrmServiceInfo"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmProcessInfo
        {
            get
            {
                return System.Convert.ToString(this["PSfrmProcessInfo"]);
            }
            set
            {
                this["PSfrmProcessInfo"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("True")]
        public bool RememberPosAndSize
        {
            get
            {
                return System.Convert.ToBoolean(this["RememberPosAndSize"]);
            }
            set
            {
                this["RememberPosAndSize"] = value;
            }
        }

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("0|0|0|0")]
        public string PSfrmScripting
        {
            get
            {
                return System.Convert.ToString(this["PSfrmScripting"]);
            }
            set
            {
                this["PSfrmScripting"] = value;
            }
        }
    }
}

namespace My
{
    [global::Microsoft.VisualBasic.HideModuleName()]
    [global::System.Diagnostics.DebuggerNonUserCode()]
    [global::System.Runtime.CompilerServices.CompilerGenerated()]
    internal static class MySettingsProperty
    {
        [global::System.ComponentModel.Design.HelpKeyword("My.Settings")]
        internal static global::My.MySettings Settings
        {
            get
            {
                return global::My.MySettings.Default;
            }
        }
    }
}

