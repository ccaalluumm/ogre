using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ogre
{
    class Downloader
    {
        /// <summary>
        /// Iterates through the programs dictionary and uses a web client to download each one to the downloads directory.
        /// </summary>
        /// <param name="programs">Dictionary mapping program names to their respective download links</param>
        public void DownloadPrograms(Dictionary<string, string> programs)
        {
            var downloads_folder = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString();

            // Create a webclient object and register an event handler for download progress
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(PrintDownloadProgress);
            
            foreach(var program in programs)
            {
                Console.WriteLine("Downloading " + program.Key);

                downloader.DownloadFileAsync(new Uri(program.Value), downloads_folder + "\\" + program.Key);

                while (downloader.IsBusy) { };

                // Sleep to ensure that the downloader fully finishes, otherwise the new line gets printed prematurely
                Thread.Sleep(10);
                Console.Write('\n');
            }
        }

        private void PrintDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            WriteProgressBar(e.ProgressPercentage, true);
        }

        /// <summary>
        /// Prints a progress bar to the console, using math to print a ■ character for every 10% of the download completed.
        /// Although refactored to suit this programs needs, full credit to this original design goes to Honey The Codewitch (https://www.codeproject.com/Members/code-witch)
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="update"></param>
        private static void WriteProgressBar(int percent, bool update = false)
        {
            const char block = '■';
            const char space = ' ';
            const string back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
            string completed = new string(block, (int)Math.Floor((float)percent / 10));
            string uncompleted = new string(space, 10 - (int)Math.Floor((float)percent / 10));

            if (update)
            {
                Console.Write(back + "[" + completed + uncompleted + "]" + " {0,3:##0}%", percent);
            }
        }
    }
}
