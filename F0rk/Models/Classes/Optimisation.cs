using System;
using System.Diagnostics;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] WmicPagefileIncreaseCommands;

        static Optimisation()
        {
            WmicPagefileIncreaseCommands = new[]
            {
                @"computersystem set AutomaticManagedPagefile=False /NOINTERACTIVE",
                @"pagefileset delete /NOINTERACTIVE",
                @"pagefileset create name=""C:\\pagefile.sys"" /NOINTERACTIVE",
                @"pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE",
                @"pagefileset create name=""D:\\pagefile.sys"" /NOINTERACTIVE",
                @"pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE"
            };
        }

        public static string[] GetWmicPagefileIncreaseCommands => WmicPagefileIncreaseCommands;
    }
}