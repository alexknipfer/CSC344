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

            'initialize count to print out array values
            Dim count As Integer = 0

            'loop through the array and print out array values (string of colors)
            'in the form of the layout of the game
            For p As Integer = 0 To (sizeChosen - 1)
                For q As Integer = 0 To (sizeChosen - 2)
                    fileWriter.Write(myCards(count).PadRight(8))    'line up all of the card values with padding
                    count = count + 1 'increase count
                Next
                fileWriter.WriteLine("")    'drop down a line
            Next

            'reset count so if a new file is created 
            count = 0

            fileWriter.Close()  'close file writer

            MessageBox.Show("File Created Successfully!")   'prompt to show file created successfully

            'if number of pairs entered was valid prompt to enter again
        Else
            MessageBox.Show("Please enter a valid number of pairs!")
        End If


    End Sub

    'prompt a file dialog to choose an image as soon as image radio button is clicked
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

    'the following function builds the array of card colors randomly based on number
    'of pairs users entered
    Public Sub buildCards(ByVal totalSize As Integer)
        Dim random As Integer
        Dim myCardsCount = totalSize - 1    'get total cards being used

        'initialize card array to have all string values of blank
        For x As Integer = 0 To myCardsCount
            myCards(x) = "blank"
        Next

        'go through all card values in array
        For y As Integer = 0 To myCardsCount

            'go through array as many times as the pairs selected for blue
            For b As Integer = 0 To (blueVal * 2) - 1
                Randomize() 'initialize randomizer
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))    'generate a random number within array bounds

                'keep generating values until filled
                While (True)
                    'if the random number generated in the array is blank it is valid to change
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Blue"    'set equal to blue
                        Exit While

                        'if the generated number has already been used, generate another number
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next

            'go through array as many times as the pairs selected for red
            For r As Integer = 0 To (redVal * 2) - 1
                Randomize() 'initialize randomizer
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))    'generate a random number within array bounds
                While (True)
                    'if the random number generated in the array is blank it is valid to change
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Red"     'set equal to red
                        Exit While

                        'if the generated number has already been used, generate another number
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next

            'go through array as many times as the pairs selected for green
            For g As Integer = 0 To (greenVal * 2) - 1
                Randomize() 'initialize randomizer
                random = CInt(Int(((myCardsCount) * Rnd()) + 0))    'generate a random number within array bounds
                While (True)
                    'if the random number generated in the array is blank it is valid to change
                    If myCards(random).Equals("blank") Then
                        myCards(random) = "Green"       'set equal to green
                        Exit While

                        'if the generated number has already been used, generate another number
                    Else
                        Randomize()
                        random = CInt(Int(((myCardsCount) * Rnd()) + 0))
                    End If
                End While
            Next
            Exit For
        Next

        'set any remaining card backs to yellow
        For y As Integer = 0 To myCardsCount
            If myCards(y).Equals("blank") Then
                myCards(y) = "Yellow"
            End If
        Next

    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()     'exit application
    End Sub

    Private Sub sizeChoice_SelectedValueChanged(sender As Object, e As EventArgs) Handles sizeChoice.SelectedValueChanged
        Dim selectedValue As Integer
        Dim totalCardsSelected As Integer
        Dim pairsNeeded As Integer

        selectedValue = CInt(sizeChoice.SelectedItem.ToString)

        totalCardsSelected = selectedValue * (selectedValue - 1)
        pairsNeeded = totalCardsSelected / 2

        cardTotalLabel.Text = totalCardsSelected

        totalPairsLabel.Text = pairsNeeded
    End Sub
End Class
