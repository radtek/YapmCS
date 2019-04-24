using System;
using Native.Api;

[Serializable()]
public class handleInfos : generalInfos
{


    // Ok, all these attributes are FRIEND because HandleEnumeration needs to access
    // to them, but let's assume the user won't corrupt these variables...

    internal int _ProcessID; // ID du processus propriétaire
    internal NativeEnums.HandleFlags _Flags;  // 0x01 = PROTECT_FROM_CLOSE, 0x02 = INHERIT
    internal IntPtr _Handle;  // valeur du handle
    internal string _ObjectName; // nom de l'objet
    internal int _ObjectTypeNumber; // type de l'objet (number)
    internal string _NameInformation; // type de l'ojet
    internal IntPtr _ObjectAddress;  // adresse de l'objet
    internal Native.Security.StandardRights _GrantedAccess;  // accès autorisés à l'objet
    internal NativeEnums.HandleFlags _Attributes; // attributs
    internal int _HandleCount; // nombre de handle de ce type dans le système
    internal uint _PointerCount; // nombre de références pointeurs à cet objet dans le système
    internal decimal _CreateTime; // date de création de l'objet
    internal int _GenericRead; // accès générique
    internal int _GenericWrite;
    internal int _GenericExecute;
    internal int _GenericAll;
    internal int _ObjectCount; // 
    internal int _PeakObjectCount; // 
    internal int _PeakHandleCount; // 
    internal int _InvalidAttributes; // définit les attributs invalides pour ce type d'objet
    internal int _ValidAccess; // 
    internal byte _Unknown;
    internal ushort _MaintainHandleDatabase;  // 
    internal NativeEnums.PoolType _PoolType;  // type de pool utilisé par l'objet
    internal int _PagedPoolUsage; // paged pool utilisé
    internal int _NonPagedPoolUsage; // non-paged pool utilisé



    public string Key
    {
        get
        {
            return _ProcessID.ToString() + "-" + _Handle.ToString();
        }
    }

    public int ProcessId
    {
        get
        {
            return _ProcessID;
        }
    }
    public IntPtr Handle
    {
        get
        {
            return _Handle;
        }
    }
    public string Type
    {
        get
        {
            return _NameInformation;
        }
    }
    public string Name
    {
        get
        {
            return _ObjectName;
        }
    }
    public int HandleCount
    {
        get
        {
            return _HandleCount;
        }
    }
    public uint PointerCount
    {
        get
        {
            return _PointerCount;
        }
    }
    public int ObjectCount
    {
        get
        {
            return _ObjectCount;
        }
    }
    public IntPtr ObjectAddress
    {
        get
        {
            return _ObjectAddress;
        }
    }
    public Native.Security.StandardRights GrantedAccess
    {
        get
        {
            return _GrantedAccess;
        }
    }
    public NativeEnums.HandleFlags Attributes
    {
        get
        {
            return _Attributes;
        }
    }
    public decimal CreateTime
    {
        get
        {
            return _CreateTime;
        }
    }
    public int PagedPoolUsage
    {
        get
        {
            return _PagedPoolUsage;
        }
    }
    public int NonPagedPoolUsage
    {
        get
        {
            return _NonPagedPoolUsage;
        }
    }
    public int ObjectTypeNumber
    {
        get
        {
            return _ObjectTypeNumber;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Merge an old and a new instance
    public handleInfos()
    {
    }
    public void Merge(ref handleInfos newI)
    {
        {
            var withBlock = newI;
            _Handle = withBlock.Handle;
            _HandleCount = withBlock.HandleCount;
            _ObjectName = withBlock.Name;
            _ObjectCount = withBlock.ObjectCount;
            _PointerCount = withBlock.PointerCount;
            _ProcessID = withBlock.ProcessId;
            _NameInformation = withBlock.Type;
            _ObjectTypeNumber = withBlock.ObjectTypeNumber;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[12];

        s[0] = "Name";
        s[1] = "HandleCount";
        s[2] = "PointerCount";
        s[3] = "ObjectCount";
        s[4] = "Process";
        s[5] = "ObjectAddress";
        s[6] = "GrantedAccess";
        s[7] = "Attributes";
        s[8] = "CreateTime";
        s[9] = "PagedPoolUsage";
        s[10] = "NonPagedPoolUsage";
        s[11] = "ObjectTypeNumber";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Type";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

