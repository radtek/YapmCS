﻿// =======================================================
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

public partial class windowList : customLV
{


    // ========================================
    // Public functions
    // ========================================

    public windowList()
    {
        _connectionObject = new cConnection();
        _windowConnection = new cWindowConnection(this, ref _connectionObject, ref new cWindowConnection.HasEnumeratedEventHandler(HasEnumeratedEventHandler));

        // Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent();

        // Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _IMG = new ImageList();
        _IMG.ImageSize = new Size(16, 16);
        _IMG.ColorDepth = ColorDepth.Depth32Bit;

        this.SmallImageList = _IMG;
        _IMG.Images.Add("noIcon", My.Resources.Resources.application_blue16);

        _first = true;

        // Set handlers
        _windowConnection.Disconnected = new cWindowConnection.DisconnectedEventHandler(HasDisconnected);
        _windowConnection.Connected = new cWindowConnection.ConnectedEventHandler(HasConnected);
    }

    public event ItemAddedEventHandler ItemAdded;

    public delegate void ItemAddedEventHandler(ref cWindow item);

    public event ItemDeletedEventHandler ItemDeleted;

    public delegate void ItemDeletedEventHandler(ref cWindow item);

    public event HasRefreshedEventHandler HasRefreshed;

    public delegate void HasRefreshedEventHandler();

    public event GotAnErrorEventHandler GotAnError;

    public delegate void GotAnErrorEventHandler(string origin, string msg);


    // ========================================
    // Private
    // ========================================
    private int _pid;
    private bool _allPid;
    private bool _unNamed;
    private bool _first;
    private Dictionary<string, cWindow> _dicoNew = new Dictionary<string, cWindow>();
    private Dictionary<string, cWindow> _dicoDel = new Dictionary<string, cWindow>();
    private Dictionary<string, cWindow> _buffDico = new Dictionary<string, cWindow>();
    private Dictionary<string, cWindow> _dico = new Dictionary<string, cWindow>();
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

    private cWindowConnection __windowConnection;

