module Config

open System

let get key defaultArg = 
    DotEnv.init
    match Environment.GetEnvironmentVariable key with
    | null -> defaultArg
    | _ ->  Environment.GetEnvironmentVariable key 
    

let DISCORD_TOKEN = get "DISCORD_TOKEN" "DEFAULT_TOKEN_VALUE"




