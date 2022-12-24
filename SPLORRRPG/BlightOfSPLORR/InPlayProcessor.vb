Imports BOS.Business

Friend Module InPlayProcessor
    Friend Sub Run(world As IBOSWorld)
        Do
            AnsiConsole.Clear()
            'TODO: messages
            AnsiConsole.MarkupLine("Yer totally playing the game!") 'TODO: this line goes away
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If Not GameMenuProcessor.Run(world) Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
