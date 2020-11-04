using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class LogStreamComponent : ILogsUriComponent
    {
        private readonly string _logGroup;

        public LogStreamComponent(string logGroup)
        {
            _logGroup = logGroup;
        }

        public string Build()
        {
            return
                $"/log-events/{_logGroup.Escape()}";
        }
    }
}