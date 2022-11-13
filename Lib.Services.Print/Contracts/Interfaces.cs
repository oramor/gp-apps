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
        public ICollection<ILabelSetup> LabelSetupList { get; set; }
        // Эти методы должны быть реализованы сервисом
        public string[] GetSupportedLabels();
        public string[] GetSupportedDrivers();
        public string[] GetSupportedSizes();
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
        public string Title { get; }
        public SupportedLabelEnum LabelEnum { get; }
        public SupportedLabelSizeEnum LabelSizeEnum { get; }
        public SupportedDriverAdapterEnum DriverAdapterEnum { get; }
        public string LabelName { get; }
        public string LabelSizeName { get; }
        public string DriverAdapterName { get; }
    }

    /// <summary>
    /// Сетап является настройкой уровня приложения пользователя и связывает
    /// абстрактную этикетку, которая поддерживается сервисом, с конкретным
    /// принтером пользователя. Кроме того, данные из сетапа (SupportedLabelEnum
    /// и другие enum) используются в качестве фильтра для выбора класса
    /// нужной этикетки из коллекции SupportedLabels. В конечном счете,
    /// выбранный класс этикетки позволяет обратиться к методу PrintLabel,
    /// который и реализует отправку команды на принтер.
    /// </summary>
    public interface ILabelSetup : ILabel
    {
        public string PrinterName { get; init; }
        public string DriverName { get; init; }
        public string PortName { get; init; }
    }

    /// <summary>
    /// Любое задание на печать этикетки содержит, помимо <see cref="ILabelSetup">
    /// сетапа</see>, количество копий, которое нужно напечатать
    /// </summary>
    public interface IBaseLabelTask
    {
        public ILabelSetup LabelSetup { get; init; }
        public int Copy { get; init; }
    }
}
