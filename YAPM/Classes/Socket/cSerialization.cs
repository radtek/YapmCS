using System.Diagnostics;
using System;
using System.IO;
using System.IO.Compression;

public class cSerialization
{

    // Return byte array from data class
    public static byte[] GetSerializedObject(object obj)
    {
        System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            formatter.Serialize(ms, obj);
            return CompressByteArray(ref ms.ToArray());
        }
    }

    // Return data class from byte array
    public static cSocketData DeserializeObject(byte[] dataBytes)
    {
        try
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(DeCompressByteArray(ref dataBytes)))
            {
                return (cSocketData)formatter.Deserialize(ms);
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error during serialization : " + ex.Message);
            return null;
        }
    }
    public static T DeserializeObject<T>(byte[] dataBytes)
    {
        try
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(DeCompressByteArray(ref dataBytes)))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error during serialization : " + ex.Message);
            return default(T);
        }
    }

    private static byte[] CompressByteArray(ref byte[] b)
    {
        // Return b
        MemoryStream ms = new MemoryStream();
        Stream s = new GZipStream(ms, CompressionMode.Compress);
        s.Write(b, 0, b.Length);
        s.Close();
        return (byte[])ms.ToArray();
    }

    private static byte[] DeCompressByteArray(ref byte[] b)
    {
        // Return b
        byte[] writeData = new byte[4097]; // = new byte[4096]
        MemoryStream memStream = new MemoryStream();
        Stream s2 = new GZipStream(new MemoryStream(b), CompressionMode.Decompress);
        int size = 1;

        while ((size > 0))
        {
            size = s2.Read(writeData, 0, writeData.Length);
            memStream.Write(writeData, 0, size);
            memStream.Flush();
        }
        return memStream.ToArray();
    }
}

