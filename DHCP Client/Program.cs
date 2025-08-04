using System;
using System.Diagnostics;
using System.Security.Principal;

class DhcpClient
{
    static void Main()
    {
        ProcessStartInfo psi = new ProcessStartInfo("ipconfig", "/renew")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
    }
    }
}
