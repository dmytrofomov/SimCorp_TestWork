module TextHelper

let stringToWordList s =
    let split s =
        let rec scan (s:string) i =
            if s.Length = 0 then []
            elif s.[i] = ' ' && i = 0 then scan s.[i+1..] 0
            elif s.[i] = ' ' then [s.[..i-1]; s.[i+1..]]
            elif i = (s.Length - 1) then [s]
            else scan s (i+1)
        scan s 0
    let rec fold acc s =
        match split s with
        | [x] -> acc @ [x]
        | [h;t] -> fold (acc @ [h]) t
        | _ -> acc
    fold [] s
