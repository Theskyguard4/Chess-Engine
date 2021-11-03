<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Promotion
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
        Me.Promote_to_queen_but = New System.Windows.Forms.Button()
        Me.Promote_to_castle_but = New System.Windows.Forms.Button()
        Me.Promote_to_bishop_but = New System.Windows.Forms.Button()
        Me.Promote_to_horse_but = New System.Windows.Forms.Button()
        Me.Cancel_promotion = New System.Windows.Forms.Button()
        Me.Promotion_label = New System.Windows.Forms.Label()
        Me.Team_label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Promote_to_queen_but
        '
        Me.Promote_to_queen_but.Location = New System.Drawing.Point(12, 73)
        Me.Promote_to_queen_but.Name = "Promote_to_queen_but"
        Me.Promote_to_queen_but.Size = New System.Drawing.Size(176, 444)
        Me.Promote_to_queen_but.TabIndex = 0
        Me.Promote_to_queen_but.Text = "Queen (Q)"
        Me.Promote_to_queen_but.UseVisualStyleBackColor = True
        '
        'Promote_to_castle_but
        '
        Me.Promote_to_castle_but.Location = New System.Drawing.Point(194, 73)
        Me.Promote_to_castle_but.Name = "Promote_to_castle_but"
        Me.Promote_to_castle_but.Size = New System.Drawing.Size(176, 444)
        Me.Promote_to_castle_but.TabIndex = 1
        Me.Promote_to_castle_but.Text = "Castle (R)"
        Me.Promote_to_castle_but.UseVisualStyleBackColor = True
        '
        'Promote_to_bishop_but
        '
        Me.Promote_to_bishop_but.Location = New System.Drawing.Point(376, 73)
        Me.Promote_to_bishop_but.Name = "Promote_to_bishop_but"
        Me.Promote_to_bishop_but.Size = New System.Drawing.Size(176, 444)
        Me.Promote_to_bishop_but.TabIndex = 2
        Me.Promote_to_bishop_but.Text = "Bishop (B)"
        Me.Promote_to_bishop_but.UseVisualStyleBackColor = True
        '
        'Promote_to_horse_but
        '
        Me.Promote_to_horse_but.Location = New System.Drawing.Point(558, 73)
        Me.Promote_to_horse_but.Name = "Promote_to_horse_but"
        Me.Promote_to_horse_but.Size = New System.Drawing.Size(176, 444)
        Me.Promote_to_horse_but.TabIndex = 3
        Me.Promote_to_horse_but.Text = "Knight (H)"
        Me.Promote_to_horse_but.UseVisualStyleBackColor = True
        '
        'Cancel_promotion
        '
        Me.Cancel_promotion.BackColor = System.Drawing.Color.Red
        Me.Cancel_promotion.Location = New System.Drawing.Point(558, 12)
        Me.Cancel_promotion.Name = "Cancel_promotion"
        Me.Cancel_promotion.Size = New System.Drawing.Size(173, 55)
        Me.Cancel_promotion.TabIndex = 4
        Me.Cancel_promotion.Text = "Cancel Promotion"
        Me.Cancel_promotion.UseVisualStyleBackColor = False
        '
        'Promotion_label
        '
        Me.Promotion_label.AutoSize = True
        Me.Promotion_label.Font = New System.Drawing.Font("MingLiU_HKSCS-ExtB", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Promotion_label.Location = New System.Drawing.Point(12, 12)
        Me.Promotion_label.Name = "Promotion_label"
        Me.Promotion_label.Size = New System.Drawing.Size(237, 38)
        Me.Promotion_label.TabIndex = 5
        Me.Promotion_label.Text = "Promote To:"
        '
        'Team_label
        '
        Me.Team_label.AutoSize = True
        Me.Team_label.Location = New System.Drawing.Point(361, 28)
        Me.Team_label.Name = "Team_label"
        Me.Team_label.Size = New System.Drawing.Size(0, 17)
        Me.Team_label.TabIndex = 6
        '
        'Promotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 529)
        Me.Controls.Add(Me.Team_label)
        Me.Controls.Add(Me.Promotion_label)
        Me.Controls.Add(Me.Cancel_promotion)
        Me.Controls.Add(Me.Promote_to_horse_but)
        Me.Controls.Add(Me.Promote_to_bishop_but)
        Me.Controls.Add(Me.Promote_to_castle_but)
        Me.Controls.Add(Me.Promote_to_queen_but)
        Me.Name = "Promotion"
        Me.Text = "Promotion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Promote_to_queen_but As System.Windows.Forms.Button
    Friend WithEvents Promote_to_castle_but As System.Windows.Forms.Button
    Friend WithEvents Promote_to_bishop_but As System.Windows.Forms.Button
    Friend WithEvents Promote_to_horse_but As System.Windows.Forms.Button
    Friend WithEvents Cancel_promotion As System.Windows.Forms.Button
    Friend WithEvents Promotion_label As System.Windows.Forms.Label
    Friend WithEvents Team_label As System.Windows.Forms.Label
End Class
