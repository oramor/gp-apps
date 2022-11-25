namespace Lib.Services.Print
{
    public static class CommonLabelFactory
    {
        private static readonly IList<ICommonLabel> _commonLabels = new List<ICommonLabel>() {
            new CommonLabel() { Id = 1, Description = "Тестовая этикетка" },
            new CommonLabel() { Id = 2, Description = "Этикетка товара" },
            new CommonLabel() { Id = 3, Description = "Этикетка партии товара" },
        };

        public static IList<ICommonLabel> GetAll() => _commonLabels;

        public static ICommonLabel TestLabel => _commonLabels[0];
        public static ICommonLabel ProductLabel => _commonLabels[1];
        public static ICommonLabel ProductBathLabel => _commonLabels[2];
    }
}
