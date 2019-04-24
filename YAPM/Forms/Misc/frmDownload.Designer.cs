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
partial class frmDownload : System.Windows.Forms.Form
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
        this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.Cancel_Button = new System.Windows.Forms.Button();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtPath = new System.Windows.Forms.TextBox();
        this.pgb = new System.Windows.Forms.ProgressBar();
        this.lblProgress = new System.Windows.Forms.Label();
        this.TableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // TableLayoutPanel1
        // 
        this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.TableLayoutPanel1.ColumnCount = 1;
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 0, 0);
        this.TableLayoutPanel1.Location = new System.Drawing.Point(349, 73);
        this.TableLayoutPanel1.Name = "TableLayoutPanel1";
        this.TableLayoutPanel1.RowCount = 1;
        this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Size = new System.Drawing.Size(74, 29);
        this.TableLayoutPanel1.TabIndex = 0;
        // 
        // Cancel_Button
        // 
        this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Cancel_Button.Location = new System.Drawing.Point(3, 3);
        this.Cancel_Button.Name = "Cancel_Button";
        this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
        this.Cancel_Button.TabIndex = 0;
        this.Cancel_Button.Text = "Cancel";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(256, 13);
        this.Label1.TabIndex = 1;
        this.Label1.Text = "Currently downloading last update available to :";
        // 
        // txtPath
        // 
        this.txtPath.Location = new System.Drawing.Point(274, 6);
        this.txtPath.Name = "txtPath";
        this.txtPath.ReadOnly = true;
        this.txtPath.Size = new System.Drawing.Size(143, 22);
        this.txtPath.TabIndex = 1;
        this.txtPath.Text = @"C:\path.zip";
        // 
        // pgb
        // 
        this.pgb.Location = new System.Drawing.Point(12, 33);
        this.pgb.Name = "pgb";
        this.pgb.Size = new System.Drawing.Size(407, 28);
        this.pgb.TabIndex = 3;
        // 
        // lblProgress
        // 
        this.lblProgress.AutoSize = true;
        this.lblProgress.Location = new System.Drawing.Point(12, 66);
        this.lblProgress.Name = "lblProgress";
        this.lblProgress.Size = new System.Drawing.Size(131, 13);
        this.lblProgress.TabIndex = 4;
        this.lblProgress.Text = "Waiting for download...";
        // 
        // frmDownload
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(435, 114);
        this.Controls.Add(this.lblProgress);
        this.Controls.Add(this.pgb);
        this.Controls.Add(this.txtPath);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.TableLayoutPanel1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmDownload";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Downloading last update...";
        this.TableLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
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
}

