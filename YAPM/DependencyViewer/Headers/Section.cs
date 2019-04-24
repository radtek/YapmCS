
// caractйristique d'une section
public enum SectionCharacteristics
{
    IMAGE_SCN_TYPE_REG = 0x0,
    IMAGE_SCN_TYPE_DSECT = 0x1,
    IMAGE_SCN_TYPE_NOLOAD = 0x2,
    IMAGE_SCN_TYPE_GROUP = 0x4,
    IMAGE_SCN_TYPE_NO_PAD = 0x8,
    IMAGE_SCN_TYPE_COPY = 0x10,
    IMAGE_SCN_CNT_CODE = 0x20,
    IMAGE_SCN_CNT_INITIALIZED_DATA = 0x40,
    IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x80,
    IMAGE_SCN_LNK_OTHER = 0x100,
    IMAGE_SCN_LNK_INFO = 0x200,
    IMAGE_SCN_TYPE_OVER = 0x400,
    IMAGE_SCN_LNK_REMOVE = 0x800,
    IMAGE_SCN_LNK_COMDAT = 0x1000,
    IMAGE_SCN_MEM_FARDATA = 0x8000,
    IMAGE_SCN_MEM_PURGEABLE = 0x20000,
    IMAGE_SCN_MEM_16BIT = 0x20000,
    IMAGE_SCN_MEM_LOCKED = 0x40000,
    IMAGE_SCN_MEM_PRELOAD = 0x80000,
    IMAGE_SCN_ALIGN_1BYTES = 0x100000,
    IMAGE_SCN_ALIGN_2BYTES = 0x200000,
    IMAGE_SCN_ALIGN_4BYTES = 0x300000,
    IMAGE_SCN_ALIGN_8BYTES = 0x400000,
    IMAGE_SCN_ALIGN_16BYTES = 0x500000,
    IMAGE_SCN_ALIGN_32BYTES = 0x600000,
    IMAGE_SCN_ALIGN_64BYTES = 0x700000,
    IMAGE_SCN_ALIGN_128BYTES = 0x800000,
    IMAGE_SCN_ALIGN_256BYTES = 0x900000,
    IMAGE_SCN_ALIGN_512BYTES = 0xA00000,
    IMAGE_SCN_ALIGN_1024BYTES = 0xB00000,
    IMAGE_SCN_ALIGN_2048BYTES = 0xC00000,
    IMAGE_SCN_ALIGN_4096BYTES = 0xD00000,
    IMAGE_SCN_ALIGN_8192BYTES = 0xE00000,
    IMAGE_SCN_LNK_NRELOC_OVFL = 0x1000000,
    IMAGE_SCN_MEM_DISCARDABLE = 0x2000000,
    IMAGE_SCN_MEM_NOT_CACHED = 0x4000000,
    IMAGE_SCN_MEM_NOT_PAGED = 0x8000000,
    IMAGE_SCN_MEM_SHARED = 0x10000000,
    IMAGE_SCN_MEM_EXECUTE = 0x20000000,
    IMAGE_SCN_MEM_READ = 0x40000000,
    IMAGE_SCN_MEM_WRITE = 0x80000000
}

public class Section
{
    // nom de la section
    public string Name;
    // taille et adresse virtuelle de la section
    public int VirtualSize;
    public int VirtualAddress;
    // taille brute dans le fichier PE
    public int SizeOfRawData;
    // pointeur vers les donnйes
    public int PointerToRawData;
    public int PointerToRelocations;
    public int PointerToLinenumbers;
    public short NumberOfRelocations;
    public short NumberOfLinenumbers;
    public SectionCharacteristics Characteristics;

    internal Section(System.IO.BinaryReader PEReader)
    {
        this.Name = System.Text.Encoding.ASCII.GetString(PEReader.ReadBytes(8));
        this.VirtualSize = PEReader.ReadInt32();
        this.VirtualAddress = PEReader.ReadInt32();
        this.SizeOfRawData = PEReader.ReadInt32();
        this.PointerToRawData = PEReader.ReadInt32();
        this.PointerToRelocations = PEReader.ReadInt32();
        this.PointerToLinenumbers = PEReader.ReadInt32();
        this.NumberOfRelocations = PEReader.ReadInt16();
        this.NumberOfLinenumbers = PEReader.ReadInt16();
        this.Characteristics = (SectionCharacteristics)PEReader.ReadInt32();
    }
}

