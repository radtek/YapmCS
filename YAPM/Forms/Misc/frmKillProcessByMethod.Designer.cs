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
partial class frmKillProcessByMethod : System.Windows.Forms.Form
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
        this.cmdKill = new System.Windows.Forms.Button();
        this.cmdExit = new System.Windows.Forms.Button();
        this.lstMethods = new System.Windows.Forms.ListView();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // cmdKill
        // 
        this.cmdKill.Enabled = false;
        this.cmdKill.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdKill.Image = global::My.Resources.Resources.cross16;
        this.cmdKill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdKill.Location = new System.Drawing.Point(12, 173);
        this.cmdKill.Name = "cmdKill";
        this.cmdKill.Size = new System.Drawing.Size(127, 26);
        this.cmdKill.TabIndex = 1;
        this.cmdKill.Text = "    Kill process";
        this.cmdKill.UseVisualStyleBackColor = true;
        // 
        // cmdExit
        // 
        this.cmdExit.Location = new System.Drawing.Point(285, 173);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(88, 26);
        this.cmdExit.TabIndex = 2;
        this.cmdExit.Text = "Exit";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // lstMethods
        // 
        this.lstMethods.CheckBoxes = true;
        this.lstMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1 });
        this.lstMethods.FullRowSelect = true;
        this.lstMethods.Location = new System.Drawing.Point(12, 12);
        this.lstMethods.MultiSelect = false;
        this.lstMethods.Name = "lstMethods";
        this.lstMethods.Size = new System.Drawing.Size(361, 155);
        this.lstMethods.TabIndex = 3;
        this.lstMethods.UseCompatibleStateImageBehavior = false;
        this.lstMethods.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Method";
        this.ColumnHeader1.Width = 341;
        // 
        // frmKillProcessByMethod
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(385, 211);
        this.Controls.Add(this.lstMethods);
        this.Controls.Add(this.cmdExit);
        this.Controls.Add(this.cmdKill);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "frmKillProcessByMethod";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Kill process [NAME] ([PID])";
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Button _cmdKill;

    internal System.Windows.Forms.Button cmdKill
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdKill;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdKill != null)
            {
            }

            _cmdKill = value;
            if (_cmdKill != null)
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

    private System.Windows.Forms.ListView _lstMethods;

    internal System.Windows.Forms.ListView lstMethods
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstMethods;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstMethods != null)
            {
            }

            _lstMethods = value;
            if (_lstMethods != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader1;

    internal System.Windows.Forms.ColumnHeader ColumnHeader1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader1 != null)
            {
            }

            _ColumnHeader1 = value;
            if (_ColumnHeader1 != null)
            {
            }
        }
    }
}

