Public Class MainBoard
    Private Sub MainBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Memory1.Play()
    End Sub

    Private Sub Memory1_GameOver(sender As Object, e As GameLibrary.GameOverEventArgs) Handles Memory1.GameOver
        Dim result As DialogResult
        result = MessageBox.Show("You win in " & e.Clicks & " turns." & ControlChars.CrLf & "Play Again?", "Game Over", MessageBoxButtons.YesNo)
        If (result = DialogResult.Yes) Then
            Me.Memory1.Play()
        End If
    End Sub
End Class
