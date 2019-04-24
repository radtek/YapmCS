using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public partial class frmHeapBlocks
{
    private int _pid;
    private IntPtr _nodeAdd;

    public frmHeapBlocks(int processId, IntPtr nodeAddress)
    {
        InitializeComponent();
        _pid = processId;
        _nodeAdd = nodeAddress;
        this.Text = "Heap blocks (node address : 0x" + nodeAddress.ToString("x") + ")";
    }

    private void frmFileRelease_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdOK, "OK");
        Native.Functions.Misc.SetTheme(this.lv.Handle);
        this.Invoke(new Enum(asyncEnum));
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Common.Misc.CopyLvToClip(e, this.lv);
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    // Start the enumeration
    private delegate void Enum();
    private void asyncEnum()
    {
        this.lv.Enabled = false;
        this.lv.BeginUpdate();
        this.lv.Items.Clear();

        // Enumerate
        Dictionary<string, Native.Api.NativeStructs.HeapBlock> _dico = Native.Objects.Heap.EnumerateBlocksByNodeAddress(_pid, _nodeAdd);

        // Add items
        foreach (Native.Api.NativeStructs.HeapBlock bl in _dico.Values)
        {
            ListViewItem it = new ListViewItem("0x" + bl.Address.ToString("x"));
            {
                var withBlock = it;
                withBlock.SubItems.Add("0x" + bl.Size.ToString("x"));
                withBlock.SubItems.Add(bl.Flags.ToString());
                withBlock.Tag = bl;
                this.lv.Items.Add(it);
            }
        }

        this.lv.EndUpdate();
        this.lv.Enabled = true;
    }

    private void MenuItemCpAddress_Click(System.Object sender, System.EventArgs e)
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

    private void MenuItemCpSize_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (ListViewItem it in this.lv.SelectedItems)
            toCopy += it.SubItems[1].Text;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void MenuItemCpStatus_Click(System.Object sender, System.EventArgs e)
    {
        string info = ((System.Windows.Forms.MenuItem)sender).Text;
        string toCopy = "";
        foreach (ListViewItem it in this.lv.SelectedItems)
            toCopy += it.SubItems[2].Text;
        if (toCopy.Length > 2)
            // Remove last vbNewline
            toCopy = toCopy.Substring(0, toCopy.Length - 2);
        My.MyProject.Computer.Clipboard.SetText(toCopy);
    }

    private void lv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            this.MenuItemViewMemory_Click(null, null);
    }

    private void lv_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        this.MenuItemViewMemory_Click(null, null);
    }

    private void lv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            this.MenuItemCopyObj.Enabled = (this.lv.SelectedItems.Count > 0);
            this.MenuItemViewMemory.Enabled = (this.lv.SelectedItems.Count > 0);
            this.mnuPopup.Show(this.lv, e.Location);
        }
    }

    private void MenuItemViewMemory_Click(System.Object sender, System.EventArgs e)
    {
        // View memory
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            Native.Api.NativeStructs.HeapBlock bl = (Native.Api.NativeStructs.HeapBlock)it.Tag;
            frmHexEditor frm = new frmHexEditor();
            MemoryHexEditor.MemoryRegion reg = new MemoryHexEditor.MemoryRegion(bl.Address, new IntPtr(bl.Size));
            frm.SetPidAndRegion(_pid, reg);
            frm.Show();
        }
    }
}
