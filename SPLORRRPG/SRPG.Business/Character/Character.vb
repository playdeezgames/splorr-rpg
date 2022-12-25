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

    Friend Shared Function Create(worldData As WorldData, name As String) As ICharacter
        Dim characterId = worldData.NextCharacterId
        worldData.Characters(characterId) = New CharacterData With {.Name = name}
        Return New Character(worldData, characterId)
    End Function
End Class
