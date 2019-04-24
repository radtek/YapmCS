using System;

namespace Native.Functions
{
    public class Service
    {

        // Get state/errorcontrol/starttype from a string as a type
        public static Native.Api.NativeEnums.ServiceErrorControl GetServiceErrorControlFromStringH(string s)
        {
            switch (s)
            {
                case "Ignore":
                    {
                        return Native.Api.NativeEnums.ServiceErrorControl.Ignore;
                    }

                case "Normal":
                    {
                        return Native.Api.NativeEnums.ServiceErrorControl.Normal;
                    }

                case "Severe":
                    {
                        return Native.Api.NativeEnums.ServiceErrorControl.Severe;
                    }

                case "Critical":
                    {
                        return Native.Api.NativeEnums.ServiceErrorControl.Critical;
                    }

                default:
                    {
                        return Native.Api.NativeEnums.ServiceErrorControl.Unknown;
                    }
            }
        }

        public static Native.Api.NativeEnums.ServiceStartType GetServiceStartTypeFromStringH(string s)
        {
            switch (s)
            {
                case "Boot":
                    {
                        return Native.Api.NativeEnums.ServiceStartType.BootStart;
                    }

                case "System":
                    {
                        return Native.Api.NativeEnums.ServiceStartType.SystemStart;
                    }

                case "Auto":
                    {
                        return Native.Api.NativeEnums.ServiceStartType.AutoStart;
                    }

                case "Manual":
                    {
                        return Native.Api.NativeEnums.ServiceStartType.DemandStart;
                    }

                case "Disabled":
                    {
                        return Native.Api.NativeEnums.ServiceStartType.StartDisabled;
                    }
            }
        }

        public static Native.Api.NativeEnums.ServiceState GetServiceStateFromStringH(string s)
        {
            switch (s)
            {
                case "Stopped":
                    {
                        return Native.Api.NativeEnums.ServiceState.Stopped;
                    }

                case "Start Pending":
                    {
                        return Native.Api.NativeEnums.ServiceState.StartPending;
                    }

                case "Stop Pending":
                    {
                        return Native.Api.NativeEnums.ServiceState.StopPending;
                    }

                case "Running":
                    {
                        return Native.Api.NativeEnums.ServiceState.Running;
                    }

                case "Continue Pending":
                    {
                        return Native.Api.NativeEnums.ServiceState.ContinuePending;
                    }

                case "Pause Pending":
                    {
                        return Native.Api.NativeEnums.ServiceState.PausePending;
                    }

                case "Paused":
                    {
                        return Native.Api.NativeEnums.ServiceState.Paused;
                    }

                default:
                    {
                        return Native.Api.NativeEnums.ServiceState.Unknown;
                    }
            }
        }

        public static Native.Api.NativeEnums.ServiceType GetServiceTypeFromStringH(string s)
        {
            switch (s)
            {
                case "Kernel Driver":
                    {
                        return Native.Api.NativeEnums.ServiceType.KernelDriver;
                    }

                case "File System Driver":
                    {
                        return Native.Api.NativeEnums.ServiceType.FileSystemDriver;
                    }

                case "Adapter":
                    {
                        return Native.Api.NativeEnums.ServiceType.Adapter;
                    }

                case "Recognizer Driver":
                    {
                        return Native.Api.NativeEnums.ServiceType.RecognizerDriver;
                    }

                case "Own Process":
                    {
                        return Native.Api.NativeEnums.ServiceType.Win32OwnProcess;
                    }

                case "Share Process":
                    {
                        return Native.Api.NativeEnums.ServiceType.Win32ShareProcess;
                    }

                case "Interactive Process":
                    {
                        return Native.Api.NativeEnums.ServiceType.InteractiveProcess;
                    }
            }
        }

        public static Native.Api.NativeEnums.ServiceErrorControl GetServiceErrorControlFromString(string s)
        {
            return (Native.Api.NativeEnums.ServiceErrorControl)Enum.Parse(typeof(Native.Api.NativeEnums.ServiceErrorControl), s);
        }

        public static Native.Api.NativeEnums.ServiceStartType GetServiceStartTypeFromString(string s)
        {
            return (Native.Api.NativeEnums.ServiceStartType)Enum.Parse(typeof(Native.Api.NativeEnums.ServiceStartType), s);
        }

        public static Native.Api.NativeEnums.ServiceState GetServiceStateFromString(string s)
        {
            return (Native.Api.NativeEnums.ServiceState)Enum.Parse(typeof(Native.Api.NativeEnums.ServiceState), s);
        }

        public static Native.Api.NativeEnums.ServiceType GetServiceTypeFromString(string s)
        {
            return (Native.Api.NativeEnums.ServiceType)Enum.Parse(typeof(Native.Api.NativeEnums.ServiceType), s);
        }
    }
}

