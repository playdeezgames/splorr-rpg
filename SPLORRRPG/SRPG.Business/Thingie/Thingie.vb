Friend MustInherit Class Thingie
    Inherits BaseThingie
    Implements IThingie
    Public ReadOnly Property Id As Integer Implements IThingie.Id
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData)
        Me.Id = id
    End Sub
End Class
