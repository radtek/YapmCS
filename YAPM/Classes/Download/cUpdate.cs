using Microsoft.VisualBasic;
using System.Xml;
using System;

public class cUpdate
{


    // ========================================
    // Private constants
    // ========================================


    // ========================================
    // Private attributes
    // ========================================


    // ========================================
    // Public properties
    // ========================================


    // ========================================
    // Other public
    // ========================================

    // Structure for new versions
    public struct NewReleaseInfos
    {
        public string Infos;
        public string Url;
        public string Hash;
        public string Version;
        public string Description;
        public string Type;
        public string Caption;
        public string Date;
        public NewReleaseInfos(string aInfos, string aUrl, string aHash)
        {
            Infos = aInfos;
            Url = aUrl;
            Hash = aHash;
        }
    }

    // Event raised when a new update is available
    public event NewVersionAvailableEventHandler NewVersionAvailable;

    public delegate void NewVersionAvailableEventHandler(bool silent, NewReleaseInfos release);

    // Event raised when no new update is available
    public event ProgramUpToDateEventHandler ProgramUpToDate;

    public delegate void ProgramUpToDateEventHandler(bool silent);

    // Event raised when failed to retrieve last version
    public event FailedToCheckVersionEventHandler FailedToCheckVersion;

    public delegate void FailedToCheckVersionEventHandler(bool silent, string msg);


    // ========================================
    // Public functions
    // ========================================

    // Check if YAPM is up to date
    // This is async. and will raise events.
    public void CheckUpdates(bool silentMode)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(pvtCheckUpdates, silentMode);
    }



    // ========================================
    // Private functions
    // ========================================

    // Check updates (sync. version)
    private void pvtCheckUpdates(object context)
    {
        bool silentMode = System.Convert.ToBoolean(context);

        NewReleaseInfos newRelease = default(NewReleaseInfos);
        NewReleaseInfos newReleaseL = default(NewReleaseInfos);
        bool upToDate = true;
        string xmlContent;
        int curVersion = getCurrentVersion();

        // Download the XML file
        System.Net.WebClient cl = new System.Net.WebClient();
        try
        {
            xmlContent = cl.DownloadString(My.MySettingsProperty.Settings.UpdateServer);
        }
        // Debug line :             xmlContent = System.IO.File.ReadAllText("C:\Users\Admin\Desktop\YAPM\Website\update.xml")
        catch (Exception ex)
        {
            FailedToCheckVersion?.Invoke(silentMode, ex.Message);
            return;
        }

        // Parse XML and extract version string
        int lastVersion = 0;
        string updHash = null;
        string updDescription = null;
        string updCaption = null;
        string updUurl = null;
        string updDate = null;
        string updVersion = null;
        string updType = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList updates;
            xmlDoc.LoadXml(xmlContent);
            updates = xmlDoc.DocumentElement.GetElementsByTagName("update");
            foreach (XmlNode update in updates)
            {

                // Retrieve type of update (stable, beta or alpha)
                string sType = update.Attributes["type"].InnerText.ToLowerInvariant();
                if (sType == "stable" || (sType == "alpha" && My.MySettingsProperty.Settings.UpdateAlpha) || (sType == "beta" && My.MySettingsProperty.Settings.UpdateBeta))
                {
                    string _updHash = null;
                    string _updDescription = null;
                    string _updCaption = null;
                    string _updUurl = null;
                    string _updDate = null;
                    string _updVersion = null;

                    // Now retrieve informations about the update
                    foreach (XmlNode childNode in update.ChildNodes)
                    {
                        if (childNode.LocalName.ToLowerInvariant() == "caption")
                            _updCaption = childNode.InnerText;
                        else if (childNode.LocalName.ToLowerInvariant() == "hash")
                            _updHash = childNode.InnerText;
                        else if (childNode.LocalName.ToLowerInvariant() == "description")
                            _updDescription = childNode.InnerText;
                        else if (childNode.LocalName.ToLowerInvariant() == "date")
                            _updDate = childNode.InnerText;
                        else if (childNode.LocalName.ToLowerInvariant() == "version")
                            _updVersion = childNode.InnerText;
                        else if (childNode.LocalName.ToLowerInvariant() == "downloadurl")
                            _updUurl = childNode.InnerText;
                    }

                    // We compare lastVersion and the version of this update
                    int i = getVersionNumberFromString(_updVersion);
                    if (i > lastVersion)
                    {
                        lastVersion = i;
                        updHash = _updHash;
                        updDescription = _updDescription;
                        updCaption = _updCaption;
                        updUurl = _updUurl;
                        updDate = _updDate;
                        updVersion = _updVersion;
                        updType = sType;
                    }
                }

                // If we get a version, exit the loop (we only retrieve ONE version)
                if (string.IsNullOrEmpty(updVersion) == false)
                    break;
            }
        }
        catch (Exception ex)
        {
            FailedToCheckVersion?.Invoke(silentMode, "Failed to parse version file : " + ex.Message);
            return;
        }


        // Compare more up-to-date version from XML with current version
        string sInfos = "";
        string sInfosL = "";
        if (lastVersion > curVersion)
        {
            upToDate = false;
            sInfosL = "New version : " + updVersion + Constants.vbNewLine + "Release date : " + updDate + Constants.vbNewLine;
            sInfos = sInfosL + Constants.vbNewLine + "Description : " + updDescription;
            newRelease = new NewReleaseInfos(sInfos, updUurl, updHash);
            newReleaseL = new NewReleaseInfos(sInfosL, updUurl, updHash);
            {
                var withBlock = newRelease;
                withBlock.Type = updType;
                withBlock.Version = updVersion;
                withBlock.Caption = updCaption;
                withBlock.Date = updDate;
                withBlock.Description = updDescription;
            }
        }


        // Raise event
        if (silentMode)
        {
            if (upToDate == false)
                NewVersionAvailable?.Invoke(silentMode, newReleaseL);
        }
        else if (upToDate)
            ProgramUpToDate?.Invoke(silentMode);
        else
            NewVersionAvailable?.Invoke(silentMode, newRelease);
    }

    // Return a version number from a version string
    // Ex : 2.2.1 returns 2210
    private int getVersionNumberFromString(string version)
    {
        try
        {
            string[] s = version.Split(System.Convert.ToChar("."));
            int l = s.Length;
            int res = 0;
            var loopTo = l - 1;
            for (int x = 0; x <= loopTo; x++)
                res += System.Convert.ToInt32(int.Parse(s[x]) * Math.Pow(10, (l - x + 1)));
            return res;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    // Return current assembly version as a version number
    private int getCurrentVersion()
    {
        string sVersion = My.MyProject.Application.Info.Version.Major + "." + My.MyProject.Application.Info.Version.Minor + "." + My.MyProject.Application.Info.Version.Build + "." + My.MyProject.Application.Info.Version.Revision;
        return getVersionNumberFromString(sVersion);
    }
}

