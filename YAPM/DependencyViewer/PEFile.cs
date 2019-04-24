using System.Collections.Generic;
using System;

/// <summary>

/// type de machine cible de l'image exйcutable PE

/// </summary>

/// <remarks></remarks>
public enum Machine
{
    IMAGE_FILE_MACHINE_UNKNOWN = 0x0,
    IMAGE_FILE_MACHINE_ALPHA = 0x184,
    IMAGE_FILE_MACHINE_ARM = 0x1C0,
    IMAGE_FILE_MACHINE_ALPHA64 = 0x284,
    IMAGE_FILE_MACHINE_I386 = 0x14C,
    IMAGE_FILE_MACHINE_IA64 = 0x200,
    IMAGE_FILE_MACHINE_M68K = 0x268,
    IMAGE_FILE_MACHINE_MIPS16 = 0x266,
    IMAGE_FILE_MACHINE_MIPSFPU = 0x366,
    IMAGE_FILE_MACHINE_MIPSFPU16 = 0x466,
    IMAGE_FILE_MACHINE_POWERPC = 0x1F0,
    IMAGE_FILE_MACHINE_R3000 = 0x162,
    IMAGE_FILE_MACHINE_R4000 = 0x166,
    IMAGE_FILE_MACHINE_R10000 = 0x168,
    IMAGE_FILE_MACHINE_SH3 = 0x1A2,
    IMAGE_FILE_MACHINE_SH4 = 0x1A6,
    IMAGE_FILE_MACHINE_THUMB = 0x1C2
}

/// <summary>

/// caractйristique de l'image exйcutable PE

/// </summary>

/// <remarks></remarks>
public enum Characteristic
{
    IMAGE_FILE_RELOCS_STRIPPED = 0x1,
    IMAGE_FILE_EXECUTABLE_IMAGE = 0x2,
    IMAGE_FILE_LINE_NUMS_STRIPPED = 0x4,
    IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x8,
    IMAGE_FILE_AGGRESSIVE_WS_TRIM = 0x10,
    IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x20,
    IMAGE_FILE_16BIT_MACHINE = 0x40,
    IMAGE_FILE_BYTES_REVERSED_LO = 0x80,
    IMAGE_FILE_32BIT_MACHINE = 0x100,
    IMAGE_FILE_DEBUG_STRIPPED = 0x200,
    IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x400,
    IMAGE_FILE_SYSTEM = 0x1000,
    IMAGE_FILE_DLL = 0x2000,
    IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000,
    IMAGE_FILE_BYTES_REVERSED_HI = 0x8000
}

public class PEFile
{
    // contenu binaire du fichier PE
    private System.IO.BinaryReader PEReader;
    // dйplacement dans le fichier PE
    private void Seek(int dwPosition)
    {
        PEReader.BaseStream.Position = dwPosition;
    }
    private void SeekRelative(int dwOffset)
    {
        PEReader.BaseStream.Position += dwOffset;
    }

    private Machine m_Machine;
    /// <summary>
    /// Architecture cible du fichier PE
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public Machine Machine
    {
        get
        {
            return m_Machine;
        }
    }

    private DateTime m_TimeStamp;
    /// <summary>
    /// Date de crйation de ce fichier PE
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public DateTime TimeStamp
    {
        get
        {
            return m_TimeStamp;
        }
    }

    private Characteristic m_Characteristics;
    /// <summary>
    /// Caractйristiques de l'image exйcutable PE
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public Characteristic Characteristics
    {
        get
        {
            return m_Characteristics;
        }
    }

    /// <summary>
    /// Structure d'une table contenant par exemple, les imports ou les exports
    /// </summary>
    /// <remarks></remarks>
    public struct IMAGE_DATA_DIRECTORY
    {
        public int RVA;
        public int Size;
    }

    private List<Section> m_Sections = new List<Section>();
    /// <summary>
    /// Liste des sections de l'exйcutable (data, rsrc, code)
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public List<Section> Sections
    {
        get
        {
            return m_Sections;
        }
    }

    private List<IMAGE_DATA_DIRECTORY> Directories = new List<IMAGE_DATA_DIRECTORY>();
    /// <summary>
    /// Table d'export
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY ExportTable
    {
        get
        {
            return Directories[0];
        }
    }
    /// <summary>
    /// Table d'import contenant les noms des imports
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY ImportTable
    {
        get
        {
            return Directories[1];
        }
    }
    /// <summary>
    /// Table des resources
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY ResourceTable
    {
        get
        {
            return Directories[2];
        }
    }
    /// <summary>
    /// Table des gestionnaire d'exception
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY ExceptionTable
    {
        get
        {
            return Directories[3];
        }
    }
    /// <summary>
    /// Table de signature numйrique
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY CertificateTable
    {
        get
        {
            return Directories[4];
        }
    }
    /// <summary>
    /// Table des adresses relatives des imports
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY ImportAddressTable
    {
        get
        {
            return Directories[12];
        }
    }
    /// <summary>
    /// Table des imports qui ne sont pas chargй tout de suite au chargement de l'exйcutable
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public IMAGE_DATA_DIRECTORY DelayImportDescriptor
    {
        get
        {
            return Directories[13];
        }
    }

