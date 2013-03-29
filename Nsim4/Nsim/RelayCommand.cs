namespace Nsim
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _xc01b87b2f28551b2;
        private readonly Predicate<object> _xce979f8896316e8b;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if ((execute == null) && (8 != 0))
            {
                throw new ArgumentNullException("execute");
            }
            this._xc01b87b2f28551b2 = execute;
            this._xce979f8896316e8b = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return ((this._xce979f8896316e8b == null) || this._xce979f8896316e8b(parameter));
        }

        public void Execute(object parameter)
        {
            this._xc01b87b2f28551b2(parameter);
        }
    }
}

