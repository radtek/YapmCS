using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;

public partial class frmSearchMonitor
{
    private void frmSearchMonitor_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.txtToSearch, "Text to search");
        Misc.SetToolTip(this.chkCase, "Is the search case sensitive or not ?");
        Misc.SetToolTip(this.cmdGo, "Launch the search of the specified text");

        Native.Functions.Misc.SetTheme(this.LV.Handle);
    }

    // Launch search
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string s = this.txtToSearch.Text;
        if (this.chkCase.Checked)
            s = s.ToLowerInvariant();
        if (Strings.Len(s) == 0)
            return;

        this.LV.Items.Clear();
        this.LV.BeginUpdate();

        // List all categories
        PerformanceCounterCategory[] myCat2;
        myCat2 = PerformanceCounterCategory.GetCategories();
        var loopTo = myCat2.Length - 1;
        for (int j = 0; j <= loopTo; j++)
        {

            // Found a category
            string category = myCat2[j].CategoryName;
            string sComp = category;
            if (this.chkCase.Checked == false)
                sComp = sComp.ToLowerInvariant();
            if (Strings.InStr(sComp, s, CompareMethod.Binary) > 0)
            {
                ListViewItem it = new ListViewItem(category);
                it.Group = this.LV.Groups["groupCategory"];
                this.LV.Items.Add(it);
            }

            // List all counters without instance
            PerformanceCounterCategory myCat = new PerformanceCounterCategory(category);
            PerformanceCounter[] mypc;
            try
            {
                mypc = myCat.GetCounters();
                var loopTo1 = mypc.Length - 1;
                for (int i = 0; i <= loopTo1; i++)
                {
                    // Found a counter

                    string sComp2 = mypc[i].CounterName;
                    if (this.chkCase.Checked == false)
                        sComp2 = sComp2.ToLowerInvariant();
                    if (Strings.InStr(sComp2, s, CompareMethod.Binary) > 0)
                    {
                        ListViewItem it = new ListViewItem(category + "->" + mypc[i].CounterName);
                        it.Group = this.LV.Groups["groupCounter"];
                        this.LV.Items.Add(it);
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }

            // List all counters with an instance
            // Get first instance of category
            PerformanceCounterCategory myCat3 = new PerformanceCounterCategory(category);
            string[] myPc2;

            try
            {
                myPc2 = myCat3.GetInstanceNames();
                if (myPc2.Length > 0)
                {
                    string instance = myPc2[0];
                    // Now get all counters with this instance
                    PerformanceCounterCategory myCat4 = new PerformanceCounterCategory(category);
                    PerformanceCounter[] mypc4;
                    try
                    {
                        mypc4 = myCat4.GetCounters(instance);
                        var loopTo2 = mypc4.Length - 1;
                        for (int o = 0; o <= loopTo2; o++)
                        {
                            string scomp3 = mypc4[o].CounterName;

                            if (this.chkCase.Checked == false)
                                scomp3 = scomp3.ToLowerInvariant();
                            if (Strings.InStr(scomp3, s, CompareMethod.Binary) > 0)
                            {
                                ListViewItem it = new ListViewItem(category + "->" + mypc4[o].CounterName);
                                it.Group = this.LV.Groups["groupCounter"];
                                this.LV.Items.Add(it);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        this.LV.EndUpdate();
    }
}
