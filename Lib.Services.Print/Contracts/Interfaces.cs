using Lib.Services.Print.Labels;

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

        /// <summary>
        /// Сервис опрашивает все классы, которые реализуют интерфейс ILabelSender,
        /// чтобы сформировать список этикеток в разрезе размеров и поддерживаемых
        /// устройств. Пользователь приложения выбирает из этого списка, чтобы
        /// сформировать коллекцию, в которой этикетка сопоставлена с драйвером
        /// принтера.
        /// </summary>
        public IReadOnlyCollection<ILabel> SupportedLabels { get; }
    }

    /// <summary>
    /// Это статические классы, на уровне которых определяются методы,
    /// реализующие печать этикетки на разных платформах и для разных
    /// размеров. Для потребителей этот класс интересен тем, что предоставляет
    /// коллекцию, которая содержит все поддерживаемые этикетки, а так же
    /// делегаты с методами печати этих этикеток
    /// </summary>
    public interface ILabelSender
    {
        public IReadOnlyCollection<ILabel> GetLabels();
    }

    public interface ICanPrint<T>
    {
        public void PrintLabel(T labelTask);
    }

    /// <summary>
    /// Этот интерфейс долен быть реализован на уровне класса приложения, либо
    /// класса главной вьюмодели (AppContext, App.ctx), от которой наследуются
    /// все конкретные вьюмодели
    /// </summary>
    public interface ICanPrintLabels
    {
        /// <summary>
        /// Список системных принтеров используется для опредления порта драйвера,
        /// на который нужно отправлять этикетку.
        /// </summary>
        public IReadOnlyCollection<ISystemPrinterInfo> GetSystemPrinters();
        /// <summary>
        /// Коллекция сетапов пользователя программы. То есть связи абстрактных
        /// этикеток с конкретными устройствами печати. Важно, что эта коллекция
        /// является модифицируемой, т.к. пользователь может добавлять и удалять
        /// сетапы.
        /// 
        /// Если будет поддержано хранение сетапов в файле, то при загрузке
        /// приложения они будут считываться и пополнять коллекцию. Однако это уже
        /// детали рализации. По умолчанию коллекцию придется заполнять заново
        /// при каждом новом пуске программы.
        /// </summary>
        public IEnumerable<ILabelSetup> LabelSetupList { get; set; }
        // Эти методы должны быть реализованы сервисом
        public string[] GetSupportedLabels();
        public string[] GetSupportedDrivers();
        public string[] GetSupportedSizes();
    }

    /// <summary>
    /// Данный интерфейс должен быть реализован вьюмоделью, которая отвечает
    /// за форму добавления нового сетапа
    /// </summary>
    public interface IAddLabelSetupForm
    {

    }

    public interface ISystemPrinterInfo
    {
        public string Name { get; init; }
        public string DriverName { get; init; }
        public string PrintPortName { get; init; }
        public int Priority { get; init; }
    }

    public interface ILabel
    {
        public string Name { get; }
        public string Description { get; }
        public SupportedLabelSizeEnum Size { get; }
        public SupportedPrinterAdapterEnum DriverAdapter { get; }
    }

    /// <summary>
    /// Сетап просто связывает абстрактную этикетку, которая поддерживается
    /// сервисом, с конкретным принтером пользователя
    /// </summary>
    public interface ILabelSetup : ILabel
    {
        public string PrinterName { get; init; }
        public string DriverName { get; init; }
        public string PortName { get; init; }
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

    #endregion

    #region Concrete labels

    /// <summary>
    /// Задание на печать тестовой этикетки
    /// </summary>
    public interface ITestLabelTask : IBaseLabelTask, ITestLabelData
    {
    }

    /// <summary>
    /// Интерфейс определяет класс или структуру, которая будет
    /// выдавать задание на печать этикетки оприходуемого товара
    /// </summary>
    public interface IProductLabelTask : IBaseLabelTask, IProductLabelData
    {
    }

    #endregion
}
