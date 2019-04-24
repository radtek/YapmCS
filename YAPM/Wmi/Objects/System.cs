using System;
using System.Management;
using Native.Api;

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
        public static bool ShutdownRemoteComputer(Enums.ShutdownType type, bool force, ManagementObjectSearcher objSearcher, ref string msgError)
        {
            if (msgError == null) throw new ArgumentNullException(nameof(msgError));
            try
            {
                var res = Enums.WBEMStatus.WBEM_NO_ERROR;
                var param = Enums.WmiShutdownValues.LogOff;
                if (force)
                    param |= Enums.WmiShutdownValues.Force;
                switch (type)
                {
                    case Enums.ShutdownType.Logoff:
                        {
                            param |= Enums.WmiShutdownValues.LogOff;
                            break;
                        }

                    case Enums.ShutdownType.Poweroff:
                        {
                            param |= Enums.WmiShutdownValues.PowerOff;
                            break;
                        }

                    case Enums.ShutdownType.Restart:
                        {
                            param |= Enums.WmiShutdownValues.Reboot;
                            break;
                        }

                    case Enums.ShutdownType.Shutdown:
                        {
                            param |= Enums.WmiShutdownValues.Shutdown;
                            break;
                        }

                    case Enums.ShutdownType.Sleep:
                        break;
                    case Enums.ShutdownType.Hibernate:
                        break;
                    case Enums.ShutdownType.Lock:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
                var obj = new object[1];
                obj[0] = param;
                foreach (var o in objSearcher.Get())
                {
                    var osObj = (ManagementObject) o;
                    res = (Enums.WBEMStatus)osObj.InvokeMethod("Win32Shutdown", obj);
                    break;
                }

                msgError = res.ToString();
                return res == Enums.WBEMStatus.WBEM_NO_ERROR;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
    }
}

