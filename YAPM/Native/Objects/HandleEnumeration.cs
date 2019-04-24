using Microsoft.VisualBasic;
using Common;
using System;
using System.Runtime.InteropServices;
using Native.Api;

namespace Native.Objects
{
    public class HandleEnumeration
    {

        // ========================================
        // Private constants
        // ========================================

        // IoCode for kernel function
        private const int IOCTL_KERNELMEMORY_GETOBJECTNAME = 0x80002004;


        // ========================================
        // Private attributes
        // ========================================

        // Some mem allocation for buffer of handles
        private Native.Memory.MemoryAlloc memAllocPIDs = new Native.Memory.MemoryAlloc(0x100);
        private Native.Memory.MemoryAlloc memAllocPID = new Native.Memory.MemoryAlloc(0x100);

        // Some other mem allocations 
        private Native.Memory.MemoryAlloc BufferObjType = new Native.Memory.MemoryAlloc(512);
        private Native.Memory.MemoryAlloc BufferObjName = new Native.Memory.MemoryAlloc(512);
        private Native.Memory.MemoryAlloc BufferObjBasic = new Native.Memory.MemoryAlloc(Marshal.SizeOf(typeof(NativeStructs.ObjectBasicInformation)));

        // Currently opened driver
        private IntPtr hProcess;
        private int lastPID;

        // Use driver or not ?
        private bool useDriver;

        // List of handles
        private handleInfos[] m_Files;

        // Number of handles
        private int m_cHandles;

        // Handle to the driver
        private IntPtr hDriver;

        // Driver control class
        private Native.Driver.DriverCtrl driver;


        // ========================================
        // Public properties
        // ========================================

