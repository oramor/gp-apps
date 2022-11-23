using Gui.BuyerDesktop.Windows;
using Lib.Services.Print;
using Lib.Wpf.Controls.Form;
using Lib.Wpf.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        // TODO move to PrintService
        private readonly ObservableCollection<ILabelSetup> _labelSetups = new();

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

        public interface ILabelSetupFormContext : IBaseFormContext, ILocalHandledForm, IModalChildWindow
        {
            IReadOnlyCollection<IPrinter> SystemPrinters { get; }
            ICollection<ILabelSize> LabelSizes { get; }
            ICollection<IDriverAdapter> DriverAdapters { get; }
            ICollection<ICommonLabel> CommonLabels { get; }
        }

        private class LabelSetupFormContext : BaseFormContext, ILabelSetupFormContext
        {
            private readonly LabelSetupContext _parent;

            public LabelSetupFormContext(LabelSetupContext parent)
            {
                _parent = parent;
            }

            #region SystemPrinter

            public IReadOnlyCollection<IPrinter> SystemPrinters
            {
                get {
                    var printers = new LocalPrintServer().GetPrintQueues().Select(v => new SystemPrinter() {
                        Title = v.Name,
                        DriverName = v.QueueDriver.Name,
                        PortName = v.QueuePort.Name,
                        Priority = v.Priority
                    }).ToList().AsReadOnly();

                    return printers;
                }
            }

            private IPrinter _systemPrinter;
            public IPrinter SystemPrinter
            {
                get => _systemPrinter;
                set => Set(ref _systemPrinter, value);
            }

            private IPrinter _systemPrinterError;
            public IPrinter SystemPrinterError
            {
                get => _systemPrinterError;
                set => Set(ref _systemPrinterError, value);
            }

            #endregion

            #region LabelSize

            public ICollection<ILabelSize> LabelSizes => LabelSizeFactory.GetAll();

            private ILabelSize _labelSize;
            public ILabelSize LabelSize
            {
                get => _labelSize;
                set => Set(ref _labelSize, value);
            }

            private string _labelSizeError = string.Empty;
            public string LabelSizeError
            {
                get => _labelSizeError;
                set => Set(ref _labelSizeError, value);
            }

            #endregion

            #region CommonLabel

            public ICollection<ICommonLabel> CommonLabels => CommonLabelFactory.GetAll();

            private ICommonLabel _commonLabel;
            public ICommonLabel CommonLabel
            {
                get => _commonLabel;
                set => Set(ref _commonLabel, value);
            }

            private string _commonLabelError = string.Empty;
            public string CommonLabelError
            {
                get => _commonLabelError;
                set => Set(ref _commonLabelError, value);
            }

            #endregion

            #region DriverAdapter

            public ICollection<IDriverAdapter> DriverAdapters => DriverAdapterFactory.GetAll();

            private IDriverAdapter _driverAdapter;
            public IDriverAdapter DriverAdapter
            {
                get => _driverAdapter;
                set => Set(ref _driverAdapter, value);
            }

            private string _driverAdapterlError = string.Empty;
            public string DriverAdapterError
            {
                get => _driverAdapterlError;
                set => Set(ref _driverAdapterlError, value);
            }

            #endregion

            public override ICommand SendFormCommand => SendCommandFabric.GetCommand(this);

            public LocalFormResult LocalHandler()
            {
                var result = new LocalFormResult();

                // Duplicity controller
                //var cnt = (from labelSetup in _parent.LabelSetups
                //           where labelSetup.SupportedLabel.CommonLabel == CommonLabel
                //           select labelSetup).Count();
                var cnt = _parent.LabelSetups.Select(v => v.SupportedLabel.CommonLabel == CommonLabel).Count();
                if (cnt > 0)
                {
                    var dto = new ErrorFormDto() {
                        Message = "Сетап для этикетки данного типа уже создан. Сперва удалите его."
                    };

                    result.SetDto(dto);
                    return result;
                }

                // Find supported label
                var service = App.Host.Services.GetService<IPrintService>();

                if (service == null) throw new ApplicationException("Not found printer service");

                var supportedLabel = (from label in service.SupportedLabels
                                      where label.CommonLabel == CommonLabel &&
                                            label.LabelSize == LabelSize &&
                                            label.DriverAdapter == DriverAdapter
                                      select label).FirstOrDefault();

                if (supportedLabel == null)
                {
                    var dto = new ErrorFormDto() {
                        Message = "Этикетка с такой конфигурацией не поддерживается"
                    };

                    result.SetDto(dto);
                    return result;
                }


                var labelSetup = new LabelSetup() {
                    SupportedLabel = supportedLabel,
                    SystemPrinter = this.SystemPrinter
                };

                _parent.LabelSetups.Add(labelSetup);

                var successDto = new SuccessFormDto();
                result.SetDto(successDto);
                return result;
            }

            public void OnWindowClosing(object sender, CancelEventArgs e)
            {
                //var a = LabelSize;
                //Console.WriteLine(a.ToString());
                _parent._ownerWindow.Effect = null;
            }
        }
    }
}
