using System;

namespace Native.Api
{
    public class Enums
    {

        // OK

        [Flags()]
        public enum KillMethod
        {
            NtTerminate = 0x1,
            ThreadTerminate = 0x2,
            CreateRemoteThread = 0x4,
            TerminateJob = 0x8,
            CloseAllHandles = 0x10,
            CloseAllWindows = 0x20,
            ThreadTerminate_GetNextThread = 0x40,
            All = KillMethod.NtTerminate | KillMethod.ThreadTerminate | KillMethod.CreateRemoteThread | KillMethod.TerminateJob | KillMethod.CloseAllHandles | KillMethod.CloseAllWindows | KillMethod.ThreadTerminate_GetNextThread
        }


        // OK

        public enum ElevationType
        {
            Default = 1,
            Full = 2,
            Limited = 3
        }


        // OK

        public enum MibTcpState : int
        {
            Closed = 1,
            Listening,
            SynSent,
            SynReceived,
            Established,
            FinWait1,
            FinWait2,
            CloseWait,
            Closing,
            LastAck,
            TimeWait,
            DeleteTcb
        }

        public enum NetworkProtocol : int
        {
            Tcp,
            Tcp6,
            Udp,
            Udp6
        }

        public enum TcpTableClass : int
        {
            BasicListener,
            BasicConnections,
            BasicAll,
            OwnerPidListener,
            OwnerPidConnections,
            OwnerPidAll,
            OwnerModuleListener,
            OwnerModuleConnections,
            OwnerModuleAll
        }

        public enum ToolType
        {
            TraceRoute,
            WhoIs,
            Ping
        }

        public enum UdpTableClass : int
        {
            Basic,
            OwnerPid,
            OwnerModule
        }


        // OK

