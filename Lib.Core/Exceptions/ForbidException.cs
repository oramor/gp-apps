using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core
{
    /// <summary>
    /// Ошибка этого типа выбрасывается из методов проверки прав
    /// доступа. Поскольку в такой метод передается идентификатор
    /// роли, он так же может быть передан в экзепшен, что позволит
    /// назвать пользователю роль, которая у него отсутстует
    /// </summary>
    public class ForbidException : Exception
    {
        public ForbidException(string message) : base(message)
        {
        }
    }
}
