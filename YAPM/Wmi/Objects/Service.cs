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
        public static bool EnumerateProcesses(int pid, bool all, ManagementObjectSearcher objSearcher,
            ref Dictionary<string, serviceInfos> dico, ref string errMsg)
        {
            ManagementObjectCollection res;
            try
            {
                res = objSearcher.Get();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }


            foreach (var o in res)
            {
                var refService = (ManagementObject) o;
                var obj = new NativeStructs.EnumServiceStatusProcess();
                var theId = Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.ProcessId.ToString()));

                if (!all && pid != theId) continue;
                {
                    var withBlock = obj;
                    withBlock.DisplayName =
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.DisplayName.ToString()));
                    withBlock.ServiceName =
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.Name.ToString()));
                    {
                        var withBlock1 = withBlock.ServiceStatusProcess;
                        withBlock1.CheckPoint =
                            Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.CheckPoint.ToString()));
                        if (Convert.ToBoolean(refService.GetPropertyValue(Enums.WmiInfoService.AcceptPause.ToString())))
                            withBlock1.ControlsAccepted |= NativeEnums.ServiceAccept.PauseContinue;
                        if (Convert.ToBoolean(refService.GetPropertyValue(Enums.WmiInfoService.AcceptStop.ToString())))
                            withBlock1.ControlsAccepted |= NativeEnums.ServiceAccept.Stop;
                        withBlock1.CurrentState = Native.Functions.Service.GetServiceStateFromStringH(
                            Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.State.ToString())));
                        withBlock1.ProcessID = theId;
                        // .ServiceFlags
                        withBlock1.ServiceSpecificExitCode = Convert.ToInt32(
                            refService.GetPropertyValue(Enums.WmiInfoService.ServiceSpecificExitCode.ToString()));
                        withBlock1.ServiceType = Native.Functions.Service.GetServiceTypeFromStringH(
                            Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.ServiceType.ToString())));
                        withBlock1.WaitHint =
                            Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.WaitHint.ToString()));
                        withBlock1.Win32ExitCode =
                            Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.ExitCode.ToString()));
                    }
                }

                // Do we have to get fixed infos ?
                var servInfos = new serviceInfos(ref obj, true);

                var conf = new NativeStructs.QueryServiceConfig();
                {
                    conf.BinaryPathName =
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.PathName.ToString()));
                    // .Dependencies
                    conf.DisplayName =
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.DisplayName.ToString()));
                    conf.ErrorControl = Native.Functions.Service.GetServiceErrorControlFromStringH(
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.ErrorControl.ToString())));
                    // .LoadOrderGroup 
                    conf.ServiceStartName =
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.StartName.ToString()));
                    conf.StartType = Native.Functions.Service.GetServiceStartTypeFromStringH(
                        Convert.ToString(refService.GetPropertyValue(Enums.WmiInfoService.StartMode.ToString())));
                    conf.TagID = Convert.ToInt32(refService.GetPropertyValue(Enums.WmiInfoService.TagId.ToString()));
                }
                servInfos.SetConfig(ref conf);

                dico.Add(obj.ServiceName, servInfos);
            }

            return true;
        }

        // Pause a service
        public static bool PauseServiceByName(string name, ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                var res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) != name) continue;
                    res = (Enums.WmiServiceReturnCode) srv.InvokeMethod("PauseService", null);
                    break;
                }

                errMsg = res.ToString();
                return res == Enums.WmiServiceReturnCode.Success;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Resume a service
        public static bool ResumeServiceByName(string name, ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                var res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) != name) continue;
                    res = (Enums.WmiServiceReturnCode) srv.InvokeMethod("ResumeService", null);
                    break;
                }

                errMsg = res.ToString();
                return res == Enums.WmiServiceReturnCode.Success;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Start a service
        public static bool StartServiceByName(string name, ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                var res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) != name) continue;
                    res = (Enums.WmiServiceReturnCode) srv.InvokeMethod("StartService", null);
                    break;
                }

                errMsg = res.ToString();
                return res == Enums.WmiServiceReturnCode.Success;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Stop a service
        public static bool StopServiceByName(string name, ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                var res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) != name) continue;
                    res = (Enums.WmiServiceReturnCode) srv.InvokeMethod("StopService", null);
                    break;
                }

                errMsg = res.ToString();
                return res == Enums.WmiServiceReturnCode.Success;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Change service start type
        public static bool SetServiceStartTypeByName(string name, NativeEnums.ServiceStartType type,
            ManagementObjectSearcher objSearcher, ref string errMsg)
        {
            try
            {
                var res = Enums.WmiServiceReturnCode.AccessDenied;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToString(srv.GetPropertyValue(Enums.WmiInfoService.Name.ToString())) != name) continue;
                    var inParams = srv.GetMethodParameters("ChangeStartMode");
                    inParams["StartMode"] = GetServiceStartTypeAsString(type);
                    var outParams = srv.InvokeMethod("ChangeStartMode", inParams, null);
                    res = (Enums.WmiServiceReturnCode) outParams["ReturnValue"];
                    break;
                }

                errMsg = res.ToString();
                return res == Enums.WmiServiceReturnCode.Success;
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