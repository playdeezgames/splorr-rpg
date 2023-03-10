Friend Module MainMenuProcessor
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
            prompt.AddChoice(StartGameText)
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If ConfirmProcessor.Run(ConfirmQuitTitle) Then
                        Exit Do
                    End If
                Case StartGameText
                    StartGame()
            End Select
        Loop
    End Sub

    Private Sub StartGame()
        Dim name = AnsiConsole.Ask(CharacterNamePrompt, CharacterNameDefault)
        Dim world = SRPG.Business.World.Create(name, AllVerbs, New Populator(name))
        InPlayProcessor.Run(world)
    End Sub
End Module
