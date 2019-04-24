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
        public static bool EnumerateJobs(ManagementObjectSearcher objSearcher,
            ref Dictionary<string, jobInfos> dico, ref string errMsg)
        {
            ManagementObjectCollection res;
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
            foreach (var o in res)
            {
                var refJob = (ManagementObject) o;
                // Job name
                var jobName =
                    Convert.ToString(refJob.GetPropertyValue(Enums.WmiInfoJob.CollectionID.ToString()));

                // TODO : have to retrieve ProcessesCount ?

                if (dico.ContainsKey(jobName) == false)
                    dico.Add(jobName, new jobInfos(jobName));
            }

            return true;
        }
    }
}