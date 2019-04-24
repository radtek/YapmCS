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
partial class frmBasedStateAction : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasedStateAction));
        this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        this.EnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.DisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.imgList = new System.Windows.Forms.ImageList(this.components);
        this.gp = new System.Windows.Forms.GroupBox();
        this.updownCounter = new System.Windows.Forms.NumericUpDown();
        this.Label7 = new System.Windows.Forms.Label();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.txtParam2Val = new System.Windows.Forms.TextBox();
        this.txtParam2Desc = new System.Windows.Forms.TextBox();
        this.Label6 = new System.Windows.Forms.Label();
        this.txtParam1Val = new System.Windows.Forms.TextBox();
        this.txtParam1Desc = new System.Windows.Forms.TextBox();
        this.Label5 = new System.Windows.Forms.Label();
        this.cbAction = new System.Windows.Forms.ComboBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.lblThresholdDesc = new System.Windows.Forms.TextBox();
        this.cbCounter = new System.Windows.Forms.ComboBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.txtThreshold = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.cbOperator = new System.Windows.Forms.ComboBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.cmdBrowseProcessPath = new System.Windows.Forms.Button();
        this.cmdBrowseProcessId = new System.Windows.Forms.Button();
        this.cmdBrowseProcessName = new System.Windows.Forms.Button();
        this.txtProcessPath = new System.Windows.Forms.TextBox();
        this.txtProcessID = new System.Windows.Forms.TextBox();
        this.txtProcessName = new System.Windows.Forms.TextBox();
        this.chkCheckProcessPath = new System.Windows.Forms.CheckBox();
        this.chkCheckProcessID = new System.Windows.Forms.CheckBox();
        this.chkCheckProcessName = new System.Windows.Forms.CheckBox();
        this.cmdKO = new System.Windows.Forms.Button();
        this.cmdAdd = new System.Windows.Forms.Button();
        this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
        this.DisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.SimulationConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.chkNotify = new System.Windows.Forms.CheckBox();
        this.ContextMenuStrip1.SuspendLayout();
        this.gp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.updownCounter).BeginInit();
        this.GroupBox3.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.MenuStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // timerRefresh
        // 
        this.timerRefresh.Enabled = true;
        // 
        // ContextMenuStrip1
        // 
        this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ShowToolStripMenuItem, this.CloseToolStripMenuItem, this.ToolStripMenuItem1, this.EnableToolStripMenuItem, this.DisableToolStripMenuItem });
        this.ContextMenuStrip1.Name = "ContextMenuStrip1";
        this.ContextMenuStrip1.Size = new System.Drawing.Size(118, 98);
        // 
        // ShowToolStripMenuItem
        // 
        this.ShowToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.ShowToolStripMenuItem.Image = global::My.Resources.Resources.plus_circle;
        this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
        this.ShowToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.ShowToolStripMenuItem.Text = "Add";
        // 
        // CloseToolStripMenuItem
        // 
        this.CloseToolStripMenuItem.Image = global::My.Resources.Resources.cross_circle16;
        this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
        this.CloseToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.CloseToolStripMenuItem.Text = "Remove";
        // 
        // ToolStripMenuItem1
        // 
        this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
        this.ToolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
        // 
        // EnableToolStripMenuItem
        // 
        this.EnableToolStripMenuItem.Name = "EnableToolStripMenuItem";
        this.EnableToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.EnableToolStripMenuItem.Text = "Enable";
        // 
        // DisableToolStripMenuItem
        // 
        this.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem";
        this.DisableToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
        this.DisableToolStripMenuItem.Text = "Disable";
        // 
        // imgList
        // 
        this.imgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList.ImageStream");
        this.imgList.TransparentColor = System.Drawing.Color.Transparent;
        this.imgList.Images.SetKeyName(0, "default");
        // 
        // gp
        // 
        this.gp.BackColor = System.Drawing.Color.White;
        this.gp.Controls.Add(this.chkNotify);
        this.gp.Controls.Add(this.updownCounter);
        this.gp.Controls.Add(this.Label7);
        this.gp.Controls.Add(this.GroupBox3);
        this.gp.Controls.Add(this.GroupBox2);
        this.gp.Controls.Add(this.GroupBox1);
        this.gp.Controls.Add(this.cmdKO);
        this.gp.Controls.Add(this.cmdAdd);
        this.gp.Location = new System.Drawing.Point(175, 48);
        this.gp.Name = "gp";
        this.gp.Size = new System.Drawing.Size(314, 416);
        this.gp.TabIndex = 6;
        this.gp.TabStop = false;
        this.gp.Text = "Add a state based action";
        this.gp.Visible = false;
        // 
        // updownCounter
        // 
        this.updownCounter.Location = new System.Drawing.Point(139, 342);
        this.updownCounter.Minimum = new decimal(new int[] { 1, 0, 0, -2147483648 });
        this.updownCounter.Name = "updownCounter";
        this.updownCounter.Size = new System.Drawing.Size(69, 22);
        this.updownCounter.TabIndex = 14;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(11, 345);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(126, 13);
        this.Label7.TabIndex = 13;
        this.Label7.Text = "Counter (-1 for infinite)";
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.txtParam2Val);
        this.GroupBox3.Controls.Add(this.txtParam2Desc);
        this.GroupBox3.Controls.Add(this.Label6);
        this.GroupBox3.Controls.Add(this.txtParam1Val);
        this.GroupBox3.Controls.Add(this.txtParam1Desc);
        this.GroupBox3.Controls.Add(this.Label5);
        this.GroupBox3.Controls.Add(this.cbAction);
        this.GroupBox3.Controls.Add(this.Label3);
        this.GroupBox3.Location = new System.Drawing.Point(14, 230);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(281, 101);
        this.GroupBox3.TabIndex = 12;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Action";
        // 
        // txtParam2Val
        // 
        this.txtParam2Val.Location = new System.Drawing.Point(185, 66);
        this.txtParam2Val.Name = "txtParam2Val";
        this.txtParam2Val.Size = new System.Drawing.Size(77, 22);
        this.txtParam2Val.TabIndex = 17;
        // 
        // txtParam2Desc
        // 
        this.txtParam2Desc.Location = new System.Drawing.Point(55, 66);
        this.txtParam2Desc.Name = "txtParam2Desc";
        this.txtParam2Desc.ReadOnly = true;
        this.txtParam2Desc.Size = new System.Drawing.Size(124, 22);
        this.txtParam2Desc.TabIndex = 16;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(9, 68);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(44, 13);
        this.Label6.TabIndex = 15;
        this.Label6.Text = "Param2";
        // 
        // txtParam1Val
        // 
        this.txtParam1Val.Location = new System.Drawing.Point(185, 43);
        this.txtParam1Val.Name = "txtParam1Val";
        this.txtParam1Val.Size = new System.Drawing.Size(77, 22);
        this.txtParam1Val.TabIndex = 14;
        // 
        // txtParam1Desc
        // 
        this.txtParam1Desc.Location = new System.Drawing.Point(55, 43);
        this.txtParam1Desc.Name = "txtParam1Desc";
        this.txtParam1Desc.ReadOnly = true;
        this.txtParam1Desc.Size = new System.Drawing.Size(124, 22);
        this.txtParam1Desc.TabIndex = 13;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(9, 46);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(44, 13);
        this.Label5.TabIndex = 12;
        this.Label5.Text = "Param1";
        // 
        // cbAction
        // 
        this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbAction.FormattingEnabled = true;
        this.cbAction.Location = new System.Drawing.Point(55, 21);
        this.cbAction.Name = "cbAction";
        this.cbAction.Size = new System.Drawing.Size(207, 21);
        this.cbAction.TabIndex = 11;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(9, 24);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(40, 13);
        this.Label3.TabIndex = 10;
        this.Label3.Text = "Action";
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.lblThresholdDesc);
        this.GroupBox2.Controls.Add(this.cbCounter);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.txtThreshold);
        this.GroupBox2.Controls.Add(this.Label2);
        this.GroupBox2.Controls.Add(this.cbOperator);
        this.GroupBox2.Controls.Add(this.Label1);
        this.GroupBox2.Location = new System.Drawing.Point(14, 126);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(280, 98);
        this.GroupBox2.TabIndex = 11;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "State to monitor";
        // 
        // lblThresholdDesc
        // 
        this.lblThresholdDesc.Location = new System.Drawing.Point(113, 42);
        this.lblThresholdDesc.Name = "lblThresholdDesc";
        this.lblThresholdDesc.ReadOnly = true;
        this.lblThresholdDesc.Size = new System.Drawing.Size(149, 22);
        this.lblThresholdDesc.TabIndex = 14;
        // 
        // cbCounter
        // 
        this.cbCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbCounter.FormattingEnabled = true;
        this.cbCounter.Items.AddRange(new object[] { "CpuUsage", "AverageCpuUsage" });
        this.cbCounter.Location = new System.Drawing.Point(70, 18);
        this.cbCounter.Name = "cbCounter";
        this.cbCounter.Size = new System.Drawing.Size(192, 21);
        this.cbCounter.TabIndex = 5;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 21);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(49, 13);
        this.Label4.TabIndex = 4;
        this.Label4.Text = "Counter";
        // 
        // txtThreshold
        // 
        this.txtThreshold.Location = new System.Drawing.Point(70, 68);
        this.txtThreshold.Name = "txtThreshold";
        this.txtThreshold.Size = new System.Drawing.Size(192, 22);
        this.txtThreshold.TabIndex = 3;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(6, 71);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(58, 13);
        this.Label2.TabIndex = 2;
        this.Label2.Text = "Threshold";
        // 
        // cbOperator
        // 
        this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbOperator.FormattingEnabled = true;
        this.cbOperator.Items.AddRange(new object[] { "<", "<=", "=", ">=", ">", "!=" });
        this.cbOperator.Location = new System.Drawing.Point(70, 43);
        this.cbOperator.Name = "cbOperator";
        this.cbOperator.Size = new System.Drawing.Size(37, 21);
        this.cbOperator.TabIndex = 1;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(6, 46);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(54, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Operator";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.cmdBrowseProcessPath);
        this.GroupBox1.Controls.Add(this.cmdBrowseProcessId);
        this.GroupBox1.Controls.Add(this.cmdBrowseProcessName);
        this.GroupBox1.Controls.Add(this.txtProcessPath);
        this.GroupBox1.Controls.Add(this.txtProcessID);
        this.GroupBox1.Controls.Add(this.txtProcessName);
        this.GroupBox1.Controls.Add(this.chkCheckProcessPath);
        this.GroupBox1.Controls.Add(this.chkCheckProcessID);
        this.GroupBox1.Controls.Add(this.chkCheckProcessName);
        this.GroupBox1.Location = new System.Drawing.Point(14, 21);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(280, 96);
        this.GroupBox1.TabIndex = 10;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Process";
        // 
        // cmdBrowseProcessPath
        // 
        this.cmdBrowseProcessPath.Location = new System.Drawing.Point(237, 64);
        this.cmdBrowseProcessPath.Name = "cmdBrowseProcessPath";
        this.cmdBrowseProcessPath.Size = new System.Drawing.Size(25, 23);
        this.cmdBrowseProcessPath.TabIndex = 8;
        this.cmdBrowseProcessPath.Text = "...";
        this.cmdBrowseProcessPath.UseVisualStyleBackColor = true;
        // 
        // cmdBrowseProcessId
        // 
        this.cmdBrowseProcessId.Location = new System.Drawing.Point(237, 40);
        this.cmdBrowseProcessId.Name = "cmdBrowseProcessId";
        this.cmdBrowseProcessId.Size = new System.Drawing.Size(25, 23);
        this.cmdBrowseProcessId.TabIndex = 7;
        this.cmdBrowseProcessId.Text = "...";
        this.cmdBrowseProcessId.UseVisualStyleBackColor = true;
        // 
        // cmdBrowseProcessName
        // 
        this.cmdBrowseProcessName.Location = new System.Drawing.Point(237, 17);
        this.cmdBrowseProcessName.Name = "cmdBrowseProcessName";
        this.cmdBrowseProcessName.Size = new System.Drawing.Size(25, 23);
        this.cmdBrowseProcessName.TabIndex = 6;
        this.cmdBrowseProcessName.Text = "...";
        this.cmdBrowseProcessName.UseVisualStyleBackColor = true;
        // 
        // txtProcessPath
        // 
        this.txtProcessPath.Location = new System.Drawing.Point(142, 65);
        this.txtProcessPath.Name = "txtProcessPath";
        this.txtProcessPath.Size = new System.Drawing.Size(89, 22);
        this.txtProcessPath.TabIndex = 5;
        // 
        // txtProcessID
        // 
        this.txtProcessID.Location = new System.Drawing.Point(142, 42);
        this.txtProcessID.Name = "txtProcessID";
        this.txtProcessID.Size = new System.Drawing.Size(89, 22);
        this.txtProcessID.TabIndex = 4;
        // 
        // txtProcessName
        // 
        this.txtProcessName.Location = new System.Drawing.Point(142, 19);
        this.txtProcessName.Name = "txtProcessName";
        this.txtProcessName.Size = new System.Drawing.Size(89, 22);
        this.txtProcessName.TabIndex = 3;
        // 
        // chkCheckProcessPath
        // 
        this.chkCheckProcessPath.AutoSize = true;
        this.chkCheckProcessPath.Location = new System.Drawing.Point(6, 67);
        this.chkCheckProcessPath.Name = "chkCheckProcessPath";
        this.chkCheckProcessPath.Size = new System.Drawing.Size(126, 17);
        this.chkCheckProcessPath.TabIndex = 2;
        this.chkCheckProcessPath.Text = "Check process path";
        this.chkCheckProcessPath.UseVisualStyleBackColor = true;
        // 
        // chkCheckProcessID
        // 
        this.chkCheckProcessID.AutoSize = true;
        this.chkCheckProcessID.Location = new System.Drawing.Point(6, 44);
        this.chkCheckProcessID.Name = "chkCheckProcessID";
        this.chkCheckProcessID.Size = new System.Drawing.Size(113, 17);
        this.chkCheckProcessID.TabIndex = 1;
        this.chkCheckProcessID.Text = "Check process ID";
        this.chkCheckProcessID.UseVisualStyleBackColor = true;
        // 
        // chkCheckProcessName
        // 
        this.chkCheckProcessName.AutoSize = true;
        this.chkCheckProcessName.Location = new System.Drawing.Point(6, 21);
        this.chkCheckProcessName.Name = "chkCheckProcessName";
        this.chkCheckProcessName.Size = new System.Drawing.Size(130, 17);
        this.chkCheckProcessName.TabIndex = 0;
        this.chkCheckProcessName.Text = "Check process name";
        this.chkCheckProcessName.UseVisualStyleBackColor = true;
        // 
        // cmdKO
        // 
        this.cmdKO.Location = new System.Drawing.Point(172, 383);
        this.cmdKO.Name = "cmdKO";
        this.cmdKO.Size = new System.Drawing.Size(55, 23);
        this.cmdKO.TabIndex = 7;
        this.cmdKO.Text = "Cancel";
        this.cmdKO.UseVisualStyleBackColor = true;
        // 
        // cmdAdd
        // 
        this.cmdAdd.Enabled = false;
        this.cmdAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdAdd.Location = new System.Drawing.Point(91, 383);
        this.cmdAdd.Name = "cmdAdd";
        this.cmdAdd.Size = new System.Drawing.Size(55, 23);
        this.cmdAdd.TabIndex = 6;
        this.cmdAdd.Text = "Add";
        this.cmdAdd.UseVisualStyleBackColor = true;
        // 
        // MenuStrip1
        // 
        this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DisplayToolStripMenuItem });
        this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
        this.MenuStrip1.Name = "MenuStrip1";
        this.MenuStrip1.Size = new System.Drawing.Size(701, 24);
        this.MenuStrip1.TabIndex = 7;
        this.MenuStrip1.Text = "MenuStrip1";
        // 
        // DisplayToolStripMenuItem
        // 
        this.DisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.SimulationConsoleToolStripMenuItem });
        this.DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem";
        this.DisplayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
        this.DisplayToolStripMenuItem.Text = "&Display";
        // 
        // SimulationConsoleToolStripMenuItem
        // 
        this.SimulationConsoleToolStripMenuItem.Name = "SimulationConsoleToolStripMenuItem";
        this.SimulationConsoleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
        this.SimulationConsoleToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
        this.SimulationConsoleToolStripMenuItem.Text = "&Simulation console";
        // 
        // lv
        // 
        this.lv.AllowColumnReorder = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2, this.ColumnHeader3, this.ColumnHeader4 });
        this.lv.ContextMenuStrip = this.ContextMenuStrip1;
        this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lv.FullRowSelect = true;
        this.lv.HideSelection = false;
        this.lv.Location = new System.Drawing.Point(0, 24);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = true;
        this.lv.Size = new System.Drawing.Size(701, 489);
        this.lv.SmallImageList = this.imgList;
        this.lv.TabIndex = 5;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Process";
        this.ColumnHeader2.Width = 200;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "State to monitor";
        this.ColumnHeader3.Width = 200;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Action";
        this.ColumnHeader4.Width = 350;
        // 
        // chkNotify
        // 
        this.chkNotify.AutoSize = true;
        this.chkNotify.Location = new System.Drawing.Point(238, 344);
        this.chkNotify.Name = "chkNotify";
        this.chkNotify.Size = new System.Drawing.Size(57, 17);
        this.chkNotify.TabIndex = 15;
        this.chkNotify.Text = "Notify";
        this.chkNotify.UseVisualStyleBackColor = true;
        // 
        // frmBasedStateAction
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(701, 513);
        this.Controls.Add(this.gp);
        this.Controls.Add(this.lv);
        this.Controls.Add(this.MenuStrip1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MainMenuStrip = this.MenuStrip1;
        this.MaximizeBox = false;
        this.Name = "frmBasedStateAction";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Based state action";
        this.ContextMenuStrip1.ResumeLayout(false);
        this.gp.ResumeLayout(false);
        this.gp.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.updownCounter).EndInit();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.MenuStrip1.ResumeLayout(false);
        this.MenuStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip1;

    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ContextMenuStrip1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ContextMenuStrip1 != null)
            {
            }

            _ContextMenuStrip1 = value;
            if (_ContextMenuStrip1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _ShowToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ShowToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ShowToolStripMenuItem != null)
            {
            }

            _ShowToolStripMenuItem = value;
            if (_ShowToolStripMenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _CloseToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _CloseToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_CloseToolStripMenuItem != null)
            {
            }

            _CloseToolStripMenuItem = value;
            if (_CloseToolStripMenuItem != null)
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

    private System.Windows.Forms.ToolStripSeparator _ToolStripMenuItem1;

    internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ToolStripMenuItem1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ToolStripMenuItem1 != null)
            {
            }

            _ToolStripMenuItem1 = value;
            if (_ToolStripMenuItem1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _EnableToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem EnableToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _EnableToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_EnableToolStripMenuItem != null)
            {
            }

            _EnableToolStripMenuItem = value;
            if (_EnableToolStripMenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _DisableToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem DisableToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DisableToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DisableToolStripMenuItem != null)
            {
            }

            _DisableToolStripMenuItem = value;
            if (_DisableToolStripMenuItem != null)
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

    private System.Windows.Forms.Button _cmdBrowseProcessPath;

    internal System.Windows.Forms.Button cmdBrowseProcessPath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowseProcessPath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowseProcessPath != null)
            {
            }

            _cmdBrowseProcessPath = value;
            if (_cmdBrowseProcessPath != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdBrowseProcessId;

    internal System.Windows.Forms.Button cmdBrowseProcessId
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowseProcessId;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowseProcessId != null)
            {
            }

            _cmdBrowseProcessId = value;
            if (_cmdBrowseProcessId != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdBrowseProcessName;

    internal System.Windows.Forms.Button cmdBrowseProcessName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdBrowseProcessName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdBrowseProcessName != null)
            {
            }

            _cmdBrowseProcessName = value;
            if (_cmdBrowseProcessName != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessPath;

    internal System.Windows.Forms.TextBox txtProcessPath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessPath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessPath != null)
            {
            }

            _txtProcessPath = value;
            if (_txtProcessPath != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessID;

    internal System.Windows.Forms.TextBox txtProcessID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessID != null)
            {
            }

            _txtProcessID = value;
            if (_txtProcessID != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtProcessName;

    internal System.Windows.Forms.TextBox txtProcessName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtProcessName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtProcessName != null)
            {
            }

            _txtProcessName = value;
            if (_txtProcessName != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCheckProcessPath;

    internal System.Windows.Forms.CheckBox chkCheckProcessPath
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCheckProcessPath;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCheckProcessPath != null)
            {
            }

            _chkCheckProcessPath = value;
            if (_chkCheckProcessPath != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCheckProcessID;

    internal System.Windows.Forms.CheckBox chkCheckProcessID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCheckProcessID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCheckProcessID != null)
            {
            }

            _chkCheckProcessID = value;
            if (_chkCheckProcessID != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCheckProcessName;

    internal System.Windows.Forms.CheckBox chkCheckProcessName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCheckProcessName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCheckProcessName != null)
            {
            }

            _chkCheckProcessName = value;
            if (_chkCheckProcessName != null)
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

    private System.Windows.Forms.ComboBox _cbOperator;

    internal System.Windows.Forms.ComboBox cbOperator
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbOperator;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbOperator != null)
            {
            }

            _cbOperator = value;
            if (_cbOperator != null)
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

    private System.Windows.Forms.TextBox _txtParam1Val;

    internal System.Windows.Forms.TextBox txtParam1Val
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtParam1Val;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtParam1Val != null)
            {
            }

            _txtParam1Val = value;
            if (_txtParam1Val != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtParam1Desc;

    internal System.Windows.Forms.TextBox txtParam1Desc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtParam1Desc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtParam1Desc != null)
            {
            }

            _txtParam1Desc = value;
            if (_txtParam1Desc != null)
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

    private System.Windows.Forms.ComboBox _cbCounter;

    internal System.Windows.Forms.ComboBox cbCounter
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbCounter;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbCounter != null)
            {
            }

            _cbCounter = value;
            if (_cbCounter != null)
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

    private System.Windows.Forms.TextBox _txtThreshold;

    internal System.Windows.Forms.TextBox txtThreshold
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtThreshold;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtThreshold != null)
            {
            }

            _txtThreshold = value;
            if (_txtThreshold != null)
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

    private System.Windows.Forms.TextBox _txtParam2Val;

    internal System.Windows.Forms.TextBox txtParam2Val
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtParam2Val;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtParam2Val != null)
            {
            }

            _txtParam2Val = value;
            if (_txtParam2Val != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtParam2Desc;

    internal System.Windows.Forms.TextBox txtParam2Desc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtParam2Desc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtParam2Desc != null)
            {
            }

            _txtParam2Desc = value;
            if (_txtParam2Desc != null)
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

    private System.Windows.Forms.ColumnHeader _ColumnHeader3;

    internal System.Windows.Forms.ColumnHeader ColumnHeader3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader3 != null)
            {
            }

            _ColumnHeader3 = value;
            if (_ColumnHeader3 != null)
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

    private System.Windows.Forms.MenuStrip _MenuStrip1;

    internal System.Windows.Forms.MenuStrip MenuStrip1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MenuStrip1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MenuStrip1 != null)
            {
            }

            _MenuStrip1 = value;
            if (_MenuStrip1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _DisplayToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem DisplayToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DisplayToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DisplayToolStripMenuItem != null)
            {
            }

            _DisplayToolStripMenuItem = value;
            if (_DisplayToolStripMenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.ToolStripMenuItem _SimulationConsoleToolStripMenuItem;

    internal System.Windows.Forms.ToolStripMenuItem SimulationConsoleToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SimulationConsoleToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SimulationConsoleToolStripMenuItem != null)
            {
            }

            _SimulationConsoleToolStripMenuItem = value;
            if (_SimulationConsoleToolStripMenuItem != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _lblThresholdDesc;

    internal System.Windows.Forms.TextBox lblThresholdDesc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblThresholdDesc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblThresholdDesc != null)
            {
            }

            _lblThresholdDesc = value;
            if (_lblThresholdDesc != null)
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

    private System.Windows.Forms.NumericUpDown _updownCounter;

    internal System.Windows.Forms.NumericUpDown updownCounter
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _updownCounter;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_updownCounter != null)
            {
            }

            _updownCounter = value;
            if (_updownCounter != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkNotify;

    internal System.Windows.Forms.CheckBox chkNotify
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkNotify;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkNotify != null)
            {
            }

            _chkNotify = value;
            if (_chkNotify != null)
            {
            }
        }
    }
}

