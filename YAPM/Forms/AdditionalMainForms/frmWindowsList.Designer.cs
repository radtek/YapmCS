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
partial class frmWindowsList : System.Windows.Forms.Form
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
        this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        this.imgList = new System.Windows.Forms.ImageList(this.components);
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader52 = new System.Windows.Forms.ColumnHeader();
        this.TheContextMenu = new System.Windows.Forms.ContextMenu();
        this.MenuItemShow = new System.Windows.Forms.MenuItem();
        this.MenuItemClose = new System.Windows.Forms.MenuItem();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // timerRefresh
        // 
        this.timerRefresh.Enabled = true;
        // 
        // imgList
        // 
        this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
        this.imgList.ImageSize = new System.Drawing.Size(16, 16);
        this.imgList.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // lv
        // 
        this.lv.AllowColumnReorder = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader52 });
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.FullRowSelect = true;
        this.lv.HideSelection = false;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(320, 287);
        this.lv.SmallImageList = this.imgList;
        this.lv.TabIndex = 5;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader52
        // 
        this.ColumnHeader52.Text = "Caption";
        this.ColumnHeader52.Width = 295;
        // 
        // TheContextMenu
        // 
        this.TheContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemShow, this.MenuItemClose });
        // 
        // MenuItemShow
        // 
        this.MenuItemShow.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemShow, global::My.Resources.Resources.monitor16);
        this.MenuItemShow.Index = 0;
        this.MenuItemShow.Text = "Show";
        // 
        // MenuItemClose
        // 
        this.VistaMenu.SetImage(this.MenuItemClose, global::My.Resources.Resources.close);
        this.MenuItemClose.Index = 1;
        this.MenuItemClose.Text = "Close";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // frmWindowsList
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(320, 287);
        this.Controls.Add(this.lv);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmWindowsList";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Window list";
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
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

    private System.Windows.Forms.Timer _timerRefresh;

    internal System.Windows.Forms.Timer timerRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timerRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timerRefresh != null)
            {
            }

            _timerRefresh = value;
            if (_timerRefresh != null)
            {
            }
        }
    }

    private System.Windows.Forms.ImageList _imgList;

    internal System.Windows.Forms.ImageList imgList
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _imgList;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_imgList != null)
            {
            }

            _imgList = value;
            if (_imgList != null)
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

    private System.Windows.Forms.MenuItem _MenuItemShow;

    internal System.Windows.Forms.MenuItem MenuItemShow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemShow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemShow != null)
            {
            }

            _MenuItemShow = value;
            if (_MenuItemShow != null)
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

    private System.Windows.Forms.MenuItem _MenuItemClose;

    internal System.Windows.Forms.MenuItem MenuItemClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemClose != null)
            {
            }

            _MenuItemClose = value;
            if (_MenuItemClose != null)
            {
            }
        }
    }
}

