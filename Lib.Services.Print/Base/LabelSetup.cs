namespace Lib.Services.Print
{
    public class LabelSetup : ILabelSetup
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Title => SupportedLabel.Title + "Принтер " + SystemPrinter.Title;
        public required ISupportedLabel SupportedLabel { get; init; }
        public required IPrinter SystemPrinter { get; init; }
    }
}
