using LibCore;
using System.Threading.Tasks;

namespace LibForm.Commands
{
    internal class SendFormCommand : BaseCommand
    {
        private readonly BaseFormContext _context;

        public SendFormCommand(BaseFormContext ctx)
        {
            _context = ctx;
        }
        public override bool CanExecute(object? parameter) => true;

        public async override void Execute(object? formContext)
        {
            if (_context.TopErrorMessage != string.Empty) {
                _context.TopErrorMessage = string.Empty;
            }

            _context.IsLoading = true;
            await Task.Delay(1000);
            _context.TopErrorMessage = "Ошибка подключения: в данный момент сервис проверки учетных данных не доступен. Попробуйте повторить попытку позже.";
            _context.IsLoading = false;
        }

        //private Task SendHandle()
        //{

        //}
    }
}
