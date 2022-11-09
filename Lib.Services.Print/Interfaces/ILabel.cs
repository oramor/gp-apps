namespace Lib.Services.Print.Interfaces
{
    internal interface ILabel<T>
    {
        public void PrintWithTscLib(T args);
    }
}
