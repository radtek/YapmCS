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
using System.Text;
using Native.Objects;

public class cWindow : cGeneralObject
{
    private windowInfos _windowInfos;
    private static cWindowConnection __connection;

    private static cWindowConnection _connection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __connection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__connection != null)
            {
            }

            __connection = value;
            if (__connection != null)
            {
            }
        }
    }

    private string _oldCaption;


    public static cWindowConnection Connection
    {
        get
        {
            return _connection;
        }
        set
        {
            _connection = value;
        }
    }



    public cWindow(ref windowInfos infos)
    {
        _windowInfos = infos;
        _connection = Connection;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.Window;
    }

    // This constructor should NOT be used to get informations of a window, has
    // it creates only an instance of cWindow with 'handle' information.
    // It is used to call instance.Close(), instance.Show().... etc., rather
    // than call cWindow.SharedClose(hWnd), cWindow.SharedShow(hWnd)...
    public cWindow(IntPtr handle)
    {
        _windowInfos = new windowInfos(0, 0, handle, "");
    }



    public windowInfos Infos
    {
        get
        {
            return _windowInfos;
        }
    }



    public bool Visible
    {
        set
        {
            if (value)
                Show();
            else
                Hide();
        }
    }
    public byte Opacity
    {
        set
        {
            SetOpacity(value);
        }
    }
    public bool Enabled
    {
        set
        {
            SetEnabled(value);
        }
    }
    public System.Drawing.Icon SmallIcon
    {
        get
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                IntPtr i = Window.GetWindowSmallIconHandleByHandle(_windowInfos.Handle);
                if (i.IsNotNull())
                    return System.Drawing.Icon.FromHandle(i);
                else
                    return null;
            }
            else
                return null;
        }
    }
    public string Caption
    {
        get
        {
            if (this.IsKilledItem == false)
            {
                _oldCaption = this.Infos.Caption;
                return _oldCaption;
            }
            else
                return _oldCaption;
        }
        set
        {
            SetCaption(value);
        }
    }


    // Merge infos
    public void Refresh()
    {
        RefreshSpecialInformations();
    }


    private void RefreshSpecialInformations()
    {
        switch (_connection.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    break;
                }

            case cConnection.TypeOfConnection.LocalConnection:
                {
                    // Local and sync
                    this.Infos.SetNonFixedInfos(ref asyncCallbackWindowGetNonFixedInfos.ProcessAndReturnLocal(this.Infos.Handle));
                    break;
                }
        }
    }



    private void actionDone(bool Success, Native.Api.Enums.AsyncWindowAction action, IntPtr handle, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not " + action.ToString() + " (window = 0x" + handle.ToString("x") + ") : " + msg);
        RemovePendingTask(actionNumber);
    }

    private asyncCallbackWindowAction _theAction;

    public int Close()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Close, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool Flash()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Flash, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool StopFlashing()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.StopFlashing, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public int BringToFront(bool value)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.BringToFront, this.Infos.Handle, System.Convert.ToInt32(value), 0, 0, newAction));
    }
    public int SetAsForegroundWindow()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetAsForegroundWindow, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public int SetAsActiveWindow()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetAsActiveWindow, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool Minimize()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Minimize, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool Maximize()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Maximize, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool Show()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Show, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool Hide()
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.Hide, this.Infos.Handle, 0, 0, 0, newAction));
    }
    public bool SetPositions(Native.Api.NativeStructs.Rect r)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetPosition, this.Infos.Handle, 0, 0, 0, newAction, r));
    }
    public int SendMessage(int msg, int param1, int param2)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SendMessage, this.Infos.Handle, msg, param1, param2, newAction));
    }
    private int SetEnabled(bool value)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetEnabled, this.Infos.Handle, System.Convert.ToInt32(value), 0, 0, newAction));
    }
    private int SetOpacity(byte value)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetOpacity, this.Infos.Handle, System.Convert.ToInt32(value), 0, 0, newAction));
    }
    private int SetCaption(string st)
    {
        if (_theAction == null)
            _theAction = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(actionDone), ref _connection);
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_theAction.Process());
        int newAction = cGeneralObject.GetActionCount();
        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackWindowAction.poolObj(Native.Api.Enums.AsyncWindowAction.SetCaption, this.Infos.Handle, 0, 0, 0, newAction, ss: st));
    }



    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return windowInfos.GetAvailableProperties(includeFirstProp, sorted);
    }

    // Retrieve informations by its name
    public override string GetInformation(string info)
    {
        string res = Program.NO_INFO_RETRIEVED;

        if (info == "ObjectCreationDate")
            res = _objectCreationDate.ToLongDateString() + " -- " + _objectCreationDate.ToLongTimeString();
        else if (info == "PendingTaskCount")
            res = PendingTaskCount.ToString();

        switch (info)
        {
            case "Name":
            case "Caption":
                {
                    res = this.Caption;
                    break;
                }

            case "Handle":
            case "Id":
                {
                    res = this.Infos.Handle.ToString();
                    break;
                }

            case "Process":
                {
                    res = this.Infos.ProcessId.ToString() + " -- " + this.Infos.ProcessName;
                    break;
                }

            case "IsTask":
                {
                    res = this.Infos.IsTask.ToString();
                    break;
                }

            case "Enabled":
                {
                    res = this.Infos.Enabled.ToString();
                    break;
                }

            case "Visible":
                {
                    res = this.Infos.Visible.ToString();
                    break;
                }

            case "ThreadId":
                {
                    res = this.Infos.ThreadId.ToString();
                    break;
                }

            case "Opacity":
                {
                    res = this.Infos.Opacity.ToString();
                    break;
                }

            case "Left":
                {
                    res = this.Infos.Left.ToString();
                    break;
                }

            case "Height":
                {
                    res = this.Infos.Height.ToString();
                    break;
                }

            case "Top":
                {
                    res = this.Infos.Top.ToString();
                    break;
                }

            case "Width":
                {
                    res = this.Infos.Width.ToString();
                    break;
                }
        }

        return res;
    }
    public override bool GetInformation(string info, ref string res)
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

        ' Old values (from last refresh)
        Static _old_ObjectCreationDate As String = ""

 */
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
        Static _old_PendingTaskCount As String = ""

 */
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
        Static _old_Name As String = ""

 */
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
        Static _old_Handle As String = ""

 */
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
        Static _old_Process As String = ""

 */
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
        Static _old_IsTask As String = ""

 */
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
        Static _old_Enabled As String = ""

 */
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
        Static _old_Visible As String = ""

 */
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
        Static _old_ThreadId As String = ""

 */
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
        Static _old_Opacity As String = ""

 */
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
        Static _old_Left As String = ""

 */
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
        Static _old_Height As String = ""

 */
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
        Static _old_Top As String = ""

 */
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
        Static _old_Width As String = ""

 */
        bool hasChanged = true;

        if (info == "ObjectCreationDate")
        {
            res = _objectCreationDate.ToLongDateString() + " -- " + _objectCreationDate.ToLongTimeString();
            if (res == _old_ObjectCreationDate)
                hasChanged = false;
            else
            {
                _old_ObjectCreationDate = res;
                return true;
            }
        }
        else if (info == "PendingTaskCount")
        {
            res = PendingTaskCount.ToString();
            if (res == _old_PendingTaskCount)
                hasChanged = false;
            else
            {
                _old_PendingTaskCount = res;
                return true;
            }
        }

        switch (info)
        {
            case "Name":
            case "Caption":
                {
                    res = this.Caption;
                    if (res == _old_Name)
                        hasChanged = false;
                    else
                        _old_Name = res;
                    break;
                }

            case "Handle":
            case "Id":
                {
                    res = this.Infos.Handle.ToString();
                    if (res == _old_Handle)
                        hasChanged = false;
                    else
                        _old_Handle = res;
                    break;
                }

            case "Process":
                {
                    res = this.Infos.ProcessId.ToString() + " -- " + this.Infos.ProcessName;
                    if (res == _old_Process)
                        hasChanged = false;
                    else
                        _old_Process = res;
                    break;
                }

            case "IsTask":
                {
                    res = this.Infos.IsTask.ToString();
                    if (res == _old_IsTask)
                        hasChanged = false;
                    else
                        _old_IsTask = res;
                    break;
                }

            case "Enabled":
                {
                    res = this.Infos.Enabled.ToString();
                    if (res == _old_Enabled)
                        hasChanged = false;
                    else
                        _old_Enabled = res;
                    break;
                }

            case "Visible":
                {
                    res = this.Infos.Visible.ToString();
                    if (res == _old_Visible)
                        hasChanged = false;
                    else
                        _old_Visible = res;
                    break;
                }

            case "ThreadId":
                {
                    res = this.Infos.ThreadId.ToString();
                    if (res == _old_ThreadId)
                        hasChanged = false;
                    else
                        _old_ThreadId = res;
                    break;
                }

            case "Opacity":
                {
                    res = this.Infos.Opacity.ToString();
                    if (res == _old_Opacity)
                        hasChanged = false;
                    else
                        _old_Opacity = res;
                    break;
                }

            case "Left":
                {
                    res = this.Infos.Left.ToString();
                    if (res == _old_Left)
                        hasChanged = false;
                    else
                        _old_Left = res;
                    break;
                }

            case "Height":
                {
                    res = this.Infos.Height.ToString();
                    if (res == _old_Height)
                        hasChanged = false;
                    else
                        _old_Height = res;
                    break;
                }

            case "Top":
                {
                    res = this.Infos.Top.ToString();
                    if (res == _old_Top)
                        hasChanged = false;
                    else
                        _old_Top = res;
                    break;
                }

            case "Width":
                {
                    res = this.Infos.Width.ToString();
                    if (res == _old_Width)
                        hasChanged = false;
                    else
                        _old_Width = res;
                    break;
                }
        }

        return hasChanged;
    }




    // Return ProcessId of ForegroundWindow
    public static int LocalGetForegroundAppProcessId()
    {
        IntPtr hWnd = Window.GetForegroundWindow();
        return Window.GetProcessIdFromWindowHandle(hWnd);
    }

    // Close
    // MUST BE USE FOR OWNED WINDOWS ONLY
    // Because SendMessage is synchron and may cause thread to be hung
    public static bool LocalClose(IntPtr handle)
    {
        return Window.CloseWindowByHandle(handle);
    }

    // ShowWindowForeground
    public static bool LocalShowWindowForeground(IntPtr handle)
    {
        return Window.SetForegroundWindowByHandle(handle);
    }
}

