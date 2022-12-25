Friend Class Location
    Inherits Thingie
    Implements ILocation

    Public Sub New(worldData As WorldData, world As IWorld, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property Name As String Implements ILocation.Name
        Get
            Return _worldData.Locations(Id).Name
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return _worldData.Locations(Id).Routes.Select(Function(x) New Route(_worldData, World, Me, New Direction(_worldData, World, x.Key)))
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, world As IWorld, name As String) As ILocation
        Dim locationId = worldData.NextLocationId
        worldData.Locations(locationId) = New LocationData With {.Name = name}
        Return New Location(worldData, world, locationId)
    End Function
End Class
