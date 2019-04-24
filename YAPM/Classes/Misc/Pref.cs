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
using System;

public class Pref
{


    // ========================================
    // Private constants
    // ========================================


    // ========================================
    // Private attributes
    // ========================================


    // ========================================
    // Public properties
    // ========================================


    // ========================================
    // Other public
    // ========================================

    // Value of 'left property' to hide a form
    public const int LEFT_POSITION_HIDDEN = -200;

    // Message displayed when YAPM starts for the first time
    public const string MessageFirstStartOfYAPM = "This is the first time you run YAPM. Please remember that it is still a beta version so there are some bugs and some missing functionnalities :-)" + Constants.vbNewLine + Constants.vbNewLine + "You should run YAPM as an administrator in order to fully control your processes. Please take care using this YAPM because you will be able to do some irreversible things if you kill or modify some system processes... Use it at your own risks !" + Constants.vbNewLine + Constants.vbNewLine + "Please let me know any of your ideas of improvement or new functionnalities in YAPM's sourceforge.net project page ('Help' pannel) :-)" + Constants.vbNewLine + Constants.vbNewLine + "This message won't be shown anymore :-)";



    // ========================================
    // Public functions
    // ========================================

    // Save
    public void Save()
    {
        My.MySettingsProperty.Settings.Save();
    }

    // Set to default
    public void SetDefault()
    {
        My.MySettingsProperty.Settings.Reset();
        My.MySettingsProperty.Settings.Save();
        this.Apply();
    }

