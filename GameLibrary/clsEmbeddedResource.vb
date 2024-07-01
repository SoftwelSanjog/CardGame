Public Class clsEmbeddedResource
    Public Shared Function FetchIcon(ByVal iconName As String) As Icon
        Dim oStream As System.IO.Stream
        Dim oAssembly As System.Reflection.Assembly
        Dim sIcon As String
        Dim oBitmap As Bitmap
        sIcon = iconName

        'open the executing assembly
        oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)

        'create stream for image (icon) in assembly
        oStream = oAssembly.GetManifestResourceStream(sIcon)

        'create new bitmap from stream
        oBitmap = CType(Image.FromStream(oStream), Bitmap)

        'create icon from bitmap
        FetchIcon = Icon.FromHandle(oBitmap.GetHicon)
    End Function
End Class
