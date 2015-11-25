Imports System.IO

Public Class Form1

    Private radioButtonSelected As String
    Private sizeChosen As Integer
    Private imageDirectory As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        sizeChoice.Items.Add("4")   'add 4 to dropdown choice
        sizeChoice.Items.Add("5")   'add 5 to dropdown choice
        sizeChoice.Items.Add("6")   'add 6 to dropdown choice
        sizeChoice.Items.Add("7")   'add 7 to dropdown choice
        sizeChoice.Items.Add("8")   'add 8 to dropdown choice
        sizeChoice.Items.Add("9")   'add 9 to dropdown choice
        sizeChoice.Items.Add("10")  'add 10 to dropdown choice

        radioButtonSelected = "Olive"   'set default card back color to olive
        sizeChoice.SelectedItem = "4"   'set default game size to 4
        imageDirectory = ""

    End Sub


    Private Sub createFile_Click(sender As Object, e As EventArgs) Handles createFile.Click

        Dim dialog As SaveFileDialog
        dialog = New SaveFileDialog     'create new save file dialog
        dialog.ShowDialog()             'show the user the dialog

        'create the file writer
        Dim fileWriter As StreamWriter
        fileWriter = New StreamWriter(dialog.FileName)

        'see which radio button was selected
        If (oliveRB.Checked) Then
            radioButtonSelected = "Olive"   'store string olive if olive was selected

        ElseIf (grayRB.Checked) Then
            radioButtonSelected = "Gray"    'store string gray if gray was selected

        End If

        sizeChosen = CInt(sizeChoice.SelectedItem.ToString) 'get the size selected from dropdown

        fileWriter.WriteLine(radioButtonSelected)   'print which card back color to file
        fileWriter.WriteLine(sizeChosen)            'print size board they want to file
        fileWriter.Close()

    End Sub

    Private Sub imageRB_CheckedChanged(sender As Object, e As EventArgs) Handles imageRB.CheckedChanged
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                radioButtonSelected = ofd.FileName.ToString
                displayImage.BackgroundImage = Bitmap.FromFile(ofd.FileName)
                displayImage.BackgroundImageLayout = ImageLayout.Stretch
            End If
        End If
    End Sub

End Class
