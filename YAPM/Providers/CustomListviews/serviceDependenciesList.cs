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

public partial class serviceDependenciesList : TreeView
{


    // ========================================
    // Public functions
    // ========================================

    public serviceDependenciesList()
    {
        _connectionObject = new cConnection();
        _servDepConnection = new cServDepConnection(this, ref _connectionObject, ref new cServDepConnection.HasEnumeratedEventHandler(HasEnumeratedEventHandler));

        // Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent();

        // Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _IMG = new ImageList();
        _IMG.ImageSize = new Size(16, 16);
        _IMG.ColorDepth = ColorDepth.Depth32Bit;

        this.ImageList = _IMG;
        _IMG.Images.Add("ok", My.Resources.Resources.gear);   // Icon is specific
        _IMG.Images.Add("ko", My.Resources.Resources.exe16);
        _IMG.Images.Add("service", My.Resources.Resources.gear);


        // Set handlers
        _servDepConnection.Disconnected = new cServDepConnection.DisconnectedEventHandler(HasDisconnected);
        _servDepConnection.Connected = new cServDepConnection.ConnectedEventHandler(HasConnected);
    }

    internal ImageList _IMG;

    public event ItemAddedEventHandler ItemAdded;

    public delegate void ItemAddedEventHandler(ref cGeneralObject item);

    public event ItemDeletedEventHandler ItemDeleted;

    public delegate void ItemDeletedEventHandler(ref cGeneralObject item);

    public event HasRefreshedEventHandler HasRefreshed;

    public delegate void HasRefreshedEventHandler();

    public event GotAnErrorEventHandler GotAnError;

    public delegate void GotAnErrorEventHandler(string origin, string msg);

    public event ConnectedEventHandler Connected;

    public delegate void ConnectedEventHandler();

    // ========================================
    // Private
    // ========================================
    private bool _isConnected = false;
    private Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();
    private cConnection __connectionObject;

    private cConnection _connectionObject
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __connectionObject;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__connectionObject != null)
            {
                __connectionObject.Connected -= _connectionObject_Connected;
                __connectionObject.Disconnected -= _connectionObject_Disconnected;
            }

            __connectionObject = value;
            if (__connectionObject != null)
            {
                __connectionObject.Connected += _connectionObject_Connected;
                __connectionObject.Disconnected += _connectionObject_Disconnected;
            }
        }
    }

    private cServDepConnection __servDepConnection;

    private cServDepConnection _servDepConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __servDepConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__servDepConnection != null)
            {
            }

            __servDepConnection = value;
            if (__servDepConnection != null)
            {
            }
        }
    }

    private string _rootService;
    private cServDepConnection.DependenciesToget _infoToGet;


    // ========================================
    // Properties
    // ========================================
    public cConnection ConnectionObj
    {
        get
        {
            return _connectionObject;
        }
        set
        {
            _connectionObject = value;
        }
    }
    public string RootService
    {
        get
        {
            return _rootService;
        }
        set
        {
            _rootService = value;
        }
    }
    public cServDepConnection.DependenciesToget InfosToGet
    {
        get
        {
            return _infoToGet;
        }
        set
        {
            _infoToGet = value;
        }
    }
    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
        set
        {
            _isConnected = value;
        }
    }

    // Delete all items
    public void ClearItems()
    {
        _dico.Clear();
        this.Nodes.Clear();
    }

    // Call this to update items in listview
    public void UpdateItems()
    {
        if (_servDepConnection.IsConnected)

            // Now enumerate items
            _servDepConnection.Enumerate(_rootService, _infoToGet);
    }

    // Get all items (associated to listviewitems)
    public Dictionary<string, serviceInfos>.ValueCollection GetAllItems()
    {
        return _dico.Values;
    }

    // Get a specified item
    public serviceInfos GetItemByKey(string key)
    {
        if (_dico.ContainsKey(key))
            return _dico[key];
        else
            return null;
    }

    // Safe add (manage icon stuff)
    public void SafeAdd(string text)
    {
        this.ClearItems();
        TreeNode n = new TreeNode(text);
        n.ImageKey = "ok";
        n.SelectedImageKey = n.ImageKey;
        this.Nodes.Add(n);
        this.Update();
    }


    // ========================================
    // Private properties
    // ========================================

    // Executed when enumeration is done
    private static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
    private void HasEnumeratedEventHandler(bool Success, Dictionary<string, serviceInfos> Dico, string errorMessage, int instanceId, cServDepConnection.DependenciesToget type)
    {
        if (!(type == _infoToGet))
            return;

        sem.WaitOne();

        if (Success == false)
        {
            Trace.WriteLine("Cannot enumerate, an error was raised...");
            GotAnError?.Invoke("Service dependencies connection enumeration", errorMessage);
            sem.Release();
            return;
        }

        _dico = Dico;

        // Now add all items to listview
        this.BeginUpdate();

        this.Nodes.Clear();
        TreeNode nn = this.Nodes.Add(Native.Objects.Service.GetServiceByName(_rootService).Infos.DisplayName);
        nn.Tag = new servTag(_rootService, _rootService);
        addChilds(_dico, ref nn);
        nn.Expand();

        if (nn.Nodes.Count > 0)
        {
            nn.ImageKey = "ko";
            nn.SelectedImageKey = "ko";
        }
        else
        {
            nn.ImageKey = "ok";
            nn.SelectedImageKey = "ok";
        }

        this.EndUpdate();

        sem.Release();

        HasRefreshed?.Invoke();
    }

    public struct servTag
    {
        public string tag;
        public string name;
        public servTag(string t, string n)
        {
            tag = t;
            name = n;
        }
    }
    private void addChilds(Dictionary<string, serviceInfos> _dico, ref TreeNode n)
    {
        foreach (System.Collections.Generic.KeyValuePair<string, serviceInfos> pair in _dico)
        {
            if (pair.Key.StartsWith(((servTag)n.Tag).tag + "->") && pair.Value.Tag == false)
            {
                TreeNode nn = n.Nodes.Add(pair.Value.DisplayName);
                nn.Name = pair.Value.DisplayName;
                nn.ExpandAll();
                ItemAdded?.Invoke(ref Native.Objects.Service.GetServiceByName(pair.Value.DisplayName));
                nn.Tag = new servTag(pair.Key, pair.Value.Name);
                nn.ImageKey = "service";
                nn.SelectedImageKey = "service";
                pair.Value.Tag = true;
                addChilds(_dico, ref nn);
            }
        }
    }


    private void _connectionObject_Connected()
    {
        Connect();
    }

    private void _connectionObject_Disconnected()
    {
        Disconnect();
    }

    protected bool Connect()
    {
        if (this.IsConnected == false)
        {
            this.IsConnected = true;
            _servDepConnection.ConnectionObj = _connectionObject;
            _servDepConnection.Connect();
        }
    }

    protected bool Disconnect()
    {
        if (this.IsConnected)
        {
            this.IsConnected = false;
            _servDepConnection.Disconnect();
        }
    }

    private void HasDisconnected(bool Success)
    {
    }

    private void HasConnected(bool Success)
    {
        if (Success)
            Connected?.Invoke();
    }
}

