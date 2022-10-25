using LibCore;
using System.Windows;

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

        public override void Execute(object? formContext)
        {
            MessageBox.Show("Send!!!");
        }
    }
}
