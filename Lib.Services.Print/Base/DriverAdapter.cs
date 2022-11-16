namespace Lib.Services.Print
{
    internal class DriverAdapter : IDriverAdapter
    {
        public SupportedDriverAdapterEnum DriverAdapterId { get; set; }
        public string DriverAdapterTitle { get; set; } = string.Empty;
    }
}
