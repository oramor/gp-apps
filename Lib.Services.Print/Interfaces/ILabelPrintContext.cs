﻿namespace Lib.Services.Print
{
    /// <summary>
    /// Этот интерфейс должен быть реализован на уровне вьюмодели приложения.
    /// Можно было бы поддержать его на уровне PrintService, но разные приложения
    /// могут по-разному обеспечивать хранение сетапов
    /// </summary>
    public interface ILabelSetupContext
    {
        /// <summary>
        /// Список системных принтеров используется только для того, чтобы
        /// помочь пользователю выбрать имя драйвера, на который нужно отправлять
        /// задаление печати
        /// </summary>
        public IReadOnlyCollection<IPrinter> SystemPrinters { get; }

        /// <summary>
        /// Коллекция сетапов, к которой пользователь может обратиться, чтобы добавить
        /// или удалить сетапы (в отличие от SystemPrinters она не только для чтения)
        /// 
        /// Если будет поддержано хранение сетапов в файле, то при загрузке
        /// приложения они будут считываться и пополнять коллекцию. Однако это уже
        /// детали рализации. По умолчанию коллекцию придется заполнять заново
        /// при каждом новом пуске программы.
        /// </summary>
        public ICollection<ILabelSetup> LabelSetups { get; }
    }
}
