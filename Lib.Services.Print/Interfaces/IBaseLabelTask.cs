namespace Lib.Services.Print.Interfaces
{
    /// <summary>
    /// Любое задание на печати этикетки должно включать ссылку
    /// на заранее созданный сетап, по которому программа определит
    /// принтер и формат для выбранного типа этикетки
    /// </summary>
    public interface IBaseLabelTask
    {
        public ILabelSetup LabelSetup { get; init; }
    }
}
