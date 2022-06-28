using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sapUrl = @"http://127.0.0.1:8200/";

            Process.Start("chrome.exe", sapUrl + " -incognito");
        }

    }
}
