using Lib.Models.Dto.Form;
using Lib.Wpf.Controls.Form.Commands;
using Lib.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace Lib.Wpf.Controls.Form.Base
{
    public enum FormStateEnum
    {
        Virgin,
        InProgress,
        Success,
        Invalid,
        Error,
    }

    public abstract class FormContextBase : ContextBase
    {
        /// <summary>
        /// Список свойств класса (не путать с полями формы!), которые хранят
        /// сообщение об ошибке. Заполняется в методе SetFieldError и таким образом
        /// содержит актуальный список полей для текущей итерации формы. Как только
        /// будет получен новый ответ, состояние формы будет сброшено через метод
        /// ResetState(), в том числе очищены поля с ошибками.
        /// </summary>
        private readonly List<PropertyInfo> _errorFieldsList = new();

        public FormContextBase()
        {
        }

        /// <summary>
        /// Содержит ссылку, по которой форма должна отправлять запрос к API
        /// </summary>
        public abstract Uri Endpoint { get; }

        #region State
        /// <summary>
        /// Внешний код может менять статус формы только через методы
        /// обработки формы
        /// </summary>
        private FormStateEnum _state = FormStateEnum.Virgin;
        public FormStateEnum State { get => _state; }
        #endregion

        #region Success Handler
        /// <summary>
        /// Каждая форма должна реализовать метод, который вызывается в случае
        /// получения от сервера ответа с кодом formSuccess. Может выполняться
        /// переход на другую страницу, загрузка нового окна, вывод TopMessage
        /// </summary>
        public virtual void HandleSuccess(SuccessFormDto dto)
        {
            ResetState();

            if (dto.Message != null)
            {
                TopMessage = dto.Message;
            }
        }
        #endregion

        #region Invalid Handler
        /// <summary>
        /// Помечает на форме поля, которые не прошли серверную валидацию
        /// </summary>
        public void HandleInvalid(InvalidFormDto dto)
        {
            ResetState();
            _state = FormStateEnum.Invalid;

            InvalidFormFieldItem[]? invalidFields = dto.Fields;

            if (invalidFields == null)
            {
                throw new ArgumentNullException(nameof(invalidFields));
            }

            foreach (InvalidFormFieldItem field in invalidFields)
            {
                // Conver to PascalCase
                var fieldName = Char.ToUpperInvariant(field.Name[0]) + field.Name[1..];

                SetFieldError(fieldName, field.Message);
            }
        }

        /// <summary>
        /// У каждого свойства, которое соотносится с полем формы должна быть
        /// error-пара (например, Name + NameError). Указанный метод пробует
        /// получить error-свойство и передает в него текст ошибки
        /// </summary>
        private void SetFieldError(string fieldName, string errorMessage)
        {
            string errorPropName = fieldName + "Error";

            var errorProp = this.GetType().GetProperty(errorPropName);
            if (errorProp == null)
            {
                throw new ApplicationException($"Не удалось установить текст ошибки для {fieldName}, т.к. свойство {errorPropName} не обнаружено");
            }

            errorProp.SetValue(this, errorMessage);
            _errorFieldsList.Add(errorProp);
        }
        #endregion

        #region Error Handler
        /// <summary>
        /// Помечает на форме поля, которые не прошли серверную валидацию
        /// </summary>
        public void HandleError(ErrorFormDto dto)
        {
            ResetState();
            _state = FormStateEnum.Invalid;
            TopErrorMessage = dto.Message;
        }
        #endregion

        #region ResetState
        public void ResetState()
        {
            _state = FormStateEnum.Virgin;

            if (TopMessage != string.Empty)
            {
                TopMessage = string.Empty;
            }

            if (TopErrorMessage != string.Empty)
            {
                TopErrorMessage = string.Empty;
            }

            if (_errorFieldsList.Count > 0)
            {
                foreach (var field in _errorFieldsList)
                {
                    field.SetValue(this, string.Empty);
                }

                _errorFieldsList.Clear();
            }
        }
        #endregion

        #region Getting values from fields
        readonly struct FormFieldItem : IFormFieldInfo
        {
            public readonly string Name { get; init; }
            public readonly string Value { get; init; }
        }

        /// <summary>
        /// Утилитарный метод, который проверяет, относится ли свойство класса
        /// к полям формы
        /// </summary>
        private static bool CheckPropertyIsFormField(string fieldName, PropertyInfo[] props)
        {
            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;

                string s = string.Concat(fieldName, "Error");

                // Поле считается подходящим, если удастся найти
                // для него пару с постфиксом Error
                if (propName.Equals(s))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }

        /// <summary>
        /// Возвращает список данных о полях класса
        /// </summary>
        public List<IFormFieldInfo> GetFormFields()
        {
            var formFieldInfoList = new List<IFormFieldInfo>();

            var props = this.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;

                // Пропускаем, если это свойство ошибки (содержит Error)
                if (prop.Name.Contains("Error")) continue;

                // Пропускаем, если свойство не содержит Error-пары (значит
                // это не свойство формы
                if (!CheckPropertyIsFormField(propName, props)) continue;

                var value = (string)prop.GetValue(this)!;

                formFieldInfoList.Add(new FormFieldItem {
                    Name = prop.Name,
                    Value = value ?? string.Empty,
                });
            }

            return formFieldInfoList;
        }
        #endregion

        #region TopMessage
        /// <summary>
        /// Сообщение, которое может выводиться пользователю после успешной отправки
        /// формы. Например, в тех случаях, когда не требуется переход на другую форму,
        /// но уведомить пользователя об успешной отправке все равно нужно
        /// </summary>
        private string _topMessage = string.Empty;
        public string TopMessage
        {
            get => _topMessage;
            set { Set(ref _topMessage, value); }
        }
        #endregion

        #region TopErrorMessage
        /// <summary>
        /// Блок с сообщением, в котором выводится информация об ошибке, относящейся
        /// к обработчику формы на сервере (значение message из ErrorFormDto)
        /// </summary>
        private string _topErrorMessage = string.Empty;
        public string TopErrorMessage
        {
            get => _topErrorMessage;
            set {
                _state = FormStateEnum.Error;
                Set(ref _topErrorMessage, value);
            }
        }
        #endregion

        #region IsLoading
        /// <summary>
        /// Указывает, что форма находится в статусе отправки данных на сервер.
        /// Во время отправки кнопка меняет свой дизайн, а к полям применяется
        /// стиль FormFieldDisableStyle
        /// </summary>
        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set {
                _state = FormStateEnum.InProgress;
                Set(ref _isLoading, value);
            }
        }
        #endregion

        #region IsFormReadyToSend
        /// <summary>
        /// The method determines the possibilities to send Form.
        /// If false, SendButton will be disabled
        /// </summary>
        /// TODO Эта реализация нарушает ППБЛ
        private bool _isFormReadyToSend = true;
        public virtual bool IsFormReadyToSend
        {
            get => _isFormReadyToSend;
            set { _isFormReadyToSend = value; }
        }
        #endregion

        public ICommand SendFormCommand => new SendFormCommand(this);
    }
}
