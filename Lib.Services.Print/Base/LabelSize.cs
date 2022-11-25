namespace Lib.Services.Print
{
    internal class LabelSize : ILabelSize
    {
        public required int Id { get; init; }
        public string Title => "W" + Width.ToString() + "H" + Height.ToString();

        public required int Height { get; init; }
        public required int Width { get; init; }
        public required string TsplCommand { get; init; }
    }
}
