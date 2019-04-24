using System;
using System.Text;
using Native.Api;

namespace Native.Objects
{
    public class File
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

        /// <summary>
        // Retrieve a resource from a file
        // The file must looks like @%systemroot%\xxx\yy.exe, 5
        /// </summary>
        public static string GetResourceStringFromFile(string filePath)
        {

            // Windows dir
            string rootDir = System.Environment.GetFolderPath(Environment.SpecialFolder.System);

            // Insert Windows dir in path
            string s = filePath.ToUpperInvariant().Replace("@%SYSTEMROOT%", rootDir);
            s = s.ToUpperInvariant().Replace("%SYSTEMROOT%", rootDir);


            // Get pos of extension
            int i = s.IndexOf(".EXE");
            if (i <= 0)
            {
                // Dll ?
                i = s.IndexOf(".DLL");
                if (i <= 0)
                    // SYS ?
                    i = s.IndexOf(".SYS");
            }

            // Get ID and File
            uint iD;
            string file;
            file = s.Substring(0, s.Length - 3);
            try
            {
                iD = uint.Parse(s.Substring(i + 6, s.Length - i - 6));
                // Get resource
                return Common.Misc.FormatPathWithDoubleSlashs(GetResourceStringFromFile(file, iD));
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        // Retrieve a resource from a file
        public static string GetResourceStringFromFile(string file, uint id)
        {
            IntPtr hInst = NativeFunctions.LoadLibrary(file);
            StringBuilder sb = new StringBuilder(1024);
            NativeFunctions.LoadString(hInst, id, sb, sb.Capacity);
            NativeFunctions.FreeLibrary(hInst);
            return sb.ToString();
        }
    }
}

