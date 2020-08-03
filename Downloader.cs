using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ogre
{
    class Downloader
    {
        public void DownloadPrograms(Dictionary<string, string> programs)
        {
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(PrintDownloadProgress);
            
            foreach(var program in programs)
            {
                Console.WriteLine("Downloading " + program.Key);
                downloader.DownloadFileAsync(new Uri(program.Value), program.Key);
                
                while (downloader.IsBusy) { };
            }
        }

        private void PrintDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("{0} downloaded {1} of {2} megabytes. {3}% complete...",
                (string)e.UserState,
                e.BytesReceived / 1024,
                e.TotalBytesToReceive / 1024,
                e.ProgressPercentage);
        }
    }
}
