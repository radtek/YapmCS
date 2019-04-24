using System;
using System.Runtime.InteropServices;

public class ProcessMemReader : IDisposable
{

    // ========================================
    // Private
    // ========================================
    private int _pid;
    private IntPtr _hProc;


    // ========================================
    // Constructor & destructor
    // ========================================
    public ProcessMemReader(int pid)
    {
        _hProc = Native.Objects.Process.GetProcessHandleById(pid, Native.Security.ProcessAccess.QueryInformation | Native.Security.ProcessAccess.VmRead);
    }
    public void Dispose()
    {
        if (_hProc.IsNotNull())
            Native.Api.NativeFunctions.CloseHandle(_hProc);
    }


    // ========================================
    // Properties
    // ========================================
    public int ProcessId
    {
        get
        {
            return _pid;
        }
    }
    public IntPtr ProcessHandle
    {
        get
        {
            return _hProc;
        }
    }


    // ========================================
    // Public functions
    // ========================================

    // Get PEB
    public IntPtr GetPebAddress()
    {
        int ret;
        Native.Api.NativeStructs.ProcessBasicInformation pbi = new Native.Api.NativeStructs.ProcessBasicInformation();
        Native.Api.NativeFunctions.NtQueryInformationProcess(_hProc, Native.Api.NativeEnums.ProcessInformationClass.ProcessBasicInformation, ref pbi, Marshal.SizeOf(pbi), ref ret);
        return pbi.PebBaseAddress;
    }

    // Read an Int32
    public int ReadInt32(IntPtr offset)
    {
        int[] buffer = new int[1];
        int lByte;
        // 4 bytes for an Int32
        Native.Api.NativeFunctions.ReadProcessMemory(_hProc, offset, buffer, 0x4, ref lByte);
        return buffer[0];
    }

    // Read a pointer
    public IntPtr ReadIntPtr(IntPtr offset)
    {
        IntPtr[] buffer = new IntPtr[1];
        int lByte;
        Native.Api.NativeFunctions.ReadProcessMemory(_hProc, offset, buffer, Marshal.SizeOf(offset), ref lByte);
        return buffer[0];
    }

    // Read a byte array
    public byte[] ReadByteArray(IntPtr offset, int size)
    {
        byte[] buffer;
        int lByte;
        buffer = new byte[size - 1 + 1];
        Native.Api.NativeFunctions.ReadProcessMemory(_hProc, offset, buffer, size, ref lByte);
        return buffer;
    }

    // Read a structure
    public T ReadStruct<T>(IntPtr offset)
    {
        T ret;

        // Size of the structure
        int structSize = Marshal.SizeOf(typeof(T));

        // Buffer of byte which received the data read
        byte[] buf = ReadByteArray(offset, structSize);

        // Retrieve a structure
        GCHandle dataH = GCHandle.Alloc(buf, GCHandleType.Pinned);
        try
        {
            ret = (T)Marshal.PtrToStructure(dataH.AddrOfPinnedObject(), typeof(T));
        }
        finally
        {
            dataH.Free();
        }

        // Return struct
        return ret;
    }

    // Read an unicode string
    public string ReadUnicodeString(Native.Api.NativeStructs.UnicodeString str)
    {
        if (str.Length == 0)
            return null;

        // Read buffer from memory
        byte[] buf = ReadByteArray(str.Buffer, str.Length);
        GCHandle dataH = GCHandle.Alloc(buf, GCHandleType.Pinned);
        try
        {
            return Marshal.PtrToStringUni(dataH.AddrOfPinnedObject(), str.Length / 2);
        }
        finally
        {
            dataH.Free();
        }
    }
}

