
public partial class HJobProp : HXXXProp
{

    // Associated job
    private cJob _job;

    public HJobProp(cHandle handle) : base(handle)
    {
        InitializeComponent();

        // Try to get the job
        _job = cJob.GetJobByName(this.TheHandle.Infos.Name);
    }

    // Refresh infos
    public override void RefreshInfos()
    {
        this.cmdOpen.Enabled = (_job != null);
    }

    private void cmdOpen_Click(object sender, System.EventArgs e)
    {
        frmJobInfo frm = new frmJobInfo();
        frm.SetJob(ref _job);
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void HKeyProp_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.cmdOpen, "Show details about the job");
    }
}

