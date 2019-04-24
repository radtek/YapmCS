using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using Native.Api;

public class ProcessRW : IDisposable
{
    private const int SIZE_FOR_STRING = 5;

    public struct T_RESULT
    {
        public IntPtr curOffset;
        public string strString;
    }


    // =======================================================
    // Private attributes
    // =======================================================
    private int _pid;
    private IntPtr _handle;
    private static NativeStructs.SystemInfo si;


    // =======================================================
    // Public properties
    // =======================================================
    public NativeStructs.SystemInfo SystemInfo
    {
        get
        {
            return si;
        }
    }
    public IntPtr Handle
    {
        get
        {
            return _handle;
        }
    }

    // =======================================================
    // Public functions
    // =======================================================
    public ProcessRW(int processId)
    {
        _pid = processId;
        _handle = Native.Objects.Process.GetProcessHandleById(processId, Native.Security.ProcessAccess.All);
        si = Native.Objects.SystemInfo.GetSystemInfo();
    }
    ~ProcessRW()
    {
        Native.Objects.General.CloseHandle(_handle);
    }
    public void Dispose()
    {
    }

    // Read in memory
    public int[] ReadInt32Array(IntPtr offset, int arraySize)
    {
        int[] sBuf;
        int lByte;
        sBuf = new int[arraySize - 1 + 1];

        // Int32 array -> size*4 to get bytes count
        NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, arraySize * 4, ref lByte);

