using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;
using Microsoft.Samples;

public partial class frmSaveSystemSnapshot
{
    private bool _optionsDisplayed = false;
    private Native.Api.Enums.SnapshotObject _option = Native.Api.Enums.SnapshotObject.All;

    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.cmdBrowse, "Select target file");
        Misc.SetToolTip(this.txtSSFile, "Target file");
        Misc.SetToolTip(this.cmdCreate, "Save the snapshot now");
        Misc.SetToolTip(this.cmdExit, "Close this window");
        Misc.SetToolTip(this.lstOptions, "Objects to include to Snapshot file");

        Native.Functions.Misc.SetTheme(this.lstOptions.Handle);

        this.txtWarning.Text = "Be careful !" + Constants.vbNewLine + Constants.vbNewLine + "If you plan to post the file on a forum asking someone to analyze your system, keep in mind that important information can be transmitted (eg list of processes/services, list of files opened by the system...etc.).";
        var loopTo = this.lstOptions.Items.Count - 1;

        // Check all items in lstOptions
        for (int i = 0; i <= loopTo; i++)
        {
            this.lstOptions.SetItemChecked(i, true);
            // Do not check "mem region" by default cause it requires a lot a
            // memory to save into a file (~1MB)
            string s = System.Convert.ToString(this.lstOptions.Items[i]);
            if (s == "MemoryRegions" || s == "Heaps")
                this.lstOptions.SetItemChecked(i, false);
        }
    }

    private void cmdCreate_Click(System.Object sender, System.EventArgs e)
    {
        string res = null;

        this.lblState.Text = "Creating snapshot...";
        this.Enabled = false;

        // Create empty snapshot file
        cSnapshot snap = new cSnapshot();

        // Get options
        Native.Api.Enums.SnapshotObject options;
        foreach (int i in this.lstOptions.CheckedIndices)
            options = options | (Native.Api.Enums.SnapshotObject)Enum.Parse(typeof(Native.Api.Enums.SnapshotObject), System.Convert.ToString(this.lstOptions.Items[i]));

        // Build it
        if (snap.CreateSnapshot(Program.Connection, options, ref res) == false)
        {
            // Failed
            Misc.ShowMsg("Snapshot creation", "Could not build snapshot.", res, MessageBoxButtons.OK, TaskDialogIcon.Error);
            this.Enabled = true;
            return;
        }

        // Save it
        this.lblState.Text = "Saving snapshot...";
        if (snap.SaveSnapshot(this.txtSSFile.Text, ref res) == false)
        {
            // Failed
            Misc.ShowMsg("Snapshot creation", "Could not save snapshot.", res, MessageBoxButtons.OK, TaskDialogIcon.Error);
            this.Enabled = true;
            return;
        }

        string sSize = "";
        try
        {
            long size = My.MyProject.Computer.FileSystem.GetFileInfo(this.txtSSFile.Text).Length;
            sSize = Misc.GetFormatedSize(size);
        }
        catch (Exception ex)
        {
            sSize = "unknown";
            Misc.ShowDebugError(ex);
        }
        this.lblState.Text = "Created a " + sSize + " size file.";
        this.Enabled = true;
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void cmdBrowse_Click(System.Object sender, System.EventArgs e)
    {
        {
            var withBlock = this.SaveFileDialog;
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtSSFile.Text = withBlock.FileName;
        }
    }

    private void txtSSFile_TextChanged(System.Object sender, System.EventArgs e)
    {
        this.cmdCreate.Enabled = (this.txtSSFile.Text != null) && (this.txtSSFile.Text.Length > 0);
    }

    private void cmdOptions_Click(System.Object sender, System.EventArgs e)
    {
        _optionsDisplayed = !(_optionsDisplayed);
        if (_optionsDisplayed)
        {
            this.Width = 484;
            this.cmdOptions.Text = "< Options";
        }
        else
        {
            this.Width = 310;
            this.cmdOptions.Text = "Options >";
        }
    }
}
