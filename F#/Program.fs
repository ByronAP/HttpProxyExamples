open System
open System.Net
open System.IO

[<EntryPoint>]
let main argv = 
    let proxyAddress = "http://rotate.proxy.services"
    let proxyPort = 8989
    let proxyUsername = "Username"
    let proxyPassword = "Password"
    let url = "https://echo.proxy.services"

    let creds = new NetworkCredential(proxyUsername, proxyPassword)
    let proxy = new WebProxy()
    proxy.Address <- new Uri(proxyAddress + ":" + proxyPort.ToString())
    proxy.Credentials <- creds

    let request = WebRequest.Create(url)
    request.Proxy <- proxy

    let responseStream =  request.GetResponse().GetResponseStream()
    let responseReader = new StreamReader(responseStream)
    let responseData = responseReader.ReadToEnd()

    printf "%s" responseData

    0
