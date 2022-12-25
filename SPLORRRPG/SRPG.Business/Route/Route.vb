Friend Class Route
    Inherits BaseThingie
    Implements IRoute

    Public Sub New(worldData As WorldData, fromLocation As ILocation, direction As IDirection)
        MyBase.New(worldData)
        Me.FromLocation = fromLocation
        Me.Direction = direction
    End Sub
    Public ReadOnly Property FromLocation As ILocation Implements IRoute.FromLocation
    Public ReadOnly Property Direction As IDirection Implements IRoute.Direction
    Public ReadOnly Property ToLocation As ILocation Implements IRoute.ToLocation
        Get
            Return New Location(_worldData, _worldData.Locations(FromLocation.Id).Routes(Direction.Id).ToLocationId)
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, fromLocation As ILocation, direction As IDirection, toLocation As ILocation) As IRoute
        worldData.Locations(fromLocation.Id).Routes(direction.Id) = New RouteData With {.ToLocationId = toLocation.Id}
        Return New Route(worldData, fromLocation, direction)
    End Function
End Class
