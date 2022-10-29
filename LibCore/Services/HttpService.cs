using System.Net.Http;
using System.Text.Json;

namespace LibCore
{
    public class HttpService
    {
        private HttpClient client;

        public HttpService()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Это Универсальный метод запроса, который создает инстанс DataResult, в который
        /// упаковывается ответ сервера (без сериализации), а так же коды обработки,
        /// по которым будет подбираться класс для сериализации
        /// </summary>
        private async Task<DataResult> Send(HttpContent content, Uri endpoint)
        {
            HttpResponseMessage result = await client.PostAsync(endpoint, content);

            var baseHandler = result.Headers.GetValues("x-nervus-base-handler").First();
            var formHandler = result.Headers.GetValues("x-nervus-form-handler").First();

            if (baseHandler == null)
            {
                throw new ArgumentException($"BaseHandler is required but empty");
            }

            return new DataResult() {
                BaseHandler = baseHandler,
                FormHandler = formHandler,
                Dto = result.Content
            };
        }

        /// <summary>
        /// Универсальный метод для сериализации полученных с сервера DTO
        /// </summary>
        public static async Task<T> SerializeDto<T>(HttpContent content)
        {
            string json = await content.ReadAsStringAsync();

            var options = new JsonSerializerOptions {
                // Обеспечивает сопоставление camelCase названий полей в исходном
                // JSON с PascalCase свойствами классов, которые должны быть
                // получены в результате десериализации
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var dto = JsonSerializer.Deserialize<T>(json, options)!;
            return dto;
        }

        /// <summary>
        /// Метод для отправки данных формы. Ожидает, что вызывающий код самостоятельно
        /// завернет данные в формат Multipart
        /// </summary>
        public async Task<FormResult> SendMultipartForm(MultipartFormDataContent formData, Uri endpoint)
        {
            DataResult dataResult = await Send(formData, endpoint);

            if (dataResult.FormHandler == null)
            {
                throw new ArgumentException("FormHandler is required but empty");
            }

            return new FormResult() {
                FormHandler = dataResult.FormHandler,
                FormDto = dataResult.Dto
            };
        }
    }
}
