using System;
using System.Windows.Input;

namespace Step7.ViewModel
{
    public class CommandObject : ICommand
    {
        private Action _action;

        public CommandObject(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
