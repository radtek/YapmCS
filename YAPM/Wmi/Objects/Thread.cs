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
        public static bool EnumerateThreadByIds(int pid, System.Management.ManagementObjectSearcher objSearcher, ref Dictionary<string, threadInfos> _dico, ref string errMsg)
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

            foreach (System.Management.ManagementObject refThread in res)
            {
                int wmiId = System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.ProcessHandle.ToString()));

                // If we have to get threads for this process...
                if (pid == wmiId)
                {
                    Native.Api.NativeStructs.SystemThreadInformation obj = new Native.Api.NativeStructs.SystemThreadInformation();
                    {
                        var withBlock = obj;
                        withBlock.BasePriority = System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.PriorityBase.ToString()));
                        withBlock.CreateTime = 0;
                        withBlock.ClientId = new Native.Api.NativeStructs.ClientId(wmiId, System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.Handle.ToString())));
                        withBlock.KernelTime = 10000 * System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.KernelModeTime.ToString()));
                        withBlock.Priority = System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.Priority.ToString()));
                        try
                        {
                            withBlock.StartAddress = (IntPtr)refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.StartAddress.ToString());
                        }
                        catch (Exception ex0)
                        {
                            withBlock.StartAddress = NativeConstants.InvalidHandleValue;
                        }
                        withBlock.State = (ThreadState)refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.ThreadState.ToString());
                        withBlock.UserTime = 10000 * System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.UserModeTime.ToString()));
                        withBlock.WaitReason = (Native.Api.NativeEnums.KwaitReason)System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.ThreadWaitReason.ToString()));
                        try
                        {
                            withBlock.WaitTime = 10000 * System.Convert.ToInt32(refThread.GetPropertyValue(Native.Api.Enums.WmiInfoThread.ElapsedTime.ToString()));
                        }
                        catch (Exception ex1)
                        {
                        }
                    }
                    threadInfos _procInfos = new threadInfos(ref obj);
                    string _key = obj.ClientId.UniqueThread.ToString() + "-" + obj.ClientId.UniqueProcess.ToString();
                    if (_dico.ContainsKey(_key) == false)
                        _dico.Add(_key, _procInfos);
                }
            }

            return true;
        }
    }
}

