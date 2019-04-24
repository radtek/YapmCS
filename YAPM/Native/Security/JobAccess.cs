using System;

namespace Native.Security
{
    [Flags()]
    public enum JobAccess : uint
    {
        AssignProcess = 0x1,
        SetAttributes = 0x2,
        Query = 0x4,
        Terminate = 0x8,
        SetSecurityAttributes = 0x10,
        All = 0x1F001F
    }
}
