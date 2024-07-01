Imports System.ComponentModel
<DefaultEvent("GameOver")>
Public Class Memory
    Private m_rows As Integer = 2
    ' Private m_clicks As Integer = 0
    Public Event GameOver(sender As Object, e As GameOverEventArgs)
    <Category("Game"), Description("Number of rows in the grid.")>
    Public Property Rows() As Integer
        Get
            Return m_rows
        End Get
        Set(value As Integer)
            If value > 0 Then
                m_rows = value
                Me.Refresh()
            End If

        End Set
    End Property

    Private m_columns As Integer = 2
    <Category("Game"), Description("Number of Columns in the grid.")>
    Public Property Columns() As Integer
        Get
            Return m_columns
        End Get
        Set(value As Integer)
            If value > 0 Then
                m_columns = value
                Me.Refresh()
            End If
        End Set
    End Property
    Private m_deck As Deck
    <Category("Game"), Description("The deck used to fill the grid with cards.")>
    Public Property Deck() As Deck
        Get
            Return m_deck
        End Get
        Set(value As Deck)
            m_deck = value
        End Set
    End Property
    Private Const m_spacing As Integer = 10
    Private Sub Memory_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim height As Integer = Card.FixedHeight
        Dim width As Integer = Card.FixedWidth
        Me.Width = (width + m_spacing) * m_columns + m_spacing
        Me.Height = (height + m_spacing) * m_rows + m_spacing
        Dim g As Graphics = Me.CreateGraphics
        Dim row, column As Integer
        For row = 0 To m_rows - 1
            For column = 0 To m_columns - 1
                g.DrawRectangle(System.Drawing.Pens.Gray, column * (width + m_spacing) + m_spacing, row * (height + m_spacing) + m_spacing, width, height)
            Next
        Next

    End Sub

    Private Sub CardOver(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim theCard As Card = CType(sender, Card)
        theCard.FaceUp = Not theCard.FaceUp
        theCard.Refresh()
        m_clicks += 1
        checkForPair
        If (Me.Controls.Count = 0) Then
            RaiseEvent GameOver(Me, New GameOverEventArgs(m_clicks))
        End If
    End Sub
    Private m_clicks As Integer = 0
    Public Sub Play()
        ' reset Controls and Clicks before Starting the nex Game
        Dim aControl As Control
        For Each aControl In Me.Controls
            RemoveHandler aControl.Click, AddressOf Me.CardOver
        Next
        Me.Controls.Clear()

        'If m_deck is null the Grid is empty and ther is no game play
        If Not IsNothing(m_deck) Then
            'The Deck should have the right numbers of cards befor the game begin

            If (m_deck.count <> (m_rows * m_columns)) Then
                Throw New DeckGridIncompatibityException(String.Format("Cards:{0} Cells:{1}", m_deck.count, m_rows * m_columns))

            End If
        End If
        ' Add the cards from the deck to the game
        m_clicks = 0
        m_deck.Suffle()

        Dim cardCounter As Integer = 0
        Dim row, column As Integer
        For row = 0 To m_rows - 1
            For column = 0 To m_columns - 1
                Dim acard As Card = CType(m_deck(cardCounter), Card)
                acard.FaceUp = False
                AddHandler acard.Click, AddressOf Me.CardOver
                Me.Controls.Add(acard)
                acard.Left = column * (60 + m_spacing) + m_spacing 'LotsOfFun.Card.Fixed_Width
                acard.Top = row * (75 + m_spacing) + m_spacing
                cardCounter += 1
            Next
        Next
    End Sub

    Public Sub CheckForPair()
        System.Threading.Thread.Sleep(500)
        Dim nFaceUp As Int16 = 0
        Dim Cards(1) As Card
        Dim count As Int16
        For count = 0 To Me.Controls.Count - 1
            Dim acard As Card = CType(Me.Controls(count), Card)
            If acard.FaceUp Then
                Cards(nFaceUp) = acard
                nFaceUp += 1
            End If
        Next

        If nFaceUp = 2 Then
            If (Cards(0).FaceValue = Cards(1).FaceValue) Then
                Me.Controls.Remove(Cards(0))
                Me.Controls.Remove(Cards(1))
                RemoveHandler Cards(0).Click, AddressOf Me.CardOver
                RemoveHandler Cards(1).Click, AddressOf Me.CardOver
                Me.Refresh()
            Else
                Cards(0).FaceUp = False
                Cards(1).FaceUp = False
            End If
        End If
    End Sub
End Class

Public Class GameOverEventArgs
    Inherits System.EventArgs
    Private m_clicks As Integer
    Public Sub New(ByVal clicks As Integer)
        m_clicks = clicks
    End Sub

    Public ReadOnly Property Clicks() As Integer
        Get
            Return m_clicks
        End Get
    End Property
End Class

Public Class DeckGridIncompatibityException
    Inherits System.ApplicationException
    Public Sub New()
        MyBase.New
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class
