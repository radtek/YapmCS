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
        public static bool EnumerateModuleById(int pid, ManagementObjectSearcher objSearcher,
            ref Dictionary<string, moduleInfos> dico, ref string errMsg)
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

            foreach (var managementBaseObject in res)
            {
                var refProcess = (ManagementObject) managementBaseObject;
                var aPid = Convert.ToInt32(
                    refProcess.GetPropertyValue(Native.Api.Enums.WmiInfoProcess.ProcessId.ToString()));

                // OK, we get modules for this process
                if (pid != aPid) continue;
                var colModule = refProcess.GetRelated("CIM_DataFile");
                foreach (var o in colModule)
                {
                    var refModule = (ManagementObject) o;
                    var obj =
                        new Native.Api.NativeStructs.LdrDataTableEntry();
                    var path = Convert.ToString(refModule.GetPropertyValue("Name"));

                    {
                        // Get base address from dico
                        // TOCHANGE
                        obj.DllBase = IntPtr.Zero;
                        obj.EntryPoint = IntPtr.Zero;
                        obj.SizeOfImage = 0;
                    }

                    var manuf = Convert.ToString(refModule.GetPropertyValue("Manufacturer"));
                    var vers = Convert.ToString(refModule.GetPropertyValue("Version"));
                    var module = new moduleInfos(ref obj, aPid, path, vers, manuf);
                    var key = path + "-" + pid + "-" + obj.DllBase;
                    dico.Add(key, module);
                }
            }

            return true;
        }
    }
}