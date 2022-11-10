namespace Lib.Services
{
    public interface IPrintService
    {
        /// <summary>
        /// Расчет кода SKU выполняется на стороне базе отдельной функцией,
        /// которая задействует для этого параметры регистра (класс качества
        /// товара, шаблон упаковки, код товарной позиции и т.д.)
        /// </summary>
        public void PrintLabel<T>(T labelParams) where T: IPrintService_AbstractLabelParams;
    }

    #region Label params

    /// <summary>
    /// Свойства этикеток для каждого маркетплейса различны. И даже при одинаковых
    /// свойствах могут различаться параметры (например, разная предельно допустимая
    /// длина для названия товара)
    /// </summary>
    public interface IPrintService_AbstractLabelParams
    {
        string PrinterName { get; init; }
        int Copy { get; init; }
    }

    public interface IPrintService_OzonLabelParams : IPrintService_AbstractLabelParams
    {
        string ProductName { get; init; }
    }

    public interface IPrintService_WbLabelParams : IPrintService_AbstractLabelParams
    {
        string ProductName { get; init; }
    }

    public interface IPrintService_IncomeProductLabelParams : IPrintService_AbstractLabelParams
    {
        public int ProductId { get; init; }
        public int Sku { get; init; }
    }

    #endregion
}
