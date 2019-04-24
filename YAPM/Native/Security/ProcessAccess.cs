using System;

namespace Native.Security
{
    [Flags()]
    public enum ProcessAccess : uint
    {
        Terminate = 0x1,
        CreateThread = 0x2,
        SetSessionId = 0x4,
        VmOperation = 0x8,
        VmRead = 0x10,
        VmWrite = 0x20,
        DupHandle = 0x40,
        CreateProcess = 0x80,
        SetQuota = 0x100,
        SetInformation = 0x200,
        QueryInformation = 0x400,
        SetPort = 0x800,
        SuspendResume = 0x800,
        QueryLimitedInformation = 0x1000,
        Synchronize = StandardRights.Synchronize,
        // should be 0xffff on Vista, but is 0xfff for backwards compatibility
        All = StandardRights.Required | StandardRights.Synchronize | 0xFFF
    }
}

