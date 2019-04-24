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
using System.Net.NetworkInformation;

public class cNetwork : cGeneralObject, IDisposable
{
    private static Dictionary<int, string> _dicoUdp = new Dictionary<int, string>();
    private static Dictionary<int, string> _dicoTcp = new Dictionary<int, string>();

    private IPAddress nullAddress = new IPAddress(0);     // For address comparison

    private bool _haveResolvedAnAddress;
    private networkInfos _networkInfos;
    private static cNetworkConnection __connection;

    private static cNetworkConnection _connection
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

    public static cNetworkConnection Connection
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



    public cNetwork(ref networkInfos infos)
    {
        _networkInfos = infos;
        _connection = Connection;
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.NetworkConnection;

        // Solve DNS
        try
        {
            if (this.Infos._Local.Address.Equals(nullAddress) == false)
            {
                System.Threading.WaitCallback t = new System.Threading.WaitCallback(getHostNameLocal);
                System.Threading.ThreadPool.QueueUserWorkItem(t, this.Infos.Local);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
        try
        {
            if (this.Infos._remote != null && this.Infos._remote.Address.Equals(nullAddress) == false)
            {
                System.Threading.WaitCallback t = new System.Threading.WaitCallback(getHostNameRemote);
                System.Threading.ThreadPool.QueueUserWorkItem(t, this.Infos.Remote);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
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



    public networkInfos Infos
    {
        get
        {
            return _networkInfos;
        }
    }



    // Close a TCP connection
    public static int LocalCloseTCP(IPEndPoint local, IPEndPoint remote)
    {
        return Native.Objects.Network.CloseTcpConnectionByIPEndPoints(local, remote);
    }

    // Retrieve description of a port
    public static string GetPortDescription(int port, Native.Api.Enums.NetworkProtocol protocol)
    {
        if (port == 0)
            return "";
        if (protocol == Native.Api.Enums.NetworkProtocol.Tcp)
        {
            if (_dicoTcp.ContainsKey(port))
                return _dicoTcp[port];
            else
                return Program.NO_INFO_RETRIEVED;
        }
        else if (_dicoUdp.ContainsKey(port))
            return _dicoUdp[port];
        else
            return Program.NO_INFO_RETRIEVED;
    }

    // Ping (sync)
    public void Ping(ListView lv)
    {
        if (this.Infos.Remote == null)
        {
            // No IP address
            Async.ListView.AddItem(lv, "Could not ping a null address");
            return;
        }

        // Create ping objects
        Ping pinger = new Ping();
        PingOptions pingOpt = new PingOptions();
        PingReply pingRep = null;

        // Conf
        IPAddress theIp = this.Infos.Remote.Address;
        int pingTimeOut = 1000;
        int pingCount = 4;
        int pingSize = 32;
        byte[] pingBuff = new byte[pingSize + 1];

        // Results
        int pingSent = 0;
        int pingLost = 0;
        int pingReceived = 0;
        long pingRespMin = long.MaxValue;
        long pingRespMax = long.MinValue;
        long pingRespAvg = 0;

        Async.ListView.AddItem(lv, "Pinging [" + theIp.ToString() + "] with " + pingSize.ToString() + " bytes of data:");
        var loopTo = pingCount - 1;
        for (pingSent = 0; pingSent <= loopTo; pingSent++)
        {
            try
            {
                // Send the "ping command"
                pingRep = pinger.Send(theIp, pingTimeOut, pingBuff, pingOpt);
            }
            catch (Exception ex)
            {
                Async.ListView.AddItem(lv, "Ping error : " + ex.Message);
            }

            // Depending on the rep status...
            if (pingRep.Status == IPStatus.Success)
            {
                if (pingRep.Options == null)
                    // Sometimes it's nothing (?)
                    Async.ListView.AddItem(lv, "Reply from " + theIp.ToString() + ": bytes=" + pingSize.ToString() + " time=" + pingRep.RoundtripTime.ToString() + "ms TTL=" + pingOpt.Ttl.ToString() + Constants.vbNewLine);
                else
                    Async.ListView.AddItem(lv, "Reply from " + theIp.ToString() + ": bytes=" + pingSize.ToString() + " time=" + pingRep.RoundtripTime.ToString() + "ms TTL=" + pingRep.Options.Ttl.ToString() + Constants.vbNewLine);

                if (pingRep.RoundtripTime > pingRespMax)
                    pingRespMax = pingRep.RoundtripTime;
                if (pingRep.RoundtripTime < pingRespMin)
                    pingRespMin = pingRep.RoundtripTime;
                pingRespAvg += pingRep.RoundtripTime;

                pingReceived += 1;
            }
            else
            {
                // Failed
                Async.ListView.AddItem(lv, pingRep.Status.ToString());
                pingLost += 1;
            }
        }

        // Average rt
        if (pingReceived != 0)
            pingRespAvg = pingRespAvg / pingReceived;

        Async.ListView.AddItem(lv, "");
        Async.ListView.AddItem(lv, "Ping statistics for " + theIp.ToString());
        Async.ListView.AddItem(lv, "   Packets: Sent = " + pingSent.ToString() + ", Received = " + pingReceived.ToString() + ", Lost = " + pingLost.ToString() + "  (" + Misc.GetFormatedPercentage(pingLost / (double)pingSent, 0, true) + "% loss)");
        if (pingReceived > 0)
        {
            Async.ListView.AddItem(lv, "Approximate round trip times in milli-seconds:");
            Async.ListView.AddItem(lv, "   Minimum = " + pingRespMin.ToString() + "ms, Maximum = " + pingRespMax.ToString() + "ms, Average = " + pingRespAvg.ToString() + "ms");
        }

        // Release ping object
        pinger.Dispose();
    }

    // WhoIs (sync)
    public void WhoIs(ListView lv)
    {
        Async.ListView.AddItem(lv, "Not yet implemented...");
    }

    // TraceRoute (sync)
    public void TraceRoute(ListView lv)
    {
        Async.ListView.AddItem(lv, "Not yet implemented...");
    }



    // Unload module
    private asyncCallbackNetworkCloseConnection _closeTCP;
    public int CloseTCP()
    {
        if (_closeTCP == null)
            _closeTCP = new asyncCallbackNetworkCloseConnection(new asyncCallbackNetworkCloseConnection.HasClosedConnection(closeTCPDone), ref _connection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_closeTCP.Process());
        int newAction = cGeneralObject.GetActionCount();

        AddPendingTask(newAction, ref t);
        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackNetworkCloseConnection.poolObj(this.Infos.Local, this.Infos.Remote, newAction));
    }
    private void closeTCPDone(bool Success, IPEndPoint local, IPEndPoint remote, string msg, int actionNumber)
    {
        if (Success == false)
        {
            string s = "";
            if (local != null)
                s = local.ToString();
            Misc.ShowError("Could not close TCP connection " + s + " : " + msg);
        }
        RemovePendingTask(actionNumber);
    }



    // Merge current infos and new infos
    public void Merge(ref networkInfos Thr)
    {
        _networkInfos.Merge(ref Thr);
    }

    // Parse port text file
    public static void ParsePortTextFile()
    {
        Common.Misc.ParsePortTextFiles(My.MyProject.Application.Info.DirectoryPath + @"\tcp.txt", My.MyProject.Application.Info.DirectoryPath + @"\udp.txt", ref _dicoTcp, ref _dicoUdp);
    }


    private int getRemotePort()
    {
        if (this.Infos.Remote != null)
            return this.Infos.Remote.Port;
        else
            return 0;
    }
    private int getLocalPort()
    {
        if (this.Infos.Local != null)
            return this.Infos.Local.Port;
        else
            return 0;
    }

    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return networkInfos.GetAvailableProperties(includeFirstProp, sorted);
    }

    // Retrieve informations by its name
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

        Static oldRemotePort As Integer = getRemotePort()

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
        Static oldRemPortD As String = Nothing

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
        Static oldLocalPort As Integer = getLocalPort()

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
        Static oldLocPortD As String = Nothing

 */
        string res = Program.NO_INFO_RETRIEVED;

        if (info == "ObjectCreationDate")
            res = _objectCreationDate.ToLongDateString() + " -- " + _objectCreationDate.ToLongTimeString();
        else if (info == "PendingTaskCount")
            res = PendingTaskCount.ToString();

        switch (info)
        {
            case "Local":
                {
                    if (this.Infos.Local != null)
                    {
                        if (Strings.Len(this.Infos.LocalString) > 0)
                            res = this.Infos.Local.ToString() + "  ----  " + this.Infos.LocalString;
                        else
                            res = this.Infos.Local.ToString();
                    }
                    else
                        res = "0.0.0.0";
                    break;
                }

            case "Remote":
                {
                    if (this.Infos.Remote != null)
                    {
                        if (Strings.Len(this.Infos.RemoteString) > 0)
                            res = this.Infos.Remote.ToString() + "  ----  " + this.Infos.RemoteString;
                        else
                            res = this.Infos.Remote.ToString();
                    }

                    break;
                }

            case "Protocol":
                {
                    res = this.Infos.Protocol.ToString().ToUpperInvariant();
                    break;
                }

            case "ProcessId":
                {
                    res = this.Infos.ProcessId.ToString();
                    break;
                }

            case "Process":
                {
                    res = this.Infos.ProcessName + " (" + this.Infos.ProcessId.ToString() + ")";
                    break;
                }

            case "State":
                {
                    if (this.Infos.Protocol == Native.Api.Enums.NetworkProtocol.Tcp)
                        res = this.Infos.State.ToString();
                    break;
                }

            case "LocalPortDescription":
                {
                    if (getLocalPort() != oldLocalPort || oldLocPortD == null)
                    {
                        oldLocPortD = GetPortDescription(getLocalPort, this.Infos.Protocol);
                        oldLocalPort = getLocalPort();
                    }
                    res = oldLocPortD;
                    break;
                }

            case "RemotePortDescription":
                {
                    if (getRemotePort() != oldRemotePort || oldRemPortD == null)
                    {
                        oldRemPortD = GetPortDescription(getRemotePort, this.Infos.Protocol);
                        oldRemotePort = getRemotePort();
                    }
                    res = oldRemPortD;
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
        Static _old_Local As String = ""

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
        Static _old_Protocol As String = ""

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
        Static _old_Remote As String = ""

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
        Static _old_LocalPortDescription As String = ""

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
        Static _old_RemotePortDescription As String = ""

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
        Static oldRemotePort As Integer = getRemotePort()

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
        Static oldRemPortD As String = Nothing

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
        Static oldLocalPort As Integer = getLocalPort()

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
        Static oldLocPortD As String = Nothing

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
            case "Local":
                {
                    if (this.Infos.Local != null)
                    {
                        if (Strings.Len(this.Infos.LocalString) > 0)
                            res = this.Infos.Local.ToString() + "  ----  " + this.Infos.LocalString;
                        else
                            res = this.Infos.Local.ToString();
                    }
                    else
                        res = "0.0.0.0";
                    if (res == _old_Local)
                        hasChanged = false;
                    else
                        _old_Local = res;
                    break;
                }

            case "Remote":
                {
                    if (this.Infos.Remote != null)
                    {
                        if (Strings.Len(this.Infos.RemoteString) > 0)
                            res = this.Infos.Remote.ToString() + "  ----  " + this.Infos.RemoteString;
                        else
                            res = this.Infos.Remote.ToString();
                        if (res == _old_Remote)
                            hasChanged = false;
                        else
                            _old_Remote = res;
                    }
                    else
                    {
                        res = "";
                        hasChanged = (res != _old_Remote);
                        _old_Remote = res;
                    }

                    break;
                }

            case "Protocol":
                {
                    res = this.Infos.Protocol.ToString().ToUpperInvariant();
                    if (res == _old_Protocol)
                        hasChanged = false;
                    else
                        _old_Protocol = res;
                    break;
                }

            case "Process":
                {
                    res = this.Infos.ProcessName + " (" + this.Infos.ProcessId.ToString() + ")";
                    if (res == _old_Process)
                        hasChanged = false;
                    else
                        _old_Process = res;
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

            case "State":
                {
                    if (this.Infos.State > 0)
                        res = this.Infos.State.ToString();
                    else
                        res = "";
                    if (res == _old_State)
                        hasChanged = false;
                    else
                        _old_State = res;
                    break;
                }

            case "LocalPortDescription":
                {
                    if (getLocalPort() != oldLocalPort || oldLocPortD == null)
                    {
                        oldLocPortD = GetPortDescription(getLocalPort, this.Infos.Protocol);
                        oldLocalPort = getLocalPort();
                    }
                    res = oldLocPortD;
                    if (res == _old_LocalPortDescription)
                        hasChanged = false;
                    else
                        _old_LocalPortDescription = res;
                    break;
                }

            case "RemotePortDescription":
                {
                    if (getRemotePort() != oldRemotePort || oldRemPortD == null)
                    {
                        oldRemPortD = GetPortDescription(getRemotePort, this.Infos.Protocol);
                        oldRemotePort = getRemotePort();
                    }
                    res = oldRemPortD;
                    if (res == _old_RemotePortDescription)
                        hasChanged = false;
                    else
                        _old_RemotePortDescription = res;
                    break;
                }
        }

        return hasChanged;
    }



    private void getHostNameLocal(object obj)
    {
        if (obj != null)
        {
            IPHostEntry hostEntry;
            System.Net.IPEndPoint ip = (IPEndPoint)obj;
            try
            {
                hostEntry = Dns.GetHostEntry(ip.Address);
            }
            catch (Exception ex)
            {
                return;
            }
            this.Infos.LocalString = hostEntry.HostName;
            _haveResolvedAnAddress = true;
        }
    }
    private void getHostNameRemote(object obj)
    {
        if (obj != null)
        {
            IPHostEntry hostEntry;
            System.Net.IPEndPoint ip = (IPEndPoint)obj;
            try
            {
                hostEntry = Dns.GetHostEntry(ip.Address);
            }
            catch (Exception ex)
            {
                return;
            }
            this.Infos.RemoteString = hostEntry.HostName;
            _haveResolvedAnAddress = true;
        }
    }
}

