using Common;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Heap
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================

        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Enumerate heaps
        public static Dictionary<string, heapInfos> EnumerateHeapsByProcessIds(int[] pid)
        {
            Dictionary<string, heapInfos> _dico = new Dictionary<string, heapInfos>();

            if (pid == null)
                return _dico;

            foreach (int id in pid)
            {
                Dictionary<string, heapInfos> _md = new Dictionary<string, heapInfos>();
                _md = EnumerateHeapsByProcessId(id);
                foreach (System.Collections.Generic.KeyValuePair<string, heapInfos> pair in _md)
                    _dico.Add(pair.Key, pair.Value);
            }
            return _dico;
        }

        // Enumerate modules
        public static Dictionary<string, heapInfos> EnumerateHeapsByProcessId(int pid)
        {
            Dictionary<string, heapInfos> retDico = new Dictionary<string, heapInfos>();

            // ' SLOW BUT ALWAYS WORKS (but some information about heap nodes couldn't be retrieved...)
            // ' Create snapshot
            // Dim snap As IntPtr = NativeFunctions.CreateToolhelp32Snapshot(NativeEnums.Toolhelp32SnapshotFlags.HeapList, pid)
            // 'Dim heap As New NativeStructs.HeapEntry32
            // Dim list As New NativeStructs.HeapList32

            // list.Size = Marshal.SizeOf(list)
            // 'heap.Size = Marshal.SizeOf(heap)

            // If snap.IsNotNull Then
            // If NativeFunctions.Heap32ListFirst(snap, list) Then
            // Do
            // ' Too much time to count the blocks....
            // 'NativeFunctions.Heap32First(heap, list.ProcessID, list.HeapID)
            // retDico.Add(list.HeapID.ToString, New heapInfos(list))
            // Loop While NativeFunctions.Heap32ListNext(snap, list)
            // End If
            // End If



            // FAST BUT SOMETIMES BUGGY SOLUTION
            DebugBuffer buf2 = new DebugBuffer();

            // Query heaps info
            buf2.Query(pid, NativeEnums.RtlQueryProcessDebugInformationFlags.Heaps | NativeEnums.RtlQueryProcessDebugInformationFlags.HeapBlocks);

            // Get debug information
            NativeStructs.DebugInformation debugInfo = buf2.GetDebugInformation();

            if (debugInfo.HeapInformation.IsNotNull())
            {
                Memory.MemoryAlloc heapInfo = new Memory.MemoryAlloc(debugInfo.HeapInformation);

                NativeStructs.ProcessHeaps heaps;
                try
                {
                    heaps = heapInfo.ReadStruct<NativeStructs.ProcessHeaps>();
                }
                catch (Exception ex)
                {
                    // Unfortunately, System.ExecutionEngineException cannot
                    // be catched....
                    // ReadStruct sometimes fails and causes YAPM to crash -___-
                    Misc.ShowDebugError(ex);
                    return retDico;
                }

                var loopTo = heaps.HeapsCount - 1;
                for (int i = 0; i <= loopTo; i++)
                {
                    NativeStructs.HeapInformation heap = heapInfo.ReadStruct<NativeStructs.HeapInformation>(NativeStructs.ProcessHeaps.HeapsOffset, i);
                    string key = heap.BaseAddress.ToString();
                    // PERFISSUE ??
                    if (retDico.ContainsKey(key) == false)
                        retDico.Add(key, new heapInfos(heap));
                }
            }

            buf2.Dispose();

            return retDico;
        }

        // Enumerate heap blocks
        public static Dictionary<string, NativeStructs.HeapBlock> EnumerateBlocksByNodeAddress(int pid, IntPtr nodeAddress)
        {
            Dictionary<string, NativeStructs.HeapBlock> res = new Dictionary<string, NativeStructs.HeapBlock>();

            NativeStructs.HeapBlock hb;
            {
                var withBlock = hb;
                withBlock.Address = IntPtr.Zero;
                withBlock.Flags = 0;
                withBlock.Reserved = IntPtr.Zero;
                withBlock.Size = 0;
            }

            DebugBuffer buf = new DebugBuffer();

            // Query heaps info
            buf.Query(pid, NativeEnums.RtlQueryProcessDebugInformationFlags.Heaps | NativeEnums.RtlQueryProcessDebugInformationFlags.HeapBlocks);

            // Get debug information
            NativeStructs.DebugInformation debugInfo = buf.GetDebugInformation();
            Memory.MemoryAlloc heapInfo = new Memory.MemoryAlloc(debugInfo.HeapInformation);
            NativeStructs.ProcessHeaps heaps = heapInfo.ReadStruct<NativeStructs.ProcessHeaps>();
            var loopTo = heaps.HeapsCount;

            // Go through each of the heap nodes 
            for (int i = 0; i <= loopTo; i++)
            {
                NativeStructs.HeapInformation heap = heapInfo.ReadStruct<NativeStructs.HeapInformation>(NativeStructs.ProcessHeaps.HeapsOffset, i);

                if (heap.BaseAddress == nodeAddress)
                {

                    // Now enumerate all blocks within this heap node...
                    {
                        var withBlock1 = hb;
                        withBlock1.Address = IntPtr.Zero;
                        withBlock1.Flags = 0;
                        withBlock1.Reserved = IntPtr.Zero;
                        withBlock1.Size = 0;
                    }

                    if ((GetFirstHeapBlock(heap, ref hb)))
                    {
                        var loopTo1 = heap.BlockCount;
                        for (int c = 1; c <= loopTo1; c++)
                        {
                            // PERFISSUE ?
                            if (res.ContainsKey(hb.Address.ToString()) == false)
                                res.Add(hb.Address.ToString(), hb);

                            // Get next block
                            GetNextHeapBlock(heap, ref hb);
                        }
                    }
                    break;
                }
            }

            // heapInfo.Free()

            // Clean up the buffer
            buf.Dispose();

            return res;
        }





        // ========================================
        // Private functions
        // ========================================

        // This is directly converted from C++
        // http://securityxploded.com/enumheaps.php
        private static bool GetFirstHeapBlock(NativeStructs.HeapInformation curHeapNode, ref NativeStructs.HeapBlock hb)
        {
            IntPtr block;

            {
                var withBlock = hb;
                withBlock.Reserved = IntPtr.Zero;
                withBlock.Address = IntPtr.Zero;
                withBlock.Flags = 0;
            }

            block = curHeapNode.Blocks;

            while ((Marshal.ReadInt32(block.Increment(IntPtr.Size * 1)) & 2) == 2)
            {
                hb.Reserved = hb.Reserved.Increment(IntPtr.Size * 1);
                hb.Address = Marshal.ReadIntPtr(block.Increment(IntPtr.Size * 3)).Increment(curHeapNode.Granularity);
                block = block.Increment(IntPtr.Size * 4);
                hb.Size = Marshal.ReadInt32(block, 0);
            }

            // Update the flags
            ushort flags = System.Convert.ToUInt16(Marshal.ReadInt32(block.Increment(IntPtr.Size * 1)));

            if (((flags & 0xF1) != 0 || (flags & 0x200) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Fixed;
            else if (((flags & 0x20) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Moveable;
            else if (((flags & 0x100) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Free;

            return true;
        }

        private static bool GetNextHeapBlock(NativeStructs.HeapInformation curHeapNode, ref NativeStructs.HeapBlock hb)
        {
            IntPtr block;

            hb.Reserved = hb.Reserved.Increment(IntPtr.Size * 1);
            block = curHeapNode.Blocks;

            // Make it point to next block address entry
            block = block.Increment(hb.Reserved.ToInt32() * 4);

            if (((Marshal.ReadInt32(block.Increment(IntPtr.Size * 1)) & 2) == 2))
            {
                while (((Marshal.ReadInt32(block.Increment(IntPtr.Size * 1)) & 2) == 2))
                {

                    // new address = curBlockAddress + Granularity ;
                    hb.Address = Marshal.ReadIntPtr(block.Increment(IntPtr.Size * 3)).Increment(curHeapNode.Granularity);

                    // If all the blocks have been enumerated....exit
                    if ((hb.Reserved.ToInt64() > curHeapNode.BlockCount))
                        return false;

                    hb.Reserved = hb.Reserved.Increment(IntPtr.Size * 4);

                    hb.Address = block.Increment(IntPtr.Size); // move to next block
                    hb.Size = Marshal.ReadInt32(block);
                }
            }
            else
            {
                // New Address = prev Address + prev block size ;
                hb.Address = (hb.Address.Increment(hb.Size));
                hb.Size = Marshal.ReadInt32(block);
            }

            // Update the flags...
            ushort flags = System.Convert.ToUInt16(Marshal.ReadInt32(block.Increment(0x4 * 1)));

            if (((flags & 0xF1) != 0 || (flags & 0x200) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Fixed;
            else if (((flags & 0x20) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Moveable;
            else if (((flags & 0x100) != 0))
                hb.Flags = NativeEnums.HeapBlockFlag.Free;

            return true;
        }
    }
}

