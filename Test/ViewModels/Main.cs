using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Methods;
using Test.Services;

namespace Test.ViewModels
{
    internal class Main
    {
        public void GetCommands()
        {
            var commands = new ConsoleArguments();
            var strings = commands.GetCommandLineArguments();
        }
    }
}
