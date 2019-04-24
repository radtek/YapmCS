using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class cServDepConnection : cGeneralConnection
{
    public enum DependenciesToget
    {
        ServiceWhichDependsFromMe,
        DependenciesOfMe
    }

    internal static int instanceId = 1;
    private int _instanceId = 1;
    private asyncCallbackServDepEnumerate _servEnum;

    public cServDepConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedEventHandler de) : base(ControlWhichGetInvoked, ref Conn)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _servEnum = new asyncCallbackServDepEnumerate(ref _control, de, ref this, _instanceId);
    }



    public delegate void ConnectedEventHandler(bool Success);
    public delegate void DisconnectedEventHandler(bool Success);
    public delegate void HasEnumeratedEventHandler(bool Success, Dictionary<string, serviceInfos> Dico, string errorMessage, int forII, cServDepConnection.DependenciesToget type);

    public ConnectedEventHandler Connected;
    public DisconnectedEventHandler Disconnected;
    // Public HasEnumerated As HasEnumeratedEventHandler



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
                    break;
                }

            default:
                {
                    // Local
                    _connected = true;
                    try
                    {
                        if (Connected != null && _control.Created)
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



    // Enumerate services
    public int Enumerate(string name, DependenciesToget typ, int forInstanceId = -1)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_servEnum.Process()), new asyncCallbackServDepEnumerate.poolObj(name, typ, forInstanceId));
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

        if (data.Type == cSocketData.DataType.RequestedList && data.Order == cSocketData.OrderType.RequestServDepList)
        {
            if (_instanceId == data.InstanceId)
                // OK it is for me
                _servEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys, (DependenciesToget)data.Param2);
        }
    }

    protected override void _sock_SentData()
    {
    }
}

