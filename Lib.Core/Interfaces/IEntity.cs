namespace Lib.Core
{
    /// <summary>
    /// Title всегда является производным значением. Хотя бы по соображениям
    /// локализации. Это значение никогда не может задаваться явно, но может
    /// быть перекрыто через description
    /// </summary>
    public interface IEntity<T>
    {
        T Id { get; init; }
        string Title { get; }
    }
}
