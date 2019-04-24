using System.Diagnostics;
using Microsoft.VisualBasic;
using Common;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Process
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Used to enumerate visible processes (simplified)
        private static Native.Memory.MemoryAlloc memAllocForVSProcesses = new Native.Memory.MemoryAlloc(0x1000);  // NOTE : never unallocated

        // Memory alloc for thread enumeration (kill by method)
        private static Native.Memory.MemoryAlloc memAllocForThreadEnum = new Native.Memory.MemoryAlloc(0x1000);   // NOTE : never unallocated

        // Used to enumerate visible processes (full)
        private static Native.Memory.MemoryAlloc memAllocForVProcesses = new Native.Memory.MemoryAlloc(0x1000);   // NOTE : never unallocated

        // Mem alloc for handle enumeration
        private static Native.Memory.MemoryAlloc memAllocPIDs = new Native.Memory.MemoryAlloc(0x100);             // NOTE : never unallocated

        // Protection for _currentProcesses
        private static System.Threading.Semaphore _semCurrentProcesses = new System.Threading.Semaphore(1, 1);

        // Current processes running
        private static Dictionary<string, cProcess> _currentProcesses;

        // List of new processes
        private static Dictionary<int, bool> dicoNewProcesses = new Dictionary<int, bool>();

        // Protection for dicoNewProcesses
        private static System.Threading.Semaphore _semNewProcesses = new System.Threading.Semaphore(1, 1);

        // Protection for 'kill by method'
        private static System.Threading.Semaphore _semKillByMethod = new System.Threading.Semaphore(1, 1);

        // Delegate for process termination event handler
        public delegate void ProcessHasTerminatedHandler(UInt32 ntStatus);
        // Associated struct
        public struct ProcessTerminationStruct
        {
            public IntPtr ProcessHandle;
            public ProcessHasTerminatedHandler Delegate;
            public ProcessTerminationStruct(IntPtr hProc, ProcessHasTerminatedHandler deg)
            {
                ProcessHandle = hProc;
                Delegate = deg;
            }
        }



        // ========================================
        // Public properties
        // ========================================

        // Min rights for Query
        public static Native.Security.ProcessAccess ProcessQueryMinRights
        {
            get
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
                Static _minRights As Native.Security.ProcessAccess = Native.Security.ProcessAccess.QueryInformation

 */
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
                Static checked As Boolean = False

 */
                if (@checked == false)
                {
                    @checked = true;
                    if (cEnvironment.SupportsMinRights)
                        _minRights = Native.Security.ProcessAccess.QueryLimitedInformation;
                }
                return _minRights;
            }
        }

        // Current processes
        public static Dictionary<string, cProcess> CurrentProcesses
        {
            get
            {
                return _currentProcesses;
            }
            set
            {
                _currentProcesses = value;
            }
        }
        public static System.Threading.Semaphore SemCurrentProcesses
        {
            get
            {
                return _semCurrentProcesses;
            }
        }

        // New processes
        public static Dictionary<int, bool> NewProcesses
        {
            get
            {
                return dicoNewProcesses;
            }
            set
            {
                dicoNewProcesses = value;
            }
        }
        public static System.Threading.Semaphore SemNewProcesses
        {
            get
            {
                return _semNewProcesses;
            }
        }

        // Is a process in job ?
        public static bool IsProcessInJob
        {
            get
            {
                bool res;
                NativeFunctions.IsProcessInJob(handle, IntPtr.Zero, ref res);
                return res;
            }
        }

        // Debugger present ?
        public static bool IsDebuggerPresent
        {
            get
            {
                IntPtr value;
                uint retLen;
                NativeFunctions.NtQueryInformationProcess(handle, NativeEnums.ProcessInformationClass.ProcessDebugPort, ref value, IntPtr.Size, ref retLen);
                return value.IsNotNull();
            }
        }

        // Is Wow64 ?
        public static bool IsWow64Process
        {
            get
            {
                IntPtr value;
                uint retLen;
                NativeFunctions.NtQueryInformationProcess(handle, NativeEnums.ProcessInformationClass.ProcessWow64Information, ref value, IntPtr.Size, ref retLen);
                return value.IsNotNull();
            }
        }



        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Clear new process dico
        public static void ClearNewProcessesDico()
        {
            dicoNewProcesses.Clear();
        }


        // Set affinity to a process
        public static bool SetProcessAffinityByHandle(IntPtr hProc, int affinity)
        {
            if (hProc.IsNotNull())
                return NativeFunctions.SetProcessAffinityMask(hProc, new IntPtr(affinity));
            else
                return false;
        }
        public static bool SetProcessAffinityById(int process, int affinity)
        {

            // Open handle, set affinity and close handle
            IntPtr hProc = Native.Objects.Process.GetProcessHandleById(process, Security.ProcessAccess.SetInformation);
            bool ret = SetProcessAffinityByHandle(hProc, affinity);
            NativeFunctions.CloseHandle(hProc);

            return ret;
        }

        // Set priority
        public static bool SetProcessPriorityById(int pid, System.Diagnostics.ProcessPriorityClass priority)
        {
            IntPtr hProc;
            bool r;
            hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.SetInformation);

            if (hProc.IsNotNull())
            {
                r = NativeFunctions.SetPriorityClass(hProc, priority);
                NativeFunctions.CloseHandle(hProc);
                return r;
            }
            else
                return false;
        }

        // Resume a process
        public static bool ResumeProcessById(int pid)
        {
            IntPtr hProc;
            uint r;
            hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.SuspendResume);
            if (hProc.IsNotNull())
            {
                r = NativeFunctions.NtResumeProcess(hProc);
                NativeFunctions.CloseHandle(hProc);
                return (r != 0);
            }
            else
                return false;
        }

        // Suspend a process
        public static bool SuspendProcessById(int pid)
        {
            IntPtr hProc;
            uint r;
            hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.SuspendResume);
            if (hProc.IsNotNull())
            {
                r = NativeFunctions.NtSuspendProcess(hProc);
                NativeFunctions.CloseHandle(hProc);
                return (r != 0);
            }
            else
                return false;
        }

        // Kill a process
        public static bool KillProcessById(int pid, int exitcode = 0)
        {
            IntPtr hProc;
            uint ret;
            hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.Terminate);
            if (hProc.IsNotNull())
            {
                ret = NativeFunctions.NtTerminateProcess(hProc, exitcode);
                NativeFunctions.CloseHandle(hProc);
                return ret == 0;
            }
            else
                return false;
        }

        // Get PIDs of child processes
        public static List<int> EnumerateChildProcessesById(int pid)
        {
            int ret;
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, IntPtr.Zero, 0, ref ret);
            int size = ret;
            IntPtr ptr = Marshal.AllocHGlobal(size);
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, ptr, size, ref ret);

            // Extract structures from unmanaged memory
            int x = 0;
            int offset = 0;
            List<int> _list = new List<int>();
            while (true)
            {
                NativeStructs.SystemProcessInformation obj = (NativeStructs.SystemProcessInformation)Marshal.PtrToStructure(ptr.Increment(offset), typeof(NativeStructs.SystemProcessInformation));
                offset += obj.NextEntryOffset;
                if (obj.InheritedFromProcessId == pid)
                    _list.Add(obj.ProcessId);
                if (obj.NextEntryOffset == 0)
                    break;
                x += 1;
            }
            Marshal.FreeHGlobal(ptr);

            return _list;
        }

        // Create a minidump
        public static bool CreateMiniDumpFileById(int pid, string file, NativeEnums.MiniDumpType type)
        {
            IntPtr hProc;
            int ret = -1;
            hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.QueryInformation | Security.ProcessAccess.VmRead);
            if (hProc.IsNotNull())
            {
                // Create dump file
                System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Create);
                // Write dump file
                NativeFunctions.MiniDumpWriteDump(hProc, pid, fs.SafeFileHandle.DangerousGetHandle(), type, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                NativeFunctions.CloseHandle(hProc);
                fs.Close();
                return ret != 0;
            }
            else
                return false;
        }

        // Get process affinity
        public static IntPtr GetProcessAffinityByHandle(IntPtr handle)
        {
            NativeStructs.ProcessBasicInformation pbi = new NativeStructs.ProcessBasicInformation();
            int ret;
            NativeFunctions.NtQueryInformationProcess(handle, NativeEnums.ProcessInformationClass.ProcessBasicInformation, ref pbi, Marshal.SizeOf(pbi), ref ret);
            return pbi.AffinityMask;
        }

        // Get GUI resource info
        public static int GetProcessGuiResourceByHandle(IntPtr handle, NativeEnums.GuiResourceType type)
        {
            return NativeFunctions.GetGuiResources(handle, type);
        }

        // Empty WS
        public static bool EmptyProcessWorkingSetById(int pid)
        {
            IntPtr hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.SetQuota);
            if (hProc.IsNotNull())
            {
                bool ret = NativeFunctions.SetProcessWorkingSetSize(hProc, NativeConstants.InvalidHandleValue, NativeConstants.InvalidHandleValue);
                NativeFunctions.CloseHandle(hProc);
                return ret;
            }
            else
                return false;
        }

        // Unload a module (by address)
        public static bool UnloadProcessModuleByAddress(IntPtr address, int pid)
        {
            return Objects.Module.UnloadModuleByAddress(address, pid);
        }

        // Return process path
        public static string GetProcessPathById(int pid)
        {

            // This is not trivial to get the process path for ALL processes
            // The first method we'll use is the native method (using NtQueryInformationProcess)
            // If it fails, we use the new QueryFullProcessImageName function (Vista and above)
            // If it fails, we try to retrieve file name from module
            // If it fails, ... we consider it has FAILED -__-

            string resFile = null;
            IntPtr hProc;

            // 1) Native method
            if (pid == 0)
                return "[Idle process]";
            else if (pid == 4)
                return "SYSTEM";
            else
            {

                // Have to open a handle
                hProc = Native.Objects.Process.GetProcessHandleById(pid, Process.ProcessQueryMinRights);

                if (hProc.IsNotNull())
                {
                    // Get size
                    int _size;
                    NativeFunctions.NtQueryInformationProcess(hProc, NativeEnums.ProcessInformationClass.ProcessImageFileName, IntPtr.Zero, 0, ref _size);

                    if (_size > 0)
                    {

                        // Retrieve unicode string
                        IntPtr _pt = Marshal.AllocHGlobal(_size);
                        NativeFunctions.NtQueryInformationProcess(hProc, NativeEnums.ProcessInformationClass.ProcessImageFileName, _pt, _size, ref _size);

                        // Read it
                        NativeStructs.UnicodeString _str = (NativeStructs.UnicodeString)Marshal.PtrToStructure(_pt, typeof(NativeStructs.UnicodeString));

                        Marshal.FreeHGlobal(_pt);
                        string _stemp = Common.Misc.ReadUnicodeString(_str);

                        if (_stemp != null)
                            resFile = Common.Misc.DeviceDriveNameToDosDriveName(_stemp);
                    }
                }
            }

            // If it works, it's OK...
            resFile = Common.Misc.GetWellFormatedPath(resFile);
            if (System.IO.File.Exists(resFile))
            {
                NativeFunctions.CloseHandle(hProc);
                return resFile;
            }


            // 2) QueryFullProcessImageName on Vista and above
            if (cEnvironment.SupportsQueryFullProcessImageNameFunction)
            {
                if (hProc.IsNotNull())
                {
                    int length = 0x400;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(length);
                    NativeFunctions.QueryFullProcessImageName(hProc, false, sb, ref length);
                    try
                    {
                        resFile = sb.ToString(0, sb.Length);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
                }
            }

            // If it works, it's OK...
            resFile = Common.Misc.GetWellFormatedPath(resFile);
            if (System.IO.File.Exists(resFile))
            {
                NativeFunctions.CloseHandle(hProc);
                return resFile;
            }


            // 3) Everything failed, we'll use the main module...

            int Ret;
            System.Text.StringBuilder sResult = new System.Text.StringBuilder(0x400);
            IntPtr hModule;

            NativeFunctions.EnumProcessModules(hProc, hModule, 4, ref Ret);
            NativeFunctions.GetModuleFileNameEx(hProc, hModule, sResult, 260);
            NativeFunctions.CloseHandle(hProc);
            resFile = sResult.ToString();

            if (Strings.InStr(resFile, Constants.vbNullChar) > 1)
                resFile = Strings.Left(resFile, Strings.InStr(resFile, Constants.vbNullChar) - 1);

            resFile = Common.Misc.GetWellFormatedPath(resFile);
            if (System.IO.File.Exists(resFile) == false)
                // EPIC FAIL !
                return Program.NO_INFO_RETRIEVED;

            return resFile;
        }

        // Return Peb address
        public static IntPtr GetProcessPebAddressById(int pid)
        {
            if (pid > 4)
            {
                IntPtr hProc = Native.Objects.Process.GetProcessHandleById(pid, Process.ProcessQueryMinRights);
                NativeStructs.ProcessBasicInformation pbi = new NativeStructs.ProcessBasicInformation();
                int ret;
                NativeFunctions.NtQueryInformationProcess(hProc, NativeEnums.ProcessInformationClass.ProcessBasicInformation, ref pbi, Marshal.SizeOf(pbi), ref ret);
                NativeFunctions.CloseHandle(hProc);
                return pbi.PebBaseAddress;
            }
            else
                return IntPtr.Zero;
        }

        // Return user
        public static bool GetProcessUserDomainNameById(int pid, ref string username, ref string domain)
        {
            int retLen;
            string _UserName;

            if (pid > 4)
            {
                IntPtr hToken;
                IntPtr hProc = Native.Objects.Process.GetProcessHandleById(pid, Process.ProcessQueryMinRights);

                if (NativeFunctions.OpenProcessToken(hProc, Native.Security.TokenAccess.Query, out hToken))
                {
                    NativeFunctions.GetTokenInformation(hToken, NativeEnums.TokenInformationClass.TokenUser, IntPtr.Zero, 0, ref retLen);
                    IntPtr data = Marshal.AllocHGlobal(retLen);
                    NativeFunctions.GetTokenInformation(hToken, NativeEnums.TokenInformationClass.TokenUser, data, retLen, ref retLen);

                    NativeFunctions.CloseHandle(hProc);
                    NativeFunctions.CloseHandle(hToken);

                    NativeStructs.TokenUser user = new NativeStructs.TokenUser();
                    user = (NativeStructs.TokenUser)Marshal.PtrToStructure(data, typeof(NativeStructs.TokenUser));

                    Objects.Token.GetAccountNameFromSid(user.User.Sid, ref username, ref domain);
                    Marshal.FreeHGlobal(data);

                    return true;
                }
                else
                {
                    _UserName = "";
                    return false;
                }
            }
            else
            {
                domain = "";
                username = "";
                return false;
            }
        }

        // Return the command line
        // Second parameter is optional
        public static string GetProcessCommandLineById(int pid, IntPtr pebAddress)
        {
            try
            {
                string res = "";

                // Get PEB address of process (from parameter or using GetProcessPebAddressById) 
                if (pebAddress.IsNull())
                    pebAddress = GetProcessPebAddressById(pid);
                if (pebAddress.IsNull())
                    return "";

                // Create a reader class to read in memory
                using (ProcessMemReader memReader = new ProcessMemReader(pid))
                {
                    if (memReader.ProcessHandle.IsNull())
                        return Program.NO_INFO_RETRIEVED;// Couldn't open a handle

                    // Retrieve process parameters block address
                    IntPtr __procParamAd = memReader.ReadIntPtr(pebAddress.Increment(NativeStructs.Peb_ProcessParametersOffset));

                    // Get unicode string adress
                    NativeStructs.UnicodeString cmdLine;

                    // Read length of the unicode string
                    IntPtr cmdLineOffset = __procParamAd.Increment(NativeStructs.ProcParamBlock_CommandLineOffset);
                    cmdLine.Length = System.Convert.ToUInt16(memReader.ReadInt32(cmdLineOffset));
                    cmdLine.MaximumLength = System.Convert.ToUInt16(cmdLine.Length + 2); // Not used, but...

                    // Read pointer to the string
                    // offset = cmdLineOffset + sizeof(IntPtr.Size) for unicode_string.size
                    cmdLine.Buffer = memReader.ReadIntPtr(cmdLineOffset.Increment(IntPtr.Size));

                    // Read the string
                    res = memReader.ReadUnicodeString(cmdLine);
                }

                return res;
            }
            catch (Exception ex)
            {
                return Program.NO_INFO_RETRIEVED;
            }
        }

        // Get all visible processes (simplified)
        public static Dictionary<string, processInfos> EnumerateVisibleProcessesSimplified()
        {

            // Refresh list of drives
            Common.Misc.RefreshLogicalDrives();

            int ret;
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForVSProcesses.Pointer, memAllocForVSProcesses.Size, ref ret);
            if (memAllocForVSProcesses.Size < ret)
                memAllocForVSProcesses.Resize(ret);
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForVSProcesses.Pointer, memAllocForVSProcesses.Size, ref ret);

            // Extract structures from unmanaged memory
            int x = 0;
            int offset = 0;
            Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();
            while (true)
            {
                NativeStructs.SystemProcessInformation obj = memAllocForVSProcesses.ReadStructOffset<NativeStructs.SystemProcessInformation>(offset);
                processInfos _procInfos = new processInfos(ref obj);

                string _path = GetProcessPathById(obj.ProcessId);
                {
                    var withBlock = _procInfos;
                    withBlock.Path = _path;
                    withBlock.UserName = Program.NO_INFO_RETRIEVED;
                    withBlock.CommandLine = Program.NO_INFO_RETRIEVED;
                    withBlock.FileInfo = null;
                    withBlock.PebAddress = IntPtr.Zero;
                }

                offset += obj.NextEntryOffset;
                string sKey = obj.ProcessId.ToString();
                if (_dico.ContainsKey(sKey) == false)
                    _dico.Add(sKey, _procInfos);

                if (obj.NextEntryOffset == 0)
                    break;
                x += 1;
            }

            return _dico;
        }

        // Get visible processes (full)
        /// <summary>
        /// Enumerate processes
        /// MUST BE protected by _semNewProcesses
        /// </summary>
        public static Dictionary<string, processInfos> EnumerateVisibleProcesses(bool forceAllInfos = false)
        {

            // Refresh list of drives
            Common.Misc.RefreshLogicalDrives();

            int ret;
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForVProcesses.Pointer, memAllocForVProcesses.Size, ref ret);
            if (memAllocForVProcesses.Size < ret)
                memAllocForVProcesses.Resize(ret);
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForVProcesses.Pointer, memAllocForVProcesses.Size, ref ret);

            // Extract structures from unmanaged memory
            int x = 0;
            int offset = 0;
            Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();
            while (true)
            {
                NativeStructs.SystemProcessInformation obj = memAllocForVProcesses.ReadStructOffset<NativeStructs.SystemProcessInformation>(offset);
                processInfos _procInfos = new processInfos(ref obj);


                // Do we have to get fixed infos ?
                if (forceAllInfos || dicoNewProcesses.ContainsKey(obj.ProcessId) == false)
                {
                    string _path = GetProcessPathById(obj.ProcessId);
                    string _domain = null;
                    string _user = null;
                    GetProcessUserDomainNameById(obj.ProcessId, ref _user, ref _domain);
                    string _command = Program.NO_INFO_RETRIEVED;
                    IntPtr _peb = GetProcessPebAddressById(obj.ProcessId);
                    if (_peb.IsNotNull())
                        _command = GetProcessCommandLineById(obj.ProcessId, _peb);
                    SerializableFileVersionInfo _finfo = null;
                    if (System.IO.File.Exists(_path))
                    {
                        try
                        {
                            _finfo = new SerializableFileVersionInfo(FileVersionInfo.GetVersionInfo(_path));
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    {
                        var withBlock = _procInfos;
                        withBlock.Path = _path;
                        withBlock.UserName = _user;
                        withBlock.DomainName = _domain;
                        withBlock.CommandLine = _command;
                        withBlock.FileInfo = _finfo;
                        withBlock.PebAddress = _peb;
                        withBlock.HasReanalize = true;
                    }

                    // Have to check if key already exists if we force retrieving
                    // of all informations, else it has already be done before
                    if (forceAllInfos == false || dicoNewProcesses.ContainsKey(obj.ProcessId) == false)
                        dicoNewProcesses.Add(obj.ProcessId, false);

                    Trace.WriteLine("Got fixed infos for id = " + obj.ProcessId.ToString());
                }

                // Set true so that the process is marked as existing
                dicoNewProcesses[obj.ProcessId] = true;

                offset += obj.NextEntryOffset;
                string sKey = obj.ProcessId.ToString();
                if (_dico.ContainsKey(sKey) == false)
                    _dico.Add(sKey, _procInfos);

                if (obj.NextEntryOffset == 0)
                    break;
                x += 1;
            }


            // Remove all processes that not exist anymore
            Dictionary<int, bool> _dicoTemp = dicoNewProcesses;
            foreach (System.Collections.Generic.KeyValuePair<int, bool> it in _dicoTemp)
            {
                if (it.Value == false)
                    dicoNewProcesses.Remove(it.Key);
            }

            // Here we fill _currentProcesses if necessary
            // PERFISSUE
            SemCurrentProcesses.WaitOne();
            if (CurrentProcesses == null)
                CurrentProcesses = new Dictionary<string, cProcess>();
            foreach (processInfos pc in _dico.Values)
            {
                if (CurrentProcesses.ContainsKey(pc.ProcessId.ToString()) == false)
                    CurrentProcesses.Add(pc.ProcessId.ToString(), new cProcess(pc));
            }
            SemCurrentProcesses.Release();

            return _dico;
        }

        // Get all hidden processes (handle method)
        public static Dictionary<string, processInfos> EnumerateHiddenProcessesHandleMethod()
        {

            // Refresh list of drives
            Common.Misc.RefreshLogicalDrives();

            // For each Process Id (PID) possible
            Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();

            // Firstly, we get all instances of csrss.exe process.
            // We retrieve them from visible list. So if csrss.exe processes are hidden... DAMN !!!
            // Note : There are more than once instance of csrss.exe on Vista.
            Dictionary<int, IntPtr> _csrss = new Dictionary<int, IntPtr>();
            foreach (processInfos proc in EnumerateVisibleProcessesSimplified.Values)
            {
                if (proc.Name.ToLowerInvariant() == "csrss.exe")
                {
                    IntPtr _theHandle = Native.Objects.Process.GetProcessHandleById(proc.ProcessId, Security.ProcessAccess.DupHandle);
                    _csrss.Add(proc.ProcessId, _theHandle);
                }
            }

            // Now we get all handles from all processes
            NativeStructs.SystemHandleEntry[] _handles = EnumerateProcessHandles();

            // For handles which belongs to a csrss.exe process
            foreach (NativeStructs.SystemHandleEntry h in _handles)
            {
                if (_csrss.ContainsKey(h.ProcessId))
                {
                    IntPtr _dup;
                    // ISNEEDED ?
                    if (NativeFunctions.DuplicateHandle(_csrss[h.ProcessId], (IntPtr)h.Handle, NativeConstants.InvalidHandleValue, ref _dup, 0, false, NativeEnums.DuplicateOptions.SameAccess))
                    {
                        int pid = NativeFunctions.GetProcessId(_dup);
                        NativeStructs.SystemProcessInformation obj = new NativeStructs.SystemProcessInformation();
                        {
                            var withBlock = obj;
                            withBlock.ProcessId = pid;
                        }
                        string _path = GetProcessPathById(obj.ProcessId);
                        processInfos _procInfos = new processInfos(ref obj, cFile.GetFileName(_path));
                        _procInfos.Path = _path;
                        if (_dico.ContainsKey(pid.ToString()) == false)
                            _dico.Add(pid.ToString(), _procInfos);
                    }
                    NativeFunctions.CloseHandle(_dup);
                }
            }

            // Add the two instances of csrss.exe to result
            // & close previously opened handles
            foreach (int h in _csrss.Keys)
            {
                NativeStructs.SystemProcessInformation obj = new NativeStructs.SystemProcessInformation();
                {
                    var withBlock1 = obj;
                    withBlock1.ProcessId = h;
                }
                string _path = GetProcessPathById(obj.ProcessId);
                processInfos _procInfos = new processInfos(ref obj, cFile.GetFileName(_path));
                _procInfos.Path = _path;
                if (_dico.ContainsKey(h.ToString()) == false)
                    _dico.Add(h.ToString(), _procInfos);

                NativeFunctions.CloseHandle(_csrss[h]);
            }


            // Get visible processes
            Dictionary<string, processInfos> _visible = EnumerateVisibleProcessesSimplified();

            // Merge results
            foreach (processInfos pp in _visible.Values)
            {
                if (_dico.ContainsKey(pp.ProcessId.ToString()) == false)
                    _dico.Add(pp.ProcessId.ToString(), pp);
            }

            // Mark processes that are not present in _visible as hidden
            foreach (processInfos pp in _dico.Values)
            {
                if (_visible.ContainsKey(pp.ProcessId.ToString()) == false)
                    pp.IsHidden = true;
            }

            return _dico;
        }

        // Get all hidden processes (brute force)
        public static Dictionary<string, processInfos> EnumerateHiddenProcessesBruteForce()
        {

            // Refresh list of drives
            Common.Misc.RefreshLogicalDrives();

            // For each Process Id (PID) possible
            Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();

            // For each PID...
            for (int pid = 0x8; pid <= 0xFFFF; pid += 4)
            {
                IntPtr handle = Native.Objects.Process.GetProcessHandleById(pid, Process.ProcessQueryMinRights);
                if (handle.IsNotNull())
                {
                    int exitcode;
                    bool res = NativeFunctions.GetExitCodeProcess(handle, ref exitcode);
                    if (exitcode == NativeConstants.STILL_ACTIVE)
                    {
                        NativeStructs.SystemProcessInformation obj = new NativeStructs.SystemProcessInformation();
                        {
                            var withBlock = obj;
                            withBlock.ProcessId = pid;
                        }
                        string _path = GetProcessPathById(obj.ProcessId);
                        processInfos _procInfos = new processInfos(ref obj, cFile.GetFileName(_path));
                        _procInfos.Path = _path;
                        string sKey = pid.ToString();
                        if (_dico.ContainsKey(sKey) == false)
                            _dico.Add(sKey, _procInfos);
                    }
                    NativeFunctions.CloseHandle(handle);
                }
            }

            // Get visible processes
            Dictionary<string, processInfos> _visible = EnumerateVisibleProcessesSimplified();

            // Merge results
            foreach (processInfos pp in _visible.Values)
            {
                if (_dico.ContainsKey(pp.ProcessId.ToString()) == false)
                    _dico.Add(pp.ProcessId.ToString(), pp);
            }

            // Mark processes that are not present in _visible as hidden
            foreach (processInfos pp in _dico.Values)
            {
                if (_visible.ContainsKey(pp.ProcessId.ToString()) == false)
                    pp.IsHidden = true;
            }

            return _dico;
        }

        // Get a service by name
        public static cProcess GetProcessById(int id)
        {
            cProcess tt = null;
            Native.Objects.Process.SemCurrentProcesses.WaitOne();
            if (_currentProcesses != null)
            {
                if (_currentProcesses.ContainsKey(id.ToString()))
                    tt = _currentProcesses[id.ToString()];
            }
            Native.Objects.Process.SemCurrentProcesses.Release();

            return tt;
        }

        // Return a handle for a process
        public static IntPtr GetProcessHandleById(int pid, Security.ProcessAccess access)
        {
            return NativeFunctions.OpenProcess(access, false, pid);
        }

        // Kill a process by method
        // Suspend calling thread 3 seconds !!
        public static bool KillProcessByMethod(int pid, Enums.KillMethod method)
        {
            _semKillByMethod.WaitOne();

            if ((method & Enums.KillMethod.NtTerminate) == Enums.KillMethod.NtTerminate)
                KillByMethod_NtTerminateProcess(pid);
            if ((method & Enums.KillMethod.ThreadTerminate) == Enums.KillMethod.ThreadTerminate)
                KillByMethod_NtTerminateThread(pid);
            if ((method & Enums.KillMethod.ThreadTerminate_GetNextThread) == Enums.KillMethod.ThreadTerminate_GetNextThread)
                KillByMethod_NtTerminateThreadNt(pid);
            if ((method & Enums.KillMethod.CreateRemoteThread) == Enums.KillMethod.CreateRemoteThread)
                KillByMethod_CreateRemoteThread(pid);
            if ((method & Enums.KillMethod.CloseAllHandles) == Enums.KillMethod.CloseAllHandles)
                KillByMethod_CloseAllHandles(pid);
            if ((method & Enums.KillMethod.CloseAllWindows) == Enums.KillMethod.CloseAllWindows)
                KillByMethod_CloseAllWindows(pid);
            if ((method & Enums.KillMethod.TerminateJob) == Enums.KillMethod.TerminateJob)
                KillByMethod_TerminateJobObject(pid);

            // Wait process to crash...
            System.Threading.Thread.Sleep(3000);

            // Now retrieve exitCode to see if process is still running or not
            bool ret;
            int exitC;
            IntPtr hProc = GetProcessHandleWById(pid, Process.ProcessQueryMinRights);
            if (hProc.IsNotNull())
            {
                NativeFunctions.GetExitCodeProcess(hProc, ref exitC);
                ret = (exitC != NativeConstants.STILL_ACTIVE);
                Native.Objects.General.CloseHandle(hProc);
            }
            else
                ret = false;

            _semKillByMethod.Release();
            return ret;
        }


        // Wait for a process to terminate
        // Must be called in another thread
        // Context.ProcessHanlde need Synchronize Or QueryMinInformation access
        public static void WaitForProcessToTerminate(object context)
        {
            ProcessTerminationStruct pObj = (ProcessTerminationStruct)context;

            if (pObj.ProcessHandle.IsNotNull())
            {
                // Wait process to terminate (infinite timeout)
                // -1 != INFINITE, but if we use the INFINITE value (Const INFINITE = &HFFFF)
                // it just waits 65 seconds... Oh yeah -__-
                NativeEnums.WaitResult ret = NativeFunctions.WaitForSingleObject(pObj.ProcessHandle, -1);

                // Get exit code
                uint exCode;
                NativeFunctions.GetExitCodeProcess(pObj.ProcessHandle, ref exCode);

                if (pObj.Delegate != null)
                {
                    try
                    {
                        pObj.Delegate.Invoke(exCode);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
                }
            }
        }





        // ========================================
        // Private functions
        // ========================================

        // Enumerate all handes opened by all processes
        private static NativeStructs.SystemHandleEntry[] EnumerateProcessHandles()
        {
            int handleCount = 0;
            int retLen;
            NativeStructs.SystemHandleEntry[] _handles;

            // I did not manage to get the good needed size with the first call to
            // NtQuerySystemInformation with SystemHandleInformation flag when the buffer
            // is too small. So each time the call to NtQuerySystemInformation fails with
            // a too small buffer, the size is multiplicated by 2 and I call NtQuerySystemInformation
            // again. And again, until the return is not STATUS_INFO_LENGTH_MISMATCH.
            // Strange behavior.
            // See http://forum.sysinternals.com/forum_posts.asp?TID=3577 for details.
            const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;

            int size = 0x400;
            using (Memory.MemoryAlloc memAlloc = new Memory.MemoryAlloc(size))
            {
                while (System.Convert.ToUInt32(NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemHandleInformation, memAlloc.Pointer, size, ref retLen)) == STATUS_INFO_LENGTH_MISMATCH)
                {
                    size *= 2;
                    memAlloc.Resize(size);
                }

                handleCount = memAlloc.ReadStruct<NativeStructs.SystemHandleInformation>().HandleCount;
                _handles = new NativeStructs.SystemHandleEntry[handleCount - 1 + 1];
                int handlesOffset = NativeStructs.SystemHandleInformation.HandlesOffset;
                var loopTo = handleCount - 1;
                for (int x = 0; x <= loopTo; x++)
                {
                    NativeStructs.SystemHandleEntry temp = memAlloc.ReadStruct<NativeStructs.SystemHandleEntry>(handlesOffset, x);

                    _handles[x] = temp;
                }
            }

            return _handles;
        }

        // Open a handle (another method if OpenProcess failed)
        private static IntPtr GetProcessHandleWById(int pid, Security.ProcessAccess access)
        {

            // ===== Try standard way
            IntPtr hProc = GetProcessHandleById(pid, access);
            if (hProc.IsNotNull())
                return hProc;


            // ===== Use NtOpenProcess (if OpenProcess is hooked and not NtOpenProcess)
            NativeStructs.ObjectAttributes _oa;
            NativeStructs.ClientId _clientId = new NativeStructs.ClientId(pid, 0);
            NativeFunctions.NtOpenProcess(out hProc, access, ref _oa, ref _clientId);
            if (hProc.IsNotNull())
                return hProc;


            // ===== Try another way (using NtGetNextProcess, VISTA ONLY)
            if (cEnvironment.SupportsGetNextThreadProcessFunctions)
            {
                // Open handle to our process

                IntPtr curHandle = GetProcessHandleById(NativeFunctions.GetCurrentProcessId(), access);
                // Define access to use
                Security.ProcessAccess theAccess;
                if ((access & Security.ProcessAccess.QueryLimitedInformation) != Security.ProcessAccess.QueryLimitedInformation && (access & Security.ProcessAccess.QueryInformation) != Security.ProcessAccess.QueryInformation)
                    theAccess = access | Security.ProcessAccess.QueryLimitedInformation;
                else
                    theAccess = access;
                // Try to find a handle using NtGetNextProcess
                int i = 0;        // Watchdog
                while (true)
                {
                    NativeFunctions.NtGetNextProcess(curHandle, access, 0, 0, out curHandle);
                    // Get process Id of this handle
                    if (curHandle.IsNotNull())
                    {
                        int thePid = NativeFunctions.GetProcessId(curHandle);
                        if (thePid == pid)
                            return curHandle;
                    }
                    i += 1;
                    // We assume there are less than 800 processes...
                    if (i > 800)
                        break;
                }
            }

            // Okay, everything failed....
            return IntPtr.Zero;
        }


        // Standard 'NtTerminateProcess' call
        private static void KillByMethod_NtTerminateThreadNt(int pid)
        {
            if (cEnvironment.SupportsGetNextThreadProcessFunctions == false)
                return;

            IntPtr hProc = GetProcessHandleWById(pid, Security.ProcessAccess.QueryInformation);
            if (hProc.IsNotNull())
            {

                // Try to find a handle using NtGetNextProcess
                IntPtr curHandle;
                int i = 0;        // Watchdog
                while (true)
                {
                    NativeFunctions.NtGetNextThread(hProc, curHandle, Security.ThreadAccess.Terminate, 0, 0, out curHandle);
                    // Get process Id of this handle
                    if (curHandle.IsNotNull())
                        Objects.Thread.KillThreadByHandle(curHandle);
                    i += 1;
                    // I assume there are less than 800 threads...
                    if (i > 800)
                        break;
                }

                Objects.General.CloseHandle(hProc);
            }
        }

        // Kill process using NtTerminateProcess
        private static bool KillByMethod_NtTerminateProcess(int pid)
        {
            bool ret = false;
            IntPtr hProc = GetProcessHandleWById(pid, Security.ProcessAccess.Terminate);
            if (hProc.IsNotNull())
            {
                ret = (Api.NativeFunctions.NtTerminateProcess(hProc, 0) == 0);
                Objects.General.CloseHandle(hProc);
            }
            return ret;
        }

        // Suspend and then kill all threads
        private static void KillByMethod_NtTerminateThread(int pid)
        {
            int deltaOff = Marshal.SizeOf(typeof(NativeStructs.SystemProcessInformation));

            int ret;
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForThreadEnum.Pointer, memAllocForThreadEnum.Size, ref ret);
            if (memAllocForThreadEnum.Size < ret)
                memAllocForThreadEnum.Resize(ret);
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForThreadEnum.Pointer, memAllocForThreadEnum.Size, ref ret);

            // Extract structures from unmanaged memory
            int x = 0;
            int offset = 0;
            List<NativeStructs.SystemThreadInformation> listOfThread = new List<NativeStructs.SystemThreadInformation>();
            while (true)
            {
                NativeStructs.SystemProcessInformation obj = memAllocForThreadEnum.ReadStructOffset<NativeStructs.SystemProcessInformation>(offset);

                if (pid == obj.ProcessId)
                {
                    var loopTo = obj.NumberOfThreads - 1;
                    for (int j = 0; j <= loopTo; j++)
                    {
                        NativeStructs.SystemThreadInformation thread = memAllocForThreadEnum.ReadStruct<NativeStructs.SystemThreadInformation>(offset + deltaOff, j);
                        listOfThread.Add(thread);
                    }
                    break;
                }

                offset += obj.NextEntryOffset;

                if (obj.NextEntryOffset == 0)
                    break;
                x += 1;
            }

            // Now we suspend all threads
            foreach (NativeStructs.SystemThreadInformation th in listOfThread)
                Native.Objects.Thread.SuspendThreadById(th.ClientId.UniqueThread.ToInt32());

            // Now we terminate all threads
            foreach (NativeStructs.SystemThreadInformation th in listOfThread)
                Native.Objects.Thread.KillThreadById(th.ClientId.UniqueThread.ToInt32());
        }

        // Create a remote thread and then call ExitProcess
        private static void KillByMethod_CreateRemoteThread(int pid)
        {
        }

        // Assign to a new job a close the job
        private static bool KillByMethod_TerminateJobObject(int pid)
        {
            bool ret = false;
            IntPtr hProc = GetProcessHandleWById(pid, Security.ProcessAccess.Terminate | Security.ProcessAccess.SetQuota);

            if (hProc.IsNotNull())
            {

                // Create new job
                IntPtr hJob;
                NativeStructs.SecurityAttributes sa = new NativeStructs.SecurityAttributes();
                {
                    var withBlock = sa;
                    withBlock.nLength = Marshal.SizeOf(sa);
                    withBlock.bInheritHandle = true;
                    withBlock.lpSecurityDescriptor = IntPtr.Zero;
                }
                // We have all access to the job cause we created it
                // Random name
                hJob = NativeFunctions.CreateJobObject(ref sa, Api.Win32.GetElapsedTime().ToString());
                if (hJob.IsNotNull())
                {
                    // Assign process to the job and terminate it
                    if (NativeFunctions.AssignProcessToJobObject(hJob, hProc))
                        ret = NativeFunctions.TerminateJobObject(hJob, 0);

                    Objects.General.CloseHandle(hJob);
                }

                Objects.General.CloseHandle(hProc);
            }
            return ret;
        }

        // Close all handles
        private static void KillByMethod_CloseAllHandles(int pid)
        {
            IntPtr hProc = GetProcessHandleWById(pid, Security.ProcessAccess.DupHandle);
            if (hProc.IsNotNull())
            {

                // Close all handles (brute force)
                for (int i = 0; i <= 0xFFFF; i += 4)
                {
                    IntPtr ptrRet;
                    NativeFunctions.NtDuplicateObject(hProc, new IntPtr(i), IntPtr.Zero, ref ptrRet, 0, 0, NativeEnums.DuplicateOptions.CloseSource);
                }

                Objects.General.CloseHandle(hProc);
            }
        }

        // Close all handles
        private static void KillByMethod_CloseAllWindows(int pid)
        {

            // Enumerate windows
            Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();
            Objects.Window.EnumerateWindowsByProcessId(pid, false, true, ref _dico, false);

            foreach (windowInfos w in _dico.Values)
                Objects.Window.CloseWindowByHandle(w.Handle);
        }
    }
}

