open System

let rec downloading (downloader: Net.WebClient)=
    if downloader.IsBusy then 
        downloading downloader
    else Console.WriteLine("Done!")

[<EntryPoint>]
let main _ =
    let downloader = new Net.WebClient()

    downloader.DownloadFileAsync(Uri("https://aka.ms/win32-x64-user-stable"), "vscode.exe")

    Console.WriteLine("Downloading...")
    downloading downloader
    
    0 // return an exit code


    