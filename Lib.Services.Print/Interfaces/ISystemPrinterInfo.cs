namespace Lib.Services.Print
{
    public interface ISystemPrinterInfo
    {
        public string Name { get; init; }
        public string DriverName { get; init; }
        public string PrintPortName { get; init; }
        public int Priority { get; init; }
    }
}
