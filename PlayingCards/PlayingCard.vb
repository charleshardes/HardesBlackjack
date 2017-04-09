Public Class HandOfCards
 Protected mHand As List(Of PlayingCard)

 Public Sub AddCard(ByVal card As PlayingCard)
  If mHand.Count = 5 Then Exit Sub
  mHand.Add(card)
 End Sub

 Public Function Card(ByRef index As Integer) As PlayingCard
  If index < 0 Or index > 4 Then Return Nothing
  Return mHand(index)
 End Function

 Public Sub SortHand()
  mHand.Sort(New PlayingCard.CardComparer)
 End Sub

 Public Overrides Function ToString() As String
  Dim s As String = ""
  mHand.Sort(New PlayingCard.CardComparer)
  For Each pc As PlayingCard In mHand
   s &= pc.ToString
  Next
  Return s
 End Function

 Public Sub New()
  mHand = New List(Of PlayingCard)
 End Sub


 Public Function ValueOfHand() As String
  Dim DictionaryOfAlpha As New Dictionary(Of Char, Integer)
  Dim Alpha() As Char = "MLKJIHGFEDCBA"
  For I As Integer = 0 To Alpha.Count - 1 : DictionaryOfAlpha.Add(Alpha(I), 0) : Next
  For i As Integer = 0 To mHand.Count - 1 : DictionaryOfAlpha(Alpha(mHand(i).CardValue)) += 1 : Next
  Dim ReorderDictionary As IEnumerable = From DictionaryEntry In DictionaryOfAlpha _
                          Select DictionaryEntry _
                          Order By DictionaryEntry.Value Descending, _
                          DictionaryEntry.Key Ascending
  ValueOfHand = ""
  For Each Entry In ReorderDictionary : ValueOfHand &= Strings.StrDup(Entry.Value, Entry.Key) : Next
 End Function

 Public Function SuitValueOfHand() As String
  Dim n(3) As Integer
  For i As Integer = 0 To mHand.Count - 1
   n(mHand(i).SuitValue) += 1
  Next
  SuitValueOfHand = n(0).ToString & n(1).ToString & n(2).ToString & n(3).ToString
  Return SuitValueOfHand
 End Function

 Public Function RankDistrubtion() As String
  Dim n(12) As Integer
  For i As Integer = 0 To mHand.Count - 1 : n(mHand(i).CardValue) += 1 : Next
  RankDistrubtion = ""
  For i As Integer = 12 To 0 Step -1 : RankDistrubtion &= n(i).ToString : Next
  Return RankDistrubtion
 End Function

 Public Function NameOfHand() As String
  Dim f As String = RankDistrubtion()
  Dim s As String = SuitValueOfHand.ToString
  Select Case True
   Case System.Text.RegularExpressions.Regex.Match(f, "0*111110*").Success
    ' Contains 5 Consectative Cards
    If System.Text.RegularExpressions.Regex.Match(s, "0*50*").Success Then
     ' Contains 5 Cards of same Suit
     If f = "1111100000000" Then
      Return "01. Royal Flush"
     Else
      Return "02. Straight Flush"
     End If
    Else
     Return "06. Straight"
    End If
   Case System.Text.RegularExpressions.Regex.Match(f, "[01]*4[01]*").Success : Return "03. Four of a Kind"
   Case System.Text.RegularExpressions.Regex.Match(f, "(0*20*30*)|(0*30*20*)").Success() : Return "04. Full House"
   Case System.Text.RegularExpressions.Regex.Match(f, "0*10*10*10*10*10*").Success
    If System.Text.RegularExpressions.Regex.Match(s, "0*50*").Success Then Return "05. Flush"
   Case System.Text.RegularExpressions.Regex.Match(f, "[01]*3[01]*").Success : Return "07. Three Of a Kind"
   Case System.Text.RegularExpressions.Regex.Match(f, "[01]*2[01]*2[01]*").Success() : Return "08. Two Pair"
   Case System.Text.RegularExpressions.Regex.Match(f, "[01]*2[01]*").Success : Return "09. Pair"
  End Select
  Return "10. High Card"
 End Function

 Public Sub DrawHand(ByRef g As Graphics, ByRef x As Integer, ByRef y As Integer)
  For i As Integer = 0 To 4
   mHand(i).DrawCard(g, 10 + 25 * i, y)

  Next
  g.DrawString(NameOfHand, New Font("Tahoma", 16, FontStyle.Regular, GraphicsUnit.Pixel, 0), Brushes.Black, 175, y + 25)
 End Sub

 Public Class HandComparer
  Implements IComparer(Of HandOfCards)
  Public Function Compare(ByVal x As HandOfCards, ByVal y As HandOfCards) As Integer Implements System.Collections.Generic.IComparer(Of HandOfCards).Compare
   Dim c As Integer = x.NameOfHand.Substring(0, 2).CompareTo(y.NameOfHand.Substring(0, 2))
   Select Case c
    Case -1, 1 : Return c
    Case 0 : Return String.Compare(x.ValueOfHand, y.ValueOfHand)
   End Select
  End Function
 End Class
