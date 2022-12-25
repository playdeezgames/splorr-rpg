Friend Class MoveVerb
    Implements IVerb

    Public ReadOnly Property ChoiceText As String Implements IVerb.ChoiceText
        Get
            Return MoveText
        End Get
    End Property

    Public Function CanPerform(character As ICharacter) As Boolean Implements IVerb.CanPerform
        Return character.Location.Routes.Any
    End Function
End Class
