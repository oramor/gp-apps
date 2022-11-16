using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public enum SupportedLabelSizeEnum
    {
        W43xH25
    }

    public interface ILabelSize
    {
        public string LabelSizeTitle { get; } // Dynamic generation
        public SupportedLabelSizeEnum LabelSizeId { get; set; }
        public int LabelSizeHeight { get; set; }
        public int LabelSizeWidth { get; set; }
    }
}
