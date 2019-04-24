
public partial class frmSBASimulationConsole
{
    private void frmSBASimulationConsole_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        e.Cancel = true;
    }

    private void frmSBASimulationConsole_Load(object sender, System.EventArgs e)
    {
        Native.Api.NativeFunctions.EnableMenuItem(Native.Api.NativeFunctions.GetSystemMenu(this.Handle, false), Native.Api.NativeConstants.SC_CLOSE, Native.Api.NativeConstants.MF_GRAYED);
        Native.Functions.Misc.SetTheme(lv.Handle);
        Native.Functions.Misc.SetListViewAsDoubleBuffered(ref this.lv);
    }

    private void ClearConsoleToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        this.lv.Items.Clear();
    }
}
