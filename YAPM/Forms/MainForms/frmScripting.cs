using System.Windows.Forms;
using Common;
using System;
using Microsoft.Samples;

public partial class frmScripting
{
    private bool _saved = false;
    private string _scriptFilePath;

    private void frmScripting_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        if (_saved == false && this.rtb.TextLength > 0)
        {
            // Wanna save before exiting ?
            if (Misc.ShowMsg("Exit", "Current script is unsaved", "Are you sure you want to exit without saving the file ?", MessageBoxButtons.YesNo, TaskDialogIcon.Information) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }
        // Save position & size
        Pref.SaveFormPositionAndSize(this, "PSfrmScripting");
    }

    private void frmScripting_Load(object sender, System.EventArgs e)
    {
        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmScripting");
    }

    private void MenuItemOpen_Click(System.Object sender, System.EventArgs e)
    {
        this.cmdOpen_Click(null, null);
    }

    private void MenuItemSave_Click(System.Object sender, System.EventArgs e)
    {
        this.cmdSave_Click(null, null);
    }

    private void MenuItemExit_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void MenuItemVerify_Click(System.Object sender, System.EventArgs e)
    {
        this.cmdCheckScript_Click(null, null);
    }

    private void MenuItemExecute_Click(System.Object sender, System.EventArgs e)
    {
        this.cmdExecute_Click(null, null);
    }


    private void MenuItemSaveAs_Click(System.Object sender, System.EventArgs e)
    {
        // Here we "save as" the file
        string sFile = null;
        {
            var withBlock = this.SaveFileDialog;
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sFile = withBlock.FileName;
                try
                {
                    // Save file
                    System.IO.File.WriteAllText(sFile, this.rtb.Text, System.Text.Encoding.Default);
                    _scriptFilePath = sFile;
                    _saved = true;
                }
                catch (Exception ex)
                {
                    Misc.ShowError(ex, "Could not save the script file");
                }
            }
        }
    }

    private void cmdOpen_Click(System.Object sender, System.EventArgs e)
    {
        // Open a new script
        if (_saved || this.rtb.TextLength == 0)
        {
            // Then we open a new file
            string sFile = null;
            {
                var withBlock = this.OpenFileDialog;
                DialogResult rep = withBlock.ShowDialog();
                if (rep == System.Windows.Forms.DialogResult.OK)
                {
                    sFile = withBlock.FileName;
                    try
                    {
                        rtb.Text = System.IO.File.ReadAllText(sFile, System.Text.Encoding.Default);
                        _saved = true;
                        _scriptFilePath = sFile;
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Could not open the script file");
                    }
                }
            }
        }
        else
            // Have to confirm before opening a new script
            if (Misc.ShowMsg("Open a new script", "", "Do you want to save the current script ?", MessageBoxButtons.YesNo, TaskDialogIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            this.cmdSave_Click(null, null);
    }

    private void cmdSave_Click(System.Object sender, System.EventArgs e)
    {
        // Save current script
        if (_saved == false && _scriptFilePath == null)
            // The save as
            this.MenuItemSaveAs_Click(null, null);
        else
            // Then simply save
            try
            {
                System.IO.File.WriteAllText(_scriptFilePath, this.rtb.Text, System.Text.Encoding.Default);
                _saved = true;
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Could not save the script file");
            }
    }



    private void cmdCheckScript_Click(System.Object sender, System.EventArgs e)
    {
        // Check script
        if (_saved == false || this.rtb.TextLength == 0)
        {
            Misc.ShowMsg("Check if script is valid", "Cannot check script.", "Please save the script first.", MessageBoxButtons.OK, TaskDialogIcon.Information);
            return;
        }
        Scripting.Engine _engine = new Scripting.Engine(_scriptFilePath);
        string _res = "";
        if (_engine.Verify(ref _res))
        {
            Misc.ShowMsg("Check script", "", "Script is OK.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
            return;
        }
        else
        {
            Misc.ShowMsg("Check script", "Script is not valid", "Message : " + _res, MessageBoxButtons.OK, TaskDialogIcon.Error);
            return;
        }
    }

    private void cmdExecute_Click(System.Object sender, System.EventArgs e)
    {
        // Execute script

        // Check it before executing it
        if (_saved == false || this.rtb.TextLength == 0)
        {
            Misc.ShowMsg("Check if script is valid", "Cannot check script.", "Please save the script first.", MessageBoxButtons.OK, TaskDialogIcon.Information);
            return;
        }
        Scripting.Engine _engine = new Scripting.Engine(_scriptFilePath);
        string _res = "";
        if (_engine.Verify(ref _res) == false)
        {
            Misc.ShowMsg("Check script", "Script is not valid", "Message : " + _res, MessageBoxButtons.OK, TaskDialogIcon.Error);
            return;
        }

        // Now we execute it
        _engine.Execute();
    }

    private void rtb_TextChanged(object sender, System.EventArgs e)
    {
        _saved = false;
    }
}
