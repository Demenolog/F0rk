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

            var WmicPagefileIncreaseCommands = new[]
            {
                @"wmic computersystem set AutomaticManagedPagefile=False /NOINTERACTIVE",
                @"wmic pagefileset delete /NOINTERACTIVE",
                @"wmic pagefileset create name=""C:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE",
                @"wmic pagefileset create name=""D:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE"
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

            StreamWriter pWriter = process.StandardInput;
            if (pWriter.BaseStream.CanWrite)
            {
                foreach (string command in WmicPagefileIncreaseCommands)
                {
                    pWriter.WriteLine(command);
                }
            }

        }

    }
}