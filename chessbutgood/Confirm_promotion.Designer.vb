<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Confirm_promotion
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
        Me.Confirm_promotion_but = New System.Windows.Forms.Button()
        Me.Cancel_promotion_button = New System.Windows.Forms.Button()
        Me.Piece_being_promoted = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Confirm_promotion_but
        '
        Me.Confirm_promotion_but.BackColor = System.Drawing.Color.Lime
        Me.Confirm_promotion_but.Location = New System.Drawing.Point(12, 38)
        Me.Confirm_promotion_but.Name = "Confirm_promotion_but"
        Me.Confirm_promotion_but.Size = New System.Drawing.Size(102, 205)
        Me.Confirm_promotion_but.TabIndex = 0
        Me.Confirm_promotion_but.Text = "Confirm"
        Me.Confirm_promotion_but.UseVisualStyleBackColor = False
        '
        'Cancel_promotion_button
        '
        Me.Cancel_promotion_button.BackColor = System.Drawing.Color.Red
        Me.Cancel_promotion_button.Location = New System.Drawing.Point(120, 38)
        Me.Cancel_promotion_button.Name = "Cancel_promotion_button"
        Me.Cancel_promotion_button.Size = New System.Drawing.Size(102, 205)
        Me.Cancel_promotion_button.TabIndex = 1
        Me.Cancel_promotion_button.Text = "Cancel"
        Me.Cancel_promotion_button.UseVisualStyleBackColor = False
        '
        'Piece_being_promoted
        '
        Me.Piece_being_promoted.AutoSize = True
        Me.Piece_being_promoted.Location = New System.Drawing.Point(77, 9)
        Me.Piece_being_promoted.Name = "Piece_being_promoted"
        Me.Piece_being_promoted.Size = New System.Drawing.Size(0, 17)
        Me.Piece_being_promoted.TabIndex = 2
        '
        'Confirm_promotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 253)
        Me.Controls.Add(Me.Piece_being_promoted)
        Me.Controls.Add(Me.Cancel_promotion_button)
        Me.Controls.Add(Me.Confirm_promotion_but)
        Me.Name = "Confirm_promotion"
        Me.Text = "Confirm_promotion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Confirm_promotion_but As System.Windows.Forms.Button
    Friend WithEvents Cancel_promotion_button As System.Windows.Forms.Button
    Friend WithEvents Piece_being_promoted As System.Windows.Forms.Label
End Class
