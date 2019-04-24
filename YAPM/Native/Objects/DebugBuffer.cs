using System;
using Native.Api;

namespace Native.Objects
{
    public class DebugBuffer : IDisposable
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================
        private IntPtr _buffer = IntPtr.Zero;


        // ========================================
        // Operators
        // ========================================
        public static implicit operator int(DebugBuffer buf)
        {
            return buf.Buffer.ToInt32();
        }

        public static implicit operator long(DebugBuffer buf)
        {
            return buf.Buffer.ToInt64();
        }

        public static implicit operator IntPtr(DebugBuffer buf)
        {
            return buf.Buffer;
        }


        // ========================================
        // Public properties
        // ========================================
        public IntPtr Buffer
        {
            get
            {
                return _buffer;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Constructor
        public DebugBuffer()
        {
            _buffer = NativeFunctions.RtlCreateQueryDebugBuffer(0, true);
        }

        // Return memory as DebugInformation
        public NativeStructs.DebugInformation GetDebugInformation()
        {
            NativeStructs.DebugInformation res = default(NativeStructs.DebugInformation);
            if (_buffer.IsNotNull())
            {
                Native.Memory.MemoryAlloc mem = new Native.Memory.MemoryAlloc(_buffer);
                res = mem.ReadStruct<NativeStructs.DebugInformation>();
            }
            return res;
        }

        // Query debug information
        public void Query(int pid, NativeEnums.RtlQueryProcessDebugInformationFlags flags)
        {
            if (_buffer.IsNotNull())
                NativeFunctions.RtlQueryProcessDebugInformation(new IntPtr(pid), flags, _buffer);
        }

        // Destructor
        public void Dispose()
        {
            if (_buffer.IsNotNull())
                NativeFunctions.RtlDestroyQueryDebugBuffer(_buffer);
        }
    }
}
