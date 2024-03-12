using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp3.Common.MVVM
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> executeAction;
        private readonly Func<bool> canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            executeAction = execute ?? throw new ArgumentNullException(nameof(execute));
            canExecuteFunc = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecuteFunc == null || canExecuteFunc.Invoke();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                if (parameter is T typedParameter)
                {
                    executeAction(typedParameter);
                }
                else
                {
                    executeAction(default);
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action executeAction;
        private readonly Func<bool> canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            executeAction = execute ?? throw new ArgumentNullException(nameof(execute));
            canExecuteFunc = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc == null || canExecuteFunc.Invoke();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                executeAction();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
