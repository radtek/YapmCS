using System.Diagnostics;
using Microsoft.VisualBasic;
using Common;
using System;

[Serializable()]
public class moduleInfos : generalInfos
{
    private string _name;
    private string _path;
    private IntPtr _address;
    private int _size;
    private IntPtr _entryPoint;
    private ushort _loadCount;
    private int _processId;
    private Native.Api.NativeEnums.LdrpDataTableEntryFlags _flags;
    private SerializableFileVersionInfo _fileInfo;

    private string _manufacturer;
    private string _version;



    public Native.Api.NativeEnums.LdrpDataTableEntryFlags Flags
    {
        get
        {
            return _flags;
        }
    }
    public int ProcessId
    {
        get
        {
            return _processId;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }
    public string Path
    {
        get
        {
            return _path;
        }
    }
    public IntPtr BaseAddress
    {
        get
        {
            return _address;
        }
    }
    public IntPtr EntryPoint
    {
        get
        {
            return _entryPoint;
        }
    }
    public int Size
    {
        get
        {
            return _size;
        }
    }
    public ushort LoadCount
    {
        get
        {
            return _loadCount;
        }
    }
    public SerializableFileVersionInfo FileInfo
    {
        get
        {
            return _fileInfo;
        }
    }
    public string Manufacturer
    {
        get
        {
            return _manufacturer;
        }
    }
    public string Version
    {
        get
        {
            return _version;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public moduleInfos()
    {
    }
    public moduleInfos(ref Native.Api.NativeStructs.LdrDataTableEntry data, int pid, string path, string dllName, bool noFileInfo = false)
    {
        {
            var withBlock = data;
            _size = withBlock.SizeOfImage;
            _entryPoint = withBlock.EntryPoint;
            _address = withBlock.DllBase;
            _flags = withBlock.Flags;
            _loadCount = withBlock.LoadCount;
        }
        _processId = pid;

        if (path.ToLowerInvariant().StartsWith(@"\systemroot\"))
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
        _path = path;
        _name = dllName;

        if (noFileInfo == false)
        {
            // Retrieve infos about file
            // Retrive infos ONLY ONE time (save path and infos into a dico)
            // As this constructor is only used for local connection, there is
            // nothing to check concerning connection
            asyncCallbackModuleEnumerate.semDicoFileInfos.WaitOne();
            if (asyncCallbackModuleEnumerate.fileInformations.ContainsKey(_path) == false)
            {
                try
                {
                    _fileInfo = new SerializableFileVersionInfo(FileVersionInfo.GetVersionInfo(path));
                }
                catch (Exception ex)
                {
                    _fileInfo = null;
                }
                asyncCallbackModuleEnumerate.fileInformations.Add(_path, _fileInfo);
            }
            else
                _fileInfo = asyncCallbackModuleEnumerate.fileInformations[_path];
            asyncCallbackModuleEnumerate.semDicoFileInfos.Release();
        }
        else
            _fileInfo = null;
    }

    public moduleInfos(ref Native.Api.NativeStructs.RtlProcessModuleInformation data, int pid, bool noFileInfo = false)
    {
        {
            var withBlock = data;
            _size = withBlock.ImageSize;
            _address = withBlock.ImageBase;
            _loadCount = withBlock.LoadCount;
            // .FullPathName()
            // .InitOrderIndex()
            // .LoadOrderIndex()
            // .MappedBase()
            // .OffsetToFileName()
            _flags = withBlock.Flags;
        }
        _processId = pid;

        // Get index of first null char (to truncate char array)
        int nullCharIndex = Array.IndexOf(data.FullPathName, default(char));
        string path;
        if (nullCharIndex > 0)
            path = new string(data.FullPathName, 0, nullCharIndex);
        else
            path = new string(data.FullPathName);// length is 256
        string dllName = Misc.GetFileName(path);

        if (path.ToLowerInvariant().StartsWith(@"\systemroot\"))
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
        _path = path;
        _name = dllName;

        if (noFileInfo == false)
        {
            // Retrieve infos about file
            // Retrive infos ONLY ONE time (save path and infos into a dico)
            // As this constructor is only used for local connection, there is
            // nothing to check concerning connection
            asyncCallbackModuleEnumerate.semDicoFileInfos.WaitOne();
            if (asyncCallbackModuleEnumerate.fileInformations.ContainsKey(_path) == false)
            {
                try
                {
                    _fileInfo = new SerializableFileVersionInfo(FileVersionInfo.GetVersionInfo(path));
                }
                catch (Exception ex)
                {
                    _fileInfo = null;
                }
                asyncCallbackModuleEnumerate.fileInformations.Add(_path, _fileInfo);
            }
            else
                _fileInfo = asyncCallbackModuleEnumerate.fileInformations[_path];
            asyncCallbackModuleEnumerate.semDicoFileInfos.Release();
        }
        else
            _fileInfo = null;
    }

    public moduleInfos(ref Native.Api.NativeStructs.LdrDataTableEntry Thr, int pid, string path, string version, string manufacturer)
    {
        // This constructor is used for WMI
        {
            var withBlock = Thr;
            _size = withBlock.SizeOfImage;
            _entryPoint = withBlock.EntryPoint;
            _address = withBlock.DllBase;
        }
        _processId = pid;

        _path = Common.Misc.GetRealPath(path);
        _name = cFile.GetFileName(_path);
        _manufacturer = manufacturer;
        _version = version;
    }

    // Merge an old and a new instance
    public void Merge(ref moduleInfos newI)
    {
        {
            var withBlock = newI;
            _size = withBlock.Size;
            _address = withBlock.BaseAddress;
            _entryPoint = withBlock.EntryPoint;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[32];

        s[0] = "Size";
        s[1] = "Address";
        s[2] = "Flags";
        s[3] = "LoadCount";
        s[4] = "Version";
        s[5] = "Description";
        s[6] = "CompanyName";
        s[7] = "Path";
        s[8] = "Comments";
        s[9] = "FileBuildPart";
        s[10] = "FileMajorPart";
        s[11] = "FileMinorPart";
        s[12] = "FilePrivatePart";
        s[13] = "InternalName";
        s[14] = "IsDebug";
        s[15] = "IsPatched";
        s[16] = "IsPreRelease";
        s[17] = "IsPrivateBuild";
        s[18] = "IsSpecialBuild";
        s[19] = "Language";
        s[20] = "LegalCopyright";
        s[21] = "LegalTrademarks";
        s[22] = "OriginalFilename";
        s[23] = "PrivateBuild";
        s[24] = "ProductBuildPart";
        s[25] = "ProductMajorPart";
        s[26] = "ProductMinorPart";
        s[27] = "ProductName";
        s[28] = "ProductPrivatePart";
        s[29] = "ProductVersion";
        s[30] = "SpecialBuild";
        s[31] = "ProcessId";

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

