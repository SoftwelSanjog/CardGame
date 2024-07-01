Imports System.ComponentModel
Public Enum Suit
    Hearts
    Diamonds
    Clubs
    Spades
End Enum
Public Enum FaceValue
        Ace
        Two
        Three
        Four
        Five
        Six
        Seven
        Eight
        Nine
        Ten
        Jack
        Queen
        King
    End Enum
Public Class Card

    Private m_faceValue As FaceValue = FaceValue.Ace
    <Category("Game"), Description("Face value Of the Card.")>
    Public Property FaceValue() As FaceValue
        Get
            Return m_faceValue
        End Get
        Set(value As FaceValue)
            m_faceValue = value
            Me.Refresh()
        End Set
    End Property
    Private m_suit As Suit = Suit.Hearts
    <Category("Game"), Description("Suit(Hearts, Spades, Diamonds, Clubs")>
    Public Property Suit() As Suit
        Get
            Return m_suit
        End Get
        Set(value As Suit)
            m_suit = value
            Me.Refresh()
        End Set

    End Property
    Private m_faceUp As Boolean = True
    <Category("Game"), Description("Is face up?")>
    Public Property FaceUp() As Boolean
        Get
            Return m_faceUp
        End Get
        Set(value As Boolean)
            m_faceUp = value
            Me.Refresh()
        End Set
    End Property
    Public Sub New(ByVal newSuit As Suit, ByVal newValue As FaceValue)
        Me.New
        m_suit = newSuit
        m_faceValue = newValue
    End Sub

    Private Sub Card_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = Me.CreateGraphics()
        g.DrawRectangle(System.Drawing.Pens.Black, 0, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
        If Me.FaceUp Then
            Me.BackColor = Color.White
            g.DrawString(Me.m_faceValue.ToString, New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, 3, 3)
            g.DrawIcon(CType(Me.m_images(m_suit), Icon), 14, 40)
        Else
            Me.BackColor = Color.Blue
        End If
    End Sub

    Public Const FixedWidth As Integer = 60
    Public Const FixedHeight As Integer = 75
    Private Sub Card_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Size = New Size(FixedWidth, FixedHeight)
    End Sub
End Class
