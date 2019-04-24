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
partial class frmSBASimulationConsole : System.Windows.Forms.Form
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
        this.lv = new System.Windows.Forms.ListView();
        this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
        this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.ClearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ContextMenuStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // lv
        // 
        this.lv.AllowColumnReorder = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader5, this.ColumnHeader2, this.ColumnHeader1, this.ColumnHeader6 });
        this.lv.ContextMenuStrip = this.ContextMenuStrip1;
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.FullRowSelect = true;
        this.lv.HideSelection = false;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.Size = new System.Drawing.Size(522, 385);
        this.lv.TabIndex = 6;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader5
        // 
        this.ColumnHeader5.Text = "Time";
        this.ColumnHeader5.Width = 106;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Process";
        this.ColumnHeader2.Width = 125;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Action";
        this.ColumnHeader1.Width = 102;
        // 
        // ColumnHeader6
        // 
        this.ColumnHeader6.Text = "Rule";
        this.ColumnHeader6.Width = 300;
        // 
        // ContextMenuStrip1
        // 
        this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ClearConsoleToolStripMenuItem });
        this.ContextMenuStrip1.Name = "ContextMenuStrip1";
        this.ContextMenuStrip1.Size = new System.Drawing.Size(146, 26);
        // 
        // ClearConsoleToolStripMenuItem
        // 
        this.ClearConsoleToolStripMenuItem.Name = "ClearConsoleToolStripMenuItem";
        this.ClearConsoleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.ClearConsoleToolStripMenuItem.Text = "&Clear console";
        // 
        // frmSBASimulationConsole
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(522, 385);
        this.Controls.Add(this.lv);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "frmSBASimulationConsole";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Simulation console";
        this.ContextMenuStrip1.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.ListView _lv;

    internal System.Windows.Forms.ListView lv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lv != null)
            {
            }

            _lv = value;
            if (_lv != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader5;

    internal System.Windows.Forms.ColumnHeader ColumnHeader5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader5 != null)
            {
            }

            _ColumnHeader5 = value;
            if (_ColumnHeader5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader6;

    internal System.Windows.Forms.ColumnHeader ColumnHeader6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader6 != null)
            {
            }

            _ColumnHeader6 = value;
            if (_ColumnHeader6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader2;

    internal System.Windows.Forms.ColumnHeader ColumnHeader2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader2 != null)
            {
            }

            _ColumnHeader2 = value;
            if (_ColumnHeader2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip1;

    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ContextMenuStrip1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ContextMenuStrip1 != null)
            {
            }

            _ContextMenuStrip1 = value;
            if (_ContextMenuStrip1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _ClearConsoleToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem ClearConsoleToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ClearConsoleToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ClearConsoleToolStripMenuItem != null)
            {
            }

            _ClearConsoleToolStripMenuItem = value;
            if (_ClearConsoleToolStripMenuItem != null)
            {
            }
        }
    }
}

