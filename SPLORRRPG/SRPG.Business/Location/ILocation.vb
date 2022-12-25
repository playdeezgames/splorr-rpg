Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Name As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property Routes As IEnumerable(Of IRoute)
End Interface
