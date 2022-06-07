using F0rk.Classes;
using F0rk.Methods.TaskKiller;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using F0rk.Methods.DirectoryCleaner;
using F0rk.Methods.ServiceStopper;

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

            _1C.ApacheStop();

            TasksHandler.KillTasks(new[] {Process.GetProcessesByName("1cv8c.exe"),
                Process.GetProcessesByName("httpd.exe")});

            #endregion KillTasksAndStopServices

            #region ClearFiles

            DirectoryCleaner.CompleteCleanup(_1C.GetPathsToClear());

            _1C.ApacheStart();

            textBoxStatus.Text = "Процесс чистки 1C завершен.";

            #endregion ClearFiles
        }


        private void ClearTempAndDiskD(object sender, RoutedEventArgs e)
        {
            ServiceHandler.ServicesStop(DiskD.GetServicesToStop);


        }
    }
}