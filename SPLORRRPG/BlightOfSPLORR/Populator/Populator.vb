Imports SRPG.Data

Friend Class Populator
    Inherits BasePopulator
    Private ReadOnly _name As String
    Sub New(name As String)
        _name = name
    End Sub

    Public Overrides Sub Populuate(worldData As WorldData, world As IWorld)
        CreateDirections(worldData, world)
        Dim north = world.Directions.Single(Function(x) x.Name = "north")
        Dim south = world.Directions.Single(Function(x) x.Name = "south")
        Dim startingLocation = CreateLocation(worldData, world, "Starting Location")
        Dim nextLocation = CreateLocation(worldData, world, "Next Location")
        CreateRoute(worldData, world, startingLocation, north, nextLocation)
        CreateRoute(worldData, world, nextLocation, south, startingLocation)
        CreatePlayerCharacter(worldData, world, _name, startingLocation)
    End Sub

    Private Shared Sub CreateDirections(worldData As WorldData, world As IWorld)
        CreateDirection(worldData, world, "north")
        CreateDirection(worldData, world, "east")
        CreateDirection(worldData, world, "south")
        CreateDirection(worldData, world, "west")
    End Sub

    Private Shared Function CreatePlayerCharacter(worldData As WorldData, world As IWorld, name As String, location As ILocation) As ICharacter
        Dim result As ICharacter = CreateCharacter(worldData, world, name, location)
        world.PlayerCharacter = result
        result.AddMessage("Poof! The game begins!")
        Return result
    End Function
End Class
