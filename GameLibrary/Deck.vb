Imports System.ComponentModel
Public Class Deck
    'This code is an array of Enumeration Values.
    Dim m_suits() As Suit = {Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades}
    <Category("Game"), Description("The suits in the Deck.")>
    Public Property Suits() As Suit()
        Get
            Return m_suits
        End Get
        Set(value As Suit())
            m_suits = value
            Me.MakeDeck()
        End Set
    End Property

    Dim m_faceValues() As FaceValue = {FaceValue.Ace, FaceValue.Two, FaceValue.Three, FaceValue.Four, FaceValue.Five, FaceValue.Six _
        , FaceValue.Seven, FaceValue.Eight, FaceValue.Nine, FaceValue.Ten, FaceValue.Jack, FaceValue.Queen, FaceValue.King}
    <Category("Game"), Description("The faceValues in the Deck.")>
    Public Property FaceValues() As FaceValue()
        Get
            Return m_faceValues
        End Get
        Set(value As FaceValue())
            m_faceValues = value
            Me.MakeDeck()
        End Set
    End Property
    Dim m_cards As New System.Collections.ArrayList()
    Public Sub MakeDeck()
        'Dispose of  the existing cards
        For i = 0 To m_cards.Count - 1
            CType(m_cards(i), Card).Dispose()
        Next
        m_cards.Clear()
        Dim asuit, avalue As Integer
        For asuit = 0 To Suits.Length - 1
            For avalue = 0 To FaceValues.Length - 1
                m_cards.Add(New Card(m_suits(asuit), m_faceValues(avalue)))
            Next
        Next
    End Sub
    Public Sub Suffle()
        Dim rgen As New System.Random
        Dim newDeck As New System.Collections.ArrayList
        While (m_cards.Count > 0)
            'Choose one card at randon
            Dim removeindex As Integer = rgen.Next(0, m_cards.Count - 1)
            Dim removeobject As Object = m_cards(removeindex)
            m_cards.RemoveAt(removeindex)
            'Add the removed card to the new collection
            newDeck.Add(removeobject)
        End While
        m_cards = newDeck
    End Sub
    <Category("Game"), Description("Number of cards in the deck.")>
    Public ReadOnly Property count() As Integer
        Get
            Return m_cards.Count
        End Get
    End Property

    Default Public ReadOnly Property Cards(ByVal Indexer As Integer) As Card
        Get
            If ((Indexer >= 0) And (Indexer < m_cards.Count)) Then
                Return CType(m_cards(Indexer), Card)
            Else
                Throw New ArgumentOutOfRangeException("Index out of range.")
            End If
        End Get
    End Property
End Class
