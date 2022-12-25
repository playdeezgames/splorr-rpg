Friend Class Direction
    Inherits Thingie
    Implements IDirection

    Public Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub

    Public ReadOnly Property Name As String Implements IDirection.Name
        Get
            Return _worldData.Directions(Id).Name
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, name As String) As IDirection
        Dim directionId As Integer = worldData.NextDirectionId
        worldData.Directions(directionId) = New DirectionData With {.name = name}
        Return New Direction(worldData, directionId)
    End Function
End Class
