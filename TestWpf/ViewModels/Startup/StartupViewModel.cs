using System;
using System.Windows.Input;
using TestWpf.Infrastructure.Commands;
using TestWpf.ViewModels.Base;

namespace TestWpf.ViewModels.Startup
{
    internal class StartupViewModel : ViewModel
    {
        public ICommand ExecuteStartParametersCommand { get; }

        private bool CanExecuteStartParametersCommandExecuted(object p) => true;

        private void OnExecuteStartParametersCommandExecute(object p)
        {
            var args = Environment.GetCommandLineArgs();


        }

        public StartupViewModel()
        {
            ExecuteStartParametersCommand = new LambdaCommand(OnExecuteStartParametersCommandExecute, CanExecuteStartParametersCommandExecuted);
        }
    }
}