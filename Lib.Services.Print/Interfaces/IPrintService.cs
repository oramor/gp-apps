using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    public interface IPrintService
    {
        /// <summary>
        /// Расчет кода SKU выполняется на стороне базе отдельной функцией,
        /// которая задействует для этого параметры регистра (класс качества
        /// товара, шаблон упаковки, код товарной позиции и т.д.)
        /// </summary>
        public void PrintLabel(IProductLabelTask labelTask);
        public void PrintLabel(ITestLabelTask labelTask);

        /// <summary>
        /// Сервис опрашивает все классы, которые реализуют интерфейс ILabelSender,
        /// чтобы сформировать список этикеток в разрезе размеров и поддерживаемых
        /// устройств. Пользователь приложения выбирает из этого списка, чтобы
        /// сформировать коллекцию, в которой этикетка сопоставлена с драйвером
        /// принтера.
        /// </summary>
        public IList<ISupportedLabel> SupportedLabels { get; }
        /// <summary>
        /// Если реализация этой коллекции будет отличаться для разных платформ
        /// (например, хранение в файлах для Windows), то потребуется выделить
        /// BasePrintService
        /// </summary>
        public ICollection<ILabelSetup> LabelSetups { get; }
    }
}