        public enum WBEMStatus
        {
            WBEM_NO_ERROR = 0,
            WBEM_S_NO_ERROR = 0,
            WBEM_S_SAME = 0,
            WBEM_S_FALSE = 1,
            WBEM_S_ALREADY_EXISTS = 0x40001,
            WBEM_S_RESET_TO_DEFAULT = 0x40002,
            WBEM_S_DIFFERENT = 0x40003,
            WBEM_S_TIMEDOUT = 0x40004,
            WBEM_S_NO_MORE_DATA = 0x40005,
            WBEM_S_OPERATION_CANCELLED = 0x40006,
            WBEM_S_PENDING = 0x40007,
            WBEM_S_DUPLICATE_OBJECTS = 0x40008,
            WBEM_S_ACCESS_DENIED = 0x40009,
            WBEM_S_PARTIAL_RESULTS = 0x40010,
            WBEM_S_SOURCE_NOT_AVAILABLE = 0x40017,
            WBEM_E_FAILED = 0x80041001,
            WBEM_E_NOT_FOUND = 0x80041002,
            WBEM_E_ACCESS_DENIED = 0x80041003,
            WBEM_E_PROVIDER_FAILURE = 0x80041004,
            WBEM_E_TYPE_MISMATCH = 0x80041005,
            WBEM_E_OUT_OF_MEMORY = 0x80041006,
            WBEM_E_INVALID_CONTEXT = 0x80041007,
            WBEM_E_INVALID_PARAMETER = 0x80041008,
            WBEM_E_NOT_AVAILABLE = 0x80041009,
            WBEM_E_CRITICAL_ERROR = 0x8004100A,
            WBEM_E_INVALID_STREAM = 0x8004100B,
            WBEM_E_NOT_SUPPORTED = 0x8004100,
            WBEM_E_INVALID_SUPERCLASS = 0x8004100D,
            WBEM_E_INVALID_NAMESPACE = 0x8004100E,
            WBEM_E_INVALID_OBJECT = 0x8004100F,
            WBEM_E_INVALID_CLASS = 0x80041010,
            WBEM_E_PROVIDER_NOT_FOUND = 0x80041011,
            WBEM_E_INVALID_PROVIDER_REGISTRATION = 0x80041012,
            WBEM_E_PROVIDER_LOAD_FAILURE = 0x80041013,
            WBEM_E_INITIALIZATION_FAILURE = 0x80041014,
            WBEM_E_TRANSPORT_FAILURE = 0x80041015,
            WBEM_E_INVALID_OPERATION = 0x80041016,
            WBEM_E_INVALID_QUERY = 0x80041017,
            WBEM_E_INVALID_QUERY_TYPE = 0x80041018,
            WBEM_E_ALREADY_EXISTS = 0x80041019,
            WBEM_E_OVERRIDE_NOT_ALLOWED = 0x8004101A,
            WBEM_E_PROPAGATED_QUALIFIER = 0x8004101B,
            WBEM_E_PROPAGATED_PROPERTY = 0x8004101,
            WBEM_E_UNEXPECTED = 0x8004101D,
            WBEM_E_ILLEGAL_OPERATION = 0x8004101E,
            WBEM_E_CANNOT_BE_KEY = 0x8004101F,
            WBEM_E_INCOMPLETE_CLASS = 0x80041020,
            WBEM_E_INVALID_SYNTAX = 0x80041021,
            WBEM_E_NONDECORATED_OBJECT = 0x80041022,
            WBEM_E_READ_ONLY = 0x80041023,
            WBEM_E_PROVIDER_NOT_CAPABLE = 0x80041024,
            WBEM_E_CLASS_HAS_CHILDREN = 0x80041025,
            WBEM_E_CLASS_HAS_INSTANCES = 0x80041026,
            WBEM_E_QUERY_NOT_IMPLEMENTED = 0x80041027,
            WBEM_E_ILLEGAL_NULL = 0x80041028,
            WBEM_E_INVALID_QUALIFIER_TYPE = 0x80041029,
            WBEM_E_INVALID_PROPERTY_TYPE = 0x8004102A,
            WBEM_E_VALUE_OUT_OF_RANGE = 0x8004102B,
            WBEM_E_CANNOT_BE_SINGLETON = 0x8004102,
            WBEM_E_INVALID_CIM_TYPE = 0x8004102D,
            WBEM_E_INVALID_METHOD = 0x8004102E,
            WBEM_E_INVALID_METHOD_PARAMETERS = 0x8004102F,
            WBEM_E_SYSTEM_PROPERTY = 0x80041030,
            WBEM_E_INVALID_PROPERTY = 0x80041031,
            WBEM_E_CALL_CANCELLED = 0x80041032,
            WBEM_E_SHUTTING_DOWN = 0x80041033,
            WBEM_E_PROPAGATED_METHOD = 0x80041034,
            WBEM_E_UNSUPPORTED_PARAMETER = 0x80041035,
            WBEM_E_MISSING_PARAMETER_ID = 0x80041036,
            WBEM_E_INVALID_PARAMETER_ID = 0x80041037,
            WBEM_E_NONCONSECUTIVE_PARAMETER_IDS = 0x80041038,
            WBEM_E_PARAMETER_ID_ON_RETVAL = 0x80041039,
            WBEM_E_INVALID_OBJECT_PATH = 0x8004103A,
            WBEM_E_OUT_OF_DISK_SPACE = 0x8004103B,
            WBEM_E_BUFFER_TOO_SMALL = 0x8004103,
            WBEM_E_UNSUPPORTED_PUT_EXTENSION = 0x8004103D,
            WBEM_E_UNKNOWN_OBJECT_TYPE = 0x8004103E,
            WBEM_E_UNKNOWN_PACKET_TYPE = 0x8004103F,
            WBEM_E_MARSHAL_VERSION_MISMATCH = 0x80041040,
            WBEM_E_MARSHAL_INVALID_SIGNATURE = 0x80041041,
            WBEM_E_INVALID_QUALIFIER = 0x80041042,
            WBEM_E_INVALID_DUPLICATE_PARAMETER = 0x80041043,
            WBEM_E_TOO_MUCH_DATA = 0x80041044,
            WBEM_E_SERVER_TOO_BUSY = 0x80041045,
            WBEM_E_INVALID_FLAVOR = 0x80041046,
            WBEM_E_CIRCULAR_REFERENCE = 0x80041047,
            WBEM_E_UNSUPPORTED_CLASS_UPDATE = 0x80041048,
            WBEM_E_CANNOT_CHANGE_KEY_INHERITANCE = 0x80041049,
            WBEM_E_CANNOT_CHANGE_INDEX_INHERITANCE = 0x80041050,
            WBEM_E_TOO_MANY_PROPERTIES = 0x80041051,
            WBEM_E_UPDATE_TYPE_MISMATCH = 0x80041052,
            WBEM_E_UPDATE_OVERRIDE_NOT_ALLOWED = 0x80041053,
            WBEM_E_UPDATE_PROPAGATED_METHOD = 0x80041054,
            WBEM_E_METHOD_NOT_IMPLEMENTED = 0x80041055,
            WBEM_E_METHOD_DISABLED = 0x80041056,
            WBEM_E_REFRESHER_BUSY = 0x80041057,
            WBEM_E_UNPARSABLE_QUERY = 0x80041058,
            WBEM_E_NOT_EVENT_CLASS = 0x80041059,
            WBEM_E_MISSING_GROUP_WITHIN = 0x8004105A,
            WBEM_E_MISSING_AGGREGATION_LIST = 0x8004105B,
            WBEM_E_PROPERTY_NOT_AN_OBJECT = 0x8004105,
            WBEM_E_AGGREGATING_BY_OBJECT = 0x8004105D,
            WBEM_E_UNINTERPRETABLE_PROVIDER_QUERY = 0x8004105F,
            WBEM_E_BACKUP_RESTORE_WINMGMT_RUNNING = 0x80041060,
            WBEM_E_QUEUE_OVERFLOW = 0x80041061,
            WBEM_E_PRIVILEGE_NOT_HELD = 0x80041062,
            WBEM_E_INVALID_OPERATOR = 0x80041063,
            WBEM_E_LOCAL_CREDENTIALS = 0x80041064,
            WBEM_E_CANNOT_BE_ABSTRACT = 0x80041065,
            WBEM_E_AMENDED_OBJECT = 0x80041066,
            WBEM_E_CLIENT_TOO_SLOW = 0x80041067,
            WBEM_E_NULL_SECURITY_DESCRIPTOR = 0x80041068,
            WBEM_E_TIMED_OUT = 0x80041069,
            WBEM_E_INVALID_ASSOCIATION = 0x8004106A,
            WBEM_E_AMBIGUOUS_OPERATION = 0x8004106B,
            WBEM_E_QUOTA_VIOLATION = 0x8004106,
            WBEM_E_RESERVED_001 = 0x8004106D,
            WBEM_E_RESERVED_002 = 0x8004106E,
            WBEM_E_UNSUPPORTED_LOCALE = 0x8004106F,
            WBEM_E_HANDLE_OUT_OF_DATE = 0x80041070,
            WBEM_E_CONNECTION_FAILED = 0x80041071,
            WBEM_E_INVALID_HANDLE_REQUEST = 0x80041072,
            WBEM_E_PROPERTY_NAME_TOO_WIDE = 0x80041073,
            WBEM_E_CLASS_NAME_TOO_WIDE = 0x80041074,
            WBEM_E_METHOD_NAME_TOO_WIDE = 0x80041075,
            WBEM_E_QUALIFIER_NAME_TOO_WIDE = 0x80041076,
            WBEM_E_RERUN_COMMAND = 0x80041077,
            WBEM_E_DATABASE_VER_MISMATCH = 0x80041078,
            WBEM_E_VETO_DELETE = 0x80041079,
            WBEM_E_VETO_PUT = 0x8004107A,
            WBEM_E_INVALID_LOCALE = 0x80041080,
            WBEM_E_PROVIDER_SUSPENDED = 0x80041081,
            WBEM_E_SYNCHRONIZATION_REQUIRED = 0x80041082,
            WBEM_E_NO_SCHEMA = 0x80041083,
            WBEM_E_PROVIDER_ALREADY_REGISTERED = 0x80041084,
            WBEM_E_PROVIDER_NOT_REGISTERED = 0x80041085,
            WBEM_E_FATAL_TRANSPORT_ERROR = 0x80041086,
            WBEM_E_ENCRYPTED_CONNECTION_REQUIRED = 0x80041087,
            WBEM_E_PROVIDER_TIMED_OUT = 0x80041088,
            WBEM_E_NO_KEY = 0x80041089,
            WBEM_E_PROVIDER_DISABLED = 0x8004108A,
            WBEMESS_E_REGISTRATION_TOO_BROAD = 0x80042001,
            WBEMESS_E_REGISTRATION_TOO_PRECISE = 0x80042002,
            WBEMESS_E_AUTHZ_NOT_PRIVILEGED = 0x80042003,
            WBEMMOF_E_EXPECTED_QUALIFIER_NAME = 0x80044001,
            WBEMMOF_E_EXPECTED_SEMI = 0x80044002,
            WBEMMOF_E_EXPECTED_OPEN_BRACE = 0x80044003,
            WBEMMOF_E_EXPECTED_CLOSE_BRACE = 0x80044004,
            WBEMMOF_E_EXPECTED_CLOSE_BRACKET = 0x80044005,
            WBEMMOF_E_EXPECTED_CLOSE_PAREN = 0x80044006,
            WBEMMOF_E_ILLEGAL_CONSTANT_VALUE = 0x80044007,
            WBEMMOF_E_EXPECTED_TYPE_IDENTIFIER = 0x80044008,
            WBEMMOF_E_EXPECTED_OPEN_PAREN = 0x80044009,
            WBEMMOF_E_UNRECOGNIZED_TOKEN = 0x8004400A,
            WBEMMOF_E_UNRECOGNIZED_TYPE = 0x8004400B,
            WBEMMOF_E_EXPECTED_PROPERTY_NAME = 0x8004400,
            WBEMMOF_E_TYPEDEF_NOT_SUPPORTED = 0x8004400D,
            WBEMMOF_E_UNEXPECTED_ALIAS = 0x8004400E,
            WBEMMOF_E_UNEXPECTED_ARRAY_INIT = 0x8004400F,
            WBEMMOF_E_INVALID_AMENDMENT_SYNTAX = 0x80044010,
            WBEMMOF_E_INVALID_DUPLICATE_AMENDMENT = 0x80044011,
            WBEMMOF_E_INVALID_PRAGMA = 0x80044012,
            WBEMMOF_E_INVALID_NAMESPACE_SYNTAX = 0x80044013,
            WBEMMOF_E_EXPECTED_CLASS_NAME = 0x80044014,
            WBEMMOF_E_TYPE_MISMATCH = 0x80044015,
            WBEMMOF_E_EXPECTED_ALIAS_NAME = 0x80044016,
            WBEMMOF_E_INVALID_CLASS_DECLARATION = 0x80044017,
            WBEMMOF_E_INVALID_INSTANCE_DECLARATION = 0x80044018,
            WBEMMOF_E_EXPECTED_DOLLAR = 0x80044019,
            WBEMMOF_E_CIMTYPE_QUALIFIER = 0x8004401A,
            WBEMMOF_E_DUPLICATE_PROPERTY = 0x8004401B,
            WBEMMOF_E_INVALID_NAMESPACE_SPECIFICATION = 0x8004401,
            WBEMMOF_E_OUT_OF_RANGE = 0x8004401D,
            WBEMMOF_E_INVALID_FILE = 0x8004401E,
            WBEMMOF_E_ALIASES_IN_EMBEDDED = 0x8004401F,
            WBEMMOF_E_NULL_ARRAY_ELEM = 0x80044020,
            WBEMMOF_E_DUPLICATE_QUALIFIER = 0x80044021,
            WBEMMOF_E_EXPECTED_FLAVOR_TYPE = 0x80044022,
            WBEMMOF_E_INCOMPATIBLE_FLAVOR_TYPES = 0x80044023,
            WBEMMOF_E_MULTIPLE_ALIASES = 0x80044024,
            WBEMMOF_E_INCOMPATIBLE_FLAVOR_TYPES2 = 0x80044025,
            WBEMMOF_E_NO_ARRAYS_RETURNED = 0x80044026,
            WBEMMOF_E_MUST_BE_IN_OR_OUT = 0x80044027,
            WBEMMOF_E_INVALID_FLAGS_SYNTAX = 0x80044028,
            WBEMMOF_E_EXPECTED_BRACE_OR_BAD_TYPE = 0x80044029,
            WBEMMOF_E_UNSUPPORTED_CIMV22_QUAL_VALUE = 0x8004402A,
            WBEMMOF_E_UNSUPPORTED_CIMV22_DATA_TYPE = 0x8004402B,
            WBEMMOF_E_INVALID_DELETEINSTANCE_SYNTAX = 0x8004402,
            WBEMMOF_E_INVALID_QUALIFIER_SYNTAX = 0x8004402D,
            WBEMMOF_E_QUALIFIER_USED_OUTSIDE_SCOPE = 0x8004402E,
            WBEMMOF_E_ERROR_CREATING_TEMP_FILE = 0x8004402F,
            WBEMMOF_E_ERROR_INVALID_INCLUDE_FILE = 0x80044030,
            WBEMMOF_E_INVALID_DELETECLASS_SYNTAX = 0x80044031
        }

