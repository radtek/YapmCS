using System;

namespace Native.Api
{
    public class NativeConstants
    {
        public const int STILL_ACTIVE = 259;



        public const int FILE_MAP_READ = SECTION_MAP_READ;
        public const int FILE_MAP_WRITE = SECTION_MAP_WRITE;
        public const int PAGE_READWRITE = 0x4;
        public const int SECTION_MAP_READ = 0x4;
        public const int SECTION_MAP_WRITE = 0x2;

        public const int SHGFI_ICON = 0x100;
        public const int SHGFI_SMALLICON = 0x1;
        public const int SHGFI_LARGEICON = 0x0;


        // OK

        public const int NULL_BRUSH = 5; // Stock Object

        public const int GWL_HWNDPARENT = -8;
        public const int GW_CHILD = 5;
        public const int GW_HWNDNEXT = 2;
        public const int WM_GETICON = 0x7F;
        public const int GCL_HICON = -14;
        public const int GCL_HICONSM = -34;
        public const int WM_CLOSE = 0x10;
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SWP_NOSIZE = 0x1;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOACTIVATE = 0x10;
        public const int HWND_TOPMOST = -1;
        public const int SWP_SHOWWINDOW = 0x40;
        public const int HWND_NOTOPMOST = -2;
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_COLORKEY = 0x1;
        public const int LWA_ALPHA = 0x2;


        // OK

        public const int KEY_NOTIFY = 0x10;


        // OK

        // Some constants
        public const int BCM_FIRST = 0x1600;
        public const int BCM_SETSHIELD = (BCM_FIRST + &H);

        // Infinite time for WaitSingleObject
        public const int WAIT_INFINITE = 0xFFFF;

        // Nt return status
        public const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;

        public const int LANG_NEUTRAL = 0x0;
        public const int SUBLANG_DEFAULT = 0x1;


        // OK

        // Some constants
        public const int SC_CLOSE = 0xF060;
        public const int MF_GRAYED = 0x1;
        public const int LVS_EX_BORDERSELECT = 0x8000;
        public const int LVS_EX_DOUBLEBUFFER = 0x10000;


        // OK

        public const int HC_ACTION = 0;


        // OK

        public static readonly IntPtr InvalidHandleValue = new IntPtr(-1);


        // OK

        // For wintrust verifications
        public const string WintrustActionGenericVerify2 = "{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}";
    }
}

