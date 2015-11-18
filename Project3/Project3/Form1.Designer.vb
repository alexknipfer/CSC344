<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cScore = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pScore = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.yellowValueInput = New System.Windows.Forms.TextBox()
        Me.greenValueInput = New System.Windows.Forms.TextBox()
        Me.redValueInput = New System.Windows.Forms.TextBox()
        Me.blueValueInput = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.imageRB = New System.Windows.Forms.RadioButton()
        Me.grayRB = New System.Windows.Forms.RadioButton()
        Me.oliveRB = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.sizeLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.newButton = New System.Windows.Forms.Button()
        Me.sizeSlider = New System.Windows.Forms.TrackBar()
        Me.mainPane = New System.Windows.Forms.FlowLayoutPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.sizeSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cScore)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pScore)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(651, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 86)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Score"
        '
        'cScore
        '
        Me.cScore.AutoSize = True
        Me.cScore.Location = New System.Drawing.Point(91, 48)
        Me.cScore.Name = "cScore"
        Me.cScore.Size = New System.Drawing.Size(13, 13)
        Me.cScore.TabIndex = 3
        Me.cScore.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Computer"
        '
        'pScore
        '
        Me.pScore.AutoSize = True
        Me.pScore.Location = New System.Drawing.Point(91, 26)
        Me.pScore.Name = "pScore"
        Me.pScore.Size = New System.Drawing.Size(13, 13)
        Me.pScore.TabIndex = 1
        Me.pScore.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Player"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.yellowValueInput)
        Me.GroupBox2.Controls.Add(Me.greenValueInput)
        Me.GroupBox2.Controls.Add(Me.redValueInput)
        Me.GroupBox2.Controls.Add(Me.blueValueInput)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(651, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 218)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pairs Available"
        '
        'yellowValueInput
        '
        Me.yellowValueInput.Location = New System.Drawing.Point(77, 166)
        Me.yellowValueInput.Name = "yellowValueInput"
        Me.yellowValueInput.Size = New System.Drawing.Size(25, 20)
        Me.yellowValueInput.TabIndex = 7
        Me.yellowValueInput.Text = "1"
        '
        'greenValueInput
        '
        Me.greenValueInput.Location = New System.Drawing.Point(77, 117)
        Me.greenValueInput.Name = "greenValueInput"
        Me.greenValueInput.Size = New System.Drawing.Size(25, 20)
        Me.greenValueInput.TabIndex = 6
        Me.greenValueInput.Text = "2"
        '
        'redValueInput
        '
        Me.redValueInput.Location = New System.Drawing.Point(77, 74)
        Me.redValueInput.Name = "redValueInput"
        Me.redValueInput.Size = New System.Drawing.Size(26, 20)
        Me.redValueInput.TabIndex = 5
        Me.redValueInput.Text = "2"
        '
        'blueValueInput
        '
        Me.blueValueInput.Location = New System.Drawing.Point(77, 27)
        Me.blueValueInput.Name = "blueValueInput"
        Me.blueValueInput.Size = New System.Drawing.Size(27, 20)
        Me.blueValueInput.TabIndex = 4
        Me.blueValueInput.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(12, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Yellow"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(12, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Green"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(12, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Red"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(12, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Blue"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.imageRB)
        Me.GroupBox3.Controls.Add(Me.grayRB)
        Me.GroupBox3.Controls.Add(Me.oliveRB)
        Me.GroupBox3.Location = New System.Drawing.Point(651, 329)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 216)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Card Back"
        '
        'imageRB
        '
        Me.imageRB.AutoSize = True
        Me.imageRB.Location = New System.Drawing.Point(15, 81)
        Me.imageRB.Name = "imageRB"
        Me.imageRB.Size = New System.Drawing.Size(54, 17)
        Me.imageRB.TabIndex = 2
        Me.imageRB.TabStop = True
        Me.imageRB.Text = "Image"
        Me.imageRB.UseVisualStyleBackColor = True
        '
        'grayRB
        '
        Me.grayRB.AutoSize = True
        Me.grayRB.BackColor = System.Drawing.Color.Gray
        Me.grayRB.Location = New System.Drawing.Point(15, 58)
        Me.grayRB.Name = "grayRB"
        Me.grayRB.Size = New System.Drawing.Size(47, 17)
        Me.grayRB.TabIndex = 1
        Me.grayRB.TabStop = True
        Me.grayRB.Text = "Gray"
        Me.grayRB.UseVisualStyleBackColor = False
        '
        'oliveRB
        '
        Me.oliveRB.AutoSize = True
        Me.oliveRB.BackColor = System.Drawing.Color.Olive
        Me.oliveRB.Location = New System.Drawing.Point(15, 35)
        Me.oliveRB.Name = "oliveRB"
        Me.oliveRB.Size = New System.Drawing.Size(49, 17)
        Me.oliveRB.TabIndex = 0
        Me.oliveRB.TabStop = True
        Me.oliveRB.Text = "Olive"
        Me.oliveRB.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.sizeLabel)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.newButton)
        Me.GroupBox4.Controls.Add(Me.sizeSlider)
        Me.GroupBox4.Location = New System.Drawing.Point(651, 551)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(180, 96)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Game Controls"
        '
        'sizeLabel
        '
        Me.sizeLabel.AutoSize = True
        Me.sizeLabel.Location = New System.Drawing.Point(39, 28)
        Me.sizeLabel.Name = "sizeLabel"
        Me.sizeLabel.Size = New System.Drawing.Size(13, 13)
        Me.sizeLabel.TabIndex = 4
        Me.sizeLabel.Text = "4"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Size"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(129, 66)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'newButton
        '
        Me.newButton.Location = New System.Drawing.Point(7, 67)
        Me.newButton.Name = "newButton"
        Me.newButton.Size = New System.Drawing.Size(44, 23)
        Me.newButton.TabIndex = 1
        Me.newButton.Text = "New"
        Me.newButton.UseVisualStyleBackColor = True
        '
        'sizeSlider
        '
        Me.sizeSlider.Location = New System.Drawing.Point(70, 19)
        Me.sizeSlider.Minimum = 4
        Me.sizeSlider.Name = "sizeSlider"
        Me.sizeSlider.Size = New System.Drawing.Size(104, 45)
        Me.sizeSlider.TabIndex = 0
        Me.sizeSlider.Value = 4
        '
        'mainPane
        '
        Me.mainPane.Location = New System.Drawing.Point(13, 13)
        Me.mainPane.Name = "mainPane"
        Me.mainPane.Size = New System.Drawing.Size(632, 627)
        Me.mainPane.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 659)
        Me.Controls.Add(Me.mainPane)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.sizeSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cScore As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pScore As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents yellowValueInput As TextBox
    Friend WithEvents greenValueInput As TextBox
    Friend WithEvents redValueInput As TextBox
    Friend WithEvents blueValueInput As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents imageRB As RadioButton
    Friend WithEvents grayRB As RadioButton
    Friend WithEvents oliveRB As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents sizeLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents newButton As Button
    Friend WithEvents sizeSlider As TrackBar
    Friend WithEvents mainPane As FlowLayoutPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
