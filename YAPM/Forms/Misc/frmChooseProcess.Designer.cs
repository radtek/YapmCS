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
partial class frmChooseProcess : System.Windows.Forms.Form
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
        this.components = new System.ComponentModel.Container();
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Processes", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        this.timerProcRefresh = new System.Windows.Forms.Timer(this.components);
        this.lvProcess = new processList();
        this.c1 = new System.Windows.Forms.ColumnHeader();
        this.c2 = new System.Windows.Forms.ColumnHeader();
        this.c3 = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // timerProcRefresh
        // 
        this.timerProcRefresh.Enabled = true;
        // 
        // lvProcess
        // 
        this.lvProcess.AllowColumnReorder = true;
        this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.c1, this.c2, this.c3 });
        this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcess.FullRowSelect = true;
        ListViewGroup1.Header = "Processes";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvProcess.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvProcess.HideSelection = false;
        this.lvProcess.Location = new System.Drawing.Point(0, 0);
        this.lvProcess.Name = "lvProcess";
        this.lvProcess.OverriddenDoubleBuffered = true;
        this.lvProcess.Size = new System.Drawing.Size(386, 307);
        this.lvProcess.TabIndex = 4;
        this.lvProcess.UseCompatibleStateImageBehavior = false;
        this.lvProcess.View = System.Windows.Forms.View.Details;
        // 
        // c1
        // 
        this.c1.Text = "Name";
        this.c1.Width = 100;
        // 
        // c2
        // 
        this.c2.Text = "PID";
        this.c2.Width = 40;
        // 
        // c3
        // 
        this.c3.Text = "Path";
        this.c3.Width = 350;
        // 
        // frmChooseProcess
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(386, 307);
        this.Controls.Add(this.lvProcess);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmChooseProcess";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Choose a process";
        this.ResumeLayout(false);
    }
    private processList _lvProcess;

    internal processList lvProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvProcess != null)
            {
            }

            _lvProcess = value;
            if (_lvProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c1;

    internal System.Windows.Forms.ColumnHeader c1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c1 != null)
            {
            }

            _c1 = value;
            if (_c1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c2;

    internal System.Windows.Forms.ColumnHeader c2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c2 != null)
            {
            }

            _c2 = value;
            if (_c2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c3;

    internal System.Windows.Forms.ColumnHeader c3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c3 != null)
            {
            }

            _c3 = value;
            if (_c3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _timerProcRefresh;

    internal System.Windows.Forms.Timer timerProcRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerProcRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerProcRefresh != null)
            {
            }

            _timerProcRefresh = value;
            if (_timerProcRefresh != null)
            {
            }
        }
    }
}

