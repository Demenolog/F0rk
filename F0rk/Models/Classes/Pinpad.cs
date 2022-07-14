namespace F0rk.Models.Classes
{
    public static class Pinpad
    {
        private static readonly string[] UnregistrationCommands;
        private static readonly string[] RegistrationCommands;
        private static readonly string PinpadServiceName;
        private static readonly string PinpadServicePath;

        static Pinpad()
        {
            PinpadServiceName = "Upos2Agent";

            PinpadServicePath = @"D:\Programs\UPOS\Agent.exe";

            UnregistrationCommands = new[]
            {
                string.Concat("sc delete ", PinpadServiceName),
                @"regsvr32 /u /s D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /u /s D:\Programs\UPOS\SBRFCOM.dll"
            };

            RegistrationCommands = new[]
            {
                @"regsvr32 /s D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /s D:\Programs\UPOS\SBRFCOM.dll",
                string.Concat(PinpadServicePath, @" \reg")
            };
        }

        public static string GetPinpadServicePath => PinpadServicePath;

        public static string GetPinpadServiceName => PinpadServiceName;

        public static string[] GetUnregistrationCommands => UnregistrationCommands;

        public static string[] GetRegistrationCommands => RegistrationCommands;
    }
}