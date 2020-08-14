using System.Collections.Generic;

namespace ogre
{
    class Program
    {
        static void Main(string[] args)
        {
            var programs = new Dictionary<string, string>
            {
                { "vscode.exe", "https://aka.ms/win32-x64-user-stable" },
                { "chrome.exe", "https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7B278D23FF-2DDB-4E40-524D-973D5996950C%7D%26lang%3Den%26browser%3D3%26usagestats%3D0%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26ap%3Dx64-stable-statsdef_1%26installdataindex%3Dempty/chrome/install/ChromeStandaloneSetup64.exe" },
                { "git.exe", "https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe" },
                { "spotify.exe", "https://download.scdn.co/SpotifySetup.exe" },
                { "razer_synapse", "http://rzr.to/synapse-3-pc-download"},
                { "corsair_icue", "https://downloads.corsair.com/Files/CUE/iCUESetup_3.31.81_release.msi" },
                { "nvidia_geforce", "https://us.download.nvidia.com/GFE/GFEClient/3.20.4.14/GeForce_Experience_v3.20.4.14.exe" }
            };

            Downloader downloader = new Downloader();
            downloader.DownloadPrograms(programs);
        }
    }
}
