using Lib.Services.Print.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class LabelSizeFactory
    {
        private readonly static ILabelSize _W43xH25 = new LabelSize() {
            Height = 25,
            Width = 43,
            Key = LabelSizeEnum.W43xH25,
            TsplCommand = "SIZE 43 mm, 25 mm"
        };

        public static ILabelSize W43xH25 => _W43xH25;
    }
}
