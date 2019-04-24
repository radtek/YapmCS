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
partial class frmLogOptions : System.Windows.Forms.Form
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
        this.logInterval = new System.Windows.Forms.NumericUpDown();
        this.Label2 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.captureDeleted = new System.Windows.Forms.CheckBox();
        this.captureCreated = new System.Windows.Forms.CheckBox();
        this.captureWindows = new System.Windows.Forms.CheckBox();
        this.captureThreads = new System.Windows.Forms.CheckBox();
        this.captureServices = new System.Windows.Forms.CheckBox();
        this.captureNetwork = new System.Windows.Forms.CheckBox();
        this.captureModules = new System.Windows.Forms.CheckBox();
        this.captureMemoryRegions = new System.Windows.Forms.CheckBox();
        this.captureHandles = new System.Windows.Forms.CheckBox();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.showDeleted = new System.Windows.Forms.CheckBox();
        this.showCreated = new System.Windows.Forms.CheckBox();
        this.showWindows = new System.Windows.Forms.CheckBox();
        this.showThreads = new System.Windows.Forms.CheckBox();
        this.showServices = new System.Windows.Forms.CheckBox();
        this.showNetwork = new System.Windows.Forms.CheckBox();
        this.showModules = new System.Windows.Forms.CheckBox();
        this.showMemoryRegions = new System.Windows.Forms.CheckBox();
        this.showHandles = new System.Windows.Forms.CheckBox();
        this.cmdOK = new System.Windows.Forms.Button();
        this._autoScroll = new System.Windows.Forms.CheckBox();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.Line2 = new HorizontalLine();
        this.Line1 = new HorizontalLine();
        ((System.ComponentModel.ISupportInitialize)this.logInterval).BeginInit();
        this.GroupBox1.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // logInterval
        // 
        this.logInterval.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        this.logInterval.Location = new System.Drawing.Point(61, 264);
        this.logInterval.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        this.logInterval.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        this.logInterval.Name = "logInterval";
        this.logInterval.Size = new System.Drawing.Size(52, 22);
        this.logInterval.TabIndex = 0;
        this.logInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.logInterval.Value = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(13, 266);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(45, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Interval";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.Line1);
        this.GroupBox1.Controls.Add(this.captureDeleted);
        this.GroupBox1.Controls.Add(this.captureCreated);
        this.GroupBox1.Controls.Add(this.captureWindows);
        this.GroupBox1.Controls.Add(this.captureThreads);
        this.GroupBox1.Controls.Add(this.captureServices);
        this.GroupBox1.Controls.Add(this.captureNetwork);
        this.GroupBox1.Controls.Add(this.captureModules);
        this.GroupBox1.Controls.Add(this.captureMemoryRegions);
        this.GroupBox1.Controls.Add(this.captureHandles);
        this.GroupBox1.Location = new System.Drawing.Point(12, 12);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(128, 240);
        this.GroupBox1.TabIndex = 7;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Capture";
        // 
        // captureDeleted
        // 
        this.captureDeleted.AutoSize = true;
        this.captureDeleted.Checked = true;
        this.captureDeleted.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureDeleted.Location = new System.Drawing.Point(6, 215);
        this.captureDeleted.Name = "captureDeleted";
        this.captureDeleted.Size = new System.Drawing.Size(66, 17);
        this.captureDeleted.TabIndex = 9;
        this.captureDeleted.Text = "Deleted";
        this.captureDeleted.UseVisualStyleBackColor = true;
        // 
        // captureCreated
        // 
        this.captureCreated.AutoSize = true;
        this.captureCreated.Checked = true;
        this.captureCreated.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureCreated.Location = new System.Drawing.Point(6, 192);
        this.captureCreated.Name = "captureCreated";
        this.captureCreated.Size = new System.Drawing.Size(66, 17);
        this.captureCreated.TabIndex = 8;
        this.captureCreated.Text = "Created";
        this.captureCreated.UseVisualStyleBackColor = true;
        // 
        // captureWindows
        // 
        this.captureWindows.AutoSize = true;
        this.captureWindows.Checked = true;
        this.captureWindows.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureWindows.Location = new System.Drawing.Point(8, 157);
        this.captureWindows.Name = "captureWindows";
        this.captureWindows.Size = new System.Drawing.Size(75, 17);
        this.captureWindows.TabIndex = 7;
        this.captureWindows.Text = "Windows";
        this.captureWindows.UseVisualStyleBackColor = true;
        // 
        // captureThreads
        // 
        this.captureThreads.AutoSize = true;
        this.captureThreads.Checked = true;
        this.captureThreads.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureThreads.Location = new System.Drawing.Point(8, 134);
        this.captureThreads.Name = "captureThreads";
        this.captureThreads.Size = new System.Drawing.Size(66, 17);
        this.captureThreads.TabIndex = 6;
        this.captureThreads.Text = "Threads";
        this.captureThreads.UseVisualStyleBackColor = true;
        // 
        // captureServices
        // 
        this.captureServices.AutoSize = true;
        this.captureServices.Checked = true;
        this.captureServices.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureServices.Location = new System.Drawing.Point(8, 111);
        this.captureServices.Name = "captureServices";
        this.captureServices.Size = new System.Drawing.Size(66, 17);
        this.captureServices.TabIndex = 5;
        this.captureServices.Text = "Services";
        this.captureServices.UseVisualStyleBackColor = true;
        // 
        // captureNetwork
        // 
        this.captureNetwork.AutoSize = true;
        this.captureNetwork.Checked = true;
        this.captureNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureNetwork.Location = new System.Drawing.Point(8, 88);
        this.captureNetwork.Name = "captureNetwork";
        this.captureNetwork.Size = new System.Drawing.Size(70, 17);
        this.captureNetwork.TabIndex = 4;
        this.captureNetwork.Text = "Network";
        this.captureNetwork.UseVisualStyleBackColor = true;
        // 
        // captureModules
        // 
        this.captureModules.AutoSize = true;
        this.captureModules.Checked = true;
        this.captureModules.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureModules.Location = new System.Drawing.Point(8, 65);
        this.captureModules.Name = "captureModules";
        this.captureModules.Size = new System.Drawing.Size(71, 17);
        this.captureModules.TabIndex = 3;
        this.captureModules.Text = "Modules";
        this.captureModules.UseVisualStyleBackColor = true;
        // 
        // captureMemoryRegions
        // 
        this.captureMemoryRegions.AutoSize = true;
        this.captureMemoryRegions.Checked = true;
        this.captureMemoryRegions.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureMemoryRegions.Location = new System.Drawing.Point(8, 42);
        this.captureMemoryRegions.Name = "captureMemoryRegions";
        this.captureMemoryRegions.Size = new System.Drawing.Size(109, 17);
        this.captureMemoryRegions.TabIndex = 1;
        this.captureMemoryRegions.Text = "Memory regions";
        this.captureMemoryRegions.UseVisualStyleBackColor = true;
        // 
        // captureHandles
        // 
        this.captureHandles.AutoSize = true;
        this.captureHandles.Checked = true;
        this.captureHandles.CheckState = System.Windows.Forms.CheckState.Checked;
        this.captureHandles.Location = new System.Drawing.Point(8, 19);
        this.captureHandles.Name = "captureHandles";
        this.captureHandles.Size = new System.Drawing.Size(68, 17);
        this.captureHandles.TabIndex = 0;
        this.captureHandles.Text = "Handles";
        this.captureHandles.UseVisualStyleBackColor = true;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.Line2);
        this.GroupBox2.Controls.Add(this.showDeleted);
        this.GroupBox2.Controls.Add(this.showCreated);
        this.GroupBox2.Controls.Add(this.showWindows);
        this.GroupBox2.Controls.Add(this.showThreads);
        this.GroupBox2.Controls.Add(this.showServices);
        this.GroupBox2.Controls.Add(this.showNetwork);
        this.GroupBox2.Controls.Add(this.showModules);
        this.GroupBox2.Controls.Add(this.showMemoryRegions);
        this.GroupBox2.Controls.Add(this.showHandles);
        this.GroupBox2.Location = new System.Drawing.Point(146, 12);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(128, 240);
        this.GroupBox2.TabIndex = 8;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Show";
        // 
        // showDeleted
        // 
        this.showDeleted.AutoSize = true;
        this.showDeleted.Checked = true;
        this.showDeleted.CheckState = System.Windows.Forms.CheckState.Checked;
        this.showDeleted.Location = new System.Drawing.Point(8, 215);
        this.showDeleted.Name = "showDeleted";
        this.showDeleted.Size = new System.Drawing.Size(66, 17);
        this.showDeleted.TabIndex = 18;
        this.showDeleted.Text = "Deleted";
        this.showDeleted.UseVisualStyleBackColor = true;
        // 
        // showCreated
        // 
        this.showCreated.AutoSize = true;
        this.showCreated.Checked = true;
        this.showCreated.CheckState = System.Windows.Forms.CheckState.Checked;
        this.showCreated.Location = new System.Drawing.Point(8, 192);
        this.showCreated.Name = "showCreated";
        this.showCreated.Size = new System.Drawing.Size(66, 17);
        this.showCreated.TabIndex = 17;
        this.showCreated.Text = "Created";
        this.showCreated.UseVisualStyleBackColor = true;
        // 
        // showWindows
        // 
        this.showWindows.AutoSize = true;
        this.showWindows.Location = new System.Drawing.Point(8, 157);
        this.showWindows.Name = "showWindows";
        this.showWindows.Size = new System.Drawing.Size(75, 17);
        this.showWindows.TabIndex = 16;
        this.showWindows.Text = "Windows";
        this.showWindows.UseVisualStyleBackColor = true;
        // 
        // showThreads
        // 
        this.showThreads.AutoSize = true;
        this.showThreads.Location = new System.Drawing.Point(8, 134);
        this.showThreads.Name = "showThreads";
        this.showThreads.Size = new System.Drawing.Size(66, 17);
        this.showThreads.TabIndex = 15;
        this.showThreads.Text = "Threads";
        this.showThreads.UseVisualStyleBackColor = true;
        // 
        // showServices
        // 
        this.showServices.AutoSize = true;
        this.showServices.Location = new System.Drawing.Point(8, 111);
        this.showServices.Name = "showServices";
        this.showServices.Size = new System.Drawing.Size(66, 17);
        this.showServices.TabIndex = 14;
        this.showServices.Text = "Services";
        this.showServices.UseVisualStyleBackColor = true;
        // 
        // showNetwork
        // 
        this.showNetwork.AutoSize = true;
        this.showNetwork.Location = new System.Drawing.Point(8, 88);
        this.showNetwork.Name = "showNetwork";
        this.showNetwork.Size = new System.Drawing.Size(70, 17);
        this.showNetwork.TabIndex = 13;
        this.showNetwork.Text = "Network";
        this.showNetwork.UseVisualStyleBackColor = true;
        // 
        // showModules
        // 
        this.showModules.AutoSize = true;
        this.showModules.Location = new System.Drawing.Point(8, 65);
        this.showModules.Name = "showModules";
        this.showModules.Size = new System.Drawing.Size(71, 17);
        this.showModules.TabIndex = 12;
        this.showModules.Text = "Modules";
        this.showModules.UseVisualStyleBackColor = true;
        // 
        // showMemoryRegions
        // 
        this.showMemoryRegions.AutoSize = true;
        this.showMemoryRegions.Location = new System.Drawing.Point(8, 42);
        this.showMemoryRegions.Name = "showMemoryRegions";
        this.showMemoryRegions.Size = new System.Drawing.Size(109, 17);
        this.showMemoryRegions.TabIndex = 11;
        this.showMemoryRegions.Text = "Memory regions";
        this.showMemoryRegions.UseVisualStyleBackColor = true;
        // 
        // showHandles
        // 
        this.showHandles.AutoSize = true;
        this.showHandles.Location = new System.Drawing.Point(8, 19);
        this.showHandles.Name = "showHandles";
        this.showHandles.Size = new System.Drawing.Size(68, 17);
        this.showHandles.TabIndex = 10;
        this.showHandles.Text = "Handles";
        this.showHandles.UseVisualStyleBackColor = true;
        // 
        // cmdOK
        // 
        this.cmdOK.Location = new System.Drawing.Point(40, 295);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 2;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // _autoScroll
        // 
        this._autoScroll.AutoSize = true;
        this._autoScroll.Checked = true;
        this._autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
        this._autoScroll.Location = new System.Drawing.Point(154, 265);
        this._autoScroll.Name = "_autoScroll";
        this._autoScroll.Size = new System.Drawing.Size(81, 17);
        this._autoScroll.TabIndex = 1;
        this._autoScroll.Text = "Auto scroll";
        this._autoScroll.UseVisualStyleBackColor = true;
        // 
        // cmdCancel
        // 
        this.cmdCancel.Location = new System.Drawing.Point(171, 295);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(75, 23);
        this.cmdCancel.TabIndex = 3;
        this.cmdCancel.Text = "Cancel";
        this.cmdCancel.UseVisualStyleBackColor = true;
        // 
        // Line2
        // 
        this.Line2.BackColor = System.Drawing.SystemColors.ActiveBorder;
        this.Line2.Location = new System.Drawing.Point(14, 181);
        this.Line2.Name = "Line2";
        this.Line2.Size = new System.Drawing.Size(100, 1);
        this.Line2.TabIndex = 13;
        // 
        // Line1
        // 
        this.Line1.BackColor = System.Drawing.SystemColors.ActiveBorder;
        this.Line1.Location = new System.Drawing.Point(14, 181);
        this.Line1.Name = "Line1";
        this.Line1.Size = new System.Drawing.Size(100, 1);
        this.Line1.TabIndex = 12;
        // 
        // frmLogOptions
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(287, 326);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this._autoScroll);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.GroupBox2);
        this.Controls.Add(this.GroupBox1);
        this.Controls.Add(this.logInterval);
        this.Controls.Add(this.Label2);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmLogOptions";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "Options";
        ((System.ComponentModel.ISupportInitialize)this.logInterval).EndInit();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.NumericUpDown _logInterval;

    internal System.Windows.Forms.NumericUpDown logInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _logInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_logInterval != null)
            {
            }

            _logInterval = value;
            if (_logInterval != null)
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

    private System.Windows.Forms.CheckBox _captureHandles;

    internal System.Windows.Forms.CheckBox captureHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureHandles != null)
            {
            }

            _captureHandles = value;
            if (_captureHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureWindows;

    internal System.Windows.Forms.CheckBox captureWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureWindows != null)
            {
            }

            _captureWindows = value;
            if (_captureWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureThreads;

    internal System.Windows.Forms.CheckBox captureThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureThreads != null)
            {
            }

            _captureThreads = value;
            if (_captureThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureServices;

    internal System.Windows.Forms.CheckBox captureServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureServices != null)
            {
            }

            _captureServices = value;
            if (_captureServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureNetwork;

    internal System.Windows.Forms.CheckBox captureNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureNetwork != null)
            {
            }

            _captureNetwork = value;
            if (_captureNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureModules;

    internal System.Windows.Forms.CheckBox captureModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureModules != null)
            {
            }

            _captureModules = value;
            if (_captureModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureMemoryRegions;

    internal System.Windows.Forms.CheckBox captureMemoryRegions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureMemoryRegions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureMemoryRegions != null)
            {
            }

            _captureMemoryRegions = value;
            if (_captureMemoryRegions != null)
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

    private System.Windows.Forms.CheckBox _showWindows;

    internal System.Windows.Forms.CheckBox showWindows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showWindows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showWindows != null)
            {
            }

            _showWindows = value;
            if (_showWindows != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showThreads;

    internal System.Windows.Forms.CheckBox showThreads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showThreads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showThreads != null)
            {
            }

            _showThreads = value;
            if (_showThreads != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showServices;

    internal System.Windows.Forms.CheckBox showServices
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showServices;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showServices != null)
            {
            }

            _showServices = value;
            if (_showServices != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showNetwork;

    internal System.Windows.Forms.CheckBox showNetwork
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showNetwork;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showNetwork != null)
            {
            }

            _showNetwork = value;
            if (_showNetwork != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showModules;

    internal System.Windows.Forms.CheckBox showModules
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showModules;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showModules != null)
            {
            }

            _showModules = value;
            if (_showModules != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showMemoryRegions;

    internal System.Windows.Forms.CheckBox showMemoryRegions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showMemoryRegions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showMemoryRegions != null)
            {
            }

            _showMemoryRegions = value;
            if (_showMemoryRegions != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showHandles;

    internal System.Windows.Forms.CheckBox showHandles
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showHandles;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showHandles != null)
            {
            }

            _showHandles = value;
            if (_showHandles != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showDeleted;

    internal System.Windows.Forms.CheckBox showDeleted
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showDeleted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showDeleted != null)
            {
            }

            _showDeleted = value;
            if (_showDeleted != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _showCreated;

    internal System.Windows.Forms.CheckBox showCreated
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _showCreated;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_showCreated != null)
            {
            }

            _showCreated = value;
            if (_showCreated != null)
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

    private System.Windows.Forms.CheckBox _captureDeleted;

    internal System.Windows.Forms.CheckBox captureDeleted
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureDeleted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureDeleted != null)
            {
            }

            _captureDeleted = value;
            if (_captureDeleted != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _captureCreated;

    internal System.Windows.Forms.CheckBox captureCreated
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _captureCreated;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_captureCreated != null)
            {
            }

            _captureCreated = value;
            if (_captureCreated != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox __autoScroll;

    internal System.Windows.Forms.CheckBox _autoScroll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __autoScroll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__autoScroll != null)
            {
            }

            __autoScroll = value;
            if (__autoScroll != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCancel;

    internal System.Windows.Forms.Button cmdCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCancel != null)
            {
            }

            _cmdCancel = value;
            if (_cmdCancel != null)
            {
            }
        }
    }

    private HorizontalLine _Line1;

    internal HorizontalLine Line1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Line1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Line1 != null)
            {
            }

            _Line1 = value;
            if (_Line1 != null)
            {
            }
        }
    }

    private HorizontalLine _Line2;

    internal HorizontalLine Line2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Line2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Line2 != null)
            {
            }

            _Line2 = value;
            if (_Line2 != null)
            {
            }
        }
    }
}

