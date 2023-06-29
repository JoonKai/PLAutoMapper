using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLAutoMapper.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _excute;
        private readonly Predicate<T> _canExcute;

        public RelayCommand(Action<T> execute, Predicate<T> canExcute = null)
        {
            this._excute = execute;
            this._canExcute = canExcute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExcute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _excute?.Invoke((T)parameter);
        }
    }
}
