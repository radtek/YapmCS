using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Window
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

        // Get all windows
        public static Dictionary<string, cWindow> EnumerateAllWindows()
        {
            // Local
            IntPtr currWnd;
            int cpt;

            Dictionary<string, cWindow> _dico = new Dictionary<string, cWindow>();

            currWnd = GetWindow(GetDesktopWindow(), NativeEnums.GetWindowCmd.Child);
            cpt = 0;
            while (currWnd.IsNotNull())
            {

                // Get procId from hwnd
                int pid = GetProcessIdFromWindowHandle(currWnd);
                int tid = GetThreadIdFromWindowHandle(currWnd);
                string key = pid.ToString() + "-" + tid.ToString() + "-" + currWnd.ToString();
                if (_dico.ContainsKey(key) == false)
                    _dico.Add(key, new cWindow(new windowInfos(pid, tid, currWnd, GetWindowCaption(currWnd))));

                currWnd = NativeFunctions.GetWindow(currWnd, NativeEnums.GetWindowCmd.Next);
            }

            return _dico;
        }

        // Enumerate windows (local)
        public static void EnumerateWindowsByProcessId(int processId, bool allProcesses, bool showUnnamed, ref Dictionary<string, windowInfos> _dico, bool refreshAllInfos)
        {
            IntPtr currWnd;
            int cpt;

            currWnd = NativeFunctions.GetWindow(NativeFunctions.GetDesktopWindow(), NativeEnums.GetWindowCmd.Child);
            cpt = 0;
            while (currWnd.IsNotNull())
            {

                // Get procId from hwnd
                int pid = GetProcessIdFromWindowHandle(currWnd);
                if (allProcesses || pid == processId)
                {
                    // Then this window belongs to one of our processes
                    string sCap = GetWindowCaption(currWnd);
                    if (showUnnamed || sCap.Length > 0)
                    {
                        int tid = GetThreadIdFromWindowHandle(currWnd);
                        string key = pid.ToString() + "-" + tid.ToString() + "-" + currWnd.ToString();
                        if (_dico.ContainsKey(key) == false)
                        {
                            if (refreshAllInfos)
                            {
                                // Then we need to retrieve all informations
                                // (this is server mode)
                                windowInfos wInfo;
                                wInfo = new windowInfos(pid, tid, currWnd, sCap);
                                wInfo.SetNonFixedInfos(ref asyncCallbackWindowGetNonFixedInfos.ProcessAndReturnLocal(currWnd));
                                _dico.Add(key, wInfo);
                            }
                            else
                                _dico.Add(key, new windowInfos(pid, tid, currWnd, sCap));
                        }
                    }
                }

                currWnd = NativeFunctions.GetWindow(currWnd, NativeEnums.GetWindowCmd.Next);
            }
        }

        // Return process id from a handle
        public static int GetProcessIdFromWindowHandle(IntPtr hwnd)
        {
            int id = 0;
            NativeFunctions.GetWindowThreadProcessId(hwnd, out id);
            return id;
        }

        // Return caption
        public static string GetWindowCaption(IntPtr hWnd)
        {
            int length;
            length = NativeFunctions.GetWindowTextLength(hWnd);
            if (length > 0)
            {
                System.Text.StringBuilder _cap = new System.Text.StringBuilder(Strings.Space(length + 1));
                length = NativeFunctions.GetWindowText(hWnd, _cap, length + 1);
                return _cap.ToString().Substring(0, Strings.Len(_cap.ToString()));
            }
            else
                return "";
        }

        // Return thread id from a handle
        public static int GetThreadIdFromWindowHandle(IntPtr hwnd)
        {
            return NativeFunctions.GetWindowThreadProcessId(hwnd, out 0);
        }

        // Is enabled ?
        public static bool IsWindowEnabled(IntPtr handle)
        {
            return NativeFunctions.IsWindowEnabled(handle);
        }

        // Is visible ?
        public static bool IsWindowVisible(IntPtr handle)
        {
            return NativeFunctions.IsWindowVisible(handle);
        }

        // Is a task ?
        public static bool IsWindowATask(IntPtr hwnd)
        {
            // Window must be visible
            if (NativeFunctions.IsWindowVisible(hwnd) && NativeFunctions.GetWindowLongPtr(hwnd, NativeEnums.GetWindowLongOffset.HwndParent).IsNull() && !(NativeFunctions.GetWindowTextLength(hwnd) == 0))
            {
                // Must not be taskmgr
                if (GetWindowClass(hwnd) != "Progman")
                    return true;
            }

            return false;
        }

        // Return window opacity
        public static byte GetWindowOpacityByHandle(IntPtr handle)
        {
            byte alpha;
            NativeFunctions.GetLayeredWindowAttributes(handle, ref 0, ref alpha, ref NativeConstants.LWA_ALPHA);
            return alpha;
        }

        // Get position/size
        public static NativeStructs.Rect GetWindowPositionAndSizeByHandle(IntPtr handle)
        {
            NativeStructs.Rect tmpRect;
            NativeFunctions.GetWindowRect(handle, out tmpRect);
            return tmpRect;
        }

        // Return window class
        public static string GetWindowClass(IntPtr hWnd)
        {
            System.Text.StringBuilder _class = new System.Text.StringBuilder(Strings.Space(255));
            NativeFunctions.GetClassName(hWnd, _class, 255);
            return _class.ToString();
        }

        // Wrapper to GetWindow Win32 function
        public static IntPtr GetWindow(IntPtr hWnd, NativeEnums.GetWindowCmd cmd)
        {
            return NativeFunctions.GetWindow(hWnd, cmd);
        }

        // Wrapper to GetDesktopWindow
        public static IntPtr GetDesktopWindow()
        {
            return NativeFunctions.GetDesktopWindow();
        }

        // Wrapper to SetForegroundWindow
        public static bool SetForegroundWindowByHandle(IntPtr handle)
        {
            return NativeFunctions.SetForegroundWindow(handle);
        }

        // Close a window
        public static bool CloseWindowByHandle(IntPtr handle)
        {
            return NativeFunctions.SendMessage(handle, NativeEnums.WindowMessage.Close, IntPtr.Zero, IntPtr.Zero).IsNull();
        }

        // Wrapper to GetForegroundWindow Win32 function
        public static IntPtr GetForegroundWindow()
        {
            return NativeFunctions.GetForegroundWindow();
        }

        // Get small icon handle of window
        public static IntPtr GetWindowSmallIconHandleByHandle(IntPtr handle)
        {
            IntPtr res;
            IntPtr @out;

            // Time we wait if we can not return SendMessage immediately
            const int WaitingTime = 50;

            res = NativeFunctions.SendMessageTimeout(handle, NativeEnums.WindowMessage.GetIcon, new IntPtr(NativeEnums.IconSize.Small), IntPtr.Zero, NativeEnums.SendMessageTimeoutFlags.AbortIfHung, WaitingTime, ref @out);

            if (@out.IsNull())
                @out = NativeFunctions.GetClassLongPtr(handle, NativeConstants.GCL_HICONSM);

            if (@out.IsNull())
                res = NativeFunctions.SendMessageTimeout(NativeFunctions.GetWindowLongPtr(handle, NativeEnums.GetWindowLongOffset.HwndParent), NativeEnums.WindowMessage.GetIcon, new IntPtr(NativeEnums.IconSize.Small), IntPtr.Zero, NativeEnums.SendMessageTimeoutFlags.AbortIfHung, WaitingTime, ref @out);

            return @out;
        }

        // Flash a window
        public static bool FlashWindowByHandle(IntPtr handle, NativeEnums.FlashWInfoFlags flag, int count = int.MaxValue)
        {
            NativeStructs.FlashWInfo FlashInfo;

            {
                var withBlock = FlashInfo;
                withBlock.cbSize = System.Convert.ToUInt32(Marshal.SizeOf(FlashInfo));
                withBlock.dwFlags = flag;
                withBlock.dwTimeout = 0;
                withBlock.hwnd = handle;
                withBlock.uCount = System.Convert.ToUInt32(count);
            }

            return NativeFunctions.FlashWindowEx(ref FlashInfo);
        }

        // Hide window
        public static bool HideWindowByHandle(IntPtr handle)
        {
            return NativeFunctions.ShowWindow(handle, NativeEnums.ShowWindowType.Hide);
        }

        // Show window
        public static bool ShowWindowByHandle(IntPtr handle, NativeEnums.ShowWindowType flag = NativeEnums.ShowWindowType.Show)
        {
            return !(NativeFunctions.ShowWindow(handle, flag));
        }

        // Maximize window
        public static bool MaximizeWindowByHandle(IntPtr handle)
        {
            return NativeFunctions.ShowWindow(handle, NativeEnums.ShowWindowType.ShowMaximized);
        }

        // Minimize window
        public static bool MinimizeWindowByHandle(IntPtr handle)
        {
            return NativeFunctions.ShowWindow(handle, NativeEnums.ShowWindowType.ShowMinimized);
        }

        // Bring to front (or not)
        public static bool BringWindowToFrontByHandle(IntPtr handle, bool val)
        {
            IntPtr flag;
            if (val)
                flag = new IntPtr(NativeConstants.HWND_TOPMOST);
            else
                flag = new IntPtr(NativeConstants.HWND_NOTOPMOST);

            return NativeFunctions.SetWindowPos(handle, flag, 0, 0, 0, 0, NativeConstants.SWP_NOACTIVATE | NativeConstants.SWP_SHOWWINDOW | NativeConstants.SWP_NOMOVE | NativeConstants.SWP_NOSIZE);
        }

        // Wrapper for SetActiveWindow
        public static bool SetActiveWindowByHandle(IntPtr handle)
        {
            return (NativeFunctions.SetActiveWindow(handle).IsNotNull());
        }

        // Enable a window
        public static bool EnableWindowByHandle(IntPtr handle, bool val)
        {
            return NativeFunctions.EnableWindow(handle, val);
        }

        // Set opacity
        public static bool SetWindowOpacityByHandle(IntPtr handle, byte alpha)
        {
            if (alpha == 255)
                return (DisableWindowOpacity(handle).IsNotNull());
            else
            {
                EnableWindowOpacity(handle);
                return SetOpacity(handle, alpha);
            }
        }

        // Wrapper for SendMessage
        public static IntPtr SendMessage(IntPtr handle, NativeEnums.WindowMessage val, IntPtr o1, IntPtr o2)
        {
            return NativeFunctions.SendMessage(handle, val, o1, o2);
        }

        // Set position/size
        public static bool SetWindowPositionAndSizeByHandle(IntPtr handle, NativeStructs.Rect r)
        {
            NativeStructs.WindowPlacement WndPl;
            WndPl.Length = Marshal.SizeOf(WndPl);
            NativeFunctions.GetWindowPlacement(handle, ref WndPl);
            WndPl.NormalPosition = r;
            return NativeFunctions.SetWindowPlacement(handle, ref WndPl);
        }

        // Set caption
        public static bool SetWindowCaptionByHandle(IntPtr handle, string caption)
        {
            return (Native.Api.NativeFunctions.SetWindowText(handle, new System.Text.StringBuilder(caption)) != 0);
        }




        // ========================================
        // Private functions
        // ========================================

        // Set opacity
        private static bool SetOpacity(IntPtr handle, byte val)
        {
            return NativeFunctions.SetLayeredWindowAttributes(handle, 0, val, NativeConstants.LWA_ALPHA);
        }

        // Disable opacity
        private static IntPtr DisableWindowOpacity(IntPtr handle)
        {
            return NativeFunctions.SetWindowLongPtr(handle, NativeEnums.GetWindowLongOffset.ExStyle, NativeFunctions.GetWindowLongPtr(handle, NativeEnums.GetWindowLongOffset.ExStyle).Decrement(NativeConstants.WS_EX_LAYERED));
        }

        // Enable opacity
        private static IntPtr EnableWindowOpacity(IntPtr handle)
        {
            return NativeFunctions.SetWindowLongPtr(handle, NativeEnums.GetWindowLongOffset.ExStyle, (NativeFunctions.GetWindowLongPtr(handle, NativeEnums.GetWindowLongOffset.ExStyle).Increment(NativeConstants.WS_EX_LAYERED)));
        }
    }
}

