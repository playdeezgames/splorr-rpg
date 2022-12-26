Public Class StatusVerb
    Implements IVerb

    Public ReadOnly Property ChoiceText As String Implements IVerb.ChoiceText
        Get
            Return StatusText
        End Get
    End Property

    Public Sub Perform(character As ICharacter) Implements IVerb.Perform
        If Not character.IsPlayerCharacter Then
            Return
        End If
        character.AddMessage("Status:")
        If character.HasStatus(StatusTypes.AliveStatus) Then
            character.AddMessage("Yer alive!")
        Else
            character.AddMessage("Yer dead!")
        End If
    End Sub

    Public Function CanPerform(character As ICharacter) As Boolean Implements IVerb.CanPerform
        Return character.IsPlayerCharacter
    End Function
End Class
