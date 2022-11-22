namespace Lib.Services.Print
{
    public enum DriverAdapterEnum
    {
        TscLib
    }

    public interface IDriverAdapter
    {
        string Title { get; set; }
    }
}
