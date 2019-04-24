using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;

public partial class frmChooseColumns
{
    private customLV theListview;

    public customLV ConcernedListView
    {
        get
        {
            return theListview;
        }
        set
        {
            theListview = value;
        }
    }


    private void OK_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;

        theListview.generalLvSemaphore.WaitOne();
        theListview.ReorganizeColumns = true;
        theListview.BeginUpdate();

        // Remove all columns
        for (int x = theListview.Columns.Count - 1; x >= 1; x += -1)
            theListview.Columns.Remove(theListview.Columns[x]);

        // Add new columns
        foreach (ListViewItem it in this.lv.CheckedItems)
        {
            int width = System.Convert.ToInt32(Conversion.Val(it.SubItems[1].Text));
            if (width <= 0)
                width = 90;// Default size
            theListview.Columns.Add(it.Text, width).TextAlign = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), it.SubItems[2].Text);
        }

        // Add items which are selected
        foreach (ListViewItem it in theListview.Items)
        {

            // Can not use .Clear because it also remove the Item
            for (int i = it.SubItems.Count - 1; i >= 1; i += -1)
                it.SubItems.RemoveAt(i);

            string[] subit;
            subit = new string[this.lv.CheckedItems.Count + 1];
            var loopTo = Information.UBound(subit) - 1;
            for (int z = 0; z <= loopTo; z++)
                subit[z] = "";

            it.SubItems.AddRange(subit);
        }

        // Refresh all items & subitems
        ConcernedListView.CreateSubItemsBuffer();
        ConcernedListView.ForceRefreshingOfAllItems();

        theListview.ReorganizeColumns = false;
        theListview.EndUpdate();
        theListview.generalLvSemaphore.Release();
        this.Close();
    }

    private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void cmdSelAll_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lv.Items)
            it.Checked = true;
    }

    private void btnUnSelAll_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lv.Items)
            it.Checked = false;
    }

    private void frmChooseProcessColumns_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(this.lv.Handle);

        string[] ss;
        ss = new string[0];

        // This is some kind of shit.
        // But as I can't write a MustOverride Shared Function...
        if ((ConcernedListView) is handleList)
            ss = handleInfos.GetAvailableProperties();
        else if ((ConcernedListView) is memoryList)
            ss = memRegionInfos.GetAvailableProperties();
        else if ((ConcernedListView) is moduleList)
            ss = moduleInfos.GetAvailableProperties();
        else if ((ConcernedListView) is networkList)
            ss = networkInfos.GetAvailableProperties();
        else if ((ConcernedListView) is processList)
            ss = processInfos.GetAvailableProperties();
        else if ((ConcernedListView) is serviceList)
            ss = serviceInfos.GetAvailableProperties();
        else if ((ConcernedListView) is taskList)
            ss = taskInfos.GetAvailableProperties();
        else if ((ConcernedListView) is threadList)
            ss = threadInfos.GetAvailableProperties();
        else if ((ConcernedListView) is windowList)
            ss = windowInfos.GetAvailableProperties();
        else if ((ConcernedListView) is privilegeList)
            ss = privilegeInfos.GetAvailableProperties();
        else if ((ConcernedListView) is envVariableList)
            ss = envVariableInfos.GetAvailableProperties();
        else if ((ConcernedListView) is jobLimitList)
            ss = jobLimitInfos.GetAvailableProperties();
        else if ((ConcernedListView) is jobList)
            ss = jobInfos.GetAvailableProperties();
        else if ((ConcernedListView) is processesInJobList)
            ss = processInfos.GetAvailableProperties();
        else if ((ConcernedListView) is heapList)
            ss = heapInfos.GetAvailableProperties();
        var oldSs = ss;
        ss = new string[ss.Length + 1 + 1];
        if (oldSs != null)
            Array.Copy(oldSs, ss, Math.Min(ss.Length + 1 + 1, oldSs.Length));
        ss[ss.Length - 2] = "ObjectCreationDate";
        ss[ss.Length - 1] = "PendingTaskCount";
        var loopTo = ConcernedListView.Columns.Count - 1;

        // Now add displayed columns names to list
        // Add this columns by DisplayIndex order

        // Start from 1 because item 0 is fixed and not added in our list
        for (int x = 1; x <= loopTo; x++)
        {
            ColumnHeader col = Common.Misc.GetColumnHeaderByDisplayIndex(ref ConcernedListView, x);
            string sss = col.Text.Replace("< ", "").Replace("> ", "");
            ListViewItem it = new ListViewItem(sss);
            it.Checked = true;
            it.Name = sss;
            it.SubItems.Add(col.Width.ToString());
            it.SubItems.Add(col.TextAlign.ToString());
            this.lv.Items.Add(it);
        }

        // Add other columns (which are not displayed)
        foreach (string s in ss)
        {
            if (this.lv.Items.ContainsKey(s) == false)
            {
                ListViewItem it = new ListViewItem(s);
                it.SubItems.Add("");
                it.SubItems.Add(HorizontalAlignment.Left.ToString());
                this.lv.Items.Add(it);
            }
        }
    }

    private void cmdInvert_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lv.Items)
            it.Checked = !(it.Checked);
    }

    private void cmdMoveUp_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lv.SelectedItems == null || this.lv.SelectedItems.Count != 1)
            return;
        if (this.lv.SelectedItems[0].Index == 0)
            return;

        this.lv.BeginUpdate();
        Misc.MoveListViewItem(this.lv, true);
        this.lv.EndUpdate();
    }

    private void cmdMoveDown_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lv.SelectedItems == null || this.lv.SelectedItems.Count != 1)
            return;
        if (this.lv.SelectedItems[0].Index == this.lv.Items.Count - 1)
            return;

        this.lv.BeginUpdate();
        Misc.MoveListViewItem(this.lv, false);
        this.lv.EndUpdate();
    }

    private void cmdDefault_Click(System.Object sender, System.EventArgs e)
    {
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lv.SelectedItems.Count == 1 && e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            string sAlign = this.lv.SelectedItems[0].SubItems[2].Text;
            switch (sAlign)
            {
                case object _ when HorizontalAlignment.Left.ToString():
                    {
                        sAlign = HorizontalAlignment.Center.ToString();
                        break;
                    }

                case object _ when HorizontalAlignment.Right.ToString():
                    {
                        sAlign = HorizontalAlignment.Left.ToString();
                        break;
                    }

                default:
                    {
                        sAlign = HorizontalAlignment.Right.ToString();
                        break;
                    }
            }
            this.lv.SelectedItems[0].SubItems[2].Text = sAlign;
        }
    }
}
