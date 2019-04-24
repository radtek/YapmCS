using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Collections;

// Implements a comparer for ListView columns.
public class ListViewComparer : IComparer
{
    private int m_ColumnNumber;
    private SortOrder m_SortOrder;

    public ListViewComparer(int column_number, SortOrder sort_order)
    {
        m_ColumnNumber = column_number;
        m_SortOrder = sort_order;
    }

    // Compare the items in the appropriate column
    // for objects x and y.
    public int Compare(object x, object y)
    {
        ListViewItem item_x = (ListViewItem)x;
        ListViewItem item_y = (ListViewItem)y;

        // Get the sub-item values.
        string string_x;
        if (item_x.SubItems.Count <= m_ColumnNumber)
            string_x = "";
        else
            string_x = item_x.SubItems[m_ColumnNumber].Text;

        string string_y;
        if (item_y.SubItems.Count <= m_ColumnNumber)
            string_y = "";
        else
            string_y = item_y.SubItems[m_ColumnNumber].Text;

        // Compare them.
        if (m_SortOrder == SortOrder.Ascending)
        {
            if (Information.IsNumeric(string_x) & Information.IsNumeric(string_y))
                // Values
                return Conversion.Val(string_x).CompareTo(Conversion.Val(string_y));
            else if (Misc.IsHex(string_x) && Misc.IsHex(string_y))
                // Hex value
                return Misc.HexToLong(string_x).CompareTo(Misc.HexToLong(string_y));
            else if ((Misc.IsFormatedSize(string_x) && Misc.IsFormatedSize(string_y)))
                // Sizes
                return Misc.GetSizeFromFormatedSize(string_x).CompareTo(Misc.GetSizeFromFormatedSize(string_y));
            else
                // String
                return string.Compare(string_x, string_y);
        }
        else if (Information.IsNumeric(string_x) & Information.IsNumeric(string_y))
            // Values
            return Conversion.Val(string_y).CompareTo(Conversion.Val(string_x));
        else if (Misc.IsHex(string_x) && Misc.IsHex(string_y))
            // Hex value
            return Misc.HexToLong(string_y).CompareTo(Misc.HexToLong(string_x));
        else if ((Misc.IsFormatedSize(string_x) && Misc.IsFormatedSize(string_y)))
            // Sizes
            return Misc.GetSizeFromFormatedSize(string_y).CompareTo(Misc.GetSizeFromFormatedSize(string_x));
        else
            // Strings
            return string.Compare(string_y, string_x);
    }
}
