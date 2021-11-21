using KoreshReportSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KoreshReportSystem.Common
{
    public class RelayCommand : ViewModelBase, ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;
        private readonly Func<string> setToolTip;

        private string _toolTip;
        public string ToolTip
        {
            get => _toolTip;
            set
            {
                if (_toolTip != value)
                {
                    _toolTip = value;
                    OnPropertyChanged(nameof(ToolTip));
                }
            }
        }

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, Func<string> setToolTip = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
            this.setToolTip = setToolTip;
            ToolTip = setToolTip?.Invoke();
        }
        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            ToolTip = setToolTip?.Invoke();
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            //Helper.Unfocus();
            this.execute(parameter);
        }

        #endregion
    }
}
