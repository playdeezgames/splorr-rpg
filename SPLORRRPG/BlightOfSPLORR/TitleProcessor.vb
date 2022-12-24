Friend Module TitleProcessor
    Friend Sub Run()
        Console.Title = GameTitle
        AnsiConsole.Clear()
        Dim figlet As New FigletText(GameTitle) With {.Color = Color.Red, .Alignment = Justify.Center}
        AnsiConsole.Write(figlet)
        OkPrompt()
        MainMenuProcessor.Run()
    End Sub
End Module
