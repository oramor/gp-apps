using System.Windows.Input;

namespace Lib.Wpf.Core
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Проверяет, должна ли команда выполняться. По умолчанию
        /// все команды сразу доступны для выполнения
        /// </summary>
        public virtual bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Собственно, сама команда
        /// </summary>
        public abstract void Execute(object? parameter);
    }
}
