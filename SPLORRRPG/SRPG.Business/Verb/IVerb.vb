Public Interface IVerb
    ReadOnly Property ChoiceText As String
    Function CanPerform(character As ICharacter) As Boolean
End Interface
