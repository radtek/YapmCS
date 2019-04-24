using System.Collections.Generic;
using System;
using Native.Api;
using System.Management;

namespace Wmi.Objects
{
    public class Service
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

        // Enumerate services
        public static bool EnumerateProcesses(int pid, bool all, System.Management.ManagementObjectSearcher objSearcher, ref Dictionary<string, serviceInfos> _dico, ref string errMsg)
        {
            ManagementObjectCollection res = null;
            try
            {
                res = objSearcher.Get();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }


            foreach (System.Management.ManagementObject refService in res)
            {
                Native.Api.NativeStructs.EnumServiceStatusProcess obj = new Native.Api.NativeStructs.EnumServiceStatusProcess();
                int theId = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.ProcessId.ToString()));

                if (all || pid == theId)
                {
                    {
                        var withBlock = obj;
                        withBlock.DisplayName = System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.DisplayName.ToString()));
                        withBlock.ServiceName = System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.Name.ToString()));
                        {
                            var withBlock1 = withBlock.ServiceStatusProcess;
                            withBlock1.CheckPoint = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.CheckPoint.ToString()));
                            if (System.Convert.ToBoolean(refService.GetPropertyValue(Enums.WmiInfoService.AcceptPause.ToString())))
                                withBlock1.ControlsAccepted = withBlock1.ControlsAccepted | Native.Api.NativeEnums.ServiceAccept.PauseContinue;
                            if (System.Convert.ToBoolean(refService.GetPropertyValue(Enums.WmiInfoService.AcceptStop.ToString())))
                                withBlock1.ControlsAccepted = withBlock1.ControlsAccepted | Native.Api.NativeEnums.ServiceAccept.Stop;
                            withBlock1.CurrentState = Native.Functions.Service.GetServiceStateFromStringH(System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.State.ToString())));
                            withBlock1.ProcessID = theId;
                            // .ServiceFlags
                            withBlock1.ServiceSpecificExitCode = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.ServiceSpecificExitCode.ToString()));
                            withBlock1.ServiceType = Native.Functions.Service.GetServiceTypeFromStringH(System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.ServiceType.ToString())));
                            withBlock1.WaitHint = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.WaitHint.ToString()));
                            withBlock1.Win32ExitCode = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.ExitCode.ToString()));
                        }
                    }

                    // Do we have to get fixed infos ?
                    serviceInfos _servInfos = new serviceInfos(ref obj, true);

                    Native.Api.NativeStructs.QueryServiceConfig conf = new Native.Api.NativeStructs.QueryServiceConfig();
                    {
                        var withBlock2 = conf;
                        withBlock2.BinaryPathName = System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.PathName.ToString()));
                        // .Dependencies
                        withBlock2.DisplayName = System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.DisplayName.ToString()));
                        withBlock2.ErrorControl = Native.Functions.Service.GetServiceErrorControlFromStringH(System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.ErrorControl.ToString())));
                        // .LoadOrderGroup 
                        withBlock2.ServiceStartName = System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.StartName.ToString()));
                        withBlock2.StartType = Native.Functions.Service.GetServiceStartTypeFromStringH(System.Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.StartMode.ToString())));
                        withBlock2.TagID = System.Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.TagId.ToString()));
                    }
                    _servInfos.SetConfig(ref conf);

                    _dico.Add(obj.ServiceName, _servInfos);
                }
            }

            return true;
        }

        // Pause a service
        public static bool PauseServiceByName(string name, System.Management.ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                Enums.WmiServiceReturnCode res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) == name)
                    {
                        res = (Enums.WmiServiceReturnCode)srv.InvokeMethod("PauseService", null);
                        break;
                    }
                }

                errMsg = res.ToString();
                return (res == Enums.WmiServiceReturnCode.Success);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Resume a service
        public static bool ResumeServiceByName(string name, System.Management.ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                Enums.WmiServiceReturnCode res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) == name)
                    {
                        res = (Enums.WmiServiceReturnCode)srv.InvokeMethod("ResumeService", null);
                        break;
                    }
                }

                errMsg = res.ToString();
                return (res == Enums.WmiServiceReturnCode.Success);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Start a service
        public static bool StartServiceByName(string name, System.Management.ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                Enums.WmiServiceReturnCode res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) == name)
                    {
                        res = (Enums.WmiServiceReturnCode)srv.InvokeMethod("StartService", null);
                        break;
                    }
                }

                errMsg = res.ToString();
                return (res == Enums.WmiServiceReturnCode.Success);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Stop a service
        public static bool StopServiceByName(string name, System.Management.ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                Enums.WmiServiceReturnCode res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) == name)
                    {
                        res = (Enums.WmiServiceReturnCode)srv.InvokeMethod("StopService", null);
                        break;
                    }
                }

                errMsg = res.ToString();
                return (res == Enums.WmiServiceReturnCode.Success);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Change service start type
        public static bool SetServiceStartTypeByName(string name, NativeEnums.ServiceStartType type, System.Management.ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                Enums.WmiServiceReturnCode res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) == name)
                    {
                        ManagementBaseObject inParams = srv.GetMethodParameters("ChangeStartMode");
                        inParams["StartMode"] = GetServiceStartTypeAsString(type);
                        ManagementBaseObject outParams = srv.InvokeMethod("ChangeStartMode", inParams, null);
                        res = (Enums.WmiServiceReturnCode)outParams["ReturnValue"];
                        break;
                    }
                }

                errMsg = res.ToString();
                return (res == Enums.WmiServiceReturnCode.Success);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================


        // ========================================
        // Private functions
        // ========================================

        // Return a String which describes start type for service
        private static string GetServiceStartTypeAsString(NativeEnums.ServiceStartType type)
        {
            switch (type)
            {
                case NativeEnums.ServiceStartType.AutoStart:
                    {
                        return "Automatic";
                    }

                case NativeEnums.ServiceStartType.BootStart:
                    {
                        return "Boot";
                    }

                case NativeEnums.ServiceStartType.StartDisabled:
                    {
                        return "Disabled";
                    }

                case NativeEnums.ServiceStartType.SystemStart:
                    {
                        return "System";
                    }

                case NativeEnums.ServiceStartType.DemandStart:
                    {
                        return "Manual";
                    }
            }
            return "";
        }
    }
}

