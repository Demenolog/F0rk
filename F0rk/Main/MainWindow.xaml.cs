using F0rk.Classes;
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
            #region KillTasksAndStopServices

            _1C.ApacheOff();

            TasksHandler.KillTasks(new[] {Process.GetProcessesByName("1cv8c.exe"),
                Process.GetProcessesByName("httpd.exe")});

            #endregion KillTasksAndStopServices

            #region ClearFiles

            foreach (string path in _1C.GetPathsToClear())
            {
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                {
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        try
                        {
                            dir.Delete(true);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }

            _1C.ApacheOn();

            textBoxStatus.Text = "Процесс чистки 1C завершен.";

            #endregion ClearFiles
        }


        private void ClearTempAndDiskD(object sender, RoutedEventArgs e)
        {

        }
    }
}