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
partial class frmNetworkInfo : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNetworkInfo));
        this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        this.GroupBox7 = new System.Windows.Forms.GroupBox();
        this.lblNumConns = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.lblOutRsTs = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.lblInErrs = new System.Windows.Forms.Label();
        this.Label11 = new System.Windows.Forms.Label();
        this.lblRetransSegs = new System.Windows.Forms.Label();
        this.Label13 = new System.Windows.Forms.Label();
        this.lblOutSegs = new System.Windows.Forms.Label();
        this.Label15 = new System.Windows.Forms.Label();
        this.lblInSegs = new System.Windows.Forms.Label();
        this.Label37 = new System.Windows.Forms.Label();
        this.lblCurEstab = new System.Windows.Forms.Label();
        this.Label29 = new System.Windows.Forms.Label();
        this.lblEstabResets = new System.Windows.Forms.Label();
        this.Label23 = new System.Windows.Forms.Label();
        this.lblAttemptFails = new System.Windows.Forms.Label();
        this.Label33 = new System.Windows.Forms.Label();
        this.lblPassiveOpens = new System.Windows.Forms.Label();
        this.Label36 = new System.Windows.Forms.Label();
        this.lblActiveOpens = new System.Windows.Forms.Label();
        this.Label38 = new System.Windows.Forms.Label();
        this.lblMaxConn = new System.Windows.Forms.Label();
        this.Label34 = new System.Windows.Forms.Label();
        this.lblRtoMax = new System.Windows.Forms.Label();
        this.Label19 = new System.Windows.Forms.Label();
        this.lblRtoMin = new System.Windows.Forms.Label();
        this.Label27 = new System.Windows.Forms.Label();
        this.lblRtoAlgo = new System.Windows.Forms.Label();
        this.Label31 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.lblNumAddrs = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblInErrors = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.lblNoPorts = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.lblOutDatagrams = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.lblInDatagrams = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.SplitContainerGraphs = new System.Windows.Forms.SplitContainer();
        this.g1 = new Graph2();
        this.g2 = new Graph2();
        this.chkTopMost = new System.Windows.Forms.CheckBox();
        this.GroupBox7.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.SplitContainerGraphs.Panel1.SuspendLayout();
        this.SplitContainerGraphs.Panel2.SuspendLayout();
        this.SplitContainerGraphs.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.g1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.g2).BeginInit();
        this.SuspendLayout();
        // 
        // timerRefresh
        // 
        this.timerRefresh.Enabled = true;
        this.timerRefresh.Interval = 1000;
        // 
        // GroupBox7
        // 
        this.GroupBox7.Controls.Add(this.lblNumConns);
        this.GroupBox7.Controls.Add(this.Label5);
        this.GroupBox7.Controls.Add(this.lblOutRsTs);
        this.GroupBox7.Controls.Add(this.Label9);
        this.GroupBox7.Controls.Add(this.lblInErrs);
        this.GroupBox7.Controls.Add(this.Label11);
        this.GroupBox7.Controls.Add(this.lblRetransSegs);
        this.GroupBox7.Controls.Add(this.Label13);
        this.GroupBox7.Controls.Add(this.lblOutSegs);
        this.GroupBox7.Controls.Add(this.Label15);
        this.GroupBox7.Controls.Add(this.lblInSegs);
        this.GroupBox7.Controls.Add(this.Label37);
        this.GroupBox7.Controls.Add(this.lblCurEstab);
        this.GroupBox7.Controls.Add(this.Label29);
        this.GroupBox7.Controls.Add(this.lblEstabResets);
        this.GroupBox7.Controls.Add(this.Label23);
        this.GroupBox7.Controls.Add(this.lblAttemptFails);
        this.GroupBox7.Controls.Add(this.Label33);
        this.GroupBox7.Controls.Add(this.lblPassiveOpens);
        this.GroupBox7.Controls.Add(this.Label36);
        this.GroupBox7.Controls.Add(this.lblActiveOpens);
        this.GroupBox7.Controls.Add(this.Label38);
        this.GroupBox7.Controls.Add(this.lblMaxConn);
        this.GroupBox7.Controls.Add(this.Label34);
        this.GroupBox7.Controls.Add(this.lblRtoMax);
        this.GroupBox7.Controls.Add(this.Label19);
        this.GroupBox7.Controls.Add(this.lblRtoMin);
        this.GroupBox7.Controls.Add(this.Label27);
        this.GroupBox7.Controls.Add(this.lblRtoAlgo);
        this.GroupBox7.Controls.Add(this.Label31);
        this.GroupBox7.Location = new System.Drawing.Point(3, 3);
        this.GroupBox7.Name = "GroupBox7";
        this.GroupBox7.Size = new System.Drawing.Size(336, 148);
        this.GroupBox7.TabIndex = 21;
        this.GroupBox7.TabStop = false;
        this.GroupBox7.Text = "TCP stats";
        // 
        // lblNumConns
        // 
        this.lblNumConns.AutoSize = true;
        this.lblNumConns.Location = new System.Drawing.Point(252, 113);
        this.lblNumConns.Name = "lblNumConns";
        this.lblNumConns.Size = new System.Drawing.Size(0, 13);
        this.lblNumConns.TabIndex = 29;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(179, 113);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(64, 13);
        this.Label5.TabIndex = 28;
        this.Label5.Text = "NumConns";
        // 
        // lblOutRsTs
        // 
        this.lblOutRsTs.AutoSize = true;
        this.lblOutRsTs.Location = new System.Drawing.Point(252, 98);
        this.lblOutRsTs.Name = "lblOutRsTs";
        this.lblOutRsTs.Size = new System.Drawing.Size(0, 13);
        this.lblOutRsTs.TabIndex = 27;
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(179, 98);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(48, 13);
        this.Label9.TabIndex = 26;
        this.Label9.Text = "OutRsts";
        // 
        // lblInErrs
        // 
        this.lblInErrs.AutoSize = true;
        this.lblInErrs.Location = new System.Drawing.Point(252, 83);
        this.lblInErrs.Name = "lblInErrs";
        this.lblInErrs.Size = new System.Drawing.Size(0, 13);
        this.lblInErrs.TabIndex = 25;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(179, 83);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(36, 13);
        this.Label11.TabIndex = 24;
        this.Label11.Text = "InErrs";
        // 
        // lblRetransSegs
        // 
        this.lblRetransSegs.AutoSize = true;
        this.lblRetransSegs.Location = new System.Drawing.Point(252, 68);
        this.lblRetransSegs.Name = "lblRetransSegs";
        this.lblRetransSegs.Size = new System.Drawing.Size(0, 13);
        this.lblRetransSegs.TabIndex = 23;
        // 
        // Label13
        // 
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(179, 68);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(70, 13);
        this.Label13.TabIndex = 22;
        this.Label13.Text = "RetransSegs";
        // 
        // lblOutSegs
        // 
        this.lblOutSegs.AutoSize = true;
        this.lblOutSegs.Location = new System.Drawing.Point(252, 53);
        this.lblOutSegs.Name = "lblOutSegs";
        this.lblOutSegs.Size = new System.Drawing.Size(0, 13);
        this.lblOutSegs.TabIndex = 21;
        // 
        // Label15
        // 
        this.Label15.AutoSize = true;
        this.Label15.Location = new System.Drawing.Point(179, 53);
        this.Label15.Name = "Label15";
        this.Label15.Size = new System.Drawing.Size(51, 13);
        this.Label15.TabIndex = 20;
        this.Label15.Text = "OutSegs";
        // 
        // lblInSegs
        // 
        this.lblInSegs.AutoSize = true;
        this.lblInSegs.Location = new System.Drawing.Point(252, 38);
        this.lblInSegs.Name = "lblInSegs";
        this.lblInSegs.Size = new System.Drawing.Size(0, 13);
        this.lblInSegs.TabIndex = 19;
        // 
        // Label37
        // 
        this.Label37.AutoSize = true;
        this.Label37.Location = new System.Drawing.Point(179, 38);
        this.Label37.Name = "Label37";
        this.Label37.Size = new System.Drawing.Size(41, 13);
        this.Label37.TabIndex = 18;
        this.Label37.Text = "InSegs";
        // 
        // lblCurEstab
        // 
        this.lblCurEstab.AutoSize = true;
        this.lblCurEstab.Location = new System.Drawing.Point(252, 23);
        this.lblCurEstab.Name = "lblCurEstab";
        this.lblCurEstab.Size = new System.Drawing.Size(0, 13);
        this.lblCurEstab.TabIndex = 17;
        // 
        // Label29
        // 
        this.Label29.AutoSize = true;
        this.Label29.Location = new System.Drawing.Point(179, 23);
        this.Label29.Name = "Label29";
        this.Label29.Size = new System.Drawing.Size(53, 13);
        this.Label29.TabIndex = 16;
        this.Label29.Text = "CurEstab";
        // 
        // lblEstabResets
        // 
        this.lblEstabResets.AutoSize = true;
        this.lblEstabResets.Location = new System.Drawing.Point(93, 23);
        this.lblEstabResets.Name = "lblEstabResets";
        this.lblEstabResets.Size = new System.Drawing.Size(0, 13);
        this.lblEstabResets.TabIndex = 15;
        // 
        // Label23
        // 
        this.Label23.AutoSize = true;
        this.Label23.Location = new System.Drawing.Point(15, 23);
        this.Label23.Name = "Label23";
        this.Label23.Size = new System.Drawing.Size(68, 13);
        this.Label23.TabIndex = 14;
        this.Label23.Text = "EstabResets";
        // 
        // lblAttemptFails
        // 
        this.lblAttemptFails.AutoSize = true;
        this.lblAttemptFails.Location = new System.Drawing.Point(93, 113);
        this.lblAttemptFails.Name = "lblAttemptFails";
        this.lblAttemptFails.Size = new System.Drawing.Size(0, 13);
        this.lblAttemptFails.TabIndex = 13;
        // 
        // Label33
        // 
        this.Label33.AutoSize = true;
        this.Label33.Location = new System.Drawing.Point(15, 113);
        this.Label33.Name = "Label33";
        this.Label33.Size = new System.Drawing.Size(71, 13);
        this.Label33.TabIndex = 12;
        this.Label33.Text = "AttemptFails";
        // 
        // lblPassiveOpens
        // 
        this.lblPassiveOpens.AutoSize = true;
        this.lblPassiveOpens.Location = new System.Drawing.Point(93, 98);
        this.lblPassiveOpens.Name = "lblPassiveOpens";
        this.lblPassiveOpens.Size = new System.Drawing.Size(0, 13);
        this.lblPassiveOpens.TabIndex = 11;
        // 
        // Label36
        // 
        this.Label36.AutoSize = true;
        this.Label36.Location = new System.Drawing.Point(15, 98);
        this.Label36.Name = "Label36";
        this.Label36.Size = new System.Drawing.Size(77, 13);
        this.Label36.TabIndex = 10;
        this.Label36.Text = "PassiveOpens";
        // 
        // lblActiveOpens
        // 
        this.lblActiveOpens.AutoSize = true;
        this.lblActiveOpens.Location = new System.Drawing.Point(93, 83);
        this.lblActiveOpens.Name = "lblActiveOpens";
        this.lblActiveOpens.Size = new System.Drawing.Size(0, 13);
        this.lblActiveOpens.TabIndex = 9;
        // 
        // Label38
        // 
        this.Label38.AutoSize = true;
        this.Label38.Location = new System.Drawing.Point(15, 83);
        this.Label38.Name = "Label38";
        this.Label38.Size = new System.Drawing.Size(71, 13);
        this.Label38.TabIndex = 8;
        this.Label38.Text = "ActiveOpens";
        // 
        // lblMaxConn
        // 
        this.lblMaxConn.AutoSize = true;
        this.lblMaxConn.Location = new System.Drawing.Point(93, 68);
        this.lblMaxConn.Name = "lblMaxConn";
        this.lblMaxConn.Size = new System.Drawing.Size(0, 13);
        this.lblMaxConn.TabIndex = 7;
        // 
        // Label34
        // 
        this.Label34.AutoSize = true;
        this.Label34.Location = new System.Drawing.Point(15, 68);
        this.Label34.Name = "Label34";
        this.Label34.Size = new System.Drawing.Size(56, 13);
        this.Label34.TabIndex = 6;
        this.Label34.Text = "MaxConn";
        // 
        // lblRtoMax
        // 
        this.lblRtoMax.AutoSize = true;
        this.lblRtoMax.Location = new System.Drawing.Point(93, 53);
        this.lblRtoMax.Name = "lblRtoMax";
        this.lblRtoMax.Size = new System.Drawing.Size(0, 13);
        this.lblRtoMax.TabIndex = 5;
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(15, 53);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(46, 13);
        this.Label19.TabIndex = 4;
        this.Label19.Text = "RtoMax";
        // 
        // lblRtoMin
        // 
        this.lblRtoMin.AutoSize = true;
        this.lblRtoMin.Location = new System.Drawing.Point(93, 38);
        this.lblRtoMin.Name = "lblRtoMin";
        this.lblRtoMin.Size = new System.Drawing.Size(0, 13);
        this.lblRtoMin.TabIndex = 3;
        // 
        // Label27
        // 
        this.Label27.AutoSize = true;
        this.Label27.Location = new System.Drawing.Point(15, 38);
        this.Label27.Name = "Label27";
        this.Label27.Size = new System.Drawing.Size(45, 13);
        this.Label27.TabIndex = 2;
        this.Label27.Text = "RtoMin";
        // 
        // lblRtoAlgo
        // 
        this.lblRtoAlgo.AutoSize = true;
        this.lblRtoAlgo.Location = new System.Drawing.Point(93, 128);
        this.lblRtoAlgo.Name = "lblRtoAlgo";
        this.lblRtoAlgo.Size = new System.Drawing.Size(0, 13);
        this.lblRtoAlgo.TabIndex = 1;
        // 
        // Label31
        // 
        this.Label31.AutoSize = true;
        this.Label31.Location = new System.Drawing.Point(15, 128);
        this.Label31.Name = "Label31";
        this.Label31.Size = new System.Drawing.Size(76, 13);
        this.Label31.TabIndex = 0;
        this.Label31.Text = "RtoAlgorithm";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.lblNumAddrs);
        this.GroupBox1.Controls.Add(this.Label3);
        this.GroupBox1.Controls.Add(this.lblInErrors);
        this.GroupBox1.Controls.Add(this.Label8);
        this.GroupBox1.Controls.Add(this.lblNoPorts);
        this.GroupBox1.Controls.Add(this.Label6);
        this.GroupBox1.Controls.Add(this.lblOutDatagrams);
        this.GroupBox1.Controls.Add(this.Label4);
        this.GroupBox1.Controls.Add(this.lblInDatagrams);
        this.GroupBox1.Controls.Add(this.Label1);
        this.GroupBox1.Location = new System.Drawing.Point(345, 3);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(203, 103);
        this.GroupBox1.TabIndex = 20;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "UDP stats";
        // 
        // lblNumAddrs
        // 
        this.lblNumAddrs.AutoSize = true;
        this.lblNumAddrs.Location = new System.Drawing.Point(102, 83);
        this.lblNumAddrs.Name = "lblNumAddrs";
        this.lblNumAddrs.Size = new System.Drawing.Size(0, 13);
        this.lblNumAddrs.TabIndex = 9;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(15, 83);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(61, 13);
        this.Label3.TabIndex = 8;
        this.Label3.Text = "NumAddrs";
        // 
        // lblInErrors
        // 
        this.lblInErrors.AutoSize = true;
        this.lblInErrors.Location = new System.Drawing.Point(102, 68);
        this.lblInErrors.Name = "lblInErrors";
        this.lblInErrors.Size = new System.Drawing.Size(0, 13);
        this.lblInErrors.TabIndex = 7;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(15, 68);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(47, 13);
        this.Label8.TabIndex = 6;
        this.Label8.Text = "InErrors";
        // 
        // lblNoPorts
        // 
        this.lblNoPorts.AutoSize = true;
        this.lblNoPorts.Location = new System.Drawing.Point(102, 53);
        this.lblNoPorts.Name = "lblNoPorts";
        this.lblNoPorts.Size = new System.Drawing.Size(0, 13);
        this.lblNoPorts.TabIndex = 5;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(15, 53);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(48, 13);
        this.Label6.TabIndex = 4;
        this.Label6.Text = "NoPorts";
        // 
        // lblOutDatagrams
        // 
        this.lblOutDatagrams.AutoSize = true;
        this.lblOutDatagrams.Location = new System.Drawing.Point(102, 38);
        this.lblOutDatagrams.Name = "lblOutDatagrams";
        this.lblOutDatagrams.Size = new System.Drawing.Size(0, 13);
        this.lblOutDatagrams.TabIndex = 3;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(15, 38);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(82, 13);
        this.Label4.TabIndex = 2;
        this.Label4.Text = "OutDatagrams";
        // 
        // lblInDatagrams
        // 
        this.lblInDatagrams.AutoSize = true;
        this.lblInDatagrams.Location = new System.Drawing.Point(102, 23);
        this.lblInDatagrams.Name = "lblInDatagrams";
        this.lblInDatagrams.Size = new System.Drawing.Size(0, 13);
        this.lblInDatagrams.TabIndex = 1;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(15, 23);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(72, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "InDatagrams";
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
        this.SplitContainer.Panel1.Controls.Add(this.SplitContainerGraphs);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.chkTopMost);
        this.SplitContainer.Panel2.Controls.Add(this.GroupBox7);
        this.SplitContainer.Panel2.Controls.Add(this.GroupBox1);
        this.SplitContainer.Size = new System.Drawing.Size(640, 312);
        this.SplitContainer.SplitterDistance = 151;
        this.SplitContainer.TabIndex = 25;
        // 
        // SplitContainerGraphs
        // 
        this.SplitContainerGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainerGraphs.IsSplitterFixed = true;
        this.SplitContainerGraphs.Location = new System.Drawing.Point(0, 0);
        this.SplitContainerGraphs.Name = "SplitContainerGraphs";
        // 
        // SplitContainerGraphs.Panel1

        // 
        this.SplitContainerGraphs.Panel1.Controls.Add(this.g1);
        // 
        // SplitContainerGraphs.Panel2
        // 
        this.SplitContainerGraphs.Panel2.Controls.Add(this.g2);
        this.SplitContainerGraphs.Size = new System.Drawing.Size(640, 151);
        this.SplitContainerGraphs.SplitterDistance = 320;
        this.SplitContainerGraphs.TabIndex = 25;
        // 
        // g1
        // 
        this.g1.BackColor = System.Drawing.Color.Black;
        this.g1.Color2 = System.Drawing.Color.Olive;
        this.g1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.g1.EnableGraph = true;
        this.g1.Fixedheight = false;
        this.g1.GridStep = 13;
        this.g1.Location = new System.Drawing.Point(0, 0);
        this.g1.Name = "g1";
        this.g1.ShowSecondGraph = true;
        this.g1.Size = new System.Drawing.Size(320, 151);
        this.g1.TabIndex = 25;
        this.g1.TabStop = false;
        this.g1.TextColor = System.Drawing.Color.Lime;
        this.g1.TopText = null;
        // 
        // g2
        // 
        this.g2.BackColor = System.Drawing.Color.Black;
        this.g2.Color2 = System.Drawing.Color.Olive;
        this.g2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.g2.EnableGraph = true;
        this.g2.Fixedheight = false;
        this.g2.GridStep = 13;
        this.g2.Location = new System.Drawing.Point(0, 0);
        this.g2.Name = "g2";
        this.g2.ShowSecondGraph = true;
        this.g2.Size = new System.Drawing.Size(316, 151);
        this.g2.TabIndex = 24;
        this.g2.TabStop = false;
        this.g2.TextColor = System.Drawing.Color.Lime;
        this.g2.TopText = null;
        // 
        // chkTopMost
        // 
        this.chkTopMost.AutoSize = true;
        this.chkTopMost.Location = new System.Drawing.Point(345, 112);
        this.chkTopMost.Name = "chkTopMost";
        this.chkTopMost.Size = new System.Drawing.Size(99, 17);
        this.chkTopMost.TabIndex = 23;
        this.chkTopMost.Text = "Always on top";
        this.chkTopMost.UseVisualStyleBackColor = true;
        // 
        // frmNetworkInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(640, 312);
        this.Controls.Add(this.SplitContainer);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MinimumSize = new System.Drawing.Size(656, 350);
        this.Name = "frmNetworkInfo";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Network statistics";
        this.GroupBox7.ResumeLayout(false);
        this.GroupBox7.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.Panel2.PerformLayout();
        this.SplitContainer.ResumeLayout(false);
        this.SplitContainerGraphs.Panel1.ResumeLayout(false);
        this.SplitContainerGraphs.Panel2.ResumeLayout(false);
        this.SplitContainerGraphs.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.g1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.g2).EndInit();
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

    private System.Windows.Forms.Label _lblNumConns;

    internal System.Windows.Forms.Label lblNumConns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumConns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNumConns != null)
            {
            }

            _lblNumConns = value;
            if (_lblNumConns != null)
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

    private System.Windows.Forms.Label _lblOutRsTs;

    internal System.Windows.Forms.Label lblOutRsTs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOutRsTs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOutRsTs != null)
            {
            }

            _lblOutRsTs = value;
            if (_lblOutRsTs != null)
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

    private System.Windows.Forms.Label _lblInErrs;

    internal System.Windows.Forms.Label lblInErrs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInErrs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblInErrs != null)
            {
            }

            _lblInErrs = value;
            if (_lblInErrs != null)
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

    private System.Windows.Forms.Label _lblRetransSegs;

    internal System.Windows.Forms.Label lblRetransSegs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRetransSegs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRetransSegs != null)
            {
            }

            _lblRetransSegs = value;
            if (_lblRetransSegs != null)
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

    private System.Windows.Forms.Label _lblOutSegs;

    internal System.Windows.Forms.Label lblOutSegs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOutSegs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOutSegs != null)
            {
            }

            _lblOutSegs = value;
            if (_lblOutSegs != null)
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

    private System.Windows.Forms.Label _lblInSegs;

    internal System.Windows.Forms.Label lblInSegs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInSegs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblInSegs != null)
            {
            }

            _lblInSegs = value;
            if (_lblInSegs != null)
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

    private System.Windows.Forms.Label _lblCurEstab;

    internal System.Windows.Forms.Label lblCurEstab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCurEstab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCurEstab != null)
            {
            }

            _lblCurEstab = value;
            if (_lblCurEstab != null)
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

    private System.Windows.Forms.Label _lblEstabResets;

    internal System.Windows.Forms.Label lblEstabResets
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblEstabResets;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblEstabResets != null)
            {
            }

            _lblEstabResets = value;
            if (_lblEstabResets != null)
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

    private System.Windows.Forms.Label _lblAttemptFails;

    internal System.Windows.Forms.Label lblAttemptFails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAttemptFails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblAttemptFails != null)
            {
            }

            _lblAttemptFails = value;
            if (_lblAttemptFails != null)
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

    private System.Windows.Forms.Label _lblPassiveOpens;

    internal System.Windows.Forms.Label lblPassiveOpens
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPassiveOpens;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPassiveOpens != null)
            {
            }

            _lblPassiveOpens = value;
            if (_lblPassiveOpens != null)
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

    private System.Windows.Forms.Label _lblActiveOpens;

    internal System.Windows.Forms.Label lblActiveOpens
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblActiveOpens;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblActiveOpens != null)
            {
            }

            _lblActiveOpens = value;
            if (_lblActiveOpens != null)
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

    private System.Windows.Forms.Label _lblMaxConn;

    internal System.Windows.Forms.Label lblMaxConn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMaxConn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMaxConn != null)
            {
            }

            _lblMaxConn = value;
            if (_lblMaxConn != null)
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

    private System.Windows.Forms.Label _lblRtoMax;

    internal System.Windows.Forms.Label lblRtoMax
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRtoMax;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRtoMax != null)
            {
            }

            _lblRtoMax = value;
            if (_lblRtoMax != null)
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

    private System.Windows.Forms.Label _lblRtoMin;

    internal System.Windows.Forms.Label lblRtoMin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRtoMin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRtoMin != null)
            {
            }

            _lblRtoMin = value;
            if (_lblRtoMin != null)
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

    private System.Windows.Forms.Label _lblRtoAlgo;

    internal System.Windows.Forms.Label lblRtoAlgo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRtoAlgo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRtoAlgo != null)
            {
            }

            _lblRtoAlgo = value;
            if (_lblRtoAlgo != null)
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

    private System.Windows.Forms.Label _lblNumAddrs;

    internal System.Windows.Forms.Label lblNumAddrs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumAddrs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNumAddrs != null)
            {
            }

            _lblNumAddrs = value;
            if (_lblNumAddrs != null)
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

    private System.Windows.Forms.Label _lblInErrors;

    internal System.Windows.Forms.Label lblInErrors
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInErrors;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblInErrors != null)
            {
            }

            _lblInErrors = value;
            if (_lblInErrors != null)
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

    private System.Windows.Forms.Label _lblNoPorts;

    internal System.Windows.Forms.Label lblNoPorts
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNoPorts;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNoPorts != null)
            {
            }

            _lblNoPorts = value;
            if (_lblNoPorts != null)
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

    private System.Windows.Forms.Label _lblOutDatagrams;

    internal System.Windows.Forms.Label lblOutDatagrams
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOutDatagrams;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOutDatagrams != null)
            {
            }

            _lblOutDatagrams = value;
            if (_lblOutDatagrams != null)
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

    private System.Windows.Forms.Label _lblInDatagrams;

    internal System.Windows.Forms.Label lblInDatagrams
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInDatagrams;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblInDatagrams != null)
            {
            }

            _lblInDatagrams = value;
            if (_lblInDatagrams != null)
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

    private System.Windows.Forms.SplitContainer _SplitContainerGraphs;

    internal System.Windows.Forms.SplitContainer SplitContainerGraphs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SplitContainerGraphs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SplitContainerGraphs != null)
            {
            }

            _SplitContainerGraphs = value;
            if (_SplitContainerGraphs != null)
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

    private Graph2 _g1;

    internal Graph2 g1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _g1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_g1 != null)
            {
            }

            _g1 = value;
            if (_g1 != null)
            {
            }
        }
    }
}

