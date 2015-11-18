Public Class Form1

    Private sliderValue As Integer
    Private card As PictureBox
    Private myCards(90) As PictureBox
    Private myCardsCount As Integer
    Private moveNumber As Integer
    Private bluePairsFound As Integer
    Private redPairsFound As Integer
    Private yellowPairsFound As Integer
    Private greenPairsFound As Integer
    Private pic As PictureBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        moveNumber = 0          'initialize number of moves
        bluePairsFound = 0      'initialize total blue pairs
        redPairsFound = 0       'initialize total red pairs
        yellowPairsFound = 0    'initialize total yellow pairs
        greenPairsFound = 0     'initialize total green pairs

        oliveRB.Checked = True  'make olive radio button default selected

        'build default size board of size 4
        sliderValue = 4
        buildCards(4)
    End Sub

    'This method builds the board size with the correct amount cards
    Public Sub buildCards(ByVal amount As Integer)
        Dim rows As Integer
        Dim cols As Integer
        Dim totalCards As Integer
        Dim blue As Integer
        Dim red As Integer
        Dim green As Integer
        Dim yellow As Integer
        Dim random As Integer

        myCardsCount = 0    'keep track of card count

        rows = amount
        cols = amount - 1

        'set total cards equal to amount of rows multiplied by rows - 1
        totalCards = rows * cols

        'build cards for board size of 4
        For x As Integer = 0 To totalCards - 1
            If amount = 4 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 150
                card.Height = 150
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 60, 10)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size of 5
            ElseIf amount = 5 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 100
                card.Height = 100
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 50, 30)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)

            ElseIf amount = 6 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 90
                card.Height = 90
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 30, 15)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)

            ElseIf amount = 7 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 70
                card.Height = 70
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 35, 20)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)

            ElseIf amount = 8 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 60
                card.Height = 60
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 25, 20)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)

            ElseIf amount = 9 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 55
                card.Height = 55
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 20, 15)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)

            ElseIf amount = 10 Then
                card = New PictureBox
                AddHandler card.Click, AddressOf card_Click
                card.Visible = True
                card.Width = 50
                card.Height = 50
                card.BackColor = Color.Olive                    'default back color of olive
                card.Margin = New Padding(0, 0, 15, 10)         'set proper padding
                card.Tag = "empty"                              'set tag to empty to say nothing is done to it
                myCards(myCardsCount) = card                    'add card to array
                myCardsCount = myCardsCount + 1                 'add to card count
                mainPane.Controls.Add(card)
            End If
        Next

        blue = CInt(blueValueInput.Text)
        red = CInt(redValueInput.Text)
        yellow = CInt(yellowValueInput.Text)
        green = CInt(greenValueInput.Text)

        For y As Integer = 0 To myCardsCount - 1
            For b As Integer = 0 To (blue * 2) - 1
                Randomize()
                random = CInt(Int(((totalCards - 1) * Rnd()) + 0))

                While (True)
                    If myCards(random).Tag = "empty" Then
                        myCards(random).Tag = "blue"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((totalCards - 1) * Rnd()) + 0))
                    End If
                End While
            Next


            For r As Integer = 0 To (red * 2) - 1
                Randomize()
                random = CInt(Int(((totalCards - 1) * Rnd()) + 0))

                While (True)
                    If myCards(random).Tag = "empty" Then
                        myCards(random).Tag = "red"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((totalCards - 1) * Rnd()) + 0))
                    End If
                End While
            Next


            For g As Integer = 0 To (green * 2) - 1
                Randomize()
                random = CInt(Int(((totalCards - 1) * Rnd()) + 0))

                While (True)
                    If myCards(random).Tag = "empty" Then
                        myCards(random).Tag = "green"
                        Exit While
                    Else
                        Randomize()
                        random = CInt(Int(((totalCards - 1) * Rnd()) + 0))
                    End If
                End While
            Next


            Exit For
        Next

        For q As Integer = 0 To myCardsCount - 1
            If myCards(q).Tag = "empty" Then
                myCards(q).Tag = "yellow"
            End If
        Next

        For v As Integer = 0 To myCardsCount - 1
            Console.WriteLine(myCards(v).Tag)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub card_Click(ByVal sender As Object, ByVal e As EventArgs)
        pic = DirectCast(sender, PictureBox)
        Dim blueFound As Boolean = False
        Dim redFound As Boolean = False
        Dim yellowFound As Boolean = False
        Dim greenFound As Boolean = False

        moveNumber = moveNumber + 1

        If pic.Tag = "blue" Then
            pic.BackColor = Color.Blue
            pic.Tag = "blueSelected"

        ElseIf pic.Tag = "red" Then
            pic.BackColor = Color.Red
            pic.Tag = "redSelected"

        ElseIf pic.Tag = "yellow" Then
            pic.BackColor = Color.Yellow
            pic.Tag = "yellowSelected"

        ElseIf pic.Tag = "green" Then
            pic.BackColor = Color.Green
            pic.Tag = "greenSelected"

        End If

        If moveNumber = 2 Then
            For q As Integer = 0 To myCardsCount - 1
                If myCards(q).Tag = "blueSelected" Then
                    bluePairsFound = bluePairsFound + 1
                    If bluePairsFound = 2 Then
                        For v As Integer = 0 To myCardsCount - 1
                            If myCards(v).Tag = "blueSelected" Then
                                myCards(v).BackColor = Color.Transparent
                                myCards(v).Tag = "done"
                                blueFound = True
                            End If
                        Next
                        MessageBox.Show("Match Found")
                        pScore.Text = Val(pScore.Text) + 1
                    End If

                ElseIf myCards(q).Tag = "redSelected" Then
                    redPairsFound = redPairsFound + 1
                    If redPairsFound = 2 Then
                        For r As Integer = 0 To myCardsCount - 1
                            If myCards(r).Tag = "redSelected" Then
                                myCards(r).BackColor = Color.Transparent
                                myCards(r).Tag = "done"
                                redFound = True
                            End If
                        Next
                        MessageBox.Show("Match Found")
                        pScore.Text = Val(pScore.Text) + 1
                    End If

                ElseIf myCards(q).Tag = "greenSelected" Then
                    greenPairsFound = greenPairsFound + 1
                    If greenPairsFound = 2 Then
                        For g As Integer = 0 To myCardsCount - 1
                            If myCards(g).Tag = "greenSelected" Then
                                myCards(g).BackColor = Color.Transparent
                                myCards(g).Tag = "done"
                                greenFound = True
                            End If
                        Next
                        MessageBox.Show("Match Found")
                        pScore.Text = Val(pScore.Text) + 1
                    End If

                ElseIf myCards(q).Tag = "yellowSelected" Then
                    yellowPairsFound = yellowPairsFound + 1
                    If yellowPairsFound = 2 Then
                        For y As Integer = 0 To myCardsCount - 1
                            If myCards(y).Tag = "yellowSelected" Then
                                myCards(y).BackColor = Color.Transparent
                                myCards(y).Tag = "done"
                                yellowFound = True
                            End If
                        Next
                        MessageBox.Show("Match Found")
                        pScore.Text = Val(pScore.Text) + 1
                    End If
                End If

            Next
            moveNumber = 0
            bluePairsFound = 0
            yellowPairsFound = 0
            greenPairsFound = 0
            redPairsFound = 0

            If blueFound = False And redFound = False And yellowFound = False And greenFound = False Then
                For x As Integer = 0 To myCardsCount - 1
                    If myCards(x).Tag = "blueSelected" Then
                        myCards(x).Tag = "blue"

                    ElseIf myCards(x).Tag = "redSelected" Then
                        myCards(x).Tag = "red"

                    ElseIf myCards(x).Tag = "yellowSelected" Then
                        myCards(x).Tag = "yellow"

                    ElseIf myCards(x).Tag = "greenSelected" Then
                        myCards(x).Tag = "green"

                    End If

                    'System.Threading.Thread.Sleep(100)
                    If myCards(x).Tag <> "done" Then
                        myCards(x).BackColor = Color.Olive
                    End If
                Next
                MessageBox.Show("Match not found!")
            End If

        End If
    End Sub

    Private Sub newButton_Click(sender As Object, e As EventArgs) Handles newButton.Click
        Dim blueVal As Integer
        Dim redVal As Integer
        Dim greenVal As Integer
        Dim yellowVal As Integer
        Dim totalVal As Integer
        Dim totalCards As Integer

        blueVal = CInt(blueValueInput.Text)
        redVal = CInt(redValueInput.Text)
        greenVal = CInt(greenValueInput.Text)
        yellowVal = CInt(yellowValueInput.Text)

        totalVal = blueVal + redVal + greenVal + yellowVal

        totalCards = sliderValue * (sliderValue - 1)

        If totalVal = (totalCards / 2) Then
            mainPane.Controls.Clear()
            buildCards(sliderValue)

            If oliveRB.Checked Then
                For x As Integer = 0 To myCardsCount - 1
                    myCards(x).BackColor = Color.Olive
                Next
            End If

            If grayRB.Checked Then
                For x As Integer = 0 To myCardsCount - 1
                    myCards(x).BackColor = Color.Gray
                Next
            End If

            If imageRB.Checked Then
                Dim ofd As New OpenFileDialog
                If ofd.ShowDialog = DialogResult.OK Then
                    If ofd.FileName <> String.Empty Then
                        For x As Integer = 0 To myCardsCount - 1
                            myCards(x).BackgroundImage = Bitmap.FromFile(ofd.FileName)
                            myCards(x).BackgroundImageLayout = ImageLayout.Stretch
                        Next
                    End If
                End If
            End If
        Else
            MessageBox.Show("Enter a valid amount of pairs!")
        End If


    End Sub

    Private Sub sizeSlider_ValueChanged(sender As Object, e As EventArgs) Handles sizeSlider.ValueChanged
        sliderValue = sizeSlider.Value
        sizeLabel.Text = sizeSlider.Value
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Console.WriteLine("hello")
    End Sub


End Class
