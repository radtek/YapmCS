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
partial class frmLog : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader52 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItem = new System.Windows.Forms.MenuItem();
        this.TheContextMenu = new System.Windows.Forms.ContextMenu();
        this.menuItem12 = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // lv
        // 
        this.lv.AllowColumnReorder = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader52, this.ColumnHeader1 });
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.FullRowSelect = true;
        this.lv.HideSelection = false;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(624, 430);
        this.lv.TabIndex = 46;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader52
        // 
        this.ColumnHeader52.Text = "Time";
        this.ColumnHeader52.Width = 202;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Event";
        this.ColumnHeader1.Width = 385;
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItem
        // 
        this.MenuItem.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItem, global::My.Resources.Resources.save16);
        this.MenuItem.Index = 0;
        this.MenuItem.Text = "Save...";
        // 
        // TheContextMenu
        // 
        this.TheContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem, this.menuItem12, this.MenuItem2 });
        // 
        // menuItem12
        // 
        this.menuItem12.Index = 1;
        this.menuItem12.Text = "-";
        // 
        // MenuItem2
        // 
        this.MenuItem2.Index = 2;
        this.MenuItem2.Text = "Clear";
        // 
        // frmLog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(624, 430);
        this.Controls.Add(this.lv);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Name = "frmLog";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Log file";
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Ribbon _Ribbon;

    internal System.Windows.Forms.Ribbon Ribbon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Ribbon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Ribbon != null)
            {
            }

            _Ribbon = value;
            if (_Ribbon != null)
            {
            }
        }
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader52;

    internal System.Windows.Forms.ColumnHeader ColumnHeader52
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader52;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader52 != null)
            {
            }

            _ColumnHeader52 = value;
            if (_ColumnHeader52 != null)
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

    private wyDay.Controls.VistaMenu _VistaMenu;

    internal wyDay.Controls.VistaMenu VistaMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _VistaMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_VistaMenu != null)
            {
            }

            _VistaMenu = value;
            if (_VistaMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem;

    internal System.Windows.Forms.MenuItem MenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem != null)
            {
            }

            _MenuItem = value;
            if (_MenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _TheContextMenu;

    private System.Windows.Forms.ContextMenu TheContextMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TheContextMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TheContextMenu != null)
            {
            }

            _TheContextMenu = value;
            if (_TheContextMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _menuItem12;

    private System.Windows.Forms.MenuItem menuItem12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuItem12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuItem12 != null)
            {
            }

            _menuItem12 = value;
            if (_menuItem12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem2;

    internal System.Windows.Forms.MenuItem MenuItem2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem2 != null)
            {
            }

            _MenuItem2 = value;
            if (_MenuItem2 != null)
            {
            }
        }
    }
}