    private cWindowConnection _windowConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __windowConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__windowConnection != null)
            {
            }

            __windowConnection = value;
            if (__windowConnection != null)
            {
            }
        }
    }


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
    public int ProcessId
    {
        get
        {
            return _pid;
        }
        set
        {
            _pid = value;
        }
    }
    public bool ShowAllPid
    {
        get
        {
            return _allPid;
        }
        set
        {
            _allPid = value;
        }
    }
    public bool ShowUnNamed
    {
        get
        {
            return _unNamed;
        }
        set
        {
            _unNamed = value;
        }
    }

    // Get an item from listview
    public System.Drawing.Image GetImageFromImageList(string key)
    {
        return _IMG.Images[key];
    }

    // Delete all items
    public void ClearItems()
    {
        _first = true;
        _buffDico.Clear();
        _dico.Clear();
        _dicoDel.Clear();
        _dicoNew.Clear();
        _IMG.Images.Clear();
        _IMG.Images.Add("noIcon", My.Resources.Resources.application_blue16);
        this.Items.Clear();
    }

    // Call this to update items in listview
    public override void UpdateItems()
    {

        // Create a buffer of subitems if necessary
        if (_columnsName == null)
            CreateSubItemsBuffer();

        if (_windowConnection.IsConnected)

            // Now enumerate items
            _windowConnection.Enumerate(_first, ref _pid, _unNamed, _allPid);
    }

    // Get all items (associated to listviewitems)
    public Dictionary<string, cWindow>.ValueCollection GetAllItems()
    {
        return _dico.Values;
    }

    // Get the selected item
    public cWindow GetSelectedItem()
    {
        if (this.SelectedItems.Count > 0)
            return _dico[this.SelectedItems[0].Name];
        else
            return null;
    }

    // Get a specified item
    public cWindow GetItemByKey(string key)
    {
        if (_dico.ContainsKey(key))
            return _dico[key];
        else
            return null;
    }

    // Get selected items
    public new Dictionary<string, cWindow>.ValueCollection GetSelectedItems()
    {
        Dictionary<string, cWindow> res = new Dictionary<string, cWindow>();

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
    private void HasEnumeratedEventHandler(bool Success, Dictionary<string, windowInfos> Dico, string errorMessage, int instanceId)
    {
        generalLvSemaphore.WaitOne();

        if (Success == false)
        {
            Trace.WriteLine("Cannot enumerate, an error was raised...");
            GotAnError?.Invoke("Window enumeration", errorMessage);
            generalLvSemaphore.Release();
            return;
        }

        // We won't enumerate next time with all informations (included fixed infos)
        _first = false;


        // Now add all items with isKilled = true to _dicoDel dictionnary
        foreach (cWindow z in _dico.Values)
        {
            if (z.IsKilledItem)
                _dicoDel.Add(z.Infos.ProcessId.ToString() + "-" + z.Infos.ThreadId.ToString() + "-" + z.Infos.Handle.ToString(), null);
        }


        // Now add new items to dictionnary
        foreach (System.Collections.Generic.KeyValuePair<string, windowInfos> pair in Dico)
        {
            if (!(_dico.ContainsKey(pair.Key)))
                // Add to dico
                _dicoNew.Add(pair.Key, new cWindow(pair.Value));
        }


        // Now remove deleted items from dictionnary
        foreach (string z in _dico.Keys)
        {
            if (Dico.ContainsKey(z) == false)
                // Remove from dico
                _dico[z].IsKilledItem = true;// Will be deleted next time
        }


        // Now remove all deleted items from listview and _dico
        foreach (string z in _dicoDel.Keys)
        {
            this.Items.RemoveByKey(z);
            ItemDeleted?.Invoke(ref _dico[z]);
            _dico.Remove(z);
        }
        _dicoDel.Clear();


        // Merge _dico and _dicoNew
        foreach (string z in _dicoNew.Keys)
        {
            cWindow _it = _dicoNew[z];
            ItemAdded?.Invoke(ref _it);
            _it.IsNewItem = !(_firstItemUpdate);        // If first refresh, don't highlight item
            _dico.Add(z.ToString(), _it);
        }


        // Now add all new items to listview
        // If first time, lock listview
        if (_firstItemUpdate || _dicoNew.Count > EMPIRIC_MINIMAL_NUMBER_OF_NEW_ITEMS_TO_BEGIN_UPDATE || _dicoDel.Count > EMPIRIC_MINIMAL_NUMBER_OF_DELETED_ITEMS_TO_BEGIN_UPDATE)
            this.BeginUpdate();
        foreach (string z in _dicoNew.Keys)
        {

            // Add to listview
            string[] _subItems;
            _subItems = new string[this.Columns.Count - 1 + 1];
            var loopTo = _subItems.Length - 1;
            for (int x = 1; x <= loopTo; x++)
                _subItems[x] = "";
            AddItemWithStyle(z).SubItems.AddRange(_subItems);
        }
        if (_firstItemUpdate || _dicoNew.Count > EMPIRIC_MINIMAL_NUMBER_OF_NEW_ITEMS_TO_BEGIN_UPDATE || _dicoDel.Count > EMPIRIC_MINIMAL_NUMBER_OF_DELETED_ITEMS_TO_BEGIN_UPDATE)
            this.EndUpdate();
        _dicoNew.Clear();


        // Now refresh all subitems of the listview
        ListViewItem.ListViewSubItem isub;
        ListViewItem it;
        foreach (var it in this.Items)
        {
            int x = 0;
            cWindow _item = _dico[it.Name];
            _item.Refresh();
            string __info = null;
            foreach (var isub in it.SubItems)
            {
                if (_item.GetInformation(_columnsName[x], ref __info))
                    isub.Text = __info;
                x += 1;
            }
            if (_item.IsNewItem)
            {
                _item.IsNewItem = false;
                it.BackColor = NEW_ITEM_COLOR;
            }
            else if (_item.IsKilledItem)
                it.BackColor = DELETED_ITEM_COLOR;
            else
                it.BackColor = Color.White;
        }

        // Sort items
        this.Sort();

        _firstItemUpdate = false;

        // Trace.WriteLine("It tooks " & _test.ToString & " ms to refresh thread list.")

        base.UpdateItems();

        generalLvSemaphore.Release();
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
                cGeneralObject _item = _dico[it.Name];
                foreach (var isub in it.SubItems)
                {
                    _item.GetInformation(_columnsName[x], ref isub.Text);
                    x += 1;
                }
                if (_item.IsNewItem)
                {
                    _item.IsNewItem = false;
                    it.BackColor = NEW_ITEM_COLOR;
                }
                else if (_item.IsKilledItem)
                    it.BackColor = DELETED_ITEM_COLOR;
                else
                    it.BackColor = Color.White;
            }
        }
    }

    // Add an item (specific to type of list)
    internal override ListViewItem AddItemWithStyle(string key)
    {
        ListViewItem item = this.Items.Add(key);
        item.Name = key;
        // item.Group = Me.Groups(0)

        // Add icon
        if (_connectionObject.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
        {
            try
            {
                System.Drawing.Icon icon = _dico[key].SmallIcon;
                if (icon != null)
                {
                    this.SmallImageList.Images.Add(key, icon);
                    item.ImageKey = key;
                }
                else
                    item.ImageKey = "noIcon";
            }
            catch (Exception ex)
            {
                item.ImageKey = "noIcon";
            }
        }
        else
            item.ImageKey = "noIcon";

        item.Tag = key;

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
            _first = true;
            _windowConnection.ConnectionObj = _connectionObject;
            _windowConnection.Connect();
            cWindow.Connection = _windowConnection;
        }
    }

    protected override bool Disconnect()
    {
        if (base.Disconnect())
        {
            this.IsConnected = false;
            _windowConnection.Disconnect();
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
        if (e.Shift && e.Control)
        {
            // OK, show thread management
            foreach (cGeneralObject obj in this.GetSelectedItems())
            {
                frmPendingTasks frm = new frmPendingTasks(ref obj);
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
        }
        else if (e.KeyCode == Keys.F7)
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

