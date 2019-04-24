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
partial class frmServer : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtIp = new System.Windows.Forms.TextBox();
        this.lvServer = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.SuspendLayout();
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer.IsSplitterFixed = true;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.SplitContainer1);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.lvServer);
        this.SplitContainer.Size = new System.Drawing.Size(538, 379);
        this.SplitContainer.SplitterDistance = 116;
        this.SplitContainer.TabIndex = 9;
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer1.IsSplitterFixed = true;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.Label1);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.txtIp);
        this.SplitContainer1.Size = new System.Drawing.Size(538, 116);
        this.SplitContainer1.SplitterDistance = 47;
        this.SplitContainer1.TabIndex = 10;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(350, 26);
        this.Label1.TabIndex = 10;
        this.Label1.Text = "This process is the 'server' of Yet Another (remote) Process Monitor." + (char)13 + (char)10 + "If you clo" + "se this form, the connection will be interrupted.";
        // 
        // txtIp
        // 
        this.txtIp.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtIp.Location = new System.Drawing.Point(0, 0);
        this.txtIp.Multiline = true;
        this.txtIp.Name = "txtIp";
        this.txtIp.ReadOnly = true;
        this.txtIp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtIp.Size = new System.Drawing.Size(538, 65);
        this.txtIp.TabIndex = 11;
        // 
        // lvServer
        // 
        this.lvServer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2 });
        this.lvServer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvServer.FullRowSelect = true;
        this.lvServer.Location = new System.Drawing.Point(0, 0);
        this.lvServer.Name = "lvServer";
        this.lvServer.OverriddenDoubleBuffered = true;
        this.lvServer.Size = new System.Drawing.Size(538, 259);
        this.lvServer.TabIndex = 9;
        this.lvServer.UseCompatibleStateImageBehavior = false;
        this.lvServer.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Time";
        this.ColumnHeader1.Width = 172;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Command received";
        this.ColumnHeader2.Width = 349;
        // 
        // frmServer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(538, 379);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Name = "frmServer";
        this.Text = "YAPM remote process (disconnected)";
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel1.PerformLayout();
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.Panel2.PerformLayout();
        this.SplitContainer1.ResumeLayout(false);
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

    private DoubleBufferedLV _lvServer;

    internal DoubleBufferedLV lvServer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvServer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvServer != null)
            {
            }

            _lvServer = value;
            if (_lvServer != null)
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

    private System.Windows.Forms.SplitContainer _SplitContainer1;

    internal System.Windows.Forms.SplitContainer SplitContainer1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer1 != null)
            {
            }

            _SplitContainer1 = value;
            if (_SplitContainer1 != null)
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

    private System.Windows.Forms.TextBox _txtIp;

    internal System.Windows.Forms.TextBox txtIp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtIp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtIp != null)
            {
            }

            _txtIp = value;
            if (_txtIp != null)
            {
            }
        }
    }
}

