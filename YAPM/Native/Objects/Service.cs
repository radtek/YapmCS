using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Service
    {


        // ========================================
        // Private constants
        // ========================================

        private const string ServicePathInRegistry = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\";



        // ========================================
        // Private attributes
        // ========================================

        // Store new services ( serviceName <-> isNew )
        private static Dictionary<string, bool> _dicoNewServices = new Dictionary<string, bool>();

        // Current services running (updated after each enumeration)
        private static Dictionary<string, cService> _currentServices;

        // Used for memory operations
        private static Native.Memory.MemoryAlloc _memBufferEnumServics = new Native.Memory.MemoryAlloc(0x1000);   // NOTE : never unallocated

        // Used to protect currentServices dico
        private static System.Threading.Semaphore _semCurrentServ = new System.Threading.Semaphore(1, 1);




        // ========================================
        // Public properties
        // ========================================

        /// <summary>
        // List of current services
        // Needs to be protected by SemCurrentServices
        /// </summary>
        public static Dictionary<string, cService> CurrentServices
        {
            get
            {
                return _currentServices;
            }
            set
            {
                _currentServices = value;
            }
        }

        // Return semaphore used to protect list of current services
        public static System.Threading.Semaphore SemCurrentServices
        {
            get
            {
                return _semCurrentServ;
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Create a service
        public static bool CreateService(Native.Api.Structs.ServiceCreationParams @params)
        {
            bool ret = false;
            IntPtr hServ = CreateService(@params, ref ret);
            if (hServ.IsNotNull())
                Native.Api.NativeFunctions.CloseServiceHandle(hServ);
            return ret;
        }
        public static IntPtr CreateService(Native.Api.Structs.ServiceCreationParams @params, ref bool res)
        {
            res = false;

            if (string.IsNullOrEmpty(@params.RegMachine) == false)
            {
                // Have to connect to the remote machine
                bool b = Native.Objects.Network.ConnectToRemoteMachine(@params.RegMachine, @params.RegUser, @params.RegPassword);
                if (b == false)
                    // Could not connect to remote machine !
                    return IntPtr.Zero;
                else
                {
                    // Then copy file to remote machine...
                    b = Network.SyncCopyFileToRemoteSystem32(@params.RegMachine, @params.FilePath, Common.Misc.GetFileName(@params.FilePath));
                    if (b == false)
                    {
                        // Could not copy file
                        if (string.IsNullOrEmpty(@params.RegMachine) == false)
                            Network.DisconnectFromRemoteMachine(@params.RegMachine);
                        return IntPtr.Zero;
                    }

                    // Now that the file is copied to the remote machine, we update
                    // the executable path
                    @params.FilePath = @"\\" + @params.RegMachine + @"\ADMIN$\System32\" + Common.Misc.GetFileName(@params.FilePath);
                }
            }

            IntPtr hSCM = GetSCManagerHandle(Security.ServiceManagerAccess.CreateService, @params.RegMachine);

            if (hSCM.IsNotNull())
            {
                IntPtr hServ = Native.Api.NativeFunctions.CreateService(hSCM, @params.ServiceName, @params.DisplayName, Security.ServiceAccess.All, @params.Type, @params.StartType, @params.ErrorControl, @params.FilePath + " " + @params.Arguments, null, IntPtr.Zero, IntPtr.Zero, null, null);

                CloseSCManagerHandle(hSCM);
                res = (hServ != IntPtr.Zero);
                if (string.IsNullOrEmpty(@params.RegMachine) == false)
                    Network.DisconnectFromRemoteMachine(@params.RegMachine);
                return hServ;
            }
            else
            {
                if (string.IsNullOrEmpty(@params.RegMachine) == false)
                    Network.DisconnectFromRemoteMachine(@params.RegMachine);
                return IntPtr.Zero;
            }
        }


        // Clear list of new services
        public static void ClearNewServicesList()
        {
            _dicoNewServices.Clear();
        }


        // Enumerate services (local)
        public static void EnumerateServices(IntPtr hSCM, ref Dictionary<string, serviceInfos> _dico, bool forAllProcesses, bool completeInfos, int processId = 0)
        {
            int lBytesNeeded;
            int lServicesReturned;
            NativeStructs.EnumServiceStatusProcess[] tServiceStatus;
            tServiceStatus = new NativeStructs.EnumServiceStatusProcess[1];

            if (hSCM.IsNotNull())
            {
                // 2nd arg : Api.SC_ENUM_PROCESS_INFO, _
                if (!(NativeFunctions.EnumServicesStatusEx(hSCM, IntPtr.Zero, NativeEnums.ServiceQueryType.All, NativeEnums.ServiceQueryState.All, _memBufferEnumServics.Pointer, _memBufferEnumServics.Size, ref lBytesNeeded, ref lServicesReturned, ref 0, null)))
                    // Resize buffer
                    _memBufferEnumServics.IncrementSize(lBytesNeeded);

                // 2nd arg : Api.SC_ENUM_PROCESS_INFO, 
                if (NativeFunctions.EnumServicesStatusEx(hSCM, IntPtr.Zero, NativeEnums.ServiceQueryType.All, NativeEnums.ServiceQueryState.All, _memBufferEnumServics.Pointer, _memBufferEnumServics.Size, ref lBytesNeeded, ref lServicesReturned, ref 0, null))
                {
                    var loopTo = lServicesReturned - 1;
                    for (int idx = 0; idx <= loopTo; idx++)
                    {

                        // Get structure from memory
                        NativeStructs.EnumServiceStatusProcess obj = _memBufferEnumServics.ReadStruct<NativeStructs.EnumServiceStatusProcess>(idx);

                        if (forAllProcesses || processId == obj.ServiceStatusProcess.ProcessID)
                        {
                            serviceInfos _servINFO = new serviceInfos(ref obj, completeInfos);

                            if (forAllProcesses == false || _dicoNewServices.ContainsKey(obj.ServiceName) == false | completeInfos)
                            {

                                // Get infos from registry
                                GetServiceInformationsFromRegistry(obj.ServiceName, ref _servINFO);

                                // PERFISSUE
                                GetServiceConfigByName(hSCM, obj.ServiceName, ref _servINFO, true);

                                if (forAllProcesses & completeInfos == false)
                                    _dicoNewServices.Add(obj.ServiceName, false);
                            }

                            _dico.Add(obj.ServiceName, _servINFO);
                        }
                        if (forAllProcesses)
                            _dicoNewServices[obj.ServiceName] = true;
                    }
                }
            }


            // Remove all services that not exist anymore
            if (forAllProcesses)
            {
                Dictionary<string, bool> _dicoTemp = _dicoNewServices;
                foreach (System.Collections.Generic.KeyValuePair<string, bool> it in _dicoTemp)
                {
                    if (it.Value == false)
                        _dicoNewServices.Remove(it.Key);
                }
            }

            // Here we fill _currentServices if necessary
            // PERFISSUE
            _semCurrentServ.WaitOne();
            if (_currentServices == null)
                _currentServices = new Dictionary<string, cService>();
            foreach (serviceInfos pc in _dico.Values)
            {
                if (_currentServices.ContainsKey(pc.Name) == false)
                    _currentServices.Add(pc.Name, new cService(pc));
            }
            _semCurrentServ.Release();
        }


        // Get config of service
        public static void GetServiceConfigByName(IntPtr hSCManager, string name, ref serviceInfos _infos, bool getFileInfo)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Security.ServiceAccess.QueryConfig);

            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {

                    // Get all available informations
                    NativeStructs.QueryServiceConfig tt = new NativeStructs.QueryServiceConfig();
                    int bytesNeeded = 0;
                    bool fResult;

                    IntPtr pt = IntPtr.Zero;
                    fResult = NativeFunctions.QueryServiceConfig(lServ, pt, bytesNeeded, ref bytesNeeded);
                    pt = Marshal.AllocHGlobal(bytesNeeded);
                    fResult = NativeFunctions.QueryServiceConfig(lServ, pt, bytesNeeded, ref bytesNeeded);
                    // Cast into NativeStructs.QueryServiceConfig unmanaged memory
                    tt = (NativeStructs.QueryServiceConfig)Marshal.PtrToStructure(pt, typeof(NativeStructs.QueryServiceConfig));
                    Marshal.FreeHGlobal(pt);

                    // Set configuration
                    _infos.SetConfig(ref tt);

                    NativeFunctions.CloseServiceHandle(lServ);
                }
            }
        }


        // Get a service by its name
        public static cService GetServiceByName(string name)
        {
            cService tt = null;
            _semCurrentServ.WaitOne();
            if (_currentServices.ContainsKey(name))
                tt = _currentServices[name];
            _semCurrentServ.Release();

            return tt;
        }

        // Get services which depends from a specific service
        public static Dictionary<string, serviceInfos> GetServiceWhichDependFromByServiceName(string serviceName)
        {
            Dictionary<string, serviceInfos> _d = new Dictionary<string, serviceInfos>();
            string[] dep = null;

            _semCurrentServ.WaitOne();

            foreach (cService serv in _currentServices.Values)
            {
                dep = serv.Infos.Dependencies;
                if (dep != null)
                {
                    foreach (string s in dep)
                    {
                        if (s.ToLowerInvariant() == serviceName.ToLowerInvariant())
                        {
                            _d.Add(serv.Infos.Name, serv.Infos);
                            break;
                        }
                    }
                }
            }

            _semCurrentServ.Release();

            return _d;
        }

        // Get dependencies of a service
        public static Dictionary<string, serviceInfos> GetServiceDependencies(string serviceName)
        {
            Dictionary<string, serviceInfos> _d = new Dictionary<string, serviceInfos>();
            string[] dep = null;

            _semCurrentServ.WaitOne();

            foreach (cService serv in _currentServices.Values)
            {
                if (serv.Infos.Name.ToLowerInvariant() == serviceName.ToLowerInvariant())
                {
                    dep = serv.Infos.Dependencies;
                    break;
                }
            }

            if (dep == null || dep.Length == 0)
            {
                _semCurrentServ.Release();
                return _d;
            }

            foreach (string servName in dep)
            {
                foreach (cService serv in _currentServices.Values)
                {
                    if (servName.ToLowerInvariant() == serv.Infos.Name.ToLowerInvariant())
                    {
                        _d.Add(servName, serv.Infos);
                        break;
                    }
                }
            }

            _semCurrentServ.Release();

            return _d;
        }

        // Pause a service
        public static bool PauseServiceByName(string name, IntPtr hSCManager)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.PauseContinue);
            bool res = false;
            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    NativeStructs.ServiceStatusProcess lpss;
                    res = NativeFunctions.ControlService(lServ, NativeEnums.ServiceControl.Pause, out lpss);
                    NativeFunctions.CloseServiceHandle(lServ);
                    return res;
                }
            }
            return false;
        }

        // Resume a service
        public static bool ResumeServiceByName(string name, IntPtr hSCManager)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.PauseContinue);
            bool res = false;
            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    NativeStructs.ServiceStatusProcess lpss;
                    res = NativeFunctions.ControlService(lServ, NativeEnums.ServiceControl.Continue, out lpss);
                    NativeFunctions.CloseServiceHandle(lServ);
                    return res;
                }
            }
            return false;
        }

        // Set start type
        public static bool SetServiceStartTypeByName(string name, NativeEnums.ServiceStartType type, IntPtr hSCManager)
        {
            IntPtr hLockSCManager;
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.ChangeConfig);
            bool ret = false;

            hLockSCManager = NativeFunctions.LockServiceDatabase(hSCManager);

            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    ret = NativeFunctions.ChangeServiceConfig(lServ, NativeEnums.ServiceType.NoChange, type, NativeEnums.ServiceErrorControl.NoChange, null, null, default(IntPtr), null, null, null, null);
                    NativeFunctions.CloseServiceHandle(lServ);
                }
                NativeFunctions.UnlockServiceDatabase(hLockSCManager);
                return ret;
            }
            return false;
        }

        // Start service
        public static bool StartServiceByName(string name, IntPtr hSCManager)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.Start);
            bool res;
            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    res = NativeFunctions.StartService(lServ, 0, null);
                    NativeFunctions.CloseServiceHandle(lServ);
                    return res;
                }
            }
            return false;
        }

        // Delete service
        public static bool DeleteServiceByName(string name, IntPtr hSCManager)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.Delete);
            bool res;
            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    res = NativeFunctions.DeleteService(lServ);
                    NativeFunctions.CloseServiceHandle(lServ);
                    return res;
                }
            }
            return false;
        }

        // Stop service
        public static bool StopServiceByName(string name, IntPtr hSCManager)
        {
            IntPtr lServ = NativeFunctions.OpenService(hSCManager, name, Native.Security.ServiceAccess.Stop);
            bool res = false;
            if (hSCManager.IsNotNull())
            {
                if (lServ.IsNotNull())
                {
                    NativeStructs.ServiceStatusProcess lpss;
                    res = NativeFunctions.ControlService(lServ, NativeEnums.ServiceControl.Stop, out lpss);
                    NativeFunctions.CloseServiceHandle(lServ);
                    return res;
                }
            }
            return false;
        }

        // Get SC manager handle
        public static IntPtr GetSCManagerHandle(Native.Security.ServiceManagerAccess access)
        {
            return NativeFunctions.OpenSCManager(null, null, access);
        }
        public static IntPtr GetSCManagerHandle(Native.Security.ServiceManagerAccess access, string machine)
        {
            return NativeFunctions.OpenSCManager(machine, null, access);
        }

        // Close SC manager handle
        public static void CloseSCManagerHandle(IntPtr hSCManager)
        {
            Native.Api.NativeFunctions.CloseServiceHandle(hSCManager);
        }

        // Return dependencies of a service (as a string array)
        public static string[] GetServiceDependenciesAsStringArrayFromPtr(IntPtr thePtr)
        {

            // If thePtr.IsNotNull Then

            // Dim res As String = Marshal.PtrToStringUni(thePtr, &H400)

            // If res Is Nothing OrElse res.Length = 0 OrElse (Char.IsLetterOrDigit(res.Chars(0)) Or Char.IsSymbol(res.Chars(0))) = False Then
            // Return Nothing
            // End If

            // ' Find the 2 consecutive NullChars
            // For i As Integer = 0 To &H400 - 1
            // If res.Chars(i) = CChar(ChrW(0)) AndAlso res.Chars(i + 1) = CChar(ChrW(0)) Then
            // res = res.Substring(0, i)
            // Return Split(res, vbNullChar)
            // End If
            // Next

            // End If

            // Return Nothing

            // === Get dependencies of service
            if (thePtr.IsNotNull())
            {

                // Get a short array from memory
                // Delimited by 2 null chars (e.g 4 zero byte as it is unicode)
                Int16[] res;
                res = new short[1];
                int size = 1;

                short b1 = -1;
                short b2 = -1;

                while (!(b1 == 0 & b2 == 0))
                {
                    size += 1;
                    res = new short[size - 1 + 1];
                    Marshal.Copy(thePtr, res, 0, res.Length);
                    b1 = res[size - 2];
                    b2 = res[size - 1];
                }

                size -= 1;
                var oldRes = res;
                res = new short[size - 1 + 1];
                if (oldRes != null)
                    Array.Copy(oldRes, res, Math.Min(size - 1 + 1, oldRes.Length));

                // Get a string array from this short array
                string __var;
                string[] rr;
                rr = new string[0];
                int xOld = 0;
                int y;

                if (size > 2)
                {
                    var loopTo = size - 1;
                    for (int x = 0; x <= loopTo; x++)
                    {
                        if (res[x] == 0)
                        {
                            var oldRr = rr;
                            rr = new string[rr.Length + 1];
                            // Then it's variable end
                            if (oldRr != null)
                                Array.Copy(oldRr, rr, Math.Min(rr.Length + 1, oldRr.Length));  // Add one item to list
                            try
                            {
                                // Parse short array to retrieve an unicode string
                                y = x * 2;
                                int __size = (y - xOld) / 2;

                                // Allocate unmanaged memory
                                IntPtr ptr = Marshal.AllocHGlobal(y - xOld);

                                // Copy from short array to unmanaged memory
                                Marshal.Copy(res, xOld / 2, ptr, __size);

                                // Convert to string (and copy to __var variable)
                                __var = Marshal.PtrToStringUni(ptr, __size);

                                // Free unmanaged memory
                                Marshal.FreeHGlobal(ptr);
                            }
                            catch (Exception ex)
                            {
                                __var = "";
                            }

                            // Insert variable
                            rr[rr.Length - 1] = __var;

                            xOld = y + 2;
                        }
                    }

                    return rr;
                }
            }

            return null;
        }



        // ========================================
        // Private functions
        // ========================================


        // Get infos from registry
        private static void GetServiceInformationsFromRegistry(string name, ref serviceInfos infos)
        {

            // Get description
            string desc = GetServiceInformationFromRegistryByName(name, "Description");

            // If in starts with @, then it points to a resource in a file
            if (Strings.InStr(desc, "@", CompareMethod.Binary) > 0)
                desc = Native.Objects.File.GetResourceStringFromFile(desc);

            // Remove duplicated slashs
            desc = Strings.Replace(desc, @"\", @"\\");

            // Get other infos
            string obj = GetServiceInformationFromRegistryByName(name, "ObjectName");
            string dmf = GetServiceInformationFromRegistryByName(name, "DiagnosticMessageFile");

            // Set to result
            infos.SetRegInfos(desc, dmf, obj);
        }

        // Retrieve an information about a service from registry
        private static string GetServiceInformationFromRegistryByName(string name, string info)
        {
            try
            {
                return System.Convert.ToString(My.MyProject.Computer.Registry.GetValue(ServicePathInRegistry
                            + name, info, ""));
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

