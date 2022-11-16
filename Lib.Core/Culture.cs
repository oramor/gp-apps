namespace Lib.Core
{
    public interface ICultureNode
    {
        public string Ru_RU { get; init; }
        public string En_US { get; init; }
    }

    public enum SupportedCulture
    {
        Ru_RU,
        En_US
    }
}