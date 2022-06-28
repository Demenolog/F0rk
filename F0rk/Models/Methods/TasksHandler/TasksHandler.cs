using System;
using System.Diagnostics;
using System.IO;

namespace F0rk.Models.Methods.TasksHandler
{
    public static class TasksHandler
    {
        public static void KillTasks(Process[][] appsProcesses)
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
            catch (Exception)
            {
                // ignored
            }
        }

        public static void KillTasks(Process[] appsProcesses)
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
                // ignore
            }
        }

        public static void StartTask(string filename, string[] commands)
        {
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename + ".exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            })
            {
                process.Start();
                using (StreamWriter pWriter = process.StandardInput)
                {
                    if (pWriter.BaseStream.CanWrite)
                    {
                        foreach (string command in commands)
                        {
                            pWriter.WriteLine(command);
                        }
                    }
                }
            }
        }
    }
}