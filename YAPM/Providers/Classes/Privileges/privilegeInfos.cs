using System;

[Serializable()]
public class privilegeInfos : generalInfos
{
    private int _procId;
    private Native.Api.NativeEnums.SePrivilegeAttributes _status;
    private string _description;
    private string _name;



    public int ProcessId
    {
        get
        {
            return _procId;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }
    public string Description
    {
        get
        {
            return _description;
        }
    }
    public Native.Api.NativeEnums.SePrivilegeAttributes Status
    {
        get
        {
            return _status;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public privilegeInfos()
    {
    }
    public privilegeInfos(ref string name, int pid, Native.Api.NativeEnums.SePrivilegeAttributes status)
    {
        _procId = pid;
        _name = name;
        _status = status;
        _description = Native.Objects.Token.GetPrivilegeDescriptionByName(name);
    }

    // Merge an old and a new instance
    public void Merge(ref privilegeInfos newI)
    {
        {
            var withBlock = newI;
            _status = newI.Status;
            _description = newI.Description;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[2];

        s[0] = "Status";
        s[1] = "Description";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Name";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

