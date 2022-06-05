using System;
using System.ServiceProcess;

namespace F0rk.Classes
{
    public class _1C
    {
        private static readonly string[] PathsToClean =
        {
            Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\1C\1Cv8\"),
            Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\1C\1Cv8\"),
            Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\temp"),
            @"C:\Contract\DATA\DB_CACHE\WORK\",
            @"D:\Programs\Contract\DATA\DB_CACHE\WORK\",
            @"D:\Profile\cms\AppData\Local\1C\1cv8"
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
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}