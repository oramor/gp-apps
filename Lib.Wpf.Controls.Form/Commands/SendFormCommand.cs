using Lib.Services;
using Lib.Wpf.Core;
using System.Net.Http;
using System.Text.Json;

namespace Lib.Wpf.Controls.Form
{
    internal class SendFormCommand : BaseCommand
    {
        private readonly IServerHandledForm _context;

        public SendFormCommand(IServerHandledForm ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Команда запрашивает значения полей с формы, выполняет их упаковку в формат Multipart,
        /// отправляет данные на сервер, парсит Dto и вызывает соответствующие методы их обработки
        /// на форме
        /// </summary>
        public async override void Execute(object? obj)
        {
            // Ничего не делаем, если форма еще не готова к отправке.
            // Актуально для отслеживания нажатия клавиши Enter
            if (!_context.IsFormReadyToSend) return;

            _context.IsLoading = true;

            if (_context.TopErrorMessage != string.Empty)
            {
                _context.TopErrorMessage = string.Empty;
            }

            var formFields = _context.GetFormFields();

            using var content = new MultipartFormDataContent();
            foreach (var field in formFields)
            {
                var fieldName = JsonNamingPolicy.CamelCase.ConvertName(field.Name);
                var fieldValue = new StringContent(field.Value);

                content.Add(fieldValue, fieldName);
            }

            var client = new HttpService();
            IHttpService_FormResult formResult = await client.SendMultipartForm(content, _context.Endpoint);
            var formHandler = formResult.FormHandler;

            HttpContent? preDto = formResult.FormDto;
            if (preDto == null)
            {
                throw new ApplicationException("FromDTO is required, but null");
            }

            // На основе метки из formHandler определяем, в какой объект нужно упаковать результат
            switch (formHandler)
            {
                case "formSuccess":
                    {
                        SuccessFormDto dto = await HttpService.DeserializeDto<SuccessFormDto>(preDto);
                        _context.HandleSuccess(dto);
                        break;
                    }
                case "formError":
                    {
                        ErrorFormDto dto = await HttpService.DeserializeDto<ErrorFormDto>(preDto);
                        _context.HandleError(dto);
                        break;
                    }
                case "formInvalid":
                    {
                        InvalidFormDto dto = await HttpService.DeserializeDto<InvalidFormDto>(preDto);
                        _context.HandleInvalid(dto);
                        break;
                    }
                default:
                    throw new NotImplementedException($"Not supported formHandler [{formHandler}]");
            }

            _context.IsLoading = false;
        }
    }
}
