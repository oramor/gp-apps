using System.Windows.Input;

namespace Lib.Wpf.Controls.Form
{
    public static class SendCommandFabric
    {
        public static ICommand GetCommand(IServerHandledForm ctx)
        {
            return new SendFormCommand(ctx);
        }

        public static ICommand GetCommand(ILocalHandledForm ctx)
        {
            return new SendFormToLocal(ctx);
        }
    }
}
