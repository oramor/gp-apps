using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class CommonLabelFactory
    {
        private readonly static ICommonLabel _testLabel = new CommonLabel() {
            Key = CommonLabelEnum.TestLabel
        };

        public static ICommonLabel TestLabel => _testLabel;
    }
}
