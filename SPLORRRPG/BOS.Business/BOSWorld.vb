Public Class BOSWorld
    Inherits World
    Implements IBOSWorld

    Protected Sub New(worldData As SRPG.Data.WorldData)
        MyBase.New(worldData)
    End Sub

    Public Shared Function Create() As IBOSWorld
        Dim worldData As New WorldData
        Dim world As IBOSWorld = New BOSWorld(New WorldData)
        CreatePlayerCharacter()
        Return world
    End Function

    Private Shared Function CreatePlayerCharacter() As ICharacter
        Dim playerCharacter As ICharacter = BOSCharacter.Create()
        Return playerCharacter
    End Function
End Class
