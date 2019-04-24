// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// This file uses third-party pieces of code under GNU 
// GPL 3.0 license. See below for details
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
// 
// 
// This file uses some work under GNU GPL 3.0 license
// The definitions marked with <from PH> are from Process Hacker by Wj32.

using System.Drawing;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Native.Api
{
    public class NativeFunctions
    {


        // Public Delegate Function HookProc(ByVal code As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        public delegate int HookProcKbd(int code, IntPtr wParam, ref NativeStructs.KBDLLHookStruct lParam);
        public delegate int HookProcMouse(int code, IntPtr wParam, ref NativeStructs.MouseHookStruct lParam);
        public delegate int LowLevelKeyboardProc(int nCode, NativeEnums.WindowMessage wParam, [In()] NativeStructs.KBDLLHookStruct lParam);
        public delegate IntPtr LowLevelMouseProc(int code, NativeEnums.WindowMessage wParam, [In()] NativeStructs.MSLLHookStruct lParam);

        class _failedMemberConversionMarker1
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

#End Region

#Region "Interop (Windows dll)"

#Region "advapi32"

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True)> _
        Public Shared Function AdjustTokenPrivileges(<[In]()> ByVal TokenHandle As IntPtr, _
                <[In]()> <MarshalAs(UnmanagedType.Bool)> ByVal DisableAllPrivileges As Boolean, _
                <[In]()> <[Optional]()> ByRef NewState As TokenPrivileges, _
                <[In]()> ByVal BufferLength As Integer, _
                <Out()> <[Optional]()> ByVal PreviousState As IntPtr, _
                <Out()> <[Optional]()> ByVal ReturnLength As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        class _failedMemberConversionMarker2
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function ChangeServiceConfig(<[In]()> ByVal Service As IntPtr, _
                    <[In]()> ByVal ServiceType As ServiceType, _
                    <[In]()> ByVal StartType As ServiceStartType, _
                    <[In]()> ByVal ErrorControl As ServiceErrorControl, _
                    <[In]()> <[Optional]()> ByVal BinaryPath As String, _
                    <[In]()> <[Optional]()> ByVal LoadOrderGroup As String, _
                    <Out()> <[Optional]()> ByVal TagId As IntPtr, _
                    <[In]()> <[Optional]()> ByVal Dependencies As String, _
                    <[In]()> <[Optional]()> ByVal StartName As String, _
                    <[In]()> <[Optional]()> ByVal Password As String, _
                    <[In]()> <[Optional]()> ByVal DisplayName As String) As Boolean
        End Function

 */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static bool CloseServiceHandle([In()] IntPtr ServiceHandle)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static bool ControlService([In()] IntPtr Service, [In()] NativeEnums.ServiceControl Control, out NativeStructs.ServiceStatusProcess ServiceStatus)
        {
        }

        class _failedMemberConversionMarker3
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function CreateService(<[In]()> ByVal SCManager As IntPtr, _
                <[In]()> ByVal ServiceName As String, _
                <[In]()> ByVal DisplayName As String, _
                <[In]()> ByVal DesiredAccess As Native.Security.ServiceAccess, _
                <[In]()> ByVal ServiceType As ServiceType, _
                <[In]()> ByVal StartType As ServiceStartType, _
                <[In]()> ByVal ErrorControl As ServiceErrorControl, _
                <[In]()> ByVal BinaryPathName As String, _
                <[In]()> ByVal LoadOrderGroup As String, _
                <Out()> ByVal TagId As IntPtr, _
                <[In]()> ByVal Dependencies As IntPtr, _
                <[In]()> ByVal ServiceStartName As String, _
                <[In]()> ByVal Password As String) As IntPtr
        End Function

 */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static bool DeleteService([In()] IntPtr Service)
        {
        }

        class _failedMemberConversionMarker4
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function EnumServicesStatusEx(<[In]()> ByVal SCManager As IntPtr, _
                        <[In]()> ByVal InfoLevel As IntPtr, _
                        <[In]()> ByVal ServiceType As ServiceQueryType, _
                        <[In]()> ByVal ServiceState As ServiceQueryState, _
                        <Out()> <[Optional]()> ByVal Services As IntPtr, _
                        <[In]()> ByVal BufSize As Integer, _
                        <Out()> ByRef BytesNeeded As Integer, _
                        <Out()> ByRef ServicesReturned As Integer, _
                        ByRef ResumeHandle As Integer, _
                        <[In]()> <[Optional]()> ByVal GroupName As String) As Boolean
        End Function

 */
        class _failedMemberConversionMarker5
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function GetTokenInformation(<[In]()> ByVal TokenHandle As IntPtr, _
                <[In]()> ByVal TokenInformationClass As TokenInformationClass, _
                <Out()> <[Optional]()> ByVal TokenInformation As IntPtr, _
                <[In]()> ByVal TokenInformationLength As Integer, _
                <Out()> ByRef ReturnLength As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static bool GetTokenInformation([In()] IntPtr TokenHandle, [In()] NativeEnums.TokenInformationClass TokenInformationClass, [Optional()] ref NativeStructs.TokenSource TokenInformation, [In()] int TokenInformationLength, out int ReturnLength)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static bool GetTokenInformation([In()] IntPtr TokenHandle, [In()] NativeEnums.TokenInformationClass TokenInformationClass, [Optional()] ref NativeStructs.TokenStatistics TokenInformation, [In()] int TokenInformationLength, out int ReturnLength)
        {
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static IntPtr LockServiceDatabase(IntPtr hSCManager)
        {
        }

        class _failedMemberConversionMarker6
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function LookupAccountSid(<[In]()> <[Optional]()> ByVal SystemName As String, _
                <[In]()> ByVal Sid As IntPtr, _
                <Out()> <[Optional]()> ByVal Name As StringBuilder, _
                ByRef NameSize As Integer, _
                <Out()> <[Optional]()> ByVal ReferencedDomainName As StringBuilder, _
                ByRef ReferencedDomainNameSize As Integer, _
                <Out()> ByRef Use As SidNameUse) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        class _failedMemberConversionMarker7
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' <from PH>
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function LookupPrivilegeDisplayName(<[In]()> <[Optional]()> ByVal SystemName As String, _
            <[In]()> ByVal Name As String, _
            <Out()> <[Optional]()> ByVal DisplayName As StringBuilder, _
            ByRef DisplayNameSize As Integer, _
            <Out()> ByRef LanguageId As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        class _failedMemberConversionMarker8
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function LookupPrivilegeName(<[In]()> <[Optional]()> ByVal SystemName As String, _
                    <[In]()> ByRef Luid As Luid, _
                    <Out()> <[Optional]()> ByVal Name As StringBuilder, _
                    ByRef RequiredSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        // <from PH>
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static bool LookupPrivilegeValue([In()][Optional()] string SystemName, [In()] string PrivilegeName, out NativeStructs.Luid Luid)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static bool OpenProcessToken([In()] IntPtr ProcessHandle, [In()] Security.TokenAccess DesiredAccess, out IntPtr TokenHandle)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static IntPtr OpenSCManager([In()][Optional()] string MachineName, [In()][Optional()] string DatabaseName, [In()] Security.ServiceManagerAccess DesiredAccess)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static IntPtr OpenService([In()] IntPtr SCManager, [In()] string ServiceName, [In()] Security.ServiceAccess DesiredAccess)
        {
        }

        [DllImport("advapi32.dll", EntryPoint = "QueryServiceConfigW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static bool QueryServiceConfig(IntPtr hService, IntPtr pBuffer, int cbBufSize, ref int pcbBytesNeeded)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static bool QueryServiceStatus(IntPtr Service, ref NativeStructs.ServiceStatus ServiceStatus)
        {
        }

        // <from PH>
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static bool QueryServiceStatusEx([In()] IntPtr Service, [In()] int InfoLevel, [Optional()] out NativeStructs.ServiceStatusProcess ServiceStatus, [In()] int BufferSize, out int BytesNeeded)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static int RegCloseKey(IntPtr hKey)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static int RegNotifyChangeKeyValue(IntPtr hKey, bool watchSubtree, int dwNotifyFilter, IntPtr hEvent, bool fAsynchronous)
        {
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyEx")]
        public static int RegOpenKeyEx(IntPtr hKey, string subKey, uint options, int sam, ref IntPtr phkResult)
        {
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        public static bool StartService([In()] IntPtr Service, [In()] int NumServiceArgs, [In()][Optional()] string[] Args)
        {
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static bool UnlockServiceDatabase(IntPtr hSCManager)
        {
        }



        [DllImport("dbghelp.dll")]
        public static bool MiniDumpWriteDump(IntPtr hProcess, int ProcessId, IntPtr hFile, int DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallackParam)
        {
        }



        [DllImport("gdi32.dll")]
        public static IntPtr CreatePen([In()] NativeEnums.GdiPenStyle PenStyle, [In()] int Width, [In()] IntPtr Color)
        {
        }

        [DllImport("gdi32.dll")]
        public static IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
        {
        }

        [DllImport("gdi32.dll")]
        public static bool DeleteObject([In()] IntPtr Object)
        {
        }

        [DllImport("gdi32.dll")]
        public static int GetClipRgn(IntPtr hdc, IntPtr hrgn)
        {
        }

        [DllImport("gdi32.dll")]
        public static IntPtr GetStockObject([In()] NativeEnums.GdiStockObject Object)
        {
        }

        [DllImport("gdi32.dll")]
        public static bool Rectangle([In()] IntPtr hDC, [In()] int LeftRect, [In()] int TopRect, [In()] int RightRect, [In()] int BottomRect)
        {
        }

        [DllImport("gdi32.dll")]
        public static bool RestoreDC([In()] IntPtr hDC, [In()] int SavedDC)
        {
        }

        [DllImport("gdi32.dll")]
        public static int SaveDC([In()] IntPtr hDC)
        {
        }

        [DllImport("gdi32.dll")]
        public static IntPtr SelectObject([In()] IntPtr hDC, [In()] IntPtr hGdiObject)
        {
        }

        [DllImport("gdi32.dll")]
        public static NativeEnums.GdiBlendMode SetROP2([In()] IntPtr hDC, [In()] NativeEnums.GdiBlendMode DrawMode)
        {
        }



        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static int GetExtendedTcpTable(IntPtr Table, ref int Size, bool Order, NativeEnums.IpVersion IpVersion, Enums.TcpTableClass TableClass, int Reserved)
        {
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static int GetExtendedUdpTable(IntPtr Table, ref int Size, bool Order, NativeEnums.IpVersion IpVersion, Enums.UdpTableClass TableClass, int Reserved)
        {
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static int GetTcpStatistics(ref NativeStructs.MibTcpStats stats)
        {
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static int GetUdpStatistics(ref NativeStructs.MibUdpStats stats)
        {
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static int SetTcpEntry(ref NativeStructs.MibTcpRow TcpRow)
        {
        }



        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool AssignProcessToJobObject([In()] IntPtr JobHandle, [In()] IntPtr ProcessHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool CheckRemoteDebuggerPresent(IntPtr ProcessHandle, [MarshalAs(UnmanagedType.Bool)] ref bool DebuggerPresent)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool CloseHandle([In()] IntPtr Handle)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists)
        {
        }

        [DllImport("kernel32.dll", EntryPoint = "CreateEventA")]
        public static IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static IntPtr CreateJobObject([In()] ref NativeStructs.SecurityAttributes SecurityAttributes, [In()] string Name)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr CreateFile(string lpFileName, NativeEnums.EFileAccess dwDesiredAccess, NativeEnums.EFileShare dwShareMode, IntPtr lpSecurityAttributes, NativeEnums.ECreationDisposition dwCreationDisposition, NativeEnums.EFileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpFileMappingAttributes, NativeEnums.FileMapProtection flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPTStr)] string lpName)
        {
        }

        // <from PH>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr CreateRemoteThread([In()] IntPtr ProcessHandle, [In()] IntPtr ThreadAttributes, [In()] int StackSize, [In()] IntPtr StartAddress, [In()] IntPtr Parameter, [In()] NativeEnums.RemoteThreadCreationFlags CreationFlags, out int ThreadId)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr CreateToolhelp32Snapshot(NativeEnums.Toolhelp32SnapshotFlags dwFlags, int th32ProcessID)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool DeviceIoControl(IntPtr FileHandle, int IoControlCode, ref NativeStructs.SystemHandleEntry InBuffer, int InBufferLength, IntPtr OutBuffer, int OutBufferLength, ref int BytesReturned, IntPtr Overlapped)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool DuplicateHandle(IntPtr hSourceProcessHandle, IntPtr hSourceHandle, IntPtr hTargetProcessHandle, ref IntPtr lpTargetHandle, uint dwDesiredAccess, bool bInheritHandle, NativeEnums.DuplicateOptions dwOptions)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static void ExitProcess(int ExitCode)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static uint FormatMessage(NativeEnums.FormatMessageFlags Flags, IntPtr Source, int MessageId, int LanguageId, ref StringBuilder Buffer, int Size, IntPtr Arguments)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static uint FormatMessage(NativeEnums.FormatMessageFlags Flags, IntPtr Source, uint MessageId, int LanguageId, ref StringBuilder Buffer, int Size, IntPtr Arguments)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "FreeLibrary")]
        public static bool FreeLibrary(IntPtr hModule)
        {
        }

        [DllImport("kernel32.dll")]
        public static uint GetCompressedFileSize(string lpFileName, ref uint lpFileSizeHigh)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr GetCurrentProcess()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetCurrentProcessId()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetCurrentThreadId()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool GetExitCodeProcess([In()] IntPtr ProcessHandle, out int ExitCode)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool GetExitCodeProcess([In()] IntPtr ProcessHandle, out uint ExitCode)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool GetExitCodeThread([In()] IntPtr ThreadHandle, out int ExitCode)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static bool GetFileSizeEx([In()] IntPtr hFile, [In()] out long lpFileSize)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static IntPtr GetModuleHandle(string ModuleName)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static IntPtr GetProcAddress([In()] IntPtr Module, [In()] ushort ProcOrdinal)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static IntPtr GetProcAddress([In()] IntPtr Module, [In()] string ProcOrdinal)
        {
        }

        // <from PH>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool GetProcessDEPPolicy([In()] IntPtr ProcessHandle, out NativeEnums.DepFlags Flags, [MarshalAs(UnmanagedType.Bool)] out bool Permanent)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetProcessId(IntPtr ProcessHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetProcessIdOfThread(IntPtr ThreadHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static int GetShortPathName(string longPath, [MarshalAs(UnmanagedType.LPTStr)] System.Text.StringBuilder ShortPath, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)] int bufferSize)
        {
        }

        [DllImport("kernel32.dll")]
        public static void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref NativeStructs.SystemInfo lpSystemInfo)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetThreadId(IntPtr ThreadHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int GetThreadPriority([In()] IntPtr ThreadHandle)
        {
        }

        [DllImport("kernel32.dll")]
        public static int GetTickCount()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool Heap32First(ref NativeStructs.HeapEntry32 lphe, int th32ProcessID, IntPtr th32HeapID)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool Heap32ListFirst([In()] IntPtr hSnapshot, ref NativeStructs.HeapList32 lphl)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool Heap32ListNext(IntPtr hSnapshot, ref NativeStructs.HeapList32 lphl)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int Heap32Next(ref NativeStructs.HeapEntry32 lphe)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool IsProcessInJob(IntPtr ProcessHandle, IntPtr JobHandle, ref bool Result)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr LocalFree(IntPtr hMem)
        {
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static IntPtr LoadLibrary([In()] string FileName)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr MapViewOfFile(IntPtr hFileMappingObject, NativeEnums.FileMapAccess dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static IntPtr OpenJobObject([In()] Security.JobAccess DesiredAccess, [In()] bool Inherit, [In()] string Name)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr OpenProcess(Security.ProcessAccess DesiredAccess, bool InheritHandle, int ProcessId)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static IntPtr OpenThread([In()] Security.ThreadAccess DesiredAccess, [In()] bool InheritHandle, [In()] int ThreadId)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static int QueryDosDevice(string DeviceName, StringBuilder TargetPath, int MaxLength)
        {
        }

        class _failedMemberConversionMarker9
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        ' Vista and higher
        ' <from PH>
        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function QueryFullProcessImageName(<[In]()> ByVal ProcessHandle As IntPtr, _
                <[In]()> <MarshalAs(UnmanagedType.Bool)> ByVal UseNativeName As Boolean, _
                <Out()> ByVal ExeName As StringBuilder, _
                ByRef Size As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        class _failedMemberConversionMarker10
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function QueryInformationJobObject(<[In]()> ByVal JobHandle As IntPtr, _
                            <[In]()> ByVal JobInformationClass As JobObjectInformationClass, _
                            <Out()> ByVal JobInformation As IntPtr, _
                            <[In]()> ByVal JobInformationLength As Integer, _
                            <Out()> ByRef ReturnLength As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        class _failedMemberConversionMarker11
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function SetInformationJobObject(<[In]()> ByVal JobHandle As IntPtr, _
                <[In]()> ByVal JobInformationClass As JobObjectInformationClass, _
                <Out()> ByVal JobInformation As IntPtr, _
                <[In]()> ByVal JobInformationLength As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

 */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool ReadProcessMemory(IntPtr Process, IntPtr BaseAddress, byte[] Buffer, int Size, ref int BytesRead)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool ReadProcessMemory(IntPtr Process, IntPtr BaseAddress, short[] Buffer, int Size, ref int BytesRead)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool ReadProcessMemory(IntPtr Process, IntPtr BaseAddress, IntPtr[] Buffer, int Size, ref int BytesRead)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool ReadProcessMemory(IntPtr Process, IntPtr BaseAddress, int[] Buffer, int Size, ref int BytesRead)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int ResumeThread([In()] IntPtr ThreadHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool SetPriorityClass([In()] IntPtr ProcessHandle, [In()] int Priority)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool SetProcessAffinityMask([In()] IntPtr ProcessHandle, [In()] IntPtr ProcessAffinityMask)
        {
        }

        [DllImport("kernel32.dll")]
        public static bool SetProcessWorkingSetSize(IntPtr hProcess, IntPtr dwMinimumWorkingSetSize, IntPtr dwMaximumWorkingSetSize)
        {
        }

        [DllImport("kernel32.dll")]
        public static IntPtr SetThreadAffinityMask(IntPtr hThread, IntPtr dwThreadAffinityMask)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool SetThreadPriority([In()] IntPtr ThreadHandle, [In()] int Priority)
        {
        }

        [DllImport("kernel32.dll")]
        public static void Sleep(uint dwMilliseconds)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static int SuspendThread([In()] IntPtr ThreadHandle)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool TerminateJobObject([In()] IntPtr JobHandle, [In()] int ExitCode)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool TerminateThread(IntPtr ThreadHandle, [In()] int ExitCode)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool UnmapViewOfFile(IntPtr lpBaseAddress)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool VirtualFreeEx(IntPtr Process, IntPtr Address, int Size, NativeEnums.MemoryState FreeType)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool VirtualProtectEx(IntPtr Process, IntPtr Address, int Size, NativeEnums.MemoryProtectionType NewProtect, ref NativeEnums.MemoryProtectionType OldProtect)
        {
        }

        // <from PH>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static int VirtualQueryEx(IntPtr Process, IntPtr Address, [MarshalAs(UnmanagedType.Struct)] ref NativeStructs.MemoryBasicInformation Buffer, int Size)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static NativeEnums.WaitResult WaitForSingleObject(IntPtr Object, int Timeout)
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static bool WriteFile(IntPtr FileHandle, byte[] Buffer, int Bytes, ref int WrittenBytes, IntPtr Overlapped)
        {
        }

        [DllImport("kernel32.dll")]
        public static void ZeroMemory(IntPtr addr, IntPtr size)
        {
        }



        [DllImport("mpr.dll")]
        public static int WNetAddConnection2(ref NativeStructs.NetResource netResource, string password, string username, NativeEnums.AddConnectionFlag flags)
        {
        }

        [DllImport("mpr.dll")]
        public static int WNetCancelConnection2(string lpName, Int32 dwFlags, bool bForce)
        {
        }



        [DllImport("ntdll.dll")]
        public static Int32 NtDuplicateObject(IntPtr SourceProcessHandle, IntPtr SourceHandle, IntPtr TargetProcessHandle, ref IntPtr TargetHandle, int DesiredAccess, NativeEnums.HandleFlags Attributes, NativeEnums.DuplicateOptions Options)
        {
        }

        // Vista and higher
        // <from PH>
        [DllImport("ntdll.dll")]
        public static uint NtGetNextProcess([In()] IntPtr ProcessHandle, [In()] Security.ProcessAccess DesiredAccess, [In()] NativeEnums.HandleFlags HandleAttributes, [In()] int Flags, out IntPtr NewProcessHandle)
        {
        }

        // <from PH>
        [DllImport("ntdll.dll")]
        public static uint NtGetNextThread([In()] IntPtr ProcessHandle, [In()] IntPtr ThreadHandle, [In()] Security.ThreadAccess DesiredAccess, [In()] NativeEnums.HandleFlags HandleAttributes, [In()] int Flags, out IntPtr NewThreadHandle)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtOpenProcess(out IntPtr ProcessHandle, [In()] Security.ProcessAccess DesiredAccess, [In()] ref NativeStructs.ObjectAttributes ObjectAttributes, [In()] ref NativeStructs.ClientId ClientId)
        {
        }

        // <from PH>
        [DllImport("ntdll.dll")]
        public static uint NtQueryInformationProcess([In()] IntPtr ProcessHandle, [In()] NativeEnums.ProcessInformationClass ProcessInformationClass, IntPtr ProcessInformation, [In()] int ProcessInformationLength, [Optional()] out int ReturnLength)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtQueryInformationProcess([In()] IntPtr ProcessHandle, [In()] NativeEnums.ProcessInformationClass ProcessInformationClass, out IntPtr ProcessInformation, [In()] int ProcessInformationLength, [Optional()] out uint ReturnLength)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtQueryInformationProcess([In()] IntPtr ProcessHandle, [In()] NativeEnums.ProcessInformationClass ProcessInformationClass, out NativeStructs.ProcessBasicInformation ProcessInformation, [In()] int ProcessInformationLength, [Optional()] out int ReturnLength)
        {
        }

        // <from PH>
        [DllImport("ntdll.dll")]
        public static uint NtQueryInformationThread([In()] IntPtr ThreadHandle, [In()] NativeEnums.ThreadInformationClass ThreadInformationClass, ref NativeStructs.ThreadBasicInformation ThreadInformation, [In()] int ThreadInformationLength, [Optional()] out int ReturnLength)
        {
        }

        class _failedMemberConversionMarker12
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("ntdll.dll")> _
        Public Shared Function NtQueryObject(<[In]()> ByVal Handle As IntPtr, _
                    <[In]()> ByVal ObjectInformationClass As ObjectInformationClass, _
                    <Out()> ByVal ObjectInformation As IntPtr, _
                    <[In]()> ByVal ObjectInformationLength As Integer, _
                    <Out()> ByRef ReturnLength As Integer) As UInteger

        End Function

 */
        // <from PH>
        [DllImport("ntdll.dll")]
        public static uint NtQuerySystemInformation([In()] NativeEnums.SystemInformationClass SystemInformationClass, out NativeStructs.SystemBasicInformation SystemInformation, [In()] int SystemInformationLength, [Optional()] out int ReturnLength)
        {
        }

        class _failedMemberConversionMarker13
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("ntdll.dll")> _
        Public Shared Function NtQuerySystemInformation(<[In]()> ByVal SystemInformationClass As SystemInformationClass, _
            <Out()> ByVal SystemInformation As IntPtr, _
            <[In]()> ByVal SystemInformationLength As Integer, _
            <Out()> <[Optional]()> ByRef ReturnLength As Integer) As UInteger
        End Function

 */
        [DllImport("ntdll.dll")]
        public static uint NtQuerySystemInformation([In()] NativeEnums.SystemInformationClass SystemInformationClass, out NativeStructs.SystemCacheInformation SystemInformation, [In()] int SystemInformationLength, [Optional()] out int ReturnLength)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtQuerySystemInformation([In()] NativeEnums.SystemInformationClass SystemInformationClass, out NativeStructs.SystemPerformanceInformation SystemInformation, [In()] int SystemInformationLength, [Optional()] out int ReturnLength)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtQuerySystemInformation([In()] NativeEnums.SystemInformationClass SystemInformationClass, out NativeStructs.SystemProcessorPerformanceInformation SystemInformation, [In()] int SystemInformationLength, [Optional()] out int ReturnLength)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtResumeProcess([In()] IntPtr ProcessHandle)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint NtSuspendProcess([In()] IntPtr ProcessHandle)
        {
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        public static uint NtTerminateProcess([In()] IntPtr ProcessHandle, [In()] int ExitCode)
        {
        }

        // From here :
        // http://www.woodmann.com/forum/blog.php?b=151
        [DllImport("ntdll.dll")]
        public static IntPtr RtlCreateQueryDebugBuffer([In()] int Size, [In()] bool EventPair)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint RtlDestroyQueryDebugBuffer([In()] IntPtr DebugBuffer)
        {
        }

        [DllImport("ntdll.dll")]
        public static uint RtlQueryProcessDebugInformation([In()] IntPtr ProcessId, [In()] NativeEnums.RtlQueryProcessDebugInformationFlags Flags, [In()] IntPtr Buffer)
        {
        }



        [DllImport("powrprof.dll", SetLastError = true)]
        public static bool SetSuspendState([In()] bool hibernate, [In()] bool forceCritical, [In()] bool disableWakeEvent)
        {
        }

        class _failedMemberConversionMarker14
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

#End Region

#Region "psapi"

        <DllImport("psapi.dll")> _
               Public Shared Function EnumProcessModules(<[In]()> ByVal ProcessHandle As IntPtr, _
                           <Out()> ByVal ModuleHandles As IntPtr(), <[In]()> ByVal Size As Integer, _
                           <Out()> ByRef RequiredSize As Integer) As Boolean
        End Function

 */
        class _failedMemberConversionMarker15
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("psapi.dll")> _
        Public Shared Function EnumProcessModules(<[In]()> ByVal ProcessHandle As IntPtr, _
                    <Out()> ByVal ModuleHandles As IntPtr, <[In]()> ByVal Size As Integer, _
                    <Out()> ByRef RequiredSize As Integer) As Boolean
        End Function

 */
        [DllImport("psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static int GetMappedFileName(IntPtr ProcessHandle, IntPtr Address, StringBuilder Buffer, int Size)
        {
        }

        class _failedMemberConversionMarker16
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("psapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function GetModuleBaseName(<[In]()> ByVal ProcessHandle As IntPtr, _
                        <[In]()> <[Optional]()> ByVal ModuleHandle As IntPtr, _
                        <Out()> ByVal BaseName As StringBuilder, _
                        <[In]()> ByVal Size As Integer) As Integer
        End Function

 */
        class _failedMemberConversionMarker17
        {
        }/* Cannot convert MethodBlockSyntax, System.ArgumentOutOfRangeException: Заданный аргумент находится вне диапазона допустимых значений.
Имя параметра: tokenInList
   в Microsoft.CodeAnalysis.SyntaxTokenList.ReplaceRange(SyntaxToken tokenInList, IEnumerable`1 newTokens)
   в Microsoft.CodeAnalysis.SyntaxTokenList.Replace(SyntaxToken tokenInList, SyntaxToken newToken)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameter(ParameterSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<VisitParameterList>b__62_0(ParameterSyntax p)
   в System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   в Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParameterList(ParameterListSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.ParameterListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodStatement(MethodStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMethodBlock(MethodBlockSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

Input: 

        <DllImport("psapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function GetModuleFileNameEx(<[In]()> ByVal ProcessHandle As IntPtr, _
                        <[In]()> <[Optional]()> ByVal ModuleHandle As IntPtr, _
                        <Out()> ByVal FileName As StringBuilder, _
                        <[In]()> ByVal Size As Integer) As Integer
        End Function

 */
        // Unused in non-commented blocks
        // <DllImport("psapi.dll")> _
        // Public Shared Function GetModuleInformation(<[In]()> ByVal ProcessHandle As IntPtr, _
        // <[In]()> <[Optional]()> ByVal ModuleHandle As IntPtr, _
        // <Out()> ByVal ModInfo As MODULEINFO, _
        // <[In]()> ByVal Size As Integer) As Boolean
        // End Function

        [DllImport("psapi.dll", SetLastError = true)]
        public static bool GetPerformanceInfo(out NativeStructs.PerformanceInformation PerformanceInformation, [In()] int Size)
        {
        }



        [DllImport("shell32.dll")]
        public static IntPtr FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult)
        {
        }

        [DllImport("shell32.dll", EntryPoint = "#61", CharSet = CharSet.Unicode)]
        public static int RunFileDlg([In()] IntPtr hWnd, [In()] IntPtr Icon, [In()] string Path, [In()] string Title, [In()] string Prompt, [In()] NativeEnums.RunFileDialogFlags Flags)
        {
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static int SHFileOperation([In()] ref NativeStructs.ShFileOpStruct lpFileOp)
        {
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static int SHGetFileInfo(string pszPath, int dwFileAttributes, ref NativeStructs.SHFileInfo psfi, int cbFileInfo, int uFlags)
        {
        }

        [DllImport("Shell32", CharSet = CharSet.Auto, SetLastError = true)]
        public static bool ShellExecuteEx(ref NativeStructs.ShellExecuteInfo lpExecInfo)
        {
        }



        [DllImport("user32.dll")]
        public static int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, [In()] NativeStructs.KBDLLHookStruct lParam)
        {
        }

        [DllImport("user32.dll")]
        public static int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, [In()] NativeStructs.MouseHookStruct lParam)
        {
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static bool DestroyIcon(IntPtr Handle)
        {
        }

        [DllImport("user32.dll")]
        public static bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable)
        {
        }

        [DllImport("user32.dll")]
        public static bool EnableWindow(IntPtr hWnd, bool bEnable)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool ExitWindowsEx([In()] NativeEnums.ExitWindowsFlags flags, [In()] int reason)
        {
        }

        [DllImport("user32.dll")]
        public static bool FlashWindowEx(ref NativeStructs.FlashWInfo pwfi)
        {
        }

        [DllImport("user32.dll")]
        public static short GetAsyncKeyState(Int32 vKey)
        {
        }

        public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                // 64 bits
                return GetClassLongPtr64(hWnd, nIndex);
            else
                // 32 bits
                return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        private static uint GetClassLongPtr32(IntPtr hWnd, int nIndex)
        {
        }

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        private static IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex)
        {
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static void GetClassName(System.IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static bool GetClientRect([In()] IntPtr hWnd, out NativeStructs.Rect rect)
        {
        }

        [DllImport("user32.dll")]
        public static bool GetCursorPos(out NativeStructs.PointApi location)
        {
        }

        [DllImport("user32.dll")]
        public static IntPtr GetDesktopWindow()
        {
        }

        [DllImport("user32.dll")]
        public static IntPtr GetForegroundWindow()
        {
        }

        [DllImport("user32.dll")]
        public static int GetGuiResources([In()] IntPtr ProcessHandle, [In()] NativeEnums.GuiResourceType UserObjects)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool GetLayeredWindowAttributes(IntPtr hwnd, ref uint crKey, ref byte bAlpha, ref uint dwFlags)
        {
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr GetWindow(IntPtr hWnd, NativeEnums.GetWindowCmd uCmd)
        {
        }

        [DllImport("user32.dll")]
        public static IntPtr GetWindowDC([In()] IntPtr hWnd)
        {
        }

        // This static method is required because Win32 does not support
        // GetWindowLongPtr directly
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex)
        {
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool GetWindowPlacement([In()] IntPtr hWnd, ref NativeStructs.WindowPlacement WindowPlacement)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static bool GetWindowRect([In()] IntPtr hWnd, out NativeStructs.Rect rect)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static int GetWindowText(IntPtr hwnd, StringBuilder lpString, int cch)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static int GetWindowTextLength(IntPtr hwnd)
        {
        }

        [DllImport("user32.dll")]
        public static int GetWindowThreadProcessId([In()] IntPtr hWnd, out int processId)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool IsWindowEnabled(IntPtr hwnd)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool IsWindowVisible(IntPtr hwnd)
        {
        }

        [DllImport("User32", SetLastError = true)]
        public static int LoadString(IntPtr hInstance, UInt32 uID, System.Text.StringBuilder lpBuffer, int nBufferMax)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool LockWorkStation()
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static bool ReleaseCapture()
        {
        }

        [DllImport("user32.dll")]
        public static int ReleaseDC([In()] IntPtr hWnd, [In()] IntPtr hDC)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr SendMessage(IntPtr hWnd, Native.Api.NativeEnums.LVM Msg, IntPtr wParam, IntPtr lParam)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr SendMessage(IntPtr hWnd, NativeEnums.WindowMessage Msg, IntPtr wParam, IntPtr lParam)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr SendMessageTimeout(IntPtr windowHandle, NativeEnums.WindowMessage Msg, IntPtr wParam, IntPtr lParam, NativeEnums.SendMessageTimeoutFlags flags, int timeout, ref IntPtr result)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static bool ShowWindow(IntPtr hwnd, NativeEnums.ShowWindowType nCmdShow)
        {
        }

        [DllImport("user32.dll")]
        public static IntPtr SetActiveWindow([In()] IntPtr hWnd)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static IntPtr SetCapture([In()] IntPtr handle)
        {
        }

        [DllImport("user32.dll")]
        public static bool SetForegroundWindow([In()] IntPtr hWnd)
        {
        }

        [DllImport("user32.dll")]
        public static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr SetWindowsHookEx(NativeEnums.HookType hook, HookProcKbd callback, IntPtr hMod, uint dwThreadId)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr SetWindowsHookEx(NativeEnums.HookType hook, HookProcMouse callback, IntPtr hMod, uint dwThreadId)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr SetWindowsHookEx(NativeEnums.HookType hook, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static IntPtr SetWindowsHookEx(NativeEnums.HookType code, LowLevelMouseProc func, IntPtr hInstance, int threadID)
        {
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong)
        {
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool SetWindowPlacement([In()] IntPtr hWnd, ref NativeStructs.WindowPlacement WindowPlacement)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, UInt32 uFlags)
        {
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static int SetWindowText(IntPtr hwnd, System.Text.StringBuilder lpString)
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static bool UnhookWindowsHookEx(IntPtr hhk)
        {
        }

        [DllImport("user32.dll")]
        public static IntPtr WindowFromPoint([In()] Point location)
        {
        }



        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static int SetWindowTheme(IntPtr hWnd, string appName, string partList)
        {
        }



        [DllImport("wintrust.dll", ExactSpelling = true, SetLastError = false, CharSet = CharSet.Unicode)]
        public static NativeEnums.WinVerifyTrustResult WinVerifyTrust([In()] IntPtr hwnd, [In()][MarshalAs(UnmanagedType.LPStruct)] Guid pgActionID, [In()] NativeStructs.WinTrustData pWVTData)
        {
        }
    }
}

