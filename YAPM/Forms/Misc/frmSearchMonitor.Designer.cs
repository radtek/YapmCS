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
partial class frmSearchMonitor : System.Windows.Forms.Form
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
        System.Windows.Forms.ListViewGroup ListViewGroup1 = new System.Windows.Forms.ListViewGroup("Category", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup ListViewGroup2 = new System.Windows.Forms.ListViewGroup("Counter", System.Windows.Forms.HorizontalAlignment.Left);
        this.Label1 = new System.Windows.Forms.Label();
        this.txtToSearch = new System.Windows.Forms.TextBox();
        this.chkCase = new System.Windows.Forms.CheckBox();
        this.cmdGo = new System.Windows.Forms.Button();
        this.LV = new System.Windows.Forms.ListView();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(77, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Text to search";
        // 
        // txtToSearch
        // 
        this.txtToSearch.Location = new System.Drawing.Point(93, 6);
        this.txtToSearch.Name = "txtToSearch";
        this.txtToSearch.Size = new System.Drawing.Size(131, 22);
        this.txtToSearch.TabIndex = 1;
        // 
        // chkCase
        // 
        this.chkCase.AutoSize = true;
        this.chkCase.Location = new System.Drawing.Point(230, 8);
        this.chkCase.Name = "chkCase";
        this.chkCase.Size = new System.Drawing.Size(97, 17);
        this.chkCase.TabIndex = 2;
        this.chkCase.Text = "Case sensitive";
        this.chkCase.UseVisualStyleBackColor = true;
        // 
        // cmdGo
        // 
        this.cmdGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.cmdGo.Image = global::My.Resources.Resources.magnifier;
        this.cmdGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdGo.Location = new System.Drawing.Point(330, 6);
        this.cmdGo.Name = "cmdGo";
        this.cmdGo.Size = new System.Drawing.Size(48, 23);
        this.cmdGo.TabIndex = 3;
        this.cmdGo.Text = "Go";
        this.cmdGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.cmdGo.UseVisualStyleBackColor = true;
        // 
        // LV
        // 
        this.LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1 });
        ListViewGroup1.Header = "Category";
        ListViewGroup1.Name = "groupCategory";
        ListViewGroup2.Header = "Counter";
        ListViewGroup2.Name = "groupCounter";
        this.LV.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { ListViewGroup1, ListViewGroup2 });
        this.LV.Location = new System.Drawing.Point(15, 32);
        this.LV.Name = "LV";
        this.LV.Size = new System.Drawing.Size(363, 165);
        this.LV.TabIndex = 4;
        this.LV.UseCompatibleStateImageBehavior = false;
        this.LV.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Name";
        this.ColumnHeader1.Width = 302;
        // 
        // frmSearchMonitor
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(398, 210);
        this.Controls.Add(this.LV);
        this.Controls.Add(this.cmdGo);
        this.Controls.Add(this.chkCase);
        this.Controls.Add(this.txtToSearch);
        this.Controls.Add(this.Label1);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmSearchMonitor";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Search a monitor item";
        this.ResumeLayout(false);
        this.PerformLayout();
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

    private System.Windows.Forms.TextBox _txtToSearch;

    internal System.Windows.Forms.TextBox txtToSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtToSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtToSearch != null)
            {
            }

            _txtToSearch = value;
            if (_txtToSearch != null)
            {
            }
        }
    }

    private System.Windows.Forms.CheckBox _chkCase;

    internal System.Windows.Forms.CheckBox chkCase
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCase;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_chkCase != null)
            {
            }

            _chkCase = value;
            if (_chkCase != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdGo;

    internal System.Windows.Forms.Button cmdGo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdGo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdGo != null)
            {
            }

            _cmdGo = value;
            if (_cmdGo != null)
            {
            }
        }
    }

    private System.Windows.Forms.ListView _LV;

    internal System.Windows.Forms.ListView LV
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _LV;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_LV != null)
            {
            }

            _LV = value;
            if (_LV != null)
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
}

