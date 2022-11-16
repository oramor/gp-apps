namespace Lib.Services.Print
{
    public enum SupportedDriverAdapterEnum
    {
        TscLib
    }

    public interface IDriverAdapter
    {
        public SupportedDriverAdapterEnum DriverAdapterId { get; set; }
        public string Title { get; set; }
    }
}
