using System.IO;
using System.Text;
using F0rk.Models.Methods.TasksHandler;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Windows\Svyaznoy\TimeSynchronization";

            string[] TimeSynchronization = new[]
            {
                @"sc start W32Time",
                @"sc config W32Time start=auto",
                @"W32tm.exe /resync"
            };

            string[] TimeSynchronizationCommandForCmd = new[]
            {
                    @"SCHTASKS /Create /SC ONSTART /TN TimeSynchronization /TR C:\Windows\Svyaznoy\TimeSynchronization\TimeSynchronization.bat"
            };

            Directory.CreateDirectory(path);

            FileInfo fi = new FileInfo(path + "\\TimeSynchronization.bat");

            using (var fs = fi.CreateText())
            {
                foreach (string command in TimeSynchronization)
                {
                    fs.WriteLine(command);
                }
            }

            TasksHandler.StartTaskWithCommands("cmd", TimeSynchronization);

            TasksHandler.StartTaskWithCommands("cmd", TimeSynchronizationCommandForCmd);
        }
    }
}