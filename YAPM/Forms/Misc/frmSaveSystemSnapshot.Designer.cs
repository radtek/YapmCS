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
partial class frmSaveSystemSnapshot : System.Windows.Forms.Form
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
        this.cmdBrowse = new System.Windows.Forms.Button();
        this.txtSSFile = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdCreate = new System.Windows.Forms.Button();
        this.cmdExit = new System.Windows.Forms.Button();
        this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        this.lblState = new System.Windows.Forms.Label();
        this.txtWarning = new System.Windows.Forms.TextBox();
        this.cmdOptions = new System.Windows.Forms.Button();
        this.lstOptions = new System.Windows.Forms.CheckedListBox();
        this.SuspendLayout();
        // 
        // cmdBrowse
        // 
        this.cmdBrowse.Location = new System.Drawing.Point(264, 10);
        this.cmdBrowse.Name = "cmdBrowse";
        this.cmdBrowse.Size = new System.Drawing.Size(30, 23);
        this.cmdBrowse.TabIndex = 0;
        this.cmdBrowse.Text = "...";
        this.cmdBrowse.UseVisualStyleBackColor = true;
        // 
        // txtSSFile
        // 
        this.txtSSFile.Location = new System.Drawing.Point(76, 12);
        this.txtSSFile.Name = "txtSSFile";
        this.txtSSFile.Size = new System.Drawing.Size(182, 22);
        this.txtSSFile.TabIndex = 1;
        this.txtSSFile.Text = "";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 17);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(58, 13);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Target file";
        // 
        // cmdCreate
        // 
        this.cmdCreate.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdCreate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdCreate.Image = global::My.Resources.Resources.save16;
        this.cmdCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdCreate.Location = new System.Drawing.Point(37, 171);
        this.cmdCreate.Name = "cmdCreate";
        this.cmdCreate.Size = new System.Drawing.Size(75, 23);
        this.cmdCreate.TabIndex = 5;
        this.cmdCreate.Text = "    Save";
        this.cmdCreate.UseVisualStyleBackColor = true;
        // 
        // cmdExit
        // 
        this.cmdExit.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdExit.Location = new System.Drawing.Point(192, 171);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(75, 23);
        this.cmdExit.TabIndex = 6;
        this.cmdExit.Text = "Exit";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // SaveFileDialog
        // 
        this.SaveFileDialog.Filter = "System Snapshot File (*.ssf)|*.ssf|All Files (*.*)|*.*";
        this.SaveFileDialog.RestoreDirectory = true;
        this.SaveFileDialog.SupportMultiDottedExtensions = true;
        this.SaveFileDialog.Title = "Select location for System Snapshot File";
        // 
        // lblState
        // 
        this.lblState.AutoSize = true;
        this.lblState.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblState.ForeColor = System.Drawing.Color.Navy;
        this.lblState.Location = new System.Drawing.Point(12, 44);
        this.lblState.Name = "lblState";
        this.lblState.Size = new System.Drawing.Size(42, 13);
        this.lblState.TabIndex = 7;
        this.lblState.Text = "Ready.";
        // 
        // txtWarning
        // 
        this.txtWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.txtWarning.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(0)), System.Convert.ToInt32(System.Convert.ToByte(0)));
        this.txtWarning.Location = new System.Drawing.Point(12, 70);
        this.txtWarning.Multiline = true;
        this.txtWarning.Name = "txtWarning";
        this.txtWarning.ReadOnly = true;
        this.txtWarning.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtWarning.Size = new System.Drawing.Size(282, 85);
        this.txtWarning.TabIndex = 8;
        // 
        // cmdOptions
        // 
        this.cmdOptions.Location = new System.Drawing.Point(219, 39);
        this.cmdOptions.Name = "cmdOptions";
        this.cmdOptions.Size = new System.Drawing.Size(75, 23);
        this.cmdOptions.TabIndex = 9;
        this.cmdOptions.Text = "Options >";
        this.cmdOptions.UseVisualStyleBackColor = true;
        // 
        // lstOptions
        // 
        this.lstOptions.CheckOnClick = true;
        this.lstOptions.FormattingEnabled = true;
        this.lstOptions.Items.AddRange(new object[] { "EnvironmentVariables", "Handles", "Heaps", "JobLimits", "Jobs", "MemoryRegions", "Modules", "NetworkConnections", "Privileges", "Services", "Tasks", "Threads", "Windows" });
        this.lstOptions.Location = new System.Drawing.Point(306, 5);
        this.lstOptions.Name = "lstOptions";
        this.lstOptions.Size = new System.Drawing.Size(167, 191);
        this.lstOptions.Sorted = true;
        this.lstOptions.TabIndex = 10;
        // 
        // frmSaveSystemSnapshot
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(304, 203);
        this.Controls.Add(this.lstOptions);
        this.Controls.Add(this.cmdOptions);
        this.Controls.Add(this.txtWarning);
        this.Controls.Add(this.lblState);
        this.Controls.Add(this.cmdExit);
        this.Controls.Add(this.cmdCreate);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.txtSSFile);
        this.Controls.Add(this.cmdBrowse);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmSaveSystemSnapshot";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Save a System Snapshot File";
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.Button _cmdCreate;

    internal System.Windows.Forms.Button cmdCreate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCreate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCreate != null)
            {
            }

            _cmdCreate = value;
            if (_cmdCreate != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdExit;

    internal System.Windows.Forms.Button cmdExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdExit != null)
            {
            }

            _cmdExit = value;
            if (_cmdExit != null)
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

    private System.Windows.Forms.SaveFileDialog _SaveFileDialog;

    internal System.Windows.Forms.SaveFileDialog SaveFileDialog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SaveFileDialog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SaveFileDialog != null)
            {
            }

            _SaveFileDialog = value;
            if (_SaveFileDialog != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblState;

    internal System.Windows.Forms.Label lblState
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblState != null)
            {
            }

            _lblState = value;
            if (_lblState != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtWarning;

    internal System.Windows.Forms.TextBox txtWarning
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtWarning;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtWarning != null)
            {
            }

            _txtWarning = value;
            if (_txtWarning != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdOptions;

    internal System.Windows.Forms.Button cmdOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOptions != null)
            {
            }

            _cmdOptions = value;
            if (_cmdOptions != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckedListBox _lstOptions;

    internal System.Windows.Forms.CheckedListBox lstOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstOptions != null)
            {
            }

            _lstOptions = value;
            if (_lstOptions != null)
            {
            }
        }
    }
}

