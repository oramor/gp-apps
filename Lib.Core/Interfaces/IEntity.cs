﻿namespace Lib.Core
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Даже у сущностей, относящихся к БД, могут быть разные типы Id,
        /// в зависимости от длинны Int
        /// </summary>
        T Id { get; init; }

        /// <summary>
        /// Title всегда является производным значением. Хотя бы по соображениям
        /// локализации. Это значение никогда не может задаваться явно, но может
        /// быть перекрыто через description
        /// </summary>
        string Title { get; }
    }
}