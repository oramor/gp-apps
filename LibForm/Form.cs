using System;
using System.Net.Http;
using System.Windows.Controls;

namespace LibForm
{
    /// <summary>
    /// Этому интерфейсу должны соответствовать поля внутри FormData
    /// </summary>
    interface IFormField
    {
        string FieldName { get; set; }
        string Value { get; set; }
    }

    internal class Form : Panel
    {
        Form()
        {
            var ctx = DataContext;
            UIElementCollection children = Children;

            // Прибиваем к верхней границе родителя
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            // Не просто собираем данные со вложенных полей формы,
            // а упаковываем их в формат multipart/form-data
            MultipartFormDataContent _formData = null;

            // MakeFormData();
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

        // Реализация DependencyProperty для SendApi и SendButtonTitle

        // Реализация команды sendFormCommand для кнопки "Отпрвить"
    }
}
