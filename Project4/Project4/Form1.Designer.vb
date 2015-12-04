<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.createFile = New System.Windows.Forms.Button()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cardTotalLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.totalPairsLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.yellowCount = New System.Windows.Forms.TextBox()
        Me.redCount = New System.Windows.Forms.TextBox()
        Me.greenCount = New System.Windows.Forms.TextBox()
        Me.blueCount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sizeChoice = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.displayImage = New System.Windows.Forms.PictureBox()
        Me.imageRB = New System.Windows.Forms.RadioButton()
        Me.grayRB = New System.Windows.Forms.RadioButton()
        Me.oliveRB = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.displayImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'createFile
        '
        Me.createFile.Location = New System.Drawing.Point(326, 232)
        Me.createFile.Name = "createFile"
        Me.createFile.Size = New System.Drawing.Size(75, 23)
        Me.createFile.TabIndex = 0
        Me.createFile.Text = "Create File"
        Me.createFile.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(407, 232)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(75, 23)
        Me.exitButton.TabIndex = 1
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cardTotalLabel)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.sizeChoice)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.exitButton)
        Me.Panel1.Controls.Add(Me.createFile)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 268)
        Me.Panel1.TabIndex = 3
        '
        'cardTotalLabel
        '
        Me.cardTotalLabel.AutoSize = True
        Me.cardTotalLabel.BackColor = System.Drawing.Color.MistyRose
        Me.cardTotalLabel.Location = New System.Drawing.Point(126, 247)
        Me.cardTotalLabel.Name = "cardTotalLabel"
        Me.cardTotalLabel.Size = New System.Drawing.Size(19, 13)
        Me.cardTotalLabel.TabIndex = 9
        Me.cardTotalLabel.Text = "12"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(151, 247)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "cards."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Your board consists of"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.totalPairsLabel)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.yellowCount)
        Me.GroupBox2.Controls.Add(Me.redCount)
        Me.GroupBox2.Controls.Add(Me.greenCount)
        Me.GroupBox2.Controls.Add(Me.blueCount)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(482, 66)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Set Up Pairs"
        '
        'totalPairsLabel
        '
        Me.totalPairsLabel.AutoSize = True
        Me.totalPairsLabel.BackColor = System.Drawing.Color.MistyRose
        Me.totalPairsLabel.Location = New System.Drawing.Point(455, 48)
        Me.totalPairsLabel.Name = "totalPairsLabel"
        Me.totalPairsLabel.Size = New System.Drawing.Size(13, 13)
        Me.totalPairsLabel.TabIndex = 8
        Me.totalPairsLabel.Text = "6"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(239, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Note: The number of pairs should add up to:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(375, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Yellow:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Green:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Red:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Blue:"
        '
        'yellowCount
        '
        Me.yellowCount.Location = New System.Drawing.Point(421, 22)
        Me.yellowCount.Name = "yellowCount"
        Me.yellowCount.Size = New System.Drawing.Size(27, 20)
        Me.yellowCount.TabIndex = 2
        Me.yellowCount.Text = "1"
        '
        'redCount
        '
        Me.redCount.Location = New System.Drawing.Point(187, 22)
        Me.redCount.Name = "redCount"
        Me.redCount.Size = New System.Drawing.Size(27, 20)
        Me.redCount.TabIndex = 0
        Me.redCount.Text = "2"
        '
        'greenCount
        '
        Me.greenCount.Location = New System.Drawing.Point(306, 22)
        Me.greenCount.Name = "greenCount"
        Me.greenCount.Size = New System.Drawing.Size(27, 20)
        Me.greenCount.TabIndex = 1
        Me.greenCount.Text = "2"
        '
        'blueCount
        '
        Me.blueCount.Location = New System.Drawing.Point(70, 22)
        Me.blueCount.Name = "blueCount"
        Me.blueCount.Size = New System.Drawing.Size(27, 20)
        Me.blueCount.TabIndex = 0
        Me.blueCount.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select what size board:"
        '
        'sizeChoice
        '
        Me.sizeChoice.FormattingEnabled = True
        Me.sizeChoice.Location = New System.Drawing.Point(133, 219)
        Me.sizeChoice.Name = "sizeChoice"
        Me.sizeChoice.Size = New System.Drawing.Size(121, 21)
        Me.sizeChoice.TabIndex = 4
        Me.sizeChoice.Text = "4"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.displayImage)
        Me.GroupBox1.Controls.Add(Me.imageRB)
        Me.GroupBox1.Controls.Add(Me.grayRB)
        Me.GroupBox1.Controls.Add(Me.oliveRB)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 57)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Card Back"
        '
        'displayImage
        '
        Me.displayImage.Location = New System.Drawing.Point(417, 10)
        Me.displayImage.Name = "displayImage"
        Me.displayImage.Size = New System.Drawing.Size(59, 41)
        Me.displayImage.TabIndex = 3
        Me.displayImage.TabStop = False
        '
        'imageRB
        '
        Me.imageRB.AutoSize = True
        Me.imageRB.Location = New System.Drawing.Point(340, 24)
        Me.imageRB.Name = "imageRB"
        Me.imageRB.Size = New System.Drawing.Size(54, 17)
        Me.imageRB.TabIndex = 2
        Me.imageRB.Text = "Image"
        Me.imageRB.UseVisualStyleBackColor = True
        '
        'grayRB
        '
        Me.grayRB.AutoSize = True
        Me.grayRB.Location = New System.Drawing.Point(180, 24)
        Me.grayRB.Name = "grayRB"
        Me.grayRB.Size = New System.Drawing.Size(47, 17)
        Me.grayRB.TabIndex = 1
        Me.grayRB.Text = "Gray"
        Me.grayRB.UseVisualStyleBackColor = True
        '
        'oliveRB
        '
        Me.oliveRB.AutoSize = True
        Me.oliveRB.Checked = True
        Me.oliveRB.Location = New System.Drawing.Point(20, 24)
        Me.oliveRB.Name = "oliveRB"
        Me.oliveRB.Size = New System.Drawing.Size(49, 17)
        Me.oliveRB.TabIndex = 0
        Me.oliveRB.TabStop = True
        Me.oliveRB.Text = "Olive"
        Me.oliveRB.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.header1
        Me.PictureBox1.Location = New System.Drawing.Point(0, -31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(497, 114)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 267)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.displayImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents createFile As Button
    Friend WithEvents exitButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents imageRB As RadioButton
    Friend WithEvents grayRB As RadioButton
    Friend WithEvents oliveRB As RadioButton
    Friend WithEvents displayImage As PictureBox
    Friend WithEvents sizeChoice As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents yellowCount As TextBox
    Friend WithEvents redCount As TextBox
    Friend WithEvents greenCount As TextBox
    Friend WithEvents blueCount As TextBox
    Friend WithEvents cardTotalLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents totalPairsLabel As Label
End Class