    /// <summary>
    /// Convertit un time_t (dйcompte en secondes depuis 01/01/1970 en DateTime
    /// </summary>
    /// <param name="time_t"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime Time_T2DateTime(UInt32 time_t)
    {
        long win32FileTime = 10000000L * time_t + 116444736000000000L;
        return DateTime.FromFileTimeUtc(win32FileTime);
    }

    /// <summary>
    /// Lit les entкtes et les sections
    /// </summary>
    /// <remarks></remarks>
    private void ReadHeadersAndSections()
    {
        // on rйcupиre l'offset de l'entкte PE а l'offset 0x3C
        Seek(0x3);
        Seek(PEReader.ReadInt32());
        // on rйcupиre l'entкte PE
        SeekRelative(4);
        m_Machine = (Machine)PEReader.ReadInt16();
        int NumberOfSections = PEReader.ReadInt16();
        m_TimeStamp = Time_T2DateTime(PEReader.ReadUInt32());

        SeekRelative(4 + 4 + 4);
        short MagicPE = PEReader.ReadInt16();

        // si PE
        if (MagicPE == 0x10B)
        {
            // l'entкte optionelle
            m_OptionalHeader = new OptionalHeader(PEReader);
            // l'entкte NT
            m_NTHeader = new NTHeader(PEReader);
        }
        else
            // ne supporte pas PE+
            throw new NotSupportedException();
        var loopTo = this.NTHeader.NumberOfRvaAndSizes - 1;

        // les dossiers
        for (int i = 0; i <= loopTo; i++)
        {
            IMAGE_DATA_DIRECTORY ImageDir = new IMAGE_DATA_DIRECTORY();
            ImageDir.RVA = PEReader.ReadInt32();
            ImageDir.Size = PEReader.ReadInt32();
            this.Directories.Add(ImageDir);
        }

        var loopTo1 = NumberOfSections - 1;
        // les sections
        for (int i = 0; i <= loopTo1; i++)
            this.Sections.Add(new Section(PEReader));
    }

    private OptionalHeader m_OptionalHeader;
    /// <summary>
    /// Entкte optionnelle
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public OptionalHeader OptionalHeader
    {
        get
        {
            return m_OptionalHeader;
        }
    }
    private NTHeader m_NTHeader;
    /// <summary>
    /// Entкte NT
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public NTHeader NTHeader
    {
        get
        {
            return m_NTHeader;
        }
    }

    private ExportDirectory m_ExportDirectory;
    /// <summary>
    /// Renvoie les exports de l'exйcutable
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public ExportDirectory ExportDirectory
    {
        get
        {
            return m_ExportDirectory;
        }
    }
    private ImportDirectory m_ImportDirectory;
    /// <summary>
    /// Renvoie les imports de l'exйcutable
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public ImportDirectory ImportDirectory
    {
        get
        {
            return m_ImportDirectory;
        }
    }

    /// <summary>
    /// Rйcupиre des informations sur un fichier exe, dll, ocx
    /// </summary>
    /// <param name="szFileName">nom du fichier а analyser</param>
    /// <remarks></remarks>
    private void Init(ref string szFileName)
    {
        // on ouvre le fichier en mode binaire pour lire
        PEReader = new System.IO.BinaryReader(new System.IO.FileStream(szFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read));

        // on recopie les infos de l'entкte PE, l'entкte optionnelle PE et l'entкte NT
        ReadHeadersAndSections();

        // les exports de l'exйcutable
        this.m_ExportDirectory = new ExportDirectory(this, PEReader);

        // les imports de l'exйcutable
        this.m_ImportDirectory = new ImportDirectory(this, PEReader);

        PEReader.Close();
    }

    /// <summary>
    /// Convertit une adresse virtuelle relative en un offset depuis le dйbut du fichier
    /// </summary>
    /// <param name="dwRVA">(Relative Virtual Address) adresse virtuelle relative а convertir</param>
    /// <returns>Offset dans le fichier exйcutable</returns>
    /// <remarks></remarks>
    public int RVA2Offset(int dwRVA)
    {
        var loopTo = this.Sections.Count - 1;
        // pour chaque section
        for (int i = 0; i <= loopTo; i++)
        {
            // si l'adresse virtuelle se trouve dans la plage des adresses virtuelles de la sections
            if ((dwRVA >= this.Sections[i].VirtualAddress) & (dwRVA < (this.Sections[i].VirtualAddress + this.Sections[i].VirtualSize)))
                // alors l'adresse virtuelle appartient а la section
                // l'offset est RVA - VA de base de la section + offset de la section
                // (+ 1 pour VB qui prend ses offsets а partir de 1)
                return dwRVA - this.Sections[i].VirtualAddress + this.Sections[i].PointerToRawData;
        }
        return 0;
    }


    private string m_FileName;
    /// <summary>
    /// Nom du fichier exйcutable
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string FileName
    {
        get
        {
            return m_FileName;
        }
    }

    /// <summary>
    /// Rйcupиre les informations du fichier exйcutable szFileName
    /// </summary>
    /// <param name="szFileName">Nom du fichier а analyser</param>
    /// <remarks></remarks>
    public PEFile(string szFileName)
    {
        this.m_FileName = szFileName;
        this.Init(ref szFileName);
    }
}

