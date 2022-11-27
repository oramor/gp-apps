using System.Windows.Input;

namespace Lib.Wpf.Core
{
    public interface ICanRemoveItems<T>
    {
        void RemoveItem(T item);
        ICommand RemoveItemCommand { get; }
    }
}
