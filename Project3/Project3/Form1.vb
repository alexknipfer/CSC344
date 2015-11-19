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
    Private currentWidth As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        moveNumber = 0          'initialize number of moves
        bluePairsFound = 0      'initialize total blue pairs
        redPairsFound = 0       'initialize total red pairs
        yellowPairsFound = 0    'initialize total yellow pairs
        greenPairsFound = 0     'initialize total green pairs

        currentWidth = 0

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
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size 6
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
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size 7
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
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size 8
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
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size 9
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
                mainPane.Controls.Add(card)                     'add card to pane (board)

                'build cards for board size 9
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
                mainPane.Controls.Add(card)                     'add card to pane (board)
            End If
        Next

        'The following gets the text box input
        'for the amount of pairs per color
        blue = CInt(blueValueInput.Text)
        red = CInt(redValueInput.Text)
        yellow = CInt(yellowValueInput.Text)
        green = CInt(greenValueInput.Text)

        'The following loop places a tag of the color randomly based on the amount
        'of pairs the user entered. The tag then determines what color that card
        'is when it is selected. This one is for the color blue
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

            'The following loop places a tag of the color randomly based on the amount
            'of pairs the user entered. The tag then determines what color that card
            'is when it is selected. This one is for the color red
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

            'The following loop places a tag of the color randomly based on the amount
            'of pairs the user entered. The tag then determines what color that card
            'is when it is selected. This one is for the color green
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

        'The following loop places a tag of the color randomly based on the amount
        'of pairs the user entered. The tag then determines what color that card
        'is when it is selected. This one is for the color yellow
        For q As Integer = 0 To myCardsCount - 1
            If myCards(q).Tag = "empty" Then
                myCards(q).Tag = "yellow"
            End If
        Next

        For v As Integer = 0 To myCardsCount - 1
            Console.WriteLine(myCards(v).Tag)
        Next
        Console.WriteLine("")
    End Sub

    'Quit the application when the Exit button is clicked
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    'This function provides action when a user clicks a card
    Private Sub card_Click(ByVal sender As Object, ByVal e As EventArgs)
        pic = DirectCast(sender, PictureBox)    'get the card that was clicked

        'initialize the variables to say if the cards have been selected
        Dim blueFound As Boolean = False
        Dim redFound As Boolean = False
        Dim yellowFound As Boolean = False
        Dim greenFound As Boolean = False

        'increaese move number since a card was clicked
        moveNumber = moveNumber + 1

        'change the color to blue if user clicked blue card
        If pic.Tag = "blue" Then
            pic.BackColor = Color.Blue
            'Timer1.Enabled = True

            pic.Tag = "blueSelected"    'a blue card has been selected
            currentWidth = pic.Width


            'change the color to red if user clicked red card
        ElseIf pic.Tag = "red" Then
            pic.BackColor = Color.Red
            pic.Tag = "redSelected"     'a red card has been selected

            'change the color to yellow if user clicked yellow card
        ElseIf pic.Tag = "yellow" Then
            pic.BackColor = Color.Yellow
            pic.Tag = "yellowSelected"  'a yellow card has been selected

            'change the color to green if user clicked green card
        ElseIf pic.Tag = "green" Then
            pic.BackColor = Color.Green
            pic.Tag = "greenSelected"   'a green card has been selected
        End If

        'If this is the users second move then be sure to check and see if the 
        'previous move was the same color (a match) and if not reset the cards
        '(turn them back over)

        'All of the following loops search to see if the previous move was the same color
        'as this move. The card is then removed (made transparent) if the previous move was the 
        'same color
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
                        MessageBox.Show("Match Found")  'prompt if match was found
                        pScore.Text = Val(pScore.Text) + 1  'add 1 to player score
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
                        MessageBox.Show("Match Found")  'prompt if match was found
                        pScore.Text = Val(pScore.Text) + 1  'add 1 to player score
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
                        MessageBox.Show("Match Found")  'prompt if match was found
                        pScore.Text = Val(pScore.Text) + 1  'add 1 to player score
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
                        MessageBox.Show("Match Found")  'prompt if match was found
                        pScore.Text = Val(pScore.Text) + 1  'add 1 to player score
                    End If
                End If
            Next

            'The second move is now over, so reset the move number back to 0
            moveNumber = 0

            'reset all pairs found since the second move is over
            bluePairsFound = 0
            yellowPairsFound = 0
            greenPairsFound = 0
            redPairsFound = 0

            'The following resets all the cards (cards tags) that were not a match since no match was found for these cards
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
                        If oliveRB.Checked = True Then
                            myCards(x).BackColor = Color.Olive

                        ElseIf grayRB.Checked Then
                            myCards(x).BackColor = Color.Gray
                        End If
                    End If
                Next
                MessageBox.Show("Match not found!") 'prompt user that a match was not found
            End If

            computerMove()

        End If
    End Sub


    'Generate a computer move after the player has played 2 moves
    'This function randomly generates values within the range of the amount of cards
    'currently on the board and plays the moves
    Public Sub computerMove()
        Dim computerRandom As Integer   'holds randomly generated move of valid cards

        'The following holds the value of each found to see if computer finds match
        Dim blueFound As Integer
        Dim redFound As Integer
        Dim yellowFound As Integer
        Dim greenFound As Integer

        'Initialize all card counts to 0
        blueFound = 0
        redFound = 0
        yellowFound = 0
        greenFound = 0

        'Loop two times to generate a computer move twice (two moves / two cards)
        For x As Integer = 0 To 1
            Randomize() 'initialize randomizer
            computerRandom = CInt(Int(((myCardsCount - 1) * Rnd()) + 0))    'generate a random move between valid cards

            'Keep generating random moves for cards without tag of "done" (these cards have already been chosen by player)
            While (True)
                'if the card hasn't been flipped, then card is valid
                If myCards(computerRandom).Tag <> "done" Then
                    If myCards(computerRandom).Tag = "blue" Then
                        blueFound = blueFound + 1                           'increase count to blue cards found
                        myCards(computerRandom).BackColor = Color.Blue      'set the card color to blue
                        myCards(computerRandom).Tag = "blueSelected"        'set the tag to show card has been selected

                    ElseIf myCards(computerRandom).Tag = "red" Then
                        redFound = redFound + 1                             'increase count to red cards found
                        myCards(computerRandom).BackColor = Color.Red       'set the card color to red
                        myCards(computerRandom).Tag = "redSelected"         'set the tag to show card has been selected

                    ElseIf myCards(computerRandom).Tag = "green" Then
                        greenFound = greenFound + 1                         'increase count to green cards found
                        myCards(computerRandom).BackColor = Color.Green     'set the card color to green
                        myCards(computerRandom).Tag = "greenSelected"       'set the tag to show card has been selected

                    ElseIf myCards(computerRandom).Tag = "yellow" Then
                        yellowFound = yellowFound + 1                       'increase count to yellow cards found
                        myCards(computerRandom).BackColor = Color.Yellow    'set the card color to yellow
                        myCards(computerRandom).Tag = "yellowSelected"      'set the tag to show card has been selected
                    End If
                    Exit While    'a valid card was found so exit while

                    'If the first randomly generated value was a card already used, then 
                    'generate another number (keep doing it until card is valid)
                Else
                    Randomize()
                    computerRandom = CInt(Int(((myCardsCount - 1) * Rnd()) + 0))
                End If
            End While
        Next

        'The following removes the cards from the board if the computer found a valid
        'pair of matching cards

        'If the computer found 2 blue cards
        If blueFound = 2 Then
            For b As Integer = 0 To myCardsCount - 1
                If myCards(b).Tag = "blueSelected" Then
                    myCards(b).Tag = "done"                     'change the tag to done to show it's been removed
                    myCards(b).BackColor = Color.Transparent    'set the background to transparent (removed)
                End If
            Next
            cScore.Text = Val(cScore.Text) + 1                  'increase 1 to computer score
            MessageBox.Show("The computer found a match")       'prompt to show computer has found a match

            'If the computer found 2 red cards
        ElseIf redFound = 2 Then
            For r As Integer = 0 To myCardsCount - 1
                If myCards(r).Tag = "redSelected" Then
                    myCards(r).Tag = "done"                     'change the tag to done to show it's been removed
                    myCards(r).BackColor = Color.Transparent    'set the background to transparent (removed)
                End If
            Next
            cScore.Text = Val(cScore.Text) + 1                  'increase 1 to computer score
            MessageBox.Show("The computer found a match")       'prompt to show computer has found a match

            'If the computer found 2 green cards
        ElseIf greenFound = 2 Then
            For g As Integer = 0 To myCardsCount - 1
                If myCards(g).Tag = "greenSelected" Then
                    myCards(g).Tag = "done"                     'change the tag to done to show it's been removed
                    myCards(g).BackColor = Color.Transparent    'set the background to transparent (removed)
                End If
            Next
            cScore.Text = Val(cScore.Text) + 1                  'increase 1 to computer score
            MessageBox.Show("The computer found a match")       'prompt to show computer has found a match

        ElseIf yellowFound = 2 Then
            For y As Integer = 0 To myCardsCount - 1
                If myCards(y).Tag = "yellowSelected" Then
                    myCards(y).Tag = "done"                     'change the tag to done to show it's been removed
                    myCards(y).BackColor = Color.Transparent    'set the background to transparent (removed)
                End If
            Next
            cScore.Text = Val(cScore.Text) + 1                  'increase 1 to computer score
            MessageBox.Show("The computer found a match")       'prompt to show computer has found a match

            'If the computer did not find a match then "turn" the cards back over
        Else
            'Go through all cards to reset
            For y As Integer = 0 To myCardsCount - 1
                'make sure the cards aren't already found as a match
                If myCards(y).Tag <> "done" Then

                    'If olive radio button is checked then reset card backs to olive
                    If oliveRB.Checked = True Then
                        myCards(y).BackColor = Color.Olive

                        'If gray radio button is checked then reset card backs to gray
                    ElseIf grayRB.Checked = True Then
                        myCards(y).BackColor = Color.Gray
                    End If


                    If myCards(y).Tag = "blueSelected" Then
                        myCards(y).Tag = "blue"     'reset the tag to blue if match wasn't found

                    ElseIf myCards(y).Tag = "redSelected" Then
                        myCards(y).Tag = "red"      'reset the tag to red if match wasn't found

                    ElseIf myCards(y).Tag = "greenSelected" Then
                        myCards(y).Tag = "green"    'reset the tag to green if match wasn't found

                    ElseIf myCards(y).Tag = "yellowSelected" Then
                        myCards(y).Tag = "yellow"   'reset the tag to yellow if match wasn't found
                    End If
                End If
            Next
            MessageBox.Show("The computer did not find a match")    'prompt to show computer did not find a match
        End If
    End Sub

    'This function resets the board based on the users settings they selected as long as their valid
    Private Sub newButton_Click(sender As Object, e As EventArgs) Handles newButton.Click
        Dim blueVal As Integer
        Dim redVal As Integer
        Dim greenVal As Integer
        Dim yellowVal As Integer
        Dim totalVal As Integer
        Dim totalCards As Integer

        'The following gets the values the user chose for the amount of pairs per color
        blueVal = CInt(blueValueInput.Text)
        redVal = CInt(redValueInput.Text)
        greenVal = CInt(greenValueInput.Text)
        yellowVal = CInt(yellowValueInput.Text)

        'Total the values of pairs
        totalVal = blueVal + redVal + greenVal + yellowVal

        'Get the total amount of cards on the board
        totalCards = sliderValue * (sliderValue - 1)

        'Make sure the pair totals are valid for the amount of cards on board
        If totalVal = (totalCards / 2) Then
            mainPane.Controls.Clear()   'get rid of old cards
            buildCards(sliderValue)     'build new ones based on size selected

            pScore.Text = 0
            cScore.Text = 0

            'set card backs to olive if radio button is selected
            If oliveRB.Checked Then
                For x As Integer = 0 To myCardsCount - 1
                    myCards(x).BackColor = Color.Olive
                Next
            End If

            'set card backs to gray if radio button is selected
            If grayRB.Checked Then
                For x As Integer = 0 To myCardsCount - 1
                    myCards(x).BackColor = Color.Gray
                Next
            End If

            'allow user to select image for card back if image radio button is selected
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
            MessageBox.Show("Enter a valid amount of pairs!")   'tell them the amount they entered was invalid
        End If


    End Sub

    'This function gets the value of the slider (board size) if it has been changed
    Private Sub sizeSlider_ValueChanged(sender As Object, e As EventArgs) Handles sizeSlider.ValueChanged
        sliderValue = sizeSlider.Value      'store the slider value
        sizeLabel.Text = sizeSlider.Value   'change the label to match slider value
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pic.Width -= 1

        If pic.Width = 0 Then
            Timer1.Enabled = False
            Timer2.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        pic.Width += 1
        If pic.Width = currentWidth Then
            Timer2.Enabled = False
        End If
    End Sub
End Class
