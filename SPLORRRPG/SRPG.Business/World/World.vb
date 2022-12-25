Public Class World
    Implements IWorld
    Private ReadOnly _worldData As WorldData
    Protected Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub

    Public Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            If _worldData.playerCharacterId.HasValue Then
                Return New Character(_worldData, _worldData.PlayerCharacterId.Value)
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

    Public Shared Function Create(name As String) As IWorld
        Dim worldData = New WorldData
        Dim result = New World(worldData)
        Dim startingLocation = CreateLocation(worldData, "Starting Location")
        CreatePlayerCharacter(worldData, result, name)
        Return result
    End Function

    Private Shared Function CreateLocation(worldData As WorldData, name As String) As ILocation
        Return Location.Create(worldData, name)
    End Function

    Private Shared Function CreatePlayerCharacter(worldData As WorldData, world As World, name As String) As ICharacter
        Dim result As ICharacter = Character.Create(worldData, name)
        world.PlayerCharacter = result
        Return result
    End Function
End Class
