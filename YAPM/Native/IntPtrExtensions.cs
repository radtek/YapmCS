using System;
using System.Runtime.InteropServices;

// http://blogs.msdn.com/jaredpar/archive/2008/11/11/properly-incrementing-an-intptr.aspx

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Assembly | AttributeTargets.Class)]
    public class ExtensionAttribute : Attribute
    {
    }
}

public static class IntPtrExtensions
{

    // This module extendes the methods available for IntPtr.
    // So now we are able to move the pointer pointed by IntPtr using
    // Increment or Decrement

    // Increment
    public static IntPtr Increment(this IntPtr ptr, int cbSize)
    {
        return new IntPtr(ptr.ToInt64() + cbSize);
    }

    public static IntPtr Increment(this IntPtr ptr, IntPtr cbSize)
    {
        return new IntPtr(ptr.ToInt64() + cbSize.ToInt64());
    }

    public static IntPtr Increment<T>(this IntPtr ptr)
    {
        return ptr.Increment(Marshal.SizeOf(typeof(T)));
    }


    // Decrement
    public static IntPtr Decrement(this IntPtr ptr, int cbSize)
    {
        return new IntPtr(ptr.ToInt64() - cbSize);
    }

    public static IntPtr Decrement<T>(this IntPtr ptr)
    {
        return ptr.Decrement(Marshal.SizeOf(typeof(T)));
    }

    public static IntPtr Decrement(this IntPtr ptr, IntPtr cbSize)
    {
        return new IntPtr(ptr.ToInt64() - cbSize.ToInt64());
    }


    // Return element at index
    public static T ElementAt<T>(this IntPtr ptr, int index)
    {
        int offset = Marshal.SizeOf(typeof(T)) * index;
        IntPtr offsetPtr = ptr.Increment(offset);
        return (T)Marshal.PtrToStructure(offsetPtr, typeof(T));
    }


    // Compare methods
    public static bool IsNull(this IntPtr ptr)
    {
        return (ptr == IntPtr.Zero);
    }
    public static bool IsNotNull(this IntPtr ptr)
    {
        return (ptr != IntPtr.Zero);
    }

    public static bool IsGreaterThan(this IntPtr ptr, IntPtr ptr2)
    {
        return (ptr.ToInt64() > ptr2.ToInt64());
    }
    public static bool IsGreaterThan(this IntPtr ptr, int ptr2)
    {
        return (ptr.ToInt64() > ptr2);
    }
    public static bool IsGreaterThan(this IntPtr ptr, long ptr2)
    {
        return (ptr.ToInt64() > ptr2);
    }

    public static bool IsLowerThan(this IntPtr ptr, IntPtr ptr2)
    {
        return (ptr.ToInt64() < ptr2.ToInt64());
    }
    public static bool IsLowerThan(this IntPtr ptr, int ptr2)
    {
        return (ptr.ToInt64() < ptr2);
    }
    public static bool IsLowerThan(this IntPtr ptr, long ptr2)
    {
        return (ptr.ToInt64() < ptr2);
    }

    public static bool IsGreaterOrEqualThan(this IntPtr ptr, IntPtr ptr2)
    {
        return (ptr.ToInt64() >= ptr2.ToInt64());
    }
    public static bool IsGreaterOrEqualThan(this IntPtr ptr, int ptr2)
    {
        return (ptr.ToInt64() >= ptr2);
    }
    public static bool IsGreaterOrEqualThan(this IntPtr ptr, long ptr2)
    {
        return (ptr.ToInt64() >= ptr2);
    }

    public static bool IsLowerOrEqualThan(this IntPtr ptr, IntPtr ptr2)
    {
        return (ptr.ToInt64() <= ptr2.ToInt64());
    }
    public static bool IsLowerOrEqualThan(this IntPtr ptr, int ptr2)
    {
        return (ptr.ToInt64() <= ptr2);
    }
    public static bool IsLowerOrEqualThan(this IntPtr ptr, long ptr2)
    {
        return (ptr.ToInt64() <= ptr2);
    }

    public static bool IsEqualTo(this IntPtr ptr, IntPtr ptr2)
    {
        return (ptr.ToInt64() == ptr2.ToInt64());
    }
    public static bool IsEqualTo(this IntPtr ptr, int ptr2)
    {
        return (ptr.ToInt64() == ptr2);
    }
    public static bool IsEqualTo(this IntPtr ptr, long ptr2)
    {
        return (ptr.ToInt64() == ptr2);
    }
}
