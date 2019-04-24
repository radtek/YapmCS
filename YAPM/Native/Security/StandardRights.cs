using System;

namespace Native.Security
{
    [Flags()]
    public enum StandardRights : uint
    {
        Delete = 0x10000,
        ReadControl = 0x20000,
        WriteDac = 0x40000,
        WriteOwner = 0x80000,
        Synchronize = 0x100000,
        Required = 0xF0000,
        Read = StandardRights.ReadControl,
        Write = StandardRights.ReadControl,
        Execute = StandardRights.ReadControl,
        All = 0x1F0000,
        SpecificRightsAll = 0xFFFF,
        AccessSystemSecurity = 0x1000000,
        MaximumAllowed = 0x2000000,
        GenericRead = 0x80000000,
        GenericWrite = 0x40000000,
        GenericExecute = 0x20000000,
        GenericAll = 0x10000000
    }
}