        public enum WmiInfoJob
        {
            CollectionID
        }

        public enum WmiInfoProcess
        {
            // Caption
            CommandLine,
            // CreationClassName
            CreationDate,
            // CSCreationClassName
            // CSName
            // Description
            ExecutablePath,
            // ExecutionState
            // Handle
            HandleCount,
            // InstallDate
            KernelModeTime,
            MaximumWorkingSetSize,
            MinimumWorkingSetSize,
            // Name
            // OSCreationClassName
            // OSName
            OtherOperationCount,
            OtherTransferCount,
            PageFaults,
            PageFileUsage,
            ParentProcessId,
            PeakPageFileUsage,
            PeakVirtualSize,
            PeakWorkingSetSize,
            Priority,
            PrivatePageCount,
            ProcessId,
            QuotaNonPagedPoolUsage,
            QuotaPagedPoolUsage,
            QuotaPeakNonPagedPoolUsage,
            QuotaPeakPagedPoolUsage,
            ReadOperationCount,
            ReadTransferCount,
            // SessionId
            // Status
            TerminationDate,
            ThreadCount,
            UserModeTime,
            VirtualSize,
            WindowsVersion,
            WorkingSetSize,
            WriteOperationCount,
            WriteTransferCount
        }

        public enum WmiInfoThread
        {
            ElapsedTime,
            ExecutionState,
            Handle,
            KernelModeTime,
            Name,
            Priority,
            PriorityBase,
            ProcessHandle,
            StartAddress,
            ThreadState,
            ThreadWaitReason,
            UserModeTime
        }

