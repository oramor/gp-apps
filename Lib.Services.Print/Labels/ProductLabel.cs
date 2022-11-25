namespace Lib.Services.Print.Labels
{
    /// <summary>
    /// Должен поддерживаться вьюмоделью, которая отправляет команду
    /// на печать этикетки данного вида
    /// </summary>
    public interface IProductLabelData
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
    }

    public interface IProductLabelTask : IBaseLabelTask, IProductLabelData
    {
    }
}
