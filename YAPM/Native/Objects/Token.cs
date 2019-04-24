using System;
using System.Runtime.InteropServices;
using Native.Api;
using System.Text;

namespace Native.Objects
{
    public class Token
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
        public static string[] PrivilegeNames = new[] { "SeCreateTokenPrivilege", "SeAssignPrimaryTokenPrivilege", "SeLockMemoryPrivilege", "SeIncreaseQuotaPrivilege", "SeUnsolicitedInputPrivilege", "SeMachineAccountPrivilege", "SeTcbPrivilege", "SeSecurityPrivilege", "SeTakeOwnershipPrivilege", "SeLoadDriverPrivilege", "SeSystemProfilePrivilege", "SeSystemtimePrivilege", "SeProfileSingleProcessPrivilege", "SeIncreaseBasePriorityPrivilege", "SeCreatePagefilePrivilege", "SeCreatePermanentPrivilege", "SeBackupPrivilege", "SeRestorePrivilege", "SeShutdownPrivilege", "SeDebugPrivilege", "SeAuditPrivilege", "SeSystemEnvironmentPrivilege", "SeChangeNotifyPrivilege", "SeRemoteShutdownPrivilege", "SeCreateGlobalPrivilege", "SeCreateTokenPrivilege", "SeAssignPrimaryTokenPrivilege", "SeLockMemoryPrivilege", "SeIncreaseQuotaPrivilege", "SeUnsolicitedInputPrivilege", "SeMachineAccountPrivilege", "SeTcbPrivilege", "SeSecurityPrivilege", "SeTakeOwnershipPrivilege", "SeLoadDriverPrivilege", "SeSystemProfilePrivilege", "SeSystemtimePrivilege", "SeProfileSingleProcessPrivilege", "SeIncreaseBasePriorityPrivilege", "SeCreatePagefilePrivilege", "SeCreatePermanentPrivilege", "SeBackupPrivilege", "SeRestorePrivilege", "SeShutdownPrivilege", "SeDebugPrivilege", "SeAuditPrivilege", "SeSystemEnvironmentPrivilege", "SeChangeNotifyPrivilege", "SeRemoteShutdownPrivilege", "SeCreateGlobalPrivilege", "SeUndockPrivilege", "SeManageVolumePrivilege", "SeImpersonatePrivilege", "SeEnableDelegationPrivilege", "SeSyncAgentPrivilege", "SeTrustedCredManAccessPrivilege", "SeRelabelPrivilege", "SeIncreaseWorkingSetPrivilege", "SeTimeZonePrivilege", "SeCreateSymbolicLinkPrivilege" };


        // ========================================
        // Public functions
        // ========================================

        // Return elevation type of a process
        public static bool GetProcessElevationTypeByTokenHandle(IntPtr hTok, ref Native.Api.Enums.ElevationType elevation)
        {
            if (hTok.IsNotNull())
            {
                int value;
                int ret;

                // Get tokeninfo length
                Native.Api.NativeFunctions.GetTokenInformation(hTok, Native.Api.NativeEnums.TokenInformationClass.TokenElevationType, IntPtr.Zero, 0, ref ret);
                IntPtr TokenInformation = Marshal.AllocHGlobal(ret);
                // Get token information
                Native.Api.NativeFunctions.GetTokenInformation(hTok, Native.Api.NativeEnums.TokenInformationClass.TokenElevationType, TokenInformation, ret, ref default(int));
                // Get a valid structure
                value = Marshal.ReadInt32(TokenInformation, 0);
                Marshal.FreeHGlobal(TokenInformation);
                elevation = (Native.Api.Enums.ElevationType)value;
                return true;
            }
            else
            {
                elevation = Native.Api.Enums.ElevationType.Default;
                return false;
            }
        }

