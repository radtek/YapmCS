using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class cHandleConnection : cGeneralConnection
{
    internal static int instanceId = 1;
    private int _instanceId = 1;
    private asyncCallbackHandleEnumerate _handleEnum;

    public cHandleConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedEventHandler de) : base(ControlWhichGetInvoked, ref Conn)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _handleEnum = new asyncCallbackHandleEnumerate(ref _control, de, ref this, _instanceId);
    }


    public delegate void ConnectedEventHandler(bool Success);
    public delegate void DisconnectedEventHandler(bool Success);
    public delegate void HasEnumeratedEventHandler(bool Success, Dictionary<string, handleInfos> Dico, string errorMessage, int instanceId);

    public ConnectedEventHandler Connected;
    public DisconnectedEventHandler Disconnected;
    public HasEnumeratedEventHandler HasEnumerated;



    // Connect
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



    // Enumerate threads
    public int Enumerate(bool getFixedInfos, ref int pid, bool showUnnamed, int forInstanceId = -1)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_handleEnum.Process()), new asyncCallbackHandleEnumerate.poolObj(pid, showUnnamed, forInstanceId));
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

        if (data.Type == cSocketData.DataType.RequestedList && data.Order == cSocketData.OrderType.RequestHandleList)
        {
            if (_instanceId == data.InstanceId)
                // OK it is for me
                _handleEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys);
        }
    }

    protected override void _sock_SentData()
    {
    }
}

