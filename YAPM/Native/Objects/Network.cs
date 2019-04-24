using Microsoft.VisualBasic;
using Common;
using System.Collections.Generic;
using System;
using System.Net;
using Native.Api;

namespace Native.Objects
{
    public class Network
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


        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        public static void EnumerateTcpUdpConnections(ref Dictionary<string, networkInfos> _dico, bool allProcesses, int processId = default(int))
        {
            int count;
            int length;


            // ===== TCP (IpV4)
            length = 0;
            NativeFunctions.GetExtendedTcpTable(IntPtr.Zero, ref length, false, NativeEnums.IpVersion.AfInet, Enums.TcpTableClass.OwnerPidAll, 0);

            using (Memory.MemoryAlloc memBuf = new Memory.MemoryAlloc(length))
            {
                if (NativeFunctions.GetExtendedTcpTable(memBuf, ref length, false, NativeEnums.IpVersion.AfInet, Enums.TcpTableClass.OwnerPidAll, 0) == 0)
                {

                    // Read number of items
                    count = memBuf.ReadInt32(0);
                    var loopTo = count - 1;
                    for (int i = 0; i <= loopTo; i++)
                    {
                        NativeStructs.MibTcpRowOwnerPid tcp_item = memBuf.ReadStruct<NativeStructs.MibTcpRowOwnerPid>(0x4, i);


                        // Test if belongs to PID list
                        bool bOkToAdd = allProcesses || (processId == tcp_item.OwningPid);

                        if (bOkToAdd)
                        {
                            IPEndPoint n = null;
                            if (tcp_item.LocalAddr > 0)
                                n = new IPEndPoint(tcp_item.LocalAddr, Misc.PermuteBytes(tcp_item.LocalPort));
                            else
                                n = new IPEndPoint(0, Misc.PermuteBytes(tcp_item.LocalPort));
                            IPEndPoint n2;
                            if (tcp_item.RemoteAddr > 0)
                                n2 = new IPEndPoint(tcp_item.RemoteAddr, Misc.PermuteBytes(tcp_item.RemotePort));
                            else
                                n2 = null;

                            Structs.LightConnection res = new Structs.LightConnection();
                            {
                                var withBlock = res;
                                withBlock.dwOwningPid = tcp_item.OwningPid;
                                withBlock.dwState = tcp_item.State;
                                withBlock.local = n;
                                withBlock.remote = n2;
                                withBlock.dwType = Enums.NetworkProtocol.Tcp;
                            }
                            string key = res.dwOwningPid.ToString() + "-" + Enums.NetworkProtocol.Tcp.ToString() + "-" + res.local.ToString();
                            if (_dico.ContainsKey(key) == false)
                                _dico.Add(key, new networkInfos(res));
                        }
                    }
                }
            }


            // ===== UDP (IPv4)
            length = 0;
            NativeFunctions.GetExtendedUdpTable(IntPtr.Zero, ref length, false, NativeEnums.IpVersion.AfInet, Enums.UdpTableClass.OwnerPid, 0);

            using (Memory.MemoryAlloc memBuf = new Memory.MemoryAlloc(length))
            {
                if (NativeFunctions.GetExtendedUdpTable(memBuf, ref length, false, NativeEnums.IpVersion.AfInet, Enums.UdpTableClass.OwnerPid, 0) == 0)
                {
                    // Read number of items
                    count = memBuf.ReadInt32(0);
                    var loopTo1 = count - 1;
                    for (int i = 0; i <= loopTo1; i++)
                    {
                        NativeStructs.MibUdpRowOwnerId udp_item = memBuf.ReadStruct<NativeStructs.MibUdpRowOwnerId>(0x4, i);


                        // Test if belongs to PID list
                        bool bOkToAdd = allProcesses || (processId == udp_item.OwningPid);

                        if (bOkToAdd)
                        {
                            IPEndPoint n = null;
                            if (udp_item.LocalAddr > 0)
                                n = new IPEndPoint(udp_item.LocalAddr, Misc.PermuteBytes(udp_item.LocalPort));
                            else
                                n = new IPEndPoint(0, Misc.PermuteBytes(udp_item.LocalPort));

                            Structs.LightConnection res = new Structs.LightConnection();
                            {
                                var withBlock1 = res;
                                withBlock1.dwOwningPid = udp_item.OwningPid;
                                withBlock1.dwState = 0;
                                withBlock1.local = n;
                                withBlock1.dwType = Enums.NetworkProtocol.Udp;
                                withBlock1.remote = null;
                            }

                            string key = res.dwOwningPid.ToString() + "-" + Enums.NetworkProtocol.Udp.ToString() + "-" + res.local.ToString();
                            if (_dico.ContainsKey(key) == false)
                                _dico.Add(key, new networkInfos(res));
                        }
                    }
                }
            }


            // ===== TCP (IPv6)
            length = 0;
            NativeFunctions.GetExtendedTcpTable(IntPtr.Zero, ref length, false, NativeEnums.IpVersion.AfInt6, Enums.TcpTableClass.OwnerPidAll, 0);

            using (Memory.MemoryAlloc memBuf = new Memory.MemoryAlloc(length))
            {
                if (NativeFunctions.GetExtendedTcpTable(memBuf, ref length, false, NativeEnums.IpVersion.AfInt6, Enums.TcpTableClass.OwnerPidAll, 0) == 0)
                {
                    // Read number of items
                    count = memBuf.ReadInt32(0);
                    var loopTo2 = count - 1;
                    for (int i = 0; i <= loopTo2; i++)
                    {
                        NativeStructs.MibTcp6RowOwnerPid tcp_item = memBuf.ReadStruct<NativeStructs.MibTcp6RowOwnerPid>(0x4, i);


                        // Test if belongs to PID list
                        bool bOkToAdd = allProcesses || (processId == tcp_item.OwningPid);

                        if (bOkToAdd)
                        {
                            IPEndPoint n = null;
                            if (Common.Misc.IsByteArrayNullOrEmpty(ref tcp_item.LocalAddr) == false)
                                n = new IPEndPoint(new IPAddress(tcp_item.LocalAddr), Misc.PermuteBytes(tcp_item.LocalPort));
                            else
                                n = new IPEndPoint(0, Misc.PermuteBytes(tcp_item.LocalPort));
                            IPEndPoint n2;
                            if (Common.Misc.IsByteArrayNullOrEmpty(ref tcp_item.RemoteAddr) == false)
                                n2 = new IPEndPoint(new IPAddress(tcp_item.RemoteAddr), Misc.PermuteBytes(tcp_item.RemotePort));
                            else
                                n2 = null;

                            Structs.LightConnection res = new Structs.LightConnection();
                            {
                                var withBlock2 = res;
                                withBlock2.dwOwningPid = tcp_item.OwningPid;
                                withBlock2.dwState = tcp_item.State;
                                withBlock2.local = n;
                                withBlock2.remote = n2;
                                withBlock2.dwType = Enums.NetworkProtocol.Tcp6;
                            }
                            string key = res.dwOwningPid.ToString() + "-" + Enums.NetworkProtocol.Tcp6.ToString() + "-" + res.local.ToString();
                            if (_dico.ContainsKey(key) == false)
                                _dico.Add(key, new networkInfos(res));
                        }
                    }
                }
            }



            // ===== UDP (IPv6)
            length = 0;
            NativeFunctions.GetExtendedUdpTable(IntPtr.Zero, ref length, false, NativeEnums.IpVersion.AfInt6, Enums.UdpTableClass.OwnerPid, 0);

            using (Memory.MemoryAlloc memBuf = new Memory.MemoryAlloc(length))
            {
                if (NativeFunctions.GetExtendedUdpTable(memBuf, ref length, false, NativeEnums.IpVersion.AfInt6, Enums.UdpTableClass.OwnerPid, 0) == 0)
                {
                    // Read number of items
                    count = memBuf.ReadInt32(0);
                    var loopTo3 = count - 1;
                    for (int i = 0; i <= loopTo3; i++)
                    {
                        NativeStructs.MibUdp6RowOwnerId udp_item = memBuf.ReadStruct<NativeStructs.MibUdp6RowOwnerId>(0x4, i);


                        // Test if belongs to PID list
                        bool bOkToAdd = allProcesses || (processId == udp_item.OwningPid);

                        if (bOkToAdd)
                        {
                            IPEndPoint n = null;
                            if (Common.Misc.IsByteArrayNullOrEmpty(ref udp_item.LocalAddr) == false)
                                n = new IPEndPoint(new IPAddress(udp_item.LocalAddr), Misc.PermuteBytes(udp_item.LocalPort));
                            else
                                n = new IPEndPoint(0, Misc.PermuteBytes(udp_item.LocalPort));

                            Structs.LightConnection res = new Structs.LightConnection();
                            {
                                var withBlock3 = res;
                                withBlock3.dwOwningPid = udp_item.OwningPid;
                                withBlock3.dwState = 0;
                                withBlock3.local = n;
                                withBlock3.dwType = Enums.NetworkProtocol.Udp6;
                                withBlock3.remote = null;
                            }

                            string key = res.dwOwningPid.ToString() + "-" + Enums.NetworkProtocol.Udp6.ToString() + "-" + res.local.ToString();
                            if (_dico.ContainsKey(key) == false)
                                _dico.Add(key, new networkInfos(res));
                        }
                    }
                }
            }
        }


