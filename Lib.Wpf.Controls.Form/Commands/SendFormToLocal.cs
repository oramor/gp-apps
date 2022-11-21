using Lib.Services;
using Lib.Wpf.Core;
using System.Net.Http;
using System.Text.Json;

namespace Lib.Wpf.Controls.Form
{
    internal class SendFormToLocal : BaseCommand
    {
        private readonly ILocalHandledForm _context;

        public SendFormToLocal(ILocalHandledForm ctx)
        {
            _context = ctx;
        }

        public async override void Execute(object? obj)
        {
            if (!_context.IsFormReadyToSend) return;

            _context.IsLoading = true;

            if (_context.TopErrorMessage != string.Empty)
            {
                _context.TopErrorMessage = string.Empty;
            }

            var result = _context.LocalHandler();

            if (result.Invalid is not null)
            {
                _context.HandleInvalid(result.Invalid);
            }
            else if (result.Error is not null)
            {
                _context.HandleError(result.Error);
            }
            else if (result.Success is not null)
            {
                _context.HandleSuccess(result.Success);
            }

            _context.IsLoading = false;
        }
    }
}
