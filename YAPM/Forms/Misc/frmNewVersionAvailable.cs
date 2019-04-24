using Microsoft.VisualBasic;
using Common;

public partial class frmNewVersionAvailable
{
    private cUpdate.NewReleaseInfos _infos;

    public frmNewVersionAvailable(cUpdate.NewReleaseInfos infos)
    {
        InitializeComponent();
        _infos = infos;
    }

    private void btnOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void frmAboutG_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.cmdDownload, "Download the new version now");
        Misc.SetToolTip(this.btnOK, "Close this window");

        {
            var withBlock = _infos;
            string desc = withBlock.Description;
            if (desc != null)
                desc = desc.Replace((char)10, Constants.vbNewLine);
            this.lblVersion.Text = withBlock.Version;
            this.lblDate.Text = withBlock.Date;
            this.txtDesc.Text = desc;
            this.lblCaption.Text = withBlock.Caption;
            this.lblType.Text = withBlock.Type;
        }
    }

    private void cmdDownload_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(_infos.Url, this.Handle);
    }
}
