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
partial class frmSetJobLimits : System.Windows.Forms.Form
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
        this.cmdSetLimits = new System.Windows.Forms.Button();
        this.cmdExit = new System.Windows.Forms.Button();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.chkUIwriteCB = new System.Windows.Forms.CheckBox();
        this.chkUIsystemParam = new System.Windows.Forms.CheckBox();
        this.chkUIreadCB = new System.Windows.Forms.CheckBox();
        this.chkUIhandles = new System.Windows.Forms.CheckBox();
        this.chkUIglobalAtoms = new System.Windows.Forms.CheckBox();
        this.chkUIExitW = new System.Windows.Forms.CheckBox();
        this.chkUIDisplaySettings = new System.Windows.Forms.CheckBox();
        this.chkUIdesktop = new System.Windows.Forms.CheckBox();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.valAffinity = new System.Windows.Forms.NumericUpDown();
        this.Label6 = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.valMaxWS = new System.Windows.Forms.NumericUpDown();
        this.valMinWS = new System.Windows.Forms.NumericUpDown();
        this.valUsertimeP = new System.Windows.Forms.NumericUpDown();
        this.valMemP = new System.Windows.Forms.NumericUpDown();
        this.valUsertimeJ = new System.Windows.Forms.NumericUpDown();
        this.valMemJ = new System.Windows.Forms.NumericUpDown();
        this.chkMinMaxWS = new System.Windows.Forms.CheckBox();
        this.chkCommittedMemPerP = new System.Windows.Forms.CheckBox();
        this.chkUserModePerP = new System.Windows.Forms.CheckBox();
        this.chkCommittedMemPerJ = new System.Windows.Forms.CheckBox();
        this.chkUserModePerJ = new System.Windows.Forms.CheckBox();
        this.cbPriority = new System.Windows.Forms.ComboBox();
        this.chkPriority = new System.Windows.Forms.CheckBox();
        this.valScheduling = new System.Windows.Forms.NumericUpDown();
        this.valActiveProcesses = new System.Windows.Forms.NumericUpDown();
        this.chkSchedulingC = new System.Windows.Forms.CheckBox();
        this.chkActiveProcesses = new System.Windows.Forms.CheckBox();
        this.chkAffinity = new System.Windows.Forms.CheckBox();
        this.chkSilentBAOK = new System.Windows.Forms.CheckBox();
        this.chkPreserveJobTime = new System.Windows.Forms.CheckBox();
        this.chkKillOnJobClose = new System.Windows.Forms.CheckBox();
        this.chkDieOnUnhandledEx = new System.Windows.Forms.CheckBox();
        this.chkBreakawayOK = new System.Windows.Forms.CheckBox();
        this.GroupBox1.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.valAffinity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valMaxWS).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valMinWS).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valUsertimeP).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valMemP).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valUsertimeJ).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valMemJ).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valScheduling).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.valActiveProcesses).BeginInit();
        this.SuspendLayout();
        // 
        // cmdSetLimits
        // 
        this.cmdSetLimits.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdSetLimits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdSetLimits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSetLimits.Location = new System.Drawing.Point(185, 392);
        this.cmdSetLimits.Name = "cmdSetLimits";
        this.cmdSetLimits.Size = new System.Drawing.Size(148, 23);
        this.cmdSetLimits.TabIndex = 32;
        this.cmdSetLimits.Text = "Set limits";
        this.cmdSetLimits.UseVisualStyleBackColor = true;
        // 
        // cmdExit
        // 
        this.cmdExit.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.cmdExit.Location = new System.Drawing.Point(438, 392);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(75, 23);
        this.cmdExit.TabIndex = 33;
        this.cmdExit.Text = "Exit";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.chkUIwriteCB);
        this.GroupBox1.Controls.Add(this.chkUIsystemParam);
        this.GroupBox1.Controls.Add(this.chkUIreadCB);
        this.GroupBox1.Controls.Add(this.chkUIhandles);
        this.GroupBox1.Controls.Add(this.chkUIglobalAtoms);
        this.GroupBox1.Controls.Add(this.chkUIExitW);
        this.GroupBox1.Controls.Add(this.chkUIDisplaySettings);
        this.GroupBox1.Controls.Add(this.chkUIdesktop);
        this.GroupBox1.Location = new System.Drawing.Point(12, 10);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(167, 205);
        this.GroupBox1.TabIndex = 31;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "UI restrictions";
        // 
        // chkUIwriteCB
        // 
        this.chkUIwriteCB.AutoSize = true;
        this.chkUIwriteCB.Location = new System.Drawing.Point(6, 182);
        this.chkUIwriteCB.Name = "chkUIwriteCB";
        this.chkUIwriteCB.Size = new System.Drawing.Size(105, 17);
        this.chkUIwriteCB.TabIndex = 7;
        this.chkUIwriteCB.Text = "WriteClipboard";
        this.chkUIwriteCB.UseVisualStyleBackColor = true;
        // 
        // chkUIsystemParam
        // 
        this.chkUIsystemParam.AutoSize = true;
        this.chkUIsystemParam.Location = new System.Drawing.Point(6, 159);
        this.chkUIsystemParam.Name = "chkUIsystemParam";
        this.chkUIsystemParam.Size = new System.Drawing.Size(117, 17);
        this.chkUIsystemParam.TabIndex = 6;
        this.chkUIsystemParam.Text = "SystemParameters";
        this.chkUIsystemParam.UseVisualStyleBackColor = true;
        // 
        // chkUIreadCB
        // 
        this.chkUIreadCB.AutoSize = true;
        this.chkUIreadCB.Location = new System.Drawing.Point(6, 136);
        this.chkUIreadCB.Name = "chkUIreadCB";
        this.chkUIreadCB.Size = new System.Drawing.Size(103, 17);
        this.chkUIreadCB.TabIndex = 5;
        this.chkUIreadCB.Text = "ReadClipboard";
        this.chkUIreadCB.UseVisualStyleBackColor = true;
        // 
        // chkUIhandles
        // 
        this.chkUIhandles.AutoSize = true;
        this.chkUIhandles.Location = new System.Drawing.Point(6, 113);
        this.chkUIhandles.Name = "chkUIhandles";
        this.chkUIhandles.Size = new System.Drawing.Size(68, 17);
        this.chkUIhandles.TabIndex = 4;
        this.chkUIhandles.Text = "Handles";
        this.chkUIhandles.UseVisualStyleBackColor = true;
        // 
        // chkUIglobalAtoms
        // 
        this.chkUIglobalAtoms.AutoSize = true;
        this.chkUIglobalAtoms.Location = new System.Drawing.Point(6, 90);
        this.chkUIglobalAtoms.Name = "chkUIglobalAtoms";
        this.chkUIglobalAtoms.Size = new System.Drawing.Size(92, 17);
        this.chkUIglobalAtoms.TabIndex = 3;
        this.chkUIglobalAtoms.Text = "GlobalAtoms";
        this.chkUIglobalAtoms.UseVisualStyleBackColor = true;
        // 
        // chkUIExitW
        // 
        this.chkUIExitW.AutoSize = true;
        this.chkUIExitW.Location = new System.Drawing.Point(6, 67);
        this.chkUIExitW.Name = "chkUIExitW";
        this.chkUIExitW.Size = new System.Drawing.Size(93, 17);
        this.chkUIExitW.TabIndex = 2;
        this.chkUIExitW.Text = "ExitWindows";
        this.chkUIExitW.UseVisualStyleBackColor = true;
        // 
        // chkUIDisplaySettings
        // 
        this.chkUIDisplaySettings.AutoSize = true;
        this.chkUIDisplaySettings.Location = new System.Drawing.Point(6, 44);
        this.chkUIDisplaySettings.Name = "chkUIDisplaySettings";
        this.chkUIDisplaySettings.Size = new System.Drawing.Size(105, 17);
        this.chkUIDisplaySettings.TabIndex = 1;
        this.chkUIDisplaySettings.Text = "DisplaySettings";
        this.chkUIDisplaySettings.UseVisualStyleBackColor = true;
        // 
        // chkUIdesktop
        // 
        this.chkUIdesktop.AutoSize = true;
        this.chkUIdesktop.Location = new System.Drawing.Point(6, 21);
        this.chkUIdesktop.Name = "chkUIdesktop";
        this.chkUIdesktop.Size = new System.Drawing.Size(69, 17);
        this.chkUIdesktop.TabIndex = 0;
        this.chkUIdesktop.Text = "Desktop";
        this.chkUIdesktop.UseVisualStyleBackColor = true;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.valAffinity);
        this.GroupBox2.Controls.Add(this.Label6);
        this.GroupBox2.Controls.Add(this.Label5);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.Label3);
        this.GroupBox2.Controls.Add(this.Label2);
        this.GroupBox2.Controls.Add(this.Label1);
        this.GroupBox2.Controls.Add(this.valMaxWS);
        this.GroupBox2.Controls.Add(this.valMinWS);
        this.GroupBox2.Controls.Add(this.valUsertimeP);
        this.GroupBox2.Controls.Add(this.valMemP);
        this.GroupBox2.Controls.Add(this.valUsertimeJ);
        this.GroupBox2.Controls.Add(this.valMemJ);
        this.GroupBox2.Controls.Add(this.chkMinMaxWS);
        this.GroupBox2.Controls.Add(this.chkCommittedMemPerP);
        this.GroupBox2.Controls.Add(this.chkUserModePerP);
        this.GroupBox2.Controls.Add(this.chkCommittedMemPerJ);
        this.GroupBox2.Controls.Add(this.chkUserModePerJ);
        this.GroupBox2.Controls.Add(this.cbPriority);
        this.GroupBox2.Controls.Add(this.chkPriority);
        this.GroupBox2.Controls.Add(this.valScheduling);
        this.GroupBox2.Controls.Add(this.valActiveProcesses);
        this.GroupBox2.Controls.Add(this.chkSchedulingC);
        this.GroupBox2.Controls.Add(this.chkActiveProcesses);
        this.GroupBox2.Controls.Add(this.chkAffinity);
        this.GroupBox2.Controls.Add(this.chkSilentBAOK);
        this.GroupBox2.Controls.Add(this.chkPreserveJobTime);
        this.GroupBox2.Controls.Add(this.chkKillOnJobClose);
        this.GroupBox2.Controls.Add(this.chkDieOnUnhandledEx);
        this.GroupBox2.Controls.Add(this.chkBreakawayOK);
        this.GroupBox2.Location = new System.Drawing.Point(185, 12);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(328, 374);
        this.GroupBox2.TabIndex = 32;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "UI restrictions";
        // 
        // valAffinity
        // 
        this.valAffinity.Enabled = false;
        this.valAffinity.Location = new System.Drawing.Point(169, 134);
        this.valAffinity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        this.valAffinity.Name = "valAffinity";
        this.valAffinity.Size = new System.Drawing.Size(105, 22);
        this.valAffinity.TabIndex = 14;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(251, 298);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(72, 13);
        this.Label6.TabIndex = 60;
        this.Label6.Text = "100-nanosec";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(251, 253);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(72, 13);
        this.Label5.TabIndex = 59;
        this.Label5.Text = "100-nanosec";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(251, 276);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(20, 13);
        this.Label4.TabIndex = 58;
        this.Label4.Text = "KB";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(251, 321);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(20, 13);
        this.Label3.TabIndex = 57;
        this.Label3.Text = "KB";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(251, 344);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(20, 13);
        this.Label2.TabIndex = 56;
        this.Label2.Text = "KB";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(251, 232);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(20, 13);
        this.Label1.TabIndex = 55;
        this.Label1.Text = "KB";
        // 
        // valMaxWS
        // 
        this.valMaxWS.Enabled = false;
        this.valMaxWS.Location = new System.Drawing.Point(169, 342);
        this.valMaxWS.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        this.valMaxWS.Name = "valMaxWS";
        this.valMaxWS.Size = new System.Drawing.Size(76, 22);
        this.valMaxWS.TabIndex = 31;
        // 
        // valMinWS
        // 
        this.valMinWS.Enabled = false;
        this.valMinWS.Location = new System.Drawing.Point(169, 319);
        this.valMinWS.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        this.valMinWS.Name = "valMinWS";
        this.valMinWS.Size = new System.Drawing.Size(76, 22);
        this.valMinWS.TabIndex = 30;
        // 
        // valUsertimeP
        // 
        this.valUsertimeP.Enabled = false;
        this.valUsertimeP.Location = new System.Drawing.Point(169, 296);
        this.valUsertimeP.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
        this.valUsertimeP.Name = "valUsertimeP";
        this.valUsertimeP.Size = new System.Drawing.Size(76, 22);
        this.valUsertimeP.TabIndex = 28;
        // 
        // valMemP
        // 
        this.valMemP.Enabled = false;
        this.valMemP.Location = new System.Drawing.Point(169, 274);
        this.valMemP.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        this.valMemP.Name = "valMemP";
        this.valMemP.Size = new System.Drawing.Size(76, 22);
        this.valMemP.TabIndex = 26;
        // 
        // valUsertimeJ
        // 
        this.valUsertimeJ.Enabled = false;
        this.valUsertimeJ.Location = new System.Drawing.Point(169, 251);
        this.valUsertimeJ.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
        this.valUsertimeJ.Name = "valUsertimeJ";
        this.valUsertimeJ.Size = new System.Drawing.Size(76, 22);
        this.valUsertimeJ.TabIndex = 24;
        // 
        // valMemJ
        // 
        this.valMemJ.Enabled = false;
        this.valMemJ.Location = new System.Drawing.Point(169, 226);
        this.valMemJ.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        this.valMemJ.Name = "valMemJ";
        this.valMemJ.Size = new System.Drawing.Size(76, 22);
        this.valMemJ.TabIndex = 22;
        // 
        // chkMinMaxWS
        // 
        this.chkMinMaxWS.AutoSize = true;
        this.chkMinMaxWS.Location = new System.Drawing.Point(6, 319);
        this.chkMinMaxWS.Name = "chkMinMaxWS";
        this.chkMinMaxWS.Size = new System.Drawing.Size(112, 30);
        this.chkMinMaxWS.TabIndex = 29;
        this.chkMinMaxWS.Text = "Min and max WS" + (char)13 + (char)10 + "size / process";
        this.chkMinMaxWS.UseVisualStyleBackColor = true;
        // 
        // chkCommittedMemPerP
        // 
        this.chkCommittedMemPerP.AutoSize = true;
        this.chkCommittedMemPerP.Location = new System.Drawing.Point(6, 274);
        this.chkCommittedMemPerP.Name = "chkCommittedMemPerP";
        this.chkCommittedMemPerP.Size = new System.Drawing.Size(158, 17);
        this.chkCommittedMemPerP.TabIndex = 25;
        this.chkCommittedMemPerP.Text = "Committed mem / process";
        this.chkCommittedMemPerP.UseVisualStyleBackColor = true;
        // 
        // chkUserModePerP
        // 
        this.chkUserModePerP.AutoSize = true;
        this.chkUserModePerP.Location = new System.Drawing.Point(6, 297);
        this.chkUserModePerP.Name = "chkUserModePerP";
        this.chkUserModePerP.Size = new System.Drawing.Size(152, 17);
        this.chkUserModePerP.TabIndex = 27;
        this.chkUserModePerP.Text = "Usermode time / process";
        this.chkUserModePerP.UseVisualStyleBackColor = true;
        // 
        // chkCommittedMemPerJ
        // 
        this.chkCommittedMemPerJ.AutoSize = true;
        this.chkCommittedMemPerJ.Location = new System.Drawing.Point(6, 228);
        this.chkCommittedMemPerJ.Name = "chkCommittedMemPerJ";
        this.chkCommittedMemPerJ.Size = new System.Drawing.Size(147, 17);
        this.chkCommittedMemPerJ.TabIndex = 21;
        this.chkCommittedMemPerJ.Text = "Committed mem for job";
        this.chkCommittedMemPerJ.UseVisualStyleBackColor = true;
        // 
        // chkUserModePerJ
        // 
        this.chkUserModePerJ.AutoSize = true;
        this.chkUserModePerJ.Location = new System.Drawing.Point(6, 251);
        this.chkUserModePerJ.Name = "chkUserModePerJ";
        this.chkUserModePerJ.Size = new System.Drawing.Size(141, 17);
        this.chkUserModePerJ.TabIndex = 23;
        this.chkUserModePerJ.Text = "Usermode time for job";
        this.chkUserModePerJ.UseVisualStyleBackColor = true;
        // 
        // cbPriority
        // 
        this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbPriority.Enabled = false;
        this.cbPriority.FormattingEnabled = true;
        this.cbPriority.Items.AddRange(new object[] { "Idle", "BelowNormal", "Normal", "AboveNormal", "High", "RealTime" });
        this.cbPriority.Location = new System.Drawing.Point(169, 204);
        this.cbPriority.Name = "cbPriority";
        this.cbPriority.Size = new System.Drawing.Size(105, 21);
        this.cbPriority.TabIndex = 20;
        // 
        // chkPriority
        // 
        this.chkPriority.AutoSize = true;
        this.chkPriority.Location = new System.Drawing.Point(6, 205);
        this.chkPriority.Name = "chkPriority";
        this.chkPriority.Size = new System.Drawing.Size(88, 17);
        this.chkPriority.TabIndex = 19;
        this.chkPriority.Text = "PriorityClass";
        this.chkPriority.UseVisualStyleBackColor = true;
        // 
        // valScheduling
        // 
        this.valScheduling.Enabled = false;
        this.valScheduling.Location = new System.Drawing.Point(169, 181);
        this.valScheduling.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        this.valScheduling.Name = "valScheduling";
        this.valScheduling.Size = new System.Drawing.Size(105, 22);
        this.valScheduling.TabIndex = 18;
        // 
        // valActiveProcesses
        // 
        this.valActiveProcesses.Enabled = false;
        this.valActiveProcesses.Location = new System.Drawing.Point(169, 157);
        this.valActiveProcesses.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        this.valActiveProcesses.Name = "valActiveProcesses";
        this.valActiveProcesses.Size = new System.Drawing.Size(105, 22);
        this.valActiveProcesses.TabIndex = 16;
        // 
        // chkSchedulingC
        // 
        this.chkSchedulingC.AutoSize = true;
        this.chkSchedulingC.Location = new System.Drawing.Point(6, 182);
        this.chkSchedulingC.Name = "chkSchedulingC";
        this.chkSchedulingC.Size = new System.Drawing.Size(110, 17);
        this.chkSchedulingC.TabIndex = 17;
        this.chkSchedulingC.Text = "SchedulingClass";
        this.chkSchedulingC.UseVisualStyleBackColor = true;
        // 
        // chkActiveProcesses
        // 
        this.chkActiveProcesses.AutoSize = true;
        this.chkActiveProcesses.Location = new System.Drawing.Point(6, 159);
        this.chkActiveProcesses.Name = "chkActiveProcesses";
        this.chkActiveProcesses.Size = new System.Drawing.Size(109, 17);
        this.chkActiveProcesses.TabIndex = 15;
        this.chkActiveProcesses.Text = "Active processes";
        this.chkActiveProcesses.UseVisualStyleBackColor = true;
        // 
        // chkAffinity
        // 
        this.chkAffinity.AutoSize = true;
        this.chkAffinity.Location = new System.Drawing.Point(6, 136);
        this.chkAffinity.Name = "chkAffinity";
        this.chkAffinity.Size = new System.Drawing.Size(63, 17);
        this.chkAffinity.TabIndex = 13;
        this.chkAffinity.Text = "Affinity";
        this.chkAffinity.UseVisualStyleBackColor = true;
        // 
        // chkSilentBAOK
        // 
        this.chkSilentBAOK.AutoSize = true;
        this.chkSilentBAOK.Location = new System.Drawing.Point(6, 113);
        this.chkSilentBAOK.Name = "chkSilentBAOK";
        this.chkSilentBAOK.Size = new System.Drawing.Size(125, 17);
        this.chkSilentBAOK.TabIndex = 12;
        this.chkSilentBAOK.Text = "SilentBreakawayOk";
        this.chkSilentBAOK.UseVisualStyleBackColor = true;
        // 
        // chkPreserveJobTime
        // 
        this.chkPreserveJobTime.AutoSize = true;
        this.chkPreserveJobTime.Location = new System.Drawing.Point(6, 90);
        this.chkPreserveJobTime.Name = "chkPreserveJobTime";
        this.chkPreserveJobTime.Size = new System.Drawing.Size(109, 17);
        this.chkPreserveJobTime.TabIndex = 11;
        this.chkPreserveJobTime.Text = "PreserveJobTime";
        this.chkPreserveJobTime.UseVisualStyleBackColor = true;
        // 
        // chkKillOnJobClose
        // 
        this.chkKillOnJobClose.AutoSize = true;
        this.chkKillOnJobClose.Location = new System.Drawing.Point(6, 67);
        this.chkKillOnJobClose.Name = "chkKillOnJobClose";
        this.chkKillOnJobClose.Size = new System.Drawing.Size(103, 17);
        this.chkKillOnJobClose.TabIndex = 10;
        this.chkKillOnJobClose.Text = "KillOnJobClose";
        this.chkKillOnJobClose.UseVisualStyleBackColor = true;
        // 
        // chkDieOnUnhandledEx
        // 
        this.chkDieOnUnhandledEx.AutoSize = true;
        this.chkDieOnUnhandledEx.Location = new System.Drawing.Point(6, 44);
        this.chkDieOnUnhandledEx.Name = "chkDieOnUnhandledEx";
        this.chkDieOnUnhandledEx.Size = new System.Drawing.Size(167, 17);
        this.chkDieOnUnhandledEx.TabIndex = 9;
        this.chkDieOnUnhandledEx.Text = "DieOnUnhandledException";
        this.chkDieOnUnhandledEx.UseVisualStyleBackColor = true;
        // 
        // chkBreakawayOK
        // 
        this.chkBreakawayOK.AutoSize = true;
        this.chkBreakawayOK.Location = new System.Drawing.Point(6, 21);
        this.chkBreakawayOK.Name = "chkBreakawayOK";
        this.chkBreakawayOK.Size = new System.Drawing.Size(96, 17);
        this.chkBreakawayOK.TabIndex = 8;
        this.chkBreakawayOK.Text = "BreakawayOK";
        this.chkBreakawayOK.UseVisualStyleBackColor = true;
        // 
        // frmSetJobLimits
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(525, 427);
        this.Controls.Add(this.GroupBox2);
        this.Controls.Add(this.GroupBox1);
        this.Controls.Add(this.cmdExit);
        this.Controls.Add(this.cmdSetLimits);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "frmSetJobLimits";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Set job limits";
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.valAffinity).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valMaxWS).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valMinWS).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valUsertimeP).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valMemP).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valUsertimeJ).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valMemJ).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valScheduling).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.valActiveProcesses).EndInit();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Button _cmdSetLimits;

    internal System.Windows.Forms.Button cmdSetLimits
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSetLimits;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSetLimits != null)
            {
            }

            _cmdSetLimits = value;
            if (_cmdSetLimits != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdExit;

    internal System.Windows.Forms.Button cmdExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdExit != null)
            {
            }

            _cmdExit = value;
            if (_cmdExit != null)
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

    private System.Windows.Forms.CheckBox _chkUIwriteCB;

    internal System.Windows.Forms.CheckBox chkUIwriteCB
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIwriteCB;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIwriteCB != null)
            {
            }

            _chkUIwriteCB = value;
            if (_chkUIwriteCB != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIsystemParam;

    internal System.Windows.Forms.CheckBox chkUIsystemParam
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIsystemParam;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIsystemParam != null)
            {
            }

            _chkUIsystemParam = value;
            if (_chkUIsystemParam != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIreadCB;

    internal System.Windows.Forms.CheckBox chkUIreadCB
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIreadCB;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIreadCB != null)
            {
            }

            _chkUIreadCB = value;
            if (_chkUIreadCB != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIhandles;

    internal System.Windows.Forms.CheckBox chkUIhandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIhandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIhandles != null)
            {
            }

            _chkUIhandles = value;
            if (_chkUIhandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIglobalAtoms;

    internal System.Windows.Forms.CheckBox chkUIglobalAtoms
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIglobalAtoms;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIglobalAtoms != null)
            {
            }

            _chkUIglobalAtoms = value;
            if (_chkUIglobalAtoms != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIExitW;

    internal System.Windows.Forms.CheckBox chkUIExitW
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIExitW;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIExitW != null)
            {
            }

            _chkUIExitW = value;
            if (_chkUIExitW != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIDisplaySettings;

    internal System.Windows.Forms.CheckBox chkUIDisplaySettings
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIDisplaySettings;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIDisplaySettings != null)
            {
            }

            _chkUIDisplaySettings = value;
            if (_chkUIDisplaySettings != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUIdesktop;

    internal System.Windows.Forms.CheckBox chkUIdesktop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUIdesktop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUIdesktop != null)
            {
            }

            _chkUIdesktop = value;
            if (_chkUIdesktop != null)
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

    private System.Windows.Forms.CheckBox _chkSchedulingC;

    internal System.Windows.Forms.CheckBox chkSchedulingC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSchedulingC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSchedulingC != null)
            {
            }

            _chkSchedulingC = value;
            if (_chkSchedulingC != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkActiveProcesses;

    internal System.Windows.Forms.CheckBox chkActiveProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkActiveProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkActiveProcesses != null)
            {
            }

            _chkActiveProcesses = value;
            if (_chkActiveProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkAffinity;

    internal System.Windows.Forms.CheckBox chkAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkAffinity != null)
            {
            }

            _chkAffinity = value;
            if (_chkAffinity != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkSilentBAOK;

    internal System.Windows.Forms.CheckBox chkSilentBAOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkSilentBAOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkSilentBAOK != null)
            {
            }

            _chkSilentBAOK = value;
            if (_chkSilentBAOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkPreserveJobTime;

    internal System.Windows.Forms.CheckBox chkPreserveJobTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkPreserveJobTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkPreserveJobTime != null)
            {
            }

            _chkPreserveJobTime = value;
            if (_chkPreserveJobTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkKillOnJobClose;

    internal System.Windows.Forms.CheckBox chkKillOnJobClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkKillOnJobClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkKillOnJobClose != null)
            {
            }

            _chkKillOnJobClose = value;
            if (_chkKillOnJobClose != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkDieOnUnhandledEx;

    internal System.Windows.Forms.CheckBox chkDieOnUnhandledEx
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkDieOnUnhandledEx;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkDieOnUnhandledEx != null)
            {
            }

            _chkDieOnUnhandledEx = value;
            if (_chkDieOnUnhandledEx != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkBreakawayOK;

    internal System.Windows.Forms.CheckBox chkBreakawayOK
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkBreakawayOK;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkBreakawayOK != null)
            {
            }

            _chkBreakawayOK = value;
            if (_chkBreakawayOK != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkPriority;

    internal System.Windows.Forms.CheckBox chkPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkPriority != null)
            {
            }

            _chkPriority = value;
            if (_chkPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valScheduling;

    internal System.Windows.Forms.NumericUpDown valScheduling
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valScheduling;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valScheduling != null)
            {
            }

            _valScheduling = value;
            if (_valScheduling != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valActiveProcesses;

    internal System.Windows.Forms.NumericUpDown valActiveProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valActiveProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valActiveProcesses != null)
            {
            }

            _valActiveProcesses = value;
            if (_valActiveProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCommittedMemPerJ;

    internal System.Windows.Forms.CheckBox chkCommittedMemPerJ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCommittedMemPerJ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCommittedMemPerJ != null)
            {
            }

            _chkCommittedMemPerJ = value;
            if (_chkCommittedMemPerJ != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUserModePerJ;

    internal System.Windows.Forms.CheckBox chkUserModePerJ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUserModePerJ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUserModePerJ != null)
            {
            }

            _chkUserModePerJ = value;
            if (_chkUserModePerJ != null)
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

    private System.Windows.Forms.NumericUpDown _valMaxWS;

    internal System.Windows.Forms.NumericUpDown valMaxWS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valMaxWS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valMaxWS != null)
            {
            }

            _valMaxWS = value;
            if (_valMaxWS != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valMinWS;

    internal System.Windows.Forms.NumericUpDown valMinWS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valMinWS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valMinWS != null)
            {
            }

            _valMinWS = value;
            if (_valMinWS != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valUsertimeP;

    internal System.Windows.Forms.NumericUpDown valUsertimeP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valUsertimeP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valUsertimeP != null)
            {
            }

            _valUsertimeP = value;
            if (_valUsertimeP != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valMemP;

    internal System.Windows.Forms.NumericUpDown valMemP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valMemP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valMemP != null)
            {
            }

            _valMemP = value;
            if (_valMemP != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valUsertimeJ;

    internal System.Windows.Forms.NumericUpDown valUsertimeJ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valUsertimeJ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valUsertimeJ != null)
            {
            }

            _valUsertimeJ = value;
            if (_valUsertimeJ != null)
            {
            }
        }
    }

    private System.Windows.Forms.NumericUpDown _valMemJ;

    internal System.Windows.Forms.NumericUpDown valMemJ
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valMemJ;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valMemJ != null)
            {
            }

            _valMemJ = value;
            if (_valMemJ != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkMinMaxWS;

    internal System.Windows.Forms.CheckBox chkMinMaxWS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkMinMaxWS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkMinMaxWS != null)
            {
            }

            _chkMinMaxWS = value;
            if (_chkMinMaxWS != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCommittedMemPerP;

    internal System.Windows.Forms.CheckBox chkCommittedMemPerP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCommittedMemPerP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCommittedMemPerP != null)
            {
            }

            _chkCommittedMemPerP = value;
            if (_chkCommittedMemPerP != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkUserModePerP;

    internal System.Windows.Forms.CheckBox chkUserModePerP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkUserModePerP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkUserModePerP != null)
            {
            }

            _chkUserModePerP = value;
            if (_chkUserModePerP != null)
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

    private System.Windows.Forms.NumericUpDown _valAffinity;

    internal System.Windows.Forms.NumericUpDown valAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _valAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_valAffinity != null)
            {
            }

            _valAffinity = value;
            if (_valAffinity != null)
            {
            }
        }
    }
}

