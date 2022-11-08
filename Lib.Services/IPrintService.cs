namespace Lib.Services
{
    public interface IPrintService
    {
        /// <summary>
        /// Расчет кода SKU выполняется на стороне базе отдельной функцией,
        /// которая задействует для этого параметры регистра (класс качества
        /// товара, шаблон упаковки, код товарной позиции и т.д.)
        /// </summary>
        Task PrintIncomeLabel(int sku);
    }

    #region Label params
    /// <summary>
    /// Свойства этикеток для каждого маркетплейса различны. И даже при одинаковых
    /// свойствах могут различаться параметры (например, разная предельно допустимая
    /// длина для названия товара)
    /// </summary>
    public interface IPrintService_OzonLabelParams
    {
        string ProductName { get; set; }
    }

    public interface IPrintService_WbLabelParams
    {
        string ProductName { get; set; }
    }
    #endregion
}
