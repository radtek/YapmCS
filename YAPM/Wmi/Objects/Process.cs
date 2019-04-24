using System.Diagnostics;
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
        public static bool EnumerateProcesses(ManagementObjectSearcher objSearcher,
            ref Dictionary<string, processInfos> dico, ref string errMsg)
        {
            try
            {
                var res = objSearcher.Get();

                foreach (var o in res)
                {
                    var refProcess = (ManagementObject) o;
                    var obj = new NativeStructs.SystemProcessInformation();
                    {
                        var withBlock = obj;
                        withBlock.BasePriority = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.Priority.ToString()]);
                        withBlock.HandleCount =
                            Convert.ToInt32(refProcess[Enums.WmiInfoProcess.HandleCount.ToString()]);
                        withBlock.InheritedFromProcessId =
                            Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ParentProcessId.ToString()]);
                        var io = new NativeStructs.IoCounters();
                        {
                            io.OtherOperationCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherOperationCount.ToString()]);
                            io.OtherTransferCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherTransferCount.ToString()]);
                            io.ReadOperationCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadOperationCount.ToString()]);
                            io.ReadTransferCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadTransferCount.ToString()]);
                            io.WriteOperationCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteOperationCount.ToString()]);
                            io.WriteTransferCount =
                                Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteTransferCount.ToString()]);
                        }
                        withBlock.IoCounters = io;
                        withBlock.KernelTime =
                            Convert.ToInt64(refProcess[Enums.WmiInfoProcess.KernelModeTime.ToString()]);
                        withBlock.NumberOfThreads =
                            Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ThreadCount.ToString()]);
                        withBlock.ProcessId = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ProcessId.ToString()]);
                        // .SessionId                 ' NOT IMPLEMENTED
                        withBlock.UserTime = Convert.ToInt64(refProcess[Enums.WmiInfoProcess.UserModeTime.ToString()]);
                        var vm = new NativeStructs.VmCountersEx();
                        {
                            vm.PageFaultCount = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFaults.ToString()]);
                            vm.PagefileUsage =
                                new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFileUsage.ToString()]));
                            vm.PeakPagefileUsage =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.PeakPageFileUsage.ToString()]));
                            vm.PeakVirtualSize =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.PeakVirtualSize.ToString()]));
                            vm.PeakWorkingSetSize =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.PeakWorkingSetSize.ToString()]));
                            vm.PrivateBytes =
                                new IntPtr(
                                    Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PrivatePageCount.ToString()]));
                            vm.QuotaNonPagedPoolUsage =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.QuotaNonPagedPoolUsage.ToString()]));
                            vm.QuotaPagedPoolUsage =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.QuotaPagedPoolUsage.ToString()]));
                            vm.QuotaPeakNonPagedPoolUsage =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.QuotaPeakNonPagedPoolUsage.ToString()]));
                            vm.QuotaPeakPagedPoolUsage =
                                new IntPtr(Convert.ToInt32(
                                    refProcess[Enums.WmiInfoProcess.QuotaPeakPagedPoolUsage.ToString()]));
                            vm.VirtualSize =
                                new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.VirtualSize.ToString()]));
                            vm.WorkingSetSize =
                                new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.WorkingSetSize.ToString()]));
                        }
                        withBlock.VirtualMemoryCounters = vm;
                    }


                    // Do we have to get fixed infos ?
                    var procInfos = new processInfos(ref obj, Convert.ToString(refProcess["Name"]));
                    if (Native.Objects.Process.NewProcesses.ContainsKey(obj.ProcessId) == false)
                    {
                        {
                            var withBlock3 = procInfos;
                            withBlock3.Path =
                                Convert.ToString(refProcess[Enums.WmiInfoProcess.ExecutablePath.ToString()]);

                            var s1 = new string[2];
                            try
                            {
                                refProcess.InvokeMethod("GetOwner", s1);
                                if (s1[0].Length + s1[1].Length > 0)
                                    withBlock3.UserName = s1[1] + @"\" + s1[0];
                                else
                                    withBlock3.UserName = Program.NO_INFO_RETRIEVED;
                            }
                            catch (Exception)
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
                    var sKey = obj.ProcessId.ToString();
                    if (dico.ContainsKey(sKey) == false)
                        dico.Add(sKey, procInfos);
                }

                // Remove all processes that not exist anymore
                var dicoTemp = Native.Objects.Process.NewProcesses;
                foreach (var it in dicoTemp)
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
        public static bool RefreshProcessInformationsById(int pid, ManagementObjectSearcher objSearcher,
            ref string msgError, ref NativeStructs.SystemProcessInformation newInfos)
        {
            // Get infos
            ManagementObject refProcess = null;

            try
            {
                // Enumerate processes and find current process
                foreach (var o in objSearcher.Get())
                {
                    var tmpMngObj = (ManagementObject) o;
                    if (pid != Convert.ToInt32(tmpMngObj.GetPropertyValue(Enums.WmiInfoProcess.ProcessId.ToString())))
                        continue;
                    refProcess = tmpMngObj;
                    break;
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
                    newInfos.BasePriority = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.Priority.ToString()]);
                    newInfos.HandleCount = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.HandleCount.ToString()]);
                    // .InheritedFromProcessId = CInt(refProcess.Item(API.WMI_INFO.ParentProcessId.ToString))
                    var io = new NativeStructs.IoCounters();
                    {
                        io.OtherOperationCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherOperationCount.ToString()]);
                        io.OtherTransferCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.OtherTransferCount.ToString()]);
                        io.ReadOperationCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadOperationCount.ToString()]);
                        io.ReadTransferCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.ReadTransferCount.ToString()]);
                        io.WriteOperationCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteOperationCount.ToString()]);
                        io.WriteTransferCount =
                            Convert.ToUInt64(refProcess[Enums.WmiInfoProcess.WriteTransferCount.ToString()]);
                    }
                    newInfos.IoCounters = io;
                    newInfos.KernelTime = Convert.ToInt64(refProcess[Enums.WmiInfoProcess.KernelModeTime.ToString()]);
                    newInfos.NumberOfThreads = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.ThreadCount.ToString()]);
                    // .ProcessId = CInt(refProcess.Item(API.WMI_INFO.ProcessId.ToString))
                    // .SessionId                 ' NOT IMPLEMENTED
                    newInfos.UserTime = Convert.ToInt64(refProcess[Enums.WmiInfoProcess.UserModeTime.ToString()]);
                    var vm = new NativeStructs.VmCountersEx();
                    {
                        vm.PageFaultCount = Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFaults.ToString()]);
                        vm.PagefileUsage =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PageFileUsage.ToString()]));
                        vm.PeakPagefileUsage =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakPageFileUsage.ToString()]));
                        vm.PeakVirtualSize =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakVirtualSize.ToString()]));
                        vm.PeakWorkingSetSize =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PeakWorkingSetSize.ToString()]));
                        vm.PrivateBytes =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.PrivatePageCount.ToString()]));
                        vm.QuotaNonPagedPoolUsage =
                            new IntPtr(Convert.ToInt32(
                                refProcess[Enums.WmiInfoProcess.QuotaNonPagedPoolUsage.ToString()]));
                        vm.QuotaPagedPoolUsage =
                            new IntPtr(Convert.ToInt32(
                                refProcess[Enums.WmiInfoProcess.QuotaPagedPoolUsage.ToString()]));
                        vm.QuotaPeakNonPagedPoolUsage =
                            new IntPtr(Convert.ToInt32(
                                refProcess[Enums.WmiInfoProcess.QuotaPeakNonPagedPoolUsage.ToString()]));
                        vm.QuotaPeakPagedPoolUsage =
                            new IntPtr(Convert.ToInt32(
                                refProcess[Enums.WmiInfoProcess.QuotaPeakPagedPoolUsage.ToString()]));
                        vm.VirtualSize =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.VirtualSize.ToString()]));
                        vm.WorkingSetSize =
                            new IntPtr(Convert.ToInt32(refProcess[Enums.WmiInfoProcess.WorkingSetSize.ToString()]));
                    }
                    newInfos.VirtualMemoryCounters = vm;
                }

                return true;
            }

            msgError = "Internal error";
            return false;
        }

        // Kill a process
        public static bool KillProcessById(int pid, ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                ManagementObject theProcess = null;
                foreach (var o in objSearcher.Get())
                {
                    var pp = (ManagementObject) o;
                    if (Convert.ToInt32(pp["ProcessId"]) != pid) continue;
                    theProcess = pp;
                    break;
                }

                if (theProcess != null)
                {
                    var ret = (Enums.WmiProcessReturnCode) theProcess.InvokeMethod("Terminate", null);
                    msgError = ret.ToString();
                    return ret == Enums.WmiProcessReturnCode.SuccessfulCompletion;
                }

                msgError = "Internal error";
                return false;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        // Create new process
        public static bool CreateNewProcessByPath(string path, ManagementObjectSearcher objSearcher,
            ref string msgError)
        {
            try
            {
                var objectGetOptions = new ObjectGetOptions();
                var managementPath = new ManagementPath("Win32_Process");
                var processClass = new ManagementClass(objSearcher.Scope, managementPath, objectGetOptions);
                var inParams = processClass.GetMethodParameters("Create");
                inParams["CommandLine"] = path;
                var outParams = processClass.InvokeMethod("Create", inParams, null);
                var res = (Enums.WmiProcessReturnCode) outParams["ReturnValue"];

                msgError = res.ToString();
                return res == Enums.WmiProcessReturnCode.SuccessfulCompletion;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        // Set process priority
        public static bool SetProcessPriorityById(int pid, ProcessPriorityClass lvl,
            ManagementObjectSearcher objSearcher, ref string msgError)
        {
            try
            {
                var res = Enums.WmiProcessReturnCode.SuccessfulCompletion;
                foreach (var o in objSearcher.Get())
                {
                    var srv = (ManagementObject) o;
                    if (Convert.ToInt32(srv.GetPropertyValue(Enums.WmiInfoProcess.ProcessId.ToString())) !=
                        pid) continue;
                    var inParams = srv.GetMethodParameters("SetPriority");
                    inParams["Priority"] = lvl;
                    var outParams = srv.InvokeMethod("SetPriority", inParams, null);
                    if (outParams != null) res = (Enums.WmiProcessReturnCode) outParams["ReturnValue"];
                    break;
                }

                msgError = res.ToString();
                return res == Enums.WmiProcessReturnCode.SuccessfulCompletion;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
    }
}