Public Class Form1
    Dim TheDeck As DeckOfCards
    Dim Hands(NumberOfHands - 1) As HandOfCards
    Const NumberOfHands As Integer = 10
    Dim testcard As String
    Dim testplayingcard As PlayingCard

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If TheDeck IsNot Nothing Then
            For i = 0 To NumberOfHands - 1
                Hands(i).DrawHand(e.Graphics, 25, 25 + i * 65)
            Next
        End If
        'If testcard IsNot Nothing Then
        'DrawCard(e.Graphics, 20, 25)
        'End If

    End Sub


 Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  Console.WriteLine("--------")


  TheDeck = New DeckOfCards
  TheDeck.ShuffleCards()
  TheDeck.ShuffleCards()
  'TheDeck.ShuffleCards()
  ' TheDeck.ShuffleCards()
  For i = 0 To NumberOfHands - 1
   Hands(i) = New HandOfCards
   For c As Integer = 0 To 4
    Hands(i).AddCard(TheDeck.TakeCard)
   Next
   Hands(i).SortHand()
  Next
  Array.Sort(Hands, New HandOfCards.HandComparer)
  For i = 0 To NumberOfHands - 1
   Console.WriteLine("{0}" & vbTab & "[{1}] = {2}" & vbTab & " {3}" & vbTab & "[{4}]" & vbTab & " ({5})", i + 1, Hands(i).ToString, Hands(i).SuitValueOfHand, Hands(i).RankDistrubtion, Hands(i).NameOfHand, Hands(i).ValueOfHand)
  Next
  'Console.WriteLine("Deck [{0}]", TheDeck.DeckState)
  'Console.WriteLine("Deck [{0}]", TheDeck.DeckState)
  'TheDeck.ShuffleCards()
  'Console.WriteLine("Deck [{0}]", TheDeck.DeckState)
  Me.Refresh()
 End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        testcard = "SA"

    End Sub
    Private Sub DrawCard(ByRef g As Graphics, ByRef x As Integer, ByRef y As Integer)
        
        g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        'g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Me.ToString & ".gif"), x, y, 46, 64) '71, 96)
        g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & testcard & ".gif"), x, y, 46, 64) '71, 96)
    End Sub
End Class
