Public Class BOSWorld
    Inherits World
    Implements IBOSWorld

    Protected Sub New(worldData As SRPG.Data.WorldData)
        MyBase.New(worldData)
    End Sub

    Public Shared Function Create() As IBOSWorld
        Return New BOSWorld(New SRPG.Data.WorldData)
    End Function
End Class
