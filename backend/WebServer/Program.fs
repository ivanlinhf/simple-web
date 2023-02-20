open Falco
open Falco.HostBuilder
open Falco.Routing

let corsHeader = Response.withHeaders ["Access-Control-Allow-Origin", "*"]

type Address = 
    { City: string 
      Street: string
      No: int }

webHost [||] {
    endpoints [
        get "/" (corsHeader 
                 >> Response.ofPlainText "Hello World")

        get "/address" (corsHeader
                        >> Response.ofJson { City = "SH"; Street = "West NJ"; No = 1129 })
    ]
}