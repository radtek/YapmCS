using System.Diagnostics;
using System.Collections.Generic;
using System;
using Native.Api;
using System.Management;

namespace Wmi.Objects
{
    public class Thread
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

        // Enumerate threads
        public static bool EnumerateThreadByIds(int pid, ManagementObjectSearcher objSearcher,
            ref Dictionary<string, threadInfos> dico, ref string errMsg)
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

            foreach (var o in res)
            {
                var refThread = (ManagementObject) o;
                var wmiId = Convert.ToInt32(
                    refThread.GetPropertyValue(Enums.WmiInfoThread.ProcessHandle.ToString()));

                // If we have to get threads for this process...
                if (pid != wmiId) continue;
                var obj =
                    new NativeStructs.SystemThreadInformation();
                {
                    obj.BasePriority = Convert.ToInt32(
                        refThread.GetPropertyValue(Enums.WmiInfoThread.PriorityBase.ToString()));
                    obj.CreateTime = 0;
                    obj.ClientId = new NativeStructs.ClientId(wmiId,
                        Convert.ToInt32(
                            refThread.GetPropertyValue(Enums.WmiInfoThread.Handle.ToString())));
                    obj.KernelTime = 10000 * Convert.ToInt32(
                                         refThread.GetPropertyValue(Enums.WmiInfoThread
                                             .KernelModeTime.ToString()));
                    obj.Priority =
                        Convert.ToInt32(
                            refThread.GetPropertyValue(Enums.WmiInfoThread.Priority.ToString()));
                    try
                    {
                        obj.StartAddress =
                            (IntPtr) refThread.GetPropertyValue(
                                Enums.WmiInfoThread.StartAddress.ToString());
                    }
                    catch (Exception)
                    {
                        obj.StartAddress = NativeConstants.InvalidHandleValue;
                    }

                    obj.State =
                        (ThreadState) refThread.GetPropertyValue(
                            Enums.WmiInfoThread.ThreadState.ToString());
                    obj.UserTime = 10000 * Convert.ToInt32(
                                       refThread.GetPropertyValue(Enums.WmiInfoThread.UserModeTime
                                           .ToString()));
                    obj.WaitReason = (NativeEnums.KwaitReason) Convert.ToInt32(
                        refThread.GetPropertyValue(Enums.WmiInfoThread.ThreadWaitReason.ToString()));
                    try
                    {
                        obj.WaitTime = 10000 * Convert.ToInt32(
                                           refThread.GetPropertyValue(Enums.WmiInfoThread
                                               .ElapsedTime.ToString()));
                    }
                    catch
                    {
                        // ignored
                    }
                }
                var procInfos = new threadInfos(ref obj);
                var key = obj.ClientId.UniqueThread + "-" + obj.ClientId.UniqueProcess;
                if (dico.ContainsKey(key) == false)
                    dico.Add(key, procInfos);
            }

            return true;
        }
    }
}