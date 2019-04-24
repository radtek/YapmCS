using System;

[Serializable()]
public class envVariableInfos : generalInfos
{
    private int _procId;
    private string _variable;
    private string _value;



    public int ProcessId
    {
        get
        {
            return _procId;
        }
    }
    public string Variable
    {
        get
        {
            return _variable;
        }
    }
    public string Value
    {
        get
        {
            return _value;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public envVariableInfos(ref string variable, string value, int pid)
    {
        _procId = pid;
        _variable = variable;
        _value = value;
    }

    // Merge an old and a new instance
    public void Merge(ref envVariableInfos newI)
    {
        _value = newI.Value;
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[1];

        s[0] = "Value";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Variable";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

