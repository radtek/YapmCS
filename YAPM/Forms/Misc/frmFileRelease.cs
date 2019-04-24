using System.Windows.Forms;
using Common;
using System;

public partial class frmFileRelease
{
    public string file;

    private void cmdCheck_Click(System.Object sender, System.EventArgs e)
    {
        // Check if the file is locked (search file as handle/process/module/service)
        checkFile(file);
    }

    private void checkFile(string sToSearch)
    {
        // Launch search
        if ((sToSearch == null) || sToSearch.Length < 1)
            return;
        sToSearch = sToSearch.ToLower();

        this.lv.ClearItems();
        this.lv.ConnectionObj = Program.Connection;
        try
        {
            Program.Connection.Connect();
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to connect");
            return;
        }

        {
            var withBlock = this.lv;
            withBlock.CaseSensitive = false;
            withBlock.SearchString = sToSearch;
            withBlock.Includes = Native.Api.Enums.GeneralObjectType.Handle | Native.Api.Enums.GeneralObjectType.Module | Native.Api.Enums.GeneralObjectType.Process | Native.Api.Enums.GeneralObjectType.Service;
            withBlock.CheckBoxes = false;
            withBlock.UpdateItems();
        }
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        // Here we kick checked items
        // Unload modules & handles
        if (Misc.WarnDangerousAction("Closing the checked items could make the system unstable.", this.Handle) == System.Windows.Forms.DialogResult.Yes)
        {
            // Ok, proceed
            foreach (ListViewItem it in this.lv.CheckedItems)
            {
                cSearchItem cIt = this.lv.GetItemByKey(it.Name);
                if (cIt != null)
                    cIt.CloseTerminate();
            }
        }
    }

    private void frmFileRelease_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdCheck, "Check if a handle to the file in opened by a process");
        Misc.SetToolTip(this.cmdFix, "Close the selected handles");

        Native.Functions.Misc.SetTheme(this.lv.Handle);
    }

    private void lv_HasRefreshed()
    {
        this.lv.CheckBoxes = true;
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lv);
    }
}
