Imports System.IO

Public Class Form1

    Private radioButtonSelected As String
    Private sizeChosen As Integer
    Private imageDirectory As String
    Private myCards(90) As String

    Private blueVal As Integer
    Private redVal As Integer
    Private yellowVal As Integer
    Private greenVal As Integer

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
        Dim totalPairs As Integer   'total pais user entered
        Dim totalSize As Integer    'total amount of cards

        Dim dialog As SaveFileDialog

        blueVal = CInt(blueCount.Text)      'get blue pairs entered
        redVal = CInt(redCount.Text)        'get red pairs entered
        greenVal = CInt(greenCount.Text)    'get green pairs entered
        yellowVal = CInt(yellowCount.Text)  'get yellow pairs entered

        totalPairs = blueVal + redVal + greenVal + yellowVal    'get total pairs entered

        sizeChosen = CInt(sizeChoice.SelectedItem.ToString) 'get the size selected from dropdown

        totalSize = sizeChosen * (sizeChosen - 1)   'total possible cards

        'see which radio button was selected
        If (oliveRB.Checked) Then
            radioButtonSelected = "Olive"   'store string olive if olive was selected

        ElseIf (grayRB.Checked) Then
            radioButtonSelected = "Gray"    'store string gray if gray was selected

        End If

        'if the entered pairs was valid, then prompt to save file
        If totalPairs = (totalSize / 2) Then
            buildCards(totalSize)

            dialog = New SaveFileDialog     'create new save file dialog
            dialog.ShowDialog()             'show the user the dialog

            'create the file writer
            Dim fileWriter As StreamWriter
            fileWriter = New StreamWriter(dialog.FileName)


            fileWriter.WriteLine(radioButtonSelected)   'print which card back color to file
            fileWriter.WriteLine(sizeChosen)            'print size board they want to file
            fileWriter.Close()

            'if number of pairs entered was valid prompt to enter again
        Else
            MessageBox.Show("Please enter a valid number of pairs!")
        End If


    End Sub

    Private Sub imageRB_CheckedChanged(sender As Object, e As EventArgs) Handles imageRB.CheckedChanged
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                radioButtonSelected = ofd.FileName.ToString     'store file name in which radio was selected as string
                displayImage.BackgroundImage = Bitmap.FromFile(ofd.FileName)    'set thumbnail image to image chosen
                displayImage.BackgroundImageLayout = ImageLayout.Stretch        'make image fit to thumbnail to scale
            End If
        End If
    End Sub

    Public Sub buildCards(ByVal totalSize As Integer)
        Dim random As Integer
        Dim myCardsCount = totalSize - 1

        For x As Integer = 0 To myCardsCount
            myCards(x) = "blank"
        Next

        For y As Integer = 0 To myCardsCount

            For b As Integer = 0 To (blueVal * 2) - 1
                Randomize()
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))

                While (True)
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Blue"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next

            For r As Integer = 0 To (redVal * 2) - 1
                Randomize()
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                While (True)
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Red"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next

            For g As Integer = 0 To (greenVal * 2) - 1
                Randomize()
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                While (True)
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Green"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next
            Exit For
        Next

        For y As Integer = 0 To myCardsCount
            If myCards(y).Equals("blank") Then
                myCards(y) = "Yellow"
            End If
        Next

        For y As Integer = 0 To totalSize
            Console.WriteLine(myCards(y))
        Next

    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()     'exit application
    End Sub
End Class
