using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

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

        public static void StartTaskWithCommand(string filename, string[] commands)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filename,
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    }
                };

                process.Start();

                var pWriter = process.StandardInput;

                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (string command in commands)
                    {
                        pWriter.WriteLine(command);
                    }
                }

                process.StandardInput.Close();

                //var output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();

                //MessageBox.Show(output);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void StartTaskWithCommand(string filename, string command)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filename,
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    }
                };

                process.Start();

                var pWriter = process.StandardInput;

                pWriter.WriteLine(command);

                process.StandardInput.Close();

                //var output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();

                //MessageBox.Show(output);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}