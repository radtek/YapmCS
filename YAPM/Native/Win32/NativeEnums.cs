using System;

namespace Native.Api
{
    public class NativeEnums
    {


        // http://msdn.microsoft.com/en-us/library/ms684155(VS.85).aspx
        [Flags()]
        public enum EndOfJobTimeActionFlag : uint
        {
            TerminateAtEndOfJob = 0,
            PostAtEndOfJob = 1
        }

        // http://msdn.microsoft.com/en-us/library/ms684152(VS.85).aspx
        [Flags()]
        public enum JobObjectBasicUiRestrictions : uint
        {
            Handles = 0x1,
            ReadClipboard = 0x2,
            WriteClipboard = 0x4,
            SystemParameters = 0x8,
            DisplaySettings = 0x10,
            GlobalAtoms = 0x20,
            Desktop = 0x40,
            ExitWindows = 0x80
        }

        public enum JobObjectInformationClass : int
        {
            JobObjectBasicAccountingInformation = 1,
            JobObjectBasicLimitInformation = 2,
            JobObjectBasicProcessIdList = 3,
            JobObjectBasicUIRestrictions = 4,
            JobObjectSecurityLimitInformation = 5,
            JobObjectEndOfJobTimeInformation = 6,
            JobObjectAssociateCompletionPortInformation = 7,
            JobObjectBasicAndIoAccountingInformation = 8,
            JobObjectExtendedLimitInformation = 9,
            JobObjectJobSetInformation = 10,
            JobObjectGroupInformation = 11      // Not supported on XP/Vista
        }

        // http://msdn.microsoft.com/en-us/library/ms684147(VS.85).aspx
        [Flags()]
        public enum JobObjectLimitFlags : uint
        {
            WorkingSet = 0x1,
            ProcessTime = 0x2,
            JobTime = 0x4,
            ActiveProcess = 0x8,
            Affinity = 0x10,
            PriorityClass = 0x20,
            PreserveJobTime = 0x40,
            SchedulingClass = 0x80,
            ProcessMemory = 0x100,
            JobMemory = 0x200,
            DieOnUnhandledException = 0x400,
            BreakawayOk = 0x800,
            SilentBreakawayOk = 0x1000,
            KillOnJobClose = 0x2000
        }



        public enum DepFlags : uint
        {
            Disable = 0x0,
            Enable = 0x1,
            DisableAtlThunkEmulation = 0x2
        }

        public enum GuiResourceType : int
        {
            GdiObjects = 0x0,
            UserObjects = 0x1
        }

        [Flags()]
        public enum LdrpDataTableEntryFlags : uint
        {
            StaticLink = 0x2,
            ImageDll = 0x4,
            Flag0x8 = 0x8,
            Flag0x10 = 0x10,
            LoadInProgress = 0x1000,
            UnloadInProgress = 0x2000,
            EntryProcessed = 0x4000,
            EntryInserted = 0x8000,
            CurrentLoad = 0x10000,
            FailedBuiltInLoad = 0x20000,
            DontCallForThreads = 0x40000,
            ProcessAttachCalled = 0x80000,
            DebugSymbolsLoaded = 0x100000,
            ImageNotAtBase = 0x200000,
            CorImage = 0x400000,
            CorOwnsUnmap = 0x800000,
            SystemMapped = 0x1000000,
            ImageVerifying = 0x2000000,
            DriverDependentDll = 0x4000000,
            EntryNative = 0x8000000,
            Redirected = 0x10000000,
            NonPagedDebugInfo = 0x20000000,
            MmLoaded = 0x40000000,
            CompatDatabaseProcessed = 0x80000000
        }

        public enum MiniDumpType : int
        {
            MiniDumpNormal = 0x0,
            MiniDumpWithDataSegs = 0x1,
            MiniDumpWithFullMemory = 0x2,
            MiniDumpWithHandleData = 0x4,
            MiniDumpFilterMemory = 0x8,
            MiniDumpScanMemory = 0x10,
            MiniDumpWithUnloadedModules = 0x20,
            MiniDumpWithIndirectlyReferencedMemory = 0x40,
            MiniDumpFilterModulePaths = 0x80,
            MiniDumpWithProcessThreadData = 0x100,
            MiniDumpWithPrivateReadWriteMemory = 0x200,
            MiniDumpWithoutOptionalData = 0x400,
            MiniDumpWithFullMemoryInfo = 0x800,
            MiniDumpWithThreadInfo = 0x1000,
            MiniDumpWithCodeSegs = 0x2000
        }

