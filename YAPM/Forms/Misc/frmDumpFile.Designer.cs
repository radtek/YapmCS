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
partial class frmDumpFile : System.Windows.Forms.Form
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
        this.cmdBrowse = new System.Windows.Forms.Button();
        this.txtDir = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.cbOption = new System.Windows.Forms.ComboBox();
        this.cmdCreate = new System.Windows.Forms.Button();
        this.cmdExit = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // cmdBrowse
        // 
        this.cmdBrowse.Location = new System.Drawing.Point(264, 12);
        this.cmdBrowse.Name = "cmdBrowse";
        this.cmdBrowse.Size = new System.Drawing.Size(30, 23);
        this.cmdBrowse.TabIndex = 0;
        this.cmdBrowse.Text = "...";
        this.cmdBrowse.UseVisualStyleBackColor = true;
        // 
        // txtDir
        // 
        this.txtDir.Location = new System.Drawing.Point(105, 12);
        this.txtDir.Name = "txtDir";
        this.txtDir.ReadOnly = true;
        this.txtDir.Size = new System.Drawing.Size(153, 22);
        this.txtDir.TabIndex = 1;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 17);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(87, 13);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Target directory";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(12, 43);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(76, 13);
        this.Label2.TabIndex = 3;
        this.Label2.Text = "Dump option";
        // 
        // cbOption
        // 
        this.cbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbOption.FormattingEnabled = true;
        this.cbOption.Items.AddRange(new object[] { "MiniDumpNormal", "MiniDumpWithDataSegs", "MiniDumpWithFullMemory", "MiniDumpWithHandleData", "MiniDumpFilterMemory", "MiniDumpScanMemory", "MiniDumpWithUnloadedModules", "MiniDumpWithIndirectlyReferencedMemory", "MiniDumpFilterModulePaths", "MiniDumpWithProcessThreadData", "MiniDumpWithPrivateReadWriteMemory", "MiniDumpWithoutOptionalData", "MiniDumpWithFullMemoryInfo", "MiniDumpWithThreadInfo", "MiniDumpWithCodeSegs" });
        this.cbOption.Location = new System.Drawing.Point(94, 40);
        this.cbOption.Name = "cbOption";
        this.cbOption.Size = new System.Drawing.Size(198, 21);
        this.cbOption.TabIndex = 4;
        // 
        // cmdCreate
        // 
        this.cmdCreate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdCreate.Location = new System.Drawing.Point(37, 72);
        this.cmdCreate.Name = "cmdCreate";
        this.cmdCreate.Size = new System.Drawing.Size(75, 23);
        this.cmdCreate.TabIndex = 5;
        this.cmdCreate.Text = "Create";
        this.cmdCreate.UseVisualStyleBackColor = true;
        // 
        // cmdExit
        // 
        this.cmdExit.Location = new System.Drawing.Point(192, 72);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(75, 23);
        this.cmdExit.TabIndex = 6;
        this.cmdExit.Text = "Exit";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // frmDumpFile
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(304, 104);
        this.Controls.Add(this.cmdExit);
        this.Controls.Add(this.cmdCreate);
        this.Controls.Add(this.cbOption);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.txtDir);
        this.Controls.Add(this.cmdBrowse);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmDumpFile";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Create a dump file";
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

    private System.Windows.Forms.Button _cmdBrowse;

    internal System.Windows.Forms.Button cmdBrowse
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowse;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowse != null)
            {
            }

            _cmdBrowse = value;
            if (_cmdBrowse != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtDir;

    internal System.Windows.Forms.TextBox txtDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtDir != null)
            {
            }

            _txtDir = value;
            if (_txtDir != null)
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

    private System.Windows.Forms.ComboBox _cbOption;

    internal System.Windows.Forms.ComboBox cbOption
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbOption;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbOption != null)
            {
            }

            _cbOption = value;
            if (_cbOption != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCreate;

    internal System.Windows.Forms.Button cmdCreate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCreate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCreate != null)
            {
            }

            _cmdCreate = value;
            if (_cmdCreate != null)
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
}

