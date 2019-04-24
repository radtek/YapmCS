using Microsoft.VisualBasic;
using Common;
using System;
using System.Text;

public class cFile
{

    // ========================================
    // Private attributes
    // ========================================
    private SerializableFileVersionInfo _tFileVersion;
    private bool _isArchive;
    private bool _isCompressed;
    private bool _isDevice;
    private bool _isDirectory;
    private bool _isEncrypted;
    private bool _isHidden;
    private bool _isNormal;
    private bool _isNotContentIndexed;
    private bool _isOffline;
    private bool _isReadOnly;
    private bool _isReparsePoint;
    private bool _isSparseFile;
    private bool _isSystem;
    private bool _isTemporary;
    private string _DateCreated;
    private string _DateLastAccessed;
    private string _DateLastModified;
    private long _FileSize;
    private long _CompressedFileSize;
    private string _ParentDirectory;
    private int _DirectoryDepth;
    private string _FileExtension;
    private string _FileAssociatedProgram;
    private string _FileType;
    private bool _FileAvailableForWrite;
    private bool _FileAvailableForRead;
    private string _ShortPath;
    private string _ShortName;
    private string _Name;
    private string _Path;

    // ========================================
    // Constructor
    // ========================================
    public cFile(string filePath, bool refreshInfos = false) : base()
    {
        _Path = filePath;
        if (refreshInfos)
            Refresh();
    }


    // ========================================
    // Getter & setter
    // ========================================
    public SerializableFileVersionInfo FileVersion
    {
        get
        {
            return _tFileVersion;
        }
    }
    public bool IsArchive
    {
        get
        {
            return _isArchive;
        }
    }
    public bool IsCompressed
    {
        get
        {
            return _isCompressed;
        }
    }
    public bool IsDevice
    {
        get
        {
            return _isDevice;
        }
    }
    public bool IsDirectory
    {
        get
        {
            return _isDirectory;
        }
    }
    public bool IsEncrypted
    {
        get
        {
            return _isEncrypted;
        }
    }
    public bool IsHidden
    {
        get
        {
            return _isHidden;
        }
    }
    public bool IsNormal
    {
        get
        {
            return _isNormal;
        }
    }
    public bool IsNotContentIndexed
    {
        get
        {
            return _isNotContentIndexed;
        }
    }
    public bool IsOffline
    {
        get
        {
            return _isOffline;
        }
    }
    public bool IsReadOnly
    {
        get
        {
            return _isReadOnly;
        }
    }
    public bool IsReparsePoint
    {
        get
        {
            return _isReparsePoint;
        }
    }
    public bool IsSparseFile
    {
        get
        {
            return _isSparseFile;
        }
    }
    public bool IsSystem
    {
        get
        {
            return _isSystem;
        }
    }
    public bool IsTemporary
    {
        get
        {
            return _isTemporary;
        }
    }
    public string DateCreated
    {
        get
        {
            return _DateCreated;
        }
    }
    public string DateLastAccessed
    {
        get
        {
            return _DateLastAccessed;
        }
    }
    public string DateLastModified
    {
        get
        {
            return _DateLastModified;
        }
    }
    public long FileSize
    {
        get
        {
            return _FileSize;
        }
    }
    public long CompressedFileSize
    {
        get
        {
            return _CompressedFileSize;
        }
    }
    public string ParentDirectory
    {
        get
        {
            return _ParentDirectory;
        }
    }
    public int DirectoryDepth
    {
        get
        {
            return _DirectoryDepth;
        }
    }
    public string FileExtension
    {
        get
        {
            return _FileExtension;
        }
    }
    public string FileAssociatedProgram
    {
        get
        {
            return _FileAssociatedProgram;
        }
    }
    public string FileType
    {
        get
        {
            return _FileType;
        }
    }
    public bool FileAvailableForWrite
    {
        get
        {
            return _FileAvailableForWrite;
        }
    }
    public bool FileAvailableForRead
    {
        get
        {
            return _FileAvailableForRead;
        }
    }
    public string ShortPath
    {
        get
        {
            return _ShortPath;
        }
    }
    public string ShortName
    {
        get
        {
            return _ShortName;
        }
    }
    public string Name
    {
        get
        {
            return _Name;
        }
    }
    public string Path
    {
        get
        {
            return _Path;
        }
    }
    public DateTime CreationTime
    {
        get
        {
            return System.IO.File.GetCreationTime(_Path);
        }
        set
        {
            System.IO.File.SetCreationTime(_Path, value);
        }
    }
    public DateTime LastAccessTime
    {
        get
        {
            return System.IO.File.GetLastAccessTime(_Path);
        }
        set
        {
            System.IO.File.SetLastAccessTime(_Path, value);
        }
    }
    public DateTime LastWriteTime
    {
        get
        {
            return System.IO.File.GetLastWriteTime(_Path);
        }
        set
        {
            System.IO.File.SetLastWriteTime(_Path, value);
        }
    }
    public System.IO.FileAttributes Attributes
    {
        get
        {
            return System.IO.File.GetAttributes(_Path);
        }
        set
        {
            System.IO.File.SetAttributes(_Path, value);
        }
    }


