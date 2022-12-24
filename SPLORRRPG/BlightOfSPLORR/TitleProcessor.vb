Friend Module TitleProcessor
    Friend Sub Run()
        Console.Title = "Blight of SPLORR!!"
        AnsiConsole.Clear()
        Dim figlet As New FigletText("Blight of SPLORR!!") With {.Color = Color.Red, .Alignment = Justify.Center}
        AnsiConsole.Write(figlet)
        OkPrompt()
        MainMenuProcessor.Run()
    End Sub
End Module
