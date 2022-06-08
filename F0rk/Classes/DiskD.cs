namespace F0rk.Classes
{
    internal static class DiskD
    {
        private static readonly string[] Services =
        {
            "BITS",
            "wuauserv",
            "cryptsvc"
        };

        public static string[] GetServicesToStop => Services;
    }
}