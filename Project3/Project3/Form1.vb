Public Class Form1

    Private sliderValue As Integer
    Private card As PictureBox
    Private myCards(90) As PictureBox
    Private myCardsCount As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        sliderValue = 4
        buildCards(4)
    End Sub

    Public Sub buildCards(ByVal amount As Integer)
        Dim rows As Integer
        Dim cols As Integer
        Dim totalCards As Integer
        Dim blue As Integer
        Dim red As Integer
        Dim green As Integer
        Dim yellow As Integer
        Dim random As Integer

        myCardsCount = 0

        rows = amount
        cols = amount - 1

        totalCards = rows * cols

        For x As Integer = 0 To totalCards - 1
            If amount = 4 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 150
                card.Height = 150
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 60, 10)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 5 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 100
                card.Height = 100
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 50, 30)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 6 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 90
                card.Height = 90
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 30, 15)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 7 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 70
                card.Height = 70
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 35, 20)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 8 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 60
                card.Height = 60
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 25, 20)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 9 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 55
                card.Height = 55
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 20, 15)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)

            ElseIf amount = 10 Then
                card = New PictureBox
                card.Visible = True
                card.Width = 50
                card.Height = 50
                card.BackColor = Color.Olive
                card.Margin = New Padding(0, 0, 15, 10)
                card.Tag = "empty"
                myCards(myCardsCount) = card
                myCardsCount = myCardsCount + 1
                mainPane.Controls.Add(card)
            End If
        Next

        blue = CInt(blueValue.Text)
        red = CInt(redValue.Text)
        yellow = CInt(yellowValue.Text)
        green = CInt(greenValue.Text)

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





    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub newButton_Click(sender As Object, e As EventArgs) Handles newButton.Click
        mainPane.Controls.Clear()
        buildCards(sliderValue)
        For tags As Integer = 0 To myCardsCount - 1
            Console.WriteLine(myCards(tags).Tag)
        Next
    End Sub

    Private Sub sizeSlider_ValueChanged(sender As Object, e As EventArgs) Handles sizeSlider.ValueChanged
        sliderValue = sizeSlider.Value
        sizeLabel.Text = sizeSlider.Value
    End Sub
End Class
