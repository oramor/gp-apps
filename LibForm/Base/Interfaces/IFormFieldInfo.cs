namespace LibForm
{
    public interface IFormFieldInfo
    {
        string Name { get; init; }
        string Value { get; init; }
    }

    public interface IFormFieldDTO : IFormFieldInfo
    {
        string? ErrorMessage { get; set; }
    }
}
