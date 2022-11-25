using Lib.Core;

namespace Lib.Services.Print
{
    public interface ICommonLabel : IEntity<int>
    {
        string Description { get; set; }
    }
}
