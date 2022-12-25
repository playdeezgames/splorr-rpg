Friend Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim character = world.PlayerCharacter
            'TODO: messages
            AnsiConsole.MarkupLine($"{character.Name} exists!")
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
