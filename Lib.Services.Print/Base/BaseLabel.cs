using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print.Base
{
    public abstract class BaseLabel
    {
        abstract protected string LabelName { get; }
        abstract public SupportedLabelSizeEnum SizeEnum { get; }
        abstract public SupportedPrinterAdapterEnum PrinterAdapterEnum { get; }

        public string SizeName
        {
            get {
                if (SizeEnum == SupportedLabelSizeEnum.W43xH25) return "43x25 mm";
                return string.Empty;
            }
        }

        public string PrinterAdapterName
        {
            get {
                if (PrinterAdapterEnum == SupportedPrinterAdapterEnum.TscLib) return "TSCLib";
                return string.Empty;
            }
        }
    }
}
