Public Class World
    Implements IWorld
    Private ReadOnly _worldData As WorldData
    Private ReadOnly _verbs As IReadOnlyList(Of IVerb)
    Protected Sub New(worldData As WorldData, verbs As IReadOnlyList(Of IVerb))
        _worldData = worldData
        _verbs = verbs
    End Sub

    Public Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            If _worldData.playerCharacterId.HasValue Then
                Return New Character(_worldData, Me, _worldData.PlayerCharacterId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                _worldData.PlayerCharacterId = Nothing
                Return
            End If
            _worldData.PlayerCharacterId = value.Id
        End Set
    End Property

    Public ReadOnly Property Directions As IEnumerable(Of IDirection) Implements IWorld.Directions
        Get
            Return _worldData.Directions.Keys.Select(Function(x) New Direction(_worldData, Me, x))
        End Get
    End Property

    Public ReadOnly Property Verbs As IEnumerable(Of IVerb) Implements IWorld.Verbs
        Get
            Return _verbs
        End Get
    End Property

    Public ReadOnly Property DirectionByName(name As String) As IDirection Implements IWorld.DirectionByName
        Get
            Return Directions.SingleOrDefault(Function(x) x.Name = name)
        End Get
    End Property

    Public Shared Function Create(name As String, verbs As IReadOnlyList(Of IVerb), populator As IPopulator) As IWorld
        Dim worldData = New WorldData
        Dim result = New World(worldData, verbs)
        populator.Populuate(worldData, result)
        Return result
    End Function
End Class
