Public Interface ICharacter
    Inherits IThingie
    ReadOnly Property Name As String
    Property Location As ILocation
    ReadOnly Property Messages As IEnumerable(Of String)
    Sub ClearMessages()
    Sub AddMessage(message As String)
    Sub AddStatus(statusType As String)
    ReadOnly Property AvailableVerbs As IEnumerable(Of IVerb)
    ReadOnly Property IsPlayerCharacter As Boolean
    ReadOnly Property HasStatus(statusType As String) As Boolean
End Interface
