using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;

public partial class frmAddProcessMonitor
{

    // Process to select by default
    public int _selProcess;

    private cConnection _con;

    private struct monCounter
    {
        public string instanceName;
        public string counterTypeName;
        public string categoryName;
    }

    public frmAddProcessMonitor(ref cConnection connection)
    {
        InitializeComponent();
        _con = connection;
    }

    private void frmAddProcessMonitor_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.butAdd, "Monitor the selected process");
        Misc.SetToolTip(this.txtInterval, "Set the refresh interval (milliseconds)");
        Misc.SetToolTip(this.cmdAddToList, "Add counters from list");
        Misc.SetToolTip(this.cmdRemoveFromList, "Remove counters from list");
        Misc.SetToolTip(this.cmdSearch, "Launch search");
        Misc.SetToolTip(this.lstToAdd, "Counters to monitor");
        Misc.SetToolTip(this.lstCounterType, "Available counters");
        Misc.SetToolTip(this.lstInstance, "Available instances");
        Misc.SetToolTip(this.lstCategory, "Available categories");

        Native.Functions.Misc.SetTheme(this.lstToAdd.Handle);
        Native.Functions.Misc.SetTheme(this.lstInstance.Handle);
        Native.Functions.Misc.SetTheme(this.lstCounterType.Handle);
        Native.Functions.Misc.SetTheme(this.lstCategory.Handle);

        // Call Me.cmdRefresh_Click(Nothing, Nothing)

        // ' Select desired process (_selProcess)
        // Dim s As String
        // For Each s In Me.cbProcess.Items
        // Dim i As Integer = InStr(s, " -- ", CompareMethod.Binary)
        // Dim _name As String = s.Substring(0, i - 1)
        // Dim _pid As Integer = CInt(Val(s.Substring(i + 3, s.Length - i - 3)))
        // If _pid = _selProcess Then
        // Me.cbProcess.Text = s
        // Exit For
        // End If
        // Next
        try
        {
            PerformanceCounterCategory[] myCat2;
            int i;
            this.lstCategory.Items.Clear();
            if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                myCat2 = PerformanceCounterCategory.GetCategories(_con.WmiParameters.serverName);
            else
                myCat2 = PerformanceCounterCategory.GetCategories();
            var loopTo = myCat2.Length - 1;
            for (i = 0; i <= loopTo; i++)
                this.lstCategory.Items.Add(myCat2[i].CategoryName);
        }
        catch (Exception ex)
        {
            // Cannot connect to network or access denied ??
            Misc.ShowDebugError(ex);
            Misc.ShowError(ex, "Unable to access to performance counters");
        }
    }

    private void butAdd_Click(System.Object sender, System.EventArgs e)
    {
        // Monitor our process
        ListViewItem lstIt;

        Program._frmMain.tvMonitor.BeginUpdate();
        Program._frmMain.lvMonitorReport.BeginUpdate();

        foreach (var lstIt in this.lstToAdd.Items)
        {
            monCounter obj = (global::frmAddProcessMonitor.monCounter)lstIt.Tag;

            {
                var withBlock = obj;
                string _name = withBlock.instanceName;
                string _cat = withBlock.categoryName;
                string _count = withBlock.counterTypeName;

                cMonitor it;
                if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                    it = new cMonitor(_cat, _count, _name, _con.WmiParameters.serverName);
                else
                    it = new cMonitor(_cat, _count, _name);
                it.Interval = System.Convert.ToInt32(Conversion.Val(this.txtInterval.Text));
                Program._frmMain.AddMonitoringItem(it);
            }
        }

        Program._frmMain.UpdateMonitoringLog();
        Program._frmMain.tvMonitor.EndUpdate();
        Program._frmMain.lvMonitorReport.EndUpdate();

        this.Close();
    }

    private void cmdAddToList_Click(System.Object sender, System.EventArgs e)
    {
        // Add selected counters to wish list
        ListViewItem listIt;

        string _name = Constants.vbNullString;
        string _cat = Constants.vbNullString;
        string _count = Constants.vbNullString;
        if (this.lstCategory.SelectedItems == null)
            return;

        foreach (var listIt in this.lstCounterType.SelectedItems)
        {
            _count = listIt.Text;
            if (this.lstInstance.SelectedItems != null && this.lstInstance.SelectedItems.Count > 0)
                _name = this.lstInstance.SelectedItems[0].Text;
            if (_count == Constants.vbNullString & _name == Constants.vbNullString)
                return;
            _cat = this.lstCategory.SelectedItems[0].Text;

            monCounter it = new monCounter();

            {
                var withBlock = it;
                withBlock.categoryName = _cat;
                withBlock.counterTypeName = _count;
                withBlock.instanceName = _name;
            }

            string sName = _cat + " -- " + System.Convert.ToString(Interaction.IIf(_name == Constants.vbNullString, Constants.vbNullString, _name + " -- ")) + _count;
            bool bPresent = false;

            // Check if item is already added or not
            ListViewItem lvIt;
            foreach (var lvIt in this.lstToAdd.Items)
            {
                if (lvIt.Text == sName)
                {
                    bPresent = true;
                    break;
                }
            }

            if (bPresent == false)
            {
                ListViewItem itList = new ListViewItem();
                itList.Text = sName;
                itList.Tag = it;
                this.lstToAdd.Items.Add(itList);
            }
        }

        this.butAdd.Enabled = (this.lstCounterType.Items.Count > 0);
    }

    private void cmdRemoveFromList_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem it;
        foreach (var it in this.lstToAdd.SelectedItems)
            it.Remove();
        this.butAdd.Enabled = (this.lstCounterType.Items.Count > 0);
    }

    private void lstCategory_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, lstCategory);
    }

    private void lstCategory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        string[] mypc;
        int i;
        if (lstCategory.SelectedItems != null && lstCategory.SelectedItems.Count > 0)
        {
            PerformanceCounterCategory myCat;
            if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text, _con.WmiParameters.serverName);
            else
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text);
            txtHelp.Text = myCat.CategoryHelp;
            this.lstInstance.Items.Clear();
            this.lstCounterType.Items.Clear();
            try
            {
                mypc = myCat.GetInstanceNames();
                var loopTo = mypc.Length - 1;
                for (i = 0; i <= loopTo; i++)
                    this.lstInstance.Items.Add(mypc[i]);
                // Add a comment if there is no instance available
                this.lstInstance.Enabled = (this.lstInstance.Items.Count > 0);
                if (this.lstInstance.Items.Count == 0)
                    this.lstInstance.Items.Add("No instance available");
            }
            catch (Exception ex)
            {
            }
            lstInstance_SelectedIndexChanged(null, null);
        }
    }

    private void lstInstance_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, lstInstance);
    }

    private void lstInstance_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        PerformanceCounter[] mypc;
        int i;
        this.lstCounterType.Items.Clear();
        if (lstInstance.SelectedItems.Count == 0)
        {
            PerformanceCounterCategory myCat;
            if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text, _con.WmiParameters.serverName);
            else
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text);
            this.lstCounterType.Items.Clear();
            try
            {
                mypc = myCat.GetCounters();
                var loopTo = mypc.Length - 1;
                for (i = 0; i <= loopTo; i++)
                    this.lstCounterType.Items.Add(mypc[i].CounterName);
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            PerformanceCounterCategory myCat;
            if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text, _con.WmiParameters.serverName);
            else
                myCat = new PerformanceCounterCategory(lstCategory.SelectedItems[0].Text);
            this.lstCounterType.Items.Clear();
            try
            {
                mypc = myCat.GetCounters(lstInstance.SelectedItems[0].Text);
                var loopTo1 = mypc.Length - 1;
                for (i = 0; i <= loopTo1; i++)
                    this.lstCounterType.Items.Add(mypc[i].CounterName);
            }
            catch (Exception ex)
            {
            }
        }
        this.butAdd.Enabled = (this.lstCounterType.SelectedItems.Count > 0);
    }

    private void lstCounterType_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, lstCounterType);
    }

    private void lstCounterType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        if (lstCounterType.SelectedItems != null && lstCounterType.SelectedItems.Count > 0)
        {
            PerformanceCounter myCat;
            try
            {
                if (_con.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                    myCat = new PerformanceCounter(this.lstCategory.SelectedItems[0].Text, lstCounterType.SelectedItems[0].Text, null, _con.WmiParameters.serverName);
                else
                    myCat = new PerformanceCounter(this.lstCategory.SelectedItems[0].Text, lstCounterType.SelectedItems[0].Text);
                txtHelp.Text = myCat.CounterHelp;
                this.cmdAddToList.Enabled = true;
            }
            catch (Exception ex)
            {
                // Multi instance counter
                this.cmdAddToList.Enabled = false;
            }
        }
    }

    private void lstToAdd_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, lstToAdd);
    }

    private void cmdSearch_Click(System.Object sender, System.EventArgs e)
    {
        frmSearchMonitor frm = new frmSearchMonitor();
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }
}
