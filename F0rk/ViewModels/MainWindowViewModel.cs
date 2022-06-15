using F0rk.Classes;
using F0rk.Infrastructure.Commands;
using F0rk.Methods.DirectoryCleaner;
using F0rk.Methods.ServiceHandler;
using F0rk.Methods.TaskKiller;
using F0rk.ViewModels.Base;
using System;
using System.IO;
using System.Windows.Input;

namespace F0rk.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Textbox Status

        private string _textBoxStatus;

        public string TextBoxStatus
        {
            get => _textBoxStatus;
            set => Set(ref _textBoxStatus, value);
        }

        #endregion Textbox Status

        #region Commands

        #region Clear1cCacheCommand

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

        #endregion Clear1cCacheCommand

        #region ClearTempCommand

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

        #endregion ClearTempCommand

        #region ClearMailCommand

        public ICommand ClearMailCommand { get; }

        private bool CanClearMailCommandExecuting(object p) => true;

        private void OnClearMailCommandExecuted(object p)
        {
            var path = DiskD.GetPathToEmails;
            var todaySubtractMonth = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            var directory = new DirectoryInfo(path);

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                if (!dir.FullName.ToUpperInvariant().Contains("Espoint".ToUpperInvariant())) continue;
                foreach (DirectoryInfo emailsDir in dir.GetDirectories())
                {
                    if (emailsDir.FullName.ToUpperInvariant().Contains("Junk".ToUpperInvariant()))
                    {
                        foreach (FileInfo email in emailsDir.GetFiles())
                        {
                            try
                            {
                                email.Delete();
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                    else
                    {
                        foreach (FileInfo email in emailsDir.GetFiles())
                        {
                            if (email.LastWriteTime < todaySubtractMonth)
                            {
                                try
                                {
                                    email.Delete();
                                }
                                catch (Exception)
                                {
                                    // ignored
                                }
                            }
                        }
                    }
                }
            }

            TextBoxStatus = "Чистка почты завершена.";
        }

        #endregion ClearMailCommand

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