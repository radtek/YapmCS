using System;

[Serializable()]
public class SerializableFileVersionInfo
{
    private string _Comments;
    private string _CompanyName;
    private int _FileBuildPart;
    private string _FileDescription;
    private int _FileMajorPart;
    private int _FileMinorPart;
    private string _FileName;
    private int _FilePrivatePart;
    private string _FileVersion;
    private string _InternalName;
    private bool _IsDebug;
    private bool _IsPatched;
    private bool _IsPreRelease;
    private bool _IsPrivateBuild;
    private bool _IsSpecialBuild;
    private string _Language;
    private string _LegalCopyright;
    private string _LegalTrademarks;
    private string _OriginalFilename;
    private string _PrivateBuild;
    private int _ProductBuildPart;
    private int _ProductMajorPart;
    private int _ProductMinorPart;
    private string _ProductName;
    private int _ProductPrivatePart;
    private string _ProductVersion;
    private string _SpecialBuild;

    public string Comments
    {
        get
        {
            return _Comments;
        }
    }
    public string CompanyName
    {
        get
        {
            return _CompanyName;
        }
    }
    public int FileBuildPart
    {
        get
        {
            return _FileBuildPart;
        }
    }
    public string FileDescription
    {
        get
        {
            return _FileDescription;
        }
    }
    public int FileMajorPart
    {
        get
        {
            return _FileMajorPart;
        }
    }
    public int FileMinorPart
    {
        get
        {
            return _FileMinorPart;
        }
    }
    public string FileName
    {
        get
        {
            return _FileName;
        }
    }
    public int FilePrivatePart
    {
        get
        {
            return _FilePrivatePart;
        }
    }
    public string FileVersion
    {
        get
        {
            return _FileVersion;
        }
    }
    public string InternalName
    {
        get
        {
            return _InternalName;
        }
    }
    public bool IsDebug
    {
        get
        {
            return _IsDebug;
        }
    }
    public bool IsPatched
    {
        get
        {
            return _IsPatched;
        }
    }
    public bool IsPreRelease
    {
        get
        {
            return _IsPreRelease;
        }
    }
    public bool IsPrivateBuild
    {
        get
        {
            return _IsPrivateBuild;
        }
    }
    public bool IsSpecialBuild
    {
        get
        {
            return _IsSpecialBuild;
        }
    }
    public string Language
    {
        get
        {
            return _Language;
        }
    }
    public string LegalCopyright
    {
        get
        {
            return _LegalCopyright;
        }
    }
    public string LegalTrademarks
    {
        get
        {
            return _LegalTrademarks;
        }
    }
    public string OriginalFilename
    {
        get
        {
            return _OriginalFilename;
        }
    }
    public string PrivateBuild
    {
        get
        {
            return _PrivateBuild;
        }
    }
    public int ProductBuildPart
    {
        get
        {
            return _ProductBuildPart;
        }
    }
    public int ProductMajorPart
    {
        get
        {
            return _ProductMajorPart;
        }
    }
    public int ProductMinorPart
    {
        get
        {
            return _ProductMinorPart;
        }
    }
    public string ProductName
    {
        get
        {
            return _ProductName;
        }
    }
    public int ProductPrivatePart
    {
        get
        {
            return _ProductPrivatePart;
        }
    }
    public string ProductVersion
    {
        get
        {
            return _ProductVersion;
        }
    }
    public string SpecialBuild
    {
        get
        {
            return _SpecialBuild;
        }
    }

    public SerializableFileVersionInfo(System.Diagnostics.FileVersionInfo info)
    {
        {
            var withBlock = info;
            _Comments = withBlock.Comments;
            _CompanyName = withBlock.CompanyName;
            _FileBuildPart = withBlock.FileBuildPart;
            _FileDescription = withBlock.FileDescription;
            _FileMajorPart = FileMajorPart;
            _FileMinorPart = withBlock.FileMinorPart;
            _FileName = withBlock.FileName;
            _FilePrivatePart = withBlock.FilePrivatePart;
            _FileVersion = withBlock.FileVersion;
            _InternalName = withBlock.InternalName;
            _IsDebug = withBlock.IsDebug;
            _IsPatched = withBlock.IsPatched;
            _IsPreRelease = withBlock.IsPreRelease;
            _IsPrivateBuild = withBlock.IsPrivateBuild;
            _IsSpecialBuild = withBlock.IsSpecialBuild;
            _Language = withBlock.Language;
            _LegalCopyright = withBlock.LegalCopyright;
            _LegalTrademarks = withBlock.LegalTrademarks;
            _OriginalFilename = withBlock.OriginalFilename;
            _PrivateBuild = withBlock.PrivateBuild;
            _ProductBuildPart = withBlock.ProductBuildPart;
            _ProductMajorPart = withBlock.ProductMajorPart;
            _ProductMinorPart = withBlock.ProductMinorPart;
            _ProductName = withBlock.ProductName;
            _ProductPrivatePart = withBlock.ProductPrivatePart;
            _ProductVersion = withBlock.ProductVersion;
            _SpecialBuild = withBlock.SpecialBuild;
        }
    }
}
