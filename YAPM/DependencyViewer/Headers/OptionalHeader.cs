
/// <summary>

/// Entкte optionnel d'un fichier PE

/// </summary>

/// <remarks></remarks>
public class OptionalHeader
{
    // version du linker
    public byte MajorLinkerVersion;
    public byte MinorLinkerVersion;
    // taille du code et des donnйes
    public int SizeOfCode;
    public int SizeOfInitializedData;
    public int SizeOfUninitializedData;
    // adresse du point d'entrйe
    public int AddressOfEntryPoint;
    // adresse du code et des donnйes
    public int BaseOfCode;
    public int BaseOfData;

    internal OptionalHeader(System.IO.BinaryReader PEReader)
    {
        this.MajorLinkerVersion = PEReader.ReadByte();
        this.MinorLinkerVersion = PEReader.ReadByte();
        this.SizeOfCode = PEReader.ReadInt32();
        this.SizeOfInitializedData = PEReader.ReadInt32();
        this.SizeOfUninitializedData = PEReader.ReadInt32();
        this.AddressOfEntryPoint = PEReader.ReadInt32();
        this.BaseOfCode = PEReader.ReadInt32();
        this.BaseOfData = PEReader.ReadInt32();
    }
}

