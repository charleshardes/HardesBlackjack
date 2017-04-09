Public Class Form1
    Dim myDeck As New Deck
    Dim PCard1 As String
    Dim PCard2 As String
    Dim DCard1 As String
    Dim DCard2 As String
 
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        DrawCard(e.Graphics, PCard1, PCard2, 30, 40)
        DrawCard(e.Graphics, DCard1, DCard2, 30, 120)
    End Sub
    Private Sub DrawCard(ByRef g As Graphics, ByRef Card1 As String, ByRef Card2 As String, x As Integer, y As Integer)
        Dim FileName As String
        FileName = System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Card1 & ".gif"
        Dim Card_image1 As Image = Image.FromFile(FileName)
        g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.DrawImage(Card_image1, 30, y, 46, 64)
        FileName = System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Card2 & ".gif"
        Dim Card_image2 As Image = Image.FromFile(FileName)
        g.DrawImage(Card_image2, 40, y, 46, 64)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        PCard1 = "hj"
        PCard2 = "ca"
        DCard1 = "sa"
        DCard2 = "b2fv"
        'FileName = System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Card1 & ".gif"
        'Dim Card1_image As Image = Image.FromFile(FileName)
        'Me.PictureBox1.Image = Card1_image
        ' FileName = System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Card2 & ".gif"
        'Dim Card2_image As Image = Image.FromFile(FileName)
        'Me.PictureBox2.Image = Card2_image
        
        Me.Refresh()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub DrawImageRect(ByVal e As PaintEventArgs)
        ' Create image.
        Dim FileName As String
        FileName = System.Windows.Forms.Application.StartupPath & "\cards_gif\" & PCard1 & ".gif"
        Dim newImage As Image = Image.FromFile(FileName)

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PCard1 = "sa"
        PCard2 = "ha"
        DCard1 = "dt"
        DCard2 = "b2fv"
    End Sub
End Class
