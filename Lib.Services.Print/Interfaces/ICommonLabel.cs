using Lib.Core;

namespace Lib.Services.Print
{
    public interface ICommonLabel : IEntity
    {
        string Description { get; set; }
    }
}
