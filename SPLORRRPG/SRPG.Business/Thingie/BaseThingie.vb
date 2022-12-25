Friend Class BaseThingie
    Implements IBaseThingie
    Protected ReadOnly Property _worldData As WorldData
    Public ReadOnly Property World As IWorld Implements IBaseThingie.World
    Sub New(worldData As WorldData, world As IWorld)
        _worldData = worldData
        Me.World = world
    End Sub
End Class
