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
partial class frmTracker : System.Windows.Forms.Form
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
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.cmdGoFeed = new System.Windows.Forms.Button();
        this.txtFeed = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.cmdGoSug = new System.Windows.Forms.Button();
        this.txtSug = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdGoBug = new System.Windows.Forms.Button();
        this.txtBug = new System.Windows.Forms.TextBox();
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
        this.SplitContainer.Panel1.Controls.Add(this.rtb);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.Label3);
        this.SplitContainer.Panel2.Controls.Add(this.cmdGoFeed);
        this.SplitContainer.Panel2.Controls.Add(this.txtFeed);
        this.SplitContainer.Panel2.Controls.Add(this.Label2);
        this.SplitContainer.Panel2.Controls.Add(this.cmdGoSug);
        this.SplitContainer.Panel2.Controls.Add(this.txtSug);
        this.SplitContainer.Panel2.Controls.Add(this.Label1);
        this.SplitContainer.Panel2.Controls.Add(this.cmdGoBug);
        this.SplitContainer.Panel2.Controls.Add(this.txtBug);
        this.SplitContainer.Size = new System.Drawing.Size(443, 373);
        this.SplitContainer.SplitterDistance = 286;
        this.SplitContainer.TabIndex = 1;
        // 
        // rtb
        // 
        this.rtb.BackColor = System.Drawing.Color.White;
        this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb.Location = new System.Drawing.Point(0, 0);
        this.rtb.Name = "rtb";
        this.rtb.ReadOnly = true;
        this.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        this.rtb.Size = new System.Drawing.Size(443, 286);
        this.rtb.TabIndex = 1;
        this.rtb.Text = "";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(12, 55);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(82, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "Give feed back";
        // 
        // cmdGoFeed
        // 
        this.cmdGoFeed.Location = new System.Drawing.Point(391, 53);
        this.cmdGoFeed.Name = "cmdGoFeed";
        this.cmdGoFeed.Size = new System.Drawing.Size(40, 23);
        this.cmdGoFeed.TabIndex = 7;
        this.cmdGoFeed.Text = "Go";
        this.cmdGoFeed.UseVisualStyleBackColor = true;
        // 
        // txtFeed
        // 
        this.txtFeed.Location = new System.Drawing.Point(100, 53);
        this.txtFeed.Name = "txtFeed";
        this.txtFeed.ReadOnly = true;
        this.txtFeed.Size = new System.Drawing.Size(285, 22);
        this.txtFeed.TabIndex = 6;
        this.txtFeed.Text = "YetAnotherProcessMonitor@gmail.com";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(12, 33);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(105, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Make a suggestion";
        // 
        // cmdGoSug
        // 
        this.cmdGoSug.Location = new System.Drawing.Point(391, 30);
        this.cmdGoSug.Name = "cmdGoSug";
        this.cmdGoSug.Size = new System.Drawing.Size(40, 23);
        this.cmdGoSug.TabIndex = 4;
        this.cmdGoSug.Text = "Go";
        this.cmdGoSug.UseVisualStyleBackColor = true;
        // 
        // txtSug
        // 
        this.txtSug.Location = new System.Drawing.Point(123, 30);
        this.txtSug.Name = "txtSug";
        this.txtSug.ReadOnly = true;
        this.txtSug.Size = new System.Drawing.Size(262, 22);
        this.txtSug.TabIndex = 3;
        this.txtSug.Text = "https://sourceforge.net/forum/?group_id=244697";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 10);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(75, 13);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Report a bug";
        // 
        // cmdGoBug
        // 
        this.cmdGoBug.Location = new System.Drawing.Point(391, 7);
        this.cmdGoBug.Name = "cmdGoBug";
        this.cmdGoBug.Size = new System.Drawing.Size(40, 23);
        this.cmdGoBug.TabIndex = 1;
        this.cmdGoBug.Text = "Go";
        this.cmdGoBug.UseVisualStyleBackColor = true;
        // 
        // txtBug
        // 
        this.txtBug.Location = new System.Drawing.Point(93, 7);
        this.txtBug.Name = "txtBug";
        this.txtBug.ReadOnly = true;
        this.txtBug.Size = new System.Drawing.Size(292, 22);
        this.txtBug.TabIndex = 0;
        this.txtBug.Text = "https://sourceforge.net/tracker/?group_id=244697";
        // 
        // frmTracker
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(443, 373);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmTracker";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Bug report & feedbacks";
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

    private System.Windows.Forms.Button _cmdGoBug;

    internal System.Windows.Forms.Button cmdGoBug
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoBug;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoBug != null)
            {
            }

            _cmdGoBug = value;
            if (_cmdGoBug != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtBug;

    internal System.Windows.Forms.TextBox txtBug
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtBug;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtBug != null)
            {
            }

            _txtBug = value;
            if (_txtBug != null)
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

    private System.Windows.Forms.Button _cmdGoFeed;

    internal System.Windows.Forms.Button cmdGoFeed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoFeed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoFeed != null)
            {
            }

            _cmdGoFeed = value;
            if (_cmdGoFeed != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtFeed;

    internal System.Windows.Forms.TextBox txtFeed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtFeed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtFeed != null)
            {
            }

            _txtFeed = value;
            if (_txtFeed != null)
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

    private System.Windows.Forms.Button _cmdGoSug;

    internal System.Windows.Forms.Button cmdGoSug
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoSug;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoSug != null)
            {
            }

            _cmdGoSug = value;
            if (_cmdGoSug != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSug;

    internal System.Windows.Forms.TextBox txtSug
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSug;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSug != null)
            {
            }

            _txtSug = value;
            if (_txtSug != null)
            {
            }
        }
    }
}

