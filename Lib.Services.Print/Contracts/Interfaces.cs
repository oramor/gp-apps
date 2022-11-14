using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{


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
        /// Список системных принтеров используется только для того, чтобы
        /// помочь пользователю выбрать имя драйвера, на который нужно отправлять
        /// задаление печати
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
}
