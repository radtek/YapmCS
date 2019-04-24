using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;

public class cLog
{
    private frmLog frm = new frmLog();

    // Private _lineCount As Integer
    // Private _spaces As Integer = 5
    // Private _addTime As Boolean = True
    // Private _s() As String

    // Constructors
    public cLog(string stringValue)
    {
    }
    public cLog()
    {
    }


    // Propeties
    // Public Property SpacesBetweenTimeAndText() As Integer
    // Get
    // Return _spaces
    // End Get
    // Set(ByVal value As Integer)
    // If value >= 0 Then
    // _spaces = value
    // End If
    // End Set
    // End Property
    // Public Property AddDateTime() As Boolean
    // Get
    // Return _addTime
    // End Get
    // Set(ByVal value As Boolean)
    // _addTime = value
    // End Set
    // End Property
    public int LineCount
    {
        get
        {
            return this.frm.lv.Items.Count;
        }
    }
    public ListView.ListViewItemCollection Items
    {
        get
        {
            return this.frm.lv.Items;
        }
    }
    // Public ReadOnly Property Line(ByVal index As Integer) As String
    // Get
    // If index > 0 And index <= Me.LineCount Then
    // Return _s(index)
    // Else
    // Return vbNullString
    // End If
    // End Get
    // End Property
    public bool ShowForm
    {
        set
        {
            if (value)
            {
                frm.TopMost = Program._frmMain.TopMost;
                frm.Show();
            }
            else
                frm.Hide();
        }
    }



    // Public functions
    public void Clear()
    {
        // ReDim _s(0)
        // _lineCount = 0
        frm.lv.Items.Clear();
    }

    public void AppendLine(string line)
    {
        // Dim s As String = ""
        // If _lineCount > 0 Then
        // s &= vbNewLine
        // End If
        // If _addTime Then
        // s &= Date.Now.ToLongDateString & " -- " & Date.Now.ToLongTimeString & Space(_spaces)
        // End If
        // s &= line
        // _lineCount += 1

        // ' Redim array if necessary
        // ' Size *2 -> size each time (reduces number of redim calls)
        // If _lineCount >= _s.Length Then
        // ReDim Preserve _s(_s.Length * 2)
        // End If
        // _s(_lineCount) = s
        ListViewItem it = new ListViewItem(DateTime.Now.ToLongDateString() + " -- " + DateTime.Now.ToLongTimeString());
        it.SubItems.Add(line);
        this.frm.lv.Items.Add(it);
    }

    public string GetLog()
    {
        // Dim logSize As Integer = System.Runtime.InteropServices.Marshal.SizeOf(_s)
        // Dim sb As New StringBuilder(logSize)
        // For Each ss As String In _s
        // sb.AppendLine(ss)
        // Next
        // Return sb.ToString
        string s = "";
        foreach (ListViewItem it in frm.lv.Items)
            s += it.Text + Constants.vbTab + it.SubItems[1].Text;
        return s;
    }
}

