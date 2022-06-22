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
            KillTasks(Process.GetProcessesByName("Surfshark"));

            void KillTasks(Process[] appsProcesses)
            {
                try
                {
                    foreach (Process app in appsProcesses)
                    {
                        app.Kill();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

    }
}
