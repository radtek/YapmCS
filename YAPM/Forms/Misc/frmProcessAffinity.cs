using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;
using Microsoft.Samples;

public partial class frmProcessAffinity
{
    private cProcess[] proc;

    public frmProcessAffinity(ref cProcess[] cProcs)
    {
        InitializeComponent();
        proc = cProcs;
    }

    private void frmProcessAffinity_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdCancel, "Do not validate changes");
        Misc.SetToolTip(this.cmdOK, "Validate changes");

        if (proc == null || proc.Length == 0)
        {
            this.Close();
            return;
        }

        // Get number of processor of current machine
        int _procCount = proc[0].ProcessorCount - 1;

        // Set checkboxes enable property
        if (_procCount >= 1)
            this.chk1.Enabled = true;
        if (_procCount >= 2)
            this.chk2.Enabled = true;
        if (_procCount >= 3)
            this.chk3.Enabled = true;
        if (_procCount >= 4)
            this.chk4.Enabled = true;
        if (_procCount >= 5)
            this.chk5.Enabled = true;
        if (_procCount >= 6)
            this.chk6.Enabled = true;
        if (_procCount >= 7)
            this.chk7.Enabled = true;
        if (_procCount >= 8)
            this.chk8.Enabled = true;
        if (_procCount >= 9)
            this.chk9.Enabled = true;
        if (_procCount >= 10)
            this.chk10.Enabled = true;
        if (_procCount >= 11)
            this.chk11.Enabled = true;
        if (_procCount >= 12)
            this.chk12.Enabled = true;
        if (_procCount >= 13)
            this.chk13.Enabled = true;
        if (_procCount >= 14)
            this.chk14.Enabled = true;
        if (_procCount >= 15)
            this.chk15.Enabled = true;
        if (_procCount >= 16)
            this.chk16.Enabled = true;
        if (_procCount >= 17)
            this.chk17.Enabled = true;
        if (_procCount >= 18)
            this.chk18.Enabled = true;
        if (_procCount >= 19)
            this.chk19.Enabled = true;
        if (_procCount >= 20)
            this.chk20.Enabled = true;
        if (_procCount >= 21)
            this.chk21.Enabled = true;
        if (_procCount >= 22)
            this.chk22.Enabled = true;
        if (_procCount >= 23)
            this.chk23.Enabled = true;
        if (_procCount >= 24)
            this.chk24.Enabled = true;
        if (_procCount >= 25)
            this.chk25.Enabled = true;
        if (_procCount >= 26)
            this.chk26.Enabled = true;
        if (_procCount >= 27)
            this.chk27.Enabled = true;
        if (_procCount >= 28)
            this.chk28.Enabled = true;
        if (_procCount >= 29)
            this.chk29.Enabled = true;
        if (_procCount >= 30)
            this.chk30.Enabled = true;
        if (_procCount >= 31)
            this.chk31.Enabled = true;

        // Set checkd property
        if (proc.Length > 1)
        {
            // Then all set to true
            foreach (object obj in this.Controls)
            {
                if (obj is CheckBox)
                    ((CheckBox)obj).Checked = ((CheckBox)obj).Enabled;
            }
        }
        else
        {
            // Then only one process
            int m = proc[0].Infos.AffinityMask.ToInt32();
            this.chk0.Checked = ((m & 1) == 1);
            this.chk1.Checked = ((m & 2) == 2);
            this.chk2.Checked = ((m & 4) == 4);
            this.chk3.Checked = ((m & 8) == 8);
            this.chk4.Checked = ((m & 16) == 16);
            this.chk5.Checked = ((m & 32) == 32);
            this.chk6.Checked = ((m & 64) == 64);
            this.chk7.Checked = ((m & 128) == 128);
            this.chk8.Checked = ((m & 256) == 256);
            this.chk9.Checked = ((m & 512) == 512);
            this.chk10.Checked = ((m & 1024) == 1024);
            this.chk11.Checked = ((m & 2048) == 2048);
            this.chk12.Checked = ((m & 4096) == 4096);
            this.chk13.Checked = ((m & 14) == 8192);
            this.chk14.Checked = ((m & 15) == 16384);
            this.chk15.Checked = ((m & 16) == 32768);
            this.chk16.Checked = ((m & 17) == 65536);
            this.chk17.Checked = ((m & 18) == 131072);
            this.chk18.Checked = ((m & 19) == 262144);
            this.chk19.Checked = ((m & 20) == 524288);
            this.chk20.Checked = ((m & 21) == 1048576);
            this.chk21.Checked = ((m & 22) == 2097152);
            this.chk22.Checked = ((m & 23) == 4194304);
            this.chk23.Checked = ((m & 24) == 8388608);
            this.chk24.Checked = ((m & 25) == 16777216);
            this.chk25.Checked = ((m & 26) == 33554432);
            this.chk26.Checked = ((m & 27) == 67108864);
            this.chk27.Checked = ((m & 28) == 134217728);
            this.chk28.Checked = ((m & 29) == 238435456);
            this.chk29.Checked = ((m & 30) == 536870912);
            this.chk30.Checked = ((m & 31) == 1073741824);
            this.chk31.Checked = ((m & 32) == 2147483648);
        }
    }

    private void cmdCancel_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {

        // Calculate new mask
        int m = 0;
        foreach (object obj in this.Controls)
        {
            if (obj is CheckBox)
            {
                CheckBox chk = (CheckBox)obj;
                int number = System.Convert.ToInt32(Conversion.Val(chk.Name.Substring(3, chk.Name.Length - 3)));
                if (chk.Enabled & chk.Checked)
                    m = System.Convert.ToInt32(m + Math.Pow(2, number));
            }
        }

        if (m == 0)
        {
            Misc.ShowMsg("Set affinity", "Could net set affinity.", "Process must have at least one affinity with a processor.", MessageBoxButtons.OK, TaskDialogIcon.Information);
            return;
        }


        // Apply new mask
        foreach (cProcess c in proc)
            c.SetAffinity(m);

        this.Close();
    }
}
