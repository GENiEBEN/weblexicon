<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DemoLexicon
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DemoLexicon))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.LstView = New System.Windows.Forms.ListView
        Me.Col1 = New System.Windows.Forms.ColumnHeader
        Me.Col2 = New System.Windows.Forms.ColumnHeader
        Me.Col3 = New System.Windows.Forms.ColumnHeader
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Text1)
        Me.SplitContainer1.Size = New System.Drawing.Size(870, 588)
        Me.SplitContainer1.SplitterDistance = 357
        Me.SplitContainer1.TabIndex = 6
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LstView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Button3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer2.Size = New System.Drawing.Size(357, 588)
        Me.SplitContainer2.SplitterDistance = 537
        Me.SplitContainer2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(264, 14)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "There are no IDs to process"
        '
        'LstView
        '
        Me.LstView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstView.BackColor = System.Drawing.SystemColors.Window
        Me.LstView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col1, Me.Col2, Me.Col3})
        Me.LstView.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LstView.FullRowSelect = True
        Me.LstView.LabelEdit = True
        Me.LstView.Location = New System.Drawing.Point(3, 21)
        Me.LstView.Name = "LstView"
        Me.LstView.Size = New System.Drawing.Size(351, 513)
        Me.LstView.TabIndex = 7
        Me.LstView.UseCompatibleStateImageBehavior = False
        Me.LstView.View = System.Windows.Forms.View.Details
        '
        'Col1
        '
        Me.Col1.Text = "Token"
        Me.Col1.Width = 150
        '
        'Col2
        '
        Me.Col2.Text = "Desc"
        Me.Col2.Width = 150
        '
        'Col3
        '
        Me.Col3.Text = "ID"
        Me.Col3.Width = 30
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(212, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 33)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "BENCH!"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(109, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 33)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Visible Scan"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 33)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Invisible Scan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(3, 0)
        Me.Text1.MaxLength = 0
        Me.Text1.Multiline = True
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Text1.Size = New System.Drawing.Size(503, 588)
        Me.Text1.TabIndex = 8
        Me.Text1.Text = resources.GetString("Text1.Text")
        '
        'DemoLexicon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(867, 590)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "DemoLexicon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Web LEXICON"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LstView As System.Windows.Forms.ListView
    Friend WithEvents Col1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
#End Region
End Class