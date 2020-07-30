open System

[<EntryPoint>]
let main _ =
    let downloader = new Net.WebClient()
    //downloader.Headers.Add("User-Agent", "Mozilla/5.0")

    downloader.DownloadFileAsync(Uri("https://aka.ms/win32-x64-user-stable"), "vscode.exe")

    while downloader.IsBusy do
        printf "Downloading\n"
    
    0 // return an exit code


    