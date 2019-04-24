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
partial class frmDepViewerMain : System.Windows.Forms.Form
{

    // Form overrides dispose to clean up the component list.
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

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepViewerMain));
        this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
        this.statusFile = new System.Windows.Forms.ToolStripStatusLabel();
        this.CDO = new System.Windows.Forms.OpenFileDialog();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.tvDepends = new System.Windows.Forms.TreeView();
        this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
        this.TabControl1 = new System.Windows.Forms.TabControl();
        this.tabImports = new System.Windows.Forms.TabPage();
        this.lvImports = new DoubleBufferedLV();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
        this.tabExports = new System.Windows.Forms.TabPage();
        this.lvExports = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
        this.lvAllDeps = new DoubleBufferedLV();
        this.ColumnHeader15 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader16 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader17 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader18 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader10 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
        this.cMenu1 = new System.Windows.Forms.ContextMenu();
        this.MenuItem1 = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.MenuItem4 = new System.Windows.Forms.MenuItem();
        this.MenuItemFileProp = new System.Windows.Forms.MenuItem();
        this.MenuItemOpenDir = new System.Windows.Forms.MenuItem();
        this.cMenu2 = new System.Windows.Forms.ContextMenu();
        this.MenuItemFileDet = new System.Windows.Forms.MenuItem();
        this.MenuItemInternetSearch = new System.Windows.Forms.MenuItem();
        this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
        this.MenuItemOpen = new System.Windows.Forms.MenuItem();
        this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
        this.MenuFile = new System.Windows.Forms.MenuItem();
        this.MenuItemSeparatorAfterOpen = new System.Windows.Forms.MenuItem();
        this.MenuItemQuit = new System.Windows.Forms.MenuItem();
        this.MenuDisplay = new System.Windows.Forms.MenuItem();
        this.MenuItemAlwaysVisible = new System.Windows.Forms.MenuItem();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.StatusStrip1.SuspendLayout();
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.SplitContainer2.Panel1.SuspendLayout();
        this.SplitContainer2.Panel2.SuspendLayout();
        this.SplitContainer2.SuspendLayout();
        this.TabControl1.SuspendLayout();
        this.tabImports.SuspendLayout();
        this.tabExports.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // StatusStrip1
        // 
        this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusFile });
        this.StatusStrip1.Location = new System.Drawing.Point(0, 412);
        this.StatusStrip1.Name = "StatusStrip1";
        this.StatusStrip1.Size = new System.Drawing.Size(711, 22);
        this.StatusStrip1.TabIndex = 2;
        this.StatusStrip1.Text = "StatusStrip1";
        // 
        // statusFile
        // 
        this.statusFile.Name = "statusFile";
        this.statusFile.Size = new System.Drawing.Size(696, 17);
        this.statusFile.Spring = true;
        this.statusFile.Text = "-";
        this.statusFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // CDO
        // 
        this.CDO.Filter = "Executables|*.exe;*.dll|All|*.*";
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.tvDepends);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
        this.SplitContainer1.Size = new System.Drawing.Size(711, 412);
        this.SplitContainer1.SplitterDistance = 237;
        this.SplitContainer1.TabIndex = 5;
        // 
        // tvDepends
        // 
        this.tvDepends.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tvDepends.FullRowSelect = true;
        this.tvDepends.Location = new System.Drawing.Point(0, 0);
        this.tvDepends.Name = "tvDepends";
        this.tvDepends.Size = new System.Drawing.Size(237, 412);
        this.tvDepends.TabIndex = 1;
        // 
        // SplitContainer2
        // 
        this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer2.Name = "SplitContainer2";
        this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer2.Panel1
        // 
        this.SplitContainer2.Panel1.Controls.Add(this.TabControl1);
        // 
        // SplitContainer2.Panel2
        // 
        this.SplitContainer2.Panel2.Controls.Add(this.lvAllDeps);
        this.SplitContainer2.Size = new System.Drawing.Size(470, 412);
        this.SplitContainer2.SplitterDistance = 245;
        this.SplitContainer2.TabIndex = 0;
        // 
        // TabControl1
        // 
        this.TabControl1.Controls.Add(this.tabImports);
        this.TabControl1.Controls.Add(this.tabExports);
        this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.TabControl1.Location = new System.Drawing.Point(0, 0);
        this.TabControl1.Name = "TabControl1";
        this.TabControl1.SelectedIndex = 0;
        this.TabControl1.Size = new System.Drawing.Size(470, 245);
        this.TabControl1.TabIndex = 4;
        // 
        // tabImports
        // 
        this.tabImports.Controls.Add(this.lvImports);
        this.tabImports.Location = new System.Drawing.Point(4, 22);
        this.tabImports.Name = "tabImports";
        this.tabImports.Padding = new System.Windows.Forms.Padding(3);
        this.tabImports.Size = new System.Drawing.Size(462, 219);
        this.tabImports.TabIndex = 0;
        this.tabImports.Text = "Imports Table";
        this.tabImports.UseVisualStyleBackColor = true;
        // 
        // lvImports
        // 
        this.lvImports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2, this.ColumnHeader3, this.ColumnHeader4, this.ColumnHeader5, this.ColumnHeader9 });
        this.lvImports.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvImports.FullRowSelect = true;
        this.lvImports.Location = new System.Drawing.Point(3, 3);
        this.lvImports.Name = "lvImports";
        this.lvImports.OverriddenDoubleBuffered = true;
        this.lvImports.Size = new System.Drawing.Size(456, 213);
        this.lvImports.TabIndex = 0;
        this.lvImports.UseCompatibleStateImageBehavior = false;
        this.lvImports.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Ordinal";
        this.ColumnHeader2.Width = 49;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Hint";
        this.ColumnHeader3.Width = 39;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Dll";
        this.ColumnHeader4.Width = 67;
        // 
        // ColumnHeader5
        // 
        this.ColumnHeader5.Text = "Function";
        this.ColumnHeader5.Width = 106;
        // 
        // ColumnHeader9
        // 
        this.ColumnHeader9.Text = "Entry Point";
        this.ColumnHeader9.Width = 101;
        // 
        // tabExports
        // 
        this.tabExports.Controls.Add(this.lvExports);
        this.tabExports.Location = new System.Drawing.Point(4, 22);
        this.tabExports.Name = "tabExports";
        this.tabExports.Padding = new System.Windows.Forms.Padding(3);
        this.tabExports.Size = new System.Drawing.Size(462, 219);
        this.tabExports.TabIndex = 1;
        this.tabExports.Text = "Exports Table";
        this.tabExports.UseVisualStyleBackColor = true;
        // 
        // lvExports
        // 
        this.lvExports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader6, this.ColumnHeader7, this.ColumnHeader8 });
        this.lvExports.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvExports.FullRowSelect = true;
        this.lvExports.Location = new System.Drawing.Point(3, 3);
        this.lvExports.Name = "lvExports";
        this.lvExports.OverriddenDoubleBuffered = true;
        this.lvExports.Size = new System.Drawing.Size(456, 213);
        this.lvExports.TabIndex = 0;
        this.lvExports.UseCompatibleStateImageBehavior = false;
        this.lvExports.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Ordinal";
        this.ColumnHeader1.Width = 52;
        // 
        // ColumnHeader6
        // 
        this.ColumnHeader6.Text = "Hint";
        this.ColumnHeader6.Width = 51;
        // 
        // ColumnHeader7
        // 
        this.ColumnHeader7.Text = "Function";
        this.ColumnHeader7.Width = 145;
        // 
        // ColumnHeader8
        // 
        this.ColumnHeader8.Text = "Entry Point";
        this.ColumnHeader8.Width = 101;
        // 
        // lvAllDeps
        // 
        this.lvAllDeps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader15, this.ColumnHeader16, this.ColumnHeader17, this.ColumnHeader18, this.ColumnHeader19, this.ColumnHeader20, this.ColumnHeader10, this.ColumnHeader11, this.ColumnHeader12, this.ColumnHeader13, this.ColumnHeader14 });
        this.lvAllDeps.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvAllDeps.FullRowSelect = true;
        this.lvAllDeps.Location = new System.Drawing.Point(0, 0);
        this.lvAllDeps.Name = "lvAllDeps";
        this.lvAllDeps.OverriddenDoubleBuffered = true;
        this.lvAllDeps.Size = new System.Drawing.Size(470, 163);
        this.lvAllDeps.TabIndex = 5;
        this.lvAllDeps.UseCompatibleStateImageBehavior = false;
        this.lvAllDeps.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader15
        // 
        this.ColumnHeader15.Text = "Module";
        this.ColumnHeader15.Width = 72;
        // 
        // ColumnHeader16
        // 
        this.ColumnHeader16.Text = "Timestamp";
        // 
        // ColumnHeader17
        // 
        this.ColumnHeader17.Text = "Size";
        // 
        // ColumnHeader18
        // 
        this.ColumnHeader18.Text = "Machine";
        // 
        // ColumnHeader19
        // 
        this.ColumnHeader19.Text = "Subsystem";
        // 
        // ColumnHeader20
        // 
        this.ColumnHeader20.Text = "Product";
        // 
        // ColumnHeader10
        // 
        this.ColumnHeader10.Text = "Company";
        // 
        // ColumnHeader11
        // 
        this.ColumnHeader11.Text = "File Version";
        // 
        // ColumnHeader12
        // 
        this.ColumnHeader12.Text = "Product Version";
        // 
        // ColumnHeader13
        // 
        this.ColumnHeader13.Text = "Linker Version";
        // 
        // ColumnHeader14
        // 
        this.ColumnHeader14.Text = "Path";
        this.ColumnHeader14.Width = 200;
        // 
        // cMenu1
        // 
        this.cMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem1, this.MenuItem2, this.MenuItem3, this.MenuItem4 });
        // 
        // MenuItem1
        // 
        this.VistaMenu.SetImage(this.MenuItem1, (System.Drawing.Image)resources.GetObject("MenuItem1.Image"));
        this.MenuItem1.Index = 0;
        this.MenuItem1.Text = "&File properties";
        // 
        // MenuItem2
        // 
        this.VistaMenu.SetImage(this.MenuItem2, (System.Drawing.Image)resources.GetObject("MenuItem2.Image"));
        this.MenuItem2.Index = 1;
        this.MenuItem2.Text = "&Open directory";
        // 
        // MenuItem3
        // 
        this.VistaMenu.SetImage(this.MenuItem3, global::My.Resources.Resources.magnifier);
        this.MenuItem3.Index = 2;
        this.MenuItem3.Text = "File details";
        // 
        // MenuItem4
        // 
        this.VistaMenu.SetImage(this.MenuItem4, global::My.Resources.Resources.globe);
        this.MenuItem4.Index = 3;
        this.MenuItem4.Text = "Internet search";
        // 
        // MenuItemFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemFileProp, (System.Drawing.Image)resources.GetObject("MenuItemFileProp.Image"));
        this.MenuItemFileProp.Index = 0;
        this.MenuItemFileProp.Text = "&File properties";
        // 
        // MenuItemOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemOpenDir.Index = 1;
        this.MenuItemOpenDir.Text = "&Open directory";
        // 
        // cMenu2
        // 
        this.cMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemFileProp, this.MenuItemOpenDir, this.MenuItemFileDet, this.MenuItemInternetSearch });
        // 
        // MenuItemFileDet
        // 
        this.VistaMenu.SetImage(this.MenuItemFileDet, global::My.Resources.Resources.magnifier);
        this.MenuItemFileDet.Index = 2;
        this.MenuItemFileDet.Text = "&File details";
        // 
        // MenuItemInternetSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemInternetSearch, global::My.Resources.Resources.globe);
        this.MenuItemInternetSearch.Index = 3;
        this.MenuItemInternetSearch.Text = "&Internet search";
        // 
        // ImageList1
        // 
        this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
        this.ImageList1.TransparentColor = System.Drawing.Color.Magenta;
        this.ImageList1.Images.SetKeyName(0, "unresolved");
        this.ImageList1.Images.SetKeyName(1, "dll");
        this.ImageList1.Images.SetKeyName(2, "function");
        // 
        // MenuItemOpen
        // 
        this.MenuItemOpen.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemOpen, global::My.Resources.Resources.folder_open_document);
        this.MenuItemOpen.Index = 0;
        this.MenuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
        this.MenuItemOpen.Text = "&Open...";
        // 
        // mainMenu
        // 
        this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuFile, this.MenuDisplay });
        // 
        // MenuFile
        // 
        this.MenuFile.Index = 0;
        this.MenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemOpen, this.MenuItemSeparatorAfterOpen, this.MenuItemQuit });
        this.MenuFile.Text = "&File";
        // 
        // MenuItemSeparatorAfterOpen
        // 
        this.MenuItemSeparatorAfterOpen.Index = 1;
        this.MenuItemSeparatorAfterOpen.Text = "-";
        // 
        // MenuItemQuit
        // 
        this.MenuItemQuit.Index = 2;
        this.MenuItemQuit.Text = "&Quit";
        // 
        // MenuDisplay
        // 
        this.MenuDisplay.Index = 1;
        this.MenuDisplay.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemAlwaysVisible });
        this.MenuDisplay.Text = "&Display";
        // 
        // MenuItemAlwaysVisible
        // 
        this.MenuItemAlwaysVisible.Index = 0;
        this.MenuItemAlwaysVisible.Text = "&Always visible";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // frmDepViewerMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(711, 434);
        this.Controls.Add(this.SplitContainer1);
        this.Controls.Add(this.StatusStrip1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Menu = this.mainMenu;
        this.Name = "frmDepViewerMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Native Dependency Viewer";
        this.StatusStrip1.ResumeLayout(false);
        this.StatusStrip1.PerformLayout();
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
        this.SplitContainer2.Panel1.ResumeLayout(false);
        this.SplitContainer2.Panel2.ResumeLayout(false);
        this.SplitContainer2.ResumeLayout(false);
        this.TabControl1.ResumeLayout(false);
        this.tabImports.ResumeLayout(false);
        this.tabExports.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.StatusStrip _StatusStrip1;

    internal System.Windows.Forms.StatusStrip StatusStrip1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _StatusStrip1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_StatusStrip1 != null)
            {
            }

            _StatusStrip1 = value;
            if (_StatusStrip1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _statusFile;

    internal System.Windows.Forms.ToolStripStatusLabel statusFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _statusFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_statusFile != null)
            {
            }

            _statusFile = value;
            if (_statusFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.OpenFileDialog _CDO;

    private System.Windows.Forms.OpenFileDialog CDO
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _CDO;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_CDO != null)
            {
            }

            _CDO = value;
            if (_CDO != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer1;

    internal System.Windows.Forms.SplitContainer SplitContainer1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer1 != null)
            {
            }

            _SplitContainer1 = value;
            if (_SplitContainer1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TreeView _tvDepends;

    internal System.Windows.Forms.TreeView tvDepends
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tvDepends;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tvDepends != null)
            {
            }

            _tvDepends = value;
            if (_tvDepends != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer2;

    internal System.Windows.Forms.SplitContainer SplitContainer2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer2 != null)
            {
            }

            _SplitContainer2 = value;
            if (_SplitContainer2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabControl _TabControl1;

    internal System.Windows.Forms.TabControl TabControl1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabControl1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabControl1 != null)
            {
            }

            _TabControl1 = value;
            if (_TabControl1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _tabImports;

    internal System.Windows.Forms.TabPage tabImports
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabImports;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabImports != null)
            {
            }

            _tabImports = value;
            if (_tabImports != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvImports;

    internal DoubleBufferedLV lvImports
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvImports;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvImports != null)
            {
            }

            _lvImports = value;
            if (_lvImports != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader4;

    internal System.Windows.Forms.ColumnHeader ColumnHeader4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader4 != null)
            {
            }

            _ColumnHeader4 = value;
            if (_ColumnHeader4 != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader9;

    internal System.Windows.Forms.ColumnHeader ColumnHeader9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader9 != null)
            {
            }

            _ColumnHeader9 = value;
            if (_ColumnHeader9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _tabExports;

    internal System.Windows.Forms.TabPage tabExports
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabExports;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabExports != null)
            {
            }

            _tabExports = value;
            if (_tabExports != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvExports;

    internal DoubleBufferedLV lvExports
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvExports;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvExports != null)
            {
            }

            _lvExports = value;
            if (_lvExports != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader7;

    internal System.Windows.Forms.ColumnHeader ColumnHeader7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader7 != null)
            {
            }

            _ColumnHeader7 = value;
            if (_ColumnHeader7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader8;

    internal System.Windows.Forms.ColumnHeader ColumnHeader8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader8 != null)
            {
            }

            _ColumnHeader8 = value;
            if (_ColumnHeader8 != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lvAllDeps;

    internal DoubleBufferedLV lvAllDeps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvAllDeps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvAllDeps != null)
            {
            }

            _lvAllDeps = value;
            if (_lvAllDeps != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader15;

    internal System.Windows.Forms.ColumnHeader ColumnHeader15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader15 != null)
            {
            }

            _ColumnHeader15 = value;
            if (_ColumnHeader15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader16;

    internal System.Windows.Forms.ColumnHeader ColumnHeader16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader16 != null)
            {
            }

            _ColumnHeader16 = value;
            if (_ColumnHeader16 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader17;

    internal System.Windows.Forms.ColumnHeader ColumnHeader17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader17 != null)
            {
            }

            _ColumnHeader17 = value;
            if (_ColumnHeader17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader18;

    internal System.Windows.Forms.ColumnHeader ColumnHeader18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader18 != null)
            {
            }

            _ColumnHeader18 = value;
            if (_ColumnHeader18 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader19;

    internal System.Windows.Forms.ColumnHeader ColumnHeader19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader19 != null)
            {
            }

            _ColumnHeader19 = value;
            if (_ColumnHeader19 != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader10;

    internal System.Windows.Forms.ColumnHeader ColumnHeader10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader10 != null)
            {
            }

            _ColumnHeader10 = value;
            if (_ColumnHeader10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader11;

    internal System.Windows.Forms.ColumnHeader ColumnHeader11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader11 != null)
            {
            }

            _ColumnHeader11 = value;
            if (_ColumnHeader11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader12;

    internal System.Windows.Forms.ColumnHeader ColumnHeader12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader12 != null)
            {
            }

            _ColumnHeader12 = value;
            if (_ColumnHeader12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader13;

    internal System.Windows.Forms.ColumnHeader ColumnHeader13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader13 != null)
            {
            }

            _ColumnHeader13 = value;
            if (_ColumnHeader13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader14;

    internal System.Windows.Forms.ColumnHeader ColumnHeader14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader14 != null)
            {
            }

            _ColumnHeader14 = value;
            if (_ColumnHeader14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _cMenu1;

    private System.Windows.Forms.ContextMenu cMenu1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cMenu1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cMenu1 != null)
            {
            }

            _cMenu1 = value;
            if (_cMenu1 != null)
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

    private System.Windows.Forms.ContextMenu _cMenu2;

    private System.Windows.Forms.ContextMenu cMenu2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cMenu2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cMenu2 != null)
            {
            }

            _cMenu2 = value;
            if (_cMenu2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileProp;

    internal System.Windows.Forms.MenuItem MenuItemFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileProp != null)
            {
            }

            _MenuItemFileProp = value;
            if (_MenuItemFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemOpenDir;

    internal System.Windows.Forms.MenuItem MenuItemOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemOpenDir != null)
            {
            }

            _MenuItemOpenDir = value;
            if (_MenuItemOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.ImageList _ImageList1;

    internal System.Windows.Forms.ImageList ImageList1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ImageList1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ImageList1 != null)
            {
            }

            _ImageList1 = value;
            if (_ImageList1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFileDet;

    internal System.Windows.Forms.MenuItem MenuItemFileDet
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFileDet;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFileDet != null)
            {
            }

            _MenuItemFileDet = value;
            if (_MenuItemFileDet != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemInternetSearch;

    internal System.Windows.Forms.MenuItem MenuItemInternetSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemInternetSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemInternetSearch != null)
            {
            }

            _MenuItemInternetSearch = value;
            if (_MenuItemInternetSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem3;

    internal System.Windows.Forms.MenuItem MenuItem3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem3 != null)
            {
            }

            _MenuItem3 = value;
            if (_MenuItem3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem4;

    internal System.Windows.Forms.MenuItem MenuItem4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem4 != null)
            {
            }

            _MenuItem4 = value;
            if (_MenuItem4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MainMenu _mainMenu;

    private System.Windows.Forms.MainMenu mainMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mainMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mainMenu != null)
            {
            }

            _mainMenu = value;
            if (_mainMenu != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuFile;

    internal System.Windows.Forms.MenuItem MenuFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuFile != null)
            {
            }

            _MenuFile = value;
            if (_MenuFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemOpen;

    internal System.Windows.Forms.MenuItem MenuItemOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemOpen != null)
            {
            }

            _MenuItemOpen = value;
            if (_MenuItemOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSeparatorAfterOpen;

    internal System.Windows.Forms.MenuItem MenuItemSeparatorAfterOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSeparatorAfterOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSeparatorAfterOpen != null)
            {
            }

            _MenuItemSeparatorAfterOpen = value;
            if (_MenuItemSeparatorAfterOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemQuit;

    internal System.Windows.Forms.MenuItem MenuItemQuit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemQuit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemQuit != null)
            {
            }

            _MenuItemQuit = value;
            if (_MenuItemQuit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuDisplay;

    internal System.Windows.Forms.MenuItem MenuDisplay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuDisplay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuDisplay != null)
            {
            }

            _MenuDisplay = value;
            if (_MenuDisplay != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemAlwaysVisible;

    internal System.Windows.Forms.MenuItem MenuItemAlwaysVisible
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemAlwaysVisible;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemAlwaysVisible != null)
            {
            }

            _MenuItemAlwaysVisible = value;
            if (_MenuItemAlwaysVisible != null)
            {
            }
        }
    }
}

