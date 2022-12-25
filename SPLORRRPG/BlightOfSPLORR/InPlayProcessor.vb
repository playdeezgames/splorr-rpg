Friend Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim character = world.PlayerCharacter
            ShowMessages(character)
            AnsiConsole.MarkupLine($"Name: {character.Name}")
            AnsiConsole.MarkupLine($"Location: {character.Location.Name}")
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

    Private Sub ShowMessages(character As ICharacter)
        For Each message In character.Messages
            AnsiConsole.MarkupLine(message)
        Next
        character.ClearMessages()
    End Sub
End Module
