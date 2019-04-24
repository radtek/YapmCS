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

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
partial class frmConnection : System.Windows.Forms.Form
{

    // Form remplace la méthode Dispose pour nettoyer la liste des composants.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
                components.Dispose();
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    // Requise par le Concepteur Windows Form
    private System.ComponentModel.IContainer components;

    // REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    // Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    // Ne la modifiez pas à l'aide de l'éditeur de code.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.Security.SecureString SecureString1 = new System.Security.SecureString();
        this.optLocal = new System.Windows.Forms.RadioButton();
        this.optWMI = new System.Windows.Forms.RadioButton();
        this.optServer = new System.Windows.Forms.RadioButton();
        this.txtDesc = new System.Windows.Forms.TextBox();
        this.cmdConnect = new System.Windows.Forms.Button();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.gpServer = new System.Windows.Forms.GroupBox();
        this.cmdShowDatas = new System.Windows.Forms.Button();
        this.txtPort = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtServerIP = new System.Windows.Forms.TextBox();
        this.Label17 = new System.Windows.Forms.Label();
        this.gpWMI = new System.Windows.Forms.GroupBox();
        this.txtServerPassword = new SecurePasswordTextBox.SecureTextBox();
        this.Label14 = new System.Windows.Forms.Label();
        this.txtServerUser = new System.Windows.Forms.TextBox();
        this.Label13 = new System.Windows.Forms.Label();
        this.txtServerMachine = new System.Windows.Forms.TextBox();
        this.Label12 = new System.Windows.Forms.Label();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.gpShutdown = new System.Windows.Forms.GroupBox();
        this.cmdShutdown = new System.Windows.Forms.Button();
        this.cbShutdown = new System.Windows.Forms.ComboBox();
        this.chkForceShutdown = new System.Windows.Forms.CheckBox();
        this.cmdTerminal = new System.Windows.Forms.Button();
        this.optSnapshot = new System.Windows.Forms.RadioButton();
        this.gpSnapshot = new System.Windows.Forms.GroupBox();
        this.cmdBrowseSSFile = new System.Windows.Forms.Button();
        this.txtSSFile = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.openFile = new System.Windows.Forms.OpenFileDialog();
        this.lvData = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.cmdSSFileInfos = new System.Windows.Forms.Button();
        this.gpServer.SuspendLayout();
        this.gpWMI.SuspendLayout();
        this.gpShutdown.SuspendLayout();
        this.gpSnapshot.SuspendLayout();
        this.SuspendLayout();
        // 
        // optLocal
        // 
        this.optLocal.AutoSize = true;
        this.optLocal.Checked = true;
        this.optLocal.Location = new System.Drawing.Point(11, 12);
        this.optLocal.Name = "optLocal";
        this.optLocal.Size = new System.Drawing.Size(51, 17);
        this.optLocal.TabIndex = 0;
        this.optLocal.TabStop = true;
        this.optLocal.Text = "Local";
        this.optLocal.UseVisualStyleBackColor = true;
        // 
        // optWMI
        // 
        this.optWMI.AutoSize = true;
        this.optWMI.Location = new System.Drawing.Point(219, 12);
        this.optWMI.Name = "optWMI";
        this.optWMI.Size = new System.Drawing.Size(108, 17);
        this.optWMI.TabIndex = 1;
        this.optWMI.Text = "Remote via WMI";
        this.optWMI.UseVisualStyleBackColor = true;
        // 
        // optServer
        // 
        this.optServer.AutoSize = true;
        this.optServer.Location = new System.Drawing.Point(68, 12);
        this.optServer.Name = "optServer";
        this.optServer.Size = new System.Drawing.Size(145, 17);
        this.optServer.TabIndex = 2;
        this.optServer.Text = "Remote via YAPM server";
        this.optServer.UseVisualStyleBackColor = true;
        // 
        // txtDesc
        // 
        this.txtDesc.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.txtDesc.Location = new System.Drawing.Point(11, 66);
        this.txtDesc.Multiline = true;
        this.txtDesc.Name = "txtDesc";
        this.txtDesc.ReadOnly = true;
        this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtDesc.Size = new System.Drawing.Size(316, 81);
        this.txtDesc.TabIndex = 3;
        // 
        // cmdConnect
        // 
        this.cmdConnect.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdConnect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdConnect.Location = new System.Drawing.Point(43, 293);
        this.cmdConnect.Name = "cmdConnect";
        this.cmdConnect.Size = new System.Drawing.Size(103, 28);
        this.cmdConnect.TabIndex = 4;
        this.cmdConnect.Text = "Connect";
        this.cmdConnect.UseVisualStyleBackColor = true;
        // 
        // cmdCancel
        // 
        this.cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdCancel.Image = global::My.Resources.Resources.down16;
        this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdCancel.Location = new System.Drawing.Point(189, 293);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(107, 28);
        this.cmdCancel.TabIndex = 5;
        this.cmdCancel.Text = "      Hide window";
        this.cmdCancel.UseVisualStyleBackColor = true;
        // 
        // gpServer
        // 
        this.gpServer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.gpServer.Controls.Add(this.cmdShowDatas);
        this.gpServer.Controls.Add(this.txtPort);
        this.gpServer.Controls.Add(this.Label1);
        this.gpServer.Controls.Add(this.txtServerIP);
        this.gpServer.Controls.Add(this.Label17);
        this.gpServer.Location = new System.Drawing.Point(13, 212);
        this.gpServer.Name = "gpServer";
        this.gpServer.Size = new System.Drawing.Size(314, 73);
        this.gpServer.TabIndex = 6;
        this.gpServer.TabStop = false;
        // 
        // cmdShowDatas
        // 
        this.cmdShowDatas.Location = new System.Drawing.Point(159, 44);
        this.cmdShowDatas.Name = "cmdShowDatas";
        this.cmdShowDatas.Size = new System.Drawing.Size(146, 23);
        this.cmdShowDatas.TabIndex = 14;
        this.cmdShowDatas.Text = "Show received data";
        this.cmdShowDatas.UseVisualStyleBackColor = true;
        // 
        // txtPort
        // 
        this.txtPort.Location = new System.Drawing.Point(43, 45);
        this.txtPort.Name = "txtPort";
        this.txtPort.Size = new System.Drawing.Size(73, 22);
        this.txtPort.TabIndex = 13;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(7, 48);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(28, 13);
        this.Label1.TabIndex = 12;
        this.Label1.Text = "Port";
        // 
        // txtServerIP
        // 
        this.txtServerIP.Location = new System.Drawing.Point(64, 17);
        this.txtServerIP.Name = "txtServerIP";
        this.txtServerIP.Size = new System.Drawing.Size(87, 22);
        this.txtServerIP.TabIndex = 11;
        // 
        // Label17
        // 
        this.Label17.AutoSize = true;
        this.Label17.Location = new System.Drawing.Point(7, 20);
        this.Label17.Name = "Label17";
        this.Label17.Size = new System.Drawing.Size(51, 13);
        this.Label17.TabIndex = 10;
        this.Label17.Text = "Machine";
        // 
        // gpWMI
        // 
        this.gpWMI.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.gpWMI.Controls.Add(this.txtServerPassword);
        this.gpWMI.Controls.Add(this.Label14);
        this.gpWMI.Controls.Add(this.txtServerUser);
        this.gpWMI.Controls.Add(this.Label13);
        this.gpWMI.Controls.Add(this.txtServerMachine);
        this.gpWMI.Controls.Add(this.Label12);
        this.gpWMI.Location = new System.Drawing.Point(13, 212);
        this.gpWMI.Name = "gpWMI";
        this.gpWMI.Size = new System.Drawing.Size(314, 73);
        this.gpWMI.TabIndex = 7;
        this.gpWMI.TabStop = false;
        // 
        // txtServerPassword
        // 
        this.txtServerPassword.Location = new System.Drawing.Point(221, 45);
        this.txtServerPassword.Name = "txtServerPassword";
        this.txtServerPassword.PasswordChar = (char)42;
        this.txtServerPassword.SecureText = SecureString1;
        this.txtServerPassword.Size = new System.Drawing.Size(87, 22);
        this.txtServerPassword.TabIndex = 15;
        this.txtServerPassword.UseSystemPasswordChar = true;
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(159, 48);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(56, 13);
        this.Label14.TabIndex = 14;
        this.Label14.Text = "Password";
        // 
        // txtServerUser
        // 
        this.txtServerUser.Location = new System.Drawing.Point(43, 45);
        this.txtServerUser.Name = "txtServerUser";
        this.txtServerUser.Size = new System.Drawing.Size(108, 22);
        this.txtServerUser.TabIndex = 13;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(7, 48);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(30, 13);
        this.Label13.TabIndex = 12;
        this.Label13.Text = "User";
        // 
        // txtServerMachine
        // 
        this.txtServerMachine.Location = new System.Drawing.Point(64, 17);
        this.txtServerMachine.Name = "txtServerMachine";
        this.txtServerMachine.Size = new System.Drawing.Size(87, 22);
        this.txtServerMachine.TabIndex = 11;
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(7, 20);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(51, 13);
        this.Label12.TabIndex = 10;
        this.Label12.Text = "Machine";
        // 
        // Timer
        // 
        this.Timer.Enabled = true;
        // 
        // gpShutdown
        // 
        this.gpShutdown.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.gpShutdown.Controls.Add(this.cmdShutdown);
        this.gpShutdown.Controls.Add(this.cbShutdown);
        this.gpShutdown.Controls.Add(this.chkForceShutdown);
        this.gpShutdown.Location = new System.Drawing.Point(13, 153);
        this.gpShutdown.Name = "gpShutdown";
        this.gpShutdown.Size = new System.Drawing.Size(308, 53);
        this.gpShutdown.TabIndex = 8;
        this.gpShutdown.TabStop = false;
        this.gpShutdown.Text = "Shutdown local system";
        // 
        // cmdShutdown
        // 
        this.cmdShutdown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdShutdown.Location = new System.Drawing.Point(260, 17);
        this.cmdShutdown.Name = "cmdShutdown";
        this.cmdShutdown.Size = new System.Drawing.Size(42, 23);
        this.cmdShutdown.TabIndex = 2;
        this.cmdShutdown.Text = "Go";
        this.cmdShutdown.UseVisualStyleBackColor = true;
        // 
        // cbShutdown
        // 
        this.cbShutdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbShutdown.FormattingEnabled = true;
        this.cbShutdown.Items.AddRange(new object[] { "Restart", "Shutdown", "Poweroff", "Sleep", "Poweroff", "Logoff", "Lock" });
        this.cbShutdown.Location = new System.Drawing.Point(70, 19);
        this.cbShutdown.Name = "cbShutdown";
        this.cbShutdown.Size = new System.Drawing.Size(184, 21);
        this.cbShutdown.TabIndex = 1;
        // 
        // chkForceShutdown
        // 
        this.chkForceShutdown.AutoSize = true;
        this.chkForceShutdown.Location = new System.Drawing.Point(10, 21);
        this.chkForceShutdown.Name = "chkForceShutdown";
        this.chkForceShutdown.Size = new System.Drawing.Size(54, 17);
        this.chkForceShutdown.TabIndex = 0;
        this.chkForceShutdown.Text = "Force";
        this.chkForceShutdown.UseVisualStyleBackColor = true;
        // 
        // cmdTerminal
        // 
        this.cmdTerminal.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdTerminal.Location = new System.Drawing.Point(172, 228);
        this.cmdTerminal.Name = "cmdTerminal";
        this.cmdTerminal.Size = new System.Drawing.Size(146, 23);
        this.cmdTerminal.TabIndex = 16;
        this.cmdTerminal.Text = "Terminal Services Client";
        this.cmdTerminal.UseVisualStyleBackColor = true;
        // 
        // optSnapshot
        // 
        this.optSnapshot.AutoSize = true;
        this.optSnapshot.Location = new System.Drawing.Point(11, 35);
        this.optSnapshot.Name = "optSnapshot";
        this.optSnapshot.Size = new System.Drawing.Size(130, 17);
        this.optSnapshot.TabIndex = 3;
        this.optSnapshot.Text = "System snapshot file";
        this.optSnapshot.UseVisualStyleBackColor = true;
        // 
        // gpSnapshot
        // 
        this.gpSnapshot.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.gpSnapshot.Controls.Add(this.cmdSSFileInfos);
        this.gpSnapshot.Controls.Add(this.cmdBrowseSSFile);
        this.gpSnapshot.Controls.Add(this.txtSSFile);
        this.gpSnapshot.Controls.Add(this.Label4);
        this.gpSnapshot.Location = new System.Drawing.Point(13, 219);
        this.gpSnapshot.Name = "gpSnapshot";
        this.gpSnapshot.Size = new System.Drawing.Size(314, 51);
        this.gpSnapshot.TabIndex = 18;
        this.gpSnapshot.TabStop = false;
        this.gpSnapshot.Visible = false;
        // 
        // cmdBrowseSSFile
        // 
        this.cmdBrowseSSFile.Location = new System.Drawing.Point(252, 15);
        this.cmdBrowseSSFile.Name = "cmdBrowseSSFile";
        this.cmdBrowseSSFile.Size = new System.Drawing.Size(25, 23);
        this.cmdBrowseSSFile.TabIndex = 12;
        this.cmdBrowseSSFile.Text = "...";
        this.cmdBrowseSSFile.UseVisualStyleBackColor = true;
        // 
        // txtSSFile
        // 
        this.txtSSFile.Location = new System.Drawing.Point(128, 17);
        this.txtSSFile.Name = "txtSSFile";
        this.txtSSFile.Size = new System.Drawing.Size(118, 22);
        this.txtSSFile.TabIndex = 11;
        this.txtSSFile.Text = "";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(7, 20);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(115, 13);
        this.Label4.TabIndex = 10;
        this.Label4.Text = "System Snapshot File";
        // 
        // openFile
        // 
        this.openFile.Filter = "System Snapshot File (*.ssf)|*.ssf|All Files (*.*)|*.*";
        this.openFile.RestoreDirectory = true;
        this.openFile.SupportMultiDottedExtensions = true;
        this.openFile.Title = "Choose System Snapshot File to open";
        // 
        // lvData
        // 
        this.lvData.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2 });
        this.lvData.FullRowSelect = true;
        this.lvData.Location = new System.Drawing.Point(345, 3);
        this.lvData.Name = "lvData";
        this.lvData.OverriddenDoubleBuffered = true;
        this.lvData.Size = new System.Drawing.Size(289, 326);
        this.lvData.TabIndex = 17;
        this.lvData.UseCompatibleStateImageBehavior = false;
        this.lvData.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Time";
        this.ColumnHeader1.Width = 143;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Command received";
        this.ColumnHeader2.Width = 349;
        // 
        // cmdSSFileInfos
        // 
        this.cmdSSFileInfos.Image = global::My.Resources.Resources.information_frame;
        this.cmdSSFileInfos.Location = new System.Drawing.Point(283, 14);
        this.cmdSSFileInfos.Name = "cmdSSFileInfos";
        this.cmdSSFileInfos.Size = new System.Drawing.Size(25, 25);
        this.cmdSSFileInfos.TabIndex = 13;
        this.cmdSSFileInfos.UseVisualStyleBackColor = true;
        // 
        // frmConnection
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(338, 330);
        this.Controls.Add(this.gpSnapshot);
        this.Controls.Add(this.optSnapshot);
        this.Controls.Add(this.lvData);
        this.Controls.Add(this.cmdTerminal);
        this.Controls.Add(this.gpShutdown);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this.cmdConnect);
        this.Controls.Add(this.txtDesc);
        this.Controls.Add(this.optServer);
        this.Controls.Add(this.optWMI);
        this.Controls.Add(this.optLocal);
        this.Controls.Add(this.gpWMI);
        this.Controls.Add(this.gpServer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "frmConnection";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Connected";
        this.gpServer.ResumeLayout(false);
        this.gpServer.PerformLayout();
        this.gpWMI.ResumeLayout(false);
        this.gpWMI.PerformLayout();
        this.gpShutdown.ResumeLayout(false);
        this.gpShutdown.PerformLayout();
        this.gpSnapshot.ResumeLayout(false);
        this.gpSnapshot.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.RadioButton _optLocal;

    internal System.Windows.Forms.RadioButton optLocal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optLocal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optLocal != null)
            {
            }

            _optLocal = value;
            if (_optLocal != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optWMI;

    internal System.Windows.Forms.RadioButton optWMI
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optWMI;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optWMI != null)
            {
            }

            _optWMI = value;
            if (_optWMI != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optServer;

    internal System.Windows.Forms.RadioButton optServer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optServer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optServer != null)
            {
            }

            _optServer = value;
            if (_optServer != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtDesc;

    internal System.Windows.Forms.TextBox txtDesc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtDesc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtDesc != null)
            {
            }

            _txtDesc = value;
            if (_txtDesc != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdConnect;

    internal System.Windows.Forms.Button cmdConnect
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdConnect;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdConnect != null)
            {
            }

            _cmdConnect = value;
            if (_cmdConnect != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCancel;

    internal System.Windows.Forms.Button cmdCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCancel != null)
            {
            }

            _cmdCancel = value;
            if (_cmdCancel != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpServer;

    internal System.Windows.Forms.GroupBox gpServer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpServer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpServer != null)
            {
            }

            _gpServer = value;
            if (_gpServer != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpWMI;

    internal System.Windows.Forms.GroupBox gpWMI
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpWMI;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpWMI != null)
            {
            }

            _gpWMI = value;
            if (_gpWMI != null)
            {
            }
        }
    }

    private SecurePasswordTextBox.SecureTextBox _txtServerPassword;

    internal SecurePasswordTextBox.SecureTextBox txtServerPassword
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServerPassword;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServerPassword != null)
            {
            }

            _txtServerPassword = value;
            if (_txtServerPassword != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label14;

    internal System.Windows.Forms.Label Label14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label14 != null)
            {
            }

            _Label14 = value;
            if (_Label14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServerUser;

    internal System.Windows.Forms.TextBox txtServerUser
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServerUser;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServerUser != null)
            {
            }

            _txtServerUser = value;
            if (_txtServerUser != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label13;

    internal System.Windows.Forms.Label Label13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label13 != null)
            {
            }

            _Label13 = value;
            if (_Label13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServerMachine;

    internal System.Windows.Forms.TextBox txtServerMachine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServerMachine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServerMachine != null)
            {
            }

            _txtServerMachine = value;
            if (_txtServerMachine != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label12;

    internal System.Windows.Forms.Label Label12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label12 != null)
            {
            }

            _Label12 = value;
            if (_Label12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServerIP;

    internal System.Windows.Forms.TextBox txtServerIP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServerIP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServerIP != null)
            {
            }

            _txtServerIP = value;
            if (_txtServerIP != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label17;

    internal System.Windows.Forms.Label Label17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label17 != null)
            {
            }

            _Label17 = value;
            if (_Label17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _Timer;

    internal System.Windows.Forms.Timer Timer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Timer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Timer != null)
            {
            }

            _Timer = value;
            if (_Timer != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpShutdown;

    internal System.Windows.Forms.GroupBox gpShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpShutdown != null)
            {
            }

            _gpShutdown = value;
            if (_gpShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShutdown;

    internal System.Windows.Forms.Button cmdShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShutdown != null)
            {
            }

            _cmdShutdown = value;
            if (_cmdShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbShutdown;

    internal System.Windows.Forms.ComboBox cbShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbShutdown != null)
            {
            }

            _cbShutdown = value;
            if (_cbShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkForceShutdown;

    internal System.Windows.Forms.CheckBox chkForceShutdown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkForceShutdown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkForceShutdown != null)
            {
            }

            _chkForceShutdown = value;
            if (_chkForceShutdown != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtPort;

    internal System.Windows.Forms.TextBox txtPort
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtPort;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtPort != null)
            {
            }

            _txtPort = value;
            if (_txtPort != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label1;

    internal System.Windows.Forms.Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label1 != null)
            {
            }

            _Label1 = value;
            if (_Label1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdTerminal;

    internal System.Windows.Forms.Button cmdTerminal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdTerminal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdTerminal != null)
            {
            }

            _cmdTerminal = value;
            if (_cmdTerminal != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShowDatas;

    internal System.Windows.Forms.Button cmdShowDatas
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShowDatas;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShowDatas != null)
            {
            }

            _cmdShowDatas = value;
            if (_cmdShowDatas != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvData;

    internal DoubleBufferedLV lvData
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvData;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvData != null)
            {
            }

            _lvData = value;
            if (_lvData != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader1;

    internal System.Windows.Forms.ColumnHeader ColumnHeader1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader1 != null)
            {
            }

            _ColumnHeader1 = value;
            if (_ColumnHeader1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader2;

    internal System.Windows.Forms.ColumnHeader ColumnHeader2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader2 != null)
            {
            }

            _ColumnHeader2 = value;
            if (_ColumnHeader2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optSnapshot;

    internal System.Windows.Forms.RadioButton optSnapshot
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optSnapshot;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optSnapshot != null)
            {
            }

            _optSnapshot = value;
            if (_optSnapshot != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpSnapshot;

    internal System.Windows.Forms.GroupBox gpSnapshot
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpSnapshot;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpSnapshot != null)
            {
            }

            _gpSnapshot = value;
            if (_gpSnapshot != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdBrowseSSFile;

    internal System.Windows.Forms.Button cmdBrowseSSFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowseSSFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowseSSFile != null)
            {
            }

            _cmdBrowseSSFile = value;
            if (_cmdBrowseSSFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSSFile;

    internal System.Windows.Forms.TextBox txtSSFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSSFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSSFile != null)
            {
            }

            _txtSSFile = value;
            if (_txtSSFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label4;

    internal System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label4 != null)
            {
            }

            _Label4 = value;
            if (_Label4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.OpenFileDialog _openFile;

    internal System.Windows.Forms.OpenFileDialog openFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openFile != null)
            {
            }

            _openFile = value;
            if (_openFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSSFileInfos;

    internal System.Windows.Forms.Button cmdSSFileInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSSFileInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSSFileInfos != null)
            {
            }

            _cmdSSFileInfos = value;
            if (_cmdSSFileInfos != null)
            {
            }
        }
    }
}

