using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using F0rk.ViewModels;
using F0rk.Classes;
using F0rk.Infrastructure.Commands.Base;
using F0rk.Methods.DirectoryCleaner;
using F0rk.Methods.TaskKiller;

namespace F0rk.Infrastructure.Commands._1cCommands
{
    internal class Clear1CCacheCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            _1C.ApacheStop();

            TasksHandler.KillTasks(_1C.GetTasksToKill());

            DirectoryCleaner.CompleteCleanup(_1C.GetPathsToClear());

            _1C.ApacheStart();
        }
    }
}