        // Get privileges list of process
        public static NativeStructs.PrivilegeInfo[] GetPrivilegesListByProcessId(int pid)
        {
            NativeStructs.PrivilegeInfo[] ListPrivileges = new NativeStructs.PrivilegeInfo[0];
            IntPtr hProcessToken;
            IntPtr hProcess;
            int RetLen;

            hProcess = Native.Objects.Process.GetProcessHandleById(pid, Native.Security.ProcessAccess.QueryInformation);
            if (hProcess.IsNotNull())
            {
                NativeFunctions.OpenProcessToken(hProcess, Native.Security.TokenAccess.Query, out hProcessToken);
                if (hProcessToken.IsNotNull())
                {

                    // Get tokeninfo length
                    NativeFunctions.GetTokenInformation(hProcessToken, NativeEnums.TokenInformationClass.TokenPrivileges, IntPtr.Zero, 0, ref RetLen);

                    // PERFISSUE (do not alloc each time)
                    using (Native.Memory.MemoryAlloc memAlloc = new Native.Memory.MemoryAlloc(RetLen))
                    {

                        // Get token information
                        NativeFunctions.GetTokenInformation(hProcessToken, NativeEnums.TokenInformationClass.TokenPrivileges, memAlloc.Pointer, memAlloc.Size, ref RetLen);

                        // Get number of privileges
                        int count = System.Convert.ToInt32(memAlloc.ReadUInt32(0));
                        ListPrivileges = new NativeStructs.PrivilegeInfo[count - 1 + 1];
                        var loopTo = count - 1;

                        // Retrieve list of privileges
                        for (int i = 0; i <= loopTo; i++)
                        {
                            NativeStructs.LuidAndAttributes @struct = memAlloc.ReadStruct<NativeStructs.LuidAndAttributes>(4, i);   // 4 first bytes are used for the size
                            ListPrivileges[i] = new NativeStructs.PrivilegeInfo();
                            {
                                var withBlock = ListPrivileges[i];
                                withBlock.pLuid = @struct.pLuid;
                                withBlock.Status = @struct.Attributes;
                                // Get name
                                StringBuilder sb = new StringBuilder();
                                int size = 0;
                                // Get size required for name
                                if (NativeFunctions.LookupPrivilegeName("", ref @struct.pLuid, sb, ref size) == false)
                                {
                                    // Redim capacity
                                    sb.EnsureCapacity(size);
                                    NativeFunctions.LookupPrivilegeName("", ref @struct.pLuid, sb, ref size);
                                }
                                withBlock.Name = sb.ToString();
                            }
                        }
                    }
                    NativeFunctions.CloseHandle(hProcessToken);
                }
                NativeFunctions.CloseHandle(hProcess);
            }

            return ListPrivileges;
        }


        // Set privilege status
        public static bool GetPrivilegeStatusByProcessId(int processId, string seName, ref NativeEnums.SePrivilegeAttributes seStatus)
        {
            IntPtr hProcess;
            bool fRet;
            IntPtr lngToken;
            NativeStructs.TokenPrivileges typTokenPriv = new NativeStructs.TokenPrivileges();
            int retLen;

            // Open handle to process
            hProcess = Native.Objects.Process.GetProcessHandleById(processId, Security.ProcessAccess.QueryInformation);

            if (hProcess.IsNotNull())
            {
                // Get token handle
                NativeFunctions.OpenProcessToken(hProcess, Security.TokenAccess.Query | Security.TokenAccess.AdjustPrivileges, out lngToken);

                if (lngToken.IsNotNull())
                {


                    // Get tokeninfo length
                    NativeFunctions.GetTokenInformation(lngToken, NativeEnums.TokenInformationClass.TokenPrivileges, IntPtr.Zero, 0, ref retLen);

                    // PERFISSUE (do not alloc each time)
                    using (Native.Memory.MemoryAlloc memAlloc = new Native.Memory.MemoryAlloc(retLen))
                    {

                        // Get token information
                        NativeFunctions.GetTokenInformation(lngToken, NativeEnums.TokenInformationClass.TokenPrivileges, memAlloc.Pointer, memAlloc.Size, ref retLen);

                        // Get number of privileges
                        int count = System.Convert.ToInt32(memAlloc.ReadUInt32(0));
                        var loopTo = count - 1;

                        // Retrieve list of privileges
                        for (int i = 0; i <= loopTo; i++)
                        {
                            NativeStructs.LuidAndAttributes @struct = memAlloc.ReadStruct<NativeStructs.LuidAndAttributes>(4, i);   // 4 first bytes are used for the size

                            // Get name of this privilege
                            StringBuilder sb = new StringBuilder();
                            int size = 0;

                            // Get size required for name
                            if (NativeFunctions.LookupPrivilegeName("", ref @struct.pLuid, sb, ref size) == false)
                            {
                                // Redim capacity
                                sb.EnsureCapacity(size);
                                NativeFunctions.LookupPrivilegeName("", ref @struct.pLuid, sb, ref size);
                            }

                            if (seName == sb.ToString())
                            {
                                seStatus = @struct.Attributes;
                                break;
                            }
                        }
                    }

                    NativeFunctions.CloseHandle(lngToken);
                }
                NativeFunctions.CloseHandle(hProcess);
            }

            return fRet;
        }

