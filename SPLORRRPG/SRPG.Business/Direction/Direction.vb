Friend Class Direction
    Inherits Thingie
    Implements IDirection

    Public Sub New(worldData As WorldData, world As IWorld, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property Name As String Implements IDirection.Name
        Get
            Return _worldData.Directions(Id).Name
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, world As IWorld, name As String) As IDirection
        Dim directionId As Integer = worldData.NextDirectionId
        worldData.Directions(directionId) = New DirectionData With {.Name = name}
        Return New Direction(worldData, world, directionId)
    End Function
End Class
