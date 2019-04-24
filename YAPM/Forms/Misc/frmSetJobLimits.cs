using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Collections.Generic;
using System;
using Native.Api;

public partial class frmSetJobLimits
{
    private string _jobName;
    private frmJobInfo _jobInfoForm;

    public string JobName
    {
        get
        {
            return _jobName;
        }
        set
        {
            _jobName = value;
        }
    }

    public frmSetJobLimits(ref frmJobInfo frmJInfo)
    {
        InitializeComponent();
        // Get the caller form
        _jobInfoForm = frmJInfo;
    }

    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        // Tooltips
        Misc.SetToolTip(this.chkActiveProcesses, "Establishes a maximum number of simultaneously active processes associated with the job");
        Misc.SetToolTip(this.chkAffinity, "Causes all processes associated with the job to use the same processor affinity");
        Misc.SetToolTip(this.chkBreakawayOK, "If any process associated with the job creates a child process using the CREATE_BREAKAWAY_FROM_JOB flag while this limit is in effect, the child process is not associated with the job");
        Misc.SetToolTip(this.chkCommittedMemPerJ, "Causes all processes associated with the job to limit the job-wide sum of their committed memory. When a process attempts to commit memory that would exceed the job-wide limit, it fails. If the job object is associated with a completion port, a JOB_OBJECT_MSG_JOB_MEMORY_LIMIT message is sent to the completion port.");
        Misc.SetToolTip(this.chkCommittedMemPerP, "Causes all processes associated with the job to limit their committed memory. When a process attempts to commit memory that would exceed the per-process limit, it fails. If the job object is associated with a completion port, a JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT message is sent to the completion port");
        Misc.SetToolTip(this.chkDieOnUnhandledEx, "Forces a call to the SetErrorMode function with the SEM_NOGPFAULTERRORBOX flag for each process associated with the job. " + Constants.vbNewLine + "If an exception occurs and the system calls the UnhandledExceptionFilter function, the debugger will be given a chance to act. If there is no debugger, the functions returns EXCEPTION_EXECUTE_HANDLER. Normally, this will cause termination of the process with the exception code as the exit status.");
        Misc.SetToolTip(this.chkKillOnJobClose, "Causes all processes associated with the job to terminate when the last handle to the job is closed");
        Misc.SetToolTip(this.chkMinMaxWS, "Causes all processes associated with the job to use the same minimum and maximum working set sizes.");
        Misc.SetToolTip(this.chkPreserveJobTime, "Preserves any job time limits you previously set. As long as this flag is set, you can establish a per-job time limit once, then alter other limits in subsequent calls. This flag cannot be used with JOB_OBJECT_LIMIT_JOB_TIME");
        Misc.SetToolTip(this.chkPriority, "Causes all processes associated with the job to use the same priority class");
        Misc.SetToolTip(this.chkSchedulingC, "Causes all processes in the job to use the same scheduling class");
        Misc.SetToolTip(this.chkSilentBAOK, "Allows any process associated with the job to create child processes that are not associated with the job");
        Misc.SetToolTip(this.chkUIdesktop, "Prevents processes associated with the job from creating desktops and switching desktops using the CreateDesktop and SwitchDesktop functions");
        Misc.SetToolTip(this.chkUIDisplaySettings, "Prevents processes associated with the job from calling the ChangeDisplaySettings function");
        Misc.SetToolTip(this.chkUIExitW, "Prevents processes associated with the job from calling the ExitWindows or ExitWindowsEx function");
        Misc.SetToolTip(this.chkUIglobalAtoms, "Prevents processes associated with the job from accessing global atoms. When this flag is used, each job has its own atom table");
        Misc.SetToolTip(this.chkUIhandles, "Prevents processes associated with the job from using USER handles owned by processes not associated with the same job");
        Misc.SetToolTip(this.chkUIreadCB, "Prevents processes associated with the job from reading data from the clipboard");
        Misc.SetToolTip(this.chkUIsystemParam, "Prevents processes associated with the job from changing system parameters by using the SystemParametersInfo function");
        Misc.SetToolTip(this.chkUIwriteCB, "Prevents processes associated with the job from writing data to the clipboard");
        Misc.SetToolTip(this.chkUserModePerJ, "Establishes a user-mode execution time limit for the job");
        Misc.SetToolTip(this.chkUserModePerP, "Establishes a user-mode execution time limit for each currently active process and for all future processes associated with the job");
        Misc.SetToolTip(this.valAffinity, "Common affinity for all processes in the job");
        Misc.SetToolTip(this.cbPriority, "Priority class of the job");
        Misc.SetToolTip(this.valActiveProcesses, "Maximum active processes in job");
        Misc.SetToolTip(this.valMaxWS, "Max working set size per process");
        Misc.SetToolTip(this.valMemJ, "Max committed memory for job");
        Misc.SetToolTip(this.valMemP, "Max committed memory for each process");
        Misc.SetToolTip(this.valMinWS, "Min working set size per process");
        Misc.SetToolTip(this.valScheduling, "Common scheduling class for all processes");
        Misc.SetToolTip(this.valUsertimeJ, "Max CPU time in usermode for job");
        Misc.SetToolTip(this.valUsertimeP, "Max CPU time in usermode per process");
        Misc.SetToolTip(this.cmdExit, "Exit without modifiying limits");
        Misc.SetToolTip(this.cmdSetLimits, "Set limits to the job");


