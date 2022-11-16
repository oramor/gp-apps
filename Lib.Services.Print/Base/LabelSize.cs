namespace Lib.Services.Print
{
    internal class LabelSize : ILabelSize
    {
        public string LabelSizeTitle => "W" + LabelSizeWidth.ToString() + "H" + LabelSizeHeight.ToString();

        public SupportedLabelSizeEnum LabelSizeId { get; set; }
        public int LabelSizeHeight { get; set; }
        public int LabelSizeWidth { get; set; }
    }
}
