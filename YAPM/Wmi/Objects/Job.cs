using System.Collections.Generic;
using System;
using Native.Api;
using System.Management;

namespace Wmi.Objects
{
    public class Job
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

        // Enumerate services
        public static bool EnumerateJobs(System.Management.ManagementObjectSearcher objSearcher, ref Dictionary<string, jobInfos> _dico, ref string errMsg)
        {
            ManagementObjectCollection res = null;
            try
            {
                res = objSearcher.Get();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

            // For each job...
            foreach (System.Management.ManagementObject refJob in res)
            {

                // Job name
                string jobName = System.Convert.ToString(refJob.GetPropertyValue(Enums.WmiInfoJob.CollectionID.ToString()));

                // TODO : have to retrieve ProcessesCount ?

                if (_dico.ContainsKey(jobName) == false)
                    _dico.Add(jobName, new jobInfos(jobName));
            }

            return true;
        }
    }
}

