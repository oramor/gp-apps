namespace Lib.Services.Print
{
    internal class LabelSize : ILabelSize
    {
        public string Title => "W" + Width.ToString() + "H" + Height.ToString();

        public SupportedLabelSizeEnum LabelSizeId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
