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
partial class frmServiceInfo : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceInfo));
        cConnection CConnection2 = new cConnection();
        this.tabProcess = new System.Windows.Forms.TabControl();
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.GroupBox7 = new System.Windows.Forms.GroupBox();
        this.cmdDelete = new System.Windows.Forms.Button();
        this.cmdResume = new System.Windows.Forms.Button();
        this.Label2 = new System.Windows.Forms.Label();
        this.cbStart = new System.Windows.Forms.ComboBox();
        this.cmdSetStartType = new System.Windows.Forms.Button();
        this.cmdStop = new System.Windows.Forms.Button();
        this.cmdPause = new System.Windows.Forms.Button();
        this.cmdStart = new System.Windows.Forms.Button();
        this.GroupBox6 = new System.Windows.Forms.GroupBox();
        this.SplitContainerOnlineInfo = new System.Windows.Forms.SplitContainer();
        this.lblSecurityRisk = new System.Windows.Forms.Label();
        this.cmdGetOnlineInfos = new System.Windows.Forms.Button();
        this.rtbOnlineInfos = new System.Windows.Forms.RichTextBox();
        this.gpProcGeneralFile = new System.Windows.Forms.GroupBox();
        this.cmdInspectExe = new System.Windows.Forms.Button();
        this.cmdShowFileDetails = new System.Windows.Forms.Button();
        this.cmdShowFileProperties = new System.Windows.Forms.Button();
        this.cmdOpenDirectory = new System.Windows.Forms.Button();
        this.txtServicePath = new System.Windows.Forms.TextBox();
        this.Label13 = new System.Windows.Forms.Label();
        this.txtImageVersion = new System.Windows.Forms.TextBox();
        this.Label12 = new System.Windows.Forms.Label();
        this.lblCopyright = new System.Windows.Forms.Label();
        this.lblDescription = new System.Windows.Forms.Label();
        this.pctSmallIcon = new System.Windows.Forms.PictureBox();
        this.pctBigIcon = new System.Windows.Forms.PictureBox();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.txtCommand = new System.Windows.Forms.TextBox();
        this.Label22 = new System.Windows.Forms.Label();
        this.cmdGoProcess = new System.Windows.Forms.Button();
        this.txtName = new System.Windows.Forms.TextBox();
        this.Label15 = new System.Windows.Forms.Label();
        this.txtProcess = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtStartType = new System.Windows.Forms.TextBox();
        this.Label17 = new System.Windows.Forms.Label();
        this.txtType = new System.Windows.Forms.TextBox();
        this.Label16 = new System.Windows.Forms.Label();
        this.txtState = new System.Windows.Forms.TextBox();
        this.Label14 = new System.Windows.Forms.Label();
        this.TabPage2 = new System.Windows.Forms.TabPage();
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.txtServiceSpecificExitCode = new System.Windows.Forms.TextBox();
        this.Label10 = new System.Windows.Forms.Label();
        this.txtDiagnosticMessageFile = new System.Windows.Forms.TextBox();
        this.Label11 = new System.Windows.Forms.Label();
        this.txtCheckPoint = new System.Windows.Forms.TextBox();
        this.Label18 = new System.Windows.Forms.Label();
        this.txtWaitHint = new System.Windows.Forms.TextBox();
        this.Label19 = new System.Windows.Forms.Label();
        this.txtServiceFlags = new System.Windows.Forms.TextBox();
        this.Label20 = new System.Windows.Forms.Label();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.rtbDescription = new System.Windows.Forms.RichTextBox();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.txtTagID = new System.Windows.Forms.TextBox();
        this.Label8 = new System.Windows.Forms.Label();
        this.txtObjectName = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.txtWin32ExitCode = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.txtServiceStartName = new System.Windows.Forms.TextBox();
        this.Label5 = new System.Windows.Forms.Label();
        this.txtLoadOrderGroup = new System.Windows.Forms.TextBox();
        this.Label6 = new System.Windows.Forms.Label();
        this.txtErrorControl = new System.Windows.Forms.TextBox();
        this.Label7 = new System.Windows.Forms.Label();
        this.tabDep = new System.Windows.Forms.TabPage();
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.Label9 = new System.Windows.Forms.Label();
        this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
        this.tv2 = new serviceDependenciesList();
        this.cmdServDet1 = new System.Windows.Forms.Button();
        this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
        this.Label21 = new System.Windows.Forms.Label();
        this.SplitContainer4 = new System.Windows.Forms.SplitContainer();
        this.tv = new serviceDependenciesList();
        this.cmdServDet2 = new System.Windows.Forms.Button();
        this.TabPage6 = new System.Windows.Forms.TabPage();
        this.SplitContainerInfoProcess = new System.Windows.Forms.SplitContainer();
        this.cmdRefresh = new System.Windows.Forms.Button();
        this.cmdInfosToClipB = new System.Windows.Forms.Button();
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.menuCopyPctbig = new System.Windows.Forms.ContextMenu();
        this.MenuItemCopyBig = new System.Windows.Forms.MenuItem();
        this.MenuItemCopySmall = new System.Windows.Forms.MenuItem();
        this.menuCopyPctSmall = new System.Windows.Forms.ContextMenu();
        this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
        this.MenuItem3 = new System.Windows.Forms.MenuItem();
        this.MenuItem4 = new System.Windows.Forms.MenuItem();
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.tabProcess.SuspendLayout();
        this.TabPage1.SuspendLayout();
        this.GroupBox7.SuspendLayout();
        this.GroupBox6.SuspendLayout();
        this.SplitContainerOnlineInfo.Panel1.SuspendLayout();
        this.SplitContainerOnlineInfo.Panel2.SuspendLayout();
        this.SplitContainerOnlineInfo.SuspendLayout();
        this.gpProcGeneralFile.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctSmallIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pctBigIcon).BeginInit();
        this.GroupBox1.SuspendLayout();
        this.TabPage2.SuspendLayout();
        this.GroupBox4.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.tabDep.SuspendLayout();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.SplitContainer2.Panel1.SuspendLayout();
        this.SplitContainer2.Panel2.SuspendLayout();
        this.SplitContainer2.SuspendLayout();
        this.SplitContainer3.Panel1.SuspendLayout();
        this.SplitContainer3.Panel2.SuspendLayout();
        this.SplitContainer3.SuspendLayout();
        this.SplitContainer4.Panel1.SuspendLayout();
        this.SplitContainer4.Panel2.SuspendLayout();
        this.SplitContainer4.SuspendLayout();
        this.TabPage6.SuspendLayout();
        this.SplitContainerInfoProcess.Panel1.SuspendLayout();
        this.SplitContainerInfoProcess.Panel2.SuspendLayout();
        this.SplitContainerInfoProcess.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // tabProcess
        // 
        this.tabProcess.Controls.Add(this.TabPage1);
        this.tabProcess.Controls.Add(this.TabPage2);
        this.tabProcess.Controls.Add(this.tabDep);
        this.tabProcess.Controls.Add(this.TabPage6);
        this.tabProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tabProcess.Location = new System.Drawing.Point(0, 0);
        this.tabProcess.Multiline = true;
        this.tabProcess.Name = "tabProcess";
        this.tabProcess.SelectedIndex = 0;
        this.tabProcess.Size = new System.Drawing.Size(655, 321);
        this.tabProcess.TabIndex = 0;
        // 
        // TabPage1
        // 
        this.TabPage1.Controls.Add(this.GroupBox7);
        this.TabPage1.Controls.Add(this.GroupBox6);
        this.TabPage1.Controls.Add(this.gpProcGeneralFile);
        this.TabPage1.Controls.Add(this.GroupBox1);
        this.TabPage1.ImageIndex = 0;
        this.TabPage1.Location = new System.Drawing.Point(4, 22);
        this.TabPage1.Name = "TabPage1";
        this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage1.Size = new System.Drawing.Size(647, 295);
        this.TabPage1.TabIndex = 0;
        this.TabPage1.Text = "General - 1";
        this.TabPage1.UseVisualStyleBackColor = true;
        // 
        // GroupBox7
        // 
        this.GroupBox7.Controls.Add(this.cmdDelete);
        this.GroupBox7.Controls.Add(this.cmdResume);
        this.GroupBox7.Controls.Add(this.Label2);
        this.GroupBox7.Controls.Add(this.cbStart);
        this.GroupBox7.Controls.Add(this.cmdSetStartType);
        this.GroupBox7.Controls.Add(this.cmdStop);
        this.GroupBox7.Controls.Add(this.cmdPause);
        this.GroupBox7.Controls.Add(this.cmdStart);
        this.GroupBox7.Location = new System.Drawing.Point(391, 155);
        this.GroupBox7.Name = "GroupBox7";
        this.GroupBox7.Size = new System.Drawing.Size(242, 116);
        this.GroupBox7.TabIndex = 18;
        this.GroupBox7.TabStop = false;
        this.GroupBox7.Text = "Actions";
        // 
        // cmdDelete
        // 
        this.cmdDelete.Image = global::My.Resources.Resources.cross16;
        this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdDelete.Location = new System.Drawing.Point(166, 21);
        this.cmdDelete.Name = "cmdDelete";
        this.cmdDelete.Size = new System.Drawing.Size(66, 23);
        this.cmdDelete.TabIndex = 11;
        this.cmdDelete.Text = "Delete";
        this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdDelete.UseVisualStyleBackColor = true;
        // 
        // cmdResume
        // 
        this.cmdResume.Enabled = false;
        this.cmdResume.Image = global::My.Resources.Resources.control;
        this.cmdResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdResume.Location = new System.Drawing.Point(94, 21);
        this.cmdResume.Name = "cmdResume";
        this.cmdResume.Size = new System.Drawing.Size(66, 23);
        this.cmdResume.TabIndex = 10;
        this.cmdResume.Text = "Resume";
        this.cmdResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdResume.UseVisualStyleBackColor = true;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(10, 82);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(56, 13);
        this.Label2.TabIndex = 9;
        this.Label2.Text = "Start type";
        // 
        // cbStart
        // 
        this.cbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbStart.FormattingEnabled = true;
        this.cbStart.Items.AddRange(new object[] { "BootStart", "SystemStart", "AutoStart", "DemandStart", "StartDisabled" });
        this.cbStart.Location = new System.Drawing.Point(72, 79);
        this.cbStart.Name = "cbStart";
        this.cbStart.Size = new System.Drawing.Size(112, 21);
        this.cbStart.TabIndex = 8;
        // 
        // cmdSetStartType
        // 
        this.cmdSetStartType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSetStartType.Location = new System.Drawing.Point(193, 79);
        this.cmdSetStartType.Name = "cmdSetStartType";
        this.cmdSetStartType.Size = new System.Drawing.Size(37, 23);
        this.cmdSetStartType.TabIndex = 7;
        this.cmdSetStartType.Text = "Set";
        this.cmdSetStartType.UseVisualStyleBackColor = true;
        // 
        // cmdStop
        // 
        this.cmdStop.Enabled = false;
        this.cmdStop.Image = global::My.Resources.Resources.control_stop_square;
        this.cmdStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdStop.Location = new System.Drawing.Point(13, 50);
        this.cmdStop.Name = "cmdStop";
        this.cmdStop.Size = new System.Drawing.Size(75, 23);
        this.cmdStop.TabIndex = 5;
        this.cmdStop.Text = "Stop     ";
        this.cmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdStop.UseVisualStyleBackColor = true;
        // 
        // cmdPause
        // 
        this.cmdPause.Enabled = false;
        this.cmdPause.Image = global::My.Resources.Resources.control_pause;
        this.cmdPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdPause.Location = new System.Drawing.Point(13, 21);
        this.cmdPause.Name = "cmdPause";
        this.cmdPause.Size = new System.Drawing.Size(75, 23);
        this.cmdPause.TabIndex = 4;
        this.cmdPause.Text = "Pause   ";
        this.cmdPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdPause.UseVisualStyleBackColor = true;
        // 
        // cmdStart
        // 
        this.cmdStart.Enabled = false;
        this.cmdStart.Image = global::My.Resources.Resources.control;
        this.cmdStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdStart.Location = new System.Drawing.Point(94, 50);
        this.cmdStart.Name = "cmdStart";
        this.cmdStart.Size = new System.Drawing.Size(66, 23);
        this.cmdStart.TabIndex = 3;
        this.cmdStart.Text = "Start   ";
        this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdStart.UseVisualStyleBackColor = true;
        // 
        // GroupBox6
        // 
        this.GroupBox6.Controls.Add(this.SplitContainerOnlineInfo);
        this.GroupBox6.Location = new System.Drawing.Point(391, 6);
        this.GroupBox6.Name = "GroupBox6";
        this.GroupBox6.Size = new System.Drawing.Size(242, 143);
        this.GroupBox6.TabIndex = 17;
        this.GroupBox6.TabStop = false;
        this.GroupBox6.Text = "Online informations";
        // 
        // SplitContainerOnlineInfo
        // 
        this.SplitContainerOnlineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerOnlineInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerOnlineInfo.IsSplitterFixed = true;
        this.SplitContainerOnlineInfo.Location = new System.Drawing.Point(3, 18);
        this.SplitContainerOnlineInfo.Name = "SplitContainerOnlineInfo";
        this.SplitContainerOnlineInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerOnlineInfo.Panel1
        // 
        this.SplitContainerOnlineInfo.Panel1.Controls.Add(this.lblSecurityRisk);
        this.SplitContainerOnlineInfo.Panel1.Controls.Add(this.cmdGetOnlineInfos);
        // 
        // SplitContainerOnlineInfo.Panel2
        // 
        this.SplitContainerOnlineInfo.Panel2.Controls.Add(this.rtbOnlineInfos);
        this.SplitContainerOnlineInfo.Size = new System.Drawing.Size(236, 122);
        this.SplitContainerOnlineInfo.SplitterDistance = 25;
        this.SplitContainerOnlineInfo.TabIndex = 16;
        // 
        // lblSecurityRisk
        // 
        this.lblSecurityRisk.AutoSize = true;
        this.lblSecurityRisk.Location = new System.Drawing.Point(124, 6);
        this.lblSecurityRisk.Name = "lblSecurityRisk";
        this.lblSecurityRisk.Size = new System.Drawing.Size(74, 13);
        this.lblSecurityRisk.TabIndex = 2;
        this.lblSecurityRisk.Text = "Not yet rated";
        // 
        // cmdGetOnlineInfos
        // 
        this.cmdGetOnlineInfos.Location = new System.Drawing.Point(10, 1);
        this.cmdGetOnlineInfos.Name = "cmdGetOnlineInfos";
        this.cmdGetOnlineInfos.Size = new System.Drawing.Size(108, 23);
        this.cmdGetOnlineInfos.TabIndex = 11;
        this.cmdGetOnlineInfos.Text = "Get online infos";
        this.cmdGetOnlineInfos.UseVisualStyleBackColor = true;
        // 
        // rtbOnlineInfos
        // 
        this.rtbOnlineInfos.AutoWordSelection = true;
        this.rtbOnlineInfos.BackColor = System.Drawing.Color.White;
        this.rtbOnlineInfos.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtbOnlineInfos.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtbOnlineInfos.HideSelection = false;
        this.rtbOnlineInfos.Location = new System.Drawing.Point(0, 0);
        this.rtbOnlineInfos.Name = "rtbOnlineInfos";
        this.rtbOnlineInfos.ReadOnly = true;
        this.rtbOnlineInfos.Size = new System.Drawing.Size(236, 93);
        this.rtbOnlineInfos.TabIndex = 12;
        this.rtbOnlineInfos.Text = "";
        // 
        // gpProcGeneralFile
        // 
        this.gpProcGeneralFile.Controls.Add(this.cmdInspectExe);
        this.gpProcGeneralFile.Controls.Add(this.cmdShowFileDetails);
        this.gpProcGeneralFile.Controls.Add(this.cmdShowFileProperties);
        this.gpProcGeneralFile.Controls.Add(this.cmdOpenDirectory);
        this.gpProcGeneralFile.Controls.Add(this.txtServicePath);
        this.gpProcGeneralFile.Controls.Add(this.Label13);
        this.gpProcGeneralFile.Controls.Add(this.txtImageVersion);
        this.gpProcGeneralFile.Controls.Add(this.Label12);
        this.gpProcGeneralFile.Controls.Add(this.lblCopyright);
        this.gpProcGeneralFile.Controls.Add(this.lblDescription);
        this.gpProcGeneralFile.Controls.Add(this.pctSmallIcon);
        this.gpProcGeneralFile.Controls.Add(this.pctBigIcon);
        this.gpProcGeneralFile.Location = new System.Drawing.Point(6, 6);
        this.gpProcGeneralFile.Name = "gpProcGeneralFile";
        this.gpProcGeneralFile.Size = new System.Drawing.Size(376, 117);
        this.gpProcGeneralFile.TabIndex = 15;
        this.gpProcGeneralFile.TabStop = false;
        this.gpProcGeneralFile.Text = "Image file";
        // 
        // cmdInspectExe
        // 
        this.cmdInspectExe.Image = global::My.Resources.Resources.dllIcon16;
        this.cmdInspectExe.Location = new System.Drawing.Point(266, 81);
        this.cmdInspectExe.Name = "cmdInspectExe";
        this.cmdInspectExe.Size = new System.Drawing.Size(26, 26);
        this.cmdInspectExe.TabIndex = 19;
        this.cmdInspectExe.UseVisualStyleBackColor = true;
        // 
        // cmdShowFileDetails
        // 
        this.cmdShowFileDetails.Enabled = false;
        this.cmdShowFileDetails.Image = global::My.Resources.Resources.magnifier;
        this.cmdShowFileDetails.Location = new System.Drawing.Point(292, 81);
        this.cmdShowFileDetails.Name = "cmdShowFileDetails";
        this.cmdShowFileDetails.Size = new System.Drawing.Size(26, 26);
        this.cmdShowFileDetails.TabIndex = 3;
        this.cmdShowFileDetails.UseVisualStyleBackColor = true;
        // 
        // cmdShowFileProperties
        // 
        this.cmdShowFileProperties.Enabled = false;
        this.cmdShowFileProperties.Image = global::My.Resources.Resources.document_text;
        this.cmdShowFileProperties.Location = new System.Drawing.Point(318, 81);
        this.cmdShowFileProperties.Name = "cmdShowFileProperties";
        this.cmdShowFileProperties.Size = new System.Drawing.Size(26, 26);
        this.cmdShowFileProperties.TabIndex = 4;
        this.cmdShowFileProperties.UseVisualStyleBackColor = true;
        // 
        // cmdOpenDirectory
        // 
        this.cmdOpenDirectory.Enabled = false;
        this.cmdOpenDirectory.Image = global::My.Resources.Resources.folder_open_document;
        this.cmdOpenDirectory.Location = new System.Drawing.Point(344, 81);
        this.cmdOpenDirectory.Name = "cmdOpenDirectory";
        this.cmdOpenDirectory.Size = new System.Drawing.Size(26, 26);
        this.cmdOpenDirectory.TabIndex = 5;
        this.cmdOpenDirectory.UseVisualStyleBackColor = true;
        // 
        // txtServicePath
        // 
        this.txtServicePath.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtServicePath.Location = new System.Drawing.Point(85, 82);
        this.txtServicePath.Name = "txtServicePath";
        this.txtServicePath.ReadOnly = true;
        this.txtServicePath.Size = new System.Drawing.Size(175, 22);
        this.txtServicePath.TabIndex = 2;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(5, 85);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(65, 13);
        this.Label13.TabIndex = 17;
        this.Label13.Text = "Image path";
        // 
        // txtImageVersion
        // 
        this.txtImageVersion.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtImageVersion.Location = new System.Drawing.Point(85, 59);
        this.txtImageVersion.Name = "txtImageVersion";
        this.txtImageVersion.ReadOnly = true;
        this.txtImageVersion.Size = new System.Drawing.Size(285, 22);
        this.txtImageVersion.TabIndex = 1;
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(6, 62);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(78, 13);
        this.Label12.TabIndex = 15;
        this.Label12.Text = "Image version";
        // 
        // lblCopyright
        // 
        this.lblCopyright.AutoSize = true;
        this.lblCopyright.Location = new System.Drawing.Point(82, 38);
        this.lblCopyright.Name = "lblCopyright";
        this.lblCopyright.Size = new System.Drawing.Size(77, 13);
        this.lblCopyright.TabIndex = 14;
        this.lblCopyright.Text = "File copyright";
        // 
        // lblDescription
        // 
        this.lblDescription.AutoSize = true;
        this.lblDescription.Location = new System.Drawing.Point(82, 19);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(86, 13);
        this.lblDescription.TabIndex = 13;
        this.lblDescription.Text = "File description";
        // 
        // pctSmallIcon
        // 
        this.pctSmallIcon.Location = new System.Drawing.Point(44, 35);
        this.pctSmallIcon.Name = "pctSmallIcon";
        this.pctSmallIcon.Size = new System.Drawing.Size(16, 16);
        this.pctSmallIcon.TabIndex = 12;
        this.pctSmallIcon.TabStop = false;
        // 
        // pctBigIcon
        // 
        this.pctBigIcon.Location = new System.Drawing.Point(6, 19);
        this.pctBigIcon.Name = "pctBigIcon";
        this.pctBigIcon.Size = new System.Drawing.Size(32, 32);
        this.pctBigIcon.TabIndex = 11;
        this.pctBigIcon.TabStop = false;
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.txtCommand);
        this.GroupBox1.Controls.Add(this.Label22);
        this.GroupBox1.Controls.Add(this.cmdGoProcess);
        this.GroupBox1.Controls.Add(this.txtName);
        this.GroupBox1.Controls.Add(this.Label15);
        this.GroupBox1.Controls.Add(this.txtProcess);
        this.GroupBox1.Controls.Add(this.Label1);
        this.GroupBox1.Controls.Add(this.txtStartType);
        this.GroupBox1.Controls.Add(this.Label17);
        this.GroupBox1.Controls.Add(this.txtType);
        this.GroupBox1.Controls.Add(this.Label16);
        this.GroupBox1.Controls.Add(this.txtState);
        this.GroupBox1.Controls.Add(this.Label14);
        this.GroupBox1.Location = new System.Drawing.Point(6, 129);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(376, 171);
        this.GroupBox1.TabIndex = 16;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Service";
        // 
        // txtCommand
        // 
        this.txtCommand.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtCommand.Location = new System.Drawing.Point(85, 44);
        this.txtCommand.Name = "txtCommand";
        this.txtCommand.ReadOnly = true;
        this.txtCommand.Size = new System.Drawing.Size(282, 22);
        this.txtCommand.TabIndex = 25;
        // 
        // Label22
        // 
        this.Label22.AutoSize = true;
        this.Label22.Location = new System.Drawing.Point(2, 47);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(59, 13);
        this.Label22.TabIndex = 26;
        this.Label22.Text = "Command";
        // 
        // cmdGoProcess
        // 
        this.cmdGoProcess.Enabled = false;
        this.cmdGoProcess.Image = global::My.Resources.Resources.down16;
        this.cmdGoProcess.Location = new System.Drawing.Point(341, 136);
        this.cmdGoProcess.Name = "cmdGoProcess";
        this.cmdGoProcess.Size = new System.Drawing.Size(26, 26);
        this.cmdGoProcess.TabIndex = 24;
        this.cmdGoProcess.UseVisualStyleBackColor = true;
        // 
        // txtName
        // 
        this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtName.Location = new System.Drawing.Point(85, 21);
        this.txtName.Name = "txtName";
        this.txtName.ReadOnly = true;
        this.txtName.Size = new System.Drawing.Size(282, 22);
        this.txtName.TabIndex = 6;
        // 
        // Label15
        // 
        this.Label15.AutoSize = true;
        this.Label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label15.Location = new System.Drawing.Point(2, 24);
        this.Label15.Name = "Label15";
        this.Label15.Size = new System.Drawing.Size(77, 13);
        this.Label15.TabIndex = 15;
        this.Label15.Text = "Display name";
        // 
        // txtProcess
        // 
        this.txtProcess.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtProcess.Location = new System.Drawing.Point(85, 136);
        this.txtProcess.Name = "txtProcess";
        this.txtProcess.ReadOnly = true;
        this.txtProcess.Size = new System.Drawing.Size(250, 22);
        this.txtProcess.TabIndex = 10;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(2, 139);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(45, 13);
        this.Label1.TabIndex = 23;
        this.Label1.Text = "Process";
        // 
        // txtStartType
        // 
        this.txtStartType.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtStartType.Location = new System.Drawing.Point(85, 112);
        this.txtStartType.Name = "txtStartType";
        this.txtStartType.ReadOnly = true;
        this.txtStartType.Size = new System.Drawing.Size(282, 22);
        this.txtStartType.TabIndex = 9;
        // 
        // Label17
        // 
        this.Label17.AutoSize = true;
        this.Label17.Location = new System.Drawing.Point(2, 115);
        this.Label17.Name = "Label17";
        this.Label17.Size = new System.Drawing.Size(56, 13);
        this.Label17.TabIndex = 21;
        this.Label17.Text = "Start type";
        // 
        // txtType
        // 
        this.txtType.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtType.Location = new System.Drawing.Point(85, 89);
        this.txtType.Name = "txtType";
        this.txtType.ReadOnly = true;
        this.txtType.Size = new System.Drawing.Size(282, 22);
        this.txtType.TabIndex = 8;
        // 
        // Label16
        // 
        this.Label16.AutoSize = true;
        this.Label16.Location = new System.Drawing.Point(2, 92);
        this.Label16.Name = "Label16";
        this.Label16.Size = new System.Drawing.Size(30, 13);
        this.Label16.TabIndex = 19;
        this.Label16.Text = "Type";
        // 
        // txtState
        // 
        this.txtState.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtState.Location = new System.Drawing.Point(85, 67);
        this.txtState.Name = "txtState";
        this.txtState.ReadOnly = true;
        this.txtState.Size = new System.Drawing.Size(282, 22);
        this.txtState.TabIndex = 7;
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(2, 70);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(33, 13);
        this.Label14.TabIndex = 17;
        this.Label14.Text = "State";
        // 
        // TabPage2
        // 
        this.TabPage2.Controls.Add(this.GroupBox4);
        this.TabPage2.Controls.Add(this.GroupBox3);
        this.TabPage2.Controls.Add(this.GroupBox2);
        this.TabPage2.ImageIndex = 0;
        this.TabPage2.Location = new System.Drawing.Point(4, 22);
        this.TabPage2.Name = "TabPage2";
        this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage2.Size = new System.Drawing.Size(647, 295);
        this.TabPage2.TabIndex = 8;
        this.TabPage2.Text = "General - 2";
        this.TabPage2.UseVisualStyleBackColor = true;
        // 
        // GroupBox4
        // 
        this.GroupBox4.Controls.Add(this.txtServiceSpecificExitCode);
        this.GroupBox4.Controls.Add(this.Label10);
        this.GroupBox4.Controls.Add(this.txtDiagnosticMessageFile);
        this.GroupBox4.Controls.Add(this.Label11);
        this.GroupBox4.Controls.Add(this.txtCheckPoint);
        this.GroupBox4.Controls.Add(this.Label18);
        this.GroupBox4.Controls.Add(this.txtWaitHint);
        this.GroupBox4.Controls.Add(this.Label19);
        this.GroupBox4.Controls.Add(this.txtServiceFlags);
        this.GroupBox4.Controls.Add(this.Label20);
        this.GroupBox4.Location = new System.Drawing.Point(329, 6);
        this.GroupBox4.Name = "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(312, 169);
        this.GroupBox4.TabIndex = 19;
        this.GroupBox4.TabStop = false;
        this.GroupBox4.Text = "Additional informations";
        // 
        // txtServiceSpecificExitCode
        // 
        this.txtServiceSpecificExitCode.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtServiceSpecificExitCode.Location = new System.Drawing.Point(144, 114);
        this.txtServiceSpecificExitCode.Name = "txtServiceSpecificExitCode";
        this.txtServiceSpecificExitCode.ReadOnly = true;
        this.txtServiceSpecificExitCode.Size = new System.Drawing.Size(158, 22);
        this.txtServiceSpecificExitCode.TabIndex = 10;
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(6, 117);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(132, 13);
        this.Label10.TabIndex = 23;
        this.Label10.Text = "Service specific exit code";
        // 
        // txtDiagnosticMessageFile
        // 
        this.txtDiagnosticMessageFile.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtDiagnosticMessageFile.Location = new System.Drawing.Point(144, 90);
        this.txtDiagnosticMessageFile.Name = "txtDiagnosticMessageFile";
        this.txtDiagnosticMessageFile.ReadOnly = true;
        this.txtDiagnosticMessageFile.Size = new System.Drawing.Size(158, 22);
        this.txtDiagnosticMessageFile.TabIndex = 9;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(6, 93);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(128, 13);
        this.Label11.TabIndex = 21;
        this.Label11.Text = "Diagnostic message file";
        // 
        // txtCheckPoint
        // 
        this.txtCheckPoint.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtCheckPoint.Location = new System.Drawing.Point(89, 67);
        this.txtCheckPoint.Name = "txtCheckPoint";
        this.txtCheckPoint.ReadOnly = true;
        this.txtCheckPoint.Size = new System.Drawing.Size(213, 22);
        this.txtCheckPoint.TabIndex = 8;
        // 
        // Label18
        // 
        this.Label18.AutoSize = true;
        this.Label18.Location = new System.Drawing.Point(6, 70);
        this.Label18.Name = "Label18";
        this.Label18.Size = new System.Drawing.Size(66, 13);
        this.Label18.TabIndex = 19;
        this.Label18.Text = "Checkpoint";
        // 
        // txtWaitHint
        // 
        this.txtWaitHint.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtWaitHint.Location = new System.Drawing.Point(89, 45);
        this.txtWaitHint.Name = "txtWaitHint";
        this.txtWaitHint.ReadOnly = true;
        this.txtWaitHint.Size = new System.Drawing.Size(213, 22);
        this.txtWaitHint.TabIndex = 7;
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(6, 48);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(55, 13);
        this.Label19.TabIndex = 17;
        this.Label19.Text = "Wait hint";
        // 
        // txtServiceFlags
        // 
        this.txtServiceFlags.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtServiceFlags.Location = new System.Drawing.Point(89, 22);
        this.txtServiceFlags.Name = "txtServiceFlags";
        this.txtServiceFlags.ReadOnly = true;
        this.txtServiceFlags.Size = new System.Drawing.Size(213, 22);
        this.txtServiceFlags.TabIndex = 6;
        // 
        // Label20
        // 
        this.Label20.AutoSize = true;
        this.Label20.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label20.Location = new System.Drawing.Point(6, 25);
        this.Label20.Name = "Label20";
        this.Label20.Size = new System.Drawing.Size(70, 13);
        this.Label20.TabIndex = 15;
        this.Label20.Text = "Service flags";
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.rtbDescription);
        this.GroupBox3.Location = new System.Drawing.Point(8, 181);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(376, 119);
        this.GroupBox3.TabIndex = 18;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Description";
        // 
        // rtbDescription
        // 
        this.rtbDescription.AutoWordSelection = true;
        this.rtbDescription.BackColor = System.Drawing.Color.White;
        this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtbDescription.HideSelection = false;
        this.rtbDescription.Location = new System.Drawing.Point(3, 18);
        this.rtbDescription.Name = "rtbDescription";
        this.rtbDescription.ReadOnly = true;
        this.rtbDescription.Size = new System.Drawing.Size(370, 98);
        this.rtbDescription.TabIndex = 13;
        this.rtbDescription.Text = "";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.txtTagID);
        this.GroupBox2.Controls.Add(this.Label8);
        this.GroupBox2.Controls.Add(this.txtObjectName);
        this.GroupBox2.Controls.Add(this.Label3);
        this.GroupBox2.Controls.Add(this.txtWin32ExitCode);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.txtServiceStartName);
        this.GroupBox2.Controls.Add(this.Label5);
        this.GroupBox2.Controls.Add(this.txtLoadOrderGroup);
        this.GroupBox2.Controls.Add(this.Label6);
        this.GroupBox2.Controls.Add(this.txtErrorControl);
        this.GroupBox2.Controls.Add(this.Label7);
        this.GroupBox2.Location = new System.Drawing.Point(8, 6);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(312, 169);
        this.GroupBox2.TabIndex = 17;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Additional informations";
        // 
        // txtTagID
        // 
        this.txtTagID.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtTagID.Location = new System.Drawing.Point(110, 138);
        this.txtTagID.Name = "txtTagID";
        this.txtTagID.ReadOnly = true;
        this.txtTagID.Size = new System.Drawing.Size(192, 22);
        this.txtTagID.TabIndex = 24;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(6, 141);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(39, 13);
        this.Label8.TabIndex = 25;
        this.Label8.Text = "Tag ID";
        // 
        // txtObjectName
        // 
        this.txtObjectName.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtObjectName.Location = new System.Drawing.Point(110, 114);
        this.txtObjectName.Name = "txtObjectName";
        this.txtObjectName.ReadOnly = true;
        this.txtObjectName.Size = new System.Drawing.Size(192, 22);
        this.txtObjectName.TabIndex = 10;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(6, 117);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(72, 13);
        this.Label3.TabIndex = 23;
        this.Label3.Text = "Object name";
        // 
        // txtWin32ExitCode
        // 
        this.txtWin32ExitCode.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtWin32ExitCode.Location = new System.Drawing.Point(110, 90);
        this.txtWin32ExitCode.Name = "txtWin32ExitCode";
        this.txtWin32ExitCode.ReadOnly = true;
        this.txtWin32ExitCode.Size = new System.Drawing.Size(192, 22);
        this.txtWin32ExitCode.TabIndex = 9;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 93);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(89, 13);
        this.Label4.TabIndex = 21;
        this.Label4.Text = "Win32 exit code";
        // 
        // txtServiceStartName
        // 
        this.txtServiceStartName.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtServiceStartName.Location = new System.Drawing.Point(110, 67);
        this.txtServiceStartName.Name = "txtServiceStartName";
        this.txtServiceStartName.ReadOnly = true;
        this.txtServiceStartName.Size = new System.Drawing.Size(192, 22);
        this.txtServiceStartName.TabIndex = 8;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(6, 70);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(99, 13);
        this.Label5.TabIndex = 19;
        this.Label5.Text = "Service start name";
        // 
        // txtLoadOrderGroup
        // 
        this.txtLoadOrderGroup.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtLoadOrderGroup.Location = new System.Drawing.Point(110, 45);
        this.txtLoadOrderGroup.Name = "txtLoadOrderGroup";
        this.txtLoadOrderGroup.ReadOnly = true;
        this.txtLoadOrderGroup.Size = new System.Drawing.Size(192, 22);
        this.txtLoadOrderGroup.TabIndex = 7;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(6, 48);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(98, 13);
        this.Label6.TabIndex = 17;
        this.Label6.Text = "Load order group";
        // 
        // txtErrorControl
        // 
        this.txtErrorControl.BackColor = System.Drawing.Color.WhiteSmoke;
        this.txtErrorControl.Location = new System.Drawing.Point(110, 22);
        this.txtErrorControl.Name = "txtErrorControl";
        this.txtErrorControl.ReadOnly = true;
        this.txtErrorControl.Size = new System.Drawing.Size(192, 22);
        this.txtErrorControl.TabIndex = 6;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Label7.Location = new System.Drawing.Point(6, 25);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(72, 13);
        this.Label7.TabIndex = 15;
        this.Label7.Text = "Error control";
        // 
        // tabDep
        // 
        this.tabDep.Controls.Add(this.SplitContainer);
        this.tabDep.ImageIndex = 8;
        this.tabDep.Location = new System.Drawing.Point(4, 22);
        this.tabDep.Name = "tabDep";
        this.tabDep.Padding = new System.Windows.Forms.Padding(3);
        this.tabDep.Size = new System.Drawing.Size(647, 295);
        this.tabDep.TabIndex = 7;
        this.tabDep.Text = "Dependencies";
        this.tabDep.UseVisualStyleBackColor = true;
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.Location = new System.Drawing.Point(3, 3);
        this.SplitContainer.Name = "SplitContainer";
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.SplitContainer1);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.SplitContainer3);
        this.SplitContainer.Size = new System.Drawing.Size(641, 289);
        this.SplitContainer.SplitterDistance = 320;
        this.SplitContainer.TabIndex = 0;
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer1.IsSplitterFixed = true;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.Label9);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
        this.SplitContainer1.Size = new System.Drawing.Size(320, 289);
        this.SplitContainer1.SplitterDistance = 25;
        this.SplitContainer1.TabIndex = 0;
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Label9.Location = new System.Drawing.Point(0, 0);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(200, 13);
        this.Label9.TabIndex = 0;
        this.Label9.Text = "The service depends on these services";
        // 
        // SplitContainer2
        // 
        this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer2.IsSplitterFixed = true;
        this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer2.Name = "SplitContainer2";
        this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer2.Panel1
        // 
        this.SplitContainer2.Panel1.Controls.Add(this.tv2);
        // 
        // SplitContainer2.Panel2
        // 
        this.SplitContainer2.Panel2.Controls.Add(this.cmdServDet1);
        this.SplitContainer2.Size = new System.Drawing.Size(320, 260);
        this.SplitContainer2.SplitterDistance = 230;
        this.SplitContainer2.TabIndex = 0;
        // 
        // tv2
        // 
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection1.Snapshot = (cSnapshot)resources.GetObject("CConnection1.Snapshot");
        CConnection1.SnapshotFile = null;
        this.tv2.ConnectionObj = CConnection1;
        this.tv2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tv2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tv2.ImageIndex = 0;
        this.tv2.InfosToGet = cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe;
        this.tv2.IsConnected = false;
        this.tv2.Location = new System.Drawing.Point(0, 0);
        this.tv2.Name = "tv2";
        this.tv2.RootService = null;
        this.tv2.SelectedImageIndex = 0;
        this.tv2.Size = new System.Drawing.Size(320, 230);
        this.tv2.TabIndex = 16;
        // 
        // cmdServDet1
        // 
        this.cmdServDet1.Location = new System.Drawing.Point(90, 2);
        this.cmdServDet1.Name = "cmdServDet1";
        this.cmdServDet1.Size = new System.Drawing.Size(140, 23);
        this.cmdServDet1.TabIndex = 0;
        this.cmdServDet1.Text = "View services details";
        this.cmdServDet1.UseVisualStyleBackColor = true;
        // 
        // SplitContainer3
        // 
        this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer3.IsSplitterFixed = true;
        this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer3.Name = "SplitContainer3";
        this.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer3.Panel1
        // 
        this.SplitContainer3.Panel1.Controls.Add(this.Label21);
        // 
        // SplitContainer3.Panel2
        // 
        this.SplitContainer3.Panel2.Controls.Add(this.SplitContainer4);
        this.SplitContainer3.Size = new System.Drawing.Size(317, 289);
        this.SplitContainer3.SplitterDistance = 25;
        this.SplitContainer3.TabIndex = 1;
        // 
        // Label21
        // 
        this.Label21.AutoSize = true;
        this.Label21.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Label21.Location = new System.Drawing.Point(0, 0);
        this.Label21.Name = "Label21";
        this.Label21.Size = new System.Drawing.Size(195, 13);
        this.Label21.TabIndex = 1;
        this.Label21.Text = "These services depend on the service";
        // 
        // SplitContainer4
        // 
        this.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer4.IsSplitterFixed = true;
        this.SplitContainer4.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer4.Name = "SplitContainer4";
        this.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer4.Panel1
        // 
        this.SplitContainer4.Panel1.Controls.Add(this.tv);
        // 
        // SplitContainer4.Panel2
        // 
        this.SplitContainer4.Panel2.Controls.Add(this.cmdServDet2);
        this.SplitContainer4.Size = new System.Drawing.Size(317, 260);
        this.SplitContainer4.SplitterDistance = 230;
        this.SplitContainer4.TabIndex = 0;
        // 
        // tv
        // 
        CConnection2.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        CConnection2.Snapshot = (cSnapshot)resources.GetObject("CConnection2.Snapshot");
        CConnection2.SnapshotFile = null;
        this.tv.ConnectionObj = CConnection2;
        this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tv.ImageIndex = 0;
        this.tv.InfosToGet = cServDepConnection.DependenciesToget.DependenciesOfMe;
        this.tv.IsConnected = false;
        this.tv.Location = new System.Drawing.Point(0, 0);
        this.tv.Name = "tv";
        this.tv.RootService = null;
        this.tv.SelectedImageIndex = 0;
        this.tv.Size = new System.Drawing.Size(317, 230);
        this.tv.TabIndex = 15;
        // 
        // cmdServDet2
        // 
        this.cmdServDet2.Location = new System.Drawing.Point(88, 2);
        this.cmdServDet2.Name = "cmdServDet2";
        this.cmdServDet2.Size = new System.Drawing.Size(140, 23);
        this.cmdServDet2.TabIndex = 1;
        this.cmdServDet2.Text = "View services details";
        this.cmdServDet2.UseVisualStyleBackColor = true;
        // 
        // TabPage6
        // 
        this.TabPage6.Controls.Add(this.SplitContainerInfoProcess);
        this.TabPage6.ImageIndex = 5;
        this.TabPage6.Location = new System.Drawing.Point(4, 22);
        this.TabPage6.Name = "TabPage6";
        this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage6.Size = new System.Drawing.Size(647, 295);
        this.TabPage6.TabIndex = 5;
        this.TabPage6.Text = "Informations";
        this.TabPage6.UseVisualStyleBackColor = true;
        // 
        // SplitContainerInfoProcess
        // 
        this.SplitContainerInfoProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerInfoProcess.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainerInfoProcess.Location = new System.Drawing.Point(3, 3);
        this.SplitContainerInfoProcess.Name = "SplitContainerInfoProcess";
        this.SplitContainerInfoProcess.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainerInfoProcess.Panel1
        // 
        this.SplitContainerInfoProcess.Panel1.Controls.Add(this.cmdRefresh);
        this.SplitContainerInfoProcess.Panel1.Controls.Add(this.cmdInfosToClipB);
        // 
        // SplitContainerInfoProcess.Panel2
        // 
        this.SplitContainerInfoProcess.Panel2.Controls.Add(this.rtb);
        this.SplitContainerInfoProcess.Size = new System.Drawing.Size(641, 289);
        this.SplitContainerInfoProcess.SplitterDistance = 25;
        this.SplitContainerInfoProcess.TabIndex = 0;
        // 
        // cmdRefresh
        // 
        this.cmdRefresh.Image = global::My.Resources.Resources.refresh16;
        this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdRefresh.Location = new System.Drawing.Point(159, 0);
        this.cmdRefresh.Name = "cmdRefresh";
        this.cmdRefresh.Size = new System.Drawing.Size(85, 24);
        this.cmdRefresh.TabIndex = 1;
        this.cmdRefresh.Text = "Refresh   ";
        this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdRefresh.UseVisualStyleBackColor = true;
        // 
        // cmdInfosToClipB
        // 
        this.cmdInfosToClipB.Enabled = false;
        this.cmdInfosToClipB.Image = global::My.Resources.Resources.copy16;
        this.cmdInfosToClipB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdInfosToClipB.Location = new System.Drawing.Point(3, 0);
        this.cmdInfosToClipB.Name = "cmdInfosToClipB";
        this.cmdInfosToClipB.Size = new System.Drawing.Size(150, 24);
        this.cmdInfosToClipB.TabIndex = 0;
        this.cmdInfosToClipB.Text = "Copy to clipboard";
        this.cmdInfosToClipB.UseVisualStyleBackColor = true;
        // 
        // rtb
        // 
        this.rtb.AutoWordSelection = true;
        this.rtb.BackColor = System.Drawing.Color.White;
        this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtb.HideSelection = false;
        this.rtb.Location = new System.Drawing.Point(0, 0);
        this.rtb.Name = "rtb";
        this.rtb.ReadOnly = true;
        this.rtb.Size = new System.Drawing.Size(641, 260);
        this.rtb.TabIndex = 4;
        this.rtb.Text = "";
        // 
        // Timer
        // 
        this.Timer.Enabled = true;
        this.Timer.Interval = 1000;
        // 
        // menuCopyPctbig
        // 
        this.menuCopyPctbig.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyBig });
        // 
        // MenuItemCopyBig
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyBig, global::My.Resources.Resources.copy16);
        this.MenuItemCopyBig.Index = 0;
        this.MenuItemCopyBig.Text = "Copy to clipboard";
        // 
        // MenuItemCopySmall
        // 
        this.VistaMenu.SetImage(this.MenuItemCopySmall, global::My.Resources.Resources.copy16);
        this.MenuItemCopySmall.Index = 0;
        this.MenuItemCopySmall.Text = "Copy to clipboard";
        // 
        // menuCopyPctSmall
        // 
        this.menuCopyPctSmall.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopySmall });
        // 
        // mainMenu
        // 
        this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem3 });
        // 
        // MenuItem3
        // 
        this.MenuItem3.Index = 0;
        this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem4 });
        this.MenuItem3.Text = "main";
        this.MenuItem3.Visible = false;
        // 
        // MenuItem4
        // 
        this.MenuItem4.Index = 0;
        this.MenuItem4.Shortcut = System.Windows.Forms.Shortcut.F5;
        this.MenuItem4.Text = "Refresh";
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // frmServiceInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(655, 321);
        this.Controls.Add(this.tabProcess);
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.Menu = this.mainMenu;
        this.MinimumSize = new System.Drawing.Size(660, 359);
        this.Name = "frmServiceInfo";
        this.Text = "Service informations";
        this.tabProcess.ResumeLayout(false);
        this.TabPage1.ResumeLayout(false);
        this.GroupBox7.ResumeLayout(false);
        this.GroupBox7.PerformLayout();
        this.GroupBox6.ResumeLayout(false);
        this.SplitContainerOnlineInfo.Panel1.ResumeLayout(false);
        this.SplitContainerOnlineInfo.Panel1.PerformLayout();
        this.SplitContainerOnlineInfo.Panel2.ResumeLayout(false);
        this.SplitContainerOnlineInfo.ResumeLayout(false);
        this.gpProcGeneralFile.ResumeLayout(false);
        this.gpProcGeneralFile.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pctSmallIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pctBigIcon).EndInit();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.TabPage2.ResumeLayout(false);
        this.GroupBox4.ResumeLayout(false);
        this.GroupBox4.PerformLayout();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.tabDep.ResumeLayout(false);
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel1.PerformLayout();
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
        this.SplitContainer2.Panel1.ResumeLayout(false);
        this.SplitContainer2.Panel2.ResumeLayout(false);
        this.SplitContainer2.ResumeLayout(false);
        this.SplitContainer3.Panel1.ResumeLayout(false);
        this.SplitContainer3.Panel1.PerformLayout();
        this.SplitContainer3.Panel2.ResumeLayout(false);
        this.SplitContainer3.ResumeLayout(false);
        this.SplitContainer4.Panel1.ResumeLayout(false);
        this.SplitContainer4.Panel2.ResumeLayout(false);
        this.SplitContainer4.ResumeLayout(false);
        this.TabPage6.ResumeLayout(false);
        this.SplitContainerInfoProcess.Panel1.ResumeLayout(false);
        this.SplitContainerInfoProcess.Panel2.ResumeLayout(false);
        this.SplitContainerInfoProcess.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.TabControl _tabProcess;

    internal System.Windows.Forms.TabControl tabProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabProcess != null)
            {
            }

            _tabProcess = value;
            if (_tabProcess != null)
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

    private System.Windows.Forms.TextBox _txtStartType;

    internal System.Windows.Forms.TextBox txtStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtStartType != null)
            {
            }

            _txtStartType = value;
            if (_txtStartType != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label17;

    internal System.Windows.Forms.Label Label17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label17 != null)
            {
            }

            _Label17 = value;
            if (_Label17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtType;

    internal System.Windows.Forms.TextBox txtType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtType != null)
            {
            }

            _txtType = value;
            if (_txtType != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label16;

    internal System.Windows.Forms.Label Label16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label16 != null)
            {
            }

            _Label16 = value;
            if (_Label16 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtState;

    internal System.Windows.Forms.TextBox txtState
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtState != null)
            {
            }

            _txtState = value;
            if (_txtState != null)
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

    private System.Windows.Forms.TextBox _txtName;

    internal System.Windows.Forms.TextBox txtName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtName != null)
            {
            }

            _txtName = value;
            if (_txtName != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label15;

    internal System.Windows.Forms.Label Label15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label15 != null)
            {
            }

            _Label15 = value;
            if (_Label15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _gpProcGeneralFile;

    internal System.Windows.Forms.GroupBox gpProcGeneralFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpProcGeneralFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpProcGeneralFile != null)
            {
            }

            _gpProcGeneralFile = value;
            if (_gpProcGeneralFile != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShowFileDetails;

    internal System.Windows.Forms.Button cmdShowFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShowFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShowFileDetails != null)
            {
            }

            _cmdShowFileDetails = value;
            if (_cmdShowFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdShowFileProperties;

    internal System.Windows.Forms.Button cmdShowFileProperties
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdShowFileProperties;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdShowFileProperties != null)
            {
            }

            _cmdShowFileProperties = value;
            if (_cmdShowFileProperties != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdOpenDirectory;

    internal System.Windows.Forms.Button cmdOpenDirectory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpenDirectory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpenDirectory != null)
            {
            }

            _cmdOpenDirectory = value;
            if (_cmdOpenDirectory != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServicePath;

    internal System.Windows.Forms.TextBox txtServicePath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServicePath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServicePath != null)
            {
            }

            _txtServicePath = value;
            if (_txtServicePath != null)
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

    private System.Windows.Forms.TextBox _txtImageVersion;

    internal System.Windows.Forms.TextBox txtImageVersion
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtImageVersion;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtImageVersion != null)
            {
            }

            _txtImageVersion = value;
            if (_txtImageVersion != null)
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

    private System.Windows.Forms.Label _lblCopyright;

    internal System.Windows.Forms.Label lblCopyright
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCopyright;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCopyright != null)
            {
            }

            _lblCopyright = value;
            if (_lblCopyright != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblDescription;

    internal System.Windows.Forms.Label lblDescription
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDescription;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblDescription != null)
            {
            }

            _lblDescription = value;
            if (_lblDescription != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctSmallIcon;

    internal System.Windows.Forms.PictureBox pctSmallIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctSmallIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctSmallIcon != null)
            {
            }

            _pctSmallIcon = value;
            if (_pctSmallIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.PictureBox _pctBigIcon;

    internal System.Windows.Forms.PictureBox pctBigIcon
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pctBigIcon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pctBigIcon != null)
            {
            }

            _pctBigIcon = value;
            if (_pctBigIcon != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _TabPage6;

    internal System.Windows.Forms.TabPage TabPage6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPage6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabPage6 != null)
            {
            }

            _TabPage6 = value;
            if (_TabPage6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerInfoProcess;

    internal System.Windows.Forms.SplitContainer SplitContainerInfoProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerInfoProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerInfoProcess != null)
            {
            }

            _SplitContainerInfoProcess = value;
            if (_SplitContainerInfoProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdInfosToClipB;

    internal System.Windows.Forms.Button cmdInfosToClipB
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdInfosToClipB;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdInfosToClipB != null)
            {
            }

            _cmdInfosToClipB = value;
            if (_cmdInfosToClipB != null)
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

    private System.Windows.Forms.TabPage _tabDep;

    internal System.Windows.Forms.TabPage tabDep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabDep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabDep != null)
            {
            }

            _tabDep = value;
            if (_tabDep != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox6;

    internal System.Windows.Forms.GroupBox GroupBox6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox6 != null)
            {
            }

            _GroupBox6 = value;
            if (_GroupBox6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainerOnlineInfo;

    internal System.Windows.Forms.SplitContainer SplitContainerOnlineInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerOnlineInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerOnlineInfo != null)
            {
            }

            _SplitContainerOnlineInfo = value;
            if (_SplitContainerOnlineInfo != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblSecurityRisk;

    internal System.Windows.Forms.Label lblSecurityRisk
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblSecurityRisk;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblSecurityRisk != null)
            {
            }

            _lblSecurityRisk = value;
            if (_lblSecurityRisk != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGetOnlineInfos;

    internal System.Windows.Forms.Button cmdGetOnlineInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGetOnlineInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGetOnlineInfos != null)
            {
            }

            _cmdGetOnlineInfos = value;
            if (_cmdGetOnlineInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.RichTextBox _rtbOnlineInfos;

    internal System.Windows.Forms.RichTextBox rtbOnlineInfos
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtbOnlineInfos;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtbOnlineInfos != null)
            {
            }

            _rtbOnlineInfos = value;
            if (_rtbOnlineInfos != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcess;

    internal System.Windows.Forms.TextBox txtProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcess != null)
            {
            }

            _txtProcess = value;
            if (_txtProcess != null)
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

    private System.Windows.Forms.GroupBox _GroupBox7;

    internal System.Windows.Forms.GroupBox GroupBox7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox7 != null)
            {
            }

            _GroupBox7 = value;
            if (_GroupBox7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdStop;

    internal System.Windows.Forms.Button cmdStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdStop != null)
            {
            }

            _cmdStop = value;
            if (_cmdStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdPause;

    internal System.Windows.Forms.Button cmdPause
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdPause;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdPause != null)
            {
            }

            _cmdPause = value;
            if (_cmdPause != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdStart;

    internal System.Windows.Forms.Button cmdStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdStart != null)
            {
            }

            _cmdStart = value;
            if (_cmdStart != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdSetStartType;

    internal System.Windows.Forms.Button cmdSetStartType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSetStartType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSetStartType != null)
            {
            }

            _cmdSetStartType = value;
            if (_cmdSetStartType != null)
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

    private System.Windows.Forms.ComboBox _cbStart;

    internal System.Windows.Forms.ComboBox cbStart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbStart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbStart != null)
            {
            }

            _cbStart = value;
            if (_cbStart != null)
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

    private System.Windows.Forms.Button _cmdGoProcess;

    internal System.Windows.Forms.Button cmdGoProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGoProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGoProcess != null)
            {
            }

            _cmdGoProcess = value;
            if (_cmdGoProcess != null)
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

    private System.Windows.Forms.RichTextBox _rtbDescription;

    internal System.Windows.Forms.RichTextBox rtbDescription
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _rtbDescription;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_rtbDescription != null)
            {
            }

            _rtbDescription = value;
            if (_rtbDescription != null)
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

    private System.Windows.Forms.TextBox _txtObjectName;

    internal System.Windows.Forms.TextBox txtObjectName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtObjectName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtObjectName != null)
            {
            }

            _txtObjectName = value;
            if (_txtObjectName != null)
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

    private System.Windows.Forms.TextBox _txtWin32ExitCode;

    internal System.Windows.Forms.TextBox txtWin32ExitCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtWin32ExitCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtWin32ExitCode != null)
            {
            }

            _txtWin32ExitCode = value;
            if (_txtWin32ExitCode != null)
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

    private System.Windows.Forms.TextBox _txtServiceStartName;

    internal System.Windows.Forms.TextBox txtServiceStartName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceStartName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceStartName != null)
            {
            }

            _txtServiceStartName = value;
            if (_txtServiceStartName != null)
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

    private System.Windows.Forms.TextBox _txtLoadOrderGroup;

    internal System.Windows.Forms.TextBox txtLoadOrderGroup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtLoadOrderGroup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtLoadOrderGroup != null)
            {
            }

            _txtLoadOrderGroup = value;
            if (_txtLoadOrderGroup != null)
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

    private System.Windows.Forms.TextBox _txtErrorControl;

    internal System.Windows.Forms.TextBox txtErrorControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtErrorControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtErrorControl != null)
            {
            }

            _txtErrorControl = value;
            if (_txtErrorControl != null)
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

    private System.Windows.Forms.GroupBox _GroupBox4;

    internal System.Windows.Forms.GroupBox GroupBox4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox4 != null)
            {
            }

            _GroupBox4 = value;
            if (_GroupBox4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServiceSpecificExitCode;

    internal System.Windows.Forms.TextBox txtServiceSpecificExitCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceSpecificExitCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceSpecificExitCode != null)
            {
            }

            _txtServiceSpecificExitCode = value;
            if (_txtServiceSpecificExitCode != null)
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

    private System.Windows.Forms.TextBox _txtDiagnosticMessageFile;

    internal System.Windows.Forms.TextBox txtDiagnosticMessageFile
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtDiagnosticMessageFile;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtDiagnosticMessageFile != null)
            {
            }

            _txtDiagnosticMessageFile = value;
            if (_txtDiagnosticMessageFile != null)
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

    private System.Windows.Forms.TextBox _txtCheckPoint;

    internal System.Windows.Forms.TextBox txtCheckPoint
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtCheckPoint;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtCheckPoint != null)
            {
            }

            _txtCheckPoint = value;
            if (_txtCheckPoint != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label18;

    internal System.Windows.Forms.Label Label18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label18 != null)
            {
            }

            _Label18 = value;
            if (_Label18 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtWaitHint;

    internal System.Windows.Forms.TextBox txtWaitHint
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtWaitHint;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtWaitHint != null)
            {
            }

            _txtWaitHint = value;
            if (_txtWaitHint != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label19;

    internal System.Windows.Forms.Label Label19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label19 != null)
            {
            }

            _Label19 = value;
            if (_Label19 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtServiceFlags;

    internal System.Windows.Forms.TextBox txtServiceFlags
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtServiceFlags;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtServiceFlags != null)
            {
            }

            _txtServiceFlags = value;
            if (_txtServiceFlags != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label20;

    internal System.Windows.Forms.Label Label20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label20 != null)
            {
            }

            _Label20 = value;
            if (_Label20 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtTagID;

    internal System.Windows.Forms.TextBox txtTagID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtTagID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtTagID != null)
            {
            }

            _txtTagID = value;
            if (_txtTagID != null)
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

    private System.Windows.Forms.Button _cmdResume;

    internal System.Windows.Forms.Button cmdResume
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdResume;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdResume != null)
            {
            }

            _cmdResume = value;
            if (_cmdResume != null)
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

    private System.Windows.Forms.SplitContainer _SplitContainer3;

    internal System.Windows.Forms.SplitContainer SplitContainer3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer3 != null)
            {
            }

            _SplitContainer3 = value;
            if (_SplitContainer3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.SplitContainer _SplitContainer4;

    internal System.Windows.Forms.SplitContainer SplitContainer4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainer4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainer4 != null)
            {
            }

            _SplitContainer4 = value;
            if (_SplitContainer4 != null)
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

    private System.Windows.Forms.Label _Label21;

    internal System.Windows.Forms.Label Label21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label21 != null)
            {
            }

            _Label21 = value;
            if (_Label21 != null)
            {
            }
        }
    }

    private serviceDependenciesList _tv2;

    internal serviceDependenciesList tv2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tv2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tv2 != null)
            {
            }

            _tv2 = value;
            if (_tv2 != null)
            {
            }
        }
    }

    private serviceDependenciesList _tv;

    internal serviceDependenciesList tv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tv != null)
            {
            }

            _tv = value;
            if (_tv != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdServDet1;

    internal System.Windows.Forms.Button cmdServDet1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdServDet1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdServDet1 != null)
            {
            }

            _cmdServDet1 = value;
            if (_cmdServDet1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdServDet2;

    internal System.Windows.Forms.Button cmdServDet2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdServDet2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdServDet2 != null)
            {
            }

            _cmdServDet2 = value;
            if (_cmdServDet2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtCommand;

    internal System.Windows.Forms.TextBox txtCommand
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtCommand;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtCommand != null)
            {
            }

            _txtCommand = value;
            if (_txtCommand != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label22;

    internal System.Windows.Forms.Label Label22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label22 != null)
            {
            }

            _Label22 = value;
            if (_Label22 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdInspectExe;

    internal System.Windows.Forms.Button cmdInspectExe
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdInspectExe;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdInspectExe != null)
            {
            }

            _cmdInspectExe = value;
            if (_cmdInspectExe != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _menuCopyPctbig;

    private System.Windows.Forms.ContextMenu menuCopyPctbig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuCopyPctbig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuCopyPctbig != null)
            {
            }

            _menuCopyPctbig = value;
            if (_menuCopyPctbig != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyBig;

    internal System.Windows.Forms.MenuItem MenuItemCopyBig
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyBig;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyBig != null)
            {
            }

            _MenuItemCopyBig = value;
            if (_MenuItemCopyBig != null)
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

    private System.Windows.Forms.ContextMenu _menuCopyPctSmall;

    private System.Windows.Forms.ContextMenu menuCopyPctSmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuCopyPctSmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuCopyPctSmall != null)
            {
            }

            _menuCopyPctSmall = value;
            if (_menuCopyPctSmall != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopySmall;

    internal System.Windows.Forms.MenuItem MenuItemCopySmall
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopySmall;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopySmall != null)
            {
            }

            _MenuItemCopySmall = value;
            if (_MenuItemCopySmall != null)
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

    private System.Windows.Forms.Button _cmdDelete;

    internal System.Windows.Forms.Button cmdDelete
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdDelete;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdDelete != null)
            {
            }

            _cmdDelete = value;
            if (_cmdDelete != null)
            {
            }
        }
    }
}

