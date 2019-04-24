using System;
using System.Management;

namespace Wmi.Objects
{
    public class cSystem
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

        // Shutdown remote pc
        public static bool ShutdownRemoteComputer(Native.Api.Enums.ShutdownType type, bool force, System.Management.ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                Native.Api.Enums.WBEMStatus res;
                Native.Api.Enums.WmiShutdownValues param;
                if (force)
                    param = param | Native.Api.Enums.WmiShutdownValues.Force;
                switch (type)
                {
                    case Native.Api.Enums.ShutdownType.Logoff:
                        {
                            param = param | Native.Api.Enums.WmiShutdownValues.LogOff;
                            break;
                        }

                    case Native.Api.Enums.ShutdownType.Poweroff:
                        {
                            param = param | Native.Api.Enums.WmiShutdownValues.PowerOff;
                            break;
                        }

                    case Native.Api.Enums.ShutdownType.Restart:
                        {
                            param = param | Native.Api.Enums.WmiShutdownValues.Reboot;
                            break;
                        }

                    case Native.Api.Enums.ShutdownType.Shutdown:
                        {
                            param = param | Native.Api.Enums.WmiShutdownValues.Shutdown;
                            break;
                        }
                }
                object[] obj = new object[1];
                obj[0] = (object)param;
                foreach (ManagementObject osObj in objSearcher.Get())
                {
                    res = (Native.Api.Enums.WBEMStatus)osObj.InvokeMethod("Win32Shutdown", obj);
                    break;
                }

                msgError = res.ToString();
                return (res == Native.Api.Enums.WBEMStatus.WBEM_NO_ERROR);
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
    }
}

