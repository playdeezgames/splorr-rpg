Module ConfirmProcessor
    Friend Function Run(title As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = title}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
