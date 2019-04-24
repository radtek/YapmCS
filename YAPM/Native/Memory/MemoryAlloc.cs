using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Native.Memory
{
    public class MemoryAlloc : IDisposable
    {

        // ========================================
        // Private
        // ========================================
        private IntPtr _ptr;
        private int _size;



        // ========================================
        // Operators
        // ========================================
        public static implicit operator int(MemoryAlloc memory)
        {
            return memory.Pointer.ToInt32();
        }

        public static implicit operator long(MemoryAlloc memory)
        {
            return memory.Pointer.ToInt64();
        }

        public static implicit operator IntPtr(MemoryAlloc memory)
        {
            return memory.Pointer;
        }



        // ========================================
        // Constructors / destructors
        // ========================================
        public MemoryAlloc()
        {
        }
        public MemoryAlloc(IntPtr ptr) : this(ptr, 0)
        {
        }
        public MemoryAlloc(IntPtr ptr, int size) : base()
        {
            _ptr = ptr;
            _size = size;
        }
        public MemoryAlloc(int size)
        {
            _ptr = Marshal.AllocHGlobal(size);
            _size = size;
        }
        public void Dispose()
        {
            this.Free();
        }



        // ========================================
        // Public properties
        // ========================================
        public IntPtr Pointer
        {
            get
            {
                return _ptr;
            }
            set
            {
                _ptr = value;
            }
        }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Free memory
        public void Free()
        {
            if (this.Pointer != IntPtr.Zero)
                Marshal.FreeHGlobal(this.Pointer);
        }

        // Read functions
        public byte[] ReadBytes(int length)
        {
            return this.ReadBytes(0, length);
        }
        public byte[] ReadBytes(int offset, int length)
        {
            byte[] buffer = new byte[length - 1 + 1];
            this.ReadBytes(offset, buffer, 0, length);
            return buffer;
        }
        public void ReadBytes(byte[] buffer, int startIndex, int length)
        {
            this.ReadBytes(0, buffer, startIndex, length);
        }
        public void ReadBytes(int offset, byte[] buffer, int startIndex, int length)
        {
            Marshal.Copy(_ptr.Increment(offset), buffer, startIndex, length);
        }

        public int ReadByte(int offset)
        {
            return this.ReadByte(offset, 0);
        }
        public int ReadByte(int offset, int index)
        {
            return Marshal.ReadByte(_ptr, offset + index * 4);
        }

        public int ReadInt32(int offset)
        {
            return this.ReadInt32(offset, 0);
        }
        public int ReadInt32(int offset, int index)
        {
            return Marshal.ReadInt32(_ptr, offset + index * 4);
        }

        public IntPtr ReadIntPtr(int offset)
        {
            return this.ReadIntPtr(offset, 0);
        }
        public IntPtr ReadIntPtr(int offset, int index)
        {
            return Marshal.ReadIntPtr(_ptr, offset + index * IntPtr.Size);
        }

        public uint ReadUInt32(int offset)
        {
            return this.ReadUInt32(offset, 0);
        }
        public uint ReadUInt32(int offset, int index)
        {
            return System.Convert.ToUInt32(this.ReadInt32(offset, index));
        }

        public T ReadStruct<T>()
        {
            return this.ReadStruct<T>(0);
        }
        public T ReadStruct<T>(int index)
        {
            return this.ReadStruct<T>(0, index);
        }
        public T ReadStruct<T>(int offset, int index)
        {
            return (T)Marshal.PtrToStructure(_ptr.Increment(offset + Marshal.SizeOf(typeof(T)) * index), typeof(T));
        }
        public T ReadStructOffset<T>(int offset)
        {
            return (T)Marshal.PtrToStructure(_ptr.Increment(offset), typeof(T));
        }

        // Resize memory allocation
        public void Resize(int newSize)
        {
            _ptr = Marshal.ReAllocHGlobal(_ptr, new IntPtr(newSize));
            _size = newSize;
        }
        public void IncrementSize(int newBytesCount)
        {
            _ptr = Marshal.ReAllocHGlobal(_ptr, new IntPtr(newBytesCount + _size));
            _size = newBytesCount + _size;
        }


        // Write functions
        public void WriteByte(int offset, byte b)
        {
            Marshal.WriteByte(this, offset, b);
        }
        public void WriteBytes(int offset, byte[] b)
        {
            Marshal.Copy(b, 0, _ptr.Increment(offset), b.Length);
        }

        public void WriteInt16(int offset, short i)
        {
            Marshal.WriteInt16(this, offset, i);
        }
        public void WriteInt32(int offset, int i)
        {
            Marshal.WriteInt32(this, offset, i);
        }
        public void WriteIntPtr(int offset, IntPtr i)
        {
            Marshal.WriteIntPtr(this, offset, i);
        }

        public void WriteStruct<T>(T s)
        {
            this.WriteStruct<T>(0, s);
        }
        public void WriteStruct<T>(int index, T s)
        {
            this.WriteStruct<T>(0, index, s);
        }
        public void WriteStruct<T>(int offset, int index, T s)
        {
            Marshal.StructureToPtr(s, _ptr.Increment(offset + Marshal.SizeOf(typeof(T)) * index), false);
        }

        public void WriteUnicodeString(int offset, string s)
        {
            byte[] b = UnicodeEncoding.Unicode.GetBytes(s);
            var loopTo = b.Length - 1;
            for (int i = 0; i <= loopTo; i++)
                Marshal.WriteByte(this.Pointer, offset + i, b[i]);
        }
    }
}
