using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCore
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChaged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T property, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(property, value)) return false;
            property = value;
            OnPropertyChaged(PropertyName);
            return true;
        }
    }
}
