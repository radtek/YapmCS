using System;
using Native.Api;

namespace Native.Driver
{
    internal class DriverCtrl
    {

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Handle to manager
        private IntPtr hSCM;

        // Handle to service
        private IntPtr hService;

        private string mvarServiceName;
        private string mvarServiceDisplayName;
        private NativeEnums.ServiceType mvarServiceType;
        private NativeEnums.ServiceStartType mvarServiceStartType;
        private NativeEnums.ServiceErrorControl mvarServiceErrorType;
        private string mvarServiceFileName;


        // ========================================
        // Public properties
        // ========================================

        public string ServiceFileName
        {
            get
            {
                ServiceFileName = mvarServiceFileName;
            }
            set
            {
                mvarServiceFileName = value;
            }
        }


        public NativeEnums.ServiceErrorControl ServiceErrorType
        {
            get
            {
                ServiceErrorType = mvarServiceErrorType;
            }
            set
            {
                mvarServiceErrorType = value;
            }
        }


        public NativeEnums.ServiceStartType ServiceStartType
        {
            get
            {
                ServiceStartType = mvarServiceStartType;
            }
            set
            {
                mvarServiceStartType = value;
            }
        }


        public NativeEnums.ServiceType ServiceType
        {
            get
            {
                ServiceType = mvarServiceType;
            }
            set
            {
                mvarServiceType = value;
            }
        }


        public string ServiceDisplayName
        {
            get
            {
                ServiceDisplayName = mvarServiceDisplayName;
            }
            set
            {
                mvarServiceDisplayName = value;
            }
        }


        public string ServiceName
        {
            get
            {
                ServiceName = mvarServiceName;
            }
            set
            {
                mvarServiceName = value;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Get a handle to our driver
        public IntPtr OpenDriver()
        {
            return NativeFunctions.CreateFile(@"\\.\" + mvarServiceName, NativeEnums.EFileAccess.GenericRead | NativeEnums.EFileAccess.GenericWrite, NativeEnums.EFileShare.Read | NativeEnums.EFileShare.Write, IntPtr.Zero, NativeEnums.ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
        }

        // Close service manager
        public void CloseSCM()
        {
            NativeFunctions.CloseServiceHandle(hSCM);
            hSCM = IntPtr.Zero;
        }

        // Query state of our service
        public NativeEnums.ServiceState QueryServiceState()
        {
            NativeStructs.ServiceStatus ss;

            // Open service
            if (OpenService())
            {
                NativeFunctions.QueryServiceStatus(hService, ref ss);
                return ss.CurrentState;
            }
            else
                return NativeEnums.ServiceState.Unknown;
        }

        // Open a handle to our service
        public bool OpenService()
        {
            if (hService.IsNull())
            {
                hService = NativeFunctions.OpenService(hSCM, mvarServiceName, Native.Security.ServiceAccess.QueryStatus | Native.Security.ServiceAccess.Start | Native.Security.ServiceAccess.Stop | Native.Security.ServiceAccess.Delete);

                if (hService.IsNull())
                    // Try with lower requirements
                    hService = NativeFunctions.OpenService(hSCM, mvarServiceName, Native.Security.ServiceAccess.QueryStatus | Native.Security.ServiceAccess.Start | Native.Security.ServiceAccess.Stop);

                return hService.IsNotNull();
            }
            else
                return true;
        }

        // Registrer our service
        public bool InstallService()
        {
            bool ret;

            hService = NativeFunctions.CreateService(hSCM, mvarServiceName, mvarServiceDisplayName, Native.Security.ServiceAccess.QueryStatus | Native.Security.ServiceAccess.Start | Native.Security.ServiceAccess.Stop, mvarServiceType, mvarServiceStartType, mvarServiceErrorType, mvarServiceFileName, null, IntPtr.Zero, default(IntPtr), null, null);
            ret = hService.IsNotNull();

            // Close service handle
            CloseService();

            // Reopen with good access
            OpenService();

            return ret;
        }

        // Remove service
        public bool RemoveService()
        {
            bool ret;

            // Open service
            if (OpenService())
            {
                // Delete service
                ret = NativeFunctions.DeleteService(hService);
                // Close handle
                CloseService();
                return ret;
            }
            else
                return false;
        }

        // Start our service
        public bool StartService()
        {

            // Open our service
            if (OpenService())
            {

                // Start !
                if (NativeFunctions.StartService(hService, 0, null))
                {
                    // Wait for the service to be running
                    while (QueryServiceState() != NativeEnums.ServiceState.Running)
                        NativeFunctions.Sleep(500);
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Stop service
        public bool StopService()
        {
            bool bResult;
            NativeStructs.ServiceStatusProcess ss;

            // Open service
            if (OpenService())
            {

                // on demande l'arrкt du service
                bResult = NativeFunctions.ControlService(hService, NativeEnums.ServiceControl.Stop, out ss);
                if (bResult)
                {
                    // Wait for the service to be stopped
                    while (QueryServiceState() != NativeEnums.ServiceState.Stopped)
                        NativeFunctions.Sleep(500);
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Constructor
        public DriverCtrl() : base()
        {
            Class_Initialize_Renamed();
        }


        // ========================================
        // Private functions
        // ========================================

        // Open handle to service manager
        private void OpenSCM()
        {
            if (hSCM.IsNull())
            {
                hSCM = NativeFunctions.OpenSCManager(null, null, Native.Security.ServiceManagerAccess.EnumerateService | Native.Security.ServiceManagerAccess.CreateService);

                // Try with lower requirements
                if (hSCM.IsNull())
                    hSCM = NativeFunctions.OpenSCManager(null, null, Native.Security.ServiceManagerAccess.EnumerateService);
            }
        }

        // Close service handle
        private void CloseService()
        {
            NativeFunctions.CloseServiceHandle(hService);
            hService = IntPtr.Zero;
        }

        // Initialization
        private void Class_Initialize_Renamed()
        {
            // Open SCM
            OpenSCM();
        }

        // Terminate
        private void Class_Terminate_Renamed()
        {
            CloseService();
            CloseSCM();
        }
        ~DriverCtrl()
        {
            Class_Terminate_Renamed();
        }
    }
}
