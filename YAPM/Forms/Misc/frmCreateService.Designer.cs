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
partial class frmCreateService : System.Windows.Forms.Form
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
        System.Security.SecureString SecureString1 = new System.Security.SecureString();
        this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.OK_Button = new System.Windows.Forms.Button();
        this.Cancel_Button = new System.Windows.Forms.Button();
        this.label5 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.cbErrControl = new System.Windows.Forms.ComboBox();
        this.cbStartType = new System.Windows.Forms.ComboBox();
        this.cbServType = new System.Windows.Forms.ComboBox();
        this.optLocal = new System.Windows.Forms.RadioButton();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.txtServerPassword = new SecurePasswordTextBox.SecureTextBox();
        this.lblPwd = new System.Windows.Forms.Label();
        this.txtUser = new System.Windows.Forms.TextBox();
        this.lblUser = new System.Windows.Forms.Label();
        this.txtMachine = new System.Windows.Forms.TextBox();
        this.lblMachine = new System.Windows.Forms.Label();
        this.optRemote = new System.Windows.Forms.RadioButton();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.cmdBrowse = new System.Windows.Forms.Button();
        this.Label14 = new System.Windows.Forms.Label();
        this.txtArgs = new System.Windows.Forms.TextBox();
        this.Label13 = new System.Windows.Forms.Label();
        this.txtPath = new System.Windows.Forms.TextBox();
        this.Label12 = new System.Windows.Forms.Label();
        this.txtDisplayName = new System.Windows.Forms.TextBox();
        this.Label11 = new System.Windows.Forms.Label();
        this.txtServiceName = new System.Windows.Forms.TextBox();
        this.Label10 = new System.Windows.Forms.Label();
        this.openDial = new System.Windows.Forms.OpenFileDialog();
        this.TableLayoutPanel1.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // TableLayoutPanel1
        // 
        this.TableLayoutPanel1.ColumnCount = 2;
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
        this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
        this.TableLayoutPanel1.Location = new System.Drawing.Point(12, 359);
        this.TableLayoutPanel1.Name = "TableLayoutPanel1";
        this.TableLayoutPanel1.RowCount = 1;
        this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Size = new System.Drawing.Size(327, 29);
        this.TableLayoutPanel1.TabIndex = 30;
        // 
        // OK_Button
        // 
        this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.OK_Button.Location = new System.Drawing.Point(48, 3);
        this.OK_Button.Name = "OK_Button";
        this.OK_Button.Size = new System.Drawing.Size(67, 23);
        this.OK_Button.TabIndex = 13;
        this.OK_Button.Text = "OK";
        // 
        // Cancel_Button
        // 
        this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Cancel_Button.Location = new System.Drawing.Point(211, 3);
        this.Cancel_Button.Name = "Cancel_Button";
        this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
        this.Cancel_Button.TabIndex = 14;
        this.Cancel_Button.Text = "Cancel";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(9, 176);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(72, 13);
        this.label5.TabIndex = 42;
        this.label5.Text = "Error control";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(10, 150);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(67, 13);
        this.label3.TabIndex = 40;
        this.label3.Text = "Service type";
        // 
        // cbErrControl
        // 
        this.cbErrControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbErrControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cbErrControl.FormattingEnabled = true;
        this.cbErrControl.Items.AddRange(new object[] { "Critical", "Ignore", "Normal", "Severe", "Unknown" });
        this.cbErrControl.Location = new System.Drawing.Point(90, 173);
        this.cbErrControl.Name = "cbErrControl";
        this.cbErrControl.Size = new System.Drawing.Size(237, 21);
        this.cbErrControl.TabIndex = 7;
        // 
        // cbStartType
        // 
        this.cbStartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbStartType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cbStartType.FormattingEnabled = true;
        this.cbStartType.Items.AddRange(new object[] { "BootStart", "SystemStart", "AutoStart", "DemandStart" });
        this.cbStartType.Location = new System.Drawing.Point(90, 121);
        this.cbStartType.Name = "cbStartType";
        this.cbStartType.Size = new System.Drawing.Size(237, 21);
        this.cbStartType.TabIndex = 5;
        // 
        // cbServType
        // 
        this.cbServType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbServType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cbServType.FormattingEnabled = true;
        this.cbServType.Items.AddRange(new object[] { "FileSystemDriver", "KernelDriver", "Adapter", "RecognizerDriver", "Win32OwnProcess", "Win32ShareProcess", "InteractiveProcess" });
        this.cbServType.Location = new System.Drawing.Point(90, 147);
        this.cbServType.Name = "cbServType";
        this.cbServType.Size = new System.Drawing.Size(237, 21);
        this.cbServType.TabIndex = 6;
        // 
        // optLocal
        // 
        this.optLocal.AutoSize = true;
        this.optLocal.Checked = true;
        this.optLocal.Location = new System.Drawing.Point(12, 21);
        this.optLocal.Name = "optLocal";
        this.optLocal.Size = new System.Drawing.Size(51, 17);
        this.optLocal.TabIndex = 8;
        this.optLocal.TabStop = true;
        this.optLocal.Text = "Local";
        this.optLocal.UseVisualStyleBackColor = true;
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.txtServerPassword);
        this.GroupBox1.Controls.Add(this.lblPwd);
        this.GroupBox1.Controls.Add(this.txtUser);
        this.GroupBox1.Controls.Add(this.lblUser);
        this.GroupBox1.Controls.Add(this.txtMachine);
        this.GroupBox1.Controls.Add(this.lblMachine);
        this.GroupBox1.Controls.Add(this.optRemote);
        this.GroupBox1.Controls.Add(this.optLocal);
        this.GroupBox1.Location = new System.Drawing.Point(12, 220);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(333, 128);
        this.GroupBox1.TabIndex = 45;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Machine";
        // 
        // txtServerPassword
        // 
        this.txtServerPassword.Enabled = false;
        this.txtServerPassword.Location = new System.Drawing.Point(122, 98);
        this.txtServerPassword.Name = "txtServerPassword";
        this.txtServerPassword.PasswordChar = (char)42;
        this.txtServerPassword.SecureText = SecureString1;
        this.txtServerPassword.Size = new System.Drawing.Size(205, 22);
        this.txtServerPassword.TabIndex = 12;
        this.txtServerPassword.UseSystemPasswordChar = true;
        // 
        // lblPwd
        // 
        this.lblPwd.AutoSize = true;
        this.lblPwd.Enabled = false;
        this.lblPwd.Location = new System.Drawing.Point(60, 101);
        this.lblPwd.Name = "lblPwd";
        this.lblPwd.Size = new System.Drawing.Size(56, 13);
        this.lblPwd.TabIndex = 50;
        this.lblPwd.Text = "Password";
        // 
        // txtUser
        // 
        this.txtUser.Enabled = false;
        this.txtUser.Location = new System.Drawing.Point(122, 73);
        this.txtUser.Name = "txtUser";
        this.txtUser.Size = new System.Drawing.Size(205, 22);
        this.txtUser.TabIndex = 11;
        // 
        // lblUser
        // 
        this.lblUser.AutoSize = true;
        this.lblUser.Enabled = false;
        this.lblUser.Location = new System.Drawing.Point(60, 76);
        this.lblUser.Name = "lblUser";
        this.lblUser.Size = new System.Drawing.Size(30, 13);
        this.lblUser.TabIndex = 48;
        this.lblUser.Text = "User";
        // 
        // txtMachine
        // 
        this.txtMachine.Enabled = false;
        this.txtMachine.Location = new System.Drawing.Point(122, 48);
        this.txtMachine.Name = "txtMachine";
        this.txtMachine.Size = new System.Drawing.Size(205, 22);
        this.txtMachine.TabIndex = 10;
        // 
        // lblMachine
        // 
        this.lblMachine.AutoSize = true;
        this.lblMachine.Enabled = false;
        this.lblMachine.Location = new System.Drawing.Point(60, 51);
        this.lblMachine.Name = "lblMachine";
        this.lblMachine.Size = new System.Drawing.Size(51, 13);
        this.lblMachine.TabIndex = 46;
        this.lblMachine.Text = "Machine";
        // 
        // optRemote
        // 
        this.optRemote.AutoSize = true;
        this.optRemote.Location = new System.Drawing.Point(69, 21);
        this.optRemote.Name = "optRemote";
        this.optRemote.Size = new System.Drawing.Size(64, 17);
        this.optRemote.TabIndex = 9;
        this.optRemote.Text = "Remote";
        this.optRemote.UseVisualStyleBackColor = true;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.cmdBrowse);
        this.GroupBox2.Controls.Add(this.Label14);
        this.GroupBox2.Controls.Add(this.txtArgs);
        this.GroupBox2.Controls.Add(this.Label13);
        this.GroupBox2.Controls.Add(this.txtPath);
        this.GroupBox2.Controls.Add(this.Label12);
        this.GroupBox2.Controls.Add(this.txtDisplayName);
        this.GroupBox2.Controls.Add(this.Label11);
        this.GroupBox2.Controls.Add(this.txtServiceName);
        this.GroupBox2.Controls.Add(this.label5);
        this.GroupBox2.Controls.Add(this.cbErrControl);
        this.GroupBox2.Controls.Add(this.Label10);
        this.GroupBox2.Controls.Add(this.cbStartType);
        this.GroupBox2.Controls.Add(this.label3);
        this.GroupBox2.Controls.Add(this.cbServType);
        this.GroupBox2.Location = new System.Drawing.Point(12, 12);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(333, 202);
        this.GroupBox2.TabIndex = 46;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "New service";
        // 
        // cmdBrowse
        // 
        this.cmdBrowse.Location = new System.Drawing.Point(298, 71);
        this.cmdBrowse.Name = "cmdBrowse";
        this.cmdBrowse.Size = new System.Drawing.Size(29, 23);
        this.cmdBrowse.TabIndex = 3;
        this.cmdBrowse.Text = "...";
        this.cmdBrowse.UseVisualStyleBackColor = true;
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(9, 124);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(56, 13);
        this.Label14.TabIndex = 8;
        this.Label14.Text = "Start type";
        // 
        // txtArgs
        // 
        this.txtArgs.Location = new System.Drawing.Point(90, 96);
        this.txtArgs.Name = "txtArgs";
        this.txtArgs.Size = new System.Drawing.Size(237, 22);
        this.txtArgs.TabIndex = 4;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(9, 99);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(63, 13);
        this.Label13.TabIndex = 6;
        this.Label13.Text = "Arguments";
        // 
        // txtPath
        // 
        this.txtPath.Location = new System.Drawing.Point(90, 71);
        this.txtPath.Name = "txtPath";
        this.txtPath.Size = new System.Drawing.Size(202, 22);
        this.txtPath.TabIndex = 2;
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(9, 74);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(30, 13);
        this.Label12.TabIndex = 4;
        this.Label12.Text = "Path";
        // 
        // txtDisplayName
        // 
        this.txtDisplayName.Location = new System.Drawing.Point(90, 46);
        this.txtDisplayName.Name = "txtDisplayName";
        this.txtDisplayName.Size = new System.Drawing.Size(237, 22);
        this.txtDisplayName.TabIndex = 1;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(9, 49);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(75, 13);
        this.Label11.TabIndex = 2;
        this.Label11.Text = "Display name";
        // 
        // txtServiceName
        // 
        this.txtServiceName.Location = new System.Drawing.Point(90, 20);
        this.txtServiceName.Name = "txtServiceName";
        this.txtServiceName.Size = new System.Drawing.Size(237, 22);
        this.txtServiceName.TabIndex = 0;
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(9, 23);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(36, 13);
        this.Label10.TabIndex = 0;
        this.Label10.Text = "Name";
        // 
        // openDial
        // 
        this.openDial.CheckFileExists = false;
        this.openDial.CheckPathExists = false;
        this.openDial.SupportMultiDottedExtensions = true;
        // 
        // frmCreateService
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(352, 397);
        this.Controls.Add(this.GroupBox2);
        this.Controls.Add(this.GroupBox1);
        this.Controls.Add(this.TableLayoutPanel1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmCreateService";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Create service";
        this.TableLayoutPanel1.ResumeLayout(false);
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.TableLayoutPanel _TableLayoutPanel1;

    internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TableLayoutPanel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TableLayoutPanel1 != null)
            {
            }

            _TableLayoutPanel1 = value;
            if (_TableLayoutPanel1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _OK_Button;

    internal System.Windows.Forms.Button OK_Button
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OK_Button;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_OK_Button != null)
            {
            }

            _OK_Button = value;
            if (_OK_Button != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _Cancel_Button;

    internal System.Windows.Forms.Button Cancel_Button
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Cancel_Button;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Cancel_Button != null)
            {
            }

            _Cancel_Button = value;
            if (_Cancel_Button != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _label5;

    private System.Windows.Forms.Label label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_label5 != null)
            {
            }

            _label5 = value;
            if (_label5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _label3;

    private System.Windows.Forms.Label label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_label3 != null)
            {
            }

            _label3 = value;
            if (_label3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbErrControl;

    private System.Windows.Forms.ComboBox cbErrControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbErrControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbErrControl != null)
            {
            }

            _cbErrControl = value;
            if (_cbErrControl != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbStartType;

    private System.Windows.Forms.ComboBox cbStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbStartType != null)
            {
            }

            _cbStartType = value;
            if (_cbStartType != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbServType;

    private System.Windows.Forms.ComboBox cbServType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbServType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbServType != null)
            {
            }

            _cbServType = value;
            if (_cbServType != null)
            {
            }
        }
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

    private System.Windows.Forms.GroupBox _GroupBox1;

    internal System.Windows.Forms.GroupBox GroupBox1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox1 != null)
            {
            }

            _GroupBox1 = value;
            if (_GroupBox1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtMachine;

    internal System.Windows.Forms.TextBox txtMachine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtMachine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtMachine != null)
            {
            }

            _txtMachine = value;
            if (_txtMachine != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblMachine;

    internal System.Windows.Forms.Label lblMachine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMachine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMachine != null)
            {
            }

            _lblMachine = value;
            if (_lblMachine != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optRemote;

    internal System.Windows.Forms.RadioButton optRemote
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optRemote;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optRemote != null)
            {
            }

            _optRemote = value;
            if (_optRemote != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPwd;

    internal System.Windows.Forms.Label lblPwd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPwd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPwd != null)
            {
            }

            _lblPwd = value;
            if (_lblPwd != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtUser;

    internal System.Windows.Forms.TextBox txtUser
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtUser;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtUser != null)
            {
            }

            _txtUser = value;
            if (_txtUser != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblUser;

    internal System.Windows.Forms.Label lblUser
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUser;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUser != null)
            {
            }

            _lblUser = value;
            if (_lblUser != null)
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

    private System.Windows.Forms.GroupBox _GroupBox2;

    internal System.Windows.Forms.GroupBox GroupBox2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox2 != null)
            {
            }

            _GroupBox2 = value;
            if (_GroupBox2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtArgs;

    internal System.Windows.Forms.TextBox txtArgs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtArgs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtArgs != null)
            {
            }

            _txtArgs = value;
            if (_txtArgs != null)
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

    private System.Windows.Forms.TextBox _txtPath;

    internal System.Windows.Forms.TextBox txtPath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtPath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtPath != null)
            {
            }

            _txtPath = value;
            if (_txtPath != null)
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

    private System.Windows.Forms.TextBox _txtDisplayName;

    internal System.Windows.Forms.TextBox txtDisplayName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtDisplayName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtDisplayName != null)
            {
            }

            _txtDisplayName = value;
            if (_txtDisplayName != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label11;

    internal System.Windows.Forms.Label Label11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label11 != null)
            {
            }

            _Label11 = value;
            if (_Label11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServiceName;

    internal System.Windows.Forms.TextBox txtServiceName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceName != null)
            {
            }

            _txtServiceName = value;
            if (_txtServiceName != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label10;

    internal System.Windows.Forms.Label Label10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label10 != null)
            {
            }

            _Label10 = value;
            if (_Label10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdBrowse;

    internal System.Windows.Forms.Button cmdBrowse
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowse;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowse != null)
            {
            }

            _cmdBrowse = value;
            if (_cmdBrowse != null)
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

    private System.Windows.Forms.OpenFileDialog _openDial;

    internal System.Windows.Forms.OpenFileDialog openDial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openDial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openDial != null)
            {
            }

            _openDial = value;
            if (_openDial != null)
            {
            }
        }
    }
}

