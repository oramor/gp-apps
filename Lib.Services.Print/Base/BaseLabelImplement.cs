using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public abstract class BaseLabelImplement : ILabelImplement
    {
        public CommonLabelEnum CommonLabelKey { get; init; }
        public LabelSizeEnum LabelSizeKey { get; init; }
        public DriverAdapterEnum DriverAdapterKey { get; init; }
    }
}
