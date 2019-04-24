// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// This file uses third-party pieces of code under GNU 
// GPL 3.0 license. See below for details
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
// 
// 
// This file uses some work under GNU GPL 3.0 license
// The following definitions are from Process Hacker by Wj32 :
// - SystemProcessInformation
// - PebLdrData
// - LdrDataTableEntry
// - RtlUserProcessParameters
// - Peb
// - TokenPrivileges
// - TokenSource
// - TokenStatistics
// - SystemPerformanceInformation
// - SystemCacheInformation
// - SystemHandleInformation
// - EnumServiceStatusProcess
// - ServiceStatusProcess
// - ObjectTypeInformation

using System.Drawing;
using System;
using System.Runtime.InteropServices;

namespace Native.Api
{
    public class NativeStructs
    {
        public static readonly IntPtr Peb_ProcessHeapOffset = Marshal.OffsetOf(typeof(Peb), "ProcessHeap");
        public static readonly IntPtr Peb_ProcessParametersOffset = Marshal.OffsetOf(typeof(Peb), "ProcessParameters");
        public static readonly IntPtr Peb_LoaderDataOffset = Marshal.OffsetOf(typeof(Peb), "LoaderData");
        public static readonly int ProcParamBlock_CommandLineOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "CommandLine").ToInt32();
        public static readonly int ProcParamBlock_EnvOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "Environment").ToInt32();
        public static readonly int SystemHandleInformation_ObjectTypeOffset = Marshal.OffsetOf(typeof(SystemHandleEntry), "ObjectTypeNumber").ToInt32();
        public static readonly int SystemHandleInformation_ProcessIdOffset = Marshal.OffsetOf(typeof(SystemHandleEntry), "ProcessId").ToInt32();



        // http://msdn.microsoft.com/en-us/library/ms684143(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectBasicAccountingInformation
        {
            public long TotalUserTime;
            public long TotalKernelTime;
            public long ThisPeriodTotalUserTime;
            public long ThisPeriodTotalKernelTime;
            public int TotalPageFaultCount;
            public int TotalProcesses;
            public int ActiveProcesses;
            public int TotalTerminatedProcesses;
        }

        // http://msdn.microsoft.com/en-us/library/ms684144(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectBasicAndIoAccountingInformation
        {
            public JobObjectBasicAccountingInformation BasicInfo;
            public IoCounters IoInfo;
        }

        // http://msdn.microsoft.com/en-us/library/ms684147(VS.85).aspx
        // 48 bytes on x86, 64 bytes on x64 with alignment
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectBasicLimitInformation
        {
            public long PerProcessUserTimeLimit;      // 8 bytes
            public long PerJobUserTimeLimit;          // 8 bytes
            public NativeEnums.JobObjectLimitFlags LimitFlags;    // 4 bytes
            public IntPtr MinimumWorkingSetSize;      // non-fixed bytes
            public IntPtr MaximumWorkingSetSize;      // non-fixed bytes
            public int ActiveProcessLimit;        // 4 bytes
            public IntPtr Affinity;                   // non-fixed bytes
            public int PriorityClass;             // 4 bytes
            public int SchedulingClass;           // 4 bytes
        }

        // http://msdn.microsoft.com/en-us/library/ms684150(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectBasicProcessIdList
        {
            public int AssignedProcessesCount;
            public int ProcessIdsCount;
            [MarshalAs(UnmanagedType.ByValArray)]
            public int[] ProcessId;
        }

        // http://msdn.microsoft.com/en-us/library/ms684152(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectBasicUiRestrictions
        {
            public NativeEnums.JobObjectBasicUiRestrictions UIRestrictionsClass;
        }

        // http://msdn.microsoft.com/en-us/library/ms684155(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectEndOfJobTimeInformation
        {
            public NativeEnums.EndOfJobTimeActionFlag EndOfJobTimeAction;
        }

        // http://msdn.microsoft.com/en-us/library/ms684156(VS.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct JobObjectExtendedLimitInformation
        {
            public JobObjectBasicLimitInformation BasicLimitInformation;
            public IoCounters IoInfo;             // 48 bytes
            public IntPtr ProcessMemoryLimit;     // non-fixed bytes
            public IntPtr JobMemoryLimit;         // non-fixed bytes
            public IntPtr PeakProcessMemoryUsed;  // non-fixed bytes
            public IntPtr PeakJobMemoryUsed;      // non-fixed bytes
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SecurityAttributes
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }



        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct IoCounters
        {
            public ulong ReadOperationCount;
            public ulong WriteOperationCount;
            public ulong OtherOperationCount;
            public ulong ReadTransferCount;
            public ulong WriteTransferCount;
            public ulong OtherTransferCount;
            public static bool operator !=(IoCounters i1, IoCounters i2)
            {
                return !(i1 == i2);
            }
            public static bool operator ==(IoCounters i1, IoCounters i2)
            {
                return (i1.ReadOperationCount == i2.ReadOperationCount && i1.WriteOperationCount == i2.WriteOperationCount && i1.OtherOperationCount == i2.OtherOperationCount && i1.ReadTransferCount == i2.ReadTransferCount && i1.WriteTransferCount == i2.WriteTransferCount && i1.OtherTransferCount == i2.OtherTransferCount);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LdrDataTableEntry
        {
            public ListEntry InLoadOrderLinks;
            public ListEntry InMemoryOrderLinks;
            public ListEntry InInitializationOrderLinks;
            public IntPtr DllBase;
            public IntPtr EntryPoint;
            public int SizeOfImage;
            public UnicodeString FullDllName;
            public UnicodeString BaseDllName;
            public NativeEnums.LdrpDataTableEntryFlags Flags;
            public ushort LoadCount;
            public short TlsIndex;
            public ListEntry HashTableEntry;
            public int TimeDateStamp;
            public IntPtr EntryPointActivationContext;
            public IntPtr PatchInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ListEntry
        {
            public IntPtr Flink;
            public IntPtr Blink;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Peb
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool InheritedAddressSpace;
            [MarshalAs(UnmanagedType.I1)]
            public bool ReadImageFileExecOptions;
            [MarshalAs(UnmanagedType.I1)]
            public bool BeingDebugged;
            [MarshalAs(UnmanagedType.I1)]
            public bool Spare;
            public IntPtr Mutant;
            public IntPtr ImageBaseAddress;
            public IntPtr LoaderData;             // pointer to ldrData
            public IntPtr ProcessParameters;      // pointer to RtlUserProcessParameters struct
            public IntPtr SubSystemData;
            public IntPtr ProcessHeap;
            public IntPtr FastPebLock;
            public IntPtr FastPebLockRoutine;
            public IntPtr FastPebUnlockRoutine;
            public int EnvironmentUpdateCount;
            public IntPtr KernelCallbackTable;
            public int EventLogSection;
            public int EventLog;
            public IntPtr FreeList;
            public int TlsExpansionCounter;
            public IntPtr TlsBitmap;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public int[] TlsBitmapBits;
            public IntPtr ReadOnlySharedMemoryBase;
            public IntPtr ReadOnlySharedMemoryHeap;
            public IntPtr ReadOnlyStaticServerData;
            public IntPtr AnsiCodePageData;
            public IntPtr OemCodePageData;
            public IntPtr UnicodeCaseTableData;
            public int NumberOfProcessors;
            public int NtGlobalFlag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Spare2;
            public long CriticalSectionTimeout;
            public IntPtr HeapSegmentReserve;
            public IntPtr HeapSegmentCommit;
            public IntPtr HeapDeCommitTotalFreeThreshold;
            public IntPtr HeapDeCommitFreeBlockThreshold;
            public int NumberOfHeaps;
            public int MaximumNumberOfHeaps;
            public IntPtr ProcessHeaps;
            public IntPtr GdiSharedHandleTable;
            public IntPtr ProcessStarterHelper;
            public int GdiDCAttributeList;
            public IntPtr LoaderLock;
            public int OSMajorVersion;
            public int OSMinorVersion;
            public short OSBuildNumber;
            public short OSPlatformId;
            public int ImageSubSystem;
            public int ImageSubsystemMajorVersion;
            public int ImageSubsystemMinorVersion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
            public int[] GdiHandleBuffer;
            public IntPtr PostProcessInitRoutine;
            public IntPtr TlsExpansionBitmap;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
            public byte[] TlsExpansionBitmapBits;
            public int SessionId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PebLdrData
        {
            public int Length;
            [MarshalAs(UnmanagedType.I1)]
            public bool Initialized;
            public IntPtr SsHandle;
            public ListEntry InLoadOrderModuleList;
            public ListEntry InMemoryOrderModuleList;
            public ListEntry InInitializationOrderModuleList;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessBasicInformation
        {
            public uint ExitStatus;
            public IntPtr PebBaseAddress;
            public IntPtr AffinityMask;
            public int BasePriority;
            public IntPtr UniqueProcessId;
            public IntPtr InheritedFromUniqueProcessId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RtlUserProcessParameters
        {
            public static readonly int CurrentDirectoryOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "CurrentDirectory").ToInt32();
            public static readonly int DllPathOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "DllPath").ToInt32();
            public static readonly int ImagePathNameOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "ImagePathName").ToInt32();
            public static readonly int CommandLineOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "CommandLine").ToInt32();
            public static readonly int EnvironmentOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "Environment").ToInt32();
            public static readonly int WindowTitleOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "WindowTitle").ToInt32();
            public static readonly int DesktopInfoOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "DesktopInfo").ToInt32();
            public static readonly int ShellInfoOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "ShellInfo").ToInt32();
            public static readonly int RuntimeDataOffset = Marshal.OffsetOf(typeof(RtlUserProcessParameters), "RuntimeData").ToInt32();

            public struct CurDir
            {
                public UnicodeString DosPath;
                public IntPtr Handle;
            }

            public struct RtlDriveLetterCurDir
            {
                public ushort Flags;
                public ushort Length;
                public uint TimeStamp;
                public IntPtr DosPath;
            }

            public int MaximumLength;
            public int Length;

            public NativeEnums.RtlUserProcessFlags Flags;
            public int DebugFlags;

            public IntPtr ConsoleHandle;
            public int ConsoleFlags;
            public IntPtr StandardInput;
            public IntPtr StandardOutput;
            public IntPtr StandardError;

            public CurDir CurrentDirectory;
            public UnicodeString DllPath;
            public UnicodeString ImagePathName;
            public UnicodeString CommandLine;
            public IntPtr Environment;

            public int StartingX;
            public int StartingY;
            public int CountX;
            public int CountY;
            public int CountCharsX;
            public int CountCharsY;
            public int FillAttribute;

            public int WindowFlags;
            public int ShowWindowFlags;
            public UnicodeString WindowTitle;
            public UnicodeString DesktopInfo;
            public UnicodeString ShellInfo;
            public UnicodeString RuntimeData;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public RtlDriveLetterCurDir[] CurrentDirectories;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemProcessInformation
        {
            public int NextEntryOffset;
            public int NumberOfThreads;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public long[] Reserved1;
            public long CreateTime;
            public long UserTime;
            public long KernelTime;
            public UnicodeString ImageName;
            public int BasePriority;
            // This two variables are private cause we prefer
            // access to ProcessId and Inherited...Id as Int32
            private IntPtr _ProcessId;
            private IntPtr _InheritedFromProcessId;
            public int HandleCount;
            public int SessionId;
            public IntPtr PageDirectoryBase;
            public VmCountersEx VirtualMemoryCounters;
            public IoCounters IoCounters;

            // 2 properties to access to private variables
            public int ProcessId
            {
                get
                {
                    return _ProcessId.ToInt32();
                }
                set
                {
                    _ProcessId = new IntPtr(value);
                }
            }
            public int InheritedFromProcessId
            {
                get
                {
                    return _InheritedFromProcessId.ToInt32();
                }
                set
                {
                    _InheritedFromProcessId = new IntPtr(value);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct VmCountersEx
        {
            public IntPtr PeakVirtualSize;
            public IntPtr VirtualSize;
            public int PageFaultCount;
            public IntPtr PeakWorkingSetSize;
            public IntPtr WorkingSetSize;
            public IntPtr QuotaPeakPagedPoolUsage;
            public IntPtr QuotaPagedPoolUsage;
            public IntPtr QuotaPeakNonPagedPoolUsage;
            public IntPtr QuotaNonPagedPoolUsage;
            public IntPtr PagefileUsage;
            public IntPtr PeakPagefileUsage;
            public IntPtr PrivateBytes;
            public static bool operator !=(VmCountersEx m1, VmCountersEx m2)
            {
                return !(m1 == m2);
            }
            public static bool operator ==(VmCountersEx i1, VmCountersEx i2)
            {
                return (i1.PeakVirtualSize == i2.PeakVirtualSize && i1.VirtualSize == i2.VirtualSize && i1.PageFaultCount == i2.PageFaultCount && i1.PeakWorkingSetSize == i2.PeakWorkingSetSize && i1.WorkingSetSize == i2.WorkingSetSize && i1.QuotaPeakPagedPoolUsage == i2.QuotaPeakPagedPoolUsage && i1.QuotaPagedPoolUsage == i2.QuotaPagedPoolUsage && i1.QuotaPeakNonPagedPoolUsage == i2.QuotaPeakNonPagedPoolUsage && i1.QuotaNonPagedPoolUsage == i2.QuotaNonPagedPoolUsage && i1.PagefileUsage == i2.PagefileUsage && i1.PeakPagefileUsage == i2.PeakPagefileUsage && i1.PrivateBytes == i2.PrivateBytes);
            }
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryBasicInformation
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public NativeEnums.MemoryProtectionType AllocationProtect;
            public IntPtr RegionSize;
            public NativeEnums.MemoryState State;
            public NativeEnums.MemoryProtectionType Protect;
            public NativeEnums.MemoryType Type;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemThreadInformation
        {
            public long KernelTime;
            public long UserTime;
            public long CreateTime;
            public int WaitTime;
            public IntPtr StartAddress;
            public ClientId ClientId;
            public int Priority;
            public int BasePriority;
            public int ContextSwitchCount;
            public System.Diagnostics.ThreadState State;
            public NativeEnums.KwaitReason WaitReason;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ThreadBasicInformation
        {
            public uint ExitStatus;
            public IntPtr TebBaseAddress;
            public ClientId ClientId;
            public IntPtr AffinityMask;
            public int Priority;
            public int BasePriority;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct ClientId
        {
            public IntPtr UniqueProcess;
            public IntPtr UniqueThread;
            public ClientId(IntPtr processId, IntPtr threadId)
            {
                UniqueProcess = processId;
                UniqueThread = threadId;
            }
            public ClientId(int processId, int threadId)
            {
                UniqueProcess = new IntPtr(processId);
                UniqueThread = new IntPtr(threadId);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Luid
        {
            public int lowpart;
            public int highpart;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LuidAndAttributes
        {
            public Luid pLuid;
            public NativeEnums.SePrivilegeAttributes Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PrivilegeInfo
        {
            public string Name;
            public NativeEnums.SePrivilegeAttributes Status;
            public Luid pLuid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SidAndAttributes
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TokenPrivileges
        {
            public int PrivilegeCount;
            [MarshalAs(UnmanagedType.ByValArray)]
            public LuidAndAttributes[] Privileges;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TokenSource
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string SourceName;
            public Luid SourceIdentifier;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TokenStatistics
        {
            public Luid TokenId;
            public Luid AuthenticationId;
            public long ExpirationTime;
            public NativeEnums.TokenType TokenType;
            public NativeEnums.SecurityImpersonationLevel ImpersonationLevel;
            public int DynamicCharged;
            public int DynamicAvailable;
            public int GroupCount;
            public int PrivilegeCount;
            public Luid ModifiedId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TokenUser
        {
            public SidAndAttributes User;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct MibTcp6RowOwnerPid
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] LocalAddr;
            public uint LocalScopeId;
            public int LocalPort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] RemoteAddr;
            public uint RemoteScopeId;
            public int RemotePort;
            public Enums.MibTcpState State;
            public int OwningPid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MibTcpRow
        {
            public Enums.MibTcpState State;
            public uint LocalAddress;
            public int LocalPort;
            public uint RemoteAddress;
            public int RemotePort;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MibTcpRowOwnerPid
        {
            public int State;
            public int LocalAddr;
            public int LocalPort;
            public int RemoteAddr;
            public int RemotePort;
            public int OwningPid;
        }

        // http://msdn.microsoft.com/en-us/library/aa924123.aspx
        [StructLayout(LayoutKind.Sequential)]
        public struct MibTcpStats
        {
            public NativeEnums.MibTcpRtoAlgorithm RtoAlgorithm;
            public uint RtoMin;
            public uint RtoMax;
            public uint MaxConn;
            public uint ActiveOpens;
            public uint PassiveOpens;
            public uint AttemptFails;
            public uint EstabResets;
            public uint CurrEstab;
            public uint InSegs;
            public uint OutSegs;
            public uint RetransSegs;
            public uint InErrs;
            public uint OutRsts;
            public uint NumConns;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MibUdp6RowOwnerId
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] LocalAddr;
            public int LocalScopeId;
            public int LocalPort;
            public int OwningPid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MibUdpRowOwnerId
        {
            public int LocalAddr;
            public int LocalPort;
            public int OwningPid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MibUdpStats
        {
            public uint InDatagrams;
            public uint NoPorts;
            public uint InErrors;
            public uint OutDatagrams;
            public uint NumAddrs;
        }

        public struct NetResource
        {
            /// <summary>
            /// Scope of the enumeration.
            /// </summary>
            public NativeEnums.NetResourceScope dwScope;

            /// <summary>
            /// Set of bit flags identifying the type of resource.
            /// </summary>
            public NativeEnums.NetResourceType dwType;

            /// <summary>
            /// Display options for the network object in a network browsing user interface.
            /// </summary>
            public NativeEnums.NetResourceDisplayType dwDisplayType;

            /// <summary>
            /// Set of bit flags describing how the resource can be used.
            /// Note that this member can be specified only if the dwScope member is equal to RESOURCE_GLOBALNET.
            /// </summary>
            public NativeEnums.NetResourceUsage dwUsage;

            /// <summary>
            /// If the dwScope member is equal to RESOURCE_CONNECTED or RESOURCE_REMEMBERED, this member is a pointer to a null-terminated character string that specifies the name of a local device. This member is NULL if the connection does not use a device.
            /// </summary>
            public string lpLocalName;

            /// <summary>
            /// If the entry is a network resource, this member is a pointer to a null-terminated character string that specifies the remote network name.
            /// If the entry is a current or persistent connection, lpRemoteName points to the network name associated with the name pointed to by the lpLocalName member.
            /// The string can be MAX_PATH characters in length, and it must follow the network provider's naming conventions.
            /// </summary>
            public string lpRemoteName;

            /// <summary>
            /// Pointer to a null-terminated string that contains a comment supplied by the network provider.
            /// </summary>
            public string lpComment;

            /// <summary>
            /// Pointer to a null-terminated string that contains the name of the provider that owns the resource. This member can be NULL if the provider name is unknown. To retrieve the provider name, you can call the WNetGetProviderName function.
            /// </summary>
            public string lpProvider;
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct ByHandleFileInformation
        {
            public long dwFileAttributes;
            public FileTime ftCreationTime;
            public FileTime ftLastAccessTime;
            public FileTime ftLastWriteTime;
            public int dwVolumeSerialNumber;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int nNumberOfLinks;
            public int nFileIndexHigh;
            public int nFileIndexLow;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FileTime
        {
            public int dwLowDateTime;
            public int dwHighDateTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShellExecuteInfo
        {
            public int cbSize;
            public NativeEnums.ShellExecuteInfoMask fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public NativeEnums.ShowWindowType nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public int dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFileInfo
        {
            public IntPtr hIcon;            // : icon
            public IntPtr iIcon;            // : icondex
            public int dwAttributes;    // : SFGAO_ flags
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct ShFileOpStruct
        {
            public IntPtr hwnd;
            public NativeEnums.FO_Func wFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTo;
            public short fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProgressTitle; // only used if FOF_SIMPLEPROGRESS
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            [MarshalAs(UnmanagedType.U2)]
            public short Year;
            [MarshalAs(UnmanagedType.U2)]
            public short Month;
            [MarshalAs(UnmanagedType.U2)]
            public short DayOfWeek;
            [MarshalAs(UnmanagedType.U2)]
            public short Day;
            [MarshalAs(UnmanagedType.U2)]
            public short Hour;
            [MarshalAs(UnmanagedType.U2)]
            public short Minute;
            [MarshalAs(UnmanagedType.U2)]
            public short Second;
            [MarshalAs(UnmanagedType.U2)]
            public short Milliseconds;
        }



        [StructLayout(LayoutKind.Sequential)]
        public class MSLLHookStruct
        {
            public Point pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ProcessorInfoUnion
        {
            [FieldOffset(0)]
            internal uint dwOemId;
            [FieldOffset(0)]
            internal ushort wProcessorArchitecture;
            [FieldOffset(2)]
            internal ushort wReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemBasicInformation
        {
            public int Reserved;
            public int TimerResolution;
            public int PageSize;
            public int NumberOfPhysicalPages;
            public int LowestPhysicalPageNumber;
            public int HighestPhysicalPageNumber;
            public int AllocationGranularity;
            public IntPtr MinimumUserModeAddress;
            public IntPtr MaximumUserModeAddress;
            public IntPtr ActiveProcessorsAffinityMask;
            public byte NumberOfProcessors;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemCacheInformation
        {
            public IntPtr SystemCacheWsSize;
            public IntPtr SystemCacheWsPeakSize;
            public int SystemCacheWsFaults;
            public IntPtr SystemCacheWsMinimum;
            public IntPtr SystemCacheWsMaximum;
            public IntPtr TransitionSharedPages;
            public IntPtr TransitionSharedPagesPeak;
            public int Reserved1;
            public int Reserved2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemInfo
        {
            internal ProcessorInfoUnion uProcessorInfo;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort dwProcessorLevel;
            public ushort dwProcessorRevision;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemPerformanceInformation
        {
            /// <summary>
            /// The total idle time of all processors in units of 100-nanoseconds.
            /// </summary>
            public long IdleTime;

            /// <summary>
            /// Total bytes read by calls to NtReadFile.
            /// </summary>
            public long IoReadTransferCount;

            /// <summary>
            /// Total bytes written by calls to NtWriteFile.
            /// </summary>
            public long IoWriteTransferCount;

            /// <summary>
            /// Total bytes transferred by other I/O operations.
            /// </summary>
            public long IoOtherTransferCount;

            /// <summary>
            /// Number of calls to NtReadFile.
            /// </summary>
            public int IoReadOperationCount;

            /// <summary>
            /// Number of calls to NtWriteFile.
            /// </summary>
            public int IoWriteOperationCount;

            /// <summary>
            /// Number of calls to other I/O functions.
            /// </summary>
            public int IoOtherOperationCount;

            /// <summary>
            /// The number of pages of physical memory available.
            /// </summary>
            public int AvailablePages;

            /// <summary>
            /// The number of pages of committed virtual memory.
            /// </summary>
            public int CommittedPages;

            /// <summary>
            /// The number of pages of virtual memory that could be committed
            /// without extending the system's pagefiles.
            /// </summary>
            public int CommitLimit;

            /// <summary>
            /// The peak number of pages of committed virtual memory.
            /// </summary>
            public int PeakCommitment;

            /// <summary>
            /// The total number of soft and hard page faults.
            /// </summary>
            public int PageFaults;

            /// <summary>
            /// The number of copy-on-write page faults.
            /// </summary>
            public int CopyOnWriteFaults;

            /// <summary>
            /// The number of soft page faults.
            /// </summary>
            public int TransitionFaults;

            /// <summary>
            /// Something that the Native API reference book doesn't have.
            /// </summary>
            public int CacheTransitionFaults;

            /// <summary>
            /// The number of demand zero faults.
            /// </summary>
            public int DemandZeroFaults;

            /// <summary>
            /// The number of pages read from disk to resolve page faults.
            /// </summary>
            public int PagesRead;

            /// <summary>
            /// The number of read operations initiated to resolve page faults.
            /// </summary>
            public int PagesReadIos;

            public int CacheRead;
            public int CacheReadIos;

            /// <summary>
            /// The number of pages written to the system's pagefiles.
            /// </summary>
            public int PagefilePagesWritten;

            /// <summary>
            /// The number of write operations performed on the system's pagefiles.
            /// </summary>
            public int PagefilePagesWriteIos;

            /// <summary>
            /// The number of pages written to mapped files.
            /// </summary>
            public int MappedFilePagesWritten;

            /// <summary>
            /// The number of write operations performed on mapped files.
            /// </summary>
            public int MappedFilePageWriteIos;

            /// <summary>
            /// The number of pages used by the paged pool.
            /// </summary>
            public int PagedPoolUsage;

            /// <summary>
            /// The number of pages used by the non-paged pool.
            /// </summary>
            public int NonPagedPoolUsage;

            /// <summary>
            /// The number of allocations made from the paged pool.
            /// </summary>
            public int PagedPoolAllocs;

            /// <summary>
            /// The number of allocations returned to the paged pool.
            /// </summary>
            public int PagedPoolFrees;

            /// <summary>
            /// The number of allocations made from the non-paged pool.
            /// </summary>
            public int NonPagedPoolAllocs;

            /// <summary>
            /// The number of allocations returned to the non-paged pool.
            /// </summary>
            public int NonPagedPoolFrees;

            /// <summary>
            /// The number of available System Page Table Entries.
            /// </summary>
            public int FreeSystemPtes;

            /// <summary>
            /// The number of pages of pageable OS code and data in physical
            /// memory.
            /// </summary>
            public int SystemCodePages;

            /// <summary>
            /// The number of pages of pageable driver code and data.
            /// </summary>
            public int TotalSystemDriverPages;

            /// <summary>
            /// The number of pages of OS driver code and data.
            /// </summary>
            public int TotalSystemCodePages;

            /// <summary>
            /// The number of times an allocation could be statisfied by one of the
            /// small non-paged lookaside lists.
            /// </summary>
            public int SmallNonPagedPoolLookasideListAllocateHits;

            /// <summary>
            /// The number of times an allocation could be statisfied by one of the
            /// small paged lookaside lists.
            /// </summary>
            public int SmallPagedPoolLookasideAllocateHits;

            public int Reserved3;

            /// <summary>
            /// The number of pages of the system cache in physical memory.
            /// </summary>
            public int SystemCachePages;

            /// <summary>
            /// The number of pages of the paged pool in physical memory.
            /// </summary>
            public int PagedPoolPages;

            /// <summary>
            /// The number of pages of pageable driver code and data in physical memory.
            /// </summary>
            public int SystemDriverPages;

            /// <summary>
            /// The number of asynchronous fast read operations.
            /// </summary>
            public int FastReadNoWait;

            /// <summary>
            /// The number of synchronous fast read operations.
            /// </summary>
            public int FastReadWait;

            /// <summary>
            /// The number of fast read operations not possible because of resource
            /// conflicts.
            /// </summary>
            public int FastReadResourceMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int FastReadNotPossible;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int FastMdlReadNoWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int FastMdlReadWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int FastMdlReadResourceMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int FastMdlReadNotPossible;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MapDataNoWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MapDataWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MapDataNoWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MapDataWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int PinMappedDataCount;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int PinReadNoWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int PinReadWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int PinReadNoWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int PinReadWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int CopyReadNoWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int CopyReadWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int CopyReadNoWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int CopyReadWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MdlReadNoWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MdlReadWait;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MdlReadNoWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int MdlReadWaitMiss;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int ReadAheadIos;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int LazyWriteIos;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int LazyWritePages;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int DataFlushes;

            /// <remarks>
            /// Google Books won't let me read the page containing the description
            /// for this field!
            /// </remarks>
            public int DataPages;

            /// <summary>
            /// The total number of context switches.
            /// </summary>
            public int ContextSwitches;

            /// <summary>
            /// The number of first level translation buffer fills.
            /// </summary>
            public int FirstLevelTbFills;

            /// <summary>
            /// The number of second level translation buffer fills.
            /// </summary>
            public int SecondLevelTbFills;

            /// <summary>
            /// The number of system calls executed.
            /// </summary>
            public int SystemCalls;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemProcessorPerformanceInformation
        {
            public long IdleTime;
            public long KernelTime;
            public long UserTime;
            public long DpcTime;
            public long InterruptTime;
            public int InterruptCount;
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct FlashWInfo
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public NativeEnums.FlashWInfoFlags dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PointApi
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable()]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowPlacement
        {
            public int Length;
            public NativeEnums.WindowPlacementFlags Flags;
            public NativeEnums.ShowWindowType ShowState;
            public Point MinPosition;
            public Point MaxPosition;
            public Rect NormalPosition;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct EnumServiceStatusProcess
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ServiceName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DisplayName;
            [MarshalAs(UnmanagedType.Struct)]
            public ServiceStatusProcess ServiceStatusProcess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct QueryServiceConfig
        {
            public NativeEnums.ServiceType ServiceType;
            public NativeEnums.ServiceStartType StartType;
            public NativeEnums.ServiceErrorControl ErrorControl;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string BinaryPathName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string LoadOrderGroup;
            public int TagID;
            public IntPtr Dependencies;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ServiceStartName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DisplayName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public NativeEnums.ServiceType ServiceType;
            public NativeEnums.ServiceState CurrentState;
            public NativeEnums.ServiceAccept ControlsAccepted;
            public int Win32ExitCode;
            public int ServiceSpecificExitCode;
            public int CheckPoint;
            public int WaitHint;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatusProcess
        {
            public NativeEnums.ServiceType ServiceType;
            public NativeEnums.ServiceState CurrentState;
            public NativeEnums.ServiceAccept ControlsAccepted;
            public int Win32ExitCode;
            public int ServiceSpecificExitCode;
            public int CheckPoint;
            public int WaitHint;
            public int ProcessID;
            public NativeEnums.ServiceFlags ServiceFlags;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct UnicodeString
        {
            public ushort Length;
            public ushort MaximumLength;
            public IntPtr Buffer;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct KBDLLHookStruct
        {
            public int vkCode;
            public int scanCode;
            public NativeEnums.KBDLLHookStructFlags flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStruct
        {
            public Point pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }


        // OK

        [StructLayout(LayoutKind.Sequential)]
        public struct GenericMapping
        {
            public int GenericRead;
            public int GenericWrite;
            public int GenericExecute;
            public int GenericAll;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjectAttributes
        {
            public int Length;
            public IntPtr RootDirectoryHandle;
            public IntPtr ObjectName; // PUNICODE_STRING
            public NativeEnums.ObjectFlags Attributes;
            public IntPtr SecurityDescriptor;
            public IntPtr SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjectBasicInformation
        {
            public uint Attributes;
            public int GrantedAccess;
            public uint HandleCount;
            public uint PointerCount;
            public uint PagedPoolUsage;
            public uint NonPagedPoolUsage;
            public int Reserved1;
            public int Reserved2;
            public int Reserved3;
            public uint NameInformationLength;
            public uint TypeInformationLength;
            public uint SecurityDescriptorLength;
            public ulong CreateTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjectNameInformation
        {
            public UnicodeString Name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjectTypeInformation
        {
            public UnicodeString Name;
            public int TotalNumberOfObjects;
            public int TotalNumberOfHandles;
            public int TotalPagedPoolUsage;
            public int TotalNonPagedPoolUsage;
            public int TotalNamePoolUsage;
            public int TotalHandleTableUsage;
            public int HighWaterNumberOfObjects;
            public int HighWaterNumberOfHandles;
            public int HighWaterPagedPoolUsage;
            public int HighWaterNonPagedPoolUsage;
            public int HighWaterNamePoolUsage;
            public int HighWaterHandleTableUsage;
            public int InvalidAttributes;
            public GenericMapping GenericMapping;
            public int ValidAccess;
            public byte SecurityRequired;
            public byte MaintainHandleCount;
            public ushort MaintainTypeList;
            public NativeEnums.PoolType PoolType;
            public int PagedPoolUsage;
            public int NonPagedPoolUsage;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ObjectTypesInformation
        {
            public int ObjectTypesCount;
            public ObjectTypeInformation Entries;
            public static int ObjectTypeInformationOffset
            {
                get
                {
                    return Marshal.OffsetOf(typeof(ObjectTypesInformation), "Entries").ToInt32();
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemHandleEntry
        {
            public int ProcessId;
            public byte ObjectTypeNumber;
            public NativeEnums.HandleFlags Flags;
            public short Handle;
            public IntPtr Object;
            public Security.StandardRights GrantedAccess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemHandleInformation
        {
            public int HandleCount;
            public SystemHandleEntry Entries;
            public static int HandlesOffset
            {
                get
                {
                    return Marshal.OffsetOf(typeof(SystemHandleInformation), "Entries").ToInt32();
                }
            }
        }


        // OK

        // http://www.woodmann.com/forum/blog.php?b=151
        // http://securityxploded.com/enumheaps.php
        // http://virtualkd.sysprogs.org/dox/a00098.html
        [StructLayout(LayoutKind.Sequential)]
        public struct DebugInformation
        {
            public IntPtr SectionHandle;
            public IntPtr SectionBase;
            public IntPtr RemoteSectionBase;
            public IntPtr SectionBaseDelta;
            public IntPtr EventPairHandle;
            public IntPtr RemoteEventPair;
            public IntPtr RemoteProcessId;
            public IntPtr RemoteThreadHandle;
            public int InfoClassMask;
            public IntPtr SizeOfInfo;
            public IntPtr AllocatedSize;
            public IntPtr SectionSize;
            public IntPtr ModuleInformation;
            public IntPtr BackTraceInformation;
            public IntPtr HeapInformation;
            public IntPtr LockInformation;
            public IntPtr SpecificHeap;
            public IntPtr TargetProcessHandle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public IntPtr[] Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeapBlock
        {
            public IntPtr Address;
            public int Size;
            public NativeEnums.HeapBlockFlag Flags;
            public IntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeapEntry32
        {
            public int Size;
            public IntPtr Handle;
            public IntPtr Address;
            public int BlockSize;
            public NativeEnums.HeapBlockFlag Flags;
            public int LockCount;
            public int Reserved;
            public int ProcessID;
            public int HeapID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeapInformation
        {
            public IntPtr BaseAddress;
            public int Flags;
            public ushort Granularity;
            public ushort Unknown;
            public IntPtr MemAllocated;
            public IntPtr MemCommitted;
            public int TagCount;
            public int BlockCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public int[] Reserved;
            public IntPtr Tags;
            public IntPtr Blocks;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeapList32
        {
            public int Size;
            public int ProcessID;
            public IntPtr HeapID;
            public NativeEnums.HeapListEntryFlags Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessHeaps
        {
            public int HeapsCount;
            public HeapInformation Heaps;
            public static int HeapsOffset
            {
                get
                {
                    return Marshal.OffsetOf(typeof(ProcessHeaps), "Heaps").ToInt32();
                }
            }
        }

        // http://virtualkd.sysprogs.org/dox/a00098.html
        [StructLayout(LayoutKind.Sequential)]
        public struct RtlProcessModuleInformation
        {
            public IntPtr Section;
            public IntPtr MappedBase;
            public IntPtr ImageBase;
            public int ImageSize;
            public NativeEnums.LdrpDataTableEntryFlags Flags;
            public ushort LoadOrderIndex;
            public ushort InitOrderIndex;
            public ushort LoadCount;
            public ushort OffsetToFileName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public char[] FullPathName;
        }

        // http://virtualkd.sysprogs.org/dox/a00098.html
        [StructLayout(LayoutKind.Sequential)]
        public struct RtlProcessModules
        {
            public int NumberOfModules;
            public RtlProcessModuleInformation Modules;
            public static int ModulesOffset
            {
                get
                {
                    return Marshal.OffsetOf(typeof(RtlProcessModules), "Modules").ToInt32();
                }
            }
        }


        // OK

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class WinTrustData
        {
            private int StructSize = Marshal.SizeOf(typeof(WinTrustData));
            private IntPtr PolicyCallbackData = IntPtr.Zero;
            private IntPtr SIPClientData = IntPtr.Zero;
            // required: UI choice
            private NativeEnums.WinTrustDataUIChoice UIChoice = NativeEnums.WinTrustDataUIChoice.None;
            // required: certificate revocation check options
            private NativeEnums.WinTrustDataRevocationChecks RevocationChecks = NativeEnums.WinTrustDataRevocationChecks.None;
            // required: which structure is being passed in?
            private NativeEnums.WinTrustDataChoice UnionChoice = NativeEnums.WinTrustDataChoice.File;
            // individual file
            private IntPtr FileInfoPtr;
            private NativeEnums.WinTrustDataStateAction StateAction = NativeEnums.WinTrustDataStateAction.Ignore;
            private IntPtr StateData = IntPtr.Zero;
            private string URLReference = null;
            private NativeEnums.WinTrustDataProvFlags ProvFlags = NativeEnums.WinTrustDataProvFlags.SaferFlag;
            private NativeEnums.WinTrustDataUIContext UIContext = NativeEnums.WinTrustDataUIContext.Execute;

            // constructor for silent WinTrustDataChoice.File check
            public WinTrustData(string _fileName)
            {
                WinTrustFileInfo wtfiData = new WinTrustFileInfo(_fileName);
                FileInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(WinTrustFileInfo)));
                Marshal.StructureToPtr(wtfiData, FileInfoPtr, false);
            }
            ~WinTrustData()
            {
                try
                {
                    Marshal.FreeCoTaskMem(FileInfoPtr);
                }
                finally
                {
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class WinTrustFileInfo
        {
            private int StructSize = Marshal.SizeOf(typeof(WinTrustFileInfo));
            private IntPtr pszFilePath;
            // required, file name to be verified
            private IntPtr hFile = IntPtr.Zero;
            // optional, open handle to FilePath
            private IntPtr pgKnownSubject = IntPtr.Zero;
            // optional, subject type if it is known
            public WinTrustFileInfo(string _filePath)
            {
                pszFilePath = Marshal.StringToCoTaskMemAuto(_filePath);
            }
            ~WinTrustFileInfo()
            {
                try
                {
                    Marshal.FreeCoTaskMem(pszFilePath);
                }
                finally
                {
                }
            }
        }
    }
}

