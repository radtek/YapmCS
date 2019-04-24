using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;

public partial class frmWindowPosition
{

    // Default values
    private Native.Api.NativeStructs.Rect defR;

    // New positions (defR must be initialized by cmdOk_Click)
    public Native.Api.NativeStructs.Rect NewRect
    {
        get
        {
            return defR;
        }
    }

    // Define current position of form
    public void SetCurrentPositions(Native.Api.NativeStructs.Rect r)
    {
        defR = r;
        this.txtHeight.Text = System.Convert.ToString(r.Bottom - r.Top);
        this.txtLeft.Text = System.Convert.ToString(r.Left);
        this.txtTop.Text = System.Convert.ToString(r.Top);
        this.txtWidth.Text = System.Convert.ToString(r.Right - r.Left);
    }

    private void cmdDefault_Click(System.Object sender, System.EventArgs e)
    {
        SetCurrentPositions(this.defR);
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        {
            var withBlock = defR;
            withBlock.Bottom = System.Convert.ToInt32(Conversion.Val(this.txtTop.Text) + Conversion.Val(this.txtHeight.Text));
            withBlock.Left = System.Convert.ToInt32(Conversion.Val(this.txtLeft.Text));
            withBlock.Right = System.Convert.ToInt32(Conversion.Val(this.txtLeft.Text) + Conversion.Val(this.txtWidth.Text));
            withBlock.Top = System.Convert.ToInt32(Conversion.Val(this.txtTop.Text));
        }
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void frmWindowPosition_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.txtHeight, "Height of the form");
        Misc.SetToolTip(this.txtLeft, "Left position of the form");
        Misc.SetToolTip(this.txtWidth, "Width of the form");
        Misc.SetToolTip(this.txtTop, "Top position of the form");
        Misc.SetToolTip(this.cmdDefault, "Reset values");
        Misc.SetToolTip(this.cmdOK, "Validate values");
        Misc.SetToolTip(this.cmdCenter, "Center on screen");
    }

    private void cmdCenter_Click(System.Object sender, System.EventArgs e)
    {
        int w = System.Convert.ToInt32(Conversion.Val(this.txtWidth.Text));
        int h = System.Convert.ToInt32(Conversion.Val(this.txtHeight.Text));
        int l = (Screen.PrimaryScreen.Bounds.Width - w) / 2;
        int t = (Screen.PrimaryScreen.Bounds.Height - h) / 2;
        this.txtLeft.Text = l.ToString();
        this.txtTop.Text = t.ToString();
    }
}
