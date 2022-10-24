using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LibCore;

namespace LibForm.Commands
{
    internal class SendFormCommand : BaseCommand
    {
        public override bool CanExecute(object? obj)
        {
            return true;
        }

        public override void Execute(object? formContext)
        {
            MessageBox.Show("Sent");
        }
    }
}
