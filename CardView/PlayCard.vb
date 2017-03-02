Public Class Deck

    Public Sub DrawCard(ByRef g As Graphics, ByRef x As Integer, ByRef y As Integer, ByRef Card As String)
        g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.DrawImage(New System.Drawing.Bitmap(System.Windows.Forms.Application.StartupPath & "\cards_gif\" & Card & ".gif"), x, y, 46, 64) '71, 96)
    End Sub
End Class
