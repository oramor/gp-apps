using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    /// <summary>
    /// По шаблону Strategy этот класс является контекстным,
    /// потому что определяет интерфейс для стратении (конкретный
    /// алгоритм печати этикетки), а так же хранит ссылку на эту
    /// стратегию.
    /// </summary>
    public class SupportedLabel : ISupportedLabel
    {
        public int Id { get => this.GetHashCode(); init => this.GetHashCode(); }

        public required ICommonLabel CommonLabel { get; init; }
        public required ILabelSize LabelSize { get; init; }
        public required IDriverAdapter DriverAdapter { get; init; }

        #region Delegates for ExecutePrint method

        private readonly Action<TestLabelTask>? TestLabelTaskExecutor;
        private readonly Action<IProductLabelTask>? ProductLabelTaskExecutor;

        #endregion

        public SupportedLabel(Action<TestLabelTask> executor)
        {
            TestLabelTaskExecutor = executor;
        }

        public SupportedLabel(Action<IProductLabelTask> executor)
        {
            ProductLabelTaskExecutor = executor;
        }

        public string Title => string.Format("{0}, {1} (драйвер {2})", CommonLabel.Title, LabelSize.Title, DriverAdapter.Title);

        public void ExecutePrint(TestLabelTask labelTask) => TestLabelTaskExecutor?.Invoke(labelTask);

        public void ExecutePrint(IProductLabelTask labelTask) => ProductLabelTaskExecutor?.Invoke(labelTask);
    }
}
