using LibCore;
using LibForm.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace LibForm.Commands
{
    internal class SendFormCommand : BaseCommand
    {
        private readonly BaseFormContext _context;

        public SendFormCommand(BaseFormContext ctx)
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
            _context.IsLoading = true;

            if (_context.TopErrorMessage != string.Empty)
            {
                _context.TopErrorMessage = string.Empty;
            }

            List<IFormFieldInfo> formFields = _context.GetFormFields();

            using var content = new MultipartFormDataContent();
            foreach (var field in formFields)
            {
                var fieldName = JsonNamingPolicy.CamelCase.ConvertName(field.Name);
                var fieldValue = new StringContent(field.Value);

                content.Add(fieldValue, fieldName);
            }

            var client = new HttpService();
            FormResult formResult = await client.SendMultipartForm(content, _context.Endpoint);
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
                        SuccessFormDto dto = await HttpService.SerializeDto<SuccessFormDto>(preDto);
                        _context.SuccessHandler(dto);
                        break;
                    }
                case "formError":
                    {
                        ErrorFormDto dto = await HttpService.SerializeDto<ErrorFormDto>(preDto);
                        _context.ErrorHandler(dto);
                        break;
                    }
                case "formInvalid":
                    {
                        InvalidFormDto dto = await HttpService.SerializeDto<InvalidFormDto>(preDto);
                        _context.InvalidHandler(dto);
                        break;
                    }
                default:
                    throw new NotImplementedException($"Not supported formHandler [{formHandler}]");
            }

            _context.IsLoading = false;
        }
    }
}
