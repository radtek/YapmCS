using System.Windows.Forms;

namespace Async
{


    // Some async and threaf safe functions for the Listview control
    public class ListView : System.Windows.Forms.ListView
    {
        private delegate ListViewItem degAddItem(ListView lv, string text);
        public static System.Windows.Forms.ListViewItem AddItem(System.Windows.Forms.ListView lv, string text)
        {
            if (lv.InvokeRequired)
            {
                degAddItem d = new degAddItem(AddItem);
                return (ListViewItem)lv.Invoke(d, lv, text);
            }
            else
            {
                ListViewItem it = lv.Items.Add(text);
                return it;
            }
        }

        private delegate void degChangeVirtualListSize(System.Windows.Forms.ListView lv, int value);
        public static void ChangeVirtualListSize(System.Windows.Forms.ListView lv, int value)
        {
            if (lv.InvokeRequired)
            {
                degChangeVirtualListSize d = new degChangeVirtualListSize(ChangeVirtualListSize);
                lv.Invoke(d, lv, value);
            }
            else
                lv.VirtualListSize = value;
        }

        private delegate System.Windows.Forms.ListViewItem degEnsureItemVisible(System.Windows.Forms.ListView lv, string text);
        public static System.Windows.Forms.ListViewItem EnsureItemVisible(System.Windows.Forms.ListView lv, string text)
        {
            if (lv.InvokeRequired)
            {
                degEnsureItemVisible d = new degEnsureItemVisible(EnsureItemVisible);
                return (ListViewItem)lv.Invoke(d, lv, text);
            }
            else
            {
                ListViewItem it = lv.FindItemWithText(text);
                if (it != null)
                {
                    it.Selected = true;
                    it.EnsureVisible();
                }
                return it;
            }
        }
    }



    // Some async and threaf safe functions for the ProgressBar control
    public class ProgressBar
    {
        private delegate void degChangeValue(System.Windows.Forms.ProgressBar pgb, int value);
        public static void ChangeValue(System.Windows.Forms.ProgressBar pgb, int value)
        {
            if (pgb.InvokeRequired)
            {
                degChangeValue d = new degChangeValue(ChangeValue);
                pgb.Invoke(d, pgb, value);
            }
            else
                pgb.Value = value;
        }

        private delegate void degChangeMaximum(System.Windows.Forms.ProgressBar pgb, int value);
        public static void ChangeMaximum(System.Windows.Forms.ProgressBar pgb, int value)
        {
            if (pgb.InvokeRequired)
            {
                degChangeMaximum d = new degChangeMaximum(ChangeMaximum);
                pgb.Invoke(d, pgb, value);
            }
            else
                pgb.Maximum = value;
        }
    }



    // Some async and threaf safe functions for the SplitContainer control
    public class SplitContainer
    {
        private delegate void degChangeEnabled(System.Windows.Forms.SplitContainer tb, bool value);
        public static void ChangeEnabled(System.Windows.Forms.SplitContainer tb, bool value)
        {
            if (tb.InvokeRequired)
            {
                degChangeEnabled d = new degChangeEnabled(ChangeEnabled);
                tb.Invoke(d, tb, value);
            }
            else
                tb.Enabled = value;
        }
    }


    // Some async and threaf safe functions for the Form control
    public class Form
    {
        private delegate void degChangeEnabled(System.Windows.Forms.Form frm, bool value);
        public static void ChangeEnabled(System.Windows.Forms.Form frm, bool value)
        {
            if (frm.InvokeRequired)
            {
                degChangeEnabled d = new degChangeEnabled(ChangeEnabled);
                frm.Invoke(d, frm, value);
            }
            else
                frm.Enabled = value;
        }
    }
}

