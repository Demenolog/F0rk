using System.IO;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
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

            TimeSynchronizationCommandForCmd = @"SCHTASKS /Create /SC ONSTART /TN TimeSynchronization /TR C:\Windows\Svyaznoy\TimeSynchronization\TimeSynchronization.bat";
        }

        public static string[] GetTimeSynchronizationBatchText => TimeSynchronizationBatchText;
        public static string GetTimeSynchronizationCommandForCmd => TimeSynchronizationCommandForCmd;
        public static string[] GetWmicPagefileIncreaseCommands => WmicPagefileIncreaseCommands;

        public static void CreateTaskForTaskScheduler()
        {
            string path = @"";
            Directory.CreateDirectory(path);

            FileInfo fi = new FileInfo(path + "\\TimeSynchronizationBatchText.bat");
            using (StreamWriter sw = fi.CreateText())
            {
                foreach (string command in TimeSynchronizationBatchText)
                {
                    sw.WriteLine(command);
                }
            }

            fi.Create();
        }
    }
}