namespace Lib.Services.Print
{
    public interface IPrinter
    {
        public string Title { get; set; }
        public string DriverName { get; init; }
        public string PortName { get; init; }
        public int Priority { get; init; }
    }
}
