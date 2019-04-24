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

public partial class HFileProp : HXXXProp
{
    public HFileProp(cHandle handle) : base(handle)
    {
        InitializeComponent();
    }

    // Refresh infos
    public override void RefreshInfos()
    {
        bool bFileExists = System.IO.File.Exists(this.TheHandle.Infos.Name);
        bool bDirExists = System.IO.Directory.Exists(this.TheHandle.Infos.Name);
        bool _local = (cHandle.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);

        bFileExists = bFileExists & _local;
        bDirExists = bDirExists & _local;

        this.cmdFileDetails.Enabled = bFileExists;
        this.cmdOpenDirectory.Enabled = bDirExists | bFileExists;
        this.cmdOpen.Enabled = this.cmdOpenDirectory.Enabled;

        if (_local)
        {
            if (bFileExists)
            {
                this.lblFileExists.ForeColor = Color.DarkGreen;
                this.lblFileExists.Text = "File exists";
            }
            else if (bDirExists)
            {
                this.lblFileExists.ForeColor = Color.DarkGreen;
                this.lblFileExists.Text = "Directory exists";
            }
            else
            {
                this.lblFileExists.ForeColor = Color.DarkRed;
                this.lblFileExists.Text = "Unknown file";
            }
        }
        else
        {
            this.lblFileExists.ForeColor = Color.Black;
            this.lblFileExists.Text = "Remote file";
        }
    }

    private void cmdOpen_Click(object sender, System.EventArgs e)
    {
        cFile.ShowFileProperty(this.TheHandle.Infos.Name, this.Handle);
    }

    private void cmdOpenDirectory_Click(object sender, System.EventArgs e)
    {
        if (System.IO.Directory.Exists(this.TheHandle.Infos.Name))
            cFile.OpenADirectory(this.TheHandle.Infos.Name);
        else
            cFile.OpenDirectory(this.TheHandle.Infos.Name);
    }

    private void HFileProp_Load(System.Object sender, System.EventArgs e)
    {
        // Common.Misc.SetToolTip(Me.cmdDetails, "Details about the object")
        Common.Misc.SetToolTip(this.cmdOpen, "Open properties of item");
        Common.Misc.SetToolTip(this.cmdOpenDirectory, "Open directory");
    }

    private void cmdFileDetails_Click(System.Object sender, System.EventArgs e)
    {
        Common.Misc.DisplayDetailsFile(this.TheHandle.Infos.Name);
    }
}

