Friend Class Location
    Inherits Thingie
    Implements ILocation

    Public Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub

    Friend Shared Function Create(worldData As WorldData, name As String) As ILocation
        Dim locationId = worldData.NextLocationId
        worldData.Locations(locationId) = New LocationData With {.Name = name}
        Return New Location(worldData, locationId)
    End Function
End Class
