Public Interface IWorld
    Property PlayerCharacter As ICharacter
    ReadOnly Property Directions As IEnumerable(Of IDirection)
    ReadOnly Property Verbs As IEnumerable(Of IVerb)
End Interface
