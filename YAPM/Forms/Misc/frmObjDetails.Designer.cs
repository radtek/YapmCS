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
partial class frmObjDetails : System.Windows.Forms.Form
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
        this.headerDesc = new System.Windows.Forms.ColumnHeader();
        this.headerValue = new System.Windows.Forms.ColumnHeader();
        this.cmdOK = new System.Windows.Forms.Button();
        this.cmdRefresh = new System.Windows.Forms.Button();
        this.mnuPopup = new System.Windows.Forms.ContextMenu();
        this.MenuItemCopyObj = new System.Windows.Forms.MenuItem();
        this.MenuItemCpProperty = new System.Windows.Forms.MenuItem();
        this.MenuItemCpValue = new System.Windows.Forms.MenuItem();
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
        this.SplitContainer.Panel2.Controls.Add(this.cmdRefresh);
        this.SplitContainer.Size = new System.Drawing.Size(330, 181);
        this.SplitContainer.SplitterDistance = 149;
        this.SplitContainer.TabIndex = 0;
        // 
        // lv
        // 
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.headerDesc, this.headerValue });
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lv.FullRowSelect = true;
        this.lv.Location = new System.Drawing.Point(0, 0);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(330, 149);
        this.lv.TabIndex = 2;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // headerDesc
        // 
        this.headerDesc.Text = "Property";
        this.headerDesc.Width = 136;
        // 
        // headerValue
        // 
        this.headerValue.Text = "Value";
        this.headerValue.Width = 159;
        // 
        // cmdOK
        // 
        this.cmdOK.Location = new System.Drawing.Point(218, 1);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 1;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // cmdRefresh
        // 
        this.cmdRefresh.Image = global::My.Resources.Resources.refresh16;
        this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdRefresh.Location = new System.Drawing.Point(37, 1);
        this.cmdRefresh.Name = "cmdRefresh";
        this.cmdRefresh.Size = new System.Drawing.Size(85, 23);
        this.cmdRefresh.TabIndex = 0;
        this.cmdRefresh.Text = "     Refresh";
        this.cmdRefresh.UseVisualStyleBackColor = true;
        // 
        // mnuPopup
        // 
        this.mnuPopup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyObj });
        // 
        // MenuItemCopyObj
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyObj, global::My.Resources.Resources.copy16);
        this.MenuItemCopyObj.Index = 0;
        this.MenuItemCopyObj.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCpProperty, this.MenuItemCpValue });
        this.MenuItemCopyObj.Text = "Copy to clipboard";
        // 
        // MenuItemCpProperty
        // 
        this.MenuItemCpProperty.Index = 0;
        this.MenuItemCpProperty.Text = "Property";
        // 
        // MenuItemCpValue
        // 
        this.MenuItemCpValue.Index = 1;
        this.MenuItemCpValue.Text = "Value";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // frmObjDetails
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(330, 181);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "frmObjDetails";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Object informations";
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

    private System.Windows.Forms.ColumnHeader _headerDesc;

    internal System.Windows.Forms.ColumnHeader headerDesc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _headerDesc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_headerDesc != null)
            {
            }

            _headerDesc = value;
            if (_headerDesc != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _headerValue;

    internal System.Windows.Forms.ColumnHeader headerValue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _headerValue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_headerValue != null)
            {
            }

            _headerValue = value;
            if (_headerValue != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdRefresh;

    internal System.Windows.Forms.Button cmdRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdRefresh != null)
            {
            }

            _cmdRefresh = value;
            if (_cmdRefresh != null)
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

    private System.Windows.Forms.MenuItem _MenuItemCpProperty;

    internal System.Windows.Forms.MenuItem MenuItemCpProperty
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCpProperty;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCpProperty != null)
            {
            }

            _MenuItemCpProperty = value;
            if (_MenuItemCpProperty != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCpValue;

    internal System.Windows.Forms.MenuItem MenuItemCpValue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCpValue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCpValue != null)
            {
            }

            _MenuItemCpValue = value;
            if (_MenuItemCpValue != null)
            {
            }
        }
    }
}

