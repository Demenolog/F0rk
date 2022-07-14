using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            string filename = "cmd";

            string[] commands = new[]
            {
                "sc delete Upos2Agent",
                @"regsvr32 /u /s D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /u /s D:\Programs\UPOS\SBRFCOM.dll"
            };

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filename,
                        CreateNoWindow = false,
                        RedirectStandardInput = true,
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

                pWriter.Dispose();
                process.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
