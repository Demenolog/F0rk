using F0rk.Methods.TaskKiller;
using System.Diagnostics;
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

        private void Clear1C(object sender, RoutedEventArgs e)
        {
            textBoxStatus.Text = "Запущен процесс чистки";

            #region KillTasks

            TasksKiller.Kill(new[] {Process.GetProcessesByName("1cv8c.exe"),
                Process.GetProcessesByName("httpd.exe")});

            #endregion KillTasks


        }
    }
}