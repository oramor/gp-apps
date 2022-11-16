namespace Lib.Services.Print
{
    public class DriverAdapter : IDriverAdapter
    {
        public required DriverAdapterEnum Key { get; init; }
        
        public string Title
        {
            get {
                if (Key == DriverAdapterEnum.TscLib) return "TSCLib";
                return string.Empty;
            }
        }
    }
}