    // ========================================
    // Public functions
    // ========================================

    // Refresh all file informations
    public void Refresh()
    {

        // Get a handle
        IntPtr ptr = Native.Api.NativeFunctions.CreateFile(_Path, Native.Api.NativeEnums.EFileAccess.GenericRead, Native.Api.NativeEnums.EFileShare.Read | Native.Api.NativeEnums.EFileShare.Write, IntPtr.Zero, Native.Api.NativeEnums.ECreationDisposition.OpenExisting, 0, IntPtr.Zero);

        if (ptr == (IntPtr)-1)
            return;

        // Get sizes
        Native.Api.NativeFunctions.GetFileSizeEx(ptr, out _FileSize);
        _CompressedFileSize = Native.Api.NativeFunctions.GetCompressedFileSize(_Path, ref 0);

        // Get dates and attributes
        DateTime dC = System.IO.File.GetCreationTime(_Path);
        DateTime dA = System.IO.File.GetLastAccessTime(_Path);
        DateTime dW = System.IO.File.GetLastWriteTime(_Path);
        _DateLastModified = dW.ToLongDateString() + " -- " + dW.ToLongTimeString();
        _DateLastAccessed = dA.ToLongDateString() + " -- " + dA.ToLongTimeString();
        _DateCreated = dC.ToLongDateString() + " -- " + dC.ToLongTimeString();

        System.IO.FileAttributes fA = System.IO.File.GetAttributes(_Path);
        _isArchive = ((fA & System.IO.FileAttributes.Archive) == System.IO.FileAttributes.Archive);
        _isCompressed = ((fA & System.IO.FileAttributes.Compressed) == System.IO.FileAttributes.Compressed);
        _isDevice = ((fA & System.IO.FileAttributes.Device) == System.IO.FileAttributes.Device);
        _isDirectory = ((fA & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory);
        _isEncrypted = ((fA & System.IO.FileAttributes.Encrypted) == System.IO.FileAttributes.Encrypted);
        _isHidden = ((fA & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden);
        _isNormal = ((fA & System.IO.FileAttributes.Normal) == System.IO.FileAttributes.Normal);
        _isNotContentIndexed = ((fA & System.IO.FileAttributes.NotContentIndexed) == System.IO.FileAttributes.NotContentIndexed);
        _isOffline = ((fA & System.IO.FileAttributes.Offline) == System.IO.FileAttributes.Offline);
        _isReadOnly = ((fA & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly);
        _isReparsePoint = ((fA & System.IO.FileAttributes.ReparsePoint) == System.IO.FileAttributes.ReparsePoint);
        _isSparseFile = ((fA & System.IO.FileAttributes.SparseFile) == System.IO.FileAttributes.SparseFile);
        _isSystem = ((fA & System.IO.FileAttributes.System) == System.IO.FileAttributes.System);
        _isTemporary = ((fA & System.IO.FileAttributes.Temporary) == System.IO.FileAttributes.Temporary);

        _ParentDirectory = Strings.Replace(GetParentDir(_Path), @"\", @"\\");
        int x;
        var loopTo = _Path.Length - 1;
        for (x = 0; x <= loopTo; x++)
        {
            if (_Path.Substring(x, 1) == @"\")
                _DirectoryDepth += 1;
        }
        x = Strings.InStrRev(_Path, ".", Compare: CompareMethod.Binary);
        _FileExtension = Strings.Right(_Path, _Path.Length - x);
        x = Strings.InStrRev(_Path, @"\", Compare: CompareMethod.Binary);
        _Name = Strings.Right(_Path, _Path.Length - x);

        StringBuilder sb = new StringBuilder(255);
        Native.Api.NativeFunctions.FindExecutable(_Path, Constants.vbNullString, sb);
        _FileAssociatedProgram = Strings.Replace(sb.ToString(), @"\", @"\\");

        // File type
        try
        {
            string ft = System.Convert.ToString(My.MyProject.Computer.Registry.GetValue(@"HKEY_CLASSES_ROOT\." + Strings.LCase(_FileExtension), "", ""));
            ft = System.Convert.ToString(My.MyProject.Computer.Registry.GetValue(@"HKEY_CLASSES_ROOT\" + ft, "", ""));
            _FileType = System.Convert.ToString(Interaction.IIf(ft == Constants.vbNullString, "Unknown", ft));
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }

        // Short name/path
        StringBuilder sb2 = new StringBuilder(80);
        StringBuilder sb3 = new StringBuilder(80);
        Native.Api.NativeFunctions.GetShortPathName(_Path, sb2, 80);
        Native.Api.NativeFunctions.GetShortPathName(_ParentDirectory, sb3, 80);
        _ShortName = Strings.Replace(sb2.ToString(), @"\", @"\\");
        _ShortPath = Strings.Replace(sb3.ToString(), @"\", @"\\");

        IntPtr ptrR = Native.Api.NativeFunctions.CreateFile(_Path, Native.Api.NativeEnums.EFileAccess.GenericRead, Native.Api.NativeEnums.EFileShare.Read | Native.Api.NativeEnums.EFileShare.Write, IntPtr.Zero, Native.Api.NativeEnums.ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
        if (ptrR.IsNotNull())
        {
            Native.Api.NativeFunctions.CloseHandle(ptrR);
            _FileAvailableForRead = true;
        }

        IntPtr ptrW = Native.Api.NativeFunctions.CreateFile(_Path, Native.Api.NativeEnums.EFileAccess.GenericWrite, Native.Api.NativeEnums.EFileShare.Read | Native.Api.NativeEnums.EFileShare.Write, IntPtr.Zero, Native.Api.NativeEnums.ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
        if (ptrW.IsNotNull())
        {
            Native.Api.NativeFunctions.CloseHandle(ptrW);
            _FileAvailableForWrite = true;
        }

        // Infos about dll/exe
        _tFileVersion = new SerializableFileVersionInfo(System.Diagnostics.FileVersionInfo.GetVersionInfo(_Path));

        sb2 = null;
        sb3 = null;
        sb = null;
        Native.Api.NativeFunctions.CloseHandle(ptr);
    }

    // Display File Property Box
    public bool ShowFileProperty(IntPtr handle)
    {
        Native.Api.NativeStructs.ShellExecuteInfo SEI = default(Native.Api.NativeStructs.ShellExecuteInfo);
        {
            var withBlock = SEI;
            withBlock.fMask = Native.Api.NativeEnums.ShellExecuteInfoMask.NoUI | Native.Api.NativeEnums.ShellExecuteInfoMask.InvokeIdList | Native.Api.NativeEnums.ShellExecuteInfoMask.NoCloseProcess;
            withBlock.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(SEI);
            withBlock.hwnd = handle;
            withBlock.lpVerb = "properties";
            withBlock.lpFile = _Path;
            withBlock.lpParameters = Constants.vbNullChar;
            withBlock.lpDirectory = Constants.vbNullChar;
            withBlock.nShow = 0;
            withBlock.hInstApp = IntPtr.Zero;
            withBlock.lpIDList = IntPtr.Zero;
        }

        return Native.Api.NativeFunctions.ShellExecuteEx(ref SEI);
    }

    // Open directory
    public int OpenDirectory()
    {
        int r = -1;
        if (System.IO.File.Exists(_Path))
        {
            string p = System.IO.Directory.GetParent(_Path).FullName;
            r = Interaction.Shell("explorer.exe " + p, AppWinStyle.NormalFocus); // This is some kind of shit, but it's the simpliest way
        }
        return r;
    }

    // Get parent dir
    public string GetParentDir()
    {
        int i = Strings.InStrRev(_Path, @"\", Compare: CompareMethod.Binary);
        if (i > 0)
            return _Path.Substring(0, i);
        else
            return _Path;
    }

    // Open a file/URL
    public bool ShellOpenFile(IntPtr handle)
    {
        Native.Api.NativeStructs.ShellExecuteInfo SEI = default(Native.Api.NativeStructs.ShellExecuteInfo);
        {
            var withBlock = SEI;
            withBlock.fMask = Native.Api.NativeEnums.ShellExecuteInfoMask.NoUI | Native.Api.NativeEnums.ShellExecuteInfoMask.InvokeIdList | Native.Api.NativeEnums.ShellExecuteInfoMask.NoCloseProcess;
            withBlock.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(SEI);
            withBlock.hwnd = handle;
            withBlock.lpVerb = Constants.vbNullChar;
            withBlock.lpFile = _Path;
            withBlock.lpParameters = Constants.vbNullChar;
            withBlock.lpDirectory = Constants.vbNullChar;
            withBlock.nShow = 0;
            withBlock.hInstApp = IntPtr.Zero;
            withBlock.lpIDList = IntPtr.Zero;
        }

        return Native.Api.NativeFunctions.ShellExecuteEx(ref SEI);
    }

    // Retrieve a good formated path from a bad string
    public string IntelligentPathRetrieving()
    {
        string rootDir = System.Environment.GetFolderPath(Environment.SpecialFolder.System);

        string s = Strings.Replace(_Path.ToLowerInvariant(), "@%systemroot%", rootDir);
        s = Strings.Replace(s, "%systemroot%", rootDir);

        // Get ID and file
        uint iD = 0;
        string file = Constants.vbNullString;
        int i = Strings.InStrRev(s, ".exe", Compare: CompareMethod.Binary);
        if (i == 0)
            i = Strings.InStrRev(s, ".dll", Compare: CompareMethod.Binary);
        file = Strings.Left(s, i + 3);
        iD = System.Convert.ToUInt32(Conversion.Val(Strings.Right(s, s.Length - i - 5)));

        // Get ressource
        return Strings.Replace(Native.Objects.File.GetResourceStringFromFile(_Path, iD), @"\", @"\\");
    }

    // Retrieve a good formated path from a bad string
    public string IntelligentPathRetrieving2()
    {
        // Get ID and file
        string file = Constants.vbNullString;
        int i = Strings.InStrRev(_Path, ".exe", Compare: CompareMethod.Binary);
        file = Strings.Left(_Path, i + 3);
        return file;
    }

    // Return file name from a path
    public string GetFileName()
    {
        int i = Strings.InStrRev(_Path, @"\", Compare: CompareMethod.Binary);
        if (i > 0)
            return Strings.Right(_Path, _Path.Length - i);
        else
            return Constants.vbNullString;
    }

    // Move a file to the trash
    public int MoveToTrash()
    {
        try
        {
            My.MyProject.Computer.FileSystem.DeleteFile(_Path, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            return 0;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    // Kill a file
    public int WindowsKill()
    {
        try
        {
            My.MyProject.Computer.FileSystem.DeleteFile(_Path, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently);
            return 0;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    // Encrypt the file
    public void Encrypt()
    {
        System.IO.File.Encrypt(_Path);
    }

    // Decrypt the file
    public void Decrypt()
    {
        System.IO.File.Decrypt(_Path);
    }

    // Move a file
    public string WindowsMove(string dest)
    {
        try
        {
            My.MyProject.Computer.FileSystem.MoveFile(_Path, dest + @"\" + this.Name, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
            _Path = dest + @"\" + this.Name;
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
        return _Path;
    }

    // Copy a file
    public int WindowCopy(string dest)
    {
        try
        {
            My.MyProject.Computer.FileSystem.CopyFile(_Path, dest, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
            return 0;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    // Rename a file
    public string WindowsRename(string newName)
    {
        try
        {
            My.MyProject.Computer.FileSystem.RenameFile(_Path, newName);
            _Path = GetParentDir(_Path) + newName;
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
        return _Path;
    }


    // ========================================
    // Shared functions
    // ========================================

    // Return file name from a path
    public static string GetFileName(string filePath)
    {
        int i = Strings.InStrRev(filePath, @"\", Compare: CompareMethod.Binary);
        if (i > 0)
            return Strings.Right(filePath, filePath.Length - i);
        else
            return Constants.vbNullString;
    }

    // Get parent dir
    public static string GetParentDir(string filePath)
    {
        int i = Strings.InStrRev(filePath, @"\", Compare: CompareMethod.Binary);
        if (i > 0)
            return filePath.Substring(0, i);
        else
            return filePath;
    }

    // Open a directory specified in parameter
    public static int OpenADirectory(string dir)
    {
        int r = -1;
        if (System.IO.Directory.Exists(dir))
            r = Interaction.Shell("explorer.exe " + dir, AppWinStyle.NormalFocus);// This is some kind of shit, but it's the simpliest way
        return r;
    }

    public static int ShowRunBox(IntPtr hWnd, string Title, string Message)
    {
        return Native.Api.NativeFunctions.RunFileDlg(hWnd, IntPtr.Zero, null, Title, Message, Native.Api.NativeEnums.RunFileDialogFlags.None);
    }

    // Return basic file size
    public static long GetFileSize(string filePath)
    {
        long ret;

        IntPtr ptr = Native.Api.NativeFunctions.CreateFile(filePath, Native.Api.NativeEnums.EFileAccess.GenericRead, Native.Api.NativeEnums.EFileShare.Read | Native.Api.NativeEnums.EFileShare.Write, IntPtr.Zero, Native.Api.NativeEnums.ECreationDisposition.OpenExisting, 0, IntPtr.Zero);

        if (ptr == (IntPtr)-1)
            return -1;

        // Get sizes
        Native.Api.NativeFunctions.GetFileSizeEx(ptr, out ret);

        Native.Api.NativeFunctions.CloseHandle(ptr);

        return ret;
    }

    // Open a file/URL
    public static bool ShellOpenFile(string filePath, IntPtr handle)
    {
        Native.Api.NativeStructs.ShellExecuteInfo SEI = default(Native.Api.NativeStructs.ShellExecuteInfo);
        {
            var withBlock = SEI;
            withBlock.fMask = Native.Api.NativeEnums.ShellExecuteInfoMask.NoCloseProcess | Native.Api.NativeEnums.ShellExecuteInfoMask.InvokeIdList | Native.Api.NativeEnums.ShellExecuteInfoMask.NoUI;
            withBlock.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(SEI);
            withBlock.hwnd = handle;
            withBlock.lpVerb = Constants.vbNullChar;
            withBlock.lpFile = filePath;
            withBlock.lpParameters = Constants.vbNullChar;
            withBlock.lpDirectory = Constants.vbNullChar;
            withBlock.nShow = 0;
            withBlock.hInstApp = IntPtr.Zero;
            withBlock.lpIDList = IntPtr.Zero;
        }

        return Native.Api.NativeFunctions.ShellExecuteEx(ref SEI);
    }

    // Display File Property Box
    public static bool ShowFileProperty(string filePath, IntPtr handle)
    {
        Native.Api.NativeStructs.ShellExecuteInfo SEI = default(Native.Api.NativeStructs.ShellExecuteInfo);
        {
            var withBlock = SEI;
            withBlock.fMask = Native.Api.NativeEnums.ShellExecuteInfoMask.NoUI | Native.Api.NativeEnums.ShellExecuteInfoMask.InvokeIdList | Native.Api.NativeEnums.ShellExecuteInfoMask.NoCloseProcess;

            withBlock.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(SEI);
            withBlock.hwnd = handle;
            withBlock.lpVerb = "properties";
            withBlock.lpFile = filePath;
            withBlock.lpParameters = Constants.vbNullChar;
            withBlock.lpDirectory = Constants.vbNullChar;
            withBlock.nShow = 0;
            withBlock.hInstApp = IntPtr.Zero;
            withBlock.lpIDList = IntPtr.Zero;
        }

        return Native.Api.NativeFunctions.ShellExecuteEx(ref SEI);
    }

    // Open directory
    public static int OpenDirectory(string filePath)
    {
        int r = -1;
        if (System.IO.File.Exists(filePath))
        {
            string p = System.IO.Directory.GetParent(filePath).FullName;
            r = Interaction.Shell("explorer.exe " + p, AppWinStyle.NormalFocus); // This is some kind of shit, but it's the simpliest way
        }
        return r;
    }

    // Retrieve a good formated path from a bad string
    public static string IntelligentPathRetrieving2(string filePath)
    {
        // Get ID and file
        string file = Constants.vbNullString;
        int i = Strings.InStrRev(filePath, ".exe", Compare: CompareMethod.Binary);
        file = Strings.Left(filePath, i + 3);
        return file;
    }
}

