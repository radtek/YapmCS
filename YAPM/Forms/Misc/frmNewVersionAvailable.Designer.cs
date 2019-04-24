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
partial class frmNewVersionAvailable : System.Windows.Forms.Form
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
        this.btnOK = new System.Windows.Forms.Button();
        this.lblCaption = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.lblVersion = new System.Windows.Forms.Label();
        this.lblDate = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.txtDesc = new System.Windows.Forms.TextBox();
        this.cmdDownload = new System.Windows.Forms.Button();
        this.lblType = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // btnOK
        // 
        this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnOK.Location = new System.Drawing.Point(320, 289);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(73, 25);
        this.btnOK.TabIndex = 1;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        // 
        // lblCaption
        // 
        this.lblCaption.AutoSize = true;
        this.lblCaption.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblCaption.Location = new System.Drawing.Point(7, 9);
        this.lblCaption.Name = "lblCaption";
        this.lblCaption.Size = new System.Drawing.Size(325, 23);
        this.lblCaption.TabIndex = 5;
        this.lblCaption.Text = "Yet Another (remote) Process Monitor";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(13, 41);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(52, 13);
        this.Label2.TabIndex = 6;
        this.Label2.Text = "Version :";
        // 
        // lblVersion
        // 
        this.lblVersion.AutoSize = true;
        this.lblVersion.BackColor = System.Drawing.SystemColors.Control;
        this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblVersion.Location = new System.Drawing.Point(73, 41);
        this.lblVersion.Name = "lblVersion";
        this.lblVersion.Size = new System.Drawing.Size(43, 13);
        this.lblVersion.TabIndex = 7;
        this.lblVersion.Text = "2.2.0.0";
        // 
        // lblDate
        // 
        this.lblDate.AutoSize = true;
        this.lblDate.BackColor = System.Drawing.SystemColors.Control;
        this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblDate.Location = new System.Drawing.Point(73, 58);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new System.Drawing.Size(108, 13);
        this.lblDate.TabIndex = 9;
        this.lblDate.Text = "Sept. 23 2009 18h18";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(13, 58);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(66, 13);
        this.Label4.TabIndex = 8;
        this.Label4.Text = "Build date :";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(13, 77);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(189, 13);
        this.Label5.TabIndex = 11;
        this.Label5.Text = "Copyright 2008-2009 (c) violent_ken";
        // 
        // txtDesc
        // 
        this.txtDesc.Location = new System.Drawing.Point(16, 103);
        this.txtDesc.Multiline = true;
        this.txtDesc.Name = "txtDesc";
        this.txtDesc.ReadOnly = true;
        this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtDesc.Size = new System.Drawing.Size(400, 179);
        this.txtDesc.TabIndex = 12;
        // 
        // cmdDownload
        // 
        this.cmdDownload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.cmdDownload.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.cmdDownload.Location = new System.Drawing.Point(35, 288);
        this.cmdDownload.Name = "cmdDownload";
        this.cmdDownload.Size = new System.Drawing.Size(181, 25);
        this.cmdDownload.TabIndex = 13;
        this.cmdDownload.Text = "Download the new version";
        this.cmdDownload.UseVisualStyleBackColor = true;
        // 
        // lblType
        // 
        this.lblType.AutoSize = true;
        this.lblType.BackColor = System.Drawing.SystemColors.Control;
        this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblType.Location = new System.Drawing.Point(256, 41);
        this.lblType.Name = "lblType";
        this.lblType.Size = new System.Drawing.Size(0, 13);
        this.lblType.TabIndex = 15;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(214, 41);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(36, 13);
        this.Label3.TabIndex = 14;
        this.Label3.Text = "Type :";
        // 
        // frmNewVersionAvailable
        // 
        this.AcceptButton = this.btnOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnOK;
        this.ClientSize = new System.Drawing.Size(428, 326);
        this.ControlBox = false;
        this.Controls.Add(this.lblType);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.cmdDownload);
        this.Controls.Add(this.txtDesc);
        this.Controls.Add(this.Label5);
        this.Controls.Add(this.lblDate);
        this.Controls.Add(this.Label4);
        this.Controls.Add(this.lblVersion);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.lblCaption);
        this.Controls.Add(this.btnOK);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmNewVersionAvailable";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "A new version is available !";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.Button _btnOK;

    internal System.Windows.Forms.Button btnOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOK != null)
            {
            }

            _btnOK = value;
            if (_btnOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCaption;

    internal System.Windows.Forms.Label lblCaption
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCaption;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCaption != null)
            {
            }

            _lblCaption = value;
            if (_lblCaption != null)
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

    private System.Windows.Forms.Label _lblVersion;

    internal System.Windows.Forms.Label lblVersion
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblVersion;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblVersion != null)
            {
            }

            _lblVersion = value;
            if (_lblVersion != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblDate;

    internal System.Windows.Forms.Label lblDate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblDate != null)
            {
            }

            _lblDate = value;
            if (_lblDate != null)
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

    private System.Windows.Forms.Label _Label5;

    internal System.Windows.Forms.Label Label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label5 != null)
            {
            }

            _Label5 = value;
            if (_Label5 != null)
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

    private System.Windows.Forms.Button _cmdDownload;

    internal System.Windows.Forms.Button cmdDownload
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdDownload;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdDownload != null)
            {
            }

            _cmdDownload = value;
            if (_cmdDownload != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblType;

    internal System.Windows.Forms.Label lblType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblType != null)
            {
            }

            _lblType = value;
            if (_lblType != null)
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
}