        public enum WmiInfoService
        {
            AcceptPause,
            AcceptStop,
            CheckPoint,
            DesktopInteract,
            DisplayName,
            ErrorControl,
            ExitCode,
            Name,
            PathName,
            ProcessId,
            ServiceSpecificExitCode,
            ServiceType,
            Started,
            StartMode,
            StartName,
            State,
            SystemCreationClassName,
            SystemName,
            TagId,
            WaitHint
        }

        public enum WmiProcessReturnCode
        {
            SuccessfulCompletion = 0,
            AccessDenied = 2,
            InsufficientPrivilege = 3,
            UnknownFailure = 8,
            PathNotFound = 9,
            InvalidParameter = 21
        }

        public enum WmiServiceReturnCode
        {
            Success = 0,
            NotSupported = 1,
            AccessDenied = 2,
            DependentServicesRunning = 3,
            InvalidServiceControl = 4,
            ServiceCannotAcceptControl = 5,
            ServiceNotActive = 6,
            ServiceRequestTimeout = 7,
            UnknownFailure = 8,
            PathNotFound = 9,
            ServiceAlreadyRunning = 10,
            ServiceDatabaseLocked = 11,
            ServiceDependencyDeleted = 12,
            ServiceDependencyFailure = 13,
            ServiceDisabled = 14,
            ServiceLogonFailure = 15,
            ServiceMarkedForDeletion = 16,
            ServiceNoThread = 17,
            StatusCircularDependency = 18,
            StatusDuplicateName = 19,
            StatusInvalidName = 20,
            StatusInvalidParameter = 21,
            StatusInvalidServiceAccount = 22,
            StatusServiceExists = 23,
            ServiceAlreadyPaused = 24
        }

