namespace Lib.Services.Print
{
    public class CommonLabel : ICommonLabel
    {
        public required int Id { get; init; }
        public string Title => Description;
        public string Description { get; set; } = string.Empty;
    }
}
