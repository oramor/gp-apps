﻿namespace Lib.Services
{
    public class FormResult
    {
        /// <summary>
        /// Метка извлекается из заголовка 'nervus-form-handler'
        /// и указывает обработчику формы, какой класс выбрать
        /// для десериализации
        /// </summary>
        public string FormHandler { get; set; } = string.Empty;

        /// <summary>
        /// За парсинг будет отвечать класс обработчика формы,
        /// поэтому контент передается ему в незименном виде
        /// </summary>
        public HttpContent? FormDto { get; set; }
    }
}
