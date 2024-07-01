<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainBoard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainBoard))
        Me.Memory1 = New GameLibrary.Memory()
        Me.Deck1 = New GameLibrary.Deck(Me.components)
        Me.SuspendLayout()
        '
        'Memory1
        '
        Me.Memory1.Columns = 4
        Me.Memory1.Deck = Me.Deck1
        Me.Memory1.Location = New System.Drawing.Point(6, 0)
        Me.Memory1.Name = "Memory1"
        Me.Memory1.Rows = 4
        Me.Memory1.Size = New System.Drawing.Size(290, 350)
        Me.Memory1.TabIndex = 0
        '
        'Deck1
        '
        Me.Deck1.FaceValues = New GameLibrary.FaceValue() {GameLibrary.FaceValue.Ace, GameLibrary.FaceValue.Jack, GameLibrary.FaceValue.Queen, GameLibrary.FaceValue.King}
        Me.Deck1.Suits = New GameLibrary.Suit() {GameLibrary.Suit.Clubs, GameLibrary.Suit.Diamonds, GameLibrary.Suit.Hearts, GameLibrary.Suit.Spades}
        '
        'MainBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(301, 353)
        Me.Controls.Add(Me.Memory1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainBoard"
        Me.Text = "Cards"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Memory1 As GameLibrary.Memory
    Friend WithEvents Deck1 As GameLibrary.Deck
End Class
