using System;
using System.Diagnostics;
using System.Windows;

namespace F0rk.Methods.TaskKiller
{
    public static class TasksKiller
    {
        public static void Kill(Process[][] appsProcesses)
        {
            try
            {
                foreach (Process[] app in appsProcesses)
                {
                    foreach (Process process in app)
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
        }

        public static void Kill(Process[] appsProcesses)
        {
            try
            {
                foreach (Process app in appsProcesses)
                {
                    app.Kill();
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