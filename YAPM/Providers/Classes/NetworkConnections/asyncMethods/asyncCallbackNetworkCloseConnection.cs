using Common;
using System;
using System.Net;

public class asyncCallbackNetworkCloseConnection
{
    private cNetworkConnection con;
    private HasClosedConnection _deg;

    public delegate void HasClosedConnection(bool Success, IPEndPoint local, IPEndPoint remote, string msg, int actionNumber);

    public asyncCallbackNetworkCloseConnection(HasClosedConnection deg, ref cNetworkConnection netConnection)
    {
        _deg = deg;
        con = netConnection;
    }

    public struct poolObj
    {
        public IPEndPoint local;
        public IPEndPoint remote;
        public int newAction;
        public poolObj(IPEndPoint loc, IPEndPoint remo, int act)
        {
            local = loc;
            remote = remo;
            newAction = act;
        }
    }

    public void Process(object thePoolObj)
    {
        poolObj pObj = (poolObj)thePoolObj;
        if (con.ConnectionObj.IsConnected == false)
            return;

        switch (con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.TcpClose, pObj.local, pObj.remote);
                        con.ConnectionObj.Socket.Send(cDat);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Unable to send request to server");
                    }

                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    break;
                }

            default:
                {
                    // Local

                    int ret = Native.Objects.Network.CloseTcpConnectionByIPEndPoints(pObj.local, pObj.remote);
                    _deg.Invoke(ret == 0, pObj.local, pObj.remote, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

