
public partial class frmChooseProcess
{
    private cProcess _cproc;

    public cProcess SelectedProcess
    {
        get
        {
            return _cproc;
        }
    }

    private void timerProcRefresh_Tick(System.Object sender, System.EventArgs e)
    {
        lvProcess.UpdateTheItems();
    }

    private void lvProcess_DoubleClick(object sender, System.EventArgs e)
    {
        if (lvProcess.SelectedItems.Count > 0)
        {
            _cproc = lvProcess.GetSelectedItem();
            this.Close();
        }
    }

    private void frmChooseProcess_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        this.timerProcRefresh.Enabled = false;
    }

    private void frmChooseProcess_Load(object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(this.lvProcess.Handle);
        lvProcess.UpdateTheItems();
    }
}
