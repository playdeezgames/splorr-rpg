Friend Module GameMenuProcessor
    Friend Function Run(world As IWorld) As Boolean
        Do
            Dim prompt As New SelectionPrompt(Of String) With {.Title = GameMenuTitle}
            prompt.AddChoice(NeverMindText)
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    Return Not ConfirmProcessor.Run(ConfirmAbandonGameTitle)
                Case NeverMindText
                    Return True
            End Select
        Loop
    End Function
End Module
