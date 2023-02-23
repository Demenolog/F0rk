using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Services;

namespace Test.Methods
{
    internal class ConsoleArguments : IEnvironmentService
    {
        public IEnumerable<string> GetCommandLineArguments()
        {
            return Environment.GetCommandLineArgs();
        }
    }
}
