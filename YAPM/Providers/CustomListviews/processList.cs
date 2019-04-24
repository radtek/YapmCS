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

public partial class processList : customLV
{


    // ========================================
    // Public functions
    // ========================================

    public processList()
    {
        _connectionObject = new cConnection();
        _processConnection = new cProcessConnection(this, ref _connectionObject, ref new cProcessConnection.HasEnumeratedEventHandler(HasEnumeratedEventHandler));

        // Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent();

        // Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _IMG = new ImageList();
        _IMG.ImageSize = new Size(16, 16);
        _IMG.ColorDepth = ColorDepth.Depth32Bit;

        this.SmallImageList = _IMG;
        _IMG.Images.Add("noIcon", My.Resources.Resources.application_blue16);

        _firstRefresh = true;
        _first = true;

        // Set handlers
        _processConnection.Disconnected = new cProcessConnection.DisconnectedEventHandler(HasDisconnected);
        _processConnection.Connected = new cProcessConnection.ConnectedEventHandler(HasConnected);
    }

    public event ItemAddedEventHandler ItemAdded;

    public delegate void ItemAddedEventHandler(ref cProcess item);

    public event ItemDeletedEventHandler ItemDeleted;

    public delegate void ItemDeletedEventHandler(ref cProcess item);

    public event HasRefreshedEventHandler HasRefreshed;

    public delegate void HasRefreshedEventHandler();

    public event GotAnErrorEventHandler GotAnError;

    public delegate void GotAnErrorEventHandler(string origin, string msg);


    // ========================================
    // Private
    // ========================================
    private bool _firstRefresh;
    private bool _first;
    private asyncCallbackProcEnumerate.ProcessEnumMethode _enumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses;
    private Dictionary<string, cProcess> _dicoNew = new Dictionary<string, cProcess>();
    private Dictionary<string, cProcess> _dicoDel = new Dictionary<string, cProcess>();
    private Dictionary<string, cProcess> _buffDico = new Dictionary<string, cProcess>();
    private Dictionary<string, cProcess> _dico = new Dictionary<string, cProcess>();
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

    private cProcessConnection __processConnection;

