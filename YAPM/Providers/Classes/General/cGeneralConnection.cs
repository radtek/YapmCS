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
using System.Runtime.InteropServices;
using System.Net;
using System.Management;
using System.Net.Sockets;
using System.Text;

public abstract class cGeneralConnection
{

    // We will invoke this control
    protected Control _control;
    private AsynchronousClient __sock;

    protected AsynchronousClient _sock
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

    // For WMI
    internal System.Management.ManagementObjectSearcher wmiSearcher;

    public cGeneralConnection(Control ControlWhichGetInvoked, ref cConnection Conn)
    {
        _control = ControlWhichGetInvoked;
        _conObj = Conn;
        _sock = Conn.Socket;     // Get a reference to the general socket, so that it si
    }


    // Attributes
    protected bool _connected = false;
    protected cConnection _conObj;

    public bool IsConnected
    {
        get
        {
            return _connected;
        }
    }
    public cConnection ConnectionObj
    {
        get
        {
            return _conObj;
        }
        set
        {
            if (_connected == false)
                _conObj = value;
        }
    }
    public AsynchronousClient Socket
    {
        get
        {
            return _sock;
        }
    }

    // Connection
    public void Connect()
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(asyncConnect), null);
    }
    protected abstract void asyncConnect(object useless);


    // Disconnect
    public void Disconnect()
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(asyncDisconnect), null);
    }
    protected abstract void asyncDisconnect(object useless);



    protected abstract void _sock_Connected();
    protected abstract void _sock_Disconnected();
    // Protected MustOverride Sub _sock_ReceivedData(ByRef data As cSocketData) Handles _sock.ReceivedData
    protected abstract void _sock_SentData();
}

