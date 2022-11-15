namespace Lib.Services.Print.Exeptions
{
    public interface ICultureNode
    {
        public string Ru_RU { get; init; }
        public string En_US { get; init; }
        public string En_CA { get; init; }
    }

    public class ExeptionCultureNode : ICultureNode
    {
        public string Ru_RU { get; init; }
        public string En_US { get; init; }
        public string En_CA { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    }

    public static class ExeptionCode
    {
        public static ICultureNode CallPrintDriver => new ExeptionCultureNode() { Ru_RU = "Ошибка на уровне обращения к API драйвера TSC (TscDll)", En_US = "The Error when TSC driver (TscDll) has been called" };
    }

    internal class ServiceExeption : ApplicationException
    {
        private readonly ExeptionCultureNode _level;

        public ServiceExeption(ExeptionCultureNode level, string? message) : base(message)
        {
            _level = level;
        }

        public ExeptionCultureNode Level { get => _level; }
    }
}
