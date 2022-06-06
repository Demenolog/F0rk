using System;
using System.ServiceProcess;

namespace F0rk.Classes
{
    public static class _1C
    {
        private static readonly string[] PathsToClean =
        {
            @"D:\Profile\cms\AppData\Roaming\1C\1cv8",
            @"D:\Profile\cms\AppData\Local\Temp",
            @"D:\Profile\cms\AppData\Local\1C\1cv8",
            @"D:\Programs\Contract\DATA\DB_CACHE\WORK\",
            @"C:\Contract\DATA\DB_CACHE\WORK\"
        };

        private static readonly string[] ApacheService =
        {
            "apache2.4",
            "apache2.2"
        };

        public static string[] GetPathsToClear() => PathsToClean;

        public static void ApacheOff()
        {
            try
            {
                foreach (string service in ApacheService)
                {
                    var sv = new ServiceController(service);
                    sv.Stop();
                    sv.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void ApacheOn()
        {
            try
            {
                foreach (string service in ApacheService)
                {
                    var sv = new ServiceController(service);
                    sv.Start();
                    sv.WaitForStatus(ServiceControllerStatus.Running);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}