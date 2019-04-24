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
partial class frmSaveReport : System.Windows.Forms.Form
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
        this.pgb = new System.Windows.Forms.ProgressBar();
        this.lblProgress = new System.Windows.Forms.Label();
        this.cmdOK = new System.Windows.Forms.Button();
        this.cmdOpenReport = new System.Windows.Forms.Button();
        this.cmdGO = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // pgb
        // 
        this.pgb.Location = new System.Drawing.Point(15, 12);
        this.pgb.Name = "pgb";
        this.pgb.Size = new System.Drawing.Size(257, 23);
        this.pgb.TabIndex = 1;
        // 
        // lblProgress
        // 
        this.lblProgress.AutoSize = true;
        this.lblProgress.Location = new System.Drawing.Point(12, 38);
        this.lblProgress.Name = "lblProgress";
        this.lblProgress.Size = new System.Drawing.Size(86, 13);
        this.lblProgress.TabIndex = 2;
        this.lblProgress.Text = "Saved 0/0 items";
        // 
        // cmdOK
        // 
        this.cmdOK.Enabled = false;
        this.cmdOK.Location = new System.Drawing.Point(223, 62);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(48, 23);
        this.cmdOK.TabIndex = 3;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // cmdOpenReport
        // 
        this.cmdOpenReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.cmdOpenReport.Enabled = false;
        this.cmdOpenReport.Image = global::My.Resources.Resources.folder_open_document;
        this.cmdOpenReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdOpenReport.Location = new System.Drawing.Point(104, 62);
        this.cmdOpenReport.Name = "cmdOpenReport";
        this.cmdOpenReport.Size = new System.Drawing.Size(113, 23);
        this.cmdOpenReport.TabIndex = 4;
        this.cmdOpenReport.Text = "Open report";
        this.cmdOpenReport.UseVisualStyleBackColor = true;
        // 
        // cmdGO
        // 
        this.cmdGO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.cmdGO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdGO.Image = global::My.Resources.Resources.save16;
        this.cmdGO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdGO.Location = new System.Drawing.Point(12, 62);
        this.cmdGO.Name = "cmdGO";
        this.cmdGO.Size = new System.Drawing.Size(86, 23);
        this.cmdGO.TabIndex = 5;
        this.cmdGO.Text = "Save";
        this.cmdGO.UseVisualStyleBackColor = true;
        // 
        // frmSaveReport
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 94);
        this.Controls.Add(this.cmdGO);
        this.Controls.Add(this.cmdOpenReport);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.lblProgress);
        this.Controls.Add(this.pgb);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmSaveReport";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Save report";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.ProgressBar _pgb;

    internal System.Windows.Forms.ProgressBar pgb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pgb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pgb != null)
            {
            }

            _pgb = value;
            if (_pgb != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProgress;

    internal System.Windows.Forms.Label lblProgress
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProgress;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProgress != null)
            {
            }

            _lblProgress = value;
            if (_lblProgress != null)
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

    private System.Windows.Forms.Button _cmdOpenReport;

    internal System.Windows.Forms.Button cmdOpenReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpenReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpenReport != null)
            {
            }

            _cmdOpenReport = value;
            if (_cmdOpenReport != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGO;

    internal System.Windows.Forms.Button cmdGO
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGO;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGO != null)
            {
            }

            _cmdGO = value;
            if (_cmdGO != null)
            {
            }
        }
    }
}

