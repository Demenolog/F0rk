using System.Diagnostics;

namespace F0rk.Classes
{
    internal static class DiskD
    {
        private static readonly string PathToEmails = @"D:\Profile\cms\AppData\Local\Microsoft\Windows Live Mail\";

        private static readonly string[] PathsesToCompleteClean =
        {
            @"C:\Program Files (x86)\InstallShield Installation Information",
            @"C:\Windows\ccmsetup",
            @"C:\Windows\Temp",
            @"C:\Windows\ccmcache",
            @"D:\Profile\cms\AppData\Local\Temp"
        };

        private static readonly string[] PathsToSubfoldersClean =
        {
            @"C:\Windows\SoftwareDistribution",
            @"C:\\Windows\PCHEALTH",
            @"C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow\Microsoft\CryptnetUrlCache",
            @"C:\Windows\System32\config\systemprofile\AppData\LocalLow\Microsoft\CryptnetUrlCache",
            @"D:\Profile\cms\AppData\Local\Microsoft\Windows\WER"
        };

        private static readonly string[] Tasks =
        {
            "1cv8c.exe",
            "httpd.exe",
            "iexplore.exe",
            "chrome.exe",
            "wmplayer.exe",
            "soffice.exe",
            "soffice.bin",
            "scalc.exe",
            "winmail.exe",
            "swriter.exe"
        };

        private static readonly string[] EmailTasksNames =
        {
            "iexplore.exe",
            "winmail.exe"
        };

        private static readonly string[] Services =
        {
            "bits",
            "wuauserv",
            "CryptSvc"
        };

        public static Process[][] GetTasksToKill(string[] tasks)
        {
            var processes = new Process[tasks.Length][];

            for (int i = 0; i < tasks.Length; i++)
            {
                processes[i] = Process.GetProcessesByName(tasks[i]);
            }

            return processes;
        }

        public static string[] GetCommonTasksNames => EmailTasksNames;

        public static string[] GetEmailTasksNames => EmailTasksNames;

        public static string[] GetServicesToStop => Services;

        public static string[] GetPathsToCompleteClean => PathsesToCompleteClean;

        public static string[] GetPathsToSubfoldersClean => PathsToSubfoldersClean;

        public static string GetPathToEmails => PathToEmails;


    }
}