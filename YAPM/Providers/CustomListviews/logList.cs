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

public partial class logList : customLV
{


    // ========================================
    // Public functions
    // ========================================

    public logList()
    {
        _connectionObject = new cConnection();
        _logConnection = new cLogConnection(this, ref _connectionObject, ref new cLogConnection.HasEnumeratedEventHandler(HasEnumeratedEventHandler));

        // Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent();

        _first = true;

        // Set handlers
        _logConnection.Disconnected = new cLogConnection.DisconnectedEventHandler(HasDisconnected);
        _logConnection.Connected = new cLogConnection.ConnectedEventHandler(HasConnected);
    }

    public event ItemAddedEventHandler ItemAdded;

    public delegate void ItemAddedEventHandler(ref cLogItem item);

    public event ItemDeletedEventHandler ItemDeleted;

    public delegate void ItemDeletedEventHandler(ref cLogItem item);

    public event HasRefreshedEventHandler HasRefreshed;

    public delegate void HasRefreshedEventHandler();

    public event GotAnErrorEventHandler GotAnError;

    public delegate void GotAnErrorEventHandler(string origin, string msg);


    // ========================================
    // Private
    // ========================================
    private int _pid;
    private bool _first;
    private asyncCallbackLogEnumerate.LogItemType _capture = asyncCallbackLogEnumerate.LogItemType.AllItems;
    private asyncCallbackLogEnumerate.LogItemType _display = asyncCallbackLogEnumerate.LogItemType.AllItems;
    private Dictionary<string, cLogItem> _dico = new Dictionary<string, cLogItem>();
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

    private cLogConnection __logConnection;

