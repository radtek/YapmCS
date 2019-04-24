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
partial class frmPreferences : System.Windows.Forms.Form
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
        System.Windows.Forms.ListViewItem ListViewItem1 = new System.Windows.Forms.ListViewItem("Suspended thread");
        System.Windows.Forms.ListViewItem ListViewItem2 = new System.Windows.Forms.ListViewItem("Relocated module");
        System.Windows.Forms.ListViewItem ListViewItem3 = new System.Windows.Forms.ListViewItem("Process being debugged");
        System.Windows.Forms.ListViewItem ListViewItem4 = new System.Windows.Forms.ListViewItem("Critical process");
        System.Windows.Forms.ListViewItem ListViewItem5 = new System.Windows.Forms.ListViewItem("Elevated process");
        System.Windows.Forms.ListViewItem ListViewItem6 = new System.Windows.Forms.ListViewItem("Process in job");
        System.Windows.Forms.ListViewItem ListViewItem7 = new System.Windows.Forms.ListViewItem("Service process");
        System.Windows.Forms.ListViewItem ListViewItem8 = new System.Windows.Forms.ListViewItem("Owned process");
        System.Windows.Forms.ListViewItem ListViewItem9 = new System.Windows.Forms.ListViewItem("System process");
        this.TabControl = new System.Windows.Forms.TabControl();
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.chkWintrust = new System.Windows.Forms.CheckBox();
        this.chkAutoOnline = new System.Windows.Forms.CheckBox();
        this.cmdResetAll = new System.Windows.Forms.Button();
        this.chkWarn = new System.Windows.Forms.CheckBox();
        this.txtSearchEngine = new System.Windows.Forms.TextBox();
        this.Label6 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.cmdChangeTaskmgr = new System.Windows.Forms.Button();
        this.chkTopMost = new System.Windows.Forms.CheckBox();
        this.chkStartTray = new System.Windows.Forms.CheckBox();
        this.chkReplaceTaskmgr = new System.Windows.Forms.CheckBox();
        this.chkStart = new System.Windows.Forms.CheckBox();
        this.TabPage5 = new System.Windows.Forms.TabPage();
        this.cmdMoveDownProcess = new System.Windows.Forms.Button();
        this.cmdMoveUpProcess = new System.Windows.Forms.Button();
        this.lvHighlightingOther = new System.Windows.Forms.ListView();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.lvHighlightingProcess = new System.Windows.Forms.ListView();
        this.Header = new System.Windows.Forms.ColumnHeader();
        this.TabPage3 = new System.Windows.Forms.TabPage();
        this.chkRemember = new System.Windows.Forms.CheckBox();
        this.chkClassicMsgbox = new System.Windows.Forms.CheckBox();
        this.cbShownTab = new System.Windows.Forms.ComboBox();
        this.chkFixedTab = new System.Windows.Forms.CheckBox();
        this.chkStatusBar = new System.Windows.Forms.CheckBox();
        this.chkUserGroup = new System.Windows.Forms.CheckBox();
        this.chkHideClosed = new System.Windows.Forms.CheckBox();
        this.chkHideMinimized = new System.Windows.Forms.CheckBox();
        this.chkRibbon = new System.Windows.Forms.CheckBox();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.pctDeletedItems = new System.Windows.Forms.PictureBox();
        this.Label8 = new System.Windows.Forms.Label();
        this.pctNewitems = new System.Windows.Forms.PictureBox();
        this.Label7 = new System.Windows.Forms.Label();
        this.chkTrayIcon = new System.Windows.Forms.CheckBox();
        this.TabPage4 = new System.Windows.Forms.TabPage();
        this.chkUnlimitedBuf = new System.Windows.Forms.CheckBox();
        this.bufferSize = new System.Windows.Forms.NumericUpDown();
        this.Label11 = new System.Windows.Forms.Label();
        this.cbPriority = new System.Windows.Forms.ComboBox();
        this.Label5 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.valCoefRemote = new System.Windows.Forms.NumericUpDown();
        this.Label14 = new System.Windows.Forms.Label();
        this.txtJobInterval = new System.Windows.Forms.NumericUpDown();
        this.Label12 = new System.Windows.Forms.Label();
        this.txtSysInfoInterval = new System.Windows.Forms.NumericUpDown();
        this.txtTrayInterval = new System.Windows.Forms.NumericUpDown();
        this.txtNetworkInterval = new System.Windows.Forms.NumericUpDown();
        this.txtTaskInterval = new System.Windows.Forms.NumericUpDown();
        this.txtServiceIntervall = new System.Windows.Forms.NumericUpDown();
        this.txtProcessIntervall = new System.Windows.Forms.NumericUpDown();
        this.Label9 = new System.Windows.Forms.Label();
        this.Label10 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.TabPage2 = new System.Windows.Forms.TabPage();
        this.cmdUpdateCheckNow = new System.Windows.Forms.Button();
        this.txtUpdateServer = new System.Windows.Forms.TextBox();
        this.Label13 = new System.Windows.Forms.Label();
        this.chkUpdateAuto = new System.Windows.Forms.CheckBox();
        this.chkUpdateAlpha = new System.Windows.Forms.CheckBox();
        this.chkUpdateBeta = new System.Windows.Forms.CheckBox();
        this.cmdSave = new System.Windows.Forms.Button();
        this.cmdQuit = new System.Windows.Forms.Button();
        this.cmdDefaut = new System.Windows.Forms.Button();
        this.colDial = new System.Windows.Forms.ColorDialog();
        this.TabControl.SuspendLayout();
        this.TabPage1.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.TabPage5.SuspendLayout();
        this.TabPage3.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctDeletedItems).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pctNewitems).BeginInit();
        this.TabPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.bufferSize).BeginInit();
        this.GroupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.valCoefRemote).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtJobInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtSysInfoInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtTrayInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtNetworkInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtTaskInterval).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtServiceIntervall).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.txtProcessIntervall).BeginInit();
        this.TabPage2.SuspendLayout();
        this.SuspendLayout();
        // 
        // TabControl
        // 
        this.TabControl.Controls.Add(this.TabPage1);
        this.TabControl.Controls.Add(this.TabPage5);
        this.TabControl.Controls.Add(this.TabPage3);
        this.TabControl.Controls.Add(this.TabPage4);
        this.TabControl.Controls.Add(this.TabPage2);
        this.TabControl.Location = new System.Drawing.Point(9, 9);
        this.TabControl.Name = "TabControl";
        this.TabControl.SelectedIndex = 0;
        this.TabControl.Size = new System.Drawing.Size(469, 306);
        this.TabControl.TabIndex = 0;
        // 
        // TabPage1
        // 
        this.TabPage1.Controls.Add(this.chkWintrust);
        this.TabPage1.Controls.Add(this.chkAutoOnline);
        this.TabPage1.Controls.Add(this.cmdResetAll);
        this.TabPage1.Controls.Add(this.chkWarn);
        this.TabPage1.Controls.Add(this.txtSearchEngine);
        this.TabPage1.Controls.Add(this.Label6);
        this.TabPage1.Controls.Add(this.GroupBox1);
        this.TabPage1.ImageKey = "(aucun)";
        this.TabPage1.Location = new System.Drawing.Point(4, 22);
        this.TabPage1.Name = "TabPage1";
        this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage1.Size = new System.Drawing.Size(461, 280);
        this.TabPage1.TabIndex = 0;
        this.TabPage1.Text = "General";
        this.TabPage1.UseVisualStyleBackColor = true;
        // 
        // chkWintrust
        // 
        this.chkWintrust.AutoSize = true;
        this.chkWintrust.Location = new System.Drawing.Point(14, 218);
        this.chkWintrust.Name = "chkWintrust";
        this.chkWintrust.Size = new System.Drawing.Size(179, 17);
        this.chkWintrust.TabIndex = 10;
        this.chkWintrust.Text = "Verify signatures of processes";
        this.chkWintrust.UseVisualStyleBackColor = true;
        // 
        // chkAutoOnline
        // 
        this.chkAutoOnline.AutoSize = true;
        this.chkAutoOnline.Location = new System.Drawing.Point(14, 195);
        this.chkAutoOnline.Name = "chkAutoOnline";
        this.chkAutoOnline.Size = new System.Drawing.Size(180, 17);
        this.chkAutoOnline.TabIndex = 9;
        this.chkAutoOnline.Text = "Get online infos automatically";
        this.chkAutoOnline.UseVisualStyleBackColor = true;
        // 
        // cmdResetAll
        // 
        this.cmdResetAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdResetAll.Location = new System.Drawing.Point(325, 247);
        this.cmdResetAll.Name = "cmdResetAll";
        this.cmdResetAll.Size = new System.Drawing.Size(133, 26);
        this.cmdResetAll.TabIndex = 8;
        this.cmdResetAll.Text = "Reset all settings";
        this.cmdResetAll.UseVisualStyleBackColor = true;
        // 
        // chkWarn
        // 
        this.chkWarn.AutoSize = true;
        this.chkWarn.Location = new System.Drawing.Point(14, 172);
        this.chkWarn.Name = "chkWarn";
        this.chkWarn.Size = new System.Drawing.Size(187, 17);
        this.chkWarn.TabIndex = 5;
        this.chkWarn.Text = "Warn about dangerous actions";
        this.chkWarn.UseVisualStyleBackColor = true;
        // 
        // txtSearchEngine
        // 
        this.txtSearchEngine.Location = new System.Drawing.Point(97, 144);
        this.txtSearchEngine.Name = "txtSearchEngine";
        this.txtSearchEngine.Size = new System.Drawing.Size(346, 22);
        this.txtSearchEngine.TabIndex = 4;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(11, 147);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(80, 13);
        this.Label6.TabIndex = 1;
        this.Label6.Text = "Search engine";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.cmdChangeTaskmgr);
        this.GroupBox1.Controls.Add(this.chkTopMost);
        this.GroupBox1.Controls.Add(this.chkStartTray);
        this.GroupBox1.Controls.Add(this.chkReplaceTaskmgr);
        this.GroupBox1.Controls.Add(this.chkStart);
        this.GroupBox1.Location = new System.Drawing.Point(14, 12);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(429, 120);
        this.GroupBox1.TabIndex = 0;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Startup";
        // 
        // cmdChangeTaskmgr
        // 
        this.cmdChangeTaskmgr.Location = new System.Drawing.Point(125, 39);
        this.cmdChangeTaskmgr.Name = "cmdChangeTaskmgr";
        this.cmdChangeTaskmgr.Size = new System.Drawing.Size(91, 26);
        this.cmdChangeTaskmgr.TabIndex = 9;
        this.cmdChangeTaskmgr.Text = "Change...";
        this.cmdChangeTaskmgr.UseVisualStyleBackColor = true;
        this.cmdChangeTaskmgr.Visible = false;
        // 
        // chkTopMost
        // 
        this.chkTopMost.AutoSize = true;
        this.chkTopMost.Location = new System.Drawing.Point(9, 91);
        this.chkTopMost.Name = "chkTopMost";
        this.chkTopMost.Size = new System.Drawing.Size(127, 17);
        this.chkTopMost.TabIndex = 3;
        this.chkTopMost.Text = "Start YAPM topmost";
        this.chkTopMost.UseVisualStyleBackColor = true;
        // 
        // chkStartTray
        // 
        this.chkStartTray.AutoSize = true;
        this.chkStartTray.Location = new System.Drawing.Point(9, 68);
        this.chkStartTray.Name = "chkStartTray";
        this.chkStartTray.Size = new System.Drawing.Size(121, 17);
        this.chkStartTray.TabIndex = 2;
        this.chkStartTray.Text = "Start YAPM hidden";
        this.chkStartTray.UseVisualStyleBackColor = true;
        // 
        // chkReplaceTaskmgr
        // 
        this.chkReplaceTaskmgr.AutoSize = true;
        this.chkReplaceTaskmgr.Location = new System.Drawing.Point(9, 45);
        this.chkReplaceTaskmgr.Name = "chkReplaceTaskmgr";
        this.chkReplaceTaskmgr.Size = new System.Drawing.Size(110, 17);
        this.chkReplaceTaskmgr.TabIndex = 1;
        this.chkReplaceTaskmgr.Text = "Replace taskmgr";
        this.chkReplaceTaskmgr.UseVisualStyleBackColor = true;
        // 
        // chkStart
        // 
        this.chkStart.AutoSize = true;
        this.chkStart.Location = new System.Drawing.Point(9, 22);
        this.chkStart.Name = "chkStart";
        this.chkStart.Size = new System.Drawing.Size(190, 17);
        this.chkStart.TabIndex = 0;
        this.chkStart.Text = "Start YAPM on Windows startup";
        this.chkStart.UseVisualStyleBackColor = true;
        // 
        // TabPage5
        // 
        this.TabPage5.Controls.Add(this.cmdMoveDownProcess);
        this.TabPage5.Controls.Add(this.cmdMoveUpProcess);
        this.TabPage5.Controls.Add(this.lvHighlightingOther);
        this.TabPage5.Controls.Add(this.lvHighlightingProcess);
        this.TabPage5.ImageKey = "(aucun)";
        this.TabPage5.Location = new System.Drawing.Point(4, 22);
        this.TabPage5.Name = "TabPage5";
        this.TabPage5.Size = new System.Drawing.Size(461, 280);
        this.TabPage5.TabIndex = 4;
        this.TabPage5.Text = "Highlighting";
        this.TabPage5.UseVisualStyleBackColor = true;
        // 
        // cmdMoveDownProcess
        // 
        this.cmdMoveDownProcess.Enabled = false;
        this.cmdMoveDownProcess.Image = global::My.Resources.Resources.down16;
        this.cmdMoveDownProcess.Location = new System.Drawing.Point(41, 237);
        this.cmdMoveDownProcess.Name = "cmdMoveDownProcess";
        this.cmdMoveDownProcess.Size = new System.Drawing.Size(28, 28);
        this.cmdMoveDownProcess.TabIndex = 11;
        this.cmdMoveDownProcess.UseVisualStyleBackColor = true;
        // 
        // cmdMoveUpProcess
        // 
        this.cmdMoveUpProcess.Enabled = false;
        this.cmdMoveUpProcess.Image = global::My.Resources.Resources.up16;
        this.cmdMoveUpProcess.Location = new System.Drawing.Point(7, 237);
        this.cmdMoveUpProcess.Name = "cmdMoveUpProcess";
        this.cmdMoveUpProcess.Size = new System.Drawing.Size(28, 28);
        this.cmdMoveUpProcess.TabIndex = 10;
        this.cmdMoveUpProcess.UseVisualStyleBackColor = true;
        // 
        // lvHighlightingOther
        // 
        this.lvHighlightingOther.CheckBoxes = true;
        this.lvHighlightingOther.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1 });
        this.lvHighlightingOther.FullRowSelect = true;
        this.lvHighlightingOther.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        ListViewItem1.StateImageIndex = 0;
        ListViewItem2.StateImageIndex = 0;
        this.lvHighlightingOther.Items.AddRange(new System.Windows.Forms.ListViewItem[] { ListViewItem1, ListViewItem2 });
        this.lvHighlightingOther.Location = new System.Drawing.Point(229, 3);
        this.lvHighlightingOther.MultiSelect = false;
        this.lvHighlightingOther.Name = "lvHighlightingOther";
        this.lvHighlightingOther.Size = new System.Drawing.Size(220, 228);
        this.lvHighlightingOther.TabIndex = 1;
        this.lvHighlightingOther.UseCompatibleStateImageBehavior = false;
        this.lvHighlightingOther.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Width = 200;
        // 
        // lvHighlightingProcess
        // 
        this.lvHighlightingProcess.CheckBoxes = true;
        this.lvHighlightingProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.Header });
        this.lvHighlightingProcess.FullRowSelect = true;
        this.lvHighlightingProcess.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        ListViewItem3.StateImageIndex = 0;
        ListViewItem4.StateImageIndex = 0;
        ListViewItem5.StateImageIndex = 0;
        ListViewItem6.StateImageIndex = 0;
        ListViewItem7.StateImageIndex = 0;
        ListViewItem8.StateImageIndex = 0;
        ListViewItem9.StateImageIndex = 0;
        this.lvHighlightingProcess.Items.AddRange(new System.Windows.Forms.ListViewItem[] { ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9 });
        this.lvHighlightingProcess.Location = new System.Drawing.Point(3, 3);
        this.lvHighlightingProcess.MultiSelect = false;
        this.lvHighlightingProcess.Name = "lvHighlightingProcess";
        this.lvHighlightingProcess.Size = new System.Drawing.Size(220, 228);
        this.lvHighlightingProcess.TabIndex = 0;
        this.lvHighlightingProcess.UseCompatibleStateImageBehavior = false;
        this.lvHighlightingProcess.View = System.Windows.Forms.View.Details;
        // 
        // Header
        // 
        this.Header.Width = 200;
        // 
        // TabPage3
        // 
        this.TabPage3.Controls.Add(this.chkRemember);
        this.TabPage3.Controls.Add(this.chkClassicMsgbox);
        this.TabPage3.Controls.Add(this.cbShownTab);
        this.TabPage3.Controls.Add(this.chkFixedTab);
        this.TabPage3.Controls.Add(this.chkStatusBar);
        this.TabPage3.Controls.Add(this.chkUserGroup);
        this.TabPage3.Controls.Add(this.chkHideClosed);
        this.TabPage3.Controls.Add(this.chkHideMinimized);
        this.TabPage3.Controls.Add(this.chkRibbon);
        this.TabPage3.Controls.Add(this.GroupBox3);
        this.TabPage3.Controls.Add(this.chkTrayIcon);
        this.TabPage3.ImageKey = "(aucun)";
        this.TabPage3.Location = new System.Drawing.Point(4, 22);
        this.TabPage3.Name = "TabPage3";
        this.TabPage3.Size = new System.Drawing.Size(461, 280);
        this.TabPage3.TabIndex = 2;
        this.TabPage3.Text = "Display";
        this.TabPage3.UseVisualStyleBackColor = true;
        // 
        // chkRemember
        // 
        this.chkRemember.AutoSize = true;
        this.chkRemember.Location = new System.Drawing.Point(15, 240);
        this.chkRemember.Name = "chkRemember";
        this.chkRemember.Size = new System.Drawing.Size(181, 17);
        this.chkRemember.TabIndex = 15;
        this.chkRemember.Text = "Remember positions and sizes";
        this.chkRemember.UseVisualStyleBackColor = true;
        // 
        // chkClassicMsgbox
        // 
        this.chkClassicMsgbox.AutoSize = true;
        this.chkClassicMsgbox.Location = new System.Drawing.Point(181, 148);
        this.chkClassicMsgbox.Name = "chkClassicMsgbox";
        this.chkClassicMsgbox.Size = new System.Drawing.Size(167, 17);
        this.chkClassicMsgbox.TabIndex = 14;
        this.chkClassicMsgbox.Text = "Show classic messageboxes";
        this.chkClassicMsgbox.UseVisualStyleBackColor = true;
        // 
        // cbShownTab
        // 
        this.cbShownTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbShownTab.FormattingEnabled = true;
        this.cbShownTab.Location = new System.Drawing.Point(293, 123);
        this.cbShownTab.Name = "cbShownTab";
        this.cbShownTab.Size = new System.Drawing.Size(150, 21);
        this.cbShownTab.TabIndex = 13;
        // 
        // chkFixedTab
        // 
        this.chkFixedTab.AutoSize = true;
        this.chkFixedTab.Location = new System.Drawing.Point(182, 125);
        this.chkFixedTab.Name = "chkFixedTab";
        this.chkFixedTab.Size = new System.Drawing.Size(105, 17);
        this.chkFixedTab.TabIndex = 12;
        this.chkFixedTab.Text = "Tab shown first";
        this.chkFixedTab.UseVisualStyleBackColor = true;
        // 
        // chkStatusBar
        // 
        this.chkStatusBar.AutoSize = true;
        this.chkStatusBar.Location = new System.Drawing.Point(15, 217);
        this.chkStatusBar.Name = "chkStatusBar";
        this.chkStatusBar.Size = new System.Drawing.Size(106, 17);
        this.chkStatusBar.TabIndex = 11;
        this.chkStatusBar.Text = "Show statusbar";
        this.chkStatusBar.UseVisualStyleBackColor = true;
        // 
        // chkUserGroup
        // 
        this.chkUserGroup.AutoSize = true;
        this.chkUserGroup.Location = new System.Drawing.Point(15, 194);
        this.chkUserGroup.Name = "chkUserGroup";
        this.chkUserGroup.Size = new System.Drawing.Size(158, 17);
        this.chkUserGroup.TabIndex = 10;
        this.chkUserGroup.Text = "Show user group/domain";
        this.chkUserGroup.UseVisualStyleBackColor = true;
        // 
        // chkHideClosed
        // 
        this.chkHideClosed.AutoSize = true;
        this.chkHideClosed.Location = new System.Drawing.Point(15, 171);
        this.chkHideClosed.Name = "chkHideClosed";
        this.chkHideClosed.Size = new System.Drawing.Size(118, 17);
        this.chkHideClosed.TabIndex = 9;
        this.chkHideClosed.Text = "Hide when closed";
        this.chkHideClosed.UseVisualStyleBackColor = true;
        // 
        // chkHideMinimized
        // 
        this.chkHideMinimized.AutoSize = true;
        this.chkHideMinimized.Location = new System.Drawing.Point(15, 148);
        this.chkHideMinimized.Name = "chkHideMinimized";
        this.chkHideMinimized.Size = new System.Drawing.Size(137, 17);
        this.chkHideMinimized.TabIndex = 3;
        this.chkHideMinimized.Text = "Hide when minimized";
        this.chkHideMinimized.UseVisualStyleBackColor = true;
        // 
        // chkRibbon
        // 
        this.chkRibbon.AutoSize = true;
        this.chkRibbon.Location = new System.Drawing.Point(15, 125);
        this.chkRibbon.Name = "chkRibbon";
        this.chkRibbon.Size = new System.Drawing.Size(127, 17);
        this.chkRibbon.TabIndex = 2;
        this.chkRibbon.Text = "Ribbon style menus";
        this.chkRibbon.UseVisualStyleBackColor = true;
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.pctDeletedItems);
        this.GroupBox3.Controls.Add(this.Label8);
        this.GroupBox3.Controls.Add(this.pctNewitems);
        this.GroupBox3.Controls.Add(this.Label7);
        this.GroupBox3.Location = new System.Drawing.Point(15, 37);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(428, 77);
        this.GroupBox3.TabIndex = 8;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Colors";
        // 
        // pctDeletedItems
        // 
        this.pctDeletedItems.Location = new System.Drawing.Point(86, 46);
        this.pctDeletedItems.Name = "pctDeletedItems";
        this.pctDeletedItems.Size = new System.Drawing.Size(16, 16);
        this.pctDeletedItems.TabIndex = 3;
        this.pctDeletedItems.TabStop = false;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(6, 48);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(77, 13);
        this.Label8.TabIndex = 2;
        this.Label8.Text = "Deleted items";
        // 
        // pctNewitems
        // 
        this.pctNewitems.Location = new System.Drawing.Point(86, 21);
        this.pctNewitems.Name = "pctNewitems";
        this.pctNewitems.Size = new System.Drawing.Size(16, 16);
        this.pctNewitems.TabIndex = 1;
        this.pctNewitems.TabStop = false;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(6, 23);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(60, 13);
        this.Label7.TabIndex = 0;
        this.Label7.Text = "New items";
        // 
        // chkTrayIcon
        // 
        this.chkTrayIcon.AutoSize = true;
        this.chkTrayIcon.Location = new System.Drawing.Point(15, 14);
        this.chkTrayIcon.Name = "chkTrayIcon";
        this.chkTrayIcon.Size = new System.Drawing.Size(102, 17);
        this.chkTrayIcon.TabIndex = 0;
        this.chkTrayIcon.Text = "Show tray icon";
        this.chkTrayIcon.UseVisualStyleBackColor = true;
        // 
        // TabPage4
        // 
        this.TabPage4.Controls.Add(this.chkUnlimitedBuf);
        this.TabPage4.Controls.Add(this.bufferSize);
        this.TabPage4.Controls.Add(this.Label11);
        this.TabPage4.Controls.Add(this.cbPriority);
        this.TabPage4.Controls.Add(this.Label5);
        this.TabPage4.Controls.Add(this.GroupBox2);
        this.TabPage4.ImageKey = "(aucun)";
        this.TabPage4.Location = new System.Drawing.Point(4, 22);
        this.TabPage4.Name = "TabPage4";
        this.TabPage4.Size = new System.Drawing.Size(461, 280);
        this.TabPage4.TabIndex = 3;
        this.TabPage4.Text = "Performances";
        this.TabPage4.UseVisualStyleBackColor = true;
        // 
        // chkUnlimitedBuf
        // 
        this.chkUnlimitedBuf.AutoSize = true;
        this.chkUnlimitedBuf.Location = new System.Drawing.Point(201, 226);
        this.chkUnlimitedBuf.Name = "chkUnlimitedBuf";
        this.chkUnlimitedBuf.Size = new System.Drawing.Size(76, 17);
        this.chkUnlimitedBuf.TabIndex = 9;
        this.chkUnlimitedBuf.Text = "Unlimited";
        this.chkUnlimitedBuf.UseVisualStyleBackColor = true;
        // 
        // bufferSize
        // 
        this.bufferSize.Location = new System.Drawing.Point(120, 224);
        this.bufferSize.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        this.bufferSize.Name = "bufferSize";
        this.bufferSize.Size = new System.Drawing.Size(75, 22);
        this.bufferSize.TabIndex = 8;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(14, 226);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(100, 13);
        this.Label11.TabIndex = 7;
        this.Label11.Text = "History buffer (KB)";
        // 
        // cbPriority
        // 
        this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbPriority.FormattingEnabled = true;
        this.cbPriority.Items.AddRange(new object[] { "Idle", "Below Normal", "Normal", "Above Normal", "High", "Real Time" });
        this.cbPriority.Location = new System.Drawing.Point(74, 191);
        this.cbPriority.Name = "cbPriority";
        this.cbPriority.Size = new System.Drawing.Size(148, 21);
        this.cbPriority.TabIndex = 6;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(14, 194);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(43, 13);
        this.Label5.TabIndex = 3;
        this.Label5.Text = "Priority";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.valCoefRemote);
        this.GroupBox2.Controls.Add(this.Label14);
        this.GroupBox2.Controls.Add(this.txtJobInterval);
        this.GroupBox2.Controls.Add(this.Label12);
        this.GroupBox2.Controls.Add(this.txtSysInfoInterval);
        this.GroupBox2.Controls.Add(this.txtTrayInterval);
        this.GroupBox2.Controls.Add(this.txtNetworkInterval);
        this.GroupBox2.Controls.Add(this.txtTaskInterval);
        this.GroupBox2.Controls.Add(this.txtServiceIntervall);
        this.GroupBox2.Controls.Add(this.txtProcessIntervall);
        this.GroupBox2.Controls.Add(this.Label9);
        this.GroupBox2.Controls.Add(this.Label10);
        this.GroupBox2.Controls.Add(this.Label3);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.Label2);
        this.GroupBox2.Controls.Add(this.Label1);
        this.GroupBox2.Location = new System.Drawing.Point(14, 14);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(428, 163);
        this.GroupBox2.TabIndex = 2;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Update intervals";
        // 
        // valCoefRemote
        // 
        this.valCoefRemote.Location = new System.Drawing.Point(367, 135);
        this.valCoefRemote.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.valCoefRemote.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
        this.valCoefRemote.Name = "valCoefRemote";
        this.valCoefRemote.Size = new System.Drawing.Size(55, 22);
        this.valCoefRemote.TabIndex = 22;
        this.valCoefRemote.Value = new decimal(new int[] { 200, 0, 0, 0 });
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(205, 138);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(156, 13);
        this.Label14.TabIndex = 21;
        this.Label14.Text = "Coeff. for remote monitoring";
        // 
        // txtJobInterval
        // 
        this.txtJobInterval.Location = new System.Drawing.Point(282, 21);
        this.txtJobInterval.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtJobInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtJobInterval.Name = "txtJobInterval";
        this.txtJobInterval.Size = new System.Drawing.Size(80, 22);
        this.txtJobInterval.TabIndex = 20;
        this.txtJobInterval.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(205, 23);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(71, 13);
        this.Label12.TabIndex = 19;
        this.Label12.Text = "Jobs interval";
        // 
        // txtSysInfoInterval
        // 
        this.txtSysInfoInterval.Location = new System.Drawing.Point(109, 136);
        this.txtSysInfoInterval.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtSysInfoInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtSysInfoInterval.Name = "txtSysInfoInterval";
        this.txtSysInfoInterval.Size = new System.Drawing.Size(80, 22);
        this.txtSysInfoInterval.TabIndex = 18;
        this.txtSysInfoInterval.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // txtTrayInterval
        // 
        this.txtTrayInterval.Location = new System.Drawing.Point(109, 113);
        this.txtTrayInterval.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtTrayInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtTrayInterval.Name = "txtTrayInterval";
        this.txtTrayInterval.Size = new System.Drawing.Size(80, 22);
        this.txtTrayInterval.TabIndex = 17;
        this.txtTrayInterval.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // txtNetworkInterval
        // 
        this.txtNetworkInterval.Location = new System.Drawing.Point(109, 90);
        this.txtNetworkInterval.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtNetworkInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtNetworkInterval.Name = "txtNetworkInterval";
        this.txtNetworkInterval.Size = new System.Drawing.Size(80, 22);
        this.txtNetworkInterval.TabIndex = 16;
        this.txtNetworkInterval.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // txtTaskInterval
        // 
        this.txtTaskInterval.Location = new System.Drawing.Point(109, 67);
        this.txtTaskInterval.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtTaskInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtTaskInterval.Name = "txtTaskInterval";
        this.txtTaskInterval.Size = new System.Drawing.Size(80, 22);
        this.txtTaskInterval.TabIndex = 15;
        this.txtTaskInterval.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // txtServiceIntervall
        // 
        this.txtServiceIntervall.Location = new System.Drawing.Point(109, 44);
        this.txtServiceIntervall.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtServiceIntervall.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtServiceIntervall.Name = "txtServiceIntervall";
        this.txtServiceIntervall.Size = new System.Drawing.Size(80, 22);
        this.txtServiceIntervall.TabIndex = 14;
        this.txtServiceIntervall.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // txtProcessIntervall
        // 
        this.txtProcessIntervall.Location = new System.Drawing.Point(109, 21);
        this.txtProcessIntervall.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
        this.txtProcessIntervall.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.txtProcessIntervall.Name = "txtProcessIntervall";
        this.txtProcessIntervall.Size = new System.Drawing.Size(80, 22);
        this.txtProcessIntervall.TabIndex = 13;
        this.txtProcessIntervall.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(6, 138);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(91, 13);
        this.Label9.TabIndex = 12;
        this.Label9.Text = "Sys. info interval";
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(6, 115);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(68, 13);
        this.Label10.TabIndex = 11;
        this.Label10.Text = "Tray interval";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(6, 92);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(92, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "Network interval";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 69);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(75, 13);
        this.Label4.TabIndex = 7;
        this.Label4.Text = "Tasks interval";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(6, 46);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(88, 13);
        this.Label2.TabIndex = 1;
        this.Label2.Text = "Services interval";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(6, 23);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(97, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Processes interval";
        // 
        // TabPage2
        // 
        this.TabPage2.Controls.Add(this.cmdUpdateCheckNow);
        this.TabPage2.Controls.Add(this.txtUpdateServer);
        this.TabPage2.Controls.Add(this.Label13);
        this.TabPage2.Controls.Add(this.chkUpdateAuto);
        this.TabPage2.Controls.Add(this.chkUpdateAlpha);
        this.TabPage2.Controls.Add(this.chkUpdateBeta);
        this.TabPage2.ImageKey = "(aucun)";
        this.TabPage2.Location = new System.Drawing.Point(4, 22);
        this.TabPage2.Name = "TabPage2";
        this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage2.Size = new System.Drawing.Size(461, 280);
        this.TabPage2.TabIndex = 1;
        this.TabPage2.Text = "Update";
        this.TabPage2.UseVisualStyleBackColor = true;
        // 
        // cmdUpdateCheckNow
        // 
        this.cmdUpdateCheckNow.Location = new System.Drawing.Point(11, 131);
        this.cmdUpdateCheckNow.Name = "cmdUpdateCheckNow";
        this.cmdUpdateCheckNow.Size = new System.Drawing.Size(108, 23);
        this.cmdUpdateCheckNow.TabIndex = 18;
        this.cmdUpdateCheckNow.Text = "Check now";
        this.cmdUpdateCheckNow.UseVisualStyleBackColor = true;
        // 
        // txtUpdateServer
        // 
        this.txtUpdateServer.Location = new System.Drawing.Point(56, 90);
        this.txtUpdateServer.Name = "txtUpdateServer";
        this.txtUpdateServer.Size = new System.Drawing.Size(345, 22);
        this.txtUpdateServer.TabIndex = 17;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(11, 93);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(38, 13);
        this.Label13.TabIndex = 16;
        this.Label13.Text = "Server";
        // 
        // chkUpdateAuto
        // 
        this.chkUpdateAuto.AutoSize = true;
        this.chkUpdateAuto.Location = new System.Drawing.Point(11, 67);
        this.chkUpdateAuto.Name = "chkUpdateAuto";
        this.chkUpdateAuto.Size = new System.Drawing.Size(219, 17);
        this.chkUpdateAuto.TabIndex = 15;
        this.chkUpdateAuto.Text = "Check if YAPM is up to date at startup";
        this.chkUpdateAuto.UseVisualStyleBackColor = true;
        // 
        // chkUpdateAlpha
        // 
        this.chkUpdateAlpha.AutoSize = true;
        this.chkUpdateAlpha.Location = new System.Drawing.Point(11, 44);
        this.chkUpdateAlpha.Name = "chkUpdateAlpha";
        this.chkUpdateAlpha.Size = new System.Drawing.Size(151, 17);
        this.chkUpdateAlpha.TabIndex = 14;
        this.chkUpdateAlpha.Text = "Check for alpha releases";
        this.chkUpdateAlpha.UseVisualStyleBackColor = true;
        // 
        // chkUpdateBeta
        // 
        this.chkUpdateBeta.AutoSize = true;
        this.chkUpdateBeta.Location = new System.Drawing.Point(11, 21);
        this.chkUpdateBeta.Name = "chkUpdateBeta";
        this.chkUpdateBeta.Size = new System.Drawing.Size(145, 17);
        this.chkUpdateBeta.TabIndex = 13;
        this.chkUpdateBeta.Text = "Check for beta releases";
        this.chkUpdateBeta.UseVisualStyleBackColor = true;
        // 
        // cmdSave
        // 
        this.cmdSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdSave.Location = new System.Drawing.Point(12, 323);
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.Size = new System.Drawing.Size(100, 26);
        this.cmdSave.TabIndex = 7;
        this.cmdSave.Text = "Save";
        this.cmdSave.UseVisualStyleBackColor = true;
        // 
        // cmdQuit
        // 
        this.cmdQuit.Location = new System.Drawing.Point(374, 323);
        this.cmdQuit.Name = "cmdQuit";
        this.cmdQuit.Size = new System.Drawing.Size(100, 26);
        this.cmdQuit.TabIndex = 9;
        this.cmdQuit.Text = "Close";
        this.cmdQuit.UseVisualStyleBackColor = true;
        // 
        // cmdDefaut
        // 
        this.cmdDefaut.Location = new System.Drawing.Point(195, 323);
        this.cmdDefaut.Name = "cmdDefaut";
        this.cmdDefaut.Size = new System.Drawing.Size(100, 26);
        this.cmdDefaut.TabIndex = 8;
        this.cmdDefaut.Text = "Default";
        this.cmdDefaut.UseVisualStyleBackColor = true;
        // 
        // colDial
        // 
        this.colDial.AnyColor = true;
        this.colDial.FullOpen = true;
        // 
        // frmPreferences
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(490, 355);
        this.ControlBox = false;
        this.Controls.Add(this.cmdDefaut);
        this.Controls.Add(this.cmdQuit);
        this.Controls.Add(this.cmdSave);
        this.Controls.Add(this.TabControl);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmPreferences";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Preferences";
        this.TabControl.ResumeLayout(false);
        this.TabPage1.ResumeLayout(false);
        this.TabPage1.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.TabPage5.ResumeLayout(false);
        this.TabPage3.ResumeLayout(false);
        this.TabPage3.PerformLayout();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctDeletedItems).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pctNewitems).EndInit();
        this.TabPage4.ResumeLayout(false);
        this.TabPage4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.bufferSize).EndInit();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.valCoefRemote).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtJobInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtSysInfoInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtTrayInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtNetworkInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtTaskInterval).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtServiceIntervall).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.txtProcessIntervall).EndInit();
        this.TabPage2.ResumeLayout(false);
        this.TabPage2.PerformLayout();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.TabControl _TabControl;

    internal System.Windows.Forms.TabControl TabControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabControl != null)
            {
            }

            _TabControl = value;
            if (_TabControl != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage1;

    internal System.Windows.Forms.TabPage TabPage1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage1 != null)
            {
            }

            _TabPage1 = value;
            if (_TabPage1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage2;

    internal System.Windows.Forms.TabPage TabPage2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage2 != null)
            {
            }

            _TabPage2 = value;
            if (_TabPage2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSave;

    internal System.Windows.Forms.Button cmdSave
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

    private System.Windows.Forms.Button _cmdQuit;

    internal System.Windows.Forms.Button cmdQuit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdQuit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdQuit != null)
            {
            }

            _cmdQuit = value;
            if (_cmdQuit != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdDefaut;

    internal System.Windows.Forms.Button cmdDefaut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdDefaut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdDefaut != null)
            {
            }

            _cmdDefaut = value;
            if (_cmdDefaut != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox1;

    internal System.Windows.Forms.GroupBox GroupBox1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox1 != null)
            {
            }

            _GroupBox1 = value;
            if (_GroupBox1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkReplaceTaskmgr;

    internal System.Windows.Forms.CheckBox chkReplaceTaskmgr
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkReplaceTaskmgr;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkReplaceTaskmgr != null)
            {
            }

            _chkReplaceTaskmgr = value;
            if (_chkReplaceTaskmgr != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkStart;

    internal System.Windows.Forms.CheckBox chkStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkStart != null)
            {
            }

            _chkStart = value;
            if (_chkStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkStartTray;

    internal System.Windows.Forms.CheckBox chkStartTray
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkStartTray;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkStartTray != null)
            {
            }

            _chkStartTray = value;
            if (_chkStartTray != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkTopMost;

    internal System.Windows.Forms.CheckBox chkTopMost
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkTopMost;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkTopMost != null)
            {
            }

            _chkTopMost = value;
            if (_chkTopMost != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage3;

    internal System.Windows.Forms.TabPage TabPage3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage3 != null)
            {
            }

            _TabPage3 = value;
            if (_TabPage3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage4;

    internal System.Windows.Forms.TabPage TabPage4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage4 != null)
            {
            }

            _TabPage4 = value;
            if (_TabPage4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label5;

    internal System.Windows.Forms.Label Label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label5 != null)
            {
            }

            _Label5 = value;
            if (_Label5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox2;

    internal System.Windows.Forms.GroupBox GroupBox2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox2 != null)
            {
            }

            _GroupBox2 = value;
            if (_GroupBox2 != null)
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

    private System.Windows.Forms.Label _Label4;

    internal System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label4 != null)
            {
            }

            _Label4 = value;
            if (_Label4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label2;

    internal System.Windows.Forms.Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label2 != null)
            {
            }

            _Label2 = value;
            if (_Label2 != null)
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

    private System.Windows.Forms.ComboBox _cbPriority;

    internal System.Windows.Forms.ComboBox cbPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbPriority != null)
            {
            }

            _cbPriority = value;
            if (_cbPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtSearchEngine;

    internal System.Windows.Forms.TextBox txtSearchEngine
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSearchEngine;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSearchEngine != null)
            {
            }

            _txtSearchEngine = value;
            if (_txtSearchEngine != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label6;

    internal System.Windows.Forms.Label Label6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label6 != null)
            {
            }

            _Label6 = value;
            if (_Label6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkWarn;

    internal System.Windows.Forms.CheckBox chkWarn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkWarn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkWarn != null)
            {
            }

            _chkWarn = value;
            if (_chkWarn != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox3;

    internal System.Windows.Forms.GroupBox GroupBox3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox3 != null)
            {
            }

            _GroupBox3 = value;
            if (_GroupBox3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label7;

    internal System.Windows.Forms.Label Label7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label7 != null)
            {
            }

            _Label7 = value;
            if (_Label7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkTrayIcon;

    internal System.Windows.Forms.CheckBox chkTrayIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkTrayIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkTrayIcon != null)
            {
            }

            _chkTrayIcon = value;
            if (_chkTrayIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctDeletedItems;

    internal System.Windows.Forms.PictureBox pctDeletedItems
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctDeletedItems;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctDeletedItems != null)
            {
            }

            _pctDeletedItems = value;
            if (_pctDeletedItems != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label8;

    internal System.Windows.Forms.Label Label8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label8 != null)
            {
            }

            _Label8 = value;
            if (_Label8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctNewitems;

    internal System.Windows.Forms.PictureBox pctNewitems
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctNewitems;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctNewitems != null)
            {
            }

            _pctNewitems = value;
            if (_pctNewitems != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkRibbon;

    internal System.Windows.Forms.CheckBox chkRibbon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkRibbon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkRibbon != null)
            {
            }

            _chkRibbon = value;
            if (_chkRibbon != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColorDialog _colDial;

    internal System.Windows.Forms.ColorDialog colDial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _colDial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_colDial != null)
            {
            }

            _colDial = value;
            if (_colDial != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkHideMinimized;

    internal System.Windows.Forms.CheckBox chkHideMinimized
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkHideMinimized;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkHideMinimized != null)
            {
            }

            _chkHideMinimized = value;
            if (_chkHideMinimized != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label9;

    internal System.Windows.Forms.Label Label9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label9 != null)
            {
            }

            _Label9 = value;
            if (_Label9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label10;

    internal System.Windows.Forms.Label Label10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label10 != null)
            {
            }

            _Label10 = value;
            if (_Label10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkHideClosed;

    internal System.Windows.Forms.CheckBox chkHideClosed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkHideClosed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkHideClosed != null)
            {
            }

            _chkHideClosed = value;
            if (_chkHideClosed != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label11;

    internal System.Windows.Forms.Label Label11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label11 != null)
            {
            }

            _Label11 = value;
            if (_Label11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUnlimitedBuf;

    internal System.Windows.Forms.CheckBox chkUnlimitedBuf
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUnlimitedBuf;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUnlimitedBuf != null)
            {
            }

            _chkUnlimitedBuf = value;
            if (_chkUnlimitedBuf != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _bufferSize;

    internal System.Windows.Forms.NumericUpDown bufferSize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _bufferSize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_bufferSize != null)
            {
            }

            _bufferSize = value;
            if (_bufferSize != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdResetAll;

    internal System.Windows.Forms.Button cmdResetAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdResetAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdResetAll != null)
            {
            }

            _cmdResetAll = value;
            if (_cmdResetAll != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkAutoOnline;

    internal System.Windows.Forms.CheckBox chkAutoOnline
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkAutoOnline;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkAutoOnline != null)
            {
            }

            _chkAutoOnline = value;
            if (_chkAutoOnline != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage5;

    internal System.Windows.Forms.TabPage TabPage5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage5 != null)
            {
            }

            _TabPage5 = value;
            if (_TabPage5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ListView _lvHighlightingProcess;

    internal System.Windows.Forms.ListView lvHighlightingProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvHighlightingProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvHighlightingProcess != null)
            {
            }

            _lvHighlightingProcess = value;
            if (_lvHighlightingProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _Header;

    internal System.Windows.Forms.ColumnHeader Header
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Header;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Header != null)
            {
            }

            _Header = value;
            if (_Header != null)
            {
            }
        }
    }

    private System.Windows.Forms.ListView _lvHighlightingOther;

    internal System.Windows.Forms.ListView lvHighlightingOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvHighlightingOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvHighlightingOther != null)
            {
            }

            _lvHighlightingOther = value;
            if (_lvHighlightingOther != null)
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

    private System.Windows.Forms.Button _cmdMoveDownProcess;

    internal System.Windows.Forms.Button cmdMoveDownProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdMoveDownProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdMoveDownProcess != null)
            {
            }

            _cmdMoveDownProcess = value;
            if (_cmdMoveDownProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdMoveUpProcess;

    internal System.Windows.Forms.Button cmdMoveUpProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdMoveUpProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdMoveUpProcess != null)
            {
            }

            _cmdMoveUpProcess = value;
            if (_cmdMoveUpProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUserGroup;

    internal System.Windows.Forms.CheckBox chkUserGroup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUserGroup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUserGroup != null)
            {
            }

            _chkUserGroup = value;
            if (_chkUserGroup != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkStatusBar;

    internal System.Windows.Forms.CheckBox chkStatusBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkStatusBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkStatusBar != null)
            {
            }

            _chkStatusBar = value;
            if (_chkStatusBar != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdChangeTaskmgr;

    internal System.Windows.Forms.Button cmdChangeTaskmgr
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdChangeTaskmgr;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdChangeTaskmgr != null)
            {
            }

            _cmdChangeTaskmgr = value;
            if (_cmdChangeTaskmgr != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtSysInfoInterval;

    internal System.Windows.Forms.NumericUpDown txtSysInfoInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtSysInfoInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtSysInfoInterval != null)
            {
            }

            _txtSysInfoInterval = value;
            if (_txtSysInfoInterval != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtTrayInterval;

    internal System.Windows.Forms.NumericUpDown txtTrayInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtTrayInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtTrayInterval != null)
            {
            }

            _txtTrayInterval = value;
            if (_txtTrayInterval != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtNetworkInterval;

    internal System.Windows.Forms.NumericUpDown txtNetworkInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtNetworkInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtNetworkInterval != null)
            {
            }

            _txtNetworkInterval = value;
            if (_txtNetworkInterval != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtTaskInterval;

    internal System.Windows.Forms.NumericUpDown txtTaskInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtTaskInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtTaskInterval != null)
            {
            }

            _txtTaskInterval = value;
            if (_txtTaskInterval != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtServiceIntervall;

    internal System.Windows.Forms.NumericUpDown txtServiceIntervall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceIntervall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceIntervall != null)
            {
            }

            _txtServiceIntervall = value;
            if (_txtServiceIntervall != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtProcessIntervall;

    internal System.Windows.Forms.NumericUpDown txtProcessIntervall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessIntervall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessIntervall != null)
            {
            }

            _txtProcessIntervall = value;
            if (_txtProcessIntervall != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _txtJobInterval;

    internal System.Windows.Forms.NumericUpDown txtJobInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtJobInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtJobInterval != null)
            {
            }

            _txtJobInterval = value;
            if (_txtJobInterval != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label12;

    internal System.Windows.Forms.Label Label12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label12 != null)
            {
            }

            _Label12 = value;
            if (_Label12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkWintrust;

    internal System.Windows.Forms.CheckBox chkWintrust
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkWintrust;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkWintrust != null)
            {
            }

            _chkWintrust = value;
            if (_chkWintrust != null)
            {
            }
        }
    }

    private System.Windows.Forms.ComboBox _cbShownTab;

    internal System.Windows.Forms.ComboBox cbShownTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbShownTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbShownTab != null)
            {
            }

            _cbShownTab = value;
            if (_cbShownTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkFixedTab;

    internal System.Windows.Forms.CheckBox chkFixedTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkFixedTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkFixedTab != null)
            {
            }

            _chkFixedTab = value;
            if (_chkFixedTab != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUpdateAuto;

    internal System.Windows.Forms.CheckBox chkUpdateAuto
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUpdateAuto;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUpdateAuto != null)
            {
            }

            _chkUpdateAuto = value;
            if (_chkUpdateAuto != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUpdateAlpha;

    internal System.Windows.Forms.CheckBox chkUpdateAlpha
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUpdateAlpha;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUpdateAlpha != null)
            {
            }

            _chkUpdateAlpha = value;
            if (_chkUpdateAlpha != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUpdateBeta;

    internal System.Windows.Forms.CheckBox chkUpdateBeta
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUpdateBeta;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUpdateBeta != null)
            {
            }

            _chkUpdateBeta = value;
            if (_chkUpdateBeta != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdUpdateCheckNow;

    internal System.Windows.Forms.Button cmdUpdateCheckNow
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdUpdateCheckNow;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdUpdateCheckNow != null)
            {
            }

            _cmdUpdateCheckNow = value;
            if (_cmdUpdateCheckNow != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtUpdateServer;

    internal System.Windows.Forms.TextBox txtUpdateServer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtUpdateServer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtUpdateServer != null)
            {
            }

            _txtUpdateServer = value;
            if (_txtUpdateServer != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label13;

    internal System.Windows.Forms.Label Label13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label13 != null)
            {
            }

            _Label13 = value;
            if (_Label13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkClassicMsgbox;

    internal System.Windows.Forms.CheckBox chkClassicMsgbox
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkClassicMsgbox;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkClassicMsgbox != null)
            {
            }

            _chkClassicMsgbox = value;
            if (_chkClassicMsgbox != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valCoefRemote;

    internal System.Windows.Forms.NumericUpDown valCoefRemote
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valCoefRemote;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valCoefRemote != null)
            {
            }

            _valCoefRemote = value;
            if (_valCoefRemote != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label14;

    internal System.Windows.Forms.Label Label14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label14 != null)
            {
            }

            _Label14 = value;
            if (_Label14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkRemember;

    internal System.Windows.Forms.CheckBox chkRemember
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkRemember;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkRemember != null)
            {
            }

            _chkRemember = value;
            if (_chkRemember != null)
            {
            }
        }
    }
}

