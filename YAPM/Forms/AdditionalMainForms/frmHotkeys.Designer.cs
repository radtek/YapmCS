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
partial class frmHotkeys : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHotkeys));
        this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        this.imgList = new System.Windows.Forms.ImageList(this.components);
        this.gp = new System.Windows.Forms.GroupBox();
        this.cbAction = new System.Windows.Forms.ComboBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.cmdKO = new System.Windows.Forms.Button();
        this.cmdAdd = new System.Windows.Forms.Button();
        this.lblKey = new System.Windows.Forms.Label();
        this.txtKey = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.chkAlt = new System.Windows.Forms.CheckBox();
        this.chkShift = new System.Windows.Forms.CheckBox();
        this.chkCtrl = new System.Windows.Forms.CheckBox();
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader52 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.mnuRemoveFolder = new System.Windows.Forms.MenuItem();
        this.MenuItem = new System.Windows.Forms.MenuItem();
        this.TheContextMenu = new System.Windows.Forms.ContextMenu();
        this.menuItem12 = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.gp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // timerRefresh
        // 
        this.timerRefresh.Enabled = true;
        // 
        // imgList
        // 
        this.imgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList.ImageStream");
        this.imgList.TransparentColor = System.Drawing.Color.Transparent;
        this.imgList.Images.SetKeyName(0, "default");
        // 
        // gp
        // 
        this.gp.Controls.Add(this.cbAction);
        this.gp.Controls.Add(this.Label3);
        this.gp.Controls.Add(this.cmdKO);
        this.gp.Controls.Add(this.cmdAdd);
        this.gp.Controls.Add(this.lblKey);
        this.gp.Controls.Add(this.txtKey);
        this.gp.Controls.Add(this.Label1);
        this.gp.Controls.Add(this.chkAlt);
        this.gp.Controls.Add(this.chkShift);
        this.gp.Controls.Add(this.chkCtrl);
        this.gp.Location = new System.Drawing.Point(121, 130);
        this.gp.Name = "gp";
        this.gp.Size = new System.Drawing.Size(300, 140);
        this.gp.TabIndex = 6;
        this.gp.TabStop = false;
        this.gp.Text = "Add an emergency hotkey";
        this.gp.Visible = false;
        // 
        // cbAction
        // 
        this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbAction.FormattingEnabled = true;
        this.cbAction.Location = new System.Drawing.Point(56, 111);
        this.cbAction.Name = "cbAction";
        this.cbAction.Size = new System.Drawing.Size(238, 21);
        this.cbAction.TabIndex = 9;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(10, 114);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(40, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "Action";
        // 
        // cmdKO
        // 
        this.cmdKO.Location = new System.Drawing.Point(239, 49);
        this.cmdKO.Name = "cmdKO";
        this.cmdKO.Size = new System.Drawing.Size(55, 23);
        this.cmdKO.TabIndex = 7;
        this.cmdKO.Text = "Cancel";
        this.cmdKO.UseVisualStyleBackColor = true;
        // 
        // cmdAdd
        // 
        this.cmdAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdAdd.Location = new System.Drawing.Point(239, 20);
        this.cmdAdd.Name = "cmdAdd";
        this.cmdAdd.Size = new System.Drawing.Size(55, 23);
        this.cmdAdd.TabIndex = 6;
        this.cmdAdd.Text = "Add";
        this.cmdAdd.UseVisualStyleBackColor = true;
        // 
        // lblKey
        // 
        this.lblKey.AutoSize = true;
        this.lblKey.Location = new System.Drawing.Point(113, 82);
        this.lblKey.Name = "lblKey";
        this.lblKey.Size = new System.Drawing.Size(62, 13);
        this.lblKey.TabIndex = 5;
        this.lblKey.Text = "Press a key";
        // 
        // txtKey
        // 
        this.txtKey.AcceptsReturn = true;
        this.txtKey.AcceptsTab = true;
        this.txtKey.BackColor = System.Drawing.Color.White;
        this.txtKey.Location = new System.Drawing.Point(128, 47);
        this.txtKey.MaxLength = 0;
        this.txtKey.Multiline = true;
        this.txtKey.Name = "txtKey";
        this.txtKey.ReadOnly = true;
        this.txtKey.Size = new System.Drawing.Size(32, 32);
        this.txtKey.TabIndex = 4;
        this.txtKey.TabStop = false;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label1.Location = new System.Drawing.Point(83, 54);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(25, 25);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "+";
        // 
        // chkAlt
        // 
        this.chkAlt.AutoSize = true;
        this.chkAlt.Location = new System.Drawing.Point(12, 90);
        this.chkAlt.Name = "chkAlt";
        this.chkAlt.Size = new System.Drawing.Size(40, 17);
        this.chkAlt.TabIndex = 2;
        this.chkAlt.Text = "Alt";
        this.chkAlt.UseVisualStyleBackColor = true;
        // 
        // chkShift
        // 
        this.chkShift.AutoSize = true;
        this.chkShift.Checked = true;
        this.chkShift.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkShift.Location = new System.Drawing.Point(13, 56);
        this.chkShift.Name = "chkShift";
        this.chkShift.Size = new System.Drawing.Size(50, 17);
        this.chkShift.TabIndex = 1;
        this.chkShift.Text = "Shift";
        this.chkShift.UseVisualStyleBackColor = true;
        // 
        // chkCtrl
        // 
        this.chkCtrl.AutoSize = true;
        this.chkCtrl.Checked = true;
        this.chkCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkCtrl.Location = new System.Drawing.Point(12, 26);
        this.chkCtrl.Name = "chkCtrl";
        this.chkCtrl.Size = new System.Drawing.Size(65, 17);
        this.chkCtrl.TabIndex = 0;
        this.chkCtrl.Text = "Control";
        this.chkCtrl.UseVisualStyleBackColor = true;
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
        this.lv.Size = new System.Drawing.Size(543, 401);
        this.lv.SmallImageList = this.imgList;
        this.lv.TabIndex = 5;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader52
        // 
        this.ColumnHeader52.Text = "Hotkeys";
        this.ColumnHeader52.Width = 210;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Action";
        this.ColumnHeader1.Width = 327;
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // mnuRemoveFolder
        // 
        this.VistaMenu.SetImage(this.mnuRemoveFolder, global::My.Resources.Resources.cross16);
        this.mnuRemoveFolder.Index = 1;
        this.mnuRemoveFolder.Text = "Remove";
        // 
        // MenuItem
        // 
        this.MenuItem.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItem, global::My.Resources.Resources.plus_circle);
        this.MenuItem.Index = 0;
        this.MenuItem.Text = "Add";
        // 
        // TheContextMenu
        // 
        this.TheContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem, this.mnuRemoveFolder, this.menuItem12, this.MenuItem2, this.MenuItem3 });
        // 
        // menuItem12
        // 
        this.menuItem12.Index = 2;
        this.menuItem12.Text = "-";
        // 
        // MenuItem2
        // 
        this.MenuItem2.Index = 3;
        this.MenuItem2.Text = "Enable";
        // 
        // MenuItem3
        // 
        this.MenuItem3.Index = 4;
        this.MenuItem3.Text = "Disable";
        // 
        // frmHotkeys
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(543, 401);
        this.Controls.Add(this.gp);
        this.Controls.Add(this.lv);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmHotkeys";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Emergency hotkeys list";
        this.gp.ResumeLayout(false);
        this.gp.PerformLayout();
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

    private System.Windows.Forms.GroupBox _gp;

    internal System.Windows.Forms.GroupBox gp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gp != null)
            {
            }

            _gp = value;
            if (_gp != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtKey;

    internal System.Windows.Forms.TextBox txtKey
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtKey;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtKey != null)
            {
            }

            _txtKey = value;
            if (_txtKey != null)
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

    private System.Windows.Forms.CheckBox _chkAlt;

    internal System.Windows.Forms.CheckBox chkAlt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkAlt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkAlt != null)
            {
            }

            _chkAlt = value;
            if (_chkAlt != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkShift;

    internal System.Windows.Forms.CheckBox chkShift
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkShift;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkShift != null)
            {
            }

            _chkShift = value;
            if (_chkShift != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCtrl;

    internal System.Windows.Forms.CheckBox chkCtrl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCtrl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCtrl != null)
            {
            }

            _chkCtrl = value;
            if (_chkCtrl != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdKO;

    internal System.Windows.Forms.Button cmdKO
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdKO;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdKO != null)
            {
            }

            _cmdKO = value;
            if (_cmdKO != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdAdd;

    internal System.Windows.Forms.Button cmdAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdAdd != null)
            {
            }

            _cmdAdd = value;
            if (_cmdAdd != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKey;

    internal System.Windows.Forms.Label lblKey
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKey;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKey != null)
            {
            }

            _lblKey = value;
            if (_lblKey != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbAction;

    internal System.Windows.Forms.ComboBox cbAction
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbAction;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbAction != null)
            {
            }

            _cbAction = value;
            if (_cbAction != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label3;

    internal System.Windows.Forms.Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label3 != null)
            {
            }

            _Label3 = value;
            if (_Label3 != null)
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

    private System.Windows.Forms.MenuItem _mnuRemoveFolder;

    private System.Windows.Forms.MenuItem mnuRemoveFolder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuRemoveFolder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuRemoveFolder != null)
            {
            }

            _mnuRemoveFolder = value;
            if (_mnuRemoveFolder != null)
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
}

