// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.


using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System;
using Microsoft.Samples;
using System.Net;

public class cConnection
{
    public const int REMOTE_PORT = 8081;

    public event ConnectedEventHandler Connected;

    public delegate void ConnectedEventHandler();

    public event DisconnectedEventHandler Disconnected;

    public delegate void DisconnectedEventHandler();

    // Type of connection
    public enum TypeOfConnection
    {
        LocalConnection,
        RemoteConnectionViaSocket,
        RemoteConnectionViaWMI,
        SnapshotFile
    }

    // Parameters for a socket connection
    public struct SocketConnectionParameters
    {
        public int port;
        public string ServerName;
        public string ClientIp;
        public SocketConnectionParameters(string server, int thePort, string aClientIp)
        {
            port = thePort;
            ServerName = server;
            ClientIp = aClientIp;
        }
    }

    // Parameters for a socket connection
    public struct WMIConnectionParameters
    {
        public string userName;
        public System.Security.SecureString password;
        public string serverName;
        public WMIConnectionParameters(string server, string user, System.Security.SecureString pass)
        {
            userName = user;
            password = pass;
            serverName = server;
        }
    }

    private AsynchronousClient __sock;

    private AsynchronousClient _sock
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __sock;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__sock != null)
            {
            }

            __sock = value;
            if (__sock != null)
            {
            }
        }
    }

    private cSnapshot _snap;
    private TypeOfConnection _conType;
    private SocketConnectionParameters _conSocket;
    private WMIConnectionParameters _conWMI;
    private bool _isConnected;
    private string _ssFile;

    // Snapshot file
    public string SnapshotFile
    {
        get
        {
            return _ssFile;
        }
        set
        {
            _ssFile = value;
        }
    }

    // Snaphot object
    public cSnapshot Snapshot
    {
        get
        {
            return _snap;
        }
        set
        {
            _snap = value;
        }
    }

    // Socket
    public AsynchronousClient Socket
    {
        get
        {
            return _sock;
        }
    }

    // Type of connection
    public TypeOfConnection ConnectionType
    {
        get
        {
            return _conType;
        }
        set
        {
            _conType = value;
        }
    }

    // Parameters for the socket
    public SocketConnectionParameters SocketParameters
    {
        get
        {
            return _conSocket;
        }
        set
        {
            if (!(_isConnected))
                _conSocket = value;
        }
    }

    // Parameters for WMI connection
    public WMIConnectionParameters WmiParameters
    {
        get
        {
            return _conWMI;
        }
        set
        {
            if (!(_isConnected))
                _conWMI = value;
        }
    }

    // Is connected ?
    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
    }

    // ToString overriden
    public override string ToString()
    {
        switch (_conType)
        {
            case TypeOfConnection.LocalConnection:
                {
                    return "Localhost";
                }

            case TypeOfConnection.RemoteConnectionViaSocket:
                {
                    if (_conSocket.ServerName != null)
                        return _conSocket.ServerName.ToString() + ":" + _conSocket.port + " (server)";
                    else
                        return "[NO SERVER] :" + _conSocket.port + " (server)";
                    break;
                }

            case TypeOfConnection.RemoteConnectionViaWMI:
                {
                    return _conWMI.serverName + " (WMI)";
                }

            case TypeOfConnection.SnapshotFile:
                {
                    return _snap.ToString();
                }

            default:
                {
                    return "Unknown";
                }
        }
    }

    // Coef of refreshment for intervals
    public double RefreshmentCoefficient
    {
        get
        {
            return System.Convert.ToDouble((_conType == TypeOfConnection.LocalConnection ? 1 : My.MySettingsProperty.Settings.CoefTimeMul / (double)100));
        }
    }


    public cConnection()
    {
        _snap = new cSnapshot();
    }
    public cConnection(ref cConnection ccon)
    {
        _conSocket = ccon.SocketParameters;
        _conType = ccon.ConnectionType;
        _conWMI = ccon.WmiParameters;
        _snap = ccon.Snapshot;
    }

    public void CopyFromInstance(ref cConnection ccon)
    {
        _conType = ccon.ConnectionType;
        _conSocket = ccon.SocketParameters;
        _conWMI = ccon.WmiParameters;
        _snap = ccon.Snapshot;
    }

    // BAD WAY (because of withevents, this is raised JUST WHEN Program.Connection.Connect
    // is called. BAD THING (should wait asyncMethod, but there are LOTS of asyncMethids
    // (one for each lvItem).
    public void Connect()
    {
        if (this.ConnectionType == TypeOfConnection.RemoteConnectionViaSocket)
        {
            if (_sock == null)
            {
                _sock = new AsynchronousClient();
                _sock.Connect(_conSocket.ServerName, _conSocket.port, _conSocket.ClientIp);
            }
            else
            {
                _isConnected = true;
                Connected?.Invoke();
            }
        }
        else if (this.ConnectionType == TypeOfConnection.SnapshotFile)
        {
            if (_isConnected == false)
            {
                _snap = new cSnapshot(ref this.SnapshotFile);
                _isConnected = true;
            }
            Connected?.Invoke();
        }
        else
        {
            _isConnected = true;
            Connected?.Invoke();
        }
    }
    public void Disconnect()
    {
        if (this.ConnectionType == TypeOfConnection.RemoteConnectionViaSocket)
            _sock.Disconnect();
        else
        {
            _isConnected = false;
            Disconnected?.Invoke();
        }
    }
    public void DisconnectForce()        // Set state as 'disconnected'
    {
        _isConnected = false;
        Disconnected?.Invoke();
    }

    private void _sock_Connected()
    {
        _isConnected = true;
        Connected?.Invoke();
    }
    private void _sock_Disconnected()
    {
        _isConnected = false;
        _sock = null;
        Disconnected?.Invoke();
    }

    private void _sock_SentData()
    {
    }

    // When we receive datas
    private void _sock_ReceivedData(ref cSocketData cDat)
    {

        // If we got an error, we display it
        try
        {
            if (cDat.Type == cSocketData.DataType.ErrorOnServer)
            {
                Exception cErr = ((SerializableException)cDat.Param1).GetException();
                Program._frmMain.Invoke(new frmMain.GotErrorFromServer(impGotErrorFromServer), cErr);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }

        // Now we add this entry to the list of received datas
        try
        {
            Program.ConnectionForm.Invoke(new frmConnection.AddItemToReceivedDataList(Program.ConnectionForm.impAddItemToReceivedDataList()), cDat);
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    // Displays error
    private void impGotErrorFromServer(Exception err)
    {
        if (_isConnected)
            Misc.ShowError(err, "The server sent a error.");
    }
}

