namespace Lib.Core.Interfaces
{
    /// <summary>
    /// Объект, реализующий этот интерфейс, должен быть доступен
    /// из любого места приложения. Интерфейс получает список ролей,
    /// специфичных для данного приложения.
    /// </summary>
    public interface ISessionContext<TRole> where TRole : System.Enum
    {
        /// <summary>
        /// Коллекция ролей текущего пользователя.
        /// </summary>
        ICollection<TRole> Roles { get; }
        /// <summary>
        /// Обычно токен заполняется в HandleSuccess той вьюмодели,
        /// которая отвечает за LoginForm
        /// </summary>
        string SessionToken { get; set; }
        /// <summary>
        /// Срок действия токена
        /// </summary>
        DateTime ValidTill { get; set; }
        /// <summary>
        /// Дата последней аутентификации
        /// </summary>
        DateTime LastLoginDT { get; set; }
        /// <summary>
        /// Обновляет токен сессии, дату логина и добавляет роль
        /// в коллекцию
        /// </summary>
        void Login(string sessionToken, TRole role);
        /// <summary>
        /// Загрузит специфичную для платформы формы аутентификации
        /// </summary>
        void ShowLoginForm();
        /// <summary>
        /// Загрузит сообщение об отсутствии прав на выполнение операции.
        /// Вызывается, например, в обработчике исключения Http 403
        /// </summary>
        void ShowForbiddenMessage();
        /// <summary>
        /// Проверит наличие у пользователя соответствующей привилегии.
        /// Может вызываться, например, для проверки доступа на выполнение операций,
        /// которые даже не требуют обращения к серверу.
        /// </summary>
        bool CheckPermit(TRole role);
        /// <summary>
        /// Просто очистит SessionToken
        /// </summary>
        void Logout();
    }
}
