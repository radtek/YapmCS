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
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public partial class frmCheckSignatures
{
    private void frmHiddenProcesses_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.cmdCheck, "Check now if processes and modules are trusted");

        Native.Functions.Misc.SetTheme(this.lvResult.Handle);
        Native.Functions.Misc.SetTheme(this.lvProcess.Handle);
        cConnection theConnection = new cConnection();
        theConnection.ConnectionType = cConnection.TypeOfConnection.LocalConnection;

        this.lvProcess.ClearItems();
        this.lvProcess.ConnectionObj = theConnection;

        try
        {
            theConnection.Connect();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }

        this.Timer.Enabled = true;
    }

    private void lvProcess_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        foreach (cProcess it in this.lvProcess.GetSelectedItems())
        {
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref it);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
        }
    }

    private void lvProcess_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.TheContextMenu.Show(this.lvProcess, e.Location);
    }

    private void MenuItemShow_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (System.IO.File.Exists(cp.Infos.Path))
                cFile.ShowFileProperty(cp.Infos.Path, this.Handle);
        }
    }

    private void MenuItemClose_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            if (cp.Infos.Path != Program.NO_INFO_RETRIEVED)
                cFile.OpenDirectory(cp.Infos.Path);
        }
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        if (this.lvProcess.SelectedItems.Count > 0)
        {
            cProcess cp = this.lvProcess.GetSelectedItem();
            string s = cp.Infos.Path;
            if (System.IO.File.Exists(s))
                Misc.DisplayDetailsFile(s);
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        foreach (cProcess cp in this.lvProcess.GetSelectedItems())
        {
            Application.DoEvents();
            Misc.SearchInternet(cp.Infos.Name, this.Handle);
        }
    }

    private void cmdCheck_Click(System.Object sender, System.EventArgs e)
    {
        // Check if files are trusted

        // Path <-> trust result
        Dictionary<string, Native.Api.NativeEnums.WinVerifyTrustResult> _dicoTrusted = new Dictionary<string, Native.Api.NativeEnums.WinVerifyTrustResult>();

        this.pgb.Minimum = 0;
        this.pgb.Value = 0;
        this.pgb.Maximum = this.lvProcess.CheckedIndices.Count;

        foreach (cProcess proc in this.lvProcess.GetCheckedItems())
        {

            // Get list of modules
            Dictionary<string, moduleInfos> _modules = asyncCallbackModuleEnumerate.SharedLocalSyncEnumerate(new asyncCallbackModuleEnumerate.poolObj(proc.Infos.ProcessId, 0));

            // For each module
            if (_modules != null)
            {
                foreach (moduleInfos file in _modules.Values)
                {
                    // If not already verified, check it
                    if (_dicoTrusted.ContainsKey(file.Path) == false)
                        _dicoTrusted[file.Path] = Security.WinTrust.WinTrust.VerifyEmbeddedSignature2(file.Path);
                }
            }

            this.pgb.Value += 1;
        }

        // Now count items and add it to result lv
        int _failed = 0;
        int _success = 0;
        int _unknown = 0;

        this.lvResult.BeginUpdate();
        this.lvResult.Items.Clear();
        foreach (System.Collections.Generic.KeyValuePair<string, Native.Api.NativeEnums.WinVerifyTrustResult> pair in _dicoTrusted)
        {
            ListViewItem it = this.lvResult.Items.Add(pair.Key);
            it.SubItems.Add(pair.Value.ToString());
            switch (pair.Value)
            {
                case Native.Api.NativeEnums.WinVerifyTrustResult.Critical | Native.Api.NativeEnums.WinVerifyTrustResult.Expired | Native.Api.NativeEnums.WinVerifyTrustResult.ExplicitDistrust | Native.Api.NativeEnums.WinVerifyTrustResult.Malformed | Native.Api.NativeEnums.WinVerifyTrustResult.RevocationFailure | Native.Api.NativeEnums.WinVerifyTrustResult.Revoked | Native.Api.NativeEnums.WinVerifyTrustResult.SubjectNotTrusted | Native.Api.NativeEnums.WinVerifyTrustResult.UntrustedCA | Native.Api.NativeEnums.WinVerifyTrustResult.UntrustedRoot | Native.Api.NativeEnums.WinVerifyTrustResult.UntrustedTestRoot | Native.Api.NativeEnums.WinVerifyTrustResult.ValidityPeriodNesting:
                    {
                        _failed += 1;
                        it.ForeColor = Color.Red;
                        break;
                    }

                case Native.Api.NativeEnums.WinVerifyTrustResult.Trusted:
                    {
                        _success += 1;
                        it.ForeColor = Color.Green;
                        break;
                    }

                default:
                    {
                        _unknown += 1;
                        break;
                    }
            }
        }
        this.lblFailed.Text = "Not trusted : " + _failed.ToString();
        this.lblOK.Text = "Trusted : " + _success.ToString();
        this.lblUnknown.Text = "Unknown : " + _unknown.ToString();
        this.lvResult.EndUpdate();
    }

    private void MenuItemCAll_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lvProcess.Items)
            it.Checked = true;
    }

    private void MenuItemCNone_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lvProcess.Items)
            it.Checked = false;
    }

    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        // Refresh list of processes
        if (this.lvProcess.Items.Count == 0)
            this.lvProcess.UpdateItemsAllInfos();
    }
}

