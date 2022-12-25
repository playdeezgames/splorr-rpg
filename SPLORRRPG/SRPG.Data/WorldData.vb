Public Class WorldData
    ReadOnly Property NextCharacterId As Integer
        Get
            Throw New NotImplementedException
        End Get
    End Property
    Public Property Characters As New Dictionary(Of Integer, CharacterData)
End Class
