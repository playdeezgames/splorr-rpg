Friend Class MoveVerb
    Implements IVerb

    Public ReadOnly Property ChoiceText As String Implements IVerb.ChoiceText
        Get
            Return MoveText
        End Get
    End Property

    Public Sub Perform(character As ICharacter) Implements IVerb.Perform
        If Not character.IsPlayerCharacter Then
            Throw New NotImplementedException
        End If
        MoveProcessor.Run(character)
    End Sub

    Public Function CanPerform(character As ICharacter) As Boolean Implements IVerb.CanPerform
        Return character.Location.Routes.Any
    End Function
End Class
