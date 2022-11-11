using Lib.Services.Print.Interfaces;

namespace Lib.Services.Print
{
    /// <summary>
    /// Интерфейс определяет класс или структуру, которая будет
    /// выдавать задание на печать этикетки оприходуемого товара
    /// </summary>
    public interface IIncomeProductLabelTask : IBaseLabelTask
    {
        public int ProductId { get; init; }
        public int Sku { get; init; }
    }
}
