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
partial class HFileProp : HXXXProp
{

    // UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        this.cmdOpen = new System.Windows.Forms.Button();
        this.cmdOpenDirectory = new System.Windows.Forms.Button();
        this.lblFileExists = new System.Windows.Forms.Label();
        this.cmdFileDetails = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // cmdOpen
        // 
        this.cmdOpen.Image = global::My.Resources.Resources.document_text;
        this.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdOpen.Location = new System.Drawing.Point(3, 3);
        this.cmdOpen.Name = "cmdOpen";
        this.cmdOpen.Size = new System.Drawing.Size(137, 25);
        this.cmdOpen.TabIndex = 0;
        this.cmdOpen.Text = "     Open file properties";
        this.cmdOpen.UseVisualStyleBackColor = true;
        // 
        // cmdOpenDirectory
        // 
        this.cmdOpenDirectory.Image = global::My.Resources.Resources.folder_open;
        this.cmdOpenDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdOpenDirectory.Location = new System.Drawing.Point(3, 34);
        this.cmdOpenDirectory.Name = "cmdOpenDirectory";
        this.cmdOpenDirectory.Size = new System.Drawing.Size(137, 25);
        this.cmdOpenDirectory.TabIndex = 1;
        this.cmdOpenDirectory.Text = "    Open directory";
        this.cmdOpenDirectory.UseVisualStyleBackColor = true;
        // 
        // lblFileExists
        // 
        this.lblFileExists.AutoSize = true;
        this.lblFileExists.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.lblFileExists.Location = new System.Drawing.Point(9, 65);
        this.lblFileExists.Name = "lblFileExists";
        this.lblFileExists.Size = new System.Drawing.Size(0, 13);
        this.lblFileExists.TabIndex = 3;
        // 
        // cmdFileDetails
        // 
        this.cmdFileDetails.Image = global::My.Resources.Resources.magnifier;
        this.cmdFileDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdFileDetails.Location = new System.Drawing.Point(146, 3);
        this.cmdFileDetails.Name = "cmdFileDetails";
        this.cmdFileDetails.Size = new System.Drawing.Size(106, 25);
        this.cmdFileDetails.TabIndex = 4;
        this.cmdFileDetails.Text = "     Show details";
        this.cmdFileDetails.UseVisualStyleBackColor = true;
        // 
        // HFileProp
        // 
        this.Controls.Add(this.cmdFileDetails);
        this.Controls.Add(this.lblFileExists);
        this.Controls.Add(this.cmdOpenDirectory);
        this.Controls.Add(this.cmdOpen);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "HFileProp";
        this.Size = new System.Drawing.Size(338, 196);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.Button _cmdOpen;

    internal System.Windows.Forms.Button cmdOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpen != null)
            {
            }

            _cmdOpen = value;
            if (_cmdOpen != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdOpenDirectory;

    internal System.Windows.Forms.Button cmdOpenDirectory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdOpenDirectory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdOpenDirectory != null)
            {
            }

            _cmdOpenDirectory = value;
            if (_cmdOpenDirectory != null)
            {
            }
        }
    }

    private System.Windows.Forms.Label _lblFileExists;

    internal System.Windows.Forms.Label lblFileExists
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblFileExists;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblFileExists != null)
            {
            }

            _lblFileExists = value;
            if (_lblFileExists != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdFileDetails;

    internal System.Windows.Forms.Button cmdFileDetails
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdFileDetails;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdFileDetails != null)
            {
            }

            _cmdFileDetails = value;
            if (_cmdFileDetails != null)
            {
            }
        }
    }
}

