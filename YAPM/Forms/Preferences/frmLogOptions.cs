
public partial class frmLogOptions
{
    private asyncCallbackLogEnumerate.LogItemType _logDisplayMask;
    private asyncCallbackLogEnumerate.LogItemType _logCaptureMask;
    private frmProcessInfo _frm;

    public asyncCallbackLogEnumerate.LogItemType LogCaptureMask
    {
        get
        {
            return _logCaptureMask;
        }
        set
        {
            _logCaptureMask = value;
        }
    }
    public asyncCallbackLogEnumerate.LogItemType LogDisplayMask
    {
        get
        {
            return _logDisplayMask;
        }
        set
        {
            _logDisplayMask = value;
        }
    }
    public frmProcessInfo Form
    {
        get
        {
            return _frm;
        }
        set
        {
            _frm = value;
        }
    }

    private void frmLogOptions_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);

        this.captureHandles.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.HandleItem) == asyncCallbackLogEnumerate.LogItemType.HandleItem;
        this.showHandles.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.HandleItem) == asyncCallbackLogEnumerate.LogItemType.HandleItem;

        this.captureMemoryRegions.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.MemoryItem) == asyncCallbackLogEnumerate.LogItemType.MemoryItem;
        this.showMemoryRegions.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.MemoryItem) == asyncCallbackLogEnumerate.LogItemType.MemoryItem;

        this.captureModules.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.ModuleItem) == asyncCallbackLogEnumerate.LogItemType.ModuleItem;
        this.showModules.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.ModuleItem) == asyncCallbackLogEnumerate.LogItemType.ModuleItem;

        this.captureNetwork.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.NetworkItem) == asyncCallbackLogEnumerate.LogItemType.NetworkItem;
        this.showNetwork.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.NetworkItem) == asyncCallbackLogEnumerate.LogItemType.NetworkItem;

        this.captureServices.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.ServiceItem) == asyncCallbackLogEnumerate.LogItemType.ServiceItem;
        this.showServices.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.ServiceItem) == asyncCallbackLogEnumerate.LogItemType.ServiceItem;

        this.captureThreads.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.ThreadItem) == asyncCallbackLogEnumerate.LogItemType.ThreadItem;
        this.showThreads.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.ThreadItem) == asyncCallbackLogEnumerate.LogItemType.ThreadItem;

        this.captureWindows.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.WindowItem) == asyncCallbackLogEnumerate.LogItemType.WindowItem;
        this.showWindows.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.WindowItem) == asyncCallbackLogEnumerate.LogItemType.WindowItem;

        this.captureCreated.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.CreatedItems) == asyncCallbackLogEnumerate.LogItemType.CreatedItems;
        this.showCreated.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.CreatedItems) == asyncCallbackLogEnumerate.LogItemType.CreatedItems;

        this.captureDeleted.Checked = (_logCaptureMask & asyncCallbackLogEnumerate.LogItemType.DeletedItems) == asyncCallbackLogEnumerate.LogItemType.DeletedItems;
        this.showDeleted.Checked = (_logDisplayMask & asyncCallbackLogEnumerate.LogItemType.DeletedItems) == asyncCallbackLogEnumerate.LogItemType.DeletedItems;

        this.logInterval.Value = _frm.timerLog.Interval;
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        _logCaptureMask = 0;
        _logDisplayMask = 0;

        if (this.captureHandles.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.HandleItem;
        if (this.captureMemoryRegions.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.MemoryItem;
        if (this.captureModules.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.ModuleItem;
        if (this.captureNetwork.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.NetworkItem;
        if (this.captureServices.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.ServiceItem;
        if (this.captureThreads.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.ThreadItem;
        if (this.captureWindows.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.WindowItem;
        if (this.captureCreated.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.CreatedItems;
        if (this.captureDeleted.Checked)
            _logCaptureMask = _logCaptureMask | asyncCallbackLogEnumerate.LogItemType.DeletedItems;

        if (this.showHandles.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.HandleItem;
        if (this.showMemoryRegions.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.MemoryItem;
        if (this.showModules.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.ModuleItem;
        if (this.showNetwork.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.NetworkItem;
        if (this.showServices.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.ServiceItem;
        if (this.showThreads.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.ThreadItem;
        if (this.showWindows.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.WindowItem;
        if (this.showCreated.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.CreatedItems;
        if (this.showDeleted.Checked)
            _logDisplayMask = _logDisplayMask | asyncCallbackLogEnumerate.LogItemType.DeletedItems;

        _frm.LogCaptureMask = _logCaptureMask;
        _frm.LogDisplayMask = _logDisplayMask;
        _frm.timerLog.Interval = System.Convert.ToInt32(this.logInterval.Value);
        _frm.LvAutoScroll = this._autoScroll.Checked;

        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void cmdCancel_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }
}
