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
partial class frmPendingTasks : System.Windows.Forms.Form
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
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.SuspendLayout();
        // 
        // lv
        // 
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3 });
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.FullRowSelect = true;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(455, 349);
        this.lv.TabIndex = 0;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "ID";
        this.ColumnHeader1.Width = 77;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Target";
        this.ColumnHeader2.Width = 210;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Method";
        this.ColumnHeader3.Width = 141;
        // 
        // Timer
        // 
        this.Timer.Enabled = true;
        // 
        // frmPendingTasks
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(455, 349);
        this.Controls.Add(this.lv);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "frmPendingTasks";
        this.ShowIcon = false;
        this.Text = "Pending tasks";
        this.ResumeLayout(false);
    }
    private DoubleBufferedLV _lv;

    internal DoubleBufferedLV lv
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader3;

    internal System.Windows.Forms.ColumnHeader ColumnHeader3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader3 != null)
            {
            }

            _ColumnHeader3 = value;
            if (_ColumnHeader3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _Timer;

    internal System.Windows.Forms.Timer Timer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Timer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Timer != null)
            {
            }

            _Timer = value;
            if (_Timer != null)
            {
            }
        }
    }
}

