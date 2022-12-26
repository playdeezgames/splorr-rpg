Public MustInherit Class BasePopulator
    Implements IPopulator

    Public MustOverride Sub Populuate(worldData As WorldData, world As IWorld) Implements IPopulator.Populuate
    Protected Shared Function CreateRoute(worldData As WorldData, world As IWorld, fromLocation As ILocation, direction As IDirection, toLocation As ILocation) As IRoute
        Return Route.Create(worldData, world, fromLocation, direction, toLocation)
    End Function
    Protected Shared Function CreateDirection(worldData As WorldData, world As IWorld, name As String) As IDirection
        Return Direction.Create(worldData, world, name)
    End Function
    Protected Shared Function CreateLocation(worldData As WorldData, world As IWorld, name As String) As ILocation
        Return Location.Create(worldData, world, name)
    End Function
    Protected Shared Function CreateCharacter(worldData As WorldData, world As IWorld, name As String, location As ILocation) As ICharacter
        Return Character.Create(worldData, world, name, location)
    End Function
End Class
