using System.Windows.Forms;
using Common;
using System;

public partial class frmHiddenProcesses
{
    private void frmHiddenProcesses_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.sb, "Change method (click on the arrow) and/or refresh items (click on the shield)");

        Native.Functions.Misc.SetTheme(this.lvProcess.Handle);
        cConnection theConnection = new cConnection();
        theConnection.ConnectionType = cConnection.TypeOfConnection.LocalConnection;

        this.lvProcess.ClearItems();
        this.lvProcess.ConnectionObj = theConnection;

        try
        {
            theConnection.Connect();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
        this.TimerProcess.Enabled = true;
    }

    private void TimerProcess_Tick(System.Object sender, System.EventArgs e)
    {
        this.lvProcess.UpdateItems();
        lblTotal.Text = this.lvProcess.Items.Count.ToString() + " processes";
        int _hidd = 0;
        foreach (cProcess p in this.lvProcess.GetAllItems())
        {
            if (p.Infos.IsHidden)
                _hidd += 1;
        }
        lblHidden.Text = _hidd.ToString() + " hidden processes";
        lblVisible.Text = (this.lvProcess.Items.Count - _hidd).ToString() + " visible processes";
    }

    private void handleMethod_Click(System.Object sender, System.EventArgs e)
    {
        handleMethod.Checked = true;
        bruteforceMethod.Checked = false;
        this.lvProcess.ClearItems();
        this.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.HandleMethod;
    }

    private void bruteforceMethod_Click(System.Object sender, System.EventArgs e)
    {
        handleMethod.Checked = false;
        bruteforceMethod.Checked = true;
        this.lvProcess.ClearItems();
        this.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.BruteForce;
    }

    private void lvProcess_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
        {
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void lvProcess_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.TheContextMenu.Show(this.lvProcess, e.Location);
    }

    private void MenuItemShow_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (System.IO.File.Exists(cp.Infos.Path))
                cFile.ShowFileProperty(cp.Infos.Path, this.Handle);
        }
    }

    private void MenuItemClose_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (cp.Infos.Path != Program.NO_INFO_RETRIEVED)
                cFile.OpenDirectory(cp.Infos.Path);
        }
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcess.SelectedItems.Count > 0)
        {
            cProcess cp = this.lvProcess.GetSelectedItem();
            string s = cp.Infos.Path;
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            Application.DoEvents();
            Misc.SearchInternet(cp.Infos.Name, this.Handle);
        }
    }
}

