using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class LogStreamNameFilterComponent : ILogsUriComponent
    {
        private readonly string _logStreamNameFilter;

        public LogStreamNameFilterComponent(string logStreamNameFilter)
        {
            _logStreamNameFilter = logStreamNameFilter;
        }

        public string Build()
        {
            return
                "?logStreamNameFilter=".ToHexString("$", true)+
                    $"{_logStreamNameFilter.Escape()}";
        }
    }
}