using System;

namespace Native.Security
{
    [Flags()]
    public enum ThreadAccess : uint
    {
        Terminate = 0x1,
        SuspendResume = 0x2,
        Alert = 0x4,
        GetContext = 0x8,
        SetContext = 0x10,
        SetInformation = 0x20,
        QueryInformation = 0x40,
        SetThreadToken = 0x80,
        Impersonate = 0x100,
        DirectImpersonation = 0x200,
        SetLimitedInformation = 0x400,
        QueryLimitedInformation = 0x800,
        // should be 0xffff on Vista, but is 0xfff for backwards compatibility
        All = StandardRights.Required | StandardRights.Synchronize | 0xFFF
    }
}

