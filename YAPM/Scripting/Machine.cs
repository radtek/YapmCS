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

namespace Scripting.Items
{
    public class Machine
    {
        public Machine(string commandLine)
        {
            _con = new cConnection();
            // Here we parse the line
            try
            {
                string[] s = commandLine.Split(System.Convert.ToChar(","));
                this.Type = (Enums.MachineType)Enum.Parse(typeof(Enums.MachineType), s[0], true);
                if (this.Type != Enums.MachineType.Local)
                {
                    this.Name = s[1];
                    this.UserName = s[2];
                    this.Password = s[3];
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Constructors
        public Machine(Enums.MachineType type, string name, string user, string password)
        {
            _con = new cConnection();
            this.Type = type;
            this.Name = name;
            this.UserName = user;
            this.Password = password;
        }

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Type
        private Enums.MachineType _type;

        // Name/IP/local
        private string _name;

        // User
        private string _user;

        // Password
        private string _pwd;

        // Connection
        private cConnection __con;

        private cConnection _con
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __con;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__con != null)
                {
                    __con.Connected -= _con_Connected;
                }

                __con = value;
                if (__con != null)
                {
                    __con.Connected += _con_Connected;
                }
            }
        }

        // Commands
        private List<Scripting.Items.Command> _com;


        // ========================================
        // Public properties
        // ========================================

        // Connection
        public cConnection Connection
        {
            get
            {
                return _con;
            }
            set
            {
                _con = value;
            }
        }

        // Type
        public Enums.MachineType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        // Name
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        // User
        public string UserName
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        // Password
        public string Password
        {
            get
            {
                return _pwd;
            }
            set
            {
                _pwd = value;
            }
        }

        // Execute commands
        public void ExecuteCommands(object commands)
        {

            // Get commands
            _com = (global::System.Collections.Generic.List<global::Scripting.Items.Command>)commands;

            // Connect to machine
            switch (this.Type)
            {
                case Enums.MachineType.Local:
                    {
                        this.Connection.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
                        break;
                    }

                case Enums.MachineType.Wmi:
                    {
                        this.Connection.ConnectionType = cConnection.TypeOfConnection.RemoteConnectionViaWMI;
                        System.Security.SecureString ss = new System.Security.SecureString();
                        foreach (char c in this.Password)
                            ss.AppendChar(c);
                        this.Connection.WmiParameters = new cConnection.WMIConnectionParameters(this.Name, this.UserName, ss);
                        break;
                    }
            }
            // Connect now
            Connection.Connect();
        }


        // ========================================
        // Private functions
        // ========================================

        // Machine is connected
        private void _con_Connected()
        {
            // Execute the commands now
            foreach (Scripting.Items.Command com in _com)
                com.Execute(this.Connection);
        }
    }
}

