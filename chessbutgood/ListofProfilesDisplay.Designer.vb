<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListofProfilesDisplay
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
        Me.ListOfUsers = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.ListOfUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListOfUsers
        '
        Me.ListOfUsers.AllowUserToAddRows = False
        Me.ListOfUsers.AllowUserToDeleteRows = False
        Me.ListOfUsers.AllowUserToResizeColumns = False
        Me.ListOfUsers.AllowUserToResizeRows = False
        Me.ListOfUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListOfUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.ListOfUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListOfUsers.Location = New System.Drawing.Point(22, 24)
        Me.ListOfUsers.Name = "ListOfUsers"
        Me.ListOfUsers.ReadOnly = True
        Me.ListOfUsers.RowTemplate.Height = 24
        Me.ListOfUsers.Size = New System.Drawing.Size(512, 483)
        Me.ListOfUsers.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(542, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 49)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListofProfilesDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListOfUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ListofProfilesDisplay"
        Me.Text = "ListofProfilesDisplay"
        CType(Me.ListOfUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListOfUsers As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
