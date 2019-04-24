using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class MemRegion
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Change protection type
        public static bool ChangeMemoryRegionProtectionType(int processId, IntPtr address, IntPtr regSize, NativeEnums.MemoryProtectionType newProtection)
        {
            bool ret;
            IntPtr hProcess;
            NativeEnums.MemoryProtectionType old;

            hProcess = Native.Objects.Process.GetProcessHandleById(processId, Security.ProcessAccess.VmOperation);
            if (hProcess.IsNotNull())
            {
                ret = NativeFunctions.VirtualProtectEx(hProcess, address, regSize.ToInt32(), newProtection, ref old);
                NativeFunctions.CloseHandle(hProcess);
            }

            return ret;
        }

        // Free memory (decommit or release)
        public static bool FreeMemory(int processId, IntPtr address, IntPtr regSize, NativeEnums.MemoryState type)
        {
            bool ret;
            IntPtr hProcess;

            hProcess = Native.Objects.Process.GetProcessHandleById(processId, Security.ProcessAccess.VmOperation);
            if (hProcess.IsNotNull())
            {
                ret = Native.Api.NativeFunctions.VirtualFreeEx(hProcess, address, regSize.ToInt32(), type);
                Native.Api.NativeFunctions.CloseHandle(hProcess);
            }

            return ret;
        }

        // Dump memory
        public static bool DumpMemory(int processId, IntPtr address, IntPtr regSize, string file)
        {
            bool ret;
            using (ProcessRW pRW = new ProcessRW(processId))
            {
                // Read from process memory
                byte[] b = pRW.ReadByteArray(address, regSize.ToInt32(), ref ret);
                if (ret)
                {
                    // Create file (replace if existing)
                    IntPtr hFile = NativeFunctions.CreateFile(file, NativeEnums.EFileAccess.GenericWrite, NativeEnums.EFileShare.Read, IntPtr.Zero, NativeEnums.ECreationDisposition.CreateAlways, 0, IntPtr.Zero);
                    if (hFile.IsNotNull())
                    {
                        // Save file
                        int res;
                        System.Threading.NativeOverlapped ol = new System.Threading.NativeOverlapped();
                        NativeFunctions.WriteFile(hFile, b, regSize.ToInt32(), ref res, IntPtr.Zero);

                        // Success ?
                        ret = (res == regSize.ToInt32());

                        // Close file handle
                        Objects.General.CloseHandle(hFile);
                    }
                    else
                        ret = false;
                }
                b = new byte[1];
            }

            return ret;
        }
        // Enumerate memory regions
        public static void EnumerateMemoryRegionsByProcessId(int pid, ref Dictionary<string, memRegionInfos> _dico)
        {
            IntPtr lHandle;
            IntPtr lPosMem;
            Native.Api.NativeStructs.MemoryBasicInformation mbi = new Native.Api.NativeStructs.MemoryBasicInformation();
            int mbiSize = Marshal.SizeOf(mbi);

            lHandle = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.QueryInformation | Security.ProcessAccess.VmRead);

            if (lHandle.IsNotNull())
            {
                // We'll exit when VirtualQueryEx will fail
                while (Native.Api.NativeFunctions.VirtualQueryEx(lHandle, lPosMem, ref mbi, mbiSize) != 0)
                {
                    _dico.Add(mbi.BaseAddress.ToString(), new memRegionInfos(mbi, pid));

                    lPosMem = lPosMem.Increment(mbi.RegionSize);
                }
                Native.Api.NativeFunctions.CloseHandle(lHandle);
            }
        }
    }
}

