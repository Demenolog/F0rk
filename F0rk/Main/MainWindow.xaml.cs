using F0rk.Classes;
using F0rk.Methods.TaskKiller;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
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

            #region KillTasks

            TasksKiller.Kill(new[] {Process.GetProcessesByName("1cv8c.exe"),
                Process.GetProcessesByName("httpd.exe")});

            #endregion KillTasks

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

            textBoxStatus.Text = "Процесс чистки завершен.";

            #endregion ClearFiles
        }
    }
}