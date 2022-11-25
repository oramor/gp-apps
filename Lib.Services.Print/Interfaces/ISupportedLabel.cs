using Lib.Core;

namespace Lib.Services.Print
{
    /// <summary>
    /// Типизирует классы, которые непосредственно реализуют
    /// печать этикеток через взаимодействие с драйвером
    /// </summary>
    public interface ISupportedLabel : IEntity<int>
    {
        public ICommonLabel CommonLabel { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }
    }
}
