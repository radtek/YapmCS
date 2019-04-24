using Microsoft.VisualBasic;

public class cAsyncProcInfoDownload
{
    public event GotInformationsEventHandler GotInformations;

    public delegate void GotInformationsEventHandler(ref InternetProcessInfo result);

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

    private string _procName;
    private const string NO_INFO_RETRIEVED = @"N\A";

    public string ProcessName
    {
        get
        {
            return _procName;
        }
        set
        {
            _procName = value;
        }
    }

    public cAsyncProcInfoDownload(string aProcessName)
    {
        _procName = aProcessName;
    }

    // Start the download of informations
    public void BeginDownload()
    {
        InternetProcessInfo ret = default(InternetProcessInfo);

        // Download source page of
        // http://www.processlibrary.com/directory/files/PROCESSS/
        // and retrieve security risk from source :
        // <h4 class="red-heading">Security risk (0-5):</h4><p>0</p>

        string s;
        s = Common.Misc.DownloadPage("http://www.processlibrary.com/directory/files/" + Strings.LCase(_procName) + "/");

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
                ret._Description = NO_INFO_RETRIEVED;
        }
        else
            ret._Risk = SecurityRisk.Unknow;

        GotInformations?.Invoke(ref ret);
    }
}

