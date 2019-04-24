using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;

public partial class frmObjDetails
{
    private cGeneralObject _TheObject;

    public cGeneralObject TheObject
    {
        get
        {
            return _TheObject;
        }
        set
        {
            _TheObject = value;
        }
    }

    private void frmFileRelease_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdOK, "OK");
        Misc.SetToolTip(this.cmdRefresh, "Refresh values");

        Native.Functions.Misc.SetTheme(this.lv.Handle);

        RefreshValues();
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lv);
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmdRefresh_Click(System.Object sender, System.EventArgs e)
    {
        RefreshValues();
    }

    // Refresh values
    private void RefreshValues()
    {
        this.lv.BeginUpdate();
        this.lv.Items.Clear();

        foreach (string sProp in _TheObject.GetAvailableProperties(true, true))
        {
            ListViewItem it = new ListViewItem(sProp);
            it.SubItems.Add(_TheObject.GetInformation(sProp));
            this.lv.Items.Add(it);
        }

        this.lv.EndUpdate();
    }

    private void lv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.mnuPopup.Show(this.lv, e.Location);
    }

    private void MenuItemCpProperty_Click(System.Object sender, System.EventArgs e)
    {
        string toCopy = "";
        foreach (ListViewItem it in this.lv.SelectedItems)
            toCopy += it.Text + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCpValue_Click(System.Object sender, System.EventArgs e)
    {
        string toCopy = "";
        foreach (ListViewItem it in this.lv.SelectedItems)
            toCopy += it.SubItems[1].Text + Constants.vbNewLine;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }
}
