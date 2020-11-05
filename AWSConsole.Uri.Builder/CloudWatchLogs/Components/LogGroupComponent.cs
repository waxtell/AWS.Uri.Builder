using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class LogGroupComponent : ILogsUriComponent
    {
        private readonly string _logGroup;

        public LogGroupComponent(string logGroup)
        {
            _logGroup = logGroup;
        }

        public string Build()
        {
            return
                $"/log-group/{_logGroup.Escape()}";
        }
    }
}