using System;
using System.Windows.Input;

namespace GoonRunner.Core
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<Object, bool> _canexecute;
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute = null)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}