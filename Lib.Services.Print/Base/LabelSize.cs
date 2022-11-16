namespace Lib.Services.Print
{
    internal class LabelSize : ILabelSize
    {
        public string Title => "W" + Width.ToString() + "H" + Height.ToString();

        public required LabelSizeEnum Key { get; init; }
        public required int Height { get; init; }
        public required int Width { get; init; }
    }
}
