using F0rk.Methods.ServiceStopper;
using System.Diagnostics;

namespace F0rk.Classes
{
    public static class _1C
    {
        private static readonly string[] PathsToClean =
        {
            @"D:\Profile\cms\AppData\Roaming\1C\1cv8\",
            @"D:\Profile\cms\AppData\Local\Temp\",
            @"D:\Profile\cms\AppData\Local\1C\1cv8\",
            @"D:\Programs\Contract\DATA\DB_CACHE\WORK\",
            @"C:\Contract\DATA\DB_CACHE\WORK\"
        };

        private static readonly string[] Tasks =
        {
            "1cv8c.exe",
            "httpd.exe"
        };

        private static readonly string[] ApacheService =
        {
            "apache2.4",
            "apache2.2"
        };

        public static string[] GetPathsToClear() => PathsToClean;

        public static void ApacheStop() => ServiceHandler.ServicesStop(ApacheService);

        public static void ApacheStart() => ServiceHandler.ServicesStart(ApacheService);

        public static Process[][] GetTasksToKill()
        {
            var processes = new Process[Tasks.Length][];

            for (int i = 0; i < Tasks.Length; i++)
            {
                processes[i] = Process.GetProcessesByName(Tasks[i]);
            }

            return processes;
        }
    }
}