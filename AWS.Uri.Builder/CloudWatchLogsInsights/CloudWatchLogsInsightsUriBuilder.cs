using System;
using System.Linq;
using System.Text;
using AWS.Uri.Builder.Extensions;

namespace AWS.Uri.Builder.CloudWatchLogsInsights
{
    public class CloudWatchLogsInsightsUriBuilder
    {
        private readonly string _region;
        private DateTime? _start;
        private DateTime? _end;
        private TimeZone? _timeZone;
        private string _query;
        private string[] _logGroups;
        private TimeReferenceType _timeType;
        private bool _liveTail;

        private CloudWatchLogsInsightsUriBuilder(string region)
        {
            _region = region;
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
            _liveTail = liveTail;

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithLogGroups(params string[] logGroups)
        {
            _logGroups = logGroups
                            ?.Where(logGroup => !string.IsNullOrWhiteSpace(logGroup))
                            .ToArray();

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithAbsoluteRange(DateTime start, DateTime end, TimeZone timeZone)
        {
            _start = start;
            _end = end;
            _timeZone = timeZone;
            _timeType = TimeReferenceType.Absolute;

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithQuery(string query)
        {
            _query = query;

            return this;
        }

        public System.Uri Build()
        {
            var builder =
                new StringBuilder($"https://{_region}.console.aws.amazon.com/cloudwatch/home?region={_region}#logsV2:logs-insights");

            builder.Append("?queryDetail=".ToHexString("$", true));

            builder.Append("=(".Escape());

            if (_end.HasValue && _start.HasValue && _timeZone.HasValue)
            {
                builder
                    .Append
                    (
                        $"end='{_end.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ").ToHexString()}=start='{_start.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ").ToHexString()}=timeType='{_timeType.TryGetName()?.ToUpper()}=tz='{_timeZone.Value.TryGetName()}"
                            .Escape()
                    );
            }

            if (!string.IsNullOrEmpty(_query))
            {
                builder.Append("=editorString='".Escape());
                builder.Append($"{_query}\n".ToHexString("*", false, false));
            }

            builder.Append($"=isLiveTail={_liveTail.ToString().ToLower()}".Escape());

            if (_logGroups != null && _logGroups.Any())
            {
                builder
                    .Append
                    (
                        $"=source=(='{string.Join("='", _logGroups.Select(logGroup => logGroup.ToHexString()))})"
                            .Escape()
                    );
            }

            builder.Append(")".Escape());

            return 
                new System.Uri(builder.ToString());
       }
    }
}