using System.Windows.Forms;

public class HXXXProp : UserControl
{

    // Concerned handle
    private cHandle _handle;
    public cHandle TheHandle
    {
        get
        {
            return _handle;
        }
        set
        {
            _handle = value;
        }
    }

    public HXXXProp()
    {
    }
    public HXXXProp(cHandle handle)
    {
        _handle = handle;
    }

    // Refresh displayed informations
    public virtual void RefreshInfos()
    {
    }
}

