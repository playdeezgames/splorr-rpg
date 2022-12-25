Friend Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim character = world.PlayerCharacter
            ShowMessages(character)
            ShowLocation(character)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatTitle}
            prompt.AddChoice(GameMenuText)
            'TODO: add all of the verbs that are possible for the character at this time
            Dim availableVerbs = character.AvailableVerbs
            For Each availableVerb In availableVerbs
                prompt.AddChoice(availableVerb.ChoiceText)
            Next
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If Not GameMenuProcessor.Run(world) Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub

    Private Sub ShowLocation(character As ICharacter)
        AnsiConsole.MarkupLine($"Name: {character.Name}")
        AnsiConsole.MarkupLine($"Location: {character.Location.Name}")
        Dim routes = character.Location.Routes
        If routes.Any Then
            AnsiConsole.MarkupLine("Exits:")
            For Each route In routes
                AnsiConsole.MarkupLine($"- {route.Direction.Name}")
            Next
        End If
    End Sub

    Private Sub ShowMessages(character As ICharacter)
        For Each message In character.Messages
            AnsiConsole.MarkupLine(message)
        Next
        character.ClearMessages()
    End Sub
End Module
