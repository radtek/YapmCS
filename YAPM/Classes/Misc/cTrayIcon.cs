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
using Common;
using System;

public class cTrayIcon
{
    private byte[,] _values;
    private Pen[] _counterPensLine;
    private Pen[] _counterPensFill;
    private int _countersCount;
    private Rectangle _blackRect = new Rectangle(0, 0, 16, 16);

    private Bitmap bm;
    private Graphics g;

    public cTrayIcon(byte countersCount) : base()
    {
        bm = new Bitmap(16, 16);
        g = Graphics.FromImage(bm);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        countersCount = System.Convert.ToByte(countersCount - 1);

        _countersCount = countersCount;
        _values = new byte[16, countersCount + 1];
        _counterPensLine = new Pen[countersCount + 1];
        _counterPensFill = new Pen[countersCount + 1];

        for (int x = 0; x <= 15; x++)
        {
            var loopTo = countersCount;
            for (int y = 0; y <= loopTo; y++)
                _values[x, y] = 16;
        }
    }

    // Add a counter
    public void SetCounter(byte counter, Color lineColor, Color fillColor)
    {
        _counterPensLine[counter - 1] = new Pen(lineColor);
        _counterPensFill[counter - 1] = new Pen(fillColor);
    }

    // Add a value to list
    public void AddValue(byte counter, double percentage)
    {

        // Move values in _values array
        for (int x = 0; x <= 14; x++)
            _values[x, counter - 1] = _values[x + 1, counter - 1];

        _values[15, counter - 1] = System.Convert.ToByte(16 - percentage * 16);

        // Refresh values
        Refresh();
    }

    private void Refresh()
    {
        Icon oIcon = null;

        try
        {
            // Create bitmap and graphics
            g.FillRectangle(Brushes.Black, _blackRect);

            // Draw all counters values
            for (int y = _countersCount; y >= 0; y += -1)
            {
                for (int x = 14; x >= 0; x += -1)
                {
                    g.DrawLine(_counterPensFill[y], x, _values[x, y], x, 16);
                    g.DrawLine(_counterPensLine[y], x, _values[x, y], x + 1, _values[x + 1, y]);
                }
            }

            // Get an icon
            oIcon = Icon.FromHandle(bm.GetHicon());
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }

        // MUST destroy previous icon to avoid memory exception after long time...
        if (Program._frmMain.Tray.Icon != null)
            Native.Api.NativeFunctions.DestroyIcon(Program._frmMain.Tray.Icon.Handle);

        // Set icon
        Program._frmMain.Tray.Icon = oIcon;
    }
}

