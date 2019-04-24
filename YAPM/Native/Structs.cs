using System.Net;

namespace Native.Api
{
    public class Structs
    {

        // OK

        public struct LightConnection
        {
            public int dwState;
            public IPEndPoint local;
            public IPEndPoint remote;
            public int dwOwningPid;
            public Enums.NetworkProtocol dwType;
        }

        public struct NicDescription
        {
            public string Name;
            public string Description;
            public string Ip;
            public NicDescription(string aName, string aDesc, string aIp)
            {
                Name = aName;
                Description = aDesc;
                Ip = aIp;
            }
        }


        // OK

        public struct ProcTimeInfo
        {
            public long time;
            public long kernel;
            public long user;
            public long total;
            public ProcTimeInfo(long aTime, long aUser, long aKernel)
            {
                time = aTime;
                kernel = aKernel;
                user = aUser;
                total = user + kernel;
            }
        }

        public struct ProcMemInfo
        {
            public long time;
            public Native.Api.NativeStructs.VmCountersEx mem;
            public ProcMemInfo(long aTime, ref Native.Api.NativeStructs.VmCountersEx aMem)
            {
                time = aTime;
                mem = aMem;
            }
        }

        public struct ProcIoInfo
        {
            public long time;
            public Native.Api.NativeStructs.IoCounters io;
            public ProcIoInfo(long aTime, ref Native.Api.NativeStructs.IoCounters aIo)
            {
                time = aTime;
                io = aIo;
            }
        }

        public struct ProcMiscInfo
        {
            public long time;
            public int gdiO;
            public int userO;
            public double cpuUsage;
            public double averageCpuUsage;
            public ProcMiscInfo(long aTime, int aGdi, int aUser, double aCpu, double aAverage)
            {
                time = aTime;
                gdiO = aGdi;
                userO = aUser;
                cpuUsage = aCpu;
                averageCpuUsage = aAverage;
            }
        }


        // OK

        public struct ServiceCreationParams
        {
            public string ServiceName;
            public string DisplayName;
            public NativeEnums.ServiceType Type;
            public NativeEnums.ServiceStartType StartType;
            public NativeEnums.ServiceErrorControl ErrorControl;
            public string FilePath;
            public string Arguments;
            public string RegMachine;
            public string RegUser;
            public System.Security.SecureString RegPassword;
        }
    }
}
