using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var PinpadServiceName = "Upos2Agent";

            var UnregistrationCommands = new[]
            {
                @"sc delete Upos2Agent",
                @"regsvr32 /u D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /u D:\Programs\UPOS\SBRFCOM.dll"
            };

            var RegistrationCommands = new[]
            {
                @"D:\Programs\UPOS\Agent.exe /reg",
                @"regsvr32 D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 D:\Programs\UPOS\SBRFCOM.dll"
            };

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = PinpadServiceName,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };
            process.Start();

            StreamWriter pWriter = process.StandardInput;
            if (pWriter.BaseStream.CanWrite)
            {
                foreach (string command in UnregistrationCommands)
                {
                    pWriter.WriteLine(command);
                }
            }
        }

    }
}
