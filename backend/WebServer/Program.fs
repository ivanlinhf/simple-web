open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open SixLabors.ImageSharp
open SixLabors.ImageSharp.PixelFormats
open System.IO

let setCorsHeader = setHttpHeader "Access-Control-Allow-Origin" "*"

let setImgHeader = setHttpHeader "Content-Type" "image/png"

let hello () = "Hello World"

let getImage () =
    use stream = new MemoryStream()
    use image = new Image<Rgba32>(64, 64)
    [| 0..63 |] |> Array.iter (fun x -> image[33, x] <- Rgba32(0.1f, 0.5f, 0.3f))
    image.SaveAsPng stream
    stream.ToArray()

let webApp =
    choose
        [ route "/" >=> setCorsHeader >=> warbler (fun _ -> hello () |> text)

          route "/img"
          >=> setCorsHeader
          >=> setImgHeader
          >=> warbler (fun _ -> getImage () |> setBody) ]

let configureApp (app: IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services: IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun webHostBuilder ->
            webHostBuilder.Configure(configureApp).ConfigureServices(configureServices)
            |> ignore)
        .Build()
        .Run()

    0
