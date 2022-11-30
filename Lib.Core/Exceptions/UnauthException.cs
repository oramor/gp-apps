namespace Lib.Core
{
    public class UnauthException : Exception
    {
        public UnauthException(string message) : base(message)
        {
        }
    }
}
