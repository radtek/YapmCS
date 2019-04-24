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
partial class frmChangeMemoryProtection : System.Windows.Forms.Form
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
        this.ChooseFolder = new System.Windows.Forms.FolderBrowserDialog();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdChangeProtection = new System.Windows.Forms.Button();
        this.cmdExit = new System.Windows.Forms.Button();
        this.chkGuard = new System.Windows.Forms.CheckBox();
        this.optE = new System.Windows.Forms.RadioButton();
        this.optER = new System.Windows.Forms.RadioButton();
        this.optEWC = new System.Windows.Forms.RadioButton();
        this.optERW = new System.Windows.Forms.RadioButton();
        this.optWC = new System.Windows.Forms.RadioButton();
        this.optRW = new System.Windows.Forms.RadioButton();
        this.optRO = new System.Windows.Forms.RadioButton();
        this.optNA = new System.Windows.Forms.RadioButton();
        this.Label2 = new System.Windows.Forms.Label();
        this.chkNoCache = new System.Windows.Forms.CheckBox();
        this.chkWriteCombine = new System.Windows.Forms.CheckBox();
        this.linkMSDN = new System.Windows.Forms.LinkLabel();
        this.SuspendLayout();
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(153, 13);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Choose new protection type";
        // 
        // cmdChangeProtection
        // 
        this.cmdChangeProtection.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdChangeProtection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdChangeProtection.Image = global::My.Resources.Resources.locked;
        this.cmdChangeProtection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdChangeProtection.Location = new System.Drawing.Point(15, 238);
        this.cmdChangeProtection.Name = "cmdChangeProtection";
        this.cmdChangeProtection.Size = new System.Drawing.Size(148, 23);
        this.cmdChangeProtection.TabIndex = 5;
        this.cmdChangeProtection.Text = "    Change protection";
        this.cmdChangeProtection.UseVisualStyleBackColor = true;
        // 
        // cmdExit
        // 
        this.cmdExit.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdExit.Location = new System.Drawing.Point(217, 238);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(75, 23);
        this.cmdExit.TabIndex = 6;
        this.cmdExit.Text = "Exit";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // chkGuard
        // 
        this.chkGuard.AutoSize = true;
        this.chkGuard.Location = new System.Drawing.Point(15, 160);
        this.chkGuard.Name = "chkGuard";
        this.chkGuard.Size = new System.Drawing.Size(58, 17);
        this.chkGuard.TabIndex = 7;
        this.chkGuard.Text = "Guard";
        this.chkGuard.UseVisualStyleBackColor = true;
        // 
        // optE
        // 
        this.optE.AutoSize = true;
        this.optE.Location = new System.Drawing.Point(15, 34);
        this.optE.Name = "optE";
        this.optE.Size = new System.Drawing.Size(64, 17);
        this.optE.TabIndex = 9;
        this.optE.TabStop = true;
        this.optE.Text = "Execute";
        this.optE.UseVisualStyleBackColor = true;
        // 
        // optER
        // 
        this.optER.AutoSize = true;
        this.optER.Location = new System.Drawing.Point(15, 57);
        this.optER.Name = "optER";
        this.optER.Size = new System.Drawing.Size(90, 17);
        this.optER.TabIndex = 10;
        this.optER.TabStop = true;
        this.optER.Text = "ExecuteRead";
        this.optER.UseVisualStyleBackColor = true;
        // 
        // optEWC
        // 
        this.optEWC.AutoSize = true;
        this.optEWC.Location = new System.Drawing.Point(15, 103);
        this.optEWC.Name = "optEWC";
        this.optEWC.Size = new System.Drawing.Size(118, 17);
        this.optEWC.TabIndex = 12;
        this.optEWC.TabStop = true;
        this.optEWC.Text = "ExecuteWriteCopy";
        this.optEWC.UseVisualStyleBackColor = true;
        // 
        // optERW
        // 
        this.optERW.AutoSize = true;
        this.optERW.Location = new System.Drawing.Point(15, 80);
        this.optERW.Name = "optERW";
        this.optERW.Size = new System.Drawing.Size(118, 17);
        this.optERW.TabIndex = 11;
        this.optERW.TabStop = true;
        this.optERW.Text = "ExecuteReadWrite";
        this.optERW.UseVisualStyleBackColor = true;
        // 
        // optWC
        // 
        this.optWC.AutoSize = true;
        this.optWC.Location = new System.Drawing.Point(144, 103);
        this.optWC.Name = "optWC";
        this.optWC.Size = new System.Drawing.Size(79, 17);
        this.optWC.TabIndex = 16;
        this.optWC.TabStop = true;
        this.optWC.Text = "WriteCopy";
        this.optWC.UseVisualStyleBackColor = true;
        // 
        // optRW
        // 
        this.optRW.AutoSize = true;
        this.optRW.Location = new System.Drawing.Point(144, 80);
        this.optRW.Name = "optRW";
        this.optRW.Size = new System.Drawing.Size(79, 17);
        this.optRW.TabIndex = 15;
        this.optRW.TabStop = true;
        this.optRW.Text = "ReadWrite";
        this.optRW.UseVisualStyleBackColor = true;
        // 
        // optRO
        // 
        this.optRO.AutoSize = true;
        this.optRO.Location = new System.Drawing.Point(144, 57);
        this.optRO.Name = "optRO";
        this.optRO.Size = new System.Drawing.Size(75, 17);
        this.optRO.TabIndex = 14;
        this.optRO.TabStop = true;
        this.optRO.Text = "ReadOnly";
        this.optRO.UseVisualStyleBackColor = true;
        // 
        // optNA
        // 
        this.optNA.AutoSize = true;
        this.optNA.Location = new System.Drawing.Point(144, 34);
        this.optNA.Name = "optNA";
        this.optNA.Size = new System.Drawing.Size(73, 17);
        this.optNA.TabIndex = 13;
        this.optNA.TabStop = true;
        this.optNA.Text = "NoAccess";
        this.optNA.UseVisualStyleBackColor = true;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(12, 134);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(158, 13);
        this.Label2.TabIndex = 17;
        this.Label2.Text = "You can combine it with flags";
        // 
        // chkNoCache
        // 
        this.chkNoCache.AutoSize = true;
        this.chkNoCache.Location = new System.Drawing.Point(15, 183);
        this.chkNoCache.Name = "chkNoCache";
        this.chkNoCache.Size = new System.Drawing.Size(72, 17);
        this.chkNoCache.TabIndex = 18;
        this.chkNoCache.Text = "NoCache";
        this.chkNoCache.UseVisualStyleBackColor = true;
        // 
        // chkWriteCombine
        // 
        this.chkWriteCombine.AutoSize = true;
        this.chkWriteCombine.Location = new System.Drawing.Point(15, 206);
        this.chkWriteCombine.Name = "chkWriteCombine";
        this.chkWriteCombine.Size = new System.Drawing.Size(100, 17);
        this.chkWriteCombine.TabIndex = 19;
        this.chkWriteCombine.Text = "WriteCombine";
        this.chkWriteCombine.UseVisualStyleBackColor = true;
        // 
        // linkMSDN
        // 
        this.linkMSDN.AutoSize = true;
        this.linkMSDN.Location = new System.Drawing.Point(121, 174);
        this.linkMSDN.Name = "linkMSDN";
        this.linkMSDN.Size = new System.Drawing.Size(171, 26);
        this.linkMSDN.TabIndex = 20;
        this.linkMSDN.TabStop = true;
        this.linkMSDN.Text = "Get informations about memory" + (char)13 + (char)10 + "protection on MSDN.com";
        // 
        // frmChangeMemoryProtection
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(304, 273);
        this.Controls.Add(this.linkMSDN);
        this.Controls.Add(this.chkWriteCombine);
        this.Controls.Add(this.chkNoCache);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.optWC);
        this.Controls.Add(this.optRW);
        this.Controls.Add(this.optRO);
        this.Controls.Add(this.optNA);
        this.Controls.Add(this.optEWC);
        this.Controls.Add(this.optERW);
        this.Controls.Add(this.optER);
        this.Controls.Add(this.optE);
        this.Controls.Add(this.chkGuard);
        this.Controls.Add(this.cmdExit);
        this.Controls.Add(this.cmdChangeProtection);
        this.Controls.Add(this.Label1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmChangeMemoryProtection";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Change memory protection type";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.FolderBrowserDialog _ChooseFolder;

    internal System.Windows.Forms.FolderBrowserDialog ChooseFolder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ChooseFolder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ChooseFolder != null)
            {
            }

            _ChooseFolder = value;
            if (_ChooseFolder != null)
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

    private System.Windows.Forms.Button _cmdChangeProtection;

    internal System.Windows.Forms.Button cmdChangeProtection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdChangeProtection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdChangeProtection != null)
            {
            }

            _cmdChangeProtection = value;
            if (_cmdChangeProtection != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdExit;

    internal System.Windows.Forms.Button cmdExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdExit != null)
            {
            }

            _cmdExit = value;
            if (_cmdExit != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkGuard;

    internal System.Windows.Forms.CheckBox chkGuard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkGuard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkGuard != null)
            {
            }

            _chkGuard = value;
            if (_chkGuard != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optE;

    internal System.Windows.Forms.RadioButton optE
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optE;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optE != null)
            {
            }

            _optE = value;
            if (_optE != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optER;

    internal System.Windows.Forms.RadioButton optER
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optER;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optER != null)
            {
            }

            _optER = value;
            if (_optER != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optEWC;

    internal System.Windows.Forms.RadioButton optEWC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optEWC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optEWC != null)
            {
            }

            _optEWC = value;
            if (_optEWC != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optERW;

    internal System.Windows.Forms.RadioButton optERW
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optERW;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optERW != null)
            {
            }

            _optERW = value;
            if (_optERW != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optWC;

    internal System.Windows.Forms.RadioButton optWC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optWC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optWC != null)
            {
            }

            _optWC = value;
            if (_optWC != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optRW;

    internal System.Windows.Forms.RadioButton optRW
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optRW;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optRW != null)
            {
            }

            _optRW = value;
            if (_optRW != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optRO;

    internal System.Windows.Forms.RadioButton optRO
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optRO;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optRO != null)
            {
            }

            _optRO = value;
            if (_optRO != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optNA;

    internal System.Windows.Forms.RadioButton optNA
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optNA;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optNA != null)
            {
            }

            _optNA = value;
            if (_optNA != null)
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

    private System.Windows.Forms.CheckBox _chkNoCache;

    internal System.Windows.Forms.CheckBox chkNoCache
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkNoCache;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkNoCache != null)
            {
            }

            _chkNoCache = value;
            if (_chkNoCache != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkWriteCombine;

    internal System.Windows.Forms.CheckBox chkWriteCombine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkWriteCombine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkWriteCombine != null)
            {
            }

            _chkWriteCombine = value;
            if (_chkWriteCombine != null)
            {
            }
        }
    }

    private System.Windows.Forms.LinkLabel _linkMSDN;

    internal System.Windows.Forms.LinkLabel linkMSDN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _linkMSDN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_linkMSDN != null)
            {
            }

            _linkMSDN = value;
            if (_linkMSDN != null)
            {
            }
        }
    }
}

