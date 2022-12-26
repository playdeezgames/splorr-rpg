Friend Module MoveProcessor
    Friend Sub Run(character As ICharacter)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = MoveMenuTitle}
        prompt.AddChoice(NeverMindText)
        Dim table = character.Location.Routes.ToDictionary(Function(x) x.Direction.Name, Function(x) x.ToLocation)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                'do nothing!
            Case Else
                character.Location = table(answer)
        End Select
    End Sub
End Module
