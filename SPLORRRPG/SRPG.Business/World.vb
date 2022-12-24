Public MustInherit Class World
    Implements IWorld
    Private ReadOnly _worldData As WorldData
    Protected Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
End Class
