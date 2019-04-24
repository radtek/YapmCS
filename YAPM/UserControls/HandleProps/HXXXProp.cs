using System.Windows.Forms;

public class HXXXProp : UserControl
{

    // Concerned handle
    public cHandle TheHandle { get; set; }

    public HXXXProp()
    {
    }
    public HXXXProp(cHandle handle)
    {
        TheHandle = handle;
    }

    // Refresh displayed informations
    public virtual void RefreshInfos()
    {
    }
}

