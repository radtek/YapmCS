<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.lblIntro = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.SplitContainer,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer.Panel1.SuspendLayout
        Me.SplitContainer.Panel2.SuspendLayout
        Me.SplitContainer.SuspendLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.IsSplitterFixed = true
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.lblIntro)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer.Size = New System.Drawing.Size(619, 375)
        Me.SplitContainer.SplitterDistance = 41
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 2
        '
        'lblIntro
        '
        Me.lblIntro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIntro.Location = New System.Drawing.Point(0, 0)
        Me.lblIntro.Name = "lblIntro"
        Me.lblIntro.Size = New System.Drawing.Size(619, 41)
        Me.lblIntro.TabIndex = 0
        Me.lblIntro.Text = "Yet Another (remote) Process Monitor and some of its components are under license"& _ 
    "s. Terms and conditions are explicited below."
        Me.lblIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = true
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.rtb)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOK)
        Me.SplitContainer2.Size = New System.Drawing.Size(619, 333)
        Me.SplitContainer2.SplitterDistance = 282
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'rtb
        '
        Me.rtb.AutoWordSelection = true
        Me.rtb.BackColor = System.Drawing.Color.White
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Location = New System.Drawing.Point(0, 0)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = true
        Me.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtb.Size = New System.Drawing.Size(619, 282)
        Me.rtb.TabIndex = 2
        Me.rtb.Text = ""
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(273, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(73, 25)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = true
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 375)
        Me.ControlBox = false
        Me.Controls.Add(Me.SplitContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAbout"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About YAPM"
        Me.SplitContainer.Panel1.ResumeLayout(false)
        Me.SplitContainer.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents lblIntro As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
