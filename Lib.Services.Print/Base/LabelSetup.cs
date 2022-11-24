namespace Lib.Services.Print
{
    public class LabelSetup : ILabelSetup
    {
        public string Title => SupportedLabel.Title + "Принтер " + SystemPrinter.Title;
        public required ISupportedLabel SupportedLabel { get; init; }
        public required IPrinter SystemPrinter { get; init; }
    }
}
