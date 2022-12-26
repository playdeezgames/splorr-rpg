Public Class World
    Implements IWorld
    Private ReadOnly _worldData As WorldData
    Private ReadOnly _verbs As IReadOnlyList(Of IVerb)
    Protected Sub New(worldData As WorldData, verbs As IReadOnlyList(Of IVerb))
        _worldData = worldData
        _verbs = verbs
    End Sub

    Public Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            If _worldData.playerCharacterId.HasValue Then
                Return New Character(_worldData, Me, _worldData.PlayerCharacterId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                _worldData.PlayerCharacterId = Nothing
                Return
            End If
            _worldData.PlayerCharacterId = value.Id
        End Set
    End Property

    Public ReadOnly Property Directions As IEnumerable(Of IDirection) Implements IWorld.Directions
        Get
            Return _worldData.Directions.Keys.Select(Function(x) New Direction(_worldData, Me, x))
        End Get
    End Property

    Public ReadOnly Property Verbs As IEnumerable(Of IVerb) Implements IWorld.Verbs
        Get
            Return _verbs
        End Get
    End Property

    Public Shared Function Create(name As String, verbs As IReadOnlyList(Of IVerb)) As IWorld
        Dim worldData = New WorldData
        Dim result = New World(worldData, verbs)

        CreateDirections(worldData, result)
        Dim north = result.Directions.Single(Function(x) x.Name = "north")
        Dim south = result.Directions.Single(Function(x) x.Name = "south")
        Dim startingLocation = CreateLocation(worldData, result, "Starting Location")
        Dim nextLocation = CreateLocation(worldData, result, "Next Location")
        Route.Create(worldData, result, startingLocation, north, nextLocation)
        Route.Create(worldData, result, nextLocation, south, startingLocation)
        CreatePlayerCharacter(worldData, result, name, startingLocation)

        Return result
    End Function

    Private Shared Sub CreateDirections(worldData As WorldData, world As IWorld)
        Direction.Create(worldData, world, "north")
        Direction.Create(worldData, world, "east")
        Direction.Create(worldData, world, "south")
        Direction.Create(worldData, world, "west")
    End Sub

    Private Shared Function CreateLocation(worldData As WorldData, world As IWorld, name As String) As ILocation
        Return Location.Create(worldData, world, name)
    End Function

    Private Shared Function CreatePlayerCharacter(worldData As WorldData, world As World, name As String, location As ILocation) As ICharacter
        Dim result As ICharacter = Character.Create(worldData, world, name, location)
        world.PlayerCharacter = result
        result.AddMessage("Poof! The game begins!")
        Return result
    End Function
End Class
