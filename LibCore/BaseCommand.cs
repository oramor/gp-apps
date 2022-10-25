using System.Windows.Input;

namespace LibCore
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Проверяет, должна ли команда выполняться
        /// </summary>
        public abstract bool CanExecute(object? parameter);

        /// <summary>
        /// Собственно, сама команда
        /// </summary>
        public abstract void Execute(object? parameter);
    }
}
