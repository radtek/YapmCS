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

public class cThread : cGeneralObject
{
    private threadInfos _threadInfos;
    private static cThreadConnection __connection;

    private static cThreadConnection _connection
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

    private IntPtr _handleQueryInfo;

    private static bool _hlSuspendedThread;
    private static Color _hlSuspendedThreadColor;


    public static cThreadConnection Connection
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



    public cThread(ref threadInfos infos, bool getPriorityInfo = false)
    {
        _threadInfos = infos;
        _connection = Connection;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.Thread;
        // Get a handle if local
        if (_connection != null)
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                _handleQueryInfo = Native.Objects.Thread.GetThreadHandle(infos.Id, Native.Security.ThreadAccess.QueryInformation);
                if (getPriorityInfo)
                    // Here we get priority (used when YAPM is used as a server)
                    infos.SetPriority(Native.Objects.Thread.GetThreadPriorityByHandle(_handleQueryInfo));
            }
        }
    }

    ~cThread()
    {
        // Close a handle if local
        if (_connection != null)
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                if (_handleQueryInfo.IsNotNull())
                    Native.Objects.General.CloseHandle(_handleQueryInfo);
            }
        }
    }



    public threadInfos Infos
    {
        get
        {
            return _threadInfos;
        }
    }

    public ThreadPriorityLevel PriorityMod
    {
        get
        {
            if (_handleQueryInfo.IsNotNull())
            {
                int priority = Native.Api.NativeFunctions.GetThreadPriority(_handleQueryInfo);
                return (ThreadPriorityLevel)priority;
            }
            else
                return this.Infos.Priority;
        }
    }


    // Merge current infos and new infos
    public void Merge(ref threadInfos Thr)
    {
        _threadInfos.Merge(ref Thr);
        RefreshSpecialInformations();
    }


    // Refresh some non fixed infos
    // For now IT IS NOT ASYNC
    // Because create ~50 threads/sec is not really cool
    // TOCHANGE
    private asyncCallbackThreadGetOtherInfos _asyncNonFixed;

    private asyncCallbackThreadGetOtherInfos asyncNonFixed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _asyncNonFixed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_asyncNonFixed != null)
            {
                _asyncNonFixed.GatheredInfos -= nonFixedInfosGathered;
            }

            _asyncNonFixed = value;
            if (_asyncNonFixed != null)
            {
                _asyncNonFixed.GatheredInfos += nonFixedInfosGathered;
            }
        }
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

            default:
                {
                    // Local
                    if (asyncNonFixed == null)
                        asyncNonFixed = new asyncCallbackThreadGetOtherInfos(this.Infos.Id, ref _connection, _handleQueryInfo);
                    asyncNonFixed.Process();
                    break;
                }
        }
    }
    private void nonFixedInfosGathered(asyncCallbackThreadGetOtherInfos.TheseInfos infos)
    {
        this.Infos.AffinityMask = infos.affinity;
    }



    // Set priority
    private asyncCallbackThreadSetPriority _setPriority;
    public int SetPriority(System.Diagnostics.ThreadPriorityLevel level)
    {
        if (_setPriority == null)
            _setPriority = new asyncCallbackThreadSetPriority(new asyncCallbackThreadSetPriority.HasSetPriority(setPriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_setPriority.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadSetPriority.poolObj(this.Infos.Id, level, newAction));
    }
    private void setPriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }


    // Kill a thread
    private asyncCallbackThreadKill _killThread;
    public int ThreadTerminate()
    {
        if (_killThread == null)
            _killThread = new asyncCallbackThreadKill(new asyncCallbackThreadKill.HasKilled(killDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killThread.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadKill.poolObj(this.Infos.Id, newAction));
    }
    private void killDone(bool Success, int id, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill thread " + id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Decrease priority
    private asyncCallbackThreadDecreasePriority _decP;
    public int DecreasePriority()
    {
        if (_decP == null)
            _decP = new asyncCallbackThreadDecreasePriority(new asyncCallbackThreadDecreasePriority.HasDecreasedPriority(decreasePriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_decP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadDecreasePriority.poolObj(this.Infos.Id, this.PriorityMod, newAction));
    }
    private void decreasePriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Increase priority
    private asyncCallbackThreadIncreasePriority _incP;
    public int IncreasePriority()
    {
        if (_incP == null)
            _incP = new asyncCallbackThreadIncreasePriority(new asyncCallbackThreadIncreasePriority.HasIncreasedPriority(increasePriorityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_incP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadIncreasePriority.poolObj(this.Infos.Id, this.PriorityMod, newAction));
    }
    private void increasePriorityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set priority to thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Suspend a process
    private asyncCallbackThreadSuspend _suspP;
    public int ThreadSuspend()
    {
        if (_suspP == null)
            _suspP = new asyncCallbackThreadSuspend(new asyncCallbackThreadSuspend.HasSuspended(suspendDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_suspP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadSuspend.poolObj(this.Infos.Id, newAction));
    }
    private void suspendDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not suspend thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Resume a process
    private asyncCallbackThreadResume _resumeP;
    public int ThreadResume()
    {
        if (_resumeP == null)
            _resumeP = new asyncCallbackThreadResume(new asyncCallbackThreadResume.HasResumed(resumeDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_resumeP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadResume.poolObj(this.Infos.Id, newAction));
    }
    private void resumeDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not resume thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Change affinity
    private asyncCallbackThreadSetAffinity _affinityP;
    public int SetAffinity(int affinity)
    {
        if (_affinityP == null)
            _affinityP = new asyncCallbackThreadSetAffinity(new asyncCallbackThreadSetAffinity.HasSetAffinity(setAffinityDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_affinityP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackThreadSetAffinity.poolObj(this.Infos.Id, affinity, newAction));
    }
    private void setAffinityDone(bool Success, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set affinity to thread " + this.Infos.Id.ToString() + " : " + msg);
        RemovePendingTask(actionNumber);
    }



    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return threadInfos.GetAvailableProperties(includeFirstProp, sorted);
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
            case "Priority":
                {
                    res = this.PriorityMod.ToString();
                    break;
                }

            case "State":
                {
                    res = this.Infos.State.ToString();
                    break;
                }

            case "WaitReason":
                {
                    res = this.Infos.WaitReason.ToString();
                    break;
                }

            case "ContextSwitchDelta":
                {
                    res = this.Infos.ContextSwitchDelta.ToString();
                    break;
                }

            case "CreateTime":
                {
                    if (this.Infos.CreateTime > 0)
                    {
                        DateTime ts = new DateTime(this.Infos.CreateTime);
                        res = ts.ToLongDateString() + " -- " + ts.ToLongTimeString();
                    }

                    break;
                }

            case "KernelTime":
                {
                    DateTime ts = new DateTime(this.Infos.KernelTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "UserTime":
                {
                    DateTime ts = new DateTime(this.Infos.UserTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "WaitTime":
                {
                    DateTime ts = new DateTime(this.Infos.WaitTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "TotalTime":
                {
                    DateTime ts = new DateTime(this.Infos.TotalTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    break;
                }

            case "StartAddress":
                {
                    res = "0x" + this.Infos.StartAddress.ToString("x");
                    break;
                }

            case "BasePriority":
                {
                    res = this.Infos.BasePriority.ToString();
                    break;
                }

            case "ContextSwitchCount":
                {
                    res = this.Infos.ContextSwitchCount.ToString();
                    break;
                }

            case "ProcessId":
                {
                    res = this.Infos.ProcessId.ToString();
                    break;
                }

            case "Id":
                {
                    res = this.Infos.Id.ToString();
                    break;
                }

            case "AffinityMask":
                {
                    res = this.Infos.AffinityMask.ToString();
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
        Static _old_Priority As String = ""

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
        Static _old_State As String = ""

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
        Static _old_WaitReason As String = ""

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
        Static _old_ContextSwitchDelta As String = ""

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
        Static _old_CreateTime As String = ""

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
        Static _old_KernelTime As String = ""

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
        Static _old_UserTime As String = ""

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
        Static _old_WaitTime As String = ""

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
        Static _old_TotalTime As String = ""

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
        Static _old_StartAddress As String = ""

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
        Static _old_BasePriority As String = ""

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
        Static _old_ContextSwitchCount As String = ""

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
        Static _old_ProcessId As String = ""

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
        Static _old_Id As String = ""

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
        Static _old_AffinityMask As String = ""

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
            case "Priority":
                {
                    res = this.PriorityMod.ToString();
                    if (res == _old_Priority)
                        hasChanged = false;
                    else
                        _old_Priority = res;
                    break;
                }

            case "State":
                {
                    res = this.Infos.State.ToString();
                    if (res == _old_State)
                        hasChanged = false;
                    else
                        _old_State = res;
                    break;
                }

            case "WaitReason":
                {
                    res = this.Infos.WaitReason.ToString();
                    if (res == _old_WaitReason)
                        hasChanged = false;
                    else
                        _old_WaitReason = res;
                    break;
                }

            case "ContextSwitchDelta":
                {
                    res = this.Infos.ContextSwitchDelta.ToString();
                    if (res == _old_ContextSwitchDelta)
                        hasChanged = false;
                    else
                        _old_ContextSwitchDelta = res;
                    break;
                }

            case "CreateTime":
                {
                    if (this.Infos.CreateTime > 0)
                    {
                        DateTime ts = new DateTime(this.Infos.CreateTime);
                        res = ts.ToLongDateString() + " -- " + ts.ToLongTimeString();
                    }
                    if (res == _old_CreateTime)
                        hasChanged = false;
                    else
                        _old_CreateTime = res;
                    break;
                }

            case "KernelTime":
                {
                    DateTime ts = new DateTime(this.Infos.KernelTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_KernelTime)
                        hasChanged = false;
                    else
                        _old_KernelTime = res;
                    break;
                }

            case "UserTime":
                {
                    DateTime ts = new DateTime(this.Infos.UserTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_UserTime)
                        hasChanged = false;
                    else
                        _old_UserTime = res;
                    break;
                }

            case "WaitTime":
                {
                    DateTime ts = new DateTime(this.Infos.WaitTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_WaitTime)
                        hasChanged = false;
                    else
                        _old_WaitTime = res;
                    break;
                }

            case "TotalTime":
                {
                    DateTime ts = new DateTime(this.Infos.TotalTime);
                    res = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond);
                    if (res == _old_TotalTime)
                        hasChanged = false;
                    else
                        _old_TotalTime = res;
                    break;
                }

            case "StartAddress":
                {
                    res = "0x" + this.Infos.StartAddress.ToString("x");
                    if (res == _old_StartAddress)
                        hasChanged = false;
                    else
                        _old_StartAddress = res;
                    break;
                }

            case "BasePriority":
                {
                    res = System.Convert.ToInt32(this.Infos.BasePriority).ToString(); // threadInfos.getPriorityClass(Me.Infos.BasePriority).ToString
                    if (res == _old_BasePriority)
                        hasChanged = false;
                    else
                        _old_BasePriority = res;
                    break;
                }

            case "ContextSwitchCount":
                {
                    res = this.Infos.ContextSwitchCount.ToString();
                    if (res == _old_ContextSwitchCount)
                        hasChanged = false;
                    else
                        _old_ContextSwitchCount = res;
                    break;
                }

            case "ProcessId":
                {
                    res = this.Infos.ProcessId.ToString();
                    if (res == _old_ProcessId)
                        hasChanged = false;
                    else
                        _old_ProcessId = res;
                    break;
                }

            case "Id":
                {
                    res = this.Infos.Id.ToString();
                    if (res == _old_Id)
                        hasChanged = false;
                    else
                        _old_Id = res;
                    break;
                }

            case "AffinityMask":
                {
                    res = this.Infos.AffinityMask.ToString();
                    if (res == _old_AffinityMask)
                        hasChanged = false;
                    else
                        _old_AffinityMask = res;
                    break;
                }
        }

        return hasChanged;
    }




    // Set highlightings
    public static void SetHighlightings(bool suspendedThreads)
    {
        _hlSuspendedThread = suspendedThreads;
    }
    public static void SetHighlightingsColor(Color suspendedThreads)
    {
        _hlSuspendedThreadColor = suspendedThreads;
    }

    // Return backcolor of current item
    public override System.Drawing.Color GetBackColor()
    {
        if (_hlSuspendedThread && this.Infos.WaitReason == Native.Api.NativeEnums.KwaitReason.Suspended)
            return _hlSuspendedThreadColor;

        return base.GetBackColor();
    }
}

