﻿using System.Data.SqlClient;
using System.Windows.Input;
using F0rk.Classes;
using F0rk.Infrastructure.Commands;
using F0rk.Methods.DirectoryCleaner;
using F0rk.Methods.TaskKiller;
using F0rk.ViewModels.Base;

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

        #endregion

        #region Commands

        #region Clear1cCache

        public ICommand Clear1CCacheCommand { get; }

        private bool CanClear1CCacheCommandExecuting(object p) => true;

        private void OnClear1CCacheCommandExecuted(object p)
        {
            _1C.ApacheStop();

            TasksHandler.KillTasks(_1C.GetTasksToKill());

            DirectoryCleaner.CompleteCleanup(_1C.GetPathsToClear());

            _1C.ApacheStart();

            TextBoxStatus = "Чистка кэша 1С завершилась.";
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            Clear1CCacheCommand = new LambdaCommand(OnClear1CCacheCommandExecuted, CanClear1CCacheCommandExecuting);

            #endregion
        }
    }
}