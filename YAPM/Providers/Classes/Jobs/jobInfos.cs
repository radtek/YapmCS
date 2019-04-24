using System.Collections.Generic;
using System;
using Native.Api;

[Serializable()]
public class jobInfos : generalInfos
{
    private string _name;

    // Stats structs
    private NativeStructs.JobObjectBasicAndIoAccountingInformation basicAcIoInfo;
    private NativeStructs.JobObjectBasicLimitInformation basicLimitInfo;

    // Contains list of process Id of the job
    private List<int> _procIds = new List<int>();



    public string Name
    {
        get
        {
            return _name;
        }
    }
    public NativeStructs.JobObjectBasicAndIoAccountingInformation BasicAndIoAccountingInformation
    {
        get
        {
            return basicAcIoInfo;
        }
    }
    public NativeStructs.JobObjectBasicLimitInformation BasicLimitInformation
    {
        get
        {
            return basicLimitInfo;
        }
    }
    public List<int> PidList
    {
        get
        {
            return _procIds;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public jobInfos()
    {
    }
    public jobInfos(string name)
    {
        _name = name;
    }

    // Refresh infos
    // Only called for local enumeration (so we do not need to check ConnectionType)
    public void Refresh()
    {
        // Here we refreh all informations about the job
        Dictionary<string, processInfos> _dico = Native.Objects.Job.GetProcessesInJobByName(Name);
        List<int> tmpProcIds = new List<int>();
        foreach (processInfos cp in _dico.Values)
            tmpProcIds.Add(cp.ProcessId);
        _procIds = tmpProcIds;
        basicAcIoInfo = Native.Objects.Job.GetJobBasicAndIoAccountingInformationByName(Name);
        basicLimitInfo = Native.Objects.Job.GetJobBasicLimitInformationByName(Name);
    }

    // Merge an old and a new instance
    public void Merge(ref jobInfos newI)
    {
        {
            var withBlock = newI;
            _procIds = withBlock.PidList;
            basicAcIoInfo = withBlock.BasicAndIoAccountingInformation;
            basicLimitInfo = withBlock.BasicLimitInformation;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[1];

        s[0] = "ProcessesCount";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Name";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

