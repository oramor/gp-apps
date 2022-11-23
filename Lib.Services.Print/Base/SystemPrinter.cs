namespace Lib.Services.Print
{
    public class SystemPrinter : IPrinter
    {
        public string Title { get; set; } = String.Empty;
        public string DriverName { get; init; } = String.Empty;
        public string PortName { get; init; } = String.Empty;
        public int Priority { get; init; }
    }
}
