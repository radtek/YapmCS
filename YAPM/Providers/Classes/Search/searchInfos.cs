using System;

[Serializable()]
public class searchInfos : generalInfos
{
    private Native.Api.Enums.GeneralObjectType _typeOfItem;
    private string _field;
    private string _res;
    private string _owner;
    private int _pid;


    public searchInfos(cGeneralObject Item, string field, string result)
    {
        _res = result;
        _field = field;
        _typeOfItem = Item.TypeOfObject;
        _pid = GetProcessId(Item);
        _owner = GetOwner(Item, _pid);
    }



    public string Field
    {
        get
        {
            return _field;
        }
    }
    public string Result
    {
        get
        {
            return _res;
        }
    }
    public Native.Api.Enums.GeneralObjectType Type
    {
        get
        {
            return _typeOfItem;
        }
    }
    public string Owner
    {
        get
        {
            return _owner;
        }
    }
    public int OwnedProcessId
    {
        get
        {
            return _pid;
        }
    }


    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[4];

        s[0] = "Type";
        s[1] = "Result";
        s[2] = "Field";
        s[3] = "Owner";

        if (sorted)
            Array.Sort(s);

        return s;
    }


    // Return owner of item
    // !!!! Process.CurrentProcesses MUST be protected by the caller
    private static string GetOwner(cGeneralObject obj, int pid)
    {
        // Just say a big thanks to polymorphism...
        try
        {
            string res = "";
            int _pid = pid;

            if (obj.TypeOfObject != Native.Api.Enums.GeneralObjectType.Service)
            {
                // Try to get the owner process
                if (Native.Objects.Process.CurrentProcesses.ContainsKey(_pid.ToString()))
                {
                    string nn = Native.Objects.Process.CurrentProcesses[_pid.ToString()].Infos.Name;
                    if (string.IsNullOrEmpty(nn) == false)
                        res = "Process " + nn + " (" + _pid.ToString() + ")";
                    else
                        res = "Process " + _pid.ToString();
                }
                else
                    res = "Process " + _pid.ToString();
            }
            else
                res = ((cService)obj).Infos.Name;

            return res;
        }
        catch (Exception ex)
        {
            return "Unknown";
        }
    }

    // Return associated process ID
    private static int GetProcessId(cGeneralObject obj)
    {
        switch (obj.TypeOfObject)
        {
            case Native.Api.Enums.GeneralObjectType.EnvironmentVariable:
                {
                    return ((cEnvVariable)obj).Infos.ProcessId;
                }

            case Native.Api.Enums.GeneralObjectType.Handle:
                {
                    return ((cHandle)obj).Infos.ProcessId;
                }

            case Native.Api.Enums.GeneralObjectType.Module:
                {
                    return ((cModule)obj).Infos.ProcessId;
                }

            case Native.Api.Enums.GeneralObjectType.Process:
                {
                    return ((cProcess)obj).Infos.ProcessId;
                }

            case Native.Api.Enums.GeneralObjectType.Service:
                {
                    return (((cService)obj).Infos.ProcessId);
                }

            case Native.Api.Enums.GeneralObjectType.Window:
                {
                    return ((cWindow)obj).Infos.ProcessId;
                }
        }
    }
}

