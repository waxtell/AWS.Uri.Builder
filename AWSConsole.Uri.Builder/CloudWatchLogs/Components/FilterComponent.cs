using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class FilterComponent : ILogsUriComponent
    {
        private readonly string _query;

        public FilterComponent(string query)
        {
            _query = query;
        }

        public string Build()
        {
            return
                "?filterPattern="
                    .ToHexString("$", true) + $"{_query}"
                    .Escape()
                    .Replace(" ", "+");
        }
    }
}