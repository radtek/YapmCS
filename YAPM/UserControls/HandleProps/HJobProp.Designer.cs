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
using System.Runtime.CompilerServices;

[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
partial class HJobProp : HXXXProp
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
        this.SuspendLayout();
        // 
        // cmdOpen
        // 
        this.cmdOpen.Image = global::My.Resources.Resources.application_blue16;
        this.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.cmdOpen.Location = new System.Drawing.Point(3, 3);
        this.cmdOpen.Name = "cmdOpen";
        this.cmdOpen.Size = new System.Drawing.Size(128, 25);
        this.cmdOpen.TabIndex = 0;
        this.cmdOpen.Text = "      Show job details";
        this.cmdOpen.UseVisualStyleBackColor = true;
        // 
        // HJobProp
        // 
        this.Controls.Add(this.cmdOpen);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.Name = "HJobProp";
        this.Size = new System.Drawing.Size(338, 196);
        this.ResumeLayout(false);
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
}

