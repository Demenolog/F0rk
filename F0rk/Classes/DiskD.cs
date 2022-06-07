namespace F0rk.Classes
{
    internal static class DiskD
    {
        private static readonly string[] ServicesToStop =
        {
            "bits",
            "wuauserv",
            "cryptsvc",
        };

        public static string[] GetServicesToStop => ServicesToStop;
    }
}