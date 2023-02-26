using System;
using System.Windows;

namespace Test
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parameters = Environment.GetCommandLineArgs();

            foreach (string str in parameters)
            {
                Console.WriteLine(str);
            }
        }
    }
}