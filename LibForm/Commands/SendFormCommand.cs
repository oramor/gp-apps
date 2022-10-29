using LibCore;
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

            _context.IsLoading = false;
        }
    }
}
