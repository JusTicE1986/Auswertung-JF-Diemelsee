using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Auswertung_JF_Diemelsee.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _executeHandler;
        private readonly Predicate<object> _canExecuteHandler;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Execute kann nicht null sein.");
            _executeHandler = execute;
            _canExecuteHandler = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null) return true;
            return _canExecuteHandler(parameter);
        }

    }
}