    private cProcessConnection _processConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __processConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__processConnection != null)
            {
            }

            __processConnection = value;
            if (__processConnection != null)
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
    public asyncCallbackProcEnumerate.ProcessEnumMethode EnumMethod
    {
        get
        {
            return _enumMethod;
        }
        set
        {
            _enumMethod = value;
            _processConnection.EnumMethod = _enumMethod;
        }
    }
    public bool FirstRefreshDone
    {
        get
        {
            return !(_firstRefresh);
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
        _firstRefresh = true;
        _firstItemUpdate = true;
        _buffDico.Clear();
        _dico.Clear();
        _dicoDel.Clear();
        _dicoNew.Clear();
        _IMG.Images.Clear();
        _IMG.Images.Add("noIcon", My.Resources.Resources.application_blue16);
        this.Items.Clear();
    }

    // Reanalize a process
    public void ReAnalizeProcesses()
    {
        int[] pid;
        pid = new int[this.GetSelectedItems().Count - 1 + 1];
        int x = 0;
        foreach (cProcess cp in this.GetSelectedItems())
        {
            pid[x] = cp.Infos.ProcessId;
            x += 1;
        }
        generalLvSemaphore.WaitOne();
        asyncCallbackProcEnumerate.ReanalizeProcess(new asyncCallbackProcEnumerate.ReanalizeProcessObj(pid, ref _processConnection));
        generalLvSemaphore.Release();
    }

    // Call this to update items in listview
    public override void UpdateItems()
    {

        // Create a buffer of subitems if necessary
        if (_columnsName == null)
            CreateSubItemsBuffer();

        if (_processConnection.IsConnected)

            // Now enumerate items
            _processConnection.Enumerate(_first, enumMethod: _enumMethod);
    }
    public void UpdateItemsAllInfos()
    {

        // Create a buffer of subitems if necessary
        if (_columnsName == null)
            CreateSubItemsBuffer();

        if (_processConnection.IsConnected)

            // Now enumerate items
            _processConnection.Enumerate(_first, enumMethod: _enumMethod, forceAllInfos: true);
    }

    // Get all items (associated to listviewitems)
    public Dictionary<string, cProcess>.ValueCollection GetAllItems()
    {
        return _dico.Values;
    }

    // Get the selected item
    public cProcess GetSelectedItem()
    {
        if (this.SelectedItems.Count > 0)
            return _dico[this.SelectedItems[0].Name];
        else
            return null;
    }

    // Get a specified item
    public cProcess GetItemByKey(string key)
    {
        if (_dico.ContainsKey(key))
            return _dico[key];
        else
            return null;
    }

    // Get selected items
    public new Dictionary<string, cProcess>.ValueCollection GetSelectedItems()
    {
        Dictionary<string, cProcess> res = new Dictionary<string, cProcess>();

        generalLvSemaphore.WaitOne();
        foreach (ListViewItem it in this.SelectedItems)
            res.Add(it.Name, _dico[it.Name]);
        generalLvSemaphore.Release();

        return res.Values;
    }

    // Get checked items
    public new Dictionary<string, cProcess>.ValueCollection GetCheckedItems()
    {
        Dictionary<string, cProcess> res = new Dictionary<string, cProcess>();

        generalLvSemaphore.WaitOne();
        foreach (ListViewItem it in this.CheckedItems)
            res.Add(it.Name, _dico[it.Name]);
        generalLvSemaphore.Release();

        return res.Values;
    }


    // ========================================
    // Private properties
    // ========================================

    // Executed when enumeration is done
    private void HasEnumeratedEventHandler(bool Success, Dictionary<string, processInfos> Dico, string errorMessage, int instanceId)
    {
        generalLvSemaphore.WaitOne();

        int _test = Native.Api.Win32.GetElapsedTime();

        if (Success == false)
        {
            Trace.WriteLine("Cannot enumerate, an error was raised...");
            GotAnError?.Invoke("Process enumeration", errorMessage);
            generalLvSemaphore.Release();
            return;
        }

        // We won't enumerate next time with all informations (included fixed infos)
        _first = false;


        // Now add all items with isKilled = true to _dicoDel dictionnary
        foreach (cProcess z in _dico.Values)
        {
            if (z.IsKilledItem)
                _dicoDel.Add(z.Infos.ProcessId.ToString(), null);
        }


        // Now add new items to dictionnary
        foreach (System.Collections.Generic.KeyValuePair<string, processInfos> pair in Dico)
        {
            if (!(_dico.ContainsKey(pair.Key)))
                // Add to dico
                _dicoNew.Add(pair.Key, new cProcess(pair.Value));
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
            cProcess.UnAssociatePidAndName(z);    // Remove from global dico
        }
        _dicoDel.Clear();


        // Merge _dico and _dicoNew
        foreach (string z in _dicoNew.Keys)
        {
            cProcess _it = _dicoNew[z];
            ItemAdded?.Invoke(ref _it);
            _it.IsNewItem = !(_firstItemUpdate);        // If first refresh, don't highlight item
            _dico.Add(z.ToString(), _it);
        }

        Native.Objects.Process.SemCurrentProcesses.WaitOne();
        Native.Objects.Process.CurrentProcesses = new Dictionary<string, cProcess>((_dico));
        Native.Objects.Process.SemCurrentProcesses.Release();


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
            cProcess _item = _dico[it.Name];
            if (Dico.ContainsKey(it.Name))
                _item.Merge(ref Dico[it.Name]);
            string ___info = null;
            foreach (var isub in it.SubItems)
            {
                if (_item.GetInformation(_columnsName[x], ref ___info))
                    isub.Text = ___info;
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
                it.BackColor = _item.GetBackColor();
            it.ForeColor = _item.GetForeColor();

            // If we are in 'show hidden process mode', we have to set color red for
            // hidden processes
            if (_item.Infos.IsHidden)
                it.ForeColor = Color.Red;
            else if (it.ForeColor == Color.Red)
                it.ForeColor = Color.Black;
        }


        // Set processes to task class
        cTask.ProcessCollection = _dico;


        // Sort items
        this.Sort();

        _firstItemUpdate = false;

        _test = Native.Api.Win32.GetElapsedTime() - _test;
        Trace.WriteLine("It tooks " + _test.ToString() + " ms to refresh process list.");

        base.UpdateItems();

        generalLvSemaphore.Release();
        _firstRefresh = false;
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
        cProcess proc = _dico[key];
        item.Name = key;

        // Add to global dico
        cProcess.AssociatePidAndName(key, _dico[key].Infos.Name);

        if (_connectionObject.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
        {
            if (proc.Infos.ProcessId > 4)
            {

                // Add icon
                try
                {
                    string fName = proc.Infos.Path;

                    if (System.IO.File.Exists(fName))
                    {
                        this.SmallImageList.Images.Add(fName, Common.Misc.GetIcon(fName, true));
                        item.ImageKey = fName;
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
            _firstRefresh = true;
            _processConnection.ConnectionObj = _connectionObject;
            Native.Objects.Process.ClearNewProcessesDico();
            _processConnection.Connect();
            cProcess.Connection = _processConnection;
        }
    }

    protected override bool Disconnect()
    {
        if (base.Disconnect())
        {
            this.IsConnected = false;
            _processConnection.Disconnect();
            Native.Objects.Process.ClearNewProcessesDico();
        }
    }

    protected void HasDisconnected(bool Success)
    {
    }

    protected void HasConnected(bool Success)
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

