using System.Collections.Generic;
using System.Linq;
using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components
{
    internal class LogGroupsComponent : IInsightUriComponent
    {
        private readonly string[] _logGroups;

        public LogGroupsComponent(IEnumerable<string> logGroups)
        {
            _logGroups = logGroups
                ?.Where(logGroup => !string.IsNullOrWhiteSpace(logGroup))
                .ToArray();
        }

        public string Build()
        {
            return
                $"source=(='{string.Join("='", _logGroups.Select(logGroup => logGroup.ToHexString()))})"
                    .Escape();
        }
    }
}