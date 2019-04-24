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
partial class frmFindWindow : System.Windows.Forms.Form
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
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblThread = new System.Windows.Forms.Label();
        this.lblProcess = new System.Windows.Forms.Label();
        this.cmdGoToProcess = new System.Windows.Forms.Button();
        this.cmdGoToThread = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Label1
        // 
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(262, 34);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Click on the target and release the left button of your mouse on the desired wind" + "ow.";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(63, 46);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(51, 13);
        this.Label2.TabIndex = 2;
        this.Label2.Text = "Process :";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(63, 65);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(48, 13);
        this.Label3.TabIndex = 3;
        this.Label3.Text = "Thread :";
        // 
        // lblThread
        // 
        this.lblThread.AutoSize = true;
        this.lblThread.Location = new System.Drawing.Point(120, 65);
        this.lblThread.Name = "lblThread";
        this.lblThread.Size = new System.Drawing.Size(0, 13);
        this.lblThread.TabIndex = 5;
        // 
        // lblProcess
        // 
        this.lblProcess.AutoSize = true;
        this.lblProcess.Location = new System.Drawing.Point(120, 46);
        this.lblProcess.Name = "lblProcess";
        this.lblProcess.Size = new System.Drawing.Size(0, 13);
        this.lblProcess.TabIndex = 4;
        // 
        // cmdGoToProcess
        // 
        this.cmdGoToProcess.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdGoToProcess.Enabled = false;
        this.cmdGoToProcess.Image = global::My.Resources.Resources.down16;
        this.cmdGoToProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdGoToProcess.Location = new System.Drawing.Point(166, 91);
        this.cmdGoToProcess.Name = "cmdGoToProcess";
        this.cmdGoToProcess.Size = new System.Drawing.Size(110, 25);
        this.cmdGoToProcess.TabIndex = 6;
        this.cmdGoToProcess.Text = "    Go to process";
        this.cmdGoToProcess.UseVisualStyleBackColor = true;
        // 
        // cmdGoToThread
        // 
        this.cmdGoToThread.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdGoToThread.Enabled = false;
        this.cmdGoToThread.Image = global::My.Resources.Resources.down16;
        this.cmdGoToThread.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdGoToThread.Location = new System.Drawing.Point(57, 91);
        this.cmdGoToThread.Name = "cmdGoToThread";
        this.cmdGoToThread.Size = new System.Drawing.Size(103, 25);
        this.cmdGoToThread.TabIndex = 7;
        this.cmdGoToThread.Text = "     Go to thread";
        this.cmdGoToThread.UseVisualStyleBackColor = true;
        // 
        // frmFindWindow
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(286, 123);
        this.Controls.Add(this.cmdGoToThread);
        this.Controls.Add(this.cmdGoToProcess);
        this.Controls.Add(this.lblThread);
        this.Controls.Add(this.lblProcess);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmFindWindow";
        this.Opacity = 0.82;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Find a process by its window";
        this.TopMost = true;
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.Label _lblThread;

    internal System.Windows.Forms.Label lblThread
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblThread;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblThread != null)
            {
            }

            _lblThread = value;
            if (_lblThread != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblProcess;

    internal System.Windows.Forms.Label lblProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcess != null)
            {
            }

            _lblProcess = value;
            if (_lblProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGoToProcess;

    internal System.Windows.Forms.Button cmdGoToProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoToProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoToProcess != null)
            {
            }

            _cmdGoToProcess = value;
            if (_cmdGoToProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGoToThread;

    internal System.Windows.Forms.Button cmdGoToThread
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoToThread;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoToThread != null)
            {
            }

            _cmdGoToThread = value;
            if (_cmdGoToThread != null)
            {
            }
        }
    }
}

