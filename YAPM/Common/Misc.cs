using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using Microsoft.Samples;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Common
{
    public class Misc
    {



        // ========================================
        // Private constants
        // ========================================
        private static string[] sizeUnits = new[] { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB" };


        // ========================================
        // Private attributes
        // ========================================

        // Contains devices (logical drives) and their corresponding path
        // e.g. :        /Device/Harddisk1/...       , C:
        // Protected by semaphore
        private static Dictionary<string, string> _DicoLogicalDrivesNames = new Dictionary<string, string>();
        private static System.Threading.Semaphore _semProtectDicoLogDrives = new System.Threading.Semaphore(1, 1);


        // ========================================
        // Public properties
        // ========================================
        public static System.Drawing.Color NON_BLACK_COLOR
        {
            get
            {
                return System.Drawing.Color.FromArgb(30, 30, 30);
            }
        }


        // ========================================
        // Other public
        // ========================================
        public enum SecurityRisk : int
        {
            Unknow = -1,
            Safe = 0,
            Caution1 = 1,
            Caution2 = 2,
            Alert1 = 3,
            Alert2 = 4,
            Alert3 = 4
        }

        public struct InternetProcessInfo
        {
            public string _Description;
            public SecurityRisk _Risk;
        }



        // ========================================
        // Public functions
        // ========================================

        // Return a path without double-slashs
        public static string FormatPathWithoutDoubleSlashs(string path)
        {
            if (path != null)
                return path.Replace(@"\\", @"\");
            else
                return null;
        }

        // Return a path with double-slashs
        public static string FormatPathWithDoubleSlashs(string path)
        {
            if (path != null)
                return path.Replace(@"\", @"\\");
            else
                return null;
        }


        // Get a formated value as a string (in Bytes, KB, MB or GB) from an Integer
        public static string GetFormatedSize(double size, int digits = 3)
        {
            return GetFormatedSize(new decimal(size), digits);
        }
        public static string GetFormatedSize(int size, int digits = 3)
        {
            return GetFormatedSize(new decimal(size), digits);
        }
        public static string GetFormatedSize(ulong size, int digits = 3)
        {
            return GetFormatedSize(new decimal(size), digits);
        }
        public static string GetFormatedSize(IntPtr size, int digits = 3)
        {
            return GetFormatedSize(new decimal(size.ToInt64()), digits);
        }
        public static string GetFormatedSize(uint size, int digits = 3)
        {
            return GetFormatedSize(new decimal(size), digits);
        }
        public static string GetFormatedSize(decimal size, int digits = 3)
        {
            decimal t = size;
            int dep = 0;

            while (t >= 1024)
            {
                t /= 1024;
                dep += 1;
            }

            double d = Math.Round(t, digits);

            if (d > 0)
                return d.ToString() + " " + sizeUnits[dep];
            else
                return "";
        }
        public static long GetSizeFromFormatedSize(string _frmtSize)
        {
            // Get position of space
            if (_frmtSize == null || _frmtSize.Length < 4)
                return 0;

            int x = -1;
            foreach (string _unit in sizeUnits)
            {
                x += 1;
                int i = Strings.InStrRev(_frmtSize, " " + _unit);
                if (i > 0)
                {
                    string z = _frmtSize.Substring(0, i - 1);
                    return System.Convert.ToInt64(double.Parse(z, System.Globalization.NumberStyles.Float) * Math.Pow(1024, x));
                }
            }
        }

        // Get formated size per second
        public static string GetFormatedSizePerSecond(double size, int digits = 3)
        {
            return GetFormatedSizePerSecond(new decimal(size), digits);
        }
        public static string GetFormatedSizePerSecond(decimal size, int digits = 3)
        {
            decimal t = size;
            int dep = 0;

            while (t >= 1024)
            {
                t /= 1024;
                dep += 1;
            }

            if (size > 0)
                return System.Convert.ToString(Math.Round(t, digits)) + " " + sizeUnits[dep] + "/s";
            else
                return "";
        }

        // Return true if a string is (or seems to be) a formated size
        public static bool IsFormatedSize(string _str)
        {
            if (_str == null || _str.Length < 4)
                return false;
            // Try to find " UNIT" in _str
            // Return true if first char is a numeric value
            foreach (string _unit in sizeUnits)
            {
                int i = Strings.InStrRev(_str, " " + _unit);
                if (i > 0 && (i + _unit.Length) == _str.Length)
                    return Information.IsNumeric(_str.Substring(0, 1));
            }
            return false;
        }

        // Return true if a string is (or seems to be) a hexadecimal expression
        public static bool IsHex(string _str)
        {
            if (_str == null || _str.Length < 4)
                return false;
            return (_str.Substring(0, 2) == "0x");
        }

        // Return long value from hex value
        public static long HexToLong(string _str)
        {
            if (_str == null || _str.Length < 4)
                return 0;
            return long.Parse(_str.Substring(2, _str.Length - 2), System.Globalization.NumberStyles.AllowHexSpecifier);
        }

        // Get a formated percentage
        public static string GetFormatedPercentage(double p, int digits = 3, bool force0 = false)
        {
            if (force0 || p > 0)
            {
                double d100 = p * 100;
                double d = Math.Round(d100, digits);
                double tr = Math.Truncate(d);
                int lp = System.Convert.ToInt32(tr);
                int rp = System.Convert.ToInt32((d100 - tr) * Math.Pow(10, digits));

                return System.Convert.ToString(Interaction.IIf(lp < 10, "0", "")) + System.Convert.ToString(lp) + "." + System.Convert.ToString(Interaction.IIf(rp < 10, "00", "")) + System.Convert.ToString(Interaction.IIf(rp < 100 & rp >= 10, "0", "")) + System.Convert.ToString(rp);
            }
            else
                return "";
        }

        // Convert a DMTF datetime to a valid Date
        public static DateTime DMTFDateToDateTime(string dmtfDate)
        {
            try
            {
                DateTime initializer = DateTime.MinValue;
                int year = initializer.Year;
                int month = initializer.Month;
                int day = initializer.Day;
                int hour = initializer.Hour;
                int minute = initializer.Minute;
                int second = initializer.Second;
                long ticks = 0;
                string dmtf = dmtfDate;
                DateTime datetime = DateTime.MinValue;
                string tempString = string.Empty;
                tempString = dmtf.Substring(0, 4);
                if (("****" != tempString))
                    year = int.Parse(tempString);
                tempString = dmtf.Substring(4, 2);
                if (("**" != tempString))
                    month = int.Parse(tempString);
                tempString = dmtf.Substring(6, 2);
                if (("**" != tempString))
                    day = int.Parse(tempString);
                tempString = dmtf.Substring(8, 2);
                if (("**" != tempString))
                    hour = int.Parse(tempString);
                tempString = dmtf.Substring(10, 2);
                if (("**" != tempString))
                    minute = int.Parse(tempString);
                tempString = dmtf.Substring(12, 2);
                if (("**" != tempString))
                    second = int.Parse(tempString);
                tempString = dmtf.Substring(15, 6);
                if (("******" != tempString))
                    ticks = (long.Parse(tempString) * System.Convert.ToInt64((System.TimeSpan.TicksPerMillisecond / (double)1000)));

                datetime = new DateTime(year, month, day, hour, minute, second, 0);
                datetime = datetime.AddTicks(ticks);
                System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime);
                int UTCOffset = 0;
                int OffsetToBeAdjusted = 0;
                long OffsetMins = System.Convert.ToInt64((tickOffset.Ticks / (double)System.TimeSpan.TicksPerMinute));
                tempString = dmtf.Substring(22, 3);
                if ((tempString != "******"))
                {
                    tempString = dmtf.Substring(21, 4);
                    UTCOffset = int.Parse(tempString);
                    OffsetToBeAdjusted = System.Convert.ToInt32((OffsetMins - UTCOffset));
                    datetime = datetime.AddMinutes(System.Convert.ToDouble(OffsetToBeAdjusted));
                }
                return datetime;
            }
            catch (Exception ex)
            {
                return new DateTime(0);
            }
        }

        public static string ReadUnicodeString(Native.Api.NativeStructs.UnicodeString str)
        {
            if (str.Length == 0)
                return null;
            try
            {
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(str.Buffer, str.Length / 2);
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        // Get a good path
        public static string GetRealPath(string path)
        {
            if (Strings.Len(path) > 0)
            {
                if (path.ToLowerInvariant().StartsWith(@"\systemroot\") || path.ToLowerInvariant().StartsWith(@"system32\"))
                {
                    path = path.Substring(12, path.Length - 12);
                    int ii = Strings.InStr(path, @"\", CompareMethod.Binary);
                    if (ii > 0)
                    {
                        path = path.Substring(ii, path.Length - ii);
                        path = Environment.SystemDirectory + @"\" + path;
                    }
                }
                else if (path.StartsWith(@"\??\"))
                    path = path.Substring(4);
                else if (path.StartsWith(char.ConvertFromUtf32(34)))
                {
                    if (path.Length > 2)
                        path = path.Substring(1, path.Length - 2);
                }
            }
            else
                path = Program.NO_INFO_RETRIEVED;
            return path;
        }

        // Get path from a command
        public static string GetPathFromCommand(string path)
        {
            if (System.IO.File.Exists(path))
                return path;
            else
                return cFile.IntelligentPathRetrieving2(path);
        }

        // Get a file name from a path
        public static string GetFileName(string _path)
        {
            int i = Strings.InStrRev(_path, @"\", Compare: CompareMethod.Binary);
            if (i > 0)
                return Strings.Right(_path, _path.Length - i);
            else
                return Constants.vbNullString;
        }

        // Permute bytes
        public static ushort PermuteBytes(int v)
        {
            byte b1 = System.Convert.ToByte(v);
            byte b2 = System.Convert.ToByte((v >> 8));

            return System.Convert.ToUInt16((b2 + (System.Convert.ToUInt16(b1) << 8)));
        }

        // Return a Uinteger from a IPEndPoint
        public static UInt32 GetAddressAsInteger(System.Net.IPEndPoint ip)
        {
            int i = 0;
            UInt32 addressInteger = 0;

            foreach (byte b in ip.Address.GetAddressBytes())
            {
                addressInteger += System.Convert.ToUInt32(System.Convert.ToInt32(b) << (8 * i));
                i += 1;
            }

            return addressInteger;
        }

        // Escape will close the form frm
        public static void CloseWithEchapKey(ref System.Windows.Forms.Form frm)
        {
            frm.KeyPreview = true;
            System.Windows.Forms.KeyEventHandler oo = new System.Windows.Forms.KeyEventHandler(handlerCloseForm_);
            frm.KeyDown += oo;
        }

        // Escape will hide the form frm
        public static void HideWithEchapKey(ref System.Windows.Forms.Form frm)
        {
            frm.KeyPreview = true;
            System.Windows.Forms.KeyEventHandler oo = new System.Windows.Forms.KeyEventHandler(handlerHideForm_);
            frm.KeyDown += oo;
        }

        // Copy content of a listview (selected items) into clipboard
        public static void CopyLvToClip(MouseEventArgs e, ListView lv)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                string s = Constants.vbNullString;
                ListViewItem it;
                int x = 0;
                foreach (var it in lv.SelectedItems)
                {
                    s += it.Text;
                    ListViewItem.ListViewSubItem it2;
                    foreach (var it2 in it.SubItems)
                        s += Constants.vbTab + Constants.vbTab + it2.Text;
                    x += 1;
                    if (!(x == lv.SelectedItems.Count))
                        s += Constants.vbNewLine;
                }
                if (string.IsNullOrEmpty(s) == false)
                    My.MyProject.Computer.Clipboard.SetText(s, TextDataFormat.Text);
            }
        }

        // Start (or not) with windows startup
        public static void StartWithWindows(bool value)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                if (value)
                    regKey.SetValue(Application.ProductName, Application.ExecutablePath);
                else
                    regKey.DeleteValue(Application.ProductName);
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        // Replace (or not) taskmgr
        public static void ReplaceTaskmgr(bool value)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);

                if (value)
                {
                    try
                    {
                        regKey.CreateSubKey("taskmgr.exe").SetValue("debugger", Application.ExecutablePath);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
                }
                else
                    try
                    {
                        if (regKey.OpenSubKey("taskmgr.exe", false) != null)
                            regKey.DeleteSubKey("taskmgr.exe");
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        // Set tool tips
        public static void SetToolTip(Control ctrl, string text)
        {
            ToolTip tToolTip = new System.Windows.Forms.ToolTip();
            {
                var withBlock = tToolTip;
                withBlock.SetToolTip(ctrl, text);
                withBlock.IsBalloon = false;
                withBlock.Active = true;
            }
        }

        // Custom input box
        public static string CInputBox(string text, string title, string defaultValue = null)
        {
            frmInput frm = new frmInput();
            {
                var withBlock = frm;
                withBlock.Text = title;
                withBlock.lblMessage.Text = text;
                withBlock.txtRes.Text = defaultValue;
                withBlock.TopMost = Program._frmMain.TopMost;
                withBlock.ShowDialog();
                return withBlock.Result;
            }
        }

        // Search on internet
        public static void SearchInternet(string item, IntPtr handle)
        {
            cFile.ShellOpenFile(My.MySettingsProperty.Settings.SearchEngine.Replace("ITEM", item), handle);
        }

        // Standard Vista message box
        public static int ShowVistaMessage(string Title = "", string HeaderMessage = "", string Content = "", TaskDialogCommonButtons Buttons = TaskDialogCommonButtons.Ok, TaskDialogIcon Icon = TaskDialogIcon.Information, int DefButton = 0)
        {
            if (cEnvironment.SupportsTaskDialog())
            {
                TaskDialog dlg = new TaskDialog();
                {
                    var withBlock = dlg;
                    withBlock.WindowTitle = Title;
                    withBlock.Content = Content;
                    withBlock.MainInstruction = HeaderMessage;
                    withBlock.MainIcon = Icon;
                    withBlock.CommonButtons = Buttons;
                    withBlock.DefaultButton = DefButton;
                }
                try
                {
                    return dlg.Show(Form.ActiveForm);
                }
                catch (Exception ex)
                {
                    // Failed !! Fu*k !!
                    Misc.ShowDebugError(ex);
                    // Display normal MessageBox
                    ShowMsg(Title, HeaderMessage, Content, MessageBoxButtons.YesNoCancel, Icon, System.Convert.ToBoolean(DefButton), true);
                }
            }
            else
                return -1;
        }

        // Get available IPV-4 IP
        public static string[] GetIpv4Ips()
        {
            string[] res;
            int x = -1;
            res = new string[x + 1];
            System.Net.IPAddress[] s = System.Net.Dns.GetHostAddresses(My.MyProject.Computer.Name);
            foreach (System.Net.IPAddress t in s)
            {
                if (t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    x += 1;
                    var oldRes = res;
                    res = new string[x + 1];
                    if (oldRes != null)
                        Array.Copy(oldRes, res, Math.Min(x + 1, oldRes.Length));
                    res[x] = t.ToString();
                }
            }
            return res;
        }

        // Return Assembly GUID
        // Could be used ??
        public static string GetAppGuid()
        {
            Guid assemblyGuid = default(Guid);
            object[] assemblyObjects = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true);
            if (assemblyObjects.Length > 0)
                assemblyGuid = new Guid(((System.Runtime.InteropServices.GuidAttribute)assemblyObjects[0]).Value);
            return assemblyGuid.ToString();
        }

        // Return informations about installed netword card interfaces
        public static List<Native.Api.Structs.NicDescription> GetNics()
        {
            List<Native.Api.Structs.NicDescription> ret = new List<Native.Api.Structs.NicDescription>();
            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (cEnvironment.IsWindowsVistaOrAbove)
                {
                    if (nic.GetIPProperties().UnicastAddresses.Count > 1)
                    {
                        if (nic.GetIPProperties().UnicastAddresses[1].Address.ToString() != "127.0.0.1")
                            ret.Add(new Native.Api.Structs.NicDescription(nic.Name, nic.Description, nic.GetIPProperties().UnicastAddresses[1].Address.ToString()));
                    }
                }
                else if (nic.GetIPProperties().UnicastAddresses.Count > 0)
                {
                    if (nic.GetIPProperties().UnicastAddresses[0].Address.ToString() != "127.0.0.1")
                        ret.Add(new Native.Api.Structs.NicDescription(nic.Name, nic.Description, nic.GetIPProperties().UnicastAddresses[0].Address.ToString()));
                }
            }
            return ret;
        }

        // Navigate to regedit
        public static void NavigateToRegedit(string key)
        {
            // Write the path of the key into the registry, so regedit
            // will use this value to show the key when it open
            RegistryKey regKey;
            string myComputerLocalized = null;
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit\", true);

            // Create key if it does not exists (happens when regedit has never been opened)
            if (regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit\", RegistryKeyPermissionCheck.ReadWriteSubTree);
                // Have to find a way to set "My Computer" to this key value ("My Computer" should be localized)
                regKey.SetValue("LastKey", "");
            }

            // Format key name
            if (key.ToLower().StartsWith(@"hklm\"))
                key = @"HKEY_LOCAL_MACHINE\" + key.Substring(5, key.Length - 5);
            if (key.ToLower().StartsWith(@"hku\"))
                key = @"HKEY_USERS\" + key.Substring(4, key.Length - 4);
            if (key.ToLower().StartsWith(@"hkcu\"))
                key = @"HKEY_CURRENT_USER\" + key.Substring(5, key.Length - 5);
            if (key.ToLower().StartsWith(@"hkcr\"))
                key = @"HKEY_CLASSES_ROOT\" + key.Substring(5, key.Length - 5);
            if (key.ToLower().StartsWith(@"hkcc\"))
                key = @"HKEY_CURRENT_CONFIG\" + key.Substring(5, key.Length - 5);
            if (key.ToLower().StartsWith(@"hkpd\"))
                key = @"HKEY_PERFORMANCE_DATA\" + key.Substring(5, key.Length - 5);

            if (regKey != null)
            {

                // Retrieve 'My Computer' translated into computer culture
                // We simply read current value of LastKey key
                myComputerLocalized = System.Convert.ToString(regKey.GetValue("LastKey"));

                int i = Strings.InStr(myComputerLocalized, @"\");
                if (i > 0)
                    myComputerLocalized = myComputerLocalized.Substring(0, i - 1);

                try
                {
                    regKey.SetValue("Lastkey", myComputerLocalized + @"\" + key);
                    regKey.Close();
                    Interaction.Shell("regedit.exe", AppWinStyle.NormalFocus);
                }
                catch (Exception ex)
                {
                    Misc.ShowDebugError(ex);
                }
            }
        }

        // Move a listview item (up or down)
        // Come from here : http://www.knowdotnet.com/articles/listviewmoveitem.html
        public static void MoveListViewItem(ListView lv, bool moveUp)
        {
            int i;
            string cache;
            System.Drawing.Color cacheColor;
            bool cacheSel;
            int selIdx;

            {
                var withBlock = lv;
                selIdx = withBlock.SelectedItems[0].Index;
                if (moveUp)
                {
                    // ignore moveup of row(0)
                    if (selIdx == 0)
                        return;
                    // move the subitems for the previous row
                    // to cache so we can move the selected row up
                    cacheSel = withBlock.Items[selIdx - 1].Checked;
                    cacheColor = withBlock.Items[selIdx - 1].BackColor;
                    var loopTo = withBlock.Items[selIdx].SubItems.Count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        cache = withBlock.Items[selIdx - 1].SubItems[i].Text;
                        withBlock.Items[selIdx - 1].SubItems[i].Text = withBlock.Items[selIdx].SubItems[i].Text;
                        withBlock.Items[selIdx].SubItems[i].Text = cache;
                    }
                    withBlock.Items[selIdx - 1].Checked = withBlock.Items[selIdx].Checked;
                    withBlock.Items[selIdx - 1].BackColor = withBlock.Items[selIdx].BackColor;
                    withBlock.Items[selIdx].Checked = cacheSel;
                    withBlock.Items[selIdx].BackColor = cacheColor;
                    withBlock.Items[selIdx - 1].Selected = true;
                    withBlock.Refresh();
                    withBlock.Focus();
                }
                else
                {
                    // ignore move down of last row
                    if (selIdx == withBlock.Items.Count - 1)
                        return;
                    // move the subitems for the next row
                    // to cache so we can move the selected row down
                    cacheSel = withBlock.Items[selIdx + 1].Checked;
                    cacheColor = withBlock.Items[selIdx + 1].BackColor;
                    var loopTo1 = withBlock.Items[selIdx].SubItems.Count - 1;
                    for (i = 0; i <= loopTo1; i++)
                    {
                        cache = withBlock.Items[selIdx + 1].SubItems[i].Text;
                        withBlock.Items[selIdx + 1].SubItems[i].Text = withBlock.Items[selIdx].SubItems[i].Text;
                        withBlock.Items[selIdx].SubItems[i].Text = cache;
                    }
                    withBlock.Items[selIdx + 1].Checked = withBlock.Items[selIdx].Checked;
                    withBlock.Items[selIdx + 1].BackColor = withBlock.Items[selIdx].BackColor;
                    withBlock.Items[selIdx].Checked = cacheSel;
                    withBlock.Items[selIdx].BackColor = cacheColor;
                    withBlock.Items[selIdx + 1].Selected = true;
                    withBlock.Refresh();
                    withBlock.Focus();
                }
            }
        }

        public static System.Drawing.Icon GetIcon(string fName, bool small = true)
        {
            int hImgSmall;
            int hImgLarge;
            Native.Api.NativeStructs.SHFileInfo shinfo;
            shinfo = new Native.Api.NativeStructs.SHFileInfo();

            if (System.IO.File.Exists(fName) == false)
                return null;

            if (small)
                hImgSmall = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, ref shinfo, Marshal.SizeOf(shinfo), Native.Api.NativeConstants.SHGFI_ICON | Native.Api.NativeConstants.SHGFI_SMALLICON);
            else
                hImgLarge = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, ref shinfo, Marshal.SizeOf(shinfo), Native.Api.NativeConstants.SHGFI_ICON | Native.Api.NativeConstants.SHGFI_LARGEICON);

            System.Drawing.Icon img = null;
            try
            {
                if (shinfo.hIcon.IsNotNull())
                    img = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            }
            catch (Exception ex)
            {
            }

            return img;
        }

        public static System.Drawing.Icon GetIcon2(string fName, bool small = true)
        {
            int hImgSmall;
            int hImgLarge;
            Native.Api.NativeStructs.SHFileInfo shinfo;
            shinfo = new Native.Api.NativeStructs.SHFileInfo();

            if (small)
                hImgSmall = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, ref shinfo, Marshal.SizeOf(shinfo), Native.Api.NativeConstants.SHGFI_ICON | Native.Api.NativeConstants.SHGFI_SMALLICON);
            else
                hImgLarge = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, ref shinfo, Marshal.SizeOf(shinfo), Native.Api.NativeConstants.SHGFI_ICON | Native.Api.NativeConstants.SHGFI_LARGEICON);

            System.Drawing.Icon img = null;
            try
            {
                if (shinfo.hIcon.IsNotNull())
                    img = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            }
            catch (Exception ex)
            {
            }

            return img;
        }

        // Get security risk from internet
        public static SecurityRisk GetSecurityRisk(string process)
        {
            int ret = 0;

            // Download source page of
            // http://www.processlibrary.com/directory/files/PROCESSS/
            // and retrieve security risk from source :
            // <h4 class="red-heading">Security risk (0-5):</h4><p>0</p>

            string s;
            s = DownloadPage("http://www.processlibrary.com/directory/files/" + Strings.LCase(process) + "/");

            int i = Strings.InStr(s, "Security risk (0-5)", CompareMethod.Binary);

            if (i > 0)
            {
                string z = s.Substring(i + 27, 1);
                ret = System.Convert.ToInt32(Conversion.Val(z));
            }
            else
                ret = -1;

            return (SecurityRisk)ret;
        }

        // Get security rick and description from internet
        public static InternetProcessInfo GetInternetInfos(string process)
        {
            InternetProcessInfo ret = default(InternetProcessInfo);

            // Download source page of
            // http://www.processlibrary.com/directory/files/PROCESSS/
            // and retrieve security risk from source :
            // <h4 class="red-heading">Security risk (0-5):</h4><p>0</p>

            string s;
            s = DownloadPage("http://www.processlibrary.com/directory/files/" + Strings.LCase(process) + "/");

            int i = Strings.InStr(s, "Security risk (0-5)", CompareMethod.Binary);
            int d1 = Strings.InStr(s, ">Description</h4>", CompareMethod.Binary);
            int d2 = Strings.InStr(d1 + 1, s, "</p>", CompareMethod.Binary);

            if (i > 0)
            {
                string z = s.Substring(i + 27, 1);
                ret._Risk = (SecurityRisk)System.Convert.ToInt32(Conversion.Val(z));
                if (d1 > 0 & d2 > 0)
                {
                    string z2 = s.Substring(d1 + 23, d2 - d1 - 24);
                    ret._Description = Strings.Replace(z2, "<BR><BR>", Constants.vbNewLine);
                }
                else
                    ret._Description = Program.NO_INFO_RETRIEVED;
            }
            else
                ret._Risk = SecurityRisk.Unknow;

            return ret;
        }

        // Download web page
        public static string DownloadPage(string sURL)
        {
            try
            {
                System.Net.WebRequest objWebRequest = System.Net.HttpWebRequest.Create(sURL);
                System.Net.WebResponse objWebResponse = objWebRequest.GetResponse();
                System.IO.StreamReader objStreamReader = null;
                string ret = Constants.vbNullString;

                try
                {
                    objStreamReader = new System.IO.StreamReader(objWebResponse.GetResponseStream());
                    ret = objStreamReader.ReadToEnd();
                }
                finally
                {
                    if (!(objWebResponse == null))
                        objWebResponse.Close();
                }

                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Display details of a file
        public static void DisplayDetailsFile(string file)
        {
            Program._frmMain.txtFile.Text = file;
            Program._frmMain.refreshFileInfos(file);
            Program._frmMain.Ribbon.ActiveTab = Program._frmMain.FileTab;
            Program._frmMain.Ribbon_MouseMove(null, null);
        }

        // Return the column header which have DisplayIndex == nDispIndex
        public static ColumnHeader GetColumnHeaderByDisplayIndex(ref customLV lv, int nDispIndex)
        {
            for (int i = lv.Columns.Count - 1; i >= 0; i += -1)
            {
                if (lv.Columns[i].DisplayIndex == nDispIndex)
                    return lv.Columns[i];
            }
            return null;
        }

        // Parse port text files
        public static bool ParsePortTextFiles(string tcpFile, string udpFile, ref Dictionary<int, string> dicoTcp, ref Dictionary<int, string> dicoUdp)
        {
            try
            {
                string[] sTcp = My.Resources.Resources.tcp.Split(System.Convert.ToChar(Constants.vbNewLine));
                string[] sUdp = My.Resources.Resources.udp.Split(System.Convert.ToChar(Constants.vbNewLine));

                // TCP
                foreach (string s in sTcp)
                {
                    int p = s.IndexOf(Constants.vbTab);
                    string ports = s.Substring(0, p);
                    string desc = s.Substring(p + 1, s.Length - p - 1);

                    int i = ports.IndexOf("-");
                    if (i > 0)
                    {
                        // Then these are multiple ports
                        int s1 = int.Parse(ports.Substring(0, i));
                        int s2 = int.Parse(ports.Substring(i + 1, ports.Length - i - 1));
                        var loopTo = s2;
                        for (int u = s1; u <= loopTo; u++)
                        {
                            if (dicoTcp.ContainsKey(u) == false)
                                dicoTcp.Add(u, desc);
                            else
                                dicoTcp[u] = dicoTcp[u] + " OR " + desc;
                        }
                    }
                    else
                    {
                        int port = int.Parse(ports);
                        if (dicoTcp.ContainsKey(port) == false)
                            dicoTcp.Add(port, desc);
                        else
                            dicoTcp[port] = dicoTcp[port] + " OR " + desc;
                    }
                }


                // UDP

                foreach (string s in sUdp)
                {
                    int p = s.IndexOf(Constants.vbTab);
                    string ports = s.Substring(0, p);
                    string desc = s.Substring(p + 1, s.Length - p - 1);

                    int i = ports.IndexOf("-");
                    if (i > 0)
                    {
                        // Then these are multiple ports
                        int s1 = int.Parse(ports.Substring(0, i));
                        int s2 = int.Parse(ports.Substring(i + 1, ports.Length - i - 1));
                        var loopTo1 = s2;
                        for (int u = s1; u <= loopTo1; u++)
                        {
                            if (dicoUdp.ContainsKey(u) == false)
                                dicoUdp.Add(u, desc);
                            else
                                dicoUdp[u] = dicoUdp[u] + " OR " + desc;
                        }
                    }
                    else
                    {
                        int port = int.Parse(ports);
                        if (dicoUdp.ContainsKey(port) == false)
                            dicoUdp.Add(port, desc);
                        else
                            dicoUdp[port] = dicoUdp[port] + " OR " + desc;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Return a well formated path
        public static string GetWellFormatedPath(string path)
        {
            try
            {
                if (path != null)
                {
                    if (path.ToUpperInvariant().StartsWith(@"\SYSTEMROOT\"))
                    {
                        path = path.Substring(12, path.Length - 12);
                        int ii = Strings.InStr(path, @"\", CompareMethod.Binary);
                        if (ii > 0)
                        {
                            path = path.Substring(ii, path.Length - ii);
                            path = Environment.SystemDirectory + @"\" + path;
                        }
                    }
                    else if (path.StartsWith(@"\??\"))
                        path = path.Substring(4);
                }
                return path;
            }
            catch (Exception ex)
            {
                return path;
            }
        }

        // Return dos drive name
        public static string DeviceDriveNameToDosDriveName(string path)
        {
            if (path != null)
            {
                string res = null;
                bool found = false;

                _semProtectDicoLogDrives.WaitOne();
                foreach (System.Collections.Generic.KeyValuePair<string, string> pair in _DicoLogicalDrivesNames)
                {
                    if (path.StartsWith(pair.Key))
                    {
                        res = pair.Value + path.Substring(pair.Key.Length);
                        found = true;
                        break;
                    }
                }
                _semProtectDicoLogDrives.Release();

                if (found)
                    return res;
                else
                    return path;
            }
            else
                return null;
        }

        // Refresh the dictionnary of logical drives
        public static void RefreshLogicalDrives()
        {
            Dictionary<string, string> _tempDico = new Dictionary<string, string>();

            // From 'A' to 'Z'
            // It also possible to use GetLogicalDriveStringsA
            for (byte c = 65; c <= 90; c++)
            {
                System.Text.StringBuilder _badPath = new System.Text.StringBuilder(1024);

                if (Native.Api.NativeFunctions.QueryDosDevice(char.ConvertFromUtf32(c) + ":", _badPath, 1024) != 0)
                    _tempDico.Add(_badPath.ToString(), char.ConvertFromUtf32(c).ToString() + ":");
            }

            _semProtectDicoLogDrives.WaitOne();
            _DicoLogicalDrivesNames = _tempDico;
            _semProtectDicoLogDrives.Release();
        }

        // Return a priority as an int from a string (System.Diagnostics.ProcessPriorityClass)
        public static System.Diagnostics.ProcessPriorityClass GetPriorityFromString(string p)
        {
            return (System.Diagnostics.ProcessPriorityClass)Enum.Parse(typeof(System.Diagnostics.ProcessPriorityClass), p);
        }

        // Return byte array from securestring
        public static char[] SecureStringToCharArray(ref System.Security.SecureString str)
        {
            char[] bytes = new char[str.Length - 1 + 1];
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(str);
                bytes = new char[str.Length - 1 + 1];
                Marshal.Copy(ptr, bytes, 0, str.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return bytes;
        }

        // Return True if a byte array is null or filled with empty values
        public static bool IsByteArrayNullOrEmpty(ref byte[] bArray)
        {
            if (bArray == null)
                return true;
            else
            {
                foreach (byte b in bArray)
                {
                    if (b != 0)
                        return false;
                }
                return true;
            }
        }

        // General ShowMessage function
        public static DialogResult ShowMsg(string Title, string HeaderText = "", string Text = "", MessageBoxButtons Buttons = MessageBoxButtons.OK, TaskDialogIcon Icon = TaskDialogIcon.Information, bool DefButtonIsNoButton = false, bool forceClassical = false)
        {

            // No messageboxes if server mode !
            if (Program.Parameters != null && Program.Parameters.ModeServer)
                return DialogResult.None;

            if (false)
            {
                // Show special task dialog
                TaskDialogCommonButtons but;  // Cancel Close No None Ok Retry Yes
                switch (Buttons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        {
                            but = TaskDialogCommonButtons.Close | TaskDialogCommonButtons.Cancel | TaskDialogCommonButtons.Retry;
                            break;
                        }

                    case MessageBoxButtons.OK:
                        {
                            but = TaskDialogCommonButtons.Ok;
                            break;
                        }

                    case MessageBoxButtons.OKCancel:
                        {
                            but = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
                            break;
                        }

                    case MessageBoxButtons.RetryCancel:
                        {
                            but = TaskDialogCommonButtons.Retry | TaskDialogCommonButtons.Cancel;
                            break;
                        }

                    case MessageBoxButtons.YesNo:
                        {
                            but = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
                            break;
                        }

                    case MessageBoxButtons.YesNoCancel:
                        {
                            but = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No | TaskDialogCommonButtons.Cancel;
                            break;
                        }

                    default:
                        {
                            but = TaskDialogCommonButtons.Ok;
                            break;
                        }
                }

                int defButton = 0;
                if (DefButtonIsNoButton)
                    defButton = DialogResult.No;

                return (DialogResult)ShowVistaMessage(Title, HeaderText, Text, but, Icon, defButton);
            }
            else
            {
                // Standard message box
                MessageBoxIcon ico;
                switch (Icon)
                {
                    case TaskDialogIcon.Error:
                    case TaskDialogIcon.ShieldError:
                        {
                            ico = MessageBoxIcon.Error;
                            break;
                        }

                    case TaskDialogIcon.None:
                        {
                            ico = MessageBoxIcon.None;
                            break;
                        }

                    case TaskDialogIcon.Shield:
                    case TaskDialogIcon.ShieldGradient:
                    case TaskDialogIcon.ShieldGray:
                        {
                            ico = MessageBoxIcon.Exclamation;
                            break;
                        }

                    case TaskDialogIcon.Warning:
                    case TaskDialogIcon.ShieldWarning:
                        {
                            ico = MessageBoxIcon.Warning;
                            break;
                        }

                    default:
                        {
                            ico = MessageBoxIcon.Information;
                            break;
                        }
                }

                string message = "";
                if (HeaderText == null)
                    message = Text;
                else
                {
                    message = HeaderText;
                    if (Text != null)
                        message += Constants.vbNewLine + Text;
                }

                MessageBoxDefaultButton defButton = MessageBoxDefaultButton.Button1;
                if (DefButtonIsNoButton)
                    defButton = MessageBoxDefaultButton.Button2;

                return MessageBox.Show(message, Title, Buttons, ico, defButton);
            }
        }

        // Dangerous action message
        public static DialogResult WarnDangerousAction(string text, IntPtr Owner)
        {
            if (My.MySettingsProperty.Settings.WarnDangerousActions)
                return ShowMsg("Warning", "This is a dangerous action.", text, MessageBoxButtons.YesNo, TaskDialogIcon.Warning, true);
            else
                return DialogResult.Yes;
        }

        // Show an error message
        public static void ShowError(Exception ex, string msg, bool forceClassical = false)
        {
            cError t0 = new cError(msg, ex);
            t0.ShowMessage(forceClassical);
        }
        public static void ShowError(string msg, bool forceClassical = false)
        {
            cError t0 = new cError(msg);
            t0.ShowMessage(forceClassical);
        }

        // Show an error message as a debug message (now messagebox)
        public static void ShowDebugError(Exception ex)
        {
            Debug.WriteLine("================================================================");
            Debug.WriteLine("GOT AN ERROR");
            Debug.WriteLine("       Source : " + ex.Source);
            Debug.WriteLine("       Message : " + ex.Message);
            Debug.WriteLine("       Trace : " + ex.StackTrace);
            Debug.WriteLine("================================================================");
        }



        // ========================================
        // Private functions
        // ========================================

        private static void handlerCloseForm_(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                try
                {
                    System.Windows.Forms.Form _tmp = (System.Windows.Forms.Form)sender;
                    _tmp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    _tmp.Close();
                }
                catch (Exception ex)
                {
                    Misc.ShowDebugError(ex);
                }
                e.Handled = true;
            }
        }

        private static void handlerHideForm_(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                try
                {
                    System.Windows.Forms.Form _tmp = (System.Windows.Forms.Form)sender;
                    _tmp.Hide();
                }
                catch (Exception ex)
                {
                    Misc.ShowDebugError(ex);
                }
                e.Handled = true;
            }
        }
    }
}

