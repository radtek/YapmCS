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

public partial class frmDownload
{
    private cDownload __download;

    private cDownload _download
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __download;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__download != null)
            {
                __download.CompleteCallback -= _download_CompleteCallback;
                __download.ProgressCallback -= _download_ProgressCallback;
            }

            __download = value;
            if (__download != null)
            {
                __download.CompleteCallback += _download_CompleteCallback;
                __download.ProgressCallback += _download_ProgressCallback;
            }
        }
    }

    public cDownload DownloadObject
    {
        get
        {
            return _download;
        }
        set
        {
            _download = value;
        }
    }

    private void _download_CompleteCallback(System.ComponentModel.AsyncCompletedEventArgs e)
    {
        Misc.ShowMsg("Download", null, "Download complete.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
        this.Cancel_Button.Text = "OK";
        cFile.OpenDirectory(this._download.Destination);
    }

    private void _download_ProgressCallback(object sender, System.Net.DownloadProgressChangedEventArgs e)
    {
        try
        {
            string s = "Downloaded " + System.Convert.ToString(Math.Round(e.BytesReceived / (double)1024, 3)) + "KB out of " + System.Convert.ToString(Math.Round(e.TotalBytesToReceive / (double)1024, 3)) + "KB";
            this.Text = "Downloading last update....  " + System.Convert.ToString(e.ProgressPercentage) + " %";
            {
                var withBlock = pgb;
                withBlock.Maximum = 100;
                withBlock.Minimum = 0;
                withBlock.Value = e.ProgressPercentage;
            }
            this.lblProgress.Text = s;
            Application.DoEvents();
        }

        // If e.ProgressPercentage = 100 Then
        // Call _download_CompleteCallback(Nothing)
        // End If

        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    public void StartDownload(string dest)
    {
        this.Text = "Downloading in preparation...";
        this.pgb.Value = 0;
        this.txtPath.Text = dest;
        this.pgb.Maximum = 1;
        this.Text = "Waiting for download...";
        Application.DoEvents();
        _download.StartDownload();
    }

    private void Cancel_Button_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            _download.Cancel();
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
        this.Close();
    }

    private void frmDownload_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.SetToolTip(this.Cancel_Button, "Cancel download");
    }
}

