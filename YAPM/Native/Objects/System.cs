using Native.Api;

public class cSystem
{

    // ========================================
    // Public
    // ========================================
    public static bool Hibernate(bool force = true)
    {
        return NativeFunctions.SetSuspendState(true, force, false);
    }

    public static bool Sleep(bool force = true)
    {
        return NativeFunctions.SetSuspendState(false, force, false);
    }

    public static bool Logoff(bool force = true)
    {
        if (force)
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Logoff | NativeEnums.ExitWindowsFlags.Force, 0);
        else
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Logoff, 0);
    }

    public static bool Lock()
    {
        return NativeFunctions.LockWorkStation();
    }

    public static bool Shutdown(bool force = true)
    {
        if (force)
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Shutdown | NativeEnums.ExitWindowsFlags.Force, 0);
        else
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Shutdown, 0);
    }

    public static bool Restart(bool force = true)
    {
        if (force)
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Reboot | NativeEnums.ExitWindowsFlags.Force, 0);
        else
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Reboot, 0);
    }

    public static bool Poweroff(bool force = true)
    {
        if (force)
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Poweroff | NativeEnums.ExitWindowsFlags.Force, 0);
        else
            return NativeFunctions.ExitWindowsEx(NativeEnums.ExitWindowsFlags.Poweroff, 0);
    }
}

