Public Interface IWorld
    Property PlayerCharacter As ICharacter
    ReadOnly Property Directions As IEnumerable(Of IDirection)
End Interface