    private cLogConnection _logConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __logConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__logConnection != null)
            {
            }

            __logConnection = value;
            if (__logConnection != null)
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
    public asyncCallbackLogEnumerate.LogItemType CaptureItems
    {
        get
        {
            return _capture;
        }
        set
        {
            _capture = value;
        }
    }
    public asyncCallbackLogEnumerate.LogItemType DisplayItems
    {
        get
        {
            return _display;
        }
        set
        {
            _display = value;
        }
    }

    // Delete all items
    public void ClearItems()
    {
        _first = true;
        _dico.Clear();
        this.Items.Clear();
    }

    // Call this to update items in listview
    public override void UpdateItems()
    {

        // Create a buffer of subitems if necessary
        if (_columnsName == null)
            CreateSubItemsBuffer();

        if (_logConnection.IsConnected)

            // Now enumerate items
            _logConnection.Enumerate(_capture, ref _pid);
    }

    // Add IF NECESSARY to listview
    // No protection by sem here cause of safe context when called
    private void conditionalAdd(cLogItem item)
    {
        bool b = false;
        if (item.Infos.State == logItemInfos.CREATED_OR_DELETED.created)
            b = ((_display & asyncCallbackLogEnumerate.LogItemType.CreatedItems) == asyncCallbackLogEnumerate.LogItemType.CreatedItems);
        else
            b = ((_display & asyncCallbackLogEnumerate.LogItemType.DeletedItems) == asyncCallbackLogEnumerate.LogItemType.DeletedItems);
        if (((item.Infos.TypeMask & _display) == item.Infos.TypeMask) && b)
        {

            // Add to listview
            int x;
            string[] _subItems;
            _subItems = new string[this.Columns.Count - 1 + 1];
            var loopTo = _subItems.Length - 1;
            for (x = 1; x <= loopTo; x++)
                _subItems[x] = "";
            ListViewItem it = AddItemWithStyle(item.Infos.Key);
            it.SubItems.AddRange(_subItems);

            // Refresh subitems
            x = 0;
            foreach (ListViewItem.ListViewSubItem isub in it.SubItems)
            {
                isub.Text = item.GetInformation(_columnsName[x]);
                x += 1;
            }
        }
    }

    // Call this to redraw all items
    public void ReAddItems()
    {
        generalLvSemaphore.WaitOne();
        this.BeginUpdate();
        this.Items.Clear();

        foreach (System.Collections.Generic.KeyValuePair<string, cLogItem> pair in _dico)
            conditionalAdd(pair.Value);

        this.EndUpdate();
        generalLvSemaphore.Release();
    }

    // Get all items (associated to listviewitems)
    public Dictionary<string, cLogItem>.ValueCollection GetAllItems()
    {
        return _dico.Values;
    }

    // Get the selected item
    public cLogItem GetSelectedItem()
    {
        if (this.SelectedItems.Count > 0)
            return _dico[this.SelectedItems[0].Name];
        else
            return null;
    }

    // Get a specified item
    public cLogItem GetItemByKey(string key)
    {
        if (_dico.ContainsKey(key))
            return _dico[key];
        else
            return null;
    }

    // Get selected items
    public new Dictionary<string, cLogItem>.ValueCollection GetSelectedItems()
    {
        Dictionary<string, cLogItem> res = new Dictionary<string, cLogItem>();

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
    private void HasEnumeratedEventHandler(bool Success, Dictionary<string, logItemInfos> Dico, string errorMessage, int InstanceId)
    {
        generalLvSemaphore.WaitOne();

        if (Success == false)
        {
            Trace.WriteLine("Cannot enumerate, an error was raised...");
            GotAnError?.Invoke("Log enumeration", errorMessage);
            generalLvSemaphore.Release();
            return;
        }

        // We won't enumerate next time with all informations (included fixed infos)
        _first = false;


        // ' Now add all items with isKilled = true to _dicoDel dictionnary
        // For Each z As cLogItem In _dico.Values
        // If z.IsKilledItem Then
        // _dicoDel.Add(z.Infos.BaseAddress.ToString, Nothing)
        // End If
        // Next


        // Now add new items to dictionnary
        Dictionary<string, cLogItem> _dicoNew = new Dictionary<string, cLogItem>();
        foreach (System.Collections.Generic.KeyValuePair<string, logItemInfos> pair in Dico)
        {
            if (!(_dico.ContainsKey(pair.Key)))
            {
                // Add to dico
                _dicoNew.Add(pair.Key, new cLogItem(pair.Value));
                _dico.Add(pair.Key, _dicoNew[pair.Key]);
            }
        }


        // ' Now remove deleted items from dictionnary
        // For Each z As String In _dico.Keys
        // If Dico.ContainsKey(z) = False Then
        // ' Remove from dico
        // _dico.Item(z).IsKilledItem = True  ' Will be deleted next time
        // End If
        // Next


        // ' Now remove all deleted items from listview and _dico
        // For Each z As String In _dicoDel.Keys
        // Me.Items.RemoveByKey(z)
        // RaiseEvent ItemDeleted(_dico.Item(z))
        // _dico.Remove(z)
        // Next
        // _dicoDel.Clear()


        // ' Merge _dico and _dicoNew
        // For Each z As String In _dicoNew.Keys
        // Dim _it As cLogItem = _dicoNew.Item(z)
        // RaiseEvent ItemAdded(_it)
        // _it.IsNewItem = Not (_firstItemUpdate)        ' If first refresh, don't highlight item
        // _dico.Add(z.ToString, _it)
        // Next


        // Now add all new items to listview
        // If first time, lock listview
        // If _firstItemUpdate OrElse _dicoNew.Count > EMPIRIC_MINIMAL_NUMBER_OF_NEW_ITEMS_TO_BEGIN_UPDATE OrElse _dicoDel.Count > EMPIRIC_MINIMAL_NUMBER_OF_DELETED_ITEMS_TO_BEGIN_UPDATE Then Me.BeginUpdate()
        foreach (string z in _dicoNew.Keys)
            conditionalAdd(_dicoNew[z]);
        // If _firstItemUpdate OrElse _dicoNew.Count > EMPIRIC_MINIMAL_NUMBER_OF_NEW_ITEMS_TO_BEGIN_UPDATE orelse _dicodel.count>EMPIRIC_MINIMAL_NUMBER_OF_deleted_ITEMS_TO_BEGIN_UPDATE Then Me.EndUpdate()
        // _dicoNew.Clear()


        // Now refresh all subitems of the listview
        // Dim isub As ListViewItem.ListViewSubItem
        // Dim it As ListViewItem
        // For Each it In Me.Items
        // Dim x As Integer = 0
        // Dim _item As cLogItem = _dico.Item(it.Name)
        // 'If Dico.ContainsKey(it.Name) Then
        // '    _item.Merge(Dico.Item(it.Name))
        // 'End If
        // For Each isub In it.SubItems
        // isub.Text = _item.GetInformation(_columnsName(x))
        // x += 1
        // Next
        // 'If _item.IsNewItem Then
        // '    _item.IsNewItem = False
        // '    it.BackColor = NEW_ITEM_COLOR
        // 'ElseIf _item.IsKilledItem Then
        // '    it.BackColor = DELETED_ITEM_COLOR
        // 'Else
        // '    it.BackColor = Color.White
        // 'End If
        // Next

        // Sort items
        this.Sort();

        _firstItemUpdate = false;

        // Trace.WriteLine("It tooks " & _test.ToString & " ms to refresh log list.")

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
        item.ForeColor = _foreColor;
        item.Tag = key;
        // item.Group = Me.Groups(0)

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
            _logConnection.ConnectionObj = _connectionObject;
            _logConnection.Connect();
            cLogItem.Connection = _logConnection;
        }
    }

    protected override bool Disconnect()
    {
        if (base.Disconnect())
        {
            this.IsConnected = false;
            _logConnection.Disconnect();
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

