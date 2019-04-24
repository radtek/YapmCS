using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using Native.Api;
using System.Management;

namespace Wmi.Objects
{
    public class Process
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

        // Enumerate processes
        public static bool EnumerateProcesses(System.Management.ManagementObjectSearcher objSearcher, ref Dictionary<string, processInfos> _dico, ref string errMsg)
        {
            ManagementObjectCollection res = null;
            try
            {
                res = objSearcher.Get();

                foreach (System.Management.ManagementObject refProcess in res)
                {
                    Native.Api.NativeStructs.SystemProcessInformation obj = new Native.Api.NativeStructs.SystemProcessInformation();
                    {
                        var withBlock = obj;
                        withBlock.BasePriority = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.Priority.ToString()]);
                        withBlock.HandleCount = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.HandleCount.ToString()]);
                        withBlock.InheritedFromProcessId = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ParentProcessId.ToString()]);
                        Native.Api.NativeStructs.IoCounters _IO = new Native.Api.NativeStructs.IoCounters();
                        {
                            var withBlock1 = _IO;
                            withBlock1.OtherOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherOperationCount.ToString()]);
                            withBlock1.OtherTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherTransferCount.ToString()]);
                            withBlock1.ReadOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadOperationCount.ToString()]);
                            withBlock1.ReadTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadTransferCount.ToString()]);
                            withBlock1.WriteOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteOperationCount.ToString()]);
                            withBlock1.WriteTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteTransferCount.ToString()]);
                        }
                        withBlock.IoCounters = _IO;
                        withBlock.KernelTime = System.Convert.ToInt64(refProcess[Enums.WmiInfoProcess.KernelModeTime.ToString()]);
                        withBlock.NumberOfThreads = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ThreadCount.ToString()]);
                        withBlock.ProcessId = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ProcessId.ToString()]);
                        // .SessionId                 ' NOT IMPLEMENTED
                        withBlock.UserTime = System.Convert.ToInt64(refProcess[Enums.WmiInfoProcess.UserModeTime.ToString()]);
                        Native.Api.NativeStructs.VmCountersEx _VM = new Native.Api.NativeStructs.VmCountersEx();
                        {
                            var withBlock2 = _VM;
                            withBlock2.PageFaultCount = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFaults.ToString()]);
                            withBlock2.PagefileUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFileUsage.ToString()]));
                            withBlock2.PeakPagefileUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakPageFileUsage.ToString()]));
                            withBlock2.PeakVirtualSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakVirtualSize.ToString()]));
                            withBlock2.PeakWorkingSetSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakWorkingSetSize.ToString()]));
                            withBlock2.PrivateBytes = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PrivatePageCount.ToString()]));
                            withBlock2.QuotaNonPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaNonPagedPoolUsage.ToString()]));
                            withBlock2.QuotaPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPagedPoolUsage.ToString()]));
                            withBlock2.QuotaPeakNonPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPeakNonPagedPoolUsage.ToString()]));
                            withBlock2.QuotaPeakPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPeakPagedPoolUsage.ToString()]));
                            withBlock2.VirtualSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.VirtualSize.ToString()]));
                            withBlock2.WorkingSetSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.WorkingSetSize.ToString()]));
                        }
                        withBlock.VirtualMemoryCounters = _VM;
                    }


                    // Do we have to get fixed infos ?
                    processInfos _procInfos = new processInfos(ref obj, System.Convert.ToString(refProcess["Name"]));
                    if (Native.Objects.Process.NewProcesses.ContainsKey(obj.ProcessId) == false)
                    {
                        {
                            var withBlock3 = _procInfos;
                            withBlock3.Path = System.Convert.ToString(refProcess[Enums.WmiInfoProcess.ExecutablePath.ToString()]);

                            string[] s1 = new string[2];
                            try
                            {
                                refProcess.InvokeMethod("GetOwner", s1);
                                if (Strings.Len(s1[0]) + Strings.Len(s1[1]) > 0)
                                    withBlock3.UserName = s1[1] + @"\" + s1[0];
                                else
                                    withBlock3.UserName = Program.NO_INFO_RETRIEVED;
                            }
                            catch (Exception ex)
                            {
                                withBlock3.UserName = Program.NO_INFO_RETRIEVED;
                            }

                            withBlock3.CommandLine = Program.NO_INFO_RETRIEVED;
                            withBlock3.FileInfo = null;
                            withBlock3.PebAddress = IntPtr.Zero;
                        }

                        Native.Objects.Process.NewProcesses.Add(obj.ProcessId, false);

                        Trace.WriteLine("Got fixed infos for id = " + obj.ProcessId.ToString());
                    }

                    // Set true so that the process is marked as existing
                    Native.Objects.Process.NewProcesses[obj.ProcessId] = true;
                    string sKey = obj.ProcessId.ToString();
                    if (_dico.ContainsKey(sKey) == false)
                        _dico.Add(sKey, _procInfos);
                }

                // Remove all processes that not exist anymore
                Dictionary<int, bool> _dicoTemp = Native.Objects.Process.NewProcesses;
                foreach (System.Collections.Generic.KeyValuePair<int, bool> it in _dicoTemp)
                {
                    if (it.Value == false)
                        Native.Objects.Process.NewProcesses.Remove(it.Key);
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        // Update process informations
        public static bool RefreshProcessInformationsById(int pid, System.Management.ManagementObjectSearcher objSearcher, ref string msgError, ref Native.Api.NativeStructs.SystemProcessInformation _newInfos)
        {

            // Get infos
            System.Management.ManagementObject refProcess = null;

            try
            {
                // Enumerate processes and find current process
                foreach (System.Management.ManagementObject tmpMngObj in objSearcher.Get())
                {
                    if (pid == System.Convert.ToInt32(tmpMngObj.GetPropertyValue(Enums.WmiInfoProcess.ProcessId.ToString())))
                    {
                        refProcess = tmpMngObj;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }


            // Get informations from found process
            if (refProcess != null)
            {
                {
                    var withBlock = _newInfos;
                    withBlock.BasePriority = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.Priority.ToString()]);
                    withBlock.HandleCount = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.HandleCount.ToString()]);
                    // .InheritedFromProcessId = CInt(refProcess.Item(API.WMI_INFO.ParentProcessId.ToString))
                    Native.Api.NativeStructs.IoCounters _IO = new Native.Api.NativeStructs.IoCounters();
                    {
                        var withBlock1 = _IO;
                        withBlock1.OtherOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherOperationCount.ToString()]);
                        withBlock1.OtherTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherTransferCount.ToString()]);
                        withBlock1.ReadOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadOperationCount.ToString()]);
                        withBlock1.ReadTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadTransferCount.ToString()]);
                        withBlock1.WriteOperationCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteOperationCount.ToString()]);
                        withBlock1.WriteTransferCount = System.Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteTransferCount.ToString()]);
                    }
                    withBlock.IoCounters = _IO;
                    withBlock.KernelTime = System.Convert.ToInt64(refProcess[Enums.WmiInfoProcess.KernelModeTime.ToString()]);
                    withBlock.NumberOfThreads = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ThreadCount.ToString()]);
                    // .ProcessId = CInt(refProcess.Item(API.WMI_INFO.ProcessId.ToString))
                    // .SessionId                 ' NOT IMPLEMENTED
                    withBlock.UserTime = System.Convert.ToInt64(refProcess[Enums.WmiInfoProcess.UserModeTime.ToString()]);
                    Native.Api.NativeStructs.VmCountersEx _VM = new Native.Api.NativeStructs.VmCountersEx();
                    {
                        var withBlock2 = _VM;
                        withBlock2.PageFaultCount = System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFaults.ToString()]);
                        withBlock2.PagefileUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFileUsage.ToString()]));
                        withBlock2.PeakPagefileUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakPageFileUsage.ToString()]));
                        withBlock2.PeakVirtualSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakVirtualSize.ToString()]));
                        withBlock2.PeakWorkingSetSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakWorkingSetSize.ToString()]));
                        withBlock2.PrivateBytes = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PrivatePageCount.ToString()]));
                        withBlock2.QuotaNonPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaNonPagedPoolUsage.ToString()]));
                        withBlock2.QuotaPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPagedPoolUsage.ToString()]));
                        withBlock2.QuotaPeakNonPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPeakNonPagedPoolUsage.ToString()]));
                        withBlock2.QuotaPeakPagedPoolUsage = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.QuotaPeakPagedPoolUsage.ToString()]));
                        withBlock2.VirtualSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.VirtualSize.ToString()]));
                        withBlock2.WorkingSetSize = new IntPtr(System.Convert.ToInt32(refProcess[Enums.WmiInfoProcess.WorkingSetSize.ToString()]));
                    }
                    withBlock.VirtualMemoryCounters = _VM;
                }

                return true;
            }
            else
            {
                msgError = "Internal error";
                return false;
            }
        }

        // Kill a process
        public static bool KillProcessById(int pid, System.Management.ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                System.Management.ManagementObject _theProcess = null;
                foreach (System.Management.ManagementObject pp in objSearcher.Get())
                {
                    if (System.Convert.ToInt32(pp["ProcessId"]) == pid)
                    {
                        _theProcess = pp;
                        break;
                    }
                }
                if (_theProcess != null)
                {
                    Enums.WmiProcessReturnCode ret;
                    ret = (Enums.WmiProcessReturnCode)_theProcess.InvokeMethod("Terminate", null);
                    msgError = ret.ToString();
                    return (ret == Enums.WmiProcessReturnCode.SuccessfulCompletion);
                }
                else
                {
                    msgError = "Internal error";
                    return false;
                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        // Create new process
        public static bool CreateNewProcessByPath(string path, System.Management.ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementPath managementPath = new ManagementPath("Win32_Process");
                ManagementClass processClass = new ManagementClass(objSearcher.Scope, managementPath, objectGetOptions);
                ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = path;
                ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);
                Enums.WmiProcessReturnCode res = (Enums.WmiProcessReturnCode)outParams["ReturnValue"];
                int pid = (Enums.WmiProcessReturnCode)outParams["ProcessId"];

                msgError = res.ToString();
                return (res == Enums.WmiProcessReturnCode.SuccessfulCompletion);
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        // Set process priority
        public static bool SetProcessPriorityById(int pid, ProcessPriorityClass lvl, System.Management.ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                Enums.WmiProcessReturnCode res;
                foreach (ManagementObject srv in objSearcher.Get())
                {
                    if (System.Convert.ToInt32(srv.GetPropertyValue(Enums.WmiInfoProcess.ProcessId.ToString())) == pid)
                    {
                        ManagementBaseObject inParams = srv.GetMethodParameters("SetPriority");
                        inParams["Priority"] = lvl;
                        ManagementBaseObject outParams = srv.InvokeMethod("SetPriority", inParams, null);
                        res = (Enums.WmiProcessReturnCode)outParams["ReturnValue"];
                        break;
                    }
                }

                msgError = res.ToString();
                return (res == Enums.WmiProcessReturnCode.SuccessfulCompletion);
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
    }
}

