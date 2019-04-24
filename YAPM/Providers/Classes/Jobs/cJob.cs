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
using System.Net;
using Native.Api;

public class cJob : cGeneralObject, IDisposable
{

    // Infos
    private jobInfos _jobInfos;

    private static cJobConnection __connection;

    private static cJobConnection _connection
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

    public static cJobConnection Connection
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



    public cJob(ref jobInfos infos)
    {
        _jobInfos = infos;
        _connection = Connection;
        _TypeOfObject = Enums.GeneralObjectType.Job;
    }
    private bool disposed = false;
    public new void Dispose()
    {
        Dispose(true);
        // This object will be cleaned up by the Dispose method.
        // Therefore, you should call GC.SupressFinalize to
        // take this object off the finalization queue 
        // and prevent finalization code for this object
        // from executing a second time.
        GC.SuppressFinalize(this);
    }
    private new void Dispose(bool disposing)
    {
        // Check to see if Dispose has already been called.
        if (!this.disposed)
        {
            // If disposing equals true, dispose all managed 
            // and unmanaged resources.
            if (disposing)
            {
            }

            // Note disposing has been done.
            disposed = true;
        }
    }



    public jobInfos Infos
    {
        get
        {
            return _jobInfos;
        }
    }



    // Create a job
    public static cJob CreateJobByName(string jobName)
    {
        return Native.Objects.Job.CreateJobByName(jobName);
    }

    // Get a job by its name
    public static cJob GetJobByName(string jobName)
    {
        foreach (jobInfos cJ in Native.Objects.Job.EnumerateJobs().Values)
        {
            if (cJ.Name == jobName)
                return new cJob(ref cJ);
        }
        return null;
    }

    // Return job a process (if any)
    public static cJob GetProcessJobById(int pid)
    {
        foreach (jobInfos cJ in Native.Objects.Job.EnumerateJobs().Values)
        {
            if (cJ.PidList.Contains(pid))
                return new cJob(ref cJ);
        }
        return null;
    }



    // Terminate job
    private static asyncCallbackJobTerminateJob _sharedTermJ;
    public static int SharedLRTerminateJob(string name)
    {
        if (_sharedTermJ == null)
            _sharedTermJ = new asyncCallbackJobTerminateJob(new asyncCallbackJobTerminateJob.HasTerminatedJob(sharedKillJobDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_sharedTermJ.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobTerminateJob.poolObj(name, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void sharedKillJobDone(bool Success, string jobName, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not kill job " + jobName + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }

    // Add a process to the job
    private static asyncCallbackJobAddProcess _addedShared;
    public static int SharedLRAddProcess(string jobName, int[] pids)
    {
        if (_addedShared == null)
            _addedShared = new asyncCallbackJobAddProcess(new asyncCallbackJobAddProcess.HasAddedProcessesToJob(sharedAddedJobDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_addedShared.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddSharedPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobAddProcess.poolObj(pids, jobName, newAction));
    }
    private static void sharedAddedJobDone(bool Success, int[] pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not add processes to job : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }

    // Set limits to the job
    private static asyncCallbackJobLimitsSetLimits _setLshared;
    public static int SharedLRSetLimits(string jobName, NativeStructs.JobObjectBasicUiRestrictions limit1, NativeStructs.JobObjectExtendedLimitInformation limit2)
    {
        if (_setLshared == null)
            _setLshared = new asyncCallbackJobLimitsSetLimits(new asyncCallbackJobLimitsSetLimits.HasSetLimits(sharedHasSetL), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_setLshared.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddSharedPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobLimitsSetLimits.poolObj(jobName, limit1, limit2, newAction));
    }
    private static void sharedHasSetL(bool Success, string jobName, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set limits to job " + jobName + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }



    // Add a process to the job
    private asyncCallbackJobAddProcess _addedP;
    public int AddProcess(int pid)
    {
        if (_addedP == null)
            _addedP = new asyncCallbackJobAddProcess(new asyncCallbackJobAddProcess.HasAddedProcessesToJob(addedProcessDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_addedP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        int[] pids;
        pids = new int[1];
        pids[0] = pid;
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobAddProcess.poolObj(pids, this.Infos.Name, newAction));
    }
    private void addedProcessDone(bool Success, int[] pid, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not add processes to job : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Terminate a job
    private asyncCallbackJobTerminateJob _killedJob;
    public int TerminateJob()
    {
        if (_killedJob == null)
            _killedJob = new asyncCallbackJobTerminateJob(new asyncCallbackJobTerminateJob.HasTerminatedJob(killJobDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killedJob.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobTerminateJob.poolObj(this.Infos.Name, newAction));
    }
    private void killJobDone(bool Success, string jobName, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not terminate job " + jobName + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Set limits to the job
    private asyncCallbackJobLimitsSetLimits _setL;
    public int SetLimits(NativeStructs.JobObjectBasicUiRestrictions limit1, NativeStructs.JobObjectExtendedLimitInformation limit2)
    {
        if (_setL == null)
            _setL = new asyncCallbackJobLimitsSetLimits(new asyncCallbackJobLimitsSetLimits.HasSetLimits(hasSetL), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_setL.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackJobLimitsSetLimits.poolObj(this.Infos.Name, limit1, limit2, newAction));
    }
    private void hasSetL(bool Success, string jobName, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not set limits to job " + jobName + " : " + msg);
        RemovePendingTask(actionNumber);
    }


    // Merge current infos and new infos
    public void Merge(ref jobInfos Thr)
    {
        _jobInfos.Merge(ref Thr);
    }



    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return jobInfos.GetAvailableProperties(includeFirstProp, sorted);
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
                {
                    res = this.Infos.Name;
                    break;
                }

            case "ProcessesCount":
                {
                    res = this.Infos.PidList.Count.ToString();
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
        Static _old_JobName As String = ""

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
        Static _old_JobId As String = ""

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
        Static _old_ProcessesCount As String = ""

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
                {
                    res = this.Infos.Name;
                    if (res == _old_JobName)
                        hasChanged = false;
                    else
                        _old_JobName = res;
                    break;
                }

            case "JobId":
                {
                    res = this.Infos.Name;
                    if (res == _old_JobId)
                        hasChanged = false;
                    else
                        _old_JobId = res;
                    break;
                }

            case "ProcessesCount":
                {
                    res = this.Infos.PidList.Count.ToString();
                    if (res == _old_ProcessesCount)
                        hasChanged = false;
                    else
                        _old_ProcessesCount = res;
                    break;
                }
        }

        return hasChanged;
    }
}

