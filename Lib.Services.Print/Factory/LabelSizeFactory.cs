namespace Lib.Services.Print
{
    public static class LabelSizeFactory
    {
        private static readonly IList<ILabelSize> _labelSizes = new List<ILabelSize>() {
            new LabelSize() { Id = 1, Height = 25, Width = 43, TsplCommand = "SIZE 43 mm, 25 mm" }
        };

        public static IList<ILabelSize> GetAll() => _labelSizes;

        public static ILabelSize W43xH25 => _labelSizes[0];
    }
}
