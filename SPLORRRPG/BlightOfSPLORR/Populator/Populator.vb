Imports SRPG.Data

Friend Class Populator
    Inherits BasePopulator
    Private ReadOnly _name As String
    Sub New(name As String)
        _name = name
    End Sub

    Const NorthDirection = "north"
    Const EastDirection = "east"
    Const SouthDirection = "south"
    Const WestDirection = "west"

    Public Overrides Sub Populuate(worldData As WorldData, world As IWorld)
        CreateDirections(worldData, world)
        Dim startingLocation = CreateMaze(worldData, world)
        CreatePlayerCharacter(worldData, world, _name, startingLocation)
    End Sub

    Private Shared Function CreateMaze(worldData As WorldData, world As IWorld) As ILocation
        Const MazeColumns = 4
        Const MazeRows = 4
        Dim mazeDirections = New Dictionary(Of String, MazeDirection(Of String)) From
                                        {
                                            {NorthDirection, New MazeDirection(Of String)(SouthDirection, 0, -1)},
                                            {EastDirection, New MazeDirection(Of String)(WestDirection, 1, 0)},
                                            {SouthDirection, New MazeDirection(Of String)(NorthDirection, 0, 1)},
                                            {WestDirection, New MazeDirection(Of String)(EastDirection, -1, 0)}
                                        }
        Dim maze As New Maze(Of String)(MazeColumns, MazeRows, mazeDirections)
        maze.Generate()
        Dim locations(MazeColumns - 1, MazeRows - 1) As ILocation
        For mazeColumn = 0 To MazeColumns - 1
            For mazeRow = 0 To MazeRows - 1
                locations(mazeColumn, mazeRow) = CreateLocation(worldData, world, $"({mazeColumn},{mazeRow})")
            Next
        Next
        For mazeColumn = 0 To MazeColumns - 1
            For mazeRow = 0 To MazeRows - 1
                Dim fromLocation = locations(mazeColumn, mazeRow)
                For Each direction In mazeDirections.Keys
                    Dim door = maze.GetCell(mazeColumn, mazeRow).GetDoor(direction)
                    If door IsNot Nothing Then
                        If door.Open Then
                            Dim toLocation = locations(mazeColumn + CInt(mazeDirections(direction).DeltaX), mazeRow + CInt(mazeDirections(direction).DeltaY))
                            CreateRoute(worldData, world, fromLocation, world.DirectionByName(direction), toLocation)
                        End If
                    End If
                Next
            Next
        Next
        Return locations(0, 0)
    End Function

    Private Shared Sub CreateDirections(worldData As WorldData, world As IWorld)
        CreateDirection(worldData, world, NorthDirection)
        CreateDirection(worldData, world, EastDirection)
        CreateDirection(worldData, world, SouthDirection)
        CreateDirection(worldData, world, WestDirection)
    End Sub

    Private Shared Function CreatePlayerCharacter(worldData As WorldData, world As IWorld, name As String, location As ILocation) As ICharacter
        Dim result As ICharacter = CreateCharacter(worldData, world, name, location)
        world.PlayerCharacter = result
        result.AddMessage("Poof! The game begins!")
        Return result
    End Function
End Class
