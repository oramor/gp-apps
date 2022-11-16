namespace Lib.Services.Print
{
    internal class DriverAdapter : IDriverAdapter
    {
        public SupportedDriverAdapterEnum DriverAdapterId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
