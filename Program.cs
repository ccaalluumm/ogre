using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Net;

namespace ogre
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Downloading Chocolatey");

            WebClient client = new WebClient();
                
            string chocolatey_install_script = client.DownloadString("https://chocolatey.org/install.ps1");

            PowerShell ps = PowerShell.Create();

            //ps.AddCommand("Set-ExecutionPolicy").AddParameter("AllSigned").Invoke();

            ps.AddScript(chocolatey_install_script).Invoke();

            ps.AddCommand("choco").AddParameter("?").Invoke();

            // Install Chocolately package manager

        }
    }
}
