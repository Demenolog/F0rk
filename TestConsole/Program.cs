using System;
using System.IO;
using System.Windows;
using F0rk.Models.Methods.TasksHandler;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }
        }
    }
}