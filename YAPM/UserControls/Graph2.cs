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
using System.Windows.Forms.PictureBox;

public class Graph2 : System.Windows.Forms.PictureBox
{

    // ========================================
    // Private attributes
    // ========================================
    private int _gridStep = 13;
    private double[] _values;
    private double[] _values2;
    private System.Drawing.Pen _colorGrid = Pens.DarkGreen;
    private System.Drawing.Pen _color = Pens.Yellow;
    private System.Drawing.Pen _color2 = Pens.Yellow;
    private System.Drawing.Pen _color3 = Pens.Red;
    private System.Drawing.Pen _textColor = Pens.Lime;
    private bool _enableGraph;
    private int _mouseY;
    private int _mouseX;
    private int _xMax = 50;
    private int _xMin = 0;
    private int nCount = 0;
    private bool _fixedH = false;
    private bool _secondV = false;
    private string _text;
    private bool _showToolTip;
    private Point _mouseLoc;

    private int numberOfValuesDisplayed;
    private int numberOfValuesHidden;
    private System.Windows.Forms.ToolTip _toolTip;

    private System.Windows.Forms.ToolTip toolTip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _toolTip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_toolTip != null)
            {
            }

            _toolTip = value;
            if (_toolTip != null)
            {
            }
        }
    }

    private System.ComponentModel.IContainer components;
    private double _yMaxValue = 0;

    private System.Drawing.Pen _colorGridEn = _colorGrid;
    private System.Drawing.Pen _colorEn = _color;
    private System.Drawing.Pen _color2En = _color2;
    private System.Drawing.Pen _color3En = _color3;
    private System.Drawing.Pen _textColorEn = _textColor;

    // ========================================
    // Properties
    // ========================================
    public new bool Enabled
    {
        get
        {
            return base.Enabled;
        }
        set
        {
            base.Enabled = value;
            if (value == false)
            {
                _colorGridEn = _colorGrid;
                _colorEn = _color;
                _color2En = _color2;
                _color3En = _color3;
                _color = Pens.Gray;
                _color2 = Pens.Gray;
                _color3 = Pens.Gray;
                _colorGrid = Pens.DarkGray;
                _textColor = Pens.DarkGray;
                this.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                _color = _colorEn;
                _color2 = _color2En;
                _color3 = _color3En;
                _textColor = _textColorEn;
                _colorGrid = _colorGridEn;
                this.BackColor = System.Drawing.Color.Black;
            }
        }
    }
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
            _colorGridEn = _colorGrid;
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Green")]
    public Color TextColor
    {
        get
        {
            return _textColor.Color;
        }
        set
        {
            _textColor = new Pen(value);
            _textColorEn = _textColor;
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color Color
    {
        get
        {
            return _color.Color;
        }
        set
        {
            _color = new Pen(value);
            _colorEn = _color;
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Yellow")]
    public Color Color2
    {
        get
        {
            return _color2.Color;
        }
        set
        {
            _color2 = new Pen(value);
            _color2En = _color2;
        }
    }
    [System.ComponentModel.Category("Configuration")]
    [System.ComponentModel.Description("value")]
    [System.ComponentModel.Browsable(true)]
    [System.ComponentModel.DefaultValue(typeof(Color), "Red")]
    public Color Color3
    {
        get
        {
            return _color3.Color;
        }
        set
        {
            _color3 = new Pen(value);
            _color3En = _color3;
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
    public bool Fixedheight
    {
        get
        {
            return _fixedH;
        }
        set
        {
            _fixedH = value;
        }
    }
    public bool ShowSecondGraph
    {
        get
        {
            return _secondV;
        }
        set
        {
            _secondV = value;
        }
    }
    public string TopText
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }


    // ========================================
    // Overriden subs
    // ========================================
    public Graph2()
    {
        _values = new double[201];
        _values2 = new double[201];
        this.toolTip = new ToolTip();
    }
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        DrawValuesDown(e.Graphics);
        DrawGrid(e.Graphics);
        if (_enableGraph)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                DrawValues(e.Graphics);
                if (_secondV)
                    DrawValues2(e.Graphics);
                DrawLegend(e.Graphics);
                if (_showToolTip)
                    ShowToolTip();
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }
    }
    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _mouseX = e.X;
        _mouseY = e.Y;

        // ' Get time (milliseconds) of current x point
        // If _values IsNot Nothing Then
        // Dim h As Integer = CInt(_xMin + e.X / Me.Width * (_values.Length - _xMin))
        // h = Math.Min(_values.Length - 1, h)
        // _mouseCurrentDate = 10000 * CInt(_values(h))
        // End If
        _mouseLoc = e.Location;
        ShowToolTip();
    }
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        _xMin = Math.Max(_xMax - this.Width, 0);
        numberOfValuesDisplayed = this.Width / 2;
        numberOfValuesHidden = System.Convert.ToInt32(nCount - numberOfValuesDisplayed);
    }
    protected override void OnMouseLeave(System.EventArgs e)
    {
        base.OnMouseLeave(e);
        _showToolTip = false;
        this.toolTip.Hide(this);
    }
    protected override void OnMouseEnter(System.EventArgs e)
    {
        base.OnMouseEnter(e);
        _showToolTip = true;
        ShowToolTip();
    }


    // ========================================
    // Private methods
    // ========================================

    // Show tooltip
    private void ShowToolTip()
    {
    }

    // Draw grid
    private void DrawGrid(Graphics g)
    {
        int i = this.Width;
        int j = this.Height;
        int stp = _gridStep;

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
        // Background rectangle
        if (this.Enabled)
        {
            SizeF sz = g.MeasureString(_text, this.Font);
            float textW = sz.Width + 4;
            float textH = sz.Height + 4;
            g.FillRectangle(new SolidBrush(System.Drawing.Color.Black), new Rectangle(0, 0, System.Convert.ToInt32(textW), System.Convert.ToInt32(textH)));
            // Draw the text
            TextRenderer.DrawText(g, _text, this.Font, new Point(2, 2), _textColor.Color);
        }
    }

    // Draw values (second curve)
    private void DrawValues2(Graphics g)
    {

        // Now calculate the Y coeff (height in pxl = VALUE(%) * _yCoeff
        double _yCoeff = 0;
        if (Fixedheight == false)
        {
            if (_yMaxValue > 0)
                _yCoeff = (this.Height - 4) / _yMaxValue;
        }
        else
            _yCoeff = (this.Height - 4) / (double)100;

        // Now calculate the X coeff
        double _xCoeff = 2;

        int newPxlX = 0;
        int newPxlY = 0;
        int oldPxlX = 0;
        int oldPxlY = 0;
        int x;
        var loopTo = _xMin;

        // Now draw lines (upper lines)
        for (x = _xMax; x >= loopTo; x += -1)
        {
            newPxlX = System.Convert.ToInt32((x - numberOfValuesHidden) * _xCoeff);
            newPxlY = System.Convert.ToInt32(this.Height - _values2[x] * _yCoeff) - 2;

            // If first line, old = new
            if (x == _xMax)
            {
                oldPxlX = newPxlX;
                oldPxlY = newPxlY;
            }

            // Draw line
            g.DrawLine(_color3, newPxlX, newPxlY, oldPxlX, oldPxlY);

            // Save old X & Y
            oldPxlX = newPxlX;
            oldPxlY = newPxlY;
        }
    }

    // Draw values
    private void DrawValues(Graphics g)
    {

        // Now calculate the Y coeff (height in pxl = VALUE(%) * _yCoeff
        double _yCoeff = 0;
        if (Fixedheight == false)
        {
            if (_yMaxValue > 0)
                _yCoeff = (this.Height - 4) / _yMaxValue;
        }
        else
            _yCoeff = (this.Height - 4) / (double)100;

        // Now calculate the X coeff
        double _xCoeff = 2;

        int newPxlX = 0;
        int newPxlY = 0;
        int oldPxlX = 0;
        int oldPxlY = 0;
        int x;
        var loopTo = _xMin;

        // Now draw lines (upper lines)
        for (x = _xMax; x >= loopTo; x += -1)
        {
            newPxlX = System.Convert.ToInt32((x - numberOfValuesHidden) * _xCoeff);
            newPxlY = System.Convert.ToInt32(this.Height - _values[x] * _yCoeff) - 2;

            // If first line, old = new
            if (x == _xMax)
            {
                oldPxlX = newPxlX;
                oldPxlY = newPxlY;
            }

            // Draw line
            g.DrawLine(_color, newPxlX, newPxlY, oldPxlX, oldPxlY);

            // Save old X & Y
            oldPxlX = newPxlX;
            oldPxlY = newPxlY;
        }
    }

    private void DrawValuesDown(Graphics g)
    {

        // Calculate maximum of current view
        int x;
        var loopTo = _xMin;
        for (x = _xMax; x >= loopTo; x += -1)
        {
            if (_values[x] > _yMaxValue)
                _yMaxValue = _values[x];
        }

        // Now calculate the Y coeff (height in pxl = VALUE(%) * _yCoeff
        double _yCoeff = 0;
        if (Fixedheight == false)
        {
            if (_yMaxValue > 0)
                _yCoeff = (this.Height - 4) / _yMaxValue;
        }
        else
            _yCoeff = (this.Height - 4) / (double)100;

        // Now calculate the X coeff
        double _xCoeff = 2;

        int newPxlX = 0;
        int newPxlY = 0;
        int oldPxlX = 0;
        int oldPxlY = 0;
        var loopTo1 = _xMin;

        // Now draw lines (lower lines)
        for (x = _xMax; x >= loopTo1; x += -1)
        {
            newPxlX = System.Convert.ToInt32((x - numberOfValuesHidden) * _xCoeff);
            newPxlY = System.Convert.ToInt32(this.Height - _values[x] * _yCoeff) - 2;

            // If first line, old = new
            if (x == _xMax)
            {
                oldPxlX = newPxlX;
                oldPxlY = newPxlY;
            }

            // Draw line
            g.DrawLine(_color2, newPxlX, newPxlY, newPxlX, this.Height - 1);
            g.DrawLine(_color2, newPxlX + 1, newPxlY, newPxlX + 1, this.Height - 1);

            // Save old X & Y
            oldPxlX = newPxlX;
            oldPxlY = newPxlY;
        }
    }


    // ========================================
    // Public functions
    // ========================================

    public void AddValue(int value)
    {
        AddValue(System.Convert.ToDouble(value));
    }
    public void AddValue(double value)
    {
        nCount += 1;
        if (_values.Length < nCount)
        {
            var old_values = _values;
            _values = new double[2 * _values.Length + 1];
            if (old_values != null)
                Array.Copy(old_values, _values, Math.Min(2 * _values.Length + 1, old_values.Length));
        }
        _values[nCount - 1] = value;


        // Calculate new xMin and xMax
        numberOfValuesDisplayed = this.Width / 2;
        numberOfValuesHidden = System.Convert.ToInt32(nCount - numberOfValuesDisplayed);

        _xMax = nCount - 1;      // Last item by default
        _xMin = System.Convert.ToInt32(Math.Max(_xMax - numberOfValuesDisplayed, 0));
    }

    public void Add2Values(int value1, int value2)
    {
        Add2Values(System.Convert.ToDouble(value1), System.Convert.ToDouble(value2));
    }
    public void Add2Values(double value1, double value2)
    {
        nCount += 1;
        if (_values.Length < nCount)
        {
            var old_values = _values;
            _values = new double[2 * _values.Length + 1];
            if (old_values != null)
                Array.Copy(old_values, _values, Math.Min(2 * _values.Length + 1, old_values.Length));
            var old_values2 = _values2;
            _values2 = new double[2 * _values.Length + 1];
            if (old_values2 != null)
                Array.Copy(old_values2, _values2, Math.Min(2 * _values.Length + 1, old_values2.Length));
        }
        _values[nCount - 1] = value1;
        _values2[nCount - 1] = value2;

        // Calculate new xMin and xMax
        numberOfValuesDisplayed = this.Width / 2;
        numberOfValuesHidden = System.Convert.ToInt32(nCount - numberOfValuesDisplayed);

        _xMax = nCount - 1;      // Last item by default
        _xMin = System.Convert.ToInt32(Math.Max(_xMax - numberOfValuesDisplayed, 0));
    }

    public void ClearValue()
    {
        _values = new double[201];
        _values2 = new double[201];
        nCount = 0;
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        ((System.ComponentModel.ISupportInitialize)this).BeginInit();
        this.SuspendLayout();
        // 
        // toolTip
        // 
        this.toolTip.AutomaticDelay = 0;
        this.toolTip.ShowAlways = true;
        ((System.ComponentModel.ISupportInitialize)this).EndInit();
        this.ResumeLayout(false);
    }
}
