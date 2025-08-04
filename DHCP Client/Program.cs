using System;
using System.Diagnostics;
using System.Security.Principal;

class DhcpClient
{
    static void Main()
    {
        Console.WriteLine("Yeu cau cap lai dia chi IP moi...\n");

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
    static bool IsRunAsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}
