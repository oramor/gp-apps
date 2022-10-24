using LibCore;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LibForm
{
    public abstract class BaseFormContext : BaseContext
    {
        private bool _isFormReadyToSend = true;
        private string _topErrorMessage = string.Empty;
        private List<IFormFieldInfo> _formFields = new List<IFormFieldInfo>();

        public BaseFormContext()
        {
            // Не просто собираем данные со вложенных полей формы,
            // а упаковываем их в формат multipart/form-data
            MultipartFormDataContent _formData = null;
        }

        public List<IFormFieldInfo> FormFields
        {
            get => _formFields;
        }

        protected void UpdateFieldForSend(IFormFieldInfo fieldInfo)
        {
            if (_formFields.Contains(fieldInfo)) 
        }

        /// <summary>
        /// The method determines the possibilities to send Form.
        /// If false, SendButton will be disabled
        /// </summary>
        /// TODO Эта реализация нарушает ППБЛ
        public virtual bool IsFormReadyToSend
        {
            get => _isFormReadyToSend;
            set { _isFormReadyToSend = value; }
        }

        public string TopErrorMessage
        {
            get => _topErrorMessage;
            set { _topErrorMessage = value; }
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
