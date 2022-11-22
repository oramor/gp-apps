namespace Lib.Services.Print
{
    public static class DriverAdapterFactory
    {
        private static readonly IList<IDriverAdapter> _driverAdapters = new List<IDriverAdapter>() {
            new DriverAdapter() { Title = "TscLib" }
        };

        public static IList<IDriverAdapter> GetAll() => _driverAdapters;

        public static IDriverAdapter TscLib => _driverAdapters[0];
    }
}
