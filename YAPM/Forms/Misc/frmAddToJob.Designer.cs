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
partial class frmAddToJob : System.Windows.Forms.Form
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
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Tasks", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left);
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.tab = new System.Windows.Forms.TabControl();
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtJobName = new System.Windows.Forms.TextBox();
        this.optAddGlobal = new System.Windows.Forms.RadioButton();
        this.optAddLocal = new System.Windows.Forms.RadioButton();
        this.TabPage2 = new System.Windows.Forms.TabPage();
        this.lvJob = new jobList();
        this.ColumnHeader50 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.OK_Button = new System.Windows.Forms.Button();
        this.Cancel_Button = new System.Windows.Forms.Button();
        this.Timer = new System.Windows.Forms.Timer(this.components);
        this.SplitContainer1.Panel1.SuspendLayout();
        this.SplitContainer1.Panel2.SuspendLayout();
        this.SplitContainer1.SuspendLayout();
        this.tab.SuspendLayout();
        this.TabPage1.SuspendLayout();
        this.TabPage2.SuspendLayout();
        this.TableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // SplitContainer1
        // 
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.SplitContainer1.IsSplitterFixed = true;
        this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
        this.SplitContainer1.Name = "SplitContainer1";
        this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // SplitContainer1.Panel1
        // 
        this.SplitContainer1.Panel1.Controls.Add(this.tab);
        // 
        // SplitContainer1.Panel2
        // 
        this.SplitContainer1.Panel2.Controls.Add(this.TableLayoutPanel1);
        this.SplitContainer1.Size = new System.Drawing.Size(429, 215);
        this.SplitContainer1.SplitterDistance = 182;
        this.SplitContainer1.TabIndex = 1;
        // 
        // tab
        // 
        this.tab.Controls.Add(this.TabPage1);
        this.tab.Controls.Add(this.TabPage2);
        this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tab.Location = new System.Drawing.Point(0, 0);
        this.tab.Name = "tab";
        this.tab.SelectedIndex = 0;
        this.tab.Size = new System.Drawing.Size(429, 182);
        this.tab.TabIndex = 4;
        // 
        // TabPage1
        // 
        this.TabPage1.Controls.Add(this.Label1);
        this.TabPage1.Controls.Add(this.txtJobName);
        this.TabPage1.Controls.Add(this.optAddGlobal);
        this.TabPage1.Controls.Add(this.optAddLocal);
        this.TabPage1.Location = new System.Drawing.Point(4, 22);
        this.TabPage1.Name = "TabPage1";
        this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage1.Size = new System.Drawing.Size(421, 156);
        this.TabPage1.TabIndex = 0;
        this.TabPage1.Text = "New job";
        this.TabPage1.UseVisualStyleBackColor = true;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(9, 52);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(36, 13);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Name";
        // 
        // txtJobName
        // 
        this.txtJobName.Location = new System.Drawing.Point(51, 49);
        this.txtJobName.Name = "txtJobName";
        this.txtJobName.Size = new System.Drawing.Size(286, 22);
        this.txtJobName.TabIndex = 2;
        // 
        // optAddGlobal
        // 
        this.optAddGlobal.AutoSize = true;
        this.optAddGlobal.Location = new System.Drawing.Point(88, 12);
        this.optAddGlobal.Name = "optAddGlobal";
        this.optAddGlobal.Size = new System.Drawing.Size(59, 17);
        this.optAddGlobal.TabIndex = 1;
        this.optAddGlobal.TabStop = true;
        this.optAddGlobal.Text = "Global";
        this.optAddGlobal.UseVisualStyleBackColor = true;
        // 
        // optAddLocal
        // 
        this.optAddLocal.AutoSize = true;
        this.optAddLocal.Checked = true;
        this.optAddLocal.Location = new System.Drawing.Point(12, 12);
        this.optAddLocal.Name = "optAddLocal";
        this.optAddLocal.Size = new System.Drawing.Size(51, 17);
        this.optAddLocal.TabIndex = 0;
        this.optAddLocal.TabStop = true;
        this.optAddLocal.Text = "Local";
        this.optAddLocal.UseVisualStyleBackColor = true;
        // 
        // TabPage2
        // 
        this.TabPage2.Controls.Add(this.lvJob);
        this.TabPage2.Location = new System.Drawing.Point(4, 22);
        this.TabPage2.Name = "TabPage2";
        this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage2.Size = new System.Drawing.Size(421, 156);
        this.TabPage2.TabIndex = 1;
        this.TabPage2.Text = "Existing job";
        this.TabPage2.UseVisualStyleBackColor = true;
        // 
        // lvJob
        // 
        this.lvJob.AllowColumnReorder = true;
        this.lvJob.CatchErrors = false;
        this.lvJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader50, this.ColumnHeader5 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        this.lvJob.ConnectionObj = CConnection1;
        this.lvJob.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvJob.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lvJob.FullRowSelect = true;
        ListViewGroup1.Header = "Tasks";
        ListViewGroup1.Name = "gpOther";
        ListViewGroup2.Header = "Search result";
        ListViewGroup2.Name = "gpSearch";
        this.lvJob.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.lvJob.HideSelection = false;
        this.lvJob.Location = new System.Drawing.Point(3, 3);
        this.lvJob.MultiSelect = false;
        this.lvJob.Name = "lvJob";
        this.lvJob.OverriddenDoubleBuffered = true;
        this.lvJob.ReorganizeColumns = true;
        this.lvJob.Size = new System.Drawing.Size(415, 150);
        this.lvJob.TabIndex = 11;
        this.lvJob.UseCompatibleStateImageBehavior = false;
        this.lvJob.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader50
        // 
        this.ColumnHeader50.Text = "Name";
        this.ColumnHeader50.Width = 284;
        // 
        // ColumnHeader5
        // 
        this.ColumnHeader5.Text = "ProcessesCount";
        this.ColumnHeader5.Width = 113;
        // 
        // TableLayoutPanel1
        // 
        this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.TableLayoutPanel1.ColumnCount = 2;
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
        this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
        this.TableLayoutPanel1.Location = new System.Drawing.Point(281, 0);
        this.TableLayoutPanel1.Name = "TableLayoutPanel1";
        this.TableLayoutPanel1.RowCount = 1;
        this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
        this.TableLayoutPanel1.TabIndex = 1;
        // 
        // OK_Button
        // 
        this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.OK_Button.Location = new System.Drawing.Point(3, 3);
        this.OK_Button.Name = "OK_Button";
        this.OK_Button.Size = new System.Drawing.Size(67, 23);
        this.OK_Button.TabIndex = 0;
        this.OK_Button.Text = "OK";
        // 
        // Cancel_Button
        // 
        this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
        this.Cancel_Button.Name = "Cancel_Button";
        this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
        this.Cancel_Button.TabIndex = 1;
        this.Cancel_Button.Text = "Cancel";
        // 
        // Timer
        // 
        this.Timer.Enabled = true;
        this.Timer.Interval = 1000;
        // 
        // frmAddToJob
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(429, 215);
        this.Controls.Add(this.SplitContainer1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAddToJob";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add process to job";
        this.SplitContainer1.Panel1.ResumeLayout(false);
        this.SplitContainer1.Panel2.ResumeLayout(false);
        this.SplitContainer1.ResumeLayout(false);
        this.tab.ResumeLayout(false);
        this.TabPage1.ResumeLayout(false);
        this.TabPage1.PerformLayout();
        this.TabPage2.ResumeLayout(false);
        this.TableLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
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

    private System.Windows.Forms.TabControl _tab;

    internal System.Windows.Forms.TabControl tab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tab != null)
            {
            }

            _tab = value;
            if (_tab != null)
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

    private jobList _lvJob;

    internal jobList lvJob
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvJob;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvJob != null)
            {
            }

            _lvJob = value;
            if (_lvJob != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader50;

    internal System.Windows.Forms.ColumnHeader ColumnHeader50
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader50;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader50 != null)
            {
            }

            _ColumnHeader50 = value;
            if (_ColumnHeader50 != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader5;

    internal System.Windows.Forms.ColumnHeader ColumnHeader5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader5 != null)
            {
            }

            _ColumnHeader5 = value;
            if (_ColumnHeader5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TableLayoutPanel _TableLayoutPanel1;

    internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TableLayoutPanel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TableLayoutPanel1 != null)
            {
            }

            _TableLayoutPanel1 = value;
            if (_TableLayoutPanel1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _OK_Button;

    internal System.Windows.Forms.Button OK_Button
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OK_Button;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_OK_Button != null)
            {
            }

            _OK_Button = value;
            if (_OK_Button != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _Cancel_Button;

    internal System.Windows.Forms.Button Cancel_Button
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Cancel_Button;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Cancel_Button != null)
            {
            }

            _Cancel_Button = value;
            if (_Cancel_Button != null)
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

    private System.Windows.Forms.TextBox _txtJobName;

    internal System.Windows.Forms.TextBox txtJobName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtJobName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtJobName != null)
            {
            }

            _txtJobName = value;
            if (_txtJobName != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optAddGlobal;

    internal System.Windows.Forms.RadioButton optAddGlobal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optAddGlobal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optAddGlobal != null)
            {
            }

            _optAddGlobal = value;
            if (_optAddGlobal != null)
            {
            }
        }
    }

    private System.Windows.Forms.RadioButton _optAddLocal;

    internal System.Windows.Forms.RadioButton optAddLocal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _optAddLocal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_optAddLocal != null)
            {
            }

            _optAddLocal = value;
            if (_optAddLocal != null)
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
}

