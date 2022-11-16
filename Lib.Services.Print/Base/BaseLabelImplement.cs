using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public abstract class BaseLabelImplement : ILabelImplement
    {
        public SupportedLabelEnum LabelId { get; init; }
        public SupportedLabelSizeEnum LabelSizeId { get; init; }
        public SupportedDriverAdapterEnum DriverAdapterId { get; init; }
    }
}
