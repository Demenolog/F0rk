using System.Diagnostics;
using System.IO;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] WmicPagefileIncreaseCommands;

        static Optimisation()
        {
            WmicPagefileIncreaseCommands = new[]
            {
                @"computersystem set AutomaticManagedPagefile=False",
                @"pagefileset delete",
                @"pagefileset create name=""C:\\pagefile.sys""",
                @"pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546",
                @"pagefileset create name=""D:\\pagefile.sys""",
                @"pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546"
            };
        }

        public static void IncreasePagefile()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };
            process.Start();

            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (string command in WmicPagefileIncreaseCommands)
                    {
                        pWriter.WriteLine(command + " /NOINTERACTIVE");
                    }
                }
            }
        }
    }
}