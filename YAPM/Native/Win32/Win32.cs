using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Native.Api
{
    public class Win32
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Contains NtStatus <-> Description
        private static Dictionary<UInt32, string> _dicoNtStatus = new Dictionary<UInt32, string>();


        // ========================================
        // Public properties
        // ========================================


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Return last error as a string
        public static string GetLastError()
        {
            int nLastError = Marshal.GetLastWin32Error();

            if (nLastError == 0)
                // Error occured
                return "";
            else
            {
                System.Text.StringBuilder lpMsgBuf = new System.Text.StringBuilder(0x100);
                uint dwChars = NativeFunctions.FormatMessage(NativeEnums.FormatMessageFlags.AllocateBuffer
                                                        | NativeEnums.FormatMessageFlags.FromSystem
                                                        | NativeEnums.FormatMessageFlags.MessageIgnoreInserts, IntPtr.Zero, nLastError, 0, ref lpMsgBuf, lpMsgBuf.Capacity, IntPtr.Zero);

                // Unknown error
                if (dwChars == 0)
                    return "Unknown error occured (0x" + nLastError.ToString("x") + ")";

                // Retrieve string
                return lpMsgBuf.ToString();
            }
        }


        // Get elapsed time since Windows started
        public static int GetElapsedTime()
        {
            return Native.Api.NativeFunctions.GetTickCount();
        }


        // Return message associated to a NtStatus
        public static string GetNtStatusMessageAsString(UInt32 status)
        {
            string sRes;
            if (status == 0)
                sRes = "Success";
            else
            {

                // If the status has already been retrieved, return result immediately
                if (_dicoNtStatus.ContainsKey(status))
                    return _dicoNtStatus[status];

                StringBuilder lpMessageBuffer = new StringBuilder(0x200);
                IntPtr Hand = NativeFunctions.LoadLibrary("NTDLL.DLL");

                // Get the buffer
                NativeFunctions.FormatMessage(NativeEnums.FormatMessageFlags.AllocateBuffer | NativeEnums.FormatMessageFlags.FromSystem | NativeEnums.FormatMessageFlags.FromHModule, Hand, status, MAKELANGID(NativeConstants.LANG_NEUTRAL, NativeConstants.SUBLANG_DEFAULT), ref lpMessageBuffer, 0, default(IntPtr));

                // Now get the string
                sRes = lpMessageBuffer.ToString();
                NativeFunctions.FreeLibrary(Hand);

                // Add to dico
                if (_dicoNtStatus.ContainsKey(status) == false)
                    _dicoNtStatus.Add(status, sRes);
            }

            return sRes;
        }



        // ========================================
        // Private functions
        // ========================================

        private static int MAKELANGID(int primary, int sub)
        {
            return (System.Convert.ToUInt16(sub) << 10) | System.Convert.ToUInt16(primary);
        }
        private static int PRIMARYLANGID(int lcid)
        {
            return System.Convert.ToUInt16(lcid) & 0x3FF;
        }
        private static int SUBLANGID(int lcid)
        {
            return System.Convert.ToUInt16(lcid) >> 10;
        }
    }
}

