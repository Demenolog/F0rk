using System.Diagnostics;

namespace F0rk.Classes
{
    internal static class DiskD
    {
        private static readonly string[] EmailTasksNames;

        private static readonly string[] PathsesToCompleteClean;

        private static readonly string[] PathsToSubfoldersClean;

        private static readonly string PathToEmails;

        private static readonly string[] Services;

        private static readonly string[] Tasks;

        static DiskD()
        {
            EmailTasksNames = new[]
            {
                "iexplore",
                "wlmail"
            };

            PathsesToCompleteClean = new[]
            {
                @"C:\Windows\ccmsetup",
                @"C:\Windows\Temp",
                @"C:\Windows\ccmcache",
                @"D:\Profile\cms\AppData\Local\Temp"
            };

            PathsToSubfoldersClean = new[]
            {
                @"C:\Windows\SoftwareDistribution",
                @"C:\Windows\PCHEALTH",
                @"C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow\Microsoft\CryptnetUrlCache",
                @"C:\Windows\System32\config\systemprofile\AppData\LocalLow\Microsoft\CryptnetUrlCache",
                @"D:\Profile\cms\AppData\Local\Microsoft\Windows\WER"
            };

            PathToEmails = @"D:\Profile\cms\AppData\Local\Microsoft\Windows Live Mail\";

            Services = new[]
            {
                "bits",
                "wuauserv",
                "CryptSvc"
            };

            Tasks = new[]
            {
                "1cv8s",
                "httpd",
                "iexplore",
                "chrome",
                "wmplayer",
                "soffice",
                "scalc",
                "wlmail",
                "swriter"
            };
        }

        public static string[] GetCommonTasksNames => Tasks;

        public static string[] GetEmailTasksNames => EmailTasksNames;

        public static string[] GetPathsToCompleteClean => PathsesToCompleteClean;

        public static string[] GetPathsToSubfoldersClean => PathsToSubfoldersClean;

        public static string GetPathToEmails => PathToEmails;

        public static string[] GetServicesToStop => Services;

        public static Process[][] GetTasksToKill(string[] tasks)
        {
            var processes = new Process[tasks.Length][];

            for (int i = 0; i < tasks.Length; i++)
            {
                processes[i] = Process.GetProcessesByName(tasks[i]);
            }

            return processes;
        }
    }
}