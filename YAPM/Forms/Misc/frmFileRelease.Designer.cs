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
partial class frmFileRelease : System.Windows.Forms.Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileRelease));
        this.cmdCheck = new System.Windows.Forms.Button();
        this.lv = new searchList();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.IMG = new System.Windows.Forms.ImageList(this.components);
        this.cmdFix = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // cmdCheck
        // 
        this.cmdCheck.Location = new System.Drawing.Point(12, 12);
        this.cmdCheck.Name = "cmdCheck";
        this.cmdCheck.Size = new System.Drawing.Size(260, 22);
        this.cmdCheck.TabIndex = 0;
        this.cmdCheck.Text = "Check if file is locked by a process";
        this.cmdCheck.UseVisualStyleBackColor = true;
        // 
        // lv
        // 
        this.lv.CaseSensitive = false;
        this.lv.CatchErrors = false;
        this.lv.CheckBoxes = true;
        this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2 });
        CConnection1.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
        this.lv.ConnectionObj = CConnection1;
        this.lv.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lv.FullRowSelect = true;
        this.lv.GridLines = true;
        this.lv.Includes = Native.Api.Enums.GeneralObjectType.Process;
        this.lv.IsConnected = false;
        this.lv.Location = new System.Drawing.Point(12, 40);
        this.lv.Name = "lv";
        this.lv.OverriddenDoubleBuffered = false;
        this.lv.ReorganizeColumns = true;
        this.lv.SearchString = null;
        this.lv.Size = new System.Drawing.Size(260, 143);
        this.lv.SmallImageList = this.IMG;
        this.lv.TabIndex = 1;
        this.lv.UseCompatibleStateImageBehavior = false;
        this.lv.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Result";
        this.ColumnHeader2.Width = 220;
        // 
        // IMG
        // 
        this.IMG.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("IMG.ImageStream");
        this.IMG.TransparentColor = System.Drawing.Color.Transparent;
        this.IMG.Images.SetKeyName(0, "module");
        this.IMG.Images.SetKeyName(1, "handle");
        // 
        // cmdFix
        // 
        this.cmdFix.Location = new System.Drawing.Point(12, 189);
        this.cmdFix.Name = "cmdFix";
        this.cmdFix.Size = new System.Drawing.Size(260, 22);
        this.cmdFix.TabIndex = 2;
        this.cmdFix.Text = "Fix checked items";
        this.cmdFix.UseVisualStyleBackColor = true;
        // 
        // frmFileRelease
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 224);
        this.Controls.Add(this.cmdFix);
        this.Controls.Add(this.lv);
        this.Controls.Add(this.cmdCheck);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "frmFileRelease";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Release file";
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Button _cmdCheck;

    internal System.Windows.Forms.Button cmdCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdCheck != null)
            {
            }

            _cmdCheck = value;
            if (_cmdCheck != null)
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

    private System.Windows.Forms.Button _cmdFix;

    internal System.Windows.Forms.Button cmdFix
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdFix;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdFix != null)
            {
            }

            _cmdFix = value;
            if (_cmdFix != null)
            {
            }
        }
    }

    private System.Windows.Forms.ImageList _IMG;

    internal System.Windows.Forms.ImageList IMG
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _IMG;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_IMG != null)
            {
            }

            _IMG = value;
            if (_IMG != null)
            {
            }
        }
    }

    private searchList _lv;

    internal searchList lv
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
}

