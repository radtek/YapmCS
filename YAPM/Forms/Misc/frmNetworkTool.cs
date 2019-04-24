using System.Windows.Forms;
using Common;

public partial class frmNetworkTool
{
    private cNetwork _net;
    private Native.Api.Enums.ToolType _type;

    public frmNetworkTool(cNetwork conn, Native.Api.Enums.ToolType type)
    {
        InitializeComponent();
        _net = conn;
        _type = type;
        if (_net.Infos.Remote == null)
        {
            this.Text = "No IP address !";
            this.lv.Enabled = false;
        }
        else
        {
            this.lv.Enabled = true;
            this.Text = "IP address : " + _net.Infos.Remote.Address.ToString();
        }
    }

    private void frmFileRelease_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdOK, "OK");
        Misc.SetToolTip(this.cmdReop, "Retry the operation");
        Native.Functions.Misc.SetTheme(this.lv.Handle);
        this.cmdReop_Click(null, null);
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lv);
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void lv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.MenuItemCopyObj.Enabled = (this.lv.SelectedItems.Count > 0);
            this.mnuPopup.Show(this.lv, e.Location);
        }
    }

    private void MenuItemCopyObj_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (ListViewItem it in this.lv.SelectedItems)
            toCopy += it.Text;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    // Start operation
    private void asyncGo(object context)
    {
        if (_net == null)
            return;
        switch (_type)
        {
            case Native.Api.Enums.ToolType.Ping:
                {
                    _net.Ping(this.lv);
                    break;
                }

            case Native.Api.Enums.ToolType.TraceRoute:
                {
                    _net.TraceRoute(this.lv);
                    break;
                }

            case Native.Api.Enums.ToolType.WhoIs:
                {
                    _net.WhoIs(this.lv);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    private void cmdReop_Click(System.Object sender, System.EventArgs e)
    {
        if (_net != null && _net.Infos.Remote != null)
            System.Threading.ThreadPool.QueueUserWorkItem(asyncGo, null);
    }
}
