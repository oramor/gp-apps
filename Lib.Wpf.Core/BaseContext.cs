using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Lib.Wpf.Core
{
    public abstract class BaseContext : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие оповещает инфраструктуру WPF о том, что свойство изменилось
        /// и, как следствие, необходимо обновить все компоненты, которые
        /// к нему биндятся
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод используется для оповещения инфраструктуры WPF о том, что свойство
        /// вьюмодели было изменено и необходимо обновить компоненты, которые завязаны
        /// на него через биндинг. Метод вызывается из универсального Set(), а так же
        /// может быть вызван напрямую.
        /// </summary>
        protected virtual void OnPropertyChaged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T currentValue, T fieldValue, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(fieldValue, currentValue)) return false;

            currentValue = fieldValue;
            OnPropertyChaged(PropertyName);

            return true;
        }

        #region Utility

        protected void CloseWindow<T>() where T : Window
        {
            var window = Application.Current.Windows.OfType<T>().First();
            window?.Close();
        }

        #endregion
    }
}
