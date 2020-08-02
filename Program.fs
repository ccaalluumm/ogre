open System

let rec checkDownloadComplete (downloader: Net.WebClient) = if downloader.IsBusy then checkDownloadComplete downloader

[<EntryPoint>]
let main _ =
    let downloader = new Net.WebClient()
    let programs = 
        Map.empty.
            Add("vscode.exe", "https://aka.ms/win32-x64-user-stable").
            Add("git.exe", "https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe").
            Add("spotify.exe", "https://download.scdn.co/SpotifySetup.exe");

    for program in programs do 
        downloader.DownloadFileAsync(Uri(program.Value), program.Key)
        checkDownloadComplete downloader

    Console.WriteLine("Downloads complete")
    
    0 // return an exit code
