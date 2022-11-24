namespace Lib.Core
{
    /// <summary>
    /// Title всегда является производным значением. Хотя бы по соображениям
    /// локализации. Это значение никогда не может задаваться явно, но может
    /// быть перекрыто через description
    /// </summary>
    public interface IEntity
    {
        string Title { get; }
    }
}
