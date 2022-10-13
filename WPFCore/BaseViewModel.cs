using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCore
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // All bindings subscribed to this event
        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
