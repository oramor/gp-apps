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
    public interface ISupportedLabel
    {
        public ICommonLabel CommonLabel { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }
    }
}
