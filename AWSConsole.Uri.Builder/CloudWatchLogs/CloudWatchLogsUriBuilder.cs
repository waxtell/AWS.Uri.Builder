using System;
using System.Collections.Generic;
using System.Text;
using AWSConsole.Uri.Builder.CloudWatchLogs.Components;

namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public class CloudWatchLogsUriBuilder
    {
        private readonly string _region;
        private readonly IDictionary<string, ILogsUriComponent> _queryComponents = new Dictionary<string, ILogsUriComponent>();

        private const string LogGroup = nameof(LogGroup);
        private const string TimeRange = nameof(TimeRange);
        private const string Filter = nameof(Filter);
        private const string LogStream = nameof(LogStream);
        private const string LogStreamNameFilter = nameof(LogStreamNameFilter);
        private const string LogGroupNameFilter = nameof(LogGroupNameFilter);

        private CloudWatchLogsUriBuilder(string region)
        {
            _region = region;
        }

        public static CloudWatchLogsUriBuilder FromRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new ArgumentException($"{nameof(region)} can not be null or empty!");
            }

            return 
                new CloudWatchLogsUriBuilder(region);
        }

        public CloudWatchLogsUriBuilder WithLogGroup(string logGroup)
        {
            _queryComponents[LogGroup] = new LogGroupComponent(logGroup);

            return this;
        }
        
        public CloudWatchLogsUriBuilder WithLogGroupNameFilter(string logGroupNameFilter)
        {
            _queryComponents[LogGroupNameFilter] = new LogGroupNameFilterComponent(logGroupNameFilter);

            return this;
        }

        public CloudWatchLogsUriBuilder WithLogStream(string logStream)
        {
            _queryComponents[LogStream] = new LogStreamComponent(logStream);

            return this;
        }

        public CloudWatchLogsUriBuilder WithLogStreamNameFilter(string logStreamNameFilter)
        {
            _queryComponents[LogStreamNameFilter] = new LogStreamNameFilterComponent(logStreamNameFilter);

            return this;
        }

        public CloudWatchLogsUriBuilder WithAbsoluteRange(DateTime start, DateTime end)
        {
            _queryComponents[TimeRange] = new AbsoluteTimeRangeComponent(start, end);

            return this;
        }

        public CloudWatchLogsUriBuilder WithRelativeRangeMilliseconds(uint lastMilliseconds)
        {
            _queryComponents[TimeRange] = new RelativeTimeRangeComponent(lastMilliseconds);

            return this;
        }

        public CloudWatchLogsUriBuilder WithFilter(string filter)
        {
            _queryComponents[Filter] = new FilterComponent(filter);

            return this;
        }

        public System.Uri Build()
        {
            var builder = new StringBuilder($"https://{_region}.console.aws.amazon.com/cloudwatch/home?region={_region}#logsV2:log-groups");

            if (_queryComponents.ContainsKey(LogGroup))
            {
                builder.Append(_queryComponents[LogGroup].Build());

                if (_queryComponents.ContainsKey(LogStream))
                {
                    builder.Append(_queryComponents[LogStream].Build());

                    if (_queryComponents.ContainsKey(TimeRange))
                    {
                        builder.Append(_queryComponents[TimeRange].Build());
                    }

                    if (_queryComponents.ContainsKey(Filter))
                    {
                        builder.Append(_queryComponents[Filter].Build());
                    }
                }
                else if (_queryComponents.ContainsKey(LogStreamNameFilter))
                {
                    builder.Append(_queryComponents[LogStreamNameFilter].Build());
                }
            }
            else if (_queryComponents.ContainsKey(LogGroupNameFilter))
            {
                builder.Append(_queryComponents[LogGroupNameFilter].Build());
            }

            return
                new System.Uri(builder.ToString());
       }
    }
}