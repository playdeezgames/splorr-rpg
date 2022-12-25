Public Class LocationData
    Public Property Name As String
    Public Property CharacterIds As New HashSet(Of Integer)
    Public Property Routes As New Dictionary(Of Integer, RouteData)
End Class
