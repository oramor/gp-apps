using LibCore;
using System;
using System.Net.Http;

namespace LibForm.Base
{
    internal abstract class BaseFormContext : BaseContext
    {
        BaseFormContext()
        {
            // Не просто собираем данные со вложенных полей формы,
            // а упаковываем их в формат multipart/form-data
            MultipartFormDataContent _formData = null;
        }

        /// <summary>
        /// Вызывается в конструкторе. Обходит children-элементы, извлекая данные
        /// из тех объектов, которые соответствуют критерию поля формы
        /// </summary>
        void MakeFormData() { throw new NotFiniteNumberException(); }

        /// <summary>
        /// Отправляет данные на сервер и получает json. При наличии в ответе
        /// ноды с ошибками, отправляет из в SetFieldsErrors()
        /// </summary>
        async void SendForm() { throw new NotImplementedException(); }

        /// <summary>
        /// В цикле применяет к каждому элементу из children ошибку
        /// </summary>
        void SetFieldErrors() { throw new NotImplementedException(); }

        /// <summary>
        /// Устанавливает одиночную ошибку для формы при наличии
        /// соответствующей ноды в ответе сервера
        /// </summary>
        void SetFormError() { throw new NotImplementedException(); }
    }
}
