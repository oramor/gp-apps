namespace Lib.Services.Print
{
    public enum LabelSizeEnum
    {
        W43xH25
    }

    public interface ILabelSize
    {
        public string Title { get; }
        public int Height { get; init; }
        public int Width { get; init; }
        public string TsplCommand { get; init; }
    }
}
