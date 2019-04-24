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
partial class frmAbout : System.Windows.Forms.Form
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
        this.lblIntro = new System.Windows.Forms.Label();
        this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.btnOK = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)this.SplitContainer).BeginInit();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.SplitContainer2).BeginInit();
        this.SplitContainer2.Panel1.SuspendLayout();
        this.SplitContainer2.Panel2.SuspendLayout();
        this.SplitContainer2.SuspendLayout();
        this.SuspendLayout();
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.IsSplitterFixed = true;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.lblIntro);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.SplitContainer2);
        this.SplitContainer.Size = new System.Drawing.Size(619, 375);
        this.SplitContainer.SplitterDistance = 41;
        this.SplitContainer.SplitterWidth = 1;
        this.SplitContainer.TabIndex = 2;
        // 
        // lblIntro
        // 
        this.lblIntro.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblIntro.Location = new System.Drawing.Point(0, 0);
        this.lblIntro.Name = "lblIntro";
        this.lblIntro.Size = new System.Drawing.Size(619, 41);
        this.lblIntro.TabIndex = 0;
        this.lblIntro.Text = "Yet Another (remote) Process Monitor and some of its components are under license" + "s. Terms and conditions are explicited below.";
        this.lblIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // SplitContainer2
        // 
        this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer2.IsSplitterFixed = true;
        this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer2.Name = "SplitContainer2";
        this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer2.Panel1
        // 
        this.SplitContainer2.Panel1.Controls.Add(this.rtb);
        // 
        // SplitContainer2.Panel2
        // 
        this.SplitContainer2.Panel2.Controls.Add(this.btnOK);
        this.SplitContainer2.Size = new System.Drawing.Size(619, 333);
        this.SplitContainer2.SplitterDistance = 282;
        this.SplitContainer2.SplitterWidth = 1;
        this.SplitContainer2.TabIndex = 0;
        // 
        // rtb
        // 
        this.rtb.AutoWordSelection = true;
        this.rtb.BackColor = System.Drawing.Color.White;
        this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb.Location = new System.Drawing.Point(0, 0);
        this.rtb.Name = "rtb";
        this.rtb.ReadOnly = true;
        this.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        this.rtb.Size = new System.Drawing.Size(619, 282);
        this.rtb.TabIndex = 2;
        this.rtb.Text = "";
        // 
        // btnOK
        // 
        this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnOK.Location = new System.Drawing.Point(273, 12);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(73, 25);
        this.btnOK.TabIndex = 2;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        // 
        // frmAbout
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(619, 375);
        this.ControlBox = false;
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmAbout";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "About YAPM";
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.SplitContainer).EndInit();
        this.SplitContainer.ResumeLayout(false);
        this.SplitContainer2.Panel1.ResumeLayout(false);
        this.SplitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.SplitContainer2).EndInit();
        this.SplitContainer2.ResumeLayout(false);
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

    private System.Windows.Forms.Label _lblIntro;

    internal System.Windows.Forms.Label lblIntro
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIntro;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIntro != null)
            {
            }

            _lblIntro = value;
            if (_lblIntro != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer2;

    internal System.Windows.Forms.SplitContainer SplitContainer2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer2 != null)
            {
            }

            _SplitContainer2 = value;
            if (_SplitContainer2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtb;

    internal System.Windows.Forms.RichTextBox rtb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtb != null)
            {
            }

            _rtb = value;
            if (_rtb != null)
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
}

