open System

let rec checkDownloadComplete (downloader: Net.WebClient) =
    if downloader.IsBusy then 
        checkDownloadComplete downloader

[<EntryPoint>]
let main _ =
    let downloader = new Net.WebClient()

    // TODO: This try block doesn't work, it just downloads nothing and doesn't raise an error if a bogus address is given
    try
        downloader.DownloadFileAsync(Uri("https://aka.ms/win32-x64-user-stable"), "vscode.exe")
    with ex ->
        printf "Error: failed to download Visual Studio Code from %s: %A" "https://aka.ms/win32-x64-user-stable" ex

    Console.WriteLine("Downloading Visual Studio Code...")
    checkDownloadComplete downloader

    //downloader.DownloadFileAsync(Uri("https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe"), "git.exe")
    //Console.WriteLine("Downloading git...")
    //checkDownloadComplete downloader

    downloader.DownloadFileAsync(Uri("https://download.mozilla.org/?product=firefox-stub&os=win&lang=en-US&attribution_code=c291cmNlPXd3dy5nb29nbGUuY29tJm1lZGl1bT1yZWZlcnJhbCZjYW1wYWlnbj0obm90IHNldCkmY29udGVudD0obm90IHNldCkmZXhwZXJpbWVudD0obm90IHNldCkmdmFyaWF0aW9uPShub3Qgc2V0KSZ1YT1jaHJvbWU.&attribution_sig=774d9972789664be6672b065e7f33820ea1cb1e7bafb5ea8c6b2a4f4bc207c70"), "firefox.exe")
    Console.WriteLine("Downloading Firefox...")
    checkDownloadComplete downloader
    
    //downloader.DownloadFileAsync(Uri("https://download.scdn.co/SpotifySetup.exe"), "spotify.exe") 
    //Console.WriteLine("Downloading Spotify...")
    //checkDownloadComplete downloader

    downloader.DownloadFileAsync(Uri("https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16#"), "visualstudio.exe")
    Console.WriteLine("Downloading Visual Studio...")
    checkDownloadComplete downloader

    Console.WriteLine("Downloads complete")
    
    0 // return an exit code
