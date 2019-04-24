
public partial class frmBox
{
    public string MsgResult2;

    private void OK_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        MsgResult2 = this.txtMsg2.Text;
        this.Close();
    }

    private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }
}

