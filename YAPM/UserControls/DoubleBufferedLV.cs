using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;


public class DoubleBufferedLV : System.Windows.Forms.ListView
{
    private ColumnHeader m_SortingColumn;

    private List<ListViewItem> _selectedItemsVMode = new List<ListViewItem>();

    // ========================================
    // Public
    // ========================================
    public DoubleBufferedLV() : base()
    {
    }

    public List<ListViewItem> SelectedItemsVMode
    {
        get
        {
            return _selectedItemsVMode;
        }
    }

    public bool OverriddenDoubleBuffered
    {
        get
        {
            return this.DoubleBuffered;
        }
        set
        {
            this.DoubleBuffered = value;
        }
    }

    protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
    {
        base.OnColumnClick(e);

        if (this.VirtualMode)
            return;

        // Get the new sorting column.
        ColumnHeader new_sorting_column = this.Columns[e.Column];

        // Figure out the new sorting order.
        System.Windows.Forms.SortOrder sort_order;
        if (m_SortingColumn == null)
            // New column. Sort ascending.
            sort_order = SortOrder.Ascending;
        else
        {
            // See if this is the same column.
            if (new_sorting_column.Equals(m_SortingColumn))
            {
                // Same column. Switch the sort order.
                if (m_SortingColumn.Text.StartsWith("> "))
                    sort_order = SortOrder.Descending;
                else
                    sort_order = SortOrder.Ascending;
            }
            else
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;

            // Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2);
        }

        // Display the new sort order.
        m_SortingColumn = new_sorting_column;
        if (sort_order == SortOrder.Ascending)
            m_SortingColumn.Text = "> " + m_SortingColumn.Text;
        else
            m_SortingColumn.Text = "< " + m_SortingColumn.Text;

        // Create a comparer.
        this.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

        // Sort.
        this.Sort();
    }

    protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyDown(e);


        if (e.Control)
        {
            if (e.KeyCode == Keys.A)
            {
                if (this.VirtualMode == false)
                {
                    foreach (ListViewItem _it in this.Items)
                        _it.Selected = true;
                }
                else
                {
                    var loopTo = this.VirtualListSize - 1;
                    // Virtual mode -> Me.Items unusable
                    for (int i = 0; i <= loopTo; i++)
                        this.SelectedIndices.Add(i);
                }
            }
            else if (e.KeyCode == Keys.C)
            {
                string _s = "";
                int x = 0;
                foreach (ColumnHeader col in this.Columns)
                {
                    x += 1;
                    _s += col.Text;
                    if (x < this.Columns.Count)
                        _s += Constants.vbTab;
                }
                _s += Constants.vbNewLine;
                x = 0;
                int y = 0;
                if (this.VirtualMode == false)
                {
                    foreach (ListViewItem _it in this.SelectedItems)
                    {
                        foreach (ListViewItem.ListViewSubItem _sub in _it.SubItems)
                        {
                            _s += _sub.Text;
                            y += 1;
                            if (y < _it.SubItems.Count)
                                _s += Constants.vbTab;
                        }
                        y = 0;
                        if (x < this.Items.Count)
                            _s += Constants.vbNewLine;
                        x += 1;
                    }
                    My.MyProject.Computer.Clipboard.SetText(_s);
                }
                else
                {
                    // Virtual mode -> Me.Items unusable
                    // So we use our custom list of selected items
                    foreach (ListViewItem lv in this._selectedItemsVMode)
                    {
                        foreach (ListViewItem.ListViewSubItem _sub in lv.SubItems)
                        {
                            _s += _sub.Text;
                            y += 1;
                            if (y < lv.SubItems.Count)
                                _s += Constants.vbTab;
                        }
                        y = 0;
                        if (x < this.VirtualListSize)
                            _s += Constants.vbNewLine;
                        x += 1;
                    }
                    My.MyProject.Computer.Clipboard.SetText(_s);
                }
            }
        }
    }

    // We have to manually save selected items into a private list
    // in virtual mode, because it's the only way to retrieve SelectedItems
    protected override void OnItemSelectionChanged(System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
    {
        base.OnItemSelectionChanged(e);
        if (this.VirtualMode)
        {
            if (e.IsSelected)
                this._selectedItemsVMode.Add(e.Item);
            else
                this._selectedItemsVMode.Remove(e.Item);
        }
    }

    // Avoid to reorder first column
    protected override void OnColumnReordered(System.Windows.Forms.ColumnReorderedEventArgs e)
    {
        if (e.OldDisplayIndex == 0 | e.NewDisplayIndex == 0)
            e.Cancel = true;
        base.OnColumnReordered(e);
    }
}
