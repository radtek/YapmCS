using Common;
using System;

public partial class HProcessProp : HXXXProp
{

    // ProcessId of the process opened with the handle
    private int _pid;
    private cProcess _proc;

    public HProcessProp(cHandle handle) : base(handle)
    {
        InitializeComponent();

        try
        {
            // Extract the processId from the name of the handle
            // The string is like : processName (processId)
            string nam = this.TheHandle.Infos.Name;
            int n2 = nam.IndexOf("(", nam.Length - 8);
            int n1 = nam.IndexOf(")", nam.Length - 2);

            if (n2 > 0 && n1 > 0)
            {
                _pid = int.Parse(nam.Substring(n2 + 1, n1 - n2 - 1));
                _proc = cProcess.GetProcessById(_pid);
            }
            else
            {
                _pid = 0;
                _proc = null;
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    // Refresh infos
    public override void RefreshInfos()
    {
        this.cmdOpen.Enabled = (_proc != null);
    }

    private void cmdOpen_Click(object sender, System.EventArgs e)
    {
        frmProcessInfo frm = new frmProcessInfo();
        frm.SetProcess(ref _proc);
        frm.TopMost = Program._frmMain.TopMost;
        frm.Show();
    }

    private void HKeyProp_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.cmdOpen, "Show details about the process");
    }
}

