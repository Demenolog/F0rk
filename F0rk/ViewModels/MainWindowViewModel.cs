using F0rk.Classes;
using F0rk.Infrastructure.Commands;
using F0rk.Methods.ServiceHandler;
using F0rk.ViewModels.Base;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using F0rk.Models.Methods.DirectoryCleaner;
using F0rk.Models.Methods.TasksHandler;

namespace F0rk.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region TextBox status

        private string _textBoxStatus;

        public string TextBoxStatus
        {
            get => _textBoxStatus;
            set => Set(ref _textBoxStatus, value);
        }

        #endregion TextBox status

        #region Commands

        #region Clear up 1C cache command

        public ICommand Clear1CCacheCommand { get; }

        private bool CanClear1CCacheCommandExecuting(object p) => true;

        private void OnClear1CCacheCommandExecuted(object p)
        {
            _1C.ApacheStop();

            TasksHandler.KillTasks(_1C.GetTasksToKill());

            DirectoryCleaner.CleanUpComplete(_1C.GetPathsToClear());

            _1C.ApacheStart();

            TextBoxStatus = "Чистка кэша 1С завершена.";
        }

        #endregion Clear 1C cache command

        #region Clear up temp command

        public ICommand ClearTempCommand { get; }

        private bool CanClearTempCommandExecuting(object p) => true;

        private void OnClearTempCommandExecuted(object p)
        {
            ServiceHandler.ServicesStop(DiskD.GetServicesToStop);

            TasksHandler.KillTasks(DiskD.GetTasksToKill());

            DirectoryCleaner.CleanUpComplete(DiskD.GetPathsToCompleteClean);

            DirectoryCleaner.CleanUpDirectories(DiskD.GetPathsToSubfoldersClean);

            TextBoxStatus = "Чистка темпа завершена.";
        }

        #endregion Clear temp command

        #region Clear up mail command

        public ICommand ClearMailCommand { get; }

        private bool CanClearMailCommandExecuting(object p) => true;

        private void OnClearMailCommandExecuted(object p)
        {
            TasksHandler.KillTasks(Process.GetProcesses("winmail.exe"));

            var path = DiskD.GetPathToEmails;

            var todaySubtractMonth = DateTime.Now.Subtract(new TimeSpan(30,0,0,0));

            var directory = new DirectoryInfo(path);

            DirectoryCleaner.CleanUpMail(directory, todaySubtractMonth);

            TextBoxStatus = "Чистка почты завершена.";
        }

        #endregion Clear mail command

        #endregion Commands

        public MainWindowViewModel()
        {
            #region Commands

            Clear1CCacheCommand = new LambdaCommand(OnClear1CCacheCommandExecuted, CanClear1CCacheCommandExecuting);

            ClearTempCommand = new LambdaCommand(OnClearTempCommandExecuted, CanClearTempCommandExecuting);

            ClearMailCommand = new LambdaCommand(OnClearMailCommandExecuted, CanClearMailCommandExecuting);

            #endregion Commands
        }
    }
}