open System

[<EntryPoint>]
let main argv =
    let res = WordCalculateModule.calculateWordsCount("Go do that thing that you do so well", Map.empty)
    printfn "result %A" res
    1


