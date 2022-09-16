using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCore
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // All bindings subscribed to this event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChaged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChaged(PropertyName);
            return true;
        }
    }
}
