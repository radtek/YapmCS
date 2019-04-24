using System.Collections.Generic;
using System;

/// <summary>

/// Reprйsente une entrйe d'export

/// </summary>

/// <remarks></remarks>
public struct ExportEntry
{
    public string Name;
    public int Hint;
    public int Ordinal;
    public int ExportRVA;
}
/// <summary>

/// Reprйsente le dossier d'export complet

/// </summary>

/// <remarks></remarks>
public class ExportDirectory
{
    public string DllName;
    public int ExportFlags;
    public DateTime TimeDateStamp;
    public short MajorVersion;
    public short MinorVersion;
    public int NameRVA;
    public int OrdinalBase;
    public int AddressTableEntries;
    public int NumberofNamePointers;
    public int ExportAddressTableRVA;
    public int NamePointerRVA;
    public int OrdinalTableRVA;
    /// <summary>
    /// Fonctions exportйes
    /// </summary>
    /// <remarks></remarks>
    public List<ExportEntry> ExportEntries = new List<ExportEntry>();

    /// <summary>
    /// Reprйsente les donnйes brutes
    /// </summary>
    /// <remarks></remarks>
    public struct RawExportDirectory
    {
        public int ExportFlags;
        public int TimeDateStamp;
        public short MajorVersion;
        public short MinorVersion;
        public int NameRVA;
        public int OrdinalBase;
        public int AddressTableEntries;
        public int NumberofNamePointers;
        public int ExportAddressTableRVA;
        public int NamePointerRVA;
        public int OrdinalTableRVA;
    }

    /// <summary>
    /// Rйcupиre les informations sur les exports
    /// </summary>
    /// <param name="pe">fichier PE</param>
    /// <param name="PEReader">donnйes binaire du fichier PE</param>
    /// <remarks></remarks>
    internal ExportDirectory(PEFile pe, System.IO.BinaryReader PEReader)
    {
        // si le fichier contient un dossier Export
        if (pe.ExportTable.RVA != 0)
        {
            // on rйcupиre les infos
            PEReader.BaseStream.Position = pe.RVA2Offset(pe.ExportTable.RVA);
            this.ExportFlags = PEReader.ReadInt32();
            this.TimeDateStamp = PEFile.Time_T2DateTime(PEReader.ReadUInt32());
            this.MajorVersion = PEReader.ReadInt16();
            this.MinorVersion = PEReader.ReadInt16();
            this.NameRVA = PEReader.ReadInt32();
            this.OrdinalBase = PEReader.ReadInt32();
            this.AddressTableEntries = PEReader.ReadInt32();
            this.NumberofNamePointers = PEReader.ReadInt32();
            this.ExportAddressTableRVA = PEReader.ReadInt32();
            this.NamePointerRVA = PEReader.ReadInt32();
            this.OrdinalTableRVA = PEReader.ReadInt32();

            // la table des adresses
            PEReader.BaseStream.Position = pe.RVA2Offset(this.ExportAddressTableRVA);
            List<int> exportAddressTable = new List<int>();
            var loopTo = this.AddressTableEntries - 1;
            for (int i = 0; i <= loopTo; i++)
                exportAddressTable.Add(PEReader.ReadInt32());
            // la table des pointeurs de noms
            PEReader.BaseStream.Position = pe.RVA2Offset(this.NamePointerRVA);
            List<int> exportNameTable = new List<int>();
            var loopTo1 = this.NumberofNamePointers - 1;
            for (int i = 0; i <= loopTo1; i++)
                exportNameTable.Add(PEReader.ReadInt32());
            // la table des numйros d'ordre (ordinal)
            PEReader.BaseStream.Position = pe.RVA2Offset(this.OrdinalTableRVA);
            List<short> exportOrdinalTable = new List<short>();
            var loopTo2 = this.NumberofNamePointers - 1;
            for (int i = 0; i <= loopTo2; i++)
                exportOrdinalTable.Add(PEReader.ReadInt16());

            byte c;
            var loopTo3 = this.NumberofNamePointers - 1;

            // pour chaque export
            for (int i = 0; i <= loopTo3; i++)
            {
                ExportEntry entry = new ExportEntry();
                // on rйcupиre le nom
                PEReader.BaseStream.Position = pe.RVA2Offset(exportNameTable[i]);
                System.Text.StringBuilder sbEntryName = new System.Text.StringBuilder();
                do
                {
                    c = PEReader.ReadByte();
                    if (c != 0)
                        sbEntryName.Append((char)c);
                }
                while (c != 0);
                entry.Name = sbEntryName.ToString();
                // le numйro d'ordre
                entry.Ordinal = exportOrdinalTable[i] + this.OrdinalBase;
                // l'adresse
                entry.ExportRVA = exportAddressTable[entry.Ordinal - this.OrdinalBase];
                entry.Hint = i;
                this.ExportEntries.Add(entry);
            }

            // le nom de la dll
            PEReader.BaseStream.Position = pe.RVA2Offset(this.NameRVA);
            System.Text.StringBuilder sbDllName = new System.Text.StringBuilder();
            do
            {
                c = PEReader.ReadByte();
                if (c != 0)
                    sbDllName.Append((char)c);
            }
            while (c != 0);
            this.DllName = sbDllName.ToString();
        }
    }
}

