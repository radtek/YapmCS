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
partial class frmAddProcessMonitor : System.Windows.Forms.Form
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
        this.butAdd = new System.Windows.Forms.Button();
        this.Label2 = new System.Windows.Forms.Label();
        this.txtInterval = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.cmdAddToList = new System.Windows.Forms.Button();
        this.cmdRemoveFromList = new System.Windows.Forms.Button();
        this.txtHelp = new System.Windows.Forms.TextBox();
        this.cmdSearch = new System.Windows.Forms.Button();
        this.lstCategory = new DoubleBufferedLV();
        this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
        this.lstInstance = new DoubleBufferedLV();
        this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.lstCounterType = new DoubleBufferedLV();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.lstToAdd = new DoubleBufferedLV();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // butAdd
        // 
        this.butAdd.Enabled = false;
        this.butAdd.Location = new System.Drawing.Point(834, 203);
        this.butAdd.Name = "butAdd";
        this.butAdd.Size = new System.Drawing.Size(271, 24);
        this.butAdd.TabIndex = 7;
        this.butAdd.Text = "Monitor counters";
        this.butAdd.UseVisualStyleBackColor = true;
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(831, 176);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(87, 13);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Refresh interval";
        // 
        // txtInterval
        // 
        this.txtInterval.Location = new System.Drawing.Point(921, 176);
        this.txtInterval.Name = "txtInterval";
        this.txtInterval.Size = new System.Drawing.Size(122, 22);
        this.txtInterval.TabIndex = 6;
        this.txtInterval.Text = "1000";
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(6, 8);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(53, 13);
        this.Label3.TabIndex = 7;
        this.Label3.Text = "Category";
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(472, 7);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(74, 13);
        this.Label4.TabIndex = 9;
        this.Label4.Text = "Counter type";
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(262, 8);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(108, 13);
        this.Label5.TabIndex = 11;
        this.Label5.Text = "Instance to monitor";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(830, 7);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(112, 13);
        this.Label1.TabIndex = 13;
        this.Label1.Text = "Counters to monitor";
        // 
        // cmdAddToList
        // 
        this.cmdAddToList.Location = new System.Drawing.Point(768, 114);
        this.cmdAddToList.Name = "cmdAddToList";
        this.cmdAddToList.Size = new System.Drawing.Size(41, 23);
        this.cmdAddToList.TabIndex = 4;
        this.cmdAddToList.Text = ">>";
        this.cmdAddToList.UseVisualStyleBackColor = true;
        // 
        // cmdRemoveFromList
        // 
        this.cmdRemoveFromList.Location = new System.Drawing.Point(768, 143);
        this.cmdRemoveFromList.Name = "cmdRemoveFromList";
        this.cmdRemoveFromList.Size = new System.Drawing.Size(41, 23);
        this.cmdRemoveFromList.TabIndex = 8;
        this.cmdRemoveFromList.Text = "<<";
        this.cmdRemoveFromList.UseVisualStyleBackColor = true;
        // 
        // txtHelp
        // 
        this.txtHelp.BackColor = System.Drawing.Color.White;
        this.txtHelp.Location = new System.Drawing.Point(9, 177);
        this.txtHelp.Multiline = true;
        this.txtHelp.Name = "txtHelp";
        this.txtHelp.ReadOnly = true;
        this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtHelp.Size = new System.Drawing.Size(738, 50);
        this.txtHelp.TabIndex = 9;
        this.txtHelp.Text = "Description of selected item";
        // 
        // cmdSearch
        // 
        this.cmdSearch.Image = global::My.Resources.Resources.magnify32;
        this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
        this.cmdSearch.Location = new System.Drawing.Point(753, 23);
        this.cmdSearch.Name = "cmdSearch";
        this.cmdSearch.Size = new System.Drawing.Size(74, 76);
        this.cmdSearch.TabIndex = 14;
        this.cmdSearch.Text = "Search counter";
        this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        this.cmdSearch.UseVisualStyleBackColor = true;
        // 
        // lstCategory
        // 
        this.lstCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader4 });
        this.lstCategory.FullRowSelect = true;
        this.lstCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.lstCategory.Location = new System.Drawing.Point(9, 24);
        this.lstCategory.MultiSelect = false;
        this.lstCategory.Name = "lstCategory";
        this.lstCategory.OverriddenDoubleBuffered = false;
        this.lstCategory.ShowGroups = false;
        this.lstCategory.ShowItemToolTips = true;
        this.lstCategory.Size = new System.Drawing.Size(250, 147);
        this.lstCategory.Sorting = System.Windows.Forms.SortOrder.Ascending;
        this.lstCategory.TabIndex = 1;
        this.lstCategory.UseCompatibleStateImageBehavior = false;
        this.lstCategory.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader4
        // 
        this.ColumnHeader4.Text = "Counter item";
        this.ColumnHeader4.Width = 1000;
        // 
        // lstInstance
        // 
        this.lstInstance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader3 });
        this.lstInstance.FullRowSelect = true;
        this.lstInstance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.lstInstance.Location = new System.Drawing.Point(265, 24);
        this.lstInstance.MultiSelect = false;
        this.lstInstance.Name = "lstInstance";
        this.lstInstance.OverriddenDoubleBuffered = false;
        this.lstInstance.ShowGroups = false;
        this.lstInstance.ShowItemToolTips = true;
        this.lstInstance.Size = new System.Drawing.Size(204, 147);
        this.lstInstance.TabIndex = 2;
        this.lstInstance.UseCompatibleStateImageBehavior = false;
        this.lstInstance.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader3
        // 
        this.ColumnHeader3.Text = "Counter item";
        this.ColumnHeader3.Width = 1000;
        // 
        // lstCounterType
        // 
        this.lstCounterType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader2 });
        this.lstCounterType.FullRowSelect = true;
        this.lstCounterType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.lstCounterType.Location = new System.Drawing.Point(475, 24);
        this.lstCounterType.Name = "lstCounterType";
        this.lstCounterType.OverriddenDoubleBuffered = false;
        this.lstCounterType.ShowGroups = false;
        this.lstCounterType.ShowItemToolTips = true;
        this.lstCounterType.Size = new System.Drawing.Size(272, 147);
        this.lstCounterType.Sorting = System.Windows.Forms.SortOrder.Ascending;
        this.lstCounterType.TabIndex = 3;
        this.lstCounterType.UseCompatibleStateImageBehavior = false;
        this.lstCounterType.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Counter item";
        this.ColumnHeader2.Width = 1000;
        // 
        // lstToAdd
        // 
        this.lstToAdd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1 });
        this.lstToAdd.FullRowSelect = true;
        this.lstToAdd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.lstToAdd.Location = new System.Drawing.Point(833, 23);
        this.lstToAdd.Name = "lstToAdd";
        this.lstToAdd.OverriddenDoubleBuffered = false;
        this.lstToAdd.ShowGroups = false;
        this.lstToAdd.ShowItemToolTips = true;
        this.lstToAdd.Size = new System.Drawing.Size(272, 147);
        this.lstToAdd.TabIndex = 5;
        this.lstToAdd.UseCompatibleStateImageBehavior = false;
        this.lstToAdd.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Counter item";
        this.ColumnHeader1.Width = 1000;
        // 
        // frmAddProcessMonitor
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1111, 235);
        this.Controls.Add(this.cmdSearch);
        this.Controls.Add(this.lstCategory);
        this.Controls.Add(this.lstInstance);
        this.Controls.Add(this.lstCounterType);
        this.Controls.Add(this.txtHelp);
        this.Controls.Add(this.lstToAdd);
        this.Controls.Add(this.cmdRemoveFromList);
        this.Controls.Add(this.cmdAddToList);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.Label5);
        this.Controls.Add(this.Label4);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.txtInterval);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.butAdd);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAddProcessMonitor";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add monitoring";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.Button _butAdd;

    internal System.Windows.Forms.Button butAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _butAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_butAdd != null)
            {
            }

            _butAdd = value;
            if (_butAdd != null)
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

    private System.Windows.Forms.TextBox _txtInterval;

    internal System.Windows.Forms.TextBox txtInterval
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtInterval;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtInterval != null)
            {
            }

            _txtInterval = value;
            if (_txtInterval != null)
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

    private System.Windows.Forms.Button _cmdAddToList;

    internal System.Windows.Forms.Button cmdAddToList
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdAddToList;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdAddToList != null)
            {
            }

            _cmdAddToList = value;
            if (_cmdAddToList != null)
            {
            }
        }
    }

    private System.Windows.Forms.Button _cmdRemoveFromList;

    internal System.Windows.Forms.Button cmdRemoveFromList
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdRemoveFromList;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdRemoveFromList != null)
            {
            }

            _cmdRemoveFromList = value;
            if (_cmdRemoveFromList != null)
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

    private System.Windows.Forms.TextBox _txtHelp;

    internal System.Windows.Forms.TextBox txtHelp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtHelp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_txtHelp != null)
            {
            }

            _txtHelp = value;
            if (_txtHelp != null)
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

    private System.Windows.Forms.Button _cmdSearch;

    internal System.Windows.Forms.Button cmdSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdSearch != null)
            {
            }

            _cmdSearch = value;
            if (_cmdSearch != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lstToAdd;

    internal DoubleBufferedLV lstToAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstToAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstToAdd != null)
            {
            }

            _lstToAdd = value;
            if (_lstToAdd != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lstCounterType;

    internal DoubleBufferedLV lstCounterType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstCounterType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstCounterType != null)
            {
            }

            _lstCounterType = value;
            if (_lstCounterType != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lstInstance;

    internal DoubleBufferedLV lstInstance
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstInstance;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstInstance != null)
            {
            }

            _lstInstance = value;
            if (_lstInstance != null)
            {
            }
        }
    }

    private DoubleBufferedLV _lstCategory;

    internal DoubleBufferedLV lstCategory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstCategory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstCategory != null)
            {
            }

            _lstCategory = value;
            if (_lstCategory != null)
            {
            }
        }
    }
}

