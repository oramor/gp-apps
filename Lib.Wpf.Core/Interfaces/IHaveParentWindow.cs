using System.Windows;

namespace Lib.Wpf.Core
{
    /// <summary>
    /// Позволяет типизировать контекст, который должен передаваться
    /// в модальные окна. Например, в наследники BaseModalForm
    /// </summary>
    public interface IHaveParentWindow
    {
        Window ParentWindow { get; set; }
        Window FormWindow { get; set; }
    }
}
