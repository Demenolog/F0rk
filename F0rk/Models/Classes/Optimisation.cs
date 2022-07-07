using System;
using System.Diagnostics;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] WmicPagefileIncreaseCommands;
        private static readonly string[] CmdPinpadRegistration;
        private static readonly string[] CmdPinpadUnregistration;

        static Optimisation()
        {
            WmicPagefileIncreaseCommands = new[]
            {
                @"wmic computersystem set AutomaticManagedPagefile=False /NOINTERACTIVE",
                @"wmic pagefileset delete /NOINTERACTIVE",
                @"wmic pagefileset create name=""C:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE",
                @"wmic pagefileset create name=""D:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE"
            };
        }

        public static void IncreasePagefile()
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false
                    }
                };

                process.Start();

                var pWriter = process.StandardInput;

                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (string command in WmicPagefileIncreaseCommands)
                    {
                        pWriter.WriteLine("/k " + command);
                    }
                }

                pWriter.Close();

                pWriter.Dispose();
                process.Dispose();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}