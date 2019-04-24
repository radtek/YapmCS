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
using System;

public class Graph : System.Windows.Forms.PictureBox
{

    // ========================================
    // Public structure
    // ========================================
    public struct ValueItem
    {
        public long x;
        public long y;
    }

    public event OnZoomEventHandler OnZoom;

    public delegate void OnZoomEventHandler(int leftVal, int rightVal);

    // ========================================
    // Private attributes
    // ========================================
    private int _gridStep = 20;
    private ValueItem[] _values;
    private ValueItem[] _values2;
    private ValueItem[] _values3;
    private System.Drawing.Pen _colorGrid = Pens.DarkGreen;
    private System.Drawing.Pen _colorCPUPercent = Pens.Yellow;
    private System.Drawing.Pen _colorCPUTime = Pens.Yellow;
    private System.Drawing.Pen _colorMemory1 = Pens.Yellow;
    private System.Drawing.Pen _colorMemory3 = Pens.Orange;
    private System.Drawing.Pen _colorMemory2 = Pens.Blue;
    private System.Drawing.Pen _colorPriority = Pens.Yellow;
    private System.Drawing.Pen _colorThreads = Pens.Yellow;
    private System.Drawing.Pen _colorLegend = Pens.Red;
    private int _xMin;
    private int _xMax;
    private DateTime _date;

    private int _xDown;
    private int _yDown;
    private bool _down;
    private int _mouseY;
    private int _mouseX;
    private int _mouseCurrentDate;
    private Rectangle _zoomRect;
    private bool _enableGraph;

    private double xCoef;



