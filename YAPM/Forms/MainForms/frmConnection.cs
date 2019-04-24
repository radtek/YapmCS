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
using Common.Misc;
using Native.Api.Enums;

public partial class frmConnection
{
    private int REMOTE_PORT;
    private cConnection __formConnectionReference;

    private cConnection _formConnectionReference
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __formConnectionReference;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__formConnectionReference != null)
            {
            }

            __formConnectionReference = value;
            if (__formConnectionReference != null)
            {
            }
        }
    }

    public delegate void AddItemToReceivedDataList(ref cSocketData dat);

    private string _localDesc = "Local connection monitors all processes and services running on the local machine.";
    private string _wmiDesc = "Remote connection via WMI monitors all processes and services running on a remote machine. You will need a username and password of the remote machine, WMI needs to be installed on both machines (your machine and the remote machine), and your firewall have to accept the connection. Furthermore, not all informations and actions on your processes are available. If possible, you should use 'remote via YAPM server' instead.";
    private string _serverDes = "Remote connection via WMI YAPM server monitors all processes and services running on a remote machine. You will need the IP address of the remote machine, and the associated port must be available (you might need to configure your firewall). You will also need to run yapmserv.exe on the remote machine. This is the best way, if possible, to monitor a remote machine.";
    private string _snapshotDesc = "System Snapshot File allows to display informations about all processes and services which were running when the snapshot file has been saved.";

    public frmConnection(ref cConnection connection)
    {
        InitializeComponent();
        _formConnectionReference = connection;
    }

    private void optLocal_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        changeInfos();
    }

    private void frmConnection_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }

    private void frmConnection_Load(object sender, System.EventArgs e)
    {
        Misc.HideWithEchapKey(ref this);
        changeInfos();
        Native.Functions.Misc.SetTheme(this.lvData.Handle);

        Misc.SetToolTip(this.txtDesc, "Description of the type of connection");
        Misc.SetToolTip(this.txtServerIP, "Name (or IP) of the server machine");
        Misc.SetToolTip(this.txtServerMachine, "Name of the remote machine");
        Misc.SetToolTip(this.txtServerPassword, "Specify a password of an account of the remote machine");
        Misc.SetToolTip(this.txtServerUser, "Specify the user name of an account of the remote machine");
        Misc.SetToolTip(this.cbShutdown, "Shutdown action");
        Misc.SetToolTip(this.cmdCancel, "Hide this window");
        Misc.SetToolTip(this.cmdConnect, "Connect or disconnect from the machine");
        Misc.SetToolTip(this.cmdShutdown, "Shutdown the specified machine");
        Misc.SetToolTip(this.chkForceShutdown, "Force (or not) the shutdown");
        Misc.SetToolTip(this.optLocal, "Local connection");
        Misc.SetToolTip(this.optServer, "Remote connection with the use of a server");
        Misc.SetToolTip(this.optWMI, "Remote connection with the use of WMI");
        Misc.SetToolTip(this.txtPort, "Port to use to connect to remote machine");
        Misc.SetToolTip(this.cmdTerminal, "Start Microsoft terminal service client");
        Misc.SetToolTip(this.cmdShowDatas, "Show/hide list of data received from remote machine");
        Misc.SetToolTip(this.optSnapshot, "Use a 'system snaphost file' to display informations");
        Misc.SetToolTip(this.txtSSFile, "Path of the System Snapshot File.");
        Misc.SetToolTip(this.cmdBrowseSSFile, "Select the System Snapshot File.");
        Misc.SetToolTip(this.cmdSSFileInfos, "Show information about the System Snapshot File.");

        this.txtPort.Text = System.Convert.ToString(My.MySettingsProperty.Settings.RemotePort);
        this.txtServerMachine.Text = My.MySettingsProperty.Settings.RemoteMachineNameW;
        this.txtServerIP.Text = My.MySettingsProperty.Settings.RemoteMachineName;
        this.txtServerUser.Text = My.MySettingsProperty.Settings.RemoteMachineUserW;
        this.cmdTerminal.Enabled = System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mstsc.exe");
    }

    private void optServer_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        changeInfos();
    }

    private void optWMI_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        changeInfos();
    }

    private void changeInfos()
    {
        this.gpServer.Visible = optServer.Checked;
        this.lvData.Enabled = this.optServer.Checked;
        this.gpWMI.Visible = optWMI.Checked;
        this.gpSnapshot.Visible = optSnapshot.Checked;
        this.cmdSSFileInfos.Enabled = Program.Connection.ConnectionType == cConnection.TypeOfConnection.SnapshotFile && Program.Connection.IsConnected;

        if (optLocal.Checked)
        {
            this.txtDesc.Text = _localDesc;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        }
        else if (optServer.Checked)
        {
            this.txtDesc.Text = _serverDes;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaSocket);
        }
        else if (optSnapshot.Checked)
        {
            this.txtDesc.Text = _snapshotDesc;
            this.gpShutdown.Enabled = false;
        }
        else
        {
            this.txtDesc.Text = _wmiDesc;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        }

        updateShutdown();
    }

    private void updateShutdown()
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
        Static _oldType As cConnection.TypeOfConnection

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
        Static _oldConnected As Boolean = True

 */
        if (optLocal.Checked)
        {
            if (_formConnectionReference != null && (_oldType != _formConnectionReference.ConnectionType || _formConnectionReference.IsConnected != _oldConnected))
            {
                this.cbShutdown.Items.Clear();
                string[] _items = new[] { "Restart", "Shutdown", "Poweroff", "Sleep", "Logoff", "Lock" };
                this.cbShutdown.Items.AddRange(_items);
                this.gpShutdown.Text = "Shutdown local system";
            }
            this.txtDesc.Text = _localDesc;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
            _oldType = cConnection.TypeOfConnection.LocalConnection;
        }
        else if (optServer.Checked)
        {
            if (_formConnectionReference != null && (_oldType != _formConnectionReference.ConnectionType || _formConnectionReference.IsConnected != _oldConnected))
            {
                this.cbShutdown.Items.Clear();
                string[] _items = new[] { "Restart", "Shutdown", "Poweroff", "Sleep", "Logoff", "Lock" };
                this.cbShutdown.Items.AddRange(_items);
                this.gpShutdown.Text = "Shutdown remote system via socket";
            }
            this.txtDesc.Text = _serverDes;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaSocket);
            _oldType = cConnection.TypeOfConnection.RemoteConnectionViaSocket;
        }
        else if (optSnapshot.Checked)
        {
        }
        else
        {
            if (_formConnectionReference != null && (_oldType != _formConnectionReference.ConnectionType || _formConnectionReference.IsConnected != _oldConnected))
            {
                this.cbShutdown.Items.Clear();
                string[] _items = new[] { "Restart", "Shutdown", "Poweroff", "Logoff" };
                this.cbShutdown.Items.AddRange(_items);
                this.gpShutdown.Text = "Shutdown remote system via WMI";
            }
            this.txtDesc.Text = _wmiDesc;
            this.gpShutdown.Enabled = (_formConnectionReference != null && _formConnectionReference.IsConnected && _formConnectionReference.ConnectionType == cConnection.TypeOfConnection.RemoteConnectionViaWMI);
            _oldType = cConnection.TypeOfConnection.RemoteConnectionViaWMI;
        }

        _oldConnected = (_formConnectionReference != null && _formConnectionReference.IsConnected);
    }

    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        switch (Program.Connection.ConnectionType)
        {
            case cConnection.TypeOfConnection.LocalConnection:
                {
                    this.optLocal.Checked = true;
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    this.optServer.Checked = true;
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    this.optWMI.Checked = true;
                    break;
                }
        }
        this.Hide();
        updateShutdown();
    }

    // Here we (dis)connect !
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string clientIp = "";

        cConnection.TypeOfConnection _connType;
        if (optLocal.Checked)
            _connType = cConnection.TypeOfConnection.LocalConnection;
        else if (optServer.Checked)
            _connType = cConnection.TypeOfConnection.RemoteConnectionViaSocket;
        else if (optSnapshot.Checked)
            _connType = cConnection.TypeOfConnection.SnapshotFile;
        else
            _connType = cConnection.TypeOfConnection.RemoteConnectionViaWMI;

        if (_formConnectionReference.IsConnected)
        {
            this.Text = "Disconnecting from current machine...";
            Program._frmMain.DisconnectFromMachine();
        }
        else
        {
            {
                var withBlock = Program.Connection;
                withBlock.ConnectionType = _connType;
                if (_connType == cConnection.TypeOfConnection.RemoteConnectionViaSocket)
                {

                    // First we have to get the available NICs
                    List<Native.Api.Structs.NicDescription> nics = Common.Misc.GetNics();
                    if (nics.Count == 0)
                    {
                        // No network card !
                        Misc.ShowMsg("Connection to remote machine", "Failed to connect to remote machine.", "You cannot connect to the server as no network card is installed on your machine.", MessageBoxButtons.OK, TaskDialogIcon.Error);
                        return;
                    }
                    else if (nics.Count == 1)
                        // Only one card, OK !
                        clientIp = nics[0].Ip;
                    else
                    {
                        // User have to choose the card to use
                        frmChooseClientIp frm = new frmChooseClientIp(nics);
                        frm.ShowDialog();
                        if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
                            return;
                        clientIp = frm.ChosenIp;
                    }

                    withBlock.SocketParameters = new cConnection.SocketConnectionParameters(this.txtServerIP.Text, REMOTE_PORT, clientIp);
                }
                else if (_connType == cConnection.TypeOfConnection.RemoteConnectionViaWMI)
                    withBlock.WmiParameters = new cConnection.WMIConnectionParameters(this.txtServerMachine.Text, this.txtServerUser.Text, this.txtServerPassword.SecureText);
                else if (_connType == cConnection.TypeOfConnection.SnapshotFile)
                    withBlock.SnapshotFile = this.txtSSFile.Text;
            }
            this.Text = "Connecting to machine...";
            Program._frmMain.ConnectToMachine();
        }
    }

    // Change the caption of the button 'Connect/Disconnect'
    private void ChangeCaption()
    {
        if (_formConnectionReference.IsConnected)
        {
            this.cmdConnect.Text = "Disconnect";
            this.Text = "Connected";
        }
        else
        {
            this.cmdConnect.Text = "Connect";
            this.Text = "Disconnected";
        }
        changeInfos();
    }

    // BAD WAY (because of withevents, this is raised JUST WHEN Program.Connection.Connect
    // is call. BAD THING (should wait asyncMethod, but there are LOTS of asyncMethids
    // (one for each lvItem).
    // Private Sub _formConnectionReference_Connected() Handles _formConnectionReference.Connected
    // Call ChangeCaption()
    // End Sub
    // Private Sub _formConnectionReference_Disconnected() Handles _formConnectionReference.Disconnected
    // Call ChangeCaption()
    // End Sub

    // BAD WAY -> should kick all timers from project (see commented lines about delegates
    // just below)
    private void Timer_Tick(System.Object sender, System.EventArgs e)
    {
        ChangeCaption();
    }

    private void frmConnection_VisibleChanged(object sender, System.EventArgs e)
    {
        this.Timer.Enabled = this.Visible;
    }

    // Private Sub _formConnectionReference_Connected() Handles _formConnectionReference.Connected
    // Try
    // Dim _deg As New degActivateShutdown(AddressOf ActivateShutdown)
    // Me.Invoke(_deg, True)
    // Catch ex As Exception
    // '
    // End Try
    // End Sub

    // Private Sub _formConnectionReference_Disconnected() Handles _formConnectionReference.Disconnected
    // Try
    // Dim _deg As New degActivateShutdown(AddressOf ActivateShutdown)
    // Me.Invoke(_deg, False)
    // Catch ex As Exception
    // '
    // End Try
    // End Sub

    // Private Delegate Sub degActivateShutdown(ByVal value As Boolean)
    // Private Sub ActivateShutdown(ByVal value As Boolean)
    // Me.gpShutdown.Enabled = value
    // End Sub

    private void txtPort_TextChanged(System.Object sender, System.EventArgs e)
    {
        My.MySettingsProperty.Settings.RemotePort = System.Convert.ToInt32(Conversion.Val(this.txtPort.Text));
        REMOTE_PORT = My.MySettingsProperty.Settings.RemotePort;
    }


    private asyncCallbackShutdownAction _shutdownAction;
    public int ShutdownAction(Native.Api.Enums.ShutdownType type, bool force)
    {
        if (_shutdownAction == null)
            _shutdownAction = new asyncCallbackShutdownAction(new asyncCallbackShutdownAction.HasShutdowned(shutdownDone), ref Program._frmMain._shutdownConnection);

        System.Threading.WaitCallback t = new System.Threading.WaitCallback(_shutdownAction.Process());

        System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackShutdownAction.poolObj(type, force));
    }
    private void shutdownDone(bool Success, Native.Api.Enums.ShutdownType type, string msg)
    {
        if (Success == false)
            Misc.ShowMsg("Shutdown command", "Could not send " + type.ToString() + " command.", msg, MessageBoxButtons.OK, TaskDialogIcon.Error);
    }

    private void cmdShutdown_Click(System.Object sender, System.EventArgs e)
    {
        switch (this.cbShutdown.Text)
        {
            case "Restart":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Restart, this.chkForceShutdown.Checked);
                    break;
                }

            case "Shutdown":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Shutdown, this.chkForceShutdown.Checked);
                    break;
                }

            case "Poweroff":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Poweroff, this.chkForceShutdown.Checked);
                    break;
                }

            case "Sleep":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Sleep, this.chkForceShutdown.Checked);
                    break;
                }

            case "Logoff":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Logoff, this.chkForceShutdown.Checked);
                    break;
                }

            case "Lock":
                {
                    ShutdownAction(Native.Api.Enums.ShutdownType.Lock, this.chkForceShutdown.Checked);
                    break;
                }
        }
    }


    private void cmdTerminal_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mstsc.exe", this.Handle);
    }

    private void txtServerMachine_TextChanged(System.Object sender, System.EventArgs e)
    {
        My.MySettingsProperty.Settings.RemoteMachineNameW = this.txtServerMachine.Text;
    }

    private void txtServerUser_TextChanged(System.Object sender, System.EventArgs e)
    {
        My.MySettingsProperty.Settings.RemoteMachineUserW = this.txtServerUser.Text;
    }

    private void txtServerIP_TextChanged(System.Object sender, System.EventArgs e)
    {
        My.MySettingsProperty.Settings.RemoteMachineName = this.txtServerIP.Text;
    }

    private void cmdShowDatas_Click(object sender, System.EventArgs e)
    {
        if (this.Width == 643)
        {
            this.Width = 347;
            this.cmdShowDatas.Text = "Show received data";
        }
        else
        {
            this.Width = 643;
            this.cmdShowDatas.Text = "Hide received data";
        }
    }

    // Add an item to the list of data received from remote server
    public void impAddItemToReceivedDataList(ref cSocketData dat)
    {
        ListViewItem it = new ListViewItem(DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString());
        it.SubItems.Add(dat.ToString());
        this.lvData.Items.Add(it);
    }

    private void cmdBrowseSSFile_Click(System.Object sender, System.EventArgs e)
    {
        DialogResult ret = this.openFile.ShowDialog();
        if (ret == System.Windows.Forms.DialogResult.OK)
            this.txtSSFile.Text = this.openFile.FileName;
    }

    private void cmdSSFileInfos_Click(System.Object sender, System.EventArgs e)
    {
        // Display informations about the snapshot
        cSnapshot snap = Program.Connection.Snapshot;
        if (snap != null)
        {
            string s = Constants.vbNewLine + "FILE INFO" + Constants.vbNewLine + Constants.vbNewLine + "Date : " + snap.Date + Constants.vbNewLine + "FileVersion : " + snap.FileVersion + Constants.vbNewLine + Constants.vbNewLine;
            if (snap.SystemInformation != null)
                s += "SYSTEM INFO" + Constants.vbNewLine + Constants.vbNewLine + "ComputerName : " + snap.SystemInformation.ComputerName + Constants.vbNewLine + "UserName : " + snap.SystemInformation.UserName + Constants.vbNewLine + "Culture : " + snap.SystemInformation.Culture.ToString() + Constants.vbNewLine + "IntPtrSize : " + snap.SystemInformation.IntPtrSize + Constants.vbNewLine + "OSFullName : " + snap.SystemInformation.OSFullName + Constants.vbNewLine + "OSPlatform : " + snap.SystemInformation.OSPlatform + Constants.vbNewLine + "OSVersion : " + snap.SystemInformation.OSVersion + Constants.vbNewLine + "AvailablePhysicalMemory : " + Misc.GetFormatedSize(snap.SystemInformation.AvailablePhysicalMemory) + Constants.vbNewLine + "AvailableVirtualMemory : " + Misc.GetFormatedSize(snap.SystemInformation.AvailableVirtualMemory) + Constants.vbNewLine + "TotalPhysicalMemory : " + Misc.GetFormatedSize(snap.SystemInformation.TotalPhysicalMemory) + Constants.vbNewLine + "TotalVirtualMemory : " + Misc.GetFormatedSize(snap.SystemInformation.TotalVirtualMemory);
            Misc.ShowMsg("System Snapshot File information", "Informations about the file " + Program.Connection.SnapshotFile, s, MessageBoxButtons.OK);
        }
    }
}
