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
using Native.Api.Enums;

public partial class searchList : customLV
{


    // ========================================
    // Public functions
    // ========================================

    public searchList()
    {
        _connectionObject = new cConnection();
        _searchConnection = new cSearchConnection(this, ref _connectionObject, ref new cSearchConnection.HasEnumeratedEventHandler(HasEnumeratedEventHandler));

        // Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent();

        // Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _IMG = new ImageList();
        _IMG.ImageSize = new Size(16, 16);
        _IMG.ColorDepth = ColorDepth.Depth32Bit;

        this.SmallImageList = _IMG;
        _IMG.Images.Add("service", My.Resources.Resources.gear);   // Icon is specific
        _IMG.Images.Add("exeFile", My.Resources.Resources.exe16);
        _IMG.Images.Add("handle", My.Resources.Resources.handle);
        _IMG.Images.Add("envvar", My.Resources.Resources.document_text);
        _IMG.Images.Add("dllIcon", My.Resources.Resources.dllIcon16);
        _IMG.Images.Add("window", My.Resources.Resources.application_blue16);


        // Set handlers
        _searchConnection.Disconnected = new cSearchConnection.DisconnectedEventHandler(HasDisconnected);
        _searchConnection.Connected = new cSearchConnection.ConnectedEventHandler(HasConnected);
    }

    public event ItemAddedEventHandler ItemAdded;

    public delegate void ItemAddedEventHandler(ref cSearchItem item);

    public event ItemDeletedEventHandler ItemDeleted;

    public delegate void ItemDeletedEventHandler(ref cSearchItem item);

    public event HasRefreshedEventHandler HasRefreshed;

    public delegate void HasRefreshedEventHandler();

    public event GotAnErrorEventHandler GotAnError;

    public delegate void GotAnErrorEventHandler(string origin, string msg);

    // ========================================
    // Private
    // ========================================
    private Dictionary<string, cSearchItem> _dico = new Dictionary<string, cSearchItem>();
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

    private cSearchConnection __searchConnection;