        // Close a TCP connection
        public static int CloseTcpConnectionByIPEndPoints(IPEndPoint local, IPEndPoint remote)
        {
            NativeStructs.MibTcpRow row = new NativeStructs.MibTcpRow();
            {
                var withBlock = row;
                if (remote != null)
                {
                    withBlock.RemotePort = Common.Misc.PermuteBytes(remote.Port);
                    withBlock.RemoteAddress = Common.Misc.GetAddressAsInteger(remote);
                }
                else
                {
                    withBlock.RemotePort = 0;
                    withBlock.RemoteAddress = 0;
                }
                withBlock.LocalAddress = Common.Misc.GetAddressAsInteger(local);
                withBlock.LocalPort = Common.Misc.PermuteBytes(local.Port);
                withBlock.State = Enums.MibTcpState.DeleteTcb;
            }

            return NativeFunctions.SetTcpEntry(ref row);
        }


        // Connect to a remote machine
        public static bool ConnectToRemoteMachine(string machineName, string user, System.Security.SecureString password)
        {

            // We should NOT use password as plain text, but that's the only way
            // to use it in Win32 functions...
            string pass = "";
            char[] b = Common.Misc.SecureStringToCharArray(ref password);
            foreach (char ch in b)
                pass += ch;

            Api.NativeStructs.NetResource Net = new Api.NativeStructs.NetResource();
            {
                var withBlock = Net;
                withBlock.dwType = NativeEnums.NetResourceType.Any;
                withBlock.lpProvider = null;
                withBlock.lpLocalName = null;
                withBlock.lpRemoteName = @"\\" + machineName + @"\IPC$";
            }

            int ret;
            ret = CancelConnection(machineName, Net, password, user);
            ret = NativeFunctions.WNetAddConnection2(ref Net, pass, user, NativeEnums.AddConnectionFlag.ConnectTemporary);
            ret = NativeFunctions.WNetAddConnection2(ref Net, pass, user, NativeEnums.AddConnectionFlag.ConnectCommandLine | NativeEnums.AddConnectionFlag.ConnectTemporary);

            if ((ret != 0) && (user != null))
            {
                if (ret == 1219)
                    // Connection already created. Disconnecting...
                    ret = CancelConnection(machineName, Net, password, user);
                else if (ret == 1326)
                {
                    if (Strings.InStr(user, '\\') == 0)
                    {
                        string CurrentUserName = @"localhost\" + user;
                        ret = NativeFunctions.WNetAddConnection2(ref Net, pass, CurrentUserName, NativeEnums.AddConnectionFlag.ConnectTemporary);
                    }
                }
                if (ret != 0)
                    // Error !
                    return false;
            }

            return true;
        }

