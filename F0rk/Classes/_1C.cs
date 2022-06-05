using System;

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
                @"C:\Contract\DATA\DB_CACHE\WORK\",
                @"D:\Programs\Contract\DATA\DB_CACHE\WORK\",
                @"D:\Profile\cms\AppData\Local\1C\1cv8"
            };
            return paths;
        }
    }
}