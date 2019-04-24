using System;

[Serializable()]
public class heapInfos : generalInfos
{
    private IntPtr _baseAddress;
    private int _blockCount;
    private int _flags;
    private int _granularity;
    private IntPtr _memAllocated;
    private IntPtr _memCommitted;
    private int _tagCount;
    private IntPtr _tags;



    public IntPtr BaseAddress
    {
        get
        {
            return _baseAddress;
        }
    }
    public int BlockCount
    {
        get
        {
            return _blockCount;
        }
    }
    public int Flags
    {
        get
        {
            return _flags;
        }
    }
    public int Granularity
    {
        get
        {
            return _granularity;
        }
    }
    public IntPtr MemAllocated
    {
        get
        {
            return _memAllocated;
        }
    }
    public IntPtr MemCommitted
    {
        get
        {
            return _memCommitted;
        }
    }
    public int TagCount
    {
        get
        {
            return _tagCount;
        }
    }
    public IntPtr Tags
    {
        get
        {
            return _tags;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public heapInfos()
    {
    }
    public heapInfos(ref Native.Api.NativeStructs.HeapInformation data)
    {
        {
            var withBlock = data;
            _baseAddress = withBlock.BaseAddress;
            _blockCount = withBlock.BlockCount;
            _flags = withBlock.Flags;
            _granularity = withBlock.Granularity;
            _memAllocated = withBlock.MemAllocated;
            _memCommitted = withBlock.MemCommitted;
            _tagCount = withBlock.TagCount;
            _tags = withBlock.Tags;
        }
    }
    public heapInfos(ref Native.Api.NativeStructs.HeapList32 data)
    {
        {
            var withBlock = data;
            _baseAddress = withBlock.HeapID;
            // _blockCount = ?
            _flags = withBlock.Flags;
        }
    }

    // Merge an old and a new instance
    public void Merge(ref heapInfos newI)
    {
        {
            var withBlock = newI;
            _blockCount = withBlock.BlockCount;
            _flags = withBlock.Flags;
            _granularity = withBlock.Granularity;
            _memAllocated = withBlock.MemAllocated;
            _memCommitted = withBlock.MemCommitted;
            _tagCount = withBlock.TagCount;
            _tags = withBlock.Tags;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[7];

        s[0] = "MemCommitted";
        s[1] = "MemAllocated";
        s[2] = "BlockCount";
        s[3] = "Flags";
        s[4] = "Granularity";
        s[5] = "TagCount";
        s[6] = "Tags";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Address";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

