using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    /// <summary>
    /// Является контекстным классом, который реализует стратегию печати
    /// этикетки
    /// </summary>
    public class SupportedLabel : ISupportedLabel
    {
        public required ICommonLabel CommonLabel { get; init; }
        public required ILabelSize LabelSize { get; init; }
        public required IDriverAdapter DriverAdapter { get; init; }

        private Action<TestLabelTask>? TestLabelTaskExecutor;
        //private PrintExecutorDelegate<TestLabelTask> TestLabelTaskExecutor;

        //delegate void PrintExecutorDelegate<T>(T labelTask);
        //private ExecutePrintDelegate<TestLabelTask> _executor;

        public string Title => string.Format("{0}, {1} (драйвер {2})", CommonLabel.Title, LabelSize.Title, DriverAdapter.Title);

        public void SetStrategy<T>(Action<T> executor)
        {
            TestLabelTaskExecutor = executor as Action<TestLabelTask>;
        }

        // Создавать перегрузки под каждый тип этикеток или попробовать обобщенный делегат
        public void ExecutePrint(TestLabelTask labelTask) => TestLabelTaskExecutor?.Invoke(labelTask);

        public void ExecutePrint<T>(T labelTask)
        {
            if (labelTask is TestLabelTask) TestLabelTaskExecutor.Invoke(labelTask);
        }
    }
}
