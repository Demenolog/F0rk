using F0rk.Methods.ServiceHandler;
using System.Diagnostics;

namespace F0rk.Classes
{
    public static class _1C
    {
        private static readonly string[] ApacheService;

        private static readonly string[] PathsToClean;

        private static readonly string[] Tasks;

        static _1C()
        {
            PathsToClean = new[]
            {
                @"D:\Profile\cms\AppData\Roaming\1C\1cv8",
                @"D:\Profile\cms\AppData\Local\Temp",
                @"D:\Profile\cms\AppData\Local\1C\1cv8",
                @"D:\Programs\Contract\Data\DB_CACHE\WORK"
            };

            Tasks = new[]
            {
                "1cv8c",
                "httpd"
            };

            ApacheService = new[]
            {
                "apache2.4",
                "apache2.2"
            };

        }

        public static void ApacheStart() => ServiceHandler.ServicesStart(ApacheService);

        public static void ApacheStop() => ServiceHandler.ServicesStop(ApacheService);

        public static string[] GetPathsToClear() => PathsToClean;

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