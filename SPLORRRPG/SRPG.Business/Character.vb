Friend Class Character
    Inherits Thingie
    Implements ICharacter
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub
    Friend Shared Function Create(worldData As WorldData) As ICharacter
        Dim characterId = worldData.NextCharacterId
        worldData.Characters(characterId) = New CharacterData
        Return New Character(worldData, characterId)
    End Function
End Class
