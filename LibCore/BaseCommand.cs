using System.Windows.Input;

namespace LibCore
{
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Проверяет, должна ли команда выполняться
        /// </summary>
        public virtual bool CanExecute() => true;

        /// <summary>
        /// Собственно, сама команда
        /// </summary>
        public virtual void Execute() => ;
    }
}
