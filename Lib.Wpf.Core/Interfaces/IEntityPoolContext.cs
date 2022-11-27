using System.Windows;
using System.Windows.Input;

namespace Lib.Wpf.Core
{
    /// <summary>
    /// Позволяет типизировать контекст, который должен передаваться
    /// в модальные окна. Например, в наследники BaseModalForm
    /// </summary>
    public interface IEntityPoolContext
    {
        /// <summary>
        /// TODO нужно будет преобразовать в ноду из склонений по падежам
        /// и числам, либо использовать Morpher
        /// </summary>
        string EntityName { get; }
        /// <summary>
        /// Указывает на форму, которая является контейнером для данного списка.
        /// Используется для создания блюр-эффекта
        /// </summary>
        Window ParentWindow { get; set; }
        Window FormWindow { get; set; }
        /// <summary>
        /// Форма для создания нового экземпляра сущности. Формы редактирования
        /// открываются методами, в которые передается id экземпляра сущности.
        /// </summary>
        ICommand ShowCreationFormCommand { get; }
    }
}
