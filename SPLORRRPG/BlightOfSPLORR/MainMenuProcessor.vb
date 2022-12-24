Friend Module MainMenuProcessor
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = MainMenuTitle}
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If ConfirmProcessor.Run(ConfirmQuitTitle) Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
