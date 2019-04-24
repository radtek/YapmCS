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
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;

public abstract partial class customLV : DoubleBufferedLV
{
    public event HasChangedColumnsEventHandler HasChangedColumns;

    public delegate void HasChangedColumnsEventHandler();

    // ========================================
    // Protected
    // ========================================

    // General semaphore which protect Dicos, Items...etc.
    internal System.Threading.Semaphore generalLvSemaphore = new System.Threading.Semaphore(1, 1);

    protected bool _firstItemUpdate = true;
    protected string[] _columnsName;

    protected ImageList _IMG;
    protected ColumnHeader m_SortingColumn;

    protected Color _foreColor = Color.FromArgb(30, 30, 30);

    public static Color NEW_ITEM_COLOR = Color.FromArgb(128, 255, 0);
    public static Color DELETED_ITEM_COLOR = Color.FromArgb(255, 64, 48);

    protected const int EMPIRIC_MINIMAL_NUMBER_OF_NEW_ITEMS_TO_BEGIN_UPDATE = 5;
    protected const int EMPIRIC_MINIMAL_NUMBER_OF_DELETED_ITEMS_TO_BEGIN_UPDATE = 5;

    protected bool _catchErrors = false;
    protected bool _reorgCol = true;

    private bool _Isconnected;

    private bool _showObjDetailsOnDblClick = true;


    // ========================================
    // Public
    // ========================================

    public enum ProvidersConnectionType
    {
        Local,
        RemoteWMI,
        Remote
    }

    // Show object details on double click
    public bool ShowObjectDetailsOnDoubleClick
    {
        get
        {
            return _showObjDetailsOnDblClick;
        }
        set
        {
            _showObjDetailsOnDblClick = value;
        }
    }

    // Catch or not errors
    public bool CatchErrors
    {
        get
        {
            return _catchErrors;
        }
        set
        {
            _catchErrors = value;
        }
    }

    // Reorganize columns ?
    public bool ReorganizeColumns
    {
        get
        {
            return _reorgCol;
        }
        set
        {
            _reorgCol = value;
        }
    }

    // Is control connected ?
    public bool IsConnected
    {
        get
        {
            return _Isconnected;
        }
        set
        {
            _Isconnected = value;
        }
    }

    // Call this to update items in listview
    public virtual void UpdateItems()
    {
    }

    // Update the items and display an error
    public virtual void UpdateTheItems()
    {
        if (_catchErrors)
        {
            try
            {
                UpdateItems();
            }
            catch (Exception ex)
            {
                string sMessage = null;
                if (Strings.InStr(ex.Message, "0x800706BA", CompareMethod.Binary) > 0)
                    sMessage = "RPC server is not available. Make sure that WMI is installed, that 'remote procedure call (RPC)' service is started and that no firewall restrict access to RPC service.";
                else if (Strings.InStr(ex.Message, "0x80070005", CompareMethod.Binary) > 0)
                    sMessage = "Access is denied. Make sure that you have the rights to access to the remote computer, and that the passwork and login you entered are correct.";
                else if (Strings.InStr(ex.Message, "0x80010108", CompareMethod.Binary) > 0)
                    sMessage = "Diconnected. Try to establish connection again.";

                if (sMessage != null)
                    Misc.ShowError(ex, "Could not retieve informations : " + sMessage);
                else
                    Misc.ShowError(ex, "Could not retieve informations");
            }
        }
        else
            UpdateItems();
    }

    // Choose column
    public void ChooseColumns()
    {
        frmChooseColumns frm = new frmChooseColumns();
        frm.ConcernedListView = this;
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();

        // Recreate subitem buffer and get columns name again
        CreateSubItemsBuffer();

        // Refresh items
        _firstItemUpdate = true;
        this.BeginUpdate();
        this.UpdateItems();
        this.EndUpdate();

        HasChangedColumns?.Invoke();
    }

    protected override void OnColumnWidthChanged(System.Windows.Forms.ColumnWidthChangedEventArgs e)
    {
        base.OnColumnWidthChanged(e);
        if (_reorgCol == false)
            HasChangedColumns?.Invoke();
    }

    // Force refreshing of all items and subitems
    // Have to NOT USE generalLvSemaphore in this method because it is always
    // called in a safe context
    public abstract void ForceRefreshingOfAllItems();

    // Connection stuffs
    protected virtual bool Connect()
    {
        return !(_Isconnected);
    }
    protected virtual bool Disconnect()
    {
        return _Isconnected;
    }


    // ========================================
    // Private
    // ========================================

    // Add an item (specific to type of list)
    internal virtual ListViewItem AddItemWithStyle(string key)
    {
        return null;
    }

    // Create some subitems
    internal void CreateSubItemsBuffer()
    {

        // Get column names
        int _size = this.Columns.Count - 1;
        _columnsName = new string[_size + 1];
        var loopTo = _size;
        for (int x = 0; x <= loopTo; x++)
            _columnsName[x] = this.Columns[x].Text.Replace("< ", "").Replace("> ", "");
    }
}

