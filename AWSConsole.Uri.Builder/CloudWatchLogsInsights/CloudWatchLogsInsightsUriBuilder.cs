using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components;
using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights
{
    public class CloudWatchLogsInsightsUriBuilder
    {
        private readonly string _region;
        private readonly IDictionary<string, IInsightUriComponent> _queryComponents = new Dictionary<string, IInsightUriComponent>();

        private const string LiveTail = nameof(LiveTail);
        private const string LogGroups = nameof(LogGroups);
        private const string TimeRange = nameof(TimeRange);
        private const string Query = nameof(Query);

        private CloudWatchLogsInsightsUriBuilder(string region)
        {
            _region = region;
            _queryComponents[LiveTail] = new LiveTailComponent(false);
        }

        public static CloudWatchLogsInsightsUriBuilder FromRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new ArgumentException($"{nameof(region)} can not be null or empty!");
            }

            return 
                new CloudWatchLogsInsightsUriBuilder(region);
        }

        public CloudWatchLogsInsightsUriBuilder WithLiveTail(bool liveTail)
        {
            _queryComponents[LiveTail] = new LiveTailComponent(liveTail);

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithLogGroups(params string[] logGroups)
        {
            if (logGroups != null && logGroups.Any(logGroup => !string.IsNullOrWhiteSpace(logGroup)))
            {
                _queryComponents[LogGroups] = new LogGroupsComponent(logGroups);
            }
            else if (_queryComponents.ContainsKey(LogGroups))
            {
                _queryComponents.Remove(LogGroups);
            }

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithAbsoluteRange(DateTime start, DateTime end, TimeZoneType timeZoneType)
        {
            _queryComponents[TimeRange] = new AbsoluteTimeRangeComponent(start, end, timeZoneType);

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithRelativeRange(uint lastSeconds)
        {
            _queryComponents[TimeRange] = new RelativeTimeRangeComponent(lastSeconds);

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithQuery(string query)
        {
            _queryComponents[Query] = new EditorStringComponent(query);

            return this;
        }

        public System.Uri Build()
        {
            var builder =
                new StringBuilder($"https://{_region}.console.aws.amazon.com/cloudwatch/home?region={_region}#logsV2:logs-insights");

            if (_queryComponents.Any())
            {
                builder
                    .Append("?queryDetail=".ToHexString("$", true))
                    .Append("=(".Escape())
                    .Append
                    (
                        string
                            .Join
                            (
                                "=".Escape(),
                                _queryComponents.Values.Select(component => component.Build())
                            )
                    )
                    .Append(")".Escape());
            }

            return 
                new System.Uri(builder.ToString());
       }
    }
}