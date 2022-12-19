module WordCalculateModule

let private lowercase (x:string) = x.ToLower()

let private updateMapWithKey (map: Map<string,int>, key: string, value: int) = map.Remove(key).Add(key, value)

let private getNewWordCount(item: Option<int>) = 
    match item.IsSome with
    | true -> item.Value + 1
    | false -> 0;

let private checkItem (map: Map<string,int>, item: string) =
    match map.ContainsKey item with
    | true -> updateMapWithKey(map, item, getNewWordCount(map.TryFind item))
    | false -> updateMapWithKey( map, item, 1)
         

let calculateWordsCount(input:string, map: Map<string,int>) =
    let wordList = TextHelper.stringToWordList input |> List.map lowercase
    let rec getMapWithWordsCount(ws, acc) = 
                        match ws with
                        | [] -> acc
                        | h::t -> getMapWithWordsCount(t, checkItem (acc, h))
    getMapWithWordsCount(wordList, map)
