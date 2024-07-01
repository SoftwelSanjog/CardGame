<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Card
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    Dim m_images As New SortedList()
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Card
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "Card"
        Me.Size = New System.Drawing.Size(60, 75)
        Me.ResumeLayout(False)

    End Sub
    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        m_images.Add(Suit.Clubs, New Icon("D:\OFFICIAL\Documents\Visual Studio 2015\Projects\CardGame\GameLibrary\bin\Debug\Clubs.ico"))
        m_images.Add(Suit.Diamonds, New Icon("D:\OFFICIAL\Documents\Visual Studio 2015\Projects\CardGame\GameLibrary\bin\Debug\Diamonds.ico"))
        m_images.Add(Suit.Hearts, New Icon("D:\OFFICIAL\Documents\Visual Studio 2015\Projects\CardGame\GameLibrary\bin\Debug\Hearts.ico"))
        m_images.Add(Suit.Spades, New Icon("D:\OFFICIAL\Documents\Visual Studio 2015\Projects\CardGame\GameLibrary\bin\Debug\Spades.ico"))
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
