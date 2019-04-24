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
partial class frmJobInfo : System.Windows.Forms.Form
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
        cConnection CConnection2 = new cConnection();
        System.Windows.Forms.ListViewGroup ListViewGroup3 = new System.Windows.Forms.ListViewGroup("Processes", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup4 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobInfo));
        this.tabJob = new System.Windows.Forms.TabControl();
        this.pageGeneral = new System.Windows.Forms.TabPage();
        this.SplitContainer = new System.Windows.Forms.SplitContainer();
        this.cmdTerminateJob = new System.Windows.Forms.Button();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.lvProcess = new processesInJobList();
        this.c1 = new System.Windows.Forms.ColumnHeader();
        this.c2 = new System.Windows.Forms.ColumnHeader();
        this.c3 = new System.Windows.Forms.ColumnHeader();
        this.c4 = new System.Windows.Forms.ColumnHeader();
        this.c5 = new System.Windows.Forms.ColumnHeader();
        this.c7 = new System.Windows.Forms.ColumnHeader();
        this.c8 = new System.Windows.Forms.ColumnHeader();
        this.c9 = new System.Windows.Forms.ColumnHeader();
        this.c10 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.pageStats = new System.Windows.Forms.TabPage();
        this.GroupBox5 = new System.Windows.Forms.GroupBox();
        this.lblPageFaultCount = new System.Windows.Forms.Label();
        this.Label21 = new System.Windows.Forms.Label();
        this.lblSchedulingClass = new System.Windows.Forms.Label();
        this.Label27 = new System.Windows.Forms.Label();
        this.lblMaxWSS = new System.Windows.Forms.Label();
        this.Label25 = new System.Windows.Forms.Label();
        this.lblMinWSS = new System.Windows.Forms.Label();
        this.Label19 = new System.Windows.Forms.Label();
        this.lblTotalTerminatedProcesses = new System.Windows.Forms.Label();
        this.Label37 = new System.Windows.Forms.Label();
        this.lblActiveProcesses = new System.Windows.Forms.Label();
        this.lbl789 = new System.Windows.Forms.Label();
        this.lblTotalProcesses = new System.Windows.Forms.Label();
        this.Label53 = new System.Windows.Forms.Label();
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.lblOthersBD = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.lblOtherD = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.lblWBD = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.lblWD = new System.Windows.Forms.Label();
        this.Label11 = new System.Windows.Forms.Label();
        this.lblRBD = new System.Windows.Forms.Label();
        this.Label34 = new System.Windows.Forms.Label();
        this.lblRD = new System.Windows.Forms.Label();
        this.Label41 = new System.Windows.Forms.Label();
        this.lblProcOtherBytes = new System.Windows.Forms.Label();
        this.Label23 = new System.Windows.Forms.Label();
        this.lblProcOther = new System.Windows.Forms.Label();
        this.Label30 = new System.Windows.Forms.Label();
        this.lblProcWriteBytes = new System.Windows.Forms.Label();
        this.Label36 = new System.Windows.Forms.Label();
        this.lblProcWrites = new System.Windows.Forms.Label();
        this.Label38 = new System.Windows.Forms.Label();
        this.lblProcReadBytes = new System.Windows.Forms.Label();
        this.Label40 = new System.Windows.Forms.Label();
        this.lblProcReads = new System.Windows.Forms.Label();
        this.Label42 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.lblPriority = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.lblTotalPeriod = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.lblUserPeriod = new System.Windows.Forms.Label();
        this.Label10 = new System.Windows.Forms.Label();
        this.lblPeriodKernel = new System.Windows.Forms.Label();
        this.Label28 = new System.Windows.Forms.Label();
        this.lblTotalTime = new System.Windows.Forms.Label();
        this.Label24 = new System.Windows.Forms.Label();
        this.lblUserTime = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.lblKernelTime = new System.Windows.Forms.Label();
        this.Label20 = new System.Windows.Forms.Label();
        this.lblAffinity = new System.Windows.Forms.Label();
        this.Label18 = new System.Windows.Forms.Label();
        this.pageLimitations = new System.Windows.Forms.TabPage();
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.cmdSetLimits = new System.Windows.Forms.Button();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.lvLimits = new jobLimitList();
        this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.VistaMenu = new wyDay.Controls.VistaMenu(this.components);
        this.MenuItemCopyLimit = new System.Windows.Forms.MenuItem();
        this.MenuItemProcKill = new System.Windows.Forms.MenuItem();
        this.MenuItemProcStop = new System.Windows.Forms.MenuItem();
        this.MenuItemProcResume = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPIdle = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPBN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPAN = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPH = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPRT = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSFileProp = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSOpenDir = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSFileDetails = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSSearch = new System.Windows.Forms.MenuItem();
        this.MenuItemProcSDep = new System.Windows.Forms.MenuItem();
        this.MenuItemCopyProcess = new System.Windows.Forms.MenuItem();
        this.TimerLimits = new System.Windows.Forms.Timer(this.components);
        this.mnuLimit = new System.Windows.Forms.ContextMenu();
        this.mnuProcess = new System.Windows.Forms.ContextMenu();
        this.MenuItemProcKillT = new System.Windows.Forms.MenuItem();
        this.MenuItemProcKillByMethod = new System.Windows.Forms.MenuItem();
        this.MenuItemProcPriority = new System.Windows.Forms.MenuItem();
        this.MenuItem44 = new System.Windows.Forms.MenuItem();
        this.MenuItem35 = new System.Windows.Forms.MenuItem();
        this.MenuItemProcWSS = new System.Windows.Forms.MenuItem();
        this.MenuItemProcAff = new System.Windows.Forms.MenuItem();
        this.MenuItemProcDump = new System.Windows.Forms.MenuItem();
        this.MenuItem51 = new System.Windows.Forms.MenuItem();
        this.MenuItem38 = new System.Windows.Forms.MenuItem();
        this.MenuItemProcColumns = new System.Windows.Forms.MenuItem();
        this.tabJob.SuspendLayout();
        this.pageGeneral.SuspendLayout();
        this.SplitContainer.Panel1.SuspendLayout();
        this.SplitContainer.Panel2.SuspendLayout();
        this.SplitContainer.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.pageStats.SuspendLayout();
        this.GroupBox5.SuspendLayout();
        this.GroupBox4.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.pageLimitations.SuspendLayout();
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).BeginInit();
        this.SuspendLayout();
        // 
        // tabJob
        // 
        this.tabJob.Controls.Add(this.pageGeneral);
        this.tabJob.Controls.Add(this.pageStats);
        this.tabJob.Controls.Add(this.pageLimitations);
        this.tabJob.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabJob.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tabJob.Location = new System.Drawing.Point(0, 0);
        this.tabJob.Multiline = true;
        this.tabJob.Name = "tabJob";
        this.tabJob.SelectedIndex = 0;
        this.tabJob.Size = new System.Drawing.Size(703, 337);
        this.tabJob.TabIndex = 0;
        // 
        // pageGeneral
        // 
        this.pageGeneral.Controls.Add(this.SplitContainer);
        this.pageGeneral.Location = new System.Drawing.Point(4, 22);
        this.pageGeneral.Name = "pageGeneral";
        this.pageGeneral.Padding = new System.Windows.Forms.Padding(3);
        this.pageGeneral.Size = new System.Drawing.Size(695, 311);
        this.pageGeneral.TabIndex = 0;
        this.pageGeneral.Text = "General";
        this.pageGeneral.UseVisualStyleBackColor = true;
        // 
        // SplitContainer
        // 
        this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer.Location = new System.Drawing.Point(3, 3);
        this.SplitContainer.Name = "SplitContainer";
        this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer.Panel1
        // 
        this.SplitContainer.Panel1.Controls.Add(this.cmdTerminateJob);
        // 
        // SplitContainer.Panel2
        // 
        this.SplitContainer.Panel2.Controls.Add(this.GroupBox1);
        this.SplitContainer.Size = new System.Drawing.Size(689, 305);
        this.SplitContainer.SplitterDistance = 25;
        this.SplitContainer.TabIndex = 19;
        // 
        // cmdTerminateJob
        // 
        this.cmdTerminateJob.Image = global::My.Resources.Resources.cross16;
        this.cmdTerminateJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdTerminateJob.Location = new System.Drawing.Point(5, 0);
        this.cmdTerminateJob.Name = "cmdTerminateJob";
        this.cmdTerminateJob.Size = new System.Drawing.Size(105, 23);
        this.cmdTerminateJob.TabIndex = 19;
        this.cmdTerminateJob.Text = "Terminate job";
        this.cmdTerminateJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdTerminateJob.UseVisualStyleBackColor = true;
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.lvProcess);
        this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.GroupBox1.Location = new System.Drawing.Point(0, 0);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(689, 276);
        this.GroupBox1.TabIndex = 17;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Processes in job";
        // 
        // lvProcess
        // 
        this.lvProcess.AllowColumnReorder = true;
        this.lvProcess.CatchErrors = false;
        this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.c1, this.c2, this.c3, this.c4, this.c5, this.c7, this.c8, this.c9, this.c10, this.ColumnHeader20 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        this.lvProcess.ConnectionObj = CConnection1;
        this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvProcess.FullRowSelect = true;
        ListViewGroup1.Header = "Processes";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvProcess.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvProcess.HideSelection = false;
        this.lvProcess.IsConnected = false;
        this.lvProcess.Job = null;
        this.lvProcess.Location = new System.Drawing.Point(3, 18);
        this.lvProcess.Name = "lvProcess";
        this.lvProcess.OverriddenDoubleBuffered = true;
        this.lvProcess.ReorganizeColumns = true;
        this.lvProcess.ShowObjectDetailsOnDoubleClick = false;
        this.lvProcess.Size = new System.Drawing.Size(683, 255);
        this.lvProcess.TabIndex = 4;
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
        this.c2.Width = 40;
        // 
        // c3
        // 
        this.c3.Text = "UserName";
        this.c3.Width = 100;
        // 
        // c4
        // 
        this.c4.DisplayIndex = 5;
        this.c4.Text = "TotalCpuTime";
        this.c4.Width = 80;
        // 
        // c5
        // 
        this.c5.DisplayIndex = 6;
        this.c5.Text = "WorkingSet";
        this.c5.Width = 80;
        // 
        // c7
        // 
        this.c7.DisplayIndex = 7;
        this.c7.Text = "Priority";
        this.c7.Width = 70;
        // 
        // c8
        // 
        this.c8.DisplayIndex = 8;
        this.c8.Text = "Path";
        this.c8.Width = 350;
        // 
        // c9
        // 
        this.c9.DisplayIndex = 9;
        this.c9.Text = "StartTime";
        this.c9.Width = 250;
        // 
        // c10
        // 
        this.c10.DisplayIndex = 3;
        this.c10.Text = "CpuUsage";
        // 
        // ColumnHeader20
        // 
        this.ColumnHeader20.DisplayIndex = 4;
        this.ColumnHeader20.Text = "AverageCpuUsage";
        // 
        // pageStats
        // 
        this.pageStats.Controls.Add(this.GroupBox5);
        this.pageStats.Controls.Add(this.GroupBox4);
        this.pageStats.Controls.Add(this.GroupBox2);
        this.pageStats.Location = new System.Drawing.Point(4, 22);
        this.pageStats.Name = "pageStats";
        this.pageStats.Padding = new System.Windows.Forms.Padding(3);
        this.pageStats.Size = new System.Drawing.Size(695, 311);
        this.pageStats.TabIndex = 8;
        this.pageStats.Text = "Statistics";
        this.pageStats.UseVisualStyleBackColor = true;
        // 
        // GroupBox5
        // 
        this.GroupBox5.Controls.Add(this.lblPageFaultCount);
        this.GroupBox5.Controls.Add(this.Label21);
        this.GroupBox5.Controls.Add(this.lblSchedulingClass);
        this.GroupBox5.Controls.Add(this.Label27);
        this.GroupBox5.Controls.Add(this.lblMaxWSS);
        this.GroupBox5.Controls.Add(this.Label25);
        this.GroupBox5.Controls.Add(this.lblMinWSS);
        this.GroupBox5.Controls.Add(this.Label19);
        this.GroupBox5.Controls.Add(this.lblTotalTerminatedProcesses);
        this.GroupBox5.Controls.Add(this.Label37);
        this.GroupBox5.Controls.Add(this.lblActiveProcesses);
        this.GroupBox5.Controls.Add(this.lbl789);
        this.GroupBox5.Controls.Add(this.lblTotalProcesses);
        this.GroupBox5.Controls.Add(this.Label53);
        this.GroupBox5.Location = new System.Drawing.Point(396, 7);
        this.GroupBox5.Name = "GroupBox5";
        this.GroupBox5.Size = new System.Drawing.Size(222, 173);
        this.GroupBox5.TabIndex = 7;
        this.GroupBox5.TabStop = false;
        this.GroupBox5.Text = "Other";
        // 
        // lblPageFaultCount
        // 
        this.lblPageFaultCount.AutoSize = true;
        this.lblPageFaultCount.Location = new System.Drawing.Point(155, 126);
        this.lblPageFaultCount.Name = "lblPageFaultCount";
        this.lblPageFaultCount.Size = new System.Drawing.Size(19, 13);
        this.lblPageFaultCount.TabIndex = 13;
        this.lblPageFaultCount.Text = "00";
        this.lblPageFaultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label21
        // 
        this.Label21.AutoSize = true;
        this.Label21.Location = new System.Drawing.Point(8, 126);
        this.Label21.Name = "Label21";
        this.Label21.Size = new System.Drawing.Size(115, 13);
        this.Label21.TabIndex = 12;
        this.Label21.Text = "TotalPageFaultCount";
        // 
        // lblSchedulingClass
        // 
        this.lblSchedulingClass.AutoSize = true;
        this.lblSchedulingClass.Location = new System.Drawing.Point(155, 108);
        this.lblSchedulingClass.Name = "lblSchedulingClass";
        this.lblSchedulingClass.Size = new System.Drawing.Size(19, 13);
        this.lblSchedulingClass.TabIndex = 11;
        this.lblSchedulingClass.Text = "00";
        this.lblSchedulingClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label27
        // 
        this.Label27.AutoSize = true;
        this.Label27.Location = new System.Drawing.Point(8, 108);
        this.Label27.Name = "Label27";
        this.Label27.Size = new System.Drawing.Size(91, 13);
        this.Label27.TabIndex = 10;
        this.Label27.Text = "SchedulingClass";
        // 
        // lblMaxWSS
        // 
        this.lblMaxWSS.AutoSize = true;
        this.lblMaxWSS.Location = new System.Drawing.Point(155, 90);
        this.lblMaxWSS.Name = "lblMaxWSS";
        this.lblMaxWSS.Size = new System.Drawing.Size(19, 13);
        this.lblMaxWSS.TabIndex = 9;
        this.lblMaxWSS.Text = "00";
        this.lblMaxWSS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label25
        // 
        this.Label25.AutoSize = true;
        this.Label25.Location = new System.Drawing.Point(8, 90);
        this.Label25.Name = "Label25";
        this.Label25.Size = new System.Drawing.Size(137, 13);
        this.Label25.TabIndex = 8;
        this.Label25.Text = "MaximumWorkingSetSize";
        // 
        // lblMinWSS
        // 
        this.lblMinWSS.AutoSize = true;
        this.lblMinWSS.Location = new System.Drawing.Point(155, 72);
        this.lblMinWSS.Name = "lblMinWSS";
        this.lblMinWSS.Size = new System.Drawing.Size(19, 13);
        this.lblMinWSS.TabIndex = 7;
        this.lblMinWSS.Text = "00";
        this.lblMinWSS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(8, 72);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(136, 13);
        this.Label19.TabIndex = 6;
        this.Label19.Text = "MinimumWorkingSetSize";
        // 
        // lblTotalTerminatedProcesses
        // 
        this.lblTotalTerminatedProcesses.AutoSize = true;
        this.lblTotalTerminatedProcesses.Location = new System.Drawing.Point(155, 54);
        this.lblTotalTerminatedProcesses.Name = "lblTotalTerminatedProcesses";
        this.lblTotalTerminatedProcesses.Size = new System.Drawing.Size(19, 13);
        this.lblTotalTerminatedProcesses.TabIndex = 5;
        this.lblTotalTerminatedProcesses.Text = "00";
        this.lblTotalTerminatedProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label37
        // 
        this.Label37.AutoSize = true;
        this.Label37.Location = new System.Drawing.Point(8, 54);
        this.Label37.Name = "Label37";
        this.Label37.Size = new System.Drawing.Size(144, 13);
        this.Label37.TabIndex = 4;
        this.Label37.Text = "Total terminated processes";
        // 
        // lblActiveProcesses
        // 
        this.lblActiveProcesses.AutoSize = true;
        this.lblActiveProcesses.Location = new System.Drawing.Point(155, 35);
        this.lblActiveProcesses.Name = "lblActiveProcesses";
        this.lblActiveProcesses.Size = new System.Drawing.Size(19, 13);
        this.lblActiveProcesses.TabIndex = 3;
        this.lblActiveProcesses.Text = "00";
        this.lblActiveProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbl789
        // 
        this.lbl789.AutoSize = true;
        this.lbl789.Location = new System.Drawing.Point(8, 35);
        this.lbl789.Name = "lbl789";
        this.lbl789.Size = new System.Drawing.Size(90, 13);
        this.lbl789.TabIndex = 2;
        this.lbl789.Text = "Active processes";
        // 
        // lblTotalProcesses
        // 
        this.lblTotalProcesses.AutoSize = true;
        this.lblTotalProcesses.Location = new System.Drawing.Point(155, 16);
        this.lblTotalProcesses.Name = "lblTotalProcesses";
        this.lblTotalProcesses.Size = new System.Drawing.Size(19, 13);
        this.lblTotalProcesses.TabIndex = 1;
        this.lblTotalProcesses.Text = "00";
        this.lblTotalProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label53
        // 
        this.Label53.AutoSize = true;
        this.Label53.Location = new System.Drawing.Point(8, 16);
        this.Label53.Name = "Label53";
        this.Label53.Size = new System.Drawing.Size(85, 13);
        this.Label53.TabIndex = 0;
        this.Label53.Text = "Total processes";
        // 
        // GroupBox4
        // 
        this.GroupBox4.Controls.Add(this.lblOthersBD);
        this.GroupBox4.Controls.Add(this.Label5);
        this.GroupBox4.Controls.Add(this.lblOtherD);
        this.GroupBox4.Controls.Add(this.Label7);
        this.GroupBox4.Controls.Add(this.lblWBD);
        this.GroupBox4.Controls.Add(this.Label9);
        this.GroupBox4.Controls.Add(this.lblWD);
        this.GroupBox4.Controls.Add(this.Label11);
        this.GroupBox4.Controls.Add(this.lblRBD);
        this.GroupBox4.Controls.Add(this.Label34);
        this.GroupBox4.Controls.Add(this.lblRD);
        this.GroupBox4.Controls.Add(this.Label41);
        this.GroupBox4.Controls.Add(this.lblProcOtherBytes);
        this.GroupBox4.Controls.Add(this.Label23);
        this.GroupBox4.Controls.Add(this.lblProcOther);
        this.GroupBox4.Controls.Add(this.Label30);
        this.GroupBox4.Controls.Add(this.lblProcWriteBytes);
        this.GroupBox4.Controls.Add(this.Label36);
        this.GroupBox4.Controls.Add(this.lblProcWrites);
        this.GroupBox4.Controls.Add(this.Label38);
        this.GroupBox4.Controls.Add(this.lblProcReadBytes);
        this.GroupBox4.Controls.Add(this.Label40);
        this.GroupBox4.Controls.Add(this.lblProcReads);
        this.GroupBox4.Controls.Add(this.Label42);
        this.GroupBox4.Location = new System.Drawing.Point(8, 6);
        this.GroupBox4.Name = "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(176, 265);
        this.GroupBox4.TabIndex = 6;
        this.GroupBox4.TabStop = false;
        this.GroupBox4.Text = "I/O";
        // 
        // lblOthersBD
        // 
        this.lblOthersBD.AutoSize = true;
        this.lblOthersBD.Location = new System.Drawing.Point(102, 217);
        this.lblOthersBD.Name = "lblOthersBD";
        this.lblOthersBD.Size = new System.Drawing.Size(19, 13);
        this.lblOthersBD.TabIndex = 43;
        this.lblOthersBD.Text = "00";
        this.lblOthersBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(6, 217);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(96, 13);
        this.Label5.TabIndex = 42;
        this.Label5.Text = "Other bytes delta";
        // 
        // lblOtherD
        // 
        this.lblOtherD.AutoSize = true;
        this.lblOtherD.Location = new System.Drawing.Point(102, 199);
        this.lblOtherD.Name = "lblOtherD";
        this.lblOtherD.Size = new System.Drawing.Size(19, 13);
        this.lblOtherD.TabIndex = 41;
        this.lblOtherD.Text = "00";
        this.lblOtherD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(6, 199);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(66, 13);
        this.Label7.TabIndex = 40;
        this.Label7.Text = "Other delta";
        // 
        // lblWBD
        // 
        this.lblWBD.AutoSize = true;
        this.lblWBD.Location = new System.Drawing.Point(102, 180);
        this.lblWBD.Name = "lblWBD";
        this.lblWBD.Size = new System.Drawing.Size(19, 13);
        this.lblWBD.TabIndex = 39;
        this.lblWBD.Text = "00";
        this.lblWBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(6, 180);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(94, 13);
        this.Label9.TabIndex = 38;
        this.Label9.Text = "Write bytes delta";
        // 
        // lblWD
        // 
        this.lblWD.AutoSize = true;
        this.lblWD.Location = new System.Drawing.Point(102, 162);
        this.lblWD.Name = "lblWD";
        this.lblWD.Size = new System.Drawing.Size(19, 13);
        this.lblWD.TabIndex = 37;
        this.lblWD.Text = "00";
        this.lblWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label11
        // 
        this.Label11.AutoSize = true;
        this.Label11.Location = new System.Drawing.Point(6, 162);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(69, 13);
        this.Label11.TabIndex = 36;
        this.Label11.Text = "Writes delta";
        // 
        // lblRBD
        // 
        this.lblRBD.AutoSize = true;
        this.lblRBD.Location = new System.Drawing.Point(102, 144);
        this.lblRBD.Name = "lblRBD";
        this.lblRBD.Size = new System.Drawing.Size(19, 13);
        this.lblRBD.TabIndex = 35;
        this.lblRBD.Text = "00";
        this.lblRBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label34
        // 
        this.Label34.AutoSize = true;
        this.Label34.Location = new System.Drawing.Point(6, 144);
        this.Label34.Name = "Label34";
        this.Label34.Size = new System.Drawing.Size(92, 13);
        this.Label34.TabIndex = 34;
        this.Label34.Text = "Read bytes delta";
        // 
        // lblRD
        // 
        this.lblRD.AutoSize = true;
        this.lblRD.Location = new System.Drawing.Point(102, 126);
        this.lblRD.Name = "lblRD";
        this.lblRD.Size = new System.Drawing.Size(19, 13);
        this.lblRD.TabIndex = 33;
        this.lblRD.Text = "00";
        this.lblRD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label41
        // 
        this.Label41.AutoSize = true;
        this.Label41.Location = new System.Drawing.Point(6, 126);
        this.Label41.Name = "Label41";
        this.Label41.Size = new System.Drawing.Size(67, 13);
        this.Label41.TabIndex = 32;
        this.Label41.Text = "Reads delta";
        // 
        // lblProcOtherBytes
        // 
        this.lblProcOtherBytes.AutoSize = true;
        this.lblProcOtherBytes.Location = new System.Drawing.Point(102, 107);
        this.lblProcOtherBytes.Name = "lblProcOtherBytes";
        this.lblProcOtherBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcOtherBytes.TabIndex = 31;
        this.lblProcOtherBytes.Text = "00";
        this.lblProcOtherBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label23
        // 
        this.Label23.AutoSize = true;
        this.Label23.Location = new System.Drawing.Point(6, 107);
        this.Label23.Name = "Label23";
        this.Label23.Size = new System.Drawing.Size(67, 13);
        this.Label23.TabIndex = 30;
        this.Label23.Text = "Other bytes";
        // 
        // lblProcOther
        // 
        this.lblProcOther.AutoSize = true;
        this.lblProcOther.Location = new System.Drawing.Point(102, 89);
        this.lblProcOther.Name = "lblProcOther";
        this.lblProcOther.Size = new System.Drawing.Size(19, 13);
        this.lblProcOther.TabIndex = 29;
        this.lblProcOther.Text = "00";
        this.lblProcOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label30
        // 
        this.Label30.AutoSize = true;
        this.Label30.Location = new System.Drawing.Point(6, 89);
        this.Label30.Name = "Label30";
        this.Label30.Size = new System.Drawing.Size(37, 13);
        this.Label30.TabIndex = 28;
        this.Label30.Text = "Other";
        // 
        // lblProcWriteBytes
        // 
        this.lblProcWriteBytes.AutoSize = true;
        this.lblProcWriteBytes.Location = new System.Drawing.Point(102, 70);
        this.lblProcWriteBytes.Name = "lblProcWriteBytes";
        this.lblProcWriteBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcWriteBytes.TabIndex = 27;
        this.lblProcWriteBytes.Text = "00";
        this.lblProcWriteBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label36
        // 
        this.Label36.AutoSize = true;
        this.Label36.Location = new System.Drawing.Point(6, 70);
        this.Label36.Name = "Label36";
        this.Label36.Size = new System.Drawing.Size(65, 13);
        this.Label36.TabIndex = 26;
        this.Label36.Text = "Write bytes";
        // 
        // lblProcWrites
        // 
        this.lblProcWrites.AutoSize = true;
        this.lblProcWrites.Location = new System.Drawing.Point(102, 52);
        this.lblProcWrites.Name = "lblProcWrites";
        this.lblProcWrites.Size = new System.Drawing.Size(19, 13);
        this.lblProcWrites.TabIndex = 25;
        this.lblProcWrites.Text = "00";
        this.lblProcWrites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label38
        // 
        this.Label38.AutoSize = true;
        this.Label38.Location = new System.Drawing.Point(6, 52);
        this.Label38.Name = "Label38";
        this.Label38.Size = new System.Drawing.Size(40, 13);
        this.Label38.TabIndex = 24;
        this.Label38.Text = "Writes";
        // 
        // lblProcReadBytes
        // 
        this.lblProcReadBytes.AutoSize = true;
        this.lblProcReadBytes.Location = new System.Drawing.Point(102, 34);
        this.lblProcReadBytes.Name = "lblProcReadBytes";
        this.lblProcReadBytes.Size = new System.Drawing.Size(19, 13);
        this.lblProcReadBytes.TabIndex = 23;
        this.lblProcReadBytes.Text = "00";
        this.lblProcReadBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label40
        // 
        this.Label40.AutoSize = true;
        this.Label40.Location = new System.Drawing.Point(6, 34);
        this.Label40.Name = "Label40";
        this.Label40.Size = new System.Drawing.Size(63, 13);
        this.Label40.TabIndex = 22;
        this.Label40.Text = "Read bytes";
        // 
        // lblProcReads
        // 
        this.lblProcReads.AutoSize = true;
        this.lblProcReads.Location = new System.Drawing.Point(102, 16);
        this.lblProcReads.Name = "lblProcReads";
        this.lblProcReads.Size = new System.Drawing.Size(19, 13);
        this.lblProcReads.TabIndex = 21;
        this.lblProcReads.Text = "00";
        this.lblProcReads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label42
        // 
        this.Label42.AutoSize = true;
        this.Label42.Location = new System.Drawing.Point(6, 16);
        this.Label42.Name = "Label42";
        this.Label42.Size = new System.Drawing.Size(38, 13);
        this.Label42.TabIndex = 20;
        this.Label42.Text = "Reads";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.lblPriority);
        this.GroupBox2.Controls.Add(this.Label8);
        this.GroupBox2.Controls.Add(this.lblTotalPeriod);
        this.GroupBox2.Controls.Add(this.Label6);
        this.GroupBox2.Controls.Add(this.lblUserPeriod);
        this.GroupBox2.Controls.Add(this.Label10);
        this.GroupBox2.Controls.Add(this.lblPeriodKernel);
        this.GroupBox2.Controls.Add(this.Label28);
        this.GroupBox2.Controls.Add(this.lblTotalTime);
        this.GroupBox2.Controls.Add(this.Label24);
        this.GroupBox2.Controls.Add(this.lblUserTime);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.lblKernelTime);
        this.GroupBox2.Controls.Add(this.Label20);
        this.GroupBox2.Controls.Add(this.lblAffinity);
        this.GroupBox2.Controls.Add(this.Label18);
        this.GroupBox2.Location = new System.Drawing.Point(190, 6);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(200, 174);
        this.GroupBox2.TabIndex = 4;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "CPU";
        // 
        // lblPriority
        // 
        this.lblPriority.AutoSize = true;
        this.lblPriority.Location = new System.Drawing.Point(116, 146);
        this.lblPriority.Name = "lblPriority";
        this.lblPriority.Size = new System.Drawing.Size(0, 13);
        this.lblPriority.TabIndex = 15;
        this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(6, 146);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(43, 13);
        this.Label8.TabIndex = 14;
        this.Label8.Text = "Priority";
        // 
        // lblTotalPeriod
        // 
        this.lblTotalPeriod.AutoSize = true;
        this.lblTotalPeriod.Location = new System.Drawing.Point(116, 128);
        this.lblTotalPeriod.Name = "lblTotalPeriod";
        this.lblTotalPeriod.Size = new System.Drawing.Size(70, 13);
        this.lblTotalPeriod.TabIndex = 13;
        this.lblTotalPeriod.Text = "00:00:00.158";
        this.lblTotalPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(6, 128);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(100, 13);
        this.Label6.TabIndex = 12;
        this.Label6.Text = "Total time (period)";
        // 
        // lblUserPeriod
        // 
        this.lblUserPeriod.AutoSize = true;
        this.lblUserPeriod.Location = new System.Drawing.Point(116, 109);
        this.lblUserPeriod.Name = "lblUserPeriod";
        this.lblUserPeriod.Size = new System.Drawing.Size(19, 13);
        this.lblUserPeriod.TabIndex = 11;
        this.lblUserPeriod.Text = "00";
        this.lblUserPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(6, 109);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(98, 13);
        this.Label10.TabIndex = 10;
        this.Label10.Text = "User time (period)";
        // 
        // lblPeriodKernel
        // 
        this.lblPeriodKernel.AutoSize = true;
        this.lblPeriodKernel.Location = new System.Drawing.Point(116, 91);
        this.lblPeriodKernel.Name = "lblPeriodKernel";
        this.lblPeriodKernel.Size = new System.Drawing.Size(19, 13);
        this.lblPeriodKernel.TabIndex = 9;
        this.lblPeriodKernel.Text = "00";
        this.lblPeriodKernel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label28
        // 
        this.Label28.AutoSize = true;
        this.Label28.Location = new System.Drawing.Point(6, 91);
        this.Label28.Name = "Label28";
        this.Label28.Size = new System.Drawing.Size(107, 13);
        this.Label28.TabIndex = 8;
        this.Label28.Text = "Kernel time (period)";
        // 
        // lblTotalTime
        // 
        this.lblTotalTime.AutoSize = true;
        this.lblTotalTime.Location = new System.Drawing.Point(114, 73);
        this.lblTotalTime.Name = "lblTotalTime";
        this.lblTotalTime.Size = new System.Drawing.Size(70, 13);
        this.lblTotalTime.TabIndex = 7;
        this.lblTotalTime.Text = "00:00:00.158";
        this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label24
        // 
        this.Label24.AutoSize = true;
        this.Label24.Location = new System.Drawing.Point(6, 73);
        this.Label24.Name = "Label24";
        this.Label24.Size = new System.Drawing.Size(57, 13);
        this.Label24.TabIndex = 6;
        this.Label24.Text = "Total time";
        // 
        // lblUserTime
        // 
        this.lblUserTime.AutoSize = true;
        this.lblUserTime.Location = new System.Drawing.Point(114, 54);
        this.lblUserTime.Name = "lblUserTime";
        this.lblUserTime.Size = new System.Drawing.Size(19, 13);
        this.lblUserTime.TabIndex = 5;
        this.lblUserTime.Text = "00";
        this.lblUserTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 54);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(55, 13);
        this.Label4.TabIndex = 4;
        this.Label4.Text = "User time";
        // 
        // lblKernelTime
        // 
        this.lblKernelTime.AutoSize = true;
        this.lblKernelTime.Location = new System.Drawing.Point(114, 36);
        this.lblKernelTime.Name = "lblKernelTime";
        this.lblKernelTime.Size = new System.Drawing.Size(19, 13);
        this.lblKernelTime.TabIndex = 3;
        this.lblKernelTime.Text = "00";
        this.lblKernelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label20
        // 
        this.Label20.AutoSize = true;
        this.Label20.Location = new System.Drawing.Point(6, 36);
        this.Label20.Name = "Label20";
        this.Label20.Size = new System.Drawing.Size(64, 13);
        this.Label20.TabIndex = 2;
        this.Label20.Text = "Kernel time";
        // 
        // lblAffinity
        // 
        this.lblAffinity.AutoSize = true;
        this.lblAffinity.Location = new System.Drawing.Point(114, 18);
        this.lblAffinity.Name = "lblAffinity";
        this.lblAffinity.Size = new System.Drawing.Size(19, 13);
        this.lblAffinity.TabIndex = 1;
        this.lblAffinity.Text = "00";
        this.lblAffinity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label18
        // 
        this.Label18.AutoSize = true;
        this.Label18.Location = new System.Drawing.Point(6, 18);
        this.Label18.Name = "Label18";
        this.Label18.Size = new System.Drawing.Size(44, 13);
        this.Label18.TabIndex = 0;
        this.Label18.Text = "Affinity";
        // 
        // pageLimitations
        // 
        this.pageLimitations.Controls.Add(this.SplitContainer1);
        this.pageLimitations.Location = new System.Drawing.Point(4, 22);
        this.pageLimitations.Name = "pageLimitations";
        this.pageLimitations.Padding = new System.Windows.Forms.Padding(3);
        this.pageLimitations.Size = new System.Drawing.Size(695, 311);
        this.pageLimitations.TabIndex = 5;
        this.pageLimitations.Text = "Limitations";
        this.pageLimitations.UseVisualStyleBackColor = true;
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
        this.SplitContainer1.Name = "SplitContainer1";
        this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.cmdSetLimits);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.GroupBox3);
        this.SplitContainer1.Size = new System.Drawing.Size(689, 305);
        this.SplitContainer1.SplitterDistance = 25;
        this.SplitContainer1.TabIndex = 20;
        // 
        // cmdSetLimits
        // 
        this.cmdSetLimits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSetLimits.Location = new System.Drawing.Point(5, 1);
        this.cmdSetLimits.Name = "cmdSetLimits";
        this.cmdSetLimits.Size = new System.Drawing.Size(72, 23);
        this.cmdSetLimits.TabIndex = 19;
        this.cmdSetLimits.Text = "Set limits...";
        this.cmdSetLimits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdSetLimits.UseVisualStyleBackColor = true;
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.lvLimits);
        this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.GroupBox3.Location = new System.Drawing.Point(0, 0);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(689, 276);
        this.GroupBox3.TabIndex = 17;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Active limitations";
        // 
        // lvLimits
        // 
        this.lvLimits.AllowColumnReorder = true;
        this.lvLimits.CatchErrors = false;
        this.lvLimits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader11, this.ColumnHeader13 });
        CConnection2.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        this.lvLimits.ConnectionObj = CConnection2;
        this.lvLimits.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvLimits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvLimits.FullRowSelect = true;
        ListViewGroup3.Header = "Processes";
        ListViewGroup3.Name = "gpOther";
        ListViewGroup4.Header = "Search result";
        ListViewGroup4.Name = "gpSearch";
        this.lvLimits.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup3, ListViewGroup4 });
        this.lvLimits.HideSelection = false;
        this.lvLimits.IsConnected = false;
        this.lvLimits.JobName = null;
        this.lvLimits.Location = new System.Drawing.Point(3, 18);
        this.lvLimits.Name = "lvLimits";
        this.lvLimits.OverriddenDoubleBuffered = true;
        this.lvLimits.ReorganizeColumns = true;
        this.lvLimits.ShowObjectDetailsOnDoubleClick = true;
        this.lvLimits.Size = new System.Drawing.Size(683, 255);
        this.lvLimits.TabIndex = 4;
        this.lvLimits.UseCompatibleStateImageBehavior = false;
        this.lvLimits.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader11
        // 
        this.ColumnHeader11.Text = "Limit";
        this.ColumnHeader11.Width = 314;
        // 
        // ColumnHeader13
        // 
        this.ColumnHeader13.Text = "Value";
        this.ColumnHeader13.Width = 319;
        // 
        // Timer
        // 
        this.Timer.Enabled = true;
        this.Timer.Interval = 1000;
        // 
        // VistaMenu
        // 
        this.VistaMenu.ContainerControl = this;
        // 
        // MenuItemCopyLimit
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyLimit, global::My.Resources.Resources.copy16);
        this.MenuItemCopyLimit.Index = 0;
        this.MenuItemCopyLimit.Text = "Copy to clipboard";
        // 
        // MenuItemProcKill
        // 
        this.MenuItemProcKill.DefaultItem = true;
        this.VistaMenu.SetImage(this.MenuItemProcKill, global::My.Resources.Resources.cross16);
        this.MenuItemProcKill.Index = 0;
        this.MenuItemProcKill.Text = "Kill";
        // 
        // MenuItemProcStop
        // 
        this.VistaMenu.SetImage(this.MenuItemProcStop, global::My.Resources.Resources.control_stop_square);
        this.MenuItemProcStop.Index = 3;
        this.MenuItemProcStop.Text = "Stop";
        // 
        // MenuItemProcResume
        // 
        this.VistaMenu.SetImage(this.MenuItemProcResume, global::My.Resources.Resources.control);
        this.MenuItemProcResume.Index = 4;
        this.MenuItemProcResume.Text = "Resume";
        // 
        // MenuItemProcPIdle
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPIdle, global::My.Resources.Resources.p0);
        this.MenuItemProcPIdle.Index = 0;
        this.MenuItemProcPIdle.Text = "Idle";
        // 
        // MenuItemProcPBN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPBN, global::My.Resources.Resources.p1);
        this.MenuItemProcPBN.Index = 1;
        this.MenuItemProcPBN.Text = "Below normal";
        // 
        // MenuItemProcPN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPN, global::My.Resources.Resources.p2);
        this.MenuItemProcPN.Index = 2;
        this.MenuItemProcPN.Text = "Normal";
        // 
        // MenuItemProcPAN
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPAN, global::My.Resources.Resources.p3);
        this.MenuItemProcPAN.Index = 3;
        this.MenuItemProcPAN.Text = "Above normal";
        // 
        // MenuItemProcPH
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPH, global::My.Resources.Resources.p4);
        this.MenuItemProcPH.Index = 4;
        this.MenuItemProcPH.Text = "High";
        // 
        // MenuItemProcPRT
        // 
        this.VistaMenu.SetImage(this.MenuItemProcPRT, global::My.Resources.Resources.p6);
        this.MenuItemProcPRT.Index = 5;
        this.MenuItemProcPRT.Text = "Real time";
        // 
        // MenuItemProcSFileProp
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSFileProp, global::My.Resources.Resources.document_text);
        this.MenuItemProcSFileProp.Index = 9;
        this.MenuItemProcSFileProp.Text = "File properties";
        // 
        // MenuItemProcSOpenDir
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSOpenDir, global::My.Resources.Resources.folder_open);
        this.MenuItemProcSOpenDir.Index = 10;
        this.MenuItemProcSOpenDir.Text = "Open directory";
        // 
        // MenuItemProcSFileDetails
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSFileDetails, global::My.Resources.Resources.magnifier);
        this.MenuItemProcSFileDetails.Index = 11;
        this.MenuItemProcSFileDetails.Text = "File details";
        // 
        // MenuItemProcSSearch
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSSearch, global::My.Resources.Resources.globe);
        this.MenuItemProcSSearch.Index = 12;
        this.MenuItemProcSSearch.Text = "Internet search";
        // 
        // MenuItemProcSDep
        // 
        this.VistaMenu.SetImage(this.MenuItemProcSDep, global::My.Resources.Resources.dllIcon16);
        this.MenuItemProcSDep.Index = 13;
        this.MenuItemProcSDep.Text = "View dependencies...";
        // 
        // MenuItemCopyProcess
        // 
        this.VistaMenu.SetImage(this.MenuItemCopyProcess, global::My.Resources.Resources.copy16);
        this.MenuItemCopyProcess.Index = 15;
        this.MenuItemCopyProcess.Text = "Copy to clipboard";
        // 
        // TimerLimits
        // 
        this.TimerLimits.Enabled = true;
        this.TimerLimits.Interval = 1000;
        // 
        // mnuLimit
        // 
        this.mnuLimit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemCopyLimit });
        // 
        // mnuProcess
        // 
        this.mnuProcess.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcKill, this.MenuItemProcKillT, this.MenuItemProcKillByMethod, this.MenuItemProcStop, this.MenuItemProcResume, this.MenuItemProcPriority, this.MenuItem44, this.MenuItem35, this.MenuItem51, this.MenuItemProcSFileProp, this.MenuItemProcSOpenDir, this.MenuItemProcSFileDetails, this.MenuItemProcSSearch, this.MenuItemProcSDep, this.MenuItem38, this.MenuItemCopyProcess, this.MenuItemProcColumns });
        // 
        // MenuItemProcKillT
        // 
        this.MenuItemProcKillT.Index = 1;
        this.MenuItemProcKillT.Text = "Kill process tree";
        // 
        // MenuItemProcKillByMethod
        // 
        this.MenuItemProcKillByMethod.Index = 2;
        this.MenuItemProcKillByMethod.Text = "Kill process by method...";
        // 
        // MenuItemProcPriority
        // 
        this.MenuItemProcPriority.Index = 5;
        this.MenuItemProcPriority.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcPIdle, this.MenuItemProcPBN, this.MenuItemProcPN, this.MenuItemProcPAN, this.MenuItemProcPH, this.MenuItemProcPRT });
        this.MenuItemProcPriority.Text = "Priority";
        // 
        // MenuItem44
        // 
        this.MenuItem44.Index = 6;
        this.MenuItem44.Text = "-";
        // 
        // MenuItem35
        // 
        this.MenuItem35.Index = 7;
        this.MenuItem35.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemProcWSS, this.MenuItemProcAff, this.MenuItemProcDump });
        this.MenuItem35.Text = "Other";
        // 
        // MenuItemProcWSS
        // 
        this.MenuItemProcWSS.Index = 0;
        this.MenuItemProcWSS.Text = "Reduce working set size";
        // 
        // MenuItemProcAff
        // 
        this.MenuItemProcAff.Index = 1;
        this.MenuItemProcAff.Text = "Set affinity...";
        // 
        // MenuItemProcDump
        // 
        this.MenuItemProcDump.Index = 2;
        this.MenuItemProcDump.Text = "Create dump file...";
        // 
        // MenuItem51
        // 
        this.MenuItem51.Index = 8;
        this.MenuItem51.Text = "-";
        // 
        // MenuItem38
        // 
        this.MenuItem38.Index = 14;
        this.MenuItem38.Text = "-";
        // 
        // MenuItemProcColumns
        // 
        this.MenuItemProcColumns.Index = 16;
        this.MenuItemProcColumns.Text = "Choose columns...";
        // 
        // frmJobInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(703, 337);
        this.Controls.Add(this.tabJob);
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MinimumSize = new System.Drawing.Size(660, 359);
        this.Name = "frmJobInfo";
        this.Text = "Job informations";
        this.tabJob.ResumeLayout(false);
        this.pageGeneral.ResumeLayout(false);
        this.SplitContainer.Panel1.ResumeLayout(false);
        this.SplitContainer.Panel2.ResumeLayout(false);
        this.SplitContainer.ResumeLayout(false);
        this.GroupBox1.ResumeLayout(false);
        this.pageStats.ResumeLayout(false);
        this.GroupBox5.ResumeLayout(false);
        this.GroupBox5.PerformLayout();
        this.GroupBox4.ResumeLayout(false);
        this.GroupBox4.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.pageLimitations.ResumeLayout(false);
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
        this.GroupBox3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.VistaMenu).EndInit();
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.TabControl _tabJob;

    internal System.Windows.Forms.TabControl tabJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabJob != null)
            {
            }

            _tabJob = value;
            if (_tabJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageGeneral;

    internal System.Windows.Forms.TabPage pageGeneral
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageGeneral;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageGeneral != null)
            {
            }

            _pageGeneral = value;
            if (_pageGeneral != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageLimitations;

    internal System.Windows.Forms.TabPage pageLimitations
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageLimitations;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageLimitations != null)
            {
            }

            _pageLimitations = value;
            if (_pageLimitations != null)
            {
            }
        }
    }

    private System.Windows.Forms.TabPage _pageStats;

    internal System.Windows.Forms.TabPage pageStats
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pageStats;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pageStats != null)
            {
            }

            _pageStats = value;
            if (_pageStats != null)
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

    private System.Windows.Forms.Label _lblTotalTerminatedProcesses;

    internal System.Windows.Forms.Label lblTotalTerminatedProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalTerminatedProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotalTerminatedProcesses != null)
            {
            }

            _lblTotalTerminatedProcesses = value;
            if (_lblTotalTerminatedProcesses != null)
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

    private System.Windows.Forms.Label _lblActiveProcesses;

    internal System.Windows.Forms.Label lblActiveProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblActiveProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblActiveProcesses != null)
            {
            }

            _lblActiveProcesses = value;
            if (_lblActiveProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lbl789;

    internal System.Windows.Forms.Label lbl789
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lbl789;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lbl789 != null)
            {
            }

            _lbl789 = value;
            if (_lbl789 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblTotalProcesses;

    internal System.Windows.Forms.Label lblTotalProcesses
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalProcesses;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotalProcesses != null)
            {
            }

            _lblTotalProcesses = value;
            if (_lblTotalProcesses != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label53;

    internal System.Windows.Forms.Label Label53
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label53;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label53 != null)
            {
            }

            _Label53 = value;
            if (_Label53 != null)
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

    private System.Windows.Forms.Label _lblOthersBD;

    internal System.Windows.Forms.Label lblOthersBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOthersBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOthersBD != null)
            {
            }

            _lblOthersBD = value;
            if (_lblOthersBD != null)
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

    private System.Windows.Forms.Label _lblOtherD;

    internal System.Windows.Forms.Label lblOtherD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOtherD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOtherD != null)
            {
            }

            _lblOtherD = value;
            if (_lblOtherD != null)
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

    private System.Windows.Forms.Label _lblWBD;

    internal System.Windows.Forms.Label lblWBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWBD != null)
            {
            }

            _lblWBD = value;
            if (_lblWBD != null)
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

    private System.Windows.Forms.Label _lblWD;

    internal System.Windows.Forms.Label lblWD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWD != null)
            {
            }

            _lblWD = value;
            if (_lblWD != null)
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

    private System.Windows.Forms.Label _lblRBD;

    internal System.Windows.Forms.Label lblRBD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRBD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRBD != null)
            {
            }

            _lblRBD = value;
            if (_lblRBD != null)
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

    private System.Windows.Forms.Label _lblRD;

    internal System.Windows.Forms.Label lblRD
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRD;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRD != null)
            {
            }

            _lblRD = value;
            if (_lblRD != null)
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

    private System.Windows.Forms.Label _lblProcOtherBytes;

    internal System.Windows.Forms.Label lblProcOtherBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcOtherBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcOtherBytes != null)
            {
            }

            _lblProcOtherBytes = value;
            if (_lblProcOtherBytes != null)
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

    private System.Windows.Forms.Label _lblProcOther;

    internal System.Windows.Forms.Label lblProcOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcOther != null)
            {
            }

            _lblProcOther = value;
            if (_lblProcOther != null)
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

    private System.Windows.Forms.Label _lblProcWriteBytes;

    internal System.Windows.Forms.Label lblProcWriteBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcWriteBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcWriteBytes != null)
            {
            }

            _lblProcWriteBytes = value;
            if (_lblProcWriteBytes != null)
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

    private System.Windows.Forms.Label _lblProcWrites;

    internal System.Windows.Forms.Label lblProcWrites
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcWrites;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcWrites != null)
            {
            }

            _lblProcWrites = value;
            if (_lblProcWrites != null)
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

    private System.Windows.Forms.Label _lblProcReadBytes;

    internal System.Windows.Forms.Label lblProcReadBytes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcReadBytes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcReadBytes != null)
            {
            }

            _lblProcReadBytes = value;
            if (_lblProcReadBytes != null)
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

    private System.Windows.Forms.Label _lblProcReads;

    internal System.Windows.Forms.Label lblProcReads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblProcReads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblProcReads != null)
            {
            }

            _lblProcReads = value;
            if (_lblProcReads != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _Label42;

    internal System.Windows.Forms.Label Label42
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label42;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label42 != null)
            {
            }

            _Label42 = value;
            if (_Label42 != null)
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

    private System.Windows.Forms.Label _lblTotalTime;

    internal System.Windows.Forms.Label lblTotalTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotalTime != null)
            {
            }

            _lblTotalTime = value;
            if (_lblTotalTime != null)
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

    private System.Windows.Forms.Label _lblUserTime;

    internal System.Windows.Forms.Label lblUserTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUserTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUserTime != null)
            {
            }

            _lblUserTime = value;
            if (_lblUserTime != null)
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

    private System.Windows.Forms.Label _lblKernelTime;

    internal System.Windows.Forms.Label lblKernelTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblKernelTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblKernelTime != null)
            {
            }

            _lblKernelTime = value;
            if (_lblKernelTime != null)
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

    private System.Windows.Forms.Label _lblAffinity;

    internal System.Windows.Forms.Label lblAffinity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAffinity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblAffinity != null)
            {
            }

            _lblAffinity = value;
            if (_lblAffinity != null)
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

    private System.Windows.Forms.Label _lblTotalPeriod;

    internal System.Windows.Forms.Label lblTotalPeriod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalPeriod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTotalPeriod != null)
            {
            }

            _lblTotalPeriod = value;
            if (_lblTotalPeriod != null)
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

    private System.Windows.Forms.Label _lblUserPeriod;

    internal System.Windows.Forms.Label lblUserPeriod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblUserPeriod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblUserPeriod != null)
            {
            }

            _lblUserPeriod = value;
            if (_lblUserPeriod != null)
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

    private System.Windows.Forms.Label _lblPeriodKernel;

    internal System.Windows.Forms.Label lblPeriodKernel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPeriodKernel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPeriodKernel != null)
            {
            }

            _lblPeriodKernel = value;
            if (_lblPeriodKernel != null)
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

    private System.Windows.Forms.Label _lblPriority;

    internal System.Windows.Forms.Label lblPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPriority != null)
            {
            }

            _lblPriority = value;
            if (_lblPriority != null)
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

    private System.Windows.Forms.Label _lblSchedulingClass;

    internal System.Windows.Forms.Label lblSchedulingClass
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblSchedulingClass;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblSchedulingClass != null)
            {
            }

            _lblSchedulingClass = value;
            if (_lblSchedulingClass != null)
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

    private System.Windows.Forms.Label _lblMaxWSS;

    internal System.Windows.Forms.Label lblMaxWSS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMaxWSS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMaxWSS != null)
            {
            }

            _lblMaxWSS = value;
            if (_lblMaxWSS != null)
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

    private System.Windows.Forms.Label _lblMinWSS;

    internal System.Windows.Forms.Label lblMinWSS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMinWSS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMinWSS != null)
            {
            }

            _lblMinWSS = value;
            if (_lblMinWSS != null)
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

    private System.Windows.Forms.Label _lblPageFaultCount;

    internal System.Windows.Forms.Label lblPageFaultCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPageFaultCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPageFaultCount != null)
            {
            }

            _lblPageFaultCount = value;
            if (_lblPageFaultCount != null)
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

    private System.Windows.Forms.Button _cmdTerminateJob;

    internal System.Windows.Forms.Button cmdTerminateJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdTerminateJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdTerminateJob != null)
            {
            }

            _cmdTerminateJob = value;
            if (_cmdTerminateJob != null)
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

    private processesInJobList _lvProcess;

    internal processesInJobList lvProcess
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

    private System.Windows.Forms.ColumnHeader _c3;

    internal System.Windows.Forms.ColumnHeader c3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c3 != null)
            {
            }

            _c3 = value;
            if (_c3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c4;

    internal System.Windows.Forms.ColumnHeader c4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c4 != null)
            {
            }

            _c4 = value;
            if (_c4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c5;

    internal System.Windows.Forms.ColumnHeader c5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c5 != null)
            {
            }

            _c5 = value;
            if (_c5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c7;

    internal System.Windows.Forms.ColumnHeader c7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c7 != null)
            {
            }

            _c7 = value;
            if (_c7 != null)
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

    private System.Windows.Forms.ColumnHeader _c9;

    internal System.Windows.Forms.ColumnHeader c9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c9 != null)
            {
            }

            _c9 = value;
            if (_c9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _c10;

    internal System.Windows.Forms.ColumnHeader c10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _c10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_c10 != null)
            {
            }

            _c10 = value;
            if (_c10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader20;

    internal System.Windows.Forms.ColumnHeader ColumnHeader20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader20 != null)
            {
            }

            _ColumnHeader20 = value;
            if (_ColumnHeader20 != null)
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

    private jobLimitList _lvLimits;

    internal jobLimitList lvLimits
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvLimits;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvLimits != null)
            {
            }

            _lvLimits = value;
            if (_lvLimits != null)
            {
            }
        }
    }

    private System.Windows.Forms.Timer _TimerLimits;

    internal System.Windows.Forms.Timer TimerLimits
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TimerLimits;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TimerLimits != null)
            {
            }

            _TimerLimits = value;
            if (_TimerLimits != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader11;

    internal System.Windows.Forms.ColumnHeader ColumnHeader11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader11 != null)
            {
            }

            _ColumnHeader11 = value;
            if (_ColumnHeader11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader13;

    internal System.Windows.Forms.ColumnHeader ColumnHeader13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader13 != null)
            {
            }

            _ColumnHeader13 = value;
            if (_ColumnHeader13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuLimit;

    private System.Windows.Forms.ContextMenu mnuLimit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuLimit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuLimit != null)
            {
            }

            _mnuLimit = value;
            if (_mnuLimit != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyLimit;

    internal System.Windows.Forms.MenuItem MenuItemCopyLimit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyLimit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyLimit != null)
            {
            }

            _MenuItemCopyLimit = value;
            if (_MenuItemCopyLimit != null)
            {
            }
        }
    }

    private System.Windows.Forms.ContextMenu _mnuProcess;

    private System.Windows.Forms.ContextMenu mnuProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mnuProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mnuProcess != null)
            {
            }

            _mnuProcess = value;
            if (_mnuProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKill;

    internal System.Windows.Forms.MenuItem MenuItemProcKill
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKill;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKill != null)
            {
            }

            _MenuItemProcKill = value;
            if (_MenuItemProcKill != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKillT;

    internal System.Windows.Forms.MenuItem MenuItemProcKillT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKillT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKillT != null)
            {
            }

            _MenuItemProcKillT = value;
            if (_MenuItemProcKillT != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcKillByMethod;

    internal System.Windows.Forms.MenuItem MenuItemProcKillByMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcKillByMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcKillByMethod != null)
            {
            }

            _MenuItemProcKillByMethod = value;
            if (_MenuItemProcKillByMethod != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcStop;

    internal System.Windows.Forms.MenuItem MenuItemProcStop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcStop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcStop != null)
            {
            }

            _MenuItemProcStop = value;
            if (_MenuItemProcStop != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcResume;

    internal System.Windows.Forms.MenuItem MenuItemProcResume
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcResume;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcResume != null)
            {
            }

            _MenuItemProcResume = value;
            if (_MenuItemProcResume != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPriority;

    internal System.Windows.Forms.MenuItem MenuItemProcPriority
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPriority;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPriority != null)
            {
            }

            _MenuItemProcPriority = value;
            if (_MenuItemProcPriority != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPIdle;

    internal System.Windows.Forms.MenuItem MenuItemProcPIdle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPIdle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPIdle != null)
            {
            }

            _MenuItemProcPIdle = value;
            if (_MenuItemProcPIdle != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPBN;

    internal System.Windows.Forms.MenuItem MenuItemProcPBN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPBN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPBN != null)
            {
            }

            _MenuItemProcPBN = value;
            if (_MenuItemProcPBN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPN;

    internal System.Windows.Forms.MenuItem MenuItemProcPN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPN != null)
            {
            }

            _MenuItemProcPN = value;
            if (_MenuItemProcPN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPAN;

    internal System.Windows.Forms.MenuItem MenuItemProcPAN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPAN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPAN != null)
            {
            }

            _MenuItemProcPAN = value;
            if (_MenuItemProcPAN != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPH;

    internal System.Windows.Forms.MenuItem MenuItemProcPH
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPH;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPH != null)
            {
            }

            _MenuItemProcPH = value;
            if (_MenuItemProcPH != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcPRT;

    internal System.Windows.Forms.MenuItem MenuItemProcPRT
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcPRT;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcPRT != null)
            {
            }

            _MenuItemProcPRT = value;
            if (_MenuItemProcPRT != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem44;

    internal System.Windows.Forms.MenuItem MenuItem44
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem44;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem44 != null)
            {
            }

            _MenuItem44 = value;
            if (_MenuItem44 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem35;

    internal System.Windows.Forms.MenuItem MenuItem35
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem35;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem35 != null)
            {
            }

            _MenuItem35 = value;
            if (_MenuItem35 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcWSS;

    internal System.Windows.Forms.MenuItem MenuItemProcWSS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcWSS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcWSS != null)
            {
            }

            _MenuItemProcWSS = value;
            if (_MenuItemProcWSS != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcAff;

    internal System.Windows.Forms.MenuItem MenuItemProcAff
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcAff;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcAff != null)
            {
            }

            _MenuItemProcAff = value;
            if (_MenuItemProcAff != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcDump;

    internal System.Windows.Forms.MenuItem MenuItemProcDump
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcDump;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcDump != null)
            {
            }

            _MenuItemProcDump = value;
            if (_MenuItemProcDump != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem51;

    internal System.Windows.Forms.MenuItem MenuItem51
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem51;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem51 != null)
            {
            }

            _MenuItem51 = value;
            if (_MenuItem51 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSFileProp;

    internal System.Windows.Forms.MenuItem MenuItemProcSFileProp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSFileProp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSFileProp != null)
            {
            }

            _MenuItemProcSFileProp = value;
            if (_MenuItemProcSFileProp != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSOpenDir;

    internal System.Windows.Forms.MenuItem MenuItemProcSOpenDir
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSOpenDir;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSOpenDir != null)
            {
            }

            _MenuItemProcSOpenDir = value;
            if (_MenuItemProcSOpenDir != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSFileDetails;

    internal System.Windows.Forms.MenuItem MenuItemProcSFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSFileDetails != null)
            {
            }

            _MenuItemProcSFileDetails = value;
            if (_MenuItemProcSFileDetails != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSSearch;

    internal System.Windows.Forms.MenuItem MenuItemProcSSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSSearch != null)
            {
            }

            _MenuItemProcSSearch = value;
            if (_MenuItemProcSSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcSDep;

    internal System.Windows.Forms.MenuItem MenuItemProcSDep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcSDep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcSDep != null)
            {
            }

            _MenuItemProcSDep = value;
            if (_MenuItemProcSDep != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItem38;

    internal System.Windows.Forms.MenuItem MenuItem38
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItem38;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItem38 != null)
            {
            }

            _MenuItem38 = value;
            if (_MenuItem38 != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemCopyProcess;

    internal System.Windows.Forms.MenuItem MenuItemCopyProcess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemCopyProcess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemCopyProcess != null)
            {
            }

            _MenuItemCopyProcess = value;
            if (_MenuItemCopyProcess != null)
            {
            }
        }
    }

    private System.Windows.Forms.MenuItem _MenuItemProcColumns;

    internal System.Windows.Forms.MenuItem MenuItemProcColumns
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuItemProcColumns;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuItemProcColumns != null)
            {
            }

            _MenuItemProcColumns = value;
            if (_MenuItemProcColumns != null)
            {
            }
        }
    }
}

