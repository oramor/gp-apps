using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public interface ICommonLabel
    {
        public string Title { get; }
        public CommonLabelEnum Key { get; init; }
    }
}
