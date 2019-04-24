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
partial class frmHeapBlocks : System.Windows.Forms.Form
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
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.cmdOK = new System.Windows.Forms.Button();
        this.mnuPopup = new System.Windows.Forms.ContextMenu();
        this.MenuItemViewMemory = new System.Windows.Forms.MenuItem();
        this.MenuItem2 = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyObj = new System.Windows.Forms.MenuItem();
        this.MenuItemCpAddress = new System.Windows.Forms.MenuItem();
        this.MenuItemCpSize = new System.Windows.Forms.MenuItem();
        this.MenuItemCpStatus = new System.Windows.Forms.MenuItem();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer.IsSplitterFixed = true;
        this.SplitContainer.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.lv);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.cmdOK);
        this.SplitContainer.Size = new System.Drawing.Size(481, 307);
        this.SplitContainer.SplitterDistance = 275;
        this.SplitContainer.TabIndex = 0;
        // 
        // lv
        // 
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader4 });
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lv.FullRowSelect = true;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(481, 275);
        this.lv.TabIndex = 2;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Address";
        this.ColumnHeader1.Width = 155;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Size";
        this.ColumnHeader2.Width = 91;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Status";
        this.ColumnHeader4.Width = 97;
        // 
        // cmdOK
        // 
        this.cmdOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.cmdOK.Location = new System.Drawing.Point(394, 1);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 1;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // mnuPopup
        // 
        this.mnuPopup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemViewMemory, this.MenuItem2, this.MenuItemCopyObj });
        // 
        // MenuItemViewMemory
        // 
        this.VistaMenu.SetImage(this.MenuItemViewMemory, global::My.Resources.Resources.magnifier);
        this.MenuItemViewMemory.Index = 0;
        this.MenuItemViewMemory.Text = "View memory";
        // 
        // MenuItem2
        // 
        this.MenuItem2.Index = 1;
        this.MenuItem2.Text = "-";
        // 
        // MenuItemCopyObj
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyObj, global::My.Resources.Resources.copy16);
        this.MenuItemCopyObj.Index = 2;
        this.MenuItemCopyObj.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCpAddress, this.MenuItemCpSize, this.MenuItemCpStatus });
        this.MenuItemCopyObj.Text = "Copy to clipboard";
        // 
        // MenuItemCpAddress
        // 
        this.MenuItemCpAddress.Index = 0;
        this.MenuItemCpAddress.Text = "Address";
        // 
        // MenuItemCpSize
        // 
        this.MenuItemCpSize.Index = 1;
        this.MenuItemCpSize.Text = "Size";
        // 
        // MenuItemCpStatus
        // 
        this.MenuItemCpStatus.Index = 2;
        this.MenuItemCpStatus.Text = "Status";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // frmHeapBlocks
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(481, 307);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "frmHeapBlocks";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Heap blocks (node address : xx)";
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
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

    private System.Windows.Forms.Button _cmdOK;

    internal System.Windows.Forms.Button cmdOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOK != null)
            {
            }

            _cmdOK = value;
            if (_cmdOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuPopup;

    private System.Windows.Forms.ContextMenu mnuPopup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuPopup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuPopup != null)
            {
            }

            _mnuPopup = value;
            if (_mnuPopup != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyObj;

    internal System.Windows.Forms.MenuItem MenuItemCopyObj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyObj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyObj != null)
            {
            }

            _MenuItemCopyObj = value;
            if (_MenuItemCopyObj != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCpAddress;

    internal System.Windows.Forms.MenuItem MenuItemCpAddress
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCpAddress;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCpAddress != null)
            {
            }

            _MenuItemCpAddress = value;
            if (_MenuItemCpAddress != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCpSize;

    internal System.Windows.Forms.MenuItem MenuItemCpSize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCpSize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCpSize != null)
            {
            }

            _MenuItemCpSize = value;
            if (_MenuItemCpSize != null)
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

    private System.Windows.Forms.MenuItem _MenuItemViewMemory;

    internal System.Windows.Forms.MenuItem MenuItemViewMemory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemViewMemory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemViewMemory != null)
            {
            }

            _MenuItemViewMemory = value;
            if (_MenuItemViewMemory != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCpStatus;

    internal System.Windows.Forms.MenuItem MenuItemCpStatus
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCpStatus;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCpStatus != null)
            {
            }

            _MenuItemCpStatus = value;
            if (_MenuItemCpStatus != null)
            {
            }
        }
    }
}

