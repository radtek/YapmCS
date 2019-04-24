using System.Collections.Generic;
using System;
using System.Management;

namespace Wmi.Objects
{
    public class Module
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

        // Enumerate modules
        public static bool EnumerateModuleById(int pid, System.Management.ManagementObjectSearcher objSearcher, ref Dictionary<string, moduleInfos> _dico, ref string errMsg)
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


            // For Each refProcess As Management.ManagementObject In res
            // Dim colMod As ManagementObjectCollection = refProcess.GetRelationships("CIM_ProcessExecutable")
            // Dim _dicoBaseA As New Dictionary(Of String, Integer)
            // For Each refModule As ManagementObject In colMod
            // Dim _s As String = CStr(refModule.GetPropertyValue("Antecedent")).ToLowerInvariant
            // ' Extract dll path from _s
            // Dim i As Integer = InStr(_s, "name=", CompareMethod.Binary)
            // Dim __s As String = vbNullString
            // If i > 0 Then
            // __s = _s.Substring(i + 5, _s.Length - i - 6).Replace("\\", "\")
            // End If
            // If __s IsNot Nothing Then
            // _dicoBaseA.Add(__s, CInt(refModule.GetPropertyValue("BaseAddress")))
            // End If
            // Next
            // Next

            foreach (System.Management.ManagementObject refProcess in res)
            {
                int aPid = System.Convert.ToInt32(refProcess.GetPropertyValue(Native.Api.Enums.WmiInfoProcess.ProcessId.ToString()));

                // OK, we get modules for this process
                if (pid == aPid)
                {
                    ManagementObjectCollection colModule = refProcess.GetRelated("CIM_DataFile");
                    foreach (ManagementObject refModule in colModule)
                    {
                        Native.Api.NativeStructs.LdrDataTableEntry obj = new Native.Api.NativeStructs.LdrDataTableEntry();
                        string path = System.Convert.ToString(refModule.GetPropertyValue("Name"));

                        {
                            var withBlock = obj;
                            // Get base address from dico
                            // TOCHANGE
                            withBlock.DllBase = IntPtr.Zero;
                            withBlock.EntryPoint = IntPtr.Zero;
                            withBlock.SizeOfImage = 0;
                        }

                        string _manuf = System.Convert.ToString(refModule.GetPropertyValue("Manufacturer"));
                        string _vers = System.Convert.ToString(refModule.GetPropertyValue("Version"));
                        moduleInfos _module = new moduleInfos(ref obj, aPid, path, _vers, _manuf);
                        string _key = path + "-" + pid.ToString() + "-" + obj.DllBase.ToString();
                        _dico.Add(_key, _module);
                    }
                }
            }

            return true;
        }
    }
}

