Public Class WorldData
    ReadOnly Property NextCharacterId As Integer
        Get
            Return If(Characters.Any, Characters.Keys.Max + 1, 0)
        End Get
    End Property
    Public Property Characters As New Dictionary(Of Integer, CharacterData)
    Public Property PlayerCharacterId As Integer?
End Class
