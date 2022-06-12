using F0rk.ViewModels.Base;

namespace F0rk.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _textBoxStatus;


        public string TextBoxStatus
        {
            get => _textBoxStatus;
            set => _textBoxStatus = value;
        }
    }
}