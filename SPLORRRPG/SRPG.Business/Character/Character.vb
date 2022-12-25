Friend Class Character
    Inherits Thingie
    Implements ICharacter
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub

    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return _worldData.Characters(Id).Name
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(_worldData, _worldData.Characters(Id).LocationId)
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, name As String, location As ILocation) As ICharacter
        Dim characterId = worldData.NextCharacterId
        worldData.Characters(characterId) = New CharacterData With {.Name = name, .LocationId = location.Id}
        worldData.Locations(location.Id).CharacterIds.Add(characterId)
        Return New Character(worldData, characterId)
    End Function
End Class
