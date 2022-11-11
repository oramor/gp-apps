namespace Lib.Services.Print
{
    #region Basic infrastructure

    public interface IPrintService
    {
        /// <summary>
        /// Расчет кода SKU выполняется на стороне базе отдельной функцией,
        /// которая задействует для этого параметры регистра (класс качества
        /// товара, шаблон упаковки, код товарной позиции и т.д.)
        /// </summary>
        public void PrintLabel(IProductLabelTask labelTask);
        public void PrintLabel(ITestLabelTask labelTask);
    }

    /// <summary>
    /// Этот интерфейс долен быть реализован на уровне класса приложения
    /// </summary>
    public interface ICanPrintLabels
    {
        public ILabelSetup DefaultLabelSetup { get; set; }
        public ISystemPrinterInfo[] GetSystemPrinters();
        public string[] GetSupportedDrivers();
        public string[] GetSupportedSizes();
    }

    /// <summary>
    /// Любое задание на печати этикетки должно включать ссылку
    /// на заранее созданный сетап, по которому программа определит
    /// принтер и формат для выбранного типа этикетки
    /// </summary>
    public interface IBaseLabelTask
    {
        public ILabelSetup LabelSetup { get; init; }
        public int Copy { get; init; }
    }

    /// <summary>
    /// Приложение поддерживает печать не только с разными типами этикеток,
    /// но и с принтерами разных производителей. Соответственно, пользователь
    /// может создать несколько сетапов для разных категорий этикеток
    /// </summary>
    public interface ILabelSetup
    {
        public string Name { get; set; }
        public string PrinterName { get; set; }
        public string DriverName { get; set; }
        public SupportedPrinterAdapterEnum DriverAdapter { get; set; }
        public SupportedLabelSizeEnum LabelSize { get; set; }
    }

    public interface ISystemPrinterInfo
    {
        public string Name { get; init; }
        public string DriverName { get; init; }
        public string PrintPortName { get; init; }
        public int Priority { get; init; }
    }

    #endregion

    #region Concrete labels

    /// <summary>
    /// Задание на печать тестовой этикетки
    /// </summary>
    public interface ITestLabelTask : IBaseLabelTask
    {
        public string Text { get; init; }
        public int Barcode { get; init; }
    }

    /// <summary>
    /// Интерфейс определяет класс или структуру, которая будет
    /// выдавать задание на печать этикетки оприходуемого товара
    /// </summary>
    public interface IProductLabelTask : IBaseLabelTask
    {
        public int ProductId { get; init; }
        public int Sku { get; init; }
    }

    #endregion
}
