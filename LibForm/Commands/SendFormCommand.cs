using LibCore;
using System.Threading.Tasks;

namespace LibForm.Commands
{
    internal class SendFormCommand : BaseCommand
    {
        private BaseFormContext _context;

        public SendFormCommand(BaseFormContext ctx)
        {
            _context = ctx;
        }
        public override bool CanExecute(object? parameter) => true;

        public async override void Execute(object? formContext)
        {
            _context.TopErrorMessage = "ddfddfd";
            _context.IsLoading = true;
            await Task.Delay(2000);
            _context.IsLoading = false;
            //MessageBox.Show(_context.TopErrorMessage);
        }

        //private Task SendHandle()
        //{

        //}
    }
}
