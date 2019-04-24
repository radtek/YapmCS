
/// <summary>

/// Type de sous systиme NT attendu par l'exйcutable

/// </summary>

/// <remarks></remarks>
public enum NTSubSystem
{
    IMAGE_SUBSYSTEM_UNKNOWN = 0,
    IMAGE_SUBSYSTEM_NATIVE = 1,
    IMAGE_SUBSYSTEM_WINDOWS_GUI = 2,
    IMAGE_SUBSYSTEM_WINDOWS_CUI = 3,
    IMAGE_SUBSYSTEM_POSIX_CUI = 7,
    IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9,
    IMAGE_SUBSYSTEM_EFI_APPLICATION = 10,
    IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11,
    IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12
}

/// <summary>

/// Caractйristique d'un exйcutable

/// </summary>

/// <remarks></remarks>
public enum DLLCharacteristic
{
    IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x800,
    IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,
    IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000
}

/// <summary>

/// Entкte du sous sytиme NT

/// </summary>

/// <remarks></remarks>
public class NTHeader
{
    // base des adresses virtuelles relatives
    public int ImageBase;
    // alignements
    public int SectionAlignment;
    public int FileAlignment;
    // systиme d'exploitation cible
    public short MajorOperatingSystemVersion;
    public short MinorOperatingSystemVersion;
    // version de l'image de l'exйcutable
    public short MajorImageVersion;
    public short MinorImageVersion;
    // version du sous systиme cible
    public short MajorSubsystemVersion;
    public short MinorSubsystemVersion;
    // taille de l'image et des entкtes
    public int SizeOfImage;
    public int SizeOfHeaders;
    // checksum
    public int CheckSum;
    // sous systиme
    public NTSubSystem Subsystem;
    // caractйristiques
    public DLLCharacteristic DLLCharacteristics;
    // taille des piles et tas
    public int SizeOfStackReserve;
    public int SizeOfStackCommit;
    public int SizeOfHeapReserve;
    public int SizeOfHeapCommit;
    // flags
    public int LoaderFlags;
    public int NumberOfRvaAndSizes;

    internal NTHeader(System.IO.BinaryReader PEReader)
    {
        this.ImageBase = PEReader.ReadInt32();
        this.SectionAlignment = PEReader.ReadInt32();
        this.FileAlignment = PEReader.ReadInt32();
        this.MajorOperatingSystemVersion = PEReader.ReadInt16();
        this.MinorOperatingSystemVersion = PEReader.ReadInt16();
        this.MajorImageVersion = PEReader.ReadInt16();
        this.MinorImageVersion = PEReader.ReadInt16();
        this.MajorSubsystemVersion = PEReader.ReadInt16();
        this.MinorSubsystemVersion = PEReader.ReadInt16();
        PEReader.BaseStream.Position += 4;
        this.SizeOfImage = PEReader.ReadInt32();
        this.SizeOfHeaders = PEReader.ReadInt32();
        this.CheckSum = PEReader.ReadInt32();
        this.Subsystem = (NTSubSystem)PEReader.ReadInt16();
        this.DLLCharacteristics = (DLLCharacteristic)PEReader.ReadInt16();
        this.SizeOfStackReserve = PEReader.ReadInt32();
        this.SizeOfStackCommit = PEReader.ReadInt32();
        this.SizeOfHeapReserve = PEReader.ReadInt32();
        this.SizeOfHeapCommit = PEReader.ReadInt32();
        this.LoaderFlags = PEReader.ReadInt32();
        this.NumberOfRvaAndSizes = PEReader.ReadInt32();
    }
}

