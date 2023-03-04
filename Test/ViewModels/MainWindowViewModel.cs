using TestWpf.ViewModels.Base;

namespace TestWpf.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title;

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}