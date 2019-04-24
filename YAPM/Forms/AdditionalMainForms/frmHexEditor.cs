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

public partial class frmHexEditor
{
    private MemoryHexEditor __hex;

    public MemoryHexEditor _hex
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __hex;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__hex != null)
            {
            }

            __hex = value;
            if (__hex != null)
            {
            }
        }
    }

    private int _pid;
    private MemoryHexEditor.MemoryRegion _region;

    public void SetPidAndRegion(int pid, MemoryHexEditor.MemoryRegion region)
    {
        _pid = pid;
        _region = region;
        _hex.NewProc(_region, _pid);
    }

    private void frmHexEditor_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);

        {
            var withBlock = _hex;
            withBlock.BackColor = Color.White;
            withBlock.Location = new Point(0, 0);
            withBlock.Size = new Size(this.Width, this.Height);
            withBlock.Dock = DockStyle.Left;
        }

        this.Controls.Add(_hex);
    }
}
