Public Interface IVerb
    ReadOnly Property ChoiceText As String
    Function CanPerform(character As ICharacter) As Boolean
    Sub Perform(character As ICharacter)
End Interface
