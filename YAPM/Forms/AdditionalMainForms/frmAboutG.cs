using Common;

public partial class frmAboutG
{
    private void btnOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void lnklblSF_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://sourceforge.net/projects/yaprocmon/", this.Handle);
    }

    private void frmAboutG_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.cmdLicense, "Display license of YAPM");
        Misc.SetToolTip(this.btnOK, "Close this window");
        Misc.SetToolTip(this.lnklblSF, "Visit YAPM webpage on sourceforge.net");
        Misc.SetToolTip(this.lnkWebsite, "Visit YAPM website");

        this.lblVersion.Text = My.MyProject.Application.Info.Version.ToString();
    }

    private void lblMe_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("mailto:YetAnotherProcessMonitor@gmail.com", this.Handle);
    }

    private void cmdLicense_Click(System.Object sender, System.EventArgs e)
    {
        frmAbout frm = new frmAbout();
        frm.TopMost = Program._frmMain.TopMost;
        frm.ShowDialog();
    }

    private void lblRibbon_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://www.codeproject.com/KB/toolbars/WinFormsRibbon.aspx", this.Handle);
    }

    private void lblFugueIcons_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://www.pinvoke.com/", this.Handle);
    }

    private void lblShareVB_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://www.sharevb.net/", this.Handle);
    }

    private void lblTaskDialog_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://www.codeproject.com/KB/vista/TaskDialogWinForms.aspx", this.Handle);
    }

    private void lblVistaMenu_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://wyday.com/opensource.php", this.Handle);
    }

    private void lnkWebsite_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://sourceforge.net/projects/yaprocmon/", this.Handle);
    }

    private void lnkMarcel_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://www.codeproject.com/Members/marcel-heeremans", this.Handle);
    }
}