    private cSearchConnection _searchConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __searchConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__searchConnection != null)
            {
            }

            __searchConnection = value;
            if (__searchConnection != null)
            {
            }
        }
    }

    private string _searchString;
    private bool _caseSensitive;
    private Native.Api.Enums.GeneralObjectType _include = Native.Api.Enums.GeneralObjectType.Process;


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
    public string SearchString
    {
        get
        {
            return _searchString;
        }
        set
        {
            _searchString = value;
        }
    }
    public bool CaseSensitive
    {
        get
        {
            return _caseSensitive;
        }
        set
        {
            _caseSensitive = value;
        }
    }
    public Native.Api.Enums.GeneralObjectType Includes
    {
        get
        {
            return _include;
        }
        set
        {
            _include = value;
        }
    }

    // Delete all items
    public void ClearItems()
    {
        _dico.Clear();
        _IMG.Images.Clear();
        _IMG.Images.Add("service", My.Resources.Resources.gear);   // Icon is specific
        _IMG.Images.Add("exeFile", My.Resources.Resources.exe16);
        _IMG.Images.Add("handle", My.Resources.Resources.handle);
        _IMG.Images.Add("envvar", My.Resources.Resources.document_text);
        _IMG.Images.Add("dllIcon", My.Resources.Resources.dllIcon16);
        _IMG.Images.Add("window", My.Resources.Resources.application_blue16);
        this.Items.Clear();
    }

    // Call this to update items in listview
    public override void UpdateItems()
    {

        // Create a buffer of subitems if necessary
        if (_columnsName == null)
            CreateSubItemsBuffer();

        if (_searchConnection.IsConnected)
        {

            // Clear items
            this.BeginUpdate();
            this.ClearItems();
            this.Items.Add("Currently searching...");
            this.Enabled = false;
            this.EndUpdate();

            // Now enumerate items
            _searchConnection.Enumerate(ref _searchString, _caseSensitive, _include);
        }
    }

    // Get all items (associated to listviewitems)
    public Dictionary<string, cSearchItem>.ValueCollection GetAllItems()
    {
        return _dico.Values;
    }

    // Get the selected item
    public cSearchItem GetSelectedItem()
    {
        if (this.SelectedItems.Count > 0)
            return _dico[this.SelectedItems[0].Name];
        else
            return null;
    }

    // Get a specified item
    public cSearchItem GetItemByKey(string key)
    {
        if (_dico.ContainsKey(key))
            return _dico[key];
        else
            return null;
    }

    // Get selected items
    public new Dictionary<string, cSearchItem>.ValueCollection GetSelectedItems()
    {
        Dictionary<string, cSearchItem> res = new Dictionary<string, cSearchItem>();

        generalLvSemaphore.WaitOne();
        foreach (ListViewItem it in this.SelectedItems)
            res.Add(it.Name, _dico[it.Name]);
        generalLvSemaphore.Release();

        return res.Values;
    }


    // ========================================
    // Private properties
    // ========================================

    // Executed when enumeration is done
    private void HasEnumeratedEventHandler(bool Success, Dictionary<string, searchInfos> Dico, string errorMessage, int instanceId)
    {
        generalLvSemaphore.WaitOne();
        this.ClearItems();

        if (Success == false)
        {
            Trace.WriteLine("Cannot enumerate, an error was raised...");
            GotAnError?.Invoke("Search connection enumeration", errorMessage);
            generalLvSemaphore.Release();
            return;
        }


        // Create cSearchItem instances
        foreach (System.Collections.Generic.KeyValuePair<string, searchInfos> pair in Dico)
            _dico.Add(pair.Key, new cSearchItem(pair.Value));

        // Now add all items to listview
        this.BeginUpdate();
        this.Enabled = true;

        foreach (string z in _dico.Keys)
        {
            // Add to listview
            string[] _subItems;
            _subItems = new string[this.Columns.Count - 1 + 1];
            var loopTo = _subItems.Length - 1;
            for (int x = 1; x <= loopTo; x++)
                _subItems[x] = "";
            cSearchItem _tmp = _dico[z];
            AddItemWithStyle(z, ref _tmp).SubItems.AddRange(_subItems);
        }


        // Now refresh all subitems of the listview
        ListViewItem.ListViewSubItem isub;
        ListViewItem it;
        foreach (var it in this.Items)
        {
            int x = 0;
            if (_dico.ContainsKey(it.Name))
            {
                cSearchItem _item = _dico[it.Name];
                foreach (var isub in it.SubItems)
                {
                    isub.Text = _item.GetInformation(_columnsName[x]);
                    x += 1;
                }
            }
        }


        // Sort items
        this.Sort();
        this.EndUpdate();

        _firstItemUpdate = false;

        // Trace.WriteLine("It tooks " & _test.ToString & " ms to refresh search list.")

        base.UpdateItems();

        generalLvSemaphore.Release();

        HasRefreshed?.Invoke();
    }

    // Force item refreshing
    public override void ForceRefreshingOfAllItems()    // Always called in a safe protected context
    {
        ListViewItem.ListViewSubItem isub;
        ListViewItem it;
        foreach (var it in this.Items)
        {
            int x = 0;
            if (_dico.ContainsKey(it.Name))
            {
                cSearchItem _item = _dico[it.Name];
                foreach (var isub in it.SubItems)
                {
                    isub.Text = _item.GetInformation(_columnsName[x]);
                    x += 1;
                }
            }
        }
    }

    // Add an item (specific to type of list)
    private new ListViewItem AddItemWithStyle(string key, ref cSearchItem it)
    {
        ListViewItem item = this.Items.Add(key);
        item.Name = key;
        item.ForeColor = _foreColor;
        item.Tag = key;

        switch (it.Infos.Type)
        {
            case Native.Api.Enums.GeneralObjectType.EnvironmentVariable:
                {
                    item.ImageKey = "envvar";
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Handle:
                {
                    item.ImageKey = "handle";
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Module:
                {
                    item.ImageKey = "dllIcon";
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Process:
                {
                    item.ImageKey = "exeFile";
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Service:
                {
                    item.ImageKey = "service";
                    break;
                }

            default:
                {
                    item.ImageKey = "window";
                    break;
                }
        }

        return item;
    }


    private void _connectionObject_Connected()
    {
        Connect();
    }

    private void _connectionObject_Disconnected()
    {
        Disconnect();
    }

    protected override bool Connect()
    {
        if (base.Connect())
        {
            this.IsConnected = true;
            _searchConnection.ConnectionObj = _connectionObject;
            _searchConnection.Connect();
        }
    }

    protected override bool Disconnect()
    {
        if (base.Disconnect())
        {
            this.IsConnected = false;
            _searchConnection.Disconnect();
        }
    }

    private void HasDisconnected(bool Success)
    {
    }

    private void HasConnected(bool Success)
    {
    }


    protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.KeyCode == Keys.F7)
            this.showObjectProperties();
    }

    // Display properties form
    protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDoubleClick(e);
        if (this.ShowObjectDetailsOnDoubleClick)
            this.showObjectProperties();
    }

    private void showObjectProperties()
    {
        foreach (cGeneralObject obj in this.GetSelectedItems())
        {
            frmObjDetails frm = new frmObjDetails();
            frm.TopMost = Program._frmMain.TopMost;
            frm.TheObject = obj;
            frm.Show();
        }
    }
}