        public enum ProcessInformationClass : int
        {
            ProcessBasicInformation,
            // 0
            ProcessQuotaLimits,
            ProcessIoCounters,
            ProcessVmCounters,
            ProcessTimes,
            ProcessBasePriority,
            ProcessRaisePriority,
            ProcessDebugPort,
            ProcessExceptionPort,
            ProcessAccessToken,
            ProcessLdtInformation,
            // 10
            ProcessLdtSize,
            ProcessDefaultHardErrorMode,
            ProcessIoPortHandlers,
            ProcessPooledUsageAndLimits,
            ProcessWorkingSetWatch,
            ProcessUserModeIOPL,
            ProcessEnableAlignmentFaultFixup,
            ProcessPriorityClass,
            ProcessWx86Information,
            ProcessHandleCount,
            // 20
            ProcessAffinityMask,
            ProcessPriorityBoost,
            ProcessDeviceMap,
            ProcessSessionInformation,
            ProcessForegroundInformation,
            ProcessWow64Information,
            ProcessImageFileName,
            ProcessLUIDDeviceMapsEnabled,
            ProcessBreakOnTermination,
            ProcessDebugObjectHandle,
            // 30
            ProcessDebugFlags,
            ProcessHandleTracing,
            ProcessIoPriority,
            ProcessExecuteFlags,
            ProcessResourceManagement,
            ProcessCookie,
            ProcessImageInformation,
            ProcessCycleTime,
            ProcessPagePriority,
            ProcessInstrumentationCallback,
            // 40
            ProcessThreadStackAllocation,
            ProcessWorkingSetWatchEx,
            ProcessImageFileNameWin32,
            ProcessImageFileMapping,
            ProcessAffinityUpdateMode,
            ProcessMemoryAllocationMode,
            MaxProcessInfoClass
        }

        [Flags()]
        public enum RtlUserProcessFlags : uint
        {
            ParamsNormalized = 0x1,
            ProfileUser = 0x2,
            ProfileKernel = 0x4,
            ProfileServer = 0x8,
            Reserve1Mb = 0x20,
            Reserve16Mb = 0x40,
            CaseSensitive = 0x80,
            DisableHeapDecommit = 0x100,
            DllRedirectionLocal = 0x1000,
            AppManifestPresent = 0x2000,
            ImageKeyMissing = 0x4000,
            OptInProcess = 0x20000
        }

        [Flags()]
        public enum Toolhelp32SnapshotFlags : uint
        {
            HeapList = 0x1,
            Process = 0x2,
            Thread = 0x4,
            Module = 0x8,
            Module32 = 0x10,
            Inherit = 0x80000000,
            All = Toolhelp32SnapshotFlags.HeapList | Toolhelp32SnapshotFlags.Module | Toolhelp32SnapshotFlags.Process | Toolhelp32SnapshotFlags.Thread
        }


        // OK

        [Flags()]
        public enum MemoryProtectionType : uint
        {
            AccessDenied = 0,
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x1,
            ReadOnly = 0x2,
            ReadWrite = 0x4,
            WriteCopy = 0x8,
            Guard = 0x100,
            NoCache = 0x200,
            WriteCombine = 0x400
        }

        [Flags()]
        public enum MemoryState : uint
        {
            Free = 0x10000,
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            TopDown = 0x100000,
            Physical = 0x400000,
            LargePages = 0x20000000
        }

        public enum MemoryType : int
        {
            Image = 0x1000000,
            Private = 0x20000,
            Mapped = 0x40000
        }


        // OK

        public enum KwaitReason : int
        {
            Executive = 0,
            FreePage = 1,
            PageIn = 2,
            PoolAllocation = 3,
            DelayExecution = 4,
            Suspended = 5,
            UserRequest = 6,
            WrExecutive = 7,
            WrFreePage = 8,
            WrPageIn = 9,
            WrPoolAllocation = 10,
            WrDelayExecution = 11,
            WrSuspended = 12,
            WrUserRequest = 13,
            WrEventPair = 14,
            WrQueue = 15,
            WrLpcReceive = 16,
            WrLpcReply = 17,
            WrVirtualMemory = 18,
            WrPageOut = 19,
            WrRendezvous = 20,
            Spare2 = 21,
            Spare3 = 22,
            Spare4 = 23,
            Spare5 = 24,
            WrCalloutStack = 25,
            WrKernel = 26,
            WrResource = 27,
            WrPushLock = 28,
            WrMutex = 29,
            WrQuantumEnd = 30,
            WrDispatchInt = 31,
            WrPreempted = 32,
            WrYieldExecution = 33,
            WrFastMutex = 34,
            WrGuardedMutex = 35,
            WrRundown = 36,
            MaximumWaitReason = 37
        }

        [Flags()]
        public enum RemoteThreadCreationFlags : uint
        {
            DebugProcess = 0x1,
            DebugOnlyThisProcess = 0x2,
            CreateSuspended = 0x4,
            DetachedProcess = 0x8,
            CreateNewConsole = 0x10,
            NormalPriorityClass = 0x20,
            IdlePriorityClass = 0x40,
            HighPriorityClass = 0x80,
            RealtimePriorityClass = 0x100,
            CreateNewProcessGroup = 0x200,
            CreateUnicodeEnvironment = 0x400,
            CreateSeparateWowVdm = 0x800,
            CreateSharedWowVdm = 0x1000,
            CreateForceDos = 0x2000,
            BelowNormalPriorityClass = 0x4000,
            AboveNormalPriorityClass = 0x8000,
            StackSizeParamIsAReservation = 0x10000,
            InheritCallerPriority = 0x20000,
            CreateProtectedProcess = 0x40000,
            ExtendedStartupInfoPresent = 0x80000,
            ProcessModeBackgroundBegin = 0x100000,
            ProcessModeBackgroundEnd = 0x200000,
            CreateBreakawayFromJob = 0x1000000,
            CreatePreserveCodeAuthzLevel = 0x2000000,
            CreateDefaultErrorMode = 0x4000000,
            CreateNoWindow = 0x8000000,
            ProfileUser = 0x10000000,
            ProfileKernel = 0x20000000,
            ProfileServer = 0x40000000,
            CreateIgnoreSystemDefault = 0x80000000
        }

