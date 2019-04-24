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
partial class frmInput : System.Windows.Forms.Form
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
        this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.OK_Button = new System.Windows.Forms.Button();
        this.Cancel_Button = new System.Windows.Forms.Button();
        this.lblMessage = new System.Windows.Forms.Label();
        this.txtRes = new System.Windows.Forms.TextBox();
        this.TableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // TableLayoutPanel1
        // 
        this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.TableLayoutPanel1.ColumnCount = 2;
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
        this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
        this.TableLayoutPanel1.Location = new System.Drawing.Point(277, 72);
        this.TableLayoutPanel1.Name = "TableLayoutPanel1";
        this.TableLayoutPanel1.RowCount = 1;
        this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
        this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
        this.TableLayoutPanel1.TabIndex = 0;
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
        // lblMessage
        // 
        this.lblMessage.AutoSize = true;
        this.lblMessage.Location = new System.Drawing.Point(12, 9);
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Size = new System.Drawing.Size(98, 13);
        this.lblMessage.TabIndex = 1;
        this.lblMessage.Text = "Custom_text_here";
        // 
        // txtRes
        // 
        this.txtRes.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.txtRes.Location = new System.Drawing.Point(15, 37);
        this.txtRes.Name = "txtRes";
        this.txtRes.Size = new System.Drawing.Size(405, 22);
        this.txtRes.TabIndex = 2;
        this.txtRes.Text = "Default_text_here";
        // 
        // frmInput
        // 
        this.AcceptButton = this.OK_Button;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.Cancel_Button;
        this.ClientSize = new System.Drawing.Size(435, 113);
        this.Controls.Add(this.txtRes);
        this.Controls.Add(this.lblMessage);
        this.Controls.Add(this.TableLayoutPanel1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmInput";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Custom_title_here";
        this.TableLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.Label _lblMessage;

    internal System.Windows.Forms.Label lblMessage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMessage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMessage != null)
            {
            }

            _lblMessage = value;
            if (_lblMessage != null)
            {
            }
        }
    }

    private System.Windows.Forms.TextBox _txtRes;

    internal System.Windows.Forms.TextBox txtRes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtRes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtRes != null)
            {
            }

            _txtRes = value;
            if (_txtRes != null)
            {
            }
        }
    }
}

