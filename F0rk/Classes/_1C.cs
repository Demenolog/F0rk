using F0rk.Methods.ServiceStopper;
using System;
using System.ServiceProcess;

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

        private static readonly string[] ApacheService =
        {
            "apache2.4",
            "apache2.2"
        };

        public static string[] GetPathsToClear() => PathsToClean;

        public static void ApacheStop() => ServiceHandler.ServicesStop(ApacheService);

        public static void ApacheStart() => ServiceHandler.ServicesStart(ApacheService);
    }
}