        public enum ThreadInformationClass
        {
            ThreadBasicInformation,
            ThreadTimes,
            ThreadPriority,
            ThreadBasePriority,
            ThreadAffinityMask,
            ThreadImpersonationToken,
            ThreadDescriptorTableEntry,
            ThreadEnableAlignmentFaultFixup,
            ThreadEventPair,
            ThreadQuerySetWin32StartAddress,
            ThreadZeroTlsCell,
            ThreadPerformanceCount,
            ThreadAmILastThread,
            ThreadIdealProcessor,
            ThreadPriorityBoost,
            ThreadSetTlsArrayAddress,
            ThreadIsIoPending,
            ThreadHideFromDebugger,
            ThreadBreakOnTermination,
            ThreadSwitchLegacyState,
            ThreadIsTerminated,
            ThreadLastSystemCall,
            ThreadIoPriority,
            ThreadCycleTime,
            ThreadPagePriority,
            ThreadActualBasePriority,
            ThreadTebInformation,
            ThreadCSwitchMon,
            MaxThreadInfoClass
        }



        public enum SecurityImpersonationLevel : int
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        [Flags()]
        public enum SePrivilegeAttributes : uint
        {
            Disabled = 0x0,
            EnabledByDefault = 0x1,
            Enabled = 0x2,
            DisabledByDefault = 0x3,
            Removed = 0x4,
            UsedForAccess = 0x80000000
        }

        public enum SidNameUse : int
        {
            User = 1,
            Group,
            Domain,
            Alias,
            WellKnownGroup,
            DeletedAccount,
            Invalid,
            Unknown,
            Computer,
            Label
        }

        public enum TokenInformationClass
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            // 10
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            // 20
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            MaxTokenInfoClass
        }

        public enum TokenType : int
        {
            Primary = 1,
            Impersonation
        }



        public enum ECreationDisposition
        {
            New = 1,
            CreateAlways = 2,
            OpenExisting = 3,
            OpenAlways = 4,
            TruncateExisting = 5
        }

