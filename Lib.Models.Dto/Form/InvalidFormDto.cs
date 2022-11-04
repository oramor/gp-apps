namespace Lib.Models.Dto.Form
{
    public class InvalidFormFieldItem
    {
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    public class InvalidFormDto
    {
        public InvalidFormFieldItem[]? Fields { get; set; }
    }
}
