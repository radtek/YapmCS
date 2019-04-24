using System.Collections.Generic;
using System;
using Native.Api;

namespace Native.Objects
{
    public class Module
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

        // Unload a module
        public static bool UnloadModuleByAddress(IntPtr address, int pid)
        {
            IntPtr hProc = Native.Objects.Process.GetProcessHandleById(pid, Security.ProcessAccess.CreateThread);
            // Create a remote thread a call FreeLibrary
            if (hProc.IsNotNull())
            {
                IntPtr kernel32 = Native.Api.NativeFunctions.GetModuleHandle("kernel32.dll");
                IntPtr freeLibrary = Native.Api.NativeFunctions.GetProcAddress(kernel32, "FreeLibrary");
                int threadId;
                IntPtr ret = Native.Api.NativeFunctions.CreateRemoteThread(hProc, IntPtr.Zero, 0, freeLibrary, address, 0, out threadId);
                return (ret.IsNotNull());
            }
            else
                return false;
        }

        // Enumerate modules
        public static Dictionary<string, moduleInfos> EnumerateModulesWow64ByProcessId(int pid, bool noFileInfo = false)
        {
            Dictionary<string, moduleInfos> retDico = new Dictionary<string, moduleInfos>();
            DebugBuffer buf2 = new DebugBuffer();

            // Query modules info
            buf2.Query(pid, NativeEnums.RtlQueryProcessDebugInformationFlags.Modules | NativeEnums.RtlQueryProcessDebugInformationFlags.Modules32);

            // Get debug information
            NativeStructs.DebugInformation debugInfo = buf2.GetDebugInformation();

            if (debugInfo.ModuleInformation.IsNotNull())
            {
                Memory.MemoryAlloc modInfo = new Memory.MemoryAlloc(debugInfo.ModuleInformation);
                NativeStructs.RtlProcessModules mods = modInfo.ReadStruct<NativeStructs.RtlProcessModules>();
                var loopTo = mods.NumberOfModules - 1;
                for (int i = 0; i <= loopTo; i++)
                {
                    NativeStructs.RtlProcessModuleInformation modu = modInfo.ReadStruct<NativeStructs.RtlProcessModuleInformation>(NativeStructs.RtlProcessModules.ModulesOffset, i);
                    string key = modu.ImageBase.ToString();
                    // PERFISSUE ??
                    if (retDico.ContainsKey(key) == false)
                        retDico.Add(key, new moduleInfos(modu, pid, noFileInfo));
                }
            }

            buf2.Dispose();

            return retDico;
        }

        // Enumerate modules
        public static Dictionary<string, moduleInfos> EnumerateModulesByProcessId(int pid, bool noFileInfo = false)
        {

            // Retrieve modules of a process (uses PEB_LDR_DATA structs)
            Dictionary<string, moduleInfos> retDico = new Dictionary<string, moduleInfos>();

            IntPtr hProc;
            IntPtr peb;
            IntPtr loaderDatePtr;

            // Open a reader to access memory !
            using (ProcessMemReader reader = new ProcessMemReader(pid))
            {
                hProc = reader.ProcessHandle;

                if (hProc.IsNotNull())
                {
                    peb = reader.GetPebAddress();

                    // PEB struct documented here
                    // http://undocumented.ntinternals.net/UserMode/Undocumented%20Functions/NT%20Objects/Process/PEB.html

                    // Get address of LoaderData pointer
                    peb = peb.Increment(NativeStructs.Peb_LoaderDataOffset);
                    loaderDatePtr = reader.ReadIntPtr(peb);

                    // PEB_LDR_DATA documented here
                    // http://msdn.microsoft.com/en-us/library/aa813708(VS.85).aspx
                    Native.Api.NativeStructs.PebLdrData ldrData = new Native.Api.NativeStructs.PebLdrData();
                    ldrData = (Native.Api.NativeStructs.PebLdrData)reader.ReadStruct<Native.Api.NativeStructs.PebLdrData>(loaderDatePtr);

                    // Now navigate into structure
                    IntPtr curObj = ldrData.InLoadOrderModuleList.Flink;
                    IntPtr firstObj = curObj;
                    string dllName;
                    string dllPath;
                    Native.Api.NativeStructs.LdrDataTableEntry curEntry;
                    int i = 0;

                    while (curObj.IsNotNull())
                    {
                        if ((i > 0 && curObj == firstObj))
                            break;

                        // Read LoaderData entry
                        curEntry = (Native.Api.NativeStructs.LdrDataTableEntry)reader.ReadStruct<Native.Api.NativeStructs.LdrDataTableEntry>(curObj);

                        if ((curEntry.DllBase.IsNotNull()))
                        {

                            // Retrive the path/name of the dll
                            dllPath = reader.ReadUnicodeString(curEntry.FullDllName);
                            if (dllPath == null)
                                dllPath = Program.NO_INFO_RETRIEVED;
                            dllName = reader.ReadUnicodeString(curEntry.BaseDllName);
                            if (dllName == null)
                                dllName = Program.NO_INFO_RETRIEVED;

                            // Add to dico
                            // Key is path-pid-baseAddress
                            string _key = dllPath.ToString() + "-" + pid.ToString() + "-" + curEntry.DllBase.ToString();
                            if (retDico.ContainsKey(_key) == false)
                                retDico.Add(_key, new moduleInfos(curEntry, pid, dllPath, dllName, noFileInfo));
                        }

                        // Next entry
                        curObj = curEntry.InLoadOrderLinks.Flink;
                        i += 1;
                    }
                }
            }

            return retDico;
        }
    }
}

