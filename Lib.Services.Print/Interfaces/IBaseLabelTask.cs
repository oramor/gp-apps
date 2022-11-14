namespace Lib.Services.Print
{
    /// <summary>
    /// Любое задание на печать этикетки содержит, помимо <see cref="ILabelSetup">
    /// сетапа</see>, количество копий, которое нужно напечатать, а так же параметры
    /// конкретной этикетки.
    /// </summary>
    public interface IBaseLabelTask
    {
        public ILabelSetup LabelSetup { get; init; }
        public int Copy { get; init; }
    }
}
