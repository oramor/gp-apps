namespace Lib.Core
{
    public class LocalizedException : Exception
    {
        private readonly ICultureNode _node;

        public LocalizedException(ICultureNode node, string message = "") : base(message)
        {
            _node = node;
        }

        public string GetLocalizeMessage(SupportedCulture culture)
        {
            if (culture == SupportedCulture.Ru_RU) return _node.Ru_RU;
            if (culture == SupportedCulture.En_US) return _node.En_US;

            return _node.Ru_RU; // default lang
        }
    }
}
