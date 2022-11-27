using Gui.BuyerDesktop.Windows;
using Lib.Services.Print;
using Lib.Wpf.Controls.Form;
using Lib.Wpf.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Input;


namespace Gui.BuyerDesktop.Contexts
{
    public interface ILabelSetupContext : IEntityPoolContext, ICanRemoveItems<ILabelSetup>
    {
        ICollection<ILabelSetup> LabelSetups { get; }
    }

    public class LabelSetupContext : BaseContext, ILabelSetupContext
    {
        private readonly IPrintService _printService = GetPrintService();
        private Window? _formWindow;

        public string EntityName => "Сетап";

        public Window ParentWindow { get; set; } = App.Current.MainWindow;
        public Window FormWindow
        {
            get => _formWindow ??= new LabelSetupForm();
            set => _formWindow = value;
        }

        public ICollection<ILabelSetup> LabelSetups => _printService.LabelSetups;

        public ICommand ShowCreationFormCommand => new ShowLabelSetupFormCmd(this);

        #region ICanRemoveItems impl

        public ICommand RemoveItemCommand => new RemoveItemCmd(this);

        public void RemoveItem(ILabelSetup item)
        {
            _ = LabelSetups.Remove(item);
        }

        #endregion

        /// <summary>
        /// Из этого метода может вызываться метод, который восстановит
        /// сохраненные на компьютере сетпаы принтера
        /// </summary>
        private static IPrintService GetPrintService()
        {
            var service = App.Host.Services.GetService<IPrintService>();
            if (service == null) throw new ApplicationException("Not found printer service");
            return service;
        }

        #region Command classes

        private class RemoveItemCmd : BaseCommand
        {
            private ILabelSetupContext _ctx;

            public RemoveItemCmd(ILabelSetupContext context)
            {
                _ctx = context;
            }

            public override void Execute(object? parameter)
            {
                var labelSetup = (LabelSetup)parameter;
                _ctx.RemoveItem(labelSetup);
            }
        }

        private class ShowLabelSetupFormCmd : BaseCommand
        {
            private readonly LabelSetupContext _parent;

            public ShowLabelSetupFormCmd(LabelSetupContext parent)
            {
                _parent = parent;
            }

            public override void Execute(object? parameter)
            {
                _ = new LabelSetupFormContext(_parent);
            }
        }

        #endregion

        public interface ILabelSetupFormContext : IBaseFormContext, ILocalHandledForm
        {
            IReadOnlyCollection<IPrinter> SystemPrinters { get; }
            ICollection<ILabelSize> LabelSizes { get; }
            ICollection<IDriverAdapter> DriverAdapters { get; }
            ICollection<ICommonLabel> CommonLabels { get; }
        }

        private class LabelSetupFormContext : BaseModalFormContext, ILabelSetupFormContext
        {
            public LabelSetupFormContext(IEntityPoolContext parentContext) : base(parentContext)
            {
            }

            #region SystemPrinter

            public IReadOnlyCollection<IPrinter> SystemPrinters
            {
                get {
                    var printers = new LocalPrintServer().GetPrintQueues().Select(v => new SystemPrinter() {
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

            #region LocalHandler

            public LocalFormResult LocalHandler()
            {
                var result = new LocalFormResult();

                var service = App.Host.Services.GetService<IPrintService>();
                if (service == null) throw new ApplicationException("Not found printer service");

                // Duplicity controller
                var cnt = service.LabelSetups.Where(v => v.SupportedLabel.CommonLabel == CommonLabel).Count();
                if (cnt > 0)
                {
                    var dto = new ErrorFormDto() {
                        Message = "Сетап для этикетки данного типа уже создан. Сперва удалите его."
                    };

                    result.SetDto(dto);
                    return result;
                }

                // Find supported label
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

                service.LabelSetups.Add(labelSetup);

                var successDto = new SuccessFormDto();
                result.SetDto(successDto);
                return result;
            }

            #endregion

            public override ICommand SendFormCommand => SendCommandFabric.GetCommand(this);
        }
    }
}
