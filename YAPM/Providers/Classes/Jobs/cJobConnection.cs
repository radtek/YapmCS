using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;
using System.Management;

public class cJobConnection : cGeneralConnection
{
    internal static int instanceId = 1;
    private int _instanceId = 1;
    private asyncCallbackJobEnumerate _jobEnum;
    private asyncCallbackProcessesInJobEnumerate _procInJobEnum;

    public cJobConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedEventHandler de) : base(ControlWhichGetInvoked, ref Conn)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _jobEnum = new asyncCallbackJobEnumerate(ref _control, de, ref this, _instanceId);
    }

    public cJobConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedProcInJobEventHandler de) : base(ControlWhichGetInvoked, ref Conn)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _procInJobEnum = new asyncCallbackProcessesInJobEnumerate(ref _control, de, ref this, _instanceId);
    }



    public delegate void ConnectedEventHandler(bool Success);
    public delegate void DisconnectedEventHandler(bool Success);
    public delegate void HasEnumeratedEventHandler(bool Success, Dictionary<string, jobInfos> Dico, string errorMessage, int instanceId);
    public delegate void HasEnumeratedProcInJobEventHandler(bool Success, Dictionary<string, processInfos> Dico, string errorMessage, int instanceId);

    public ConnectedEventHandler Connected;
    public DisconnectedEventHandler Disconnected;
    public HasEnumeratedEventHandler HasEnumerated;
    public HasEnumeratedProcInJobEventHandler HasEnumeratedProcessesInJob;



    // Connection
    protected override void asyncConnect(object useless)
    {

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
                        wmiSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_NamedJobObject");
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
                    try
                    {
                        if (Connected != null)
                            _control.Invoke(Connected, true);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }
        }
    }

    // Disconnect
    protected override void asyncDisconnect(object useless)
    {
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



    // Enumerate jobs
    public int Enumerate(bool getFixedInfos, int forInstanceId = -1)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_jobEnum.Process()), new asyncCallbackJobEnumerate.poolObj(forInstanceId));
    }

    // Enumerate processes in a job
    public int EnumerateProcessesInJob(string jobName, int forInstanceId = -1)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_procInJobEnum.Process()), new asyncCallbackProcessesInJobEnumerate.poolObj(jobName, forInstanceId));
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

        if (data.Type == cSocketData.DataType.RequestedList)
        {
            if (data.Order == cSocketData.OrderType.RequestJobList)
            {
                if (_instanceId == data.InstanceId)
                    // OK it is for me
                    _jobEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys);
            }
            else if (data.Order == cSocketData.OrderType.RequestProcessesInJobList)
            {
                if (_instanceId == data.InstanceId)
                    // OK it is for me
                    _procInJobEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys);
            }
        }
    }

    protected override void _sock_SentData()
    {
    }
}

