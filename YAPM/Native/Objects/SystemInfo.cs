using Native.Api;

namespace Native.Objects
{
    public class SystemInfo
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Wrapper for GetSystemInfo Win32 function
        public static NativeStructs.SystemInfo GetSystemInfo()
        {
            NativeStructs.SystemInfo si;
            Native.Api.NativeFunctions.GetSystemInfo(ref si);
            return si;
        }
    }
}