        // Disconnect from remote machine
        public static bool DisconnectFromRemoteMachine(string machineName, bool force = true)
        {
            int ret = NativeFunctions.WNetCancelConnection2(machineName, 0, force);
            return (ret == 0);
        }

        // Copy a file to system32 dir on a remote machine...
        // This call is synchronous (blocking)
        public static bool SyncCopyFileToRemoteSystem32(string remoteMachine, string localPath, string remoteName)
        {
            string remote = @"\\" + remoteMachine + @"\ADMIN$\System32";
            return NativeFunctions.CopyFile(localPath, remote + @"\" + remoteName, false);
        }

        // Return TCP statistics
        public static NativeStructs.MibTcpStats GetTcpStatistics()
        {
            NativeStructs.MibTcpStats ret = new NativeStructs.MibTcpStats();
            NativeFunctions.GetTcpStatistics(ref ret);
            return ret;
        }

        // Return UDP statistics
        public static NativeStructs.MibUdpStats GetUdpStatistics()
        {
            NativeStructs.MibUdpStats ret = new NativeStructs.MibUdpStats();
            NativeFunctions.GetUdpStatistics(ref ret);
            return ret;
        }



        // ========================================
        // Private functions
        // ========================================

        // Cancel connection
        private static int CancelConnection(string host, NativeStructs.NetResource net, System.Security.SecureString password, string user)
        {

            // We should NOT use password as plain text, but that's the only way
            // to use it in Win32 functions...
            string pass = "";
            char[] b = Common.Misc.SecureStringToCharArray(ref password);
            foreach (char ch in b)
                pass += ch;

            DisconnectFromRemoteMachine(host);
            return NativeFunctions.WNetAddConnection2(ref net, pass, user, NativeEnums.AddConnectionFlag.ConnectTemporary);
        }
    }
}

