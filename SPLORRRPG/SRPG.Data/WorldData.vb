Public Class WorldData
    ReadOnly Property NextCharacterId As Integer
        Get
            Return If(Characters.Any, Characters.Keys.Max + 1, 1)
        End Get
    End Property
    ReadOnly Property NextLocationId As Integer
        Get
            Return If(Locations.Any, Locations.Keys.Max + 1, 1)
        End Get
    End Property
    Public Property Characters As New Dictionary(Of Integer, CharacterData)
    Public Property PlayerCharacterId As Integer?
    Public Property Locations As New Dictionary(Of Integer, LocationData)
End Class
