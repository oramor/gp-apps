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
        public string Title { get; } // Dynamic generation
        public SupportedLabelSizeEnum LabelSizeId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