        // Handle count
        public int Count
        {
            get
            {
                return m_cHandles;
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Refresh list of handles
        // One PIDs or a list of PIDs
        public void Refresh(int oneProcessId = -1)
        {
            // oneProcessId = -1 <=> all processes
            CreateQueryHandlesBuffer(oneProcessId);
        }
        public void Refresh(int[] PIDs)
        {
            CreateQueryHandlesBuffer(PIDs);
        }


        // Properties of a handle
        public bool IsNotNull(int dwIndex)  // Item is null ?
        {
            return m_Files[dwIndex] != null;
        }
        public handleInfos GetHandleInfos(int dwIndex) // All infos
        {
            return m_Files[dwIndex];
        }
        public string GetObjectName(int dwIndex)   // Name
        {
            return m_Files[dwIndex].Name;
        }
        public string GetNameInformation(int dwIndex) // Type 
        {
            return m_Files[dwIndex].Type;
        }
        public string GetProcessName(int dwIndex)  // Proprietary process name
        {
            return GetProcessNameFromPID(m_Files[dwIndex].ProcessId);
        }
        public int GetProcessID(int dwIndex)   // Proprietary process ID
        {
            return m_Files[dwIndex].ProcessId;
        }
        public IntPtr GetHandle(int dwIndex)  // Handle itself
        {
            return m_Files[dwIndex].Handle;
        }
        public IntPtr GetObjectAddress(int dwIndex)  // Obj address
        {
            return m_Files[dwIndex].ObjectAddress;
        }
        public int GetObjectCount(int dwIndex) // Obj count
        {
            return m_Files[dwIndex].ObjectCount;
        }
        public Native.Security.StandardRights GetGrantedAccess(int dwIndex)  // Access to the object
        {
            return m_Files[dwIndex].GrantedAccess;
        }
        public uint GetAttributes(int dwIndex) // Attributes
        {
            return m_Files[dwIndex].Attributes;
        }
        public int GetHandleCount(int dwIndex) // Count
        {
            return m_Files[dwIndex].HandleCount;
        }
        public uint GetPointerCount(int dwIndex) // Number of references to the pointer to this object
        {
            return m_Files[dwIndex].PointerCount;
        }
        public decimal GetCreateTime(int dwIndex) // Creation time of object
        {
            return m_Files[dwIndex].CreateTime;
        }
        public int GetPagedPoolUsage(int dwIndex) // Paged pool usage
        {
            return m_Files[dwIndex].PagedPoolUsage;
        }
        public int GetNonPagedPoolUsage(int dwIndex)  // Non-paged pool usage
        {
            return m_Files[dwIndex].NonPagedPoolUsage;
        }

        // Close this instance (close some handles and the kernel if necessary)
        public void Close()
        {
            Class_Terminate_Renamed();
        }

        // Constructor
        public HandleEnumeration(bool useKDriver) : base()
        {
            useDriver = useKDriver;

            // If we use the driver, we install it
            if (useDriver)
            {
                bool ret;

                // Instanciate driverCtrl class
                driver = new Native.Driver.DriverCtrl();

                {
                    var withBlock = driver;

                    // Configure the driver
                    withBlock.ServiceDisplayName = "KernelMemory";
                    withBlock.ServiceErrorType = NativeEnums.ServiceErrorControl.Normal;
                    withBlock.ServiceFileName = My.MyProject.Application.Info.DirectoryPath + @"\KernelMemory.sys";
                    withBlock.ServiceName = "KernelMemory";
                    withBlock.ServiceStartType() = NativeEnums.ServiceStartType.DemandStart;
                    withBlock.ServiceType = NativeEnums.ServiceType.KernelDriver;

                    // Register service
                    ret = withBlock.InstallService();

                    // Start it
                    ret = withBlock.StartService();

                    // Get a handle to the driver
                    hDriver = withBlock.OpenDriver();
                }
            }
        }


        // ========================================
        // Private functions
        // ========================================

        // Create a buffer containing handles
        private void CreateQueryHandlesBuffer(int oneProcessId = -1)
        {
            int Length;
            int x;
            int ret;
            NativeStructs.SystemHandleEntry Handle;

            Length = memAllocPIDs.Size;
            // While length is too small
            while (NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemHandleInformation, memAllocPIDs.Pointer, memAllocPIDs.Size, ref ret) == NativeConstants.STATUS_INFO_LENGTH_MISMATCH)
            {
                // Resize buffer
                Length = Length * 2;
                memAllocPIDs.Resize(Length);
            }

            // Get the number of handles 
            m_cHandles = memAllocPIDs.ReadStruct<NativeStructs.SystemHandleInformation>().HandleCount;

            int procIdOffsetInStruct = Native.Api.NativeStructs.SystemHandleInformation_ProcessIdOffset;
            int structSize = Marshal.SizeOf(typeof(NativeStructs.SystemHandleEntry));
            int handlesOffset = NativeStructs.SystemHandleInformation.HandlesOffset;

            // Resize our array
            m_Files = new handleInfos[m_cHandles - 1 + 1];
            var loopTo = m_cHandles - 1;
            for (x = 0; x <= loopTo; x++)
            {
                // Do not retrieve the whole struct cause it requires too much CPU
                // Just retrieve the processId for now
                int pid = memAllocPIDs.ReadInt32(procIdOffsetInStruct + handlesOffset + x * structSize);
                // Only if handle belongs to specified process
                if (oneProcessId == -1 || oneProcessId == pid)
                {
                    // Ok, now we get the whole struct !
                    // &h4 offset because of HandleCount on 4 first bytes
                    Handle = memAllocPIDs.ReadStruct<NativeStructs.SystemHandleEntry>(handlesOffset, x);

                    m_Files[x] = RetrieveObject(ref Handle);
                }
            }


            // Close handle to last used process
            CloseProcessForHandle();
        }

        // Create a buffer containing handles
        private void CreateQueryHandlesBuffer(int[] PIDs)
        {
            if (PIDs == null)
            {
                m_Files = new handleInfos[0];
                m_cHandles = 0;
                return;
            }

            int Length;
            int X;
            int ret;
            NativeStructs.SystemHandleEntry Handle;

            Length = memAllocPIDs.Size;
            // While length is too small
            while (NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemHandleInformation, memAllocPIDs.Pointer, memAllocPIDs.Size, ref ret) == NativeConstants.STATUS_INFO_LENGTH_MISMATCH)
            {
                // Resize buffer
                Length = Length * 2;
                memAllocPIDs.Resize(Length);
            }

            // Get the number of handles
            m_cHandles = memAllocPIDs.ReadStruct<NativeStructs.SystemHandleInformation>().HandleCount;

            int procIdOffsetInStruct = Native.Api.NativeStructs.SystemHandleInformation_ProcessIdOffset;
            int structSize = Marshal.SizeOf(typeof(NativeStructs.SystemHandleEntry));
            int handlesOffset = NativeStructs.SystemHandleInformation.HandlesOffset;

            // Resize our array
            m_Files = new handleInfos[m_cHandles - 1 + 1];
            var loopTo = m_cHandles - 1;
            for (X = 0; X <= loopTo; X++)
            {
                // Do not retrieve the whole struct cause it requires too much CPU
                // Just retrieve the processId for now
                int pid = memAllocPIDs.ReadInt32(procIdOffsetInStruct + handlesOffset + X * structSize);
                // Only if handle belongs to specified process
                foreach (int __pid in PIDs)
                {
                    if (pid == __pid)
                    {
                        // Ok, now we get the whole struct !
                        // &h4 offset because of HandleCount on 4 first bytes
                        Handle = memAllocPIDs.ReadStruct<NativeStructs.SystemHandleEntry>(handlesOffset, X);

                        m_Files[X] = RetrieveObject(ref Handle);
                    }
                }
            }

            // Close handle of last process
            CloseProcessForHandle();
        }

