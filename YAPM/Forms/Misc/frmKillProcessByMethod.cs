using System.Windows.Forms;
using Common;

public partial class frmKillProcessByMethod
{
    private cProcess _proc;
    public cProcess ProcessToKill
    {
        get
        {
            return _proc;
        }
        set
        {
            _proc = value;
        }
    }

    private void frmKillProcessByMethod_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.lstMethods, "List of available methods to kill the process");
        Misc.SetToolTip(this.cmdExit, "Exit");
        Misc.SetToolTip(this.cmdKill, "Kill process with selected methods");
        Native.Functions.Misc.SetTheme(this.lstMethods.Handle);

        // Add all methods to the listview
        this.lstMethods.Items.Add("Use NtTerminateProcess").Tag = Native.Api.Enums.KillMethod.NtTerminate;
        this.lstMethods.Items.Add("Terminate all threads").Tag = Native.Api.Enums.KillMethod.ThreadTerminate;
        if (cEnvironment.SupportsGetNextThreadProcessFunctions)
            this.lstMethods.Items.Add("Terminate all threads (other method)").Tag = Native.Api.Enums.KillMethod.ThreadTerminate_GetNextThread;
        // Me.lstMethods.Items.Add("Create remote thread and call ExitProcess").Tag = Native.Api.Enums.KillMethod.CreateRemoteThread
        this.lstMethods.Items.Add("Close all handles").Tag = Native.Api.Enums.KillMethod.CloseAllHandles;
        this.lstMethods.Items.Add("Close all windows").Tag = Native.Api.Enums.KillMethod.CloseAllWindows;
        this.lstMethods.Items.Add("Assign process to a job and terminate job").Tag = Native.Api.Enums.KillMethod.TerminateJob;
        this.lstMethods.Items.Add("All methods").Tag = Native.Api.Enums.KillMethod.All;

        this.Text = this.Text.Replace("[PID]", _proc.Infos.ProcessId.ToString()).Replace("[NAME]", _proc.Infos.Name);
    }

    private void cmdKill_Click(System.Object sender, System.EventArgs e)
    {
        Native.Api.Enums.KillMethod methods;
        foreach (ListViewItem it in this.lstMethods.CheckedItems)
        {
            if ((Native.Api.Enums.KillMethod)it.Tag != Native.Api.Enums.KillMethod.All)
                methods = methods | (Native.Api.Enums.KillMethod)it.Tag;
        }

        if (Misc.WarnDangerousAction("Are you sure you want to kill this process ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return;

        // Now call method to kill
        _proc.KillByMethod(methods);
    }

    private void lstMethods_ItemChecked(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
    {
        this.cmdKill.Enabled = (this.lstMethods.CheckedItems.Count > 0);

        if ((Native.Api.Enums.KillMethod)e.Item.Tag == Native.Api.Enums.KillMethod.All)
        {
            if (e.Item.Checked)
            {
                foreach (ListViewItem it in this.lstMethods.Items)
                    it.Checked = true;
            }
        }
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }
}
