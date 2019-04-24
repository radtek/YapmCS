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
partial class frmAboutG : System.Windows.Forms.Form
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
        this.lnklblSF = new System.Windows.Forms.LinkLabel();
        this.btnOK = new System.Windows.Forms.Button();
        this.pctIcon = new System.Windows.Forms.PictureBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.lblVersion = new System.Windows.Forms.Label();
        this.lblDate = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.lblRibbon = new System.Windows.Forms.LinkLabel();
        this.lblFugueIcons = new System.Windows.Forms.LinkLabel();
        this.lblShareVB = new System.Windows.Forms.LinkLabel();
        this.lblMe = new System.Windows.Forms.LinkLabel();
        this.cmdLicense = new System.Windows.Forms.Button();
        this.lblTaskDialog = new System.Windows.Forms.LinkLabel();
        this.lblVistaMenu = new System.Windows.Forms.LinkLabel();
        this.lnkWebsite = new System.Windows.Forms.LinkLabel();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.lnkMarcel = new System.Windows.Forms.LinkLabel();
        ((System.ComponentModel.ISupportInitialize)this.pctIcon).BeginInit();
        this.GroupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // lnklblSF
        // 
        this.lnklblSF.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.lnklblSF.AutoSize = true;
        this.lnklblSF.Location = new System.Drawing.Point(13, 279);
        this.lnklblSF.Name = "lnklblSF";
        this.lnklblSF.Size = new System.Drawing.Size(138, 13);
        this.lnklblSF.TabIndex = 2;
        this.lnklblSF.TabStop = true;
        this.lnklblSF.Text = "YAPM on Sourceforge.net";
        // 
        // btnOK
        // 
        this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnOK.Location = new System.Drawing.Point(346, 283);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(73, 25);
        this.btnOK.TabIndex = 1;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        // 
        // pctIcon
        // 
        this.pctIcon.Image = global::My.Resources.Resources.process;
        this.pctIcon.Location = new System.Drawing.Point(12, 12);
        this.pctIcon.Name = "pctIcon";
        this.pctIcon.Size = new System.Drawing.Size(64, 64);
        this.pctIcon.TabIndex = 4;
        this.pctIcon.TabStop = false;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label1.Location = new System.Drawing.Point(86, 12);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(325, 23);
        this.Label1.TabIndex = 5;
        this.Label1.Text = "Yet Another (remote) Process Monitor";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(95, 46);
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
        this.lblVersion.Location = new System.Drawing.Point(155, 46);
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
        this.lblDate.Location = new System.Drawing.Point(155, 63);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new System.Drawing.Size(105, 13);
        this.lblDate.TabIndex = 9;
        this.lblDate.Text = "Nov. 21 2009 00h21";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(95, 63);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(66, 13);
        this.Label4.TabIndex = 8;
        this.Label4.Text = "Build date :";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(16, 118);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(348, 13);
        this.Label3.TabIndex = 10;
        this.Label3.Text = "Yet Another (remote) Process Monitor is under GNU GPL 3.0 license";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(95, 82);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(189, 13);
        this.Label5.TabIndex = 11;
        this.Label5.Text = "Copyright 2008-2009 (c) violent_ken";
        // 
        // lblRibbon
        // 
        this.lblRibbon.AutoSize = true;
        this.lblRibbon.Location = new System.Drawing.Point(6, 18);
        this.lblRibbon.Name = "lblRibbon";
        this.lblRibbon.Size = new System.Drawing.Size(198, 13);
        this.lblRibbon.TabIndex = 15;
        this.lblRibbon.TabStop = true;
        this.lblRibbon.Text = "Jose Manuel Menéndez Poó (Ribbon)";
        // 
        // lblFugueIcons
        // 
        this.lblFugueIcons.AutoSize = true;
        this.lblFugueIcons.Location = new System.Drawing.Point(6, 31);
        this.lblFugueIcons.Name = "lblFugueIcons";
        this.lblFugueIcons.Size = new System.Drawing.Size(181, 13);
        this.lblFugueIcons.TabIndex = 16;
        this.lblFugueIcons.TabStop = true;
        this.lblFugueIcons.Text = "Yusuke Kamiyamane (Fugue Icons)";
        // 
        // lblShareVB
        // 
        this.lblShareVB.AutoSize = true;
        this.lblShareVB.Location = new System.Drawing.Point(6, 44);
        this.lblShareVB.Name = "lblShareVB";
        this.lblShareVB.Size = new System.Drawing.Size(184, 26);
        this.lblShareVB.TabIndex = 17;
        this.lblShareVB.TabStop = true;
        this.lblShareVB.Text = "ShareVB (KernelMemory driver and" + (char)13 + (char)10 + "Dependencies Viewer)";
        // 
        // lblMe
        // 
        this.lblMe.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.lblMe.AutoSize = true;
        this.lblMe.Location = new System.Drawing.Point(13, 295);
        this.lblMe.Name = "lblMe";
        this.lblMe.Size = new System.Drawing.Size(83, 13);
        this.lblMe.TabIndex = 18;
        this.lblMe.TabStop = true;
        this.lblMe.Text = "Send feedback";
        // 
        // cmdLicense
        // 
        this.cmdLicense.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.cmdLicense.Location = new System.Drawing.Point(259, 283);
        this.cmdLicense.Name = "cmdLicense";
        this.cmdLicense.Size = new System.Drawing.Size(73, 25);
        this.cmdLicense.TabIndex = 19;
        this.cmdLicense.Text = "Licenses...";
        this.cmdLicense.UseVisualStyleBackColor = true;
        // 
        // lblTaskDialog
        // 
        this.lblTaskDialog.AutoSize = true;
        this.lblTaskDialog.Location = new System.Drawing.Point(6, 70);
        this.lblTaskDialog.Name = "lblTaskDialog";
        this.lblTaskDialog.Size = new System.Drawing.Size(162, 13);
        this.lblTaskDialog.TabIndex = 20;
        this.lblTaskDialog.TabStop = true;
        this.lblTaskDialog.Text = "KevinGre (Taskdialog wrapper)";
        // 
        // lblVistaMenu
        // 
        this.lblVistaMenu.AutoSize = true;
        this.lblVistaMenu.Location = new System.Drawing.Point(6, 83);
        this.lblVistaMenu.Name = "lblVistaMenu";
        this.lblVistaMenu.Size = new System.Drawing.Size(109, 13);
        this.lblVistaMenu.TabIndex = 21;
        this.lblVistaMenu.TabStop = true;
        this.lblVistaMenu.Text = "WyDay (Vista Menu)";
        // 
        // lnkWebsite
        // 
        this.lnkWebsite.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.lnkWebsite.AutoSize = true;
        this.lnkWebsite.Location = new System.Drawing.Point(157, 279);
        this.lnkWebsite.Name = "lnkWebsite";
        this.lnkWebsite.Size = new System.Drawing.Size(49, 13);
        this.lnkWebsite.TabIndex = 22;
        this.lnkWebsite.TabStop = true;
        this.lnkWebsite.Text = "Website";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.lnkMarcel);
        this.GroupBox1.Controls.Add(this.lblVistaMenu);
        this.GroupBox1.Controls.Add(this.lblTaskDialog);
        this.GroupBox1.Controls.Add(this.lblRibbon);
        this.GroupBox1.Controls.Add(this.lblFugueIcons);
        this.GroupBox1.Controls.Add(this.lblShareVB);
        this.GroupBox1.Location = new System.Drawing.Point(17, 147);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(240, 120);
        this.GroupBox1.TabIndex = 23;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Thanks a lot to :";
        // 
        // lnkMarcel
        // 
        this.lnkMarcel.AutoSize = true;
        this.lnkMarcel.Location = new System.Drawing.Point(6, 97);
        this.lnkMarcel.Name = "lnkMarcel";
        this.lnkMarcel.Size = new System.Drawing.Size(226, 13);
        this.lnkMarcel.TabIndex = 22;
        this.lnkMarcel.TabStop = true;
        this.lnkMarcel.Text = "marcel heeremans (article about Remoting)";
        // 
        // frmAboutG
        // 
        this.AcceptButton = this.btnOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnOK;
        this.ClientSize = new System.Drawing.Size(428, 322);
        this.ControlBox = false;
        this.Controls.Add(this.lnkWebsite);
        this.Controls.Add(this.cmdLicense);
        this.Controls.Add(this.lblMe);
        this.Controls.Add(this.Label5);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.lblDate);
        this.Controls.Add(this.Label4);
        this.Controls.Add(this.lblVersion);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.pctIcon);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.lnklblSF);
        this.Controls.Add(this.GroupBox1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmAboutG";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "About YAPM";
        ((System.ComponentModel.ISupportInitialize)this.pctIcon).EndInit();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.LinkLabel _lnklblSF;

    internal System.Windows.Forms.LinkLabel lnklblSF
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lnklblSF;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lnklblSF != null)
            {
            }

            _lnklblSF = value;
            if (_lnklblSF != null)
            {
            }
        }
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

    private System.Windows.Forms.PictureBox _pctIcon;

    internal System.Windows.Forms.PictureBox pctIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctIcon != null)
            {
            }

            _pctIcon = value;
            if (_pctIcon != null)
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

    private System.Windows.Forms.LinkLabel _lblRibbon;

    internal System.Windows.Forms.LinkLabel lblRibbon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRibbon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRibbon != null)
            {
            }

            _lblRibbon = value;
            if (_lblRibbon != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lblFugueIcons;

    internal System.Windows.Forms.LinkLabel lblFugueIcons
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblFugueIcons;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblFugueIcons != null)
            {
            }

            _lblFugueIcons = value;
            if (_lblFugueIcons != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lblShareVB;

    internal System.Windows.Forms.LinkLabel lblShareVB
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblShareVB;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblShareVB != null)
            {
            }

            _lblShareVB = value;
            if (_lblShareVB != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lblMe;

    internal System.Windows.Forms.LinkLabel lblMe
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMe;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMe != null)
            {
            }

            _lblMe = value;
            if (_lblMe != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdLicense;

    internal System.Windows.Forms.Button cmdLicense
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdLicense;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdLicense != null)
            {
            }

            _cmdLicense = value;
            if (_cmdLicense != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lblTaskDialog;

    internal System.Windows.Forms.LinkLabel lblTaskDialog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTaskDialog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTaskDialog != null)
            {
            }

            _lblTaskDialog = value;
            if (_lblTaskDialog != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lblVistaMenu;

    internal System.Windows.Forms.LinkLabel lblVistaMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblVistaMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblVistaMenu != null)
            {
            }

            _lblVistaMenu = value;
            if (_lblVistaMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _lnkWebsite;

    internal System.Windows.Forms.LinkLabel lnkWebsite
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lnkWebsite;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lnkWebsite != null)
            {
            }

            _lnkWebsite = value;
            if (_lnkWebsite != null)
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

    private System.Windows.Forms.LinkLabel _lnkMarcel;

    internal System.Windows.Forms.LinkLabel lnkMarcel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lnkMarcel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lnkMarcel != null)
            {
            }

            _lnkMarcel = value;
            if (_lnkMarcel != null)
            {
            }
        }
    }
}

