Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Name As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
End Interface
