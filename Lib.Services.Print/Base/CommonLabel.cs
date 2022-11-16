using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public class CommonLabel : ICommonLabel
    {
        public string Title
        {
            get {
                if (Key == CommonLabelEnum.TestLabel) return "Тестовая этикетка";
                if (Key == CommonLabelEnum.ProductLabel) return "Этикетка товара";
                if (Key == CommonLabelEnum.ProductBatchLabel) return "Этикетка партии товара";
                return "<Unsupported label>";
            }
        }

        public CommonLabelEnum Key { get; init; }
    }
}