        // Open a handle to process ProcessId
        // Used to duplicate handles of handles owned by the process
        private void OpenProcessForHandle(int ProcessID)
        {
            if (ProcessID != lastPID)
            {
                NativeFunctions.CloseHandle(hProcess);
                hProcess = Native.Objects.Process.GetProcessHandleById(ProcessID, Security.ProcessAccess.DupHandle);
                lastPID = ProcessID;
            }
        }

        // Close handle to the process (PID = lastPID)
        private void CloseProcessForHandle()
        {
            NativeFunctions.CloseHandle(hProcess);
            hProcess = IntPtr.Zero;
            lastPID = 0;
        }

        // Create buffer with all informations about our handle
        private handleInfos RetrieveObject(ref NativeStructs.SystemHandleEntry Handle)
        {
            int ret;
            IntPtr hHandle;
            NativeStructs.ObjectBasicInformation ObjBasic;
            NativeStructs.ObjectTypeInformation ObjType;
            NativeStructs.ObjectNameInformation ObjName;
            string m_ObjectTypeName;
            string m_ObjectName;

            // Create the instance of the structure we'll return
            handleInfos h = new handleInfos();

            // Open an handle to the process which owns our handle
            OpenProcessForHandle(Handle.ProcessId);

            // Duplicate the handle in our process with same access
            NativeFunctions.DuplicateHandle(hProcess, new IntPtr(Handle.Handle), NativeFunctions.GetCurrentProcess(), ref hHandle, 0, false, NativeEnums.DuplicateOptions.SameAccess);

            // If we failed... we failed.
            if (hHandle.IsNull())
                return h;

            // Get Basic infos about object
            NativeFunctions.NtQueryObject(hHandle, NativeEnums.ObjectInformationClass.ObjectAttributes, BufferObjBasic.Pointer, Marshal.SizeOf(ObjBasic), ref ret);
            ObjBasic = BufferObjBasic.ReadStruct<NativeStructs.ObjectBasicInformation>(0);

            // Get Type infos about object
            NativeFunctions.NtQueryObject(hHandle, NativeEnums.ObjectInformationClass.ObjectTypeInformation, BufferObjType.Pointer, BufferObjType.Size, ref ret);
            ObjType = BufferObjType.ReadStruct<NativeStructs.ObjectTypeInformation>(0);
            m_ObjectTypeName = Marshal.PtrToStringUni(ObjType.Name.Buffer);


            NativeFunctions.ZeroMemory(BufferObjName, new IntPtr(0x200));

            // Get the name of the object
            if (m_ObjectTypeName == "File")
            {
                // Have to use our kernel if it is a file
                // ======== requкte pour obtenir le nom d'un handle
                // hDevice : handle du driver KernelMemory
                // dwIoControlCode : IOCTL_KERNELMEMORY_GETOBJECTNAME
                // lpInBuffer : une structure SYSTEM_HANDLE_INFORMATION contenant les infos sur le handle
                // nInBufferSize : taille de la structure SYSTEM_HANDLE_INFORMATION
                // lpOutBuffer : tampon d'une taille suffisante pour contenir le nom du handle (au moins MAX_PATH caractиres)
                // nOutBufferSize : taille de ce tampon
                // lpBytesReturned : taille des donnйes retournйe (sauf erreur : nOutBufferSize)
                // lpOverlapped : nul
                // renvoie ERROR_SUCCESS ou ERROR_BUFFER_TOO_SMALL
                NativeFunctions.DeviceIoControl(hDriver, IOCTL_KERNELMEMORY_GETOBJECTNAME, ref Handle, 16, BufferObjName.Pointer, 512, ref ret, IntPtr.Zero);
                ObjName = BufferObjName.ReadStruct<NativeStructs.ObjectNameInformation>(0);
                // TODO64 -> x64 not compatible !!!!!
                m_ObjectName = Marshal.PtrToStringUni(BufferObjName.Pointer.Increment(8));
            }
            else
            {
                // Not a file, so we query handle name withNtQueryObject
                NativeFunctions.NtQueryObject(hHandle, NativeEnums.ObjectInformationClass.ObjectNameInformation, BufferObjName.Pointer, BufferObjName.Size, ref ret);
                ObjName = BufferObjName.ReadStruct<NativeStructs.ObjectNameInformation>(0);
                m_ObjectName = Marshal.PtrToStringUni(ObjName.Name.Buffer);
            }


            // Get the name of the handle for differents objects
            if (m_ObjectTypeName == "File")
                // Get DOS path
                m_ObjectName = Common.Misc.DeviceDriveNameToDosDriveName(m_ObjectName);
            else if (m_ObjectTypeName == "Key")
                // Get key as a standard key (not internal)
                m_ObjectName = GetKeyName(m_ObjectName);
            else if (m_ObjectTypeName == "Process")
            {
                // If it's a process, we retrieve processID from handle
                int i = NativeFunctions.GetProcessId(hHandle);
                m_ObjectName = GetProcessNameFromPID(i) + " (" + System.Convert.ToString(i) + ")";
            }
            else if (m_ObjectTypeName == "Thread" && cEnvironment.SupportsGetThreadIdFunction)
            {
                // Have to get thread ID, and then, Process ID
                // These functions are only present in a VISTA OS
                int i = NativeFunctions.GetThreadId(hHandle);
                int i2 = NativeFunctions.GetProcessIdOfThread(hHandle);
                m_ObjectName = GetProcessNameFromPID(i2) + " (" + System.Convert.ToString(i2) + ")" + " - " + System.Convert.ToString(i);
            }

            // Close the duplicated handle
            NativeFunctions.CloseHandle(hHandle);

            // Return all informations we've got
            {
                var withBlock = h;
                withBlock._Attributes = (NativeEnums.HandleFlags)ObjBasic.Attributes;
                withBlock._CreateTime = ObjBasic.CreateTime;
                withBlock._Flags = Handle.Flags;
                withBlock._GenericAll = ObjType.GenericMapping.GenericAll;
                withBlock._GenericExecute = ObjType.GenericMapping.GenericExecute;
                withBlock._GenericRead = ObjType.GenericMapping.GenericRead;
                withBlock._GenericWrite = ObjType.GenericMapping.GenericWrite;
                withBlock._GrantedAccess = Handle.GrantedAccess;
                withBlock._Handle = new IntPtr(Handle.Handle);
                withBlock._HandleCount = ObjType.TotalNumberOfHandles;
                withBlock._InvalidAttributes = ObjType.InvalidAttributes;
                withBlock._MaintainHandleDatabase = ObjType.MaintainTypeList;
                withBlock._NameInformation = m_ObjectTypeName;
                withBlock._NonPagedPoolUsage = ObjType.NonPagedPoolUsage;
                withBlock._ObjectAddress = Handle.Object;
                withBlock._ObjectCount = ObjType.TotalNumberOfObjects;
                withBlock._ObjectName = m_ObjectName;
                withBlock._PagedPoolUsage = ObjType.PagedPoolUsage;
                withBlock._PeakHandleCount = ObjType.HighWaterNumberOfHandles;
                withBlock._PeakObjectCount = ObjType.HighWaterNumberOfObjects;
                withBlock._PointerCount = ObjBasic.PointerCount;
                withBlock._PoolType = ObjType.PoolType;
                withBlock._ProcessID = Handle.ProcessId;
                withBlock._Unknown = ObjType.MaintainHandleCount;
                withBlock._ValidAccess = ObjType.ValidAccess;
                withBlock._ObjectTypeNumber = Handle.ObjectTypeNumber;
            }

            return h;
        }