        public enum EFileAccess
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,
            GenericAll = 0x10000000
        }

        public enum EFileShare
        {
            None = 0x0,
            Read = 0x1,
            Write = 0x2,
            Delete = 0x4
        }

        public enum EFileAttributes
        {
            Readonly = 0x1,
            Hidden = 0x2,
            System = 0x4,
            Directory = 0x10,
            Archive = 0x20,
            Device = 0x40,
            Normal = 0x80,
            Temporary = 0x100,
            SparseFile = 0x200,
            ReparsePoint = 0x400,
            Compressed = 0x800,
            Offline = 0x1000,
            NotContentIndexed = 0x2000,
            Encrypted = 0x4000,
            Write_Through = 0x80000000,
            Overlapped = 0x40000000,
            NoBuffering = 0x20000000,
            RandomAccess = 0x10000000,
            SequentialScan = 0x8000000,
            DeleteOnClose = 0x4000000,
            BackupSemantics = 0x2000000,
            PosixSemantics = 0x1000000,
            OpenReparsePoint = 0x200000,
            OpenNoRecall = 0x100000,
            FirstPipeInstance = 0x80000
        }

        [Flags()]
        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x1,
            FileMapWrite = 0x2,
            FileMapRead = 0x4,
            FileMapAllAccess = 0x1F,
            fileMapExecute = 0x20
        }

        [Flags()]
        public enum FileMapProtection : uint
        {
            PageReadonly = 0x2,
            PageReadWrite = 0x4,
            PageWriteCopy = 0x8,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000
        }

        public enum FO_Func : uint
        {
            Move = 0x1,
            Copy = 0x2,
            Delete = 0x3,
            Rename = 0x4
        }

        [Flags()]
        public enum RunFileDialogFlags : uint
        {
            None = 0x0,
            NoBrowse = 0x1,
            NoDefault = 0x2,
            CalcDirectory = 0x4,
            NoLabel = 0x8,
            NoSeparateMemory = 0x20
        }

        [Flags()]
        public enum ShellExecuteInfoMask : int
        {
            InvokeIdList = &H,
            NoCloseProcess = 0x40,
            NoUI = 0x400
        }


        // OK

        public enum ExitWindowsFlags : int
        {
            Logoff = 0x0,
            Shutdown = 0x1,
            Reboot = 0x2,
            Force = 0x4,
            Poweroff = 0x8,
            ForceIfHung = 0x10,
            RestartApps = 0x40
        }

        [Flags()]
        public enum KBDLLHookStructFlags : int
        {
            Extended = 0x1,
            Injected = 0x10,
            AltDown = 0x20,
            Up = 0x80
        }

        public enum SystemInformationClass : int
        {
            SystemBasicInformation,
            SystemProcessorInformation,
            SystemPerformanceInformation,
            SystemTimeOfDayInformation,
            SystemPathInformation,
            SystemProcessInformation,
            SystemCallCountInformation,
            SystemDeviceInformation,
            SystemProcessorPerformanceInformation,
            SystemFlagsInformation,
            SystemCallTimeInformation,
            // 10
            SystemModuleInformation,
            SystemLocksInformation,
            SystemStackTraceInformation,
            SystemPagedPoolInformation,
            SystemNonPagedPoolInformation,
            SystemHandleInformation,
            SystemObjectInformation,
            SystemPageFileInformation,
            SystemVdmInstemulInformation,
            SystemVdmBopInformation,
            // 20
            SystemFileCacheInformation,
            SystemPoolTagInformation,
            SystemInterruptInformation,
            SystemDpcBehaviorInformation,
            SystemFullMemoryInformation,
            SystemLoadGdiDriverInformation,
            SystemUnloadGdiDriverInformation,
            SystemTimeAdjustmentInformation,
            SystemSummaryMemoryInformation,
            SystemMirrorMemoryInformation,
            // 30
            SystemPerformanceTraceInformation,
            SystemCrashDumpInformation,
            SystemExceptionInformation,
            SystemCrashDumpStateInformation,
            SystemKernelDebuggerInformation,
            SystemContextSwitchInformation,
            SystemRegistryQuotaInformation,
            SystemExtendServiceTableInformation,
            // used to be SystemLoadAndCallImage
            SystemPrioritySeparation,
            SystemVerifierAddDriverInformation,
            // 40
            SystemVerifierRemoveDriverInformation,
            SystemProcessorIdleInformation,
            SystemLegacyDriverInformation,
            SystemCurrentTimeZoneInformation,
            SystemLookasideInformation,
            SystemTimeSlipNotification,
            SystemSessionCreate,
            SystemSessionDetach,
            SystemSessionInformation,
            SystemRangeStartInformation,
            // 50
            SystemVerifierInformation,
            SystemVerifierThunkExtend,
            SystemSessionProcessInformation,
            SystemLoadGdiDriverInSystemSpace,
            SystemNumaProcessorMap,
            SystemPrefetcherInformation,
            SystemExtendedProcessInformation,
            SystemRecommendedSharedDataAlignment,
            SystemComPlusPackage,
            SystemNumaAvailableMemory,
            // 60
            SystemProcessorPowerInformation,
            SystemEmulationBasicInformation,
            SystemEmulationProcessorInformation,
            SystemExtendedHandleInformation,
            SystemLostDelayedWriteInformation,
            SystemBigPoolInformation,
            SystemSessionPoolTagInformation,
            SystemSessionMappedViewInformation,
            SystemHotpatchInformation,
            SystemObjectSecurityMode,
            // 70
            SystemWatchdogTimerHandler,
            // doesn't seem to be implemented
            SystemWatchdogTimerInformation,
            SystemLogicalProcessorInformation,
            SystemWow64SharedInformation,
            SystemRegisterFirmwareTableInformationHandler,
            SystemFirmwareTableInformation,
            SystemModuleInformationEx,
            SystemVerifierTriageInformation,
            SystemSuperfetchInformation,
            SystemMemoryListInformation,
            // 80
            SystemFileCacheInformationEx,
            SystemNotImplemented19,
            SystemProcessorDebugInformation,
            SystemVerifierInformation2,
            SystemNotImplemented20,
            SystemRefTraceInformation,
            SystemSpecialPoolTag,
            // MmSpecialPoolTag, then MmSpecialPoolCatchOverruns != 0
            SystemProcessImageName,
            SystemNotImplemented21,
            SystemBootEnvironmentInformation,
            // 90
            SystemEnlightenmentInformation,
            SystemVerifierInformationEx,
            SystemNotImplemented22,
            SystemNotImplemented23,
            SystemCovInformation,
            SystemNotImplemented24,
            SystemNotImplemented25,
            SystemPartitionInformation,
            SystemSystemDiskInformation,
            // this and SystemPartitionInformation both call IoQuerySystemDeviceName
            SystemPerformanceDistributionInformation,
            // 100
            SystemNumaProximityNodeInformation,
            SystemTimeZoneInformation2,
            SystemCodeIntegrityInformation,
            SystemNotImplemented26,
            SystemUnknownInformation,
            // No symbols for this case, very strange...
            SystemVaInformation
        }



        [Flags()]
        public enum FlashWInfoFlags : uint
        {
            Stop = 0,
            Caption = 0x1,
            Tray = 0x2,
            All = 0x3,
            Timer = 0x4,
            TimerNoFG = &H
        }

        public enum GdiBlendMode : int
        {
            Black = 1,
            NotMergePen,
            MaskNotPen,
            NotCopyPen,
            MaskPenNot,
            Not,
            XorPen,
            NotMaskPen,
            MaskPen,
            NotXorPen,
            Nop,
            MergeNotPen,
            CopyPen,
            MergePenNot,
            MergePen,
            White,
            Last
        }

        public enum GdiPenStyle : int
        {
            Solid = 0,
            Dash,
            Dot,
            DashDot,
            DashDotDot,
            Null,
            InsideFrame,
            UserStyle,
            Alternate
        }

        public enum GdiStockObject : int
        {
            WhiteBrush = 0,
            LightGrayBrush,
            GrayBrush,
            DarkGrayBrush,
            BlackBrush,
            NullBrush,
            WhitePen,
            BlackPen,
            NullPen,
            OemFixedFont,
            AnsiFixedFont,
            AnsiVarFont,
            SystemFont,
            DeviceDefaultFont,
            DefaultPalette,
            SystemFixedFont,
            DefaultGuiFont,
            DcBrush,
            DcPen
        }

        public enum GetWindowCmd : uint
        {
            First = 0,
            Last = 1,
            Next = 2,
            Previous = 3,
            Owner = 4,
            Child = 5,
            EnabledPopup = 6
        }

        public enum GetWindowLongOffset : int
        {
            WndProc = -4,
            HInstance = -6,
            HwndParent = -8,
            Id = -12,
            Style = -16,
            ExStyle = -20,
            UserData = -21
        }

        public enum LvsEx
        {
            GridLines = 0x1,
            SubitemImages = 0x2,
            Checkboxes = 0x4,
            TrackSelect = 0x8,
            HeaderDragDrop = 0x10,
            FullRowSelect = 0x20,
            OneClickActivate = 0x40,
            TwoClickActivate = 0x80,
            FlatSB = 0x100,
            Regional = 0x200,
            InfoTip = 0x400,
            UnderlineHot = 0x800,
            UnderlineCold = 0x1000,
            MultiWorkAreas = 0x2000,
            LabelTip = 0x4000,
            BorderSelect = 0x8000,
            DoubleBuffer = 0x10000,
            HideLabels = 0x20000,
            SingleRow = 0x40000,
            SnapToGrid = 0x80000,
            SimpleSelect = 0x100000
        }

        public enum SendMessageTimeoutFlags : int
        {
            Normal = 0x0,
            Block = 0x1,
            AbortIfHung = 0x2,
            NoTimeoutIfHung = 0x8
        }

        public enum ShowWindowType : uint
        {
            Hide = 0,
            ShowNormal = 1,
            Normal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActive = 7,
            ShowNa = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimize = 11,
            Max = 11
        }

        [Flags()]
        public enum SmtoFlags : int
        {
            Normal = 0x0,
            Block = 0x1,
            AbortIfHung = 0x2,
            NoTimeoutIfNotHung = 0x8,
            ErrorOnExit = 0x20
        }

        public enum WindowMessage : uint
        {
            Null = 0x0,
            Create = 0x1,
            Destroy = 0x2,
            Move = 0x3,
            Size = 0x5,
            Activate = 0x6,
            SetFocus = 0x7,
            KillFocus = 0x8,
            Enable = 0xA,
            SetRedraw = 0xB,
            SetText = &H,
            GetText = 0xD,
            GetTextLength = 0xE,
            Paint = 0xF,
            Close = 0x10,
            QueryEndSession = 0x11,
            Quit = 0x12,
            QueryOpen = 0x13,
            EraseBkgnd = 0x14,
            SysColorChange = 0x15,
            EndSession = 0x16,
            SystemError = 0x17,
            ShowWindow = 0x18,
            CtlColor = 0x19,
            WinIniChange = 0x1A,
            SettingChange = 0x1A,
            DevModeChange = 0x1B,
            ActivateApp = 0x1,
            FontChange = 0x1D,
            TimeChange = 0x1E,
            CancelMode = 0x1F,
            SetCursor = 0x20,
            MouseActivate = 0x21,
            ChildActivate = 0x22,
            QueueSync = 0x23,
            GetMinMaxInfo = 0x24,
            PaintIcon = 0x26,
            IconEraseBkgnd = 0x27,
            NextDlgCtl = 0x28,
            SpoolerStatus = 0x2A,
            DrawIcon = 0x2B,
            MeasureItem = 0x2,
            DeleteItem = 0x2D,
            VKeyToItem = 0x2E,
            CharToItem = 0x2F,
            SetFont = 0x30,
            GetFont = 0x31,
            SetHotkey = 0x32,
            GetHotkey = 0x33,
            QueryDragIcon = 0x37,
            CompareItem = 0x39,
            Compacting = 0x41,
            WindowPosChanging = 0x46,
            WindowPosChanged = 0x47,
            Power = 0x48,
            CopyData = 0x4A,
            CancelJournal = 0x4B,
            Notify = 0x4E,
            InputLangChangeRequest = 0x50,
            InputLangChange = 0x51,
            TCard = 0x52,
            Help = 0x53,
            UserChanged = 0x54,
            NotifyFormat = 0x55,
            ContextMenu = 0x7B,
            StyleChanging = 0x7,
            StyleChanged = 0x7D,
            DisplayChange = 0x7E,
            GetIcon = 0x7F,
            SetIcon = 0x80,
            NcCreate = 0x81,
            NcDestroy = 0x82,
            NcCalcSize = 0x83,
            NcHitTest = 0x84,
            NcPaint = 0x85,
            NcActivate = 0x86,
            GetDlgCode = 0x87,
            NcMouseMove = 0xA0,
            NcLButtonDown = 0xA1,
            NcLButtonUp = 0xA2,
            NcLButtonDblClk = 0xA3,
            NcRButtonDown = 0xA4,
            NcRButtonUp = 0xA5,
            NcRButtonDblClk = 0xA6,
            NcMButtonDown = 0xA7,
            NcMButtonUp = 0xA8,
            NcMButtonDblClk = 0xA9,
            KeyDown = 0x100,
            KeyUp = 0x101,
            Char = 0x102,
            DeadChar = 0x103,
            SysKeyDown = 0x104,
            SysKeyUp = 0x105,
            SysChar = 0x106,
            SysDeadChar = 0x107,
            ImeStartComposition = 0x10D,
            ImeEndComposition = 0x10E,
            ImeComposition = 0x10F,
            ImeKeyLast = 0x10F,
            InitDialog = 0x110,
            Command = 0x111,
            SysCommand = 0x112,
            Timer = 0x113,
            HScroll = 0x114,
            VScroll = 0x115,
            InitMenu = 0x116,
            InitMenuPopup = 0x117,
            MenuSelect = 0x11F,
            MenuChar = 0x120,
            EnterIdle = 0x121,
            CtlColorMsgBox = 0x132,
            CtlColorEdit = 0x133,
            CtlColorListBox = 0x134,
            CtlColorBtn = 0x135,
            CtlColorDlg = 0x136,
            CtlColorScrollbar = 0x137,
            CtlColorStatic = 0x138,
            MouseMove = 0x200,
            LButtonDown = 0x201,
            LButtonUp = 0x202,
            LButtonDblClk = 0x203,
            RButtonDown = 0x204,
            RButtonUp = 0x205,
            RButtonDblClk = 0x206,
            MButtonDown = 0x207,
            MButtonUp = 0x208,
            MButtonDblClk = 0x209,
            MouseWheel = 0x20A,
            ParentNotify = 0x210,
            EnterMenuLoop = 0x211,
            ExitMenuLoop = 0x212,
            NextMenu = 0x213,
            Sizing = 0x214,
            CaptureChanged = 0x215,
            Moving = 0x216,
            PowerBroadcast = 0x218,
            DeviceChange = 0x219,
            MdiCreate = 0x220,
            MdiDestroy = 0x221,
            MdiActivate = 0x222,
            MdiRestore = 0x223,
            MdiNext = 0x224,
            MdiMaximize = 0x225,
            MdiTile = 0x226,
            MdiCascade = 0x227,
            MdiIconArrange = 0x228,
            MdiGetActive = 0x229,
            MdiSetMenu = 0x230,
            EnterSizeMove = 0x231,
            ExitSizeMove = 0x232,
            DropFiles = 0x233,
            MdiRefreshMenu = 0x234,
            ImeSetContext = 0x281,
            ImeNotify = 0x282,
            ImeControl = 0x283,
            ImeCompositionFull = 0x284,
            ImeSelect = 0x285,
            ImeChar = 0x286,
            ImeKeyDown = 0x290,
            ImeKeyUp = 0x291,
            NcMouseHover = 0x2A0,
            MouseHover = 0x2A1,
            NcMouseLeave = 0x2A2,
            MouseLeave = 0x2A3,
            WtsSessionChange = 0x2B1,
            TabletFirst = 0x2C0,
            TabletLast = 0x2DF,
            Cut = 0x300,
            Copy = 0x301,
            Paste = 0x302,
            Clear = 0x303,
            Undo = 0x304,
            RenderFormat = 0x305,
            RenderAllFormats = 0x306,
            DestroyClipboard = 0x307,
            DrawClipboard = 0x308,
            PaintClipboard = 0x309,
            VScrollClipboard = 0x30A,
            SizeClipboard = 0x30B,
            AskCbFormatName = 0x30,
            ChangeCbChain = 0x30D,
            HScrollClipboard = 0x30E,
            QueryNewPalette = 0x30F,
            PaletteIsChanging = 0x310,
            PaletteChanged = 0x311,
            Hotkey = 0x312,
            Print = 0x317,
            PrintClient = 0x318,
            HandheldFirst = 0x358,
            HandheldLast = 0x35F,
            PenWinFirst = 0x380,
            PenWinLast = 0x38F,
            CoalesceFirst = 0x390,
            CoalesceLast = 0x39F,
            DdeInitiate = 0x3E0,
            DdeTerminate = 0x3E1,
            DdeAdvise = 0x3E2,
            DdeUnadvise = 0x3E3,
            DdeAck = 0x3E4,
            DdeData = 0x3E5,
            DdeRequest = 0x3E6,
            DdePoke = 0x3E7,
            DdeExecute = 0x3E8,
            User = 0x400,
            BcmSetShield = 0x160,
            App = 0x8000
        }

        [Flags()]
        public enum WindowPlacementFlags : int
        {
            SetMinPosition = 0x1,
            RestoreToMaximized = 0x2,
            AsyncWindowPlacement = 0x4
        }


        // OK

        public enum ServiceAccept : uint
        {
            NetBindChange = 0x10,
            ParamChange = 0x8,
            PauseContinue = 0x2,
            PreShutdown = 0x100,
            Shutdown = 0x4,
            Stop = 0x1,
            HardwareProfileChange = 0x20,
            PowerEvent = 0x40,
            SessionChange = 0x80
        }

        public enum ServiceControl
        {
            Stop = 1,
            Pause = 2,
            Continue = 3,
            Interrogate = 4,
            Shutdown = 5,
            ParamChange = 6,
            NetBindAdd = 7,
            NetBindRemove = 8,
            NetBindEnable = 9,
            NetBindDisable = 10,
            DeviceEvent = 11,
            HardwareProfileChange = 12,
            PowerEvent = 13,
            SessionChange = 14
        }

        public enum ServiceErrorControl : int
        {
            Critical = 0x3,
            Ignore = 0x0,
            Normal = 0x1,
            Severe = 0x2,
            Unknown = 0xF,
            NoChange = 0xFFFFFFFF
        }

        public enum ServiceFlags : uint
        {
            None = 0,
            RunsInSystemProcess = 0x1
        }

        public enum ServiceQueryState : uint
        {
            Active = 1,
            Inactive = 2,
            All = 3
        }

        [Flags()]
        public enum ServiceQueryType : uint
        {
            Driver = 0xB,
            Win32 = 0x30,
            All = ServiceQueryType.Driver | ServiceQueryType.Win32
        }

        public enum ServiceStartType : int
        {
            BootStart = 0x0,
            SystemStart = 0x1,
            AutoStart = 0x2,
            DemandStart = 0x3,
            StartDisabled = 0x4,
            NoChange = 0xFFFFFFFF
        }

        public enum ServiceState : uint
        {
            ContinuePending = 0x5,
            PausePending = 0x6,
            Paused = 0x7,
            Running = 0x4,
            StartPending = 0x2,
            StopPending = 0x3,
            Stopped = 0x1,
            Unknown = 0xF
        }

        [Flags()]
        public enum ServiceType : uint
        {
            FileSystemDriver = 0x2,
            KernelDriver = 0x1,
            Adapter = 0x4,
            RecognizerDriver = 0x8,
            Win32OwnProcess = 0x10,
            Win32ShareProcess = 0x20,
            InteractiveProcess = 0x100,
            NoChange = 0xFFFFFFFF
        }


        // OK

        // Type of monitoring to apply
        [Flags()]
        public enum KeyMonitoringType
        {
            ChangeName = 0x1            // Subkey added or deleted
,
            ChangeAttributes = 0x2      // Attributes changed
,
            ChangeLastSet = 0x4         // Value changed (changed, deleted, added)
,
            ChangeSecurity = 0x8        // Security descriptor changed
        }

        // http://msdn.microsoft.com/en-us/library/ms724892(VS.85).aspx
        // Type of Key
        public enum KeyType
        {
            ClassesRoot = 0x80000000,
            CurrentUser = 0x80000001,
            LocalMachine = 0x80000002,
            Users = 0x80000003,
            CurrentConfig = 0x80000005,
            PerformanceData = 0x80000004,
            DynData = 0x80000006
        }

        public enum WaitResult : uint
        {
            Infinite = 0xFFFFFFFF,
            Abandoned = 0x80,
            Object_0 = 0x0,
            TimeOut = 0x102,
            Failed = 0xFFFFFFFF
        }


        // OK

        public enum IconSize : int
        {
            Small = 0x0,
            Big = 0x1
        }

        public enum LVM : uint
        {
            First = 0x1000,
            SetExtendedListviewStyle = (LVM.First + 54),
            GetExtendedListviewStyle = (LVM.First + 55)
        }


        // OK

        public enum HookType : byte
        {
            JournalRecord = 0,
            JournalPlayBack = 1,
            Kerboard = 2,
            GetMessage = 3,
            CallWindowProc = 4,
            Cbt = 5,
            SysMsgFilter = 6,
            Mouse = 7,
            Hardware = 8,
            Debug = 9,
            Shell = 10,
            ForegroundIdle = 11,
            CallWindowProcRet = 12,
            KeyboardLowLevel = 13,
            MouseLowLevel = 14
        }


        // OK

        [Flags()]
        public enum FormatMessageFlags : int
        {
            AllocateBuffer = 0x100,
            ArgumentArray = 0x2000,
            FromHModule = 0x800,
            FromString = 0x400,
            FromSystem = 0x1000,
            MessageIgnoreInserts = 0x200
        }


        // OK

        [Flags()]
        public enum DuplicateOptions : int
        {
            CloseSource = 0x1,
            SameAccess = 0x2,
            SameAttributes = 0x4
        }

        [Flags()]
        public enum HandleFlags : byte
        {
            ProtectFromClose = 0x1,
            Inherit = 0x2,
            AuditObjectClose = 0x4
        }

        [Flags()]
        public enum ObjectFlags : uint
        {
            Inherit = 0x2,
            Permanent = 0x10,
            Exclusive = 0x20,
            CaseInsensitive = 0x40,
            OpenIf = 0x80,
            OpenLink = 0x100,
            KernelHandle = 0x200,
            ForceAccessCheck = 0x400,
            ValidAttributes = 0x7F2
        }

        public enum ObjectInformationClass : int
        {
            ObjectAttributes = 0,
            ObjectNameInformation = 1,
            ObjectTypeInformation = 2,
            ObjectTypesInformation = 3,
            ObjectHandleFlagInformation = 4,
            ObjectSessionInformation = 5
        }

        public enum PoolType : uint
        {
            NonPagedPool,
            PagedPool,
            NonPagedPoolMustSucceed,
            DontUseThisType,
            NonPagedPoolCacheAligned,
            PagedPoolCacheAligned,
            NonPagedPoolCacheAlignedMustS
        }


        // OK

        [Flags()]
        public enum AddConnectionFlag : int
        {
            ConnectUpdateProfile = 0x1,
            ConnectUpdateRecent = 0x2,
            ConnectTemporary = 0x4,
            ConnectInteractive = 0x8,
            ConnectPrompt = 0x10,
            ConnectRedirect = 0x80,
            ConnectCurrentMedia = 0x200,
            ConnectCommandLine = 0x800,
            ConnectCmdSaveCred = 0x1000,
            ConnectCredReset = 0x2000
        }

        public enum IpVersion : uint
        {
            AfInet = 0x2,
            AfInt6 = 0x17
        }

        public enum MibTcpRtoAlgorithm : uint
        {
            Other = 0x1,
            ConstantTimeOut = 0x2,
            MIL_STD_1778_Appendix_B = 0x3,
            VanJacobson = 0x4
        }

        /// <summary>
        /// Display options for the network object in a network browsing user interface.
        /// </summary>
        public enum NetResourceDisplayType : uint
        {
            /// <summary>
            /// The object should be displayed as a domain.
            /// </summary>
            Generic = 0x0,

            /// <summary>
            /// The object should be displayed as a server.
            /// </summary>
            Domain = 0x1,

            /// <summary>
            /// The object should be displayed as a share.
            /// </summary>
            Server = 0x2,

            /// <summary>
            /// The method used to display the object does not matter.
            /// </summary>
            Share = 0x3
        }

        /// <summary>
        /// Scope of the enumeration.
        /// </summary>
        public enum NetResourceScope : uint
        {
            /// <summary>
            /// Enumerate currently connected resources. The dwUsage member cannot be specified.
            /// </summary>
            Connected = 0x1,

            /// <summary>
            /// Enumerate all resources on the network. The dwUsage member is specified.
            /// </summary>
            GlobalNet = 0x2,

            /// <summary>
            /// Enumerate remembered (persistent) connections. The dwUsage member cannot be specified.
            /// </summary>
            Remembered = 0x3
        }

        /// <summary>
        /// Set of bit flags identifying the type of resource.
        /// </summary>
        public enum NetResourceType : uint
        {
            /// <summary>
            /// All resources
            /// </summary>
            Any = 0x0,

            /// <summary>
            /// Disk resources
            /// </summary>
            Disk = 0x1,

            /// <summary>
            /// Print resources
            /// </summary>
            Print = 0x2
        }

        /// <summary>
        /// Set of bit flags describing how the resource can be used.
        /// Note that this member can be specified only if the dwScope member is equal to RESOURCE_GLOBALNET.
        /// </summary>
        public enum NetResourceUsage : uint
        {
            /// <summary>
            /// The resource is a connectable resource; the name pointed to by the lpRemoteName member can be passed to the WNetAddConnection function to make a network connection.
            /// </summary>
            Connectable = 0x1,

            /// <summary>
            /// The resource is a container resource; the name pointed to by the lpRemoteName member can be passed to the WNetOpenEnum function to enumerate the resources in the container.
            /// </summary>
            Container = 0x2
        }


        // OK

        [Flags()]
        public enum HeapBlockFlag : int
        {
            Fixed = 0x1,
            Free = 0x2,
            Moveable = 0x4
        }

        [Flags()]
        public enum HeapListEntryFlags : int
        {
            Default = 0x1
        }

        // http://www.cygwin.com/ml/cygwin-talk/2006-q2/txt00000.txt
        [Flags()]
        public enum RtlQueryProcessDebugInformationFlags : uint
        {
            Modules = 0x1,
            BackTrace = 0x2,
            Heaps = 0x4,
            HeapTags = 0x8,
            HeapBlocks = 0x10,
            Locks = 0x20,
            Modules32 = 0x40
        }


        // OK

        public enum WinTrustDataChoice : uint
        {
            File = 1,
            Catalog = 2,
            Blob = 3,
            Signer = 4,
            Certificate = 5
        }

        public enum WinTrustDataUIChoice : uint
        {
            All = 1,
            None = 2,
            NoBad = 3,
            NoGood = 4
        }

        [Flags()]
        public enum WinTrustDataProvFlags : uint
        {
            UseIe4TrustFlag = 0x1,
            NoIe4ChainFlag = 0x2,
            NoPolicyUsageFlag = 0x4,
            RevocationCheckNone = 0x10,
            RevocationCheckEndCert = 0x20,
            RevocationCheckChain = 0x40,
            RevocationCheckChainExcludeRoot = 0x80,
            SaferFlag = 0x100,
            HashOnlyFlag = 0x200,
            UseDefaultOsverCheck = 0x400,
            LifetimeSigningFlag = 0x800,
            CacheOnlyUrlRetrieval = 0x1000
        }

        public enum WinTrustDataRevocationChecks : uint
        {
            None = 0x0,
            WholeChain = 0x1
        }

        public enum WinTrustDataStateAction : uint
        {
            Ignore = 0x0,
            Verify = 0x1,
            Close = 0x2,
            AutoCache = 0x3,
            AutoCacheFlush = 0x4
        }

        public enum WinTrustDataUIContext : uint
        {
            Execute = 0,
            Install = 1
        }

        public enum WinVerifyTrustResult : int
        {
            Trusted = 0,
            ProviderUnknown = 0x800B0001,
            ActionUnknown = 0x800B0002,
            SubjectFormUnknown = 0x800B0003,
            SubjectNotTrusted = 0x800B0004,
            NoSignature = 0x800B0100,
            Expired = 0x800B0101,
            ValidityPeriodNesting = 0x800B0102,
            Role = 0x800B0103,
            PathLenConst = 0x800B0104,
            Critical = 0x800B0105,
            Purpose = 0x800B0106,
            IssuerChaining = 0x800B0107,
            Malformed = 0x800B0108,
            UntrustedRoot = 0x800B0109,
            Chaining = 0x800B010A,
            Revoked = 0x800B010,
            UntrustedTestRoot = 0x800B010D,
            RevocationFailure = 0x800B010E,
            CNNotMatch = 0x800B010F,
            WrongUsage = 0x800B0110,
            ExplicitDistrust = 0x800B0111,
            UntrustedCA = 0x800B0112,
            SecuritySettings = 0x80092026
        }
    }
}

