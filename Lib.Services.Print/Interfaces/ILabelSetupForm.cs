namespace Lib.Services.Print
{
    /// <summary>
    /// Это общий интерфейс, который должен быть реализован формой добавления/редактирования
    /// сетапа этикетки. Для каждой конкретной платформы так же реализуется интерфейс
    /// команды сохранения (его здесь нет, т.к. он платформозависим, а так же зависит
    /// от способа хранения — сервер или клиент).
    /// </summary>
    public interface ILabelSetupForm : ILabelSetup
    {
        public string[] GetSupportedLabels();
        public string[] GetSupportedDrivers();
        public string[] GetSupportedSizes(SupportedLabelEnum label, SupportedDriverAdapterEnum driver);
    }
}
