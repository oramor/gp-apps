using Gui.BuyerDesktop.Windows;
using Lib.Services.Print;
using Lib.Wpf.Controls.Form;
using Lib.Wpf.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace Gui.BuyerDesktop.Contexts
{
    public class LabelSetupContext : BaseContext, ILabelSetupContext
    {
        private readonly ICollection<ILabelSetup> _labelSetups = new Collection<ILabelSetup>();

        public readonly System.Windows.Window _ownerWindow = App.Current.MainWindow;

        public ICollection<ILabelSetup> LabelSetups => _labelSetups;

        public ICommand OpenLabelSetupForm => new ShowLabelSetupFormCommand(this);

        private class ShowLabelSetupFormCommand : BaseCommand
        {
            private readonly LabelSetupContext _parent;

            public ShowLabelSetupFormCommand(LabelSetupContext parent)
            {
                _parent = parent;
            }

            public override void Execute(object? parameter)
            {
                var context = new LabelSetupFormContext(_parent);
                var window = new LabelSetupForm() {
                    Owner = _parent._ownerWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
                    DataContext = context
                };
                window.Owner.Effect = new BlurEffect {
                    Radius = 1,
                    KernelType = KernelType.Box
                };
                window.Closing += context.OnWindowClosing;
                window.ShowDialog();
            }
        }

        public interface IModalChildWindow
        {
            public void OnWindowClosing(object sender, CancelEventArgs e);
        }

        public interface ILabelSetupFormContext : IBaseFormContext, ILocalHandledForm
        {
        }

        private class LabelSetupFormContext : BaseFormContext, IModalChildWindow, ILabelSetupFormContext
        {
            private readonly LabelSetupContext _parent;

            public LabelSetupFormContext(LabelSetupContext parent)
            {
                _parent = parent;
            }

            public IReadOnlyCollection<IPrinter> SystemPrinters
            {
                get {
                    var printers = new LocalPrintServer().GetPrintQueues().Select(v => new SystemPrinter() {
                        Name = v.Name,
                        DriverName = v.QueueDriver.Name,
                        PortName = v.QueuePort.Name,
                        Priority = v.Priority
                    }).ToList().AsReadOnly();

                    return printers;
                }
            }

            public override ICommand SendFormCommand => SendCommandFabric.GetCommand(this);

            public LocalFormResult LocalHandler()
            {
                throw new System.NotImplementedException();
            }

            public void OnWindowClosing(object sender, CancelEventArgs e)
            {
                _parent._ownerWindow.Effect = null;
            }
        }
    }
}