        // Return key name from internal key name
        private string GetKeyName(string strInternalKey)
        {
            // HKEY_CURRENT_CONFIG
            strInternalKey = Strings.Replace(strInternalKey, @"\REGISTRY\MACHINE\SYSTEM\CURRENTCONTROLSET\HARDWARE PROFILES\CURRENT", "HKCC");
            // HKEY_CLASSES_ROOT
            strInternalKey = Strings.Replace(strInternalKey, @"\REGISTRY\MACHINE\SOFTWARE\CLASSES", "HKCR");
            // HKEY_USERS
            strInternalKey = Strings.Replace(strInternalKey, @"\REGISTRY\USER\S", @"HKU\S");
            // HKEY_LOCAL_MACHINE
            strInternalKey = Strings.Replace(strInternalKey, @"\REGISTRY\MACHINE", "HKLM");
            // HKEY_CURRENT_USER
            strInternalKey = Strings.Replace(strInternalKey, @"\REGISTRY\USER", "HKCU");
            // on renvoie
            return strInternalKey;
        }

        // Return process name from process ID
        private string GetProcessNameFromPID(int ProcessID)
        {
            return cProcess.GetProcessName(ProcessID);
        }

        // Called when we want to terminate this instance
        private void Class_Terminate_Renamed()
        {
            // Close handle to the "current process"
            CloseProcessForHandle();
            // Close handle to the driver
            NativeFunctions.CloseHandle(hDriver);
            // Stop the driver & remove it
            try
            {
                if (driver != null)
                {
                    driver.StopService();
                    driver.RemoveService();
                    driver = null;
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        ~HandleEnumeration()
        {
            Class_Terminate_Renamed();
        }
    }
}