    // Apply pref
    public void Apply()
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
        Program._frmMain.timerProcess.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.ProcessInterval * Program.Connection.RefreshmentCoefficient);
        Program._frmMain.timerServices.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.ServiceInterval * Program.Connection.RefreshmentCoefficient);
        Program._frmMain.timerNetwork.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.NetworkInterval * Program.Connection.RefreshmentCoefficient);
        Program._frmMain.timerTask.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.TaskInterval * Program.Connection.RefreshmentCoefficient);
        Program._frmMain.timerTrayIcon.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.TrayInterval * Program.Connection.RefreshmentCoefficient);
        Program._frmMain.timerJobs.Interval = System.Convert.ToInt32(My.MySettingsProperty.Settings.JobInterval * Program.Connection.RefreshmentCoefficient);
        switch (My.MySettingsProperty.Settings.Priority)
        {
            case 0:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Idle;
                    break;
                }

            case 1:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
                    break;
                }

            case 2:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
                    break;
                }

            case 3:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
                    break;
                }

            case 4:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                    break;
                }

            case 5:
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
                    break;
                }
        }
        handleList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        handleList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        memoryList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        memoryList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        windowList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        windowList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        moduleList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        moduleList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        networkList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        networkList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        processList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        processList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        serviceList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        serviceList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        taskList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        taskList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        threadList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        threadList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        jobList.DELETED_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.DeletedItemColor);
        jobList.NEW_ITEM_COLOR = Color.FromArgb(My.MySettingsProperty.Settings.NewItemColor);
        Program._frmMain.Tray.Visible = My.MySettingsProperty.Settings.ShowTrayIcon;
        Program._frmMain.StatusBar.Visible = My.MySettingsProperty.Settings.ShowStatusBar;

        // Common tasks on first time
        if (first)
        {
            first = false;

            // Ribbon style ?
            Program._frmMain.permuteMenuStyle(My.MySettingsProperty.Settings.UseRibbonStyle);

            // Update ?
            if (My.MySettingsProperty.Settings.UpdateAuto)
                Program.Updater.CheckUpdates(true);

            Program._frmMain.TopMost = My.MySettingsProperty.Settings.TopMost;
            Program._frmMain.butAlwaysDisplay.Checked = My.MySettingsProperty.Settings.TopMost;
            Program._frmMain.Visible = !(My.MySettingsProperty.Settings.StartHidden);
            Program._frmMain.MenuItemMainAlwaysVisible.Checked = My.MySettingsProperty.Settings.TopMost;
            Program._frmMain.MenuItemNotifNP.Checked = My.MySettingsProperty.Settings.NotifyNewProcesses;
            Program._frmMain.MenuItemNotifDS.Checked = My.MySettingsProperty.Settings.NotifyDeletedServices;
            Program._frmMain.MenuItemNotifNS.Checked = My.MySettingsProperty.Settings.NotifyNewServices;
            Program._frmMain.MenuItemNotifTP.Checked = My.MySettingsProperty.Settings.NotifyTerminatedProcesses;
        }

        // Highlightings
        {
            var withBlock = My.MySettingsProperty.Settings;
            cThread.SetHighlightings(withBlock.EnableHighlightingSuspendedThread);
            cThread.SetHighlightingsColor(withBlock.HighlightingColorSuspendedThread);
            cModule.SetHighlightings(withBlock.EnableHighlightingRelocatedModule);
            cModule.SetHighlightingsColor(withBlock.HighlightingColorRelocatedModule);
            cProcess.SetHighlightings(withBlock.EnableHighlightingBeingDebugged, withBlock.EnableHighlightingJobProcess, withBlock.EnableHighlightingElevated, withBlock.EnableHighlightingCriticalProcess, withBlock.EnableHighlightingOwnedProcess, withBlock.EnableHighlightingSystemProcess, withBlock.EnableHighlightingServiceProcess);
            cProcess.SetHighlightingsColor(withBlock.HighlightingColorBeingDebugged, withBlock.HighlightingColorJobProcess, withBlock.HighlightingColorElevatedProcess, withBlock.HighlightingColorCriticalProcess, withBlock.HighlightingColorOwnedProcess, withBlock.HighlightingColorSystemProcess, withBlock.HighlightingColorServiceProcess);
        }
    }

    // Display columns of a listview (previously saved)
    public static void LoadListViewColumns(customLV lv, string name)
    {


        // Here is an example of column description :
        // col1?width1?index1?alignment1$col2?width2?index2?alignment2$...
        string s = "";
        try
        {
            s = System.Convert.ToString(My.MySettingsProperty.Settings[name]);
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
        }

        if (s == null || s.Length < 3)
        {
            Trace.WriteLine("could not read column configuration for a listview" + Constants.vbNewLine + name + "  " + getColumnDesc(lv));
            return;
        }

        lv.BeginUpdate();
        lv.ReorganizeColumns = true;
        lv.Columns.Clear();

        string[] res = Strings.Split(s, "$");
        foreach (string column in res)
        {
            if (Strings.Len(column) > 0)
            {
                string[] obj = Strings.Split(column, "?");
                ColumnHeader col = lv.Columns.Add(obj[0], System.Convert.ToInt32(Conversion.Val((obj[1]))));
                if (obj.Length < 4)
                    col.TextAlign = HorizontalAlignment.Left;
                else
                    try
                    {
                        col.TextAlign = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), obj[3]);
                    }
                    catch (Exception ex)
                    {
                        col.TextAlign = HorizontalAlignment.Left;
                    }
            }
        }

        var loopTo = lv.Columns.Count - 1;
        for (int u = 0; u <= loopTo; u++)
        {
            foreach (string column in res)
            {
                string[] obj = Strings.Split(column, "?");
                if (lv.Columns[u].Text == obj[0])
                {
                    lv.Columns[u].DisplayIndex = System.Convert.ToInt32(Conversion.Val(obj[2]));
                    break;
                }
            }
        }

        lv.ReorganizeColumns = false;
        lv.EndUpdate();
    }

    // Save columns list of a listview
    public static void SaveListViewColumns(ListView lv, string name)
    {
        string s = "";

        foreach (ColumnHeader it in lv.Columns)
            s += it.Text.Replace("< ", "").Replace("> ", "") + "?" + it.Width.ToString() + "?" + it.DisplayIndex.ToString() + "?" + it.TextAlign.ToString() + "$";

        My.MySettingsProperty.Settings[name] = s;
    }

    // Load position & size of a form
    public static void LoadFormPositionAndSize(Form form, string name)
    {
        // Example : X|Y|W|H
        if (My.MySettingsProperty.Settings.RememberPosAndSize)
        {
            try
            {
                string value = System.Convert.ToString(My.MySettingsProperty.Settings[name]);
                string[] b = value.Split(System.Convert.ToChar("|"));
                int[] bb = new[] { int.Parse(b[0]), int.Parse(b[1]), int.Parse(b[2]), int.Parse(b[3]) };
                if (bb[0] + bb[1] + bb[2] + bb[3] == 0)
                {
                    // Then we center the form !
                    {
                        var withBlock = form;
                        withBlock.Left = (Screen.PrimaryScreen.Bounds.Width - withBlock.Width) / 2;
                        withBlock.Top = (Screen.PrimaryScreen.Bounds.Height - withBlock.Height) / 2;
                    }
                }
                else
                {
                    var withBlock1 = form;
                    withBlock1.Left = int.Parse(b[0]);
                    withBlock1.Top = int.Parse(b[1]);
                    withBlock1.Width = int.Parse(b[2]);
                    withBlock1.Height = int.Parse(b[3]);
                }
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }
    }

    // Save position & size of a form
    public static void SaveFormPositionAndSize(Form form, string name)
    {
        // Example : X|Y|W|H
        if (form != null)
        {
            if (form.WindowState != FormWindowState.Minimized)
            {
                if (My.MySettingsProperty.Settings.RememberPosAndSize)
                {
                    try
                    {
                        string res = string.Format("{0}|{1}|{2}|{3}", form.Left.ToString(), form.Top.ToString(), form.Width.ToString(), form.Height.ToString());
                        My.MySettingsProperty.Settings[name] = res;
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }
                }
            }
        }
    }



    // ========================================
    // Private functions
    // ========================================

    // Get current configuration of columns of a listview
    // (only used for debug)
    private static string getColumnDesc(ListView lv)
    {
        string s = "";

        foreach (ColumnHeader it in lv.Columns)
            s += it.Text.Replace("< ", "").Replace("> ", "") + "?" + it.Width.ToString() + "$";

        return s;
    }
}

