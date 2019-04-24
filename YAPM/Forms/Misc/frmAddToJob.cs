// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.


using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System;
using Microsoft.Samples;

public partial class frmAddToJob
{
    private List<int> _pids;
    private cConnection _theConnection;

    private cConnection theConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _theConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_theConnection != null)
            {
            }

            _theConnection = value;
            if (_theConnection != null)
            {
            }
        }
    }

    private bool _local = true;
    private bool _notWMI;

    public frmAddToJob(List<int> pids) : base()
    {
        InitializeComponent();
        _pids = pids;
    }

    private void frmAddToJob_Load(System.Object sender, System.EventArgs e)
    {
        // Connect providers
        // theConnection.CopyFromInstance(Program.Connection)
        try
        {
            theConnection = Program.Connection;
            this.lvJob.ConnectionObj = theConnection;
            theConnection.Connect();
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to connect");
        }

        Common.Misc.SetToolTip(this.optAddGlobal, "Create global job");
        Common.Misc.SetToolTip(this.optAddLocal, "Create local job");
        Common.Misc.SetToolTip(this.OK_Button, "Add to job");
        Common.Misc.SetToolTip(this.Cancel_Button, "Cancel");
        Common.Misc.SetToolTip(this.txtJobName, "Job name (must be not null)");

        Native.Functions.Misc.SetTheme(this.lvJob.Handle);
        Common.Misc.CloseWithEchapKey(ref this);
    }

    private void OK_Button_Click(System.Object sender, System.EventArgs e)
    {

        // Now add the processes to job
        // Add to job
        string name = "";
        if (tab.SelectedIndex == 0)
        {
            if (string.IsNullOrEmpty(this.txtJobName.Text))
            {
                Misc.ShowMsg("Add process to a job", "Could not add process to this job.", "Job name must not be null", MessageBoxButtons.OK, TaskDialogIcon.Error);
                return;
            }

            // New job
            if (optAddGlobal.Checked)
                name = @"Global\" + this.txtJobName.Text;
            else
                name = this.txtJobName.Text;
        }
        else
        {
            // Existing
            cJob _job = this.lvJob.GetSelectedItem();
            name = _job.Infos.Name;
            // Format name
            if (name.StartsWith(@"\BaseNamedObjects\"))
                // Global
                name = name.Replace(@"\BaseNamedObjects\", @"Global\");
        }

        cJob job = cJob.CreateJobByName(name);
        if (job != null)
        {
            // Then we add the job to the menu
            int pid;
            foreach (var pid in _pids)
                job.AddProcess(pid);
        }
        else
            Misc.ShowMsg("Add process to job", "Failed to add the process to the job.", "Informations : " + Native.Api.Win32.GetLastError(), MessageBoxButtons.OK, TaskDialogIcon.Error);

        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        this.lvJob.UpdateTheItems();
    }

    private void lvJob_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (lvJob.SelectedItems.Count > 0)
            this.OK_Button_Click(null, null);
    }

    private void txtJobName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            this.OK_Button_Click(null, null);
    }
}

