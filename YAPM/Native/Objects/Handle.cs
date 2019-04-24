using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using Native.Api;

namespace Native.Objects
{
    public class Handle
    {


        // ========================================
        // Private constants
        // ========================================

        // Handle enumeration class
        private static HandleEnumeration hEnum;

        // Protect handle enumeration
        private static System.Threading.Semaphore semProtectEnum = new System.Threading.Semaphore(1, 1);


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================

        public static HandleEnumeration HandleEnumerationClass
        {
            get
            {
                return hEnum;
            }
            set
            {
                hEnum = value;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Close a handle in another process
        public static int CloseProcessLocalHandle(int dwProcessID, IntPtr hHandle)
        {
            IntPtr hMod;
            IntPtr lpProc;
            IntPtr hThread;
            IntPtr hProcess;
            int res;

            hMod = NativeFunctions.GetModuleHandle("kernel32.dll");
            lpProc = NativeFunctions.GetProcAddress(hMod, "CloseHandle");
            hProcess = Native.Objects.Process.GetProcessHandleById(dwProcessID, Native.Security.ProcessAccess.CreateThread | Native.Security.ProcessAccess.VmOperation | Native.Security.ProcessAccess.VmWrite | Native.Security.ProcessAccess.VmRead);
            if (hProcess.IsNotNull())
            {
                hThread = NativeFunctions.CreateRemoteThread(hProcess, IntPtr.Zero, 0, lpProc, hHandle, 0, out 0);
                if (hThread.IsNotNull())
                {
                    NativeFunctions.WaitForSingleObject(hThread, NativeConstants.WAIT_INFINITE);
                    NativeFunctions.GetExitCodeThread(hThread, out res);
                    NativeFunctions.CloseHandle(hThread);
                }
                NativeFunctions.CloseHandle(hProcess);
            }

            return res;
        }

        // Return handles of some processes
        public static void EnumerateHandleByProcessId(int pid, bool showUnNamed, ref Dictionary<string, handleInfos> _dico)
        {

            // Handle enumeration class not initialized...
            if (hEnum == null)
                return;

            // Protection !
            semProtectEnum.WaitOne();

            // Refresh handles
            hEnum.Refresh(pid);
            var loopTo = hEnum.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                if (hEnum.IsNotNull(i) && hEnum.GetHandle(i).IsNotNull())
                {
                    if (showUnNamed || (Strings.Len(hEnum.GetObjectName(i)) > 0))
                    {
                        string _key = hEnum.GetHandleInfos(i).Key;

                        // This verification should not be needed, but in reality
                        // it IS needed
                        // TOCHECK
                        if (_dico.ContainsKey(_key) == false)
                            _dico.Add(_key, hEnum.GetHandleInfos(i));
                    }
                }
            }

            semProtectEnum.Release();
        }

        // Return all local handles (protected by semaphore)
        public static Dictionary<string, cHandle> EnumerateCurrentLocalHandles(bool all = true)
        {
            Dictionary<string, cHandle> _dico = new Dictionary<string, cHandle>();

            // Handle enumeration class not initialized...
            if (hEnum == null)
                return _dico;

            // Protection !
            semProtectEnum.WaitOne();

            // Refresh handles
            hEnum.Refresh(-1);    // Refresh all
            var loopTo = hEnum.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                if (hEnum.IsNotNull(i) && hEnum.GetHandle(i).IsNotNull())
                {
                    if (all || (Strings.Len(hEnum.GetObjectName(i)) > 0))
                    {
                        string _key = hEnum.GetHandleInfos(i).Key;

                        // This verification should not be needed, but in reality
                        // it IS needed
                        // TOCHECK
                        if (_dico.ContainsKey(_key) == false)
                            _dico.Add(_key, new cHandle(hEnum.GetHandleInfos(i)));
                    }
                }
            }

            semProtectEnum.Release();

            return _dico;
        }
    }
}

