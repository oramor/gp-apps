namespace Lib.Services.Print
{
    /// <summary>
    /// Типизирует классы, которые непосредственно реализуют
    /// печать этикеток через взаимодействие с драйвером
    /// </summary>
    public interface ISupportedLabel
    {
        string Title { get; }
        public ICommonLabel CommonLabel { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }
    }
}
