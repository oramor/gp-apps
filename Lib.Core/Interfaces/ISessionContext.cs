using System.Windows.Input;

namespace Lib.Core.Interfaces
{
    /// <summary>
    /// Объект, реализующий этот интерфейс, должен быть доступен
    /// из любого места приложения в качестве синглтона. Интерфейс
    /// получает список ролей, специфичных для данного приложения.
    /// </summary>
    public interface ISessionContext<T_Role> where T_Role : System.Enum
    {
        /// <summary>
        /// Важно, что внешний код не может напрямую менять состояние
        /// этого флага, только через Login/Logout.
        /// </summary>
        bool IsAuth { get; }
        /// <summary>
        /// Коллекция ролей текущего пользователя.
        /// </summary>
        ICollection<T_Role> Roles { get; set; }
        /// <summary>
        /// Обычно токен заполняется в HandleSuccess той вьюмодели,
        /// которая отвечает за LoginForm
        /// </summary>
        string SessionToken { get; set; }
        /// <summary>
        /// Срок действия токена в секундах
        /// </summary>
        int SessionTokenDuration { get; set; }
        /// <summary>
        /// Обновляет токен сессии, дату логина и добавляет роль
        /// в коллекцию
        /// </summary>
        void Login(string sessionToken, ICollection<T_Role> roles, int sessionTokenDuration);
        /// <summary>
        /// Дата успешного логина. Используется для проверки expired токена.
        /// </summary>
        DateTime LoginDate { get; set; }
        /// <summary>
        /// Загрузит специфичную для платформы формы аутентификации
        /// </summary>
        void ShowLoginForm();
        /// <summary>
        /// Проверит наличие у пользователя соответствующей привилегии и выбросит
        /// ForbidException при ее отстутствии. Может вызываться, например, для проверки
        /// доступа на выполнение операций, которые даже не требуют обращения к серверу.
        /// Обрабатывает Http 403 (Forbidden)
        /// </summary>
        bool CheckPermit(T_Role role);
        /// <summary>
        /// Просто очистит SessionToken
        /// </summary>
        void Logout();
        ICommand ShowLoginFormCmd { get; }
    }
}
