﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F0rk.Infrastructure.Commands.Base;

namespace F0rk.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override void Execute(object parameter) => _execute(parameter);

        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
    }
}
