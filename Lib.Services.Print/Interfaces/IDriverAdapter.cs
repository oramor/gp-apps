namespace Lib.Services.Print
{
    public enum DriverAdapterEnum
    {
        TscLib
    }

    public interface IDriverAdapter
    {
        public DriverAdapterEnum Key { get; init; }
        public string Title { get; }
    }
}
