using System.Windows.Forms;
using Common;
using Microsoft.Samples;

public partial class frmCreateService
{
    private void frmAddToJob_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.OK_Button, "Create service");
        Common.Misc.SetToolTip(this.Cancel_Button, "Cancel");
        Common.Misc.SetToolTip(this.txtArgs, "Arguments used in command line");
        Common.Misc.SetToolTip(this.txtDisplayName, "Service display name");
        Common.Misc.SetToolTip(this.txtMachine, "Machine name");
        Common.Misc.SetToolTip(this.txtPath, "Path of the executable file");
        Common.Misc.SetToolTip(this.txtServerPassword, "Password");
        Common.Misc.SetToolTip(this.txtServiceName, "Service name");
        Common.Misc.SetToolTip(this.txtUser, "User name");
        Common.Misc.SetToolTip(this.cbErrControl, "Error control");
        Common.Misc.SetToolTip(this.cbServType, "Service type");
        Common.Misc.SetToolTip(this.cbStartType, "Service start type");
        Common.Misc.SetToolTip(this.cmdBrowse, "Browse for executable file");
        Common.Misc.SetToolTip(this.optLocal, "Create service on the local machine");
        Common.Misc.SetToolTip(this.optRemote, "Create service on a remote machine");

        Common.Misc.CloseWithEchapKey(ref this);

        this.cbErrControl.SelectedIndex = 1;
        this.cbServType.SelectedIndex = 4;
        this.cbStartType.SelectedIndex = 3;
    }

    private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void OK_Button_Click(System.Object sender, System.EventArgs e)
    {
        Native.Api.Structs.ServiceCreationParams @params = new Native.Api.Structs.ServiceCreationParams();

        this.OK_Button.Enabled = false;
        this.Cancel_Button.Enabled = false;

        // Create service
        {
            var withBlock = @params;
            withBlock.Arguments = this.txtArgs.Text;
            withBlock.DisplayName = this.txtDisplayName.Text;
            withBlock.ErrorControl = Native.Functions.Service.GetServiceErrorControlFromString(this.cbErrControl.Text);
            withBlock.FilePath = this.txtPath.Text;
            withBlock.ServiceName = this.txtServiceName.Text;
            withBlock.StartType = Native.Functions.Service.GetServiceStartTypeFromString(this.cbStartType.Text);
            withBlock.Type = Native.Functions.Service.GetServiceTypeFromString(this.cbServType.Text);
            if (this.optRemote.Checked)
            {
                withBlock.RegMachine = this.txtMachine.Text;
                withBlock.RegPassword = this.txtServerPassword.SecureText;
                withBlock.RegUser = this.txtUser.Text;
            }
        }
        if (Native.Objects.Service.CreateService(@params))
            this.Close();
        else
            Misc.ShowMsg("Create service", "Failed to create the service.", "Informations : " + Native.Api.Win32.GetLastError(), MessageBoxButtons.OK, TaskDialogIcon.Error);

        this.OK_Button.Enabled = true;
        this.Cancel_Button.Enabled = true;
    }

    private void optLocal_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.txtUser.Enabled = optRemote.Checked;
        this.txtMachine.Enabled = optRemote.Checked;
        this.txtServerPassword.Enabled = optRemote.Checked;
        this.lblMachine.Enabled = optRemote.Checked;
        this.lblPwd.Enabled = optRemote.Checked;
        this.lblUser.Enabled = optRemote.Checked;
    }

    private void optRemote_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        optLocal_CheckedChanged(null, null);
    }

    private void cmdBrowse_Click(System.Object sender, System.EventArgs e)
    {
        // Open a file
        {
            var withBlock = this.openDial;
            withBlock.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            withBlock.Title = "Select service executable";
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtPath.Text = withBlock.FileName;
        }
    }
}

