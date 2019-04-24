using System;

namespace Native.Objects
{
    public class General
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

        // Close a handle
        public static void CloseHandle(IntPtr handle)
        {
            Native.Api.NativeFunctions.CloseHandle(handle);
        }
    }
}

