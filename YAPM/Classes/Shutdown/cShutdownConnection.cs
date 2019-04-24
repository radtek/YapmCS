using System.Windows.Forms;
using Common;
using System;
using System.Management;

public class cShutdownConnection : cGeneralConnection
{
    public cShutdownConnection(Control ControlWhichGetInvoked, ref cConnection Conn) : base(ControlWhichGetInvoked, ref Conn)
    {
    }


    public delegate void ConnectedEventHandler(bool Success);
    public delegate void DisconnectedEventHandler(bool Success);

    public ConnectedEventHandler Connected;
    public DisconnectedEventHandler Disconnected;



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
                    ConnectionOptions __con = new ConnectionOptions();
                    __con.Impersonation = ImpersonationLevel.Impersonate;
                    __con.Password = Common.Misc.SecureStringToCharArray(ref _conObj.WmiParameters.password);
                    __con.Username = _conObj.WmiParameters.userName;

                    try
                    {
                        wmiSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
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
    }

    protected override void _sock_SentData()
    {
    }
}

