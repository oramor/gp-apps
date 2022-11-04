using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lib.Wpf.Core
{
    public abstract class ContextBase : INotifyPropertyChanged
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

        /// <summary>
        /// Всего лишь обертка, которая убирает необходимость вызывать OnPropertyChanged
        /// напрямую в сеттерах свойств вьюмодели.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentValue"></param>
        /// <param name="fieldValue"></param>
        /// <param name="PropertyName">Строковое имя свойства, полученное через выражение nameof()</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T currentValue, T fieldValue, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(fieldValue, currentValue)) return false;

            currentValue = fieldValue;
            OnPropertyChaged(PropertyName);

            return true;
        }
    }
}
