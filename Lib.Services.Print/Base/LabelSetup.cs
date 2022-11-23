namespace Lib.Services.Print
{
    public class LabelSetup : ILabelSetup
    {
        public required ISupportedLabel SupportedLabel { get; init; }
        public required IPrinter SystemPrinter { get; init; }
    }
}
