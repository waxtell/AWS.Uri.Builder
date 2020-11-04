using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class LogGroupNameFilterComponent : ILogsUriComponent
    {
        private readonly string _logGroupNameFilter;

        public LogGroupNameFilterComponent(string logGroupNameFilter)
        {
            _logGroupNameFilter = logGroupNameFilter;
        }

        public string Build()
        {
            return
                "?logGroupNameFilter=".ToHexString("$", true)+
                    $"{_logGroupNameFilter.Escape()}";
        }
    }
}