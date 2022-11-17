using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public enum LabelSizeEnum
    {
        W43xH25
    }

    public interface ILabelSize
    {
        public string Title { get; }
        public LabelSizeEnum Key { get; init; }
        public int Height { get; init; }
        public int Width { get; init; }
        public string TsplCommand { get; init; }
    }
}