        [Flags]
        public enum WmiShutdownValues : int
        {
            LogOff = 0,
            Shutdown = 1,
            Reboot = 2,
            PowerOff = 8,
            Force = 4
        }


        // OK

        public enum AsyncWindowAction : int
        {
            Close,
            Flash,
            StopFlashing,
            BringToFront,
            SetAsForegroundWindow,
            SetAsActiveWindow,
            Minimize,
            Maximize,
            Show,
            Hide,
            SendMessage,
            SetOpacity,
            SetEnabled,
            SetPosition,
            SetCaption
        }


        // OK

        public enum HandleObjectType
        {
            Adapter,
            AlpcPort,
            Callback,
            Controller,
            DebugObject,
            Desktop,
            Device,
            Directory,
            Driver,
            EtwRegistration,
            Event,
            EventPair,
            File,
            FilterCommunicationPort,
            FilterConnectionPort,
            IoCompletion,
            Job,
            Key,
            KeyedEvent,
            Mutant,
            Process,
            Profile,
            Section,
            Semaphore,
            Session,
            SymbolicLink,
            Thread,
            Timer,
            TmEn,
            TmRm,
            TmTm,
            TmTx,
            Token,
            TpWorkerFactory,
            Type,
            WindowStation,
            WmiGuid
        }


