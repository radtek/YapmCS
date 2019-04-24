using System;

[Serializable()]
public class taskInfos : windowInfos
{


    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public taskInfos()
    {
    }
    public taskInfos(ref windowInfos window) : base(ref window)
    {
    }

    // Retrieve all information's names availables
    public new static string[] GetAvailableProperties(bool includeFirstProp = false)
    {
        string[] s = new string[12];

        s[0] = "Caption";
        s[1] = "Process";
        s[2] = "CpuUsage";
        s[3] = "IsTask";
        s[4] = "Enabled";
        s[5] = "Visible";
        s[6] = "ThreadId";
        s[7] = "Height";
        s[8] = "Width";
        s[9] = "Top";
        s[10] = "Left";
        s[11] = "Opacity";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Name";
            s = s2;
        }

        return s;
    }
}

