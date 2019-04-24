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
partial class frmScripting : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScripting));
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemOpen = new System.Windows.Forms.MenuItem();
        this.MenuItemSave = new System.Windows.Forms.MenuItem();
        this.MenuItemSaveAs = new System.Windows.Forms.MenuItem();
        this.MenuItemExit = new System.Windows.Forms.MenuItem();
        this.MenuItemVerify = new System.Windows.Forms.MenuItem();
        this.MenuItemExecute = new System.Windows.Forms.MenuItem();
        this.mnuSystem = new System.Windows.Forms.MainMenu(this.components);
        this.MenuItemFile = new System.Windows.Forms.MenuItem();
        this.MenuItem56 = new System.Windows.Forms.MenuItem();
        this.MenuItemScripts = new System.Windows.Forms.MenuItem();
        this.StatusBar = new System.Windows.Forms.StatusBar();
        this.sbPanelLines = new System.Windows.Forms.StatusBarPanel();
        this.ToolStrip = new System.Windows.Forms.ToolStrip();
        this.cmdOpen = new System.Windows.Forms.ToolStripButton();
        this.cmdSave = new System.Windows.Forms.ToolStripButton();
        this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.cmdCheckScript = new System.Windows.Forms.ToolStripButton();
        this.cmdExecute = new System.Windows.Forms.ToolStripButton();
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelLines).BeginInit();
        this.ToolStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItemOpen
        // 
        this.MenuItemOpen.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemOpen, global::My.Resources.Resources.folder_open_document);
        this.MenuItemOpen.Index = 0;
        this.MenuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
        this.MenuItemOpen.Text = "&Open script...";
        // 
        // MenuItemSave
        // 
        this.VistaMenu.SetImage(this.MenuItemSave, global::My.Resources.Resources.save16);
        this.MenuItemSave.Index = 1;
        this.MenuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
        this.MenuItemSave.Text = "&Save script";
        // 
        // MenuItemSaveAs
        // 
        this.VistaMenu.SetImage(this.MenuItemSaveAs, global::My.Resources.Resources.save16);
        this.MenuItemSaveAs.Index = 2;
        this.MenuItemSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
        this.MenuItemSaveAs.Text = "&Save as...";
        // 
        // MenuItemExit
        // 
        this.VistaMenu.SetImage(this.MenuItemExit, global::My.Resources.Resources.cross16);
        this.MenuItemExit.Index = 4;
        this.MenuItemExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
        this.MenuItemExit.Text = "E&xit";
        // 
        // MenuItemVerify
        // 
        this.VistaMenu.SetImage(this.MenuItemVerify, global::My.Resources.Resources.ok16);
        this.MenuItemVerify.Index = 0;
        this.MenuItemVerify.Shortcut = System.Windows.Forms.Shortcut.F3;
        this.MenuItemVerify.Text = "&Verify";
        // 
        // MenuItemExecute
        // 
        this.MenuItemExecute.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemExecute, global::My.Resources.Resources.right16);
        this.MenuItemExecute.Index = 1;
        this.MenuItemExecute.Shortcut = System.Windows.Forms.Shortcut.F5;
        this.MenuItemExecute.Text = "&Execute";
        // 
        // mnuSystem
        // 
        this.mnuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemFile, this.MenuItemScripts });
        // 
        // MenuItemFile
        // 
        this.MenuItemFile.Index = 0;
        this.MenuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemOpen, this.MenuItemSave, this.MenuItemSaveAs, this.MenuItem56, this.MenuItemExit });
        this.MenuItemFile.Text = "&File";
        // 
        // MenuItem56
        // 
        this.MenuItem56.Index = 3;
        this.MenuItem56.Text = "-";
        // 
        // MenuItemScripts
        // 
        this.MenuItemScripts.Index = 1;
        this.MenuItemScripts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemVerify, this.MenuItemExecute });
        this.MenuItemScripts.Text = "&Script";
        // 
        // StatusBar
        // 
        this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.StatusBar.Location = new System.Drawing.Point(0, 358);
        this.StatusBar.Name = "StatusBar";
        this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.sbPanelLines });
        this.StatusBar.ShowPanels = true;
        this.StatusBar.Size = new System.Drawing.Size(644, 20);
        this.StatusBar.TabIndex = 63;
        // 
        // sbPanelLines
        // 
        this.sbPanelLines.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
        this.sbPanelLines.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
        this.sbPanelLines.MinWidth = 100;
        this.sbPanelLines.Name = "sbPanelLines";
        this.sbPanelLines.Text = "Lines : 1";
        // 
        // ToolStrip
        // 
        this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cmdOpen, this.cmdSave, this.ToolStripSeparator1, this.cmdCheckScript, this.cmdExecute });
        this.ToolStrip.Location = new System.Drawing.Point(0, 0);
        this.ToolStrip.Name = "ToolStrip";
        this.ToolStrip.Size = new System.Drawing.Size(644, 25);
        this.ToolStrip.TabIndex = 64;
        // 
        // cmdOpen
        // 
        this.cmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.cmdOpen.Image = global::My.Resources.Resources.folder_open_document;
        this.cmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cmdOpen.Name = "cmdOpen";
        this.cmdOpen.Size = new System.Drawing.Size(23, 22);
        this.cmdOpen.Text = "Open script";
        this.cmdOpen.ToolTipText = "Open script";
        // 
        // cmdSave
        // 
        this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.cmdSave.Image = global::My.Resources.Resources.save16;
        this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.Size = new System.Drawing.Size(23, 22);
        this.cmdSave.Text = "Save script";
        // 
        // ToolStripSeparator1
        // 
        this.ToolStripSeparator1.Name = "ToolStripSeparator1";
        this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        // 
        // cmdCheckScript
        // 
        this.cmdCheckScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.cmdCheckScript.Image = global::My.Resources.Resources.ok16;
        this.cmdCheckScript.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cmdCheckScript.Name = "cmdCheckScript";
        this.cmdCheckScript.Size = new System.Drawing.Size(23, 22);
        this.cmdCheckScript.Text = "Verify script";
        this.cmdCheckScript.ToolTipText = "Verify script";
        // 
        // cmdExecute
        // 
        this.cmdExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.cmdExecute.Image = global::My.Resources.Resources.right16;
        this.cmdExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cmdExecute.Name = "cmdExecute";
        this.cmdExecute.Size = new System.Drawing.Size(23, 22);
        this.cmdExecute.Text = "Execute script";
        this.cmdExecute.ToolTipText = "Execute script";
        // 
        // rtb
        // 
        this.rtb.AcceptsTab = true;
        this.rtb.AutoWordSelection = true;
        this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb.DetectUrls = false;
        this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.rtb.Location = new System.Drawing.Point(0, 25);
        this.rtb.Name = "rtb";
        this.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        this.rtb.ShowSelectionMargin = true;
        this.rtb.Size = new System.Drawing.Size(644, 333);
        this.rtb.TabIndex = 65;
        this.rtb.Text = "";
        // 
        // SaveFileDialog
        // 
        this.SaveFileDialog.DefaultExt = "txt";
        this.SaveFileDialog.Filter = "Text file (*.txt)|*.txt|All (*.*)|*.*";
        this.SaveFileDialog.SupportMultiDottedExtensions = true;
        this.SaveFileDialog.Title = "Save script";
        // 
        // OpenFileDialog
        // 
        this.OpenFileDialog.DefaultExt = "txt";
        this.OpenFileDialog.Filter = "Text file (*.txt)|*.txt|All (*.*)|*.*";
        this.OpenFileDialog.ShowReadOnly = true;
        this.OpenFileDialog.SupportMultiDottedExtensions = true;
        this.OpenFileDialog.Title = "Open script";
        // 
        // frmScripting
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(644, 378);
        this.Controls.Add(this.rtb);
        this.Controls.Add(this.ToolStrip);
        this.Controls.Add(this.StatusBar);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Menu = this.mnuSystem;
        this.MinimumSize = new System.Drawing.Size(660, 359);
        this.Name = "frmScripting";
        this.Text = "Script editor";
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.sbPanelLines).EndInit();
        this.ToolStrip.ResumeLayout(false);
        this.ToolStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.MainMenu _mnuSystem;

    private System.Windows.Forms.MainMenu mnuSystem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuSystem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuSystem != null)
            {
            }

            _mnuSystem = value;
            if (_mnuSystem != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemFile;

    internal System.Windows.Forms.MenuItem MenuItemFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemFile != null)
            {
            }

            _MenuItemFile = value;
            if (_MenuItemFile != null)
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

    private System.Windows.Forms.MenuItem _MenuItemSave;

    internal System.Windows.Forms.MenuItem MenuItemSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSave != null)
            {
            }

            _MenuItemSave = value;
            if (_MenuItemSave != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemSaveAs;

    internal System.Windows.Forms.MenuItem MenuItemSaveAs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemSaveAs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemSaveAs != null)
            {
            }

            _MenuItemSaveAs = value;
            if (_MenuItemSaveAs != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem56;

    internal System.Windows.Forms.MenuItem MenuItem56
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem56;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem56 != null)
            {
            }

            _MenuItem56 = value;
            if (_MenuItem56 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemExit;

    internal System.Windows.Forms.MenuItem MenuItemExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemExit != null)
            {
            }

            _MenuItemExit = value;
            if (_MenuItemExit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemScripts;

    internal System.Windows.Forms.MenuItem MenuItemScripts
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemScripts;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemScripts != null)
            {
            }

            _MenuItemScripts = value;
            if (_MenuItemScripts != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemVerify;

    internal System.Windows.Forms.MenuItem MenuItemVerify
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemVerify;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemVerify != null)
            {
            }

            _MenuItemVerify = value;
            if (_MenuItemVerify != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemExecute;

    internal System.Windows.Forms.MenuItem MenuItemExecute
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemExecute;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemExecute != null)
            {
            }

            _MenuItemExecute = value;
            if (_MenuItemExecute != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBar _StatusBar;

    internal System.Windows.Forms.StatusBar StatusBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _StatusBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_StatusBar != null)
            {
            }

            _StatusBar = value;
            if (_StatusBar != null)
            {
            }
        }
    }

    private System.Windows.Forms.StatusBarPanel _sbPanelLines;

    internal System.Windows.Forms.StatusBarPanel sbPanelLines
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sbPanelLines;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sbPanelLines != null)
            {
            }

            _sbPanelLines = value;
            if (_sbPanelLines != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStrip _ToolStrip;

    internal System.Windows.Forms.ToolStrip ToolStrip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ToolStrip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ToolStrip != null)
            {
            }

            _ToolStrip = value;
            if (_ToolStrip != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripButton _cmdOpen;

    internal System.Windows.Forms.ToolStripButton cmdOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpen != null)
            {
            }

            _cmdOpen = value;
            if (_cmdOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripButton _cmdSave;

    internal System.Windows.Forms.ToolStripButton cmdSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSave != null)
            {
            }

            _cmdSave = value;
            if (_cmdSave != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;

    internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ToolStripSeparator1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ToolStripSeparator1 != null)
            {
            }

            _ToolStripSeparator1 = value;
            if (_ToolStripSeparator1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripButton _cmdCheckScript;

    internal System.Windows.Forms.ToolStripButton cmdCheckScript
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCheckScript;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCheckScript != null)
            {
            }

            _cmdCheckScript = value;
            if (_cmdCheckScript != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripButton _cmdExecute;

    internal System.Windows.Forms.ToolStripButton cmdExecute
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdExecute;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdExecute != null)
            {
            }

            _cmdExecute = value;
            if (_cmdExecute != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtb;

    internal System.Windows.Forms.RichTextBox rtb
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtb;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtb != null)
            {
            }

            _rtb = value;
            if (_rtb != null)
            {
            }
        }
    }

    private System.Windows.Forms.SaveFileDialog _SaveFileDialog;

    internal System.Windows.Forms.SaveFileDialog SaveFileDialog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SaveFileDialog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SaveFileDialog != null)
            {
            }

            _SaveFileDialog = value;
            if (_SaveFileDialog != null)
            {
            }
        }
    }

    private System.Windows.Forms.OpenFileDialog _OpenFileDialog;

    internal System.Windows.Forms.OpenFileDialog OpenFileDialog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OpenFileDialog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_OpenFileDialog != null)
            {
            }

            _OpenFileDialog = value;
            if (_OpenFileDialog != null)
            {
            }
        }
    }
}

