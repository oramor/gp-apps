namespace Lib.Services.Print
{
    public class SystemPrinter : IPrinter
    {
        public int Id { get => this.GetHashCode(); init => this.GetHashCode(); }
        public string Title { get => DriverName; }
        public string DriverName { get; init; } = String.Empty;
        public string PortName { get; init; } = String.Empty;
        public int Priority { get; init; }
    }
}
