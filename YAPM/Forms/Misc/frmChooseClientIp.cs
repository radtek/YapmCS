using System.Windows.Forms;
using Common;
using System.Collections.Generic;

public partial class frmChooseClientIp
{
    private string _chosenIp = "";
    private List<Native.Api.Structs.NicDescription> _nics;

    public frmChooseClientIp(List<Native.Api.Structs.NicDescription> nics)
    {
        InitializeComponent();
        _nics = nics;
    }

    public string ChosenIp
    {
        get
        {
            return _chosenIp;
        }
        set
        {
            _chosenIp = value;
        }
    }

    private void frmChooseClientIp_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.lvNIC, "List of available netword card interface");
        Misc.SetToolTip(this.cmdExit, "Cancel");
        Misc.SetToolTip(this.cmdOk, "Use selected netword card interface");
        Native.Functions.Misc.SetTheme(this.lvNIC.Handle);

        // Display NICs
        foreach (Native.Api.Structs.NicDescription nic in _nics)
        {
            ListViewItem it = new ListViewItem(nic.Name);
            it.SubItems.Add(nic.Ip);
            it.SubItems.Add(nic.Description);
            it.Tag = nic;
            this.lvNIC.Items.Add(it);
        }
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void cmdOk_Click(System.Object sender, System.EventArgs e)
    {
        this.ChosenIp = ((Native.Api.Structs.NicDescription)this.lvNIC.SelectedItems[0].Tag).Ip;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void lvNIC_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (this.lvNIC.SelectedItems.Count == 1)
            cmdOk_Click(null, null);
    }

    private void lvNIC_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.cmdOk.Enabled = (this.lvNIC.SelectedItems.Count == 1);
    }
}
