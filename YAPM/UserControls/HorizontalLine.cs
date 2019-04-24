
public class HorizontalLine : System.Windows.Forms.Control
{
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        this.Height = 1;
    }
}
