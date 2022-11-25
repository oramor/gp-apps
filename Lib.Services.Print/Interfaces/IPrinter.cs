using Lib.Core;

namespace Lib.Services.Print
{
    public interface IPrinter : IEntity<int>
    {
        public string DriverName { get; init; }
        public string PortName { get; init; }
        public int Priority { get; init; }
    }
}
