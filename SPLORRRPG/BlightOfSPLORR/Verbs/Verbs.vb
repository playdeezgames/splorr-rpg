Friend Module Verbs
    Friend AllVerbs As IReadOnlyList(Of IVerb) =
        New List(Of IVerb) From
        {
            New MoveVerb,
            New StatusVerb
        }
End Module
