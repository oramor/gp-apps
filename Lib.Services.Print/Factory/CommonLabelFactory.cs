using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class CommonLabelFactory
    {
        public static ICommonLabel TestLabel => new CommonLabel() {
            Key = CommonLabelEnum.TestLabel
        };
    }
}
