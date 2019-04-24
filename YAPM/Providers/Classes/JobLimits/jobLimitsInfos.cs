using System;

[Serializable()]
public class jobLimitInfos : generalInfos
{
    private string _name;
    private string _desc;
    private string _value;
    private object _valueObj;



    public string Name
    {
        get
        {
            return _name;
        }
    }
    public string Value
    {
        get
        {
            return _value;
        }
    }
    public object ValueObject
    {
        get
        {
            return _valueObj;
        }
    }
    public string Description
    {
        get
        {
            return _desc;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public jobLimitInfos()
    {
    }
    public jobLimitInfos(string name, string desc, string value, object valObj)
    {
        _name = name;
        _desc = desc;
        _value = value;
        _valueObj = valObj;
    }

    // Merge an old and a new instance
    public void Merge(ref jobLimitInfos newI)
    {
        {
            var withBlock = newI;
            _value = withBlock.Value;
            _valueObj = withBlock.ValueObject;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[2];

        s[0] = "Value";
        s[1] = "Description";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Limit";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

