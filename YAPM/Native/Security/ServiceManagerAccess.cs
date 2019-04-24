using System;

namespace Native.Security
{
    [Flags()]
    public enum ServiceManagerAccess : uint
    {
        Connect = 0x1,
        CreateService = 0x2,
        EnumerateService = 0x4,
        Lock = 0x8,
        QueryLockStatus = 0x10,
        ModifyBootConfig = 0x20,
        All = StandardRights.Required | ServiceManagerAccess.Connect | ServiceManagerAccess.CreateService | ServiceManagerAccess.EnumerateService | ServiceManagerAccess.Lock | ServiceManagerAccess.QueryLockStatus | ServiceManagerAccess.ModifyBootConfig
    }
}
