Friend Class Character
    Inherits Thingie
    Implements ICharacter
    Sub New(worldData As WorldData, world As IWorld, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return _worldData.Characters(Id).Name
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(_worldData, World, _worldData.Characters(Id).LocationId)
        End Get
    End Property

    Public ReadOnly Property Messages As IEnumerable(Of String) Implements ICharacter.Messages
        Get
            If Not IsPlayerCharacter Then
                Return Array.Empty(Of String)
            End If
            Return _worldData.Messages
        End Get
    End Property

    Public Sub ClearMessages() Implements ICharacter.ClearMessages
        If IsPlayerCharacter Then
            _worldData.Messages.Clear()
        End If
    End Sub

    Private ReadOnly Property IsPlayerCharacter As Boolean
        Get
            Return _worldData.PlayerCharacterId.HasValue AndAlso _worldData.PlayerCharacterId.Value = Id
        End Get
    End Property

    Public ReadOnly Property AvailableVerbs As IEnumerable(Of IVerb) Implements ICharacter.AvailableVerbs
        Get
            Return World.Verbs.Where(Function(x) x.CanPerform(Me))
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, world As IWorld, name As String, location As ILocation) As ICharacter
        Dim characterId = worldData.NextCharacterId
        worldData.Characters(characterId) = New CharacterData With {.Name = name, .LocationId = location.Id}
        worldData.Locations(location.Id).CharacterIds.Add(characterId)
        Return New Character(worldData, world, characterId)
    End Function

    Public Sub AddMessage(message As String) Implements ICharacter.AddMessage
        If IsPlayerCharacter Then
            _worldData.Messages.Add(message)
        End If
    End Sub
End Class
