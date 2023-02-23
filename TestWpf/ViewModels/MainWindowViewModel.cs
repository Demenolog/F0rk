using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using TestWpf.Infrastructure.Commands;
using TestWpf.ViewModels.Base;

namespace TestWpf.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region MainWindow Title

        private string _title = "Test wpf window";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        #endregion

        #region Commands

        #region Close application command

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecuted);

            #endregion
        }
    }
}