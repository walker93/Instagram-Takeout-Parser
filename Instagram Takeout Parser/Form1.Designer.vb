<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_Browse_input = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OutputPath_txt = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.input_path_lbl = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.percent_lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.status_lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Browse_input
        '
        Me.btn_Browse_input.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Browse_input.Location = New System.Drawing.Point(326, 22)
        Me.btn_Browse_input.Name = "btn_Browse_input"
        Me.btn_Browse_input.Size = New System.Drawing.Size(96, 23)
        Me.btn_Browse_input.TabIndex = 0
        Me.btn_Browse_input.Text = "&Sfoglia"
        Me.btn_Browse_input.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Percorso Takeout"
        '
        'OutputPath_txt
        '
        Me.OutputPath_txt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputPath_txt.Location = New System.Drawing.Point(15, 73)
        Me.OutputPath_txt.Name = "OutputPath_txt"
        Me.OutputPath_txt.Size = New System.Drawing.Size(305, 20)
        Me.OutputPath_txt.TabIndex = 2
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(326, 71)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "S&foglia"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(326, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "&Genera Report"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Percorso Report"
        '
        'input_path_lbl
        '
        Me.input_path_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.input_path_lbl.Location = New System.Drawing.Point(12, 27)
        Me.input_path_lbl.Name = "input_path_lbl"
        Me.input_path_lbl.Size = New System.Drawing.Size(308, 13)
        Me.input_path_lbl.TabIndex = 1
        Me.input_path_lbl.Text = "C:\"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.percent_lbl, Me.status_lbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 156)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(434, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'progressBar
        '
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 16)
        Me.progressBar.Step = 1
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressBar.Visible = False
        '
        'percent_lbl
        '
        Me.percent_lbl.Name = "percent_lbl"
        Me.percent_lbl.Size = New System.Drawing.Size(23, 17)
        Me.percent_lbl.Text = "0%"
        Me.percent_lbl.Visible = False
        '
        'status_lbl
        '
        Me.status_lbl.Name = "status_lbl"
        Me.status_lbl.Size = New System.Drawing.Size(43, 17)
        Me.status_lbl.Text = "Pronto"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 178)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.OutputPath_txt)
        Me.Controls.Add(Me.input_path_lbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Browse_input)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Instagram Takeout"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Browse_input As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents OutputPath_txt As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents input_path_lbl As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents progressBar As ToolStripProgressBar
    Friend WithEvents percent_lbl As ToolStripStatusLabel
    Friend WithEvents status_lbl As ToolStripStatusLabel
End Class
