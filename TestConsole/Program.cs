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
            string[] commands = new[]
            {
                @"computersystem set AutomaticManagedPagefile=False",
                @"pagefileset delete",
                @"pagefileset create name=""C:\\pagefile.sys""",
                @"pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546",
                @"pagefileset create name=""D:\\pagefile.sys""",
                @"pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546"
            };

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
                    foreach (string command in commands)
                    {
                        pWriter.WriteLine(command + " /NOINTERACTIVE");
                        //pWriter.WriteLine();
                    }
                }

            }
        }

    }
}
