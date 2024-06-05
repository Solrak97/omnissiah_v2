open System.Threading.Tasks
open DSharpPlus
open DSharpPlus.EventArgs


module Omnissiah =
    let CreateClient () =
        let config =
            DiscordConfiguration(
                Token = Config.DISCORD_TOKEN,
                TokenType = TokenType.Bot,
                Intents = (DiscordIntents.AllUnprivileged ||| DiscordIntents.MessageContents)
            )

        new DiscordClient(config)


    let onMessageCreated (e: MessageCreateEventArgs) =
        async {
                if e.Message.Content.ToLower().StartsWith("ping") then
                    e.Message.RespondAsync("Gatto se la come") |> ignore
        }


    let RunAsync () =
        async {
            let discord = CreateClient()

            discord.add_MessageCreated (fun s e -> onMessageCreated e |> Async.StartAsTask :> Task)

            do! discord.ConnectAsync() |> Async.AwaitTask
            do! Task.Delay(-1) |> Async.AwaitTask


        }


    [<EntryPoint>]
    let main args =

        printfn "Starting"
        RunAsync() |> Async.RunSynchronously
        printfn "Gatto se la come"

        0
