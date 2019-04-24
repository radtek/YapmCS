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
partial class frmProcessAffinity : System.Windows.Forms.Form
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
        this.cmdOK = new System.Windows.Forms.Button();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.chk0 = new System.Windows.Forms.CheckBox();
        this.chk1 = new System.Windows.Forms.CheckBox();
        this.chk3 = new System.Windows.Forms.CheckBox();
        this.chk2 = new System.Windows.Forms.CheckBox();
        this.chk5 = new System.Windows.Forms.CheckBox();
        this.chk4 = new System.Windows.Forms.CheckBox();
        this.chk7 = new System.Windows.Forms.CheckBox();
        this.chk6 = new System.Windows.Forms.CheckBox();
        this.chk15 = new System.Windows.Forms.CheckBox();
        this.chk14 = new System.Windows.Forms.CheckBox();
        this.chk13 = new System.Windows.Forms.CheckBox();
        this.chk12 = new System.Windows.Forms.CheckBox();
        this.chk11 = new System.Windows.Forms.CheckBox();
        this.chk10 = new System.Windows.Forms.CheckBox();
        this.chk9 = new System.Windows.Forms.CheckBox();
        this.chk8 = new System.Windows.Forms.CheckBox();
        this.chk23 = new System.Windows.Forms.CheckBox();
        this.chk22 = new System.Windows.Forms.CheckBox();
        this.chk21 = new System.Windows.Forms.CheckBox();
        this.chk20 = new System.Windows.Forms.CheckBox();
        this.chk19 = new System.Windows.Forms.CheckBox();
        this.chk18 = new System.Windows.Forms.CheckBox();
        this.chk17 = new System.Windows.Forms.CheckBox();
        this.chk16 = new System.Windows.Forms.CheckBox();
        this.chk31 = new System.Windows.Forms.CheckBox();
        this.chk30 = new System.Windows.Forms.CheckBox();
        this.chk29 = new System.Windows.Forms.CheckBox();
        this.chk28 = new System.Windows.Forms.CheckBox();
        this.chk27 = new System.Windows.Forms.CheckBox();
        this.chk26 = new System.Windows.Forms.CheckBox();
        this.chk25 = new System.Windows.Forms.CheckBox();
        this.chk24 = new System.Windows.Forms.CheckBox();
        this.SuspendLayout();
        // 
        // cmdOK
        // 
        this.cmdOK.Location = new System.Drawing.Point(105, 201);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 0;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // cmdCancel
        // 
        this.cmdCancel.Location = new System.Drawing.Point(186, 201);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(75, 23);
        this.cmdCancel.TabIndex = 1;
        this.cmdCancel.Text = "Cancel";
        this.cmdCancel.UseVisualStyleBackColor = true;
        // 
        // chk0
        // 
        this.chk0.AutoSize = true;
        this.chk0.Location = new System.Drawing.Point(12, 12);
        this.chk0.Name = "chk0";
        this.chk0.Size = new System.Drawing.Size(56, 17);
        this.chk0.TabIndex = 2;
        this.chk0.Text = "CPU 0";
        this.chk0.UseVisualStyleBackColor = true;
        // 
        // chk1
        // 
        this.chk1.AutoSize = true;
        this.chk1.Enabled = false;
        this.chk1.Location = new System.Drawing.Point(12, 35);
        this.chk1.Name = "chk1";
        this.chk1.Size = new System.Drawing.Size(56, 17);
        this.chk1.TabIndex = 3;
        this.chk1.Text = "CPU 1";
        this.chk1.UseVisualStyleBackColor = true;
        // 
        // chk3
        // 
        this.chk3.AutoSize = true;
        this.chk3.Enabled = false;
        this.chk3.Location = new System.Drawing.Point(12, 81);
        this.chk3.Name = "chk3";
        this.chk3.Size = new System.Drawing.Size(56, 17);
        this.chk3.TabIndex = 5;
        this.chk3.Text = "CPU 3";
        this.chk3.UseVisualStyleBackColor = true;
        // 
        // chk2
        // 
        this.chk2.AutoSize = true;
        this.chk2.Enabled = false;
        this.chk2.Location = new System.Drawing.Point(12, 58);
        this.chk2.Name = "chk2";
        this.chk2.Size = new System.Drawing.Size(56, 17);
        this.chk2.TabIndex = 4;
        this.chk2.Text = "CPU 2";
        this.chk2.UseVisualStyleBackColor = true;
        // 
        // chk5
        // 
        this.chk5.AutoSize = true;
        this.chk5.Enabled = false;
        this.chk5.Location = new System.Drawing.Point(12, 127);
        this.chk5.Name = "chk5";
        this.chk5.Size = new System.Drawing.Size(56, 17);
        this.chk5.TabIndex = 7;
        this.chk5.Text = "CPU 5";
        this.chk5.UseVisualStyleBackColor = true;
        // 
        // chk4
        // 
        this.chk4.AutoSize = true;
        this.chk4.Enabled = false;
        this.chk4.Location = new System.Drawing.Point(12, 104);
        this.chk4.Name = "chk4";
        this.chk4.Size = new System.Drawing.Size(56, 17);
        this.chk4.TabIndex = 6;
        this.chk4.Text = "CPU 4";
        this.chk4.UseVisualStyleBackColor = true;
        // 
        // chk7
        // 
        this.chk7.AutoSize = true;
        this.chk7.Enabled = false;
        this.chk7.Location = new System.Drawing.Point(12, 173);
        this.chk7.Name = "chk7";
        this.chk7.Size = new System.Drawing.Size(56, 17);
        this.chk7.TabIndex = 9;
        this.chk7.Text = "CPU 7";
        this.chk7.UseVisualStyleBackColor = true;
        // 
        // chk6
        // 
        this.chk6.AutoSize = true;
        this.chk6.Enabled = false;
        this.chk6.Location = new System.Drawing.Point(12, 150);
        this.chk6.Name = "chk6";
        this.chk6.Size = new System.Drawing.Size(56, 17);
        this.chk6.TabIndex = 8;
        this.chk6.Text = "CPU 6";
        this.chk6.UseVisualStyleBackColor = true;
        // 
        // chk15
        // 
        this.chk15.AutoSize = true;
        this.chk15.Enabled = false;
        this.chk15.Location = new System.Drawing.Point(75, 173);
        this.chk15.Name = "chk15";
        this.chk15.Size = new System.Drawing.Size(62, 17);
        this.chk15.TabIndex = 17;
        this.chk15.Text = "CPU 15";
        this.chk15.UseVisualStyleBackColor = true;
        // 
        // chk14
        // 
        this.chk14.AutoSize = true;
        this.chk14.Enabled = false;
        this.chk14.Location = new System.Drawing.Point(75, 150);
        this.chk14.Name = "chk14";
        this.chk14.Size = new System.Drawing.Size(62, 17);
        this.chk14.TabIndex = 16;
        this.chk14.Text = "CPU 14";
        this.chk14.UseVisualStyleBackColor = true;
        // 
        // chk13
        // 
        this.chk13.AutoSize = true;
        this.chk13.Enabled = false;
        this.chk13.Location = new System.Drawing.Point(75, 127);
        this.chk13.Name = "chk13";
        this.chk13.Size = new System.Drawing.Size(62, 17);
        this.chk13.TabIndex = 15;
        this.chk13.Text = "CPU 13";
        this.chk13.UseVisualStyleBackColor = true;
        // 
        // chk12
        // 
        this.chk12.AutoSize = true;
        this.chk12.Enabled = false;
        this.chk12.Location = new System.Drawing.Point(75, 104);
        this.chk12.Name = "chk12";
        this.chk12.Size = new System.Drawing.Size(62, 17);
        this.chk12.TabIndex = 14;
        this.chk12.Text = "CPU 12";
        this.chk12.UseVisualStyleBackColor = true;
        // 
        // chk11
        // 
        this.chk11.AutoSize = true;
        this.chk11.Enabled = false;
        this.chk11.Location = new System.Drawing.Point(75, 81);
        this.chk11.Name = "chk11";
        this.chk11.Size = new System.Drawing.Size(62, 17);
        this.chk11.TabIndex = 13;
        this.chk11.Text = "CPU 11";
        this.chk11.UseVisualStyleBackColor = true;
        // 
        // chk10
        // 
        this.chk10.AutoSize = true;
        this.chk10.Enabled = false;
        this.chk10.Location = new System.Drawing.Point(75, 58);
        this.chk10.Name = "chk10";
        this.chk10.Size = new System.Drawing.Size(62, 17);
        this.chk10.TabIndex = 12;
        this.chk10.Text = "CPU 10";
        this.chk10.UseVisualStyleBackColor = true;
        // 
        // chk9
        // 
        this.chk9.AutoSize = true;
        this.chk9.Enabled = false;
        this.chk9.Location = new System.Drawing.Point(75, 35);
        this.chk9.Name = "chk9";
        this.chk9.Size = new System.Drawing.Size(56, 17);
        this.chk9.TabIndex = 11;
        this.chk9.Text = "CPU 9";
        this.chk9.UseVisualStyleBackColor = true;
        // 
        // chk8
        // 
        this.chk8.AutoSize = true;
        this.chk8.Enabled = false;
        this.chk8.Location = new System.Drawing.Point(75, 12);
        this.chk8.Name = "chk8";
        this.chk8.Size = new System.Drawing.Size(56, 17);
        this.chk8.TabIndex = 10;
        this.chk8.Text = "CPU 8";
        this.chk8.UseVisualStyleBackColor = true;
        // 
        // chk23
        // 
        this.chk23.AutoSize = true;
        this.chk23.Enabled = false;
        this.chk23.Location = new System.Drawing.Point(138, 173);
        this.chk23.Name = "chk23";
        this.chk23.Size = new System.Drawing.Size(62, 17);
        this.chk23.TabIndex = 25;
        this.chk23.Text = "CPU 23";
        this.chk23.UseVisualStyleBackColor = true;
        // 
        // chk22
        // 
        this.chk22.AutoSize = true;
        this.chk22.Enabled = false;
        this.chk22.Location = new System.Drawing.Point(138, 150);
        this.chk22.Name = "chk22";
        this.chk22.Size = new System.Drawing.Size(62, 17);
        this.chk22.TabIndex = 24;
        this.chk22.Text = "CPU 22";
        this.chk22.UseVisualStyleBackColor = true;
        // 
        // chk21
        // 
        this.chk21.AutoSize = true;
        this.chk21.Enabled = false;
        this.chk21.Location = new System.Drawing.Point(138, 127);
        this.chk21.Name = "chk21";
        this.chk21.Size = new System.Drawing.Size(62, 17);
        this.chk21.TabIndex = 23;
        this.chk21.Text = "CPU 21";
        this.chk21.UseVisualStyleBackColor = true;
        // 
        // chk20
        // 
        this.chk20.AutoSize = true;
        this.chk20.Enabled = false;
        this.chk20.Location = new System.Drawing.Point(138, 104);
        this.chk20.Name = "chk20";
        this.chk20.Size = new System.Drawing.Size(62, 17);
        this.chk20.TabIndex = 22;
        this.chk20.Text = "CPU 20";
        this.chk20.UseVisualStyleBackColor = true;
        // 
        // chk19
        // 
        this.chk19.AutoSize = true;
        this.chk19.Enabled = false;
        this.chk19.Location = new System.Drawing.Point(138, 81);
        this.chk19.Name = "chk19";
        this.chk19.Size = new System.Drawing.Size(62, 17);
        this.chk19.TabIndex = 21;
        this.chk19.Text = "CPU 19";
        this.chk19.UseVisualStyleBackColor = true;
        // 
        // chk18
        // 
        this.chk18.AutoSize = true;
        this.chk18.Enabled = false;
        this.chk18.Location = new System.Drawing.Point(138, 58);
        this.chk18.Name = "chk18";
        this.chk18.Size = new System.Drawing.Size(62, 17);
        this.chk18.TabIndex = 20;
        this.chk18.Text = "CPU 18";
        this.chk18.UseVisualStyleBackColor = true;
        // 
        // chk17
        // 
        this.chk17.AutoSize = true;
        this.chk17.Enabled = false;
        this.chk17.Location = new System.Drawing.Point(138, 35);
        this.chk17.Name = "chk17";
        this.chk17.Size = new System.Drawing.Size(62, 17);
        this.chk17.TabIndex = 19;
        this.chk17.Text = "CPU 17";
        this.chk17.UseVisualStyleBackColor = true;
        // 
        // chk16
        // 
        this.chk16.AutoSize = true;
        this.chk16.Enabled = false;
        this.chk16.Location = new System.Drawing.Point(138, 12);
        this.chk16.Name = "chk16";
        this.chk16.Size = new System.Drawing.Size(62, 17);
        this.chk16.TabIndex = 18;
        this.chk16.Text = "CPU 16";
        this.chk16.UseVisualStyleBackColor = true;
        // 
        // chk31
        // 
        this.chk31.AutoSize = true;
        this.chk31.Enabled = false;
        this.chk31.Location = new System.Drawing.Point(201, 173);
        this.chk31.Name = "chk31";
        this.chk31.Size = new System.Drawing.Size(62, 17);
        this.chk31.TabIndex = 33;
        this.chk31.Text = "CPU 31";
        this.chk31.UseVisualStyleBackColor = true;
        // 
        // chk30
        // 
        this.chk30.AutoSize = true;
        this.chk30.Enabled = false;
        this.chk30.Location = new System.Drawing.Point(201, 150);
        this.chk30.Name = "chk30";
        this.chk30.Size = new System.Drawing.Size(62, 17);
        this.chk30.TabIndex = 32;
        this.chk30.Text = "CPU 30";
        this.chk30.UseVisualStyleBackColor = true;
        // 
        // chk29
        // 
        this.chk29.AutoSize = true;
        this.chk29.Enabled = false;
        this.chk29.Location = new System.Drawing.Point(201, 127);
        this.chk29.Name = "chk29";
        this.chk29.Size = new System.Drawing.Size(62, 17);
        this.chk29.TabIndex = 31;
        this.chk29.Text = "CPU 29";
        this.chk29.UseVisualStyleBackColor = true;
        // 
        // chk28
        // 
        this.chk28.AutoSize = true;
        this.chk28.Enabled = false;
        this.chk28.Location = new System.Drawing.Point(201, 104);
        this.chk28.Name = "chk28";
        this.chk28.Size = new System.Drawing.Size(62, 17);
        this.chk28.TabIndex = 30;
        this.chk28.Text = "CPU 28";
        this.chk28.UseVisualStyleBackColor = true;
        // 
        // chk27
        // 
        this.chk27.AutoSize = true;
        this.chk27.Enabled = false;
        this.chk27.Location = new System.Drawing.Point(201, 81);
        this.chk27.Name = "chk27";
        this.chk27.Size = new System.Drawing.Size(62, 17);
        this.chk27.TabIndex = 29;
        this.chk27.Text = "CPU 27";
        this.chk27.UseVisualStyleBackColor = true;
        // 
        // chk26
        // 
        this.chk26.AutoSize = true;
        this.chk26.Enabled = false;
        this.chk26.Location = new System.Drawing.Point(201, 58);
        this.chk26.Name = "chk26";
        this.chk26.Size = new System.Drawing.Size(62, 17);
        this.chk26.TabIndex = 28;
        this.chk26.Text = "CPU 26";
        this.chk26.UseVisualStyleBackColor = true;
        // 
        // chk25
        // 
        this.chk25.AutoSize = true;
        this.chk25.Enabled = false;
        this.chk25.Location = new System.Drawing.Point(201, 35);
        this.chk25.Name = "chk25";
        this.chk25.Size = new System.Drawing.Size(62, 17);
        this.chk25.TabIndex = 27;
        this.chk25.Text = "CPU 25";
        this.chk25.UseVisualStyleBackColor = true;
        // 
        // chk24
        // 
        this.chk24.AutoSize = true;
        this.chk24.Enabled = false;
        this.chk24.Location = new System.Drawing.Point(201, 12);
        this.chk24.Name = "chk24";
        this.chk24.Size = new System.Drawing.Size(62, 17);
        this.chk24.TabIndex = 26;
        this.chk24.Text = "CPU 24";
        this.chk24.UseVisualStyleBackColor = true;
        // 
        // frmProcessAffinity
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(273, 236);
        this.Controls.Add(this.chk31);
        this.Controls.Add(this.chk30);
        this.Controls.Add(this.chk29);
        this.Controls.Add(this.chk28);
        this.Controls.Add(this.chk27);
        this.Controls.Add(this.chk26);
        this.Controls.Add(this.chk25);
        this.Controls.Add(this.chk24);
        this.Controls.Add(this.chk23);
        this.Controls.Add(this.chk22);
        this.Controls.Add(this.chk21);
        this.Controls.Add(this.chk20);
        this.Controls.Add(this.chk19);
        this.Controls.Add(this.chk18);
        this.Controls.Add(this.chk17);
        this.Controls.Add(this.chk16);
        this.Controls.Add(this.chk15);
        this.Controls.Add(this.chk14);
        this.Controls.Add(this.chk13);
        this.Controls.Add(this.chk12);
        this.Controls.Add(this.chk11);
        this.Controls.Add(this.chk10);
        this.Controls.Add(this.chk9);
        this.Controls.Add(this.chk8);
        this.Controls.Add(this.chk7);
        this.Controls.Add(this.chk6);
        this.Controls.Add(this.chk5);
        this.Controls.Add(this.chk4);
        this.Controls.Add(this.chk3);
        this.Controls.Add(this.chk2);
        this.Controls.Add(this.chk1);
        this.Controls.Add(this.chk0);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this.cmdOK);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmProcessAffinity";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Set processor affinity";
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.CheckBox _chk0;

    internal System.Windows.Forms.CheckBox chk0
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk0 != null)
            {
            }

            _chk0 = value;
            if (_chk0 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk1;

    internal System.Windows.Forms.CheckBox chk1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk1 != null)
            {
            }

            _chk1 = value;
            if (_chk1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk3;

    internal System.Windows.Forms.CheckBox chk3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk3 != null)
            {
            }

            _chk3 = value;
            if (_chk3 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk2;

    internal System.Windows.Forms.CheckBox chk2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk2 != null)
            {
            }

            _chk2 = value;
            if (_chk2 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk5;

    internal System.Windows.Forms.CheckBox chk5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk5 != null)
            {
            }

            _chk5 = value;
            if (_chk5 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk4;

    internal System.Windows.Forms.CheckBox chk4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk4 != null)
            {
            }

            _chk4 = value;
            if (_chk4 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk7;

    internal System.Windows.Forms.CheckBox chk7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk7 != null)
            {
            }

            _chk7 = value;
            if (_chk7 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk6;

    internal System.Windows.Forms.CheckBox chk6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk6 != null)
            {
            }

            _chk6 = value;
            if (_chk6 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk15;

    internal System.Windows.Forms.CheckBox chk15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk15 != null)
            {
            }

            _chk15 = value;
            if (_chk15 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk14;

    internal System.Windows.Forms.CheckBox chk14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk14 != null)
            {
            }

            _chk14 = value;
            if (_chk14 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk13;

    internal System.Windows.Forms.CheckBox chk13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk13 != null)
            {
            }

            _chk13 = value;
            if (_chk13 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk12;

    internal System.Windows.Forms.CheckBox chk12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk12 != null)
            {
            }

            _chk12 = value;
            if (_chk12 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk11;

    internal System.Windows.Forms.CheckBox chk11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk11 != null)
            {
            }

            _chk11 = value;
            if (_chk11 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk10;

    internal System.Windows.Forms.CheckBox chk10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk10 != null)
            {
            }

            _chk10 = value;
            if (_chk10 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk9;

    internal System.Windows.Forms.CheckBox chk9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk9 != null)
            {
            }

            _chk9 = value;
            if (_chk9 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk8;

    internal System.Windows.Forms.CheckBox chk8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk8 != null)
            {
            }

            _chk8 = value;
            if (_chk8 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk23;

    internal System.Windows.Forms.CheckBox chk23
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk23;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk23 != null)
            {
            }

            _chk23 = value;
            if (_chk23 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk22;

    internal System.Windows.Forms.CheckBox chk22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk22 != null)
            {
            }

            _chk22 = value;
            if (_chk22 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk21;

    internal System.Windows.Forms.CheckBox chk21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk21 != null)
            {
            }

            _chk21 = value;
            if (_chk21 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk20;

    internal System.Windows.Forms.CheckBox chk20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk20 != null)
            {
            }

            _chk20 = value;
            if (_chk20 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk19;

    internal System.Windows.Forms.CheckBox chk19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk19 != null)
            {
            }

            _chk19 = value;
            if (_chk19 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk18;

    internal System.Windows.Forms.CheckBox chk18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk18 != null)
            {
            }

            _chk18 = value;
            if (_chk18 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk17;

    internal System.Windows.Forms.CheckBox chk17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk17 != null)
            {
            }

            _chk17 = value;
            if (_chk17 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk16;

    internal System.Windows.Forms.CheckBox chk16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk16 != null)
            {
            }

            _chk16 = value;
            if (_chk16 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk31;

    internal System.Windows.Forms.CheckBox chk31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk31 != null)
            {
            }

            _chk31 = value;
            if (_chk31 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk30;

    internal System.Windows.Forms.CheckBox chk30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk30 != null)
            {
            }

            _chk30 = value;
            if (_chk30 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk29;

    internal System.Windows.Forms.CheckBox chk29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk29 != null)
            {
            }

            _chk29 = value;
            if (_chk29 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk28;

    internal System.Windows.Forms.CheckBox chk28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk28 != null)
            {
            }

            _chk28 = value;
            if (_chk28 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk27;

    internal System.Windows.Forms.CheckBox chk27
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk27;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk27 != null)
            {
            }

            _chk27 = value;
            if (_chk27 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk26;

    internal System.Windows.Forms.CheckBox chk26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk26 != null)
            {
            }

            _chk26 = value;
            if (_chk26 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk25;

    internal System.Windows.Forms.CheckBox chk25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk25 != null)
            {
            }

            _chk25 = value;
            if (_chk25 != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chk24;

    internal System.Windows.Forms.CheckBox chk24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chk24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chk24 != null)
            {
            }

            _chk24 = value;
            if (_chk24 != null)
            {
            }
        }
    }
}