    // ========================================
    // Properties
    // ========================================
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(20)]
    public int GridStep
    {
        get
        {
            return _gridStep;
        }
        set
        {
            if (value > 0)
                _gridStep = value;
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "DarkGreen")]
    public Color ColorGrid
    {
        get
        {
            return _colorGrid.Color;
        }
        set
        {
            _colorGrid = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color ColorCPUPercent
    {
        get
        {
            return _colorCPUPercent.Color;
        }
        set
        {
            _colorCPUPercent = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color ColorCPUTime
    {
        get
        {
            return _colorCPUTime.Color;
        }
        set
        {
            _colorCPUTime = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Red")]
    public Color ColorLegend
    {
        get
        {
            return _colorLegend.Color;
        }
        set
        {
            _colorLegend = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color ColorPriority
    {
        get
        {
            return _colorPriority.Color;
        }
        set
        {
            _colorPriority = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color ColorThreads
    {
        get
        {
            return _colorThreads.Color;
        }
        set
        {
            _colorThreads = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color ColorMemory1
    {
        get
        {
            return _colorMemory1.Color;
        }
        set
        {
            _colorMemory1 = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Red")]
    public Color ColorMemory2
    {
        get
        {
            return _colorMemory2.Color;
        }
        set
        {
            _colorMemory2 = new Pen(value);
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Blue")]
    public Color ColorMemory3
    {
        get
        {
            return _colorMemory3.Color;
        }
        set
        {
            _colorMemory3 = new Pen(value);
        }
    }
    public int ViewMax
    {
        get
        {
            return _xMax;
        }
        set
        {
            _xMax = value;
        }
    }
    public int ViewMin
    {
        get
        {
            return _xMin;
        }
        set
        {
            _xMin = value;
        }
    }
    public DateTime dDate
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }
    public bool EnableGraph
    {
        get
        {
            return _enableGraph;
        }
        set
        {
            _enableGraph = value;
        }
    }


    // ========================================
    // Overriden subs
    // ========================================
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        if (_enableGraph)
        {
            DrawGrid(e.Graphics);
            DrawValues(e.Graphics);
            if (_values2 != null)
                DrawValues2(e.Graphics);
            if (_values3 != null)
                DrawValues3(e.Graphics);
            DrawLegend(e.Graphics);
        }
    }
    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            _xDown = e.X;
            _yDown = e.Y;
            _down = true;
        }
    }
    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _mouseX = e.X;
        _mouseY = e.Y;
        if (_down == true)
        {
            this.Refresh();
            // Draw a zoom rectangle
            {
                var withBlock = _zoomRect;
                withBlock.X = Math.Min(_xDown, e.X);
                withBlock.Y = Math.Min(_yDown, e.Y);
                withBlock.Width = Math.Abs(_xDown - e.X);
                withBlock.Height = Math.Abs(_yDown - e.Y);
            }
            Graphics g = this.CreateGraphics();
            {
                var withBlock1 = g;
                withBlock1.DrawRectangle(Pens.WhiteSmoke, _zoomRect);
                withBlock1.Dispose();
            }
        }

        // Get time (milliseconds) of current x point
        if (_values != null)
        {
            int h = System.Convert.ToInt32(_xMin + e.X / (double)this.Width * (_values.Length - _xMin));
            h = Math.Min(_values.Length - 1, h);
            _mouseCurrentDate = 10000 * System.Convert.ToInt32(_values[h].x);
        }
    }
    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        // We have to zoom
        if (_down & e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            _down = false;
            this.Refresh();        // Delete rectangle

            if (_values == null)
            {
                _down = false;
                return;
            }

            int ul = System.Convert.ToInt32(_xMin + Math.Min(e.X, _xDown) / (double)this.Width * (_values.Length - _xMin));
            int ur = System.Convert.ToInt32(_xMin + Math.Max(e.X, _xDown) / (double)this.Width * (_values.Length - _xMin));
            ur = Math.Min(ur, _values.Length - 1);
            int l = 0;
            int r = 0;

            // Find times from ul and ur (positions in array)
            l = System.Convert.ToInt32(_values[ul].x);
            r = System.Convert.ToInt32(_values[ur].x);

            OnZoom?.Invoke(l, r);
        }
    }

    // ========================================
    // Private methods
    // ========================================

    // Draw grid
    private void DrawGrid(Graphics g)
    {
        int i = this.Width;
        int j = this.Height;
        int stp = 20;

        int x, y;

        // Vertical lines
        for (x = i; x >= 0; x += -stp)
            g.DrawLine(_colorGrid, x, 0, x, j);

        // Horizontal lines
        for (y = j; y >= 0; y += -stp)
            g.DrawLine(_colorGrid, 0, y, i, y);
    }

    // Draw legend
    private void DrawLegend(Graphics g)
    {
    }

    // Draw values
    private void DrawValues(Graphics g)
    {
        int x;

        if (_values == null)
            return;

        // Get the max (height)
        long yMax = 0;
        var loopTo = (_values.Length - 1);
        for (x = 0; x <= loopTo; x++)
        {
            if (_values[x].y > yMax)
                yMax = _values[x].y;
        }

        // If yMax = 0 Then Exit Sub
        yMax += 1;

        double yCoef = (this.Height - 25) / (double)yMax;
        xCoef = this.Width / (double)(_xMax - _xMin);

        int x1 = 0;
        int x2 = 0;
        double y1 = yMax;
        double y2 = y1;
        int v;

        int xx1 = 0;
        int xx2 = 0;
        int yy1 = 0;
        int yy2 = 0;
        var loopTo1 = _xMax;
        for (x = _xMin + 1; x <= loopTo1; x++)
        {
            // v start at 0
            v = x - _xMin;

            if ((x1 == 0 & y1 == yMax))
            {
                x1 = 0;
                y1 = _values[x - 1].y;
            }
            else
            {
                x1 = x2;
                y1 = y2;
            }
            x2 = v;
            y2 = _values[x].y;

            xx1 = System.Convert.ToInt32(x1 * xCoef);
            xx2 = System.Convert.ToInt32(x2 * xCoef);
            yy1 = System.Convert.ToInt32(this.Height - y1 * yCoef) - 5;
            yy2 = System.Convert.ToInt32(this.Height - y2 * yCoef) - 5;
            g.DrawLine(_colorMemory1, xx1, yy1, xx2, yy2);
        }

        // Draw zoom rectangle
        if (_down == true)
            g.DrawRectangle(Pens.WhiteSmoke, _zoomRect);

        // Calcule current value
        long _mouseCurrentValue = 0;
        int h;
        if (_values != null)
        {
            h = System.Convert.ToInt32(_xMin + _mouseX / (double)this.Width * (_xMax - _xMin));
            h = Math.Min(_values.Length - 1, h);
            _mouseCurrentValue = _values[h].y;
        }

        // Draw current date
        DateTime d = new DateTime(_date.Ticks + _mouseCurrentDate);
        g.DrawString(d.ToLongDateString() + " -- " + d.ToLongTimeString(), Program._frmMain.Font, Brushes.Beige, 0, 0);
        g.DrawString("Value : " + _mouseCurrentValue.ToString(), Program._frmMain.Font, Brushes.Beige, 200, 0);
    }

    private void DrawValues2(Graphics g)
    {
        int x;

        // Get the max (height)
        long yMax = 0;
        var loopTo = (_values2.Length - 1);
        for (x = 0; x <= loopTo; x++)
        {
            if (_values2[x].y > yMax)
                yMax = _values2[x].y;
        }

        if (yMax == 0)
            return;
        yMax += 1;

        double yCoef = (this.Height - 25) / (double)yMax;

        int x1 = 0;
        int x2 = 0;
        double y1 = yMax;
        double y2 = y1;
        int v;

        int xx1 = 0;
        int xx2 = 0;
        int yy1 = 0;
        int yy2 = 0;
        var loopTo1 = _xMax;
        for (x = _xMin + 1; x <= loopTo1; x++)
        {
            // v start at 0
            v = x - _xMin;

            if ((x1 == 0 & y1 == yMax))
            {
                x1 = 0;
                y1 = _values2[x - 1].y;
            }
            else
            {
                x1 = x2;
                y1 = y2;
            }
            x2 = v;
            y2 = _values2[x].y;

            xx1 = System.Convert.ToInt32(x1 * xCoef);
            xx2 = System.Convert.ToInt32(x2 * xCoef);
            yy1 = System.Convert.ToInt32(this.Height - y1 * yCoef) + 10;
            yy2 = System.Convert.ToInt32(this.Height - y2 * yCoef) + 10;
            g.DrawLine(_colorMemory2, xx1, yy1, xx2, yy2);
        }
    }

    private void DrawValues3(Graphics g)
    {
        int x;

        // Get the max (height)
        long yMax = 0;
        var loopTo = (_values3.Length - 1);
        for (x = 0; x <= loopTo; x++)
        {
            if (_values3[x].y > yMax)
                yMax = _values3[x].y;
        }

        if (yMax == 0)
            return;
        yMax += 1;

        double yCoef = (this.Height - 25) / (double)yMax;

        int x1 = 0;
        int x2 = 0;
        double y1 = yMax;
        double y2 = y1;
        int v;

        int xx1 = 0;
        int xx2 = 0;
        int yy1 = 0;
        int yy2 = 0;
        var loopTo1 = _xMax;
        for (x = _xMin + 1; x <= loopTo1; x++)
        {
            // v start at 0
            v = x - _xMin;

            if ((x1 == 0 & y1 == yMax))
            {
                x1 = 0;
                y1 = _values2[x - 1].y;
            }
            else
            {
                x1 = x2;
                y1 = y2;
            }
            x2 = v;
            y2 = _values3[x].y;

            xx1 = System.Convert.ToInt32(x1 * xCoef);
            xx2 = System.Convert.ToInt32(x2 * xCoef);
            yy1 = System.Convert.ToInt32(this.Height - y1 * yCoef) + 10;
            yy2 = System.Convert.ToInt32(this.Height - y2 * yCoef) + 10;
            g.DrawLine(_colorMemory3, xx1, yy1, xx2, yy2);
        }
    }


    // ========================================
    // Public functions
    // ========================================

    public void SetValues(ValueItem[] values)
    {
        _values = values;
    }
    public void SetValues2(ValueItem[] values)
    {
        _values2 = values;
    }
    public void SetValues3(ValueItem[] values)
    {
        _values3 = values;
    }
}