        // Query privilege status
        public static bool SetPrivilegeStatusByProcessId(int processId, string seName, NativeEnums.SePrivilegeAttributes seStatus)
        {
            IntPtr hProcess;
            bool fRet;
            IntPtr lngToken;
            NativeStructs.Luid typLUID;
            NativeStructs.TokenPrivileges typTokenPriv = new NativeStructs.TokenPrivileges();
            IntPtr newTokenPriv;
            IntPtr ret2;

            // Open handle to process
            hProcess = Native.Objects.Process.GetProcessHandleById(processId, Security.ProcessAccess.QueryInformation);

            if (hProcess.IsNotNull())
            {
                // Get token handle
                NativeFunctions.OpenProcessToken(hProcess, Security.TokenAccess.Query | Security.TokenAccess.AdjustPrivileges, out lngToken);

                if (lngToken.IsNotNull())
                {

                    // Retrieve Luid from PrivilegeName
                    if (NativeFunctions.LookupPrivilegeValue(null, seName, out typLUID))
                    {

                        // Adjust privilege
                        typTokenPriv.PrivilegeCount = 1;
                        typTokenPriv.Privileges = new NativeStructs.LuidAndAttributes[1];
                        typTokenPriv.Privileges[0] = new NativeStructs.LuidAndAttributes();
                        typTokenPriv.Privileges[0].Attributes = seStatus;
                        typTokenPriv.Privileges[0].pLuid = typLUID;
                        fRet = NativeFunctions.AdjustTokenPrivileges(lngToken, false, ref typTokenPriv, 0, newTokenPriv, ret2);
                    }
                    NativeFunctions.CloseHandle(lngToken);
                }
                NativeFunctions.CloseHandle(hProcess);
            }

            return fRet;
        }

        // Get description of a privilege
        public static string GetPrivilegeDescriptionByName(string privilegeName)
        {
            StringBuilder sb = new StringBuilder(0x100);
            int size = sb.Capacity;
            int languageId = 0;
            if (!NativeFunctions.LookupPrivilegeDisplayName(null, privilegeName, sb, ref size, ref languageId))
            {
                sb.EnsureCapacity(size);

                NativeFunctions.LookupPrivilegeDisplayName(null, privilegeName, sb, ref size, ref languageId);
            }
            return sb.ToString();
        }

        // Get an account name from a SID
        public static bool GetAccountNameFromSid(IntPtr SID, ref string userName, ref string domainName)
        {
            StringBuilder name = new StringBuilder(255);
            StringBuilder domain = new StringBuilder(255);
            int namelen = 255;
            int domainlen = 255;
            NativeEnums.SidNameUse use = NativeEnums.SidNameUse.User;

            domainName = "";
            userName = "";

            try
            {
                if (!NativeFunctions.LookupAccountSid(null, SID, name, ref namelen, domain, ref domainlen, ref use))
                {
                    name.EnsureCapacity(namelen);
                    domain.EnsureCapacity(domainlen);
                    NativeFunctions.LookupAccountSid(null, SID, name, ref namelen, domain, ref domainlen, ref use);
                }
                userName = name.ToString();
            }
            catch
            {
                // return string SID
                userName = new System.Security.Principal.SecurityIdentifier(SID).ToString();
                return false;
            }

            domainName = domain.ToString();
            return true;
        }

        // Return a process token handle
        public static IntPtr GetProcessTokenHandleByProcessHandle(IntPtr handle, Native.Security.TokenAccess access)
        {
            IntPtr _tokenHandle;
            Native.Api.NativeFunctions.OpenProcessToken(handle, access, out _tokenHandle);
            return _tokenHandle;
        }
    }
}

