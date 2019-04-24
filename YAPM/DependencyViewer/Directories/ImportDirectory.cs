using Microsoft.VisualBasic;
using System.Collections.Generic;

/// <summary>

/// Rйprйsente une entrйe d'import

/// </summary>

/// <remarks></remarks>
public struct ImportEntry
{
    public string Name;
    public int Ordinal;
    public int Address;
    public short Hint;
}

/// <summary>

/// Rйprйsente une dll importйe

/// </summary>

/// <remarks></remarks>
public struct DllImportEntry
{
    public string DllName;
    public List<ImportEntry> Entries;
}

/// <summary>

/// Rйprйsente le dossier d'import

/// </summary>

/// <remarks></remarks>
public class ImportDirectory
{
    /// <summary>
    /// Liste des dlls
    /// </summary>
    /// <remarks></remarks>
    public List<DllImportEntry> DllEntries = new List<DllImportEntry>();

    /// <summary>
    /// Rйprйsente une entrйe de dossier d'import
    /// </summary>
    /// <remarks></remarks>
    public struct RawImportDirectoryEntry
    {
        public int ImportLookupTableRVA;
        public int TimeDateStamp;
        public int FowarderChain;
        public int NameRVA;
        public int ImportAddressTableRVA;
    }

    /// <summary>
    /// Rйcupиre les informations sur les imports
    /// </summary>
    /// <param name="pe">fichier PE</param>
    /// <param name="PEReader">donnйes binaire du fichier PE</param>
    /// <remarks></remarks>
    internal ImportDirectory(PEFile pe, System.IO.BinaryReader PEReader)
    {
        // s'il y a un dossier Import
        if (pe.ImportTable.RVA != 0)
        {
            int indexImport = 0;
            // tant que l'on a une dll importйe
            do
            {
                // entrйe d'import suivante
                PEReader.BaseStream.Position = pe.RVA2Offset(pe.ImportTable.RVA) + indexImport * 20;

                // on rйcupиre les infos sur chaque Dll importйe
                int importLookupTableRVA = PEReader.ReadInt32();
                PEReader.BaseStream.Position += 4;
                int forwarderChain = PEReader.ReadInt32();
                int nameRVA = PEReader.ReadInt32();
                int importAddressTableRVA = PEReader.ReadInt32();

                // si on est а la fin de la table des imports
                if ((forwarderChain == 0) && (importAddressTableRVA == 0) && (importLookupTableRVA == 0) && (nameRVA == 0))
                    break;
                DllImportEntry DllImport = new DllImportEntry();

                // le nom de dll
                PEReader.BaseStream.Position = pe.RVA2Offset(nameRVA);
                byte c;
                System.Text.StringBuilder sbDllName = new System.Text.StringBuilder();
                do
                {
                    c = PEReader.ReadByte();
                    if (c != 0)
                        sbDllName.Append((char)c);
                }
                while (c != 0);
                DllImport.DllName = sbDllName.ToString();
                DllImport.Entries = new List<ImportEntry>();
                List<int> importLookupTable = new List<int>();
                // la table de nom
                PEReader.BaseStream.Position = pe.RVA2Offset(importLookupTableRVA);
                do
                {
                    int lookupEntryRVA = PEReader.ReadInt32();
                    if (lookupEntryRVA == 0)
                        break;
                    importLookupTable.Add(lookupEntryRVA);
                }
                while (true);
                List<int> importAddressTable = new List<int>();
                // la table d'adresse
                PEReader.BaseStream.Position = pe.RVA2Offset(importAddressTableRVA);
                do
                {
                    int addressEntryRVA = PEReader.ReadInt32();
                    if (addressEntryRVA == 0)
                        break;
                    importAddressTable.Add(addressEntryRVA);
                }
                while (true);
                var loopTo = importAddressTable.Count - 1;

                // pour chaque fonction importйe dans la dll
                for (int i = 0; i <= loopTo; i++)
                {
                    int lookupEntry = importLookupTable[i];
                    int addressEntry = importAddressTable[i];
                    ImportEntry importEntry = new ImportEntry();
                    // si l'import est par ordinal
                    if ((lookupEntry & 0x80000000) == 0x80000000)
                    {
                        importEntry.Ordinal = (lookupEntry & 0x7FFFFFFF);
                        importEntry.Name = Constants.vbNullString;
                        importEntry.Hint = System.Convert.ToInt16(i);
                    }
                    else
                    {
                        int importNameAddress = lookupEntry & 0x7FFFFFFF;
                        PEReader.BaseStream.Position = pe.RVA2Offset(importNameAddress);
                        importEntry.Hint = PEReader.ReadInt16();
                        System.Text.StringBuilder sbImportName = new System.Text.StringBuilder();
                        do
                        {
                            c = PEReader.ReadByte();
                            if (c != 0)
                                sbImportName.Append((char)c);
                        }
                        while (c != 0);
                        importEntry.Name = sbImportName.ToString();
                        importEntry.Ordinal = 0;
                    }
                    // et l'adresse dans tous les cas
                    importEntry.Address = pe.RVA2Offset(addressEntry);
                    DllImport.Entries.Add(importEntry);
                }

                this.DllEntries.Add(DllImport);
                // entrйe suivante
                indexImport += 1;
            }
            while (true);
        }
    }
}

