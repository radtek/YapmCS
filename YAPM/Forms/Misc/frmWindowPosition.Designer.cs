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
partial class frmWindowPosition : System.Windows.Forms.Form
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
        this.Panel1 = new System.Windows.Forms.Panel();
        this.txtWidth = new System.Windows.Forms.TextBox();
        this.Label4 = new System.Windows.Forms.Label();
        this.txtHeight = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.txtTop = new System.Windows.Forms.TextBox();
        this.txtLeft = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.cmdOK = new System.Windows.Forms.Button();
        this.cmdDefault = new System.Windows.Forms.Button();
        this.cmdCenter = new System.Windows.Forms.Button();
        this.Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        this.Panel1.BackColor = System.Drawing.Color.White;
        this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Panel1.Controls.Add(this.txtWidth);
        this.Panel1.Controls.Add(this.Label4);
        this.Panel1.Controls.Add(this.txtHeight);
        this.Panel1.Controls.Add(this.Label3);
        this.Panel1.ForeColor = System.Drawing.Color.Black;
        this.Panel1.Location = new System.Drawing.Point(74, 33);
        this.Panel1.Name = "Panel1";
        this.Panel1.Size = new System.Drawing.Size(130, 87);
        this.Panel1.TabIndex = 0;
        // 
        // txtWidth
        // 
        this.txtWidth.Location = new System.Drawing.Point(53, 47);
        this.txtWidth.Name = "txtWidth";
        this.txtWidth.Size = new System.Drawing.Size(62, 22);
        this.txtWidth.TabIndex = 3;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(12, 50);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(39, 13);
        this.Label4.TabIndex = 5;
        this.Label4.Text = "Width";
        // 
        // txtHeight
        // 
        this.txtHeight.Location = new System.Drawing.Point(53, 15);
        this.txtHeight.Name = "txtHeight";
        this.txtHeight.Size = new System.Drawing.Size(62, 22);
        this.txtHeight.TabIndex = 2;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(9, 18);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(42, 13);
        this.Label3.TabIndex = 3;
        this.Label3.Text = "Height";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(90, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(26, 13);
        this.Label1.TabIndex = 1;
        this.Label1.Text = "Top";
        // 
        // txtTop
        // 
        this.txtTop.Location = new System.Drawing.Point(121, 6);
        this.txtTop.Name = "txtTop";
        this.txtTop.Size = new System.Drawing.Size(62, 22);
        this.txtTop.TabIndex = 0;
        // 
        // txtLeft
        // 
        this.txtLeft.Location = new System.Drawing.Point(6, 74);
        this.txtLeft.Name = "txtLeft";
        this.txtLeft.Size = new System.Drawing.Size(62, 22);
        this.txtLeft.TabIndex = 1;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(22, 58);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(26, 13);
        this.Label2.TabIndex = 3;
        this.Label2.Text = "Left";
        // 
        // cmdOK
        // 
        this.cmdOK.Location = new System.Drawing.Point(21, 135);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(68, 27);
        this.cmdOK.TabIndex = 4;
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        // 
        // cmdDefault
        // 
        this.cmdDefault.Location = new System.Drawing.Point(112, 135);
        this.cmdDefault.Name = "cmdDefault";
        this.cmdDefault.Size = new System.Drawing.Size(88, 27);
        this.cmdDefault.TabIndex = 5;
        this.cmdDefault.Text = "Default";
        this.cmdDefault.UseVisualStyleBackColor = true;
        // 
        // cmdCenter
        // 
        this.cmdCenter.Location = new System.Drawing.Point(6, 9);
        this.cmdCenter.Name = "cmdCenter";
        this.cmdCenter.Size = new System.Drawing.Size(51, 28);
        this.cmdCenter.TabIndex = 6;
        this.cmdCenter.Text = "Center";
        this.cmdCenter.UseVisualStyleBackColor = true;
        // 
        // frmWindowPosition
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(220, 176);
        this.Controls.Add(this.cmdCenter);
        this.Controls.Add(this.cmdDefault);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.txtLeft);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.txtTop);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.Panel1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmWindowPosition";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Window position";
        this.Panel1.ResumeLayout(false);
        this.Panel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.Panel _Panel1;

    internal System.Windows.Forms.Panel Panel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Panel1 != null)
            {
            }

            _Panel1 = value;
            if (_Panel1 != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtWidth;

    internal System.Windows.Forms.TextBox txtWidth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtWidth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtWidth != null)
            {
            }

            _txtWidth = value;
            if (_txtWidth != null)
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

    private System.Windows.Forms.TextBox _txtHeight;

    internal System.Windows.Forms.TextBox txtHeight
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtHeight;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtHeight != null)
            {
            }

            _txtHeight = value;
            if (_txtHeight != null)
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

    private System.Windows.Forms.TextBox _txtTop;

    internal System.Windows.Forms.TextBox txtTop
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtTop;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtTop != null)
            {
            }

            _txtTop = value;
            if (_txtTop != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtLeft;

    internal System.Windows.Forms.TextBox txtLeft
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtLeft;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtLeft != null)
            {
            }

            _txtLeft = value;
            if (_txtLeft != null)
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

    private System.Windows.Forms.Button _cmdDefault;

    internal System.Windows.Forms.Button cmdDefault
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdDefault;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdDefault != null)
            {
            }

            _cmdDefault = value;
            if (_cmdDefault != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdCenter;

    internal System.Windows.Forms.Button cmdCenter
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCenter;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCenter != null)
            {
            }

            _cmdCenter = value;
            if (_cmdCenter != null)
            {
            }
        }
    }
}

