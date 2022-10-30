﻿using LibCore;
using LibForm.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace LibForm
{
    public abstract class BaseFormContext : BaseContext
    {
        private bool _isFormReadyToSend = true;
        private bool _isLoading = false;
        private string _topErrorMessage = string.Empty;

        public BaseFormContext()
        {
        }

        /// <summary>
        /// Содержит ссылку, по которой форма должна отправлять запрос к API
        /// </summary>
        public abstract Uri Endpoint { get; }

        /// <summary>
        /// Каждая форма должна реализовать метод, который вызывается в случае
        /// получения от сервера ответа с кодом formSuccess. Например, может
        /// происходить переход на другую страницу, либо открытие нового окна
        /// </summary>
        public abstract void SuccessHandler();

        /// <summary>
        /// Помечает на форме поля, которые не прошли серверную валидацию
        /// </summary>
        public void MarkInvalidFields()
        {

        }

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
            set { Set(ref _topErrorMessage, value); }
        }

        /// <summary>
        /// Указывает, что форма находится в статусе отправки данных на сервер.
        /// Во время отправки кнопка меняет свой дизайн, а к полям применяется
        /// стиль FormFieldDisableStyle
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set { Set(ref _isLoading, value); }
        }

        public ICommand SendFormCommand => new SendFormCommand(this);

        /// <summary>
        /// Вызывается в конструкторе. Обходит children-элементы, извлекая данные
        /// из тех объектов, которые соответствуют критерию поля формы
        /// </summary>
        //void MakeFormData() { throw new NotFiniteNumberException(); }

        /// <summary>
        /// Отправляет данные на сервер и получает json. При наличии в ответе
        /// ноды с ошибками, отправляет из в SetFieldsErrors()
        /// </summary>
        //async void SendForm() { throw new NotImplementedException(); }

        /// <summary>
        /// В цикле применяет к каждому элементу из children ошибку
        /// </summary>
        //void SetFieldErrors() { throw new NotImplementedException(); }

        /// <summary>
        /// Устанавливает одиночную ошибку для формы при наличии
        /// соответствующей ноды в ответе сервера
        /// </summary>
        //void SetFormError() { throw new NotImplementedException(); }
    }
}
