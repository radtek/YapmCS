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
partial class frmChooseColumns : System.Windows.Forms.Form
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
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdSelAll = new System.Windows.Forms.Button();
        this.btnUnSelAll = new System.Windows.Forms.Button();
        this.cmdInvert = new System.Windows.Forms.Button();
        this.cmdMoveUp = new System.Windows.Forms.Button();
        this.cmdMoveDown = new System.Windows.Forms.Button();
        this.cmdDefault = new System.Windows.Forms.Button();
        this.lv = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
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
        this.TableLayoutPanel1.Location = new System.Drawing.Point(178, 310);
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
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 6);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(212, 26);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Select the columns you want to display" + (char)13 + (char)10 + "Right click to change the text alignment";
        // 
        // cmdSelAll
        // 
        this.cmdSelAll.Location = new System.Drawing.Point(8, 227);
        this.cmdSelAll.Name = "cmdSelAll";
        this.cmdSelAll.Size = new System.Drawing.Size(99, 23);
        this.cmdSelAll.TabIndex = 4;
        this.cmdSelAll.Text = "Select all";
        this.cmdSelAll.UseVisualStyleBackColor = true;
        // 
        // btnUnSelAll
        // 
        this.btnUnSelAll.Location = new System.Drawing.Point(8, 256);
        this.btnUnSelAll.Name = "btnUnSelAll";
        this.btnUnSelAll.Size = new System.Drawing.Size(99, 23);
        this.btnUnSelAll.TabIndex = 5;
        this.btnUnSelAll.Text = "Unselect all";
        this.btnUnSelAll.UseVisualStyleBackColor = true;
        // 
        // cmdInvert
        // 
        this.cmdInvert.Location = new System.Drawing.Point(8, 285);
        this.cmdInvert.Name = "cmdInvert";
        this.cmdInvert.Size = new System.Drawing.Size(99, 23);
        this.cmdInvert.TabIndex = 7;
        this.cmdInvert.Text = "Invert selection";
        this.cmdInvert.UseVisualStyleBackColor = true;
        // 
        // cmdMoveUp
        // 
        this.cmdMoveUp.Image = global::My.Resources.Resources.up16;
        this.cmdMoveUp.Location = new System.Drawing.Point(264, 227);
        this.cmdMoveUp.Name = "cmdMoveUp";
        this.cmdMoveUp.Size = new System.Drawing.Size(28, 28);
        this.cmdMoveUp.TabIndex = 8;
        this.cmdMoveUp.UseVisualStyleBackColor = true;
        // 
        // cmdMoveDown
        // 
        this.cmdMoveDown.Image = global::My.Resources.Resources.down16;
        this.cmdMoveDown.Location = new System.Drawing.Point(293, 227);
        this.cmdMoveDown.Name = "cmdMoveDown";
        this.cmdMoveDown.Size = new System.Drawing.Size(28, 28);
        this.cmdMoveDown.TabIndex = 9;
        this.cmdMoveDown.UseVisualStyleBackColor = true;
        // 
        // cmdDefault
        // 
        this.cmdDefault.Location = new System.Drawing.Point(8, 314);
        this.cmdDefault.Name = "cmdDefault";
        this.cmdDefault.Size = new System.Drawing.Size(99, 23);
        this.cmdDefault.TabIndex = 10;
        this.cmdDefault.Text = "Default";
        this.cmdDefault.UseVisualStyleBackColor = true;
        // 
        // lv
        // 
        this.lv.CheckBoxes = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3 });
        this.lv.FullRowSelect = true;
        this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.lv.Location = new System.Drawing.Point(12, 38);
        this.lv.MultiSelect = false;
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = false;
        this.lv.Size = new System.Drawing.Size(309, 183);
        this.lv.TabIndex = 6;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Width = 230;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Width";
        this.ColumnHeader2.Width = 0;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Alignment";
        this.ColumnHeader3.Width = 50;
        // 
        // frmChooseColumns
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(336, 351);
        this.Controls.Add(this.cmdDefault);
        this.Controls.Add(this.cmdMoveDown);
        this.Controls.Add(this.cmdMoveUp);
        this.Controls.Add(this.cmdInvert);
        this.Controls.Add(this.lv);
        this.Controls.Add(this.btnUnSelAll);
        this.Controls.Add(this.cmdSelAll);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.TableLayoutPanel1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmChooseColumns";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Select columns";
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

    private System.Windows.Forms.Button _cmdSelAll;

    internal System.Windows.Forms.Button cmdSelAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSelAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSelAll != null)
            {
            }

            _cmdSelAll = value;
            if (_cmdSelAll != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _btnUnSelAll;

    internal System.Windows.Forms.Button btnUnSelAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnUnSelAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnUnSelAll != null)
            {
            }

            _btnUnSelAll = value;
            if (_btnUnSelAll != null)
            {
            }
        }
    }

    private System.Windows.Forms.ColumnHeader _ColumnHeader1;

    internal System.Windows.Forms.ColumnHeader ColumnHeader1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ColumnHeader1 != null)
            {
            }

            _ColumnHeader1 = value;
            if (_ColumnHeader1 != null)
            {
            }
        }
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

    private System.Windows.Forms.Button _cmdInvert;

    internal System.Windows.Forms.Button cmdInvert
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdInvert;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdInvert != null)
            {
            }

            _cmdInvert = value;
            if (_cmdInvert != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdMoveUp;

    internal System.Windows.Forms.Button cmdMoveUp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdMoveUp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdMoveUp != null)
            {
            }

            _cmdMoveUp = value;
            if (_cmdMoveUp != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdMoveDown;

    internal System.Windows.Forms.Button cmdMoveDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdMoveDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdMoveDown != null)
            {
            }

            _cmdMoveDown = value;
            if (_cmdMoveDown != null)
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
}

