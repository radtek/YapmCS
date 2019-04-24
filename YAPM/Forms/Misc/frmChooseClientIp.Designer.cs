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
partial class frmChooseClientIp : System.Windows.Forms.Form
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
        this.cmdExit = new System.Windows.Forms.Button();
        this.lvNIC = new DoubleBufferedLV();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdOk = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // cmdExit
        // 
        this.cmdExit.Location = new System.Drawing.Point(234, 245);
        this.cmdExit.Name = "cmdExit";
        this.cmdExit.Size = new System.Drawing.Size(88, 26);
        this.cmdExit.TabIndex = 2;
        this.cmdExit.Text = "Cancel";
        this.cmdExit.UseVisualStyleBackColor = true;
        // 
        // lvNIC
        // 
        this.lvNIC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2, this.ColumnHeader3, this.ColumnHeader4 });
        this.lvNIC.FullRowSelect = true;
        this.lvNIC.Location = new System.Drawing.Point(12, 78);
        this.lvNIC.MultiSelect = false;
        this.lvNIC.Name = "lvNIC";
        this.lvNIC.OverriddenDoubleBuffered = true;
        this.lvNIC.Size = new System.Drawing.Size(361, 155);
        this.lvNIC.TabIndex = 3;
        this.lvNIC.UseCompatibleStateImageBehavior = false;
        this.lvNIC.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Name";
        this.ColumnHeader2.Width = 89;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Ip";
        this.ColumnHeader3.Width = 89;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Description";
        this.ColumnHeader4.Width = 161;
        // 
        // Label1
        // 
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(361, 52);
        this.Label1.TabIndex = 4;
        this.Label1.Text = "You have more than one Network Card Interface (NIC) installed on your computer." + (char)13 + (char)10 + "To establish the communication with the server, please choose the correct NIC to" + " use.";
        // 
        // cmdOk
        // 
        this.cmdOk.Enabled = false;
        this.cmdOk.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.cmdOk.Location = new System.Drawing.Point(63, 245);
        this.cmdOk.Name = "cmdOk";
        this.cmdOk.Size = new System.Drawing.Size(88, 26);
        this.cmdOk.TabIndex = 5;
        this.cmdOk.Text = "OK";
        this.cmdOk.UseVisualStyleBackColor = true;
        // 
        // frmChooseClientIp
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(385, 282);
        this.Controls.Add(this.cmdOk);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.lvNIC);
        this.Controls.Add(this.cmdExit);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "frmChooseClientIp";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Choose network interface card";
        this.ResumeLayout(false);
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

    private DoubleBufferedLV _lvNIC;

    internal DoubleBufferedLV lvNIC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lvNIC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lvNIC != null)
            {
            }

            _lvNIC = value;
            if (_lvNIC != null)
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

    private System.Windows.Forms.Button _cmdOk;

    internal System.Windows.Forms.Button cmdOk
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOk;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOk != null)
            {
            }

            _cmdOk = value;
            if (_cmdOk != null)
            {
            }
        }
    }
}

