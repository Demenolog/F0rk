using System.IO;
using F0rk.Models.Methods.TasksHandler;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string PathToTimeSynchronizationDirectory;
        private static readonly string[] TimeSynchronizationBatchText;
        private static readonly string TimeSynchronizationCommandForCmd;
        private static readonly string[] WmicPagefileIncreaseCommands;

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

            TimeSynchronizationBatchText = new[]
            {
                @"sc start W32Time",
                @"sc config W32Time start=auto",
                @"W32tm.exe /resync"
            };

            TimeSynchronizationCommandForCmd = @"SCHTASKS /Create /SC ONSTART /TN TimeSynchronization /TR " +
                                               @"C:\Windows\Svyaznoy\TimeSynchronization\TimeSynchronization.bat";

            PathToTimeSynchronizationDirectory = @"C:\Windows\Svyaznoy\TimeSynchronization";
        }

        public static string[] GetWmicPagefileIncreaseCommands => WmicPagefileIncreaseCommands;

        public static void TimeSynchronization()
        {
            Directory.CreateDirectory(PathToTimeSynchronizationDirectory);

            FileInfo fi = new FileInfo(PathToTimeSynchronizationDirectory + "\\TimeSynchronizationBatchText.bat");

            using (StreamWriter sw = fi.CreateText())
            {
                foreach (string command in TimeSynchronizationBatchText)
                {
                    sw.WriteLine(command);
                }
            }

            TasksHandler.StartTaskWithCommand("cmd",TimeSynchronizationBatchText);

            TasksHandler.StartTaskWithCommand("cmd", TimeSynchronizationCommandForCmd);
        }
    }
}