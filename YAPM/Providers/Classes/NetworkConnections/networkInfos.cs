using System;
using System.Net;

[Serializable()]
public class networkInfos : generalInfos
{
    public static bool operator ==(networkInfos m1, networkInfos m2)
    {
        return (m1.ProcessId == m2.ProcessId && m2.State == m1.State && m2.Protocol == m1.Protocol && ((m1.Local == null && m2.Local == null)
|| (m1.Local != null && m2.Local != null && m2.Local.Equals(m1.Local))) && ((m1.Remote == null && m2.Remote == null) || (m1.Remote != null && m2.Remote != null && m2.Remote.Equals(m1.Remote))));
    }
    public static bool operator !=(networkInfos m1, networkInfos m2)
    {
        return !(m1 == m2);
    }



    private int _pid;
    private Native.Api.Enums.NetworkProtocol _Protocol;
    internal IPEndPoint _Local;
    internal IPEndPoint _remote;
    private string _key;
    private Native.Api.Enums.MibTcpState _State;
    private string _procName;
    private string _localString;
    private string _remoteString;



    public int ProcessId
    {
        get
        {
            return _pid;
        }
    }
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
    public Native.Api.Enums.NetworkProtocol Protocol
    {
        get
        {
            return _Protocol;
        }
    }
    public Native.Api.Enums.MibTcpState State
    {
        get
        {
            return _State;
        }
    }
    public IPEndPoint Local
    {
        get
        {
            return _Local;
        }
    }
    public string Key
    {
        get
        {
            return _key;
        }
    }
    public IPEndPoint Remote
    {
        get
        {
            return _remote;
        }
    }
    public string RemoteString
    {
        get
        {
            return _remoteString;
        }
        set
        {
            _remoteString = value;
        }
    }
    public string LocalString
    {
        get
        {
            return _localString;
        }
        set
        {
            _localString = value;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public networkInfos()
    {
    }
    public networkInfos(ref Native.Api.Structs.LightConnection lc)
    {
        _pid = lc.dwOwningPid;
        _Protocol = lc.dwType;
        _State = (Native.Api.Enums.MibTcpState)lc.dwState;
        _Local = lc.local;
        _remote = lc.remote;
        _procName = cProcess.GetProcessName(_pid);
    }

    // Merge an old and a new instance
    public void Merge(ref networkInfos newI)
    {
        {
            var withBlock = newI;
            _State = withBlock.State;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[7];

        s[0] = "Remote";
        s[1] = "Protocol";
        s[2] = "ProcessId";
        s[3] = "Process";
        s[4] = "State";
        s[5] = "LocalPortDescription";
        s[6] = "RemotePortDescription";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Local";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

