using System;
using System.Diagnostics;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] WmicPagefileIncreaseCommands;
        private static readonly string[] TimeSynchronization;
        

        static Optimisation()
        {
            WmicPagefileIncreaseCommands = new[]
            {
                @"wmic computersystem set AutomaticManagedPagefile=False /NOINTERACTIVE",
                @"wmic pagefileset delete /NOINTERACTIVE",
                @"wmic pagefileset create name=""C:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE",
                @"wmic pagefileset create name=""D:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE"
            };

            TimeSynchronization = new[]
            {
                @"sc start W32Time",
                @"sc config W32Time start=auto",
                @"W32tm.exe /resync"
            };

        }

        public static string[] GetWmicPagefileIncreaseCommands => WmicPagefileIncreaseCommands;
        public static string[] GetTimeSynchronization => TimeSynchronization;
    }
}