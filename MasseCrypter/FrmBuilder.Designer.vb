<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuilder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuilder))
        Me.BrowseBtn = New System.Windows.Forms.Button()
        Me.FileText = New System.Windows.Forms.TextBox()
        Me.CryptBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BrowseBtn
        '
        Me.BrowseBtn.Location = New System.Drawing.Point(306, 10)
        Me.BrowseBtn.Name = "BrowseBtn"
        Me.BrowseBtn.Size = New System.Drawing.Size(43, 23)
        Me.BrowseBtn.TabIndex = 8
        Me.BrowseBtn.Text = "..."
        Me.BrowseBtn.UseVisualStyleBackColor = True
        '
        'FileText
        '
        Me.FileText.Location = New System.Drawing.Point(12, 12)
        Me.FileText.Name = "FileText"
        Me.FileText.ReadOnly = True
        Me.FileText.Size = New System.Drawing.Size(288, 20)
        Me.FileText.TabIndex = 7
        '
        'CryptBtn
        '
        Me.CryptBtn.Location = New System.Drawing.Point(355, 8)
        Me.CryptBtn.Name = "CryptBtn"
        Me.CryptBtn.Size = New System.Drawing.Size(100, 26)
        Me.CryptBtn.TabIndex = 6
        Me.CryptBtn.Text = "Encrypt File"
        Me.CryptBtn.UseVisualStyleBackColor = True
        '
        'FrmBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 46)
        Me.Controls.Add(Me.BrowseBtn)
        Me.Controls.Add(Me.FileText)
        Me.Controls.Add(Me.CryptBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBuilder"
        Me.Text = "Masse Crypter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BrowseBtn As System.Windows.Forms.Button
    Friend WithEvents FileText As System.Windows.Forms.TextBox
    Friend WithEvents CryptBtn As System.Windows.Forms.Button

End Class
