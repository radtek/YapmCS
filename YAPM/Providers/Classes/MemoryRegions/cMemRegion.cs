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

public class cMemRegion : cGeneralObject
{
    private memRegionInfos _memInfos;
    private static cMemRegionConnection __connection;

    private static cMemRegionConnection _connection
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

    private string _moduleFileName;


    public static cMemRegionConnection Connection
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



    public cMemRegion(ref memRegionInfos infos)
    {
        _memInfos = infos;
        _connection = Connection;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.MemoryRegion;

        if (_connection != null)
        {
            if (_connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection)
            {
                if (infos.Type == Native.Api.NativeEnums.MemoryType.Image)
                    _moduleFileName = getModuleName(infos.BaseAddress);
                else if (infos.Type == Native.Api.NativeEnums.MemoryType.Mapped)
                {
                    if (infos.State == Native.Api.NativeEnums.MemoryState.Commit)
                        _moduleFileName = getModuleName(infos.BaseAddress);
                }
            }
        }
    }

    // Return the name of the mapped file
    private string getModuleName(IntPtr ad)
    {
        StringBuilder sb = new StringBuilder(1024);
        IntPtr _h = Native.Objects.Process.GetProcessHandleById(Infos.ProcessId, Native.Security.ProcessAccess.QueryInformation | Native.Security.ProcessAccess.VmRead);

        if (_h.IsNotNull())
        {
            int leng = Native.Api.NativeFunctions.GetMappedFileName(_h, ad, sb, sb.Capacity);
            Native.Api.NativeFunctions.CloseHandle(_h);

            if (leng > 0)
            {
                string file = sb.ToString(0, leng);
                if (file.StartsWith(@"\"))
                    file = Common.Misc.DeviceDriveNameToDosDriveName(file);
                return file;
            }
            else
                return Program.NO_INFO_RETRIEVED;
        }
        else
            return Program.NO_INFO_RETRIEVED;
    }



    public memRegionInfos Infos
    {
        get
        {
            return _memInfos;
        }
    }
    public string ModuleFileName
    {
        get
        {
            return _moduleFileName;
        }
    }



    // Release/decommit mem region
    private asyncCallbackMemRegionFree _freeMem;
    public int Release()
    {
        if (_freeMem == null)
            _freeMem = new asyncCallbackMemRegionFree(new asyncCallbackMemRegionFree.HasFreed(freedMemoryDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_freeMem.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionFree.poolObj(this.Infos.ProcessId, this.Infos.BaseAddress, this.Infos.RegionSize, Native.Api.NativeEnums.MemoryState.Release, newAction));
    }
    public int Decommit()
    {
        if (_freeMem == null)
            _freeMem = new asyncCallbackMemRegionFree(new asyncCallbackMemRegionFree.HasFreed(freedMemoryDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_freeMem.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionFree.poolObj(this.Infos.ProcessId, this.Infos.BaseAddress, this.Infos.RegionSize, Native.Api.NativeEnums.MemoryState.Decommit, newAction));

        AddPendingTask(newAction, ref t);
    }
    private void freedMemoryDone(bool Success, int pid, IntPtr address, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not free memory (" + address.ToString("x") + ")" + " : " + msg);
        RemovePendingTask(actionNumber);
    }

    // Dump
    private asyncCallbackMemRegionDump _dump;
    public int DumpToFile(string file)
    {
        if (_dump == null)
            _dump = new asyncCallbackMemRegionDump(new asyncCallbackMemRegionDump.HasDumped(DumpDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_dump.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionDump.poolObj(this.Infos.ProcessId, this.Infos.BaseAddress, file, this.Infos.RegionSize, newAction));
    }
    private void DumpDone(bool Success, string file, IntPtr address, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not dump memory (" + address.ToString("x") + ") to file " + file + ": " + msg);
        RemovePendingTask(actionNumber);
    }

    // Change protection type
    private asyncCallbackMemRegionChangeProtection _changeProtec;
    public int ChangeProtectionType(Native.Api.NativeEnums.MemoryProtectionType newProtection)
    {
        if (_changeProtec == null)
            _changeProtec = new asyncCallbackMemRegionChangeProtection(new asyncCallbackMemRegionChangeProtection.HasChangedProtection(ChangedProtectionDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_changeProtec.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionChangeProtection.poolObj(this.Infos.ProcessId, this.Infos.BaseAddress, this.Infos.RegionSize, newProtection, newAction));
    }
    private void ChangedProtectionDone(bool Success, int pid, IntPtr address, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not change memory protection (" + address.ToString("x") + ")" + " : " + msg);
        RemovePendingTask(actionNumber);
    }



    private static asyncCallbackMemRegionFree _sharedFree;
    public static int SharedLRFree(int pid, IntPtr address, IntPtr size, Native.Api.NativeEnums.MemoryState type)
    {
        if (_sharedFree == null)
            _sharedFree = new asyncCallbackMemRegionFree(new asyncCallbackMemRegionFree.HasFreed(freedSharedDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_sharedFree.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionFree.poolObj(pid, address, size, type, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void freedSharedDone(bool Success, int pid, IntPtr address, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not free memory region (" + address.ToString("x") + ")" + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }

    private static asyncCallbackMemRegionChangeProtection _sharedProtection;
    public static int SharedLRChangeProtection(int pid, IntPtr address, IntPtr size, Native.Api.NativeEnums.MemoryProtectionType type)
    {
        if (_sharedProtection == null)
            _sharedProtection = new asyncCallbackMemRegionChangeProtection(new asyncCallbackMemRegionChangeProtection.HasChangedProtection(changedSharedProtectionDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_sharedProtection.Process());
        int newAction = cGeneralObject.GetActionCount();

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackMemRegionChangeProtection.poolObj(pid, address, size, type, newAction));

        AddSharedPendingTask(newAction, ref t);
    }
    private static void changedSharedProtectionDone(bool Success, int pid, IntPtr address, string msg, int actionNumber)
    {
        if (Success == false)
            Misc.ShowError("Could not change memory protection (" + address.ToString("x") + ")" + " : " + msg);
        RemoveSharedPendingTask(actionNumber);
    }


    // Merge current infos and new infos
    public void Merge(ref memRegionInfos Thr)
    {
        _memInfos.Merge(ref Thr);
    }


    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return memRegionInfos.GetAvailableProperties(includeFirstProp, sorted);
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
            case "Type":
                {
                    res = this.Infos.Type.ToString();
                    break;
                }

            case "Protection":
                {
                    res = GetProtectionType(this.Infos.Protection);
                    break;
                }

            case "State":
                {
                    res = this.Infos.State.ToString();
                    break;
                }

            case "Name":
                {
                    res = this.Infos.Name;
                    break;
                }

            case "Address":
                {
                    res = "0x" + this.Infos.BaseAddress.ToString("x");
                    break;
                }

            case "Size":
                {
                    res = getSizeString();
                    break;
                }

            case "File":
                {
                    res = _moduleFileName;
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
        Static _old_Type As String = ""

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
        Static _old_Protection As String = ""

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
        Static _old_Address As String = ""

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
        Static _old_Size As String = ""

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
        Static _old_File As String = ""

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
            case "Type":
                {
                    res = this.Infos.Type.ToString();
                    if (res == _old_Type)
                        hasChanged = false;
                    else
                        _old_Type = res;
                    break;
                }

            case "Protection":
                {
                    res = GetProtectionType(this.Infos.Protection);
                    if (res == _old_Protection)
                        hasChanged = false;
                    else
                        _old_Protection = res;
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

            case "Name":
                {
                    res = this.Infos.Name;
                    if (res == _old_Name)
                        hasChanged = false;
                    else
                        _old_Name = res;
                    break;
                }

            case "Address":
                {
                    res = "0x" + this.Infos.BaseAddress.ToString("x");
                    if (res == _old_Address)
                        hasChanged = false;
                    else
                        _old_Address = res;
                    break;
                }

            case "Size":
                {
                    res = getSizeString();
                    if (res == _old_Size)
                        hasChanged = false;
                    else
                        _old_Size = res;
                    break;
                }

            case "File":
                {
                    res = _moduleFileName;
                    if (res == _old_File)
                        hasChanged = false;
                    else
                        _old_File = res;
                    break;
                }
        }

        return hasChanged;
    }

    // Get size as a string
    private string getSizeString()
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
        Static oldSize As IntPtr = Me.Infos.RegionSize

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
        Static _sizeStr As String = Common.Misc.GetFormatedSize(Me.Infos.RegionSize)

 */
        if (!(this.Infos.RegionSize == oldSize))
        {
            _sizeStr = Common.Misc.GetFormatedSize(this.Infos.RegionSize);
            oldSize = this.Infos.RegionSize;
        }

        return _sizeStr;
    }

    // Get protection type as string
    internal static string GetProtectionType(Native.Api.NativeEnums.MemoryProtectionType protec)
    {
        string s = "";

        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.Execute) == Native.Api.NativeEnums.MemoryProtectionType.Execute)
            s += "E/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.ExecuteRead) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteRead)
            s += "ERO/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.ExecuteReadWrite) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteReadWrite)
            s += "ERW/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.ExecuteWriteCopy) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteWriteCopy)
            s += "EWC/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.Guard) == Native.Api.NativeEnums.MemoryProtectionType.Guard)
            s += "G/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.NoAccess) == Native.Api.NativeEnums.MemoryProtectionType.NoAccess)
            s += "NA/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.NoCache) == Native.Api.NativeEnums.MemoryProtectionType.NoCache)
            s += "NC";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.ReadOnly) == Native.Api.NativeEnums.MemoryProtectionType.ReadOnly)
            s += "RO/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.ReadWrite) == Native.Api.NativeEnums.MemoryProtectionType.ReadWrite)
            s += "RW/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.WriteCombine) == Native.Api.NativeEnums.MemoryProtectionType.WriteCombine)
            s += "WCOMB/";
        if ((protec & Native.Api.NativeEnums.MemoryProtectionType.WriteCopy) == Native.Api.NativeEnums.MemoryProtectionType.WriteCopy)
            s += "WC/";

        if (s.Length > 0)
            s = s.Substring(0, s.Length - 1);
        else
            s = Program.NO_INFO_RETRIEVED;

        return s;
    }
}

