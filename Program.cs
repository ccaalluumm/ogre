using System.Collections.Generic;

namespace ogre
{
    class Program
    {
        static void Main()
        {
            var programs = new Dictionary<string, string>
            {
                { "vscode.exe", "https://aka.ms/win32-x64-user-stable" },
                { "git.exe", "https://github.com/git-for-windows/git/releases/download/v2.28.0.windows.1/Git-2.28.0-64-bit.exe" },
                { "spotify.exe", "https://download.scdn.co/SpotifySetup.exe" },
                { "razer_synapse", "http://rzr.to/synapse-3-pc-download"},
                { "corsair_icue", "https://downloads.corsair.com/Files/CUE/iCUESetup_3.31.81_release.msi" },
                { "nvidia_geforce", "https://us.download.nvidia.com/GFE/GFEClient/3.20.4.14/GeForce_Experience_v3.20.4.14.exe" },
                { "nodejs.exe", "https://nodejs.org/dist/v12.18.3/node-v12.18.3-x64.msi" },
                { "chocolatey.ps1", "https://chocolatey.org/install.ps1" }
            };

            Downloader downloader = new Downloader();

            downloader.DownloadPrograms(programs);

            // Install Chocolately package manager

        }
    }
}
