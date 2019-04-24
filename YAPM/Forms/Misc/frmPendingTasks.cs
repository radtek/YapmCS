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
using System.Collections.Generic;

public partial class frmPendingTasks
{
    private cGeneralObject _obj;
    private bool _forAll = false;

    private void frm_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);
        Native.Functions.Misc.SetTheme(lv.Handle);
        RefreshTasksList();
    }

    // Constructor used to display pending task of ONE object
    public frmPendingTasks(ref cGeneralObject obj)
    {
        InitializeComponent();
        _obj = obj;
    }
    // For ALL objects
    public frmPendingTasks()
    {
        InitializeComponent();
        _forAll = true;
    }

    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        RefreshTasksList();
    }

    // List all pending tasks
    private void RefreshTasksList()
    {
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

        Static first As Boolean = True

 */
        // Wait for semaphore
        cGeneralObject.globalSemPendingtask.WaitOne();

        Dictionary<int, System.Threading.WaitCallback> _list;
        if (_forAll)
            _list = cGeneralObject.GetAllPendingTasks;
        else
            _list = _obj.GetPendingTasks;

        // Remove 'red' items (previously deleted)
        foreach (ListViewItem it in this.lv.Items)
        {
            if (it.BackColor == Program.DELETED_ITEM_COLOR)
                it.Remove();
        }

        // Deleted items
        foreach (ListViewItem it in this.lv.Items)
        {
            bool exist = false;
            foreach (System.Collections.Generic.KeyValuePair<int, System.Threading.WaitCallback> thr in _list)
            {
                if (thr.Key.ToString() == it.Text)
                {
                    // Still existing -> update infos
                    exist = true;
                    break;
                }
            }

            if (exist == false)
                // Deleted
                it.BackColor = Program.DELETED_ITEM_COLOR;
        }


        // Remove 'green' items (previously deleted)
        foreach (ListViewItem it in this.lv.Items)
        {
            if (it.BackColor == Program.NEW_ITEM_COLOR)
                it.BackColor = Color.White;
        }


        // New items
        foreach (System.Collections.Generic.KeyValuePair<int, System.Threading.WaitCallback> thr in _list)
        {
            bool exist = false;
            foreach (ListViewItem itt in this.lv.Items)
            {
                if (itt.Text == thr.Key.ToString())
                {
                    exist = true;
                    break;
                }
            }

            if (exist == false)
            {
                // Have to create
                ListViewItem nene = new ListViewItem(thr.Key.ToString());
                if (first == false)
                    nene.BackColor = Program.NEW_ITEM_COLOR;
                nene.ForeColor = Color.FromArgb(30, 30, 30);
                string[] items = new string[2];
                items[0] = thr.Value.Target.ToString();
                items[1] = thr.Value.Method.ToString();
                nene.SubItems.AddRange(items);
                this.lv.Items.Add(nene);
            }
        }

        // Change infos
        // For Each it As ListViewItem In Me.lv.Items
        // Dim theThread As System.Threading.WaitCallback = Nothing
        // For Each thr As System.Collections.Generic.KeyValuePair(Of Integer, System.Threading.WaitCallback) In _list
        // If thr.Key.ToString = it.Text Then
        // theThread = thr.Value
        // Exit For
        // End If
        // Next

        // 'If theThread IsNot Nothing Then
        // '    it.SubItems(1).Text = theThread.ThreadState.ToString
        // '    it.SubItems(2).Text = theThread.Priority.ToString
        // 'End If
        // Next


        // Release semaphore
        cGeneralObject.globalSemPendingtask.Release();

        first = false;
    }
}
