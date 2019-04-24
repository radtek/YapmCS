using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Thread
    {

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Memory alloc for thread enumeration
        private static Native.Memory.MemoryAlloc memAllocForThreadEnum = new Native.Memory.MemoryAlloc(0x1000);   // NOTE : never unallocated


        // ========================================
        // Public properties
        // ========================================

        // Min rights for Query
        public static Native.Security.ThreadAccess ThreadQueryMinRights
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
                Static _minRights As Native.Security.ThreadAccess = Native.Security.ThreadAccess.QueryInformation

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
                        _minRights = Native.Security.ThreadAccess.QueryLimitedInformation;
                }
                return _minRights;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Get affinity
        public static IntPtr GetThreadAffinityByHandle(IntPtr handle)
        {
            Native.Api.NativeStructs.ThreadBasicInformation infos = new Native.Api.NativeStructs.ThreadBasicInformation();
            int ret;
            Native.Api.NativeFunctions.NtQueryInformationThread(handle, Native.Api.NativeEnums.ThreadInformationClass.ThreadBasicInformation, ref infos, Marshal.SizeOf(infos), out ret);
            return infos.AffinityMask;
        }

        // Set affinity
        public static bool SetThreadAffinityById(int tid, IntPtr affinity)
        {
            IntPtr hThread;
            bool r;
            hThread = Native.Api.NativeFunctions.OpenThread(Native.Security.ThreadAccess.QueryInformation | Security.ThreadAccess.SetInformation, false, tid);
            if (hThread.IsNotNull())
            {
                r = (Native.Api.NativeFunctions.SetThreadAffinityMask(hThread, affinity).IsNotNull());
                Native.Api.NativeFunctions.CloseHandle(hThread);
            }
            return r;
        }

        // Set priority
        public static bool SetThreadPriorityById(int tid, System.Diagnostics.ThreadPriorityLevel priority)
        {
            IntPtr hThread;
            bool r;
            hThread = Native.Api.NativeFunctions.OpenThread(Native.Security.ThreadAccess.SetInformation, false, tid);
            if (hThread.IsNotNull())
            {
                r = Native.Api.NativeFunctions.SetThreadPriority(hThread, priority);
                Native.Api.NativeFunctions.CloseHandle(hThread);
            }
            return r;
        }

        // Get priority of a thread
        public static int GetThreadPriorityByHandle(IntPtr handle)
        {
            return Native.Api.NativeFunctions.GetThreadPriority(handle);
        }

        // Get a valid handle on a thread
        public static IntPtr GetThreadHandle(int tid, Native.Security.ThreadAccess access)
        {
            return Native.Api.NativeFunctions.OpenThread(access, false, tid);
        }

        // Resume a thread
        public static bool ResumeThreadByHandle(IntPtr hThread)
        {
            if (hThread.IsNotNull())
                return NativeFunctions.ResumeThread(hThread) > 0;
            else
                return false;
        }
        public static bool ResumeThreadById(int thread)
        {

            // Open handle, resume thread and close handle
            IntPtr hThread = NativeFunctions.OpenThread(Security.ThreadAccess.SuspendResume, false, thread);
            bool ret = ResumeThreadByHandle(hThread);
            NativeFunctions.CloseHandle(hThread);

            return ret;
        }


        // Suspend a thread
        public static bool SuspendThreadByHandle(IntPtr hThread)
        {
            if (hThread.IsNotNull())
                return NativeFunctions.SuspendThread(hThread) > -1;
            else
                return false;
        }
        public static bool SuspendThreadById(int thread)
        {

            // Open handle, suspend thread and close handle
            IntPtr hThread = NativeFunctions.OpenThread(Security.ThreadAccess.SuspendResume, false, thread);
            bool ret = SuspendThreadByHandle(hThread);
            NativeFunctions.CloseHandle(hThread);

            return ret;
        }

        // Kill a thread
        public static bool KillThreadById(int tid, int exitCode = 0)
        {
            IntPtr hThread;
            bool ret;
            hThread = Native.Api.NativeFunctions.OpenThread(Native.Security.ThreadAccess.Terminate, false, tid);
            if (hThread.IsNotNull())
            {
                ret = Native.Api.NativeFunctions.TerminateThread(hThread, exitCode);
                Native.Api.NativeFunctions.CloseHandle(hThread);
            }

            return ret;
        }

        // Kill a thread 
        public static bool KillThreadByHandle(IntPtr hThread, int exitCode = 0)
        {
            bool ret;
            if (hThread.IsNotNull())
                ret = Native.Api.NativeFunctions.TerminateThread(hThread, exitCode);
            return ret;
        }

        // Enumerate threads
        public static void EnumerateThreadsByProcessId(ref Dictionary<string, threadInfos> _dico, int pid)
        {
            int deltaOff = Marshal.SizeOf(typeof(Native.Api.NativeStructs.SystemProcessInformation));

            int ret;
            Native.Api.NativeFunctions.NtQuerySystemInformation(Native.Api.NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForThreadEnum.Pointer, memAllocForThreadEnum.Size, ref ret);
            if (memAllocForThreadEnum.Size < ret)
                memAllocForThreadEnum.Resize(ret);
            Native.Api.NativeFunctions.NtQuerySystemInformation(Native.Api.NativeEnums.SystemInformationClass.SystemProcessInformation, memAllocForThreadEnum.Pointer, memAllocForThreadEnum.Size, ref ret);

            // Extract structures from unmanaged memory
            int x = 0;
            int offset = 0;
            while (true)
            {
                Native.Api.NativeStructs.SystemProcessInformation obj = memAllocForThreadEnum.ReadStructOffset<Native.Api.NativeStructs.SystemProcessInformation>(offset);

                // If this is the desired process...
                if (obj.ProcessId == pid)
                {
                    var loopTo = obj.NumberOfThreads - 1;
                    for (int j = 0; j <= loopTo; j++)
                    {
                        Native.Api.NativeStructs.SystemThreadInformation thread = memAllocForThreadEnum.ReadStruct<Native.Api.NativeStructs.SystemThreadInformation>(offset + deltaOff, j);

                        string _key = thread.ClientId.UniqueThread.ToString() + "-" + thread.ClientId.UniqueProcess.ToString();
                        threadInfos _th = new threadInfos(ref thread);
                        if (_dico.ContainsKey(_key) == false)
                            _dico.Add(_key, _th);
                    }
                }

                offset += obj.NextEntryOffset;

                if (obj.NextEntryOffset == 0)
                    break;
                x += 1;
            }
        }
    }
}

