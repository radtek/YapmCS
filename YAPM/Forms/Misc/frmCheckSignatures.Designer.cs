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
partial class frmCheckSignatures : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckSignatures));
        this.sb = new System.Windows.Forms.StatusStrip();
        this.lblOK = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblUnknown = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblFailed = new System.Windows.Forms.ToolStripStatusLabel();
        this.pgb = new System.Windows.Forms.ToolStripProgressBar();
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.lvProcess = new processList();
        this.c1 = new System.Windows.Forms.ColumnHeader();
        this.c2 = new System.Windows.Forms.ColumnHeader();
        this.c8 = new System.Windows.Forms.ColumnHeader();
        this.lvResult = new DoubleBufferedLV();
        this.pathCol = new System.Windows.Forms.ColumnHeader();
        this.resCol = new System.Windows.Forms.ColumnHeader();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemShow = new System.Windows.Forms.MenuItem();
        this.MenuItemClose = new System.Windows.Forms.MenuItem();
        this.MenuItem1 = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.TheContextMenu = new System.Windows.Forms.ContextMenu();
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.MenuItemCAll = new System.Windows.Forms.MenuItem();
        this.MenuItemCNone = new System.Windows.Forms.MenuItem();
        this.cmdCheck = new System.Windows.Forms.Button();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.sb.SuspendLayout();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // sb
        // 
        this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblOK, this.lblUnknown, this.lblFailed, this.pgb });
        this.sb.Location = new System.Drawing.Point(0, 352);
        this.sb.Name = "sb";
        this.sb.Size = new System.Drawing.Size(591, 22);
        this.sb.TabIndex = 5;
        this.sb.Text = "StatusStrip1";
        // 
        // lblOK
        // 
        this.lblOK.ForeColor = System.Drawing.Color.Green;
        this.lblOK.Name = "lblOK";
        this.lblOK.Size = new System.Drawing.Size(62, 17);
        this.lblOK.Text = "Trusted : 0";
        // 
        // lblUnknown
        // 
        this.lblUnknown.Name = "lblUnknown";
        this.lblUnknown.Size = new System.Drawing.Size(73, 17);
        this.lblUnknown.Text = "Unknown : 0";
        // 
        // lblFailed
        // 
        this.lblFailed.ForeColor = System.Drawing.Color.Red;
        this.lblFailed.Name = "lblFailed";
        this.lblFailed.Size = new System.Drawing.Size(82, 17);
        this.lblFailed.Text = "Not trusted : 0";
        // 
        // pgb
        // 
        this.pgb.Name = "pgb";
        this.pgb.Size = new System.Drawing.Size(100, 16);
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.SplitContainer1);
        this.SplitContainer.Panel2Collapsed = true;
        this.SplitContainer.Size = new System.Drawing.Size(591, 352);
        this.SplitContainer.SplitterDistance = 211;
        this.SplitContainer.TabIndex = 6;
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.lvProcess);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.lvResult);
        this.SplitContainer1.Size = new System.Drawing.Size(591, 352);
        this.SplitContainer1.SplitterDistance = 334;
        this.SplitContainer1.TabIndex = 0;
        // 
        // lvProcess
        // 
        this.lvProcess.AllowColumnReorder = true;
        this.lvProcess.CatchErrors = false;
        this.lvProcess.CheckBoxes = true;
        this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.c1, this.c2, this.c8 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection1.Snapshot = null;
        CConnection1.SnapshotFile = null;
        this.lvProcess.ConnectionObj = CConnection1;
        this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.VisibleProcesses;
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
        this.lvProcess.Size = new System.Drawing.Size(334, 352);
        this.lvProcess.TabIndex = 6;
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
        this.c8.Width = 156;
        // 
        // lvResult
        // 
        this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.pathCol, this.resCol });
        this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvResult.FullRowSelect = true;
        this.lvResult.Location = new System.Drawing.Point(0, 0);
        this.lvResult.Name = "lvResult";
        this.lvResult.OverriddenDoubleBuffered = true;
        this.lvResult.Size = new System.Drawing.Size(253, 352);
        this.lvResult.TabIndex = 0;
        this.lvResult.UseCompatibleStateImageBehavior = false;
        this.lvResult.View = System.Windows.Forms.View.Details;
        // 
        // pathCol
        // 
        this.pathCol.Text = "File";
        this.pathCol.Width = 171;
        // 
        // resCol
        // 
        this.resCol.Text = "Result";
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
        this.TheContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemShow, this.MenuItemClose, this.MenuItem1, this.MenuItem2, this.MenuItem3, this.MenuItemCAll, this.MenuItemCNone });
        // 
        // MenuItem3
        // 
        this.MenuItem3.Index = 4;
        this.MenuItem3.Text = "-";
        // 
        // MenuItemCAll
        // 
        this.MenuItemCAll.Index = 5;
        this.MenuItemCAll.Text = "Check all";
        // 
        // MenuItemCNone
        // 
        this.MenuItemCNone.Index = 6;
        this.MenuItemCNone.Text = "Check none";
        // 
        // cmdCheck
        // 
        this.cmdCheck.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.cmdCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdCheck.Location = new System.Drawing.Point(467, 353);
        this.cmdCheck.Name = "cmdCheck";
        this.cmdCheck.Size = new System.Drawing.Size(93, 21);
        this.cmdCheck.TabIndex = 7;
        this.cmdCheck.Text = "Check now";
        this.cmdCheck.UseVisualStyleBackColor = true;
        // 
        // Timer
        // 
        this.Timer.Interval = 1000;
        // 
        // frmCheckSignatures
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(591, 374);
        this.Controls.Add(this.cmdCheck);
        this.Controls.Add(this.SplitContainer);
        this.Controls.Add(this.sb);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Name = "frmCheckSignatures";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Check signatures";
        this.sb.ResumeLayout(false);
        this.sb.PerformLayout();
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
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

    private System.Windows.Forms.ToolStripStatusLabel _lblOK;

    internal System.Windows.Forms.ToolStripStatusLabel lblOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOK != null)
            {
            }

            _lblOK = value;
            if (_lblOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _lblUnknown;

    internal System.Windows.Forms.ToolStripStatusLabel lblUnknown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUnknown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUnknown != null)
            {
            }

            _lblUnknown = value;
            if (_lblUnknown != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripStatusLabel _lblFailed;

    internal System.Windows.Forms.ToolStripStatusLabel lblFailed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblFailed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblFailed != null)
            {
            }

            _lblFailed = value;
            if (_lblFailed != null)
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

    private System.Windows.Forms.ToolStripProgressBar _pgb;

    internal System.Windows.Forms.ToolStripProgressBar pgb
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

    private System.Windows.Forms.Button _cmdCheck;

    internal System.Windows.Forms.Button cmdCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCheck != null)
            {
            }

            _cmdCheck = value;
            if (_cmdCheck != null)
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

    private DoubleBufferedLV _lvResult;

    internal DoubleBufferedLV lvResult
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvResult;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvResult != null)
            {
            }

            _lvResult = value;
            if (_lvResult != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _pathCol;

    internal System.Windows.Forms.ColumnHeader pathCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pathCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pathCol != null)
            {
            }

            _pathCol = value;
            if (_pathCol != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _resCol;

    internal System.Windows.Forms.ColumnHeader resCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _resCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_resCol != null)
            {
            }

            _resCol = value;
            if (_resCol != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCAll;

    internal System.Windows.Forms.MenuItem MenuItemCAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCAll != null)
            {
            }

            _MenuItemCAll = value;
            if (_MenuItemCAll != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCNone;

    internal System.Windows.Forms.MenuItem MenuItemCNone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCNone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCNone != null)
            {
            }

            _MenuItemCNone = value;
            if (_MenuItemCNone != null)
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

