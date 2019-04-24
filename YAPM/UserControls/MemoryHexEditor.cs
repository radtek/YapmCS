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
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public partial class MemoryHexEditor
{
    private MemoryHexEditor(IContainer components)
    {
        this.components = components;
        _vs = new VScrollBar();
    }

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ShowCaret(IntPtr hWnd);


    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool DestroyCaret();


    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetCaretPos(int X, int Y);


    [DllImport("user32.dll", SetLastError = true)]
    private static extern int InvertRect(IntPtr hdc, ref RECT lpRect);


    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public RECT(int _left, int _top, int _width, int _height)
        {
            Left = _left;
            Top = _top;
            Bottom = _height + Top;
            Right = _width + _left;
        }
    }




    // Controls
    private VScrollBar __vs;

    private VScrollBar _vs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __vs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__vs != null)
            {
            }

            __vs = value;
            if (__vs != null)
            {
            }
        }
    }

    // Process attributes
    private int _pid = 0;             // Process ID
    private IntPtr _hProc;                // Handle to process
    private ProcessRW _rw;

    // Memory informations
    private MemoryRegion _memRegion;
    private int _physBeg;
    private int _physEnd;
    private bool _relativeOffset;

    // Informations about current view
    private IntPtr _curViewDeb;
    private int _linesNumber;

    // Colors
    private static Color _OffsetColor = Color.Black;
    private static Color _HValuesColor = Color.Blue;
    private static Color _SValuesColor = Color.Red;
    private static Color _SelectionColor = Color.AliceBlue;
    private static Color _LineColor = Color.DarkGray;

    // Pens
    private Pen _HValuesPen = new Pen(_HValuesColor);
    private Pen _SValuesPen = new Pen(_SValuesColor);
    private Pen _SelectionPen = new Pen(_SelectionColor);
    private Pen _OffsetPen = new Pen(_OffsetColor);
    private Pen _LinePen = new Pen(_LineColor);

    // Brushes
    private Brush _OffsetBrush = Brushes.Blue;
    private Brush _HexaBrush = Brushes.Black;
    private Brush _failedBrush = Brushes.Red;

    // Positions (to draw)
    private const int CONTROL_WIDTH = 625;
    private const int LEFT_HEXA = 100;
    private const int LEFT_OFFSET = 2;
    private const int LEFT_FIRST_LINE = 90;
    private const int LEFT_SECOND_LINE = 460;
    private const int LEFT_STRING = 470;
    private const int LINE_HEIGHT = 12;
    private const int TOP_OFFSET = 3;
    private int CHAR_HEIGHT = 13;
    private int CHAR_WIDTH = 7;

    // Graphic items
    private Font _font = new Font("Courier New", 12, FontStyle.Regular, GraphicsUnit.World, 0);

    // Caret
    private int _xCaret = LEFT_HEXA + 1;      // pxl
    private int _yCaret = TOP_OFFSET;         // pxl
    private int _xCar = 1;                    // 0-15
    private int _yCar = 1;                    // 0-_linesNumber

    // Selection
    private bool _selection = false;
    private int _xOld;
    private int _yOld;
    private bool _ShiftDown = false;
    private bool shitD;


    // ========================================
    // Structures
    // ========================================
    public struct MemoryRegion
    {
        public IntPtr BeginningAddress;
        public IntPtr Size;
        public MemoryRegion(IntPtr _begin, IntPtr _size)
        {
            BeginningAddress = _begin;
            Size = _size;
        }
    }

    // ========================================
    // Properties
    // ========================================
    public int ProcessID
    {
        get
        {
            return _pid;
        }
    }
    public MemoryRegion MemRegion
    {
        get
        {
            return _memRegion;
        }
    }
    public bool UseRelativeOffset
    {
        get
        {
            return _relativeOffset;
        }
        set
        {
            _relativeOffset = value;
        }
    }


    // ========================================
    // Public functions
    // ========================================

    // Navigate to offset
    public void NavigateToOffset(long offset)
    {
        if (offset >= _vs.Minimum && offset <= _vs.Maximum)
            _vs.Value = System.Convert.ToInt32(offset);
    }

    // Constructor & destructor
    ~MemoryHexEditor()
    {
    }
    public void NewProc(MemoryRegion MemRegion, int ProcessId)
    {

        // Required
        // InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        Width = CONTROL_WIDTH;
        // CHAR_HEIGHT = CInt(Me.CreateGraphics.MeasureString("0", _font, 0).Height)

        _pid = ProcessId;
        _rw = new ProcessRW(_pid);
        _memRegion = MemRegion;
        _curViewDeb = _memRegion.BeginningAddress;

        // Initialize VS
        {
            var withBlock = _vs;
            withBlock.Maximum = System.Convert.ToInt32(_memRegion.Size.ToInt32() / (double)16);
            withBlock.Minimum = 0;
            withBlock.Value = 0;
            withBlock.SmallChange = 1;
            withBlock.LargeChange = System.Convert.ToInt32(withBlock.Maximum / (double)30 + 1);
            withBlock.Top = 0;
            withBlock.Width = 20;
            withBlock.Height = Height;
            withBlock.Left = Width - withBlock.Width;
            Controls.Add(_vs);
        }

        // Initialize caret
        CreateCaret(Handle, IntPtr.Zero, 1, CHAR_HEIGHT);
        UpdateCaretPosition();
        _xOld = 1;
        _yOld = 1;
        ShowCaret(Handle);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
    {
        base.OnPaint(pe);

        var peGraphics = pe.Graphics;
        DrawOffset(ref peGraphics);
        DrawValues(ref peGraphics);
        DrawSelection(ref peGraphics);
    }



    // ========================================
    // Private functions
    // ========================================

    // Draw selection
    private void DrawSelection(ref Graphics g)
    {

        // Draw 3 invert rectangles
        // Hexa + String

        // first -> first incomplete line
        // second -> full lines
        // third -> last incomplet line

        IntPtr hDc = g.GetHdc();

        switch (Math.Abs(_yOld - _yCar))
        {
            case 0:
                {
                    // Only 1 rect (hexa)
                    int y = GetYpxlHexa(_yOld);
                    int x1 = GetXpxlHexa(_xOld);
                    int x2 = GetXpxlHexa(_xCar);
                    RECT rect1 = new RECT(Math.Min(x1, x2), y, Math.Abs(x2 - x1) + CHAR_WIDTH, CHAR_HEIGHT);
                    InvertRect(hDc, ref rect1);

                    // String
                    y = GetYpxlString(_yOld);
                    x1 = GetXpxlString(_xOld);
                    x2 = GetXpxlString(_xCar);
                    rect1 = new RECT(Math.Min(x1, x2), y, Math.Abs(x2 - x1) + CHAR_WIDTH, CHAR_HEIGHT);
                    InvertRect(hDc, ref rect1);
                    break;
                }

            case 1:
                {
                    // 2 rects (hexa)
                    int y1 = GetYpxlHexa(_yOld);
                    int y2 = GetYpxlHexa(_yCar);
                    int x1 = GetXpxlHexa(_xOld);
                    int x2 = GetXpxlHexa(_xCar);

                    RECT rect1;
                    RECT rect2;

                    if (y1 > y2)
                    {
                        int t = GetXpxlHexa(1);
                        rect1 = new RECT(t, y1, x1 - t, CHAR_HEIGHT);
                        rect2 = new RECT(x2, y2 - 1, GetXpxlHexa(32) + CHAR_WIDTH - x2, CHAR_HEIGHT);
                    }
                    else
                    {
                        int t = GetXpxlHexa(1);
                        rect1 = new RECT(x1, y1, GetXpxlHexa(32) + CHAR_WIDTH - x1, CHAR_HEIGHT);
                        rect2 = new RECT(t, y2 + 1, x2 - t, CHAR_HEIGHT);
                    }

                    InvertRect(hDc, ref rect1);
                    InvertRect(hDc, ref rect2);


                    // String
                    y1 = GetYpxlString(_yOld);
                    y2 = GetYpxlString(_yCar);
                    x1 = GetXpxlString(_xOld);
                    x2 = GetXpxlString(_xCar);

                    if (y1 > y2)
                    {
                        int t = GetXpxlString(1);
                        rect1 = new RECT(t, y1, x1 - t, CHAR_HEIGHT);
                        rect2 = new RECT(x2, y2 - 1, GetXpxlString(32) + CHAR_WIDTH - x2, CHAR_HEIGHT);
                    }
                    else
                    {
                        int t = GetXpxlString(1);
                        rect1 = new RECT(x1, y1, GetXpxlString(32) + CHAR_WIDTH - x1, CHAR_HEIGHT);
                        rect2 = new RECT(t, y2 + 1, x2 - t, CHAR_HEIGHT);
                    }

                    InvertRect(hDc, ref rect1);
                    InvertRect(hDc, ref rect2);
                    break;
                }

            default:
                {
                    // 3 rects (hexa)
                    int y1 = GetYpxlHexa(_yOld);
                    int y2 = GetYpxlHexa(_yCar);
                    int x1 = GetXpxlHexa(_xOld);
                    int x2 = GetXpxlHexa(_xCar);

                    RECT rect1;
                    RECT rect2;
                    RECT rect3;

                    if (y1 > y2)
                    {
                        int t = GetXpxlHexa(1);
                        int t2 = GetXpxlHexa(32) + CHAR_WIDTH;
                        rect1 = new RECT(t, y1, x1 - t, CHAR_HEIGHT);
                        rect2 = new RECT(x2, y2, t2 - x2, CHAR_HEIGHT);
                        rect3 = new RECT(t, y2 + CHAR_HEIGHT, t2 - t, y1 - y2 - CHAR_HEIGHT);
                    }
                    else
                    {
                        int t = GetXpxlHexa(1);
                        int t2 = GetXpxlHexa(32) + CHAR_WIDTH;
                        rect1 = new RECT(x1, y1, t2 - x1, CHAR_HEIGHT);
                        rect2 = new RECT(t, y2, x2 - t, CHAR_HEIGHT);
                        rect3 = new RECT(t, y1 + CHAR_HEIGHT, t2 - t, y2 - y1 - CHAR_HEIGHT);
                    }

                    InvertRect(hDc, ref rect1);
                    InvertRect(hDc, ref rect2);
                    InvertRect(hDc, ref rect3);


                    // String
                    y1 = GetYpxlString(_yOld);
                    y2 = GetYpxlString(_yCar);
                    x1 = GetXpxlString(_xOld);
                    x2 = GetXpxlString(_xCar);

                    if (y1 > y2)
                    {
                        int t = GetXpxlString(1);
                        int t2 = GetXpxlString(32) + CHAR_WIDTH;
                        rect1 = new RECT(t, y1, x1 - t, CHAR_HEIGHT);
                        rect2 = new RECT(x2, y2, t2 - x2, CHAR_HEIGHT);
                        rect3 = new RECT(t, y2 + CHAR_HEIGHT, t2 - t, y1 - y2 - CHAR_HEIGHT);
                    }
                    else
                    {
                        int t = GetXpxlString(1);
                        int t2 = GetXpxlString(32) + CHAR_WIDTH;
                        rect1 = new RECT(x1, y1, t2 - x1, CHAR_HEIGHT);
                        rect2 = new RECT(t, y2, x2 - t, CHAR_HEIGHT);
                        rect3 = new RECT(t, y1 + CHAR_HEIGHT, t2 - t, y2 - y1 - CHAR_HEIGHT);
                    }

                    InvertRect(hDc, ref rect1);
                    InvertRect(hDc, ref rect2);
                    InvertRect(hDc, ref rect3);
                    break;
                }
        }

        g.ReleaseHdc();
    }

    // Draw offsets
    private void DrawOffset(ref Graphics g)
    {
        var loopTo = _linesNumber - 1;

        // Draw offsets
        for (int x = 0; x <= loopTo; x++)
            g.DrawString(FormatedOffset(_memRegion.BeginningAddress.Increment((_vs.Value + x) * 16)), _font, _OffsetBrush, LEFT_OFFSET, TOP_OFFSET + x * LINE_HEIGHT);

        // Draw 2 lines
        g.DrawLine(_LinePen, LEFT_FIRST_LINE, 0, LEFT_FIRST_LINE, Height);
        g.DrawLine(_LinePen, LEFT_SECOND_LINE, 0, LEFT_SECOND_LINE, Height);
    }

    // Draw values read in memory
    private void DrawValues(ref Graphics g)
    {

        // Read all bytes to display from memory
        int size = 16 * _linesNumber;
        bool isOk = true;
        byte[] buff = _rw.ReadByteArray(_curViewDeb, size, ref isOk);

        Brush theBruh = _HexaBrush;
        if (isOk == false)
            theBruh = _failedBrush;
        var loopTo = _linesNumber - 1;

        // Display hexa
        for (int x = 0; x <= loopTo; x++)
        {
            string s = "";

            for (int y = 1; y <= 16; y++)
            {
                string s2 = buff[x * 16 + y - 1].ToString("x");
                if (s2.Length == 1)
                    s2 = "0" + s2;
                s += s2 + " ";
            }

            g.DrawString(s, _font, theBruh, LEFT_HEXA, TOP_OFFSET + x * LINE_HEIGHT);
        }

        var loopTo1 = _linesNumber - 1;

        // Display strings
        for (int x = 0; x <= loopTo1; x++)
        {
            string s = "";

            for (int y = 1; y <= 16; y++)
            {
                byte b = buff[x * 16 + y - 1];
                if ((b > 0x1F & !(b > 0x7E & b < 0xA0)))
                    s += Convert.ToChar(b).ToString();
                else
                    s += ".";
            }

            g.DrawString(s, _font, theBruh, LEFT_STRING, TOP_OFFSET + x * LINE_HEIGHT);
        }
    }

    // Get X (pixel) from X (logical)
    private int GetXpxlHexa(int x)
    {
        return 1 + LEFT_HEXA + CHAR_WIDTH * (x - 1) + System.Convert.ToInt32((CHAR_WIDTH + 1.35) * Math.Floor((x - 1) / (double)2));
    }
    // Get Y (pixel) from Y (logical)
    private int GetYpxlHexa(int y)
    {
        return TOP_OFFSET + System.Convert.ToInt32(CHAR_HEIGHT - 0.5) * (y - 1);
    }
    // Get X (pixel) from X (logical)
    private int GetXpxlString(int x)
    {
        return System.Convert.ToInt32(1 + LEFT_STRING + CHAR_WIDTH * (x - 1) / (double)2); // + CInt((CHAR_WIDTH + 1.35) * Math.Floor((x - 1) / 2))
    }
    // Get Y (pixel) from Y (logical)
    private int GetYpxlString(int y)
    {
        return GetYpxlHexa(y);
    }

    // Change caret position
    private void UpdateCaretPosition()
    {

        // Calculate size (pixel) from _xCar and _yCar
        _xCaret = GetXpxlHexa(_xCar); // 1 + LEFT_HEXA + CHAR_WIDTH * (_xCar - 1) + CInt((CHAR_WIDTH + 1.35) * Math.Floor((_xCar - 1) / 2))
        _yCaret = GetYpxlHexa(_yCar); // TOP_OFFSET + CInt(CHAR_HEIGHT - 0.5) * (_yCar - 1)

        SetCaretPos(_xCaret, _yCaret);
    }

    // Calculate car positions
    private void ReCalcX(int eX)
    {
        if (eX > LEFT_HEXA & eX < LEFT_SECOND_LINE)
        {

            // spaces take 1 CHAR_WIDTH+1 pixels
            int x = eX - LEFT_HEXA;
            int spaces = System.Convert.ToInt32(Math.Floor(x / (double)(3 * CHAR_WIDTH + 1)));
            _xCar = System.Convert.ToInt32((x - spaces) / (double)CHAR_WIDTH) - spaces;
            if (_xCar < 1)
                _xCar = 1;
            if (_xCar > 32)
                _xCar = 32;
        }
    }
    private void ReCalcY(int eY)
    {
        _yCar = 1 + System.Convert.ToInt32((eY - TOP_OFFSET) / (CHAR_HEIGHT - 0.5));
    }

    // Get formated offset
    private string FormatedOffset(IntPtr address)
    {
        string s = address.ToString("x");
        return "0x" + new string(Convert.ToChar(48), 8 - s.Length) + s;
    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (_ShiftDown == false)
        {
            _xCar = _xOld;
            _yCar = _yOld;
        }
    }

    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 

        Static shitD As Boolean = False

 */
        if (e.Button != System.Windows.Forms.MouseButtons.Left)
            return;

        if (_ShiftDown)
        {
            if (shitD == false)
            {
                shitD = true;
                _xOld = _xCar;
                _yOld = _yCar;
            }
        }

        // Calculate _xCar and _yCar
        ReCalcX(e.X);
        ReCalcY(e.Y);

        Refresh();
    }

    protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        if (e.Delta < 0)
        {
            if (_vs.Value < _vs.Maximum)
                _vs.Value += 1;
        }
        else if (_vs.Value > _vs.Minimum)
            _vs.Value -= 1;
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 

        Static shitD As Boolean = False

 */
        if (_ShiftDown)
        {
            if (shitD == false)
            {
                shitD = true;
                _xOld = _xCar;
                _yOld = _yCar;
                Trace.WriteLine("changement");
            }
        }

        // Calculate _xCar and _yCar
        ReCalcX(e.X);
        ReCalcY(e.Y);

        if (!(_ShiftDown))
        {
            shitD = false;
            _xOld = _xCar;
            _yOld = _yCar;
            Trace.WriteLine("aucun");
            UpdateCaretPosition();
        }

        Trace.WriteLine("old=" + _xOld + " new=" + _xCar);

        Refresh();
    }

    protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyUp(e);

        switch (e.KeyCode)
        {
            case Keys.ShiftKey:
                {
                    _ShiftDown = false;
                    break;
                }
        }
    }

    protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyDown(e);

        // Static shitD As Boolean = False

        // If e.Shift Then
        // If shitD = False Then
        // shitD = True
        // _xOld = _xCar
        // _yOld = _yCar
        // End If
        // End If


        switch (e.KeyCode)
        {
            case Keys.Q:
                {
                    if (_xCar > 1)
                        _xCar -= 1;
                    else
                    {
                        _yCar -= 1;
                        _xCar = 32;
                        if (_yCar < 1)
                        {
                            _yCar = 1;
                            _xCar = 1;
                        }
                    }

                    break;
                }

            case Keys.D:
                {
                    if (_xCar < 32)
                        _xCar += 1;
                    else
                    {
                        _yCar += 1;
                        _xCar = 1;
                        if (_yCar > _linesNumber - 1)
                        {
                            _yCar = _linesNumber - 1;
                            // Scroll down
                            if (_vs.Value < _vs.Maximum)
                                _vs.Value += 1;
                        }
                    }

                    break;
                }

            case Keys.Z:
                {
                    _yCar -= 1;
                    if (_yCar < 1)
                    {
                        _yCar = 1;
                        if (_vs.Value > 1)
                            _vs.Value -= 1;
                    }

                    break;
                }

            case Keys.S:
                {
                    _yCar += 1;
                    if (_yCar > _linesNumber - 1)
                    {
                        _yCar = _linesNumber - 1;
                        // Scroll down
                        if (_vs.Value < _vs.Maximum)
                            _vs.Value += 1;
                    }

                    break;
                }

            case Keys.ShiftKey:
                {
                    _ShiftDown = true;
                    return;
                }
        }


        if (e.Shift)
            Refresh();
        else
        {
            _xOld = _xCar;
            _yOld = _yCar;
        }

        UpdateCaretPosition();
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        _vs.Height = Height;
        _linesNumber = System.Convert.ToInt32((Height - TOP_OFFSET) / (double)CHAR_HEIGHT);  // Calculate number of lines to display
        Refresh();
    }

    private void _vs_ValueChanged(object sender, System.EventArgs e)
    {
        _curViewDeb = _memRegion.BeginningAddress.Increment(_vs.Value * 16);  // Calculate first address
        Refresh();
    }
}

