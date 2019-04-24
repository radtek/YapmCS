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
partial class frmHandleInfo : System.Windows.Forms.Form
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
        this.tabProcess = new System.Windows.Forms.TabControl();
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.gpCustomControl = new System.Windows.Forms.GroupBox();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.lblNonPaged = new System.Windows.Forms.Label();
        this.Label12 = new System.Windows.Forms.Label();
        this.lblPaged = new System.Windows.Forms.Label();
        this.Label10 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.lblPointerCount = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.lblObjectCount = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.lblHandleCount = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.txtAccess = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.txtAddress = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.txtType = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.tabProcess.SuspendLayout();
        this.TabPage1.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tabProcess
        // 
        this.tabProcess.Controls.Add(this.TabPage1);
        this.tabProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.tabProcess.Location = new System.Drawing.Point(0, 0);
        this.tabProcess.Multiline = true;
        this.tabProcess.Name = "tabProcess";
        this.tabProcess.SelectedIndex = 0;
        this.tabProcess.Size = new System.Drawing.Size(334, 377);
        this.tabProcess.TabIndex = 1;
        // 
        // TabPage1
        // 
        this.TabPage1.Controls.Add(this.gpCustomControl);
        this.TabPage1.Controls.Add(this.GroupBox3);
        this.TabPage1.Controls.Add(this.GroupBox2);
        this.TabPage1.Controls.Add(this.GroupBox1);
        this.TabPage1.Location = new System.Drawing.Point(4, 22);
        this.TabPage1.Name = "TabPage1";
        this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.TabPage1.Size = new System.Drawing.Size(326, 351);
        this.TabPage1.TabIndex = 0;
        this.TabPage1.Text = "Details";
        this.TabPage1.UseVisualStyleBackColor = true;
        // 
        // gpCustomControl
        // 
        this.gpCustomControl.Location = new System.Drawing.Point(10, 218);
        this.gpCustomControl.Name = "gpCustomControl";
        this.gpCustomControl.Size = new System.Drawing.Size(308, 125);
        this.gpCustomControl.TabIndex = 3;
        this.gpCustomControl.TabStop = false;
        this.gpCustomControl.Text = "Object informations";
        // 
        // GroupBox3
        // 
        this.GroupBox3.Controls.Add(this.lblNonPaged);
        this.GroupBox3.Controls.Add(this.Label12);
        this.GroupBox3.Controls.Add(this.lblPaged);
        this.GroupBox3.Controls.Add(this.Label10);
        this.GroupBox3.Location = new System.Drawing.Point(163, 115);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(155, 97);
        this.GroupBox3.TabIndex = 2;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "Quota";
        // 
        // lblNonPaged
        // 
        this.lblNonPaged.AutoSize = true;
        this.lblNonPaged.Location = new System.Drawing.Point(78, 44);
        this.lblNonPaged.Name = "lblNonPaged";
        this.lblNonPaged.Size = new System.Drawing.Size(0, 13);
        this.lblNonPaged.TabIndex = 5;
        // 
        // Label12
        // 
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(6, 44);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(72, 13);
        this.Label12.TabIndex = 4;
        this.Label12.Text = "Non-paged :";
        // 
        // lblPaged
        // 
        this.lblPaged.AutoSize = true;
        this.lblPaged.Location = new System.Drawing.Point(78, 23);
        this.lblPaged.Name = "lblPaged";
        this.lblPaged.Size = new System.Drawing.Size(0, 13);
        this.lblPaged.TabIndex = 3;
        // 
        // Label10
        // 
        this.Label10.AutoSize = true;
        this.Label10.Location = new System.Drawing.Point(6, 23);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(45, 13);
        this.Label10.TabIndex = 2;
        this.Label10.Text = "Paged :";
        // 
        // GroupBox2
        // 
        this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
        this.GroupBox2.Controls.Add(this.lblPointerCount);
        this.GroupBox2.Controls.Add(this.Label8);
        this.GroupBox2.Controls.Add(this.lblObjectCount);
        this.GroupBox2.Controls.Add(this.Label7);
        this.GroupBox2.Controls.Add(this.lblHandleCount);
        this.GroupBox2.Controls.Add(this.Label5);
        this.GroupBox2.Location = new System.Drawing.Point(10, 115);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(147, 97);
        this.GroupBox2.TabIndex = 1;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "References";
        // 
        // lblPointerCount
        // 
        this.lblPointerCount.AutoSize = true;
        this.lblPointerCount.Location = new System.Drawing.Point(89, 67);
        this.lblPointerCount.Name = "lblPointerCount";
        this.lblPointerCount.Size = new System.Drawing.Size(0, 13);
        this.lblPointerCount.TabIndex = 5;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(7, 67);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(82, 13);
        this.Label8.TabIndex = 4;
        this.Label8.Text = "PointerCount :";
        // 
        // lblObjectCount
        // 
        this.lblObjectCount.AutoSize = true;
        this.lblObjectCount.Location = new System.Drawing.Point(89, 45);
        this.lblObjectCount.Name = "lblObjectCount";
        this.lblObjectCount.Size = new System.Drawing.Size(0, 13);
        this.lblObjectCount.TabIndex = 3;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(6, 45);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(79, 13);
        this.Label7.TabIndex = 2;
        this.Label7.Text = "ObjectCount :";
        // 
        // lblHandleCount
        // 
        this.lblHandleCount.AutoSize = true;
        this.lblHandleCount.Location = new System.Drawing.Point(89, 24);
        this.lblHandleCount.Name = "lblHandleCount";
        this.lblHandleCount.Size = new System.Drawing.Size(0, 13);
        this.lblHandleCount.TabIndex = 1;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(6, 24);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(82, 13);
        this.Label5.TabIndex = 0;
        this.Label5.Text = "HandleCount :";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.txtAccess);
        this.GroupBox1.Controls.Add(this.Label4);
        this.GroupBox1.Controls.Add(this.txtAddress);
        this.GroupBox1.Controls.Add(this.Label3);
        this.GroupBox1.Controls.Add(this.txtType);
        this.GroupBox1.Controls.Add(this.Label2);
        this.GroupBox1.Controls.Add(this.txtName);
        this.GroupBox1.Controls.Add(this.Label1);
        this.GroupBox1.Location = new System.Drawing.Point(8, 6);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(310, 103);
        this.GroupBox1.TabIndex = 0;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "General informations";
        // 
        // txtAccess
        // 
        this.txtAccess.BackColor = System.Drawing.SystemColors.Window;
        this.txtAccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtAccess.Location = new System.Drawing.Point(94, 79);
        this.txtAccess.Name = "txtAccess";
        this.txtAccess.ReadOnly = true;
        this.txtAccess.Size = new System.Drawing.Size(206, 15);
        this.txtAccess.TabIndex = 7;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(6, 79);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(88, 13);
        this.Label4.TabIndex = 6;
        this.Label4.Text = "GrantedAccess :";
        // 
        // txtAddress
        // 
        this.txtAddress.BackColor = System.Drawing.SystemColors.Window;
        this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtAddress.Location = new System.Drawing.Point(94, 58);
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.ReadOnly = true;
        this.txtAddress.Size = new System.Drawing.Size(206, 15);
        this.txtAddress.TabIndex = 5;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(6, 58);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(88, 13);
        this.Label3.TabIndex = 4;
        this.Label3.Text = "ObjectAddress :";
        // 
        // txtType
        // 
        this.txtType.BackColor = System.Drawing.SystemColors.Window;
        this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtType.Location = new System.Drawing.Point(42, 39);
        this.txtType.Name = "txtType";
        this.txtType.ReadOnly = true;
        this.txtType.Size = new System.Drawing.Size(258, 15);
        this.txtType.TabIndex = 3;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(6, 39);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(36, 13);
        this.Label2.TabIndex = 2;
        this.Label2.Text = "Type :";
        // 
        // txtName
        // 
        this.txtName.BackColor = System.Drawing.SystemColors.Window;
        this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.txtName.Location = new System.Drawing.Point(48, 18);
        this.txtName.Name = "txtName";
        this.txtName.ReadOnly = true;
        this.txtName.Size = new System.Drawing.Size(252, 15);
        this.txtName.TabIndex = 1;
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(6, 18);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(42, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Name :";
        // 
        // frmHandleInfo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(334, 377);
        this.Controls.Add(this.tabProcess);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "frmHandleInfo";
        this.ShowIcon = false;
        this.Text = "Handle informations";
        this.tabProcess.ResumeLayout(false);
        this.TabPage1.ResumeLayout(false);
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
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

    private System.Windows.Forms.GroupBox _gpCustomControl;

    internal System.Windows.Forms.GroupBox gpCustomControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _gpCustomControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_gpCustomControl != null)
            {
            }

            _gpCustomControl = value;
            if (_gpCustomControl != null)
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

    private System.Windows.Forms.TextBox _txtAddress;

    internal System.Windows.Forms.TextBox txtAddress
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtAddress;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtAddress != null)
            {
            }

            _txtAddress = value;
            if (_txtAddress != null)
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

    private System.Windows.Forms.TextBox _txtAccess;

    internal System.Windows.Forms.TextBox txtAccess
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtAccess;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtAccess != null)
            {
            }

            _txtAccess = value;
            if (_txtAccess != null)
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

    private System.Windows.Forms.Label _lblObjectCount;

    internal System.Windows.Forms.Label lblObjectCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblObjectCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblObjectCount != null)
            {
            }

            _lblObjectCount = value;
            if (_lblObjectCount != null)
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

    private System.Windows.Forms.Label _lblHandleCount;

    internal System.Windows.Forms.Label lblHandleCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblHandleCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblHandleCount != null)
            {
            }

            _lblHandleCount = value;
            if (_lblHandleCount != null)
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

    private System.Windows.Forms.Label _lblPointerCount;

    internal System.Windows.Forms.Label lblPointerCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPointerCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPointerCount != null)
            {
            }

            _lblPointerCount = value;
            if (_lblPointerCount != null)
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

    private System.Windows.Forms.Label _lblNonPaged;

    internal System.Windows.Forms.Label lblNonPaged
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNonPaged;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNonPaged != null)
            {
            }

            _lblNonPaged = value;
            if (_lblNonPaged != null)
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

    private System.Windows.Forms.Label _lblPaged;

    internal System.Windows.Forms.Label lblPaged
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPaged;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblPaged != null)
            {
            }

            _lblPaged = value;
            if (_lblPaged != null)
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
}

