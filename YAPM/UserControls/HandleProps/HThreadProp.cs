using Common;
using System;

public partial class HThreadProp : HXXXProp
{

    // ProcessId/threadId of the process opened with the handle
    private int _pid;
    private cProcess _proc;
    private int _tid;

    public HThreadProp(cHandle handle) : base(handle)
    {
        InitializeComponent();

        try
        {
            // Extract the processId from the name of the handle
            // The string is like : processName (processId) - threadId
            string nam = this.TheHandle.Infos.Name;
            int n2 = nam.IndexOf("(", nam.Length - 17);
            int n1 = nam.IndexOf(")", nam.Length - 13);
            int n3 = nam.IndexOf(" ", nam.Length - 5);

            if (n2 > 0 && n1 > 0 && n3 > 0)
            {
                _pid = int.Parse(nam.Substring(n2 + 1, n1 - n2 - 1));
                _tid = int.Parse(nam.Substring(n3 + 1, nam.Length - n3 - 1));
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
        frm.tabProcess.SelectedTab = frm.TabPageThreads;

        // Create a thread which wait for threads to be added in the lvThread
        // and then select the good thread
        System.Threading.ThreadPool.QueueUserWorkItem(selectThreadImp, new contextObj(_tid, frm));
    }

    private void HKeyProp_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.cmdOpen, "Show details about the thread");
    }

    private struct contextObj
    {
        public int tid;
        public frmProcessInfo frmProcInfo;
        public contextObj(int threadId, frmProcessInfo form)
        {
            tid = threadId;
            frmProcInfo = form;
        }
    }
    private void selectThreadImp(object context)
    {
        contextObj pObj = (contextObj)context;

        // Wait for threads to be added
        while (pObj.frmProcInfo.lvThreads.Items.Count == 0)
            System.Threading.Thread.Sleep(50);

        // Select the good thread
        Async.ListView.EnsureItemVisible(pObj.frmProcInfo.lvThreads, pObj.tid.ToString());
    }
}

