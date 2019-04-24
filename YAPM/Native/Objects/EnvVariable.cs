using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace Native.Objects
{
    public class EnvVariable
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

        // Return environment variables
        public static int GetEnvironmentVariablesBycProcess(ref cProcess process, ref string[] variables, ref string[] values)
        {
            return GetEnvironmentVariables(process.Infos.PebAddress, process.Infos.ProcessId, ref variables, ref values);
        }

        // Return environment variables
        public static int GetEnvironmentVariables(IntPtr peb, int pid, ref string[] variables, ref string[] values)
        {
            variables = new string[0];
            values = new string[0];

            // Get PEB address of process
            IntPtr pebAddress = peb;
            if (pebAddress.IsNull())
                return 0;

            // Create a processMemRW class to read in memory
            ProcessRW cR = new ProcessRW(pid);

            if (cR.Handle.IsNull())
                return 0;// Couldn't open a handle


            // Get address of Process parameter block
            IntPtr procParamAddress = cR.ReadIntPtr(pebAddress.Increment(Native.Api.NativeStructs.Peb_ProcessParametersOffset));


            // Get environnement block address
            IntPtr envAddress = cR.ReadIntPtr(procParamAddress.Increment(Native.Api.NativeStructs.ProcParamBlock_EnvOffset));


            // ======= Read environnement block byte per byte to calculate env. block size
            // Block is finished by a 4 consecutive null bytes (0)
            // Short variables because it's unicode coded (2 bytes per char)
            short b1 = -1;
            short b2 = -1;
            int _size = 0;

            // Read mem until 4 null char (<==> 2 null shorts)
            while (!(b1 == 0 & b2 == 0))
            {
                b1 = cR.ReadInt16(envAddress.Increment(_size));
                b2 = cR.ReadInt16(envAddress.Increment(_size + 2));
                _size += 2;
            }

            // Now we can get all env. variables from memory
            short[] blockEnv = cR.ReadInt16Array(envAddress, _size);

            // Parse these env. variables
            // Env. variables are separated by 2 null bytes ( <==> 1 null short)
            string[] _envVar;
            string __var;
            int xOld = 0;
            _envVar = new string[1];
            int y;
            var loopTo = _size / 2;
            for (int x = 0; x <= loopTo; x++)
            {
                if (blockEnv[x] == 0)
                {
                    var old_envVar = _envVar;
                    _envVar = new string[_envVar.Length + 1];
                    // Then it's variable end
                    if (old_envVar != null)
                        Array.Copy(old_envVar, _envVar, Math.Min(_envVar.Length + 1, old_envVar.Length));  // Add one item to list
                    try
                    {
                        // Parse short array to retrieve an unicode string
                        y = x * 2;
                        int __size = (y - xOld) / 2;

                        // Allocate unmanaged memory
                        IntPtr ptr = Marshal.AllocHGlobal(y - xOld);

                        // Copy from short array to unmanaged memory
                        Marshal.Copy(blockEnv, xOld / 2, ptr, __size);

                        // Convert to string (and copy to __var variable)
                        __var = Marshal.PtrToStringUni(ptr, __size);

                        // Free unmanaged memory
                        Marshal.FreeHGlobal(ptr);
                    }
                    catch (Exception ex)
                    {
                        __var = "";
                    }

                    // Insert variable
                    _envVar[_envVar.Length - 2] = __var;

                    xOld = y + 2;
                }
            }

            var old_envVar1 = _envVar;
            _envVar = new string[_envVar.Length - 2 + 1];

            // Remove useless last nothing item
            if (old_envVar1 != null)
                Array.Copy(old_envVar1, _envVar, Math.Min(_envVar.Length - 2 + 1, old_envVar1.Length));

            // Separate variables and values
            variables = new string[_envVar.Length - 2 + 1];
            values = new string[_envVar.Length - 2 + 1];
            var loopTo1 = _envVar.Length - 2;
            for (int x = 0; x <= loopTo1; x++)
            {
                int i = Strings.InStr(_envVar[x], "=", CompareMethod.Binary);
                if (i > 0)
                {
                    variables[x] = _envVar[x].Substring(0, i - 1);
                    values[x] = _envVar[x].Substring(i, _envVar[x].Length - i);
                }
                else
                {
                    variables[x] = "";
                    values[x] = "";
                }
            }

            return _envVar.Length;
        }
    }
}

