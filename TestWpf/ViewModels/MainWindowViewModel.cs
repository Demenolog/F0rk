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

        public MainWindowViewModel()
        {
            
        }
    }
}