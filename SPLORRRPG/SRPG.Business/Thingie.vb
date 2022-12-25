Friend MustInherit Class Thingie
    Implements IThingie
    Protected ReadOnly Property _worldData As WorldData
    Public ReadOnly Property Id As Integer Implements IThingie.Id
    Sub New(worldData As WorldData, id As Integer)
        _worldData = worldData
        Me.Id = id
    End Sub
End Class
