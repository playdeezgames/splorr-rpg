Public Class World
    Implements IWorld
    Private ReadOnly _worldData As WorldData
    Private ReadOnly _playerCharacterId As Integer?
    Protected Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub

    Public ReadOnly Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            If _playerCharacterId.HasValue Then
                Return New Character(_worldData, _playerCharacterId.Value)
            End If
            Return Nothing
        End Get
    End Property

    Public Shared Function Create() As IWorld
        Dim worldData = New WorldData
        Dim result = New World(worldData)
        Return result
    End Function
End Class
