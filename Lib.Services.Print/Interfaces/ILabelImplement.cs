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
        public CommonLabelEnum LabelKey { get; init; }
        public LabelSizeEnum LabelSizeKey { get; init; }
        public DriverAdapterEnum DriverAdapterKey { get; init; }
    }
}
