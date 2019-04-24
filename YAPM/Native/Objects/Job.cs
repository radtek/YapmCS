using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class Job
    {


        // ========================================
        // Private constants
        // ========================================

        private const int ERROR_ALREADY_EXISTS = 0xB7;

        // NtStatus length mismatch
        private const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;


        // ========================================
        // Private attributes
        // ========================================

        // ObjectTypeNumer for Job
        private static int jobTypeNumber = 0;

        // List of valid handles (name <-> handle) + sem to protect access
        private static Dictionary<string, IntPtr> _dupHandles = new Dictionary<string, IntPtr>();
        private static Dictionary<string, IntPtr> _ownHandles = new Dictionary<string, IntPtr>();
        private static System.Threading.Semaphore semDupHandles = new System.Threading.Semaphore(1, 1);

        // Sem for enumeration
        private static System.Threading.Semaphore semEnum = new System.Threading.Semaphore(1, 1);

        // List of created jobs
        private static Dictionary<string, cJob> colJobs = new Dictionary<string, cJob>();

        // Some mem allocations
        private static Native.Memory.MemoryAlloc memAllocJobs = new Native.Memory.MemoryAlloc(0x100);     // NOTE : never unallocated
        private static Native.Memory.MemoryAlloc BufferObjNameJob = new Native.Memory.MemoryAlloc(512);   // NOTE : never unallocated


        // ========================================
        // Public properties
        // ========================================

        // Current jobs
        public static Dictionary<string, cJob> CreatedJobs
        {
            get
            {
                return colJobs;
            }
        }


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Call this function to start executin a code which uses a valid handle to a named job
        public static IntPtr BeginUsingValidJobHandle(string name)
        {
            if (name == null)
                return IntPtr.Zero;

            // Wait sem
            semDupHandles.WaitOne();

            if (_dupHandles.ContainsKey(name))
                // Then it's a duplicated handle
                return _dupHandles[name];
            else if (_ownHandles.ContainsKey(name))
                // Then it's an owned handle
                return _ownHandles[name];
            else
                return IntPtr.Zero;
        }

        // Same to finish
        public static void EndUsingValidJobHandle()
        {

            // Simply release semaphore, so the enumeration func will close the handle
            // next time
            semDupHandles.Release();
        }


        // Add a process to a job
        public static cJob CreateJobByName(string jobName)
        {

            // Create a job
            IntPtr hJob;
            NativeStructs.SecurityAttributes sa = new NativeStructs.SecurityAttributes();
            {
                var withBlock = sa;
                withBlock.nLength = Marshal.SizeOf(sa);
                withBlock.bInheritHandle = true;
                withBlock.lpSecurityDescriptor = IntPtr.Zero;
            }

            hJob = NativeFunctions.CreateJobObject(ref sa, jobName);

            if (hJob.IsNotNull())
            {
                // Add process to job
                // The job created has All access

                if (colJobs.ContainsKey(jobName) == false)
                {
                    // Add the new job to the dico
                    jobInfos tJ = new jobInfos(jobName);
                    cJob theJob = new cJob(ref tJ);
                    colJobs.Add(jobName, theJob);
                    return theJob;
                }
                else
                    return colJobs[jobName];
            }

            return null;
        }

        // Add a process to a job
        public static bool AddProcessToJobById(int processId, string jobName)
        {
            bool ret;

            // Create (or open existing) job
            IntPtr hJob;
            NativeStructs.SecurityAttributes sa = new NativeStructs.SecurityAttributes();
            {
                var withBlock = sa;
                withBlock.nLength = Marshal.SizeOf(sa);
                withBlock.bInheritHandle = true;
                withBlock.lpSecurityDescriptor = IntPtr.Zero;
            }

            hJob = NativeFunctions.CreateJobObject(ref sa, jobName);

            if (hJob.IsNotNull())
            {
                // Add process to job
                // The job created has All access

                if (colJobs.ContainsKey(jobName) == false)
                {
                    // Add the new job to the dico
                    jobInfos tJ = new jobInfos(jobName);
                    colJobs.Add(jobName, new cJob(tJ));
                }

                IntPtr hProc = Native.Objects.Process.GetProcessHandleById(processId, Security.ProcessAccess.SetQuota | Security.ProcessAccess.Terminate);
                if (hProc.IsNotNull())
                {
                    ret = NativeFunctions.AssignProcessToJobObject(hJob, hProc);
                    Objects.General.CloseHandle(hProc);
                }
            }

            return ret;
        }

        // Terminate a job
        public static bool TerminateJobByJobName(string jobName, int exitCode = 0)
        {

            // Open job by its name
            // Query a valid handle (all acces)
            IntPtr hJob = BeginUsingValidJobHandle(jobName);
            bool ret;

            if (hJob.IsNotNull())
            {
                // Then terminate job !
                ret = NativeFunctions.TerminateJobObject(hJob, exitCode);

                if (ret)
                    // Successfully terminated job
                    // Now close the handle YAPM has opened to the job
                    Objects.General.CloseHandle(hJob);
            }

            // End using the valid handle
            EndUsingValidJobHandle();

            return ret;
        }

        // Add some processes to a job
        public static bool AddProcessToJobByIds(int[] processId, string jobName)
        {
            if (processId != null)
            {
                bool ret = true;
                foreach (int id in processId)
                    ret = ret & AddProcessToJobById(id, jobName);
                return ret;
            }
            else
                return false;
        }

        // Enumerate created jobs
        public static Dictionary<string, jobLimitInfos> EnumerateJobLimitsByJobName(string jobName)
        {
            Dictionary<string, jobLimitInfos> ret = new Dictionary<string, jobLimitInfos>();

            // UiRestrictions
            NativeStructs.JobObjectBasicUiRestrictions struct1 = GetJobBasicUiRestrictionsByName(jobName);
            NativeEnums.JobObjectBasicUiRestrictions flag1 = struct1.UIRestrictionsClass;

            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.Desktop) == NativeEnums.JobObjectBasicUiRestrictions.Desktop)
                ret.Add("Desktop", new jobLimitInfos("Desktop", "Desktop", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.DisplaySettings) == NativeEnums.JobObjectBasicUiRestrictions.DisplaySettings)
                ret.Add("DisplaySettings", new jobLimitInfos("DisplaySettings", "DisplaySettings", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.ExitWindows) == NativeEnums.JobObjectBasicUiRestrictions.ExitWindows)
                ret.Add("ExitWindows", new jobLimitInfos("ExitWindows", "ExitWindows", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.GlobalAtoms) == NativeEnums.JobObjectBasicUiRestrictions.GlobalAtoms)
                ret.Add("GlobalAtoms", new jobLimitInfos("GlobalAtoms", "GlobalAtoms", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.Handles) == NativeEnums.JobObjectBasicUiRestrictions.Handles)
                ret.Add("Handles", new jobLimitInfos("Handles", "Handles", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.ReadClipboard) == NativeEnums.JobObjectBasicUiRestrictions.ReadClipboard)
                ret.Add("ReadClipboard", new jobLimitInfos("ReadClipboard", "ReadClipboard", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.SystemParameters) == NativeEnums.JobObjectBasicUiRestrictions.SystemParameters)
                ret.Add("SystemParameters", new jobLimitInfos("SystemParameters", "SystemParameters", "Limited", null));
            if ((flag1 & NativeEnums.JobObjectBasicUiRestrictions.WriteClipboard) == NativeEnums.JobObjectBasicUiRestrictions.WriteClipboard)
                ret.Add("WriteClipboard", new jobLimitInfos("WriteClipboard", "WriteClipboard", "Limited", null));

            // Other limitations
            NativeStructs.JobObjectExtendedLimitInformation struct2 = GetJobExtendedLimitInformationByName(jobName);
            NativeEnums.JobObjectLimitFlags flag2 = struct2.BasicLimitInformation.LimitFlags;

            if ((flag2 & NativeEnums.JobObjectLimitFlags.ActiveProcess) == NativeEnums.JobObjectLimitFlags.ActiveProcess)
                ret.Add("ActiveProcess", new jobLimitInfos("ActiveProcess", "Active processes", struct2.BasicLimitInformation.ActiveProcessLimit.ToString(), struct2.BasicLimitInformation.ActiveProcessLimit));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.Affinity) == NativeEnums.JobObjectLimitFlags.Affinity)
                ret.Add("Affinity", new jobLimitInfos("Affinity", "Affinity", struct2.BasicLimitInformation.Affinity.ToString(), struct2.BasicLimitInformation.Affinity));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.BreakawayOk) == NativeEnums.JobObjectLimitFlags.BreakawayOk)
                ret.Add("BreakawayOk", new jobLimitInfos("BreakawayOk", "Breakaway OK", "Enabled", null));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.DieOnUnhandledException) == NativeEnums.JobObjectLimitFlags.DieOnUnhandledException)
                ret.Add("DieOnUnhandledException", new jobLimitInfos("DieOnUnhandledException", "Die on unhandled exception", "Enabled", null));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.JobMemory) == NativeEnums.JobObjectLimitFlags.JobMemory)
                ret.Add("JobMemory", new jobLimitInfos("JobMemory", "Committed memory for job", Common.Misc.GetFormatedSize(struct2.JobMemoryLimit), struct2.JobMemoryLimit));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.JobTime) == NativeEnums.JobObjectLimitFlags.JobTime)
                ret.Add("JobTime", new jobLimitInfos("JobTime", "Usermode time for job", struct2.BasicLimitInformation.PerJobUserTimeLimit.ToString(), struct2.BasicLimitInformation.PerJobUserTimeLimit));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.KillOnJobClose) == NativeEnums.JobObjectLimitFlags.KillOnJobClose)
                ret.Add("KillOnJobClose", new jobLimitInfos("KillOnJobClose", "Kill on job close", "Enabled", null));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.PreserveJobTime) == NativeEnums.JobObjectLimitFlags.PreserveJobTime)
                ret.Add("PreserveJobTime", new jobLimitInfos("PreserveJobTime", "Preserve job time", "Enabled", null));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.PriorityClass) == NativeEnums.JobObjectLimitFlags.PriorityClass)
                ret.Add("PriorityClass", new jobLimitInfos("PriorityClass", "Priority class", ((System.Diagnostics.ProcessPriorityClass)struct2.BasicLimitInformation.PriorityClass).ToString(), struct2.BasicLimitInformation.PriorityClass));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.ProcessMemory) == NativeEnums.JobObjectLimitFlags.ProcessMemory)
                ret.Add("ProcessMemory", new jobLimitInfos("ProcessMemory", "Committed memory for each process", Common.Misc.GetFormatedSize(struct2.ProcessMemoryLimit), struct2.ProcessMemoryLimit));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.ProcessTime) == NativeEnums.JobObjectLimitFlags.ProcessTime)
                ret.Add("ProcessTime", new jobLimitInfos("ProcessTime", "Usermode time for each process", struct2.BasicLimitInformation.PerProcessUserTimeLimit.ToString(), struct2.BasicLimitInformation.PerProcessUserTimeLimit));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.SchedulingClass) == NativeEnums.JobObjectLimitFlags.SchedulingClass)
                ret.Add("SchedulingClass", new jobLimitInfos("SchedulingClass", "Scheduling class", struct2.BasicLimitInformation.SchedulingClass.ToString(), struct2.BasicLimitInformation.SchedulingClass));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.SilentBreakawayOk) == NativeEnums.JobObjectLimitFlags.SilentBreakawayOk)
                ret.Add("SilentBreakawayOk", new jobLimitInfos("SilentBreakawayOk", "Slient breakaway OK", "Enabled", null));
            if ((flag2 & NativeEnums.JobObjectLimitFlags.WorkingSet) == NativeEnums.JobObjectLimitFlags.WorkingSet)
            {
                ret.Add("WorkingSetMin", new jobLimitInfos("WorkingSetMin", "Minimum working set size per process", Common.Misc.GetFormatedSize(struct2.BasicLimitInformation.MinimumWorkingSetSize), struct2.BasicLimitInformation.MinimumWorkingSetSize));
                ret.Add("WorkingSetMax", new jobLimitInfos("WorkingSetMax", "Maximum working set size per process", Common.Misc.GetFormatedSize(struct2.BasicLimitInformation.MaximumWorkingSetSize), struct2.BasicLimitInformation.MaximumWorkingSetSize));
            }

            return ret;
        }

        // Enumerate created jobs
        public static Dictionary<string, jobInfos> EnumerateJobs()
        {
            return GetJobList();
        }

        // Enumerate Processes in a job
        public static Dictionary<string, processInfos> GetProcessesInJobByName(string jobName)
        {

            // Query valid handle
            IntPtr hJob = BeginUsingValidJobHandle(jobName);

            Dictionary<string, processInfos> procs = new Dictionary<string, processInfos>();
            int ret;

            if (hJob.IsNotNull())
            {
                using (Memory.MemoryAlloc memAlloc = new Memory.MemoryAlloc(0x1000))
                {
                    NativeFunctions.QueryInformationJobObject(hJob, NativeEnums.JobObjectInformationClass.JobObjectBasicProcessIdList, memAlloc.Pointer, memAlloc.Size, ref ret);

                    if (ret > 0)
                    {
                        NativeStructs.JobObjectBasicProcessIdList list = memAlloc.ReadStruct<NativeStructs.JobObjectBasicProcessIdList>();
                        Debug.WriteLine(list.ProcessIdsCount.ToString());
                        var loopTo = list.ProcessIdsCount - 1;
                        for (int i = 0; i <= loopTo; i++)
                        {
                            int pid = memAlloc.ReadInt32(0x8, i);      // &h8 cause of two first Int32
                            cProcess proc = cProcess.GetProcessById(pid);
                            // /!\ We HAVE to check that the cProcess we retrieve
                            // is NOT null, as it may has just been created and is not
                            // yet available in list of cProcesses
                            if (proc != null && pid > 0)
                            {
                                // PERFISSUE ?
                                if (procs.ContainsKey(pid.ToString()) == false)
                                    procs.Add(pid.ToString(), proc.Infos);
                            }
                        }
                    }
                }
            }

            // End using valid handle
            EndUsingValidJobHandle();

            return procs;
        }

        // Query some informations
        // These 5 functions use QueryJobInformationByHandle
        public static NativeStructs.JobObjectBasicAndIoAccountingInformation GetJobBasicAndIoAccountingInformationByName(string jobName)
        {
            return QueryJobInformationByName<NativeStructs.JobObjectBasicAndIoAccountingInformation>(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicAndIoAccountingInformation);
        }

        public static NativeStructs.JobObjectBasicAccountingInformation GetJobBasicAccountingInformationByName(string jobName)
        {
            return QueryJobInformationByName<NativeStructs.JobObjectBasicAccountingInformation>(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicAccountingInformation);
        }

        public static NativeStructs.JobObjectBasicUiRestrictions GetJobBasicUiRestrictionsByName(string jobName)
        {
            return QueryJobInformationByName<NativeStructs.JobObjectBasicUiRestrictions>(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicUIRestrictions);
        }

        public static NativeStructs.JobObjectBasicLimitInformation GetJobBasicLimitInformationByName(string jobName)
        {
            return QueryJobInformationByName<NativeStructs.JobObjectBasicLimitInformation>(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicLimitInformation);
        }

        public static NativeStructs.JobObjectExtendedLimitInformation GetJobExtendedLimitInformationByName(string jobName)
        {
            return QueryJobInformationByName<NativeStructs.JobObjectExtendedLimitInformation>(jobName, NativeEnums.JobObjectInformationClass.JobObjectExtendedLimitInformation);
        }

        // Set some informations
        public static bool SetJobBasicLimitInformationByName(string jobName, NativeStructs.JobObjectBasicLimitInformation limit)
        {
            return SetJobInformationByName(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicLimitInformation, limit);
        }

        public static bool SetJobCommonLimitsByName(string jobName, NativeStructs.JobObjectBasicUiRestrictions limit1, NativeStructs.JobObjectExtendedLimitInformation limit2)
        {
            bool ret = true;
            ret = ret & SetJobBasicUiRestrictionsName(jobName, limit1);
            ret = ret & SetJobExtendedLimitInformationsByName(jobName, limit2);
            return ret;
        }

        public static bool SetJobBasicUiRestrictionsName(string jobName, NativeStructs.JobObjectBasicUiRestrictions limit)
        {
            return SetJobInformationByName(jobName, NativeEnums.JobObjectInformationClass.JobObjectBasicUIRestrictions, limit);
        }

        public static bool SetJobExtendedLimitInformationsByName(string jobName, NativeStructs.JobObjectExtendedLimitInformation limit)
        {
            return SetJobInformationByName(jobName, NativeEnums.JobObjectInformationClass.JobObjectExtendedLimitInformation, limit);
        }

        public static bool SetJobEndOfTimeInformationByName(string jobName, NativeStructs.JobObjectEndOfJobTimeInformation limit)
        {
            return SetJobInformationByName(jobName, NativeEnums.JobObjectInformationClass.JobObjectEndOfJobTimeInformation, limit);
        }


        // Return job handle
        public static IntPtr GetJobHandleByName(string name, Security.JobAccess access)
        {
            return NativeFunctions.OpenJobObject(access, true, name);
        }



        // ========================================
        // Private functions
        // ========================================

        // Return list of jobs
        private static Dictionary<string, jobInfos> GetJobList()
        {
            int Length;
            int x;
            int mCount;
            int ret;
            NativeStructs.ObjectNameInformation ObjName;
            NativeStructs.SystemHandleEntry Handle;
            Dictionary<string, jobInfos> buf = new Dictionary<string, jobInfos>();
            IntPtr hProcess;
            int noNameJobIndex = 0;

            semDupHandles.WaitOne();

            // We have to get jobTypeNumber
            if (jobTypeNumber == 0)
            {
                // For an unknown reason, there seems to be a problem with
                // Windows 7 : ObjectTypeNumber for Jobs handles is 6 but
                // that is not what is retrieved using ObjectTypesInformation...
                // So, for now, we have to hardcode the value for Windows 7
                // In fact, there is a difference of 1 for all object types between
                // the value returned by GetObjectTypeNumberByName and the real
                // value.
                jobTypeNumber = GetObjectTypeNumberByName("Job");
                if (cEnvironment.IsWindows7)
                    jobTypeNumber += 1;
            }

            // HACK HACK HACK HACK
            // Here is how we retrieve the job list :
            // - we enumerate all handles
            // - we select all handles with type = job
            // - we duplicate these handles to have access in our application (if they are
            // not already owned by our application)
            // This is it !
            // NOTE : we should NOT keep these handles (if duplicated) opened as it might implies
            // a change of bevahior in jobs which have JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE limit,
            // as they terminate only when all opened handles are closed.
            // SO we save the list of opened handle some time (as we must have the handle
            // to access to the job !), and we then close/reopen them each enumeration

            // Closed previously duplicated handles
            // We refresh the informations (stats) if demanded
            foreach (IntPtr ptr in _dupHandles.Values)
            {
                if (ptr.IsNotNull())
                    Native.Objects.General.CloseHandle(ptr);
            }
            _dupHandles.Clear();

            Length = memAllocJobs.Size;
            // While length is too small
            while (NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemHandleInformation, memAllocJobs.Pointer, memAllocJobs.Size, ref ret) == STATUS_INFO_LENGTH_MISMATCH)
            {
                // Resize buffer
                Length = Length * 2;
                memAllocJobs.Resize(Length);
            }

            // Get the number of handles 
            mCount = memAllocJobs.ReadStruct<NativeStructs.SystemHandleInformation>().HandleCount;

            // Resize our array
            int objTypeOffsetInStruct = NativeStructs.SystemHandleInformation_ObjectTypeOffset;
            int structSize = Marshal.SizeOf(typeof(NativeStructs.SystemHandleEntry));
            int handlesOffset = NativeStructs.SystemHandleInformation.HandlesOffset;
            var loopTo = mCount - 1;
            for (x = 0; x <= loopTo; x++)
            {
                // We do not retrieve the entire SystemHandleInformation struct
                // cause it requires too much CPU time
                // We just retrieve the Byte which represent the object type

                // &h4 offset because of HandleCount on 4 first bytes
                int type = memAllocJobs.ReadByte(objTypeOffsetInStruct + handlesOffset + x * structSize);
                if (type == jobTypeNumber)
                {

                    // This is a job !

                    // Get entire struct
                    Handle = memAllocJobs.ReadStruct<NativeStructs.SystemHandleEntry>(handlesOffset, x);

                    // Retrieve its name
                    string theName;
                    IntPtr targetHandle;

                    // If this handle belongs to our process, there is no need
                    // to duplicate it
                    if (Handle.ProcessId == NativeFunctions.GetCurrentProcessId())
                    {
                        targetHandle = new IntPtr(Handle.Handle);

                        if (targetHandle.IsNotNull())
                        {
                            NativeFunctions.ZeroMemory(BufferObjNameJob, new IntPtr(0x200));
                            NativeFunctions.NtQueryObject(targetHandle, NativeEnums.ObjectInformationClass.ObjectNameInformation, BufferObjNameJob.Pointer, BufferObjNameJob.Size, ref ret);
                            ObjName = BufferObjNameJob.ReadStruct<NativeStructs.ObjectNameInformation>(0);
                            theName = Marshal.PtrToStringUni(ObjName.Name.Buffer);

                            // Add to dico
                            // The key is the name
                            if (!(string.IsNullOrEmpty(theName)))
                            {
                                if (buf.ContainsKey(theName) == false)
                                    buf.Add(theName, new jobInfos(theName));

                                // Add handle to list
                                if (_ownHandles.ContainsKey(theName) == false)
                                    _ownHandles.Add(theName, targetHandle);
                            }
                        }
                    }
                    else
                    {

                        // Open an handle to the process which owns our handle
                        hProcess = Native.Objects.Process.GetProcessHandleById(Handle.ProcessId, Security.ProcessAccess.DupHandle);

                        if (hProcess.IsNotNull())
                        {

                            // Duplicate the handle in our process with same access
                            NativeFunctions.DuplicateHandle(hProcess, new IntPtr(Handle.Handle), NativeFunctions.GetCurrentProcess(), ref targetHandle, Security.JobAccess.All, false, 0);
                            // Close process' handle
                            Objects.General.CloseHandle(hProcess);

                            if (targetHandle.IsNotNull())
                            {
                                NativeFunctions.ZeroMemory(BufferObjNameJob, new IntPtr(0x200));
                                NativeFunctions.NtQueryObject(targetHandle, NativeEnums.ObjectInformationClass.ObjectNameInformation, BufferObjNameJob.Pointer, BufferObjNameJob.Size, ref ret);
                                ObjName = BufferObjNameJob.ReadStruct<NativeStructs.ObjectNameInformation>(0);
                                theName = Marshal.PtrToStringUni(ObjName.Name.Buffer);

                                // Add to dico only NAMED jobs
                                // The key is theName
                                if (string.IsNullOrEmpty(theName) == false)
                                {
                                    if (buf.ContainsKey(theName) == false)
                                        buf.Add(theName, new jobInfos(theName));

                                    // Add the handle to the list of duplicated handles
                                    // So we will close it just before next enumeration
                                    // to avoid to multiple per 2 each enumeration the number
                                    // of handles... And to avoid JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE limit issue
                                    if (_dupHandles.ContainsKey(theName) == false)
                                        _dupHandles.Add(theName, targetHandle);
                                    else
                                        Objects.General.CloseHandle(targetHandle);
                                }
                                else
                                {
                                    // Then the job has no name...
                                    // We will create a name for this job, as a name
                                    // is expected as a primary key for dictionaries.

                                    noNameJobIndex += 1;
                                    theName = "(no name)[" + noNameJobIndex.ToString() + "]";

                                    if (buf.ContainsKey(theName) == false)
                                        buf.Add(theName, new jobInfos(theName));

                                    // Add the handle to the list of duplicated handles
                                    // So we will close it just before next enumeration
                                    // to avoid to multiple per 2 each enumeration the number
                                    // of handles... And to avoid JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE limit issue
                                    if (_dupHandles.ContainsKey(theName) == false)
                                        _dupHandles.Add(theName, targetHandle);
                                }
                            }
                        }
                    }
                }
            }

            semDupHandles.Release();

            // Now refresh informations for all jobs
            foreach (jobInfos j in buf.Values)
                j.Refresh();

            return buf;
        }

        // Query a job information struct
        internal static T QueryJobInformationByName<T>(string name, NativeEnums.JobObjectInformationClass info)
        {

            // Query valid handle
            IntPtr handle = BeginUsingValidJobHandle(name);

            int ret;
            T retStruct = default(T);

            if (handle.IsNotNull())
            {
                using (Memory.MemoryAlloc memAlloc = new Memory.MemoryAlloc(Marshal.SizeOf(typeof(T))))
                {
                    if (!NativeFunctions.QueryInformationJobObject(handle, info, memAlloc.Pointer, memAlloc.Size, ref ret))
                    {
                        // Need a greater mem alloc
                        memAlloc.Resize(ret);

                        NativeFunctions.QueryInformationJobObject(handle, info, memAlloc.Pointer, memAlloc.Size, ref ret);
                    }

                    retStruct = memAlloc.ReadStruct<T>();
                }
            }

            // End using handle
            EndUsingValidJobHandle();

            return retStruct;
        }

        // Set a job information struct
        internal static bool SetJobInformationByName<T>(string name, NativeEnums.JobObjectInformationClass info, T limit)
        {

            // Query valid handle
            IntPtr handle = BeginUsingValidJobHandle(name);

            bool ret;

            if (handle.IsNotNull())
            {
                using (Memory.MemoryAlloc memAlloc = new Memory.MemoryAlloc(Marshal.SizeOf(typeof(T))))
                {
                    memAlloc.WriteStruct<T>(limit);
                    ret = NativeFunctions.SetInformationJobObject(handle, info, memAlloc.Pointer, memAlloc.Size);
                }
            }

            // End using handle
            EndUsingValidJobHandle();

            return ret;
        }

        // Return ObjectTypeNumber associated to a ObjectType defined by its name
        private static int GetObjectTypeNumberByName(string typeName)
        {
            int cbReqLength;
            int cTypeCount;
            int x;
            NativeStructs.ObjectTypeInformation TypeInfo;
            string strType;

            // Request size for types informations
            using (Memory.MemoryAlloc memAlloc = new Memory.MemoryAlloc(0x100))
            {
                NativeFunctions.NtQueryObject(IntPtr.Zero, NativeEnums.ObjectInformationClass.ObjectTypesInformation, memAlloc.Pointer, memAlloc.Size, ref cbReqLength);
                memAlloc.Resize(cbReqLength);

                // Retrive list of types
                NativeFunctions.NtQueryObject(IntPtr.Zero, NativeEnums.ObjectInformationClass.ObjectTypesInformation, memAlloc.Pointer, cbReqLength, ref cbReqLength);

                // Get number of struct to read
                cTypeCount = memAlloc.ReadStruct<NativeStructs.ObjectTypesInformation>().ObjectTypesCount;

                int offset = NativeStructs.ObjectTypesInformation.ObjectTypeInformationOffset;
                var loopTo = cTypeCount - 1;
                for (x = 0; x <= loopTo; x++)
                {
                    // Retrieve name of type
                    TypeInfo = memAlloc.ReadStruct<NativeStructs.ObjectTypeInformation>(offset, x);
                    strType = Common.Misc.ReadUnicodeString(TypeInfo.Name);
                    if (typeName == strType)
                        return x + 1;

                    // Find the position of the next element in the structure.
                    // The format of the structure is:
                    // -------------------
                    // | Type1 Information | [sizeof(OBJECT_TYPE_INFORMATION)]
                    // | Type1 Type Name   | [OBJECT_TYPE_INFORMATION.TypeName.MaximumLength]
                    // | Alignement        | [0-3 Bytes for 32-bits, 0-7 bytes for 64-bits]
                    // | Type2 Information | 
                    // 
                    // | TypeN Information |
                    // | TypeN Type Name   |
                    // -------------------
                    // The beginning of each type is aligned on IntPtr.size bytes boudary.
                    // 
                    // Find the offset(aligned) to the next item
                    // Magic operation :
                    offset += TypeInfo.Name.MaximumLength + (IntPtr.Size - 1) & !(IntPtr.Size - 1);
                }
            }

            if (typeName == "Driver")
                return 24;
            else if (typeName == "IoCompletion")
                return 25;
            else if (typeName == "File")
                return 26;
            else
                return -1;
        }
    }
}

