namespace Lib.Services.Print
{
    public class CommonLabel : ICommonLabel
    {
        public string Title => Description;
        public string Description { get; set; } = string.Empty;
    }
}
