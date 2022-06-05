using System;
using System.ServiceProcess;

namespace F0rk.Classes
{
    public class _1C
    {
        public static string[] GetPathsToClear()
        {
            var paths = new string[]
            {
                Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\1C\1Cv8\"),
                Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\1C\1Cv8\"),
                Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\temp"),
                @"C:\Contract\DATA\DB_CACHE\WORK\",
                @"D:\Programs\Contract\DATA\DB_CACHE\WORK\",
                @"D:\Profile\cms\AppData\Local\1C\1cv8"
            };
            return paths;
        }

        public static void ApacheOff()
        {
            var services = new string[]
            {
                "apache2.4",
                "apache2.2"
            };

            try
            {
                foreach (string service in services)
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
            var services = new string[]
            {
                "apache2.4",
                "apache2.2"
            };

            try
            {
                foreach (string service in services)
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