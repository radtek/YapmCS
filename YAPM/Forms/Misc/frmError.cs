using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;
using Microsoft.Samples;
using System.Net;

public partial class frmError
{
    private Exception _theExeption;
    private bool _canClose = false;
    private const string NEW_ARTIFACT_URL = "http://sourceforge.net/tracker/?atid=1126635&group_id=244697&func=add";

    public frmError(Exception e)
    {
        InitializeComponent();

        _theExeption = e;

        // Create a log
        string s = "";
        s += "System informations : ";
        s += Constants.vbNewLine + Constants.vbTab + "Name : " + My.MyProject.Computer.Info.OSFullName;
        s += Constants.vbNewLine + Constants.vbTab + "Platform : " + My.MyProject.Computer.Info.OSPlatform;
        s += Constants.vbNewLine + Constants.vbTab + "Version : " + My.MyProject.Computer.Info.OSVersion.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "UICulture : " + My.MyProject.Computer.Info.InstalledUICulture.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "Processor count : " + Program.PROCESSOR_COUNT.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "Physical memory : " + Misc.GetFormatedSize(My.MyProject.Computer.Info.AvailablePhysicalMemory) + "/" + Misc.GetFormatedSize(My.MyProject.Computer.Info.TotalPhysicalMemory);
        s += Constants.vbNewLine + Constants.vbTab + "Virtual memory : " + Misc.GetFormatedSize(My.MyProject.Computer.Info.AvailableVirtualMemory) + "/" + Misc.GetFormatedSize(My.MyProject.Computer.Info.TotalVirtualMemory);
        s += Constants.vbNewLine + Constants.vbTab + "Screen : " + My.MyProject.Computer.Screen.Bounds.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "IntPtr.Size : " + IntPtr.Size.ToString();
        s += Constants.vbNewLine + Constants.vbNewLine;
        s += "User informations : ";
        s += Constants.vbNewLine + Constants.vbTab + "Admin : " + Program.IsAdministrator.ToString();
        s += Constants.vbNewLine + Constants.vbNewLine;
        s += "Application informations : ";
        s += Constants.vbNewLine + Constants.vbTab + "Path : " + My.MyProject.Application.Info.DirectoryPath;
        s += Constants.vbNewLine + Constants.vbTab + "Version : " + My.MyProject.Application.Info.Version.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "WorkingSetSize : " + My.MyProject.Application.Info.WorkingSet.ToString();
        s += Constants.vbNewLine + Constants.vbNewLine;
        s += "Error informations : ";
        s += Constants.vbNewLine + Constants.vbTab + "Message : " + e.Message;
        s += Constants.vbNewLine + Constants.vbTab + "Source : " + e.Source;
        s += Constants.vbNewLine + Constants.vbTab + "StackTrace : " + e.StackTrace;
        s += Constants.vbNewLine + Constants.vbTab + "Target : " + e.TargetSite.ToString();
        s += Constants.vbNewLine + Constants.vbNewLine;
        s += "Other informations : ";
        s += Constants.vbNewLine + Constants.vbTab + "Connection : " + Program.Connection.ConnectionType.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "Connected : " + Program.Connection.IsConnected.ToString();
        s += Constants.vbNewLine + Constants.vbTab + "Elapsed time : " + Program.ElapsedTime.ToString();
        s += Constants.vbNewLine + Constants.vbNewLine;
        s += "Modules : ";
        foreach (ProcessModule mdl in System.Diagnostics.Process.GetCurrentProcess().Modules)
        {
            s += Constants.vbNewLine + Constants.vbTab + mdl.ModuleName;
            s += Constants.vbNewLine + Constants.vbTab + Constants.vbTab + "Path : " + mdl.FileName;
            if (mdl.FileVersionInfo != null)
                s += Constants.vbNewLine + Constants.vbTab + Constants.vbTab + "Version : " + mdl.FileVersionInfo.FileVersion;
        }

        this.txtReport.Text = s;
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        Native.Api.NativeFunctions.ExitProcess(0);
    }

    private void frmError_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        e.Cancel = !(_canClose);
    }

    private void Button1_Click_1(System.Object sender, System.EventArgs e)
    {
        _canClose = true;
        this.Close();
    }

    private void frmError_Load(System.Object sender, System.EventArgs e)
    {
        Misc.SetToolTip(this.cmdQuit, "Terminate YAPM immediatly");
        Misc.SetToolTip(this.cmdContinue, "Cloe this window and try to continue the execution of YAPM. It's probably gonna crash");
        Misc.SetToolTip(this.cmdIgnore, "Hide this window and ignore the error");
        Misc.SetToolTip(this.cmdSend, "Send the bug report to sourceforge.net. Of course NO PERSONAL INFORMATION will be send.");

        this.txtCustomMessage.Focus();
    }

    private void cmdIgnore_Click(System.Object sender, System.EventArgs e)
    {
        this.Hide();
    }

    private void cmdSend_Click(System.Object sender, System.EventArgs e)
    {
        BugReporter bgRep = new BugReporter();
        this.Enabled = false;
        Application.DoEvents();

        // Set the handler (used when download completed)
        bgRep.DownloadStringCompleted += impDownloadStringCompleted;

        // Create an unique string to prevent some identical error messages to
        // be added with identical summaries on sourceforge.net
        string uId = DateTime.Now.ToFileTimeUtc().ToString();

        // Set summary and description
        {
            var withBlock = bgRep;
            withBlock.ValueDetails = this.txtReport.Text + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine + "CUSTOM MESSAGE : " + Constants.vbNewLine + this.txtCustomMessage.Text;
            withBlock.ValueSummary = _theExeption.Message + " (" + uId + ")";
        }

        if (bgRep.GoAsync() == false)
            this.Enabled = true;
    }

    private void impDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if (this.Enabled)
            return;

        if (e.Error != null)
            Misc.ShowMsg("Could not send bug report", "An error occured when sending bug report.", e.Error.ToString(), MessageBoxButtons.OK, TaskDialogIcon.Error);
        else
            Misc.ShowMsg("Successfully sent the bug report", "Successfully sent the bug report.", "", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);

        Async.Form.ChangeEnabled(this, true);
    }
}

