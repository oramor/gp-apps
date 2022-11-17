using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public abstract class BaseLabelTask : IBaseLabelTask
    {
        public required ILabelSetup LabelSetup { get; init; }
        public int Copy { get; init; } = 1;
    }
}
