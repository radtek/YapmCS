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
partial class frmGlobalReport : System.Windows.Forms.Form
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
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.chkAllWindows = new System.Windows.Forms.CheckBox();
        this.chkAllHandles = new System.Windows.Forms.CheckBox();
        this.chkFull = new System.Windows.Forms.CheckBox();
        this.chkModules = new System.Windows.Forms.CheckBox();
        this.chkThreads = new System.Windows.Forms.CheckBox();
        this.chkHandles = new System.Windows.Forms.CheckBox();
        this.chkMemory = new System.Windows.Forms.CheckBox();
        this.chkWindows = new System.Windows.Forms.CheckBox();
        this.chkServices = new System.Windows.Forms.CheckBox();
        this.cmdSave = new System.Windows.Forms.Button();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.pgb = new System.Windows.Forms.ProgressBar();
        this.lblState = new System.Windows.Forms.Label();
        this.GroupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.chkAllWindows);
        this.GroupBox1.Controls.Add(this.chkAllHandles);
        this.GroupBox1.Controls.Add(this.chkFull);
        this.GroupBox1.Controls.Add(this.chkModules);
        this.GroupBox1.Controls.Add(this.chkThreads);
        this.GroupBox1.Controls.Add(this.chkHandles);
        this.GroupBox1.Controls.Add(this.chkMemory);
        this.GroupBox1.Controls.Add(this.chkWindows);
        this.GroupBox1.Controls.Add(this.chkServices);
        this.GroupBox1.Location = new System.Drawing.Point(12, 12);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(200, 163);
        this.GroupBox1.TabIndex = 0;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Informations to save";
        // 
        // chkAllWindows
        // 
        this.chkAllWindows.AutoSize = true;
        this.chkAllWindows.Location = new System.Drawing.Point(9, 90);
        this.chkAllWindows.Name = "chkAllWindows";
        this.chkAllWindows.Size = new System.Drawing.Size(126, 17);
        this.chkAllWindows.TabIndex = 9;
        this.chkAllWindows.Text = "Unnamed windows";
        this.chkAllWindows.UseVisualStyleBackColor = true;
        // 
        // chkAllHandles
        // 
        this.chkAllHandles.AutoSize = true;
        this.chkAllHandles.Location = new System.Drawing.Point(9, 113);
        this.chkAllHandles.Name = "chkAllHandles";
        this.chkAllHandles.Size = new System.Drawing.Size(120, 17);
        this.chkAllHandles.TabIndex = 8;
        this.chkAllHandles.Text = "Unnamed handles";
        this.chkAllHandles.UseVisualStyleBackColor = true;
        // 
        // chkFull
        // 
        this.chkFull.AutoSize = true;
        this.chkFull.Location = new System.Drawing.Point(9, 136);
        this.chkFull.Name = "chkFull";
        this.chkFull.Size = new System.Drawing.Size(80, 17);
        this.chkFull.TabIndex = 7;
        this.chkFull.Text = "Full report";
        this.chkFull.UseVisualStyleBackColor = true;
        // 
        // chkModules
        // 
        this.chkModules.AutoSize = true;
        this.chkModules.Checked = true;
        this.chkModules.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkModules.Location = new System.Drawing.Point(118, 67);
        this.chkModules.Name = "chkModules";
        this.chkModules.Size = new System.Drawing.Size(71, 17);
        this.chkModules.TabIndex = 6;
        this.chkModules.Text = "Modules";
        this.chkModules.UseVisualStyleBackColor = true;
        // 
        // chkThreads
        // 
        this.chkThreads.AutoSize = true;
        this.chkThreads.Checked = true;
        this.chkThreads.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkThreads.Location = new System.Drawing.Point(118, 44);
        this.chkThreads.Name = "chkThreads";
        this.chkThreads.Size = new System.Drawing.Size(66, 17);
        this.chkThreads.TabIndex = 5;
        this.chkThreads.Text = "Threads";
        this.chkThreads.UseVisualStyleBackColor = true;
        // 
        // chkHandles
        // 
        this.chkHandles.AutoSize = true;
        this.chkHandles.Checked = true;
        this.chkHandles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkHandles.Location = new System.Drawing.Point(118, 21);
        this.chkHandles.Name = "chkHandles";
        this.chkHandles.Size = new System.Drawing.Size(68, 17);
        this.chkHandles.TabIndex = 4;
        this.chkHandles.Text = "Handles";
        this.chkHandles.UseVisualStyleBackColor = true;
        // 
        // chkMemory
        // 
        this.chkMemory.AutoSize = true;
        this.chkMemory.Checked = true;
        this.chkMemory.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkMemory.Location = new System.Drawing.Point(9, 67);
        this.chkMemory.Name = "chkMemory";
        this.chkMemory.Size = new System.Drawing.Size(96, 17);
        this.chkMemory.TabIndex = 3;
        this.chkMemory.Text = "Mem. regions";
        this.chkMemory.UseVisualStyleBackColor = true;
        // 
        // chkWindows
        // 
        this.chkWindows.AutoSize = true;
        this.chkWindows.Checked = true;
        this.chkWindows.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkWindows.Location = new System.Drawing.Point(9, 44);
        this.chkWindows.Name = "chkWindows";
        this.chkWindows.Size = new System.Drawing.Size(75, 17);
        this.chkWindows.TabIndex = 2;
        this.chkWindows.Text = "Windows";
        this.chkWindows.UseVisualStyleBackColor = true;
        // 
        // chkServices
        // 
        this.chkServices.AutoSize = true;
        this.chkServices.Checked = true;
        this.chkServices.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkServices.Location = new System.Drawing.Point(9, 21);
        this.chkServices.Name = "chkServices";
        this.chkServices.Size = new System.Drawing.Size(66, 17);
        this.chkServices.TabIndex = 0;
        this.chkServices.Text = "Services";
        this.chkServices.UseVisualStyleBackColor = true;
        // 
        // cmdSave
        // 
        this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdSave.Location = new System.Drawing.Point(21, 230);
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.Size = new System.Drawing.Size(75, 23);
        this.cmdSave.TabIndex = 2;
        this.cmdSave.Text = "Save...";
        this.cmdSave.UseVisualStyleBackColor = true;
        // 
        // cmdCancel
        // 
        this.cmdCancel.Location = new System.Drawing.Point(130, 230);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(75, 23);
        this.cmdCancel.TabIndex = 3;
        this.cmdCancel.Text = "Cancel";
        this.cmdCancel.UseVisualStyleBackColor = true;
        // 
        // pgb
        // 
        this.pgb.Location = new System.Drawing.Point(12, 178);
        this.pgb.Name = "pgb";
        this.pgb.Size = new System.Drawing.Size(200, 23);
        this.pgb.TabIndex = 4;
        // 
        // lblState
        // 
        this.lblState.AutoSize = true;
        this.lblState.Location = new System.Drawing.Point(18, 209);
        this.lblState.Name = "lblState";
        this.lblState.Size = new System.Drawing.Size(0, 13);
        this.lblState.TabIndex = 5;
        // 
        // frmGlobalReport
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(227, 264);
        this.Controls.Add(this.lblState);
        this.Controls.Add(this.pgb);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this.cmdSave);
        this.Controls.Add(this.GroupBox1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmGlobalReport";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "General system report";
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.Button _cmdSave;

    internal System.Windows.Forms.Button cmdSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSave != null)
            {
            }

            _cmdSave = value;
            if (_cmdSave != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCancel;

    internal System.Windows.Forms.Button cmdCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCancel != null)
            {
            }

            _cmdCancel = value;
            if (_cmdCancel != null)
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

    private System.Windows.Forms.CheckBox _chkServices;

    internal System.Windows.Forms.CheckBox chkServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkServices != null)
            {
            }

            _chkServices = value;
            if (_chkServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkModules;

    internal System.Windows.Forms.CheckBox chkModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkModules != null)
            {
            }

            _chkModules = value;
            if (_chkModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkThreads;

    internal System.Windows.Forms.CheckBox chkThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkThreads != null)
            {
            }

            _chkThreads = value;
            if (_chkThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkHandles;

    internal System.Windows.Forms.CheckBox chkHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkHandles != null)
            {
            }

            _chkHandles = value;
            if (_chkHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkMemory;

    internal System.Windows.Forms.CheckBox chkMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkMemory != null)
            {
            }

            _chkMemory = value;
            if (_chkMemory != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkWindows;

    internal System.Windows.Forms.CheckBox chkWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkWindows != null)
            {
            }

            _chkWindows = value;
            if (_chkWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblState;

    internal System.Windows.Forms.Label lblState
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblState != null)
            {
            }

            _lblState = value;
            if (_lblState != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFull;

    internal System.Windows.Forms.CheckBox chkFull
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFull;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFull != null)
            {
            }

            _chkFull = value;
            if (_chkFull != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkAllWindows;

    internal System.Windows.Forms.CheckBox chkAllWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkAllWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkAllWindows != null)
            {
            }

            _chkAllWindows = value;
            if (_chkAllWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkAllHandles;

    internal System.Windows.Forms.CheckBox chkAllHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkAllHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkAllHandles != null)
            {
            }

            _chkAllHandles = value;
            if (_chkAllHandles != null)
            {
            }
        }
    }
}

