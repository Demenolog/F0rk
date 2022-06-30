using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var PinpadServiceName = "Upos2Agent";

            var UnregistrationCommands = new[]
            {
                @"@echo off",
                @"sc delete Upos2Agent",
                @"regsvr32 /u /s D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /u /s D:\Programs\UPOS\SBRFCOM.dll"
            };

            var RegistrationCommands = new[]
            {
                @"@echo off",
                @"D:\Programs\UPOS\Agent.exe /reg",
                @"regsvr32 /s D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /s D:\Programs\UPOS\SBRFCOM.dll"
            };

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };

            process.Start();
            //ServiceStop("Upos2Agent");

            StreamWriter pWriter = process.StandardInput;
            if (pWriter.BaseStream.CanWrite)
            {
                foreach (string command in RegistrationCommands)
                {
                    pWriter.WriteLine(command);
                }
            }

            ServiceStart("Upos2Agent");
        }

        public static void ServiceStop(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void ServiceStart(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}