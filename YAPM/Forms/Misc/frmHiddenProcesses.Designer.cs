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
partial class frmHiddenProcesses : System.Windows.Forms.Form
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
        cConnection CConnection1 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Processes", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHiddenProcesses));
        this.sb = new System.Windows.Forms.StatusStrip();
        this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblVisible = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblHidden = new System.Windows.Forms.ToolStripStatusLabel();
        this.ToolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
        this.handleMethod = new System.Windows.Forms.ToolStripMenuItem();
        this.bruteforceMethod = new System.Windows.Forms.ToolStripMenuItem();
        this.TimerProcess = new System.Windows.Forms.Timer(this.components);
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.lvProcess = new processList();
        this.c1 = new System.Windows.Forms.ColumnHeader();
        this.c2 = new System.Windows.Forms.ColumnHeader();
        this.c8 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemShow = new System.Windows.Forms.MenuItem();
        this.MenuItemClose = new System.Windows.Forms.MenuItem();
        this.MenuItem1 = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.TheContextMenu = new System.Windows.Forms.ContextMenu();
        this.sb.SuspendLayout();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // sb
        // 
        this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblTotal, this.lblVisible, this.lblHidden, this.ToolStripSplitButton1 });
        this.sb.Location = new System.Drawing.Point(0, 484);
        this.sb.Name = "sb";
        this.sb.Size = new System.Drawing.Size(633, 22);
        this.sb.TabIndex = 5;
        this.sb.Text = "StatusStrip1";
        // 
        // lblTotal
        // 
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new System.Drawing.Size(67, 17);
        this.lblTotal.Text = "0 processes";
        // 
        // lblVisible
        // 
        this.lblVisible.Name = "lblVisible";
        this.lblVisible.Size = new System.Drawing.Size(103, 17);
        this.lblVisible.Text = "0 visible processes";
        // 
        // lblHidden
        // 
        this.lblHidden.Name = "lblHidden";
        this.lblHidden.Size = new System.Drawing.Size(107, 17);
        this.lblHidden.Text = "0 hidden processes";
        // 
        // ToolStripSplitButton1
        // 
        this.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.ToolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.handleMethod, this.bruteforceMethod });
        this.ToolStripSplitButton1.Image = global::My.Resources.Resources.shield16;
        this.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.ToolStripSplitButton1.Name = "ToolStripSplitButton1";
        this.ToolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
        this.ToolStripSplitButton1.Text = "ToolStripSplitButton1";
        // 
        // handleMethod
        // 
        this.handleMethod.Checked = true;
        this.handleMethod.CheckState = System.Windows.Forms.CheckState.Checked;
        this.handleMethod.Name = "handleMethod";
        this.handleMethod.Size = new System.Drawing.Size(157, 22);
        this.handleMethod.Text = "Handle method";
        // 
        // bruteforceMethod
        // 
        this.bruteforceMethod.Name = "bruteforceMethod";
        this.bruteforceMethod.Size = new System.Drawing.Size(157, 22);
        this.bruteforceMethod.Text = "Brute force";
        // 
        // TimerProcess
        // 
        this.TimerProcess.Interval = 1000;
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.lvProcess);
        this.SplitContainer.Panel2Collapsed = true;
        this.SplitContainer.Size = new System.Drawing.Size(633, 484);
        this.SplitContainer.SplitterDistance = 211;
        this.SplitContainer.TabIndex = 6;
        // 
        // lvProcess
        // 
        this.lvProcess.AllowColumnReorder = true;
        this.lvProcess.CatchErrors = false;
        this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.c1, this.c2, this.c8, this.ColumnHeader20 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        this.lvProcess.ConnectionObj = CConnection1;
        this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.HandleMethod;
        this.lvProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcess.FullRowSelect = true;
        ListViewGroup1.Header = "Processes";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvProcess.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvProcess.HideSelection = false;
        this.lvProcess.IsConnected = false;
        this.lvProcess.Location = new System.Drawing.Point(0, 0);
        this.lvProcess.Name = "lvProcess";
        this.lvProcess.OverriddenDoubleBuffered = true;
        this.lvProcess.ReorganizeColumns = true;
        this.lvProcess.ShowObjectDetailsOnDoubleClick = true;
        this.lvProcess.Size = new System.Drawing.Size(633, 484);
        this.lvProcess.TabIndex = 5;
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
        this.c2.Width = 50;
        // 
        // c8
        // 
        this.c8.Text = "Path";
        this.c8.Width = 378;
        // 
        // ColumnHeader20
        // 
        this.ColumnHeader20.Text = "ObjectCreationDate";
        this.ColumnHeader20.Width = 152;
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItemShow
        // 
        this.VistaMenu.SetImage(this.MenuItemShow, global::My.Resources.Resources.document_text);
        this.MenuItemShow.Index = 0;
        this.MenuItemShow.Text = "File properties";
        // 
        // MenuItemClose
        // 
        this.VistaMenu.SetImage(this.MenuItemClose, global::My.Resources.Resources.folder_open);
        this.MenuItemClose.Index = 1;
        this.MenuItemClose.Text = "Open directory";
        // 
        // MenuItem1
        // 
        this.VistaMenu.SetImage(this.MenuItem1, global::My.Resources.Resources.magnifier);
        this.MenuItem1.Index = 2;
        this.MenuItem1.Text = "File details";
        // 
        // MenuItem2
        // 
        this.VistaMenu.SetImage(this.MenuItem2, global::My.Resources.Resources.globe);
        this.MenuItem2.Index = 3;
        this.MenuItem2.Text = "Internet search";
        // 
        // TheContextMenu
        // 
        this.TheContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemShow, this.MenuItemClose, this.MenuItem1, this.MenuItem2 });
        // 
        // frmHiddenProcesses
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(633, 506);
        this.Controls.Add(this.SplitContainer);
        this.Controls.Add(this.sb);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Name = "frmHiddenProcesses";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Hidden processes";
        this.sb.ResumeLayout(false);
        this.sb.PerformLayout();
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.StatusStrip _sb;

    internal System.Windows.Forms.StatusStrip sb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sb != null)
            {
            }

            _sb = value;
            if (_sb != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _lblTotal;

    internal System.Windows.Forms.ToolStripStatusLabel lblTotal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotal != null)
            {
            }

            _lblTotal = value;
            if (_lblTotal != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _lblVisible;

    internal System.Windows.Forms.ToolStripStatusLabel lblVisible
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblVisible;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblVisible != null)
            {
            }

            _lblVisible = value;
            if (_lblVisible != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _lblHidden;

    internal System.Windows.Forms.ToolStripStatusLabel lblHidden
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblHidden;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblHidden != null)
            {
            }

            _lblHidden = value;
            if (_lblHidden != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripSplitButton _ToolStripSplitButton1;

    internal System.Windows.Forms.ToolStripSplitButton ToolStripSplitButton1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ToolStripSplitButton1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ToolStripSplitButton1 != null)
            {
            }

            _ToolStripSplitButton1 = value;
            if (_ToolStripSplitButton1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _handleMethod;

    internal System.Windows.Forms.ToolStripMenuItem handleMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _handleMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_handleMethod != null)
            {
            }

            _handleMethod = value;
            if (_handleMethod != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _bruteforceMethod;

    internal System.Windows.Forms.ToolStripMenuItem bruteforceMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _bruteforceMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_bruteforceMethod != null)
            {
            }

            _bruteforceMethod = value;
            if (_bruteforceMethod != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _TimerProcess;

    internal System.Windows.Forms.Timer TimerProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TimerProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TimerProcess != null)
            {
            }

            _TimerProcess = value;
            if (_TimerProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer;

    internal System.Windows.Forms.SplitContainer SplitContainer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer != null)
            {
            }

            _SplitContainer = value;
            if (_SplitContainer != null)
            {
            }
        }
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

    private System.Windows.Forms.ColumnHeader _c8;

    internal System.Windows.Forms.ColumnHeader c8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c8 != null)
            {
            }

            _c8 = value;
            if (_c8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader20;

    internal System.Windows.Forms.ColumnHeader ColumnHeader20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader20 != null)
            {
            }

            _ColumnHeader20 = value;
            if (_ColumnHeader20 != null)
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

    private System.Windows.Forms.MenuItem _MenuItem1;

    internal System.Windows.Forms.MenuItem MenuItem1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem1 != null)
            {
            }

            _MenuItem1 = value;
            if (_MenuItem1 != null)
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