End Class

Public Class DeckOfCards
 Dim r As New Random(Now.Millisecond)
 Dim mDeck As New List(Of PlayingCard)
 Dim Suits() As String = {"S", "D", "C", "H"}
 Dim Faces() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"}

 Public Sub New()
  For Each Suit As String In Suits
   For Each Face As String In Faces.Reverse
    mDeck.Add(New PlayingCard(Suit, Face))
   Next
  Next
 End Sub

 Public Sub ShuffleCards()
  Dim rc As PlayingCard
  Dim rn As Integer
  For i As Integer = 0 To 52
   rn = r.Next(0, 51) Mod mDeck.Count
   rc = mDeck(rn)
   mDeck.RemoveAt(rn)
   mDeck.Add(rc)
  Next
 End Sub

 Public ReadOnly Property TakeCard() As PlayingCard
  Get
   Dim RemovedCard As PlayingCard = mDeck(0)
   mDeck.RemoveAt(0)
   Return RemovedCard
  End Get
 End Property

 Public ReadOnly Property DeckState() As String
  Get
   Dim d As String = ""
   For Each m As PlayingCard In mDeck
    d &= m.ToString
   Next
   Return d
  End Get
 End Property
End Class


Public Class PlayingCard
 Dim Suits() As String = {"S", "D", "C", "H"}
 Dim Faces() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"}
 Private mFace As String
 Private mSuit As String
 Protected cv As Integer = 0
 Protected sv As Integer = 0

 Public Sub New(ByVal tSuit As String, ByVal tFaceValue As String)
        mFace = tFaceValue
        mSuit = tSuit
        cv = Array.IndexOf(Of String)(Faces, mFace) '+ 1
        sv = Array.IndexOf(Of String)(Suits, mSuit) ' + 1

 End Sub

 Public ReadOnly Property Suit() As String
  Get
   Return mSuit
  End Get
 End Property

 Public ReadOnly Property Face() As String
  Get
   Return mFace
  End Get
 End Property

 Public Overrides Function ToString() As String
  Return mSuit & mFace
 End Function

 Public Sub DrawCard(ByRef g As Graphics, ByRef x As Integer, ByRef y As Integer)
        Dim testcard As String
        testcard = "SA"
        g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Me.ToString & ".gif"), x, y, 46, 64) '71, 96)
        'g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & testcard & ".gif"), x, y, 46, 64) '71, 96)
 End Sub
    Public Sub DrawCard2(ByRef g As Graphics, ByRef x As Integer, ByRef y As Integer, cd As String)

        g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & cd & ".gif"), x, y, 46, 64) '71, 96)
        'g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & testcard & ".gif"), x, y, 46, 64) '71, 96)
    End Sub
 Public ReadOnly Property CardValue() As Integer
  Get
   Return cv
  End Get
 End Property

 Public ReadOnly Property SuitValue() As Integer
  Get
   Return sv
  End Get
 End Property

 Public Class CardComparer
  Implements IComparer(Of PlayingCard)
  Public Function Compare(ByVal x As PlayingCard, ByVal y As PlayingCard) As Integer Implements System.Collections.Generic.IComparer(Of PlayingCard).Compare
   Dim RANKS() As String = {"A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2"}
   Dim xi = Array.IndexOf(Of String)(RANKS, CStr(x.ToString)(1))
   Dim Yi = Array.IndexOf(Of String)(RANKS, CStr(y.ToString)(1))
   Return xi.CompareTo(Yi)
  End Function
 End Class

End Class
