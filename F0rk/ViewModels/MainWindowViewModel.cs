using F0rk.Classes;
using F0rk.Infrastructure.Commands;
using F0rk.Methods.ServiceHandler;
using F0rk.Models.Classes;
using F0rk.Models.Methods.DirectoryCleaner;
using F0rk.Models.Methods.TasksHandler;
using F0rk.ViewModels.Base;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

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

        #region Clearing commands

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

        #endregion Clear up 1C cache command

        #region Clear up temp command

        public ICommand ClearTempCommand { get; }

        private bool CanClearTempCommandExecuting(object p) => true;

        private void OnClearTempCommandExecuted(object p)
        {
            ServiceHandler.ServicesStop(DiskD.GetServicesToStop);

            TasksHandler.KillTasks(DiskD.GetTasksToKill(DiskD.GetCommonTasksNames));

            DirectoryCleaner.CleanUpComplete(DiskD.GetPathsToCompleteClean);

            DirectoryCleaner.CleanUpDirectories(DiskD.GetPathsToSubfoldersClean);

            TextBoxStatus = "Чистка темпа завершена.";
        }

        #endregion Clear up temp command

        #region Clear up mail command

        public ICommand ClearMailCommand { get; }

        private bool CanClearMailCommandExecuting(object p) => true;

        private void OnClearMailCommandExecuted(object p)
        {
            TasksHandler.KillTasks(DiskD.GetTasksToKill(DiskD.GetEmailTasksNames));

            var directory = new DirectoryInfo(DiskD.GetPathToEmails);

            var todaySubtractMonth = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));

            DirectoryCleaner.CleanUpMail(directory, todaySubtractMonth);

            TextBoxStatus = "Чистка почты завершена.";
        }

        #endregion Clear up mail command

        #endregion Clearing commands

        #region Optimisation commands

        #region Increase pagefile command

        public ICommand IncreasePagefileCommand { get; }

        private bool CanIncreasePagefileCommandExecuting(object p) => true;

        private void OnIncreasePagefileCommandExecuted(object p)
        {
            Optimisation.IncreasePagefile();
            TextBoxStatus = "Pagefile увеличен до 3,5 Гб.";
        }

        #endregion Increase pagefile command

        #endregion Optimisation commands

        #region Other setting

        #region Restart Sap\Apache command

        public ICommand RestartSapApache { get; }

        private bool CanRestartSapApacheCommandExecuting(object p) => true;

        private void OnRestartSapApacheCommandExecuted(object p)
        {
            _1C.SapApacheRestart();

            TextBoxStatus = @"Службы Sap\Apache перезапущены.";
        }

        #endregion Restart Sap\Apache command

        #endregion Other setting

        public MainWindowViewModel()
        {
            #region Clearing commands

            Clear1CCacheCommand = new LambdaCommand(OnClear1CCacheCommandExecuted, CanClear1CCacheCommandExecuting);

            ClearTempCommand = new LambdaCommand(OnClearTempCommandExecuted, CanClearTempCommandExecuting);

            ClearMailCommand = new LambdaCommand(OnClearMailCommandExecuted, CanClearMailCommandExecuting);

            #endregion Clearing commands

            #region Optimisation commands

            IncreasePagefileCommand = new LambdaCommand(OnIncreasePagefileCommandExecuted, CanIncreasePagefileCommandExecuting);

            #endregion Optimisation commands

            #region Other settings commands

            RestartSapApache = new LambdaCommand(OnRestartSapApacheCommandExecuted, CanRestartSapApacheCommandExecuting);

            #endregion Other settings commands
        }
    }
}