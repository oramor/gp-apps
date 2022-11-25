namespace Lib.Services.Print
{
    public class DriverAdapter : IDriverAdapter
    {
        public required int Id { get; init; }
        public string Title { get; set; } = string.Empty;
    }
}
