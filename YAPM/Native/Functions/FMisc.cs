using System.Windows.Forms;
using System;

namespace Native.Functions
{
    public class Misc
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
        // Public functions
        // ========================================

        // Set 'explorer' theme
        public static void SetTheme(IntPtr handle)
        {
            Native.Api.NativeFunctions.SetWindowTheme(handle, "explorer", null);
        }

        // Set a listview as 'double buffered'
        public static void SetListViewAsDoubleBuffered(ref ListView lv)
        {
            IntPtr styles = Native.Api.NativeFunctions.SendMessage(lv.Handle, Native.Api.NativeEnums.LVM.GetExtendedListviewStyle, IntPtr.Zero, IntPtr.Zero);
            styles = (IntPtr)styles.ToInt32() | Native.Api.NativeEnums.LvsEx.DoubleBuffer | Native.Api.NativeEnums.LvsEx.BorderSelect;
            Native.Api.NativeFunctions.SendMessage(lv.Handle, Native.Api.NativeEnums.LVM.SetExtendedListviewStyle, IntPtr.Zero, styles);
        }
    }
}

