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
partial class frmSnapshotInfos : System.Windows.Forms.Form
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
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.tv = new System.Windows.Forms.TreeView();
        this.cmdGo = new System.Windows.Forms.Button();
        this.cmdBrowseSSFile = new System.Windows.Forms.Button();
        this.txtSSFile = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.cmdOK = new System.Windows.Forms.Button();
        this.openFile = new System.Windows.Forms.OpenFileDialog();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.SuspendLayout();
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer.IsSplitterFixed = true;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.tv);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.cmdGo);
        this.SplitContainer.Panel2.Controls.Add(this.cmdBrowseSSFile);
        this.SplitContainer.Panel2.Controls.Add(this.txtSSFile);
        this.SplitContainer.Panel2.Controls.Add(this.Label4);
        this.SplitContainer.Panel2.Controls.Add(this.cmdOK);
        this.SplitContainer.Size = new System.Drawing.Size(481, 359);
        this.SplitContainer.SplitterDistance = 327;
        this.SplitContainer.TabIndex = 0;
        // 
        // tv
        // 
        this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tv.FullRowSelect = true;
        this.tv.Location = new System.Drawing.Point(0, 0);
        this.tv.Name = "tv";
        this.tv.Size = new System.Drawing.Size(481, 327);
        this.tv.TabIndex = 0;
        // 
        // cmdGo
        // 
        this.cmdGo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdGo.Location = new System.Drawing.Point(314, 2);
        this.cmdGo.Name = "cmdGo";
        this.cmdGo.Size = new System.Drawing.Size(77, 23);
        this.cmdGo.TabIndex = 16;
        this.cmdGo.Text = "Explore";
        this.cmdGo.UseVisualStyleBackColor = true;
        // 
        // cmdBrowseSSFile
        // 
        this.cmdBrowseSSFile.Location = new System.Drawing.Point(281, 2);
        this.cmdBrowseSSFile.Name = "cmdBrowseSSFile";
        this.cmdBrowseSSFile.Size = new System.Drawing.Size(27, 23);
        this.cmdBrowseSSFile.TabIndex = 15;
        this.cmdBrowseSSFile.Text = "...";
        this.cmdBrowseSSFile.UseVisualStyleBackColor = true;
        // 
        // txtSSFile
        // 
        this.txtSSFile.Location = new System.Drawing.Point(133, 4);
        this.txtSSFile.Name = "txtSSFile";
        this.txtSSFile.Size = new System.Drawing.Size(142, 22);
        this.txtSSFile.TabIndex = 14;
        this.txtSSFile.Text = "";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(12, 7);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(115, 13);
        this.Label4.TabIndex = 13;
        this.Label4.Text = "System Snapshot File";
        // 
        // cmdOK
        // 
        this.cmdOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.cmdOK.Location = new System.Drawing.Point(415, 1);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(54, 23);
        this.cmdOK.TabIndex = 1;
        this.cmdOK.Text = "Exit";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // openFile
        // 
        this.openFile.Filter = "System Snapshot File (*.ssf)|*.ssf|All Files (*.*)|*.*";
        this.openFile.RestoreDirectory = true;
        this.openFile.SupportMultiDottedExtensions = true;
        this.openFile.Title = "Choose System Snapshot File to open";
        // 
        // frmSnapshotInfos
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(481, 359);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.MinimumSize = new System.Drawing.Size(497, 397);
        this.Name = "frmSnapshotInfos";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "System Snapshot File information";
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.Panel2.PerformLayout();
        this.SplitContainer.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.SplitContainer _SplitContainer;

    internal System.Windows.Forms.SplitContainer SplitContainer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer != null)
            {
            }

            _SplitContainer = value;
            if (_SplitContainer != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdOK;

    internal System.Windows.Forms.Button cmdOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOK != null)
            {
            }

            _cmdOK = value;
            if (_cmdOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.TreeView _tv;

    internal System.Windows.Forms.TreeView tv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tv != null)
            {
            }

            _tv = value;
            if (_tv != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGo;

    internal System.Windows.Forms.Button cmdGo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGo != null)
            {
            }

            _cmdGo = value;
            if (_cmdGo != null)
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
}

