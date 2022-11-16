namespace Lib.Core
{
    /// <summary>
    /// Класс позволяет быстро поддержать добавление новой культуры
    /// в сообщениях об ошибке за счет добавления общего дефолтного
    /// сообщения на языке культуры
    /// </summary>
    public class ExeptionCultureNode : ICultureNode
    {
        public required string Ru_RU { get; init; }
        public required string En_US { get; init; }
    }
}
