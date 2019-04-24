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
using Native.Api.Enums;

public class cSearchItem : cGeneralObject
{
    private searchInfos _info;
    private static cSearchConnection __connection;

    private static cSearchConnection _connection
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

    public static cSearchConnection Connection
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



    public cSearchItem(ref searchInfos item)
    {
        _info = item;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.SearchItem;
    }



    public searchInfos Infos
    {
        get
        {
            return _info;
        }
    }




    // Close/Terminate/Unload
    private asyncCallbackHandleUnload _closeH;
    private asyncCallbackWindowAction _closeW;
    private asyncCallbackModuleUnload _closeM;
    private asyncCallbackServiceStop _closeS;
    private asyncCallbackProcKill _closeP;
    public int CloseTerminate()
    {
        switch (Infos.Type)
        {
            case Native.Api.Enums.GeneralObjectType.Handle:
                {
                    // Close a handle
                    if (_closeH == null)
                        _closeH = new asyncCallbackHandleUnload(new asyncCallbackHandleUnload.HasUnloadedHandle(unloadHandleDone), ref cHandle.Connection);

                    System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeH.Process());
                    int newAction = cGeneralObject.GetActionCount();

                    AddPendingTask(newAction, ref t);
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Module:
                {
                    // Unload a module
                    if (_closeM == null)
                        _closeM = new asyncCallbackModuleUnload(new asyncCallbackModuleUnload.HasUnloadedModule(unloadModuleDone), ref cModule.Connection);

                    System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeM.Process());
                    int newAction = cGeneralObject.GetActionCount();

                    AddPendingTask(newAction, ref t);
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Process:
                {
                    // Kill a process
                    if (_closeP == null)
                        _closeP = new asyncCallbackProcKill(new asyncCallbackProcKill.HasKilled(killDone), ref cProcess.Connection);

                    System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeP.Process());
                    int newAction = cGeneralObject.GetActionCount();

                    AddPendingTask(newAction, ref t);
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Service:
                {
                    // Stop service
                    if (_closeS == null)
                        _closeS = new asyncCallbackServiceStop(new asyncCallbackServiceStop.HasStopped(stopServiceDone), ref cService.Connection);

                    System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeS.Process());
                    int newAction = cGeneralObject.GetActionCount();

                    AddPendingTask(newAction, ref t);
                    break;
                }

            case Native.Api.Enums.GeneralObjectType.Window:
                {
                    // Close window
                    if (_closeW == null)
                        _closeW = new asyncCallbackWindowAction(new asyncCallbackWindowAction.HasMadeAction(windowActionDone), ref cWindow.Connection);
                    System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeW.Process());
                    int newAction = cGeneralObject.GetActionCount();

                    AddPendingTask(newAction, ref t);
                    break;
                }
        }
    }
    private void unloadHandleDone(bool Success, int pid, IntPtr handle, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not unload handle " + handle.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }
    private void unloadModuleDone(bool Success, int pid, string name, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not unload module " + name + " : " + msg);
        RemovePendingTask(actionNumber);
    }
    private void killDone(bool Success, int pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill process (" + pid.ToString() + ") : " + msg);
        RemovePendingTask(actionNumber);
    }
    private void stopServiceDone(bool Success, string name, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not stop service " + name + " : " + msg);
        RemovePendingTask(actionNumber);
    }
    private void windowActionDone(bool Success, Native.Api.Enums.AsyncWindowAction action, IntPtr handle, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not " + action.ToString() + " (window = 0x" + handle.ToString("x") + ") : " + msg);
        RemovePendingTask(actionNumber);
    }



    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return searchInfos.GetAvailableProperties(includeFirstProp, sorted);
    }

    // Get information as a string
    public override string GetInformation(string info)
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

        Static _owner As String = Nothing

 */
        string res = Program.NO_INFO_RETRIEVED;
        switch (info)
        {
            case "Type":
                {
                    res = Infos.Type.ToString();
                    break;
                }

            case "Result":
                {
                    res = Infos.Result;
                    break;
                }

            case "Field":
                {
                    res = Infos.Field;
                    break;
                }

            case "Owner":
                {
                    if (_owner == null)
                        _owner = Infos.Owner;
                    return _owner;
                }
        }

        return res;
    }

    public override bool GetInformation(string info, ref string res)
    {
        res = this.GetInformation(info);
        return true;
    }
}