        // OK

        public enum ShutdownType : byte
        {
            Restart,
            Shutdown,
            Poweroff,
            Sleep,
            Hibernate,
            Logoff,
            Lock
        }


        // OK

        [Flags()]
        public enum GeneralObjectType
        {
            Window = 0x1,
            Process = 0x2,
            Service = 0x4,
            Handle = 0x8,
            EnvironmentVariable = 0x10,
            Module = 0x20,
            JobLimit = 0x40,
            Job = 0x80,
            Log = 0x100,
            MemoryRegion = 0x200,
            NetworkConnection = 0x400,
            Privilege = 0x800,
            SearchItem = 0x1000,
            Task = 0x2000,
            Thread = 0x4000,
            Heap = 0x8000
        }

        [Flags()]
        public enum SnapshotObject
        {
            Windows = 0x1,
            Services = 0x4,
            Handles = 0x8,
            EnvironmentVariables = 0x10,
            Modules = 0x20,
            JobLimits = 0x40,
            Jobs = 0x80,
            MemoryRegions = 0x200,
            NetworkConnections = 0x400,
            Privileges = 0x800,
            Tasks = 0x2000,
            Threads = 0x4000,
            Heaps = 0x8000,
            All = SnapshotObject.Windows | SnapshotObject.Services | SnapshotObject.Handles | SnapshotObject.EnvironmentVariables | SnapshotObject.Modules | SnapshotObject.JobLimits | SnapshotObject.Jobs | SnapshotObject.MemoryRegions | SnapshotObject.NetworkConnections | SnapshotObject.Privileges | SnapshotObject.Tasks | SnapshotObject.Threads | SnapshotObject.Heaps
        }
    }
}
