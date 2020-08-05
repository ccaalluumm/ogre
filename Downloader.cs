using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

                // Sleep to ensure that the downloader fully finishes, otherwise the new line gets printed prematurely
                Thread.Sleep(10);
                Console.Write('\n');
            }
        }

        private void PrintDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            WriteProgressBar(e.ProgressPercentage, true);
            Thread.Sleep(50);
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
