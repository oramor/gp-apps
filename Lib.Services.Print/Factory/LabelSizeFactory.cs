using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class LabelSizeFactory
    {
        public static ILabelSize W43xH25 => new LabelSize() {
            Height = 25, Width = 43, Key = LabelSizeEnum.W43xH25
        };
    }
}
