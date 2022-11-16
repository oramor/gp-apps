using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    /// <summary>
    /// Типизирует классы, которые непосредственно реализуют
    /// печать этикеток через взаимодействие с драйвером
    /// </summary>
    public interface ILabelImplement
    {
        public SupportedLabelEnum LabelId { get; init; }
        public SupportedLabelSizeEnum LabelSizeId { get; init; }
        public SupportedDriverAdapterEnum DriverAdapterId { get; init; }
    }
}
