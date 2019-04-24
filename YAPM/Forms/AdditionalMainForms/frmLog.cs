using System.Windows.Forms;

public partial class frmLog
{

    // Private lCount As Integer = 0

    // Private Sub timerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRefresh.Tick
    // If lCount <> Program.Log.LineCount Then
    // Dim i As Integer = Me.txtLog.SelectionStart
    // Dim z As Integer = Program.Log.LineCount

    // ' Add new lines
    // For x As Integer = lCount + 1 To z
    // Me.txtLog.Text &= Program.Log.Line(x)
    // Next x

    // lCount = z

    // Me.txtLog.SelectionStart = i
    // Me.txtLog.ScrollToCaret()
    // End If
    // End Sub

    // Private Sub frmLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mybase.Load
    // Call timerRefresh_Tick(Nothing, Nothing)
    // End Sub


    private void frmLog_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        Program.Log.ShowForm = false;
        e.Cancel = true;
    }

    private void frmLog_Load(object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(this.lv.Handle);
    }

    private void MenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmSaveReport frm = new frmSaveReport();
        {
            var withBlock = frm;
            withBlock.ReportType = "log";
            Application.DoEvents();
            withBlock.TopMost = Program._frmMain.TopMost;
            withBlock.ShowDialog();
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        Program.Log.Clear();
    }

    private void lv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.TheContextMenu.Show(this.lv, e.Location);
    }
}
