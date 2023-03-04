using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    internal interface IEnvironmentService
    {
        IEnumerable<string> GetCommandLineArguments();
    }
}
