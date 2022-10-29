using System.Net.Http;

namespace LibCore
{
    public class DataResult
    {
        /// <summary>
        /// Метка извлекается из заголовка 'nervus-base-handler'
        /// и указывает базовый обработик. Этот заголовок всегда
        /// должен присутствовать в ответе, поэтому свойство
        /// обязательное
        /// </summary>
        public string BaseHandler { get; set; } = string.Empty;

        /// <summary>
        /// Метка извлекается из заголовка 'nervus-form-handler'
        /// и указывает обработчику формы, какой класс выбрать
        /// для десериализации
        /// </summary>
        public string? FormHandler { get; set; } = string.Empty;

        /// <summary>
        /// За парсинг будет отвечать класс обработчика формы,
        /// поэтому контент передается ему в незименном виде
        /// </summary>
        public HttpContent? Dto { get; set; }
    }
}