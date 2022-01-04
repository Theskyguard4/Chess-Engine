<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinningScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinningScreen))
        Me.ViewGameButt = New System.Windows.Forms.Button()
        Me.CloseGameButt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ViewGameButt
        '
        Me.ViewGameButt.Location = New System.Drawing.Point(12, 406)
        Me.ViewGameButt.Name = "ViewGameButt"
        Me.ViewGameButt.Size = New System.Drawing.Size(360, 97)
        Me.ViewGameButt.TabIndex = 0
        Me.ViewGameButt.Text = "View Game"
        Me.ViewGameButt.UseVisualStyleBackColor = True
        '
        'CloseGameButt
        '
        Me.CloseGameButt.Location = New System.Drawing.Point(554, 406)
        Me.CloseGameButt.Name = "CloseGameButt"
        Me.CloseGameButt.Size = New System.Drawing.Size(360, 97)
        Me.CloseGameButt.TabIndex = 1
        Me.CloseGameButt.Text = "Close Game"
        Me.CloseGameButt.UseVisualStyleBackColor = True
        '
        'WinningScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(926, 585)
        Me.ControlBox = False
        Me.Controls.Add(Me.CloseGameButt)
        Me.Controls.Add(Me.ViewGameButt)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "WinningScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Winner!"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ViewGameButt As System.Windows.Forms.Button
    Friend WithEvents CloseGameButt As System.Windows.Forms.Button
End Class
