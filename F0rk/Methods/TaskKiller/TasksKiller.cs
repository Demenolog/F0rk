using System;
using System.Diagnostics;
using System.Windows;

namespace F0rk.Methods.TaskKiller
{
    public static class TasksKiller
    {
        public static void Kill(Process[][] appsProcesses)
        {

            // TODO ДОБАВИТЬ ЦИКЛ FOR

            try
            {
                foreach (Process process in appsProcesses[0])
                {
                    process.Kill();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
        }
    }
}