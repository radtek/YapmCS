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
partial class frmError : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
        this.txtReport = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdQuit = new System.Windows.Forms.Button();
        this.cmdContinue = new System.Windows.Forms.Button();
        this.cmdIgnore = new System.Windows.Forms.Button();
        this.cmdSend = new System.Windows.Forms.Button();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.txtCustomMessage = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // txtReport
        // 
        this.txtReport.Location = new System.Drawing.Point(12, 144);
        this.txtReport.Multiline = true;
        this.txtReport.Name = "txtReport";
        this.txtReport.ReadOnly = true;
        this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtReport.Size = new System.Drawing.Size(641, 124);
        this.txtReport.TabIndex = 0;
        // 
        // Label1
        // 
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(641, 104);
        this.Label1.TabIndex = 1;
        this.Label1.Text = resources.GetString("Label1.Text");
        // 
        // cmdQuit
        // 
        this.cmdQuit.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdQuit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdQuit.Location = new System.Drawing.Point(532, 394);
        this.cmdQuit.Name = "cmdQuit";
        this.cmdQuit.Size = new System.Drawing.Size(121, 23);
        this.cmdQuit.TabIndex = 4;
        this.cmdQuit.Text = "Terminate YAPM";
        this.cmdQuit.UseVisualStyleBackColor = true;
        // 
        // cmdContinue
        // 
        this.cmdContinue.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdContinue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdContinue.Location = new System.Drawing.Point(450, 394);
        this.cmdContinue.Name = "cmdContinue";
        this.cmdContinue.Size = new System.Drawing.Size(74, 23);
        this.cmdContinue.TabIndex = 5;
        this.cmdContinue.Text = "Continue";
        this.cmdContinue.UseVisualStyleBackColor = true;
        // 
        // cmdIgnore
        // 
        this.cmdIgnore.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdIgnore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdIgnore.Location = new System.Drawing.Point(370, 394);
        this.cmdIgnore.Name = "cmdIgnore";
        this.cmdIgnore.Size = new System.Drawing.Size(74, 23);
        this.cmdIgnore.TabIndex = 6;
        this.cmdIgnore.Text = "Ignore";
        this.cmdIgnore.UseVisualStyleBackColor = true;
        // 
        // cmdSend
        // 
        this.cmdSend.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdSend.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdSend.Image = global::My.Resources.Resources.up16;
        this.cmdSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSend.Location = new System.Drawing.Point(15, 394);
        this.cmdSend.Name = "cmdSend";
        this.cmdSend.Size = new System.Drawing.Size(169, 23);
        this.cmdSend.TabIndex = 7;
        this.cmdSend.Text = "    Send the bug report";
        this.cmdSend.UseVisualStyleBackColor = true;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label2.Location = new System.Drawing.Point(12, 125);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(170, 17);
        this.Label2.TabIndex = 8;
        this.Label2.Text = "Generated error message :";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label3.Location = new System.Drawing.Point(15, 280);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(404, 17);
        this.Label3.TabIndex = 10;
        this.Label3.Text = "Your custom message (how to reproduce the crash for example)";
        // 
        // txtCustomMessage
        // 
        this.txtCustomMessage.Location = new System.Drawing.Point(15, 299);
        this.txtCustomMessage.Multiline = true;
        this.txtCustomMessage.Name = "txtCustomMessage";
        this.txtCustomMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtCustomMessage.Size = new System.Drawing.Size(638, 78);
        this.txtCustomMessage.TabIndex = 9;
        // 
        // frmError
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(665, 429);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.txtCustomMessage);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.cmdSend);
        this.Controls.Add(this.cmdIgnore);
        this.Controls.Add(this.cmdContinue);
        this.Controls.Add(this.cmdQuit);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.txtReport);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmError";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Yet Another (remote) Process Monitor";
        this.TopMost = true;
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.TextBox _txtReport;

    internal System.Windows.Forms.TextBox txtReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtReport != null)
            {
            }

            _txtReport = value;
            if (_txtReport != null)
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

    private System.Windows.Forms.Button _cmdQuit;

    internal System.Windows.Forms.Button cmdQuit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdQuit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdQuit != null)
            {
            }

            _cmdQuit = value;
            if (_cmdQuit != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdContinue;

    internal System.Windows.Forms.Button cmdContinue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdContinue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdContinue != null)
            {
            }

            _cmdContinue = value;
            if (_cmdContinue != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdIgnore;

    internal System.Windows.Forms.Button cmdIgnore
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdIgnore;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdIgnore != null)
            {
            }

            _cmdIgnore = value;
            if (_cmdIgnore != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSend;

    internal System.Windows.Forms.Button cmdSend
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSend;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSend != null)
            {
            }

            _cmdSend = value;
            if (_cmdSend != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label2;

    internal System.Windows.Forms.Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label2 != null)
            {
            }

            _Label2 = value;
            if (_Label2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label3;

    internal System.Windows.Forms.Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label3 != null)
            {
            }

            _Label3 = value;
            if (_Label3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtCustomMessage;

    internal System.Windows.Forms.TextBox txtCustomMessage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtCustomMessage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtCustomMessage != null)
            {
            }

            _txtCustomMessage = value;
            if (_txtCustomMessage != null)
            {
            }
        }
    }
}

