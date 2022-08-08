using System.IO;
using System.Text;
using F0rk.Models.Methods.TasksHandler;
using F0rk.Models.Methods.ServiceHandler;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Services = new[]
            {
                "bits",
                "wuauserv",
                "CryptSvc"
            };

            ServiceHandler.ServiceStop(Services);
        }
    }
}