        // Get all limits from the limit's listview (cause it's well refreshed
        // depending of the type of connection)
        Dictionary<string, cJobLimit> _limits = new Dictionary<string, cJobLimit>();
        foreach (cJobLimit limit in _jobInfoForm.lvLimits.GetAllItems())
            _limits.Add(limit.Infos.Name, limit);

        foreach (System.Collections.Generic.KeyValuePair<string, cJobLimit> pair in _limits)
        {

            // UI limits
            if (pair.Key == "Desktop")
                this.chkUIdesktop.Checked = true;
            if (pair.Key == "DisplaySettings")
                this.chkUIDisplaySettings.Checked = true;
            if (pair.Key == "ExitWindows")
                this.chkUIExitW.Checked = true;
            if (pair.Key == "GlobalAtoms")
                this.chkUIglobalAtoms.Checked = true;
            if (pair.Key == "Handles")
                this.chkUIhandles.Checked = true;
            if (pair.Key == "ReadClipboard")
                this.chkUIreadCB.Checked = true;
            if (pair.Key == "SystemParameters")
                this.chkUIsystemParam.Checked = true;
            if (pair.Key == "WriteClipboard")
                this.chkUIwriteCB.Checked = true;

            // Other limitations
            if (pair.Key == "ActiveProcess")
            {
                this.chkActiveProcesses.Checked = true;
                this.valActiveProcesses.Value = System.Convert.ToInt32(pair.Value.Infos.ValueObject);
            }
            if (pair.Key == "Affinity")
            {
                this.chkAffinity.Checked = true;
                this.valAffinity.Value = ((IntPtr)pair.Value.Infos.ValueObject).ToInt32();
            }
            if (pair.Key == "BreakawayOk")
                this.chkBreakawayOK.Checked = true;
            if (pair.Key == "DieOnUnhandledException")
                this.chkDieOnUnhandledEx.Checked = true;
            if (pair.Key == "JobMemory")
            {
                this.chkCommittedMemPerJ.Checked = true;
                IntPtr value = (IntPtr)pair.Value.Infos.ValueObject;
                this.valMemJ.Value = System.Convert.ToDecimal(value.ToInt64() / (double)1024);
            }
            if (pair.Key == "JobTime")
            {
                this.chkUserModePerJ.Checked = true;
                this.valUsertimeJ.Value = System.Convert.ToInt32(System.Convert.ToInt64(pair.Value.Infos.ValueObject) / (double)10);
            }
            if (pair.Key == "KillOnJobClose")
                this.chkKillOnJobClose.Checked = true;
            if (pair.Key == "PreserveJobTime")
                this.chkPreserveJobTime.Checked = true;
            if (pair.Key == "PriorityClass")
            {
                this.chkPriority.Checked = true;
                this.cbPriority.Text = ((System.Diagnostics.ProcessPriorityClass)pair.Value.Infos.ValueObject).ToString();
            }
            if (pair.Key == "ProcessMemory")
            {
                this.chkCommittedMemPerP.Checked = true;
                IntPtr value = (IntPtr)pair.Value.Infos.ValueObject;
                this.valMemP.Value = System.Convert.ToDecimal(value.ToInt64() / (double)1024);
            }
            if (pair.Key == "ProcessTime")
            {
                this.chkUserModePerJ.Checked = true;
                this.valUsertimeP.Value = System.Convert.ToInt32(System.Convert.ToInt32(pair.Value.Infos.ValueObject) / (double)10);
            }
            if (pair.Key == "SchedulingClass")
            {
                this.chkSchedulingC.Checked = true;
                this.valScheduling.Value = System.Convert.ToInt32(pair.Value.Infos.ValueObject);
            }
            if (pair.Key == "SilentBreakawayOk")
                this.chkSilentBAOK.Checked = true;
            if (pair.Key == "WorkingSetMin")
            {
                this.chkMinMaxWS.Checked = true;
                IntPtr value = (IntPtr)pair.Value.Infos.ValueObject;
                this.valMinWS.Value = System.Convert.ToDecimal(value.ToInt64() / (double)1024);
            }
            if (pair.Key == "WorkingSetMax")
            {
                this.chkMinMaxWS.Checked = true;
                IntPtr value = (IntPtr)pair.Value.Infos.ValueObject;
                this.valMaxWS.Value = System.Convert.ToDecimal(value.ToInt64() / (double)1024);
            }
        }
    }

    private void cmdCreate_Click(System.Object sender, System.EventArgs e)
    {
        if (setLimits() == System.Windows.Forms.DialogResult.OK)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }


    // This is NOT possible to combile all flags together
    // See http://msdn.microsoft.com/en-us/library/ms684147(VS.85).aspx
    // for details about what is permitted and what is not

    private void chkPreserveJobTime_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.chkUserModePerJ.Enabled = !(this.chkPreserveJobTime.Checked);
        if (this.chkPreserveJobTime.Enabled == false)
            this.chkPreserveJobTime.Checked = false;
    }

    private void chkUserModePerJ_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.chkPreserveJobTime.Enabled = !(this.chkUserModePerJ.Checked);
        if (this.chkPreserveJobTime.Enabled == false)
            this.chkPreserveJobTime.Checked = false;
        this.valUsertimeJ.Enabled = this.chkUserModePerJ.Checked;
    }

    private void chkAffinity_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valAffinity.Enabled = this.chkAffinity.Checked;
    }

    private void chkActiveProcesses_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valActiveProcesses.Enabled = this.chkActiveProcesses.Checked;
    }

    private void chkSchedulingC_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valScheduling.Enabled = this.chkSchedulingC.Checked;
    }

    private void chkPriority_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.cbPriority.Enabled = this.chkPriority.Checked;
    }

    private void chkCommittedMemPerJ_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valMemJ.Enabled = this.chkCommittedMemPerJ.Checked;
    }

    private void chkCommittedMemPerP_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valMemP.Enabled = this.chkCommittedMemPerP.Checked;
    }

    private void chkUserModePerP_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valUsertimeP.Enabled = this.chkUserModePerP.Checked;
    }

    private void chkMinMaxWS_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.valMinWS.Enabled = this.chkMinMaxWS.Checked;
        this.valMaxWS.Enabled = this.chkMinMaxWS.Checked;
    }

    private void linkMSDN_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://msdn.microsoft.com/en-us/library/ms684147(VS.85).aspx", this.Handle);
    }

    private void lnkMSDN2_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://msdn.microsoft.com/en-us/library/ms684152(VS.85).aspx", this.Handle);
    }

    private DialogResult setLimits()
    {
        // Set limits to the job
        NativeStructs.JobObjectBasicUiRestrictions struct1 = new NativeStructs.JobObjectBasicUiRestrictions();
        NativeStructs.JobObjectExtendedLimitInformation struct2 = new NativeStructs.JobObjectExtendedLimitInformation();

        // UI limitations
        NativeEnums.JobObjectBasicUiRestrictions flag1;

        if (this.chkUIdesktop.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.Desktop;
        if (this.chkUIDisplaySettings.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.DisplaySettings;
        if (this.chkUIExitW.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.ExitWindows;
        if (this.chkUIglobalAtoms.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.GlobalAtoms;
        if (this.chkUIhandles.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.Handles;
        if (this.chkUIreadCB.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.ReadClipboard;
        if (this.chkUIsystemParam.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.SystemParameters;
        if (this.chkUIwriteCB.Checked == true)
            flag1 = flag1 | NativeEnums.JobObjectBasicUiRestrictions.WriteClipboard;
        struct1.UIRestrictionsClass = flag1;


        // Other limitations
        NativeEnums.JobObjectLimitFlags flag2;

        if (this.chkActiveProcesses.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.ActiveProcess;
            struct2.BasicLimitInformation.ActiveProcessLimit = System.Convert.ToInt32(this.valActiveProcesses.Value);
        }
        if (this.chkAffinity.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.Affinity;
            struct2.BasicLimitInformation.Affinity = new IntPtr(System.Convert.ToInt32(this.valAffinity.Value));
        }
        if (this.chkBreakawayOK.Checked == true)
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.BreakawayOk;
        if (this.chkDieOnUnhandledEx.Checked == true)
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.DieOnUnhandledException;
        if (this.chkCommittedMemPerJ.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.JobMemory;
            struct2.JobMemoryLimit = new IntPtr(System.Convert.ToInt32(1024 * this.valMemJ.Value));
        }
        if (this.chkSilentBAOK.Checked == true)
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.SilentBreakawayOk;
        if (this.chkUserModePerJ.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.JobTime;
            struct2.BasicLimitInformation.PerJobUserTimeLimit = System.Convert.ToInt32(10 * this.valUsertimeJ.Value);
        }
        if (this.chkKillOnJobClose.Checked == true)
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.KillOnJobClose;
        if (this.chkPreserveJobTime.Checked == true)
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.PreserveJobTime;
        if (this.chkPriority.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.PriorityClass;
            struct2.BasicLimitInformation.PriorityClass = Common.Misc.GetPriorityFromString(this.cbPriority.Text);
        }
        if (this.chkCommittedMemPerP.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.ProcessMemory;
            struct2.ProcessMemoryLimit = new IntPtr(System.Convert.ToInt32(1024 * this.valMemP.Value));
        }
        if (this.chkUserModePerJ.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.ProcessTime;
            struct2.BasicLimitInformation.PerProcessUserTimeLimit = System.Convert.ToInt32(1024 * this.valUsertimeP.Value);
        }
        if (this.chkSchedulingC.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.SchedulingClass;
            struct2.BasicLimitInformation.SchedulingClass = System.Convert.ToInt32(this.valScheduling.Value);
        }
        if (this.chkMinMaxWS.Checked == true)
        {
            flag2 = flag2 | NativeEnums.JobObjectLimitFlags.WorkingSet;
            struct2.BasicLimitInformation.MinimumWorkingSetSize = new IntPtr(System.Convert.ToInt32(1024 * this.valMinWS.Value));
            struct2.BasicLimitInformation.MaximumWorkingSetSize = new IntPtr(System.Convert.ToInt32(1024 * this.valMaxWS.Value));
        }
        struct2.BasicLimitInformation.LimitFlags = flag2;

        // Set limit
        if (Misc.WarnDangerousAction("Are you sure you want to set the limits you specified ?", this.Handle) != System.Windows.Forms.DialogResult.Yes)
            return System.Windows.Forms.DialogResult.Cancel;

        cJob job = cJob.GetJobByName(_jobName);
        if (job != null)
            job.SetLimits(struct1, struct2);

        return System.Windows.Forms.DialogResult.OK;
    }
}
