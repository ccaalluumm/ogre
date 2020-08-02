open System

let rec checkDownloadComplete (downloader: Net.WebClient) = if downloader.IsBusy then checkDownloadComplete downloader

let downloadPrograms (programs: Map<_,_>) =
    use downloader = new Net.WebClient()
    for program in programs do
        Console.WriteLine("Downloading " + program.Key)
        downloader.DownloadFileAsync(Uri(program.Value), program.Key)
        checkDownloadComplete downloader

let startInstallers (programs: Map<_,_>) =
    for program in programs do
        try
            System.Diagnostics.Process.Start(program.Key) |> ignore
        with
            | :? System.ComponentModel.Win32Exception as ex -> Console.WriteLine("Exception: " + ex.Message);

[<EntryPoint>]
let main _ =
    let programs = 
        Map.empty.
            Add("vscode.exe", "https://aka.ms/win32-x64-user-stable").
            Add("docker.exe", "https://download.docker.com/win/stable/Docker%20Desktop%20Installer.exe").
            Add("chrome.exe", "https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7B278D23FF-2DDB-4E40-524D-973D5996950C%7D%26lang%3Den%26browser%3D3%26usagestats%3D0%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26ap%3Dx64-stable-statsdef_1%26installdataindex%3Dempty/chrome/install/ChromeStandaloneSetup64.exe").
            Add("git.exe", "https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe").
            Add("spotify.exe", "https://download.scdn.co/SpotifySetup.exe");

    downloadPrograms programs

    startInstallers programs

    Console.WriteLine("Downloads complete")

    0
