using F0rk.Methods.TaskKiller;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace F0rk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearCache1C(object sender, RoutedEventArgs e)
        {
            textBoxStatus.Text = "Запущен процесс чистки";

            #region KillTasks

            TasksKiller.Kill(new[] {Process.GetProcessesByName("1cv8c.exe"),
                Process.GetProcessesByName("httpd.exe")});

            #endregion KillTasks

            #region ClearFiles

            try
            {
                var pathWithEnv = @"%USERPROFILE%\Documents\Test";
                var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
                var directory = new DirectoryInfo(filePath);

                foreach (FileInfo file in directory.EnumerateFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    dir.Delete(true);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            #endregion ClearFiles
        }
    }
}