using F0rk.Classes;
using F0rk.Infrastructure.Commands;
using F0rk.Models.Classes;
using F0rk.Models.Methods.DirectoryCleaner;
using F0rk.Models.Methods.ServiceHandler;
using F0rk.Models.Methods.TasksHandler;
using F0rk.ViewModels.Base;
using System;
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

        #region Cleaning commands

        #region Clear up temp command

        public ICommand ClearTempCommand { get; }

        private bool CanClearTempCommandExecuting(object p) => true;

        private void OnClearTempCommandExecuted(object p)
        {
            ServiceHandler.ServiceStop(HardDrive.GetServicesToStop);

            TasksHandler.KillTasks(HardDrive.GetTasksToKill);

            DirectoryCleaner.CleanUpCompletely(HardDrive.GetPathsToCompletelyClean);

            DirectoryCleaner.CleanUpDirectories(HardDrive.GetPathsToSubfoldersClean);

            TextBoxStatus = "Чистка темпа завершена.";
        }

        #endregion Clear up temp command

        #region Clear up mail command

        public ICommand ClearMailCommand { get; }

        private bool CanClearMailCommandExecuting(object p) => true;

        private void OnClearMailCommandExecuted(object p)
        {
            TasksHandler.KillTasks("wlmail");

            var directory = new DirectoryInfo(HardDrive.GetPathToEmails);

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
            TasksHandler.StartTaskWithCommands("cmd", Optimisation.GetWmicPagefileIncreaseCommands);

            TextBoxStatus = "Pagefile увеличен до 3,5 Гб.";
        }

        #endregion Increase pagefile command

        #region Time synchronization

        public ICommand TimeSynchronizationCommand { get; }

        private bool CanTimeSynchronizationExecuting(object p) => true;

        private void OnTimeSynchronizationExecuted(object p)
        {
            Optimisation.TimeSynchronization();

            TextBoxStatus = "Время синхронизировано.";
        }

        #endregion Time synchronization

        #region ReturnLanguageBar

        public ICommand LanguageBarCommand { get; }

        private bool CanLanguageBarExecuting(object p) => true;

        private void OnLanguageBarExecuted(object p)
        {
            Optimisation.ReturnLanguageBar();

            TextBoxStatus = "Яз. панель восстановлена.";
        }

        #endregion ReturnLanguageBar

        #endregion Optimisation commands

        public MainWindowViewModel()
        {
            #region Cleaning commands

            ClearTempCommand = new LambdaCommand(OnClearTempCommandExecuted, CanClearTempCommandExecuting);

            ClearMailCommand = new LambdaCommand(OnClearMailCommandExecuted, CanClearMailCommandExecuting);

            #endregion Clearing commands

            #region Optimisation commands

            IncreasePagefileCommand = new LambdaCommand(OnIncreasePagefileCommandExecuted, CanIncreasePagefileCommandExecuting);

            TimeSynchronizationCommand =
                new LambdaCommand(OnTimeSynchronizationExecuted, CanTimeSynchronizationExecuting);

            LanguageBarCommand =
                new LambdaCommand(OnLanguageBarExecuted, CanLanguageBarExecuting);

            #endregion Optimisation commands
        }
    }
}