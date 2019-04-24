using System;

[Serializable()]
public class memRegionInfos : generalInfos
{
    public static bool operator !=(memRegionInfos m1, memRegionInfos m2)
    {
        return !(m1 == m2);
    }
    public static bool operator ==(memRegionInfos m1, memRegionInfos m2)
    {
        return (m1.BaseAddress == m2.BaseAddress && m1.RegionSize == m2.RegionSize && m1.State == m2.State && m1.Name == m2.Name && m1.Type == m2.Type && m1.Protection == m2.Protection && m1.ProcessId == m2.ProcessId);
    }



    private int _procId;
    private Native.Api.NativeEnums.MemoryState _state;
    private IntPtr _size;
    private IntPtr _address;
    private Native.Api.NativeEnums.MemoryProtectionType _protection;
    private Native.Api.NativeEnums.MemoryType _type;



    public int ProcessId
    {
        get
        {
            return _procId;
        }
    }
    public IntPtr RegionSize
    {
        get
        {
            return _size;
        }
    }
    public Native.Api.NativeEnums.MemoryState State
    {
        get
        {
            return _state;
        }
    }
    public IntPtr BaseAddress
    {
        get
        {
            return _address;
        }
    }
    public Native.Api.NativeEnums.MemoryProtectionType Protection
    {
        get
        {
            return _protection;
        }
    }
    public Native.Api.NativeEnums.MemoryType Type
    {
        get
        {
            return _type;
        }
    }
    public string Name
    {
        get
        {
            return getName();
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public memRegionInfos()
    {
    }
    public memRegionInfos(ref Native.Api.NativeStructs.MemoryBasicInformation mbi, int pid)
    {
        _procId = pid;
        {
            var withBlock = mbi;
            _state = withBlock.State;
            _size = withBlock.RegionSize;
            _address = withBlock.BaseAddress;
            _protection = withBlock.AllocationProtect;
            _type = withBlock.Type;
        }
    }

    // Merge an old and a new instance
    public void Merge(ref memRegionInfos newI)
    {
        {
            var withBlock = newI;
            _protection = withBlock.Protection;
            _size = withBlock.RegionSize;
            _state = withBlock.State;
            _type = withBlock.Type;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[6];

        s[0] = "Type";
        s[1] = "Protection";
        s[2] = "State";
        s[3] = "Address";
        s[4] = "Size";
        s[5] = "File";

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

    private string getName()
    {
        if (_state == Native.Api.NativeEnums.MemoryState.Free)
            return _state.ToString();
        else if (_type == Native.Api.NativeEnums.MemoryType.Image)
            return _type.ToString();
        else
            return _type.ToString() + " (" + _state.ToString() + ")";
    }
}

