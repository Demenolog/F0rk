using F0rk.Models.Methods.TasksHandler;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] WmicPagefileIncreaseCommands;
        private static readonly string[] CmdPinpadRegistration;
        private static readonly string[] CmdPinpadUnregistration;

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

        public static void IncreasePagefile() => TasksHandler.StartTaskWithCommands("wmic.exe", WmicPagefileIncreaseCommands);
    }
}