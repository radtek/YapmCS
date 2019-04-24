
public partial class HKeyProp : HXXXProp
{
    public HKeyProp(cHandle handle) : base(handle)
    {
        InitializeComponent();
    }

    // Refresh infos
    public override void RefreshInfos()
    {
        this.cmdOpen.Enabled = (cHandle.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
    }

    private void cmdOpen_Click(object sender, System.EventArgs e)
    {
        Common.Misc.NavigateToRegedit(this.TheHandle.Infos.Name);
    }

    private void HKeyProp_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.cmdOpen, "Open the key in regedit");
    }
}

