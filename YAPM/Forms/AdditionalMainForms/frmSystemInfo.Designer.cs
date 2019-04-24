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
partial class frmSystemInfo : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemInfo));
        this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        this.mainSplit = new System.Windows.Forms.SplitContainer();
        this.chkOneGraphPerCpu = new System.Windows.Forms.CheckBox();
        this.GroupBox8 = new System.Windows.Forms.GroupBox();
        this.lblKnpf = new System.Windows.Forms.Label();
        this.Label49 = new System.Windows.Forms.Label();
        this.lblKnpa = new System.Windows.Forms.Label();
        this.Label35 = new System.Windows.Forms.Label();
        this.lblKnpu = new System.Windows.Forms.Label();
        this.Label39 = new System.Windows.Forms.Label();
        this.lblKpf = new System.Windows.Forms.Label();
        this.Label41 = new System.Windows.Forms.Label();
        this.lblKpa = new System.Windows.Forms.Label();
        this.Label43 = new System.Windows.Forms.Label();
        this.lblKpp = new System.Windows.Forms.Label();
        this.Label47 = new System.Windows.Forms.Label();
        this.GroupBox7 = new System.Windows.Forms.GroupBox();
        this.lblCPUUsage = new System.Windows.Forms.Label();
        this.Label40 = new System.Windows.Forms.Label();
        this.lblCPUTotalTime = new System.Windows.Forms.Label();
        this.Label37 = new System.Windows.Forms.Label();
        this.lblCPUdpcTime = new System.Windows.Forms.Label();
        this.Label29 = new System.Windows.Forms.Label();
        this.lblCPUidleTime = new System.Windows.Forms.Label();
        this.Label23 = new System.Windows.Forms.Label();
        this.lblCPUuserTime = new System.Windows.Forms.Label();
        this.Label33 = new System.Windows.Forms.Label();
        this.lblCPUkernelTime = new System.Windows.Forms.Label();
        this.Label36 = new System.Windows.Forms.Label();
        this.lblCPUinterruptTime = new System.Windows.Forms.Label();
        this.Label38 = new System.Windows.Forms.Label();
        this.lblCPUcontextSwitches = new System.Windows.Forms.Label();
        this.Label34 = new System.Windows.Forms.Label();
        this.lblCPUsystemCalls = new System.Windows.Forms.Label();
        this.Label19 = new System.Windows.Forms.Label();
        this.lblCPUinterrupts = new System.Windows.Forms.Label();
        this.Label27 = new System.Windows.Forms.Label();
        this.lblCPUprocessors = new System.Windows.Forms.Label();
        this.Label31 = new System.Windows.Forms.Label();
        this.GroupBox6 = new System.Windows.Forms.GroupBox();
        this.lblPFcache = new System.Windows.Forms.Label();
        this.Label15 = new System.Windows.Forms.Label();
        this.lblPFdemandZero = new System.Windows.Forms.Label();
        this.Label21 = new System.Windows.Forms.Label();
        this.lblPFcacheTransition = new System.Windows.Forms.Label();
        this.Label25 = new System.Windows.Forms.Label();
        this.lblPFtransition = new System.Windows.Forms.Label();
        this.Label28 = new System.Windows.Forms.Label();
        this.lblPFcopyOnWrite = new System.Windows.Forms.Label();
        this.Label30 = new System.Windows.Forms.Label();
        this.lblPFtotal = new System.Windows.Forms.Label();
        this.Label32 = new System.Windows.Forms.Label();
        this.GroupBox5 = new System.Windows.Forms.GroupBox();
        this.lblIOotherBytes = new System.Windows.Forms.Label();
        this.Label26 = new System.Windows.Forms.Label();
        this.lblIOothers = new System.Windows.Forms.Label();
        this.Label10 = new System.Windows.Forms.Label();
        this.lblIOwriteBytes = new System.Windows.Forms.Label();
        this.Label18 = new System.Windows.Forms.Label();
        this.lblIOwrites = new System.Windows.Forms.Label();
        this.Label20 = new System.Windows.Forms.Label();
        this.lblIOreadBytes = new System.Windows.Forms.Label();
        this.Label22 = new System.Windows.Forms.Label();
        this.lblIOreads = new System.Windows.Forms.Label();
        this.Label24 = new System.Windows.Forms.Label();
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.lblPMT = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.lblPMU = new System.Windows.Forms.Label();
        this.Label13 = new System.Windows.Forms.Label();
        this.lblPMF = new System.Windows.Forms.Label();
        this.Label17 = new System.Windows.Forms.Label();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.lblCCL = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.lblCCP = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.lblCCC = new System.Windows.Forms.Label();
        this.Label11 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.lblHandles = new System.Windows.Forms.Label();
        this.Label12 = new System.Windows.Forms.Label();
        this.lblThreads = new System.Windows.Forms.Label();
        this.Label14 = new System.Windows.Forms.Label();
        this.lblProcesses = new System.Windows.Forms.Label();
        this.Label16 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.lblCacheErrors = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblCacheMaximum = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.lblCacheMinimum = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.lblCachePeak = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.lblCacheCurrent = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
        this.chkTopMost = new System.Windows.Forms.CheckBox();
        this.g2 = new Graph2();
        this.g3 = new Graph2();
        this.g4 = new Graph2();
        this.mainSplit.Panel1.SuspendLayout();
        this.mainSplit.Panel2.SuspendLayout();
        this.mainSplit.SuspendLayout();
        this.GroupBox8.SuspendLayout();
        this.GroupBox7.SuspendLayout();
        this.GroupBox6.SuspendLayout();
        this.GroupBox5.SuspendLayout();
        this.GroupBox4.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.SplitContainer2.Panel1.SuspendLayout();
        this.SplitContainer2.Panel2.SuspendLayout();
        this.SplitContainer2.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.SplitContainer3.Panel1.SuspendLayout();
        this.SplitContainer3.Panel2.SuspendLayout();
        this.SplitContainer3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.g2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.g3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.g4).BeginInit();
        this.SuspendLayout();
        // 
        // timerRefresh
        // 
        this.timerRefresh.Enabled = true;
        this.timerRefresh.Interval = 1000;
        // 
        // mainSplit
        // 
        this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
        this.mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.mainSplit.IsSplitterFixed = true;
        this.mainSplit.Location = new System.Drawing.Point(0, 0);
        this.mainSplit.Name = "mainSplit";
        // 
        // mainSplit.Panel1
        // 
        this.mainSplit.Panel1.Controls.Add(this.chkTopMost);
        this.mainSplit.Panel1.Controls.Add(this.chkOneGraphPerCpu);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox8);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox7);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox6);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox5);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox4);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox3);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox2);
        this.mainSplit.Panel1.Controls.Add(this.GroupBox1);
        // 
        // mainSplit.Panel2
        // 
        this.mainSplit.Panel2.Controls.Add(this.SplitContainer2);
        this.mainSplit.Size = new System.Drawing.Size(735, 477);
        this.mainSplit.SplitterDistance = 425;
        this.mainSplit.TabIndex = 11;
        // 
        // chkOneGraphPerCpu
        // 
        this.chkOneGraphPerCpu.AutoSize = true;
        this.chkOneGraphPerCpu.Location = new System.Drawing.Point(168, 448);
        this.chkOneGraphPerCpu.Name = "chkOneGraphPerCpu";
        this.chkOneGraphPerCpu.Size = new System.Drawing.Size(124, 17);
        this.chkOneGraphPerCpu.TabIndex = 16;
        this.chkOneGraphPerCpu.Text = "One graph per cpu";
        this.chkOneGraphPerCpu.UseVisualStyleBackColor = true;
        // 
        // GroupBox8
        // 
        this.GroupBox8.Controls.Add(this.lblKnpf);
        this.GroupBox8.Controls.Add(this.Label49);
        this.GroupBox8.Controls.Add(this.lblKnpa);
        this.GroupBox8.Controls.Add(this.Label35);
        this.GroupBox8.Controls.Add(this.lblKnpu);
        this.GroupBox8.Controls.Add(this.Label39);
        this.GroupBox8.Controls.Add(this.lblKpf);
        this.GroupBox8.Controls.Add(this.Label41);
        this.GroupBox8.Controls.Add(this.lblKpa);
        this.GroupBox8.Controls.Add(this.Label43);
        this.GroupBox8.Controls.Add(this.lblKpp);
        this.GroupBox8.Controls.Add(this.Label47);
        this.GroupBox8.Location = new System.Drawing.Point(158, 317);
        this.GroupBox8.Name = "GroupBox8";
        this.GroupBox8.Size = new System.Drawing.Size(259, 125);
        this.GroupBox8.TabIndex = 15;
        this.GroupBox8.TabStop = false;
        this.GroupBox8.Text = "Kernel pools";
        // 
        // lblKnpf
        // 
        this.lblKnpf.AutoSize = true;
        this.lblKnpf.Location = new System.Drawing.Point(121, 98);
        this.lblKnpf.Name = "lblKnpf";
        this.lblKnpf.Size = new System.Drawing.Size(13, 13);
        this.lblKnpf.TabIndex = 13;
        this.lblKnpf.Text = "0";
        // 
        // Label49
        // 
        this.Label49.AutoSize = true;
        this.Label49.Location = new System.Drawing.Point(15, 98);
        this.Label49.Name = "Label49";
        this.Label49.Size = new System.Drawing.Size(94, 13);
        this.Label49.TabIndex = 12;
        this.Label49.Text = "Non-paged frees";
        // 
        // lblKnpa
        // 
        this.lblKnpa.AutoSize = true;
        this.lblKnpa.Location = new System.Drawing.Point(121, 83);
        this.lblKnpa.Name = "lblKnpa";
        this.lblKnpa.Size = new System.Drawing.Size(13, 13);
        this.lblKnpa.TabIndex = 11;
        this.lblKnpa.Text = "0";
        // 
        // Label35
        // 
        this.Label35.AutoSize = true;
        this.Label35.Location = new System.Drawing.Point(15, 83);
        this.Label35.Name = "Label35";
        this.Label35.Size = new System.Drawing.Size(98, 13);
        this.Label35.TabIndex = 10;
        this.Label35.Text = "Non-paged allocs";
        // 
        // lblKnpu
        // 
        this.lblKnpu.AutoSize = true;
        this.lblKnpu.Location = new System.Drawing.Point(121, 68);
        this.lblKnpu.Name = "lblKnpu";
        this.lblKnpu.Size = new System.Drawing.Size(13, 13);
        this.lblKnpu.TabIndex = 9;
        this.lblKnpu.Text = "0";
        // 
        // Label39
        // 
        this.Label39.AutoSize = true;
        this.Label39.Location = new System.Drawing.Point(15, 68);
        this.Label39.Name = "Label39";
        this.Label39.Size = new System.Drawing.Size(100, 13);
        this.Label39.TabIndex = 8;
        this.Label39.Text = "Non-paged usage";
        // 
        // lblKpf
        // 
        this.lblKpf.AutoSize = true;
        this.lblKpf.Location = new System.Drawing.Point(121, 53);
        this.lblKpf.Name = "lblKpf";
        this.lblKpf.Size = new System.Drawing.Size(13, 13);
        this.lblKpf.TabIndex = 7;
        this.lblKpf.Text = "0";
        // 
        // Label41
        // 
        this.Label41.AutoSize = true;
        this.Label41.Location = new System.Drawing.Point(15, 53);
        this.Label41.Name = "Label41";
        this.Label41.Size = new System.Drawing.Size(67, 13);
        this.Label41.TabIndex = 6;
        this.Label41.Text = "Paged frees";
        // 
        // lblKpa
        // 
        this.lblKpa.AutoSize = true;
        this.lblKpa.Location = new System.Drawing.Point(121, 38);
        this.lblKpa.Name = "lblKpa";
        this.lblKpa.Size = new System.Drawing.Size(13, 13);
        this.lblKpa.TabIndex = 5;
        this.lblKpa.Text = "0";
        // 
        // Label43
        // 
        this.Label43.AutoSize = true;
        this.Label43.Location = new System.Drawing.Point(15, 38);
        this.Label43.Name = "Label43";
        this.Label43.Size = new System.Drawing.Size(71, 13);
        this.Label43.TabIndex = 4;
        this.Label43.Text = "Paged allocs";
        // 
        // lblKpp
        // 
        this.lblKpp.AutoSize = true;
        this.lblKpp.Location = new System.Drawing.Point(121, 23);
        this.lblKpp.Name = "lblKpp";
        this.lblKpp.Size = new System.Drawing.Size(13, 13);
        this.lblKpp.TabIndex = 1;
        this.lblKpp.Text = "0";
        // 
        // Label47
        // 
        this.Label47.AutoSize = true;
        this.Label47.Location = new System.Drawing.Point(15, 23);
        this.Label47.Name = "Label47";
        this.Label47.Size = new System.Drawing.Size(73, 13);
        this.Label47.TabIndex = 0;
        this.Label47.Text = "Paged usage";
        // 
        // GroupBox7
        // 
        this.GroupBox7.Controls.Add(this.lblCPUUsage);
        this.GroupBox7.Controls.Add(this.Label40);
        this.GroupBox7.Controls.Add(this.lblCPUTotalTime);
        this.GroupBox7.Controls.Add(this.Label37);
        this.GroupBox7.Controls.Add(this.lblCPUdpcTime);
        this.GroupBox7.Controls.Add(this.Label29);
        this.GroupBox7.Controls.Add(this.lblCPUidleTime);
        this.GroupBox7.Controls.Add(this.Label23);
        this.GroupBox7.Controls.Add(this.lblCPUuserTime);
        this.GroupBox7.Controls.Add(this.Label33);
        this.GroupBox7.Controls.Add(this.lblCPUkernelTime);
        this.GroupBox7.Controls.Add(this.Label36);
        this.GroupBox7.Controls.Add(this.lblCPUinterruptTime);
        this.GroupBox7.Controls.Add(this.Label38);
        this.GroupBox7.Controls.Add(this.lblCPUcontextSwitches);
        this.GroupBox7.Controls.Add(this.Label34);
        this.GroupBox7.Controls.Add(this.lblCPUsystemCalls);
        this.GroupBox7.Controls.Add(this.Label19);
        this.GroupBox7.Controls.Add(this.lblCPUinterrupts);
        this.GroupBox7.Controls.Add(this.Label27);
        this.GroupBox7.Controls.Add(this.lblCPUprocessors);
        this.GroupBox7.Controls.Add(this.Label31);
        this.GroupBox7.Location = new System.Drawing.Point(158, 3);
        this.GroupBox7.Name = "GroupBox7";
        this.GroupBox7.Size = new System.Drawing.Size(259, 177);
        this.GroupBox7.TabIndex = 14;
        this.GroupBox7.TabStop = false;
        this.GroupBox7.Text = "CPU";
        // 
        // lblCPUUsage
        // 
        this.lblCPUUsage.AutoSize = true;
        this.lblCPUUsage.Location = new System.Drawing.Point(188, 23);
        this.lblCPUUsage.Name = "lblCPUUsage";
        this.lblCPUUsage.Size = new System.Drawing.Size(52, 13);
        this.lblCPUUsage.TabIndex = 21;
        this.lblCPUUsage.Text = "00,000 %";
        // 
        // Label40
        // 
        this.Label40.AutoSize = true;
        this.Label40.Location = new System.Drawing.Point(143, 23);
        this.Label40.Name = "Label40";
        this.Label40.Size = new System.Drawing.Size(39, 13);
        this.Label40.TabIndex = 20;
        this.Label40.Text = "Usage";
        // 
        // lblCPUTotalTime
        // 
        this.lblCPUTotalTime.AutoSize = true;
        this.lblCPUTotalTime.Location = new System.Drawing.Point(113, 158);
        this.lblCPUTotalTime.Name = "lblCPUTotalTime";
        this.lblCPUTotalTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUTotalTime.TabIndex = 19;
        this.lblCPUTotalTime.Text = "0";
        // 
        // Label37
        // 
        this.Label37.AutoSize = true;
        this.Label37.Location = new System.Drawing.Point(15, 158);
        this.Label37.Name = "Label37";
        this.Label37.Size = new System.Drawing.Size(57, 13);
        this.Label37.TabIndex = 18;
        this.Label37.Text = "Total time";
        // 
        // lblCPUdpcTime
        // 
        this.lblCPUdpcTime.AutoSize = true;
        this.lblCPUdpcTime.Location = new System.Drawing.Point(113, 143);
        this.lblCPUdpcTime.Name = "lblCPUdpcTime";
        this.lblCPUdpcTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUdpcTime.TabIndex = 17;
        this.lblCPUdpcTime.Text = "0";
        // 
        // Label29
        // 
        this.Label29.AutoSize = true;
        this.Label29.Location = new System.Drawing.Point(15, 143);
        this.Label29.Name = "Label29";
        this.Label29.Size = new System.Drawing.Size(53, 13);
        this.Label29.TabIndex = 16;
        this.Label29.Text = "DPC time";
        // 
        // lblCPUidleTime
        // 
        this.lblCPUidleTime.AutoSize = true;
        this.lblCPUidleTime.Location = new System.Drawing.Point(113, 128);
        this.lblCPUidleTime.Name = "lblCPUidleTime";
        this.lblCPUidleTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUidleTime.TabIndex = 15;
        this.lblCPUidleTime.Text = "0";
        // 
        // Label23
        // 
        this.Label23.AutoSize = true;
        this.Label23.Location = new System.Drawing.Point(15, 128);
        this.Label23.Name = "Label23";
        this.Label23.Size = new System.Drawing.Size(51, 13);
        this.Label23.TabIndex = 14;
        this.Label23.Text = "Idle time";
        // 
        // lblCPUuserTime
        // 
        this.lblCPUuserTime.AutoSize = true;
        this.lblCPUuserTime.Location = new System.Drawing.Point(113, 113);
        this.lblCPUuserTime.Name = "lblCPUuserTime";
        this.lblCPUuserTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUuserTime.TabIndex = 13;
        this.lblCPUuserTime.Text = "0";
        // 
        // Label33
        // 
        this.Label33.AutoSize = true;
        this.Label33.Location = new System.Drawing.Point(15, 113);
        this.Label33.Name = "Label33";
        this.Label33.Size = new System.Drawing.Size(55, 13);
        this.Label33.TabIndex = 12;
        this.Label33.Text = "User time";
        // 
        // lblCPUkernelTime
        // 
        this.lblCPUkernelTime.AutoSize = true;
        this.lblCPUkernelTime.Location = new System.Drawing.Point(113, 98);
        this.lblCPUkernelTime.Name = "lblCPUkernelTime";
        this.lblCPUkernelTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUkernelTime.TabIndex = 11;
        this.lblCPUkernelTime.Text = "0";
        // 
        // Label36
        // 
        this.Label36.AutoSize = true;
        this.Label36.Location = new System.Drawing.Point(15, 98);
        this.Label36.Name = "Label36";
        this.Label36.Size = new System.Drawing.Size(64, 13);
        this.Label36.TabIndex = 10;
        this.Label36.Text = "Kernel time";
        // 
        // lblCPUinterruptTime
        // 
        this.lblCPUinterruptTime.AutoSize = true;
        this.lblCPUinterruptTime.Location = new System.Drawing.Point(113, 83);
        this.lblCPUinterruptTime.Name = "lblCPUinterruptTime";
        this.lblCPUinterruptTime.Size = new System.Drawing.Size(13, 13);
        this.lblCPUinterruptTime.TabIndex = 9;
        this.lblCPUinterruptTime.Text = "0";
        // 
        // Label38
        // 
        this.Label38.AutoSize = true;
        this.Label38.Location = new System.Drawing.Point(15, 83);
        this.Label38.Name = "Label38";
        this.Label38.Size = new System.Drawing.Size(78, 13);
        this.Label38.TabIndex = 8;
        this.Label38.Text = "Interrupt time";
        // 
        // lblCPUcontextSwitches
        // 
        this.lblCPUcontextSwitches.AutoSize = true;
        this.lblCPUcontextSwitches.Location = new System.Drawing.Point(113, 68);
        this.lblCPUcontextSwitches.Name = "lblCPUcontextSwitches";
        this.lblCPUcontextSwitches.Size = new System.Drawing.Size(13, 13);
        this.lblCPUcontextSwitches.TabIndex = 7;
        this.lblCPUcontextSwitches.Text = "0";
        // 
        // Label34
        // 
        this.Label34.AutoSize = true;
        this.Label34.Location = new System.Drawing.Point(15, 68);
        this.Label34.Name = "Label34";
        this.Label34.Size = new System.Drawing.Size(94, 13);
        this.Label34.TabIndex = 6;
        this.Label34.Text = "Context switches";
        // 
        // lblCPUsystemCalls
        // 
        this.lblCPUsystemCalls.AutoSize = true;
        this.lblCPUsystemCalls.Location = new System.Drawing.Point(113, 53);
        this.lblCPUsystemCalls.Name = "lblCPUsystemCalls";
        this.lblCPUsystemCalls.Size = new System.Drawing.Size(13, 13);
        this.lblCPUsystemCalls.TabIndex = 5;
        this.lblCPUsystemCalls.Text = "0";
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(15, 53);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(67, 13);
        this.Label19.TabIndex = 4;
        this.Label19.Text = "System calls";
        // 
        // lblCPUinterrupts
        // 
        this.lblCPUinterrupts.AutoSize = true;
        this.lblCPUinterrupts.Location = new System.Drawing.Point(113, 38);
        this.lblCPUinterrupts.Name = "lblCPUinterrupts";
        this.lblCPUinterrupts.Size = new System.Drawing.Size(13, 13);
        this.lblCPUinterrupts.TabIndex = 3;
        this.lblCPUinterrupts.Text = "0";
        // 
        // Label27
        // 
        this.Label27.AutoSize = true;
        this.Label27.Location = new System.Drawing.Point(15, 38);
        this.Label27.Name = "Label27";
        this.Label27.Size = new System.Drawing.Size(58, 13);
        this.Label27.TabIndex = 2;
        this.Label27.Text = "Interrupts";
        // 
        // lblCPUprocessors
        // 
        this.lblCPUprocessors.AutoSize = true;
        this.lblCPUprocessors.Location = new System.Drawing.Point(113, 23);
        this.lblCPUprocessors.Name = "lblCPUprocessors";
        this.lblCPUprocessors.Size = new System.Drawing.Size(13, 13);
        this.lblCPUprocessors.TabIndex = 1;
        this.lblCPUprocessors.Text = "0";
        // 
        // Label31
        // 
        this.Label31.AutoSize = true;
        this.Label31.Location = new System.Drawing.Point(15, 23);
        this.Label31.Name = "Label31";
        this.Label31.Size = new System.Drawing.Size(61, 13);
        this.Label31.TabIndex = 0;
        this.Label31.Text = "Processors";
        // 
        // GroupBox6
        // 
        this.GroupBox6.Controls.Add(this.lblPFcache);
        this.GroupBox6.Controls.Add(this.Label15);
        this.GroupBox6.Controls.Add(this.lblPFdemandZero);
        this.GroupBox6.Controls.Add(this.Label21);
        this.GroupBox6.Controls.Add(this.lblPFcacheTransition);
        this.GroupBox6.Controls.Add(this.Label25);
        this.GroupBox6.Controls.Add(this.lblPFtransition);
        this.GroupBox6.Controls.Add(this.Label28);
        this.GroupBox6.Controls.Add(this.lblPFcopyOnWrite);
        this.GroupBox6.Controls.Add(this.Label30);
        this.GroupBox6.Controls.Add(this.lblPFtotal);
        this.GroupBox6.Controls.Add(this.Label32);
        this.GroupBox6.Location = new System.Drawing.Point(158, 186);
        this.GroupBox6.Name = "GroupBox6";
        this.GroupBox6.Size = new System.Drawing.Size(259, 125);
        this.GroupBox6.TabIndex = 13;
        this.GroupBox6.TabStop = false;
        this.GroupBox6.Text = "Page faults";
        // 
        // lblPFcache
        // 
        this.lblPFcache.AutoSize = true;
        this.lblPFcache.Location = new System.Drawing.Point(121, 98);
        this.lblPFcache.Name = "lblPFcache";
        this.lblPFcache.Size = new System.Drawing.Size(13, 13);
        this.lblPFcache.TabIndex = 11;
        this.lblPFcache.Text = "0";
        // 
        // Label15
        // 
        this.Label15.AutoSize = true;
        this.Label15.Location = new System.Drawing.Point(15, 98);
        this.Label15.Name = "Label15";
        this.Label15.Size = new System.Drawing.Size(38, 13);
        this.Label15.TabIndex = 10;
        this.Label15.Text = "Cache";
        // 
        // lblPFdemandZero
        // 
        this.lblPFdemandZero.AutoSize = true;
        this.lblPFdemandZero.Location = new System.Drawing.Point(121, 83);
        this.lblPFdemandZero.Name = "lblPFdemandZero";
        this.lblPFdemandZero.Size = new System.Drawing.Size(13, 13);
        this.lblPFdemandZero.TabIndex = 9;
        this.lblPFdemandZero.Text = "0";
        // 
        // Label21
        // 
        this.Label21.AutoSize = true;
        this.Label21.Location = new System.Drawing.Point(15, 83);
        this.Label21.Name = "Label21";
        this.Label21.Size = new System.Drawing.Size(81, 13);
        this.Label21.TabIndex = 8;
        this.Label21.Text = "Demande zero";
        // 
        // lblPFcacheTransition
        // 
        this.lblPFcacheTransition.AutoSize = true;
        this.lblPFcacheTransition.Location = new System.Drawing.Point(121, 68);
        this.lblPFcacheTransition.Name = "lblPFcacheTransition";
        this.lblPFcacheTransition.Size = new System.Drawing.Size(13, 13);
        this.lblPFcacheTransition.TabIndex = 7;
        this.lblPFcacheTransition.Text = "0";
        // 
        // Label25
        // 
        this.Label25.AutoSize = true;
        this.Label25.Location = new System.Drawing.Point(15, 68);
        this.Label25.Name = "Label25";
        this.Label25.Size = new System.Drawing.Size(91, 13);
        this.Label25.TabIndex = 6;
        this.Label25.Text = "Cache transition";
        // 
        // lblPFtransition
        // 
        this.lblPFtransition.AutoSize = true;
        this.lblPFtransition.Location = new System.Drawing.Point(121, 53);
        this.lblPFtransition.Name = "lblPFtransition";
        this.lblPFtransition.Size = new System.Drawing.Size(13, 13);
        this.lblPFtransition.TabIndex = 5;
        this.lblPFtransition.Text = "0";
        // 
        // Label28
        // 
        this.Label28.AutoSize = true;
        this.Label28.Location = new System.Drawing.Point(15, 53);
        this.Label28.Name = "Label28";
        this.Label28.Size = new System.Drawing.Size(58, 13);
        this.Label28.TabIndex = 4;
        this.Label28.Text = "Transition";
        // 
        // lblPFcopyOnWrite
        // 
        this.lblPFcopyOnWrite.AutoSize = true;
        this.lblPFcopyOnWrite.Location = new System.Drawing.Point(121, 38);
        this.lblPFcopyOnWrite.Name = "lblPFcopyOnWrite";
        this.lblPFcopyOnWrite.Size = new System.Drawing.Size(13, 13);
        this.lblPFcopyOnWrite.TabIndex = 3;
        this.lblPFcopyOnWrite.Text = "0";
        // 
        // Label30
        // 
        this.Label30.AutoSize = true;
        this.Label30.Location = new System.Drawing.Point(15, 38);
        this.Label30.Name = "Label30";
        this.Label30.Size = new System.Drawing.Size(81, 13);
        this.Label30.TabIndex = 2;
        this.Label30.Text = "Copy-on-write";
        // 
        // lblPFtotal
        // 
        this.lblPFtotal.AutoSize = true;
        this.lblPFtotal.Location = new System.Drawing.Point(121, 23);
        this.lblPFtotal.Name = "lblPFtotal";
        this.lblPFtotal.Size = new System.Drawing.Size(13, 13);
        this.lblPFtotal.TabIndex = 1;
        this.lblPFtotal.Text = "0";
        // 
        // Label32
        // 
        this.Label32.AutoSize = true;
        this.Label32.Location = new System.Drawing.Point(15, 23);
        this.Label32.Name = "Label32";
        this.Label32.Size = new System.Drawing.Size(32, 13);
        this.Label32.TabIndex = 0;
        this.Label32.Text = "Total";
        // 
        // GroupBox5
        // 
        this.GroupBox5.Controls.Add(this.lblIOotherBytes);
        this.GroupBox5.Controls.Add(this.Label26);
        this.GroupBox5.Controls.Add(this.lblIOothers);
        this.GroupBox5.Controls.Add(this.Label10);
        this.GroupBox5.Controls.Add(this.lblIOwriteBytes);
        this.GroupBox5.Controls.Add(this.Label18);
        this.GroupBox5.Controls.Add(this.lblIOwrites);
        this.GroupBox5.Controls.Add(this.Label20);
        this.GroupBox5.Controls.Add(this.lblIOreadBytes);
        this.GroupBox5.Controls.Add(this.Label22);
        this.GroupBox5.Controls.Add(this.lblIOreads);
        this.GroupBox5.Controls.Add(this.Label24);
        this.GroupBox5.Location = new System.Drawing.Point(3, 349);
        this.GroupBox5.Name = "GroupBox5";
        this.GroupBox5.Size = new System.Drawing.Size(149, 120);
        this.GroupBox5.TabIndex = 12;
        this.GroupBox5.TabStop = false;
        this.GroupBox5.Text = "I/O";
        // 
        // lblIOotherBytes
        // 
        this.lblIOotherBytes.AutoSize = true;
        this.lblIOotherBytes.Location = new System.Drawing.Point(80, 98);
        this.lblIOotherBytes.Name = "lblIOotherBytes";
        this.lblIOotherBytes.Size = new System.Drawing.Size(13, 13);
        this.lblIOotherBytes.TabIndex = 11;
        this.lblIOotherBytes.Text = "0";
        // 
        // Label26
        // 
        this.Label26.AutoSize = true;
        this.Label26.Location = new System.Drawing.Point(15, 98);
        this.Label26.Name = "Label26";
        this.Label26.Size = new System.Drawing.Size(67, 13);
        this.Label26.TabIndex = 10;
        this.Label26.Text = "Other bytes";
        // 
        // lblIOothers
        // 
        this.lblIOothers.AutoSize = true;
        this.lblIOothers.Location = new System.Drawing.Point(80, 83);
        this.lblIOothers.Name = "lblIOothers";
        this.lblIOothers.Size = new System.Drawing.Size(13, 13);
        this.lblIOothers.TabIndex = 9;
        this.lblIOothers.Text = "0";
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(15, 83);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(42, 13);
        this.Label10.TabIndex = 8;
        this.Label10.Text = "Others";
        // 
        // lblIOwriteBytes
        // 
        this.lblIOwriteBytes.AutoSize = true;
        this.lblIOwriteBytes.Location = new System.Drawing.Point(80, 68);
        this.lblIOwriteBytes.Name = "lblIOwriteBytes";
        this.lblIOwriteBytes.Size = new System.Drawing.Size(13, 13);
        this.lblIOwriteBytes.TabIndex = 7;
        this.lblIOwriteBytes.Text = "0";
        // 
        // Label18
        // 
        this.Label18.AutoSize = true;
        this.Label18.Location = new System.Drawing.Point(15, 68);
        this.Label18.Name = "Label18";
        this.Label18.Size = new System.Drawing.Size(65, 13);
        this.Label18.TabIndex = 6;
        this.Label18.Text = "Write bytes";
        // 
        // lblIOwrites
        // 
        this.lblIOwrites.AutoSize = true;
        this.lblIOwrites.Location = new System.Drawing.Point(80, 53);
        this.lblIOwrites.Name = "lblIOwrites";
        this.lblIOwrites.Size = new System.Drawing.Size(13, 13);
        this.lblIOwrites.TabIndex = 5;
        this.lblIOwrites.Text = "0";
        // 
        // Label20
        // 
        this.Label20.AutoSize = true;
        this.Label20.Location = new System.Drawing.Point(15, 53);
        this.Label20.Name = "Label20";
        this.Label20.Size = new System.Drawing.Size(40, 13);
        this.Label20.TabIndex = 4;
        this.Label20.Text = "Writes";
        // 
        // lblIOreadBytes
        // 
        this.lblIOreadBytes.AutoSize = true;
        this.lblIOreadBytes.Location = new System.Drawing.Point(80, 38);
        this.lblIOreadBytes.Name = "lblIOreadBytes";
        this.lblIOreadBytes.Size = new System.Drawing.Size(13, 13);
        this.lblIOreadBytes.TabIndex = 3;
        this.lblIOreadBytes.Text = "0";
        // 
        // Label22
        // 
        this.Label22.AutoSize = true;
        this.Label22.Location = new System.Drawing.Point(15, 38);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(63, 13);
        this.Label22.TabIndex = 2;
        this.Label22.Text = "Read bytes";
        // 
        // lblIOreads
        // 
        this.lblIOreads.AutoSize = true;
        this.lblIOreads.Location = new System.Drawing.Point(80, 23);
        this.lblIOreads.Name = "lblIOreads";
        this.lblIOreads.Size = new System.Drawing.Size(13, 13);
        this.lblIOreads.TabIndex = 1;
        this.lblIOreads.Text = "0";
        // 
        // Label24
        // 
        this.Label24.AutoSize = true;
        this.Label24.Location = new System.Drawing.Point(15, 23);
        this.Label24.Name = "Label24";
        this.Label24.Size = new System.Drawing.Size(38, 13);
        this.Label24.TabIndex = 0;
        this.Label24.Text = "Reads";
        // 
        // GroupBox4
        // 
        this.GroupBox4.Controls.Add(this.lblPMT);
        this.GroupBox4.Controls.Add(this.Label7);
        this.GroupBox4.Controls.Add(this.lblPMU);
        this.GroupBox4.Controls.Add(this.Label13);
        this.GroupBox4.Controls.Add(this.lblPMF);
        this.GroupBox4.Controls.Add(this.Label17);
        this.GroupBox4.Location = new System.Drawing.Point(3, 161);
        this.GroupBox4.Name = "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(149, 73);
        this.GroupBox4.TabIndex = 11;
        this.GroupBox4.TabStop = false;
        this.GroupBox4.Text = "Physical memory";
        // 
        // lblPMT
        // 
        this.lblPMT.AutoSize = true;
        this.lblPMT.Location = new System.Drawing.Point(70, 53);
        this.lblPMT.Name = "lblPMT";
        this.lblPMT.Size = new System.Drawing.Size(13, 13);
        this.lblPMT.TabIndex = 5;
        this.lblPMT.Text = "0";
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(15, 53);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(32, 13);
        this.Label7.TabIndex = 4;
        this.Label7.Text = "Total";
        // 
        // lblPMU
        // 
        this.lblPMU.AutoSize = true;
        this.lblPMU.Location = new System.Drawing.Point(70, 38);
        this.lblPMU.Name = "lblPMU";
        this.lblPMU.Size = new System.Drawing.Size(13, 13);
        this.lblPMU.TabIndex = 3;
        this.lblPMU.Text = "0";
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(15, 38);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(33, 13);
        this.Label13.TabIndex = 2;
        this.Label13.Text = "Used";
        // 
        // lblPMF
        // 
        this.lblPMF.AutoSize = true;
        this.lblPMF.Location = new System.Drawing.Point(70, 23);
        this.lblPMF.Name = "lblPMF";
        this.lblPMF.Size = new System.Drawing.Size(13, 13);
        this.lblPMF.TabIndex = 1;
        this.lblPMF.Text = "0";
        // 
        // Label17
        // 
        this.Label17.AutoSize = true;
        this.Label17.Location = new System.Drawing.Point(15, 23);
        this.Label17.Name = "Label17";
        this.Label17.Size = new System.Drawing.Size(29, 13);
        this.Label17.TabIndex = 0;
        this.Label17.Text = "Free";
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.lblCCL);
        this.GroupBox3.Controls.Add(this.Label5);
        this.GroupBox3.Controls.Add(this.lblCCP);
        this.GroupBox3.Controls.Add(this.Label9);
        this.GroupBox3.Controls.Add(this.lblCCC);
        this.GroupBox3.Controls.Add(this.Label11);
        this.GroupBox3.Location = new System.Drawing.Point(3, 82);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(149, 73);
        this.GroupBox3.TabIndex = 10;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Commit charge";
        // 
        // lblCCL
        // 
        this.lblCCL.AutoSize = true;
        this.lblCCL.Location = new System.Drawing.Point(70, 53);
        this.lblCCL.Name = "lblCCL";
        this.lblCCL.Size = new System.Drawing.Size(13, 13);
        this.lblCCL.TabIndex = 5;
        this.lblCCL.Text = "0";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(15, 53);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(31, 13);
        this.Label5.TabIndex = 4;
        this.Label5.Text = "Limit";
        // 
        // lblCCP
        // 
        this.lblCCP.AutoSize = true;
        this.lblCCP.Location = new System.Drawing.Point(70, 38);
        this.lblCCP.Name = "lblCCP";
        this.lblCCP.Size = new System.Drawing.Size(13, 13);
        this.lblCCP.TabIndex = 3;
        this.lblCCP.Text = "0";
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(15, 38);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(31, 13);
        this.Label9.TabIndex = 2;
        this.Label9.Text = "Peak";
        // 
        // lblCCC
        // 
        this.lblCCC.AutoSize = true;
        this.lblCCC.Location = new System.Drawing.Point(70, 23);
        this.lblCCC.Name = "lblCCC";
        this.lblCCC.Size = new System.Drawing.Size(13, 13);
        this.lblCCC.TabIndex = 1;
        this.lblCCC.Text = "0";
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(15, 23);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(46, 13);
        this.Label11.TabIndex = 0;
        this.Label11.Text = "Current";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.lblHandles);
        this.GroupBox2.Controls.Add(this.Label12);
        this.GroupBox2.Controls.Add(this.lblThreads);
        this.GroupBox2.Controls.Add(this.Label14);
        this.GroupBox2.Controls.Add(this.lblProcesses);
        this.GroupBox2.Controls.Add(this.Label16);
        this.GroupBox2.Location = new System.Drawing.Point(3, 3);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(149, 73);
        this.GroupBox2.TabIndex = 9;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Total";
        // 
        // lblHandles
        // 
        this.lblHandles.AutoSize = true;
        this.lblHandles.Location = new System.Drawing.Point(80, 53);
        this.lblHandles.Name = "lblHandles";
        this.lblHandles.Size = new System.Drawing.Size(13, 13);
        this.lblHandles.TabIndex = 5;
        this.lblHandles.Text = "0";
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(15, 53);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(49, 13);
        this.Label12.TabIndex = 4;
        this.Label12.Text = "Handles";
        // 
        // lblThreads
        // 
        this.lblThreads.AutoSize = true;
        this.lblThreads.Location = new System.Drawing.Point(80, 38);
        this.lblThreads.Name = "lblThreads";
        this.lblThreads.Size = new System.Drawing.Size(13, 13);
        this.lblThreads.TabIndex = 3;
        this.lblThreads.Text = "0";
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(15, 38);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(47, 13);
        this.Label14.TabIndex = 2;
        this.Label14.Text = "Threads";
        // 
        // lblProcesses
        // 
        this.lblProcesses.AutoSize = true;
        this.lblProcesses.Location = new System.Drawing.Point(80, 23);
        this.lblProcesses.Name = "lblProcesses";
        this.lblProcesses.Size = new System.Drawing.Size(13, 13);
        this.lblProcesses.TabIndex = 1;
        this.lblProcesses.Text = "0";
        // 
        // Label16
        // 
        this.Label16.AutoSize = true;
        this.Label16.Location = new System.Drawing.Point(15, 23);
        this.Label16.Name = "Label16";
        this.Label16.Size = new System.Drawing.Size(56, 13);
        this.Label16.TabIndex = 0;
        this.Label16.Text = "Processes";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.lblCacheErrors);
        this.GroupBox1.Controls.Add(this.Label3);
        this.GroupBox1.Controls.Add(this.lblCacheMaximum);
        this.GroupBox1.Controls.Add(this.Label8);
        this.GroupBox1.Controls.Add(this.lblCacheMinimum);
        this.GroupBox1.Controls.Add(this.Label6);
        this.GroupBox1.Controls.Add(this.lblCachePeak);
        this.GroupBox1.Controls.Add(this.Label4);
        this.GroupBox1.Controls.Add(this.lblCacheCurrent);
        this.GroupBox1.Controls.Add(this.Label1);
        this.GroupBox1.Location = new System.Drawing.Point(3, 240);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(149, 103);
        this.GroupBox1.TabIndex = 8;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Cache";
        // 
        // lblCacheErrors
        // 
        this.lblCacheErrors.AutoSize = true;
        this.lblCacheErrors.Location = new System.Drawing.Point(80, 83);
        this.lblCacheErrors.Name = "lblCacheErrors";
        this.lblCacheErrors.Size = new System.Drawing.Size(13, 13);
        this.lblCacheErrors.TabIndex = 9;
        this.lblCacheErrors.Text = "0";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(15, 83);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(38, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "Faults";
        // 
        // lblCacheMaximum
        // 
        this.lblCacheMaximum.AutoSize = true;
        this.lblCacheMaximum.Location = new System.Drawing.Point(80, 68);
        this.lblCacheMaximum.Name = "lblCacheMaximum";
        this.lblCacheMaximum.Size = new System.Drawing.Size(13, 13);
        this.lblCacheMaximum.TabIndex = 7;
        this.lblCacheMaximum.Text = "0";
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(15, 68);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(56, 13);
        this.Label8.TabIndex = 6;
        this.Label8.Text = "Maximum";
        // 
        // lblCacheMinimum
        // 
        this.lblCacheMinimum.AutoSize = true;
        this.lblCacheMinimum.Location = new System.Drawing.Point(80, 53);
        this.lblCacheMinimum.Name = "lblCacheMinimum";
        this.lblCacheMinimum.Size = new System.Drawing.Size(13, 13);
        this.lblCacheMinimum.TabIndex = 5;
        this.lblCacheMinimum.Text = "0";
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(15, 53);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(55, 13);
        this.Label6.TabIndex = 4;
        this.Label6.Text = "Minimum";
        // 
        // lblCachePeak
        // 
        this.lblCachePeak.AutoSize = true;
        this.lblCachePeak.Location = new System.Drawing.Point(80, 38);
        this.lblCachePeak.Name = "lblCachePeak";
        this.lblCachePeak.Size = new System.Drawing.Size(13, 13);
        this.lblCachePeak.TabIndex = 3;
        this.lblCachePeak.Text = "0";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(15, 38);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(31, 13);
        this.Label4.TabIndex = 2;
        this.Label4.Text = "Peak";
        // 
        // lblCacheCurrent
        // 
        this.lblCacheCurrent.AutoSize = true;
        this.lblCacheCurrent.Location = new System.Drawing.Point(80, 23);
        this.lblCacheCurrent.Name = "lblCacheCurrent";
        this.lblCacheCurrent.Size = new System.Drawing.Size(13, 13);
        this.lblCacheCurrent.TabIndex = 1;
        this.lblCacheCurrent.Text = "0";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(15, 23);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(46, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Current";
        // 
        // SplitContainer2
        // 
        this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer2.IsSplitterFixed = true;
        this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer2.Name = "SplitContainer2";
        this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer2.Panel1
        // 
        this.SplitContainer2.Panel1.Controls.Add(this.SplitContainer1);
        // 
        // SplitContainer2.Panel2
        // 
        this.SplitContainer2.Panel2.Controls.Add(this.SplitContainer3);
        this.SplitContainer2.Size = new System.Drawing.Size(306, 477);
        this.SplitContainer2.SplitterDistance = 239;
        this.SplitContainer2.TabIndex = 0;
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.IsSplitterFixed = true;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.g2);
        this.SplitContainer1.Size = new System.Drawing.Size(306, 239);
        this.SplitContainer1.SplitterDistance = 119;
        this.SplitContainer1.TabIndex = 1;
        // 
        // SplitContainer3
        // 
        this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer3.IsSplitterFixed = true;
        this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer3.Name = "SplitContainer3";
        this.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer3.Panel1
        // 
        this.SplitContainer3.Panel1.Controls.Add(this.g3);
        // 
        // SplitContainer3.Panel2
        // 
        this.SplitContainer3.Panel2.Controls.Add(this.g4);
        this.SplitContainer3.Size = new System.Drawing.Size(306, 234);
        this.SplitContainer3.SplitterDistance = 117;
        this.SplitContainer3.TabIndex = 0;
        // 
        // chkTopMost
        // 
        this.chkTopMost.AutoSize = true;
        this.chkTopMost.Location = new System.Drawing.Point(298, 448);
        this.chkTopMost.Name = "chkTopMost";
        this.chkTopMost.Size = new System.Drawing.Size(99, 17);
        this.chkTopMost.TabIndex = 17;
        this.chkTopMost.Text = "Always on top";
        this.chkTopMost.UseVisualStyleBackColor = true;
        // 
        // g2
        // 
        this.g2.BackColor = System.Drawing.Color.Black;
        this.g2.Color2 = System.Drawing.Color.Olive;
        this.g2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.g2.EnableGraph = true;
        this.g2.Fixedheight = true;
        this.g2.GridStep = 13;
        this.g2.Location = new System.Drawing.Point(0, 0);
        this.g2.Name = "g2";
        this.g2.ShowSecondGraph = false;
        this.g2.Size = new System.Drawing.Size(306, 116);
        this.g2.TabIndex = 11;
        this.g2.TabStop = false;
        this.g2.TextColor = System.Drawing.Color.Lime;
        this.g2.TopText = null;
        // 
        // g3
        // 
        this.g3.BackColor = System.Drawing.Color.Black;
        this.g3.Color = System.Drawing.Color.Red;
        this.g3.Color2 = System.Drawing.Color.Maroon;
        this.g3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.g3.EnableGraph = true;
        this.g3.Fixedheight = false;
        this.g3.GridStep = 13;
        this.g3.Location = new System.Drawing.Point(0, 0);
        this.g3.Name = "g3";
        this.g3.ShowSecondGraph = false;
        this.g3.Size = new System.Drawing.Size(306, 117);
        this.g3.TabIndex = 10;
        this.g3.TabStop = false;
        this.g3.TextColor = System.Drawing.Color.Lime;
        this.g3.TopText = null;
        // 
        // g4
        // 
        this.g4.BackColor = System.Drawing.Color.Black;
        this.g4.Color = System.Drawing.Color.Red;
        this.g4.Color2 = System.Drawing.Color.Maroon;
        this.g4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.g4.EnableGraph = true;
        this.g4.Fixedheight = false;
        this.g4.GridStep = 13;
        this.g4.Location = new System.Drawing.Point(0, 0);
        this.g4.Name = "g4";
        this.g4.ShowSecondGraph = false;
        this.g4.Size = new System.Drawing.Size(306, 113);
        this.g4.TabIndex = 11;
        this.g4.TabStop = false;
        this.g4.TextColor = System.Drawing.Color.Lime;
        this.g4.TopText = null;
        // 
        // frmSystemInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(735, 477);
        this.Controls.Add(this.mainSplit);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MinimumSize = new System.Drawing.Size(656, 513);
        this.Name = "frmSystemInfo";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "System information";
        this.mainSplit.Panel1.ResumeLayout(false);
        this.mainSplit.Panel1.PerformLayout();
        this.mainSplit.Panel2.ResumeLayout(false);
        this.mainSplit.ResumeLayout(false);
        this.GroupBox8.ResumeLayout(false);
        this.GroupBox8.PerformLayout();
        this.GroupBox7.ResumeLayout(false);
        this.GroupBox7.PerformLayout();
        this.GroupBox6.ResumeLayout(false);
        this.GroupBox6.PerformLayout();
        this.GroupBox5.ResumeLayout(false);
        this.GroupBox5.PerformLayout();
        this.GroupBox4.ResumeLayout(false);
        this.GroupBox4.PerformLayout();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.SplitContainer2.Panel1.ResumeLayout(false);
        this.SplitContainer2.Panel2.ResumeLayout(false);
        this.SplitContainer2.ResumeLayout(false);
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
        this.SplitContainer3.Panel1.ResumeLayout(false);
        this.SplitContainer3.Panel2.ResumeLayout(false);
        this.SplitContainer3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.g2).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.g3).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.g4).EndInit();
        this.ResumeLayout(false);
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

    private System.Windows.Forms.SplitContainer _mainSplit;

    internal System.Windows.Forms.SplitContainer mainSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mainSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mainSplit != null)
            {
            }

            _mainSplit = value;
            if (_mainSplit != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox8;

    internal System.Windows.Forms.GroupBox GroupBox8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox8 != null)
            {
            }

            _GroupBox8 = value;
            if (_GroupBox8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKnpf;

    internal System.Windows.Forms.Label lblKnpf
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKnpf;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKnpf != null)
            {
            }

            _lblKnpf = value;
            if (_lblKnpf != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label49;

    internal System.Windows.Forms.Label Label49
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label49;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label49 != null)
            {
            }

            _Label49 = value;
            if (_Label49 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKnpa;

    internal System.Windows.Forms.Label lblKnpa
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKnpa;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKnpa != null)
            {
            }

            _lblKnpa = value;
            if (_lblKnpa != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label35;

    internal System.Windows.Forms.Label Label35
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label35;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label35 != null)
            {
            }

            _Label35 = value;
            if (_Label35 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKnpu;

    internal System.Windows.Forms.Label lblKnpu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKnpu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKnpu != null)
            {
            }

            _lblKnpu = value;
            if (_lblKnpu != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label39;

    internal System.Windows.Forms.Label Label39
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label39;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label39 != null)
            {
            }

            _Label39 = value;
            if (_Label39 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKpf;

    internal System.Windows.Forms.Label lblKpf
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKpf;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKpf != null)
            {
            }

            _lblKpf = value;
            if (_lblKpf != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label41;

    internal System.Windows.Forms.Label Label41
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label41;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label41 != null)
            {
            }

            _Label41 = value;
            if (_Label41 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKpa;

    internal System.Windows.Forms.Label lblKpa
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKpa;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKpa != null)
            {
            }

            _lblKpa = value;
            if (_lblKpa != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label43;

    internal System.Windows.Forms.Label Label43
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label43;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label43 != null)
            {
            }

            _Label43 = value;
            if (_Label43 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblKpp;

    internal System.Windows.Forms.Label lblKpp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKpp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKpp != null)
            {
            }

            _lblKpp = value;
            if (_lblKpp != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label47;

    internal System.Windows.Forms.Label Label47
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label47;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label47 != null)
            {
            }

            _Label47 = value;
            if (_Label47 != null)
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

    private System.Windows.Forms.Label _lblCPUdpcTime;

    internal System.Windows.Forms.Label lblCPUdpcTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUdpcTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUdpcTime != null)
            {
            }

            _lblCPUdpcTime = value;
            if (_lblCPUdpcTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label29;

    internal System.Windows.Forms.Label Label29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label29 != null)
            {
            }

            _Label29 = value;
            if (_Label29 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUidleTime;

    internal System.Windows.Forms.Label lblCPUidleTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUidleTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUidleTime != null)
            {
            }

            _lblCPUidleTime = value;
            if (_lblCPUidleTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label23;

    internal System.Windows.Forms.Label Label23
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label23;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label23 != null)
            {
            }

            _Label23 = value;
            if (_Label23 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUuserTime;

    internal System.Windows.Forms.Label lblCPUuserTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUuserTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUuserTime != null)
            {
            }

            _lblCPUuserTime = value;
            if (_lblCPUuserTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label33;

    internal System.Windows.Forms.Label Label33
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label33;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label33 != null)
            {
            }

            _Label33 = value;
            if (_Label33 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUkernelTime;

    internal System.Windows.Forms.Label lblCPUkernelTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUkernelTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUkernelTime != null)
            {
            }

            _lblCPUkernelTime = value;
            if (_lblCPUkernelTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label36;

    internal System.Windows.Forms.Label Label36
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label36;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label36 != null)
            {
            }

            _Label36 = value;
            if (_Label36 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUinterruptTime;

    internal System.Windows.Forms.Label lblCPUinterruptTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUinterruptTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUinterruptTime != null)
            {
            }

            _lblCPUinterruptTime = value;
            if (_lblCPUinterruptTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label38;

    internal System.Windows.Forms.Label Label38
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label38;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label38 != null)
            {
            }

            _Label38 = value;
            if (_Label38 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUcontextSwitches;

    internal System.Windows.Forms.Label lblCPUcontextSwitches
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUcontextSwitches;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUcontextSwitches != null)
            {
            }

            _lblCPUcontextSwitches = value;
            if (_lblCPUcontextSwitches != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label34;

    internal System.Windows.Forms.Label Label34
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label34;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label34 != null)
            {
            }

            _Label34 = value;
            if (_Label34 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUsystemCalls;

    internal System.Windows.Forms.Label lblCPUsystemCalls
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUsystemCalls;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUsystemCalls != null)
            {
            }

            _lblCPUsystemCalls = value;
            if (_lblCPUsystemCalls != null)
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

    private System.Windows.Forms.Label _lblCPUinterrupts;

    internal System.Windows.Forms.Label lblCPUinterrupts
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUinterrupts;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUinterrupts != null)
            {
            }

            _lblCPUinterrupts = value;
            if (_lblCPUinterrupts != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label27;

    internal System.Windows.Forms.Label Label27
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label27;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label27 != null)
            {
            }

            _Label27 = value;
            if (_Label27 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUprocessors;

    internal System.Windows.Forms.Label lblCPUprocessors
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUprocessors;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUprocessors != null)
            {
            }

            _lblCPUprocessors = value;
            if (_lblCPUprocessors != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label31;

    internal System.Windows.Forms.Label Label31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label31 != null)
            {
            }

            _Label31 = value;
            if (_Label31 != null)
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

    private System.Windows.Forms.Label _lblPFcache;

    internal System.Windows.Forms.Label lblPFcache
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFcache;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFcache != null)
            {
            }

            _lblPFcache = value;
            if (_lblPFcache != null)
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

    private System.Windows.Forms.Label _lblPFdemandZero;

    internal System.Windows.Forms.Label lblPFdemandZero
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFdemandZero;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFdemandZero != null)
            {
            }

            _lblPFdemandZero = value;
            if (_lblPFdemandZero != null)
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

    private System.Windows.Forms.Label _lblPFcacheTransition;

    internal System.Windows.Forms.Label lblPFcacheTransition
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFcacheTransition;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFcacheTransition != null)
            {
            }

            _lblPFcacheTransition = value;
            if (_lblPFcacheTransition != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label25;

    internal System.Windows.Forms.Label Label25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label25 != null)
            {
            }

            _Label25 = value;
            if (_Label25 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPFtransition;

    internal System.Windows.Forms.Label lblPFtransition
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFtransition;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFtransition != null)
            {
            }

            _lblPFtransition = value;
            if (_lblPFtransition != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label28;

    internal System.Windows.Forms.Label Label28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label28 != null)
            {
            }

            _Label28 = value;
            if (_Label28 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPFcopyOnWrite;

    internal System.Windows.Forms.Label lblPFcopyOnWrite
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFcopyOnWrite;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFcopyOnWrite != null)
            {
            }

            _lblPFcopyOnWrite = value;
            if (_lblPFcopyOnWrite != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label30;

    internal System.Windows.Forms.Label Label30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label30 != null)
            {
            }

            _Label30 = value;
            if (_Label30 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblPFtotal;

    internal System.Windows.Forms.Label lblPFtotal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPFtotal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPFtotal != null)
            {
            }

            _lblPFtotal = value;
            if (_lblPFtotal != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label32;

    internal System.Windows.Forms.Label Label32
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label32;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label32 != null)
            {
            }

            _Label32 = value;
            if (_Label32 != null)
            {
            }
        }
    }

    private System.Windows.Forms.GroupBox _GroupBox5;

    internal System.Windows.Forms.GroupBox GroupBox5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GroupBox5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_GroupBox5 != null)
            {
            }

            _GroupBox5 = value;
            if (_GroupBox5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblIOotherBytes;

    internal System.Windows.Forms.Label lblIOotherBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOotherBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOotherBytes != null)
            {
            }

            _lblIOotherBytes = value;
            if (_lblIOotherBytes != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label26;

    internal System.Windows.Forms.Label Label26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label26 != null)
            {
            }

            _Label26 = value;
            if (_Label26 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblIOothers;

    internal System.Windows.Forms.Label lblIOothers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOothers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOothers != null)
            {
            }

            _lblIOothers = value;
            if (_lblIOothers != null)
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

    private System.Windows.Forms.Label _lblIOwriteBytes;

    internal System.Windows.Forms.Label lblIOwriteBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOwriteBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOwriteBytes != null)
            {
            }

            _lblIOwriteBytes = value;
            if (_lblIOwriteBytes != null)
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

    private System.Windows.Forms.Label _lblIOwrites;

    internal System.Windows.Forms.Label lblIOwrites
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOwrites;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOwrites != null)
            {
            }

            _lblIOwrites = value;
            if (_lblIOwrites != null)
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

    private System.Windows.Forms.Label _lblIOreadBytes;

    internal System.Windows.Forms.Label lblIOreadBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOreadBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOreadBytes != null)
            {
            }

            _lblIOreadBytes = value;
            if (_lblIOreadBytes != null)
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

    private System.Windows.Forms.Label _lblIOreads;

    internal System.Windows.Forms.Label lblIOreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblIOreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblIOreads != null)
            {
            }

            _lblIOreads = value;
            if (_lblIOreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label24;

    internal System.Windows.Forms.Label Label24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label24 != null)
            {
            }

            _Label24 = value;
            if (_Label24 != null)
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

    private System.Windows.Forms.Label _lblPMT;

    internal System.Windows.Forms.Label lblPMT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPMT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPMT != null)
            {
            }

            _lblPMT = value;
            if (_lblPMT != null)
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

    private System.Windows.Forms.Label _lblPMU;

    internal System.Windows.Forms.Label lblPMU
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPMU;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPMU != null)
            {
            }

            _lblPMU = value;
            if (_lblPMU != null)
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

    private System.Windows.Forms.Label _lblPMF;

    internal System.Windows.Forms.Label lblPMF
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPMF;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPMF != null)
            {
            }

            _lblPMF = value;
            if (_lblPMF != null)
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

    private System.Windows.Forms.Label _lblCCL;

    internal System.Windows.Forms.Label lblCCL
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCCL;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCCL != null)
            {
            }

            _lblCCL = value;
            if (_lblCCL != null)
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

    private System.Windows.Forms.Label _lblCCP;

    internal System.Windows.Forms.Label lblCCP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCCP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCCP != null)
            {
            }

            _lblCCP = value;
            if (_lblCCP != null)
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

    private System.Windows.Forms.Label _lblCCC;

    internal System.Windows.Forms.Label lblCCC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCCC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCCC != null)
            {
            }

            _lblCCC = value;
            if (_lblCCC != null)
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

    private System.Windows.Forms.Label _lblHandles;

    internal System.Windows.Forms.Label lblHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblHandles != null)
            {
            }

            _lblHandles = value;
            if (_lblHandles != null)
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

    private System.Windows.Forms.Label _lblThreads;

    internal System.Windows.Forms.Label lblThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblThreads != null)
            {
            }

            _lblThreads = value;
            if (_lblThreads != null)
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

    private System.Windows.Forms.Label _lblProcesses;

    internal System.Windows.Forms.Label lblProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcesses != null)
            {
            }

            _lblProcesses = value;
            if (_lblProcesses != null)
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

    private System.Windows.Forms.Label _lblCacheErrors;

    internal System.Windows.Forms.Label lblCacheErrors
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCacheErrors;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCacheErrors != null)
            {
            }

            _lblCacheErrors = value;
            if (_lblCacheErrors != null)
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

    private System.Windows.Forms.Label _lblCacheMaximum;

    internal System.Windows.Forms.Label lblCacheMaximum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCacheMaximum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCacheMaximum != null)
            {
            }

            _lblCacheMaximum = value;
            if (_lblCacheMaximum != null)
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

    private System.Windows.Forms.Label _lblCacheMinimum;

    internal System.Windows.Forms.Label lblCacheMinimum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCacheMinimum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCacheMinimum != null)
            {
            }

            _lblCacheMinimum = value;
            if (_lblCacheMinimum != null)
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

    private System.Windows.Forms.Label _lblCachePeak;

    internal System.Windows.Forms.Label lblCachePeak
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCachePeak;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCachePeak != null)
            {
            }

            _lblCachePeak = value;
            if (_lblCachePeak != null)
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

    private System.Windows.Forms.Label _lblCacheCurrent;

    internal System.Windows.Forms.Label lblCacheCurrent
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCacheCurrent;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCacheCurrent != null)
            {
            }

            _lblCacheCurrent = value;
            if (_lblCacheCurrent != null)
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

    private Graph2 _g2;

    internal Graph2 g2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _g2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_g2 != null)
            {
            }

            _g2 = value;
            if (_g2 != null)
            {
            }
        }
    }

    private Graph2 _g3;

    internal Graph2 g3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _g3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_g3 != null)
            {
            }

            _g3 = value;
            if (_g3 != null)
            {
            }
        }
    }

    private Graph2 _g4;

    internal Graph2 g4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _g4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_g4 != null)
            {
            }

            _g4 = value;
            if (_g4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkOneGraphPerCpu;

    internal System.Windows.Forms.CheckBox chkOneGraphPerCpu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkOneGraphPerCpu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkOneGraphPerCpu != null)
            {
            }

            _chkOneGraphPerCpu = value;
            if (_chkOneGraphPerCpu != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUTotalTime;

    internal System.Windows.Forms.Label lblCPUTotalTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUTotalTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUTotalTime != null)
            {
            }

            _lblCPUTotalTime = value;
            if (_lblCPUTotalTime != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label37;

    internal System.Windows.Forms.Label Label37
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label37;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label37 != null)
            {
            }

            _Label37 = value;
            if (_Label37 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblCPUUsage;

    internal System.Windows.Forms.Label lblCPUUsage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCPUUsage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCPUUsage != null)
            {
            }

            _lblCPUUsage = value;
            if (_lblCPUUsage != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label40;

    internal System.Windows.Forms.Label Label40
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label40;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label40 != null)
            {
            }

            _Label40 = value;
            if (_Label40 != null)
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
}

