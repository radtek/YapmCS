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
using System;

public partial class frmWindowsList
{
    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Common.Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(lv.Handle);
        RefreshWindowsList();
    }

    private void timerRefresh_Tick(System.Object sender, System.EventArgs e)
    {
        RefreshWindowsList();
    }

    // List all windows
    private void RefreshWindowsList()
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
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Handle == (IntPtr)it.Tag)
                {
                    // Still existing -> update infos
                    it.Text = frm.Text;
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
        foreach (Form frm in Application.OpenForms)
        {
            bool exist = false;
            foreach (ListViewItem itt in this.lv.Items)
            {
                if ((IntPtr)itt.Tag == frm.Handle)
                {
                    exist = true;
                    if (frm.Visible)
                        itt.ForeColor = Color.Black;
                    else
                        itt.ForeColor = Color.Gray;
                    break;
                }
            }

            if (exist == false)
            {
                // Have to create
                ListViewItem nene = new ListViewItem(frm.Text);
                if (first == false)
                    nene.BackColor = Program.NEW_ITEM_COLOR;
                nene.ForeColor = Color.FromArgb(30, 30, 30);
                nene.Tag = frm.Handle;

                // Add icon
                try
                {
                    string sKey = "_" + System.Convert.ToString(frm.Handle);
                    this.imgList.Images.Add(sKey, frm.Icon);
                    nene.ImageKey = sKey;
                }
                catch (Exception ex)
                {
                    nene.ImageKey = "";
                }

                if (frm.Visible)
                    nene.ForeColor = Color.Black;
                else
                    nene.ForeColor = Color.Gray;
                this.lv.Items.Add(nene);
            }
        }

        first = false;
    }

    private void lv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.TheContextMenu.Show(this.lv, e.Location);
    }

    private void lv_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        if (this.lv.SelectedItems.Count == 0)
        {
            this.MenuItemShow.Enabled = false;
            this.MenuItemClose.Enabled = false;
        }
        else
        {
            bool oneGray = false;
            foreach (ListViewItem it in this.lv.SelectedItems)
            {
                if (it.ForeColor == Color.Gray)
                {
                    oneGray = true;
                    break;
                }
            }
            this.MenuItemShow.Enabled = !(oneGray);
            this.MenuItemClose.Enabled = !(oneGray);
        }
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            IntPtr hWnd = (IntPtr)it.Tag;
            if (hWnd.IsNotNull())
                cWindow.LocalShowWindowForeground(hWnd);
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            IntPtr hWnd = (IntPtr)it.Tag;
            if (hWnd.IsNotNull())
                cWindow.LocalClose(hWnd);
        }
    }
}
