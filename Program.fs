open System

let rec checkDownloadComplete(downloader: Net.WebClient)=
    if downloader.IsBusy then 
        checkDownloadComplete downloader

[<EntryPoint>]
let main _ =
    let downloader = new Net.WebClient()

    downloader.DownloadFileAsync(Uri("https://aka.ms/win32-x64-user-stable"), "vscode.exe")

    Console.WriteLine("Downloading Visual Studio Code...")
    checkDownloadComplete downloader
    
    
    downloader.DownloadFileAsync(Uri("https://download.scdn.co/SpotifySetup.exe"), "spotify.exe") 
    Console.WriteLine("Downloading Spotify...")
    checkDownloadComplete downloader

    Console.WriteLine("Downloads complete")
    
    0 // return an exit code


    