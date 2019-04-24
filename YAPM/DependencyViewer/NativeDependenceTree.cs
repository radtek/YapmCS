using System.Collections.Generic;
using System;

/// <summary>

/// Reprйsente l'arborescence des dйpendances d'un exйcutable

/// </summary>

/// <remarks></remarks>
public class NativeDependenciesTree
{
    /// <summary>
    /// Une dll et ses dйpendences
    /// </summary>
    /// <remarks></remarks>
    public class NativeDependency
    {
        // liste des dll dйjа trouvйes
        private static Dictionary<string, NativeDependency> Cache = new Dictionary<string, NativeDependency>();

        private PEFile m_PE;
        /// <summary>
        /// Renvoie les informations du fichier PE
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public PEFile PE
        {
            get
            {
                return m_PE;
            }
        }

        private bool m_Resolved;
        /// <summary>
        /// Indique si le dll a йtй trouvйe
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Resolved
        {
            get
            {
                return m_Resolved;
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "LoadLibraryA")]
        private static extern IntPtr LoadLibrary(string lpLibFileName);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int FreeLibrary(IntPtr hLibModule);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "GetModuleFileNameA")]
        private static extern int GetModuleFileName(IntPtr hModule, System.Text.StringBuilder lpFileName, int nSize);
        /// <summary>
        /// Renvoie le chemin complet d'une dll (en la chargeant et la dйchargeant)
        /// </summary>
        /// <param name="szFileName">nom relatif de la dll</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ResolveDll(string szFileName)
        {
            // charge la dll
            IntPtr hModule = LoadLibrary(szFileName);
            if ((hModule.IsNotNull()))
            {
                // rйcupиre le nom complet de la dll
                System.Text.StringBuilder sbFileName = new System.Text.StringBuilder(1024);
                int retLen = GetModuleFileName(hModule, sbFileName, 1024);
                // libиre la dll
                FreeLibrary(hModule);
                if (retLen > 0)
                    return sbFileName.ToString(0, retLen);
                else
                    return null;
            }
            else
                return null;
        }

        private string m_FileName;
        /// <summary>
        /// renvoie le nom de la dll
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
        /// essaie de rйcupйrer les infos sur le fichier PE passй en argument
        /// </summary>
        /// <param name="szFileName">nom de la dll (absolu ou relatif)</param>
        /// <remarks></remarks>
        internal NativeDependency(string szFileName)
        {
            string fFile = szFileName;
            // si pas absolu
            if (!System.IO.Path.IsPathRooted(szFileName))
                // on essaie de rйsoudre
                fFile = ResolveDll(szFileName);

            m_FileName = szFileName;

            if (fFile != null && System.IO.File.Exists(fFile))
            {
                // si on a toruvй, on rйcupиre les infos
                this.m_Resolved = true;
                m_PE = new PEFile(fFile);
            }
            else
                this.m_Resolved = false;
        }

        private List<NativeDependency> m_Dependencies = null;
        public IEnumerable<NativeDependency> Dependencies
        {
            get
            {
                // rйcupиre les infos sur la liste des dйpendances "а la demande"
                if (this.PE != null && m_Dependencies == null)
                {
                    m_Dependencies = new List<NativeDependency>();
                    // pour chaque dll importйe
                    foreach (DllImportEntry i in this.PE.ImportDirectory.DllEntries)
                    {
                        // si pas dйjа rencontrй, on l'ajoute au cache des "trouvйes"
                        if (!Cache.ContainsKey(i.DllName))
                            Cache.Add(i.DllName, new NativeDependency(i.DllName));
                        this.m_Dependencies.Add(Cache[i.DllName]);
                    }
                }
                return m_Dependencies;
            }
        }
    }

    private NativeDependency m_MainDll;
    /// <summary>
    /// Dll racine de l'arborescence reprйsentйe
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public NativeDependency MainDll
    {
        get
        {
            return m_MainDll;
        }
    }

    /// <summary>
    /// Rйcupиre les dйpendences d'un exйcutable
    /// </summary>
    /// <param name="szFileName"></param>
    /// <remarks></remarks>
    public NativeDependenciesTree(string szFileName)
    {
        this.m_MainDll = new NativeDependency(szFileName);
    }

    /// <summary>
    /// Rйcupиre rйcursivement les dйpendances
    /// </summary>
    /// <param name="allDeps">liste de toutes le dйpendances</param>
    /// <param name="dep">dйpendance а traiter</param>
    /// <remarks></remarks>
    private void ProcessDependencies(List<NativeDependency> allDeps, NativeDependency dep)
    {
        // ajoute la dll а la liste des dйpendances
        allDeps.Add(dep);
        // si on a toruvй la dll
        if (dep.Resolved)
        {
            // pour chaque dйpendance direct
            foreach (NativeDependency natDep in dep.Dependencies)
            {
                // si l'on n'a pas dйjа la dll dans la liste
                if (!allDeps.Contains(natDep))
                    this.ProcessDependencies(allDeps, natDep);
            }
        }
    }
    /// <summary>
    /// Rйcupиre l'ensemble des dйpendances d'un exйcutable
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public IEnumerable<NativeDependency> GetAllDependencies()
    {
        List<NativeDependency> l = new List<NativeDependency>();
        this.ProcessDependencies(l, this.MainDll);
        return l;
    }
}

