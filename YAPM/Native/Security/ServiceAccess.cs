using System;

namespace Native.Security
{
    [Flags()]
    public enum ServiceAccess : uint
    {
        QueryConfig = 0x1,
        ChangeConfig = 0x2,
        QueryStatus = 0x4,
        EnumerateDependents = 0x8,
        Start = 0x10,
        Stop = 0x20,
        PauseContinue = 0x40,
        Interrogate = 0x80,
        UserDefinedControl = 0x100,
        Delete = 0x10000,
        All = StandardRights.Required | ServiceAccess.QueryConfig | ServiceAccess.ChangeConfig | ServiceAccess.QueryStatus | ServiceAccess.EnumerateDependents | ServiceAccess.Start | ServiceAccess.Stop | ServiceAccess.PauseContinue | ServiceAccess.Interrogate | ServiceAccess.UserDefinedControl
    }
}
