using System;

namespace Native.Security
{
    [Flags()]
    public enum TokenAccess : uint
    {
        AllPlusSessionId = 0xF01FF,
        MaximumAllowed = 0x2000000,
        AccessSystemSecurity = 0x1000000,
        AssignPrimary = 0x1,
        Duplicate = 0x2,
        Impersonate = 0x4,
        Query = 0x8,
        QuerySource = 0x10,
        AdjustPrivileges = 0x20,
        AdjustGroups = 0x40,
        AdjustDefault = 0x80,
        AdjustSessionId = 0x100,
        All = StandardRights.Required | TokenAccess.AssignPrimary | TokenAccess.Duplicate | TokenAccess.Impersonate | TokenAccess.Query | TokenAccess.QuerySource | TokenAccess.AdjustPrivileges | TokenAccess.AdjustGroups | TokenAccess.AdjustDefault | TokenAccess.AdjustSessionId,
        GenericRead = StandardRights.Read | TokenAccess.Query,
        GenericWrite = StandardRights.Write | TokenAccess.AdjustPrivileges | TokenAccess.AdjustGroups | TokenAccess.AdjustDefault,
        GenericExecute = StandardRights.Execute
    }
}

