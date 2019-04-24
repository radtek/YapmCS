using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;
using System.Management;

public class cProcessConnection : cGeneralConnection
{
    internal static int instanceId = 1;
    private int _instanceId = 1;
    private asyncCallbackProcEnumerate _procEnum;
    private asyncCallbackProcEnumerate.ProcessEnumMethode _enumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses;

    // For processor count
    private static int _processors = 1;

    public cProcessConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedEventHandler de) : base(ControlWhichGetInvoked, ref Conn)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _procEnum = new asyncCallbackProcEnumerate(ref _control, de, ref this, _instanceId);
    }


    public delegate void ConnectedEventHandler(bool Success);
    public delegate void DisconnectedEventHandler(bool Success);
    public delegate void HasEnumeratedEventHandler(bool Success, Dictionary<string, processInfos> Dico, string errorMessage, int instanceId);

    public ConnectedEventHandler Connected;
    public DisconnectedEventHandler Disconnected;
    public HasEnumeratedEventHandler HasEnumerated;



    public static int ProcessorCount
    {
        get
        {
            return _processors;
        }
    }
    public asyncCallbackProcEnumerate.ProcessEnumMethode EnumMethod
    {
        get
        {
            return _enumMethod;
        }
        set
        {
            _enumMethod = value;
        }
    }




    // Connection
    protected override void asyncConnect(object useless)
    {
        _processors = 0;         // Reinit processor count

        // Connect
        switch (_conObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    // When we are here, the socket IS CONNECTED
                    _sock = ConnectionObj.Socket;
                    _connected = true;
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    ConnectionOptions __con = new ConnectionOptions();
                    __con.Impersonation = ImpersonationLevel.Impersonate;
                    __con.Password = Common.Misc.SecureStringToCharArray(ref _conObj.WmiParameters.password);
                    __con.Username = _conObj.WmiParameters.userName;

                    try
                    {
                        wmiSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Process");
                        wmiSearcher.Scope = new System.Management.ManagementScope(@"\\" + _conObj.WmiParameters.serverName + @"\root\cimv2", __con);
                        _connected = true;
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }

            default:
                {
                    // Local
                    _connected = true;
                    if (Connected != null && _control.Created)
                        _control.Invoke(Connected, true);
                    break;
                }
        }


        // Get processor count
        switch (_conObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    try
                    {
                        ManagementObjectSearcher objSearcherSystem = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                        objSearcherSystem.Scope = wmiSearcher.Scope;
                        int _count = 0;
                        foreach (System.Management.ManagementObject res in objSearcherSystem.Get())
                            _count += 1;
                        _processors = _count;
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Could not get informations about the remote system");
                        _processors = 1;
                    }

                    break;
                }

            default:
                {
                    // Local
                    _processors = cSystemInfo.GetProcessorCount();
                    break;
                }
        }
    }

    // Disconnect
    protected override void asyncDisconnect(object useless)
    {
        _processors = 0;     // Reinit processor count

        switch (_conObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    _connected = false;
                    if (Disconnected != null && _control.Created)
                        _control.Invoke(Disconnected, true);
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    _connected = false;
                    if (Disconnected != null && _control.Created)
                        _control.Invoke(Disconnected, true);
                    break;
                }

            default:
                {
                    // Local
                    _connected = false;
                    if (Disconnected != null && _control.Created)
                        _control.Invoke(Disconnected, true);
                    break;
                }
        }
    }



    // Enumerate processes
    public int Enumerate(bool getFixedInfos, int forInstanceId = -1, asyncCallbackProcEnumerate.ProcessEnumMethode enumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses, bool forceAllInfos = false)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_procEnum.Process()), new asyncCallbackProcEnumerate.poolObj(forInstanceId, _enumMethod, forceAllInfos));
    }



    protected override void _sock_Connected()
    {
        _connected = true;
    }

    protected override void _sock_Disconnected()
    {
        _connected = false;
    }

    protected new void _sock_ReceivedData(ref cSocketData data)
    {

        // Exit immediately if not connected
        if (Program.Connection.IsConnected == false || Program.Connection.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaSocket)
            return;

        if (data == null)
        {
            Trace.WriteLine("Serialization error");
            return;
        }

        if (data.Type == cSocketData.DataType.Order && data.Order == cSocketData.OrderType.ReturnProcessorCount)
            _processors = System.Convert.ToInt32(data.Param1);

        if (_processors == 0)
        {
            // Send the request
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestProcessorCount);
                _conObj.Socket.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Could not send request to server");
            }
        }

        if (data.Type == cSocketData.DataType.RequestedList && data.Order == cSocketData.OrderType.RequestProcessList)
        {
            if (_instanceId == data.InstanceId)
                // OK it is for me
                _procEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys);
        }
    }

    protected override void _sock_SentData()
    {
    }
}

