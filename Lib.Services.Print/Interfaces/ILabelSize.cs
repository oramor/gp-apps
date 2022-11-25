using Lib.Core;

namespace Lib.Services.Print
{
    public interface ILabelSize : IEntity<int>
    {
        public int Height { get; init; }
        public int Width { get; init; }
        public string TsplCommand { get; init; }
    }
}
