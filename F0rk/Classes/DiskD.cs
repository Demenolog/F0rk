namespace F0rk.Classes
{
    internal static class DiskD
    {
        private static readonly string[] PathsToCompleteClean =
        {
            @"C:\Program Files (x86)\InstallShield Installation Information",
            @"C:\Windows\ccmsetup",
            @"C:\Windows\Temp",
            @"C:\Windows\ccmcache",
            @"D:\Profile\cms\AppData\Local\Temp"
        };

        private static readonly string[] PathsToNotCompleteClean =
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
            "swriter.exe"
        };

        private static readonly string[] Services =
        {
            "bits",
            "wuauserv",
            "cryptsvc"
        };

        public static string[] GetServicesToStop => Services;
    }
}