        return sBuf;
    }

    // Used for memory search only (because string is crappy for ReadProcMemory)
    public string ReadString(IntPtr offset, IntPtr stringSize)
    {
        byte[] sBuf;
        int lByte;
        sBuf = new byte[stringSize.ToInt32() - 1 + 1];

        NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, stringSize.ToInt32(), ref lByte);
        return System.Text.Encoding.ASCII.GetString(sBuf);
    }

    public IntPtr[] ReadIntPtrArray(IntPtr offset, int arraySize)
    {
        IntPtr[] sBuf;
        int lByte;
        sBuf = new IntPtr[arraySize - 1 + 1];

        // Intptr array -> size*Intptr.size to get bytes count
        NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, arraySize * IntPtr.Size, ref lByte);

        return sBuf;
    }

    public IntPtr ReadIntPtr(IntPtr offset)
    {
        IntPtr[] sBuf;
        int lByte;
        sBuf = new IntPtr[1];

        // Intptr array -> size*Intptr.size to get bytes count
        NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, IntPtr.Size, ref lByte);

        return sBuf[0];
    }

    public byte[] ReadByteArray(IntPtr offset, int arraySize, ref bool ok)
    {
        byte[] sBuf;
        int lByte;
        sBuf = new byte[arraySize - 1 + 1];

        // Byte array -> size*1 to get bytes count
        ok = NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, arraySize, ref lByte);

        return sBuf;
    }

    public short[] ReadInt16Array(IntPtr offset, int arraySize)
    {
        short[] sBuf;
        int lByte;
        sBuf = new short[arraySize - 1 + 1];

        // Byte array -> size*1 to get bytes count
        NativeFunctions.ReadProcessMemory(_handle, offset, sBuf, arraySize, ref lByte);

        return sBuf;
    }

    public byte ReadByte(IntPtr offset)
    {
        byte[] ret = new byte[1];
        int lByte;
        // 1 byte
        NativeFunctions.ReadProcessMemory(_handle, offset, ret, 1, ref lByte);
        return ret[0];
    }

    public short ReadInt16(IntPtr offset)
    {
        short[] ret = new short[1];
        int lByte;
        // A short = 2 bytes
        NativeFunctions.ReadProcessMemory(_handle, offset, ret, 2, ref lByte);
        return ret[0];
    }

    // Retrieve memory regions (availables for r/w)
    public void RetrieveMemRegions(ref NativeStructs.MemoryBasicInformation[] regions, int pid, bool onlyProcessRegions = false)
    {
        IntPtr lPosMem;
        int lRet;
        int lLenMBI;
        NativeStructs.MemoryBasicInformation mbi;

        regions = new NativeStructs.MemoryBasicInformation[1001];     // Initial buffer

        lLenMBI = System.Runtime.InteropServices.Marshal.SizeOf(mbi);
        if (si.lpMaximumApplicationAddress.IsNull())
            NativeFunctions.GetSystemInfo(ref si);
        lPosMem = si.lpMinimumApplicationAddress;  // Start from shorter address

        int _xx = 0;

        while (lPosMem.IsLowerThan(si.lpMaximumApplicationAddress)) // While addresse is lower than max address
        {
            mbi.RegionSize = IntPtr.Zero;

            lRet = NativeFunctions.VirtualQueryEx(_handle, lPosMem, ref mbi, lLenMBI);

            if (lRet == lLenMBI)
            {
                if (mbi.RegionSize.IsGreaterThan(0) && ((!onlyProcessRegions) || (mbi.Type == NativeEnums.MemoryType.Private & mbi.State == NativeEnums.MemoryState.Commit)))
                {
                    // Here is a region
                    _xx += 1;
                    if (_xx >= regions.Length)
                    {
                        var oldRegions = regions;
                        regions = new NativeStructs.MemoryBasicInformation[regions.Length * 2 + 1];
                        if (oldRegions != null)
                            Array.Copy(oldRegions, regions, Math.Min(regions.Length * 2 + 1, oldRegions.Length));
                    }
                    regions[_xx - 1] = mbi;
                }

                // Goes on
                // (add region size to start addresse ==> get next start addresse)
                lPosMem = mbi.BaseAddress.Increment(mbi.RegionSize);
            }
            else
                // Done
                break;
        }

        var oldRegions1 = regions;
        regions = new NativeStructs.MemoryBasicInformation[_xx - 1 + 1];

        // Remove last item
        if (oldRegions1 != null)
            Array.Copy(oldRegions1, regions, Math.Min(_xx - 1 + 1, oldRegions1.Length));
    }

    public void RetrieveMemRegions(ref IntPtr[] lBaseAdress, ref IntPtr[] lRegionSize, bool onlyProc = false)
    {
        NativeStructs.MemoryBasicInformation[] regions;

        regions = new NativeStructs.MemoryBasicInformation[1];
        RetrieveMemRegions(ref regions, this._pid, onlyProc);

        lBaseAdress = new IntPtr[regions.Length - 1 + 1];
        lRegionSize = new IntPtr[regions.Length - 1 + 1];
        var loopTo = regions.Length - 1;
        for (int x = 0; x <= loopTo; x++)
        {
            lBaseAdress[x] = regions[x].BaseAddress;
            lRegionSize[x] = regions[x].RegionSize;
        }
    }

    // Search a string in memory
    public void SearchForStringMemory(string sMatch, bool bCasse, ref long[] tRes, ProgressBar PGB = null)
    {
        int x;
        string strBufT;
        IntPtr[] LB;
        IntPtr[] LS;

        tRes = new long[1];
        LB = new IntPtr[1];
        LS = new IntPtr[1];

        // Get memory regions
        RetrieveMemRegions(ref LB, ref LS);

        if (!(PGB == null))
        {
            {
                var withBlock = PGB;
                withBlock.Minimum = 0;
                withBlock.Value = 0;
                withBlock.Maximum = LS.Length;
            }
        }

        if (bCasse == false)
            sMatch = sMatch.ToLower();
        var loopTo = LS.Length;
        for (x = 1; x <= loopTo; x++)
        {

            // Get current region into one string
            // Not a good idea -> TOCHANGE
            strBufT = ReadString(LB[x], LS[x]);

            if (bCasse == false)
                strBufT = strBufT.ToLower();

            // While match
            while (!(Strings.InStr(1, strBufT, sMatch, Constants.vbBinaryCompare) == 0))
            {
                var oldTRes = tRes;
                tRes = new long[tRes.Length + 1 + 1];

                // Found a string
                if (oldTRes != null)
                    Array.Copy(oldTRes, tRes, Math.Min(tRes.Length + 1 + 1, oldTRes.Length));

                tRes[tRes.Length] = LB[x].ToInt64() + Strings.InStr(1, strBufT, sMatch, CompareMethod.Binary) + LS[x].ToInt64() - Strings.Len(strBufT) - 1;

                strBufT = Strings.Right(strBufT, Strings.Len(strBufT) - Strings.InStr(1, strBufT, sMatch, CompareMethod.Binary) - Strings.Len(sMatch) + 1);
            }

            if (!(PGB == null))
                PGB.Value = x;
        }

        if (!(PGB == null))
            PGB.Value = PGB.Maximum;

        strBufT = Constants.vbNullString;
    }


    // Search a complete string
    private bool _stringSearchImmediateStop;
    public bool StopSearch
    {
        set
        {
            _stringSearchImmediateStop = value;
        }
    }
    public void SearchEntireStringMemory(ref IntPtr[] lngRes, ref string[] strRes, ProgressBar PGB = null)
    {
        string strCtemp = Constants.vbNullString;
        int x = 1;
        IntPtr lngLen;
        string strBuffer;
        int i;
        T_RESULT[] tRes;
        IntPtr[] LB;
        IntPtr[] LS;
        int cArraySizeBef = 0;

        const int BUF_SIZE = 2000;     // Size of array

        tRes = new T_RESULT[2001];

        LB = new IntPtr[1];
        LS = new IntPtr[1];

        // Get memory regions
        RetrieveMemRegions(ref LB, ref LS, true);

        // Calculate max size
        lngLen = IntPtr.Zero;
        var loopTo = LS.Length - 1;
        for (i = 0; i <= loopTo; i++)
            lngLen.Increment(LS[i]);

        if (!(PGB == null))
        {
            Async.ProgressBar.ChangeMaximum(PGB, LS.Length + 1);
            Async.ProgressBar.ChangeValue(PGB, 0);
        }

        var loopTo1 = LS.Length - 1;


        // For each region
        for (x = 0; x <= loopTo1; x++)
        {

            // Get entire region
            strBuffer = ReadString(LB[x], LS[x]);
            strCtemp = Constants.vbNullString;

            // Search in string
            if (!(PGB == null))
                Async.ProgressBar.ChangeValue(PGB, PGB.Value + 1);
            var loopTo2 = LS[x].ToInt32() - 1;
            for (i = 0; i <= loopTo2; i++)
            {
                if (_stringSearchImmediateStop)
                {
                    // Exit
                    Async.ProgressBar.ChangeValue(PGB, PGB.Maximum);
                    return;
                }

                if (isLetter(strBuffer[i]))
                    strCtemp += strBuffer.Chars[i];
                else
                {
                    // strCtemp = Trim$(strCtemp)
                    if (Strings.Len(strCtemp) > SIZE_FOR_STRING)
                    {

                        // Resize only every BUF times
                        if (cArraySizeBef == BUF_SIZE)
                        {
                            cArraySizeBef = 0;
                            var oldTRes = tRes;
                            tRes = new T_RESULT[tRes.Length + BUF_SIZE + 1];
                            if (oldTRes != null)
                                Array.Copy(oldTRes, tRes, Math.Min(tRes.Length + BUF_SIZE + 1, oldTRes.Length));
                        }

                        tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].curOffset = new IntPtr(i + LB[x].ToInt64() - Strings.Len(strCtemp) + 1);
                        tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].strString = strCtemp;
                        cArraySizeBef += 1;
                    }
                    strCtemp = Constants.vbNullString;
                }
            }

            if (Strings.Len(strCtemp) > SIZE_FOR_STRING)
            {
                // Resize only every BUF times
                if (cArraySizeBef == BUF_SIZE)
                {
                    cArraySizeBef = 0;
                    var oldTRes1 = tRes;
                    tRes = new T_RESULT[tRes.Length + BUF_SIZE + 1];
                    if (oldTRes1 != null)
                        Array.Copy(oldTRes1, tRes, Math.Min(tRes.Length + BUF_SIZE + 1, oldTRes1.Length));
                }

                tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].curOffset = LB[x].Increment(LS[x].ToInt32() + 1 - Strings.Len(strCtemp));
                tRes[tRes.Length - BUF_SIZE + cArraySizeBef - 1].strString = strCtemp;
            }
        }


        if (!(PGB == null))
            Async.ProgressBar.ChangeValue(PGB, PGB.Maximum);
        strBuffer = Constants.vbNullString;

        lngRes = new IntPtr[tRes.Length - BUF_SIZE + cArraySizeBef - 1 + 1];
        strRes = new string[tRes.Length - BUF_SIZE + cArraySizeBef - 1 + 1];
        var loopTo3 = tRes.Length - BUF_SIZE + cArraySizeBef - 1;
        for (i = 0; i <= loopTo3; i++)
        {
            lngRes[i] = tRes[i].curOffset;
            strRes[i] = tRes[i].strString;
        }
    }


    private bool isLetter(char c)
    {
        int i = Strings.Asc(c);
        // A-Z [/]_^' space a-z {|}
        return ((i >= 65 & i <= 125) || (i >= 45 & i <= 57) || i == 32);
    }
}

