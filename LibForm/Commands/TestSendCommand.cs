using LibCore;
using System;
using System.Net.Http;
using System.Text.Json;

namespace LibForm
{
    internal class TestSendCommand : BaseCommand
    {
        class ServerResponse
        {
            public string Handler { get; set; } = string.Empty;
            public FormResult Dto { get; set; } = new FormResult();
        }

        class FormResult
        {
            public string FormState { get; set; } = string.Empty;
            public FormResultDTO FormDto { get; set; } = new FormResultDTO();

        }

        class FieldErrorInfo
        {
            public string Name { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
        }

        class FormResultDTO
        {
            /// <summary>
            /// Ошибка, которая должна отображаться в верхней части формы.
            /// Есть предложение удалить это поле (см. сервер).
            /// Относится к InvalidFormDTO
            /// </summary>
            public string? TopError { get; set; }

            /// <summary>
            /// Список полей, в которых обнаружена ошибка
            /// Относится к InvalidFormDTO
            /// </summary>
            public FieldErrorInfo[]? Fields { get; set; }

            /// <summary>
            /// Сообщение успешной отправки формы. Относится к SuccessFormDTO
            /// </summary>
            public string? Title { get; set; }

            /// <summary>
            /// Содержит как результат ошибки в случае кода formError,
            /// так и сообщение об успехе в случае кода formSuccess
            /// </summary>
            public string? Message { get; set; }

        }

        public async override void Execute(object? parameter)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent()) {
                client.DefaultRequestHeaders.Add("Authorization", "ssdsd");
                var fieldValue = new StringContent("fgff");
                var fieldName = JsonNamingPolicy.CamelCase.ConvertName("Login");
                var fieldValue2 = new StringContent("sssdddds");
                var fieldName2 = JsonNamingPolicy.CamelCase.ConvertName("Password");
                content.Add(fieldValue, fieldName);
                content.Add(fieldValue2, fieldName2);

                var endpoint = new Uri("http://localhost/api/v1/subjects/login");
                HttpResponseMessage rs = await client.PostAsync(endpoint, content);
                var handlerCode = rs.Headers.GetValues("x-handler-code");
                var httpContent = rs.Content;
                string json = await httpContent.ReadAsStringAsync();

                var options = new JsonSerializerOptions {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                ServerResponse formResult = JsonSerializer.Deserialize<ServerResponse>(json, options)!;
                string formState = formResult.Dto.FormState;
            };


        }

        //private static HttpStringContent MakeStringContent()
    }
}
